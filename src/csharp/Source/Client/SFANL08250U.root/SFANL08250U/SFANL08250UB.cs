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
		// 選択行
		private DataRow _selectedRow;
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFANL08250UB()
		{
			InitializeComponent();
		}
		#endregion

		#region Property
		/// <summary>選択行</summary>
		public DataRow SelectedRow
		{
			get { return _selectedRow; }
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// ShowDialog
		/// </summary>
		/// <param name="dt">選択対象データテーブル</param>
		/// <param name="extraCndCdList">選択対象から除外する抽出条件枝番</param>
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
		/// グリッドInitializeLayoutイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: レイアウトが初期化されたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
						col.Header.Caption = "抽出条件枝番";
						col.CellAppearance.TextHAlign = HAlign.Right;
						break;
					}
					case SFANL08250UA.COL_PRTITEMSET_FREEPRTPAPERITEMNM:
					{
						col.Header.Caption = "条件タイトル";
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
		/// マウスグリッドダブルクリックイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: マウスでコントロールをダブルクリックした時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.10.22</br>
		/// </remarks>
		private void gridPrtItemSet_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Point lastMouseDown = new Point(e.X, e.Y);
			// UIElementを利用して座標位置のコントロールを取得
			UIElement element = this.gridPrtItemSet.DisplayLayout.UIElement.ElementFromPoint(lastMouseDown);
			// クリックした位置がGridRowの場合のみ処理を行う
			UltraGridCell ultraGridCell = element.GetContext(typeof(UltraGridCell)) as UltraGridCell;
			if (ultraGridCell != null)
			{
				_selectedRow = ((DataRowView)ultraGridCell.Row.ListObject).Row;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		/// <summary>
		/// グリッドキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッド上でキーが押下された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
		/// フォームキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: フォーム上でキーが押下された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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