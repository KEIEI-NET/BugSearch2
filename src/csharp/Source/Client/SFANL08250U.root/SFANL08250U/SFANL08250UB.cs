using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
	internal partial class SFANL08250UB : Form
	{
		#region PrivateMember
		// �I���s
		private DataRow _selectedRow;
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08250UB()
		{
			InitializeComponent();
		}
		#endregion

		#region Property
		/// <summary>�I���s</summary>
		public DataRow SelectedRow
		{
			get { return _selectedRow; }
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// ShowDialog
		/// </summary>
		/// <param name="dt">�I��Ώۃf�[�^�e�[�u��</param>
		/// <param name="extraCndCdList">�I��Ώۂ��珜�O���钊�o�����}��</param>
		/// <returns>DialogResult</returns>
		public DialogResult ShowDialog(DataTable dt, List<int> extraCndCdList)
		{
			DataView dv = new DataView(dt);
			dv.RowFilter = SFANL08250UA.COL_PRTITEMSET_EXTRACONDITIONDIVCD + "<> 0";
			StringBuilder wkStr = new StringBuilder();
			if (extraCndCdList != null && extraCndCdList.Count > 0)
			{
				foreach (int extraCndCd in extraCndCdList)
				{
					if (wkStr.Length > 0)
						wkStr.Append(",");
					wkStr.Append(extraCndCd);
				}
				dv.RowFilter += " AND NOT(" + SFANL08250UA.COL_PRTITEMSET_FREEPRTPAPERITEMCD + " IN (" + wkStr.ToString() + "))";
			}

			if (dv.Count == 0)
			{
				return DialogResult.Abort;
			}
			else
			{
				this.gridPrtItemSet.DataSource = dv;

				return ShowDialog();
			}
		}
		#endregion

		#region Event
		/// <summary>
		/// �O���b�hInitializeLayout�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���C�A�E�g�����������ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void gridPrtItemSet_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
		{
			foreach (UltraGridColumn col in e.Layout.Bands[0].Columns)
			{
				switch (col.Key)
				{
					case SFANL08250UA.COL_PRTITEMSET_FREEPRTPAPERITEMCD:
					{
						col.Header.Caption = "���o�����}��";
						col.CellAppearance.TextHAlign = HAlign.Right;
						break;
					}
					case SFANL08250UA.COL_PRTITEMSET_FREEPRTPAPERITEMNM:
					{
						col.Header.Caption = "�����^�C�g��";
						break;
					}
					default:
					{
						col.Hidden = true;
						break;
					}
				}
			}
		}

		/// <summary>
		/// �}�E�X�O���b�h�_�u���N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �}�E�X�ŃR���g���[�����_�u���N���b�N�������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void gridPrtItemSet_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Point lastMouseDown = new Point(e.X, e.Y);
			// UIElement�𗘗p���č��W�ʒu�̃R���g���[�����擾
			UIElement element = this.gridPrtItemSet.DisplayLayout.UIElement.ElementFromPoint(lastMouseDown);
			// �N���b�N�����ʒu��GridRow�̏ꍇ�̂ݏ������s��
			UltraGridCell ultraGridCell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
			if (ultraGridCell != null)
			{
				_selectedRow = ((DataRowView)ultraGridCell.Row.ListObject).Row;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		/// <summary>
		/// �O���b�h�L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h��ŃL�[���������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void gridPrtItemSet_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.gridPrtItemSet.ActiveRow != null)
			{
				switch (e.KeyCode)
				{
					case Keys.Enter:
					{
						_selectedRow = ((DataRowView)this.gridPrtItemSet.ActiveRow.ListObject).Row;
						this.DialogResult = DialogResult.OK;
						this.Close();
						break;
					}
				}
			}
		}

		/// <summary>
		/// �t�H�[���L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[����ŃL�[���������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void SFANL08242UB_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
				{
					this.DialogResult = DialogResult.Cancel;
					this.Close();
					break;
				}
			}
		}
		#endregion
	}
}