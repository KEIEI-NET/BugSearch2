using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources; // ADD K2013/05/13 ���N Redmine#35663

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�����̓R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�����̉��i�����͂��s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2008.6.18</br>
    /// <br>Update Note: 2009.02.03 30414 �E �K�j ��QID:10848�Ή�</br>
    /// <br>Update Note: 2009.02.10 30414 �E �K�j ��QID:11234�Ή�</br>
    /// <br>Update Note: 2010.01.05 30434 �H��    ��QID:14816�Ή�</br>
    /// <br>Update Note: K2013/05/13 ���N</br>
    /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
    /// <br>             Redmine#35663 ���i�݌Ƀ}�X�^�E�R�`���i�l�ʑg�ݍ���</br>
    /// </remarks>
    public partial class MAKHN09280UB : UserControl
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        private GoodsAcs _goodsAcs;                                         // ���i�}�X�^�A�N�Z�X�N���X
        //private GoodsInputDataSet.GoodsPriceDataTable _goodsPriceDataTable; // ���i���i�f�[�^�e�[�u�� // DEL 2010/08/09
        internal GoodsInputDataSet.GoodsPriceDataTable _goodsPriceDataTable; // ���i���i�f�[�^�e�[�u�� // ADD 2010/08/09
        private GoodsUnitData _goodsUnitData;                               // ���i�A���f�[�^�N���X
        private DateTime _beforePriceStartDate = DateTime.MinValue;
        private double _beforeListPrice = 0;
        private double _beforeStockRate = 0;
        private double _beforeSalesUnitCost = 0;
        private DateTime _beforeOfferDate = DateTime.MinValue;
        private bool _beforeCellUpdateCancel = false;
        // --- ADD K2013/05/13 ���N Redmine#35663 ---------->>>>>
        /// <summary> �R�`���i�I�v�V�����t���O</summary>
        private int _opt_YamagataCtrl;
        /// <summary> �d����/���P���C���ۃt���O</summary>
        private bool _cstChangeEnable = false;
        /// <summary> �݌ɐ��C���ۃt���O</summary>
        private bool _stcChangeEnable = false;
        // --- ADD ADD K2013/05/13 ���N Redmine#35663 ----------<<<<<

        private bool _parentEnabled = true;

        private object _beforeOpenPriceDiv; // ADD 2010/08/09

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/18 DEL
        //public MAKHN09280UB()
        //{
        //    InitializeComponent();

        //    this._goodsAcs = new GoodsAcs();
        //    this._goodsPriceDataTable = this._goodsAcs.GoodsPriceDataTable;
        //    this._goodsUnitData = new GoodsUnitData();
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/18 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/18 ADD
        /// <remarks>
        /// <br>Update Note: K2013/05/13 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>             Redmine#35663 ���i�݌Ƀ}�X�^�E�R�`���i�l�ʑg�ݍ���</br>
        /// </remarks>
        public MAKHN09280UB( GoodsAcs goodsAcs, GoodsUnitData goodsUnitData )
        {
            InitializeComponent();

            this._goodsAcs = goodsAcs;
            this._goodsPriceDataTable = this._goodsAcs.GoodsPriceDataTable;
            this._goodsUnitData = goodsUnitData;
            // --- ADD K2013/05/13 ���N Redmine#35663 ---------->>>>>
            // �I�v�V�������L���b�V��
            CacheOptionInfo();
            if (this._opt_YamagataCtrl == (int)MAKHN09280UA.Option.ON)
            {
                this._goodsAcs.GetYmgtMngChangeEnable(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, out this._cstChangeEnable, out this._stcChangeEnable); // �d����/���P���C���ۃt���O
            }
            // --- ADD K2013/05/13 ���N Redmine#35663 ----------<<<<<
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/18 ADD

        //----- ADD K2013/05/13 ���N Redmine#35663 ----->>>>>
        /// <summary>
        /// �I�v�V�������L���b�V��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �I�v�V������񐧌䏈���B</br>
        /// <br>Programmer : ���N</br>
        /// <br>Date       : K2013/05/13</br>
        /// </remarks>
        private void CacheOptionInfo()
        {
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;

            #region ���R�`���i�I�v�V����
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_YamagataCustomControl);
            if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_YamagataCtrl = (int)Broadleaf.Windows.Forms.MAKHN09280UA.Option.ON;
            }
            else
            {
                this._opt_YamagataCtrl = (int)Broadleaf.Windows.Forms.MAKHN09280UA.Option.OFF;
            }
            #endregion
        }
        //-----  ADD K2013/05/13 ���N Redmine#35663 -----<<<<<

        // ===================================================================================== //
        // �萔
        // ===================================================================================== //

        // ===================================================================================== //
        // �f���Q�[�g
        // ===================================================================================== //
        /// <summary>
        /// ���i���ݒ�f���Q�[�g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="rowNo"></param>
        internal delegate void SettingGoodsPriceEventHandler(object sender, int rowNo);
        
        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        /// <summary>�O���b�h�ŏ�ʍs�L�[�_�E���C�x���g</summary>
        internal event EventHandler GridKeyDownTopRow;

        /// <summary>�O���b�h�ŉ��w�s�L�[�_�E���C�x���g</summary>
        internal event EventHandler GridKeyDownButtomRow;

        /// <summary>���i���ݒ�C�x���g</summary>
        internal event SettingGoodsPriceEventHandler SettingGoodsPrice;
        
        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        /// <summary>
        /// ���i�A���f�[�^�N���X
        /// </summary>
        public GoodsUnitData GoodsUnitData
        {
            get { return this._goodsUnitData; }
            set { this._goodsUnitData = value; }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/17 ADD
        /// <summary>
        /// ���i�A�N�Z�X�N���X
        /// </summary>
        public GoodsAcs GoodsAcs
        {
            get { return this._goodsAcs; }
            set 
            { 
                this._goodsAcs = value;
                this._goodsPriceDataTable = this._goodsAcs.GoodsPriceDataTable;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/17 ADD

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        /// <summary>
        /// �O���b�h�L�[�}�b�s���O�ݒ菈��
        /// </summary>
        /// <param name="grid">�ݒ�Ώۂ̃O���b�h</param>
        private void MakeKeyMappingForGrid(Infragistics.Win.UltraWinGrid.UltraGrid grid)
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
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- Shift + Enter�L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Enter,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                Infragistics.Win.SpecialKeys.AltCtrl,
                Infragistics.Win.SpecialKeys.Shift,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŏ�i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Up,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowFirst | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- ���L�[ (�ŉ��i�̃h���b�v�_�E�����X�g�ł͉������Ȃ��B���ꂪ�����ƃ��X�g���ڂ��ς���Ă��܂��̂�...)
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.RowLast | Infragistics.Win.UltraWinGrid.UltraGridState.HasDropdown,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- ���L�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Down,
                Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell,
                Infragistics.Win.UltraWinGrid.UltraGridState.IsDroppedDown,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- �O�ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Prior,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageUpCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);

            //----- ���ŃL�[
            enterMap = new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                Keys.Next,
                Infragistics.Win.UltraWinGrid.UltraGridAction.PageDownCell,
                0,
                Infragistics.Win.UltraWinGrid.UltraGridState.InEdit,
                Infragistics.Win.SpecialKeys.All,
                0,
                true);
            this.uGrid_GoodsPriceInfo.KeyActionMappings.Add(enterMap);
        }

        /// <summary>
        /// Return�L�[�_�E������
        /// </summary>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        internal bool ReturnKeyDown()
        {
            if (this.uGrid_GoodsPriceInfo.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_GoodsPriceInfo.ActiveCell;
            int rowIndex = cell.Row.Index;

            this.uGrid_GoodsPriceInfo.BeginUpdate();

            this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

            // �O���b�h�Z���ݒ菈��
            this.SettingGridRow(rowIndex);

            try
            {
                bool canMove = true;

                //------------------------------------------------------------
                // ���i�J�n��
                //------------------------------------------------------------
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
                //if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
                //{
                //    if (this._beforeCellUpdateCancel)
                //    {
                //        this._beforeCellUpdateCancel = false;
                //    }
                //    else
                //    {
                //        // �����͉\�Z���ړ�����
                //        canMove = this.MoveNextAllowEditCell(false);
                //    }
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
                // ���i�J�n��(�N)
                if ( cell.Column.Key == this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName )
                {
                    if ( this._beforeCellUpdateCancel )
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MoveNextAllowEditCell( false );
                    }
                }
                // ���i�J�n��(��)
                else if ( cell.Column.Key == this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName )
                {
                    if ( this._beforeCellUpdateCancel )
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MoveNextAllowEditCell( false );
                    }
                }
                // ���i�J�n��(��)
                else if ( cell.Column.Key == this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName )
                {
                    if ( this._beforeCellUpdateCancel )
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MoveNextAllowEditCell( false );
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
                //------------------------------------------------------------
                // �W�����i
                //------------------------------------------------------------
                else if (cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MoveNextAllowEditCell(false);
                    }
                }
                //------------------------------------------------------------
                // �d����
                //------------------------------------------------------------
                else if (cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MoveNextAllowEditCell(false);
                    }
                }
                //------------------------------------------------------------
                // ���P��
                //------------------------------------------------------------
                else if (cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MoveNextAllowEditCell(false);
                    }
                }
                else
                {
                    // �����͉\�Z���ړ�����
                    canMove = this.MoveNextAllowEditCell(false);
                }
                return canMove;
            }
            finally
            {
                this.uGrid_GoodsPriceInfo.EndUpdate();
            }
        }

        // ADD 2008/12/15 �s��Ή�[8733] ---------->>>>>
        internal bool ShiftReturnKeyDown()
        {
            if (this.uGrid_GoodsPriceInfo.ActiveCell == null) return false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_GoodsPriceInfo.ActiveCell;
            int rowIndex = cell.Row.Index;

            this.uGrid_GoodsPriceInfo.BeginUpdate();

            this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

            // �O���b�h�Z���ݒ菈��
            this.SettingGridRow(rowIndex);

            try
            {
                bool canMove = true;

                
                // ���i�J�n��(�N)
                if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                }
                // ���i�J�n��(��)
                else if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                }
                // ���i�J�n��(��)
                else if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                }
                //------------------------------------------------------------
                // �W�����i
                //------------------------------------------------------------
                else if (cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                }
                //------------------------------------------------------------
                // �d����
                //------------------------------------------------------------
                else if (cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                }
                //------------------------------------------------------------
                // ���P��
                //------------------------------------------------------------
                else if (cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)
                {
                    if (this._beforeCellUpdateCancel)
                    {
                        this._beforeCellUpdateCancel = false;
                    }
                    else
                    {
                        // �����͉\�Z���ړ�����
                        canMove = this.MovePrevAllowEditCell(false);
                    }
                }
                else
                {
                    // �����͉\�Z���ړ�����
                    canMove = this.MovePrevAllowEditCell(false);
                }
                return canMove;
            }
            finally
            {
                this.uGrid_GoodsPriceInfo.EndUpdate();
            }
        }

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="currentCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        private bool MovePrevAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_GoodsPriceInfo.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_GoodsPriceInfo.ActiveCell != null))
            {
                if ((!this.uGrid_GoodsPriceInfo.ActiveCell.Column.Hidden) &&
                    (this.uGrid_GoodsPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_GoodsPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {

                performActionResult = this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                if (performActionResult)
                {
                    if ((this.uGrid_GoodsPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_GoodsPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_GoodsPriceInfo.ResumeLayout();
            return performActionResult;
        }
        // ADD 2008/12/15 �s��Ή�[8733] ----------<<<<<

        /// <summary>
        /// �����͉\�Z���ړ�����
        /// </summary>
        /// <param name="currentCheck">true:ActiveCell�����͉\�̏ꍇ��Next�Ɉړ������Ȃ� false:ActiveCell�Ɋ֌W�Ȃ�Next�Ɉړ�������</param>
        /// <returns>true:�Z���ړ����� false:�Z���ړ����s</returns>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_GoodsPriceInfo.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_GoodsPriceInfo.ActiveCell != null))
            {
                if ((!this.uGrid_GoodsPriceInfo.ActiveCell.Column.Hidden) &&
                    (this.uGrid_GoodsPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_GoodsPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                //if (this.uGrid_GoodsPriceInfo.ActiveCell != null)
                //{
                //    int editMode = (int)this.uGrid_GoodsPriceInfo.Rows[this.uGrid_GoodsPriceInfo.ActiveCell.Row.Index].Cells[this._salesDetailDataTable.EditStatusColumn.ColumnName].Value;

                //    if ((editMode == StockSlipInputAcs.ctEDITSTATUS_AllDisable) || (editMode == StockSlipInputAcs.ctEDITSTATUS_AllReadOnly))
                //    {
                //        performActionResult = this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);

                //        if ((performActionResult) && (this.uGrid_GoodsPriceInfo.ActiveRow != null))
                //        {
                //            int index = this.uGrid_GoodsPriceInfo.ActiveRow.Index;

                //            if (!(this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Columns[this._salesDetailDataTable.GoodsNoColumn.ColumnName].Hidden))
                //            {
                //                this.uGrid_GoodsPriceInfo.ActiveCell = this.uGrid_GoodsPriceInfo.Rows[index].Cells[this._salesDetailDataTable.GoodsNoColumn.ColumnName];
                //            }
                //            else
                //            {
                //                this.uGrid_GoodsPriceInfo.ActiveCell = this.uGrid_GoodsPriceInfo.Rows[index].Cells[this._salesDetailDataTable.GoodsNameColumn.ColumnName];
                //            }

                //            // �ċA����
                //            this.MoveNextAllowEditCell(true);

                //            return true;
                //        }
                //    }
                //}

                performActionResult = this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                //performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);

                if (performActionResult)
                {
                    if ((this.uGrid_GoodsPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_GoodsPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
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
                this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_GoodsPriceInfo.ResumeLayout();
            return performActionResult;
        }

        /// <summary>
        /// FIXME:���i���ݒ�C�x���g�R�[������
        /// </summary>
        /// <param name="rowNo"></param>
        private void SettingGoodsPriceEventCall(int rowNo)
        {
            if ((this.SettingGoodsPrice != null) && (rowNo != 0))
            {
                this.SettingGoodsPrice(this, rowNo);
            }
        }

        /// <summary>
        /// ActiveRow�C���f�b�N�X�擾����
        /// </summary>
        /// <returns>ActiveRow�C���f�b�N�X</returns>
        private int GetActiveRowIndex()
        {
            if (this.uGrid_GoodsPriceInfo.ActiveCell != null)
            {
                return this.uGrid_GoodsPriceInfo.ActiveCell.Row.Index;
            }
            else if (this.uGrid_GoodsPriceInfo.ActiveRow != null)
            {
                return this.uGrid_GoodsPriceInfo.ActiveRow.Index;
            }
            else
            {
                // DEL 2010/01/05 MANTIS�Ή�[14816]�F���i���̍Čv�Z�����̏C�� ---------->>>>>
                // return -1;
                // DEL 2010/01/05 MANTIS�Ή�[14816]�F���i���̍Čv�Z�����̏C�� ----------<<<<<
                // ADD 2010/01/05 MANTIS�Ή�[14816]�F���i���̍Čv�Z�����̏C�� ---------->>>>>
                // MEMO:���i���̍Čv�Z�p�c�A�N�e�B�u�s�����݂��Ȃ��ꍇ�A�ێ����Ă������C���f�b�N�X��Ԃ�
                return CurrentRowIndex;
                // ADD 2010/01/05 MANTIS�Ή�[14816]�F���i���̍Čv�Z�����̏C�� ----------<<<<<
            }
        }

        /// <summary>
        /// ActiveRow�̍s�ԍ��擾����
        /// </summary>
        /// <returns></returns>
        internal int GetActiveRowRowNo()
        {
            int rowIndex = this.GetActiveRowIndex();
            if (rowIndex < 0) return -1;

            return this._goodsPriceDataTable[rowIndex].RowNo;
        }

        /// <summary>
        /// FIXME:���׃O���b�h�E�s�P�ʂł̃Z���ݒ�
        /// </summary>
        /// <param name="rowIndex">�Ώۍs�C���f�b�N�X</param>
        /// <param name="salesSlip">�d���f�[�^�N���X�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Update Note: K2013/05/13 ���N</br>
        /// <br>�Ǘ��ԍ�   : 10901273-00 2013/06/18�z�M��</br>
        /// <br>             Redmine#35663 ���i�݌Ƀ}�X�^�E�R�`���i�l�ʑg�ݍ���</br>
        /// </remarks>
        internal void SettingGridRow(int rowIndex)
        {
            if (this._goodsPriceDataTable.Count == 0) return;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // ���i�J�n��
            DateTime priceStartDate = this._goodsPriceDataTable[rowIndex].PriceStartDate;
            // �񋟓��t
            DateTime offerDate = this._goodsPriceDataTable[rowIndex].OfferDate;

            // �w��s�̑S�Ă̗�ɑ΂��Đݒ���s���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �Z�������擾
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_GoodsPriceInfo.Rows[rowIndex].Cells[col];
                if (cell == null) continue;

                // --- ADD 2009/02/03 ��QID:10848�Ή�------------------------------------------------------>>>>>
                int yy = 0;
                int mm = 0;
                int dd = 0;

                if (cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value != DBNull.Value)
                {
                    yy = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value;
                }
                if (cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value != DBNull.Value)
                {
                    mm = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value;
                }
                if (cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value != DBNull.Value)
                {
                    dd = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value;
                }
                // --- ADD 2009/02/03 ��QID:10848�Ή�------------------------------------------------------<<<<<

                //------------------------------------------------
                // �Z����Ԑݒ�
                //------------------------------------------------
                if ((col.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName) ||
                    (col.Key == this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName) ||
                    (col.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName) ||
                    (col.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName))
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 DEL
                    //(col.Key == this._goodsPriceDataTable.OfferDateColumn.ColumnName)
                �@�@// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 DEL
                {
                    //----- ADD K2013/05/13 ���N Redmine#35663 ----->>>>>
                    if ((this._opt_YamagataCtrl == (int)MAKHN09280UA.Option.ON) &&
                        ((col.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName) ||
                        (col.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)))
                    {
                        if (this._cstChangeEnable == false)
                        {
                            cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // �g�p�s��
                            continue;
                        }
                    }
                    //----- ADD K2013/05/13 ���N Redmine#35663 -----<<<<<
                    // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------>>>>>
                    //if (priceStartDate == DateTime.MinValue)
                    if ((yy == 0) && (mm == 0) && (dd == 0))
                    // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------<<<<<
                    {
                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // �g�p�s��
                    }
                    else
                    {
                        cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; // �ҏW�\
                    }
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 ADD
                if ( col.Key == this._goodsPriceDataTable.OfferDateColumn.ColumnName )
                {
                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.Disabled; // �g�p�s��
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 ADD

                //------------------------------------------------
                // �����v�f�̃e�L�X�g�J���[�ݒ�
                //------------------------------------------------
                // ���i�J�n��
                if (col.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
                {
                    // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------>>>>>
                    //if (priceStartDate == DateTime.MinValue)
                    if ((yy == 0) && (mm == 0) && (dd == 0))
                    // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------<<<<<
                    {
                        cell.Appearance.ForeColor = Color.Transparent;
                    }
                    else
                    {
                        cell.Appearance.ForeColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                    }
                }
                // �I�[�v�����i�敪
                if (col.Key == this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName)
                {
                    // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------>>>>>
                    //if (priceStartDate == DateTime.MinValue)
                    if ((yy == 0) && (mm == 0) && (dd == 0))
                    // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------<<<<<
                    {
                        cell.Appearance.ForeColor = Color.Transparent;
                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                    }
                    else
                    {
                        cell.Appearance.ForeColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                        cell.Appearance.ForeColorDisabled = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                    }
                }
                // �񋟓��t
                if ( col.Key == this._goodsPriceDataTable.OfferDateColumn.ColumnName )
                {
                    if ( offerDate == DateTime.MinValue )
                    {
                        cell.Appearance.ForeColor = Color.Transparent;
                        cell.Appearance.ForeColorDisabled = Color.Transparent;
                    }
                    else
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 DEL
                        //cell.Appearance.ForeColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                        //cell.Appearance.ForeColorDisabled = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.RowAppearance.ForeColorDisabled;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/04 ADD
                        cell.Appearance.ForeColor = Color.Black;
                        cell.Appearance.ForeColorDisabled = Color.Black;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/04 ADD
                    }
                }
            }
        }

        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        /// <summary>
        /// Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAKHN09280UB_Load(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/03 DEL
            //if ((this._goodsUnitData.GoodsNo == string.Empty))
            //{
            //    this._goodsPriceDataTable.Clear();

            //    this.uGrid_GoodsPriceInfo.DataSource = this._goodsPriceDataTable;

            //    this._goodsAcs.ClearGoodsPriceDataTable();
            //}
            //else
            //{
            //    this.uGrid_GoodsPriceInfo.DataSource = this._goodsPriceDataTable;
            //}


            //// �L�[�}�b�s���O�ݒ�
            //this.MakeKeyMappingForGrid(this.uGrid_GoodsPriceInfo);

            //// �`�悪�K�v�Ȗ��׌������擾����B
            //int cnt = this._goodsPriceDataTable.Count;

            //// �e�s���Ƃ̐ݒ�
            //for (int i = 0; i < cnt; i++)
            //{
            //    this.SettingGridRow(i);
            //}

            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
            //// ���͉ېݒ�
            //this.SettingEnabled( _goodsUnitData.LogicalDeleteCode == 0 );
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/03 DEL
        }
        /// <summary>
        /// ���[�h����
        /// </summary>
        public void Loading()
        {
            if ( (this._goodsUnitData.GoodsNo == string.Empty) )
            {
                this._goodsPriceDataTable.Clear();

                this.uGrid_GoodsPriceInfo.DataSource = this._goodsPriceDataTable;

                this._goodsAcs.ClearGoodsPriceDataTable();
            }
            else
            {
                this.uGrid_GoodsPriceInfo.DataSource = this._goodsPriceDataTable;
            }

            // �L�[�}�b�s���O�ݒ�
            this.MakeKeyMappingForGrid( this.uGrid_GoodsPriceInfo );

            // �`�悪�K�v�Ȗ��׌������擾����B
            int cnt = this._goodsPriceDataTable.Count;

            // �e�s���Ƃ̐ݒ�
            for ( int i = 0; i < cnt; i++ )
            {
                this.SettingGridRow( i );
            }

            // ���͉ېݒ�
            this.SettingEnabled( _goodsUnitData.LogicalDeleteCode == 0 );
        }

        /// <summary>
        /// InitializeLayout�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
            }

            string moneyFormat = "#,##0;-#,##0;''";
            string moneyFormatFl = "#,##0.00;-#,##0.00;''";
            string rateFormatFl = "###0.00;-###0.00;''";

            int visiblePosition = 0;

            // �񕝂̎����������@
            this.uGrid_GoodsPriceInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
            //this.uGrid_GoodsPriceInfo.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
            this.uGrid_GoodsPriceInfo.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------
            this.uGrid_GoodsPriceInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // ��
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
            //// ���i�J�n��
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Hidden = false;
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Width = 100;
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            // ���i�J�n���i��\���j
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Hidden = true;
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Width = 100;
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // ���i�J�n���i�N�j
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Width = 80;
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Format = "####�N";
            Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // ���i�J�n���i���j
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Width = 35;
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Format = "##��";
            Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // ���i�J�n���i���j
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Width = 35;
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Format = "##��";
            Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD

            // �W�����i
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].Hidden = false;
            // 2008.11.18 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].MaxLength = 11;
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].MaxLength = 7;
            // 2008.11.18 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].Format = moneyFormat;
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].Width = 100;
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // �I�[�v�����i�敪
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].Width = 100;
            // --- UPD 2010/08/09 ---------->>>>>
            //Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
            // --- UPD 2010/08/09 ----------<<<<<
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Infragistics.Win.ValueList list = new Infragistics.Win.ValueList();
            list.DisplayStyle = Infragistics.Win.ValueListDisplayStyle.DisplayText;
            list.DropDownListMinWidth = 0;
            list.MaxDropDownItems = 2;
            Infragistics.Win.ValueListItem listItem0 = new Infragistics.Win.ValueListItem();
            listItem0.DataValue = 0;
            //listItem0.DisplayText = "�ʏ�"; // DEL 2010/08/09
            listItem0.DisplayText = "0:�ʏ�"; // ADD 2010/08/09
            Infragistics.Win.ValueListItem listItem1 = new Infragistics.Win.ValueListItem();
            listItem1.DataValue = 1;
            //listItem1.DisplayText = "�I�[�v�����i"; // DEL 2010/08/09
            listItem1.DisplayText = "1:�I�[�v�����i"; // ADD 2010/08/09
            list.ValueListItems.Add(listItem0);
            list.ValueListItems.Add(listItem1);
            Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].ValueList = list;
            
            // �d����
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].MaxLength = 12;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].Format = rateFormatFl;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].Width = 100;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // ���P��
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].Hidden = false;
            // 2008.11.18 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].MaxLength = 12;
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].MaxLength = 10;
            // 2008.11.18 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].Format = moneyFormatFl;
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].Width = 100;
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            // �񋟓��t
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].Hidden = false;
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].Width = 100;
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Date;
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �Œ���؂���ݒ�
            this.uGrid_GoodsPriceInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_GoodsPriceInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// AfterPerformAction�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_AfterPerformAction(object sender, Infragistics.Win.UltraWinGrid.AfterUltraGridPerformActionEventArgs e)
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
                    if ((this.uGrid_GoodsPriceInfo.ActiveCell != null) && (this.uGrid_GoodsPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_GoodsPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        // �A�N�e�B�u�Z���̃X�^�C�����擾
                        switch (this.uGrid_GoodsPriceInfo.ActiveCell.StyleResolved)
                        {
                            // �G�f�B�b�g�n�X�^�C��
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Default:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    // �ҏW���[�h�ɂ���H
                                    if (this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode))
                                    {
                                        if (!(this.uGrid_GoodsPriceInfo.ActiveCell.Value is System.DBNull))
                                        {
                                            // �S�I����Ԃɂ���B
                                            this.uGrid_GoodsPriceInfo.ActiveCell.SelStart = 0;
                                            this.uGrid_GoodsPriceInfo.ActiveCell.SelLength = this.uGrid_GoodsPriceInfo.ActiveCell.Text.Length;
                                        }
                                    }
                                    break;
                                }
                            default:
                                {
                                    // �G�f�B�b�g�n�ȊO�̃X�^�C���ł���΁A�ҏW��Ԃɂ���B
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    break;
                                }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Enter�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_Enter(object sender, EventArgs e)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
            if ( !_parentEnabled ) return;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD

            if (this.uGrid_GoodsPriceInfo.ActiveCell == null)
            {
                if (!this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ActivateCell) || (this.uGrid_GoodsPriceInfo.ActiveCell == null))
                {
                    if (this.uGrid_GoodsPriceInfo.Rows.Count > 0)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
                        //this.uGrid_GoodsPriceInfo.ActiveCell = this.uGrid_GoodsPriceInfo.Rows[0].Cells[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName];
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
                        this.uGrid_GoodsPriceInfo.ActiveCell = this.uGrid_GoodsPriceInfo.Rows[0].Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName];
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD

                        // �����͉\�Z���ړ�����
                        this.MoveNextAllowEditCell(true);
                    }
                }
            }

            if (this.uGrid_GoodsPriceInfo.ActiveCell != null)
            {
                if ((!this.uGrid_GoodsPriceInfo.ActiveCell.IsInEditMode) && (this.uGrid_GoodsPriceInfo.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) && (this.uGrid_GoodsPriceInfo.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
                else
                {
                    // �����͉\�Z���ړ�����
                    this.MoveNextAllowEditCell(true);
                }
            }

            // �O���b�h�Z���A�N�e�B�u�㔭���C�x���g
            //this.uGrid_Details_AfterCellActivate(this.uGrid_Details, new EventArgs());

        }

        /// <summary>
        /// KeyDown�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_GoodsPriceInfo.ActiveCell != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_GoodsPriceInfo.ActiveCell;

                if (e.KeyCode == Keys.Escape)
                {
                    //// �d�����׃f�[�^�e�[�u��RowStatus�񏉊�������
                    //this._stockSlipInputAcs.InitializeStockDetailRowStatusColumn();

                    //// ���׃O���b�h�Z���ݒ菈��
                    //this.SettingGrid();
                }

                if (e.Shift)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Down:
                            {
                                this.uGrid_GoodsPriceInfo.ActiveCell = null;
                                this.uGrid_GoodsPriceInfo.ActiveRow = cell.Row;
                                this.uGrid_GoodsPriceInfo.Selected.Rows.Clear();
                                this.uGrid_GoodsPriceInfo.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Up:
                            {
                                this.uGrid_GoodsPriceInfo.ActiveCell = null;
                                this.uGrid_GoodsPriceInfo.ActiveRow = cell.Row;
                                this.uGrid_GoodsPriceInfo.Selected.Rows.Clear();
                                this.uGrid_GoodsPriceInfo.Selected.Rows.Add(cell.Row);
                                break;
                            }
                        case Keys.Home:
                            {
                                if ((this.uGrid_GoodsPriceInfo.ActiveCell != null) && (this.uGrid_GoodsPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInGrid);
                                    this.MoveNextAllowEditCell(true);
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                if ((this.uGrid_GoodsPriceInfo.ActiveCell != null) && (this.uGrid_GoodsPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid);
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
                                //if ((cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown) &&
                                //    (cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList) &&
                                //    (cell.Column.Style != Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownValidate))
                                //{
                                //    ((Infragistics.Win.UltraWinToolbars.PopupMenuTool)this.tToolbarsManager_Main.Tools["PopupMenuTool_Edit"]).ShowPopup(System.Windows.Forms.Cursor.Position, this.uGrid_GoodsPriceInfo);
                                //}

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
                        switch (this.uGrid_GoodsPriceInfo.ActiveCell.StyleResolved)
                        {
                            // �e�L�X�g�{�b�N�X�E�e�L�X�g�{�b�N�X(�{�^���t)
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.Edit:
                            case Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton:
                                {
                                    switch (e.KeyData)
                                    {
                                        // ���L�[
                                        case Keys.Left:
                                            if (this.uGrid_GoodsPriceInfo.ActiveCell.SelStart == 0)
                                            {
                                                this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            if (this.uGrid_GoodsPriceInfo.ActiveCell.SelStart >= this.uGrid_GoodsPriceInfo.ActiveCell.Text.Length)
                                            {
                                                this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
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
                                                this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellByTab);
                                                e.Handled = true;
                                            }
                                            break;
                                        // ���L�[
                                        case Keys.Right:
                                            {
                                                this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab);
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
                                if ((this.uGrid_GoodsPriceInfo.ActiveCell != null) && (this.uGrid_GoodsPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                }
                                else
                                {
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow);
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.End:
                            {
                                // �ҏW���[�h�̏ꍇ�͂Ȃɂ����Ȃ�
                                if ((this.uGrid_GoodsPriceInfo.ActiveCell != null) && (this.uGrid_GoodsPriceInfo.ActiveCell.IsInEditMode))
                                {
                                    //
                                }
                                else
                                {
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInRow);
                                    this.uGrid_GoodsPriceInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    e.Handled = true;
                                }
                                break;
                            }
                        case Keys.Up:
                            {
                                if ((this.uGrid_GoodsPriceInfo.ActiveCell != null) && (!this.uGrid_GoodsPriceInfo.ActiveCell.DroppedDown))
                                {
                                    if (this.uGrid_GoodsPriceInfo.ActiveCell.Row.Index == 0)
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
                                if (this.uGrid_GoodsPriceInfo.ActiveCell.Row.Index == this.uGrid_GoodsPriceInfo.Rows.Count - 1)
                                {
                                    if (e.KeyCode == Keys.Down)
                                    {
                                        if (this.GridKeyDownButtomRow != null)
                                        {
                                            this.GridKeyDownButtomRow(this, new EventArgs());
                                            e.Handled = true;
                                        }
                                    }
                                }

                                break;
                            }
                    }
                }
            }
            else if (this.uGrid_GoodsPriceInfo.ActiveRow != null)
            {
                Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_GoodsPriceInfo.ActiveRow;

                if (this.uGrid_GoodsPriceInfo.ActiveRow.Index == 0)
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
                else if (this.uGrid_GoodsPriceInfo.ActiveRow.Index == this.uGrid_GoodsPriceInfo.Rows.Count - 1)
                {
                    if (e.KeyCode == Keys.Down)
                    {
                        if (this.GridKeyDownButtomRow != null)
                        {
                            this.GridKeyDownButtomRow(this, new EventArgs());
                            e.Handled = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// BeforeCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_BeforeCellUpdate(object sender, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e)
        {
            if (e.Cell == null) return;

            this._beforeCellUpdateCancel = false;
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            //------------------------------------------------------------
            // ���i�J�n��
            //------------------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
            //if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
            //{
            //    if ((e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)))
            //    {
            //        //DateTime dt = new DateTime((long)e.Cell.Value);
            //        DateTime dt = new DateTime();
            //        //DateTime dt = new DateTime((long)e.Cell.Value);
            //        dt = (DateTime)e.NewValue;
            //        // ���i�J�n���d���`�F�b�N
            //        if (this._goodsAcs.CheckRepeatPriceStartDate(dt))
            //        {
            //            TMsgDisp.Show(
            //                this,
            //                emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //                this.Name,
            //                "���͂��ꂽ���t�͊��ɑ��݂���ׁA���͂ł��܂���B",
            //                -1,
            //                MessageBoxButtons.OK);

            //            this._beforeCellUpdateCancel = true;
            //            e.Cancel = true;
            //            return;
            //        }
            //        this._beforePriceStartDate = (DateTime)e.Cell.Value;
            //    }
            //    else
            //    {
            //        this._beforePriceStartDate = DateTime.MinValue;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            if ( (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName) ||
                      (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName) ||
                      (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName) )
            {
                // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------>>>>>
                //// �ύX�O�̓��t��Δ䁨AfterCellUpdate�Ŏg�p����
                //if ( e.Cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Value != DBNull.Value )
                //{
                //    this._beforePriceStartDate = (DateTime)e.Cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Value;
                //}
                // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------<<<<<

                if ( (e.NewValue != null) && (e.NewValue != DBNull.Value) )
                {
                    // �V�������͂��ꂽ���t���擾(���݂̃Z��������NewValue���疢�X�V�̍ŐV�l���擾����)
                    DateTime inputDate = GetPriceStartDateFromNewInput( cell.Column.Key, e );

                    if ( inputDate != DateTime.MinValue )
                    {
                        if ( this._goodsAcs.CheckRepeatPriceStartDate( inputDate ) )
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "���͂��ꂽ���t�͊��ɑ��݂���ׁA���͂ł��܂���B",
                                -1,
                                MessageBoxButtons.OK );

                            this._beforeCellUpdateCancel = true;
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
            //------------------------------------------------------------
            // �W�����i
            //------------------------------------------------------------
            else if ( cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName )
            {
                if ( (e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)) )
                {
                    this._beforeListPrice = (double)e.Cell.Value;
                }
                else
                {
                    this._beforeListPrice = 0;
                }
            }
            //------------------------------------------------------------
            // �d����
            //------------------------------------------------------------
            else if ( cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName )
            {
                if ( (e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)) )
                {
                    this._beforeStockRate = (double)e.Cell.Value;
                }
                else
                {
                    this._beforeStockRate = 0;
                }
            }
            //------------------------------------------------------------
            // ���P��
            //------------------------------------------------------------
            else if ( cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName )
            {
                if ( (e.Cell.Value != null) && (!(e.Cell.Value is System.DBNull)) )
                {
                    this._beforeSalesUnitCost = (double)e.Cell.Value;
                }
                else
                {
                    this._beforeSalesUnitCost = 0;
                }
            }

            // --- ADD 2010/08/09 ---------->>>>>
            //------------------------------------------------------------
            // �I�[�v�����i�敪
            //------------------------------------------------------------
            else if (cell.Column.Key == this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName)
            {
                if ((cell.Value != null) && (!(cell.Value is System.DBNull)))
                {
                    this._beforeOpenPriceDiv = cell.Value;
                }
            }
            // --- ADD 2010/08/09 ----------<<<<<
        }

        /// <summary>
        /// AfterCellUpdate�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;
            int rowNo = this._goodsPriceDataTable[cell.Row.Index].RowNo;
            int rowIndex = e.Cell.Row.Index;

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Columns; // ADD 2010/08/11

            if (e.Cell.Value is DBNull)
            {
                if ((e.Cell.Column.DataType == typeof(Int32)) ||
                    (e.Cell.Column.DataType == typeof(Int64)) ||
                    (e.Cell.Column.DataType == typeof(double)))
                {
                    e.Cell.Value = 0;
                }
                else if (e.Cell.Column.DataType == typeof(string))
                {
                    e.Cell.Value = "";
                }
            }

            //------------------------------------------------------------
            // ���i�J�n��
            //------------------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
            //if (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateColumn.ColumnName)
            //{
            //    DateTime dt = new DateTime();
            //    dt = (DateTime)e.Cell.Value;
            //    if (this._beforePriceStartDate != dt)
            //    {
            //        this._goodsAcs.CalclateUnitPrice(rowNo, this._goodsUnitData);

            //        this._goodsAcs.ClearInputInfo(rowNo); // ���͏��N���A
            //        this._goodsAcs.SettingCalcStockRate(rowNo); // �v�Z�������ݒ�
            //        this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // �v�Z�����z�ݒ菈��
            //        this._goodsAcs.SettingCalcMaster(rowNo); // �Z�o�}�X�^�ݒ菈��
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            if ( (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName) ||
                 (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName) ||
                 (cell.Column.Key == this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName)
                )
            {
                // ���͂��ꂽ���t���擾
                DateTime inputDate;

                // --- ADD 2009/02/03 ��QID:10848�Ή�------------------------------------------------------>>>>>
                int yy = 0;
                int mm = 0;
                int dd = 0;
                // --- ADD 2009/02/03 ��QID:10848�Ή�------------------------------------------------------<<<<<

                try
                {
                    // --- DEL 2009/02/03 ��QID:10848�Ή�------------------------------------------------------>>>>>
                    //int yy = 0;
                    //int mm = 0;
                    //int dd = 0;
                    // --- DEL 2009/02/03 ��QID:10848�Ή�------------------------------------------------------<<<<<

                    if ( cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value != DBNull.Value )
                    {
                        yy = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value;
                    }
                    if ( cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value != DBNull.Value )
                    {
                        mm = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value;
                    }
                    if ( cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value != DBNull.Value )
                    {
                        dd = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value;
                    }

                    this.uGrid_GoodsPriceInfo.BeforeCellUpdate -= uGrid_GoodsPriceInfo_BeforeCellUpdate;
                    this.uGrid_GoodsPriceInfo.AfterCellUpdate -= uGrid_GoodsPriceInfo_AfterCellUpdate;
                    if ( yy == 0 )
                    {
                        cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value = DBNull.Value;
                        yy = 0;
                    }
                    // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------>>>>>
                    //if (mm == 0 || mm > 12)
                    if (mm == 0)
                    // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------<<<<<
                    {
                        cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value = DBNull.Value;
                        mm = 0;
                    }
                    // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------>>>>>
                    //if (dd == 0 || dd > 31)
                    if (dd == 0)
                    // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------<<<<<
                    {
                        cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value = DBNull.Value;
                        dd = 0;
                    }
                    this.uGrid_GoodsPriceInfo.BeforeCellUpdate += uGrid_GoodsPriceInfo_BeforeCellUpdate;
                    this.uGrid_GoodsPriceInfo.AfterCellUpdate += uGrid_GoodsPriceInfo_AfterCellUpdate;

                    inputDate = new DateTime( yy, mm, dd );
                }
                catch
                {
                    inputDate = DateTime.MinValue;
                }

                // DateTime�J�����ɒl���Z�b�g
                cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].Value = inputDate;

                // ���͒l�̔��f
                if ( this._beforePriceStartDate != inputDate )
                {
                    // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------>>>>>
                    //this._goodsAcs.CalclateUnitPrice(rowNo, this._goodsUnitData);

                    //this._goodsAcs.ClearInputInfo(rowNo); // ���͏��N���A
                    //this._goodsAcs.SettingCalcStockRate(rowNo); // �v�Z�������ݒ�
                    //this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // �v�Z�����z�ݒ菈��
                    //this._goodsAcs.SettingCalcMaster(rowNo); // �Z�o�}�X�^�ݒ菈��

                    //// �L���l���疳���l�ɕύX���ꂽ�ꍇ�́A�N���A����
                    //if (inputDate == DateTime.MinValue)
                    //{
                    //    this.uGrid_GoodsPriceInfo.BeforeCellUpdate -= uGrid_GoodsPriceInfo_BeforeCellUpdate;
                    //    this.uGrid_GoodsPriceInfo.AfterCellUpdate -= uGrid_GoodsPriceInfo_AfterCellUpdate;
                    //    cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value = DBNull.Value;
                    //    cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value = DBNull.Value;
                    //    cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value = DBNull.Value;
                    //    this.uGrid_GoodsPriceInfo.BeforeCellUpdate += uGrid_GoodsPriceInfo_BeforeCellUpdate;
                    //    this.uGrid_GoodsPriceInfo.AfterCellUpdate += uGrid_GoodsPriceInfo_AfterCellUpdate;
                    //}

                    //_beforePriceStartDate = inputDate;
                    
                    bool clearFlg = false;
                    if ((yy == 0) && (mm == 0) && (dd == 0))
                    {
                        clearFlg = true;
                    }

                    if (clearFlg)
                    {
                        this._goodsAcs.CalclateUnitPrice(rowNo, this._goodsUnitData);

                        this._goodsAcs.ClearInputInfo(rowNo); // ���͏��N���A
                        this._goodsAcs.SettingCalcStockRate(rowNo); // �v�Z�������ݒ�
                        this._goodsAcs.SettingCalcSalesUnitCost(rowNo); // �v�Z�����z�ݒ菈��
                        this._goodsAcs.SettingCalcMaster(rowNo); // �Z�o�}�X�^�ݒ菈��

                        // �L���l���疳���l�ɕύX���ꂽ�ꍇ�́A�N���A����
                        if (inputDate == DateTime.MinValue)
                        {
                            this.uGrid_GoodsPriceInfo.BeforeCellUpdate -= uGrid_GoodsPriceInfo_BeforeCellUpdate;
                            this.uGrid_GoodsPriceInfo.AfterCellUpdate -= uGrid_GoodsPriceInfo_AfterCellUpdate;
                            cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value = DBNull.Value;
                            cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value = DBNull.Value;
                            cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value = DBNull.Value;
                            this.uGrid_GoodsPriceInfo.BeforeCellUpdate += uGrid_GoodsPriceInfo_BeforeCellUpdate;
                            this.uGrid_GoodsPriceInfo.AfterCellUpdate += uGrid_GoodsPriceInfo_AfterCellUpdate;
                        }

                        _beforePriceStartDate = inputDate;
                    }
                    else
                    {
                        _beforePriceStartDate = new DateTime(1900, 1, 1);

                        // ���i���ݒ�C�x���g�R�[��
                        this.SettingGoodsPriceEventCall(rowNo);

                        // �O���b�h�Z���ݒ菈��
                        this.SettingGridRow(rowIndex);

                        return;

                    }
                    // --- CHG 2009/02/03 ��QID:10848�Ή�------------------------------------------------------<<<<<
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
            //------------------------------------------------------------
            // �W�����i
            //------------------------------------------------------------
            else if ( cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName )
            {
                double listPrice = TStrConv.StrToDoubleDef( e.Cell.ToString(), 0 );
                if ( this._beforeListPrice != (double)e.Cell.Value )
                {
                    // �v�Z���������̓`�F�b�N
                    if ( this._goodsAcs.CheckInputCalcStockRate( rowNo ) )
                    {
                        // �v�Z�����������͂���Ă���ꍇ�A�v�Z�����z�Čv�Z
                        // --- ADD 2009/02/10 ��QID:11234�Ή�------------------------------------------------------>>>>>
                        this._goodsAcs.ClearCalcInfo(rowNo); // �Z�o���N���A
                        // --- ADD 2009/02/10 ��QID:11234�Ή�------------------------------------------------------<<<<<
                        this._goodsAcs.SettingCalcStockRate(rowNo); // �v�Z�������ݒ�
                        this._goodsAcs.SettingCalcSalesUnitCost( rowNo ); // �v�Z�����z�ݒ菈��
                        this._goodsAcs.SettingCalcMaster( rowNo ); // �Z�o�}�X�^�ݒ菈��
                    }
                }
            }
            //------------------------------------------------------------
            // �d����
            //------------------------------------------------------------
            else if ( cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName )
            {
                if ( this._beforeStockRate != (double)e.Cell.Value )
                {
                    this._goodsAcs.ClearCalcInfo( rowNo ); // �Z�o���N���A
                    this._goodsAcs.SettingCalcStockRate( rowNo ); // �v�Z�������ݒ�
                    this._goodsAcs.SettingCalcSalesUnitCost( rowNo ); // �v�Z�����z�ݒ菈��
                    this._goodsAcs.SettingCalcMaster( rowNo ); // �Z�o�}�X�^�ݒ菈��
                }
            }
            //------------------------------------------------------------
            // ���P��
            //------------------------------------------------------------
            else if ( cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName )
            {
                if ( this._beforeSalesUnitCost != (double)e.Cell.Value )
                {
                    this._goodsAcs.ClearCalcInfo( rowNo ); // �Z�o���N���A
                    this._goodsAcs.SettingCalcStockRate( rowNo ); // �v�Z�������ݒ�
                    this._goodsAcs.SettingCalcSalesUnitCost( rowNo ); // �v�Z�����z�ݒ菈��
                    this._goodsAcs.SettingCalcMaster( rowNo ); // �Z�o�}�X�^�ݒ菈��
                }
            }

            // --- ADD 2010/08/09 ---------->>>>>
            //------------------------------------------------------------
            // �I�[�v�����i�敪
            //------------------------------------------------------------
            else if (cell.Column.Key == this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName)
            {
                if ((cell.Value != null) && (!(cell.Value is System.DBNull)))
                {
                    bool inputErrorFlg = true;
                    Infragistics.Win.ValueList list = (Infragistics.Win.ValueList)Columns[cell.Column.Key].ValueList;
                    foreach (Infragistics.Win.ValueListItem item in list.ValueListItems)
                    {
                        if (item.DataValue.Equals(cell.Value))
                        {
                            inputErrorFlg = false;
                            break;
                        }
                    }

                    if (inputErrorFlg)
                    {
                        cell.Value = this._beforeOpenPriceDiv;
                    }
                    else
                    {
                        this._beforeOpenPriceDiv = cell.Value;
                    }
                }
                else
                {
                    cell.Value = this._beforeOpenPriceDiv;
                }
            }
            // --- ADD 2010/08/09 ----------<<<<<

            // ���i���ݒ�C�x���g�R�[��
            this.SettingGoodsPriceEventCall(rowNo);

            // �O���b�h�Z���ݒ菈��
            this.SettingGridRow(rowIndex);
        }

        // ADD 2010/01/05 MANTIS�Ή�[14816]�F���i���̍Čv�Z�����̏C�� ---------->>>>>
        /// <summary>UNDONE:���݂̍s�C���f�b�N�X</summary>
        private int _currentRowIndex;
        /// <summary>���݂̍s�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</summary>
        private int CurrentRowIndex
        {
            get { return _currentRowIndex; }
            set { _currentRowIndex = value; }
        }
        // ADD 2010/01/05 MANTIS�Ή�[14816]�F���i���̍Čv�Z�����̏C�� ----------<<<<<

        /// <summary>
        /// AfterRowActivate�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_AfterRowActivate(object sender, EventArgs e)
        {
            if (this.uGrid_GoodsPriceInfo.ActiveRow == null) return;
            Infragistics.Win.UltraWinGrid.UltraGridRow row = this.uGrid_GoodsPriceInfo.ActiveRow;

            // ADD 2010/01/05 MANTIS�Ή�[14816]�F���i���̍Čv�Z�����̏C�� ---------->>>>>
            // MEMO:���݂̍s�C���f�b�N�X��ێ�
            CurrentRowIndex = this.uGrid_GoodsPriceInfo.ActiveRow.Index;
            // ADD 2010/01/05 MANTIS�Ή�[14816]�F���i���̍Čv�Z�����̏C�� ----------<<<<<

            // ���i���ݒ�C�x���g�R�[��
            this.SettingGoodsPriceEventCall(this.GetActiveRowRowNo());

            // �O���b�h�Z���ݒ菈��
            this.SettingGridRow(this.GetActiveRowIndex());
        }

        /// <summary>
        /// CellDataError�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_CellDataError(object sender, Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs e)
        {
            if (this.uGrid_GoodsPriceInfo.ActiveCell != null)
            {
                // ���l���ڂ̏ꍇ
                if ((this.uGrid_GoodsPriceInfo.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_GoodsPriceInfo.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_GoodsPriceInfo.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_GoodsPriceInfo.ActiveCell.EditorResolved;

                    // �����͂�0�ɂ���
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_GoodsPriceInfo.ActiveCell.Value = 0;
                    }
                    // ���l���ڂɁu-�vor�u.�v�������������ĂȂ�������ʖڂł�
                    else if ((editorBase.CurrentEditText.Trim() == "-") ||
                        (editorBase.CurrentEditText.Trim() == ".") ||
                        (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = 0;				// 0���Z�b�g
                        this.uGrid_GoodsPriceInfo.ActiveCell.Value = 0;
                    }
                    // �ʏ����
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_GoodsPriceInfo.ActiveCell.Column.DataType);
                            this.uGrid_GoodsPriceInfo.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;
                            this.uGrid_GoodsPriceInfo.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                // ���t�̏ꍇ
                else if ( this.uGrid_GoodsPriceInfo.ActiveCell.Column.DataType == typeof( DateTime ) )
                {
                    this.uGrid_GoodsPriceInfo.ActiveCell.Value = DateTime.MinValue;

                    e.RaiseErrorEvent = false;			// �G���[�C�x���g�͔��������Ȃ�
                    e.RestoreOriginalValue = false;		// �Z���̒l�����ɖ߂��Ȃ�
                    e.StayInEditMode = false;			// �ҏW���[�h�͔�����
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
            }
        }
        
        private void uGrid_GoodsPriceInfo_Leave( object sender, EventArgs e )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/18 ADD
            if ( uGrid_GoodsPriceInfo.ActiveRow != null )
            {
                uGrid_GoodsPriceInfo.ActiveRow.Selected = false;
                uGrid_GoodsPriceInfo.ActiveRow = null;
                uGrid_GoodsPriceInfo.Invalidate();

                // ADD 2010/01/05 MANTIS�Ή�[14816]�F���i���̍Čv�Z�����̏C�� ---------->>>>>
                // MEMO:�A�N�e�B�u�s�̃f�[�^�ŉ��i�����Čv�Z����̂ŁA�A�N�e�B�u��
                this.uGrid_GoodsPriceInfo.Rows[CurrentRowIndex].Activate();
                // ADD 2010/01/05 MANTIS�Ή�[14816]�F���i���̍Čv�Z�����̏C�� ----------<<<<<
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/18 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/24 ADD
        /// <summary>
        /// �R���g���[�����͉E�s�ݒ�
        /// </summary>
        /// <param name="enabled"></param>
        public void SettingEnabled( bool enabled )
        {
            _parentEnabled = enabled;
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_GoodsPriceInfo.DisplayLayout.Bands[0].Columns;

            try
            {
                if ( enabled )
                {
                    // �J��������Activation�ݒ�
                    Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
                    //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
                    Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
                    Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
                    Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
                else
                {
                    // �S�J������Activation��Disabled�ɂ���
                    Columns[this._goodsPriceDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 DEL
                    //Columns[this._goodsPriceDataTable.PriceStartDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
                    Columns[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    Columns[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    Columns[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
                    Columns[this._goodsPriceDataTable.ListPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    Columns[this._goodsPriceDataTable.OpenPriceDivColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    Columns[this._goodsPriceDataTable.StockRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    Columns[this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                    Columns[this._goodsPriceDataTable.OfferDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                }
            }
            catch
            { 
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
        private bool KeyPressNumCheck( int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg )
        {
            // ����L�[�������ꂽ�H
            if ( Char.IsControl( key ) )
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if ( !Char.IsDigit( key ) )
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ( (key != '.') && (key != '-') )
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if ( sellength > 0 )
            {
                _strResult = prevVal.Substring( 0, selstart ) + prevVal.Substring( selstart + sellength, prevVal.Length - (selstart + sellength) );
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if ( key == '-' )
            {
                if ( (minusFlg == false) || (selstart > 0) || (_strResult.IndexOf( '-' ) != -1) )
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if ( key == '.' )
            {
                if ( (priod <= 0) || (_strResult.IndexOf( '.' ) != -1) )
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring( 0, selstart )
                + key
                + prevVal.Substring( selstart + sellength, prevVal.Length - (selstart + sellength) );

            // �����`�F�b�N�I
            if ( _strResult.Length > keta )
            {
                if ( _strResult[0] == '-' )
                {
                    if ( _strResult.Length > (keta + 1) )
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
            if ( priod > 0 )
            {
                // �����_�̈ʒu����
                int _pointPos = _strResult.IndexOf( '.' );

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if ( _pointPos != -1 )
                {
                    if ( _pointPos > _Rketa )
                    {
                        return false;
                    }
                }
                else
                {
                    if ( _strResult.Length > _Rketa )
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if ( _pointPos != -1 )
                {
                    // �������̌������v�Z
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if ( priod < _priketa )
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// �O���b�h�E�L�[�v���X�E�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_GoodsPriceInfo_KeyPress( object sender, KeyPressEventArgs e )
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = uGrid_GoodsPriceInfo.ActiveCell;
            if ( cell == null ) return;


            if ( cell.Column.Key == this._goodsPriceDataTable.ListPriceColumn.ColumnName )
            {
                //----------------------------------------
                // �W�����i
                //----------------------------------------
                if ( cell.IsInEditMode )
                {
                    if ( !KeyPressNumCheck( 9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false ) )
                    {
                        // �C�x���g�����ς݂ɂ���
                        e.Handled = true;
                    }
                }
            }
            else if (cell.Column.Key == this._goodsPriceDataTable.StockRateColumn.ColumnName) 
            {
                //----------------------------------------
                // �d����
                //----------------------------------------
                if ( cell.IsInEditMode )
                {
                    if ( !KeyPressNumCheck( 6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false ) )
                    {
                        // �C�x���g�����ς݂ɂ���
                        e.Handled = true;
                    }
                }
            }
            else if (cell.Column.Key == this._goodsPriceDataTable.SalesUnitCostColumn.ColumnName)
            {
                //----------------------------------------
                // ���P��
                //----------------------------------------
                if ( cell.IsInEditMode )
                {
                    // 2008.11.18 UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //if (!KeyPressNumCheck(12, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    if (!KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    // 2008.11.18 UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        // �C�x���g�����ς݂ɂ���
                        e.Handled = true;
                    }
                }
            }
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
            else if ( cell.Column.Key == this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName )
            {
                //----------------------------------------
                // ���i�J�n��(�Nyyyy)
                //----------------------------------------
                if ( cell.IsInEditMode )
                {
                    if ( !KeyPressNumCheck( 4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false ) )
                    {
                        // �C�x���g�����ς݂ɂ���
                        e.Handled = true;
                    }
                }
            }
            else if ( cell.Column.Key == this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName )
            {
                //----------------------------------------
                // ���i�J�n��(��mm)
                //----------------------------------------
                if ( cell.IsInEditMode )
                {
                    if ( !KeyPressNumCheck( 2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false ) )
                    {
                        // �C�x���g�����ς݂ɂ���
                        e.Handled = true;
                    }
                }
            }
            else if ( cell.Column.Key == this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName )
            {
                //----------------------------------------
                // ���i�J�n��(��dd)
                //----------------------------------------
                if ( cell.IsInEditMode )
                {
                    if ( !KeyPressNumCheck( 2, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false ) )
                    {
                        // �C�x���g�����ς݂ɂ���
                        e.Handled = true;
                    }
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/24 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/13 ADD
        /// <summary>
        /// ���i�J�n���̐V���͒l�擾(BeforeCellUpdate�C�x���g��p)
        /// </summary>
        /// <param name="columnKey"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private DateTime GetPriceStartDateFromNewInput( string columnKey, Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs e )
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = e.Cell;

            string mode;
            # region [mode�m��]
            const string ct_Year = "Year";
            const string ct_Month = "Month";
            const string ct_Day = "Day";

            if ( columnKey == this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName )
            {
                mode = ct_Month;
            }
            else if ( columnKey == this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName )
            {
                mode = ct_Day;
            }
            else
            {
                mode = ct_Year;
            }
            # endregion

            // �N�����̊e�l���擾
            int yy = 0;
            int mm = 0;
            int dd = 0;

            # region [yy/mm/dd�擾]
            if ( mode == ct_Year )
            {
                yy = (Int32)e.NewValue;
            }
            else
            {
                if ( cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value != DBNull.Value )
                {
                    yy = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateYearColumn.ColumnName].Value;
                }
            }

            if ( mode == ct_Month )
            {
                mm = (Int32)e.NewValue;
            }
            else
            {
                if ( cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value != DBNull.Value )
                {
                    mm = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateMonthColumn.ColumnName].Value;
                }
            }

            if ( mode == ct_Day )
            {
                dd = (Int32)e.NewValue;
            }
            else
            {
                if ( cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value != DBNull.Value )
                {
                    dd = (Int32)cell.Row.Cells[this._goodsPriceDataTable.PriceStartDateDayColumn.ColumnName].Value;
                }
            }
            # endregion

            DateTime inputDate;
            # region [���͂��ꂽ���t�̎擾]
            try
            {
                inputDate = new DateTime( yy, mm, dd );
            }
            catch
            {
                inputDate = DateTime.MinValue;
            }
            # endregion


            return inputDate;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/13 ADD
    }
}
