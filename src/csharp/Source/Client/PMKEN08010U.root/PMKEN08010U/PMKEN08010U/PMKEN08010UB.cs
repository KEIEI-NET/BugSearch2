using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Common;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// �Ԏ�I���K�C�h
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ԏ�I���K�C�h�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    internal partial class SelectionForm : Form
    {
        #region [ �����o�[�ϐ��錾 ]
        private readonly string colCarKindCd = "CarKindCd";
        private PMKEN01010E.CarKindInfoDataTable srcTable = null;
        private string rowNoInput = string.Empty;
        #endregion

        #region [ �t�H�[���֘A���� ]
        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="dtSource">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        public SelectionForm(PMKEN01010E.CarKindInfoDataTable dtSource)
        {
            InitializeComponent();

            // DataTable �̐ݒ�
            srcTable = dtSource;
            InitializaDataTable();

            gridCarKindInfo.DataSource = srcTable;

            // �X�e�[�^�X�o�[�̏�����
            StatusBar.Panels[0].Text = "";

            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;

            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            ToolbarsManager.Tools["Button_ShowCode"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.COL;

            // �擪�s��I����Ԃɂ���
            gridCarKindInfo.Rows[0].Selected = true;
            RefreshCount();

        }

        private void RefreshCount()
        {
            if (gridCarKindInfo.Selected.Rows.Count > 0)
                ToolbarsManager.Toolbars[1].Tools["TotalCount"].SharedProps.Caption = string.Format("{0}�^{1}",
                    gridCarKindInfo.Selected.Rows[0].VisibleIndex + 1,
                    gridCarKindInfo.Rows.VisibleRowCount);
        }

        /// <summary>
        /// FormClosing �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�s���̎��Ԃ�����邽�߁A�T�u�X���b�h�̎��s���͏I���ł��Ȃ��悤�ɂ���</br>
        /// </remarks>
        private void SelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            srcTable.Columns.Remove(colCarKindCd);
        }

        /// <summary>
        /// FormClosed �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResult��OK�̏ꍇ�ɂ̂݁A�O���b�h��őI������Ă���s�Ɋ֘A����DataRow�I�u�W�F�N�g���擾���A</br>
        /// <br>"�I�����"�ɑ������鏈�����s���܂��B</br>
        /// </remarks>
        private void SelectionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                for (int Index = 0; Index <= this.gridCarKindInfo.Selected.Rows.Count - 1; Index++)
                {
                    this.gridCarKindInfo.Selected.Rows[Index].Cells["SelectionState"].Value = true;
                }
            }

            gridCarKindInfo.BeginUpdate();
            try
            {
                gridCarKindInfo.DataSource = null;
            }
            finally
            {
                gridCarKindInfo.EndUpdate();
            }
        }

        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
                case Keys.Back:
                    int rowNo;
                    if (rowNoInput.Length > 1)
                    {
                        rowNoInput = rowNoInput.Remove(rowNoInput.Length - 1);
                        rowNo = int.Parse(rowNoInput);
                    }
                    else
                    {
                        rowNoInput = string.Empty;
                        rowNo = 1;
                    }
                    gridCarKindInfo.Rows[rowNo - 1].Activate();
                    gridCarKindInfo.Rows[rowNo - 1].Selected = true;
                    break;
                case Keys.Delete:
                    rowNoInput = string.Empty;
                    gridCarKindInfo.Rows[0].Activate();
                    gridCarKindInfo.Rows[0].Selected = true;
                    break;
            }
        }

        private void SelectionForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                string strRowNo = rowNoInput + e.KeyChar.ToString();

                int rowNo = int.Parse(strRowNo);
                if (rowNo > 0 && rowNo <= gridCarKindInfo.Rows.VisibleRowCount)
                {
                    rowNoInput = strRowNo;
                }
                else
                {
                    if (e.KeyChar.Equals('0') == false)
                    {
                        rowNoInput = e.KeyChar.ToString();
                        rowNo = int.Parse(rowNoInput);
                        if (rowNo > gridCarKindInfo.Rows.VisibleRowCount)
                        {
                            rowNoInput = string.Empty;
                            rowNo = 1;
                        }
                    }
                    else
                    {
                        rowNo = 1;
                    }
                }
                if (gridCarKindInfo.Focused == false)
                    gridCarKindInfo.Select();
                gridCarKindInfo.Rows[rowNo - 1].Activate();
                gridCarKindInfo.Rows[rowNo - 1].Selected = true;
            }
        }
        #endregion

        #region [ �C�x���g���� ]
        /// <summary>
        /// �c�[���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "Button_Select":
                    // �I������Ă���s���m�肷��
                    DialogResult = DialogResult.OK;
                    break;

                #region �S�I���͂Ȃ����߁A�R�����g�A�E�g����B
                //case "Button_SelectAll":
                //    // �S�Ă̍s��I�����Ċm�肷��B
                //    this.gridCarKindInfo.BeginUpdate();
                //    try
                //    {
                //        this.gridCarKindInfo.Selected.Rows.Clear();

                //        UltraGridRow[] SelectRows = new UltraGridRow[gridCarKindInfo.Rows.FilteredInRowCount];

                //        int i = 0;
                //        foreach (UltraGridRow ulRow in gridCarKindInfo.Rows)
                //        {
                //            if (!ulRow.IsFilteredOut)
                //            {
                //                SelectRows[i] = ulRow;
                //                i += 1;
                //            }
                //        }

                //        gridCarKindInfo.Selected.Rows.AddRange(SelectRows);
                //    }
                //    finally
                //    {
                //        this.gridCarKindInfo.EndUpdate();
                //    }
                //    DialogResult = DialogResult.OK;
                //    break;
                #endregion

                case "Button_Back":
                    // �O�̉�ʂɖ߂�
                    DialogResult = DialogResult.Cancel;
                    break;
                case "Button_ShowCode":
                    if (ToolbarsManager.Tools["Button_ShowCode"].SharedProps.Caption == "�R�[�h�\��(F9)")
                    {
                        ToolbarsManager.Tools["Button_ShowCode"].SharedProps.Caption = "�R�[�h��\��(F9)";
                        gridCarKindInfo.DisplayLayout.Bands[0].Columns[colCarKindCd].Hidden = false;
                    }
                    else
                    {
                        ToolbarsManager.Tools["Button_ShowCode"].SharedProps.Caption = "�R�[�h�\��(F9)";
                        gridCarKindInfo.DisplayLayout.Bands[0].Columns[colCarKindCd].Hidden = true;
                    }
                    break;
            }
        }

        #endregion

        #region [ �O���b�h���� ]
        private void InitializaDataTable()
        {
            srcTable.Columns.Add(colCarKindCd, typeof(string));
            srcTable.Columns[colCarKindCd].Caption = "�Ԏ�R�[�h";
            for (int i = 0; i < srcTable.Count; i++)
            {
                srcTable[i][colCarKindCd] = string.Format("{0:d3}-{1:d3}-{2:d3}", srcTable[i].MakerCode, srcTable[i].ModelCode, srcTable[i].ModelSubCode);
            }
        }

        /// <summary>
        /// InitializeLayout �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�O���b�h�̃��C�A�E�g����������</br>
        /// </remarks>
        private void gridCarKindInfo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;
            e.Layout.Override.RowSelectorHeaderStyle = RowSelectorHeaderStyle.SeparateElement;

            // �o���h�̎擾
            UltraGridBand band = e.Layout.Bands[0];
            band.Columns[srcTable.SelectionStateColumn.ColumnName].Hidden = true;
            band.Columns[srcTable.MakerCodeColumn.ColumnName].Hidden = true;
            band.Columns[srcTable.ModelCodeColumn.ColumnName].Hidden = true;
            band.Columns[srcTable.ModelSubCodeColumn.ColumnName].Hidden = true;
            band.Columns[srcTable.MakerHalfNameColumn.ColumnName].Hidden = true;
            band.Columns[srcTable.ModelHalfNameColumn.ColumnName].Hidden = true;
            if (srcTable[0].EngineModelNm != string.Empty)
            {
                band.Columns[srcTable.EngineModelNmColumn.ColumnName].Hidden = false;
                band.Columns[colCarKindCd].Hidden = true;
                ToolbarsManager.Tools["Button_ShowCode"].SharedProps.Visible = false;
            }
            else
            {
                band.Columns[srcTable.EngineModelNmColumn.ColumnName].Hidden = true;
                band.Columns[colCarKindCd].Hidden = false;
            }

            band.UseRowLayout = true;

            band.Columns[srcTable.MakerFullNameColumn.ColumnName].Width = 150;
            band.Columns[srcTable.ModelFullNameColumn.ColumnName].Width = 300;
            band.Columns[srcTable.EngineModelNmColumn.ColumnName].Width = 120;
            band.Columns[colCarKindCd].Width = 120;

            if (band.Columns[srcTable.EngineModelNmColumn.ColumnName].Hidden)
            {
                band.SortedColumns.Add(srcTable.MakerCodeColumn.ColumnName, false);
                band.SortedColumns.Add(srcTable.MakerFullNameColumn.ColumnName, false);
                band.Columns[srcTable.MakerFullNameColumn.ColumnName].MergedCellStyle = MergedCellStyle.OnlyWhenSorted;

                band.Columns[srcTable.MakerFullNameColumn.ColumnName].RowLayoutColumnInfo.OriginX = 0;
                band.Columns[srcTable.ModelFullNameColumn.ColumnName].RowLayoutColumnInfo.OriginX = 150;
                band.Columns[colCarKindCd].RowLayoutColumnInfo.OriginX = 450;
            }
            else
            {
                band.SortedColumns.Add(srcTable.EngineModelNmColumn.ColumnName, false);
                band.Columns[srcTable.EngineModelNmColumn.ColumnName].MergedCellStyle = MergedCellStyle.OnlyWhenSorted;

                band.Columns[srcTable.EngineModelNmColumn.ColumnName].RowLayoutColumnInfo.OriginX = 0;
                band.Columns[srcTable.ModelFullNameColumn.ColumnName].RowLayoutColumnInfo.OriginX = 120;
                band.Columns[srcTable.MakerFullNameColumn.ColumnName].RowLayoutColumnInfo.OriginX = 420;
            }
            gridCarKindInfo.Rows[0].Activate();
        }

        /// <summary>
        /// �O���b�h���Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridCarKindInfo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    DialogResult = DialogResult.OK;
                    break;
            }
        }

        /// <summary>
        /// �s���_�u���N���b�N���ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// �f�[�^���\������Ă��Ȃ��s���_�u���N���b�N���Ă��{�C�x���g�͔������Ȃ��B
        /// </remarks>
        private void gridCarKindInfo_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void gridCarKindInfo_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            RefreshCount();
        }
        #endregion
    }
}