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
	/// 自由帳票ソート順位設定UIクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票ソート順位設定UIです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
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
		/// コンストラクタ
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

			// テーブルスキーマの設定
			_bindTable = new DataTable();
			_bindTable.Columns.Add(COL_FREEPRTPAPERITEMNM,	typeof(string));
			_bindTable.Columns.Add(COL_SORTINGORDERDIVCD,	typeof(int));
			_bindTable.Columns.Add(COL_FREPPRSRTO,			typeof(FrePprSrtO));
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// ソート順位設定画面表示処理
		/// </summary>
		/// <param name="frePprSrtOList">自由帳票ソート順位マスタLIST</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票ソート順位設定画面を表示します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		public DialogResult ShowSortOderSetting(List<FrePprSrtO> frePprSrtOList)
		{
			this.gridItemSelect.DataSource = _bindTable;

			// ソート
			frePprSrtOList.Sort(ComparisonFrePprSrtO);

			// データをセット
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

				// ソート
				frePprSrtOList.Sort(ComparisonFrePprSrtO);
			}

			return dlgRet;
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// 自由帳票ソート順位比較処理
		/// </summary>
		/// <param name="frePprSrtO1">比較対象の第1 自由帳票ソート順位マスタ</param>
		/// <param name="frePprSrtO2">比較対象の第2 自由帳票ソート順位マスタ</param>
		/// <returns>比較結果(IComparer.Compareに準拠)</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票ソート順位LISTのソートに使用します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
		/// 移動用ボタン入力制御処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 行移動用のボタンの入力制御を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
		/// ソート順位更新処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: バンドデータ内容の自由帳票ソート順位マスタのソート順位を更新します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
		/// 確定ボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 確定ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void ubDecide_Click(object sender, EventArgs e)
		{
			UpdateSortingOrder();

			this.Close();
		}

		/// <summary>
		/// キャンセルボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: キャンセルボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void ubCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// ↑ボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ↑ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
		/// ↓ボタンClickイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ↓ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
		/// グリッド行初期化イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: 行の初期化が発生したタイミングで発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void gridItemSelect_InitializeLayout(object sender, InitializeLayoutEventArgs e)
		{
			e.Layout.Bands[0].Columns[COL_FREPPRSRTO].Hidden = true;
			e.Layout.Bands[0].Columns[COL_FREEPRTPAPERITEMNM].Header.Caption	= "項目名称";
			e.Layout.Bands[0].Columns[COL_SORTINGORDERDIVCD].Header.Caption		= "ソート方法";

			e.Layout.Bands[0].Columns[COL_FREEPRTPAPERITEMNM].CellActivation = Activation.NoEdit;
			e.Layout.Bands[0].Columns[COL_SORTINGORDERDIVCD].Style
				= Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
			ValueList valueList = new ValueList();
			valueList.ValueListItems.Add(0, "なし");
			valueList.ValueListItems.Add(1, "昇順");
			valueList.ValueListItems.Add(2, "降順");
			e.Layout.Bands[0].Columns[COL_SORTINGORDERDIVCD].ValueList = valueList;
		}

		/// <summary>
		/// グリッドAfterRowActivateイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: 行がアクティブになった後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
		/// グリッドAfterSortChangeイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ソートアクション完了後に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.29</br>
		/// </remarks>
		private void gridItemSelect_AfterSortChange(object sender, BandEventArgs e)
		{
			ChangeEnableToMoveButton();
		}

		/// <summary>
		/// グリッドキーダウンイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントハンドラ</param>
		/// <remarks>
		/// <br>Note		: グリッド上でキーが押下された時に発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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
		/// コントロールEnterイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: コントロールがフォームのアクティブコントロールに</br>
		/// <br>			: なったときに発生します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
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