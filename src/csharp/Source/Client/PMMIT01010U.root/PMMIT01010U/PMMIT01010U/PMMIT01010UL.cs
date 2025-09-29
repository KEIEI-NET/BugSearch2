using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �������� �����I�𖾍ד��̓R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������ς�UOE�����ł̖��ד��͂��s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2008.10.17</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.10.17 men �V�K�쐬</br>
    /// </remarks>
    public partial class PMMIT01010UL : UserControl
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructor

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="estimateInputOrderSelectAcs">�������ϔ����I���A�N�Z�X�N���X</param>
        public PMMIT01010UL(EstimateInputOrderSelectAcs estimateInputOrderSelectAcs)
        {
            InitializeComponent();
            this._estimateInputInitDataAcs = EstimateInputInitDataAcs.GetInstance();
            this._estimateInputOrderSelectAcs = estimateInputOrderSelectAcs;
            this._imageList16 = IconResourceManagement.ImageList16;

            this._orderCancelButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_Main.Tools["ButtonTool_OrderCancel"];
        }

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region ��Private Members

        private ImageList _imageList16 = null;									// �C���[�W���X�g
        //private DataTable _dataTable;
        //private DataView _detailView;
        private int _supplierCd;
        private UOESupplier _uOESupplier;

        private Int32 _beforeInt32Value = 0;
        private string _beforeStringValue = "";

        private bool _afterCellUpdateCancel;
        private bool _beforeCellUpdateCancel;

        private EstimateInputInitDataAcs _estimateInputInitDataAcs;
        private EstimateInputOrderSelectAcs _estimateInputOrderSelectAcs;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _orderCancelButton;

        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region ��Properties

        /// <summary>�d����R�[�h</summary>
        public int SupplierCd
        {
            set 
            {                 
                _supplierCd = value;
                //this.SettingFilter();
            }
        }

        /// <summary>������}�X�^�I�u�W�F�N�g</summary>
        public UOESupplier UOESupplier
        {
            set
            {
                _uOESupplier = value;
            }
        }

        #endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region ��Delegate

        /// <summary>
        /// ���׃f�[�^�ύX�f���Q�[�g
        /// </summary>
        /// <param name="supplierCd">�d����R�[�h</param>
        internal delegate void DetailDataChangedEventHandler(int supplierCd);

        #endregion


        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region ��Events
        /// <summary>�O���b�h�ŏ�ʍs�L�[�_�E���C�x���g</summary>
        internal event EventHandler GridKeyDownTopRow;

        /// <summary>���׏��ύX�C�x���g</summary>
        internal DetailDataChangedEventHandler DetailDataChanged; 
        #endregion


        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods

        /// <summary>
        /// ���׃f�[�^�ύX�C�x���g�R�[������
        /// </summary>
        private void DetailDataChangedCall()
        {
            if (this.DetailDataChanged != null)
            {
                this.DetailDataChanged(this._supplierCd);
            }
        }

        /// <summary>
        /// Return�L�[�_�E������
        /// </summary>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        internal bool ReturnKeyDown()
        {
            if (this.uGrid_Details.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            int rowIndex = cell.Row.Index;

            try
            {
                this.uGrid_Details.SuspendLayout();
                this.uGrid_Details.BeginUpdate();

                bool canMove = true;

                // �Z���ҏW���[�h�̏ꍇ
                if (cell.IsInEditMode)
                {
                    string beforeCellKey = cell.Column.Key;

                    // �Z�����X�V����
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                    // ActiveCell���ύX���Ă��Ȃ��ꍇ��NextCell���擾����
                    if (this.uGrid_Details.ActiveCell.Column.Key == beforeCellKey)
                    {
                        // BeforeCellUpdate�ŃL�����Z���t���O�������Ă���ꍇ�̓Z���ړ�����
                        if (this._beforeCellUpdateCancel)
                        {
                            this._beforeCellUpdateCancel = false;
                        }
                        // AfterCellUpdate�ŃL�����Z���t���O�������Ă���ꍇ�̓Z���ړ�����
                        else if (this._afterCellUpdateCancel)
                        {
                            this._afterCellUpdateCancel = false;
                        }
                        else
                        {
                            canMove = this.MoveReturnCell();
                        }
                    }
                }
                else
                {
                    // �����͉\�Z���ړ�����
                    canMove = this.MoveReturnCell();
                }

                if (!canMove)
                {
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[rowIndex].Cells[cell.Column.Key];
                    this.uGrid_Details.Rows[rowIndex].Cells[cell.Column.Key].Selected = true; // �ҏW�s���ڂ̃t�H�[�J�X�J���[�Ή�
                    this.uGrid_Details.ActiveRow = this.uGrid_Details.Rows[rowIndex];
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                return canMove;
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
                this.uGrid_Details.ResumeLayout();
            }
        }

        /// <summary>
        /// Return�L�[�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:���ړ���Z�o���s��Ȃ�</param>
        /// <returns></returns>
        internal bool MoveReturnCell()
        {
            return MoveNextAllowEditCell(false);
        }


        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_Details.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if (( activeCellCheck ) && ( this.uGrid_Details.ActiveCell != null ))
            {
                if (( !this.uGrid_Details.ActiveCell.Column.Hidden ) &&
                    ( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) &&
                    ( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                //if (this.uGrid_Details.ActiveCell != null)
                //{
                //    int editMode = (int)this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Cells[this._stockDetailDataTable.EditStatusColumn.ColumnName].Value;

                //    if (( editMode == StockSlipInputAcs.ctEDITSTATUS_AllDisable ) || ( editMode == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly ))
                //    {
                //        performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);

                //        if (( performActionResult ) && ( this.uGrid_Details.ActiveRow != null ))
                //        {
                //            int index = this.uGrid_Details.ActiveRow.Index;

                //            if (!( this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._stockDetailDataTable.GoodsCodeColumn.ColumnName].Hidden ))
                //            {
                //                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._stockDetailDataTable.GoodsCodeColumn.ColumnName];
                //            }
                //            else
                //            {
                //                this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[index].Cells[this._stockDetailDataTable.GoodsNameColumn.ColumnName];
                //            }

                //            // �ċA����
                //            this.MoveNextAllowEditCell(true);

                //            return true;
                //        }
                //    }
                //}

                performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                //performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if (( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) &&
                        ( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
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
                if (( key != '.' ) && ( key != '-' ))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - ( selstart + sellength ));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if (( minusFlg == false ) || ( selstart > 0 ) || ( _strResult.IndexOf('-') != -1 ))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if (( priod <= 0 ) || ( _strResult.IndexOf('.') != -1 ))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - ( selstart + sellength ));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > ( keta + 1 ))
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
                int _Rketa = ( _strResult[0] == '-' ) ? keta - priod : keta - priod - 1;
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
        /// �O���b�h�L�[�}�b�s���O�ݒ菈��
        /// </summary>
        /// <param name="ultraGrid">�ݒ�Ώۂ̃O���b�h</param>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid)
        {
            Infragistics.Win.UltraWinGrid.GridKeyActionMapping enterMap;

            //----- Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

            //----- Shift + Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.uGrid_Details.KeyActionMappings.Add(enterMap);

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
        /// ���׃O���b�h�ݒ菈��
        /// </summary>
        internal void SettingGrid()
        {
            try
            {
                // �`����ꎞ��~
                this.uGrid_Details.BeginUpdate();

                // �`�悪�K�v�Ȗ��׌������擾����B
                int cnt = this.uGrid_Details.Rows.Count;

                // �e�s���Ƃ̐ݒ�
                for (int i = 0; i < cnt; i++)
                {
                    this.SettingGridRow(i);
                }

                if (this.uGrid_Details.ActiveCell != null)
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // �`����J�n
                this.uGrid_Details.EndUpdate();
            }
        }

        /// <summary>
        /// ���׃O���b�h�E�s�P�ʂł̃Z���ݒ�
        /// </summary>
        /// <param name="rowIndex">�Ώۍs�C���f�b�N�X</param>
        /// <param name="stockSlip">�d���f�[�^�N���X�I�u�W�F�N�g</param>
        private void SettingGridRow(int rowIndex)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // �w��s�̑S�Ă̗�ɑ΂��Đݒ���s���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �Z�������擾
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.Rows[rowIndex].Cells[col];
                if (cell == null) continue;

                cell.Row.Hidden = false;

                // �A���_�[���C����S�ẴZ���ɑ΂��Ĕ�\���Ƃ���
                cell.Appearance.FontData.Underline = Infragistics.Win.DefaultableBoolean.False;

                cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                // BO�R�[�h���擾
                string boCode = (string)this.uGrid_Details.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Value;

                // �q�ɃR�[�h���擾
                string warehouseCode = (string)this.uGrid_Details.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].Value;

                #region �Z���w�i�F�ύX

                if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode)
                {
                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                }
                else if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt)
                {
                    cell.Activation = ( boCode == "*" ) ? Infragistics.Win.UltraWinGrid.Activation.NoEdit : Infragistics.Win.UltraWinGrid.Activation.AllowEdit;

                    if (cell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                    {
                    }
                }
                else if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt)
                {
                    if (string.IsNullOrEmpty(warehouseCode))
                    {
                        cell.Appearance.ForeColor = Color.Transparent;
                    }
                    else
                    {
                        cell.Appearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.CellAppearance.ForeColor;
                    }
                }
                #endregion
            }
        }

        #region Control Events

        /// <summary>
        /// ���[�U�[�R���g���[�� Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PMMIT01010UL_Load(object sender, EventArgs e)
        {
            //this.uGrid_Details.DataSource = this._detailView;
            this.uGrid_Details.DataSource = this._estimateInputOrderSelectAcs.DetailView;
            this.tToolbarsManager_Main.ImageListSmall = this._imageList16;
            //this._orderCancelButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.can;

            // �O���b�h�L�[�}�b�s���O�ݒ菈��
            this.MakeKeyMappingForGrid(this.uGrid_Details);

            this.SettingGrid();
        }

        #region �O���b�h�֘A
        /// <summary>
        /// �O���b�h InitializeLayout�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            string moneyFormat = "#,##0;-#,##0;''";
            string decimalFormat_Zero = "#,##0.00;-#,##0.00;'0'";

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
                column.Header.Fixed = false;
                //���͋��ݒ�
                //column.AutoEdit = false;
            }

            int visiblePosition = 1;
            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------
            #region �J�������̐ݒ�

            // BO
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;

            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].TabStop = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].MaxLength = 4;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Header.Caption = "��";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Width = 40;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_No].Header.Fixed = true;

            // BO
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].MaxLength = 4;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Header.Caption = "BO";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Width = 40;

            // ������
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Format = moneyFormat;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Header.Caption = "������";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Width = 70;

            // �i��

            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsName].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsName].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsName].Header.Caption = "�i��";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsName].Width = 200;

            // �i��
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsNo].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsNo].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsNo].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsNo].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsNo].Header.Caption = "�i��";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_GoodsNo].Width = 200;

            // �q��
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].Header.Caption = "�q��";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_WarehouseCode].Width = 60;

            // ���݌ɐ�
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].Hidden = false;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].Header.VisiblePosition = visiblePosition++;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].Format = decimalFormat_Zero;
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].Header.Caption = "���݌ɐ�";
            Columns[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_ShipmentPosCnt].Width = 80;


            #endregion

            // �Œ���؂���ݒ�
            this.uGrid_Details.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;

            this.uGrid_Details.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
        }

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            //// �Z���A�N�e�B�u���{�^���L�������R���g���[������
            //this.ActiveCellButtonEnabledControl(cell.Row.Index, cell.Column.Key);

            this._beforeCellUpdateCancel = false;
            this._afterCellUpdateCancel = false;
        }

        /// <summary>
        /// �O���b�h�Z���A�b�v�f�[�g��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>        
        private void uGrid_Details_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            int rowIndex = e.Cell.Row.Index;

            if (e.Cell.Value is DBNull)
            {
                this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;
                this.uGrid_Details.BeforeCellUpdate -= this.uGrid_Details_BeforeCellUpdate;
                if (( e.Cell.Column.DataType == typeof(Int32) ) ||
                    ( e.Cell.Column.DataType == typeof(Int64) ) ||
                    ( e.Cell.Column.DataType == typeof(double) ))
                {
                    e.Cell.Value = 0;
                }
                else if (e.Cell.Column.DataType == typeof(string))
                {
                    e.Cell.Value = string.Empty;
                }
                this.uGrid_Details.BeforeCellUpdate += this.uGrid_Details_BeforeCellUpdate;
                this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
            }

            Guid dtlRelationGuid = (Guid)this.uGrid_Details.Rows[cell.Row.Index].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_DtlRelationGuid].Value;

            // ������
            if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt)
			{
                int orderCnt = TStrConv.StrToIntDef(e.Cell.Value.ToString(), 0);

                if (orderCnt == 0)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�����������͂���Ă��܂���B",
                        -1,
                        MessageBoxButtons.OK);

                    this.uGrid_Details.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt].Value = this._beforeInt32Value;

                    this._afterCellUpdateCancel = true;
                }
                else
                {
                    this.DetailDataChangedCall();
                }
			}
            // BO�R�[�h
            else if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode)
            {
                string boCode = cell.Value.ToString();
                string boCodeName = this._estimateInputInitDataAcs.GetName_FromUOEGuideName(EstimateInputInitDataAcs.ctUOEGuideDivCd_BoCode, this._uOESupplier.UOESupplierCd, boCode);

                if (boCode == "*")
                {
                    this._estimateInputOrderSelectAcs.DetailOrderCancel(dtlRelationGuid);
                    this.DetailDataChanged(this._supplierCd);
                }
                else if (!this._estimateInputOrderSelectAcs.ChackCanOrder(dtlRelationGuid))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�����ł��Ȃ����[�J�[�̕��i�ł��B",
                        -1,
                        MessageBoxButtons.OK);
                    this.uGrid_Details.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Value = this._beforeStringValue;

                    this._afterCellUpdateCancel = true;
                }

                else if (string.IsNullOrEmpty(boCodeName))
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "�Y������a�n�R�[�h�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK);
                    this._afterCellUpdateCancel = true;

                    this.uGrid_Details.Rows[rowIndex].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode].Value = this._beforeStringValue;
                }
                else
                {
                    // "*"����ύX���ꂽ�ꍇ�͔������̏����l��\��
                    if (this._beforeStringValue == "*")
                    {
                        this._estimateInputOrderSelectAcs.DetailSettingDefaultOrderCnt(dtlRelationGuid);
                    }
                }
                this.SettingGridRow(rowIndex);
                this.DetailDataChangedCall();
            }
        }

        /// <summary>
        /// Grid�A�N�V����������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_AfterPerformAction(object sender, Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs e)
        {
            switch (e.UltraGridAction)
            {
                case Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell:
                case Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell:

                    // �A�N�e�B�u�ȃZ�������邩�H�܂��͕ҏW�\�Z�����H
                    if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) && ( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                    {
                        // �A�N�e�B�u�Z���̃X�^�C�����擾
                        switch (this.uGrid_Details.ActiveCell.StyleResolved)
                        {
                            // �G�f�B�b�g�n�X�^�C��
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // �ҏW���[�h�ɂ���H
                                    if (this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!( this.uGrid_Details.ActiveCell.Value is System.DBNull ))
                                        {
                                            // �S�I����Ԃɂ���B
                                            this.uGrid_Details.ActiveCell.SelStart = 0;
                                            this.uGrid_Details.ActiveCell.SelLength = this.uGrid_Details.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// �O���b�h�s�A�N�e�B�u�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_Details.ActiveRow;
        }

        /// <summary>
        /// �O���b�h�Z���A�N�e�B�u���O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {
            // IME���N�����Ȃ�
            this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;
        }

        /// <summary>
        /// �O���b�h�Z����A�N�e�B�u���O�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
        }

        /// <summary>
        /// �O���b�h�Z���A�b�v�f�[�g�O�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            if (e.Cell == null) return;

            if (( this._uOESupplier == null ) || ( this._uOESupplier.SupplierCd == 0 ))
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "�����悪���͂���Ă��܂���",
                    -1,
                    MessageBoxButtons.OK);
                this._beforeCellUpdateCancel = true;
                e.Cancel = true;
                return;
            }

            this._beforeCellUpdateCancel = false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            this._beforeStringValue = string.Empty;
            this._beforeInt32Value = 0;

            if (this._estimateInputOrderSelectAcs.DetailTable.Columns.Contains(cell.Column.Key))
            {
                if (this._estimateInputOrderSelectAcs.DetailTable.Columns[cell.Column.Key].DataType == typeof(System.String))
                {
                    this._beforeStringValue = ( e.Cell.Value is DBNull ) ? string.Empty : e.Cell.Value.ToString();
                }
                else if (this._estimateInputOrderSelectAcs.DetailTable.Columns[cell.Column.Key].DataType == typeof(System.Int32))
                {
                    this._beforeInt32Value = ( e.Cell.Value is DBNull ) ? 0 : Convert.ToInt32(e.Cell.Value);
                }
            }
        }


        /// <summary>
        /// �O���b�h�f�[�^�G���[�����C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if (( this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32) ) ||
                    ( this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64) ) ||
                    ( this.uGrid_Details.ActiveCell.Column.DataType == typeof(double) ))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���
                    if (string.IsNullOrEmpty(editorBase.CurrentEditText.Trim()))
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�
                    else if (( editorBase.CurrentEditText.Trim() == "-" ) ||
                        ( editorBase.CurrentEditText.Trim() == "." ) ||
                        ( editorBase.CurrentEditText.Trim() == "-." ))
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_Details.ActiveCell.Value = 0;
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
                            editorBase.Value = 0;
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
            }
        }

        /// <summary>
        /// �O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

                if (e.KeyCode == Keys.Escape)
                {

                    // ���׃O���b�h�Z���ݒ菈��
                    this.SettingGrid();
                }

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
                                if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.IsInEditMode ))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                    this.MoveNextAllowEditCell(true);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.IsInEditMode ))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                }
                                break;
                            }
                    }
                }
                else if (e.Alt)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                if (( cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown ) &&
                                    ( cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList ) &&
                                    ( cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate ))
                                {
                                    ( (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"] ).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_Details);
                                }

                                break;
                            }
                    }
                }
                else if (e.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Home:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                e.Handled = true;
                                break;
                            }
                        case Keys.End:
                            {
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
                                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                e.Handled = true;
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
                                    }
                                    break;
                                }
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
                                if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.IsInEditMode ))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                if (( this.uGrid_Details.ActiveCell != null ) && ( this.uGrid_Details.ActiveCell.IsInEditMode ))
                                {
                                    //
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.Up:
                            {
                                if (( this.uGrid_Details.ActiveCell != null ) && ( !this.uGrid_Details.ActiveCell.DroppedDown ))
                                {
                                    if (this.uGrid_Details.ActiveCell.Row.Index == 0)
                                    {
                                        if (this.GridKeyDownTopRow != null)
                                        {
                                            this.GridKeyDownTopRow(this, new EventArgs());
                                            e.Handled = true;
                                        }
                                    }
                                }

                                break;
                            }
                        case Keys.Down:
                            {
                                if (this.uGrid_Details.ActiveCell.Row.Index == this.uGrid_Details.Rows.Count - 1)
                                {
                                    if (e.KeyCode == Keys.Down)
                                    {
                                        //if (this.GridKeyDownButtomRow != null)
                                        //{
                                        //    this.GridKeyDownButtomRow(this, new EventArgs());
                                        //    e.Handled = true;
                                        //}
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
                    case Keys.Delete:
                        {
                            //this.uButton_RowDelete_Click(this.uButton_RowDelete, new EventArgs());
                            break;
                        }
                }

                if (this.uGrid_Details.ActiveRow.Index == 0)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        if (this.GridKeyDownTopRow != null)
                        {
                            this.GridKeyDownTopRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                }
                else if (this.uGrid_Details.ActiveRow.Index == this.uGrid_Details.Rows.Count - 1)
                {
                    //if (e.KeyCode == Keys.Down)
                    //{
                    //    if (this.GridKeyDownButtomRow != null)
                    //    {
                    //        this.GridKeyDownButtomRow(this, new EventArgs());
                    //        e.Handled = true;
                    //    }
                    //}
                }
            }
        }


        /// <summary>
        /// �O���b�h�L�[�v���X�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (cell.Column.Key == EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_OrderCnt)
            {
                // �ҏW���[�h���H
                if (cell.IsInEditMode)
                {
                    if (!this.KeyPressNumCheck(3, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// �O���b�h�L�[�A�b�v�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
        }

        /// <summary>
        /// �O���b�h�G���^�[�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_Enter(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                if (!this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || ( this.uGrid_Details.ActiveCell == null ))
                {
                    if (this.uGrid_Details.Rows.Count > 0)
                    {
                        this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_BOCode];
                    }
                }
            }
            if (this.uGrid_Details.ActiveCell != null)
            {
                if (( !this.uGrid_Details.ActiveCell.IsInEditMode ) &&
                    ( this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ) &&
                    ( this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit ))
                {
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                else
                {
                    // �����͉\�Z���ړ�����
                    this.MoveNextAllowEditCell(true);
                }
            }
            // �O���b�h�Z���A�N�e�B�u�㔭���C�x���g
            this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());
        }

        /// <summary>
        /// ���׃O���b�h���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Details_Leave(object sender, EventArgs e)
        {

        }

        #endregion

        /// <summary>
        /// ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_OrderCancel_Click(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Details.ActiveCell;
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Details.Selected.Rows;

            if (( cell == null ) && ( rows == null )) return;

            if (cell != null)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.UndoCell);
                this._estimateInputOrderSelectAcs.OrderCancel((Guid)this.uGrid_Details.Rows[cell.Row.Index].Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_DtlRelationGuid].Value);
                this.SettingGridRow(cell.Row.Index);
                this.DetailDataChangedCall();
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
            else if (rows != null)
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in rows)
                {
                    this._estimateInputOrderSelectAcs.OrderCancel((Guid)row.Cells[EstimateInputOrderSelectAcs.OrderSelectDtlTable.ctColName_DtlRelationGuid].Value);
                }
                this.SettingGrid();
                this.DetailDataChangedCall();
            }
        }

        #endregion

        /// <summary>
        /// ���׃O���b�h�@MouseClick�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_MouseClick(object sender, MouseEventArgs e)
        {
            // �E�N���b�N�ȊO�̏ꍇ
			if (e.Button != MouseButtons.Right) return;

            System.Drawing.Point nowPos = new Point(e.X, e.Y);

            Infragistics.Win.UIElement objElement = this.uGrid_Details.DisplayLayout.UIElement.ElementFromPoint(nowPos);

            // �N���b�N�ʒu����w�b�_�[������
            bool isColumnHeader = false;

            if (objElement != null)
            {
                if (( objElement.SelectableItem is Infragistics.Win.UltraWinGrid.ColumnHeader ) ||
                    ( objElement is Infragistics.Win.UltraWinGrid.HeaderUIElement ))
                {
                    isColumnHeader = true;
                    // string columnName = ((Infragistics.Win.UltraWinGrid.ColumnHeader)objElement.SelectableItem).Column.Key;
                }
            }

            if (isColumnHeader)
            {
                // ��w�b�_�[�E�N���b�N���͉������Ȃ�
            }
            else
            {
                // ����ȊO�ŉE�N���b�N���ꂽ�ꍇ�́A�ҏW�̃|�b�v�A�b�v��\������
                ( (Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"] ).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_Details);

                if (( this.uGrid_Details.ActiveCell == null ) && ( this.uGrid_Details.ActiveRow != null ))
                {
                    if (this.uGrid_Details.ActiveRow.Selected)
                    {
                        //
                    }
                    else
                    {
                        this.uGrid_Details.Selected.Rows.Clear();
                        this.uGrid_Details.ActiveRow.Selected = true;
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// �c�[���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager_Main_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_OrderCancel":
                    this.uButton_OrderCancel_Click(this.uGrid_Details, new EventArgs());
                    break;
                default:
                    break;
            }
        }

    }
}
