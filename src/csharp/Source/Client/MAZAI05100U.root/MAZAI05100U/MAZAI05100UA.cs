using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;

using Infragistics.Win;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
	/// �I�������������C���t���[���N���X    
	/// </summary>
	/// <remarks>
	/// <br>Note       : �I�������������C���t���[���N���X�̋@�\���������܂�</br>
	/// <br>Programmer : 23010 �����m</br>
	/// <br>Date       : 2007.04.12</br>
    /// <br>UpDateNote : 2007.07.23 H.NAKAMURA</br>
    ///                  �t���[���Ɏ����_(���O�C�����_���̂�\������悤�C��)
    /// <br>UpdateNote : 2008/08/28 30414 �E �K�j</br>
    /// <br>             �EPartsman�p�ɕύX</br>
	/// </remarks>
    public partial class MAZAI05100UA : Form
    {
        #region Constructor

        /// <summary>
	    /// �I�������������C���t���[���N���X�R���X�g���N�^    
	    /// </summary>
	    /// <remarks>
	    /// <br>Note       : �I�������������C���t���[���N���X�̃C���X�^���X�����������܂�</br>
	    /// <br>Programmer : 23010 �����m</br>
	    /// <br>Date       : 2007.04.12</br>
	    /// </remarks>
        public MAZAI05100UA()
        {
            InitializeComponent();

			// ���O�C����񐶐� //
			if (LoginInfoAcquisition.Employee != null)
			{
				// �]�ƈ����
				Employee employee = new Employee();
				employee = LoginInfoAcquisition.Employee;			    
                //��ƃR�[�h
                this._enterpriseCode = employee.EnterpriseCode;
				//���O�C���]�ƈ��R�[�h
				this._employeeCode = employee.EmployeeCode;
				//���O�C���]�ƈ�����
				this._employeeName = employee.Name;

                /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
                //���O�C�����_�R�[�h
                this._loginSectionCode = employee.BelongSectionCode;
                   --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

                //���O�C�����_����
                //�]�ƈ����狒�_���̂��擾�ł��Ȃ��B�B�B
                //this._loginSectionName = employee.BelongSectionName;
			}

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            //���_�K�C�h���̎擾
            SecInfoSet set;
            ArrayList list;
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoAcs.GetSecInfo(out set,out list);
            if(set != null)
            {
                this._loginSectionName = set.SectionGuideNm;
            }
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

            //�ߕs���X�V���ʃt���[���ɂȂ����̂łP�Œ�
			//�N���p�����[�^
			//this._iPara = ConvertToInt32(Program._parameter[0]);
            this._iPara = 1;

			// �^�u�ɕ\������t�H�[���N���X�̏����\�z����
            switch (this._iPara)
			{
				case ctInventoryPrepare:
					// �I����������
					this.Text = NO0_INVENTORYPREPARE_TITLE;
					break;
				case ctJustEnough:
					// �ߕs���X�V����
					this.Text = NO1_JUSTENOUGH_TITLE;
					break;
			}
        }

        #endregion 

        #region Private Member

        #region Const

        // �p�����[�^
		private const int ctInventoryPrepare = 1;			// �I����������
		private const int ctJustEnough = 2;					// �ߕs���X�V����

		// �^�u�֘A
		private const string NO0_INVENTORYPREPARE_TITLE			= "�I����������";
		private const string NO0_INVENTORYPREPARE_TAB			= "INVENTORYPREPARE_TAB";
		private const string NO0_INVENTORYPREPARE_VIEW_TITLE	= "�I���������[�r���[";
		private const string NO0_INVENTORYPREPARE_VIEW_TAB		= "INVENTORYPREPARE_VIEW_TAB";
	
		private const string NO1_JUSTENOUGH_TITLE				= "�I���ߕs���X�V����";
		private const string NO1_JUSTENOUGH_TAB					= "JUSTENOUGH_TAB";
		private const string NO1_JUSTENOUGH_VIEW_TITLE			= "�I���\�r���[";
		private const string NO1_JUSTENOUGH_VIEW_TAB			= "JUSTENOUGH_VIEW_TAB";

        //�c�[���o�[�֘A
        //�L�[
        private const string ctFILE_POPUPMENUTOOLKEY        = "File_PopupMenuTool";         //�t�@�C��
        private const string ctCLOSE_BUTTONTOOLKEY          = "Close_ButtonTool";           //����
        private const string ctSAVE_BUTTONTOOLKEY           = "Save_ButtonTool";            //�ۑ�
        private const string ctPRINT_BUTTONTOOLKEY          = "Print_ButtonTool";           //���
        private const string ctLOGINNAMETITLE_LABELTOOLKEY  = "LoginNameTitle_LabelTool";   //���O�C���S���҃��x��
        private const string ctLOGINNAME_LABELTOOLKEY       = "LoginName_LabelTool";        //���O�C���S���Җ�

        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        private const string ctSECTIONNAMETITLE_LABELTOOLKEY = "SectionNameTitle_LabelTool";      //���O�C�����_�^�C�g�����x��
        private const string ctSECTIONNAME_LABLETOOLKEY     = "SectionName_LableTool";      //���O�C�����_����
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

        // StatusBar�֘A
		private const string ctSTATUSBAR_TEXT = "StatusBarPanel_Text";
		private const string ctSTATUSBAR_PROGRESS = "StatusBarPanel_Progress";

        #endregion

        #region Member

        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        //���_���A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs;
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

        // ���O�C�����
		private string _enterpriseCode;
		private string _employeeCode;
		private string _employeeName;

        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        private string _loginSectionCode;
        private string _loginSectionName;
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

        // �C�x���g�L�����Z���t���O
		private bool _eventExecFlg = false;
		// �X�e�[�^�X�o�[���b�Z�[�W�N���A�L�����Z���t���O
		private bool _isMsgClearCansel = false;

        // �t�H�[���R���g���[���N���X����
		private Dictionary<string, FormControlInfo_Invent> _formControlInfoDic = null;

        // �N������
		int _iPara = 0 ;

        #endregion

        #endregion

        #region Private Methods

        #region ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏������������s���܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.02</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �X�e�[�^�X�o�[�i���o�[���䏈��(����)
			this.StatusBarProgressControlEnd();
           
            // �c�[���o�[�����ݒ菈��
			this.SetToolbar();

            // �c�[���o�[�Ƀ��O�C���S���҂�\������
			this.ShowToolbarSlip();

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            // �c�[���o�[�Ƀ��O�C�����_���̂�\��
            this.ShowSectionForToolbar();
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        }
        #endregion

        #region �X�e�[�^�X�o�[�i������

        /// <summary>
		/// �X�e�[�^�X�o�[�i���o�[���䏈��(�J�n)
		/// </summary>
		private void StatusBarProgressControlStart(int max, int min, int val, string message)
		{
			this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = message;
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].Visible = true;
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Maximum = max;
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Minimum = min;
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Value = val;
			this.Main_StatusBar.Refresh();
		}

		/// <summary>
		/// �X�e�[�^�X�o�[�i���o�[���䏈��(�o��)
		/// </summary>
		private void StatusBarProgressControl(string message)
		{
			this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = message;
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Value++;
			this.Main_StatusBar.Refresh();
		}

        /// <summary>
		/// �X�e�[�^�X�o�[�i���o�[���䏈��(����)
		/// </summary>
		private void StatusBarProgressControlEnd()
		{          
			this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = "";
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Value = this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].ProgressBarInfo.Maximum;
			this.Main_StatusBar.Panels[ctSTATUSBAR_PROGRESS].Visible = false;
			this.Main_StatusBar.Refresh();
        }

        #endregion

        #region �c�[���o�[�����ݒ菈��

        /// <summary>
		/// �c�[���o�[�����ݒ菈��
		/// </summary>
		private void SetToolbar()
		{
			// �C���[�W���X�g��ݒ肷��
            ImageList imageList16 = IconResourceManagement.ImageList16;
			this.Main_ToolbarsManager.ImageListSmall = imageList16;

            // ���O�C���S���҂ւ̃A�C�R���ݒ�
			LabelTool loginEmployeeLabel = (LabelTool)Main_ToolbarsManager.Tools[ctLOGINNAMETITLE_LABELTOOLKEY];
			if (loginEmployeeLabel != null)
				loginEmployeeLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;

			// �I���̃A�C�R���ݒ�
			ButtonTool closeButton = (ButtonTool)Main_ToolbarsManager.Tools[ctCLOSE_BUTTONTOOLKEY];
			if (closeButton != null)
				closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;

			// �ۑ��̃A�C�R���ݒ�
			ButtonTool saveButton = (ButtonTool)Main_ToolbarsManager.Tools[ctSAVE_BUTTONTOOLKEY];
			if (saveButton != null)
				saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;

			// ����̃A�C�R���ݒ�(�t���[������̈���@�\�͕ۗ�)
			ButtonTool printButton = (ButtonTool)Main_ToolbarsManager.Tools[ctPRINT_BUTTONTOOLKEY];
			if (printButton != null)
				printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            // ���_���x���̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.LabelTool sectionLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[ctSECTIONNAMETITLE_LABELTOOLKEY];
			if (sectionLabel != null)
				sectionLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        }

        #endregion

        #region ���O�C���S���ҕ\������
        /// <summary>
        /// �c�[���o�[�Ƀ��O�C���S���҂�\������
        /// </summary>
        private void ShowToolbarSlip()
        {          
			//���O�C���]�ƈ�����
            if(LoginInfoAcquisition.Employee.Name != null)
            {
                this.Main_ToolbarsManager.Tools[ctLOGINNAME_LABELTOOLKEY].SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            }
            
            LabelTool loginName = (LabelTool)Main_ToolbarsManager.Tools[ctLOGINNAME_LABELTOOLKEY];
            if (loginName != null && _employeeName != null)
                loginName.SharedProps.Caption = this._employeeName;
        }
        #endregion

        #region DEL 2008/08/28 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        #region �I�����_�\������

        /// <summary>
        /// �c�[���o�[�ɒI�����_��\������
        /// </summary>
        private void ShowSectionForToolbar()
        {          
			//���O�C�����_����
            if(LoginInfoAcquisition.Employee.Name != null)
            {
                this.Main_ToolbarsManager.Tools[ctSECTIONNAME_LABLETOOLKEY].SharedProps.Caption = this._loginSectionName;
            }
            
            Infragistics.Win.UltraWinToolbars.LabelTool secName = (Infragistics.Win.UltraWinToolbars.LabelTool)Main_ToolbarsManager.Tools[ctSECTIONNAME_LABLETOOLKEY];
            if (secName != null)
                secName.SharedProps.Caption = this._loginSectionName;
        }

        #endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �t�H�[���R���g���[���N���X�N���G�C�g����
        /// <summary>
		/// �t�H�[���R���g���[���N���X�N���G�C�g����
		/// </summary>
		private void FormControlInfoCreate()
		{
			if ( this._formControlInfoDic != null ) 
			{
				return;
			}
			else
			{
				this._formControlInfoDic = new Dictionary<string,FormControlInfo_Invent>();
			}

			// �^�u�ɕ\������t�H�[���N���X�̏����\�z����
            switch (this._iPara)
            {
                case ctInventoryPrepare:
                    // �I����������
                    // �^�u�ɕ\������t�H�[���N���X�̏����\�z����
                    // UIForm
                    this._formControlInfoDic.Add(
                        NO0_INVENTORYPREPARE_TAB ,                  // Key
                        new FormControlInfo_Invent(			        // Tab Info
                            NO0_INVENTORYPREPARE_TAB,				// Tab Key
                            "MAZAI05110U",							// Tab AsmID
                            "Broadleaf.Windows.Forms.MAZAI05110UA",	// Tab ClassID
                            NO0_INVENTORYPREPARE_TITLE,				// Tab Name
                            IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH	]	// icon
                        )
                    );
                    // ListView(�t���[�����������s���ۂɎg�p�B�@�\�g���̈׏������Ă���)
                    this._formControlInfoDic.Add(
                        NO0_INVENTORYPREPARE_VIEW_TAB, 
                        new FormControlInfo_Invent(			        // Tab Info
                            NO0_INVENTORYPREPARE_VIEW_TAB,			// Tab Key
                            "MAZAI05100U",							// Tab AsmID
                            "Broadleaf.Windows.Forms.MAZAI05100UB",	// Tab ClassID
                            NO0_INVENTORYPREPARE_VIEW_TITLE,		// Tab Name
                            IconResourceManagement.ImageList16.Images[(int)Size16_Index.VIEW	]	// icon
                        )
                    );

                    break;
                case ctJustEnough:
                    //����͉ߕs���X�V���s��Ȃ��d�l�Ȃ̂Ŗ��g�p
                    //����d�l���ύX���ꂽ�ꍇ�Ɏg�p����
                    // �^�u�ɕ\������t�H�[���N���X�̏����\�z����
                    // �I���ߕs���X�V
                    // �^�u�ɕ\������t�H�[���N���X�̏����\�z����
                    // UIForm
                    this._formControlInfoDic.Add(
                        NO1_JUSTENOUGH_TAB ,                        // Key
                        new FormControlInfo_Invent(			        // Tab Info
                            NO1_JUSTENOUGH_TAB,						// Tab Key
                            "MAZAIXXXXXU",							// Tab AsmID
                            "Broadleaf.Windows.Forms.MAZAIXXXXXUA",	// Tab ClassID
                            NO1_JUSTENOUGH_TITLE	,				// Tab Name
                            IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH	]	// icon
                        )
                    );
                    // ListView
                    this._formControlInfoDic.Add(
                        NO1_JUSTENOUGH_VIEW_TAB, 
                        new FormControlInfo_Invent(			// Tab Info
                            NO1_JUSTENOUGH_VIEW_TAB,				// Tab Key
                            "MAZAI05100U",							// Tab AsmID
                            "Broadleaf.Windows.Forms.MAZAI05100UB",	// Tab ClassID
                            NO1_JUSTENOUGH_VIEW_TITLE		,		// Tab Name
                            IconResourceManagement.ImageList16.Images[(int)Size16_Index.VIEW	]	// icon
                        )
                    );

                    break;
            }
        }

        #endregion

        #region �^�u�N���G�C�g����(TabCreate)
		/// <summary>
		/// �^�u�N���G�C�g����
		/// </summary>
		/// <param name="key">�^�uKey</param>
		private void TabCreate(string key)
		{
			// �t�H�[���R���g���[���N���X�����ɃL�[�����݂��Ȃ��ꍇ�͏������Ȃ�
			if (!this._formControlInfoDic.ContainsKey(key)) return;
	
			FormControlInfo_Invent info = this._formControlInfoDic[key];

			Cursor _localCursor = this.Cursor;
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (info.Form == null)
				{
					// �^�u�q��ʐ���
					if (this.CreateMdiChildForm(info)) return;
				}
				else
				{
					this.Main_UTabControl.Tabs[key].Visible = true;
					this.Main_UTabControl.Tabs[key].Active = true;
					this.Main_UTabControl.Tabs[key].Selected = true;
					this.Main_UTabControl.Tabs[key].Text = info.Name;
				}
			}
			finally
			{
				this.Cursor = _localCursor;
			}
		}
		#endregion

        #region MDI�q��ʂ𐶐�����(CreateMdiChildForm)
		/// <summary>
		/// MDI�q��ʂ𐶐�����
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		private bool CreateMdiChildForm(FormControlInfo_Invent info)
		{
			info.Form = null;
			info.Form = (Form)this.LoadAssemblyFrom(info.AssemblyID, info.ClassID, typeof(Form));

			if (info.Form == null)
				info.Form = new Form();

			if (info.Form != null)
			{
				// �t�H�[���v���p�e�B�ύX
				info.Form.Name = info.Name;

				// �^�u�y�[�W�R���g���[�����C���X�^���X
				UltraTabPageControl uTabPageControl = new UltraTabPageControl();

				// �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
				UltraTab uTab = new UltraTab();
				uTab.TabPage = uTabPageControl;
				uTab.Text = info.Name;								// ����
				uTab.Key = info.Key;								// Key
				uTab.Tag = info.Form;								// �t�H�[���̃C���X�^���X
				uTab.Appearance.Image = info.Icon;					// �A�C�R��
				uTab.Appearance.BackColor = Color.White;
				uTab.Appearance.BackColor2 = Color.Lavender;
				uTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
				uTab.ActiveAppearance.BackColor = Color.White;
				uTab.ActiveAppearance.BackColor2 = Color.LightPink;
				uTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;

				this.Main_UTabControl.Controls.Add(uTabPageControl);
				this.Main_UTabControl.Tabs.AddRange(new UltraTab[] { uTab });
				this.Main_UTabControl.SelectedTab = uTab;

				info.Form.TopLevel = false;
				info.Form.FormBorderStyle = FormBorderStyle.None;
				info.Form.Show();

				uTabPageControl.Controls.Add(info.Form);
				info.Form.Dock = DockStyle.Fill;
			}

			return true;
		}
		#endregion

        #region �N���X���C���X�^���X������(LoadAssemblyFrom)
		/// <summary>
		/// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		private object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object obj = null;

			try
			{
				Assembly asm = Assembly.Load(asmname);
				Type objType = asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
						obj = Activator.CreateInstance(objType);
				}
			}
			catch (FileNotFoundException er)
			{
				// �ΏۃA�Z���u���Ȃ��I
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.ctPGID,
					er.Message,
					0, MessageBoxButtons.OK);

			}
			catch (System.Exception er)
			{
				// �ΏۃA�Z���u���Ȃ�
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.ctPGID,
					"Message=" + er.Message + "\r\n" + "Trace  =" + er.StackTrace + "\r\n" + "Source =" + er.Source,
					0, MessageBoxButtons.OK);
			}

			return obj;
		}
		#endregion

        #region �^�u�A�N�e�B�u����(TabActive)
		/// <summary>
		/// �^�u�A�N�e�B�u����
		/// </summary>
		/// <param name="key">�ΏۃL�[���</param>
		private Form TabActive(string key)
		{
			Form form = new Form();
			form = null;

			// �w��Key�̃^�u�����݂��邩�`�F�b�N
			bool bingo = false;
			foreach (UltraTab tab in Main_UTabControl.Tabs)
			{
				if (tab.Key == key)
				{
					bingo = true;

					break;
				}
			}
			if (!bingo) return form;

			Cursor _localCursor = this.Cursor;
			try
			{
				this.Cursor = Cursors.WaitCursor;
				switch (key)
				{
					case NO0_INVENTORYPREPARE_TAB:
					case NO1_JUSTENOUGH_TAB:
						// �t�H�[�����擾����
						if (Main_UTabControl.Tabs[key].Tag is Form) form = (Form)Main_UTabControl.Tabs[key].Tag;

						// �w��Key��Select��ԂłȂ��ꍇ�́A�^�u��Select��Ԃɂ���
						if (this.Main_UTabControl.Tabs[key].Selected == false)
							this.Main_UTabControl.SelectedTab = this.Main_UTabControl.Tabs[key];

						break;
					default:
						break;
				}
			}
			finally
			{
				this.Cursor = _localCursor;
			}

			return form;
		}
		#endregion

        #region �X�^�e�B�b�N���W�J�������q���
        /// <summary>
		/// �q��ʂ�Static����\��������
		/// </summary>
		private void ShowMdiChild()
		{
			FormControlInfo_Invent formControlInfo = GetFormControlInfo_Invent();
			if (formControlInfo != null)
			{
                if (formControlInfo.Form is IEntryTbsMDIChild)
                    // �X�^�e�B�b�N�ۑ�����
                    ((IEntryTbsMDIChild)formControlInfo.Form).ShowStaticMemoryData(this);
			}
        }
        #endregion

        #region �X�^�e�B�b�N��񏊓�����
        /// <summary>
		/// FormControlInfo_Invent�擾����
		/// </summary>
		/// <returns>FormControlInfo_Invent</returns>
		private FormControlInfo_Invent GetFormControlInfo_Invent()
		{
			FormControlInfo_Invent formControlInfo = null;
			if ( this._iPara == ctInventoryPrepare )
			{
				if ( this._formControlInfoDic.ContainsKey(NO0_INVENTORYPREPARE_TAB) )
				{
					formControlInfo = this._formControlInfoDic[NO0_INVENTORYPREPARE_TAB];
				}
			}
			else
			{
				if ( this._formControlInfoDic.ContainsKey(NO1_JUSTENOUGH_TAB) )
				{
					formControlInfo = this._formControlInfoDic[NO1_JUSTENOUGH_TAB];
				}
			}
			return formControlInfo;
        }
        #endregion

        #region ���̓`�F�b�N����

        /// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <returns>STATUS: 0:OK, 1:NG</returns>
		private int InputCheck()
		{
            //�X�^�e�B�b�N���擾
			FormControlInfo_Invent formControlInfo = GetFormControlInfo_Invent();
			int status = 0;
			int status2 = 0;
			ArrayList errorList = new ArrayList();

			if (formControlInfo != null)
			{
				if (formControlInfo.Form is IEntryTbsMDIChild)
					status2 = ((IEntryTbsMDIChildEdit)formControlInfo.Form).ShowErrorItems(this, errorList);

                    if (status2 != 0)
                        status = status2;
			}

			if (status != 0)
			{
				string message = "";
				foreach (string s in errorList)
				{
					if (s != "")
					{
						if (message == "")
							message = s;
						else
							message += "\n" + s;
					}
				}
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.ctPGID,
					message,
					0, MessageBoxButtons.OK);
			}

			return status;
        }

        #endregion

        #region MDI�t�H�[���̓o�^����

        /// <summary>
		/// MDI�t�H�[���̓o�^����
		/// </summary>
		private int SaveEditMdiChild()
		{
			int status = 0;

			// ���݂̃J�[�\����ޔ�����
			Cursor _localCursor = this.Cursor;

			string beforSaveMsg = string.Empty;	// �ۑ��OMsg
			string savingMsg = string.Empty;	// �ۑ���Msg
			string faledSaveMsg =string.Empty;	// �ۑ���Msg

			if ( this._iPara == ctInventoryPrepare )
			{
				// �I����������
				beforSaveMsg = "�I�������������ł��D�D�D";
				savingMsg = "�I�������������������܂����B";
				faledSaveMsg = "�I�����������Ɏ��s���܂����B";
			}
			else
			{
				// �ߕs���X�V
				beforSaveMsg = "�I���ߕs���X�V���ł��D�D�D";
				savingMsg = "�I���ߕs���X�V���������܂����B";
				faledSaveMsg = "�I���ߕs���X�V�Ɏ��s���܂����B";
			}

            //�X�^�e�B�b�N���擾
			FormControlInfo_Invent formControlInfo = GetFormControlInfo_Invent();
			try
			{

				if (formControlInfo.Form != null)
				{
					// �J�[�\�����wWait�x�ɂ���
					this.Cursor = Cursors.WaitCursor;

					this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = beforSaveMsg;
					// �ۑ�����
					status = this.StoreMdiChild(formControlInfo);

				}

				switch (status)
				{
					case 0:
						this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = savingMsg;
						break;
					case 1:	// �����f�[�^����Dialog�ŃL�����Z���������ꂽ�Ƃ��̏����B(MethodResult.ctFNC_NO_RETURN)
						this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = "";
						break;
//                    case 4:
//                    case 800:
//                    case 801:
//                        // ������ł͉������Ȃ��B�q��ʂŃG���[�\���ȂǑΉ�����
//                        break;
                    default:
        			this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = faledSaveMsg;
		              break;
                }
            }
			finally
			{
				
				((IEntryTbsMDIChild)formControlInfo.Form).ShowStaticMemoryData(this);

				//extraForm.Close();
				StatusBar_MsgClear_Timer.Enabled = true;
				// �J�[�\�������ɖ߂�
				this.Cursor = _localCursor;
			}

            return status;
        }

        #endregion

        #region �q��ʂ̕ۑ�����

        /// <summary>
		/// �q��ʂ̕ۑ�����
		/// </summary>
		/// <param name="formControlInfo"></param>
		/// <returns></returns>
		private int StoreMdiChild(FormControlInfo_Invent formControlInfo)
		{
			int status = -1;

			if (formControlInfo != null)
			{
				if (formControlInfo.Form is IEntryTbsMDIChildEdit)
					// �X�^�e�B�b�N�ۑ�����
					status = ((IEntryTbsMDIChildEdit)formControlInfo.Form).SaveStaticMemoryData(this);
			}

			return status;
        }

        #endregion

        #region PDF�v���r���[��ʃt�H�[���擾����

        /// <summary>
		/// PDF�v���r���[��ʃt�H�[���擾����
		/// </summary>
		/// <param name="key">�L�[</param>
		/// <returns>PDF�v���r���[��ʃt�H�[��</returns>
		private  MAZAI05100UB GetFormFromControlInfoDic(string key)
		{
			MAZAI05100UB MAZAI05100UB = null;
			if (this._formControlInfoDic.ContainsKey(key))
			{
				Form form = this._formControlInfoDic[key].Form;
				if ((form != null) && (form is MAZAI05100UB))
				{
					MAZAI05100UB = (MAZAI05100UB)form;
				}
			}
			return MAZAI05100UB;
        }

        #endregion

        #region DEL 2008/08/28 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        #region �R���o�[�g����

        /// <summary>
		/// �R���o�[�g�iInt32�j����
		/// </summary>
		/// <param name="source">�R���o�[�g�Ώ�</param>
		/// <returns>�R���o�[�g����</returns>
		private Int32 ConvertToInt32(object source)
		{
			Int32 dest = 0;

			try
			{
				dest = Convert.ToInt32(source);
			}
			catch
			{
				dest = 0;
			}

			return dest;
        }

        #endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region �c�[���o�[�{�^���L�������ݒ菈��
        /// <summary>
		/// �c�[���o�[�{�^���L�������ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�{�^���L�������ݒ���s���܂�</br>
		/// <br>Programer  : 23010 �����@�m</br>
		/// <br>Date       : 2007.04.03</br>
		/// </remarks>
		private void ToolBarButtonEnabledSetting()
		{
			// �I����������or�ߕs���X�V�^�u
			if ( ((this.Main_UTabControl.Tabs.Exists(NO0_INVENTORYPREPARE_TAB)) && (this.Main_UTabControl.SelectedTab.Key == NO0_INVENTORYPREPARE_TAB)) ||
				 ((this.Main_UTabControl.Tabs.Exists(NO1_JUSTENOUGH_TAB)) && (this.Main_UTabControl.SelectedTab.Key == NO1_JUSTENOUGH_TAB)) )
			{
				this.SetToolEnabled("Close_ButtonTool"		, true);
				this.SetToolEnabled("Save_ButtonTool"		, true);
				this.SetToolEnabled("Print_ButtonTool"		, true);
			}
			else
			{
				this.SetToolEnabled("Close_ButtonTool"		, true);
				this.SetToolEnabled("Save_ButtonTool"		, false);
				this.SetToolEnabled("Print_ButtonTool"		, false);
			}
        }
       
        /// <summary>
		/// ToolBarEnableSetting
		/// </summary>
		/// <param name="key"></param>
		/// <param name="enabled"></param>
		private void SetToolEnabled(string key, bool enabled)
		{
			ToolBase toolBase = this.Main_ToolbarsManager.Tools[key];
			if (toolBase != null) toolBase.SharedProps.Enabled = enabled;
		}

        #endregion

        #region MDI�t�H�[���̈������(�ۗ�)
        /// <summary>
        /// MDI�t�H�[���̈������
        /// </summary>
        private void PrintEditMdiChild()
        {
            //TODO:�t���[������̈���͕ۗ�
            #region Del
            //�X�^�e�B�b�N���擾
            //FormControlInfo_Invent formControlInfo = GetFormControlInfo_Invent();
            //if (formControlInfo.Form != null)
            //{
            //    // ���݂̃J�[�\����ޔ�����
            //    Cursor _localCursor = this.Cursor;

            //    int status = 0;
            //    string pdfFilePath = string.Empty;
            //    MAZAI05100UB MAZAI05100UB = null;
            //    try
            //    {
            //        // �J�[�\�����wWait�x�ɂ���
            //        this.Cursor = Cursors.WaitCursor;

            //        // �I�������\�A�I���\�ǂ����������邩�`�F�b�N
            //        if ( formControlInfo.Key == NO0_INVENTORYPREPARE_TAB )
            //        {
            //this._prtsInventSearchCndtnWork = new PrtsInventSearchCndtnWork();
            //// �I�������[
            //if (formControlInfo != null)
            //{
            //    if (formControlInfo.Form is IEntryTbsMDIChild)
            //        // UI�̒��o�����擾�̂��߃X�^�e�B�b�N�ۑ��������Ăяo��
            //        ((IEntryTbsMDIChild)formControlInfo.Form).ShowStaticMemoryData((object)this._prtsInventSearchCndtnWork);
            //}

            //if ( _prtsInventSearchCndtnWork == null )
            //{
            //    this._prtsInventSearchCndtnWork = new PrtsInventSearchCndtnWork();
            //    this._prtsInventSearchCndtnWork.EnterpriseCode = this._enterpriseCode;
            //    this._prtsInventSearchCndtnWork.PartsInventorySecCd = this._stockSecInfoSet.SectionCode;
            //}

            //// �����ʕ\��
            //if ( this._sfzai03005UA == null )
            //{
            //    this._sfzai03005UA = new SFZAI03005UA();
            //}

            //this._sfzai03005UA.Show( this._prtsInventSearchCndtnWork );
            //status = 0; // �p�����[�^���A���Ă��Ȃ��̂ŏ�Ƀ[���B�G���[�͈��UI�ŕ\��

            //// PDF����`�F�b�N
            //if ( this._sfzai03005UA.PdfTempPath != null )
            //{
            //    pdfFilePath = this._sfzai03005UA.PdfTempPath; // TODO:PDFFilePath���擾����
            //}
            //else
            //{
            //    pdfFilePath = string.Empty;
            //}
            //    if (pdfFilePath != string.Empty)
            //    {
            //        //// ���[�ɂ���ă^�u�̖��̂�ύX����
            //        //if ( this._sfzai03005UA.PrpIndex == (int)SFZAI03005UA.PrintOutPaperIndex.PrintOutPaperIndex_1 )
            //        //{
            //        //    this._formControlInfoDic[NO0_INVENTORYPREPARE_VIEW_TAB].Name = SFZAI03005UA.PrintOutPaperName_1 + "�r���[";
            //        //}
            //        //else if ( this._sfzai03005UA.PrpIndex == (int)SFZAI03005UA.PrintOutPaperIndex.PrintOutPaperIndex_2 )
            //        //{
            //        //    this._formControlInfoDic[NO0_INVENTORYPREPARE_VIEW_TAB].Name = SFZAI03005UA.PrintOutPaperName_2 + "�r���[";
            //        //}

            //        // �݌ɕ��i�ꗗ�\PDF�v���r���[�\��
            //        this.TabCreate(NO0_INVENTORYPREPARE_VIEW_TAB);

            //        MAZAI05100UB = this.GetFormFromControlInfoDic(NO0_INVENTORYPREPARE_VIEW_TAB);
            //        if (MAZAI05100UB != null)
            //        {
            //            // PDF�v���r���[�N��
            //            MAZAI05100UB.ShowPDFPreview(pdfFilePath);
            //        }
            //    }

            //}
            //else if ( formControlInfo.Key == NO1_JUSTENOUGH_TAB )
            //{
            //if ( this._sfzai03045UA == null )
            //{
            //    this._sfzai03045UA = new SFZAI03045UA();
            //}
            //// �I���\
            //CreatePrtsInventInputCndtn();
            //this._sfzai03045UA.ShowDialog(this._prtsInventInputCndtn);

            //status = 0; // �p�����[�^���A���Ă��Ȃ��̂ŏ�Ƀ[���B�G���[�͈��UI�ŕ\��

            //// PDF����`�F�b�N
            //if ( this._sfzai03045UA.PdfTempPath != null )
            //{
            //    pdfFilePath = this._sfzai03045UA.PdfTempPath; // TODO:PDFFilePath���擾����
            //}
            //else
            //{
            //    pdfFilePath = string.Empty;
            //}

            //        if (pdfFilePath != string.Empty)
            //        {
            //            // �݌ɕ��i�ꗗ�\PDF�v���r���[�\��
            //            this.TabCreate(NO1_JUSTENOUGH_VIEW_TAB);
            //            MAZAI05100UB = this.GetFormFromControlInfoDic(NO1_JUSTENOUGH_VIEW_TAB);
            //            if (MAZAI05100UB != null)
            //            {
            //                // PDF�v���r���[�N��
            //                MAZAI05100UB.ShowPDFPreview(pdfFilePath);
            //            }
            //        }
            //    }


            //}
            //finally
            //{
            //    // �J�[�\�������ɖ߂�
            //    this.Cursor = _localCursor;
            //}

            //                switch (status)
            //                {
            //                    case 0:
            //                        // �q��ʂɑ΂��čĕ\�������s������
            //                        ShowMdiChild();
            //                        break;
            ////                    case 4:
            ////                    case 800:
            ////                    case 801:
            ////                        // ������ł͉������Ȃ��B�q��ʂŃG���[�\���ȂǑΉ�����
            ////                        break;
            //                    default:
            ////                        if (retMsg != "")
            ////                            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, Program.ctPGID,
            //////								"�������݂ŃG���[���������܂���",
            ////                                retMsg,
            ////                                status, MessageBoxButtons.OK);

            //                        break;
            //                }
            //}
            #endregion
            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "MAZAI05100UA", "�������ł�", 0, MessageBoxButtons.OK);
        }

        #endregion

        #region �t���[������̈���@�\(�ۗ�)
        ///// <summary>
        ///// ���i�I���������o�����N���X�쐬����
        ///// </summary>
        //private void CreatePrtsInventInputCndtn()
        //{
        //    if ( this._prtsInventInputCndtn == null )
        //    {
        //        this._prtsInventInputCndtn = new PrtsInventInputCndtn();
        //        this._prtsInventInputCndtn.EnterpriseCode = this._enterpriseCode.Trim();		// ��ƃR�[�h
        //        this._prtsInventInputCndtn.PartsInventorySecCd = this._stockSecInfoSet.SectionCode.Trim();	// ���_�R�[�h
        //        this._prtsInventInputCndtn.SortingOrder = 0;// �i�ԏ�
        //        this._prtsInventInputCndtn.StckWtoutHyhnPNDiv = 0;	// �i�ԞB�������敪
        //        this._prtsInventInputCndtn.PartsNameDiv = 0;		// ���i���̂����܂������敪
        //        this._prtsInventInputCndtn.PartsKindDivCd = -1;		// ���i�i��敪
        //        this._prtsInventInputCndtn.StockAnalysisDivCd = -1;	// �݌ɕ��͋敪
        //        this._prtsInventInputCndtn.WorkAccessoriesCd = -1;	// ��Ɨp�i�敪
        //        this._prtsInventInputCndtn.InventCountInputDiv = -1; // �I�������͋敪
        //    }
        //}
        #endregion

        #endregion

        #region ControlEvent

        #region Form Load �C�x���g

        /// <summary>
        /// Form.Load �C�x���g (MAZAI05100UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������߂ĕ\������钼�O�ɔ������܂��B</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.01</br>
        /// </remarks>
        private void MAZAI05100UA_Load(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = true;
        }
        
        #endregion

        #region Form Closing �C�x���g

        private void MAZAI05100UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �A�N�e�B�u��Ԃ̃^�u����t�H�[�����擾����
            for (int index = 0; index < this.Main_UTabControl.Tabs.Count; index++)
            {
                Form frm = this.Main_UTabControl.Tabs[index].Tag as System.Windows.Forms.Form;
				if ( ( frm == null ) || (frm.IsDisposed) ) continue;
                frm.Close();
			}		
        }

        #endregion

        #region Initial_Timer_Tick

        /// <summary>
        /// Initial_Timer_Tick�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���Ԃ̊Ԋu���o�߂������ɔ������܂�</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.01</br>
        /// </remarks> 
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;
            try
			{
				this.Cursor = Cursors.AppStarting;

				// ��ʏ����ݒ菈��
				this.ScreenInitialSetting();
                
                // �C�x���g�L�����Z���t���O
                this._eventExecFlg = false;
                
                // �t�H�[���R���g���[���N���X�N���G�C�g����
                this.FormControlInfoCreate();

                // ��������^�u��Key��ݒ�
                string tabCreateKey = string.Empty;
                if ( this._iPara == ctInventoryPrepare )
                {
                    // �I����������
                    tabCreateKey = NO0_INVENTORYPREPARE_TAB;
                }
                else
                {
                    // �ߕs���X�V
                    tabCreateKey = NO1_JUSTENOUGH_TAB;
                }
                
                // �^�u�쐬
                this.TabCreate(tabCreateKey);
                
                // �^�u�A�N�e�B�u������
                // �^�u�ɕ\������t�H�[���N���X�̏����\�z����
                this.TabActive(tabCreateKey);             
                
                // �C�x���g�L�����Z���t���O
                this._eventExecFlg = true;
              
                if(this.Main_UTabControl.SelectedTab != null)
                {
                    // Static�̈�̏�����ʂɕ\������
                    this.Form_Activated((Form)this.Main_UTabControl.SelectedTab.Tag, new EventArgs());
                }
               
			}
			finally
			{
				// �C�x���g�L�����Z���t���O
                this._eventExecFlg = true;

                this.Cursor = Cursors.Default;

                Program._form.Focus();
			}
        }

        #endregion

        #region StatusBar_MsgClear_Timer_Tick

        /// <summary>
        /// StatusBar_MsgClear_Timer_Tick�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ���Ԃ̊Ԋu���o�߂������ɔ������܂�</br>
        /// <br>Programmer : 23010 �����@�m</br>
        /// <br>Date       : 2007.04.03</br>
        /// </remarks> 
        private void StatusBar_MsgClear_Timer_Tick(object sender, EventArgs e)
        {
            StatusBar_MsgClear_Timer.Enabled = false;
			//// 5�b�ҋ@���Ă��珈�������s
			if ( this._isMsgClearCansel )
			{
				this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = string.Empty;
				this._isMsgClearCansel = false;
			}
        }

        #endregion

        #region MDI�q��� Active�C�x���g(Form_Activated)
        /// <summary>
		/// MDI�q��ʂ�Active�C�x���g
		/// </summary>
		private void Form_Activated(object sender, System.EventArgs e)
		{
            
			if (!this._eventExecFlg)
				return;
			Form frm = (Form)sender;
            
			if (frm != null)
				// �q��ʂɑ΂��čĕ\�������s������
				ShowMdiChild();
		}
		#endregion

        #region DEL 2008/08/28 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        #region MDI�q��� Deactived�C�x���g�iForm_Deactivated�j
        /// <summary>
		/// MDI�q��ʂ�Deactived�C�x���g
		/// </summary>
		private void Form_Deactivated(object sender, System.EventArgs e)
		{
		}

        #endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region Main_ToolbarsManager

        /// <summary>
        /// TToolbarsManager.ToolClick �C�x���g(Main_ToolbarsManager)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">ToolClick�C�x���g�Ɏg�p�����C�x���g�p�����[�^</param>
        private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            try
            {
                this.Main_StatusBar.Panels[ctSTATUSBAR_TEXT].Text = string.Empty;	// �X�e�[�^�X�o�[���b�Z�[�W�N���A
                this._isMsgClearCansel = false;	// �X�e�[�^�X�o�[���b�Z�[�W�N���A�L�����Z��
                switch (e.Tool.Key)
                {
                    // �I���{�^��
                    case ctCLOSE_BUTTONTOOLKEY:
                        this.Close();

                        break;
                    // �X�V�{�^��
                    case ctSAVE_BUTTONTOOLKEY:

                        // ���̓`�F�b�N����
                        if (this.InputCheck() != 0)
                            return;

                        // MDI�t�H�[��(�ҏW��ʁj�̓o�^����
                        SaveEditMdiChild();
                        break;
                    // ����{�^��
                    case ctPRINT_BUTTONTOOLKEY:
                        // ���̓`�F�b�N����
                        if (this.InputCheck() != 0)
                            return;

                        // MDI�t�H�[��(�ҏW��ʁj�̓o�^����
                        PrintEditMdiChild();

                        break;
                }
            }
            finally
            {
                this._isMsgClearCansel = true;
            }
        }
        
        #endregion

        #region Main_UTabControl

        /// <summary>
        /// �^�u�I��ؑփC�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_UTabControl_SelectedTabChanged_1(object sender, SelectedTabChangedEventArgs e)
        {
            this.ToolBarButtonEnabledSetting();
        }

        #endregion

        #endregion
    }
}