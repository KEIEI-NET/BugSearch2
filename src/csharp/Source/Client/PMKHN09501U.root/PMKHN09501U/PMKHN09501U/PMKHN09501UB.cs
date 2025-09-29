//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi�s�ݒ�
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
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

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �ԕi�s�ݒ薾�׃R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԕi�s�ݒ薾�ׂ��s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.04.20</br>
    /// </remarks>
    public partial class PMKHN09501UB : UserControl
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constroctors
        /// <summary>
        /// �ԕi�s�ݒ薾�ד��̓R���g���[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMKHN09501UB(PMKHN09501UA parentForm)
        {
            InitializeComponent();
            this._dataSet = new GoodsNotReturnDataSet();
            this._goodsNotReturnAcs = GoodsNotReturnAcs.GetInstance();
            this._goodsNotReturnDetailDataTable = this._goodsNotReturnAcs.GoodsNotReturnDetailDataTable;
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region ��Private Members

        private delegate void settingHandler(int row);

        /// <summary>�f�t�H���g�s�̊O�ϐݒ�</summary>
        Infragistics.Win.Appearance _defRowAppearance = new Infragistics.Win.Appearance();

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        private GoodsNotReturnDataSet _dataSet;
        private GoodsNotReturnDataSet.GoodsNotReturnDetailDataTable _goodsNotReturnDetailDataTable;
        private GoodsNotReturnAcs _goodsNotReturnAcs;
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color READONLY_COLOR = Color.WhiteSmoke;
        private static readonly Color ROWSTATUS_COPY_COLOR = Color.Pink;
        private static readonly Color ROWSTATUS_CUT_COLOR = Color.Gray;
        private static readonly Color REDUCTION_FONT_COLOR = Color.Green;
        private static readonly Color READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
        private static readonly Color ALLWAYS_CELL_COLOR = Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
        // �I���O���b�h�sBackColor
        private static readonly Color SELECTED_BACKCOLOR = Color.FromArgb(216, 235, 253);
        private static readonly Color SELECTED_BACKCOLOR2 = Color.FromArgb(101, 144, 218);

        double limitReturnNo = 0;
        double shipmentNo = 0;
        double returnNo = 0;
        #endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        # region ��Event

        /// <summary>
        /// �t�H�[�J�X�̕ω�
        /// </summary>
        /// <remarks>
        /// <br>Note       : Grid�̏œ_���ړ����鎞�A�t�H�[�J�X�̕ω����s���܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.01</br> 
        /// </remarks>
        internal event EventHandler GridKeyUpTopRow;

        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        /// <summary>
        /// ���[�h�C�x���g                                            
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                            
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ����[�h���ɔ������܂��B</br>      
        /// <br>Programmer : 杍^</br>                                  
        /// <br>Date       : 2009.04.20</br> 
        /// </remarks>
        private void PMKHN09501UB_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.DataSource = this._goodsNotReturnDetailDataTable;
            // �O���b�h�L�[�}�b�s���O�ݒ菈��
            this.MakeKeyMappingForGrid(this.uGrid_Details);
        }

        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="prevVal">���͒l</param>
        /// <param name="selstart">���͎n�l</param>
        /// <param name="sellength">���͒l���x</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        /// <remarks>						
        /// <br>Note		: ���l���̓`�F�b�N�������s���܂��B</br>				
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>
        private bool KeyPressNumCheck(char key, string prevVal, int selstart, int sellength)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key))
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (!Char.IsDigit(key))
            {
                return false;
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

            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > 8)
            {
                return false;
            }

            return true;
        }

        /// <summary>		
        /// Enter�L�[�̏���		
        /// </summary>		
        /// <param name="activeCell">�I���Z��</param>		
        /// <param name="mode">���[�h</param>		
        /// <remarks>		
        /// <br>Note		: Enter�L�[���N�b���N���鎞�A�������s���܂��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2008.11.26</br>
        /// </remarks>		
        private void EnterNextEditableCell(Infragistics.Win.UltraWinGrid.UltraGridCell activeCell, int mode)
        {
            int curRowIndex = activeCell.Row.Index;
            int curColIndex = activeCell.Column.Index;
            int rowCount = this.uGrid_Details.Rows.Count;
            int colCount = this.uGrid_Details.Rows[curRowIndex].Cells.Count;
            switch (mode)
            {
                case -1:
                    {
                        bool found = false;
                        for (int i = curRowIndex; i >= 0; i--)
                        {
                            int j = colCount - 1;
                            if (i == curRowIndex && curColIndex > 0)
                            {
                                j = curColIndex - 1;
                            }
                            Infragistics.Win.UltraWinGrid.UltraGridCell cell;
                            for (; j >= 0; j--)
                            {
                                cell = this.uGrid_Details.Rows[i].Cells[j];
                                if (cell.Activation == Activation.AllowEdit && cell.Column.CellActivation == Activation.AllowEdit
                                    && cell.CanEnterEditMode && !cell.Hidden && !cell.Column.Hidden)
                                {
                                    cell.Activated = true;
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        bool found = false;
                        for (int i = curRowIndex; i < rowCount; i++)
                        {
                            int j = 0;
                            if (i == curRowIndex)
                            {
                                j = curColIndex + 1;
                            }
                            Infragistics.Win.UltraWinGrid.UltraGridCell cell;
                            for (; j < colCount; j++)
                            {
                                cell = this.uGrid_Details.Rows[i].Cells[j];
                                if (cell.Activation == Activation.AllowEdit && cell.Column.CellActivation == Activation.AllowEdit
                                    && cell.CanEnterEditMode && !cell.Hidden && !cell.Column.Hidden)
                                {
                                    cell.Activated = true;
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                break;
                            }
                        }
                        break;
                    }
            }
        }


        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>						
        /// <br>Note		: �t�H�[�����[�h�C�x���g���s���܂��B</br>				
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>	
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.InitialSettingGridCol();
        }

        /// <summary>
        /// �ԕi�s�ݒ薾�׃N���A����
        /// </summary>
        internal void Clear()
        {
            // �ԕi�s�ݒ薾�׃N���A����
            this._goodsNotReturnDetailDataTable.Rows.Clear();
        }

        /// <summary>
        /// �O���b�h�Z���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>						
        /// <br>Note		: �O���b�h�Z���C�x���g���s���܂��B</br>				
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>	
        private void uGrid_Details_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell == null) return;
            int rowIndex = e.Cell.Row.Index;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName)
            {
                string limitNo = cell.Value.ToString().Trim();
                // �`�F�b�N����
                if (!string.IsNullOrEmpty(limitNo))
                {
                    bool inputFlg = true;
                    for (int i = 0; i < limitNo.Length; i++)
                    {
                        if (!char.IsNumber(limitNo, i))
                        {
                            inputFlg = false;
                            break;
                        }
                    }

                    if (!inputFlg)
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "�ԕi���������������͂��ĉ������B",
                           -1,
                           MessageBoxButtons.OK);

                           return;
                    }
                }
            }
        }

        /// <summary>						
        /// �O���b�h�L�[�ݒ菈��						
        /// </summary>						
        /// <param name="sender">�ݒ�Ώۂ̃O���b�h</param>		
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>						
        /// <br>Note		: �O���b�h�L�[�ݒ菈�����s���܂��B</br>				
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>	
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = cell.Row.Index;

            // ActiveCell�����ʂ̏ꍇ
            if (cell.Column.Key == this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(e.KeyChar, cell.Text, cell.SelStart, cell.SelLength))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        # endregion

        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        # region �� Control Event Methods
        /// <summary>						
        /// �O���b�h�L�[�}�b�s���O�ݒ菈��						
        /// </summary>						
        /// <param name="grid">�ݒ�Ώۂ̃O���b�h</param>						
        /// <remarks>						
        /// <br>Note		: �O���b�h�L�[�ɂ��A�}�b�s���O�ݒ菈�����s���܂��B</br>				
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>		
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;
            //----- ���L�[		
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŏ�i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŉ��i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- �O�ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- ���ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);
        }

        /// <summary>
        /// �O���b�h�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>						
        /// <br>Note		: �O���b�h�񏉊��ݒ菈�����s���܂��B</br>				
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.04.26</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                if (col.Key == this._goodsNotReturnDetailDataTable.UpdateTimeColumn.ColumnName
                    || col.Key == this._goodsNotReturnDetailDataTable.AcptAnOdrStatusColumn.ColumnName
                    || col.Key == this._goodsNotReturnDetailDataTable.SalesSlipDtlNumColumn.ColumnName)
                {
                    col.Hidden = true;
                }

                //�uNo��v�ȊO�̑S�ẴZ����DiabledColor��ݒ肷��B
                if (col.Key != this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            // �\�����ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].Width = 40;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ProductNoColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.GoodsNameColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ManufacturerColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ShipmentNoColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ReturnNoColumn.ColumnName].Width = 100;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].Width = 100;

            // �Œ��ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ProductNoColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.GoodsNameColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ManufacturerColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ShipmentNoColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ReturnNoColumn.ColumnName].Header.Fixed = true;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].Header.Fixed = true;

            // CellAppearance�ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ProductNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ManufacturerColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ShipmentNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ReturnNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // ���͋��ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ProductNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.GoodsNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ManufacturerColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ShipmentNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ReturnNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

            // �t�H�[�}�b�g
            string format = "#,##0;-#,##0;'0'";
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].Format = format;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ReturnNoColumn.ColumnName].Format = format;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ShipmentNoColumn.ColumnName].Format = format;
            // Style�ݒ�
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ProductNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.GoodsNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ManufacturerColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ShipmentNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.ReturnNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;

            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._goodsNotReturnDetailDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        /// <remarks>
        /// <br>Note       : �����͉\�Z���ړ����������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_Details.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

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
                performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);

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

            this.uGrid_Details.ResumeLayout();
            return performActionResult;
        }

        /// <summary>										
        /// �O���b�h�L�[�_�E���C�x���g										
        /// </summary>										
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>										
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>										
        /// <remarks>										
        /// <br>Note		: �O���b�h�L�[�_�E�����A�������s���܂��B</br>								
        /// <br>Programmer	: 杍^</br>									
        /// <br>Date		: 2009.05.26</br>								
        /// </remarks>										
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {										
            if (this.uGrid_Details.ActiveCell != null)										
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
                // Shift�L�[�̏ꍇ
                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_Details.ActiveCell = null;
                                this.uGrid_Details.ActiveRow = cell.Row;
                                this.uGrid_Details.Selected.Rows.Clear();
                                this.uGrid_Details.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Home:
                            {
                                if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                bool isMove = MoveNextAllowEditCell(false);
                                break;
                            }
                    }
                }
                // Alt�L�[�̏ꍇ
                else if (e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                // �|�b�v�A�b�v���j���[�c�[�����|�b�v�A�b�v�����B
                                break;
                            }
                    }
                }
                else
                {
                    // �ҏW���ł������ꍇ
                    if (cell.IsInEditMode)
                    {
                        // �Z���̃X�^�C���ɂĔ���
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            // �e�L�X�g�{�b�N�X�E�e�L�X�g�{�b�N�X(�{�^���t)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            if (this.uGrid_Details.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            if (this.uGrid_Details.ActiveCell.SelStart >= this.uGrid_Details.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        case Keys.Up:
                                            // ����`�[�ԍ��O���b�h
                                            //if (MoveNextAllowEditCell(true))
                                            //{
                                            //    //e.Handled = true;
                                            //}
                                            //else
                                            //{
                                            //    //e.NextCtrl = this.tce_SendAndReceKubun;
                                            //    this.uGrid_Details.Rows[0].Cells[6].Activate();
                                            //    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                            //}
                                            break;
                                    }
                                }
                                break;
                            // ��L�ȊO�̃X�^�C��
                            default:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            {
                                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                    }
                                    break;
                                }
                        }
                    }
                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                if ((this.uGrid_Details.ActiveCell != null) && (this.uGrid_Details.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                }
                                break;
                            }
                        case Keys.Enter:
                            {
                                EnterNextEditableCell(cell, 0);
                                break;
                            }
                        case Keys.Up:
                            {
                                if ((this.uGrid_Details.ActiveCell != null) && (!this.uGrid_Details.ActiveCell.DroppedDown))
                                {
                                    if (this.uGrid_Details.ActiveCell.Row.Index == 0)
                                    {
                                        if (this.GridKeyUpTopRow != null)
                                        {
                                            this.GridKeyUpTopRow(this, new EventArgs());
                                            e.Handled = true;
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        {
                            if ((this.uGrid_Details.ActiveRow != null))
                            {
                                if (this.uGrid_Details.ActiveRow.Index == 0)
                                {
                                    if (this.GridKeyUpTopRow != null)
                                    {
                                        this.GridKeyUpTopRow(this, new EventArgs());
                                        e.Handled = true;
                                    }
                                }
                            }
                            break;
                        }

                    case Keys.Delete:
                        {
                            // Del�L�[�̑���
                            break;
                        }
                }
            }
        }

        /// <summary>										
        /// �O���b�h�L�[�_�E���C�x���g										
        /// </summary>										
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>										
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>										
        /// <remarks>										
        /// <br>Note		: �O���b�h�L�[�_�E�����A�������s���܂��B</br>								
        /// <br>Programmer	: 杍^</br>									
        /// <br>Date		: 2009.05.26</br>								
        /// </remarks>	
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = cell.Row.Index;

            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName)
            {
                if (string.IsNullOrEmpty(Convert.ToString(cell.Value)))
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "�ԕi�������0�ȏ�̒l����͂��ĉ������B",
                       -1,
                       MessageBoxButtons.OK);
                    this._goodsNotReturnDetailDataTable[rowIndex].LimitReturnNo = limitReturnNo;
                    return;
                }
                double value = Convert.ToDouble(cell.Value);

                this._goodsNotReturnDetailDataTable[rowIndex].LimitReturnNo = value;

                // ���͕ԕi��������o�א��̏ꍇ�A�u�ԕi��������o�א��𒴂��Ă��܂��B�v�Ƃ������b�Z�[�W�_�C�A���O�iOK�̂݁j���\�������B
                if (value > shipmentNo)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "�ԕi��������o�א��𒴂��Ă��܂��B",
                       -1,
                       MessageBoxButtons.OK);
                    //this.uGrid_Details.Rows[rowIndex].Cells[6].Activated = true;
                    //this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    this._goodsNotReturnDetailDataTable[rowIndex].LimitReturnNo = limitReturnNo;
                    return;
                }
                // ���͕ԕi��������ԕi�ϐ��̏ꍇ�A�u�ԕi������͕ԕi�ϐ��ȏ�̒l����͂��ĉ������B�v�Ƃ������b�Z�[�W�_�C�A���O�iOK�̂݁j���\�������B
                if (value < returnNo)
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "�ԕi������͕ԕi�ϐ��ȏ�̒l����͂��ĉ������B",
                       -1,
                       MessageBoxButtons.OK);
                    this._goodsNotReturnDetailDataTable[rowIndex].LimitReturnNo = limitReturnNo;
                    return;
                }
                // ���͕ԕi�������0�̏ꍇ�A�u�ԕi�������0�ȏ�̒l����͂��ĉ������B�v�Ƃ������b�Z�[�W�_�C�A���O�iOK�̂݁j���\�������B
                if (value < 0)
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "�ԕi�������0�ȏ�̒l����͂��ĉ������B",
                       -1,
                       MessageBoxButtons.OK);
                    this._goodsNotReturnDetailDataTable[rowIndex].LimitReturnNo = limitReturnNo;
                    return;
                }
            }
        }
        /// <summary>
        /// �Z���̃f�[�^�`�F�b�N����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.05.20</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {

            if (this.uGrid_Details.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "�ԕi���������������͂��ĉ������B",
                           -1,
                           MessageBoxButtons.OK);
                        //editorBase.Value = 0;				// 0���Z�b�g
                        //this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // �ʏ����				
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            TMsgDisp.Show(
                               this,
                               emErrorLevel.ERR_LEVEL_INFO,
                               this.Name,
                               "�ԕi���������������͂��ĉ������B",
                               -1,
                               MessageBoxButtons.OK);
                            //editorBase.Value = 0;
                            //this.uGrid_Details.ActiveCell.Value = 0;


                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�	
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����

                    return;
                }
            }
        }

        /// <summary>										
        /// �O���b�h�L�[�_�E���C�x���g										
        /// </summary>										
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>										
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>										
        /// <remarks>										
        /// <br>Note		: �O���b�h�L�[�_�E�����A�������s���܂��B</br>								
        /// <br>Programmer	: 杍^</br>									
        /// <br>Date		: 2009.05.26</br>								
        /// </remarks>	
        private void uGrid_Details_BeforeEnterEditMode(object sender, CancelEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = cell.Row.Index;


            // ActiveCell���J�n���Ԃ̏ꍇ
            if (cell.Column.Key == this._goodsNotReturnDetailDataTable.LimitReturnNoColumn.ColumnName)
            {
                limitReturnNo = Convert.ToDouble(cell.Value);
                shipmentNo = Convert.ToDouble(this.uGrid_Details.Rows[rowIndex].Cells[4].Value);
                returnNo = Convert.ToDouble(this.uGrid_Details.Rows[rowIndex].Cells[5].Value);
            }
        }
        # endregion
    }
}
