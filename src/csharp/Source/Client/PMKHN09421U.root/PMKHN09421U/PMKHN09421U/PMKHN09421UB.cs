//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�U�[���i�E�����ꊇ�ݒ�
// �v���O�����T�v   : ���[�U�[���i�E�����𕡐����ꊇ�ŏC���E�o�^����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���[�U�[���i�E�����ꊇ�ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�U�[���i�E�����ꊇ�ݒ�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.03.27</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.05.21 men �V�K�쐬(DC.NS���痬�p)</br>
    /// </remarks>
    public partial class PMKHN09421UB : UserControl
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructors
        /// <summary>
        /// ��M�f�[�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMKHN09421UB()
        {
            InitializeComponent();

            _userPriceInputAcs = UserPriceInputAcs.GetInstance();
            _userPriceDataTable = this._userPriceInputAcs.UserPriceDataTable;
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private readonly Color DISABLE_COLOR = Color.Gainsboro;
        private readonly Color DISABLE_FONT_COLOR = Color.Black;
        private UserPriceInputAcs _userPriceInputAcs;
        private UserPriceDataSet.UserPriceDataTable _userPriceDataTable;

        // �� 2009.06.18 ���m add PVCS.209
        /// <summary>
        /// �t�H�[�J�X�ݒ�f���Q�[�g
        /// </summary>
        /// <param name="itemName">���ږ���</param>
        internal delegate void SettingFocusEventHandler(string itemName);

        /// <summary>�t�H�[�J�X�ݒ�C�x���g</summary>
        internal event SettingFocusEventHandler SetFocus;
        // �� 2009.06.18 ���m add

        # endregion




        // ===================================================================================== //
        // �v���C�x�[�g�E�C���^�[�i�����\�b�h
        // ===================================================================================== //
        # region Private Methods and Internal Methods
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �uNo��v�ȊO�̑S�ẴZ����DiabledColor��ݒ肷��B
                if (col.Key != this._userPriceDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Appearance.FontData.SizeInPoints = 11F;

            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = Color.White;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = Color.White;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellActivation = Activation.Disabled;

            // �\�����ݒ�
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].Width = 60;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsCdColumn.ColumnName].Width = 100;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsNmColumn.ColumnName].Width = 254;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsNoColumn.ColumnName].Width = 240;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.UserPriceColumn.ColumnName].Width = 100;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.PriceColumn.ColumnName].Width = 100;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StockPriceColumn.ColumnName].Width = 110;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StarFlgColumn.ColumnName].Width = 30;

            // CellAppearance�ݒ�
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsNmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.UserPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.PriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StockPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StarFlgColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;

            string FORMAT = "#,###,##0.00;-#,###,##0.00;''";
            string FORMAT1 = "00000";
            string FORMAT2 = "###,###,##0;-###,###,##0;''";
            string FORMAT3 = "#,###,##0;-#,###,##0;''";
            // ���͋��ݒ�
            // this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;// No
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsCdColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsNmColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.UserPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.PriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StockPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StarFlgColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

            // �t�H�[�}�b�g
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.BLGoodsCdColumn.ColumnName].Format = FORMAT1;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.UserPriceColumn.ColumnName].Format = FORMAT2;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.PriceColumn.ColumnName].Format = FORMAT3;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._userPriceDataTable.StockPriceColumn.ColumnName].Format = FORMAT;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMKHN09421UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Result.DataSource = this._userPriceDataTable;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Result.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;

            // ActiveCell���P���̏ꍇ
            if (cell.Column.Key == this._userPriceInputAcs.UserPriceDataTable.UserPriceColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
            else if (cell.Column.Key == this._userPriceInputAcs.UserPriceDataTable.StockPriceColumn.ColumnName)
            {
                 // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, true))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = _strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_KeyDown(object sender, KeyEventArgs e)
        {
            // �� 2009.06.18 ���m add PVCS.209

            UltraGrid uGrid = (UltraGrid)sender;

            if ((uGrid.Rows.Count == 0) ||
                ((uGrid.ActiveCell == null) && (uGrid.ActiveRow == null)))
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            this.SetFocus("tNedit_BLGoodsCode");
                            break;
                        }
                    case Keys.Down:
                    case Keys.Right:
                        {
                            this.SetFocus("tNedit_BLGoodsCode");
                            break;
                        }
                    case Keys.Left:
                        {
                            this.SetFocus("tNedit_BLGoodsCode");
                            break;
                        }
                }
                return;
            }

            int rowIndex;
            int columnIndex;
            string columnKey;

            if (uGrid.ActiveCell != null)
            {
                // �A�N�e�B�u�Z��
                rowIndex = uGrid.ActiveCell.Row.Index;
                columnIndex = uGrid.ActiveCell.Column.Index;
                columnKey = uGrid.ActiveCell.Column.Key;
            }
            else
            {
                // �A�N�e�B�u�s
                rowIndex = uGrid.ActiveRow.Index;
                columnIndex = 0;
                columnKey = uGrid.ActiveRow.Cells[columnIndex].Column.Key;
            }

            string nextFocusColumn;
            bool doActivate = false;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            e.Handled = true;
                            this.SetFocus("tNedit_BLGoodsCode");
                            if (this.uGrid_Result.ActiveCell != null)
                            {
                                this.uGrid_Result.ActiveCell.Activated = false;
                            }
                        }
                        else
                        {
                            if (uGrid.ActiveCell != null)
                            {
                                // �Z���A�N�e�B�u��DDL
                                if (uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                                {
                                    e.Handled = true;
                                    if (uGrid.ActiveCell.ValueListResolved.SelectedItemIndex != 0)
                                    {
                                        // �I�𒆂�ValueList���ŏ��łȂ���΃L�[�J�ڂ��Ȃ�
                                        uGrid.ActiveCell.ValueListResolved.SelectedItemIndex = uGrid.ActiveCell.ValueListResolved.SelectedItemIndex - 1;
                                        break;
                                    }
                                    else
                                    {
                                        for (int i = rowIndex - 1; i >= 0; i--)
                                        {
                                            if (uGrid.Rows[i].Cells[columnIndex].Activation == Activation.AllowEdit)
                                            {
                                                uGrid.Rows[i].Cells[columnIndex].Activate();
                                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                doActivate = true;
                                                break;
                                            }
                                        }

                                        if (!doActivate)
                                        {
                                            this.SetFocus("tNedit_BLGoodsCode");
                                            if (this.uGrid_Result.ActiveCell != null)
                                            {
                                                this.uGrid_Result.ActiveCell.Activated = false;
                                            }
                                        }

                                        break;
                                    }
                                }
                            }

                            if (uGrid.ActiveCell != null)
                            {
                                e.Handled = true;

                                for (int i = rowIndex; i >= 1; i--)
                                {
                                    // �\���s�T��
                                    if (!uGrid.Rows[i - 1].IsFilteredOut)
                                    {
                                        if (uGrid.Rows[i - 1].Cells[columnIndex].Activation == Activation.AllowEdit)
                                        {
                                            uGrid.Rows[i - 1].Cells[columnIndex].Activate();
                                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                        else
                                        {

                                            // �s�A�N�e�B�u
                                            uGrid.Rows[i - 1].Activate();
                                            uGrid.Rows[i - 1].Selected = true;
                                            doActivate = true;
                                            break;

                                        }
                                    }
                                }

                                if (!doActivate)
                                {
                                    this.SetFocus("tNedit_BLGoodsCode");
                                    if (this.uGrid_Result.ActiveCell != null)
                                    {
                                        this.uGrid_Result.ActiveCell.Activated = false;
                                    }
                                }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        if (rowIndex == uGrid.Rows.Count - 1)
                        {
                            e.Handled = true;
                            this.SetFocus("tEdit_SectionCodeAllowZero");
                            if (this.uGrid_Result.ActiveCell != null)
                            {
                                this.uGrid_Result.ActiveCell.Activated = false;
                            }
                        }
                        else
                        {
                            if (uGrid.ActiveCell != null)
                            {
                                if (uGrid.DisplayLayout.Bands[0].Columns[columnIndex].Style == Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList)
                                {
                                    e.Handled = true;
                                    if (uGrid.ActiveCell.ValueListResolved.SelectedItemIndex != uGrid.ActiveCell.ValueListResolved.ItemCount - 1)
                                    {
                                        // �I�𒆂�ValueList���ő�łȂ���΃L�[�J�ڂ��Ȃ�
                                        uGrid.ActiveCell.ValueListResolved.SelectedItemIndex = uGrid.ActiveCell.ValueListResolved.SelectedItemIndex + 1;
                                        break;
                                    }
                                    else
                                    {
                                        for (int i = rowIndex + 1; i < uGrid.Rows.Count; i++)
                                        {
                                            if (uGrid.Rows[i].Cells[columnIndex].Activation == Activation.AllowEdit)
                                            {
                                                uGrid.Rows[i].Cells[columnIndex].Activate();
                                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                                doActivate = true;
                                                break;
                                            }
                                        }

                                        if (!doActivate)
                                        {
                                            this.SetFocus("tEdit_SectionCodeAllowZero");
                                            if (this.uGrid_Result.ActiveCell != null)
                                            {
                                                this.uGrid_Result.ActiveCell.Activated = false;
                                            }
                                        }

                                        break;
                                    }
                                }
                            }

                            if (uGrid.ActiveCell != null)
                            {
                                e.Handled = true;

                                for (int i = rowIndex; i < uGrid.Rows.Count - 1; i++)
                                {
                                    // �\���s�T��
                                    if (!uGrid.Rows[i + 1].IsFilteredOut)
                                    {
                                        if (uGrid.Rows[i + 1].Cells[columnIndex].Activation == Activation.AllowEdit)
                                        {
                                            uGrid.Rows[i + 1].Cells[columnIndex].Activate();
                                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                            doActivate = true;
                                            break;
                                        }
                                        else
                                        {

                                            // �s�A�N�e�B�u
                                            uGrid.Rows[i + 1].Activate();
                                            uGrid.Rows[i + 1].Selected = true;
                                            doActivate = true;
                                            break;

                                        }
                                    }
                                }

                                if (!doActivate)
                                {
                                    this.SetFocus("tEdit_SectionCodeAllowZero");
                                    if (this.uGrid_Result.ActiveCell != null)
                                    {
                                        this.uGrid_Result.ActiveCell.Activated = false;
                                    }
                                }
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid.ActiveCell == null)
                        {
                            // �s�A�N�e�B�u
                            int activationColIndex;
                            int activationRowIndex;

                            // ����Shift+Tab�Ɠ���
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("tNedit_BLGoodsCode");
                                if (this.uGrid_Result.ActiveCell != null)
                                {
                                    this.uGrid_Result.ActiveCell.Activated = false;
                                }
                            }

                            break;
                        }

                        if (
                            (uGrid.ActiveCell.IsInEditMode)
                            &&
                            ((uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                            &&
                            (uGrid.ActiveCell.SelStart != 0)
                            )
                        {
                            break;
                        }
                        else
                        {
                            e.Handled = true;

                            int activationColIndex;
                            int activationRowIndex;

                            // ����Shift+Tab�Ɠ���
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("tNedit_BLGoodsCode");
                                if (this.uGrid_Result.ActiveCell != null)
                                {
                                    this.uGrid_Result.ActiveCell.Activated = false;
                                }
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (uGrid.ActiveCell == null)
                        {
                            // �s�A�N�e�B�u
                            int activationColIndex;
                            int activationRowIndex;

                            // �E��Tab�Ɠ���
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("tEdit_SectionCodeAllowZero");
                                if (this.uGrid_Result.ActiveCell != null)
                                {
                                    this.uGrid_Result.ActiveCell.Activated = false;
                                }
                            }
                            break;
                        }

                        if (
                            (uGrid.ActiveCell.IsInEditMode)
                            &&
                            ((uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Default) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Edit) ||
                                (uGrid.ActiveCell.Column.Style == Infragistics.Win.UltraWinGrid.ColumnStyle.Date))
                            &&
                            (uGrid.ActiveCell.SelStart < uGrid.ActiveCell.Text.Length)
                            )
                        {
                            break;
                        }
                        else
                        {
                            e.Handled = true;

                            int activationColIndex;
                            int activationRowIndex;

                            // �E��Tab�Ɠ���
                            nextFocusColumn = this.GetNextFocusColumnKey(columnIndex, rowIndex, false, out activationColIndex, out activationRowIndex);

                            if (nextFocusColumn != string.Empty)
                            {
                                uGrid.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.SetFocus("tEdit_SectionCodeAllowZero");
                                if (this.uGrid_Result.ActiveCell != null)
                                {
                                    this.uGrid_Result.ActiveCell.Activated = false;
                                }
                            }
                        }

                        break;
                    }
            }

            // �� 2009.06.18 ���m add
        }

        /// <summary>
        /// ���̓��͉\���Key���擾����
        /// </summary>
        /// <param name="colIndex">�`�F�b�N�J�n��index�AActivation�\���Ԃ�</param>
        /// <param name="rowIndex">�`�F�b�N�J�n�sindex�AActivation�\�s��Ԃ�</param>
        /// <param name="isShift">true:�V�t�g���� false:�V�t�g�Ȃ�</param>
        /// <param name="ActivationColIndex">�s�ԍ�</param>
        /// <param name="ActivationRowIndex">�ԍ�</param>
        /// <returns>Activation�\��̃L�[�B�Ȃ��ꍇ��string.Empty</returns>
        internal string GetNextFocusColumnKey(int colIndex, int rowIndex, bool isShift, out int ActivationColIndex, out int ActivationRowIndex)
        {
            ActivationColIndex = 0;
            ActivationRowIndex = 0;

            // �w���̎��̓��͉\�������
            if (!isShift)
            {
                // �V�t�g��
                for (int j = rowIndex; j < this.uGrid_Result.Rows.Count; j++)
                {
                    if (!this.uGrid_Result.Rows[j].IsFilteredOut) // ADD 2009/03/06
                    {
                        if (j == rowIndex)
                        {
                            // �w��s�͎w��J�����������`�F�b�N
                            for (int i = colIndex + 1; i < this.uGrid_Result.DisplayLayout.Bands[0].Columns.Count; i++)
                            {
                                if (this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Result.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // ���͉\�s��ColumnKey���擾
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                        else
                        {
                            // ���s�ȍ~�̓J���������Ƀ`�F�b�N
                            for (int i = 0; i < this.uGrid_Result.DisplayLayout.Bands[0].Columns.Count; i++)
                            {
                                if (this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Result.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // ���͉\�s��ColumnKey���擾
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // �V�t�g����
                for (int j = rowIndex; j >= 0; j--)
                {
                    if (!this.uGrid_Result.Rows[j].IsFilteredOut) // ADD 2009/03/06
                    {
                        if (j == rowIndex)
                        {
                            for (int i = colIndex - 1; i >= 0; i--)
                            {
                                if (this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Result.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // ���͉\�s��ColumnKey���擾
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                        else
                        {
                            for (int i = this.uGrid_Result.DisplayLayout.Bands[0].Columns.Count - 1; i >= 0; i--)
                            {

                                if (this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].CellActivation == Activation.AllowEdit
                                    && this.uGrid_Result.Rows[j].Cells[i].Activation == Activation.AllowEdit
                                    && this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Hidden == false)
                                {
                                    // ���͉\�s��ColumnKey���擾
                                    ActivationColIndex = i;
                                    ActivationRowIndex = j;
                                    return this.uGrid_Result.DisplayLayout.Bands[0].Columns[i].Key;
                                }
                            }
                        }
                    }
                }
            }


            return string.Empty;
        }


        /// <summary>
        /// �O���b�h�V�t�g�^�u����
        /// </summary>
        /// <param name="e">�C�x���g�n���h��</param>
        internal void SetGridShiftTabFocus(ref ChangeFocusEventArgs e)
        {
            // ���t�H�[�J�X��J������
            string nextFocusColumn;
            int activationColIndex;
            int activationRowIndex;

            if (this.uGrid_Result.ActiveCell == null)
            {
                // �A�N�e�B�u�Ȃ� �܂��� �s�A�N�e�B�u
                e.NextCtrl = null;
                this.uGrid_Result.Focus();

                int colIndex = this.uGrid_Result.DisplayLayout.Bands[0].Columns.Count - 1;
                int rowIndex = this.uGrid_Result.Rows.Count - 1;

                if (this.uGrid_Result.ActiveRow != null)
                {
                    colIndex = 0;
                    rowIndex = uGrid_Result.ActiveRow.Index;
                }

                // 1�s�ڂ̍Ō�̓��͉\�s�Ƀt�H�[�J�X
                nextFocusColumn = this.GetNextFocusColumnKey(colIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_Result.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    this.SetFocus("tNedit_BLGoodsCode");
                    this.uGrid_Result.ActiveCell.Activated = false;
                }

                return;
            }
            else
            {
                // �Z���A�N�e�B�u
                int rowIndex = this.uGrid_Result.ActiveCell.Row.Index;
                int columnIndex = this.uGrid_Result.ActiveCell.Column.Index;

                // �O���b�h�E�o���p�̃R���g���[����ێ�
                e.NextCtrl = null;
                this.uGrid_Result.PerformAction(UltraGridAction.ExitEditMode);

                this.uGrid_Result.Focus();

                // ���Z���擾
                nextFocusColumn = GetNextFocusColumnKey(columnIndex, rowIndex, true, out activationColIndex, out activationRowIndex);

                if (nextFocusColumn != string.Empty)
                {
                    this.uGrid_Result.Rows[activationRowIndex].Cells[nextFocusColumn].Activate();
                    this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
                }
                else
                {
                    if (this._userPriceInputAcs.UserPriceData.BLGoodsCode != 0)
                    {
                        this.SetFocus("tNedit_BLGoodsCode");
                    }
                    else
                    {
                        this.SetFocus("BLGoodsGuide_Button");
                    }
                    if (this.uGrid_Result.ActiveCell != null)
                    {
                        this.uGrid_Result.ActiveCell.Activated = false;
                    }
                }
            }
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        public bool ReturnKeyDown()
        {
            return MoveNextAllowEditCell(false);
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {

            this.uGrid_Result.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Result.ActiveCell != null))
            {
                if ((!this.uGrid_Result.ActiveCell.Column.Hidden) &&
                    (this.uGrid_Result.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Result.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {

                performActionResult = this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                //performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if ((this.uGrid_Result.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Result.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                this.uGrid_Result.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_Result.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// �O���b�h�ݒ�
        /// </summary>
        public void SettingGrid()
        {
            UltraGridRow dr;

            for (int i = 0; i < this.uGrid_Result.Rows.Count; i++)
            {
                dr = this.uGrid_Result.Rows[i];

                this.SetGridColorRow(dr);
            }
        }


        /// <summary>
        /// BeforeCellDeactivate �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note        : �ҏW���[�h���I���������ɔ������܂��B</br>
        /// <br>Programmer  : ���M</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void uGrid_Result_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            UltraGridRow dr;

            for (int i = 0; i < this.uGrid_Result.Rows.Count; i++)
            {
                dr = this.uGrid_Result.Rows[i];

                this.SetGridColorRow(dr);
            }
        }

        /// <summary>
        /// �e�f�[�^�̏�Ԃɉ������w�i�F��ݒ�
        /// </summary>
        /// <remarks>
        /// <br>�X�V�s�F��</br>
        /// <br>�݌ɓo�^����Ă��鏤�i�F�s���N</br>
        /// </remarks>
        private void SetGridColorRow(UltraGridRow dr)
        {
            DataRow originalDr = this._userPriceInputAcs.UserPriceCopyDataTable.Select(
                this._userPriceInputAcs.UserPriceCopyDataTable.RowNoColumn.ColumnName + " ='"
                + dr.Cells[0].Value.ToString() + "'")[0];

            if (originalDr != null)
            {
                // ���[�U�[���i
                if (dr.Cells[4].Value.ToString() != originalDr[4].ToString())
                {
                    dr.Cells[4].Appearance.BackColor = Color.Red;
                    dr.Cells[4].Appearance.BackColor2 = Color.Red;
                    dr.Cells[4].Appearance.BackColorDisabled = Color.Red;
                    dr.Cells[4].Appearance.BackColorDisabled2 = Color.Red;
                }
                else
                {
                    dr.Cells[4].Appearance.BackColor = Color.Empty;
                    dr.Cells[4].Appearance.BackColor2 = Color.Empty;
                    dr.Cells[4].Appearance.BackColorDisabled = Color.Empty;
                    dr.Cells[4].Appearance.BackColorDisabled2 = Color.Empty;
                }

                // �d������
                if (dr.Cells[6].Value.ToString() != originalDr[6].ToString())
                {
                    dr.Cells[6].Appearance.BackColor = Color.Red;
                    dr.Cells[6].Appearance.BackColor2 = Color.Red;
                    dr.Cells[6].Appearance.BackColorDisabled = Color.Red;
                    dr.Cells[6].Appearance.BackColorDisabled2 = Color.Red;
                }
                else
                {
                    if ("��".Equals(dr.Cells[7].Value.ToString()))
                    {
                        dr.Cells[6].Appearance.BackColor = Color.Empty;
                        dr.Cells[6].Appearance.BackColor2 = Color.Empty;
                        dr.Cells[6].Appearance.BackColorDisabled = Color.Empty;
                        dr.Cells[6].Appearance.BackColorDisabled2 = Color.Empty;
                    }
                    else
                    {
                        dr.Cells[6].Appearance.BackColor = Color.Lime;
                        dr.Cells[6].Appearance.BackColor2 = Color.Lime;
                        dr.Cells[6].Appearance.BackColorDisabled = Color.Lime;
                        dr.Cells[6].Appearance.BackColorDisabled2 = Color.Lime;
                    }
                }
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Result.ActiveCell != null)
            {
                if ((this.uGrid_Result.ActiveCell.Column.DataType == typeof(Double)))
                {

                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Result.ActiveCell.EditorResolved;

                    editorBase.Value = 0;
                    this.uGrid_Result.ActiveCell.Value = 0;
                }

                e.RaiseErrorEvent = false;	
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Result.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;

            if (cell == null) return;
            int rowIndex = cell.Row.Index;

            if (cell.Value is DBNull)
            {
                if ((cell.Column.DataType == typeof(Int32)) ||
                    (cell.Column.DataType == typeof(Int64)))
                {
                    cell.Value = 0;
                }
                else if (cell.Column.DataType == typeof(double))
                {
                    cell.Value = 0.0;
                }
                else if (cell.Column.DataType == typeof(string))
                {
                    cell.Value = "";
                }
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMKHN09421UB_Leave(object sender, EventArgs e)
        {
            this.uGrid_Result.ActiveCell = null;
            this.uGrid_Result.ActiveRow = null;
            this.uGrid_Result.Selected.Rows.Clear();
        }
        #endregion
    }
}
