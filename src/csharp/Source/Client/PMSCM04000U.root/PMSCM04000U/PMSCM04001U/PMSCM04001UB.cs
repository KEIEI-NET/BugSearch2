//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �⍇���ꗗ/�󒍌����E�B���h�E
// �v���O�����T�v   : SCM�󒍃f�[�^�ASCM�󒍖��׃f�[�^�̏Ɖ���s���B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �� �� ��  2009/05/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/04/16  �C�����e : �L�����Z���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/17  �C�����e : �L�����Z���ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���n ���
// �� �� ��  2010/06/17  �C�����e : Delphi���`���N������悤�ɕύX
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� ��
// �� �� ��  2011/01/24  �C�����e : �E���גP�ʂŉ񓚏󋵂��킩��悤�ɏC��
//                                 �E�⍇/������ʖ��ׂŕ\������悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� ��
// �� �� ��  2011/02/14  �C�����e : �E����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �v�ۓc ��
// �� �� ��  2011/05/26  �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10703242-00 �쐬�S�� : 20056 ���n ���
// �� �� ��  2011/06/09  �C�����e : ���̕ύX�Ή�[SCM��PCC]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : wangl2
// �� �� ��  2013/04/03  �C�����e : Redmine#35273 (SCM��Q��10319)�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : qijh
// �� �� ��  2013/02/27  �C�����e : 2013/06/18�z�M Redmine#34752 �uPMSCM��No.10385�vBLP�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �g��
// �� �� ��  2015/02/20  �C�����e : SCM������ C������ʓ��L�Ή�
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �⍇���ꗗ(����)/�󒍌����E�B���h�E(����)�����t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM�󒍃f�[�^�ASCM�󒍖��׃f�[�^�̏Ɖ���s��</br>
    /// <br>Programmer : 30452 ��� �r��</br>
    /// <br>Date       : 2009.05.27</br>
    /// <br></br>
    public partial class PMSCM04001UB : Form
    {
        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        # region Event
        /// <summary>��ʒ��o�����擾�C�x���g</summary>
        internal event SetExtraInfoFromScreen SetScreen;

        # endregion

        // ===================================================================================== //
        // �f���Q�[�g
        // ===================================================================================== //
        # region Delegate
        /// <summary>
        /// ��ʒ��o�����擾�f���Q�[�g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="salesRowNo"></param>
        internal delegate SCMInquiryOrder SetExtraInfoFromScreen();

        # endregion

        #region ��private�萔
        //>>>2010/06/17
        //private const string SALESSLIPINPUT_EXE_NAME = "MAHNB01000U.exe"; // ����`�[���͂̎��sexe
        private const string SALESSLIPINPUT_EXE_NAME = "MAHNB01001U.exe"; // ����`�[���͂̎��sexe
        //<<<2010/06/17
        // ��ʏ�ԕۑ��p�t�@�C����
        private const string XML_FILE_INITIAL_DATA = "PMSCM04001UB.dat";// ADD  2013/04/03 wangl2 #35273
        #endregion

        #region ��private�ϐ�

        private ControlScreenSkin _controlScreenSkin; // ���ʃX�L��

        SCMInquiryOrderAcs _scmInquiryOrderAcs; // �⍇���ꗗ�\�A�N�Z�X�N���X

        UltraGridRow _scmInquiryResultRow; // SCM�󒍃f�[�^(�`�[)

        // -- ADD 2010/02/09 -------------------->>>
        string _inquiryNumber = string.Empty;    //�⍇���ԍ�

        string _acptAnOdrStatus = string.Empty;  //�󒍃X�e�[�^�X
 
        string _salesSlipNum = string.Empty;     //����`�[�ԍ�
        // -- ADD 2010/02/09 --------------------<<<

        // -- ADD 2010/03/02 -------------------->>>
        string _inqOriginalEpCd = string.Empty;  //�⍇������ƃR�[�h

        string _inqOriginalSecCd = string.Empty; //�⍇�������_�R�[�h
        // -- ADD 2010/03/02 --------------------<<<

        // 2011/02/14 Add >>>
        int _inqOrdDivCd = 0;                    // �⍇���E�������
        // 2011/02/14 Add <<<

        // 2010/05/27 Add >>>
        int _answerDivCd = 0;
        // 2010/05/27 Add <<<

        private Mode _mode; // �N�����[�h

        private string[] _commandLineArgs; // �R�}���h���C������

        private bool _isLegacySection; // ���V�X�e���A�g�L��(true:���V�X�e���A�g����)
        // �O���b�h��ԕۑ�
        private GridStateController _gridStateController;// ADD  2013/04/03 wangl2 #35273

        #endregion

        #region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMSCM04001UB()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="commandLineArgs">�e��ʋN�����̃R�}���h���C������</param>
        /// <param name="scmInquiryResultRow">�e��ʂőI������SCM�󒍃f�[�^(�`�[)</param>
        public PMSCM04001UB(int mode, string[] commandLineArgs, UltraGridRow scmInquiryResultRow, bool isLegacySection,
            bool canInputSalesSlip  // ADD 2010/04/16 �L�����Z���Ή�
        ) : this()
        {
            this._mode = (Mode)mode;
            this._commandLineArgs = commandLineArgs;
            this._scmInquiryResultRow = scmInquiryResultRow;
            this._isLegacySection = isLegacySection;


            // -- ADD 2010/02/09 -------------------->>>
            this.GetGuideInstance();
            this._inquiryNumber = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value.ToString();
            this._acptAnOdrStatus = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AcptAnOdrStatusColumn.ColumnName].Value.ToString();
            this._salesSlipNum = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName].Value.ToString();
            // -- ADD 2010/02/09 --------------------<<<

            // -- ADD 2010/03/02 -------------------->>>
            this._inqOriginalEpCd = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalEpCdColumn.ColumnName].Value.ToString().Trim();	//@@@@20230303
            this._inqOriginalSecCd = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalSecCdColumn.ColumnName].Value.ToString();
            // -- ADD 2010/03/02 --------------------<<<

            // 2010/05/27 Add >>>
            this._answerDivCd = (int)this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName].Value;
            // 2010/05/27 Add <<<

            // 2011/02/14 Add >>>
            this._inqOrdDivCd = (int)this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOrdDivCdColumn.ColumnName].Value;
            // 2011/02/14 Add <<<

            // 2010/05/27 >>>
            //// ADD 2010/04/16 �L�����Z���Ή� ---------->>>>>
            //// �ȉ��̏ꍇ�A����`�[���͂��s���܂���B
            //// �@�񓚋敪����񓚊����
            //// �A�񓚋敪����L�����Z����Łw���񓚃f�[�^���S�ăL�����Z���x�܂��́w�S�ĕԕi�ς݁x
            //this.uButton_SalesSlip.Enabled = canInputSalesSlip;
            //// ADD 2010/04/16 �L�����Z���Ή� ----------<<<<<


            this.uButton_SalesSlip.Visible = false;
            // 2010/05/27 <<<
        }
        #endregion

        #region ��private���\�b�h
        /// <summary>
        /// Visible�ݒ�C�x���g�R�[������
        /// </summary>
        private SCMInquiryOrder SetExtraInfoFromScreenEventCall()
        {
            if (this.SetScreen != null)
            {
                return this.SetScreen();
            }
            return null;
        }

        /// <summary>
        /// ��ʏ����ݒ�
        /// </summary>
        private void SetInitialSetting()
        {
            this._gridStateController = new GridStateController();// ADD  2013/04/03 wangl2 #35273
            // �^�C�g��
            if (this._mode == Mode.SalesSlip)
            {
                this.Text = "�󒍌����E�B���h�E�i���ׁj";
            }
            else
            {
                //>>>2011/06/09
                //this.Text = "SCM�⍇���ꗗ�i���ׁj";
                this.Text = "PCC�⍇���ꗗ�i���ׁj";
                //<<<2011/06/09
            }

            // �K�C�h�A�N�Z�X������
            this.GetGuideInstance();
            
            // �X�L���ݒ�
            this._controlScreenSkin = new ControlScreenSkin();

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // �{�^������
            // �C���[�W�ݒ�
            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.uButton_SalesSlip.Appearance.Image = imageList16.Images[(int)Size16_Index.SLIP];
            this.uButton_SalesSlip.Appearance.ImageHAlign = HAlign.Center;
            this.uButton_SalesSlip.Appearance.ImageVAlign = VAlign.Top;
            this.uButton_Close.Appearance.Image = imageList16.Images[(int)Size16_Index.CLOSE];
            this.uButton_Close.Appearance.ImageHAlign = HAlign.Center;
            this.uButton_Close.Appearance.ImageVAlign = VAlign.Top;

            // �e��ʂ�����`�[���͉�ʂ���J�ڂ����ꍇ�ƁA
            // ���V�X�e���A�g���_�̏ꍇ�͔���`�[���̓{�^�����\���ɂ���B
            if (this._mode == Mode.SalesSlip || this._isLegacySection)
            {
                this.uButton_SalesSlip.Visible = false;
            }

            // �e���ڂ̏����l�ݒ�
            // �ޕ�
            this.uLabel_ModelCategory.Text 
                = this._scmInquiryResultRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ModelCategoryColumn.ColumnName].Value.ToString();

            // �Ԏ�
            this.uLabel_ModelName.Text
                = this._scmInquiryResultRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ModelNameColumn.ColumnName].Value.ToString();

            // �^��
            this.uLabel_ModelDesignationNo.Text
                = this._scmInquiryResultRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.FullModelColumn.ColumnName].Value.ToString();

            // �N��
            this.uLabel_ProduceTypeOfYearNum.Text
                = this._scmInquiryResultRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ProduceTypeOfYearStringColumn.ColumnName].Value.ToString();

            // ���z
            Int64 salesTotalTaxInc = (Int64)this._scmInquiryResultRow.Cells[
                this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesTotalTaxIncColumn.ColumnName].Value;
            this.uLabel_SalesTotalTaxInc.Text
                = salesTotalTaxInc.ToString("#,##0");

            // �O���b�h�ݒ�
            this.SetGridSetting();

            this.LoadStateXmlData();// ADD  2013/04/03 wangl2 #35273
        }

        /// <summary>
        /// �K�C�h�A�N�Z�X������
        /// </summary>
        private void GetGuideInstance()
        {
            this._scmInquiryOrderAcs = SCMInquiryOrderAcs.GetInstance();
        }

        /// <summary>
        /// �O���b�h�ݒ�
        /// </summary>
        private void SetGridSetting()
        {
            // ��ʁ����o�����N���X
            SCMInquiryOrder scmInquiryOrder = this.SetExtraInfoFromScreenEventCall();

            SCMAcOdrDataDataSet.SCMInquiryResultDataTable ttable = this._scmInquiryOrderAcs.SCMInquiryResultDataTable;

            SCMInquiryResultWork scmInquiryResultWork = new SCMInquiryResultWork();
            scmInquiryResultWork.AcptAnOdrStatus = (int)this._scmInquiryResultRow.Cells[ttable.AcptAnOdrStatusColumn.ColumnName].Value;
            //scmInquiryResultWork.AnsEmployeeCd = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnsEmployeeCdColumn.ColumnName].Value;
            //scmInquiryResultWork.AnsEmployeeNm = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnsEmployeeNmColumn.ColumnName].Value;
            
            scmInquiryResultWork.AnswerDivCd = (int)this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName].Value;
            
            //scmInquiryResultWork.AwnserMethod = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerMethodColumn.ColumnName].Value;
            //scmInquiryResultWork.CarInspectCertModel = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.CarInspectCertModelColumn.ColumnName].Value;
            //scmInquiryResultWork.CarProperNo = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.CarProperNoColumn.ColumnName].Value;
            //scmInquiryResultWork.CategoryNo = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.CategoryNoColumn.ColumnName].Value;
            //scmInquiryResultWork.ChassisNo = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ChassisNoColumn.ColumnName].Value;
            //scmInquiryResultWork.ColorName1 = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ColorName1Column.ColumnName].Value;
            //scmInquiryResultWork.Comment = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.CommentColumn.ColumnName].Value;
            //scmInquiryResultWork.CustomerCode = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.CustomerCodeColumn.ColumnName].Value;
            //scmInquiryResultWork.CustomerName = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.CustomerNameColumn.ColumnName].Value;
            scmInquiryResultWork.EnterpriseCode = scmInquiryOrder.EnterpriseCode;
            //scmInquiryResultWork.FrameModel = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.FrameModelColumn.ColumnName].Value;
            //scmInquiryResultWork.FrameNo = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.FrameNoColumn.ColumnName].Value;
            //scmInquiryResultWork.FullModel = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.FullModelColumn.ColumnName].Value;
            //scmInquiryResultWork.InqEmployeeCd = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqEmployeeCdColumn.ColumnName].Value;
            //scmInquiryResultWork.InqEmployeeCd_Car = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqEmployeeCdCarColumn.ColumnName].Value;
            //scmInquiryResultWork.InqEmployeeNm = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqEmployeeNmColumn.ColumnName].Value;
            //scmInquiryResultWork.InqEmployeeNm_Car = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqEmployeeNmCarColumn.ColumnName].Value;
            scmInquiryResultWork.InqOrdDivCd = (int)this._scmInquiryResultRow.Cells[ttable.InqOrdDivCdColumn.ColumnName].Value;
            //scmInquiryResultWork.InqOrdNote = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOrdNoteColumn.ColumnName].Value;

            scmInquiryResultWork.InqOriginalEpCd = ((string)this._scmInquiryResultRow.Cells[ttable.InqOriginalEpCdColumn.ColumnName].Value).Trim();	//@@@@20230303
            scmInquiryResultWork.InqOriginalSecCd = (string)this._scmInquiryResultRow.Cells[ttable.InqOriginalSecCdColumn.ColumnName].Value;
            scmInquiryResultWork.InqOtherEpCd = (string)this._scmInquiryResultRow.Cells[ttable.InqOtherEpCdColumn.ColumnName].Value;
            scmInquiryResultWork.InqOtherSecCd = (string)this._scmInquiryResultRow.Cells[ttable.InqOtherSecCdColumn.ColumnName].Value;
            //scmInquiryResultWork.InquiryDate = (int)this._scmInquiryResultRow.Cells[ttable.InquiryDateColumn.ColumnName].Value;
            //scmInquiryResultWork.InquiryDate_Car = (int)this._scmInquiryResultRow.Cells[ttable.InquiryDateCarColumn.ColumnName].Value;
            scmInquiryResultWork.InquiryNumber = (long)this._scmInquiryResultRow.Cells[ttable.InquiryNumberColumn.ColumnName].Value;

            //scmInquiryResultWork.JudgementDate = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.JudgementDateColumn.ColumnName].Value;
            //scmInquiryResultWork.MakerCode = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.MakerCodeColumn.ColumnName].Value;
            //scmInquiryResultWork.Mileage = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.MileageColumn.ColumnName].Value;
            //scmInquiryResultWork.ModelCode = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ModelCodeColumn.ColumnName].Value;
            //scmInquiryResultWork.ModelDesignationNo = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ModelDesignationNoColumn.ColumnName].Value;
            //scmInquiryResultWork.ModelName = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ModelNameColumn.ColumnName].Value;
            //scmInquiryResultWork.ModelSubCode = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ModelSubCodeColumn.ColumnName].Value;
            //scmInquiryResultWork.NumberPlate1Code = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.NumberPlate1CodeColumn.ColumnName].Value;
            //scmInquiryResultWork.NumberPlate1Name = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.NumberPlate1NameColumn.ColumnName].Value;
            //scmInquiryResultWork.NumberPlate2 = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.NumberPlate2Column.ColumnName].Value;
            //scmInquiryResultWork.NumberPlate3 = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.NumberPlate3Column.ColumnName].Value;
            //scmInquiryResultWork.NumberPlate4 = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.NumberPlate4Column.ColumnName].Value;
            //scmInquiryResultWork.ProduceTypeOfYearNum = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.ProduceTypeOfYearNumColumn.ColumnName].Value;
            //scmInquiryResultWork.RpColorCode = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.RpColorCodeColumn.ColumnName].Value;
            //scmInquiryResultWork.SalesOrderDate_Car = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesOrderDateCarColumn.ColumnName].Value;
            //scmInquiryResultWork.SalesOrderEmployeeCd = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesOrderEmployeeCdColumn.ColumnName].Value;
            //scmInquiryResultWork.SalesOrderEmployeeNm = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesOrderEmployeeNmColumn.ColumnName].Value;
            // DEL 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ---------->>>>>
            // FIXME:1�⍇���������̓`�[�ɕ�����邱�Ƃ�����̂ŁA�`�[�ԍ��������ɐݒ肵�Ȃ�
            scmInquiryResultWork.SalesSlipNum = (string)this._scmInquiryResultRow.Cells[ttable.SalesSlipNumColumn.ColumnName].Value;
            // DEL 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ----------<<<<<
            //scmInquiryResultWork.SalesTotalTaxInc = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesTotalTaxIncColumn.ColumnName].Value;
            //scmInquiryResultWork.TrimCode = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.TrimCodeColumn.ColumnName].Value;
            //scmInquiryResultWork.TrimName = this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.TrimNameColumn.ColumnName].Value;

            scmInquiryResultWork.UpdateDate = (DateTime)this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.UpdateDateColumn.ColumnName].Value;
            scmInquiryResultWork.UpdateTime = (int)this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.UpdateTimeColumn.ColumnName].Value;
            
            //this._scmInquiryOrderAcs.Setting
            string errMsg;

            // DEL 2010/06/17 �L�����Z���ǉ��Ή� ---------->>>>>
            int status = 0; // finally��Ŏ��{����A�O���b�h�̃t�H���g�F��ԂɕύX���鏈���Ŏg�p
            // DEL 2010/06/17 �L�����Z���ǉ��Ή� ----------<<<<<
            if (scmInquiryResultWork != null)
            {
                // DEL 2010/06/17 �L�����Z���ǉ��Ή� ---------->>>>>
                //this._scmInquiryOrderAcs.SearchDetail(scmInquiryResultWork, out errMsg);
                // DEL 2010/06/17 �L�����Z���ǉ��Ή� ----------<<<<<
                // ADD 2010/06/17 �L�����Z���ǉ��Ή� ---------->>>>>
                status = this._scmInquiryOrderAcs.SearchDetail(scmInquiryResultWork, out errMsg);
                // ADD 2010/06/17 �L�����Z���ǉ��Ή� ---------->>>>>
            }
            
            //// �f�[�^�\�[�X�ݒ�
            //int linkKey = (int)this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable.DetailLinkKeyNumberColumn.ColumnName].Value;

            DataView dv = new DataView(this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable);

            //// PMSCM04001UA�őI�������sKey�Ńt�B���^
            //dv.RowFilter = this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable.DetailLinkKeyNumberColumn.ColumnName + " = " + linkKey;

            // �s�ԍ��̐ݒ�
            for (int i = 0; i < dv.Count; i++)
            {
                dv[i][this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable.RowNumberColumn.ColumnName] = i + 1;
            }

            dv.RowStateFilter = DataViewRowState.CurrentRows;

            this.uGrid_Details.DataSource = dv;

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

                SCMAcOdrDataDataSet.SCMInquiryDetailResultDataTable table = (SCMAcOdrDataDataSet.SCMInquiryDetailResultDataTable)this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable;

                // �Œ��ݒ�(�s�ԍ���̂�)
                columns[table.RowNumberColumn.ColumnName].Header.Fixed = true;

                // �s�ԍ���̃Z���\���F�ύX
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
                columns[table.RowNumberColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
                columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColor = Color.White;
                columns[table.RowNumberColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;

                int visiblePosition = 0;

                // No.��
                columns[table.RowNumberColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.RowNumberColumn.ColumnName].Header.Caption = "No."; // ��L���v�V����
                columns[table.RowNumberColumn.ColumnName].Width = 50; // �\����
                columns[table.RowNumberColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.RowNumberColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // 2011/01/24 Add >>>
                columns[table.InqAnsDivNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.InqAnsDivNameColumn.ColumnName].Header.Caption = "�񓚋敪"; // ��L���v�V����
                columns[table.InqAnsDivNameColumn.ColumnName].Width = 80; // �\����
                columns[table.InqAnsDivNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.InqAnsDivNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                // 2011/01/24 Add <<<

                // BL�R�[�h��
                columns[table.BLGoodsCodeColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.BLGoodsCodeColumn.ColumnName].Header.Caption = "BL�R�[�h"; // ��L���v�V����
                columns[table.BLGoodsCodeColumn.ColumnName].Width = 100; // �\����
                columns[table.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.BLGoodsCodeColumn.ColumnName].Format = "00000";
                columns[table.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �i����
                columns[table.GoodsNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.GoodsNameColumn.ColumnName].Header.Caption = "�i��"; // ��L���v�V����
                columns[table.GoodsNameColumn.ColumnName].Width = 200; // �\����
                columns[table.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �i�ԗ�
                columns[table.GoodsNoColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.GoodsNoColumn.ColumnName].Header.Caption = "�i��"; // ��L���v�V����
                columns[table.GoodsNoColumn.ColumnName].Width = 200; // �\����
                columns[table.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ���[�J�[��
                columns[table.MakerNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.MakerNameColumn.ColumnName].Header.Caption = "���[�J�["; // ��L���v�V����
                columns[table.MakerNameColumn.ColumnName].Width = 100; // �\����
                columns[table.MakerNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.MakerNameColumn.ColumnName].Format = "0000";
                columns[table.MakerNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �󒍐���
                columns[table.SalesOrderCountColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.SalesOrderCountColumn.ColumnName].Header.Caption = "�󒍐�"; // ��L���v�V����
                columns[table.SalesOrderCountColumn.ColumnName].Width = 100; // �\����
                columns[table.SalesOrderCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.SalesOrderCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesOrderCountColumn.ColumnName].Format = "#,##0.00";

                // �o�א���
                columns[table.DeliveredGoodsCountColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.DeliveredGoodsCountColumn.ColumnName].Header.Caption = "�o�א�"; // ��L���v�V����
                columns[table.DeliveredGoodsCountColumn.ColumnName].Width = 100; // �\����
                columns[table.DeliveredGoodsCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.DeliveredGoodsCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.DeliveredGoodsCountColumn.ColumnName].Format = "#,##0.00";

                // �W�����i��
                columns[table.ListPriceColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.ListPriceColumn.ColumnName].Header.Caption = "�W�����i"; // ��L���v�V����
                columns[table.ListPriceColumn.ColumnName].Width = 100; // �\����
                columns[table.ListPriceColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.ListPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.ListPriceColumn.ColumnName].Format = "#,##0";

                // ���P����
                columns[table.UnitPriceColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.UnitPriceColumn.ColumnName].Header.Caption = "���P��"; // ��L���v�V����
                columns[table.UnitPriceColumn.ColumnName].Width = 100; // �\����
                columns[table.UnitPriceColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.UnitPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.UnitPriceColumn.ColumnName].Format = "#,##0";

                // ���z��
                columns[table.SalesMoneyColumn.ColumnName].Hidden = true; // �\���ݒ�
                columns[table.SalesMoneyColumn.ColumnName].Header.Caption = "���z"; // ��L���v�V����
                columns[table.SalesMoneyColumn.ColumnName].Width = 100; // �\����
                columns[table.SalesMoneyColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.SalesMoneyColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesMoneyColumn.ColumnName].Format = "#,##0";

                // ����ŗ�
                columns[table.SalesPriceConsTaxColumn.ColumnName].Hidden = true; // �\���ݒ�
                columns[table.SalesPriceConsTaxColumn.ColumnName].Header.Caption = "�����"; // ��L���v�V����
                columns[table.SalesPriceConsTaxColumn.ColumnName].Width = 100; // �\����
                columns[table.SalesPriceConsTaxColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.SalesPriceConsTaxColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesPriceConsTaxColumn.ColumnName].Format = "#,##0";

                //--- DEL 2011/05/26 --------------------------------------------------------->>>
                // �I�ԗ�
                //columns[table.ShelfNoColumn.ColumnName].Hidden = false; // �\���ݒ�
                //columns[table.ShelfNoColumn.ColumnName].Header.Caption = "�I��"; // ��L���v�V����
                //columns[table.ShelfNoColumn.ColumnName].Width = 100; // �\����
                //columns[table.ShelfNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                //columns[table.ShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                //--- DEL 2011/05/26 ---------------------------------------------------------<<<

                //--- ADD 2011/05/26 --------------------------------------------------------->>>
                // �q�ɖ���
                columns[table.WarehouseNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.WarehouseNameColumn.ColumnName].Header.Caption = "�q��"; // ��L���v�V����
                columns[table.WarehouseNameColumn.ColumnName].Width = 100; // �\����
                columns[table.WarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.WarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // �I�ԗ�
                columns[table.WarehouseShelfNoColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.WarehouseShelfNoColumn.ColumnName].Header.Caption = "�I��"; // ��L���v�V����
                columns[table.WarehouseShelfNoColumn.ColumnName].Width = 100; // �\����
                columns[table.WarehouseShelfNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.WarehouseShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                //--- ADD 2011/05/26 ---------------------------------------------------------<<<

                // ���T�C�N�����
                columns[table.RecyclePrtKindNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.RecyclePrtKindNameColumn.ColumnName].Width = 120; // �\����
                columns[table.RecyclePrtKindNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.RecyclePrtKindNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ���ה��l
                columns[table.CommentDtlColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.CommentDtlColumn.ColumnName].Width = 150; // �\����
                columns[table.CommentDtlColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.CommentDtlColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.CommentDtlColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;

                // ADD 2010/04/16 �L�����Z���Ή� ---------->>>>>
                // �`�[�敪
                columns[table.SlipNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.SlipNameColumn.ColumnName].Width = 100; // �\����
                columns[table.SlipNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.SlipNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SlipNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;

                // �`�[�ԍ�
                columns[table.SalesSlipNumColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.SalesSlipNumColumn.ColumnName].Width = 100; // �\����
                columns[table.SalesSlipNumColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.SalesSlipNumColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.SalesSlipNumColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button;
                // ADD 2010/04/16 �L�����Z���Ή� ----------<<<<<

                // ADD 2010/06/17 �L�����Z���ǉ��Ή� ---------->>>>>
                // ��ԗ�
                columns[table.StateColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.StateColumn.ColumnName].Header.Caption = "�L�����Z�����"; // ��L���v�V����
                columns[table.StateColumn.ColumnName].Width = 120; // �\����
                columns[table.StateColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.StateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.StateColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.Red;
                // ADD 2010/06/17 �L�����Z���ǉ��Ή� ----------<<<<<

                // ------------ ADD START 2013/02/27 qijh #34752 ---------- >>>>>>
                // PM��Ǒq�ɃR�[�h
                columns[table.PmMainMngWarehouseCdColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.PmMainMngWarehouseCdColumn.ColumnName].Width = 120; // �\����
                columns[table.PmMainMngWarehouseCdColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.PmMainMngWarehouseCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // PM��Ǒq�ɖ���
                columns[table.PmMainMngWarehouseNameColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.PmMainMngWarehouseNameColumn.ColumnName].Width = 120; // �\����
                columns[table.PmMainMngWarehouseNameColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.PmMainMngWarehouseNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // PM��ǒI��
                columns[table.PmMainMngShelfNoColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.PmMainMngShelfNoColumn.ColumnName].Width = 100; // �\����
                columns[table.PmMainMngShelfNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.PmMainMngShelfNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // PM��ǌ��݌�
                columns[table.PmMainMngPrsntCountColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.PmMainMngPrsntCountColumn.ColumnName].Width = 120; // �\����
                columns[table.PmMainMngPrsntCountColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;// �\���ʒu
                columns[table.PmMainMngPrsntCountColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                columns[table.PmMainMngPrsntCountColumn.ColumnName].Format = "#,##0.00;-#,##0.00;";
                // ------------ ADD END 2013/02/27 qijh #34752 ---------- <<<<<<

                // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   -------------->>>>>>>>>>>>>>>>>>>>
                // ���i�K�i�E���L����(�H�����)
                columns[table.GoodsSpecialNtForFacColumn.ColumnName].Hidden = true; // �\���ݒ�
                columns[table.GoodsSpecialNtForFacColumn.ColumnName].Width = 120; // �\����
                columns[table.GoodsSpecialNtForFacColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.GoodsSpecialNtForFacColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

                // ���i�K�i�E���L����(�J�[�I�[�i�[����)
                columns[table.GoodsSpecialNtForCOwColumn.ColumnName].Hidden = true; // �\���ݒ�
                columns[table.GoodsSpecialNtForCOwColumn.ColumnName].Width = 120; // �\����
                columns[table.GoodsSpecialNtForCOwColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.GoodsSpecialNtForCOwColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                // �D�ǐݒ�ڍז��̂Q(�H�����)
                columns[table.PrmSetDtlName2ForFacColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.PrmSetDtlName2ForFacColumn.ColumnName].Width = 120; // �\����
                columns[table.PrmSetDtlName2ForFacColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.PrmSetDtlName2ForFacColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                columns[table.PrmSetDtlName2ForCOwColumn.ColumnName].Hidden = false; // �\���ݒ�
                columns[table.PrmSetDtlName2ForCOwColumn.ColumnName].Width = 120; // �\����
                columns[table.PrmSetDtlName2ForCOwColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Left;// �\���ʒu
                columns[table.PrmSetDtlName2ForCOwColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
                // ADD 2015/02/20 �g�� SCM������ C������ʓ��L�Ή�   --------------<<<<<<<<<<<<<<<<<<<<
            }
            finally
            {
                this.uGrid_Details.EndUpdate();

                // ADD 2010/06/17 �L�����Z���ǉ��Ή� ---------->>>>>
                // �u�L�����Z���敪�v���u10:�L�����Z���v���v�̖��ׂ̓t�H���g�F��Ԃɂ���
                if (status.Equals(0))
                {
                    SCMAcOdrDataDataSet columnName = new SCMAcOdrDataDataSet();
                    string stateCellName = columnName.SCMInquiryDetailResult.StateColumn.ColumnName;
                    for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
                    {
                        // 2011/02/14 >>>
                        //string state = this.uGrid_Details.Rows[i].Cells[stateCellName].Value.ToString();
                        int cancelCndtinDiv = (int)this.uGrid_Details.Rows[i].Cells[columnName.SCMInquiryDetailResult.CancelCndtinDivColumn.ColumnName].Value;
                        // 2011/02/14 <<<

                        Color fontColor = Color.Black;
                        // 2011/02/14 >>>
                        //if (
                        //    state.Equals(SCMInquiryDBAgent.GetCancelCndtinDivName((int)CancelCndtinDiv.Cancelling))
                        //        ||
                        //    state.Equals(SCMInquiryDBAgent.GetCancelCndtinDivName((int)CancelCndtinDiv.Cancelled))
                        //)
                        // �񓚋敪�u�L�����Z���v�ȊO�Ŗ��ׂ��u�L�����Z���m��v�́A����f�[�^
                        if (_answerDivCd != (int)AnswerDivCd.Cancel && cancelCndtinDiv.Equals((int)CancelCndtinDiv.Cancelled))
                        {
                            fontColor = Color.Gray;
                        }
                        else if (cancelCndtinDiv.Equals((int)CancelCndtinDiv.Cancelling) ||
                                 cancelCndtinDiv.Equals((int)CancelCndtinDiv.Cancelled)
                        )
                        // 2011/02/14 <<<
                        {
                            // �u10:�L�����Z���v���v�u30:�L�����Z����t�v�͐�
                            fontColor = Color.Red;
                        }
                        int iCell = 0;
                        foreach (UltraGridCell cell in this.uGrid_Details.Rows[i].Cells)
                        {
                            if (iCell > 0)  // �擪�̃Z��(No.�Z��)�͐F��ς��Ȃ�
                            {
                                cell.Appearance.ForeColorDisabled = fontColor;
                            }
                            iCell++;
                        }
                    }
                }
                // ADD 2010/06/17 �L�����Z���ǉ��Ή� ----------<<<<<
            }
        }

        // 2010/05/27 Add >>>

        /// <summary>
        /// ���������擾
        /// </summary>
        /// <returns></returns>
        private SCMInquiryOrder GetSearchCndtn()
        {
            SCMInquiryOrder cndtn = new SCMInquiryOrder();

            cndtn.EnterpriseCode = (string)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.EnterpriseCodeColumn.ColumnName].Value;

            cndtn.AcptAnOdrStatus = new int[1] { (int)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AcptAnOdrStatusColumn.ColumnName].Value };

            cndtn.AnswerDivCd = new int[1] { (int)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AnswerDivCdColumn.ColumnName].Value };

            cndtn.InqOrdDivCd = new int[1] { (int)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOrdDivCdColumn.ColumnName].Value };

            cndtn.InqOriginalEpCd = ((string)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalEpCdColumn.ColumnName].Value).Trim();//@@@@20230303
            cndtn.InqOriginalSecCd = (string)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOriginalSecCdColumn.ColumnName].Value;
            cndtn.InqOtherEpCd = (string)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOtherEpCdColumn.ColumnName].Value;
            cndtn.InqOtherSecCd = (string)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InqOtherSecCdColumn.ColumnName].Value;
            cndtn.St_InquiryNumber = (long)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value;

            cndtn.SalesSlipNum = (string)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName].Value;
            cndtn.UpdateDate = (DateTime)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.UpdateDateColumn.ColumnName].Value;
            cndtn.UpdateTime = (int)_scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.UpdateTimeColumn.ColumnName].Value;
            return cndtn;
        }
       
        // 2010/05/27 Add <<<
        #endregion

        #region ���C�x���g
        /// <summary>
        /// PMSCM04001UB_Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMSCM04001UB_Load(object sender, EventArgs e)
        {
            // ��ʏ����ݒ�
            this.SetInitialSetting();

            this.uGrid_Details.ActiveRow = null;
        }

        /// <summary>
        /// uButton_SalesSlip_Click�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_SalesSlip_Click(object sender, EventArgs e)
        {
            string programPath = Path.Combine(Directory.GetCurrentDirectory(), SALESSLIPINPUT_EXE_NAME);
            if (!File.Exists(programPath)) return;

            // ���O�C���p�����[�^����ݒ�
            // �|�b�v�A�b�v����̋N���̏ꍇ�A�������ǉ�����Ă���̂Ŏg�p���Ȃ��B
            StringBuilder loginArguments = new StringBuilder();
            {
                for (int i = 0; i < this._commandLineArgs.Length && i < 2; i++)
                {
                    string argument = this._commandLineArgs[i];

                    if (!string.IsNullOrEmpty(argument.Trim()))
                    {
                        loginArguments.Append(argument + " ");
                    }
                }
            }

            // -- ADD 2010/03/02 ------------------>>>
            //// -- UPD 2010/02/09 ------------------>>>
            ////// �⍇���ԍ���ǉ�
            ////loginArguments.Append(this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.InquiryNumberColumn.ColumnName].Value.ToString() + " ");
            ////// �󒍃X�e�[�^�X��ǉ�
            ////loginArguments.Append(this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.AcptAnOdrStatusColumn.ColumnName].Value.ToString() + " ");
            ////// �`�[�ԍ���ǉ�
            ////loginArguments.Append(this._scmInquiryResultRow.Cells[this._scmInquiryOrderAcs.SCMInquiryResultDataTable.SalesSlipNumColumn.ColumnName].Value.ToString() + " ");

            //// �⍇���ԍ���ǉ�
            //loginArguments.Append(this._inquiryNumber + " ");
            //// �󒍃X�e�[�^�X��ǉ�
            //loginArguments.Append(this._acptAnOdrStatus + " ");
            //// �`�[�ԍ���ǉ�
            //loginArguments.Append(this._salesSlipNum + " ");
            //// -- UPD 2010/02/09 ------------------<<<

            //���`�N�����[�h
            loginArguments.Append("/INQ ");
            // �⍇���ԍ���ǉ�
            loginArguments.Append(this._inquiryNumber + ",");
            // �󒍃X�e�[�^�X��ǉ�
            loginArguments.Append(this._acptAnOdrStatus + ",");
            // �`�[�ԍ���ǉ�
            loginArguments.Append(this._salesSlipNum + ",");
            // �⍇������ƃR�[�h��ǉ�
            loginArguments.Append(this._inqOriginalEpCd.Trim() + ",");//@@@@20230303_
            // �⍇�������_�R�[�h��ǉ�
            loginArguments.Append(this._inqOriginalSecCd + "");
            // -- ADD 2010/03/02 ------------------<<<

            // ����`�[���͉�ʂ��N��
            Process.Start(programPath, loginArguments.ToString());
        }

        /// <summary>
        /// uButton_Close_Click�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// tRetKeyControl1_ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {

        }

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
        #endregion

        #region �N���^�C�v�敪��
        /// <summary>�N���^�C�v��</summary>
        private enum Mode
        {
            ///<summary>���j���[</summary>
            Menu = 0,
            ///<summary>�|�b�v�A�b�v</summary>
            Popup = 1,
            /// <summary>����`�[����</summary>
            SalesSlip = 2
        }
        #endregion

        // --------------- ADD 2013/04/03 wangl2 #35273------>>>> 
        #region XML����
        /// <summary>
        /// �w�l�k�f�[�^�̓Ǎ�����
        /// </summary>
        private void LoadStateXmlData()
        {

            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }

        /// <summary>
        /// �w�l�k�f�[�^�̕ۑ�����
        /// </summary>
        private void SaveStateXmlData()
        {
            // �O���b�h����ۑ�
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
        }
        #endregion
        // --------------- ADD 2013/04/03 wangl2 #35273------<<<<<

        private void button1_Click(object sender, EventArgs e)
        {
            PMSCM04001UC noteForm = new PMSCM04001UC();
            noteForm.ShowDialog();
        }

        private void uGrid_Details_Click(object sender, EventArgs e)
        {
            // ADD 2010/06/17 �L�����Z���ǉ��Ή� ---------->>>>>
            try
            {
            // ADD 2010/06/17 �L�����Z���ǉ��Ή� ----------<<<<<
                Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

                // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
                Point point = System.Windows.Forms.Cursor.Position;
                point = targetGrid.PointToClient(point);

                // UIElement���擾����B
                Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
                if (objUIElement == null)
                    return;

                // �}�E�X�|�C���^�[����̃w�b�_��ɂ��邩�`�F�b�N�B
                Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
                  (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

                if (objHeader != null) return;

                // �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
                Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
                  (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

                if (objRow == null) return;

                Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                  (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

                if (objCell.Column.Index != 16) return;

                string commentDtl = (string)objRow.Cells[this._scmInquiryOrderAcs.SCMInquiryDetailResultDataTable.CommentDtlColumn.ColumnName].Value;

                PMSCM04001UC noteForm = new PMSCM04001UC();
                noteForm.CommentDtl = commentDtl;
                noteForm.ShowDialog();

                ////-----------------------------------------------------------
                //// �J���[���ݒ菈��
                ////-----------------------------------------------------------
                //this.SettingColorInfoProc(colorCode);
            // ADD 2010/06/17 �L�����Z���ǉ��Ή� ---------->>>>>
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine(ex);
            }
            // ADD 2010/06/17 �L�����Z���ǉ��Ή� ----------<<<<<
        }

        private void PMSCM04001UB_Shown(object sender, EventArgs e)
        {
            //
        }

        // --------------- ADD 2013/04/03 wangl2 #35273------>>>> 
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
            // ��ړ���
            e.Layout.Override.AllowColMoving = AllowColMoving.WithinBand;
        }

        /// <summary>
        ///  PMSCM04001UB_FormClosing�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: �t�H�[�����I������ۂɂ��܂��B</br>
        /// <br>Programmer	: wangl2</br>
        /// <br>Date		: 2013/04/03</br>
        /// </remarks>
        private void PMSCM04001UB_FormClosing(object sender, FormClosingEventArgs e)
        {
            // XML�f�[�^�̕ۑ�����
            this.SaveStateXmlData();
        }
        // --------------- ADD 2013/04/03 wangl2 #35273------<<<<<
    }
}