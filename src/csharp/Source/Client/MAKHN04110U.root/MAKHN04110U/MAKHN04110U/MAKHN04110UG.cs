using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinTree;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	public partial class MAKHN04110UG : Form
	{
		public MAKHN04110UG()
		{
			InitializeComponent();

		}

		private bool _initial = true;
		private List<GoodsKind> _viwGoodsKindLst = new List<GoodsKind>();


		/// <summary>
		/// 
		/// </summary>
		/// <param name="viwGoodsKindLst"></param>
		public void SetGoodsKindLst(List<GoodsKind> viwGoodsKindLst)
		{
			if (this._viwGoodsKindLst.Count > 0)
				this._viwGoodsKindLst.Clear();

			foreach (GoodsKind gk in viwGoodsKindLst)
			{
				this._viwGoodsKindLst.Add(gk.Clone());
			}
		}
		
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="viewGoodsKind"></param>
		/// <param name="selGoodsKind"></param>
		/// <returns></returns>
		public DialogResult ShowGuide(IWin32Window owner, out List<GoodsKind> retGoodsKind)
		{
			retGoodsKind = null;

			DialogResult dr = base.ShowDialog(owner);
			if (dr == DialogResult.OK)
			{
				foreach (UltraTreeNode node in GoodsKind_uTree.Nodes)
				{
					if (node.CheckedState == CheckState.Checked)
					{
						GoodsKind goodsKind = node.Tag as GoodsKind;
						if (goodsKind != null)
						{
							if (retGoodsKind == null)
								retGoodsKind = new List<GoodsKind>();

							retGoodsKind.Add(goodsKind);
						}
					}
				}
			}

			// ����t���O��OFF��
			this._initial = false;

			return dr;
		}

		/// <summary>
		/// �c�[���o�[�����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note       : �c�[���o�[�̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.04.26</br>
		/// </remarks>
		private void InitSettingToolBar()
		{
			// �c�[���o�[�A�C�R���̐ݒ�
			this.Sub_uToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

			// �߂�̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool backButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Sub_uToolbarsManager.Tools["Back_ButtonTool"];
			if (backButton != null) backButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;

			// �m��̃A�C�R���ݒ�
			Infragistics.Win.UltraWinToolbars.ButtonTool enterButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.Sub_uToolbarsManager.Tools["Enter_ButtonTool"];
			if (enterButton != null) enterButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MAKHN04110UG_Load(object sender, EventArgs e)
		{
			if (this._initial)
			{
				this.InitSettingToolBar();

				this.GoodsKind_uTree.ShowLines = false;

				if (this._viwGoodsKindLst.Count > 0)
				{
					foreach (GoodsKind goodsKind in this._viwGoodsKindLst)
					{
						//this.GoodsKind_uTree.Nodes.Add(goodsKind.GoodsKindCode.ToString(), goodsKind.GoodsKindName);
						this.GoodsKind_uTree.Nodes[goodsKind.GoodsKindCode.ToString()].Override.NodeStyle = Infragistics.Win.UltraWinTree.NodeStyle.CheckBox;
						this.GoodsKind_uTree.Nodes[goodsKind.GoodsKindCode.ToString()].CheckedState = System.Windows.Forms.CheckState.Unchecked;
						this.GoodsKind_uTree.Nodes[goodsKind.GoodsKindCode.ToString()].Tag = goodsKind.Clone();
					}
				}
			}
		}

		private void Sub_uToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Back_ButtonTool":
					this.DialogResult = DialogResult.Cancel;
					break;
				case "Enter_ButtonTool":
					this.DialogResult = DialogResult.OK;
					break;
			}

		}
	}
}