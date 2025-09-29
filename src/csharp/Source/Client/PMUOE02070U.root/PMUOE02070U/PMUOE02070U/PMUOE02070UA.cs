using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinTree;

namespace Broadleaf.Windows.Forms
{
    // <summary>
    /// �d����ϯ�ؽ�UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����ϯ�ؽ�UI�t�H�[���N���X</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2008.12.17</br>
    /// -----------------------------------------------------------------------------------
    /// <br></br>
    /// </remarks>
    public partial class PMUOE02070UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
    {

        #region �� Constructor
        /// <summary>
        /// �d����ϯ�ؽ�UI�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d����ϯ�ؽ�UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.12.17</br>
        /// <br></br>
        /// </remarks>
        public PMUOE02070UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���_�p��Hashtable�쐬
            this._selectedSectionList = new Hashtable();

            // �d����ϯ�ؽăA�N�Z�X�N���X
            this._supplierUnmAcs = new SupplierUnmAcs();

            // ���t�擾���i
            this._dateGetAcs = DateGetAcs.GetInstance();

            // �d����}�X�^�A�N�Z�X�N���X
            this._supplierAcs = new SupplierAcs();
        }
        #endregion

        #region �� Private Member
        #region �� Interface member
        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // ���o�{�^����Ԏ擾�v���p�e�B
        private bool _canExtract = false;
        // PDF�o�̓{�^����Ԏ擾�v���p�e�B    
        private bool _canPdf = true;
        // ����{�^����Ԏ擾�v���p�e�B
        private bool _canPrint = true;
        // ���o�{�^���\���L���v���p�e�B
        private bool _visibledExtractButton = false;
        // PDF�o�̓{�^���\���L���v���p�e�B	
        private bool _visibledPdfButton = true;
        // ����{�^���\���L���v���p�e�B
        private bool _visibledPrintButton = true;

        //--IPrintConditionInpTypeSelectedSection�̃v���p�e�B�p�ϐ� -------------------
        // �v�㋒�_�I��\���擾�v���p�e�B
        private bool _visibledSelectAddUpCd = false;
        // ���_�I�v�V�����L��
        private bool _isOptSection = false;
        // �{�Ћ@�\�L��
        private bool _isMainOfficeFunc = false;
        // �I�����_���X�g
        private Hashtable _selectedSectionList = new Hashtable();
        #endregion �� Interface member

        // ���_�R�[�h
        private string _enterpriseCode = "";
        // �d����ϯ�ؽăA�N�Z�X�N���X
        private SupplierUnmAcs _supplierUnmAcs;
        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���t�擾���i
        private DateGetAcs _dateGetAcs;

        // �d����}�X�^�A�N�Z�X�N���X
        private SupplierAcs _supplierAcs;
        
        #endregion �� Private Member

        #region �� Private Const
        #region �� Interface member
        //--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
        // �N���XID
        private const string ct_ClassID = "PMUOE02070UA";
        // �v���O����ID
        private const string ct_PGID = "PMUOE02070U";
        // ���[����
        private const string ct_PrintName = "�d����ϯ�ؽ�";
        // ���[�L�[	
        private const string ct_PrintKey = "86aa7f12-55e0-4988-8585-1645e2ffbb5a";
        #endregion �� Interface member

        // ExporerBar �O���[�v����
        private const string ct_ExBarGroupNm_ReportSelectGroup = "ReportSelectGroup";		// �o�͏���
        private const string ct_ExBarGroupNm_PrintOderGroup = "PrintOderGroup";			    // �\�[�g��
        private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";	// ���o����
        #endregion

        #region �� IPrintConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Property
        /// <summary> ���o�{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanExtract
        {
            get { return this._canExtract; }
        }

        /// <summary> PDF�o�̓{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPdf
        {
            get { return this._canPdf; }
        }

        /// <summary> ����{�^����Ԏ擾�v���p�e�B </summary>
        public bool CanPrint
        {
            get { return this._canPrint; }
        }

        /// <summary> ���o�{�^���\���L���v���p�e�B </summary>
        public bool VisibledExtractButton
        {
            get { return this._visibledExtractButton; }
        }

        /// <summary> PDF�o�̓{�^���\���L���v���p�e�B </summary>
        public bool VisibledPdfButton
        {
            get { return this._visibledPdfButton; }
        }

        /// <summary> ����{�^���\���v���p�e�B </summary>
        public bool VisibledPrintButton
        {
            get { return this._visibledPrintButton; }
        }

        #endregion �� Public Property

        #region �� Public Method
        #region �� ���o����
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        public int Extract(ref object parameter)
        {
            // ���o�����͖����̂ŏ����I��
            return 0;
        }
        #endregion

        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ����������s���B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        public int Print(ref object parameter)
        {
            SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
            SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^

            // ��ƃR�[�h���Z�b�g
            printInfo.enterpriseCode = this._enterpriseCode;
            printInfo.kidopgid = ct_PGID;				// �N��PGID

            // PDF�o�͗���p
            printInfo.key = ct_PrintKey;
            printInfo.prpnm = ct_PrintName;
            printInfo.PrintPaperSetCd = 0;
            // ���o�����N���X
            SupplierUnmOrderCndtn extrInfo = new SupplierUnmOrderCndtn();

            // ��ʁ����o�����N���X
            int status = this.SetExtraInfoFromScreen(extrInfo);
            if (status != 0)
            {
                return -1;
            }
            // ���o�����̐ݒ�
            printInfo.jyoken = extrInfo;
            printDialog.PrintInfo = printInfo;

            // ���[�I���K�C�h
            DialogResult dialogResult = printDialog.ShowDialog();

            if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
            }

            parameter = printInfo;

            return printInfo.status;
        }
        #endregion

        #region �� ����O�m�F����
        /// <summary>
        /// ����O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        public bool PrintBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }
        #endregion

        #region �� ��ʕ\������
        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        public void Show(object parameter)
        {
            // Todo:�N���p�����[�^��ύX����ꍇ�͂����ōs���B
            this.Show();
            return;
        }
        #endregion

        #endregion �� Public Method
        #endregion �� IPrintConditionInpType �����o

        #region �� IPrintConditionInpTypeSelectedSection �����o
        #region �� Public Property

        /// <summary> �{�Ћ@�\�v���p�e�B </summary>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// <summary> ���_�I�v�V�����v���p�e�B </summary>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// <summary> �v�㋒�_�I��\���擾�v���p�e�B </summary>
        public bool VisibledSelectAddUpCd
        {
            get { return _visibledSelectAddUpCd; }
        }

        #endregion �� Public Property

        #region �� Public Method

        #region �� ���_�I������
        /// <summary>
        /// ���_�I������
        /// </summary>
        /// <param name="sectionCode">�I�����_�R�[�h</param>
        /// <param name="checkState">�I�����</param>
        /// <remarks>
        /// <br>Note		: ���_�I���������s���B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        public void CheckedSection(string sectionCode, CheckState checkState)
        {
            // ���_��I��������
            if (checkState == CheckState.Checked)
            {
                // �S�Ђ��I�����ꂽ�ꍇ
                if (sectionCode == "0")
                {
                    this._selectedSectionList.Clear();
                }

                if (!this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Add(sectionCode, sectionCode);
                }
            }
            // ���_�I��������������
            else if (checkState == CheckState.Unchecked)
            {
                if (this._selectedSectionList.ContainsKey(sectionCode))
                {
                    this._selectedSectionList.Remove(sectionCode);
                }
            }
        }
        #endregion

        #region �� �����I���v�㋒�_�ݒ菈��( ������ )
        /// <summary>
        /// �����I���v�㋒�_�ݒ菈��( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        public void InitSelectAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
        }
        #endregion

        #region �� �����I�����_�ݒ菈��
        /// <summary>
        /// �����I�����_�ݒ菈��
        /// </summary>
        /// <param name="sectionCodeLst">�I�����_�R�[�h���X�g</param>
        /// <remarks>
        /// <br>Note		: ���_���X�g�̏��������s���B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        public void InitSelectSection(string[] sectionCodeLst)
        {
            // �I�����X�g������
            this._selectedSectionList.Clear();
            foreach (string wk in sectionCodeLst)
            {
                this._selectedSectionList.Add(wk, wk);
            }
        }
        #endregion

        #region �� �������_�I��\���`�F�b�N����
        /// <summary>
        /// �������_�I��\���`�F�b�N����
        /// </summary>
        /// <param name="isDefaultState">true�F�X���C�_�[�\���@false�F�X���C�_�[��\��</param>
        /// <remarks>
        /// <br>Note		: ���_�I���X���C�_�[�̕\���L���𔻒肷��B</br>
        /// <br>			: ���_�I�v�V�����A�{�Ћ@�\�ȊO�̌ʂ̕\���L��������s���B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        public bool InitVisibleCheckSection(bool isDefaultState)
        {
            return isDefaultState;
        }
        #endregion

        #region �� �v�㋒�_�I������( ������ )
        /// <summary>
        /// �v�㋒�_�I������( ������ )
        /// </summary>
        /// <param name="addUpCd"></param>
        /// <remarks>
        /// <br>Note		: ������</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        public void SelectedAddUpCd(int addUpCd)
        {
            // �v�㋒�_�I�����Ȃ��̂Ŗ�����
        }
        #endregion

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypeSelectedSection �����o

        #region �� IPrintConditionInpTypePdfCareer �����o
        #region �� Public Property

        /// <summary> ���[�L�[�v���p�e�B </summary>
        public string PrintKey
        {
            get { return ct_PrintKey; }
        }

        /// <summary> ���[���v���p�e�B </summary>
        public string PrintName
        {
            get { return ct_PrintName; }
        }

        #endregion �� Public Method
        #endregion �� IPrintConditionInpTypePdfCareer �����o

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // ������
                this.tde_St_ReceiveDate.SetDateTime(TDateTime.GetSFDateNow());
                this.tde_Ed_ReceiveDate.SetDateTime(TDateTime.GetSFDateNow());
                // �d����(�͈�)
                this.tNedit_SupplierCd_St.Clear();
                this.tNedit_SupplierCd_Ed.Clear();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion �� ��ʏ������֌W

        #region �� ����O����
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";
            
            errMessage = "";
            errComponent = null;

            DateGetAcs.CheckDateRangeResult cdrResult;

            // �������i�J�n�E�I���j
            if ((this.tde_St_ReceiveDate.LongDate != 0) ||
                (this.tde_Ed_ReceiveDate.LongDate != 0))
            {
                if (CallCheckDateRange(out cdrResult, ref tde_St_ReceiveDate, ref tde_Ed_ReceiveDate) == false)
                {
                    switch (cdrResult)
                    {
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                            {
                                errMessage = "�J�n������͂��ĉ�����";
                                errComponent = this.tde_St_ReceiveDate;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                            {
                                errMessage = "�J�n���̓��͂��s���ł�";
                                errComponent = this.tde_St_ReceiveDate;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                            {
                                errMessage = "�I��������͂��ĉ�����";
                                errComponent = this.tde_Ed_ReceiveDate;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                            {
                                errMessage = "�I�����̓��͂��s���ł�";
                                errComponent = this.tde_Ed_ReceiveDate;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                            {
                                errMessage = "���t�͈͎̔w��Ɍ�肪����܂�";
                                errComponent = this.tde_St_ReceiveDate;
                            }
                            break;
                        case DateGetAcs.CheckDateRangeResult.ErrorOfRangeOver:
                            {
                                errMessage = "���t�͂R�����͈̔͂œ��͂��ĉ�����";
                                errComponent = this.tde_St_ReceiveDate;
                            }
                            break;

                    }
                    status = false;
                    return status;
                }
            }
            else
            {
                // �J�n���ƏI�����̗���������
                errMessage = "�J�n���ƏI��������͂��ĉ�����";
                errComponent = this.tde_St_ReceiveDate;
                status = false;
                return status;
            }

            // �d����`�F�b�N
            if ((this.tNedit_SupplierCd_St.DataText.Trim() != "") &&
                (this.tNedit_SupplierCd_Ed.DataText.Trim() != "") &&
                (this.tNedit_SupplierCd_St.GetInt() > this.tNedit_SupplierCd_Ed.GetInt()))
            {
                errMessage = string.Format("�d����{0}", ct_RangeError);
                errComponent = this.tNedit_SupplierCd_St;
                status = false;
            }

            return status;
        }
        #endregion

        #region �� ���t���̓`�F�b�N����
        /// <summary>
        /// ���t�͈̓`�F�b�N�Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit startDate, ref TDateEdit endDate)
        {
            cdrResult = _dateGetAcs.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref startDate, ref endDate, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        #endregion

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ���o�����ݒ菈��(��ʁ����o����)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        private int SetExtraInfoFromScreen(SupplierUnmOrderCndtn supplierUnmOrderCndtn)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // ���_�I�v�V����
                supplierUnmOrderCndtn.IsOptSection = this._isOptSection;
                // ��ƃR�[�h
                supplierUnmOrderCndtn.EnterpriseCode = this._enterpriseCode;
                // �I�����_
                supplierUnmOrderCndtn.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));
                // ������
                supplierUnmOrderCndtn.St_ReceiveDate = this.tde_St_ReceiveDate.GetDateTime();
                supplierUnmOrderCndtn.Ed_ReceiveDate = this.tde_Ed_ReceiveDate.GetDateTime();
                // �d����
                supplierUnmOrderCndtn.St_SupplierCd = this.tNedit_SupplierCd_St.GetInt();
                supplierUnmOrderCndtn.Ed_SupplierCd = this.tNedit_SupplierCd_Ed.GetInt();
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion
        #endregion �� ����O����

        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PrintName,						// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="procnm">�������\�b�hID</param>
        /// <param name="ex">��O���</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        private void MsgDispProc(string message, int status, string procnm, Exception ex)
        {
            string errMessage = message + "\r\n" + ex.Message;

            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                ct_PrintName,						// �v���O��������
                procnm, 							// ��������
                "",									// �I�y���[�V����
                errMessage,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion
        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        #endregion �� Private Method

        #region �� Control Event
        #region �� PMUOE02070UA
        #region �� PMUOE02070UA_Load Event
        /// <summary>
        /// PMUOE02070UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        /// 
        private void PMUOE02070UA_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;

            // �������^�C�}�[�N��
            Initialize_Timer.Enabled = true;

            // ��ʃC���[�W����
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }
        #endregion
        #endregion �� PMUOE02070UA

        #region �� ueb_MainExplorerBar
        #region �� GroupCollapsing Event
        /// <summary>
        /// GroupCollapsing Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���k�������O�ɔ�������B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
            {
                // �O���[�v�̏k�����L�����Z��
                e.Cancel = true;
            }
        }
        #endregion

        #region �� GroupExpanding Event
        /// <summary>
        /// GroupExpanding Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: UltraExplorerBarGroup���W�J�����O�ɔ�������B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.12.17</br>
        /// </remarks>
        private void ueb_MainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
        {
            if ((e.Group.Key == ct_ExBarGroupNm_ReportSelectGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_PrintOderGroup) ||
                (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup))
            {
                // �O���[�v�̓W�J���L�����Z��
                e.Cancel = true;
            }

        }
        #endregion
        #endregion �� ueb_MainExplorerBar Event


        #region �� ub_St_SupplierCodeGuide_Click Event
        /// <summary>
        /// �J�n�d����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_St_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // ���ڂɓW�J
            if (status == 0)
            {
                this.tNedit_SupplierCd_St.SetInt(supplier.SupplierCd);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� ub_Ed_SupplierCodeGuide_Click Event
        /// <summary>
        /// �I���d����K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void ub_Ed_SupplierCodeGuide_Click(object sender, EventArgs e)
        {
            int status = -1;

            // �K�C�h�N��
            Supplier supplier = new Supplier();
            status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, "0");

            // ���ڂɓW�J
            if (status == 0)
            {
                this.tNedit_SupplierCd_Ed.SetInt(supplier.SupplierCd);

                // ���̃R���g���[���փt�H�[�J�X���ړ�
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        #endregion

        #region �� tArrowKeyControl1_ChangeFocus Event
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_SupplierCd_St)
                    {
                        // �d����(�J�n)���d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��)��������(�J�n)
                        e.NextCtrl = this.tde_St_ReceiveDate;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tde_St_ReceiveDate)
                    {
                        // ������(�J�n)���d����(�I��)
                        e.NextCtrl = this.tNedit_SupplierCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_SupplierCd_Ed)
                    {
                        // �d����(�I��)���d����(�J�n)
                        e.NextCtrl = this.tNedit_SupplierCd_St;
                    }
                }
            }
        }
        #endregion
        #endregion �� Control Event

        #region �� Initialize_Timer
        #region �� Tick Event
        /// <summary>
        /// Tick Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void Initialize_Timer_Tick(object sender, EventArgs e)
        {
            Initialize_Timer.Enabled = false;
            string errMsg = string.Empty;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                // �R���g���[��������
                int status = this.InitializeScreen(out errMsg);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                    return;
                }
                
                // �K�C�h�{�^���̃A�C�R���ݒ�
                this.SetIconImage(this.ub_St_SupplierCodeGuide, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_SupplierCodeGuide, Size16_Index.STAR1);
                
                ParentToolbarSettingEvent(this);	// �c�[���o�[�ݒ�C�x���g
            }
            finally
            {
                this.tde_St_ReceiveDate.Focus();

                this.Cursor = Cursors.Default;
            }
        }
        #endregion
        #endregion �� Initialize_Timer
    }
}
