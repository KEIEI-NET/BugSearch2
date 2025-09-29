using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ���R���[�C���^�t�F�[�X�p�R���X�g��`
	/// </summary>
	public static class FreeSheetConst
	{
		// ���C�����j���[�pConst��`
		/// <summary>�t�@�C��</summary>
		public const string ctPopupMenu_File		= "File_PopupMenuTool";
		/// <summary>�ҏW</summary>
		public const string ctPopupMenu_Edit		= "Edit_PopupMenuTool";
		/// <summary>�\��</summary>
		public const string ctPopupMenu_Display		= "Display_PopupMenuTool";
		/// <summary>�E�B���h�E</summary>
		public const string ctPopupMenu_Window		= "Window_PopupMenuTool";
		/// <summary>�w���v</summary>
		public const string ctPopupMenu_Help		= "Help_PopupMenuTool";
		// �c�[���{�^���pConst��`
		/// <summary>���O�C�����́i�^�C�g���j</summary>
		public const string ctToolBase_LoginTitle	= "LoginTitle_LabelTool";
		/// <summary>���O�C������</summary>
		public const string ctToolBase_LoginName	= "LoginName_LabelTool";
		/// <summary></summary>
		public const string ctToolBase_Dummy		= "Dummy_LabelTool";
		/// <summary>�I��</summary>
		public const string ctToolBase_Exit			= "Exit_ButtonTool";
		/// <summary>�ۑ�</summary>
		public const string ctToolBase_Save			= "Save_ButtonTool";
		/// <summary>�V�K</summary>
		public const string ctToolBase_New			= "New_ButtonTool";
		/// <summary>�J��</summary>
		public const string ctToolBase_Open			= "Open_ButtonTool";
		/// <summary>���</summary>
		public const string ctToolBase_Print		= "Print_ButtonTool";
		// �c�[���o�[�pConst��`
		/// <summary>���C�����j���[</summary>
		public const string ctToolBar_MainMenu		= "MainMenu_UltraToolbar";
		/// <summary>���C���c�[���o�[</summary>
		public const string ctToolBar_Main			= "Main_UltraToolbar";
		// �q��ʋN�����p�t�@�C���p�X
		/// <summary>�q��ʋN�����p�t�@�C���p�X</summary>
		public const string ctFILE_NAVIGATOR		= "SFANL08100U.DAT";
		// �q��ʋN�����p�񖼏�
		/// <summary>�N���p�����[�^</summary>
		public const string COL_STARTARGS			= "StartArgs";
		/// <summary>�A�Z���u��ID</summary>
		public const string COL_ASSEMBLYID			= "AssemblyID";
		/// <summary>�N���X����</summary>
		public const string COL_CLASSNAME			= "ClassName";
		/// <summary>�\���^�C�g������</summary>
		public const string COL_TITLENAME			= "TitleName";
		/// <summary>�q��ʋN���p�����[�^</summary>
		public const string COL_CHILDSTARTARGS		= "ChildStartArgs";
	}

	/// <summary>
	/// �c�[���{�^�����͐���ʒm�C�x���g�n���h��
	/// </summary>
	/// <param name="keys">�c�[���o�[�L�[</param>
	/// <param name="allowing">����t���O</param>
	public delegate void ToolButtonDisplayControlEventHandler(List<string> keys, bool allowing);

	/// <summary>
	/// ���R���[�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�̃��C���t���[���p�C���^�[�t�F�[�X�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.15</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public interface IFreeSheetMainFrame
	{
		/// <summary>�N���[�Y���v���p�e�B</summary>
		/// <value>��ʂ��I�����Ă悢�ꍇ��True�A��肪����ꍇ��False��Ԃ��܂�</value>
		bool CanClose { get; }

		/// <summary>
		/// �c�[���o�[���ݒ菈��
		/// </summary>
		/// <param name="rootToolsCollection">�c�[���R���N�V����</param>
		/// <param name="toolbarsCollection">�c�[���o�[�R���N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		int SetToolBarInfo(ref RootToolsCollection rootToolsCollection, ref ToolbarsCollection toolbarsCollection);

		/// <summary>
		/// �h�b�N���擾����
		/// </summary>
		/// <param name="dockAreaPaneArray">�h�b�N���z��</param>
		/// <returns>�X�e�[�^�X</returns>
		int GetDockAreaInfo(out DockAreaPane[] dockAreaPaneArray);

		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g�i���C���t���[���j
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		void FrameToolbars_ToolClick(object sender, ToolClickEventArgs e);

		/// <summary>
		/// �c�[���{�^�����͐���ʒm�C�x���g
		/// </summary>
		event ToolButtonDisplayControlEventHandler ToolButtonEnableChanged;

		/// <summary>
		/// �c�[���{�^���\������ʒm�C�x���g
		/// </summary>
		event ToolButtonDisplayControlEventHandler ToolButtonVisibleChanged;
	}

	/// <summary>
	/// ���R���[�N���L�����Z����O
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�̃��C���t���[���N�����L�����Z������ׂ̗�O�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.15</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public class FreeSheetStartCancelException : Exception
	{
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="message">��O���b�Z�[�W</param>
		public FreeSheetStartCancelException(string message)
			: base(message)
		{
		}
	}
}
