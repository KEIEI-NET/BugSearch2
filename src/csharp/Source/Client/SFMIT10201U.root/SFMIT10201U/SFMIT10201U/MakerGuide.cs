using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// メーカーガイド
    /// </summary>
    public partial class MakerGuide : Form
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MakerGuide()
        {
            InitializeComponent();
            this._makerList = new List<Propose_Para_Maker>();
            this._makerTable = new DataTable();
            this._makerTable.CaseSensitive = true;
            this._makerNameChange = false;
            this._makerKanaChange = false;
        }
        #endregion

        #region const
        private const string COL_CD = "コード";
        private const string COL_NAME = "名称";
        private const string COL_KANA = "カナ";
        private const string CT_ASSEMBLYID = "SFMIT10201U";
        #endregion

        #region メンバ
        /// <summary>メーカーテーブル</summary>
        private DataTable _makerTable;
        /// <summary>メーカー名称変更フラグ</summary>
        private bool _makerNameChange;
        /// <summary>メーカーカナ変更フラグ</summary>
        private bool _makerKanaChange;

        /// <summary>メーカーリスト</summary>
        public List<Propose_Para_Maker> _makerList;

        /// <summary>選択メーカーコード</summary>
        public int _makerCode;
        /// <summary>選択メーカー名称</summary>
        public string _makerName;
        #endregion

        #region Public
        /// <summary>
        /// メーカーガイド起動
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowMakerGuide()
        {
            // テーブル作成
            this.MakeMakerTable();

            // データセット
            this.SetDataTable();

            // 起動
            return this.ShowDialog();
        }
        #endregion

        #region Private

        /// <summary>
        /// テーブル作成
        /// </summary>
        private void MakeMakerTable()
        {
            this._makerTable.Columns.Add(COL_CD, typeof(int));
            this._makerTable.Columns.Add(COL_NAME, typeof(string));
            this._makerTable.Columns.Add(COL_KANA, typeof(string));
        }

        /// <summary>
        /// データセット
        /// </summary>
        private void SetDataTable()
        {
            // ソート
            this._makerList.Sort(delegate(Propose_Para_Maker obj1, Propose_Para_Maker obj2)
            {
                int comp = obj1.DisplayOrder.CompareTo(obj2.DisplayOrder);
                if (comp == 0)
                {
                    return obj1.GoodsMakerCd.CompareTo(obj2.GoodsMakerCd);
                }
                else
                {
                    return comp;
                }

            });

            foreach (Propose_Para_Maker maker in this._makerList)
            {
                DataRow row = this._makerTable.NewRow();
                row[COL_CD] = maker.GoodsMakerCd;
                row[COL_NAME] = maker.MakerName;
                row[COL_KANA] = maker.MakerKanaName;
                this._makerTable.Rows.Add(row);
            }

            this.Maker_Grid.DataSource = this._makerTable.DefaultView;

            // 1行目を選択
            if (this.Maker_Grid.Rows.Count > 0)
            {
                this.Maker_Grid.Rows[0].Selected = true;
                this.Maker_Grid.Rows[0].Activated = true;
            }
        }

        /// <summary>
        /// SettingGridColumn
        /// </summary>
        /// <param name="cols"></param>
        private void SettingGridColumn(ColumnsCollection cols)
        {
            // コード
            cols[COL_CD].Width = 40;
            cols[COL_CD].Hidden = false;
            cols[COL_CD].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            cols[COL_CD].CellActivation = Activation.NoEdit;
            cols[COL_CD].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
            cols[COL_CD].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            cols[COL_CD].CellDisplayStyle = CellDisplayStyle.PlainText;

            // 名称
            cols[COL_NAME].Hidden = false;
            cols[COL_NAME].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            cols[COL_NAME].CellActivation = Activation.NoEdit;
            cols[COL_NAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
            cols[COL_NAME].CellDisplayStyle = CellDisplayStyle.PlainText;

            // カナ
            cols[COL_KANA].Hidden = false;
            cols[COL_KANA].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            cols[COL_KANA].CellActivation = Activation.NoEdit;
            cols[COL_KANA].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Top;
            cols[COL_KANA].CellDisplayStyle = CellDisplayStyle.PlainText;
        }

        /// <summary>
        /// 選択結果を戻す
        /// </summary>
        private void SetResult()
        {
            if (this.Maker_Grid.ActiveRow != null)
            {
                this._makerCode = (int)this.Maker_Grid.ActiveRow.Cells[COL_CD].Value;
                this._makerName = this.Maker_Grid.ActiveRow.Cells[COL_NAME].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        /// <summary>
        /// フィルター処理
        /// </summary>
        private void MakeFilter()
        {
            string filter = "";
            StringBuilder cndString = new StringBuilder();
            if (!string.IsNullOrEmpty(this.MakerName_TextBox.Text))
            {
                if (!string.IsNullOrEmpty(this.MakerKana_TextBox.Text))
                {
                    cndString.Append(String.Format("{0} Like '%{1}%' AND {2} Like '%{3}%'", COL_NAME, this.MakerName_TextBox.Text, COL_KANA, this.MakerKana_TextBox.Text));
                    filter = cndString.ToString();
                }
                else
                {
                    cndString.Append(String.Format("{0} Like '%{1}%'", COL_NAME, this.MakerName_TextBox.Text));
                    filter = cndString.ToString();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this.MakerKana_TextBox.Text))
                {
                    cndString.Append(String.Format("{0} Like '%{1}%'", COL_KANA, this.MakerKana_TextBox.Text));
                    filter = cndString.ToString();
                }
            }
            this._makerTable.DefaultView.RowFilter = filter;
            this.Maker_Grid.Refresh();
            this.Maker_Grid.Update();
        }

        #endregion

        #region Evnet

        #region Grid

        /// <summary>
        /// Maker_Grid_InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Maker_Grid_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            UltraGridLayout layout = e.Layout;
            // グリッドのカラム情報を設定します。
            this.SettingGridColumn(layout.Bands[0].Columns);

            layout.ScrollBounds = ScrollBounds.ScrollToFill;
            layout.ScrollStyle = ScrollStyle.Immediate;
            layout.Override.AllowAddNew = AllowAddNew.No;
            layout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            layout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            layout.Override.AllowColMoving = AllowColMoving.NotAllowed;
            layout.UseFixedHeaders = false;

            // ヘッダーの外観設定
            layout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            layout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            layout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            layout.Override.HeaderAppearance.ForeColor = System.Drawing.Color.White;
            layout.Override.HeaderAppearance.FontData.Name = "ＭＳ ゴシック";
            layout.Override.HeaderAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
            layout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;

            // 1行おきの外観設定
            layout.Override.RowAlternateAppearance.BackColor = Color.Lavender;
            // 行セレクターの設定
            layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            layout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            layout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            layout.Override.RowSelectorAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            // 行選択設定 行選択無しモード(アクティブのみ)
            layout.Override.SelectTypeCell = SelectType.None;
            layout.Override.SelectTypeCol = SelectType.None;
            layout.Override.SelectTypeRow = SelectType.Single;

            // 選択行の外観設定
            layout.Override.SelectedRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.SelectedRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            layout.Override.SelectedRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            layout.Override.SelectedRowAppearance.ForeColor = System.Drawing.Color.Black;
            layout.Override.SelectedRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.SelectedRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);

            // アクティブ行の外観設定
            layout.Override.ActiveRowAppearance.BackColor = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.ActiveRowAppearance.BackColor2 = System.Drawing.Color.FromArgb(238, 149, 21);
            layout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            layout.Override.ActiveRowAppearance.ForeColor = System.Drawing.Color.Black;
            layout.Override.ActiveRowAppearance.BackColorDisabled = System.Drawing.Color.FromArgb(251, 230, 148);
            layout.Override.ActiveRowAppearance.BackColorDisabled2 = System.Drawing.Color.FromArgb(238, 149, 21);
            // 行フィルターの設定
            layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // 列の自動調整
            layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            // 列の入替不可
            layout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            // 列のサイズ変更不可
            layout.Override.AllowColSizing = AllowColSizing.None;
            // 列のソート不可
            layout.Override.FixedHeaderIndicator = FixedHeaderIndicator.None;
            layout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.Select;
            layout.Override.CellClickAction = CellClickAction.RowSelect;

            //行サイズ変更不可
            layout.Override.RowSizing = RowSizing.Fixed;
        }

        /// <summary>
        /// Maker_Grid_Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Maker_Grid_Enter(object sender, EventArgs e)
        {
            // 1行目を選択
            if (this.Maker_Grid.Rows.Count > 0)
            {
                this.Maker_Grid.Rows[0].Selected = true;
                this.Maker_Grid.Rows[0].Activated = true;
            }
        }

        /// <summary>
        /// Maker_Grid_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Maker_Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Maker_Grid.ActiveRow != null)
            {
                switch (e.KeyData)
                {
                    // ↑キー
                    case Keys.Up:
                        if (this.Maker_Grid.ActiveRow.HasPrevSibling())
                        {
                            this.Maker_Grid.PerformAction(UltraGridAction.AboveRow);
                        }
                        else
                        {
                            this.MakerKana_TextBox.Focus();
                        }
                        e.Handled = true;
                        break;
                    // ↓キー
                    case Keys.Down:
                        this.Maker_Grid.PerformAction(UltraGridAction.BelowRow);
                        e.Handled = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Maker_Grid_DoubleClickRow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Maker_Grid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            this.SetResult();
        }

        #endregion

        #region その他

        /// <summary>
        /// 戻るボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 確定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.SetResult();
        }

        /// <summary>
        /// MakerName_TextBox_Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerName_TextBox_Enter(object sender, EventArgs e)
        {
            //フラグ初期化
            this._makerNameChange = false;
        }

        /// <summary>
        /// MakerName_TextBox_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerName_TextBox_TextChanged(object sender, EventArgs e)
        {
            //ユーザーによる変更か？
            if (this.MakerName_TextBox.Modified == true)
            {
                //フラグ初期化
                this._makerNameChange = true;
            }
        }

        /// <summary>
        /// MakerName_TextBox_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerName_TextBox_Leave(object sender, EventArgs e)
        {
            if (this._makerNameChange)
            {
                this.MakeFilter();
            }
        }

        /// <summary>
        /// MakerKana_TextBox_Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerKana_TextBox_Enter(object sender, EventArgs e)
        {
            //フラグ初期化
            this._makerKanaChange = false;
        }

        /// <summary>
        /// MakerKana_TextBox_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerKana_TextBox_TextChanged(object sender, EventArgs e)
        {
            //ユーザーによる変更か？
            if (this.MakerKana_TextBox.Modified == true)
            {
                //フラグ初期化
                this._makerKanaChange = true;
            }
        }

        /// <summary>
        /// MakerKana_TextBox_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakerKana_TextBox_Leave(object sender, EventArgs e)
        {
            if (this._makerKanaChange)
            {
                this.MakeFilter();
            }
        }


        /// <summary>
        /// tRetKeyControl1_ChangeFocus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) || (e.NextCtrl == null))
                return;

            //キー制御         
            switch (e.PrevCtrl.Name)
            {
                case "Maker_Grid":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    e.NextCtrl = null;
                                    this.SetResult();
                                    break;
                                }
                        }
                        break;
                    }
            }

        }
        #endregion

        #endregion
    }
}