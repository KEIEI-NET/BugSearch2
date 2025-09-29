using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�����o�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�����o�^�̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2008.05.23</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.05.23 20056 ���n ��� �V�K�쐬</br>
    /// </remarks>
    public partial class MAHNB01010UL : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private SalesSlipInputAcs _salesSlipInputAcs;
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private SalesInputDataSet.AutoEntryGoodsDataTable _autoEntryGoodsDataTable;
        private DataView _autoEntryGoodsView = null;
        private ImageList _imageList16 = null;									// �C���[�W���X�g
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;		// �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _decisionButton;	// �m��{�^��
        private DialogResult _dialogRes = DialogResult.Cancel;                  // �_�C�A���O���U���g

        private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
        private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        public MAHNB01010UL()
        {
            InitializeComponent();

            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();

            this._autoEntryGoodsDataTable = new SalesInputDataSet.AutoEntryGoodsDataTable();

            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Close"];
            this._decisionButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager1.Tools["ButtonTool_Decision"];
        }
        # endregion

        // ===================================================================================== //
        // �e��R���|�[�l���g�C�x���g�����S
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// �t�H�[��Load�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UI_Load(object sender, EventArgs e)
        {
            //---------------------------------------------------------
            // �c�[���o�[�{�^�������ݒ�
            //---------------------------------------------------------
            this.ButtonInitialSetting();

            //---------------------------------------------------------
            // �����ݒ�^�C�}�[�N��
            //---------------------------------------------------------
            this.Initial_Timer.Enabled = true;

            //---------------------------------------------------------
            // ���i�����o�^�f�[�^�e�[�u��
            //---------------------------------------------------------
            this._autoEntryGoodsDataTable = this._salesSlipInputAcs.AutoEntryGoodsDataTable;

            //---------------------------------------------------------
            // �O���b�h���ݒ�
            //---------------------------------------------------------
            this._autoEntryGoodsView = this._autoEntryGoodsDataTable.DefaultView;
            this.uGrid_AutoEntryGoods.DataSource = this._autoEntryGoodsView;
        }

        /// <summary>
        /// Timer.Tick �C�x���g �C�x���g(Initial_Timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///	                 ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///	                 �X���b�h�Ŏ��s����܂��B</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // �����ݒ�^�C�}�[����
            this.Initial_Timer.Enabled = false;

            // �����t�H�[�J�X�ʒu�w��
            this.uGrid_AutoEntryGoods.Focus();
            this.uGrid_AutoEntryGoods.Rows[0].Selected = true;
        }

        /// <summary>
        /// �t�H�[�J�X�R���g���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // ���ו�
                //---------------------------------------------------------------
                case "uGrid_AutoEntryGoods":
                    {
                        switch (e.Key)
                        {
                            case Keys.Return:
                                {
                                    // �A�N�e�B�u�s�I���^�C�}�[�N��
                                    this.timer_SelectRow.Enabled = true;
                                    e.NextCtrl = e.PrevCtrl;
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tToolbarsManager1_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                //--------------------------------------------
                // �I��
                //--------------------------------------------
                case "ButtonTool_Close":
                    {
                        this.SetDialogRes(DialogResult.Cancel);
                        this.CloseForm();
                        break;
                    }
                //--------------------------------------------
                // �S�I��
                //--------------------------------------------
                case "ButtonTool_AllSelect":
                    {
                        this.SetRowSelectedAll(true);
                        this.ChangedSelectColorAll(true);
                        break;
                    }
                //--------------------------------------------
                // �S����
                //--------------------------------------------
                case "ButtonTool_AllCancel":
                    {
                        this.SetRowSelectedAll(false);
                        this.ChangedSelectColorAll(false);
                        break;
                    }
                //--------------------------------------------
                // �m��
                //--------------------------------------------
                case "ButtonTool_Decision":
                    {
                        this._salesSlipInputAcs.AutoEntryGoodsDataTable = this._autoEntryGoodsDataTable;
                        this.SetDialogRes(DialogResult.OK);
                        this.CloseForm();
                        break;
                    }
            }
        }

        /// <summary>
        /// �t�H�[���N���[�Y�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UI_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = _dialogRes;
        }

        /// <summary>
        /// InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_CompleteInfo_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_AutoEntryGoods.DisplayLayout.Bands[0].Columns;

            // ��U�A�S�Ă̗���\���ɂ���B
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn column in Columns)
            {
                //��\���ݒ�
                column.Hidden = true;
            }

            int visiblePosition = 0;

            //--------------------------------------------------------------------------------
            //  �\������J�������
            //--------------------------------------------------------------------------------
            this.uGrid_AutoEntryGoods.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            this.uGrid_AutoEntryGoods.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.uGrid_AutoEntryGoods.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_AutoEntryGoods.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_AutoEntryGoods.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_AutoEntryGoods.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // ��
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._autoEntryGoodsDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �I���t���O
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Header.Fixed = true;		    // �Œ荀��
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Width = 30;
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].AutoEdit = true;
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // �a�k�R�[�h
            Columns[this._autoEntryGoodsDataTable.BLGoodsCodeColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._autoEntryGoodsDataTable.BLGoodsCodeColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.BLGoodsCodeColumn.ColumnName].Width = 40;
            Columns[this._autoEntryGoodsDataTable.BLGoodsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.BLGoodsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // �i��
            Columns[this._autoEntryGoodsDataTable.GoodsNameColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._autoEntryGoodsDataTable.GoodsNameColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.GoodsNameColumn.ColumnName].Width = 150;
            Columns[this._autoEntryGoodsDataTable.GoodsNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.GoodsNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // �i��
            Columns[this._autoEntryGoodsDataTable.GoodsNoColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._autoEntryGoodsDataTable.GoodsNoColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.GoodsNoColumn.ColumnName].Width = 120;
            Columns[this._autoEntryGoodsDataTable.GoodsNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.GoodsNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // ���[�J�[
            Columns[this._autoEntryGoodsDataTable.GoodsMakerCdColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._autoEntryGoodsDataTable.GoodsMakerCdColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.GoodsMakerCdColumn.ColumnName].Width = 50;
            Columns[this._autoEntryGoodsDataTable.GoodsMakerCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.GoodsMakerCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // �d����
            Columns[this._autoEntryGoodsDataTable.SupplierCdColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._autoEntryGoodsDataTable.SupplierCdColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.SupplierCdColumn.ColumnName].Width = 60;
            Columns[this._autoEntryGoodsDataTable.SupplierCdColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.SupplierCdColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // �艿
            Columns[this._autoEntryGoodsDataTable.ListPriceColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._autoEntryGoodsDataTable.ListPriceColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.ListPriceColumn.ColumnName].Width = 70;
            Columns[this._autoEntryGoodsDataTable.ListPriceColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.ListPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // ������
            Columns[this._autoEntryGoodsDataTable.CostRateColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._autoEntryGoodsDataTable.CostRateColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.CostRateColumn.ColumnName].Width = 60;
            Columns[this._autoEntryGoodsDataTable.CostRateColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.CostRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // �����P��
            Columns[this._autoEntryGoodsDataTable.SalesUnitCostColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._autoEntryGoodsDataTable.SalesUnitCostColumn.ColumnName].Hidden = false;
            Columns[this._autoEntryGoodsDataTable.SalesUnitCostColumn.ColumnName].Width = 70;
            Columns[this._autoEntryGoodsDataTable.SalesUnitCostColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._autoEntryGoodsDataTable.SalesUnitCostColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            // �Œ���؂���ݒ�
            this.uGrid_AutoEntryGoods.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_AutoEntryGoods.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        /// <summary>
        /// �O���b�h�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_AutoEntryGoods_Click(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElement���擾����B
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // �}�E�X�|�C���^�[����̃w�b�_��ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
              (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));

            // �I���`�F�b�N
            if (objCell == objRow.Cells[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName])
            {
                this.ChangedSelect(objRow);
            }
        }

        /// <summary>
        /// �O���b�h�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_AutoEntryGoods_DoubleClick(object sender, EventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // �}�E�X�|�C���^���O���b�h�̂ǂ̈ʒu�ɂ��邩�𔻒肷��
            Point point = System.Windows.Forms.Cursor.Position;
            point = targetGrid.PointToClient(point);

            // UIElement���擾����B
            Infragistics.Win.UIElement objUIElement = targetGrid.DisplayLayout.UIElement.ElementFromPoint(point);
            if (objUIElement == null)
                return;

            // �}�E�X�|�C���^�[����̃w�b�_��ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.ColumnHeader objHeader =
              (Infragistics.Win.UltraWinGrid.ColumnHeader)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.ColumnHeader));

            if (objHeader != null) return;

            // �}�E�X�|�C���^�[���s�̏�ɂ��邩�`�F�b�N�B
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow =
              (Infragistics.Win.UltraWinGrid.UltraGridRow)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            if (objRow == null) return;

            // �`�F�b�N���]
            this.ChangedSelect(objRow);
        }

        /// <summary>
        /// �I���s���擾�^�C�}�[�N���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void timer_SelectRow_Tick(object sender, EventArgs e)
        {
            this.timer_SelectRow.Enabled = false;
            if (this.uGrid_AutoEntryGoods.ActiveRow != null)
            {
                // �I�� or ����
                this.ChangedSelect(this.uGrid_AutoEntryGoods.ActiveRow);
            }
        }

        /// <summary>
        /// �O���b�h�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_AutoEntryGoods_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    // �A�N�e�B�u�s�I���^�C�}�[�N��
                    this.timer_SelectRow.Enabled = true;
                    break;
            }
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager1.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._decisionButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        private void CloseForm()
        {
            //---------------------------------------------------------
            // ���i�����o�^�f�[�^�e�[�u��
            //---------------------------------------------------------
            this._salesSlipInputAcs.AutoEntryGoodsDataTable = this._autoEntryGoodsDataTable;

            this.Close();
        }

        /// <summary>
        /// �_�C�A���O���U���g�ݒ菈��
        /// </summary>
        /// <param name="dialogRes">�_�C�A���O���U���g</param>
        private void SetDialogRes(DialogResult dialogRes)
        {
            _dialogRes = dialogRes;
        }

        #region �I���E��I��ύX����
        /// <summary>
        /// �I���E���I��ύX�����i���]�j
        /// </summary>
        /// <param name="gridRow"></param>
        private void ChangedSelect(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            bool newSelectedValue = !(bool)gridRow.Cells[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Value;

            // �e�[�u���X�V
            gridRow.Cells[this._autoEntryGoodsDataTable.CheckedColumn.ColumnName].Value = newSelectedValue;

            // �w�i�F��ύX
            ChangedSelectColor(newSelectedValue, gridRow);
        }
        /// <summary>
        /// �I���E��I��ύX�����i�w�i�F�̂݁j
        /// </summary>
        /// <param name="isSelected"></param>
        /// <param name="gridRow"></param>
        private void ChangedSelectColor(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            if (gridRow == null) return;

            // �Ώۍs�̑I��F��ݒ肷��
            if (isSelected)
            {
                gridRow.Appearance.BackColor = _selectedBackColor;
                gridRow.Appearance.BackColor2 = _selectedBackColor2;
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            }
            else
            {
                if (gridRow.Index % 2 == 1)
                {
                    gridRow.Appearance.BackColor = Color.Lavender;
                }
                else
                {
                    gridRow.Appearance.BackColor = Color.White;
                }
                gridRow.Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Default;
            }
        }
        /// <summary>
        /// �S�Ă̍s�̔w�i�F�ύX
        /// </summary>
        /// <param name="isSelected"></param>
        private void ChangedSelectColorAll(bool isSelected)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in this.uGrid_AutoEntryGoods.Rows)
            {
                ChangedSelectColor(isSelected, row);
            }
        }
        /// <summary>
        /// �S�Ă̍s�̑I���`�F�b�N���Z�b�g
        /// </summary>
        public void SetRowSelectedAll(bool rowSelected)
        {
            // �S�Ă̍s�̑I���`�F�b�N��ݒ�
            foreach (DataRow row in this._autoEntryGoodsDataTable.Rows)
            {
                row[this._salesSlipInputAcs.AutoEntryGoodsDataTable.CheckedColumn] = rowSelected;
            }
        }
        # endregion

        /// <summary>
        /// uButton_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uButton_Close_Click(object sender, EventArgs e)
        {

            this.SetDialogRes(DialogResult.Cancel);
            this.CloseForm();
        }
        # endregion
    }
}