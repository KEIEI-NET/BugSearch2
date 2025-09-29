using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	internal partial class SFANL08250UC : Form
	{
		private int _selectedSchmGrpCd;
		private int _newSchmGrpCd;
		private List<int> _schmGrpCdList;

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08250UC()
		{
			InitializeComponent();
		}
		#endregion

		#region Property
		/// <summary>
		/// 
		/// </summary>
		public int NewSchmGrpCd
		{
			get { return _newSchmGrpCd; }
		}

		/// <summary>
		/// 
		/// </summary>
		public int SelectedSchmGrpCd
		{
			get { return _selectedSchmGrpCd; }
		}
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public DialogResult ShowDialog(List<int> schmGrpCdList)
		{
			_schmGrpCdList = schmGrpCdList;

			this.cmbFreePrtPprSchmGrpCd.Items.Clear();
			this.cmbFreePrtPprSchmGrpCd.Items.Add(-1, "印字項目設定");
			foreach (int schmGrpCd in schmGrpCdList)
				this.cmbFreePrtPprSchmGrpCd.Items.Add(schmGrpCd);
			if (this.cmbFreePrtPprSchmGrpCd.Items.Count > 0)
				this.cmbFreePrtPprSchmGrpCd.SelectedIndex = 0;

			return this.ShowDialog();
		}

		private void ubDecide_Click(object sender, EventArgs e)
		{
			int newSchmGrpCd = this.ndtFreePrtPprSchmGrpCd.GetInt();

			if (_schmGrpCdList.Contains(newSchmGrpCd))
			{
				MessageBox.Show(
					"すでに追加済みのスキーマグループコードです",
					SFANL08250UA.ctMSG_CAPTION,
					MessageBoxButtons.OK,
					MessageBoxIcon.Information,
					MessageBoxDefaultButton.Button1);
				return;
			}

			_newSchmGrpCd = newSchmGrpCd;
			_selectedSchmGrpCd = (int)this.cmbFreePrtPprSchmGrpCd.Value;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void ubCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}