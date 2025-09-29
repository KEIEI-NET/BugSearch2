using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���s�m�F�ꗗ�\UI�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���s�m�F�ꗗ�\UI�t�H�[���N���X</br>
	/// <br>Programmer : 30009 �a�J ���</br>
	/// <br>Date       : 2008.12.02</br>
    /// <br>UpdateNote : 2008.12.24  30009 �a�J ���</br>
    /// <br>           : �E�s��̏C��</br>
    /// <br>UpdateNote : 2009.01.05  30009 �a�J ���</br>
    /// <br>           : �E�s��̏C��</br>
    /// <br>Update Note: 2009/03/02 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12053 �V�X�e���敪�̕\�����琔�l�������폜</br>
    /// <br></br>
    /// </remarks>
	public partial class PMUOE02040UA : Form,
                                IPrintConditionInpType,					// ���[���ʁi�������̓^�C�v�j
                                IPrintConditionInpTypeSelectedSection,	// ���[�Ɩ��i�������́j���_�I��
                                IPrintConditionInpTypePdfCareer			// ���[�Ɩ��i�������́jPDF�o�͗����Ǘ�
	{
		# region Constractor
		/// <summary>
		/// ���s�m�F�ꗗ�\UI�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���s�m�F�ꗗ�\UI�N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// <br></br>
		/// </remarks>
		public PMUOE02040UA()
		{
			InitializeComponent();

			// ��ƃR�[�h�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// ���_�p��Hashtable�쐬
			this._selectedSectionList = new Hashtable();

            // ���t�擾���i
            _dateGet = DateGetAcs.GetInstance();   
		}
		# endregion

		# region Private Menbers
		/// <summary> ���_�R�[�h </summary>
		private string _enterpriseCode = "";
		/// <summary> ��ʃC���[�W�R���g���[�����i </summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���t�擾���i
        private DateGetAcs _dateGet;  

		# endregion

		# region Private Menbers IPrintConditionInpType �C���^�[�t�F�[�X
		/// <summary> ���o�{�^����Ԏ擾�v���p�e�B </summary>
		private bool _canExtract = false;
		/// <summary> PDF�o�̓{�^����Ԏ擾�v���p�e�B </summary>
		private bool _canPdf = true;
		/// <summary> ����{�^����Ԏ擾�v���p�e�B </summary>
		private bool _canPrint = true;
		/// <summary> ���o�{�^���\���L���v���p�e�B </summary>
		private bool _visibledExtractButton = false;
		/// <summary> PDF�o�̓{�^���\���L���v���p�e�B </summary>
		private bool _visibledPdfButton = true;
		/// <summary> ����{�^���\���L���v���p�e�B </summary>
		private bool _visibledPrintButton = true;
		# endregion

		# region Private Menbers IPrintConditionInpTypeSelectedSection �C���^�[�t�F�[�X
		/// <summary> �v�㋒�_�I��\���擾�v���p�e�B </summary>
		private bool _visibledSelectAddUpCd = false;
		/// <summary> ���_�I�v�V�����L�� </summary>
		private bool _isOptSection = false;
		/// <summary> �{�Ћ@�\�L�� </summary>
		private bool _isMainOfficeFunc = false;
		/// <summary> �I�����_���X�g </summary>
		private Hashtable _selectedSectionList = new Hashtable();
		# endregion

		# region Private const Menbers
		# region �� Interface member
		//--IPrintConditionInpTypePdfCareer�̃v���p�e�B�p�ϐ� -------------------------
		/// <summary> �N���XID </summary>
		private const string ct_ClassID = "PMUOE02040UA";
		/// <summary> �v���O����ID </summary>
		private const string ct_PGID = "PMUOE02040U";
		/// <summary> ���[���� </summary>
        private const string ct_PrintName = "���s�m�F�ꗗ�\";
        /// <summary> ���[�L�[ </summary>
		private const string ct_PrintKey = "f91b7283-9d5e-46d9-a4c2-1dcb12ac1145";
		# endregion �� Interface member

		// ExporerBar �O���[�v����
		private const string ct_ExBarGroupNm_PrintConditionGroup = "PrintConditionGroup";		// �o�͏���

        // �������
        private const string ct_Chk = "�`�F�b�N���̂�";
        private const string ct_All = "�S��";

        // �V�X�e���敪
        private const string ct_Type0 = "0:�����";
        //private const string ct_Type1 = "1:�`��"; // DEL 2009/03/02
        private const string ct_Type1 = "�`��"; // ADD 2009/03/02
        private const string ct_Type2 = "2:����";
        private const string ct_Type3 = "3:�ꊇ";
        private const string ct_Type4 = "4:��[";
        //private const string ct_Type9 = "9:�S��";
        //private const string ct_Type9 = "9:�`���ȊO";    // 2009.01.05 UPD // DEL 2009/03/02
        private const string ct_Type9 = "�`���ȊO"; // ADD 2009/03/02

		# endregion

		# region IPrintConditionInpType �C���^�[�t�F�[�X
		# region Public Event
		/// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
		public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
		# endregion

		# region Public Property
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
		# endregion

		# region Public Method
		/// <summary>
		/// ���o����
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>0( �Œ� )</returns>
		/// <remarks>
		/// <br>Note		: ���o�������s���B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		public int Extract(ref object parameter)
		{
			// ���o�����͖����̂ŏ����I��
			return 0;
		}

		/// <summary>
		/// �������
		/// </summary>
		/// <param name="parameter">�p�����[�^</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ����������s���B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		public int Print(ref object parameter)
		{
			SFCMN06001U printDialog = new SFCMN06001U();		// ���[�I���K�C�h
			SFCMN06002C printInfo = parameter as SFCMN06002C;	// ������p�����[�^


			printInfo.enterpriseCode	= this._enterpriseCode;	// ��ƃR�[�h
			printInfo.kidopgid			= ct_PGID;				// �N��PGID
			printInfo.key				= ct_PrintKey;			// PDF�o�͗���p
			printInfo.prpnm				= ct_PrintName;			// PDF�o�͗���p

			// ���o�����N���X
			PublicationConfOrderCndtn extrInfo = new PublicationConfOrderCndtn();

			// ���o�����ݒ菈��(��ʁ����o����)
			if (this.SetExtraInfoFromScreen(extrInfo) != 0) return -1;


			// ���o�����̐ݒ�
            //printInfo.PrintPaperSetCd = 20;
            printInfo.PrintPaperSetCd = 0;
            printInfo.jyoken = extrInfo;
			printDialog.PrintInfo = printInfo;

			// ���[�I���K�C�h
			printDialog.ShowDialog();

			if (printInfo.status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "�Y������f�[�^������܂���", 0);
			}

			parameter = printInfo;

			return printInfo.status;
		}

		/// <summary>
		/// ����O�m�F����
		/// </summary>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note		: ����O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		public bool PrintBeforeCheck()
		{
			bool status = true;

			string errMessage = "";
			Control errComponent = null;

			// ���̓`�F�b�N����
			if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
			{
				// ���b�Z�[�W��\��
				this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

				// �R���g���[���Ƀt�H�[�J�X���Z�b�g
				if (errComponent != null) errComponent.Focus();

				status = false;
			}

			return status;
		}

		/// <summary>
		/// ��ʕ\������
		/// </summary>
		/// <param name="parameter">�N���p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ��ʕ\�����s���B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		public void Show(object parameter)
		{
			// Todo:�N���p�����[�^��ύX����ꍇ�͂����ōs���B
			this.Show();
			return;
		}
		# endregion
		# endregion

		# region IPrintConditionInpTypeSelectedSection �C���^�[�t�F�[�X
		# region Public Property
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
		# endregion

		# region Public Method
		/// <summary>
		/// ���_�I������
		/// </summary>
		/// <param name="sectionCode">�I�����_�R�[�h</param>
		/// <param name="checkState">�I�����</param>
		/// <remarks>
		/// <br>Note		: ���_�I���������s���B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
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

		/// <summary>
		/// �����I���v�㋒�_�ݒ菈��( ������ )
		/// </summary>
		/// <param name="addUpCd"></param>
		/// <remarks>
		/// <br>Note		: ������</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		public void InitSelectAddUpCd(int addUpCd)
		{
			// �v�㋒�_�I�����Ȃ��̂Ŗ�����
		}

		/// <summary>
		/// �����I�����_�ݒ菈��
		/// </summary>
		/// <param name="sectionCodeLst">�I�����_�R�[�h���X�g</param>
		/// <remarks>
		/// <br>Note		: ���_���X�g�̏��������s���B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
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

		/// <summary>
		/// �������_�I��\���`�F�b�N����
		/// </summary>
		/// <param name="isDefaultState">true�F�X���C�_�[�\���@false�F�X���C�_�[��\��</param>
		/// <remarks>
		/// <br>Note		: ���_�I���X���C�_�[�̕\���L���𔻒肷��B</br>
		/// <br>			: ���_�I�v�V�����A�{�Ћ@�\�ȊO�̌ʂ̕\���L��������s���B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		public bool InitVisibleCheckSection(bool isDefaultState)
		{
			return isDefaultState;
		}

		/// <summary>
		/// �v�㋒�_�I������( ������ )
		/// </summary>
		/// <param name="addUpCd"></param>
		/// <remarks>
		/// <br>Note		: ������</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		public void SelectedAddUpCd(int addUpCd)
		{
			// �v�㋒�_�I�����Ȃ��̂Ŗ�����
		}
		# endregion
		# endregion

		# region IPrintConditionInpTypePdfCareer �C���^�[�t�F�[�X
		# region Public Property
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
		# endregion
		# endregion

		# region Private Methods
		/// <summary>
		/// ��ʏ���������
		/// </summary>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: ���͍��ڂ̏��������s��</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		private int InitializeScreen(out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;

			try
			{
				// �������t
                this.tDateEdit_SalesOrderDate_St.SetDateTime(TDateTime.GetSFDateNow());
                this.tDateEdit_SalesOrderDate_Ed.SetDateTime(TDateTime.GetSFDateNow());
                
                // �V�X�e���敪�A�C�e���ǉ�
                // 2009.01.05 UPD �K�v�Ȃ��敪���폜 --------------------------------------------------->>
                /*
                systemDivCdComboEditor.Items.Add(0, ct_Type0);
                systemDivCdComboEditor.Items.Add(1, ct_Type1);
                systemDivCdComboEditor.Items.Add(2, ct_Type2);
                systemDivCdComboEditor.Items.Add(3, ct_Type3);
                systemDivCdComboEditor.Items.Add(4, ct_Type4);
                systemDivCdComboEditor.Items.Add(5, ct_Type9);
                systemDivCdComboEditor.SelectedIndex = 0;
                */
                systemDivCdComboEditor.Items.Add(0, ct_Type1);
                systemDivCdComboEditor.Items.Add(1, ct_Type9);
                systemDivCdComboEditor.SelectedIndex = 0;
                // 2009.01.05 UPD ---------------------------------------------------------------------<<

                // ��������A�C�e���ǉ�
                printConditionComboEditor.Items.Add(0, ct_Chk);
                printConditionComboEditor.Items.Add(1, ct_All);
                printConditionComboEditor.SelectedIndex = 0;
            }
			catch (Exception ex)
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}

		/// <summary>
		/// �{�^���A�C�R���ݒ菈��
		/// </summary>
		/// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
		/// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
		/// <remarks>
		/// <br>Note		: �{�^���A�C�R���̐ݒ���s��</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		private void SetIconImage(object settingControl, Size16_Index iconIndex)
		{
			((Infragistics.Win.Misc.UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
			((Infragistics.Win.Misc.UltraButton)settingControl).Appearance.Image = iconIndex;
		}

		/// <summary>
		/// ���o�����ݒ菈��(��ʁ����o����)
		/// </summary>
		/// <param name="extraInfo">���o����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: ��ʁ����o�����֐ݒ肷��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        //private int SetExtraInfoFromScreen(ConfirmStockAdjustListCndtn extraInfo)
        private int SetExtraInfoFromScreen(PublicationConfOrderCndtn extraInfo)
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// ��ƃR�[�h
				extraInfo.EnterpriseCode = this._enterpriseCode;

                // �I�����_
                extraInfo.SectionCodes = (string[])new ArrayList(this._selectedSectionList.Values).ToArray(typeof(string));

                // ��M���t
                extraInfo.St_ReceiveDate = this.tDateEdit_SalesOrderDate_St.GetDateTime();
                extraInfo.Ed_ReceiveDate = this.tDateEdit_SalesOrderDate_Ed.GetDateTime();

                // �V�X�e���敪
                // 2009.01.05 UPD �K�v�Ȃ��敪���폜 --------------------------------------------------->>
                /*
                if (this.systemDivCdComboEditor.SelectedIndex == 0)
                {
                    // �����
                    extraInfo.SystemDivCd = 0;
                }
                else if (this.systemDivCdComboEditor.SelectedIndex == 1)
                {
                    // �`��
                    extraInfo.SystemDivCd = 1;
                }
                else if (this.systemDivCdComboEditor.SelectedIndex == 2)
                {
                    // ����
                    extraInfo.SystemDivCd = 2;
                }
                else if (this.systemDivCdComboEditor.SelectedIndex == 3)
                {
                    // �ꊇ
                    extraInfo.SystemDivCd = 3;
                }
                else if (this.systemDivCdComboEditor.SelectedIndex == 4)
                {
                    // ��[
                    extraInfo.SystemDivCd = 4;
                }
                else if (this.systemDivCdComboEditor.SelectedIndex == 5)
                {
                    // �S��
                    extraInfo.SystemDivCd = 9;
                }
                */
                if (this.systemDivCdComboEditor.SelectedIndex == 0)
                {
                    // �`��
                    extraInfo.SystemDivCd = 1;
                }
                else if (this.systemDivCdComboEditor.SelectedIndex == 1)
                {
                    // �`���ȊO
                    extraInfo.SystemDivCd = 9;
                }
                // 2009.01.05 UPD ---------------------------------------------------------------------<<

                // ���s�^�C�v
                if (this.printConditionComboEditor.SelectedIndex == 0)
                {
                    // �`�F�b�N���̂�
                    extraInfo.PrintCndtn = 0;
                }
                else if (this.printConditionComboEditor.SelectedIndex == 1)
                {
                    // �S��
                    extraInfo.PrintCndtn = 1;
                }

			}
			catch (Exception)
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}

		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="errMessage">�G���[���b�Z�[�W</param>
		/// <param name="errComponent">�G���[�����R���g���[��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: ���͓��e�̃`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
		{
			bool status = true;

			const string ct_InputError = "�̓��͂��s���ł�";
			const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂�";

            DateGetAcs.CheckDateRangeResult cdrResult;
            // �������`�F�b�N
            // 2008.12.24 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //if (!CallCheckDateRangeAllowNoInput(out cdrResult, ref tDateEdit_SalesOrderDate_St, ref tDateEdit_SalesOrderDate_Ed))
            if (CallCheckDateRange(out cdrResult, ref tDateEdit_SalesOrderDate_St, ref tDateEdit_SalesOrderDate_Ed) == false)
            // 2008.12.24 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            {
                switch (cdrResult)
                {
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartNoInput:
                        {
                            errMessage = string.Format("�����J�n��{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesOrderDate_St;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfStartInvalid:
                        {
                            errMessage = string.Format("�����J�n��{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesOrderDate_St;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput:
                        {
                            errMessage = string.Format("�����I����{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesOrderDate_Ed;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfEndInvalid:
                        {
                            errMessage = string.Format("�����I����{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesOrderDate_Ed;
                            break;
                        }
                    case DateGetAcs.CheckDateRangeResult.ErrorOfReverse:
                        {
                            errMessage = string.Format("������{0}", ct_RangeError);
                            errComponent = this.tDateEdit_SalesOrderDate_St;
                            break;
                        }
                    default:
                        {
                            errMessage = string.Format("������{0}", ct_InputError);
                            errComponent = this.tDateEdit_SalesOrderDate_St;
                            break;
                        }
                }
                status = false;

            }


			return status;
		}

        #region �� ���t���̓`�F�b�N����
        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpADate"></param>
        /// <param name="tde_Ed_AddUpADate"></param>
        /// <returns></returns>
        private bool CallCheckDateRange(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpADate, ref TDateEdit tde_Ed_AddUpADate)
        {
            cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 3, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, false, false);
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }

        /// <summary>
        /// ���t�`�F�b�N�����Ăяo��(�͈̓`�F�b�N�Ȃ��A������OK)
        /// </summary>
        /// <param name="cdrResult"></param>
        /// <param name="tde_St_AddUpADate"></param>
        /// <param name="tde_Ed_AddUpADate"></param>
        /// <returns></returns>
        private bool CallCheckDateRangeAllowNoInput(out DateGetAcs.CheckDateRangeResult cdrResult, ref TDateEdit tde_St_AddUpADate, ref TDateEdit tde_Ed_AddUpADate)
        {
            cdrResult = DateGetAcs.CheckDateRangeResult.OK;
            if ((tde_St_AddUpADate.GetLongDate() != 0) && (tde_Ed_AddUpADate.GetLongDate() != 0))
            {
                cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 0, ref tde_St_AddUpADate, ref tde_Ed_AddUpADate, true);
            }
            else
                if (((tde_St_AddUpADate.GetLongDate() != 0) && (tde_Ed_AddUpADate.GetLongDate() == 0)) ||
                    ((tde_St_AddUpADate.GetLongDate() == 0) && (tde_Ed_AddUpADate.GetLongDate() != 0)))
                {
                    TDateEdit stDate = new TDateEdit();
                    TDateEdit edDate = new TDateEdit();
                    if (tde_St_AddUpADate.GetLongDate() != 0)
                    {
                        stDate = tde_St_AddUpADate;
                    }
                    else
                    {
                        stDate.SetDateTime(DateTime.MinValue);
                    }
                    if (tde_Ed_AddUpADate.GetLongDate() != 0)
                    {
                        edDate = tde_Ed_AddUpADate;

                        DateGetAcs.CheckDateResult cdrResult2 = _dateGet.CheckDate(ref tde_Ed_AddUpADate);
                        if (cdrResult2 != DateGetAcs.CheckDateResult.OK)
                        {
                            cdrResult = DateGetAcs.CheckDateRangeResult.ErrorOfEndNoInput;
                            return false;
                        }
                    }
                    else
                    {
                        edDate.SetDateTime(DateTime.MaxValue);
                    }
                    
                    cdrResult = _dateGet.CheckDateRange(DateGetAcs.YmdType.YearMonth, 1, ref stDate, ref edDate, true);
                }
            return (cdrResult == DateGetAcs.CheckDateRangeResult.OK);
        }
        #endregion

		/// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="iLevel">�G���[���x��</param>
		/// <param name="message">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <remarks>
		/// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
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

		/// <summary>
		/// �G���[���b�Z�[�W�\������
		/// </summary>
		/// <param name="message">�\�����b�Z�[�W</param>
		/// <param name="status">�X�e�[�^�X</param>
		/// <param name="procnm">�������\�b�hID</param>
		/// <param name="ex">��O���</param>
		/// <remarks>
		/// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
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
		# endregion

		# region Control Events
		/// <summary>
		/// ��ʂ�LOAD �C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note       : ��ʂ�LOAD���ɔ������܂��B</br>
		/// </remarks>
		private void PMUOE02040UA_Load(object sender, EventArgs e)
		{
			string errMsg = string.Empty;

			// �R���g���[��������
			int status = this.InitializeScreen(out errMsg);
			if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
				return;
			}


			// ��ʃC���[�W����
			// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
			this._controlScreenSkin.LoadSkin();

			// ��ʃX�L���ύX
			this._controlScreenSkin.SettingScreenSkin(this);

			// �c�[���o�[�ݒ�C�x���g
			ParentToolbarSettingEvent(this);
		}

		/// <summary>
		/// ��ʂ̕\����Ԑؑ� �C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note       : ��ʂ̕\����Ԃ��ؑւ鎞�ɔ������܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		private void PMUOE02040UA_VisibleChanged(object sender, EventArgs e)
		{
			if (this.Visible == true)
			{
				// �����t�H�[�J�X�ݒ�
                tDateEdit_SalesOrderDate_St.Focus();     // ADD 2008.07.04
			}
		}

		/// <summary>
		/// �G�N�X�v���[���[�o�[ �O���[�v�k�� �C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note       : �O���[�v���k�������O�ɔ������܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		private void uebMainExplorerBar_GroupCollapsing(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
				// �O���[�v�̏k�����L�����Z��
				e.Cancel = true;
			}
		}

		/// <summary>
		/// �G�N�X�v���[���[�o�[ �O���[�v�W�J �C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note       : �O���[�v���W�J�����O�ɔ������܂��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
		private void uebMainExplorerBar_GroupExpanding(object sender, Infragistics.Win.UltraWinExplorerBar.CancelableGroupEventArgs e)
		{
            if (e.Group.Key == ct_ExBarGroupNm_PrintConditionGroup)
            {
				// �O���[�v�̏k�����L�����Z��
				e.Cancel = true;
			}
		}

        /// <summary>
        /// tRetKeyControl1_ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : ���^�[���L�[�������ɔ�������C�x���g�ł��B</br>
        /// <br>Programmer : 30009 �a�J ���</br>
        /// <br>Date       : 2008.12.02</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // ������
        }
        # endregion
    }
}