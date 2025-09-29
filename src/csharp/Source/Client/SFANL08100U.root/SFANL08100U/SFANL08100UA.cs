using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���R���[���C���t���[��
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�p�̃��C���t���[���ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.15</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public partial class SFANL08100UA : Form
	{
		#region PrivateMember
		// �N���t�H�[��
		private Form		_bindForm;
		// �N������
		private string[]	_args;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="args">�p�����[�^����</param>
		public SFANL08100UA(string[] args)
		{
			InitializeComponent();

			_args = args;

			SetIconImageToToolbar();

			this.tToolbarsManager.ToolClick += new ToolClickEventHandler(tToolbarsManager_ToolClick);

			this.tToolbarsManager.Visible = false;
			this.ultraDockManager.Visible = false;
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// �A�C�R���摜�ݒ菈���i�c�[���o�[�p�j
		/// </summary>
		/// <remarks>
		/// <br>Note		: �c�[���o�[�̃A�C�R���ݒ���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SetIconImageToToolbar()
		{
			// �C���[�W���X�g��ݒ肷��
			this.tToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
			// �V�K�̃A�C�R���ݒ�
			ButtonTool newButton = (ButtonTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_New];
			if (newButton != null) newButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
			// �ۑ��̃A�C�R���ݒ�
			ButtonTool saveButton = (ButtonTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_Save];
			if (saveButton != null) saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			// �J���̃A�C�R���ݒ�
			ButtonTool openButton = (ButtonTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_Open];
			if (openButton != null) openButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.FOLDER;
			// ����̃A�C�R���ݒ�
			ButtonTool printButton = (ButtonTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_Print];
			if (printButton != null) printButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.PRINT;
			// �I���̃A�C�R���ݒ�
			ButtonTool exitButton = (ButtonTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_Exit];
			if (exitButton != null) exitButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			// ���O�C���S���҂̃A�C�R���ݒ�
			LabelTool loginTitleLabel = (LabelTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_LoginTitle];
			if (loginTitleLabel != null) loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			// ���O�C���S�����̐ݒ�
			LabelTool loginNameLabel = (LabelTool)this.tToolbarsManager.Tools[FreeSheetConst.ctToolBase_LoginName];
			if ((LoginInfoAcquisition.Employee != null) &&
				(loginNameLabel != null))
			{
				loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
			}
		}

		/// <summary>
		/// ���C���t�H�[���쐬����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �N�������ɉ����ă��C���t�H�[�����쐬���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void CreateMainForm()
		{
			string classID		= string.Empty;
			string assmPath		= string.Empty;
			string title		= string.Empty;
			string[] startArg	= new string[0];

			// �q��ʂ̋N�������擾
			DataTable dt;
			if (LoadNavigator(out dt) == 0)
			{
				if (_args.Length > 0)
				{
					string filter = FreeSheetConst.COL_STARTARGS + "='" + _args[0] + "'";
					DataRow[] drArray = dt.Select(filter);
					if (drArray.Length > 0)
					{
						DataRow dr = drArray[0];
						assmPath	= dr[FreeSheetConst.COL_ASSEMBLYID].ToString();
						classID		= dr[FreeSheetConst.COL_CLASSNAME].ToString();
						title		= dr[FreeSheetConst.COL_TITLENAME].ToString();

						if (!dr[FreeSheetConst.COL_CHILDSTARTARGS].Equals(DBNull.Value) &&
							!dr[FreeSheetConst.COL_CHILDSTARTARGS].Equals(string.Empty))
							startArg = dr[FreeSheetConst.COL_CHILDSTARTARGS].ToString().Split(' ');
					}
				}
			}

			// �t�@�C�������݂��Ȃ��ꍇ�͏������Ȃ�
			if (!File.Exists(assmPath)) return;

			SFCMN00299CA waitForm = new SFCMN00299CA();
			waitForm.DispCancelButton	= false;
			waitForm.Title				= "��ʋN����";
			waitForm.Message			= title + "�̋N�����ł��D�D�D";
			waitForm.Show();
			try
			{
				Assembly assm = Assembly.LoadFrom(assmPath);
				Type type = assm.GetType(classID);

				if (startArg.Length > 0)
					_bindForm = Activator.CreateInstance(type, startArg) as Form;
				else
					_bindForm = Activator.CreateInstance(type) as Form;
				if (_bindForm is IFreeSheetMainFrame)
				{
					_bindForm.TopLevel			= false;
					_bindForm.FormBorderStyle	= FormBorderStyle.None;
					this.Text					= title;
					_bindForm.Dock				= DockStyle.Fill;
					this.Controls.Add(_bindForm);

					IFreeSheetMainFrame iFreeSheet = (IFreeSheetMainFrame)_bindForm;

					SetToolbars(iFreeSheet);

					SetDockManager(iFreeSheet);
				}
				else
				{
					throw new Exception("IFreeSheetMainFrame���p�����Ă��܂���B");
				}
			}
			finally
			{
				waitForm.Close();
			}
		}

		/// <summary>
		/// �c�[���o�[�ݒ菈��
		/// </summary>
		/// <param name="iFreeSheet">���R���[�C���^�[�t�F�[�X</param>
		/// <remarks>
		/// <br>Note		: �c�[���o�[�̒ǉ��y�ъe��ݒ���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SetToolbars(IFreeSheetMainFrame iFreeSheet)
		{
			RootToolsCollection rootToolsCollection = this.tToolbarsManager.Tools;
			ToolbarsCollection toolbarsCollection = this.tToolbarsManager.Toolbars;
			iFreeSheet.SetToolBarInfo(ref rootToolsCollection, ref toolbarsCollection);

			// �c�[���N���b�N�C�x���g���f���Q�[�g�ɓo�^
			this.tToolbarsManager.ToolClick += new ToolClickEventHandler(iFreeSheet.FrameToolbars_ToolClick);

			// �q��ʂ���̃c�[���{�^���̓��͐���ʒm
			iFreeSheet.ToolButtonEnableChanged += new ToolButtonDisplayControlEventHandler(iFreeSheet_ToolButtonEnableChanged);

			// �q��ʂ���̃c�[���{�^���̕\������ʒm
			iFreeSheet.ToolButtonVisibleChanged += new ToolButtonDisplayControlEventHandler(iFreeSheet_ToolButtonVisibleChanged);
		}

		/// <summary>
		/// �h�b�N�}�l�[�W���[�ݒ菈��
		/// </summary>
		/// <param name="iFreeSheet">���R���[�C���^�[�t�F�[�X</param>
		/// <remarks>
		/// <br>Note		: �h�b�N�}�l�[�W���[���̐ݒ���s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SetDockManager(IFreeSheetMainFrame iFreeSheet)
		{
			DockAreaPane[] dockAreaPaneArray;
			int status = iFreeSheet.GetDockAreaInfo(out dockAreaPaneArray);

			if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			{
				foreach (DockAreaPane dockAreaPane in dockAreaPaneArray)
					this.ultraDockManager.DockAreas.Add(dockAreaPane);
			}
		}

		/// <summary>
		/// �i�r�Q�[�^�[�Ǎ�����
		/// </summary>
		/// <param name="dt">�i�r�Q�[�^�[���</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �N���i�r�Q�[�^�[���̓Ǎ����s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private int LoadNavigator(out DataTable dt)
		{
			dt = null;

			using (FileStream fileStream = new FileStream(FreeSheetConst.ctFILE_NAVIGATOR, FileMode.Open, FileAccess.Read))
			{
				try
				{
					if (fileStream.Length > 0)
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						DataSet ds = (DataSet)binaryFormatter.Deserialize(fileStream);
						dt = ds.Tables[0];
					}
				}
				finally
				{
					fileStream.Close();
				}
			}

			return 0;
		}
		#endregion

		#region Event
		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void tToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case FreeSheetConst.ctToolBase_Exit:
				{
					this.Close();
					break;
				}
			}
		}

		/// <summary>
		/// �c�[���{�^�����͐���ʒm�C�x���g
		/// </summary>
		/// <param name="keys">�Ώۃc�[���{�^���̃L�[</param>
		/// <param name="allowing">������</param>
		/// <remarks>
		/// <br>Note		: �c�[���{�^���̓��͐���̕ύX��ʒm���ꂽ���ɁB</br>
		/// <br>			: �������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void iFreeSheet_ToolButtonEnableChanged(List<string> keys, bool allowing)
		{
			foreach (string key in keys)
				this.tToolbarsManager.Tools[key].SharedProps.Enabled = allowing;
		}

		/// <summary>
		/// �c�[���{�^���\������ʒm�C�x���g
		/// </summary>
		/// <param name="keys">�Ώۃc�[���{�^���̃L�[</param>
		/// <param name="allowing">������</param>
		/// <remarks>
		/// <br>Note		: �c�[���{�^���̓��͐���̕ύX��ʒm���ꂽ���ɁB</br>
		/// <br>			: �������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void iFreeSheet_ToolButtonVisibleChanged(List<string> keys, bool allowing)
		{
			foreach (string key in keys)
				this.tToolbarsManager.Tools[key].SharedProps.Visible = allowing;
		}

		/// <summary>
		/// FormClosing�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[������邽�тɁA�t�H�[����������O�A</br>
		/// <br>			: ����ѕ��闝�R���w�肷��O�ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SFANL08100UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			// �N���[�Y���t���O
			bool canClose = true;

			if (e.CloseReason == CloseReason.UserClosing)
			{
				// �C���^�t�F�[�X���N���[�Y���t���O���擾
				if (_bindForm is IFreeSheetMainFrame)
					canClose = ((IFreeSheetMainFrame)_bindForm).CanClose;
			}

			if (!canClose)
				e.Cancel = true;
		}

		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SFANL08100UA_Load(object sender, EventArgs e)
		{
			try
			{
				CreateMainForm();

				this.FormClosing += new FormClosingEventHandler(SFANL08100UA_FormClosing);
			}
			catch (Exception ex)
			{
				string message = "�q��ʂ̍쐬�Ɏ��s���܂����B" + Environment.NewLine + ex.Message;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, this.Text
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_INIT
					, message
					, -1
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
				this.Close();
			}
		}

		/// <summary>
		/// �t�H�[��Shown�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����ŏ��ɕ\�����ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SFANL08100UA_Shown(object sender, EventArgs e)
		{
			try
			{
				// �c�[���o�[���̕`����y������׃C�x���g��؂�
				this.tToolbarsManager.EventManager.AllEventsEnabled = false;
				this.ultraDockManager.EventManager.AllEventsEnabled = false;

				this.tToolbarsManager.Visible = true;
				this.ultraDockManager.Visible = true;
				_bindForm.Show();

				// �C�x���g����
				this.tToolbarsManager.EventManager.AllEventsEnabled = true;
				this.ultraDockManager.EventManager.AllEventsEnabled = true;
			}
			catch (FreeSheetStartCancelException ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION
					, this.ToString()
					, ex.Message
					, 0
					, MessageBoxButtons.OK);
				this.Close();
			}
			catch (Exception ex)
			{
				string message = "�q��ʂ̏����\�����ɗ�O���������܂����B" + Environment.NewLine + ex.Message;
				TMsgDisp.Show(this
					, emErrorLevel.ERR_LEVEL_STOPDISP
					, this.ToString()
					, this.Text
					, ex.TargetSite.ToString()
					, TMsgDisp.OPE_INIT
					, message
					, -1
					, null
					, MessageBoxButtons.OK
					, MessageBoxDefaultButton.Button1);
				this.Close();
			}
		}
		#endregion
	}
}