//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^�N���A����
// �v���O�����T�v   : �f�[�^�N���A�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/06/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �f�[�^�N���A�����R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �f�[�^�N���A�����\�����s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.06.16</br>
    /// </remarks>
    public partial class PMKHN01000UB : UserControl
    {
        #region �� private field ��

        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;

        #endregion �� private field ��

        #region �� Private Members

        /// <summary>�f�[�^�N���A�����f�[�^�Z�b�g</summary>
        /// <remarks></remarks>
        private DataClearDataSet.DataClearDataTable _dataClearDataTable;

        /// <summary>�f�[�^�N���A�����A�N�Z�X</summary>
        /// <remarks></remarks>
        private DataClearAcs _dataClearAcs;

        #endregion

        #region �� Constroctors
        /// <summary>
        /// �f�[�^�N���A�����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�N���A�����N���X�R���X�g���N�^�ł��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public PMKHN01000UB()
        {
            InitializeComponent();
            this._dataClearAcs = DataClearAcs.GetInstance();
            this._dataClearDataTable = this._dataClearAcs.DataClearDataTable;
            this.uGrid_Details.DataSource = this._dataClearDataTable;
        }
        #endregion

        #region �� Control Event
        /// <summary>
        /// �R���g���[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �R���g���[�����[�h�C�x���g���s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        private void PMKHN01000UB_Load(object sender, EventArgs e)
        {
            // �O���b�h�񏉊��ݒ菈��
            this.InitialSettingGridCol();

            // �O���b�h�s�����ݒ菈��
            this.GridRowInitialSetting();

            // �����t�H�[�J�X�ʒu
            this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
        }

        /// <summary>
        /// �O���b�h�s�����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[�����[�h�C�x���g���s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        private void GridRowInitialSetting()
        {
            this._dataClearDataTable.Rows.Clear();
        }

        /// <summary>
        /// �O���b�h�̏������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̏������C�x���g���s��</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �O���b�h�񏉊��ݒ菈��
            this.InitialSettingGridCol();
        }

        /// <summary>
        /// �O���b�h�Z���A�b�v�f�[�g��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Z���A�b�v�f�[�g��C�x���g�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/06/17</br>
        /// </remarks>
        private void uGrid_Details_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            this._dataClearDataTable.AcceptChanges();
            if (e.Cell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
            bool check;
            string checkStringDel = this.uGrid_Details.Rows[cell.Row.Index].Cells[this._dataClearDataTable.IsCheckedColumn.ColumnName].Text;
            if ("True".Equals(checkStringDel))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            //-----------------------------------------------------------
            // ����
            //-----------------------------------------------------------
            if (cell.Column.Key == this._dataClearDataTable.IsCheckedColumn.ColumnName)
            {
                this._dataClearAcs.SelectCheckbox(this._dataClearDataTable[cell.Row.Index].TableId, check);
            }
        }

        /// <summary>
        /// KeyDown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key�������ꂽ���ɔ������܂��B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009/06/26</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid uGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            int colIndex = uGrid.ActiveCell.Column.Index;
            string colKey = uGrid.ActiveCell.Column.Key;

            switch (e.KeyCode)
            {
                case Keys.Space:
                    //-----------------------------------------------------------
                    // ����
                    //-----------------------------------------------------------
                    if (colKey == this._dataClearDataTable.IsCheckedColumn.ColumnName)
                    {
                        bool check = !Convert.ToBoolean(this.uGrid_Details.Rows[rowIndex].Cells[colIndex].Value);
                        this._dataClearAcs.SelectCheckbox(this._dataClearDataTable[rowIndex].TableId, check);
                    }
                    break;
            }
        }

        /// <summary>
        /// Leave �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �O���b�h�A�N�e�B�u����Key��Leave���ɔ������܂��B</br>
        /// <br>Programmer  : ���w�q</br>
        /// <br>Date        : 2009/06/26</br>
        /// </remarks>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {
            this.ChangedGridCellUnSelect();
        }
        #endregion �� Control Event

        #region �� Public Methods
        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�񏉊��ݒ菈�����s��</br>
        /// <br>Programer  : ���w�q</br>
        /// <br>Date       : 2009.06.16</br>
        /// </remarks>
        public void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.uGrid_Details.DisplayLayout.Bands[0];
            if (band == null) return;

            int visiblePosition = 0;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in band.Columns)
            {
                //�uNo��v�ȊO�̑S�ẴZ����DiabledColor��ݒ肷��B
                if (col.Key != this._dataClearDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = 11F;

            // �\������
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // Fix�ݒ�
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Header.Fixed = true;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Header.Fixed = true;

            // �^�C�g���ݒ�
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Header.Caption = "No.";
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Header.Caption = "TableId";
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Header.Caption = "�����Ώ�";
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Header.Caption = "����";
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Header.Caption = "�����R�[�h";
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Header.Caption = "�����t�B�[���h";
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Header.Caption = "��������";

            // �^�C�g���̋l�ߕ�
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // ���͋��ݒ�
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �\�����ݒ�
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Width = 40;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Width = 80;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Width = 300;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Width = 50;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Width = 100;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Width = 100;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Width = 587;

            // �Œ��ݒ�
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            // �l�ߕ��ݒ�
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // Style�ݒ�
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            // ��\���ݒ�
            band.Columns[this._dataClearDataTable.RowNoColumn.ColumnName].Hidden = false;
            band.Columns[this._dataClearDataTable.TableIdColumn.ColumnName].Hidden = true;
            band.Columns[this._dataClearDataTable.TableNmColumn.ColumnName].Hidden = false;
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].Hidden = false;
            band.Columns[this._dataClearDataTable.ClearCodeColumn.ColumnName].Hidden = true;
            band.Columns[this._dataClearDataTable.FileIdColumn.ColumnName].Hidden = true;
            band.Columns[this._dataClearDataTable.ClearResultColumn.ColumnName].Hidden = false;

            // �����X�V
            band.Columns[this._dataClearDataTable.IsCheckedColumn.ColumnName].AutoEdit = true;
        }

        /// <summary>
        /// �O���b�h�̃`�F�b�N�{�b�N�X�̃t�H�[�J�X����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�̃`�F�b�N�{�b�N�X�̃t�H�[�J�X�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        public void ActivateCheckBox(Int32 rowNo)
        {
            // �S�Ă̍s�̃A���Z���N�g����
            this.ChangedGridCellUnSelect();

            this.uGrid_Details.Focus();

            // ��s�ڂ�I����Ԃɂ���
            this.uGrid_Details.Rows[rowNo].Cells[this._dataClearDataTable.IsCheckedColumn.ColumnName].Activate();

            return;
        }

        /// <summary>
        /// �S�Ă̍s�̃A���Z���N�g����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �S�Ă̍s�̃A���Z���N�g�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.17</br>
        /// </remarks>
        public void ChangedGridCellUnSelect()
        {
            this.uGrid_Details.BeginUpdate();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow gridRow in this.uGrid_Details.Rows)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridCell cell in gridRow.Cells)
                {
                    cell.Activated = false;
                    cell.Selected = false;
                }
            }
            this.uGrid_Details.EndUpdate();
        }
        #endregion �� Public Methods

        #region �� Private Methods
        /// <summary>
        /// Return�L�[�_�E������
        /// </summary>
        /// <param name="isPrevOrNext">true:�O�Z�� false:���Z��</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : Return�L�[�_�E���������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        internal bool ReturnKeyDown(bool isPrevOrNext)
        {
            if (this.uGrid_Details.ActiveCell == null) return false;

            return this.MovePrevNextAllowEditCell(false, isPrevOrNext);
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <param name="isPrevOrNext">true:�O�Z�� false:���Z��</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ��������s���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        private bool MovePrevNextAllowEditCell(bool activeCellCheck, bool isPrevOrNext)
        {
            bool moved = false;
            bool performActionResult = false;

            try
            {
                // �X�V�J�n�i�`��X�g�b�v�j
                this.uGrid_Details.BeginUpdate();

                if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
                {
                    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                }

                while (!moved)
                {
                    if (isPrevOrNext)
                    {
                        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);
                    }
                    else
                    {
                        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                    }
                    if (performActionResult)
                    {
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            moved = true;
                        }
                        else
                        {
                            moved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (moved)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // �X�V�I���i�`��ĊJ�j
                this.uGrid_Details.EndUpdate();
            }

            return performActionResult;
        }
        #endregion �� Private Methods

    }
}
