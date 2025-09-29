//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���������i�ݒ�}�X�^
// �v���O�����T�v   : ���_�E���Ӑ�I�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : �e�c ���V
// �� �� ��  2015/02/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// �I���K�C�h
    /// </summary>
    /// <remarks>
    /// <br>�{�N���X��internal�Ő錾����Ă���ׁA�O���A�Z���u������͒��ڎQ�Ƃł��Ȃ��B</br>
    /// <br>�O���A�Z���u������{�N���X�ɃA�N�Z�X����ꍇ�́A����N���X�ɃC���^�[�t�F�[�X</br>
    /// <br>�ƂȂ郁�\�b�h��v���p�e�B���쐬���鎖</br>
    /// </remarks>
    public partial class PMREC09021UC : Form
    {

        # region �ϐ���`

        /// <summary>SecCusSet DataTable</summary>
        private RecBgnGdsDataSet.SecCusSetDataTable _secCusSetDataTable;

        /// <summary>SecCusSet DataTable �v���p�e�B</summary>
        public RecBgnGdsDataSet.SecCusSetDataTable SecCusSetDataTable
        {
            get { return this._secCusSetDataTable; }
            set { this._secCusSetDataTable = value; }
        }

        private bool flipflopFlg = false;

        # endregion

        #region [ �R���X�g���N�^ ]

        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="secCusSetDataTable">�O���b�h�\���p �f�[�^�e�[�u��</param>
        public PMREC09021UC(RecBgnGdsDataSet.SecCusSetDataTable secCusSetDataTable)
        {
            this._secCusSetDataTable = secCusSetDataTable;

            InitializeComponent();
            InitializeTable();
            InitializeForm();

        }

        #endregion

        #region [ �������� ]
        private void InitializeForm()
        {
            // �X�e�[�^�X�o�[�̏�����
            StatusBar.Panels[0].Text = "";

            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Select"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
        }

        /// <summary>
        /// �f�[�^�\�[�X�̏�����
        /// </summary>
        private void InitializeTable()
        {
            this.gridSecCusSetInfo.BeginUpdate();
            this.gridSecCusSetInfo.DataSource = this._secCusSetDataTable.DefaultView;
            this.gridSecCusSetInfo.EndUpdate();
        }

        #endregion

        #region ColInfo�@�C���^�[�i��

        internal static class ColInfo
        {
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
            public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int spanX, int spanY, int width)
            {
                System.Drawing.Size sizeHeader = new Size();
                System.Drawing.Size sizeCell = new Size();

                Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
                Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

                Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
                Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
                Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;
                Band.Columns[colname].RowLayoutColumnInfo.SpanX = spanX;
                Band.Columns[colname].RowLayoutColumnInfo.SpanY = spanY;

                sizeCell.Height = 24;
                sizeCell.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
                sizeHeader.Height = 24;
                sizeHeader.Width = width;
                Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

            }
        }
        #endregion

        #region [ �t�H�[���C�x���g���� ]
        /// <summary>
        /// FormClosed �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>DialogResult��OK�̏ꍇ�ɂ̂݁A�O���b�h��őI������Ă���s�Ɋ֘A����DataRow�I�u�W�F�N�g���擾���A</br>
        /// <br>"�I�����"�ɑ������鏈�����s���܂��B</br>
        /// </remarks>
        private void PMREC09021UC_FormClosed(object sender, FormClosedEventArgs e)
        {
            gridSecCusSetInfo.BeginUpdate();
            try
            {
                gridSecCusSetInfo.DataSource = null;
            }
            finally
            {
                gridSecCusSetInfo.EndUpdate();
            }
        }

        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMREC09021UC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            gridSecCusSetInfo.Select();
        }

        private void PMREC09021UC_Shown(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;

            this.gridSecCusSetInfo.Focus();

            // �擪�s��I����Ԃɂ���
            if (this.gridSecCusSetInfo.Rows.Count > 0)
            {
                if (this.gridSecCusSetInfo.ActiveRow != null)
                {
                    if (!this.gridSecCusSetInfo.ActiveRow.Selected)
                    {
                        this.gridSecCusSetInfo.ActiveRow.Selected = true;
                    }
                }
                else
                {
                    this.gridSecCusSetInfo.Rows[0].Activate();
                    this.gridSecCusSetInfo.Rows[0].Selected = true;
                }
                return;
            }
        }
        /// <summary>
        /// ShowDialog
        /// </summary>
        /// <returns>DialogResult</returns>
        internal new DialogResult ShowDialog()
        {
            DialogResult ret = base.ShowDialog();
            if (ret == DialogResult.OK || ret == DialogResult.Cancel)
            {
                // DataTable���疢�I���s�𒊏o���폜����
                DataRow[] rows = this._secCusSetDataTable.Select("SelectionState = false");
                for (int i = 0; i < rows.Length; i++)
                {
                    if (rows[i].RowState != DataRowState.Deleted)
                    {
                        rows[i].Delete();
                    }
                }
                this._secCusSetDataTable.AcceptChanges();
            }
            return ret;
        }

        #endregion

        #region [ �c�[���o�[�C�x���g���� ]
        /// <summary>
        /// �c�[���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            if (flipflopFlg)
                return;
            bool chk = ((StateButtonTool)ToolbarsManager.Tools["Button_Pos"]).Checked;
            switch (e.Tool.Key)
            {
                case "Button_Select": // �I������Ă���s���m�肷��
                    DialogResult = DialogResult.OK;
                    break;

                case "Button_Back": // �O�̉�ʂɖ߂�
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        #endregion

        #region [ �O���b�h�C�x���g���� ]

        /// <summary>
        /// �O���b�h�@InitializeLayout �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�O���b�h���C�A�E�g�̏���������</br>
        /// </remarks>
        private void gridSecCusSetInfo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            #region �O���b�h�̃��C�A�E�g������

            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;

            // �o���h�̎擾
            UltraGridBand Band = e.Layout.Bands[0];
            Band.UseRowLayout = true;

            for (int Index = 0; Index < Band.Columns.Count; Index++)
            {
                // �t�B���^�𖳌�
                Band.Columns[Index].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
                
                // �����\���ʒu
                if (Band.Columns[Index].DataType == typeof(int) || Band.Columns[Index].DataType == typeof(double))
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else
                {
                    Band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                Band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

                // �����\���ʒu
                Band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            Band.Columns[_secCusSetDataTable.SelImageColumn.ColumnName].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;

            Band.Columns[_secCusSetDataTable.SelImageColumn.ColumnName].Hidden = false;
            Band.Columns[_secCusSetDataTable.SelectionStateColumn.ColumnName].Hidden = true;
            Band.Columns[_secCusSetDataTable.SectionCodeColumn.ColumnName].Hidden = true;
            Band.Columns[_secCusSetDataTable.SectionNameColumn.ColumnName].Hidden = true;
            Band.Columns[_secCusSetDataTable.CustomerCodeColumn.ColumnName].Hidden = false;
            Band.Columns[_secCusSetDataTable.CustomerNameColumn.ColumnName].Hidden = false;
            Band.Columns[_secCusSetDataTable.MngSectionCodeColumn.ColumnName].Hidden = true;
            Band.Columns[_secCusSetDataTable.CnectOriginalEpCdColumn.ColumnName].Hidden = true;
            Band.Columns[_secCusSetDataTable.CnectOriginalSecCdColumn.ColumnName].Hidden = true;

            Band.Columns[_secCusSetDataTable.SelectionStateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;

            Band.Columns[_secCusSetDataTable.SelImageColumn.ColumnName].Width = 40;
            //Band.Columns[_secCusSetDataTable.SectionCodeColumn.ColumnName].Width = 40;
            //Band.Columns[_secCusSetDataTable.SectionNameColumn.ColumnName].Width = 120;
            Band.Columns[_secCusSetDataTable.CustomerCodeColumn.ColumnName].Width = 60;
            Band.Columns[_secCusSetDataTable.CustomerNameColumn.ColumnName].Width = 120;

            #endregion
        }

        /// <summary>
        /// �O���b�h�@�A�N�e�B�u�s�ύX��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridSecCusSetInfo_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            if (gridSecCusSetInfo.Selected.Rows.Count > 0)
            {
                gridSecCusSetInfo.Selected.Rows[0].Activate();
            }
        }

        /// <summary>
        /// �O���b�h�@KeyDown�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </remarks>
        private void gridSecCusSetInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (gridSecCusSetInfo.ActiveRow != null)
                {
                    if (gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelImageColumn.ColumnName].Value != DBNull.Value)
                    {
                        // �I������
                        gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelImageColumn.ColumnName].Value = DBNull.Value; // �I���C���[�W
                        gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelectionStateColumn.ColumnName].Value = false;  // �I����
                    }
                    else
                    {
                        // �I��
                        gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                        gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelectionStateColumn.ColumnName].Value = true;
                    }

                    UltraGridRow ugr = this.gridSecCusSetInfo.ActiveRow.GetSibling(SiblingRow.Next);
                    if (ugr != null)
                    {
                        ugr.Activate();
                        ugr.Selected = true;
                    }

                    // �ύX�f�[�^�̃R�~�b�g
                    gridSecCusSetInfo.UpdateData();
                }
            }
        }

        /// <summary>
        /// �O���b�h�@�s�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// �_�u���N���b�N�s��I������
        /// �f�[�^���\������Ă��Ȃ��s���_�u���N���b�N���Ă��{�C�x���g�͔������Ȃ��B
        /// </remarks>
        private void gridSecCusSetInfo_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (gridSecCusSetInfo.ActiveRow != null)
            {
                if (gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelImageColumn.ColumnName].Value != DBNull.Value)
                {
                    // �I������
                    gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelImageColumn.ColumnName].Value = DBNull.Value;
                    gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelectionStateColumn.ColumnName].Value = false;
                }
                else
                {
                    // �I��
                    gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelImageColumn.ColumnName].Value = IconResourceManagement.ImageList24.Images[(int)Size24_Index.ITEMCHECK];
                    gridSecCusSetInfo.ActiveRow.Cells[_secCusSetDataTable.SelectionStateColumn.ColumnName].Value = true;
                }
                gridSecCusSetInfo.UpdateData();
            }
        }
        #endregion
    }
}