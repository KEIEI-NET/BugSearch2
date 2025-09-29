//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : SCM����񓚗����Ɖ�
// �v���O�����T�v   : SCM�󒍃f�[�^�ASCM�󒍖��׃f�[�^�̏Ɖ���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �� �� ��  2009/05/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCM����񓚗����Ɖ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM�󒍃f�[�^�ASCM�󒍖��׃f�[�^�̏Ɖ���s��</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2009.05.27</br>
    /// <br></br>
    public partial class PMSCM04101UA : Form
    {
        #region ��private�萔
        // ��ʏ�ԕۑ��p�t�@�C����
        private const string XML_FILE_INITIAL_DATA = "PMSCM04101U.dat";

        //�G���[�������b�Z�[�W
        private const string ct_InputError = "�̓��͂��s���ł�";
        private const string ct_NoInput = "����͂��ĉ�����";
        private const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
        #endregion

        #region ��private�ϐ�
        // ���ʃX�L��
        private ControlScreenSkin _controlScreenSkin;

        // ���O�C����ƃR�[�h
        private string _enterpriseCode;
        // ���O�C�����_�R�[�h
        private string _sectionCode;

        private readonly Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionTitleLabel;   // ���O�C�����_�^�C�g��
        private readonly Infragistics.Win.UltraWinToolbars.LabelTool _loginSectionNameLabel;	// ���O�C�����_����
        private readonly Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;		    // ���O�C���S���҃^�C�g��
        private readonly Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;			// ���O�C���S���Җ���

        // �O���b�h��ԕۑ�
        private GridStateController _gridStateController;

        #region �A�N�Z�X�N���X
        // ����񓚗����Ɖ�A�N�Z�X�N���X
        private SCMAnsHistInquiryAsc _scmAnsHistInquiryAcs;
        // ���t���i
        private DateGetAcs _dateGet;
        // ���_�K�C�h
        private SecInfoSetAcs _secInfoSetAcs;
        // ���[�J�[�K�C�h
        private MakerAcs _makerAcs;
        // BL�R�[�h�K�C�h
        private BLGoodsCdAcs _blGoodsCdAcs;
        // �Ԏ�K�C�h
        private ModelNameUAcs _modelNameUAcs;
        #endregion

        #region �O����͒l
        private string _beforeSectionCode; // ���_�R�[�h
        private int _beforeMakerCode; // ���[�J�[�R�[�h
        private int _beforeBLGoodsCode; // BL�R�[�h
        private int _beforeMakerCodeCar; // ���[�J�[�R�[�h(�ԗ����)
        private int _beforeModelCode; // �Ԏ�R�[�h
        private int _beforeModelSubCode; // �Ԏ�T�u�R�[�h
        private string _beforeGoodsNo; // ���i�ԍ�
        private string _beforePureGoodsNo; // �������i�ԍ�
        #endregion

        #region ���Ӑ�K�C�h�p
        // �����K�C�h�{�^��
        private UltraButton _customerGuideSender;
        #endregion

        #endregion

        #region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMSCM04101UA()
        {
            InitializeComponent();

            #region ���O�C�����

            // �����o�ɕێ�
            _loginSectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginSectionTitle"];
            _loginSectionNameLabel  = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginSectionName"];
            _loginTitleLabel        = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginTitle"];
            _loginNameLabel         = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager1.Tools["LabelTool_LoginName"];

            // �A�C�R����ݒ�
            _loginSectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image   = Size16_Index.BASE;
            _loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image          = Size16_Index.EMPLOYEE;

            // ���O�C������ݒ�
            string loginSectionName = string.Empty;
            string loginEmployeeName= string.Empty;
            if (LoginInfoAcquisition.Employee != null)
            {
                loginSectionName = LoginInfoAcquisition.Employee.BelongSectionName;
                loginEmployeeName= LoginInfoAcquisition.Employee.Name;
            }
            _loginSectionNameLabel.SharedProps.Caption  = loginSectionName;
            _loginNameLabel.SharedProps.Caption         = loginEmployeeName;

            #endregion // ���O�C�����
        }
        #endregion

        #region ��public���\�b�h
        #region XML����
        /// <summary>
        /// �w�l�k�f�[�^�̕ۑ�����
        /// </summary>
        public void SaveStateXmlData()
        {
            // �O���b�h����ۑ�
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion
        #endregion

        #region ��private���\�b�h
        #region �����ݒ�
        /// <summary>
        /// �K�C�h�A�N�Z�X������
        /// </summary>
        private void GetGuideInstance()
        {
            this._scmAnsHistInquiryAcs = SCMAnsHistInquiryAsc.GetInstance();
            this._dateGet = DateGetAcs.GetInstance();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._modelNameUAcs = new ModelNameUAcs();
        }

        /// <summary>
        /// ���������s��
        /// </summary>
        private void SetInitialSetting()
        {
            // �K�C�h�A�N�Z�X������
            this.GetGuideInstance();

            this._gridStateController = new GridStateController();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;�@// ����ƃR�[�h
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0'); // �����_�R�[�h

            this._controlScreenSkin = new ControlScreenSkin();

            // �X�L���ύX���O�ݒ�
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
            excCtrlNm.Add(this.uGroupBox_DetailInfo.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // �c�[���o�[�A�C�R���ݒ�
            tToolbarsManager1.ImageListSmall = IconResourceManagement.ImageList16;
            this.tToolbarsManager1.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this.tToolbarsManager1.Tools["ButtonTool_Search"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            this.tToolbarsManager1.Tools["ButtonTool_Clear"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;

            // �K�C�h�{�^���ݒ�
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SectionCdGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerCdGuideSt.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_CustomerCdGuideEd.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_GoodsMakerCdGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_BLGoodsCdGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.uButton_ModelFullGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            // �O���b�h�ݒ�
            this.SetGridSetting();
        }

        /// <summary>
        /// �������ڐݒ�
        /// </summary>
        private void ClearScreen()
        {
            // �O��ݒ�l��������
            this._beforeSectionCode = string.Empty; // ���_�R�[�h
            this._beforeMakerCode = 0; // ���[�J�[�R�[�h
            this._beforeBLGoodsCode = 0; // BL�R�[�h
            this._beforeMakerCodeCar = 0; // ���[�J�[�R�[�h(�ԗ����)
            this._beforeModelCode = 0; // �Ԏ�R�[�h
            this._beforeModelSubCode = 0; // �Ԏ�T�u�R�[�h
            this._beforeGoodsNo = string.Empty; // ���i�ԍ�
            this._beforePureGoodsNo = string.Empty; // �������i�ԍ�

            // �⍇����
            tde_InquiryDateSt.SetLongDate(0);
            tde_InquiryDateEd.SetLongDate(0);

            // ���_
            this.tEdit_SectionCodeAllowZero.Text = string.Empty;
            this.uLabel_SectionName.Text = string.Empty;

            // ���Ӑ�
            this.tNedit_CustomerCode_St.SetInt(0);
            this.tNedit_CustomerCode_Ed.SetInt(0);

            // �񓚕��@
            this.uCheckEditor_AnswerMethodAll.Checked = true; // �S��
            this.uCheckEditor_AnswerMethodAuto.Checked = false; // ����
            this.uCheckEditor_AnswerMethodManual.Checked = false; // �蓮

            // �`�[�ԍ�(�󒍃X�e�[�^�X)
            this.uCheckEditor_AcptAnOdrStatusAll.Checked = true; // �S��
            this.uCheckEditor_AcptAnOdrStatusSales.Checked = false; // ����
            this.uCheckEditor_AcptAnOdrStatusAccept.Checked = false; // ��
            this.uCheckEditor_AcptAnOdrStatusEstimate.Checked = false; // ����

            // �`�[�ԍ�
            this.tEdit_SalesSlipNum_St.Text = string.Empty;
            this.tEdit_SalesSlipNum_Ed.Text = string.Empty;

            // �⍇���ԍ�(�⍇���E�������)
            this.uCheckEditor_InqOrdDivAll.Checked = true; // �S��
            this.uCheckEditor_InqOrdDivAccept.Checked = false; // ��
            this.uCheckEditor_InqOrdDivEstimate.Checked = false; // ����

            // �⍇���ԍ�
            this.tNedit_InquiryNumber_St.SetInt(0);
            this.tNedit_InquiryNumber_Ed.SetInt(0);

            // �ԗ��o�^�ԍ�(�v���[�g�ԍ�)
            this.tNedit_NumberPlate4.SetInt(0);
            // �^��
            this.tEdit_FullModel.DataText = string.Empty;
            // �Ԏ�(���[�J�[)
            this.tNedit_CarMakerCode.SetInt(0);
            // �Ԏ�R�[�h
            this.tNedit_ModelCode.SetInt(0);
            // �Ԏ�T�u�R�[�h
            this.tNedit_ModelSubCode.SetInt(0);
            // �Ԏ햼
            this.tEdit_ModelFullName.DataText = string.Empty;

            // ���[�J�[
            this.tNedit_GoodsMakerCd.SetInt(0);
            // BL�R�[�h
            this.tNedit_BLGoodsCode.SetInt(0);
            // �i��
            this.tEdit_GoodsNo.DataText = string.Empty;
            // �����i��
            this.tEdit_PureGoodsNo.DataText = string.Empty;
        }

        /// <summary>
        /// �O���b�h�ݒ�
        /// </summary>
        private void SetGridSetting()
        {
            // �f�[�^�\�[�X�ݒ�
            this.uGrid_Details.DataSource = this._scmAnsHistInquiryAcs.SCMAnsHistInquiryDataTable;

            // �O�ϕ\���ݒ�
            this.uGrid_Details.BeginUpdate();

            try
            {
                ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

                foreach (UltraGridColumn col in columns)
                {
                    // �S�񋤒ʐݒ�
                    // �\���ʒu(vertical)
                    col.CellAppearance.TextVAlign = VAlign.Middle;

                    // �N���b�N���͍s�Z���N�g
                    col.CellClickAction = CellClickAction.RowSelect;

                    // �ҏW�s��
                    col.CellActivation = Activation.Disabled;
                    
                    // �S�Ă̗�����������\���ɂ���B
                    col.Hidden = true;
                }

                SCMAcOdrDataDataSet.SCMAnsHistInquiryDataTable table = this._scmAnsHistInquiryAcs.SCMAnsHistInquiryDataTable;

                // �Œ��ݒ�(�s�ԍ���̂�)
                columns[table.RowNumberColumn.ColumnName].Header.Fixed = true;

                // �s�ԍ���̃Z���\���F�ύX
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
                columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColor = Color.White;
                columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;

                int visiblePosition = 0;

                #region �J�����ݒ�
                // No.��
                columns[table.RowNumberColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.RowNumberColumn.ColumnName].Header.Caption = "No."; // ��L���v�V����
                columns[table.RowNumberColumn.ColumnName].Width = 50; // �\����
                columns[table.RowNumberColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.RowNumberColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                #region �󒍃f�[�^
                // ���_
                columns[table.InqOtherSecCdColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.InqOtherSecCdColumn.ColumnName].Header.Caption = "���_"; // ��L���v�V����
                columns[table.InqOtherSecCdColumn.ColumnName].Width = 70; // �\����
                columns[table.InqOtherSecCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.InqOtherSecCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ���_��
                columns[table.InqOtherSecNmColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.InqOtherSecNmColumn.ColumnName].Header.Caption = "���_��"; // ��L���v�V����
                columns[table.InqOtherSecNmColumn.ColumnName].Width = 100; // �\����
                columns[table.InqOtherSecNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.InqOtherSecNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �⍇���ԍ�
                columns[table.InquiryNumberColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.InquiryNumberColumn.ColumnName].Header.Caption = "�⍇���ԍ�"; // ��L���v�V����
                columns[table.InquiryNumberColumn.ColumnName].Width = 100; // �\����
                columns[table.InquiryNumberColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.InquiryNumberColumn.ColumnName].Format = "0000000000";
                columns[table.InquiryNumberColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ���Ӑ�
                columns[table.CustomerCodeColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.CustomerCodeColumn.ColumnName].Header.Caption = "���Ӑ�"; // ��L���v�V����
                columns[table.CustomerCodeColumn.ColumnName].Width = 100; // �\����
                columns[table.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.CustomerCodeColumn.ColumnName].Format = "00000000";
                columns[table.CustomerCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ���Ӑ於
                columns[table.CustomerNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.CustomerNameColumn.ColumnName].Header.Caption = "���Ӑ於"; // ��L���v�V����
                columns[table.CustomerNameColumn.ColumnName].Width = 120; // �\����
                columns[table.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.CustomerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �X�V����
                columns[table.UpdateDateTimeForDispColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.UpdateDateTimeForDispColumn.ColumnName].Header.Caption = "�X�V����"; // ��L���v�V����
                columns[table.UpdateDateTimeForDispColumn.ColumnName].Width = 200; // �\����
                columns[table.UpdateDateTimeForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.UpdateDateTimeForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �񓚋敪
                columns[table.AnswerDivNmColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.AnswerDivNmColumn.ColumnName].Header.Caption = "�񓚋敪"; // ��L���v�V����
                columns[table.AnswerDivNmColumn.ColumnName].Width = 150; // �\����
                columns[table.AnswerDivNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.AnswerDivNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �m���
                //columns[table.JudgementDateForDispColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.JudgementDateForDispColumn.ColumnName].Header.Caption = "�m���"; // ��L���v�V����
                //columns[table.JudgementDateForDispColumn.ColumnName].Width = 100; // �\����
                //columns[table.JudgementDateForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.JudgementDateForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �⍇���E�������l
                //columns[table.InqOrdNoteColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.InqOrdNoteColumn.ColumnName].Header.Caption = "�⍇���E�������l"; // ��L���v�V����
                //columns[table.InqOrdNoteColumn.ColumnName].Width = 150; // �\����
                //columns[table.InqOrdNoteColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.InqOrdNoteColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �⍇���]�ƈ��R�[�h
                columns[table.InqEmployeeCdColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.InqEmployeeCdColumn.ColumnName].Header.Caption = "�⍇���S����"; // ��L���v�V����
                columns[table.InqEmployeeCdColumn.ColumnName].Width = 170; // �\����
                columns[table.InqEmployeeCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.InqEmployeeCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �⍇���]�ƈ�����
                columns[table.InqEmployeeNmColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.InqEmployeeNmColumn.ColumnName].Header.Caption = "�⍇���S���Җ�"; // ��L���v�V����
                columns[table.InqEmployeeNmColumn.ColumnName].Width = 150; // �\����
                columns[table.InqEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.InqEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �񓚏]�ƈ��R�[�h
                columns[table.AnsEmployeeCdColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.AnsEmployeeCdColumn.ColumnName].Header.Caption = "�S����"; // ��L���v�V����
                columns[table.AnsEmployeeCdColumn.ColumnName].Width = 170; // �\����
                columns[table.AnsEmployeeCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.AnsEmployeeCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �񓚏]�ƈ�����
                columns[table.AnsEmployeeNmColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.AnsEmployeeNmColumn.ColumnName].Header.Caption = "�S���Җ�"; // ��L���v�V����
                columns[table.AnsEmployeeNmColumn.ColumnName].Width = 150; // �\����
                columns[table.AnsEmployeeNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.AnsEmployeeNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �⍇����
                columns[table.InquiryDateForDispColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.InquiryDateForDispColumn.ColumnName].Header.Caption = "�⍇����"; // ��L���v�V����
                columns[table.InquiryDateForDispColumn.ColumnName].Width = 150; // �\����
                columns[table.InquiryDateForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.InquiryDateForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ����`�[���v�i�ō��݁j
                columns[table.SalesTotalTaxIncColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.SalesTotalTaxIncColumn.ColumnName].Header.Caption = "���z"; // ��L���v�V����
                columns[table.SalesTotalTaxIncColumn.ColumnName].Width = 200; // �\����
                columns[table.SalesTotalTaxIncColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.SalesTotalTaxIncColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesTotalTaxIncColumn.ColumnName].Format = "#,##0";

                // ���㏬�v�i�Łj
                columns[table.SalesSubtotalTaxColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.SalesSubtotalTaxColumn.ColumnName].Header.Caption = "�����"; // ��L���v�V����
                columns[table.SalesSubtotalTaxColumn.ColumnName].Width = 150; // �\����
                columns[table.SalesSubtotalTaxColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.SalesSubtotalTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesSubtotalTaxColumn.ColumnName].Format = "#,##0";

                // �┭�E�񓚎��
                columns[table.InqOrdAnsDivNmColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.InqOrdAnsDivNmColumn.ColumnName].Header.Caption = "�┭�E�񓚋敪"; // ��L���v�V����
                columns[table.InqOrdAnsDivNmColumn.ColumnName].Width = 150; // �\����
                columns[table.InqOrdAnsDivNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.InqOrdAnsDivNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ��M����
                columns[table.ReceiveDateTimeForDispColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.ReceiveDateTimeForDispColumn.ColumnName].Header.Caption = "��M����"; // ��L���v�V����
                columns[table.ReceiveDateTimeForDispColumn.ColumnName].Width = 170; // �\����
                columns[table.ReceiveDateTimeForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.ReceiveDateTimeForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                #endregion

                #region �ԗ����
                //// ���^�������ԍ�
                //columns[table.NumberPlate1CodeColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.NumberPlate1CodeColumn.ColumnName].Header.Caption = "���^�������ԍ�"; // ��L���v�V����
                //columns[table.NumberPlate1CodeColumn.ColumnName].Width = 150; // �\����
                //columns[table.NumberPlate1CodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.NumberPlate1CodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// ���^�����ǖ���
                //columns[table.NumberPlate1NameColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.NumberPlate1NameColumn.ColumnName].Header.Caption = "���^�����ǖ���"; // ��L���v�V����
                //columns[table.NumberPlate1NameColumn.ColumnName].Width = 150; // �\����
                //columns[table.NumberPlate1NameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.NumberPlate1NameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// ���^�����ǖ���
                //columns[table.NumberPlate1NameColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.NumberPlate1NameColumn.ColumnName].Header.Caption = "���^�����ǖ���"; // ��L���v�V����
                //columns[table.NumberPlate1NameColumn.ColumnName].Width = 150; // �\����
                //columns[table.NumberPlate1NameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.NumberPlate1NameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �ԗ��o�^�ԍ��i��ʁj
                //columns[table.NumberPlate2Column.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.NumberPlate2Column.ColumnName].Header.Caption = "�ԗ��o�^�ԍ��i��ʁj"; // ��L���v�V����
                //columns[table.NumberPlate2Column.ColumnName].Width = 200; // �\����
                //columns[table.NumberPlate2Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.NumberPlate2Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �ԗ��o�^�ԍ��i�J�i�j
                //columns[table.NumberPlate3Column.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.NumberPlate3Column.ColumnName].Header.Caption = "�ԗ��o�^�ԍ��i�J�i�j"; // ��L���v�V����
                //columns[table.NumberPlate3Column.ColumnName].Width = 200; // �\����
                //columns[table.NumberPlate3Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.NumberPlate3Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                //columns[table.NumberPlate4Column.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.NumberPlate4Column.ColumnName].Header.Caption = "�ԗ��o�^�ԍ��i�v���[�g�ԍ��j"; // ��L���v�V����
                //columns[table.NumberPlate4Column.ColumnName].Width = 250; // �\����
                //columns[table.NumberPlate4Column.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.NumberPlate4Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �v���[�gNo
                columns[table.PlateNoColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.PlateNoColumn.ColumnName].Header.Caption = "�ԗ��o�^�ԍ��i�v���[�g�ԍ��j"; // ��L���v�V����
                columns[table.PlateNoColumn.ColumnName].Width = 250; // �\����
                columns[table.PlateNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.PlateNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �^���w��ԍ�
                //columns[table.ModelDesignationNoColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.ModelDesignationNoColumn.ColumnName].Header.Caption = "�^���w��ԍ�"; // ��L���v�V����
                //columns[table.ModelDesignationNoColumn.ColumnName].Width = 150; // �\����
                //columns[table.ModelDesignationNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.ModelDesignationNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �ޕʔԍ�
                //columns[table.CategoryNoColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.CategoryNoColumn.ColumnName].Header.Caption = "�ޕʔԍ�"; // ��L���v�V����
                //columns[table.CategoryNoColumn.ColumnName].Width = 100; // �\����
                //columns[table.CategoryNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.CategoryNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �ޕ�
                columns[table.ModelCategoryColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.ModelCategoryColumn.ColumnName].Header.Caption = "�ޕ�"; // ��L���v�V����
                columns[table.ModelCategoryColumn.ColumnName].Width = 150; // �\����
                columns[table.ModelCategoryColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.ModelCategoryColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// ���[�J�[�R�[�h(�ԗ����)
                //columns[table.MakerCodeCarColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.MakerCodeCarColumn.ColumnName].Header.Caption = "���[�J�[(�ԗ�)"; // ��L���v�V����
                //columns[table.MakerCodeCarColumn.ColumnName].Width = 150; // �\����
                //columns[table.MakerCodeCarColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.MakerCodeCarColumn.ColumnName].Format = "0000";
                //columns[table.MakerCodeCarColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// ���[�J�[��(�ԗ����)
                //columns[table.MakerNameCarColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.MakerNameCarColumn.ColumnName].Header.Caption = "���[�J�[��(�ԗ�)"; // ��L���v�V����
                //columns[table.MakerNameCarColumn.ColumnName].Width = 170; // �\����
                //columns[table.MakerNameCarColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.MakerNameCarColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �Ԏ�R�[�h
                //columns[table.ModelCodeColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.ModelCodeColumn.ColumnName].Header.Caption = "�Ԏ�R�[�h"; // ��L���v�V����
                //columns[table.ModelCodeColumn.ColumnName].Width = 100; // �\����
                //columns[table.ModelCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.ModelCodeColumn.ColumnName].Format = "000";
                //columns[table.ModelCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �Ԏ�T�u�R�[�h
                //columns[table.ModelSubCodeColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.ModelSubCodeColumn.ColumnName].Header.Caption = "�Ԏ�T�u�R�[�h"; // ��L���v�V����
                //columns[table.ModelSubCodeColumn.ColumnName].Width = 150; // �\����
                //columns[table.ModelSubCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.ModelSubCodeColumn.ColumnName].Format = "000";
                //columns[table.ModelSubCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �Ԏ햼
                columns[table.ModelNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.ModelNameColumn.ColumnName].Header.Caption = "�Ԏ햼"; // ��L���v�V����
                columns[table.ModelNameColumn.ColumnName].Width = 150; // �\����
                columns[table.ModelNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.ModelNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �Ԍ��،^��
                //columns[table.CarInspectCertModelColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.CarInspectCertModelColumn.ColumnName].Header.Caption = "�Ԍ��،^��"; // ��L���v�V����
                //columns[table.CarInspectCertModelColumn.ColumnName].Width = 150; // �\����
                //columns[table.CarInspectCertModelColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.CarInspectCertModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �^���i�t���^�j
                columns[table.FullModelColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.FullModelColumn.ColumnName].Header.Caption = "�^��"; // ��L���v�V����
                columns[table.FullModelColumn.ColumnName].Width = 150; // �\����
                columns[table.FullModelColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.FullModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // UNDONE:�ԑ�ԍ�
                columns[table.FrameNoColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.FrameNoColumn.ColumnName].Header.Caption = "�ԑ�ԍ�"; // ��L���v�V����
                columns[table.FrameNoColumn.ColumnName].Width = 100; // �\����
                columns[table.FrameNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.FrameNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �ԑ�^��
                //columns[table.FrameModelColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.FrameModelColumn.ColumnName].Header.Caption = "�ԑ�^��"; // ��L���v�V����
                //columns[table.FrameModelColumn.ColumnName].Width = 100; // �\����
                //columns[table.FrameModelColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.FrameModelColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �V���V�[No
                //columns[table.ChassisNoColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.ChassisNoColumn.ColumnName].Header.Caption = "�V���V�[No"; // ��L���v�V����
                //columns[table.ChassisNoColumn.ColumnName].Width = 100; // �\����
                //columns[table.ChassisNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.ChassisNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �ԗ��ŗL�ԍ�
                // ����:�\�����Ă͂����Ȃ�����
                //columns[table.CarProperNoColumn.ColumnName].Hidden = false; // �\���ݒ�
                //columns[table.CarProperNoColumn.ColumnName].Header.Caption = "�ԗ��ŗL�ԍ�"; // ��L���v�V����
                //columns[table.CarProperNoColumn.ColumnName].Width = 150; // �\����
                //columns[table.CarProperNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.CarProperNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ���Y�N��
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].Header.Caption = "�N��"; // ��L���v�V����
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].Width = 150; // �\����
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.ProduceTypeOfYearStringColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �R�����g
                columns[table.CommentColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.CommentColumn.ColumnName].Header.Caption = "�R�����g"; // ��L���v�V����
                columns[table.CommentColumn.ColumnName].Width = 100; // �\����
                columns[table.CommentColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.CommentColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ���y�A�J���[�R�[�h
                columns[table.RpColorCodeColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.RpColorCodeColumn.ColumnName].Header.Caption = "�J���["; // ��L���v�V����
                columns[table.RpColorCodeColumn.ColumnName].Width = 200; // �\����
                columns[table.RpColorCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.RpColorCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �J���[����1
                columns[table.ColorName1Column.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.ColorName1Column.ColumnName].Header.Caption = "�J���[����"; // ��L���v�V����
                columns[table.ColorName1Column.ColumnName].Width = 100; // �\����
                columns[table.ColorName1Column.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.ColorName1Column.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �g�����R�[�h
                columns[table.TrimCodeColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.TrimCodeColumn.ColumnName].Header.Caption = "�g����"; // ��L���v�V����
                columns[table.TrimCodeColumn.ColumnName].Width = 150; // �\����
                columns[table.TrimCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.TrimCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �g��������
                columns[table.TrimNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.TrimNameColumn.ColumnName].Header.Caption = "�g��������"; // ��L���v�V����
                columns[table.TrimNameColumn.ColumnName].Width = 100; // �\����
                columns[table.TrimNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.TrimNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �ԗ����s����
                columns[table.MileageColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.MileageColumn.ColumnName].Header.Caption = "�ԗ����s����"; // ��L���v�V����
                columns[table.MileageColumn.ColumnName].Width = 150; // �\����
                columns[table.MileageColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.MileageColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �����I�u�W�F�N�g
                //columns[table.EquipObjColumn.ColumnName].Hidden = false; // �\���ݒ�
                //columns[table.EquipObjColumn.ColumnName].Header.Caption = "�����I�u�W�F�N�g"; // ��L���v�V����
                //columns[table.EquipObjColumn.ColumnName].Width = 200; // �\����
                //columns[table.EquipObjColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.EquipObjColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                #endregion

                #region �󒍖��׃f�[�^

                // �⍇���s�ԍ�
                columns[table.InqRowNumberColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.InqRowNumberColumn.ColumnName].Header.Caption = "�⍇���sNo"; // ��L���v�V����
                columns[table.InqRowNumberColumn.ColumnName].Width = 150; // �\����
                columns[table.InqRowNumberColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.InqRowNumberColumn.ColumnName].Format = "00";
                columns[table.InqRowNumberColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �⍇���s�ԍ��}��
                //columns[table.InqRowNumDerivedNoColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.InqRowNumDerivedNoColumn.ColumnName].Header.Caption = "�⍇���s�ԍ��}��"; // ��L���v�V����
                //columns[table.InqRowNumDerivedNoColumn.ColumnName].Width = 200; // �\����
                //columns[table.InqRowNumDerivedNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.InqRowNumDerivedNoColumn.ColumnName].Format = "00";
                //columns[table.InqRowNumDerivedNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ���i���
                columns[table.GoodsDivNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.GoodsDivNameColumn.ColumnName].Header.Caption = "���i���"; // ��L���v�V����
                columns[table.GoodsDivNameColumn.ColumnName].Width = 100; // �\����
                columns[table.GoodsDivNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.GoodsDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ���T�C�N�����i���
                columns[table.RecyclePrtKindNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.RecyclePrtKindNameColumn.ColumnName].Header.Caption = "���T�C�N���敪"; // ��L���v�V����
                columns[table.RecyclePrtKindNameColumn.ColumnName].Width = 200; // �\����
                columns[table.RecyclePrtKindNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.RecyclePrtKindNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �[�i�敪
                //columns[table.DeliveredGoodsDivNameColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.DeliveredGoodsDivNameColumn.ColumnName].Header.Caption = "�[�i�敪"; // ��L���v�V����
                //columns[table.DeliveredGoodsDivNameColumn.ColumnName].Width = 100; // �\����
                //columns[table.DeliveredGoodsDivNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.DeliveredGoodsDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �戵�敪
                //columns[table.HandleDivCodeNameColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.HandleDivCodeNameColumn.ColumnName].Header.Caption = "�戵�敪"; // ��L���v�V����
                //columns[table.HandleDivCodeNameColumn.ColumnName].Width = 100; // �\����
                //columns[table.HandleDivCodeNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.HandleDivCodeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// ���i�`��
                //columns[table.GoodsShapeNameColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.GoodsShapeNameColumn.ColumnName].Header.Caption = "���i�`��"; // ��L���v�V����
                //columns[table.GoodsShapeNameColumn.ColumnName].Width = 100; // �\����
                //columns[table.GoodsShapeNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.GoodsShapeNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �[�i�m�F�敪
                //columns[table.DelivrdGdsConfNmColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.DelivrdGdsConfNmColumn.ColumnName].Header.Caption = "�[�i�m�F�敪"; // ��L���v�V����
                //columns[table.DelivrdGdsConfNmColumn.ColumnName].Width = 150; // �\����
                //columns[table.DelivrdGdsConfNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.DelivrdGdsConfNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �[�i�����\���
                //columns[table.DeliGdsCmpltDueDateForDispColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.DeliGdsCmpltDueDateForDispColumn.ColumnName].Header.Caption = "�[�i�����\���"; // ��L���v�V����
                //columns[table.DeliGdsCmpltDueDateForDispColumn.ColumnName].Width = 200; // �\����
                //columns[table.DeliGdsCmpltDueDateForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.DeliGdsCmpltDueDateForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �񓚔[��
                columns[table.AnswerDeliveryDateColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.AnswerDeliveryDateColumn.ColumnName].Header.Caption = "�񓚔[��"; // ��L���v�V����
                columns[table.AnswerDeliveryDateColumn.ColumnName].Width = 100; // �\����
                columns[table.AnswerDeliveryDateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.AnswerDeliveryDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // BL���i�R�[�h
                columns[table.BLGoodsCodeColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.BLGoodsCodeColumn.ColumnName].Header.Caption = "BL����"; // ��L���v�V����
                columns[table.BLGoodsCodeColumn.ColumnName].Width = 100; // �\����
                columns[table.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // BL���i�R�[�h�}��
                columns[table.BLGoodsDrCodeColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.BLGoodsDrCodeColumn.ColumnName].Header.Caption = "BL���ގ}��"; // ��L���v�V����
                columns[table.BLGoodsDrCodeColumn.ColumnName].Width = 100; // �\����
                columns[table.BLGoodsDrCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.BLGoodsDrCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ������
                columns[table.SalesOrderCountColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.SalesOrderCountColumn.ColumnName].Header.Caption = "������"; // ��L���v�V����
                columns[table.SalesOrderCountColumn.ColumnName].Width = 100; // �\����
                columns[table.SalesOrderCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.SalesOrderCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesOrderCountColumn.ColumnName].Format = "#,##0.00";

                // �[�i��
                columns[table.DeliveredGoodsCountColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.DeliveredGoodsCountColumn.ColumnName].Header.Caption = "�[�i��"; // ��L���v�V����
                columns[table.DeliveredGoodsCountColumn.ColumnName].Width = 100; // �\����
                columns[table.DeliveredGoodsCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.DeliveredGoodsCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.DeliveredGoodsCountColumn.ColumnName].Format = "#,##0.00";

                // ���i�ԍ�
                columns[table.GoodsNoColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.GoodsNoColumn.ColumnName].Header.Caption = "�i��"; // ��L���v�V����
                columns[table.GoodsNoColumn.ColumnName].Width = 200; // �\����
                columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // UNDONE:�H�H�H���i��(�J�i)���i��

                // ���[�J�[
                columns[table.GoodsMakerCdColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.GoodsMakerCdColumn.ColumnName].Header.Caption = "���[�J�["; // ��L���v�V����
                columns[table.GoodsMakerCdColumn.ColumnName].Width = 100; // �\����
                columns[table.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.GoodsMakerCdColumn.ColumnName].Format = "0000;'';''";
                columns[table.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ���[�J�[��
                columns[table.GoodsMakerNmColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.GoodsMakerNmColumn.ColumnName].Header.Caption = "���[�J�[��"; // ��L���v�V����
                columns[table.GoodsMakerNmColumn.ColumnName].Width = 150; // �\����
                columns[table.GoodsMakerNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.GoodsMakerNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �������i���[�J�[
                columns[table.PureGoodsMakerCdColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.PureGoodsMakerCdColumn.ColumnName].Header.Caption = "�������[�J�["; // ��L���v�V����
                columns[table.PureGoodsMakerCdColumn.ColumnName].Width = 200; // �\����
                columns[table.PureGoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.PureGoodsMakerCdColumn.ColumnName].Format = "0000;'';''";
                columns[table.PureGoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �������i���[�J�[��
                columns[table.PureGoodsMakerNmColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.PureGoodsMakerNmColumn.ColumnName].Header.Caption = "�������[�J�[��"; // ��L���v�V����
                columns[table.PureGoodsMakerNmColumn.ColumnName].Width = 200; // �\����
                columns[table.PureGoodsMakerNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.PureGoodsMakerNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �┭�������i�ԍ�
                //columns[table.InqPureGoodsNoColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.InqPureGoodsNoColumn.ColumnName].Header.Caption = "�┭�������i�ԍ�"; // ��L���v�V����
                //columns[table.InqPureGoodsNoColumn.ColumnName].Width = 200; // �\����
                //columns[table.InqPureGoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.InqPureGoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �┭�������i��
                //columns[table.InqPureGoodsNameColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.InqPureGoodsNameColumn.ColumnName].Header.Caption = "�┭�������i��"; // ��L���v�V����
                //columns[table.InqPureGoodsNameColumn.ColumnName].Width = 200; // �\����
                //columns[table.InqPureGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.InqPureGoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �񓚏������i�ԍ�
                //columns[table.AnsPureGoodsNoColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.AnsPureGoodsNoColumn.ColumnName].Header.Caption = "�񓚏������i�ԍ�"; // ��L���v�V����
                //columns[table.AnsPureGoodsNoColumn.ColumnName].Width = 200; // �\����
                //columns[table.AnsPureGoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.AnsPureGoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �񓚏������i��
                //columns[table.AnsPureGoodsNameColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.AnsPureGoodsNameColumn.ColumnName].Header.Caption = "�񓚏������i��"; // ��L���v�V����
                //columns[table.AnsPureGoodsNameColumn.ColumnName].Width = 200; // �\����
                //columns[table.AnsPureGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.AnsPureGoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // UNDONE:�⍇���i��

                // �┭���i��
                columns[table.InqGoodsNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.InqGoodsNameColumn.ColumnName].Header.Caption = "�⍇���i��"; // ��L���v�V����
                columns[table.InqGoodsNameColumn.ColumnName].Width = 200; // �\����
                columns[table.InqGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.InqGoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // UNDONE:�񓚕i��

                // �񓚏��i��
                columns[table.AnsGoodsNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.AnsGoodsNameColumn.ColumnName].Header.Caption = "�񓚕i��"; // ��L���v�V����
                columns[table.AnsGoodsNameColumn.ColumnName].Width = 200; // �\����
                columns[table.AnsGoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.AnsGoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �艿
                columns[table.ListPriceColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.ListPriceColumn.ColumnName].Header.Caption = "�W�����i"; // ��L���v�V����
                columns[table.ListPriceColumn.ColumnName].Width = 100; // �\����
                columns[table.ListPriceColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.ListPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.ListPriceColumn.ColumnName].Format = "#,##0";

                // �P��
                columns[table.UnitPriceColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.UnitPriceColumn.ColumnName].Header.Caption = "�P��"; // ��L���v�V����
                columns[table.UnitPriceColumn.ColumnName].Width = 100; // �\����
                columns[table.UnitPriceColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.UnitPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.UnitPriceColumn.ColumnName].Format = "#,##0";

                //// ���i�⑫���
                //columns[table.GoodsAddInfoColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.GoodsAddInfoColumn.ColumnName].Header.Caption = "���i�⑫���"; // ��L���v�V����
                //columns[table.GoodsAddInfoColumn.ColumnName].Width = 150; // �\����
                //columns[table.GoodsAddInfoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.GoodsAddInfoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �e���z
                columns[table.RoughRrofitColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.RoughRrofitColumn.ColumnName].Header.Caption = "�e���z"; // ��L���v�V����
                columns[table.RoughRrofitColumn.ColumnName].Width = 100; // �\����
                columns[table.RoughRrofitColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.RoughRrofitColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.RoughRrofitColumn.ColumnName].Format = "#,##0";

                // �e����
                columns[table.RoughRateColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.RoughRateColumn.ColumnName].Header.Caption = "�e����"; // ��L���v�V����
                columns[table.RoughRateColumn.ColumnName].Width = 100; // �\����
                columns[table.RoughRateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.RoughRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.RoughRateColumn.ColumnName].Format = "#,##0";

                // �񓚊���
                columns[table.AnswerLimitDateForDispColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.AnswerLimitDateForDispColumn.ColumnName].Header.Caption = "�񓚊���"; // ��L���v�V����
                columns[table.AnswerLimitDateForDispColumn.ColumnName].Width = 150; // �\����
                columns[table.AnswerLimitDateForDispColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.AnswerLimitDateForDispColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ���l(����)
                columns[table.CommentDtlColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.CommentDtlColumn.ColumnName].Header.Caption = "���l"; // ��L���v�V����
                columns[table.CommentDtlColumn.ColumnName].Width = 150; // �\����
                columns[table.CommentDtlColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.CommentDtlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �I��
                columns[table.ShelfNoColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.ShelfNoColumn.ColumnName].Header.Caption = "�I��"; // ��L���v�V����
                columns[table.ShelfNoColumn.ColumnName].Width = 100; // �\����
                columns[table.ShelfNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.ShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �ǉ��敪
                //columns[table.AdditionalDivCdColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.AdditionalDivCdColumn.ColumnName].Header.Caption = "�ǉ��敪"; // ��L���v�V����
                //columns[table.AdditionalDivCdColumn.ColumnName].Width = 100; // �\����
                //columns[table.AdditionalDivCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.AdditionalDivCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �����敪
                //columns[table.CorrectDivCDColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.CorrectDivCDColumn.ColumnName].Header.Caption = "�����敪"; // ��L���v�V����
                //columns[table.CorrectDivCDColumn.ColumnName].Width = 100; // �\����
                //columns[table.CorrectDivCDColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.CorrectDivCDColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �󒍃X�e�[�^�X
                columns[table.AcptAnOdrStatusNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.AcptAnOdrStatusNameColumn.ColumnName].Header.Caption = "�敪"; // ��L���v�V����
                columns[table.AcptAnOdrStatusNameColumn.ColumnName].Width = 150; // �\����
                columns[table.AcptAnOdrStatusNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.AcptAnOdrStatusNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ����`�[�ԍ�
                columns[table.SalesSlipNumColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.SalesSlipNumColumn.ColumnName].Header.Caption = "�`�[�ԍ�"; // ��L���v�V����
                columns[table.SalesSlipNumColumn.ColumnName].Width = 150; // �\����
                columns[table.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.SalesSlipNumColumn.ColumnName].Format = "000000000;'';''";
                columns[table.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ����s�ԍ�
                columns[table.SalesRowNoColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.SalesRowNoColumn.ColumnName].Header.Caption = "�sNo"; // ��L���v�V����
                columns[table.SalesRowNoColumn.ColumnName].Width = 100; // �\����
                columns[table.SalesRowNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.SalesRowNoColumn.ColumnName].Format = "0000;'';''";
                columns[table.SalesRowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �⍇���E�������
                columns[table.InqOrdDivNmColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.InqOrdDivNmColumn.ColumnName].Header.Caption = "�⍇���E�����敪"; // ��L���v�V����
                columns[table.InqOrdDivNmColumn.ColumnName].Width = 200; // �\����
                columns[table.InqOrdDivNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.InqOrdDivNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �񓚍쐬�敪
                columns[table.AnswerCreateDivNmColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.AnswerCreateDivNmColumn.ColumnName].Header.Caption = "�񓚍쐬�敪"; // ��L���v�V����
                columns[table.AnswerCreateDivNmColumn.ColumnName].Width = 150; // �\����
                columns[table.AnswerCreateDivNmColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.AnswerCreateDivNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �݌ɋ敪
                columns[table.StockDivNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.StockDivNameColumn.ColumnName].Header.Caption = "�݌ɋ敪"; // ��L���v�V����
                columns[table.StockDivNameColumn.ColumnName].Width = 150; // �\����
                columns[table.StockDivNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.StockDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                //// �\������
                //columns[table.DisplayOrderColumn.ColumnName].Hidden = true; // �\���ݒ�
                //columns[table.DisplayOrderColumn.ColumnName].Header.Caption = "�\������"; // ��L���v�V����
                //columns[table.DisplayOrderColumn.ColumnName].Width = 150; // �\����
                //columns[table.DisplayOrderColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                //columns[table.DisplayOrderColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �L�����y�[���R�[�h
                columns[table.CampaignCodeColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.CampaignCodeColumn.ColumnName].Header.Caption = "�L�����y�[���R�[�h"; // ��L���v�V����
                columns[table.CampaignCodeColumn.ColumnName].Width = 200; // �\����
                columns[table.CampaignCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.CampaignCodeColumn.ColumnName].Format = "00000000;'';''";
                columns[table.CampaignCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �L�����y�[����
                columns[table.CampaignNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.CampaignNameColumn.ColumnName].Header.Caption = "�L�����y�[������"; // ��L���v�V����
                columns[table.CampaignNameColumn.ColumnName].Width = 150; // �\����
                columns[table.CampaignNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.CampaignNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                #endregion

                #endregion
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
        }

        #endregion

        #region XML����
        /// <summary>
        /// �w�l�k�f�[�^�̓Ǎ�����
        /// </summary>
        private void LoadStateXmlData()
        {
            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion

        #region ��������

        /// <summary>
        /// ��������
        /// </summary>
        private void Search()
        {
            if (this.SeachBeforeCheck())
            {
                this.ExecuteSearch();
            }
        }

        /// <summary>
        /// �����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        public bool SeachBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    errMessage,
                    0,
                    MessageBoxButtons.OK);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }

        /// <summary>
        /// ��ʓ��̓`�F�b�N
        /// </summary>
        /// <param name="errMessage"></param>
        /// <param name="errComponent"></param>
        /// <returns></returns>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            // �⍇����
            DateGetAcs.CheckDateResult cdResult;

            if (tde_InquiryDateSt.GetLongDate() != 0)
            {
                cdResult = this._dateGet.CheckDate(ref tde_InquiryDateSt, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("�J�n�⍇����{0}", ct_InputError);
                    errComponent = this.tde_InquiryDateSt;
                    return false;
                }
            }

            if (tde_InquiryDateEd.GetLongDate() != 0)
            {
                cdResult = this._dateGet.CheckDate(ref tde_InquiryDateEd, true);
                if (cdResult == DateGetAcs.CheckDateResult.ErrorOfInvalid)
                {
                    errMessage = string.Format("�I���⍇����{0}", ct_InputError);
                    errComponent = this.tde_InquiryDateEd;
                    return false;
                }
            }

            // �召�`�F�b�N
            if (tde_InquiryDateSt.GetLongDate() != 0
                && tde_InquiryDateEd.GetLongDate() != 0)
            {
                if (tde_InquiryDateSt.GetLongDate() > tde_InquiryDateEd.GetLongDate())
                {
                    errMessage = string.Format("�⍇����{0}", ct_RangeError);
                    errComponent = this.tde_InquiryDateSt;
                    return false;
                }
            }

            // ���_�̖����̓`�F�b�N
            if (this.tEdit_SectionCodeAllowZero.Text == string.Empty)
            {
                errMessage = string.Format("���_{0}", ct_NoInput);
                errComponent = this.tEdit_SectionCodeAllowZero;
                return false;
            }

            // ���Ӑ�召�`�F�b�N
            if (!this.CheckInputRange(this.tNedit_CustomerCode_St, this.tNedit_CustomerCode_Ed))
            {
                errMessage = string.Format("���Ӑ�{0}", ct_RangeError);
                errComponent = this.tNedit_CustomerCode_St;
                return false;
            }

            // �񓚕��@
            if (!this.uCheckEditor_AnswerMethodAll.Checked
                && !this.uCheckEditor_AnswerMethodAuto.Checked
                && !this.uCheckEditor_AnswerMethodManual.Checked)
            {
                errMessage = "�񓚕��@��I�����Ă��������B";
                errComponent = this.uCheckEditor_AnswerMethodAll;
                return false;
            }

            // �`�[�ԍ�(�󒍃X�e�[�^�X)
            if (!this.uCheckEditor_AcptAnOdrStatusAll.Checked
                && !this.uCheckEditor_AcptAnOdrStatusEstimate.Checked
                && !this.uCheckEditor_AcptAnOdrStatusAccept.Checked
                && !this.uCheckEditor_AcptAnOdrStatusSales.Checked)
            {
                errMessage = "�󒍃X�e�[�^�X��I�����Ă��������B";
                errComponent = this.uCheckEditor_AcptAnOdrStatusAll;
                return false;
            }

            // �`�[�ԍ��召�`�F�b�N
            if (this.tEdit_SalesSlipNum_St.Text != string.Empty
                && this.tEdit_SalesSlipNum_Ed.Text != string.Empty)
            {
                int salesSlipNumSt;
                int salesSlipNumEd;

                Int32.TryParse(this.tEdit_SalesSlipNum_St.Text, out salesSlipNumSt);
                Int32.TryParse(this.tEdit_SalesSlipNum_Ed.Text, out salesSlipNumEd);

                if (salesSlipNumSt > salesSlipNumEd)
                {
                    errMessage = string.Format("�`�[�ԍ�{0}", ct_RangeError);
                    errComponent = this.tEdit_SalesSlipNum_St;
                    return false;
                }
            }

            // �⍇���ԍ�(�⍇���E�������)
            if (!this.uCheckEditor_InqOrdDivAll.Checked
                && !this.uCheckEditor_InqOrdDivEstimate.Checked
                && !this.uCheckEditor_InqOrdDivAccept.Checked)
            {
                errMessage = "�⍇���E������ʂ�I�����Ă��������B";
                errComponent = this.uCheckEditor_InqOrdDivAll;
                return false;
            }

            // �⍇���ԍ��召�`�F�b�N
            if (!this.CheckInputRange(this.tNedit_InquiryNumber_St, this.tNedit_InquiryNumber_Ed))
            {
                errMessage = string.Format("�⍇���ԍ�{0}", ct_RangeError);
                errComponent = this.tNedit_InquiryNumber_St;
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���l���ڂ̑召��r
        /// </summary>
        /// <param name="stEdit"></param>
        /// <param name="edEdit"></param>
        /// <returns></returns>
        private bool CheckInputRange(TNedit stEdit, TNedit edEdit)
        {
            int stCode = stEdit.GetInt();
            int edCode = edEdit.GetInt();

            if (stCode != 0 &&
                 edCode != 0 &&
                 stCode > edCode)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void ExecuteSearch()
        {
            // ��ʁ����o�����N���X
            SCMAnsHistInquiryInfo scmAnsHistInquiryInfo = this.SetExtraInfoFromScreen();

            string errMsg;
            int status = this._scmAnsHistInquiryAcs.Search(scmAnsHistInquiryInfo, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // �Y���Ȃ�
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                errMsg, // �\�����郁�b�Z�[�W
                                -1,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);
            }
            else
            {
                // �G���[
                TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOP, 						// �G���[���x��
                                this.Name,											// �A�Z���u��ID
                                errMsg, // �\�����郁�b�Z�[�W
                                status,													// �X�e�[�^�X�l
                                MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// ��ʏ��擾
        /// </summary>
        /// <returns></returns>
        private SCMAnsHistInquiryInfo SetExtraInfoFromScreen()
        {
            SCMAnsHistInquiryInfo scmAnsHistInquiryInfo = new SCMAnsHistInquiryInfo();

            scmAnsHistInquiryInfo.EnterpriseCode = this._enterpriseCode; // ���ʃw�b�_�̊�ƃR�[�h

            scmAnsHistInquiryInfo.St_InquiryDate = this.tde_InquiryDateSt.GetLongDate(); // �⍇����(�J�n)
            scmAnsHistInquiryInfo.Ed_InquiryDate = this.tde_InquiryDateEd.GetLongDate(); // �⍇����(�I��)

            scmAnsHistInquiryInfo.InqOtherEpCd = this._enterpriseCode; // �⍇�����ƃR�[�h
            scmAnsHistInquiryInfo.InqOtherSecCd = this.tEdit_SectionCodeAllowZero.DataText; // �⍇���拒�_�R�[�h

            scmAnsHistInquiryInfo.St_CustomerCode = this.tNedit_CustomerCode_St.GetInt(); // ���Ӑ�(�J�n)
            scmAnsHistInquiryInfo.Ed_CustomerCode = this.tNedit_CustomerCode_Ed.GetInt(); // ���Ӑ�(�I��)

            // �񓚕��@
            List<Int32> answerMethodList = new List<int>();
            if (this.uCheckEditor_AnswerMethodAll.Checked)
            {
                answerMethodList.AddRange(new Int32[] {(int)SCMAnsHistInquiryInfo.AnswerMethodState.Auto ,
                                                        (int)SCMAnsHistInquiryInfo.AnswerMethodState.ManualWeb ,
                                                        (int)SCMAnsHistInquiryInfo.AnswerMethodState.ManualOther});
            }
            else
            {
                if (this.uCheckEditor_AnswerMethodAuto.Checked)
                {
                    answerMethodList.Add((int)SCMAnsHistInquiryInfo.AnswerMethodState.Auto);
                }
                if (this.uCheckEditor_AnswerMethodManual.Checked)
                {
                    answerMethodList.Add((int)SCMAnsHistInquiryInfo.AnswerMethodState.ManualWeb);
                    answerMethodList.Add((int)SCMAnsHistInquiryInfo.AnswerMethodState.ManualOther);
                }
            }

            scmAnsHistInquiryInfo.AwnserMethod = answerMethodList.ToArray();

            // �`�[�ԍ�(�󒍃X�e�[�^�X)
            List<Int32> acptAnOdrStatusList = new List<int>();
            if (this.uCheckEditor_AcptAnOdrStatusAll.Checked)
            {
                acptAnOdrStatusList.AddRange(new Int32[] {(int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.NotSet ,
                                                        (int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.Estimate ,
                                                        (int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.Accept ,
                                                        (int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.Sales});
            }
            else
            {
                if (this.uCheckEditor_AcptAnOdrStatusEstimate.Checked)
                {
                    acptAnOdrStatusList.Add((int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.Estimate);
                }
                if (this.uCheckEditor_AcptAnOdrStatusAccept.Checked)
                {
                    acptAnOdrStatusList.Add((int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.Accept);
                }
                if (this.uCheckEditor_AcptAnOdrStatusSales.Checked)
                {
                    acptAnOdrStatusList.Add((int)SCMAnsHistInquiryInfo.AcptAnOdrStatusState.Sales);
                }
            }

            scmAnsHistInquiryInfo.AcptAnOdrStatus = acptAnOdrStatusList.ToArray();

            // �`�[�ԍ�
            scmAnsHistInquiryInfo.St_SalesSlipNum = this.tEdit_SalesSlipNum_St.DataText; // �`�[�ԍ�(�J�n)
            scmAnsHistInquiryInfo.Ed_SalesSlipNum = this.tEdit_SalesSlipNum_Ed.DataText; // �`�[�ԍ�(�I��) 

            // �⍇���ԍ�(�⍇���E�������)
            List<Int32> inqOrdDivList = new List<int>();
            if (this.uCheckEditor_InqOrdDivAll.Checked)
            {
                inqOrdDivList.AddRange(new Int32[] {(int)SCMAnsHistInquiryInfo.InqOrdDivState.Estimate ,
                                                        (int)SCMAnsHistInquiryInfo.InqOrdDivState.Accept});
            }
            else
            {
                if (this.uCheckEditor_InqOrdDivEstimate.Checked)
                {
                    inqOrdDivList.Add((int)SCMAnsHistInquiryInfo.InqOrdDivState.Estimate);
                }
                if (this.uCheckEditor_InqOrdDivAccept.Checked)
                {
                    inqOrdDivList.Add((int)SCMAnsHistInquiryInfo.InqOrdDivState.Accept);
                }
            }

            scmAnsHistInquiryInfo.InqOrdDivCd = inqOrdDivList.ToArray();

            // �⍇���ԍ�
            scmAnsHistInquiryInfo.St_InquiryNumber = this.tNedit_InquiryNumber_St.GetInt(); // �⍇���ԍ�(�J�n)
            scmAnsHistInquiryInfo.Ed_InquiryNumber = this.tNedit_InquiryNumber_Ed.GetInt(); // �⍇���ԍ�(�I��)

            // �ԗ����
            scmAnsHistInquiryInfo.NumberPlate4 = this.tNedit_NumberPlate4.GetInt(); // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            scmAnsHistInquiryInfo.FullModel = this.tEdit_FullModel.DataText; // �^��(�t��)

            scmAnsHistInquiryInfo.CarMakerCode = this.tNedit_CarMakerCode.GetInt(); // ���[�J�[�R�[�h
            scmAnsHistInquiryInfo.ModelCode = this.tNedit_ModelCode.GetInt(); // �Ԏ�R�[�h
            scmAnsHistInquiryInfo.ModelSubCode = this.tNedit_ModelSubCode.GetInt(); // �Ԏ�T�u�R�[�h

            // ���׏��
            scmAnsHistInquiryInfo.DetailMakerCode = this.tNedit_GoodsMakerCd.GetInt(); // ���[�J�[�R�[�h
            scmAnsHistInquiryInfo.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt(); // BL�R�[�h
            scmAnsHistInquiryInfo.GoodsNo = this.tEdit_GoodsNo.DataText; // �i��
            scmAnsHistInquiryInfo.PureGoodsNo = this.tEdit_PureGoodsNo.DataText; // �����i��

            return scmAnsHistInquiryInfo;
        }

        #endregion

        #endregion

        #region ���C�x���g
        /// <summary>
        /// PMSCM04101UA_Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM04101UA_Load(object sender, EventArgs e)
        {
            // ��ʏ����ݒ�
            this.SetInitialSetting();

            // ��ʃN���A
            ClearScreen();

            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// �������^�C�}�[
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // �t�H�[�J�X�ݒ�
            this.tde_InquiryDateSt.Focus();

            // XML�f�[�^�Ǎ�
            LoadStateXmlData();

            // �O���b�h�̃A�N�e�B�u�s���N���A
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// tRetKeyControl1_ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                case "uCheckEditor_AnswerDivNon":
                    {
                        #region �񓚋敪 ���A�N�V����
                        if ((e.Key == Keys.Tab || e.Key == Keys.Left)
                            && e.NextCtrl == this.uGrid_Details)
                        {
                            if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                            {
                                this.uGrid_Details.DisplayLayout.Rows[this.uGrid_Details.DisplayLayout.Rows.Count - 1].Activate();
                                this.uGrid_Details.DisplayLayout.Rows[this.uGrid_Details.DisplayLayout.Rows.Count - 1].Selected = true;
                            }
                            else
                            {
                                if (uGroupBox_DetailInfo.Expanded)
                                {
                                    e.NextCtrl = this.tEdit_PureGoodsNo;
                                }
                                else
                                {
                                    e.NextCtrl = this.tNedit_InquiryNumber_Ed;
                                }
                            }
                        }
                        break;
                        #endregion
                    }
                case "tEdit_SectionCodeAllowZero":
                    {
                        #region ���_�R�[�h
                        // ���͖���
                        if (this.tEdit_SectionCodeAllowZero.DataText == string.Empty
                            || this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0') == "00")
                        {
                            this.tEdit_SectionCodeAllowZero.Text = "00";
                            this.uLabel_SectionName.Text = "�S��";

                            // �ݒ�l�ۑ�
                            this._beforeSectionCode = "00";

                            if (e.NextCtrl == this.uButton_SectionCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                e.NextCtrl = this.tNedit_CustomerCode_St;
                            }

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tEdit_SectionCodeAllowZero.Text.Trim().PadLeft(2, '0') == this._beforeSectionCode)
                        {
                            if (e.NextCtrl == this.uButton_SectionCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                                e.NextCtrl = this.tNedit_CustomerCode_St;
                            }

                            break;
                        }

                        // ���͒l�`�F�b�N
                        SecInfoSet secInfoSet;

                        int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, this.tEdit_SectionCodeAllowZero.DataText);

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                            this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm;

                            // �ݒ�l��ۑ�
                            this._beforeSectionCode = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tEdit_SectionCodeAllowZero.DataText = this._beforeSectionCode;

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����ŋ��_�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_SectionCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            // ���͂��聕Tab�J�ځ������K�C�h�{�^���̏ꍇ�A�K�C�h�{�^���͔�΂�
                            e.NextCtrl = this.tNedit_CustomerCode_St;
                        }

                        break;
                        #endregion
                    }
                case "tNedit_CustomerCode_St":
                    {
                        #region ���Ӑ�R�[�h(�J�n)
                        if (e.NextCtrl == this.uButton_CustomerCdGuideSt)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_CustomerCode_Ed;
                            }
                        }

                        break;
                        #endregion
                    }
                case "tNedit_CustomerCode_Ed":
                    {
                        #region ���Ӑ�R�[�h(�I��)
                        if (e.NextCtrl == this.uButton_CustomerCdGuideEd)
                        {
                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.uCheckEditor_AnswerMethodAll;
                            }
                        }

                        break;
                        #endregion
                    }
                case "tNedit_InquiryNumber_Ed":
                    {
                        #region �⍇���ԍ�(�I��)
                        // �ڍ׏����������Ă���ꍇ�ɊY��
                        if ((e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)
                            && e.NextCtrl == this.uGrid_Details)
                        {
                            if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                            {
                                this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                            }
                            else
                            {
                                e.NextCtrl = this.tde_InquiryDateSt;
                            }
                        }
                        break;
                        #endregion
                    }
                case "tNedit_GoodsMakerCd":
                    {
                        #region ���[�J�[�R�[�h
                        // ���͖���
                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._beforeMakerCode = 0;
                            this.uLabel_GoodsMakerName.Text = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_GoodsMakerCd.GetInt() == this._beforeMakerCode)
                        {
                            if (e.NextCtrl == this.uButton_GoodsMakerCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {
                                e.NextCtrl = this.tNedit_NumberPlate4;
                            }

                            break;
                        }

                        // ���͒l�`�F�b�N
                        MakerUMnt makerUMnt;

                        int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                            this.uLabel_GoodsMakerName.Text = makerUMnt.MakerName;

                            // �ݒ�l��ۑ�
                            this._beforeMakerCode = makerUMnt.GoodsMakerCd;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tNedit_GoodsMakerCd.SetInt(this._beforeMakerCode);

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����Ń��[�J�[�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_GoodsMakerCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            e.NextCtrl = this.tNedit_NumberPlate4;
                        }

                        break;
                        #endregion
                    }
                case "tNedit_BLGoodsCode":
                    {
                        #region BL�R�[�h
                        // ���͖���
                        if (this.tNedit_BLGoodsCode.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._beforeBLGoodsCode = 0;
                            this.uLabel_BLGoodsCodeName.Text = string.Empty;

                            break;
                        }

                        // ���͕ύX�Ȃ�
                        if (this.tNedit_BLGoodsCode.GetInt() == this._beforeBLGoodsCode)
                        {
                            if (e.NextCtrl == this.uButton_BLGoodsCdGuide
                                && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                            {

                                e.NextCtrl = this.tEdit_FullModel;
                            }

                            break;
                        }

                        // ���͒l�`�F�b�N
                        BLGoodsCdUMnt blGoodsCdUMnt;

                        int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, this.tNedit_BLGoodsCode.GetInt());

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                            this.uLabel_BLGoodsCodeName.Text = blGoodsCdUMnt.BLGoodsHalfName;

                            // �ݒ�l��ۑ�
                            this._beforeBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tNedit_BLGoodsCode.SetInt(this._beforeBLGoodsCode);

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ������BL�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��
                            return;
                        }

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                            && e.NextCtrl == this.uButton_BLGoodsCdGuide
                            && (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right))
                        {
                            e.NextCtrl = this.tEdit_FullModel;
                        }

                        break;
                        #endregion
                    }
                case "tNedit_CarMakerCode":
                    {
                        #region ���[�J�[�R�[�h(�ԗ����)
                        // ���͂Ȃ�
                        if (this.tNedit_CarMakerCode.GetInt() == 0)
                        {
                            // �ݒ�l�ۑ��A���̂̃N���A
                            this._beforeMakerCodeCar = 0;
                            this.tNedit_ModelCode.SetInt(0);
                            this.tNedit_ModelSubCode.SetInt(0);
                            this.tEdit_ModelFullName.DataText = string.Empty;
                            this.tNedit_ModelCode.Enabled = false;
                            this.tNedit_ModelSubCode.Enabled = false;

                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }

                            break;
                        }

                        // ���͒l�ύX�Ȃ�
                        if (this.tNedit_CarMakerCode.GetInt() == this._beforeMakerCodeCar)
                        {
                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }

                            break;
                        }
                        
                        // ���͒l�`�F�b�N
                        MakerUMnt makerUMnt;

                        int status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_CarMakerCode.GetInt());

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tNedit_CarMakerCode.SetInt(makerUMnt.GoodsMakerCd);
                            this.tEdit_ModelFullName.DataText = makerUMnt.MakerName;

                            // �ݒ�l��ۑ�
                            this._beforeMakerCodeCar = makerUMnt.GoodsMakerCd;

                            // �Ԏ�R�[�h����͉\�ɂ���
                            this.tNedit_ModelCode.Enabled = true;
                            this.tNedit_ModelCode.SetInt(0);
                            this.tNedit_ModelSubCode.SetInt(0);

                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_ModelCode;
                            }
                            else if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tNedit_CarMakerCode.SetInt(this._beforeMakerCodeCar);

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����Ń��[�J�[�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��

                            return;
                        }

                        break;
                        #endregion
                    }
                case "tNedit_ModelCode":
                    {
                        #region �Ԏ�R�[�h

                        int status;

                        // ���͂Ȃ�
                        if (this.tNedit_ModelCode.GetInt() == 0)
                        {
                            // ���[�J�[�����擾
                            MakerUMnt makerUMnt;

                            status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_CarMakerCode.GetInt());

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.tEdit_ModelFullName.DataText = makerUMnt.MakerName;
                            }

                            // �ݒ�l��ۑ�
                            this._beforeModelCode = this.tNedit_ModelCode.GetInt();

                            this.tNedit_ModelSubCode.Enabled = false;
                            this.tNedit_ModelSubCode.SetInt(0);

                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }

                            break;
                        }

                        // ���͒l�ύX�Ȃ�
                        if (this.tNedit_ModelCode.GetInt() == this._beforeModelCode)
                        {
                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }

                            break;
                        }

                        ModelNameU modelNameU = new ModelNameU();

                        status = this._modelNameUAcs.Read(
                            out modelNameU, this._enterpriseCode, this.tNedit_CarMakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt());

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tNedit_ModelCode.SetInt(modelNameU.ModelCode);
                            this.tEdit_ModelFullName.DataText = modelNameU.ModelFullName;

                            // �ݒ�l��ۑ�
                            this._beforeModelCode = modelNameU.ModelCode;

                            // �Ԏ�T�u�R�[�h����͉\�ɂ���
                            this.tNedit_ModelSubCode.Enabled = true;
                            this.tNedit_ModelSubCode.SetInt(0);

                            if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tNedit_ModelSubCode;
                            }
                            else if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tNedit_ModelCode.SetInt(this._beforeModelCode);

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����ŎԎ�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��
                            return;
                        }

                        break;
                        #endregion
                    }
                case "tNedit_ModelSubCode":
                    {
                        #region �Ԏ�T�u�R�[�h

                        int status;
                        ModelNameU modelNameU;

                        // ���͂Ȃ�
                        if (this.tNedit_ModelSubCode.GetInt() == 0)
                        {
                            modelNameU = new ModelNameU();

                            // ���[�J�[�A�Ԏ�R�[�h��薼�̂��擾
                            status = this._modelNameUAcs.Read(
                            out modelNameU, this._enterpriseCode, this.tNedit_CarMakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt());

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                this.tEdit_ModelFullName.DataText = modelNameU.ModelFullName;
                            }

                            this._beforeModelSubCode = this.tNedit_ModelSubCode.GetInt();

                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }

                            break;
                        }

                        // �ύX�Ȃ�
                        if (this.tNedit_ModelSubCode.GetInt() == this._beforeModelSubCode)
                        {
                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }

                            break;
                        }

                        modelNameU = new ModelNameU();

                        status = this._modelNameUAcs.Read(
                            out modelNameU, this._enterpriseCode, this.tNedit_CarMakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt());

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            // ���ʂ���ʂɐݒ�
                            this.tNedit_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                            this.tEdit_ModelFullName.DataText = modelNameU.ModelFullName;

                            // �ݒ�l��ۑ�
                            this._beforeModelSubCode = modelNameU.ModelSubCode;

                            if (e.Key == Keys.Down && e.NextCtrl == this.uGrid_Details)
                            {
                                if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                                {
                                    this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                    this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }
                        }
                        else
                        {
                            // �O����͒l��ݒ�
                            this.tNedit_ModelSubCode.SetInt(this._beforeModelSubCode);

                            // �Y���Ȃ�
                            TMsgDisp.Show(this, 												// �e�E�B���h�E�t�H�[��
                                            emErrorLevel.ERR_LEVEL_INFO, 						// �G���[���x��
                                            this.Name,											// �A�Z���u��ID
                                            "�w�肳�ꂽ�����ŎԎ�T�u�R�[�h�͑��݂��܂���ł����B", // �\�����郁�b�Z�[�W
                                            -1,													// �X�e�[�^�X�l
                                            MessageBoxButtons.OK);								// �\������{�^��
                            return;
                        }

                        break;
                        #endregion
                    }
                case "tEdit_PureGoodsNo":
                    {
                        #region �����i��
                        if ((e.Key == Keys.Tab || e.Key == Keys.Right || e.Key == Keys.Down)
                            && e.NextCtrl == this.uGrid_Details)
                        {
                            if (this.uGrid_Details.DisplayLayout.Rows.Count != 0)
                            {
                                this.uGrid_Details.DisplayLayout.Rows[0].Activate();
                                this.uGrid_Details.DisplayLayout.Rows[0].Selected = true;
                            }
                            else
                            {
                                e.NextCtrl = this.tde_InquiryDateSt;
                            }
                        }

                        break;
                        #endregion
                    }
                case "uGrid_Details":
                    {
                        #region �O���b�h
                        if (e.Key == Keys.Tab)
                        {
                            if (this.uGrid_Details.Rows.Count == 0 ||
                                ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null)))
                            {
                                if (e.ShiftKey)
                                {
                                    if (this.uGroupBox_DetailInfo.Expanded)
                                    {
                                        e.NextCtrl = this.tEdit_PureGoodsNo;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_InquiryNumber_Ed;
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = this.tde_InquiryDateSt;
                                }
                            }
                            else
                            {
                                if (e.ShiftKey)
                                {
                                    if (this.uGrid_Details.DisplayLayout.ActiveRow.Index == 0)
                                    {
                                        if (this.uGroupBox_DetailInfo.Expanded)
                                        {
                                            e.NextCtrl = this.tEdit_PureGoodsNo;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.tNedit_InquiryNumber_Ed;
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uGrid_Details;
                                        this.uGrid_Details.PerformAction(UltraGridAction.AboveRow);
                                    }
                                }
                                else
                                {
                                    if (this.uGrid_Details.DisplayLayout.ActiveRow.Index
                                        == this.uGrid_Details.DisplayLayout.Rows.Count - 1)
                                    {
                                        e.NextCtrl = this.tde_InquiryDateSt;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.uGrid_Details;
                                        this.uGrid_Details.PerformAction(UltraGridAction.BelowRow);
                                    }
                                }
                            }
                        }
                        break;
                        #endregion
                    }
            }
        }

        #region �K�C�h�{�^�������C�x���g
        /// <summary>
        /// ���_�K�C�h�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SectionCdGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero.Text = secInfoSet.SectionCode.Trim().PadLeft(2, '0');
                    this.uLabel_SectionName.Text = secInfoSet.SectionGuideNm.Trim();

                    this._beforeSectionCode = secInfoSet.SectionCode.Trim().PadLeft(2, '0');

                    // ���t�H�[�J�X
                    tNedit_CustomerCode_St.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// ���Ӑ�K�C�h�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_CustomerCdGuideSt_Click(object sender, EventArgs e)
        {
            // �������ꂽ�{�^����ޔ�
            if (sender is UltraButton)
            {
                _customerGuideSender = (UltraButton)sender;
            }

            // ���Ӑ�K�C�h�p���C�u�������ύX
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// ���Ӑ挟���A�N�Z�X�N���X
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            DialogResult ret = customerSearchForm.ShowDialog(this);
            if (ret == DialogResult.OK)
            {
                // ���t�H�[�J�X
                if (sender == this.uButton_CustomerCdGuideSt)
                {
                    this.tNedit_CustomerCode_Ed.Focus();
                }
                else
                {
                    this.uCheckEditor_AnswerMethodAll.Focus();
                }

            }
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            CustomerInfo customerInfo = new CustomerInfo();

            int status = customerInfoAcs.ReadDBData(this._enterpriseCode, customerSearchRet.CustomerCode, out customerInfo);
            if (status != 0) return;

            if (_customerGuideSender == this.uButton_CustomerCdGuideSt)
            {
                this.tNedit_CustomerCode_St.SetInt(customerInfo.CustomerCode);
            }
            else
            {
                this.tNedit_CustomerCode_Ed.SetInt(customerInfo.CustomerCode);
            }

        }

        /// <summary>
        /// ���[�J�[�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            MakerUMnt makerUmnt;

            int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUmnt);

            if (status == 0)
            {
                this.tNedit_GoodsMakerCd.SetInt(makerUmnt.GoodsMakerCd);
                this.uLabel_GoodsMakerName.Text = makerUmnt.MakerName;

                this._beforeMakerCode = makerUmnt.GoodsMakerCd;

                // �t�H�[�J�X
                this.tNedit_BLGoodsCode.Focus();
            }
        }

        /// <summary>
        /// BL�R�[�h�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_BLGoodsCdGuide_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt;

            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);

            if (status == 0)
            {
                this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                this.uLabel_BLGoodsCodeName.Text = blGoodsCdUMnt.BLGoodsHalfName;

                this._beforeBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;

                // �t�H�[�J�X
                this.tEdit_GoodsNo.Focus();
            }
        }

        /// <summary>
        /// �Ԏ�K�C�h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
        {
            
            ModelNameU modelNameU;

            int makerCode = this.tNedit_CarMakerCode.GetInt();
            int status = this._modelNameUAcs.ExecuteGuid(makerCode, this._enterpriseCode, out modelNameU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_CarMakerCode.SetInt(modelNameU.MakerCode);
                this.tNedit_ModelCode.SetInt(modelNameU.ModelCode);
                this.tNedit_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                this.tEdit_ModelFullName.DataText = modelNameU.ModelFullName;

                this.tNedit_ModelCode.Enabled = true;
                this.tNedit_ModelSubCode.Enabled = true;

                this._beforeMakerCodeCar = modelNameU.MakerCode;
                this._beforeModelCode = modelNameU.ModelCode;
                this._beforeModelSubCode = modelNameU.ModelSubCode;

                // �t�H�[�J�X
                this.tNedit_GoodsMakerCd.Focus();
            }
        }
        #endregion

        #region �񓚋敪����
        /// <summary>
        /// �񓚋敪�u�S�āv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AnswerMethodAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AnswerMethodAll.Checked)
            {
                this.uCheckEditor_AnswerMethodAuto.Checked = false;
                this.uCheckEditor_AnswerMethodManual.Checked = false;
            }
        }

        /// <summary>
        /// �񓚋敪�u�����v
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AnswerMethodAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AnswerMethodAuto.Checked)
            {
                this.uCheckEditor_AnswerMethodAll.Checked = false;
            }
        }

        /// <summary>
        /// �񓚋敪�u�蓮�v
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AnswerMethodManual_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AnswerMethodManual.Checked)
            {
                this.uCheckEditor_AnswerMethodAll.Checked = false;
            }
        }
        #endregion

        #region �`�[�ԍ�(�󒍃X�e�[�^�X)����
        /// <summary>
        /// �`�[�ԍ� �󒍃X�e�[�^�X�u�S�āv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AcptAnOdrStatusAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AcptAnOdrStatusAll.Checked)
            {
                this.uCheckEditor_AcptAnOdrStatusSales.Checked = false;
                this.uCheckEditor_AcptAnOdrStatusAccept.Checked = false;
                this.uCheckEditor_AcptAnOdrStatusEstimate.Checked = false;
            }
        }

        /// <summary>
        /// �`�[�ԍ� �󒍃X�e�[�^�X�u����v
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AcptAnOdrStatusSales_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AcptAnOdrStatusSales.Checked)
            {
                this.uCheckEditor_AcptAnOdrStatusAll.Checked = false;
            }
        }

        /// <summary>
        /// �`�[�ԍ� �󒍃X�e�[�^�X�u�󒍁v
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AcptAnOdrStatusAccept_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AcptAnOdrStatusAccept.Checked)
            {
                this.uCheckEditor_AcptAnOdrStatusAll.Checked = false;
            }
        }

        /// <summary>
        /// �`�[�ԍ� �󒍃X�e�[�^�X�u���ρv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_AcptAnOdrStatusEstimate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_AcptAnOdrStatusEstimate.Checked)
            {
                this.uCheckEditor_AcptAnOdrStatusAll.Checked = false;
            }
        }
        #endregion

        #region �⍇���ԍ�(�⍇���������)����
        /// <summary>
        /// �⍇���ԍ� �⍇��������ʁu�S�āv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_InqOrdDivAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_InqOrdDivAll.Checked)
            {
                this.uCheckEditor_InqOrdDivAccept.Checked = false;
                this.uCheckEditor_InqOrdDivEstimate.Checked = false;
            }
        }

        /// <summary>
        /// �⍇���ԍ� �⍇��������ʁu�󒍁v
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_InqOrdDivAccept_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_InqOrdDivAccept.Checked)
            {
                this.uCheckEditor_InqOrdDivAll.Checked = false;
            }
        }

        /// <summary>
        /// �⍇���ԍ� �⍇��������ʁu���ρv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_InqOrdDivEstimate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.uCheckEditor_InqOrdDivEstimate.Checked)
            {
                this.uCheckEditor_InqOrdDivAll.Checked = false;
            }
        }
        #endregion

        #region �c�[���o�[�N���b�N
        /// <summary>
        /// tToolbarsManager1_ToolClick�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        this.Close();
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        this.Search();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        // ��ʃN���A
                        this.ClearScreen();

                        // �O���b�h�N���A
                        this._scmAnsHistInquiryAcs.SCMAnsHistInquiryDataTable.Clear();

                        this.Initial_Timer.Enabled = true;

                        break;
                    }
            }
        }
        #endregion

        #region �O���b�h�֘A
        /// <summary>
        /// uGrid_Details_Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            // �A�N�e�B�u�s�̉���
            if (this.uGrid_Details.ActiveRow != null)
            {
                this.uGrid_Details.ActiveRow.Selected = false;
                this.uGrid_Details.ActiveRow = null;
            }
        }

        /// <summary>
        /// uGrid_Details_InitializeLayout�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // �w�b�_�N���b�N�A�N�V�����̐ݒ�(�\�[�g����)
            e.Layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            // �s�t�B���^�[�ݒ�
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            // ��ړ��\
            e.Layout.Override.AllowColMoving = AllowColMoving.WithinBand;
        }

        /// <summary>
        /// uGrid_Details_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.Rows.Count == 0 ||
                ((uGrid.ActiveCell == null) && (uGrid.ActiveRow == null)))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            e.Handled = true;
                            this.tNedit_CarMakerCode.Focus();
                            break;
                        }
                    case Keys.Down:
                    case Keys.Right:
                        {
                            e.Handled = true;
                            this.tde_InquiryDateSt.Focus();
                            break;
                        }
                    case Keys.Left:
                        {
                            e.Handled = true;
                            if (this.uGroupBox_DetailInfo.Expanded)
                            {
                                this.tEdit_PureGoodsNo.Focus();
                            }
                            else
                            {
                                this.tNedit_InquiryNumber_Ed.Focus();
                            }

                            break;
                        }
                }

                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Left:
                    {
                        e.Handled = true;
                        if (uGrid.DisplayLayout.ActiveRow.Index != 0)
                        {
                            uGrid.PerformAction(UltraGridAction.AboveRow);
                        }
                        else
                        {
                            if (e.KeyCode == Keys.Up)
                            {
                                this.tNedit_CarMakerCode.Focus();
                            }
                            else
                            {
                                if (this.uGroupBox_DetailInfo.Expanded)
                                {
                                    this.tEdit_PureGoodsNo.Focus();
                                }
                                else
                                {
                                    this.tNedit_InquiryNumber_Ed.Focus();
                                }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                case Keys.Right:
                    {
                        e.Handled = true;
                        if (uGrid.DisplayLayout.ActiveRow.Index != uGrid.DisplayLayout.Rows.Count - 1)
                        {
                            uGrid.PerformAction(UltraGridAction.BelowRow);
                        }
                        else
                        {
                            this.tde_InquiryDateSt.Focus();
                        }
                        break;
                    }
            }
        }
        #endregion

        #endregion

    }
}