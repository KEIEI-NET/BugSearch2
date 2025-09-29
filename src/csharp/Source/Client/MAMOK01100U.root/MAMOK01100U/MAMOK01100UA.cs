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

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// ����ڕW�ݒ�(����)���C���t���[��
	/// </summary>
	/// <remarks>
	/// <br>Note		: ����ڕW�ݒ�(����)���s����ʂł��B</br>
	/// <br>Programmer	: NEPCO</br>
	/// <br>Date		: 2007.05.08</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public partial class MAMOK01100UA : Form
	{
		#region Const

		// ����ڕW�ݒ�(����)�^�u
        private const string ctNO0_MONTHSALESTARTGET_TAB   = "NO0_MONTHSALESTARTGET_TAB";
        private const string ctNO0_MONTHSALESTARTGET_ASSY  = "MAMOK01110U";
        private const string ctNO0_MONTHSALESTARTGET_CLASS = "Broadleaf.Windows.Forms.MAMOK01110UA";
        private const string ctNO0_MONTHSALESTARTGET_TITLE = "����ڕW�ݒ�(����)";

		#endregion

		# region Private Menbers

		// ���_���}�X�^�A�N�Z�X�N���X
		private SecInfoAcs _secInfoAcs;
		// �t�H�[�����䃊�X�gHashtable
		private Hashtable _formControlInfoTable;
		// Tab�q��ʕ\���p�����[�^
		private int _parameter;
		// ���ݑI�����_
		private object selectedSection;
		// ���_�I�𒆃t���O
		private bool selectedSectionFlg;
		// �E�B���h�E��ԕێ��p�iToolBar�j
		private MemoryStream _toolMemoryStream;
		// ����N���t���O
		private int _firstStartFlg;

		private int _mode;

		/// <summary>��ʃf�U�C���ύX�N���X</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MAMOK01100UA()
		{
			InitializeComponent();

			try
			{
				if (Program._param.Length >= 3)
				{
					this._mode = int.Parse(Program._param[2]);
				}
				else
				{
					this._mode = 0;
				}

				// �t�H�[�����䃊�X�g
				this._formControlInfoTable = new Hashtable();
				// MDI�\���p�����[�^
				this._parameter = 1;
				// ���ݑI�����_
				this.selectedSection = null;
				// ���_�I�𒆃t���O
				this.selectedSectionFlg = false;
				// �E�B���h�E��ԕێ��p�iToolBar�j
				this._toolMemoryStream = null;
				// ����N���t���O
				this._firstStartFlg = 0;

				// �c�[���o�[��������
				ToobarInitProc();
			}
			catch (Exception ex)
			{
				string message = "���������ɂė�O���������܂���"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, "�ڕW�ݒ胁�C���t���[��"
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_INIT
					, message
					, -1
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
                //Program._floatingWindow.Close();
			}
		}
		#endregion

		#region PrivateMethod

		/// <summary>
		/// �c�[���o�[��������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �c�[���o�[�̏����ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void ToobarInitProc()
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA DEL START
            //// ���_���擾
            //SecInfoSet secInfoSet;
            //_secInfoAcs = new SecInfoAcs();
            //// ���Џ��擾
            //_secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);

            //// ���_�R���{�{�b�N�X�ɋ��_���X�g��ݒ肷��
            //ValueList secInfoList = new ValueList();
            //foreach (SecInfoSet secInfoSetWk in _secInfoAcs.SecInfoSetList)
            //{
            //    ValueListItem secInfoItem = new ValueListItem();
            //    secInfoItem.DataValue = secInfoSetWk.SectionCode;
            //    secInfoItem.DisplayText = secInfoSetWk.SectionGuideNm;
            //    secInfoList.ValueListItems.Add(secInfoItem);
            //}
            //ComboBoxTool sectionCombo = (ComboBoxTool)Main_ToolbarsManager.Tools["Section_ComboBoxTool"];
            //sectionCombo.ValueList = secInfoList;
            //sectionCombo.SharedProps.Enabled = false;
            //sectionCombo.SharedProps.AppearancesLarge.Appearance.ForeColorDisabled = Color.Black;
            //sectionCombo.SharedProps.AppearancesSmall.Appearance.ForeColorDisabled = Color.Black;
            //LabelTool sectionLabel = (LabelTool)Main_ToolbarsManager.Tools["Section_LabelTool"];

            //// �{�Ћ@�\����or���_�I�v�V���������Ȃ狒�_��ύX�ł��Ȃ��悤�ɂ���
            //if ((_secInfoAcs.GetMainOfficeFuncFlag(secInfoSet.SectionCode) == 0) ||
            //    (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) < PurchaseStatus.Contract))
            //{
            //    if (sectionCombo != null) sectionCombo.SharedProps.Visible = false;
            //    if (sectionLabel != null) sectionLabel.SharedProps.Visible = false;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA DEL END

			// �c�[���o�[�ɃC���[�W���X�g��ݒ肷��
			Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA DEL START
			// ���_�̃A�C�R���ݒ�
            //if (sectionLabel != null) sectionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA DEL END
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
			ButtonTool workButton;
			// �I���{�^���̃A�C�R���ݒ�
			workButton = (ButtonTool)Main_ToolbarsManager.Tools["Exit_ButtonTool"];
			if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			// �ۑ��{�^���̃A�C�R���ݒ�
			workButton = (ButtonTool)Main_ToolbarsManager.Tools["Save_ButtonTool"];
			if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Save_MenuTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // �䗦����v�Z�{�^���̃A�C�R���ݒ�
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["CalcFromRatio_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EDITING;
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["CalcFromRatio_MenuTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EDITING;
            // ���ɖ߂��{�^���̃A�C�R���ݒ�
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Undo_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Undo_MenuTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.UNDO;
            // �N�x����Ɖ�{�^���̃A�C�R���ݒ�
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["YearTarget_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["YearTarget_MenuTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
        }

		/// <summary>
		/// �t�H�[���R���g���[���N���X�N���G�C�g����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �q��ʃt�H�[����������쐬���܂�</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void FormControlInfoCreate()
		{
			FormControlInfo info;

			// ����ڕW�ݒ�(����)�̃R���g���[���N���X����
			info = new FormControlInfo(
				ctNO0_MONTHSALESTARTGET_TAB,
                ctNO0_MONTHSALESTARTGET_ASSY,
				ctNO0_MONTHSALESTARTGET_CLASS,
                ctNO0_MONTHSALESTARTGET_TITLE,
				IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2],
				"",
				"");
			// �t�H�[�����䃊�X�g�ɒǉ�
			this._formControlInfoTable.Add(ctNO0_MONTHSALESTARTGET_TAB, info);
		}

		/// <summary>
		/// �c�[���o�[�{�^���L�������ݒ菈��
		/// </summary>
        /// <param name="activeForm">�A�N�e�B�u�t�H�[��</param>
        /// <remarks>
		/// <br>Note		: �c�[���[�o�[�{�^���̗L���E�����ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void ToolBarButtonEnabledSetting(object activeForm)
		{
			if (this.Main_TabControl.ActiveTab == null)
				return;

			// �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
			FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
			System.Windows.Forms.Form frm = formControlInfo.Form;

			// �����ς̎��͕\������
			// ISalesMonTargetMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ������s����B
			if (!(frm is ISalesMonTargetMDIChild)) return;

			// �^�C�g��
			this.Text = ((ISalesMonTargetMDIChild)frm).Title;

			ButtonTool workButton;

			// �ۑ��{�^��
			workButton = Main_ToolbarsManager.Tools["Save_ButtonTool"] as ButtonTool;
			if (workButton != null) workButton.SharedProps.Enabled = ((ISalesMonTargetMDIChild)frm).SaveButton;
            workButton = Main_ToolbarsManager.Tools["Save_MenuTool"] as ButtonTool;
            if (workButton != null) workButton.SharedProps.Enabled = ((ISalesMonTargetMDIChild)frm).SaveButton;

			// �䗦����v�Z�{�^��
			workButton = Main_ToolbarsManager.Tools["CalcFromRatio_ButtonTool"] as ButtonTool;
			if (workButton != null) workButton.SharedProps.Enabled = ((ISalesMonTargetMDIChild)frm).CalcFromRatioButton;
            workButton = Main_ToolbarsManager.Tools["CalcFromRatio_MenuTool"] as ButtonTool;
            if (workButton != null) workButton.SharedProps.Enabled = ((ISalesMonTargetMDIChild)frm).CalcFromRatioButton;

            // ���ɖ߂��{�^��
            workButton = Main_ToolbarsManager.Tools["Undo_ButtonTool"] as ButtonTool;
            if (workButton != null) workButton.SharedProps.Enabled = ((ISalesMonTargetMDIChild)frm).UndoButton;
            workButton = Main_ToolbarsManager.Tools["Undo_MenuTool"] as ButtonTool;
            if (workButton != null) workButton.SharedProps.Enabled = ((ISalesMonTargetMDIChild)frm).UndoButton;

            // �N�x����Ɖ�{�^��
            workButton = Main_ToolbarsManager.Tools["YearTarget_ButtonTool"] as ButtonTool;
            if (workButton != null) workButton.SharedProps.Enabled = ((ISalesMonTargetMDIChild)frm).YearTargetButton;
            workButton = Main_ToolbarsManager.Tools["YearTarget_MenuTool"] as ButtonTool;
            if (workButton != null) workButton.SharedProps.Enabled = ((ISalesMonTargetMDIChild)frm).YearTargetButton;

        }

		/// <summary>
		/// �^�u�\������
		/// </summary>
		/// <param name="tabKind">�^�u���</param>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�^�u��\�����܂�</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
		/// <remarks>
		/// <br>Note		: �q��ʃ^�u�𐶐����܂�</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
			if ((form is ISalesMonTargetMDIChild))
			{
				// �c�[���o�[�{�^������f���Q�[�g�̓o�^
				((ISalesMonTargetMDIChild)form).ParentToolbarSettingEvent += new ParentToolbarSalesMonTargetSettingEventHandler(this.ParentToolbarSettingEvent);

				// �I�����_�擾�f���Q�[�g�̓o�^
                //((ISalesMonTargetMDIChild)form).GetSelectSectionCodeEvent += new GetSalesMonTargetSelectSectionCodeEventHandler(this.GetSelectSectionCodeEvent);

                int status = ((ISalesMonTargetMDIChild)form).InitializeForm();
                if (status != 0)
                {
                    return;
                }

				((ISalesMonTargetMDIChild)form).Show(this._parameter);
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
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�^�u���A�N�e�B�u�����܂�</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ�^�u���폜���܂�</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private Form CreateTabChildForm(string frmAssemblyId, string frmClassId, FormControlInfo info)
		{
			Form form = null;

			// �N���X�C���X�^���X������
			form = (System.Windows.Forms.Form)this.LoadAssemblyFrom(frmAssemblyId, frmClassId, typeof(System.Windows.Forms.Form));

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
			dataviewTab.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			dataviewTab.ActiveAppearance.BackColor = Color.White;
			dataviewTab.ActiveAppearance.BackColor2 = Color.LightPink;
			dataviewTab.ActiveAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
			dataviewTab.ActiveAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

			this.Main_TabControl.Controls.Add(dataviewTabPageControl);
			this.Main_TabControl.Tabs.AddRange(new UltraTab[] { dataviewTab });
			this.Main_TabControl.SelectedTab = dataviewTab;

			// �t�H�[���v���p�e�B�ύX
			form.TopLevel = false;
			form.FormBorderStyle = FormBorderStyle.None;
			form.Dock = System.Windows.Forms.DockStyle.Fill;
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
				string message = "�N���X�C���X�^���X�������ɂė�O���������܂���"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, "�ڕW�ݒ胁�C���t���[��"
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
		/// �E�B���h�E����������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �E�B���h�E������������</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void InitWindow()
		{
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
        //private string GetSelectSectionCodeEvent(object sender)
        //{
        //    // ���ݑI�����_��Ԃ�
        //    ValueListItem secInfoList = selectedSection as ValueListItem;
        //    if (secInfoList != null)
        //    {
        //        return secInfoList.DataValue.ToString();
        //    }

        //    return "";
        //}

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
		#endregion

		#region Event
		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2006.05.17</br>
		/// </remarks>
		private void MAMOK01100UA_Load(object sender, EventArgs e)
		{
			// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
			this._controlScreenSkin.LoadSkin();

			// ��ʃX�L���ύX
			this._controlScreenSkin.SettingScreenSkin(this);

			// ����N���t���O
			try
			{
				if (this._firstStartFlg == 0)
				{
					// �t�H�[������e�[�u��������
					this._formControlInfoTable.Clear();

					// �t�H�[���R���g���[���N���X�N���G�C�g����
					FormControlInfoCreate();
					TabShow(ctNO0_MONTHSALESTARTGET_TAB);

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.23 TOKUNAGA DEL START
					// ���_��ݒ�
					//ComboBoxTool sectionCombo = (ComboBoxTool)Main_ToolbarsManager.Tools["Section_ComboBoxTool"];
					//sectionCombo.Value = LoginInfoAcquisition.Employee.BelongSectionCode;

					//Main_ToolbarsManager_ToolValueChanged(sender, new ToolEventArgs(Main_ToolbarsManager.Tools["Section_ComboBoxTool"]));
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.23 TOKUNAGA DEL END

					this._firstStartFlg++;
				}
			}
			catch (Exception ex)
			{
				string message = "�t�H�[�����[�h�����ɂė�O���������܂���"
					+ "\n\r" + ex.Message + "\n\r" + ex.StackTrace;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, "�ڕW�ݒ胁�C���t���[��"
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
                //Program._floatingWindow.Close();
			}

			// �N���^�C�}�[�J�n
			StartTimer.Enabled = true;
		}

        /// <summary>
        /// �t�H�[���I���N�G���[�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �t�H�[������悤�Ƃ������ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.05.08</br>
        /// </remarks>
        private void MAMOK01100UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
            FormControlInfo formControlInfo = (FormControlInfo)this._formControlInfoTable[this.Main_TabControl.ActiveTab.Key.ToString()];
            System.Windows.Forms.Form frm = formControlInfo.Form;

            // �����ς̎��͕\������
            // ISalesMonTargetMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
            if ((frm is ISalesMonTargetMDIChild))
            {
                object parameter = null;
                if (((ISalesMonTargetMDIChild)frm).BeforeClose(parameter) != 0)
                {
                    e.Cancel = true;
                    return;
                }
            }
            // �^�u�폜����
            TabRemove(ctNO0_MONTHSALESTARTGET_TAB);
        }

        /// <summary>
		/// �c�[���o�[���e�I���C�x���g
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="e">�C�x���g���</param>
		/// <remarks>
		/// <br>Note		: �c�[���o�[�̊e�A�C�e�����e���I�����ꂽ���ɔ������܂�</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
						System.Windows.Forms.Form frm = formControlInfo.Form;

						// �����ς̎��͕\������
						// ISalesMonTargetMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�͈ȉ��̏��������s����B
						if ((frm is ISalesMonTargetMDIChild))
						{
							// ���_�ύX�O�ʒm����
							if (((ISalesMonTargetMDIChild)frm).BeforeSectionChange() != 0)
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
							((ISalesMonTargetMDIChild)frm).AfterSectionChange();
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void StartTimer_Tick(object sender, EventArgs e)
		{
			// �N���^�C�}�[�I��
			StartTimer.Enabled = false;

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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
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
			System.Windows.Forms.Form frm = formControlInfo.Form;

			// ISalesMonTargetMDIChild�C���^�[�t�F�C�X���������Ă���ꍇ�݈̂ȉ����s
			if (!(frm is ISalesMonTargetMDIChild)) return;

			switch (e.Tool.Key)
			{
                case "Save_ButtonTool":
                case "Save_MenuTool":
				{
					// �ۑ�����
					((ISalesMonTargetMDIChild)frm).SaveSalesMonTargetProc();
					break;
				}
                case "CalcFromRatio_ButtonTool":
                case "CalcFromRatio_MenuTool":
				{
					// �䗦����v�Z����
					((ISalesMonTargetMDIChild)frm).CalcFromRatioSalesMonTargetProc();
					break;
				}
                case "Undo_ButtonTool":
                case "Undo_MenuTool":
				{
                    // ���ɖ߂�����
					((ISalesMonTargetMDIChild)frm).UndoSalesMonTargetProc();
					break;
				}
                case "YearTarget_ButtonTool":
                case "YearTarget_MenuTool":
				{
                    // �N�x����Ɖ��
					((ISalesMonTargetMDIChild)frm).YearTargetSalesMonTargetProc();
					break;
				}
			}
		}

        #endregion

	}
}