using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// �c�[���o�[�}�l�[�W���[�J�X�^�}�C�Y�ݒ�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �c�[���}�l�[�W���[�̃J�X�^�}�C�Y�ݒ���Ǘ�����N���X�ł��B</br>
	/// <br>Programmer : 21024 ���X�� ��</br>
	/// <br>Date       : 2008.05.22</br>
	/// <br></br>
	/// </remarks>
	public class ToolbarManagerCustomizeSettingAcs
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region ��Private Members

		private static readonly string ct_CommonFileName = "ToolButtonCustomize";

		#endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region ��Constructor

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public ToolbarManagerCustomizeSettingAcs()
		{
		}

		#endregion

		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		#region ��Private Methods

		/// <summary>
		/// �c�[���}�l�[�W���[�̃J�X�^�}�C�Y�����f�V���A���C�Y���܂��B
		/// </summary>
		/// <param name="saveFileName">�ۑ��t�@�C����</param>
		/// <returns>ToolManagerCustomizeSetting�I�u�W�F�N�g</returns>
		private static ToolManagerCustomizeSetting Deserialize( string saveFileName )
		{
			if (string.IsNullOrEmpty(saveFileName)) return null;

			string fileName = string.Format("{0}_{1}.xml", ToolbarManagerCustomizeSettingAcs.ct_CommonFileName, saveFileName);
			try
			{
				if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName)))
				{
					return UserSettingController.ByteDeserializeUserSetting<ToolManagerCustomizeSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
				}
			}
			catch (System.InvalidOperationException)
			{
				UserSettingController.DeleteUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
			}
			return null;
		}

		/// <summary>
		/// �c�[���}�l�[�W���[�̃J�X�^�}�C�Y�����V���A���C�Y���܂��B
		/// </summary>
		/// <param name="saveFileName">�ۑ��t�@�C����</param>
		/// <param name="toolManagerCustomizeSetting">ToolManagerCustomizeSetting�I�u�W�F�N�g</param>
		private static void Serialize( string saveFileName, ToolManagerCustomizeSetting toolManagerCustomizeSetting )
		{
			if (string.IsNullOrEmpty(saveFileName)) return;

			string fileName = string.Format("{0}_{1}.xml", ct_CommonFileName, saveFileName);

            UserSettingController.ByteSerializeUserSetting(toolManagerCustomizeSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, fileName));
		}

		/// <summary>
		/// �c�[���o�[�̃J�X�^�}�C�Y����ݒ肵�܂��B
		/// </summary>
		/// <param name="toolMenuCustomizeSetting">ToolMenuCustomizeSetting�I�u�W�F�N�g</param>
		/// <param name="toolBar">UltraToolbar�I�u�W�F�N�g</param>
		private static void ToolbarCustomizeSetting( ToolMenuCustomizeSetting toolMenuCustomizeSetting, ref Infragistics.Win.UltraWinToolbars.UltraToolbar toolBar )
		{
            toolBar.Visible = toolMenuCustomizeSetting.ToolBarVisible;
            toolBar.DockedRow = toolMenuCustomizeSetting.DockedRow;
            toolBar.DockedColumn = toolMenuCustomizeSetting.DockedColumn;
            toolBar.DockedPosition = (Infragistics.Win.UltraWinToolbars.DockedPosition)toolMenuCustomizeSetting.DockedPosition;
                
            for (int index = 0; index < toolBar.Tools.Count; index++)
            {
                ToolButtonCustomizeSetting toolButtonCustomizeSetting = toolMenuCustomizeSetting.GetToolButtonCustomizeSetting(toolBar.Tools[index].Key);

                if (toolButtonCustomizeSetting != null)
                {
                    toolBar.Tools[index].CustomizedVisible = toolButtonCustomizeSetting.ToolButtonCustomizeInfo.CustomizedVisible;
                }
            }
		}

		/// <summary>
		/// �c�[���o�[�̃J�X�^�}�C�Y�ݒ���擾���܂��B
		/// </summary>
		/// <param name="toolBar">UltraToolbar�I�u�W�F�N�g</param>
		/// <returns></returns>
		private static ToolMenuCustomizeSetting GetToolbarCustomizeSetting( Infragistics.Win.UltraWinToolbars.UltraToolbar toolBar )
		{
			ToolMenuCustomizeSetting toolButtonCustomizeSettings = new ToolMenuCustomizeSetting();
			toolButtonCustomizeSettings.ToolBarKey= toolBar.Key;
            toolButtonCustomizeSettings.ToolBarVisible = toolBar.Visible;
            toolButtonCustomizeSettings.DockedRow = toolBar.DockedRow;
            toolButtonCustomizeSettings.DockedColumn = toolBar.DockedColumn;
            toolButtonCustomizeSettings.DockedPosition = (int)toolBar.DockedPosition;

			for (int index = 0; index < toolBar.Tools.Count; index++)
			{
				string key = toolBar.Tools[index].Key;
				Infragistics.Win.DefaultableBoolean defaultboolean = toolBar.Tools[key].CustomizedVisible;
				toolButtonCustomizeSettings.ToolButtonCustomizeSettingsList.Add(new ToolButtonCustomizeSetting(key, new ToolButtonCustomizeInfo(defaultboolean)));
			}

			return toolButtonCustomizeSettings;
		}


		#endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		#region ��Public Methods

		/// <summary>
		/// �c�[���o�[�}�l�[�W���[�̃J�X�^�}�C�Y�������[�h���܂��B
		/// </summary>
		/// <param name="saveFileName">�ۑ��t�@�C����</param>
        /// <param name="ultraToolbarsManager">UltraToolbarsManager�I�u�W�F�N�g</param>
		public static void LoadToolManagerCustomizeInfo( string saveFileName, ref Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager )
		{
			ToolManagerCustomizeSetting toolManagerCustomizeSetting = ToolbarManagerCustomizeSettingAcs.Deserialize(saveFileName);
			if (toolManagerCustomizeSetting == null)
			{
				return;
			}

			for (int index = 0; index < ultraToolbarsManager.Toolbars.Count; index++)
			{
				ToolMenuCustomizeSetting toolMenuCustomizeSetting = toolManagerCustomizeSetting.GetMenueToolButtonCustomizeSettings(ultraToolbarsManager.Toolbars[index].Key);
				if (toolMenuCustomizeSetting != null)
				{
					Infragistics.Win.UltraWinToolbars.UltraToolbar toolbar = ultraToolbarsManager.Toolbars[index];
					ToolbarManagerCustomizeSettingAcs.ToolbarCustomizeSetting(toolMenuCustomizeSetting, ref toolbar);
				}
			}

		}

		/// <summary>
		/// �c�[���o�[�}�l�[�W���[�̃J�X�^�}�C�Y�������[�h���܂��B
		/// </summary>
		/// <param name="saveFileName">�ۑ��t�@�C����</param>
		/// <param name="tToolbarsManatger">TToolbarsManager�I�u�W�F�N�g</param>
		public static void LoadToolManagerCustomizeInfo( string saveFileName, ref TToolbarsManager tToolbarsManatger )
		{
			ToolManagerCustomizeSetting toolManagerCustomizeSetting = ToolbarManagerCustomizeSettingAcs.Deserialize(saveFileName);
			if (toolManagerCustomizeSetting == null)
			{
				return;
			}

			for (int index = 0; index < tToolbarsManatger.Toolbars.Count; index++)
			{
				ToolMenuCustomizeSetting toolMenuCustomizeSetting = toolManagerCustomizeSetting.GetMenueToolButtonCustomizeSettings(tToolbarsManatger.Toolbars[index].Key);
				if (toolMenuCustomizeSetting != null)
				{
					Infragistics.Win.UltraWinToolbars.UltraToolbar toolbar = tToolbarsManatger.Toolbars[index];
					ToolbarManagerCustomizeSettingAcs.ToolbarCustomizeSetting(toolMenuCustomizeSetting, ref toolbar);
				}
			}
		}

		/// <summary>
		/// �c�[���o�[�}�l�[�W���[�̃J�X�^�}�C�Y����ۑ����܂��B
		/// </summary>
		/// <param name="saveFileName">�ۑ��t�@�C����</param>
		/// <param name="ultraToolbarsManager">UltraToolbarsManager�I�u�W�F�N�g</param>
		public static void SaveToolManagerCustomizeInfo( string saveFileName, Infragistics.Win.UltraWinToolbars.UltraToolbarsManager ultraToolbarsManager )
		{
			ToolManagerCustomizeSetting toolManagerCustomizeSetting = new ToolManagerCustomizeSetting();

			for (int index = 0; index < ultraToolbarsManager.Toolbars.Count; index++)
			{
				Infragistics.Win.UltraWinToolbars.UltraToolbar toolbar = ultraToolbarsManager.Toolbars[index];
				toolManagerCustomizeSetting.ToolMenuCustomizeSettingList.Add(GetToolbarCustomizeSetting(toolbar));
			}

			ToolbarManagerCustomizeSettingAcs.Serialize(saveFileName, toolManagerCustomizeSetting);
		}
		
		/// <summary>
		/// �c�[���o�[�}�l�[�W���[�̃J�X�^�}�C�Y����ۑ����܂��B
		/// </summary>
		/// <param name="saveFileName">�ۑ��t�@�C����</param>
		/// <param name="tToolbarsManatger">TToolbarsManager�I�u�W�F�N�g</param>
		public static void SaveToolManagerCustomizeInfo( string saveFileName, TToolbarsManager tToolbarsManatger )
		{
			ToolManagerCustomizeSetting toolManagerCustomizeSetting = new ToolManagerCustomizeSetting();

			for (int index = 0; index < tToolbarsManatger.Toolbars.Count; index++)
			{
				Infragistics.Win.UltraWinToolbars.UltraToolbar toolbar = tToolbarsManatger.Toolbars[index];
				toolManagerCustomizeSetting.ToolMenuCustomizeSettingList.Add(GetToolbarCustomizeSetting(toolbar));
			}

			ToolbarManagerCustomizeSettingAcs.Serialize(saveFileName, toolManagerCustomizeSetting);
		}

		#endregion
	}

	/// <summary>
	/// �c�[���}�l�[�W���[�J�X�^�}�C�Y�ݒ�N���X
	/// </summary>
	[Serializable]
	public class ToolManagerCustomizeSetting
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region ��Private Members

		private List<ToolMenuCustomizeSetting> _toolMenuCustomizeSettingList;

		#endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region ��Constructor

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public ToolManagerCustomizeSetting()
		{
			this._toolMenuCustomizeSettingList = new List<ToolMenuCustomizeSetting>();
		}

		#endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		#region ��Properties

		/// <summary>�c�[�����j���[�J�X�^�}�C�Y�ݒ胊�X�g</summary>
		public List<ToolMenuCustomizeSetting> ToolMenuCustomizeSettingList
		{
			get { return _toolMenuCustomizeSettingList; }
			set { _toolMenuCustomizeSettingList = value; }
		}

		#endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		#region ��Public Methods

		/// <summary>
		/// �c�[�����j���[�J�X�^�}�C�Y�ݒ���擾���܂��B
		/// </summary>
		/// <param name="keyName"></param>
		/// <returns></returns>
		public ToolMenuCustomizeSetting GetMenueToolButtonCustomizeSettings( string keyName )
		{
			foreach (ToolMenuCustomizeSetting toolButtonCustomizeSettings in _toolMenuCustomizeSettingList)
			{
				if (toolButtonCustomizeSettings.ToolBarKey == keyName)
				{
					return toolButtonCustomizeSettings;
				}
			}
			return null;
		}

		#endregion
	}

	/// <summary>
	/// �c�[�����j���[�J�X�^�}�C�Y�ݒ�N���X
	/// </summary>
	[Serializable]
	public class ToolMenuCustomizeSetting
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region ��Private Members

		private List<ToolButtonCustomizeSetting> _toolButtonCustomizeSettingList;
		private string _toolBarKey;
        private bool _toolBarVisible;
        private int _dockedRow;
        private int _dockedColumn;
        private int _dockedPosition;

		#endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region ��Constructor
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public ToolMenuCustomizeSetting()
		{
			this._toolBarKey = "";
            this._toolBarVisible = true;
            this._dockedColumn = 0;
            this._dockedRow = 0;
			this._toolButtonCustomizeSettingList = new List<ToolButtonCustomizeSetting>();
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="toolBarKey">�c�[���o�[�̃L�[</param>
        /// <param name="toolbarVisible">�c�[���o�[�̕\���L��</param>
		/// <param name="toolButtonCustomizeSettingList">�c�[���o�[�̃c�[���{�^���J�X�^�}�C�Y�ݒ胊�X�g</param>
        public ToolMenuCustomizeSetting(string toolBarKey, bool toolbarVisible, List<ToolButtonCustomizeSetting> toolButtonCustomizeSettingList)
		{
			this._toolBarKey = toolBarKey;
            this._toolBarVisible = toolbarVisible;
			this._toolButtonCustomizeSettingList = toolButtonCustomizeSettingList;
		}
		#endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		#region ��Properties

		/// <summary>�c�[���o�[�̃L�[</summary>
		public string ToolBarKey
		{
			get { return _toolBarKey; }
			set { _toolBarKey = value; }
		}

        /// <summary>�c�[���o�[�̕\���L��</summary>
        public bool ToolBarVisible
        {
            get { return _toolBarVisible; }
            set { _toolBarVisible = value; }
        }

		/// <summary>�c�[���o�[�̃c�[���{�^���J�X�^�}�C�Y�ݒ胊�X�g</summary>
		public List<ToolButtonCustomizeSetting> ToolButtonCustomizeSettingsList
		{
			get { return _toolButtonCustomizeSettingList; }
			set { _toolButtonCustomizeSettingList = value; }
		}

        /// <summary></summary>
        public int DockedRow
        {
            get { return _dockedRow; }
            set { _dockedRow = value; }
        }

        /// <summary></summary>
        public int DockedColumn
        {
            get { return _dockedColumn; }
            set { _dockedColumn = value; }
        }

        /// <summary></summary>
        public int DockedPosition
        {
            get { return _dockedPosition; }
            set { _dockedPosition = value; }
        }

		#endregion

		// ===================================================================================== //
		// �p�u���b�N���\�b�h
		// ===================================================================================== //
		#region ��Public Methods

		/// <summary>
		/// �c�[���{�^���J�X�^�}�C�Y�ݒ���擾���܂��B
		/// </summary>
		/// <param name="buttonKey">�擾����c�[���{�^���̃L�[</param>
		/// <returns>�c�[���{�^���J�X�^�}�C�Y�ݒ�I�u�W�F�N�g</returns>
		public ToolButtonCustomizeSetting GetToolButtonCustomizeSetting( string buttonKey )
		{
			foreach (ToolButtonCustomizeSetting toolButtonCustomizeSetting in this._toolButtonCustomizeSettingList)
			{
				if (toolButtonCustomizeSetting.ButtonKey == buttonKey)
				{
					return toolButtonCustomizeSetting;
				}
			}

			return null;
		}
		#endregion
	}

	/// <summary>
	/// �c�[���{�^���J�X�^�}�C�Y�ݒ�N���X
	/// </summary>
	[Serializable]
	public class ToolButtonCustomizeSetting
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region ��Private Members

		private string _buttonKey;
		private ToolButtonCustomizeInfo _toolButtonCustomizeInfo;

		#endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region ��Constructor

		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public ToolButtonCustomizeSetting()
		{
			this._toolButtonCustomizeInfo = new ToolButtonCustomizeInfo();
			this._buttonKey = "";
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="buttonKey">�c�[���{�^���L�[</param>
		/// <param name="toolButtonCustomizeInfo">�c�[���{�^���J�X�^�}�C�Y�ݒ���I�u�W�F�N�g</param>
		public ToolButtonCustomizeSetting( string buttonKey, ToolButtonCustomizeInfo toolButtonCustomizeInfo )
		{
			this._toolButtonCustomizeInfo = toolButtonCustomizeInfo;
			this._buttonKey = buttonKey;
		}
		#endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		#region ��Properties
		/// <summary>�c�[���{�^���̃L�[</summary>
		public string ButtonKey
		{
			get { return _buttonKey; }
			set { _buttonKey = value; }
		}

		/// <summary>�c�[���{�^���J�X�^�}�C�Y�ݒ���</summary>
		public ToolButtonCustomizeInfo ToolButtonCustomizeInfo
		{
			get { return _toolButtonCustomizeInfo; }
			set { _toolButtonCustomizeInfo = value; }
		}
		#endregion
	}

	/// <summary>
	/// �c�[���{�^���J�X�^�}�C�Y�ݒ���N���X
	/// </summary>
	[Serializable]
	public class ToolButtonCustomizeInfo
	{
		// ===================================================================================== //
		// �v���C�x�[�g�ϐ�
		// ===================================================================================== //
		#region ��Private Members

		private Infragistics.Win.DefaultableBoolean _customizedVisible;

		#endregion

		// ===================================================================================== //
		// �R���X�g���N�^
		// ===================================================================================== //
		#region ��Constructors
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public ToolButtonCustomizeInfo()
		{
			this._customizedVisible = Infragistics.Win.DefaultableBoolean.Default;
		}

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="customizedVisible">CustomizedVisible�v���p�e�B�l</param>
		public ToolButtonCustomizeInfo( Infragistics.Win.DefaultableBoolean customizedVisible )
		{
			this._customizedVisible = customizedVisible;
		}
		#endregion

		// ===================================================================================== //
		// �v���p�e�B
		// ===================================================================================== //
		#region ��Properties

		/// <summary>CustomizedVisible</summary>
		public Infragistics.Win.DefaultableBoolean CustomizedVisible
		{
			get { return _customizedVisible; }
			set { _customizedVisible = value; }
		}

		#endregion
	}
}
