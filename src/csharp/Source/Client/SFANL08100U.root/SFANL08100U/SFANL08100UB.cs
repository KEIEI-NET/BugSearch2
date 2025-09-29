using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;

using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;

using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���R���[�N���i�r�Q�[�^�[�쐬���
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�p�̃��C���t���[���p�i�r�Q�[�^�[��</br>
	/// <br>			: �쐬��ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.03.15</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public partial class SFANL08100UB : Form, IFreeSheetMainFrame
	{
		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08100UB()
		{
			InitializeComponent();
		}
		#endregion

		#region SFANL00001IA �����o
		/// <summary>�N���[�Y���v���p�e�B</summary>
		/// <value>��ʂ��I�����Ă悢�ꍇ��True�A��肪����ꍇ��False��Ԃ��܂�</value>
		public bool CanClose
		{
			get { return true; }
		}

		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g�i���C���t���[���j
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		public void FrameToolbars_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case FreeSheetConst.ctToolBase_Open:
				{
					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.Title	= "�i�r�Q�[�^�[�����J��";
					openFileDialog.Filter	= "DAT�t�@�C��|*.dat";
					openFileDialog.RestoreDirectory = true;
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						LoadProc(openFileDialog.FileName);
					}
					break;
				}
				case FreeSheetConst.ctToolBase_Save:
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.Title	= "�i�r�Q�[�^�[����ۑ�";
					saveFileDialog.Filter	= "DAT�t�@�C��|*.dat";
					saveFileDialog.RestoreDirectory = true;
					saveFileDialog.FileName	= FreeSheetConst.ctFILE_NAVIGATOR;
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						if (SaveProc(saveFileDialog.FileName) == 0)
							MessageBox.Show("�ۑ����܂���");
					}
					break;
				}
			}
		}

		/// <summary>
		/// �h�b�N���擾����
		/// </summary>
		/// <param name="dockAreaPaneArray">�h�b�N���R���N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		public int GetDockAreaInfo(out DockAreaPane[] dockAreaPaneArray)
		{
			dockAreaPaneArray = null;
			return 4;
		}

		/// <summary>
		/// �c�[���o�[���擾����
		/// </summary>
		/// <param name="rootToolsCollection">�c�[���R���N�V����</param>
		/// <param name="toolbarsCollection">�c�[���o�[�R���N�V����</param>
		/// <returns>�X�e�[�^�X</returns>
		public int SetToolBarInfo(ref RootToolsCollection rootToolsCollection, ref ToolbarsCollection toolbarsCollection)
		{
			return 4;
		}

		/// <summary>��\���c�[���{�^�����v���p�e�B</summary>
		/// <value>�����񋟕��̃c�[���{�^���̓��A��\���ɂ������c�[���{�^���̃L�[���</value>
		/// <remarks>FreeSheetConst���g�p���܂��B</remarks>
		public string[] HideToolButton
		{
			get
			{
				return new string[] {
					FreeSheetConst.ctToolBase_New,
					FreeSheetConst.ctToolBase_Print,
					FreeSheetConst.ctPopupMenu_Edit,
					FreeSheetConst.ctPopupMenu_Window,
					FreeSheetConst.ctPopupMenu_Display,
					FreeSheetConst.ctPopupMenu_Help
				};
			}
		}

		/// <summary>
		/// �c�[���{�^�����͐���ʒm�C�x���g
		/// </summary>
		public event ToolButtonDisplayControlEventHandler ToolButtonEnableChanged;

		/// <summary>
		/// �c�[���{�^���\������ʒm�C�x���g
		/// </summary>
		public event ToolButtonDisplayControlEventHandler ToolButtonVisibleChanged;
		#endregion

		#region PrivateMethod
		/// <summary>
		/// �i�r�Q�[�^���Ǎ�����
		/// </summary>
		/// <param name="filePath">�t�@�C���p�X</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note		: �i�r�Q�[�^�[���̕ۑ����s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private int LoadProc(string filePath)
		{
			Bind_DataSet.Tables[0].Rows.Clear();

			using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
			{
				try
				{
					if (fileStream.Length > 0)
					{
						BinaryFormatter binaryFormatter = new BinaryFormatter();
						DataSet ds = (DataSet)binaryFormatter.Deserialize(fileStream);
						foreach (DataRow dr in ds.Tables[0].Rows)
							this.Bind_DataSet.Tables[0].Rows.Add(dr.ItemArray);
					}
				}
				catch (Exception)
				{
					MessageBox.Show("�i�r�Q�[�^�[���̓Ǎ��Ɏ��s���܂����B" + Environment.NewLine + "�w��t�@�C�������R���[�p�̃i�r�Q�[�^�[�t�@�C�����m�F���Ă��������B");
				}
				finally
				{
					fileStream.Close();
				}
			}

			return 0;
		}

		/// <summary>
		/// �ۑ�����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �i�r�Q�[�^�[���̕ۑ����s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private int SaveProc(string filePath)
		{
			int status = 0;

			try
			{
				if (InputCheck())
				{
					using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
					{
						try
						{
							BinaryFormatter binaryFormatter = new BinaryFormatter();
							binaryFormatter.Serialize(fileStream, this.Bind_DataSet);
						}
						finally
						{
							fileStream.Close();
						}
					}
				}
				else
				{
					status = -1;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("�ۑ������ɂė�O���������܂����B" + Environment.NewLine + ex.Message);
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �f�[�^�ۑ��O�̃`�F�b�N�����ł��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private bool InputCheck()
		{
			this.dataGridView.EndEdit();

			foreach (DataGridViewRow dr in this.dataGridView.Rows)
			{
				if (dr.IsNewRow)
					continue;

				// null�̏ꍇ�͋󕶎��ɕϊ�
				if (dr.Cells[FreeSheetConst.COL_STARTARGS].Value == DBNull.Value)
					dr.Cells[FreeSheetConst.COL_STARTARGS].Value = string.Empty;
				if (dr.Cells[FreeSheetConst.COL_ASSEMBLYID].Value == DBNull.Value)
					dr.Cells[FreeSheetConst.COL_ASSEMBLYID].Value = string.Empty;
				if (dr.Cells[FreeSheetConst.COL_CLASSNAME].Value == DBNull.Value)
					dr.Cells[FreeSheetConst.COL_CLASSNAME].Value = string.Empty;
				if (dr.Cells[FreeSheetConst.COL_TITLENAME].Value == DBNull.Value)
					dr.Cells[FreeSheetConst.COL_TITLENAME].Value = string.Empty;
				if (dr.Cells[FreeSheetConst.COL_CHILDSTARTARGS].Value == DBNull.Value)
					dr.Cells[FreeSheetConst.COL_CHILDSTARTARGS].Value = string.Empty;

				// �f�[�^���ݒ�̍s�͍폜
				if (dr.Cells[FreeSheetConst.COL_STARTARGS].Value.Equals(string.Empty) &&
					dr.Cells[FreeSheetConst.COL_ASSEMBLYID].Value.Equals(string.Empty) &&
					dr.Cells[FreeSheetConst.COL_CLASSNAME].Value.Equals(string.Empty) &&
					dr.Cells[FreeSheetConst.COL_TITLENAME].Value.Equals(string.Empty) &&
					dr.Cells[FreeSheetConst.COL_CHILDSTARTARGS].Value.Equals(string.Empty))
				{
					this.dataGridView.Rows.Remove(dr);
					continue;
				}

				// �ȉ����̓`�F�b�N
				if (dr.Cells[FreeSheetConst.COL_STARTARGS].Value.Equals(string.Empty))
				{
					MessageBox.Show("���������͂���Ă��܂���B");
					this.dataGridView.CurrentCell = dr.Cells[FreeSheetConst.COL_STARTARGS];
					return false;
				}

				if (dr.Cells[FreeSheetConst.COL_ASSEMBLYID].Value.Equals(string.Empty))
				{
					MessageBox.Show("�A�Z���u��ID�����͂���Ă��܂���B");
					this.dataGridView.CurrentCell = dr.Cells[FreeSheetConst.COL_ASSEMBLYID];
					return false;
				}

				if (dr.Cells[FreeSheetConst.COL_CLASSNAME].Value.Equals(string.Empty))
				{
					MessageBox.Show("�N���X�������͂���Ă��܂���B");
					this.dataGridView.CurrentCell = dr.Cells[FreeSheetConst.COL_CLASSNAME];
					return false;
				}
			}

			return true;
		}
		#endregion

		#region Event
		/// <summary>
		/// �t�H�[�����[�h�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.15</br>
		/// </remarks>
		private void SFANL00000UB_Load(object sender, EventArgs e)
		{
			ToolButtonEnableChanged(new List<string>(), true);

			List<string> hideToolKey = new List<string>();
			hideToolKey.Add(FreeSheetConst.ctToolBase_New);
			hideToolKey.Add(FreeSheetConst.ctToolBase_Print);
			hideToolKey.Add(FreeSheetConst.ctPopupMenu_Edit);
			hideToolKey.Add(FreeSheetConst.ctPopupMenu_Window);
			hideToolKey.Add(FreeSheetConst.ctPopupMenu_Display);
			hideToolKey.Add(FreeSheetConst.ctPopupMenu_Help);
			ToolButtonVisibleChanged(hideToolKey, false);

			LoadProc(FreeSheetConst.ctFILE_NAVIGATOR);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <remarks>
		/// <br>Note		: �I�����ꂽ�Z���ɑ΂��ĕҏW���[�h���J�n����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.03.28</br>
		/// </remarks>
		private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (e.ColumnIndex == 3)
				this.dataGridView.ImeMode = ImeMode.Hiragana;
			else
				this.dataGridView.ImeMode = ImeMode.Disable;
		}
		#endregion
	}
}