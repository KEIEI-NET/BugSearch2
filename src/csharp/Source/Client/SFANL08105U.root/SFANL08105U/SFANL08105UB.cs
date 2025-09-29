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
	/// 追加項目一覧画面
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票に追加可能なControlの一覧を表示する画面です。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal partial class SFANL08105UB : UserControl
	{
		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08105UB()
		{
			InitializeComponent();
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// 追加項目一覧表示処理
		/// </summary>
		/// <param name="prtItemSetList">印字項目設定LIST</param>
		/// <param name="prtItemGroupingDispTitleList">印字項目グループ表示名称LIST</param>
		/// <param name="imageList">画像LIST</param>
		/// <remarks>
		/// <br>Note		: 印字項目設定を元に追加項目一覧を表示します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
					// 追加項目使用区分(0:使用不可,1:使用可)
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
							uebItemGrp = this.uebPrtItemSetList.Groups.Add(prtItemSet.FreePrtPprDispGrpCd.ToString(), "タイトル未設定グループ");
						uebItemGrp.Expanded = false;
					}

					StringBuilder itemCaption = new StringBuilder();
					UltraExplorerBarItem uebItem = new UltraExplorerBarItem();
					uebItem.Tag = prtItemSet;

					// 項目名称
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

					// レポートコントロール区分(1:TextBox,2:Label,3:Picture,4:Shape,5:Line,6:BarCode)
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
		/// 追加項目一覧ItemDraggingイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 項目のドラッグが開始される前に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
		/// 追加項目一覧GroupExpandedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: グループが展開された後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
	/// 印字項目設定比較クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 印字項目設定をソートする際に使用するCompareクラスです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.06.06</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal class PrtItemSetCompare : IComparer<PrtItemSetWork>
	{
		#region PublicMethod
		/// <summary>
		/// 比較処理
		/// </summary>
		/// <param name="x">比較対象1</param>
		/// <param name="y">比較対象2</param>
		/// <returns>比較結果</returns>
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