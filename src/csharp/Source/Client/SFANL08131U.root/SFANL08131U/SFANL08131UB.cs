using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ���R���[�\�[�g���ʐݒ�UI�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�\�[�g���ʐݒ�UI�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.05.29</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	public partial class SFANL08131UB : Form
	{
		#region PrivateMember
		private DataTable _bindTable;
		#endregion

		#region Const
		private const string COL_FREEPRTPAPERITEMNM	= "FreePrtPaperItemNm";
		private const string COL_SORTINGORDERDIVCD	= "SortingOrderDivCd";
		private const string COL_FREPPRSRTO			= "FrePprSrtO";
		#endregion

		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08131UB()
		{
			InitializeComponent();

			this.ubDecide.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.DECISION];
			this.ubCancel.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.INTERRUPTION];

			this.ubArrowUp.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.LATERARROW];
			this.ubArrowDn.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.BUTTOMARROW];

			// �e�[�u���X�L�[�}�̐ݒ�
			_bindTable = new DataTable();
			_bindTable.Columns.Add(COL_FREEPRTPAPERITEMNM,	typeof(string));
			_bindTable.Columns.Add(COL_SORTINGORDERDIVCD,	typeof(int));
			_bindTable.Columns.Add(COL_FREPPRSRTO,			typeof(FrePprSrtO));
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// �\�[�g���ʐݒ��ʕ\������
		/// </summary>
		/// <param name="frePprSrtOList">���R���[�\�[�g���ʃ}�X�^LIST</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note		: ���R���[�\�[�g���ʐݒ��ʂ�\�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		public DialogResult ShowSortOderSetting(List<FrePprSrtO> frePprSrtOList)
		{
			this.gridItemSelect.DataSource = _bindTable;

			// �\�[�g
			frePprSrtOList.Sort(ComparisonFrePprSrtO);

			// �f�[�^���Z�b�g
			_bindTable.Rows.Clear();
			foreach (FrePprSrtO frePprSrtO in frePprSrtOList)
			{
				DataRow dr = _bindTable.NewRow();
				_bindTable.Rows.Add(dr);
				dr[COL_FREEPRTPAPERITEMNM]	= frePprSrtO.FreePrtPaperItemNm;
				dr[COL_SORTINGORDERDIVCD]	= frePprSrtO.SortingOrderDivCd;
				dr[COL_FREPPRSRTO]			= frePprSrtO.Clone();
			}

			DialogResult dlgRet = this.ShowDialog();
			if (dlgRet == DialogResult.OK)
			{
				frePprSrtOList.Clear();
				foreach (DataRow dr in _bindTable.Rows)
					frePprSrtOList.Add((FrePprSrtO)dr[COL_FREPPRSRTO]);

				// �\�[�g
				frePprSrtOList.Sort(ComparisonFrePprSrtO);
			}

			return dlgRet;
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// ���R���[�\�[�g���ʔ�r����
		/// </summary>
		/// <param name="frePprSrtO1">��r�Ώۂ̑�1 ���R���[�\�[�g���ʃ}�X�^</param>
		/// <param name="frePprSrtO2">��r�Ώۂ̑�2 ���R���[�\�[�g���ʃ}�X�^</param>
		/// <returns>��r����(IComparer.Compare�ɏ���)</returns>
		/// <remarks>
		/// <br>Note		: ���R���[�\�[�g����LIST�̃\�[�g�Ɏg�p���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private int ComparisonFrePprSrtO(FrePprSrtO frePprSrtO1, FrePprSrtO frePprSrtO2)
		{
			if (frePprSrtO1 == null && frePprSrtO2 == null) return 0;

			if (frePprSrtO1 == null && frePprSrtO2 != null) return -1;

			if (frePprSrtO1 != null && frePprSrtO2 == null) return 1;

			return frePprSrtO1.SortingOrder.CompareTo(frePprSrtO2.SortingOrder);
		}

		/// <summary>
		/// �ړ��p�{�^�����͐��䏈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �s�ړ��p�̃{�^���̓��͐�����s���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void ChangeEnableToMoveButton()
		{
			if (this.gridItemSelect.ActiveRow != null)
			{
				if (this.gridItemSelect.ActiveRow.Index == 0)
					this.ubArrowUp.Enabled = false;
				else
					this.ubArrowUp.Enabled = true;

				if (this.gridItemSelect.ActiveRow.Index >= this.gridItemSelect.Rows.Count - 1)
					this.ubArrowDn.Enabled = false;
				else
					this.ubArrowDn.Enabled = true;
			}
		}

		/// <summary>
		/// �\�[�g���ʍX�V����
		/// </summary>
		/// <remarks>
		/// <br>Note		: �o���h�f�[�^���e�̎��R���[�\�[�g���ʃ}�X�^�̃\�[�g���ʂ��X�V���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void UpdateSortingOrder()
		{
			foreach (UltraGridRow ultraGridRow in this.gridItemSelect.Rows)
			{
				FrePprSrtO frePprSrtO = (FrePprSrtO)_bindTable.Rows[ultraGridRow.ListIndex][COL_FREPPRSRTO];
				frePprSrtO.SortingOrder			= ultraGridRow.Index + 1;
				frePprSrtO.SortingOrderDivCd	= (int)_bindTable.Rows[ultraGridRow.ListIndex][COL_SORTINGORDERDIVCD];
			}
		}
		#endregion

		#region Event
		/// <summary>
		/// �m��{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �m��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void ubDecide_Click(object sender, EventArgs e)
		{
			UpdateSortingOrder();

			this.Close();
		}

		/// <summary>
		/// �L�����Z���{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �L�����Z���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void ubCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// ���{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void ubArrowUp_Click(object sender, EventArgs e)
		{
			if (this.gridItemSelect.ActiveRow != null)
			{
				int nowIndex = this.gridItemSelect.ActiveRow.Index;
				if (nowIndex > 0)
				{
					this.gridItemSelect.Rows.Move(this.gridItemSelect.ActiveRow, nowIndex - 1, true);

					ChangeEnableToMoveButton();
				}
			}
		}

		/// <summary>
		/// ���{�^��Click�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void ubArrowDn_Click(object sender, EventArgs e)
		{
			if (this.gridItemSelect.ActiveRow != null)
			{
				int nowIndex = this.gridItemSelect.ActiveRow.Index;
				if (nowIndex < this.gridItemSelect.Rows.Count - 1)
				{
					this.gridItemSelect.Rows.Move(this.gridItemSelect.ActiveRow, nowIndex + 1, true);

					ChangeEnableToMoveButton();
				}
			}
		}

		/// <summary>
		/// �O���b�h�s�������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �s�̏����������������^�C�~���O�Ŕ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void gridItemSelect_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			e.Layout.Bands[0].Columns[COL_FREPPRSRTO].Hidden = true;
			e.Layout.Bands[0].Columns[COL_FREEPRTPAPERITEMNM].Header.Caption	= "���ږ���";
			e.Layout.Bands[0].Columns[COL_SORTINGORDERDIVCD].Header.Caption		= "�\�[�g���@";

			e.Layout.Bands[0].Columns[COL_FREEPRTPAPERITEMNM].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns[COL_SORTINGORDERDIVCD].Style
				= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			ValueList valueList = new ValueList();
			valueList.ValueListItems.Add(0, "�Ȃ�");
			valueList.ValueListItems.Add(1, "����");
			valueList.ValueListItems.Add(2, "�~��");
			e.Layout.Bands[0].Columns[COL_SORTINGORDERDIVCD].ValueList = valueList;
		}

		/// <summary>
		/// �O���b�hAfterRowActivate�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �s���A�N�e�B�u�ɂȂ�����ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void gridItemSelect_AfterRowActivate(object sender, EventArgs e)
		{
			foreach (UltraGridRow ultraGridRow in this.gridItemSelect.Selected.Rows)
				ultraGridRow.Selected = false;

			this.gridItemSelect.ActiveRow.Selected = true;

			ChangeEnableToMoveButton();
		}

		/// <summary>
		/// �O���b�hAfterSortChange�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �\�[�g�A�N�V����������ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void gridItemSelect_AfterSortChange(object sender, BandEventArgs e)
		{
			ChangeEnableToMoveButton();
		}

		/// <summary>
		/// �O���b�h�L�[�_�E���C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h��ŃL�[���������ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void gridItemSelect_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Up:
				{
					if (this.gridItemSelect.ActiveCell != null)
					{
						switch (this.gridItemSelect.ActiveCell.Column.Style)
						{
							case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:
							{
								if (e.Alt)
								{
									this.gridItemSelect.ActiveCell.DroppedDown
										= !this.gridItemSelect.ActiveCell.DroppedDown;
									e.Handled = true;
								}
								else if (!this.gridItemSelect.ActiveCell.DroppedDown)
								{
									this.gridItemSelect.PerformAction(UltraGridAction.AboveCell);
									e.Handled = true;
								}
								break;
							}
							default:
							{
								this.gridItemSelect.PerformAction(UltraGridAction.AboveCell);
								e.Handled = true;
								break;
							}
						}
					}
					break;
				}
				case Keys.Down:
				{
					if (this.gridItemSelect.ActiveCell != null)
					{
						switch (this.gridItemSelect.ActiveCell.Column.Style)
						{
							case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:
							{
								if (e.Alt)
								{
									this.gridItemSelect.ActiveCell.DroppedDown
										= !this.gridItemSelect.ActiveCell.DroppedDown;
									e.Handled = true;
								}
								else if (!this.gridItemSelect.ActiveCell.DroppedDown)
								{
									if (this.gridItemSelect.ActiveRow.Index == this.gridItemSelect.Rows.Count - 1)
										this.ubDecide.Focus();
									else
										this.gridItemSelect.PerformAction(UltraGridAction.BelowCell);
									e.Handled = true;
								}
								break;
							}
							default:
							{
								if (this.gridItemSelect.ActiveRow.Index == this.gridItemSelect.Rows.Count - 1)
									this.ubDecide.Focus();
								else
									this.gridItemSelect.PerformAction(UltraGridAction.BelowCell);
								e.Handled = true;
								break;
							}
						}
					}
					break;
				}
				case Keys.Left:
				{
					if (this.gridItemSelect.ActiveCell != null &&
						this.gridItemSelect.ActiveCell.Column.Key == COL_FREEPRTPAPERITEMNM)
						e.Handled = true;
					break;
				}
				case Keys.Right:
				{
					if (this.gridItemSelect.ActiveCell != null)
					{
						switch (this.gridItemSelect.ActiveCell.Column.Style)
						{
							case Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList:
							{
								if (!this.gridItemSelect.ActiveCell.DroppedDown)
								{
									if (this.ubArrowUp.Enabled)
										this.ubArrowUp.Focus();
									else
										this.ubArrowDn.Focus();
									e.Handled = true;
								}
								break;
							}
						}
					}
					break;
				}
			}
		}

		/// <summary>
		/// �R���g���[��Enter�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �R���g���[�����t�H�[���̃A�N�e�B�u�R���g���[����</br>
		/// <br>			: �Ȃ����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void gridItemSelect_Enter(object sender, EventArgs e)
		{
			if (this.gridItemSelect.Rows.Count > 0)
			{
				if (this.gridItemSelect.ActiveCell == null)
					this.gridItemSelect.Rows[0].Cells[COL_FREEPRTPAPERITEMNM].Activate();
			}
			else
			{
				this.ubCancel.Focus();
			}
		}
		#endregion
	}
}