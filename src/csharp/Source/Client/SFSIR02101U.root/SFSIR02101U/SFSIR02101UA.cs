using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTabControl;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Controller.Facade;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �x���`�[���̓��C���t���[��
	/// </summary>
	/// <remarks>
	/// <br>Note		: �x�������͂��s����ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2006.05.20</br>
	/// <br></br>
	/// <br>UpdateNote	: 2007.02.13 T.Kimura MA.NS ��ʃX�L���ύX�Ή�</br>
	/// <br>              2007.02.13 T.Kimura MA.NS ���Ӑ�X���C�_�[�̃p�����[�^��ύX</br>
    /// <br>              2008.02.21 20081 �D�c �E�l DC.NS�p�ɕύX(���_�擾���@��ύX)</br>
    /// <br>              2008/07/08 30414 �E �K�j Partsman�p�ɕύX</br>
   	/// <br>Update Date	: 2012/12/24 ���N </br>
    /// <br>�Ǘ��ԍ��@�@: 10806793-00 2013/03/13�z�M��</br>
    /// <br>            : Redmine#33741�̑Ή�</br>
    /// </remarks>
	public partial class SFSIR02101UA : Form
	{
		#region Const
		// �x���`�[���̓^�u�L�[
		private const string ctNO0_PAYMENTINPUT_TAB = "NO0_PAYMENTINPUT_TAB";
		#endregion

		# region Private Menbers
		// ���_���}�X�^�A�N�Z�X�N���X
		private SecInfoAcs _secInfoAcs;
		// �X���C�_�[�p�l���N���X
		private SFCMN00221UA _superSlider;
		// �t�H�[�����䃊�X�gHashtable
		private Hashtable _formControlInfoTable;
		// Tab�q��ʕ\���p�����[�^
		private int _parameter;
		// ���ݑI�����_
		private object selectedSection;
		// ���_�I�𒆃t���O
		private bool selectedSectionFlg;
		// �E�B���h�E��ԕێ��p�iDockManager�j
		private MemoryStream _dockMemoryStream;
		// �E�B���h�E��ԕێ��p�iToolBar�j
		private MemoryStream _toolMemoryStream;
		// ����N���t���O
		private int _firstStartFlg;

        // �� 20070213 18322 a MA.NS�p�ɕύX
        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // �� 20070213 18322 a

        private IOperationAuthority _operationAuthority;    // ���쌠���̐���I�u�W�F�N�g

		# endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFSIR02101UA()
		{
			InitializeComponent();

			try
			{
				// �t�H�[�����䃊�X�g
				this._formControlInfoTable = new Hashtable();
				// MDI�\���p�����[�^
				this._parameter = 1;
				// ���ݑI�����_
				this.selectedSection = null;
				// ���_�I�𒆃t���O
				this.selectedSectionFlg = false;
				// �E�B���h�E��ԕێ��p�iDockManager�j
				this._dockMemoryStream = null;
				// �E�B���h�E��ԕێ��p�iToolBar�j
				this._toolMemoryStream = null;
				// ����N���t���O
				this._firstStartFlg = 0;

				// �h�b�N�}�l�[�W���[�ɃC���[�W���X�g��ݒ肷��
				Main_DockManager.ImageList = IconResourceManagement.ImageList16;
				DockablePaneBase pnlSliderPaneBase = Main_DockManager.DockAreas["pnlSlider"].Panes["pnlSlider"];
				if (pnlSliderPaneBase != null) pnlSliderPaneBase.Settings.Appearance.Image = Size16_Index.VIEW;

				// �c�[���o�[��������
				ToobarInitProc();

                SFCMN00221UAParam param = new SFCMN00221UAParam();
                param.SupplierDiv = 1;

				// �X���C�_�[���C���X�^���X��
                _superSlider = new SFCMN00221UA(param);
			}
			catch (Exception ex)
			{
				string message = "���������ɂė�O���������܂����B"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, "�x���`�[���̓��C���t���[��"
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_INIT
					, message
					, -1
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
				Program._floatingWindow.Close();
			}
		}
		#endregion

        /// <summary>
        /// �I�y���[�V�����R�[�h
        /// </summary>
        internal enum OperationCode : int
        {
            /// <summary>�C��</summary>
            Revision = 10,
            /// <summary>�폜</summary>
            Delete = 11,
            /// <summary>�ԓ`</summary>
            RedSlip = 12,
        }

        // ���쌠���̐���I�u�W�F�N�g�ۗ̕L
        /// <summary>
        /// ���쌠���̐���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <value>���쌠���̐���I�u�W�F�N�g</value>
        private IOperationAuthority MyOpeCtrl
        {
            get
            {
                if (_operationAuthority == null)
                {
                    _operationAuthority = OpeAuthCtrlFacade.CreateEntryOperationAuthority("SFSIR02101U", this);
                }
                return _operationAuthority;
            }
        }

        /// <summary>
        /// ���쌠���̐�����J�n���܂��B
        /// </summary>
        private void BeginControllingByOperationAuthority()
        {
            // �`�[�폜�{�^��
            if (MyOpeCtrl.Disabled((int)OperationCode.Delete))
            {
                Main_ToolbarsManager.Tools["Delete_ButtonTool"].SharedProps.Visible = false;
                Main_ToolbarsManager.Tools["Delete_ButtonTool"].SharedProps.Shortcut = Shortcut.None;
            }

            // �ԓ`�{�^��
            if (MyOpeCtrl.Disabled((int)OperationCode.RedSlip))
            {
                Main_ToolbarsManager.Tools["DebitNote_ButtonTool"].SharedProps.Visible = false;
                Main_ToolbarsManager.Tools["DebitNote_ButtonTool"].SharedProps.Shortcut = Shortcut.None;
            }
        }

		#region PrivateMethod
		/// <summary>
		/// �c�[���o�[��������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �c�[���o�[�̏����ݒ���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
        /// <br>Update Date : 2012/12/24 ���N</br> 
        /// <br>�Ǘ��ԍ��@�@: 10806793-00 2013/03/13�z�M��</br> 
        /// <br>            : Redmine#33741�̑Ή�</br>
		/// </remarks>
		private void ToobarInitProc()
		{
			// ���_���擾
			SecInfoSet secInfoSet;
			_secInfoAcs = new SecInfoAcs();
			// ���Џ��擾
			_secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);

			// ���_�R���{�{�b�N�X�ɋ��_���X�g��ݒ肷��
			ValueList secInfoList = new ValueList();
			foreach (SecInfoSet secInfoSetWk in _secInfoAcs.SecInfoSetList)
			{
				ValueListItem secInfoItem = new ValueListItem();
				secInfoItem.DataValue = secInfoSetWk.SectionCode;
				secInfoItem.DisplayText = secInfoSetWk.SectionGuideNm;
				secInfoList.ValueListItems.Add(secInfoItem);
			}
			ComboBoxTool sectionCombo = (ComboBoxTool)Main_ToolbarsManager.Tools["Section_ComboBoxTool"];
			sectionCombo.ValueList = secInfoList;
			LabelTool sectionLabel = (LabelTool)Main_ToolbarsManager.Tools["Section_LabelTool"];

			// �{�Ћ@�\����or���_�I�v�V���������Ȃ狒�_��ύX�ł��Ȃ��悤�ɂ���
            // 2008.12.26 del [9576] ��ɖ{�Ћ@�\�Ƃ��ē��삷��
			//if (//(_secInfoAcs.GetMainOfficeFuncFlag(secInfoSet.SectionCode) == 0) ||   
				//(LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) < PurchaseStatus.Contract))
			//{
				//if (sectionCombo != null) sectionCombo.SharedProps.Visible = false;
				//if (sectionLabel != null) sectionLabel.SharedProps.Visible = false;
			//}

			// �c�[���o�[�ɃC���[�W���X�g��ݒ肷��
			Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
			// ���_�̃A�C�R���ݒ�
			if (sectionLabel != null) sectionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
			// ���O�C���S���҂̃A�C�R���ݒ�
			LabelTool loginCaptionLabel = (LabelTool)Main_ToolbarsManager.Tools["LoginCaption_LabelTool"];
			if (loginCaptionLabel != null) loginCaptionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			// ���O�C���S�����̐ݒ�
			LabelTool loginNameLabel = (LabelTool)Main_ToolbarsManager.Tools["LoginName_LabelTool"];
			if ((LoginInfoAcquisition.Employee != null) &&
				(loginNameLabel != null))
			{
				loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			}
			// �I���{�^���̃A�C�R���ݒ�
			ButtonTool exitButton = (ButtonTool)Main_ToolbarsManager.Tools["Exit_ButtonTool"];
			if (exitButton != null) exitButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			// �V�K�{�^���̃A�C�R���ݒ�
			ButtonTool newButton = (ButtonTool)Main_ToolbarsManager.Tools["New_ButtonTool"];
			if (newButton != null) newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
			// �ۑ��{�^���̃A�C�R���ݒ�
			ButtonTool saveButton = (ButtonTool)Main_ToolbarsManager.Tools["Save_ButtonTool"];
			if (saveButton != null) saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			// �폜�{�^���̃A�C�R���ݒ�
			ButtonTool deleteButton = (ButtonTool)Main_ToolbarsManager.Tools["Delete_ButtonTool"];
			if (deleteButton != null) deleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
			// �ԓ`�{�^���̃A�C�R���ݒ�
			ButtonTool debitNoteButton = (ButtonTool)Main_ToolbarsManager.Tools["DebitNote_ButtonTool"];
			if (debitNoteButton != null) debitNoteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.REDSLIP;
            // �ŐV���{�^���̃A�C�R���ݒ�
            ButtonTool renewalButton = (ButtonTool)Main_ToolbarsManager.Tools["Renewal_ButtonTool"];
            if (renewalButton != null) renewalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            //---ADD ���N 2012/12/24 Redmine#33741 ---------->>>>>
            // �x���`�[�ďo�{�^���̃A�C�R���ݒ�
            ButtonTool readsupslipButton = (ButtonTool)Main_ToolbarsManager.Tools["ReadSupSlip_ButtonTool"];
            if (readsupslipButton != null) readsupslipButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPSEARCH;
            //---ADD ���N 2012/12/24 Redmine#33741 ----------<<<<<
		}

		/// <summary>
		/// �t�H�[���R���g���[���N���X�N���G�C�g����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �q��ʃt�H�[����������쐬���܂�</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void FormControlInfoCreate()
		{
			// ��������(�����^)�̃R���g���[���N���X����
			FormControlInfo info = new FormControlInfo(ctNO0_PAYMENTINPUT_TAB, "SFSIR02102U", "Broadleaf.Windows.Forms.SFSIR02102UA", "�x���`�[����", IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2], "", "");

			// �t�H�[�����䃊�X�g�ɒǉ�
			this._formControlInfoTable.Add(ctNO0_PAYMENTINPUT_TAB, info);
		}

		/// <summary>
		/// �c�[���o�[�{�^���L�������ݒ菈��
		/// </summary>
		/// <param>none</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note		: �c�[���[�o�[�{�^���̗L���E�����ݒ���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
        /// <br>Update Date : 2012/12/24 ���N</br> 
        /// <br>�Ǘ��ԍ��@�@: 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br>
		/// </remarks>
		private void ToolBarButtonEnabledSetting(object activeForm)
		{
			if (this.Main_TabControl.ActiveTab == null)
				return;

			// �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
			FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
			Form frm = formControlInfo.Form;

			// �����ς̎��͕\������
			// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ������s����B
			if (!(frm is IDepositInputMDIChild)) return;


			// �ۑ��{�^��
			ButtonTool saveButton = Main_ToolbarsManager.Tools["Save_ButtonTool"] as ButtonTool;
			if (saveButton != null) saveButton.SharedProps.Enabled = ((IDepositInputMDIChild)frm).SaveButton;

			// �V�K�{�^��
			ButtonTool newButton = Main_ToolbarsManager.Tools["New_ButtonTool"] as ButtonTool;
			if (newButton != null) newButton.SharedProps.Enabled = ((IDepositInputMDIChild)frm).NewButton;

			// �폜�{�^��
			ButtonTool deleteButton = Main_ToolbarsManager.Tools["Delete_ButtonTool"] as ButtonTool;
			if (deleteButton != null) deleteButton.SharedProps.Enabled = ((IDepositInputMDIChild)frm).DeleteButton;

			// �ԓ`�{�^��
			ButtonTool debitNoteButton = Main_ToolbarsManager.Tools["DebitNote_ButtonTool"] as ButtonTool;
			if (debitNoteButton != null) debitNoteButton.SharedProps.Enabled = ((IDepositInputMDIChild)frm).AkaButton;

            ButtonTool renewalButton = Main_ToolbarsManager.Tools["Renewal_ButtonTool"] as ButtonTool;
            if (renewalButton != null) renewalButton.SharedProps.Enabled = ((IDepositInputMDIChild)frm).RenewalButton;

            // ---- ADD ���N 2012/12/24 Redmine#33741 ----->>>>>
            ButtonTool readsupslipButton = (ButtonTool)Main_ToolbarsManager.Tools["ReadSupSlip_ButtonTool"];
            if (readsupslipButton != null) readsupslipButton.SharedProps.Enabled = ((IDepositInputMDIChild)frm).ReadSlipButton;
            // ---- ADD ���N 2012/12/24 Redmine#33741 -----<<<<<

            BeginControllingByOperationAuthority();
		}

		/// <summary>
		/// �^�u�\������
		/// </summary>
		/// <param name="tabKind">�^�u���</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�^�u��\�����܂�</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void TabShow(string tabKind)
		{
			// �^�u����
			this.TabCreate(tabKind);

			// �^�u�A�N�e�B�u������
			this.TabActive(tabKind);
		}

		/// <summary>
		/// �^�u�N���G�C�g����
		/// </summary>
		/// <param name="key">��ʎ��</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note		: �q��ʃ^�u�𐶐����܂�</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void TabCreate(string key)
		{
			FormControlInfo info = (FormControlInfo)this._formControlInfoTable[key];
			Form form;

			// �^�u�����݂��Ȃ���
			if (this.Main_TabControl.Tabs.Exists(key) == false)
			{
				// TAB�q��ʐ�������
				form = this.CreateTabChildForm(info.AssemblyID, info.ClassID, info);
			}
			else
			{
				form = info.Form;
			}

			// IDepositInputTabChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
			if ((form is IDepositInputMDIChild))
			{
				// �c�[���o�[�{�^������f���Q�[�g�̓o�^
				((IDepositInputMDIChild)form).ParentToolbarSettingEvent += new ParentToolbarDepositSettingEventHandler(this.ParentToolbarSettingEvent);

				// �I�����_�擾�f���Q�[�g�̓o�^
				((IDepositInputMDIChild)form).GetSelectSectionCodeEvent += new GetDepositSelectSectionCodeEventHandler(this.GetSelectSectionCodeEvent);

                // �v�㋒�_�擾�f���Q�[�g�̓o�^
                ((IDepositInputMDIChild)form).HandOverAddUpSecNameEvent += new HandOverDepositAddUpSecNameEventHandler(this.HandOverAddUpSecNameEvent);  // 2008.02.21 add

				((IDepositInputMDIChild)form).Show(this._parameter);
			}
			else
			{
				form.Show();
			}
		}

		/// <summary>
		/// �^�u�A�N�e�B�u������
		/// </summary>
		/// <param name="key">��ʎ��</param>
		/// <returns>��������</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�^�u���A�N�e�B�u�����܂�</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void TabActive(string key)
		{
			// �^�u�����݂��鎞
			if (this.Main_TabControl.Tabs.Exists(key))
			{
				this.Main_TabControl.Tabs[key].Visible = true;
				this.Main_TabControl.SelectedTab = this.Main_TabControl.Tabs[key];
			}
		}

		/// <summary>
		/// �^�u�폜����
		/// </summary>
		/// <param name="key">��ʎ��</param>
		/// <returns>��������</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�^�u���폜���܂�</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void TabRemove(string key)
		{
			// �^�u�����݂��鎞
			if (this.Main_TabControl.Tabs.Exists(key))
			{
				this.Main_TabControl.Tabs.Remove(this.Main_TabControl.Tabs[key]);
			}
		}

		/// <summary>
		/// TAB�q��ʐ�������
		/// </summary>
		/// <param name="frmAssemblyId">�A�Z���u���h�c</param>
		/// <param name="frmClassId">�N���X�h�c</param>
		/// <param name="info">�t�H�[���R���g���[�����</param>
		/// <returns>�t�H�[��</returns>
		/// <remarks>
		/// <br>Note		: TAB�q��ʂ𐶐����܂�</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private Form CreateTabChildForm(string frmAssemblyId, string frmClassId, FormControlInfo info)
		{
			Form form = null;

			// �N���X�C���X�^���X������
			form = (Form)this.LoadAssemblyFrom(frmAssemblyId, frmClassId, typeof(Form));

			if (form == null)
			{
				form = new Form();
			}

			// �^�u�R���g���[���ɒǉ�����^�u�y�[�W���C���X�^���X������
			UltraTabPageControl dataviewTabPageControl = new UltraTabPageControl();

			// �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
			UltraTab dataviewTab = new UltraTab();

			dataviewTab.TabPage = dataviewTabPageControl;
			dataviewTab.Text = info.Name;
			dataviewTab.Key = info.Key;
			dataviewTab.Tag = info.Form;
			dataviewTab.Appearance.Image = info.Icon;
			dataviewTab.Appearance.BackColor = Color.White;
			dataviewTab.Appearance.BackColor2 = Color.Lavender;
			dataviewTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
			dataviewTab.ActiveAppearance.BackColor = Color.White;
			dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
			dataviewTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;
			dataviewTab.ActiveAppearance.FontData.Bold = DefaultableBoolean.True;

			this.Main_TabControl.Controls.Add(dataviewTabPageControl);
			this.Main_TabControl.Tabs.AddRange(new UltraTab[] { dataviewTab });
			this.Main_TabControl.SelectedTab = dataviewTab;

			// �t�H�[���v���p�e�B�ύX
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = DockStyle.Fill;
			dataviewTabPageControl.Controls.Add(form);

			info.Form = form;

			return info.Form;
		}

		/// <summary>
		/// �N���X�C���X�^���X������
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂�</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object obj = null;

			try
			{
				// �A�Z���u�����t���N�V����
				Assembly asm = Assembly.Load(asmname);

				// �N���X�^�擾
				Type objType = asm.GetType(classname);
				if (objType != null)
				{
					// ����ł���΃C���X�^���X������
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch (FileNotFoundException exNotFound)
			{
				// �ΏۃA�Z���u���Ȃ��I
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, this.Name, exNotFound.Message, -1, MessageBoxButtons.OK);
			}
			catch (Exception ex)
			{
				string message = "�N���X�C���X�^���X�������ɂė�O���������܂����B"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, "�x���`�[���̓��C���t���[��"
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_INIT
					, message
					, -1
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
			}

			return obj;
		}

		/// <summary>
		/// Tab�q��ʂ̃f�[�^�\���w�� (�d����R�[�h�w�胂�[�h)
		/// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
		/// <remarks>
		/// <br>Note		: Tab�q��ʂ̃f�[�^�\���w��</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void RefreshTabChildCustomerMode(int supplierCode)
		{
			// �p�����[�^������ȂƂ�
			if (supplierCode != 0)
			{
				// ���݁A�A�N�e�B�u�ȉ�ʂ��擾����
				FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
				Form frm = formControlInfo.Form;

				if (frm != null)
				{
					// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
					if ((frm is IDepositInputMDIChild))
					{
						object[] parameter = new object[1] { supplierCode };

						((IDepositInputMDIChild)frm).ShowData(0, parameter);
					}
				}

				if ((!this.Main_DockManager.ControlPanes[0].Pinned) &&
					(this.Main_DockManager.ControlPanes[0].Manager.FlyoutPane != null))
				{
					this.Main_DockManager.ControlPanes[0].Manager.FlyIn(true);
				}
			}
		}

		/// <summary>
		/// �E�B���h�E����������
		/// </summary>
		/// <param>none</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: �E�B���h�E������������</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void InitWindow()
		{
			// �h�b�N�̏�Ԃ�������
			if (this._dockMemoryStream == null)
				return;
			this._dockMemoryStream.Position = 0;
			this.Main_DockManager.LoadFromBinary(this._dockMemoryStream);

			// �c�[���o�[�̏�Ԃ�������
			if (this._toolMemoryStream == null)
				return;
			this._toolMemoryStream.Position = 0;
			this.Main_ToolbarsManager.LoadFromBinary(this._toolMemoryStream);
		}
		#endregion

		#region DelegateEvent
		/// <summary>
		/// �c�[���o�[�{�^������C�x���g
		/// </summary>
		/// <param name="sender">�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note		: �t���[���̃{�^���L������������������ꍇ�ɔ��������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void ParentToolbarSettingEvent(object sender)
		{
			ToolBarButtonEnabledSetting(sender);
		}

		/// <summary>
		/// ���_�R�[�h�擾
		/// </summary>
		/// <param name="sender">�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note		: �t���[���ɂđI������Ă��鋒�_�R�[�h���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private string GetSelectSectionCodeEvent(object sender)
		{
			// ���ݑI�����_��Ԃ�
			ValueListItem secInfoList = selectedSection as ValueListItem;
			if (secInfoList != null)
			{
				return secInfoList.DataValue.ToString();
			}

			return "";
		}

        /// <summary>
        /// �x���v�㋒�_���̎擾
        /// </summary>
        /// <param name="sender">�I�u�W�F�N�g</param>
        /// <param name="sectionName">�v�㋒�_����</param>
        /// <remarks>
        /// <br>Note       : �x���v�㋒�_���̂��擾���܂��B</br>
        /// <br>Programer  : 20081 �D�c �E�l</br>
        /// <br>Date       : 2008.02.21</br>
        /// </remarks>
        private void HandOverAddUpSecNameEvent(object sender, string sectionName)
        {
            // �x���v�㋒�_��\��
            Main_ToolbarsManager.Tools["SectionCode_L"].SharedProps.Caption = sectionName;
        }

		/// <summary>
		/// ���[�U�[�f�[�^�擾�����f���Q�[�g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		private void SearchUserDataFinish(object sender, EventArgs e)
		{
			//�������[�h�����Ȃ��̂ŁA���̃��W�b�N�͕s�v�ł��B
		}

		/// <summary>
		/// �񋟃f�[�^�擾�����f���Q�[�g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		private void SearchOfferDataFinish(object sender, EventArgs e)
		{
			//�������[�h�����Ȃ��̂ŁA���̃��W�b�N�͕s�v�ł��B
		}

		/// <summary>
		/// �ڋq�ԗ��I���C�x���g(�X���C�_�[�ɂČڋq�ԗ��I�����ɔ���)
		/// </summary>
		/// <param name="selectData">�ڋq���q�I�����</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note		: �ڋq�ԗ��I���C�x���g(�X���C�_�[�ɂČڋq�ԗ��I�����ɔ���)</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// <br>Update Note : 2007.02.22 T.Kimura �p�����[�^��MA.NS�p�ɕύX</br>
		/// </remarks>
        // �� 20070222 18322 c MA.NS�p�ɕύX
        //public void SelectedSupplier(CustomerCarSearchAcsRet selectData)
		//{

        public void SelectedSupplier(Supplier selectData)
		{
        // �� 20070222 18322 c
			// �ڋq�ԗ����I������ꍇ�ɔ�э��݂܂�
			if (selectData != null)
			{
				// �q��ʂ̃f�[�^�\���w�� (���Ӑ�R�[�h�w�胂�[�h)
				this.RefreshTabChildCustomerMode(selectData.SupplierCd);
			}
		}
		#endregion

		#region Event
		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.17</br>
		/// </remarks>
		private void SFSIR02101UA_Load(object sender, EventArgs e)
		{
			// ����N���t���O
			try
			{
				if (this._firstStartFlg == 0)
				{
                    // �� 20070213 18322 a MA.NS�p�ɕύX
                    // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
                    this._controlScreenSkin.LoadSkin();

                    // ��ʃX�L���ύX
                    this._controlScreenSkin.SettingScreenSkin(this);
                    // �� 20070213 18322 a

                    // �� 20070519 18322 d �g�p���Ȃ��悤�ɕύX�����̂ō폜
                    //// �d���݌ɋ��ʏ����������[�U�[�f�[�^�擾
					//// �x���`�[���͋��ʏ����l�擾
					//StokCommonInitDataAcs stokCommonInitDataAcs = new StokCommonInitDataAcs();
					//stokCommonInitDataAcs.Search(StockPayInitProcCall_Mode.PAY
					//	, LoginInfoAcquisition.EnterpriseCode
					//	, _secInfoAcs.SecInfoSet.SectionCode
					//	, new EventHandler(SearchUserDataFinish)
					//	, new EventHandler(SearchOfferDataFinish));
                    // �� 20070519 18322 d

					// �t�H�[������e�[�u��������
					this._formControlInfoTable.Clear();

					// �t�H�[���R���g���[���N���X�N���G�C�g����
					FormControlInfoCreate();

					TabShow(ctNO0_PAYMENTINPUT_TAB);

					// ���_��ݒ�
                    // --- CHG 2008/07/08 --------------------------------------------------------------------->>>>>
                    //ComboBoxTool sectionCombo = (ComboBoxTool)Main_ToolbarsManager.Tools["Section_ComboBoxTool"];
                    //SecInfoSet secInfoSet;
                    //_secInfoAcs.GetSecInfo(_secInfoAcs.SecInfoSet.SectionCode, SecInfoAcs.CtrlFuncCode.PayAddUpSecCd, out secInfoSet);
                    //sectionCombo.Value = secInfoSet.SectionCode;
                    Main_ToolbarsManager.Tools["SectionCode_L"].SharedProps.Caption = this._secInfoAcs.SecInfoSet.SectionGuideNm.Trim();
                    // --- CHG 2008/07/08 ---------------------------------------------------------------------<<<<<
                    Main_ToolbarsManager_ToolValueChanged(sender, new ToolEventArgs(Main_ToolbarsManager.Tools["Section_ComboBoxTool"]));

                    // �� 20070222 18322 d MA.NS�p�ɕύX
					//// �X�[�p�[�X���C�_�[�A�Z���u�����[�h�E�K�C�h�ǉ�����
					//_superSlider.AcceptOrderListShow = false;				// �ŋߎg�p�����`�[��\��
					//Panel sldpanel = _superSlider.GetMainPanel(0, 15);
					//this.pnlSlider.Controls.Add(sldpanel);					// ���\��t����p�l�����w��
					//sldpanel.Dock = System.Windows.Forms.DockStyle.Fill;
                    //
					//// �ڋq�I���C�x���g(�X���C�_�[�ɂČڋq�I�����ɔ���)
					//_superSlider.SelectedSupplier += new SelectedCustomerCarHandler(SelectedSupplier);
                    // �� 20070222 18322 d

                    // �� 20070309 pend 18322 a MA.NS�p�ɕύX
					// �X�[�p�[�X���C�_�[�A�Z���u�����[�h�E�K�C�h�ǉ�����
					_superSlider.StockSlipListShow = false;				// �ŋߎg�p�����`�[��\��
					Panel sldpanel = _superSlider.GetMainPanel(0, 15);
					this.pnlSlider.Controls.Add(sldpanel);					// ���\��t����p�l�����w��
					sldpanel.Dock = DockStyle.Fill;

                    // �ڋq�I���C�x���g(�X���C�_�[�ɂČڋq�I�����ɔ���)
					_superSlider.SelectedSupplier += new SelectedSupplierHandler(SelectedSupplier);
                    // �� 20070309 18322 a

                    BeginControllingByOperationAuthority();

					this._firstStartFlg++;
				}
			}
			catch (Exception ex)
			{
				string message = "�t�H�[�����[�h�����ɂė�O���������܂����B"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, "�x���`�[���̓��C���t���[��"
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_LOAD
					, message
					, -1
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
			}
			finally
			{
				// �N���p�t���[�e�B���O�E�B���h�E(Close)
				Program._floatingWindow.Close();
			}

			// �N���^�C�}�[�J�n
			StartTimer.Enabled = true;
		}

		/// <summary>
		/// �c�[���o�[���e�I���C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note		: �c�[���o�[�̊e�A�C�e�����e���I�����ꂽ���ɔ������܂�</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolValueChanged(object sender, ToolEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Section_ComboBoxTool":
				{
					// ��d�N���h�~�t���O����
					if (selectedSectionFlg) return;

					// ���_�R���{�{�b�N�X�̎擾
					ComboBoxTool sectionList = (ComboBoxTool)e.Tool;
					if (sectionList.Value == null) return;

					// ���݃A�N�e�B�u�^�u�����邩
					if (this.Main_TabControl.ActiveTab != null)
					{
						// �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
						FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
						Form frm = formControlInfo.Form;

						// �����ς̎��͕\������
						// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
						if ((frm is IDepositInputMDIChild))
						{
							// ���_�ύX�O�ʒm����
							if (((IDepositInputMDIChild)frm).BeforeSectionChange() != 0)
							{
								// �O��I�����_�ɖ߂� ���C�x���g�̓�d�N���h�~�t���O�g�p
								selectedSectionFlg = true;
								sectionList.SelectedItem = selectedSection;
								selectedSectionFlg = false;
								return;
							}

							// ���ݑI�����_�̃R�[�h��ێ�
							selectedSection = sectionList.SelectedItem;

							// ���_�ύX��ʒm����
							((IDepositInputMDIChild)frm).AfterSectionChange();
						}
					}
					else
					{
						// ���ݑI�����_��ێ�
						selectedSection = sectionList.SelectedItem;
					}

					break;
				}
			}
		}

		/// <summary>
		/// �N���^�C�}�[�J�n�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note		: �N���������s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void StartTimer_Tick(object sender, EventArgs e)
		{
			// �N���^�C�}�[�I��
			StartTimer.Enabled = false;

			RefreshTabChildCustomerMode(0);

			// DockManager�̏�Ԃ�ێ�����
			this._dockMemoryStream = new MemoryStream();
			this.Main_DockManager.SaveAsBinary(this._dockMemoryStream);
			// ToolBar�̏�Ԃ�ێ�����
			this._toolMemoryStream = new MemoryStream();
			this.Main_ToolbarsManager.SaveAsBinary(this._toolMemoryStream, false);
		}

		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note		: �c�[���o�[��̃c�[�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
        /// <br>Update Date : 2012/12/24 ���N</br> 
        /// <br>�Ǘ��ԍ��@�@: 10806793-00 2013/03/13�z�M��</br>
        /// <br>            : Redmine#33741�̑Ή�</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Exit_ButtonTool":
				{
					// ���C����ʂ̃N���[�Y
					this.Close();
					return;
				}
				case "InitWindow_ButtonTool":
				{
					// �E�B���h�E����������
					this.InitWindow();
					return;
				}
			}

			// �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
			FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
			Form frm = formControlInfo.Form;

			// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�݈̂ȉ����s
			if (!(frm is IDepositInputMDIChild)) return;

			switch (e.Tool.Key)
			{
				case "Save_ButtonTool":
				{
					// �ۑ�����
					((IDepositInputMDIChild)frm).SaveDepositProc();
					break;
				}
				case "New_ButtonTool":
				{
					// �V�K����
					((IDepositInputMDIChild)frm).NewDepositProc();
					break;
				}
				case "Delete_ButtonTool":
				{
					// �폜����
					((IDepositInputMDIChild)frm).DeleteDepositProc();
					break;
				}
				case "DebitNote_ButtonTool":
				{
					// �ԓ`����
					((IDepositInputMDIChild)frm).AkaDepositProc();
					break;
				}
            case "Renewal_ButtonTool":
                {
                    ((IDepositInputMDIChild)frm).RenewalProc();
                    break;
                }
                // ----- ADD ���N 2012/12/24 Redmine#33741 -------->>>>>
                case "ReadSupSlip_ButtonTool":
                {
                    //�`�[�ďo����
                    ((IDepositInputMDIChild)frm).ReadSlipProc();
                    break;
                }
                // ----- ADD ���N 2012/12/24 Redmine#33741 --------<<<<<
			}
		}

		/// <summary>
		/// �t�H�[���I���N�G���[�C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note		: �t�H�[������悤�Ƃ������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.20</br>
		/// </remarks>
		private void SFSIR02101UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			// �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
			FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
			Form frm = formControlInfo.Form;

			// �����ς̎��͕\������
			// IDepositInputMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
			if ((frm is IDepositInputMDIChild))
			{
				object parameter = null;
				if (((IDepositInputMDIChild)frm).BeforeClose(parameter) != 0)
				{
					e.Cancel = true;
					return;
				}
			}

			if (this.Main_TabControl.Tabs.Exists(ctNO0_PAYMENTINPUT_TAB))
			{
				// �X���C�_�[�̕\�����e��ۑ�����
				_superSlider.ClosePanel();
			}

			// �^�u�폜����
			TabRemove(ctNO0_PAYMENTINPUT_TAB);
		}
		#endregion

        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // �{�^�����uVisible = False�v�ɂ���ƁA�C�x���g���������Ȃ����߁A
            // �T�C�Y���u1, 1�v�ɂ��A�����I�Ɍ����Ȃ��悤�ɂ���

            DialogResult dResult = TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_QUESTION,
                            this.Name,
                            "�I�����Ă���낵���ł����H",
                            0,
                            MessageBoxButtons.YesNo,
                            MessageBoxDefaultButton.Button1);

            if (dResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
	}
}