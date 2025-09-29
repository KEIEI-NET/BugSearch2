using System;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win.UltraWinExplorerBar;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ǉ����ڈꗗ���
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�ɒǉ��\��Control�̈ꗗ��\�������ʂł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08105UB : UserControl
	{
		#region Constructor
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public SFANL08105UB()
		{
			InitializeComponent();
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// �ǉ����ڈꗗ�\������
		/// </summary>
		/// <param name="prtItemSetList">�󎚍��ڐݒ�LIST</param>
		/// <param name="prtItemGroupingDispTitleList">�󎚍��ڃO���[�v�\������LIST</param>
		/// <param name="imageList">�摜LIST</param>
		/// <remarks>
		/// <br>Note		: �󎚍��ڐݒ�����ɒǉ����ڈꗗ��\�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		public void ShowPrtItemSetList(List<PrtItemSetWork> prtItemSetList, List<PrtItemGroupingDispTitle> prtItemGroupingDispTitleList, ImageList imageList)
		{
			this.uebPrtItemSetList.Groups.Clear();
			this.uebPrtItemSetList.GroupSettings.ItemSort = ItemSortType.None;

			if (prtItemSetList != null)
			{
				prtItemSetList.Sort(new PrtItemSetCompare());
				foreach (PrtItemSetWork prtItemSet in prtItemSetList)
				{
					// �ǉ����ڎg�p�敪(0:�g�p�s��,1:�g�p��)
					if (prtItemSet.AddItemUseDivCd != 1) continue;

					UltraExplorerBarGroup uebItemGrp;
					if (this.uebPrtItemSetList.Groups.Exists(prtItemSet.FreePrtPprDispGrpCd.ToString()))
					{
						uebItemGrp = this.uebPrtItemSetList.Groups[prtItemSet.FreePrtPprDispGrpCd.ToString()];
					}
					else
					{
						PrtItemGroupingDispTitle prtItemGroupingDispTitle = prtItemGroupingDispTitleList.Find(
								delegate(PrtItemGroupingDispTitle dispTitle)
								{
									if (dispTitle.FreePrtPprDispGrpCd == prtItemSet.FreePrtPprDispGrpCd)
										return true;
									else
										return false;
								}
							);
						if (prtItemGroupingDispTitle != null)
							uebItemGrp = this.uebPrtItemSetList.Groups.Add(prtItemSet.FreePrtPprDispGrpCd.ToString(), prtItemGroupingDispTitle.FreePrtPprDispGrpNm);
						else
							uebItemGrp = this.uebPrtItemSetList.Groups.Add(prtItemSet.FreePrtPprDispGrpCd.ToString(), "�^�C�g�����ݒ�O���[�v");
						uebItemGrp.Expanded = false;
					}

					StringBuilder itemCaption = new StringBuilder();
					UltraExplorerBarItem uebItem = new UltraExplorerBarItem();
					uebItem.Tag = prtItemSet;

					// ���ږ���
					itemCaption.Append("[");
					if (prtItemSet.HeaderUseDivCd == 1)
						itemCaption.Append("H");
					else
						itemCaption.Append(" ");

					if (prtItemSet.DetailUseDivCd == 1)
						itemCaption.Append("D");
					else
						itemCaption.Append(" ");

					if (prtItemSet.FooterUseDivCd == 1)
						itemCaption.Append("F");
					else
						itemCaption.Append(" ");
					uebItem.Text = itemCaption.Append("] ").Append(prtItemSet.FreePrtPaperItemNm).ToString();

					// ���|�[�g�R���g���[���敪(1:TextBox,2:Label,3:Picture,4:Shape,5:Line,6:BarCode)
					switch (prtItemSet.ReportControlCode)
					{
						case 1: uebItem.Settings.AppearancesSmall.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_TEXTBOX]; break;
						case 2: uebItem.Settings.AppearancesSmall.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_LABEL]; break;
						case 3: uebItem.Settings.AppearancesSmall.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_PICTURE]; break;
						case 4: uebItem.Settings.AppearancesSmall.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_SHAPE]; break;
						case 5: uebItem.Settings.AppearancesSmall.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_LINE]; break;
						case 6: uebItem.Settings.AppearancesSmall.Appearance.Image = imageList.Images[SFANL08105UA.AR_ICON_BARCODE]; break;
					}

					uebItemGrp.Items.Add(uebItem);
				}
			}

			foreach (UltraExplorerBarGroup uebItemGrp in this.uebPrtItemSetList.Groups)
			{
				if (uebItemGrp.Items.Count == 0)
					uebItemGrp.Visible = false;
			}
		}
		#endregion

		#region Event
		/// <summary>
		/// �ǉ����ڈꗗItemDragging�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: ���ڂ̃h���b�O���J�n�����O�ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void uebPrtItemSetList_ItemDragging(object sender, CancelableItemEventArgs e)
		{
			PrtItemSetWork prtItemSet = e.Item.Tag as PrtItemSetWork;
			if (prtItemSet != null)
			{
				this.uebPrtItemSetList.DoDragDrop(prtItemSet, DragDropEffects.All);
			}
		}

		/// <summary>
		/// �ǉ����ڈꗗGroupExpanded�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note		: �O���[�v���W�J���ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.06.06</br>
		/// </remarks>
		private void uebPrtItemSetList_GroupExpanded(object sender, GroupEventArgs e)
		{
			foreach (UltraExplorerBarGroup uebItemGrp in this.uebPrtItemSetList.Groups)
			{
				if (!uebItemGrp.Key.Equals(e.Group.Key) && uebItemGrp.Expanded)
					uebItemGrp.Expanded = false;
			}
		}
		#endregion
	}

	/// <summary>
	/// �󎚍��ڐݒ��r�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �󎚍��ڐݒ���\�[�g����ۂɎg�p����Compare�N���X�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal class PrtItemSetCompare : IComparer<PrtItemSetWork>
	{
		#region PublicMethod
		/// <summary>
		/// ��r����
		/// </summary>
		/// <param name="x">��r�Ώ�1</param>
		/// <param name="y">��r�Ώ�2</param>
		/// <returns>��r����</returns>
		public int Compare(PrtItemSetWork x, PrtItemSetWork y)
		{
			int retCompare = 0;
			retCompare = x.FreePrtPprDispGrpCd - y.FreePrtPprDispGrpCd;
			if (retCompare == 0)
			{
				retCompare = x.ReportControlCode - y.ReportControlCode;
				if (retCompare == 0)
				{
					retCompare = y.HeaderUseDivCd - x.HeaderUseDivCd;
					if (retCompare == 0)
					{
						retCompare = y.DetailUseDivCd - x.DetailUseDivCd;
						if (retCompare == 0)
						{
							retCompare = y.FooterUseDivCd - x.FooterUseDivCd;
							if (retCompare == 0)
								retCompare = string.Compare(x.FreePrtPaperItemNm, y.FreePrtPaperItemNm);
						}
					}
				}
			}
			return retCompare;
		}
		#endregion
	}
}