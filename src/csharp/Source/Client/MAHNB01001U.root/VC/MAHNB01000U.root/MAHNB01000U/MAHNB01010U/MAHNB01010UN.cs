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
    /// BL�R�[�h�ϊ��I���t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL�R�[�h�ϊ��I���̃t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2009.07.30</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.07.30 20056 ���n ��� �V�K�쐬</br>
    /// </remarks>
    public partial class MAHNB01010UN : Form
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private SalesSlipInputAcs _salesSlipInputAcs;
        private SalesInputDataSet.BLCodeChgDataTable _blCodeChgDataTable;
        private DataView _blCodeChgView = null;
        private DialogResult _dialogRes = DialogResult.Cancel;                  // �_�C�A���O���U���g

        private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
        private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// MAHNB01010UN
        /// </summary>
        public MAHNB01010UN()
        {
            InitializeComponent();

            this._salesSlipInputAcs = SalesSlipInputAcs.GetInstance();
            this._blCodeChgDataTable = new SalesInputDataSet.BLCodeChgDataTable();
        }
        # endregion

        // ===================================================================================== //
        // �e��R���|�[�l���g�C�x���g�����S
        // ===================================================================================== //
        # region Event Methods
        /// <summary>
        /// MAHNB01010UN_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MAHNB01010UN_Load(object sender, EventArgs e)
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
            // BL�R�[�h�}�ԃf�[�^�e�[�u��
            //---------------------------------------------------------
            this._blCodeChgDataTable = this._salesSlipInputAcs.BLCodeChgDataTable;

            //---------------------------------------------------------
            // �O���b�h���ݒ�
            //---------------------------------------------------------
            this._blCodeChgView = this._blCodeChgDataTable.DefaultView;
            this.uGrid_SelectBLCodeChg.DataSource = this._blCodeChgView;
        }

        /// <summary>
        /// tArrowKeyControl1_ChangeFocus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                //---------------------------------------------------------------
                // ���ו�
                //---------------------------------------------------------------
                case "uGrid_SelectBLCodeChg":
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
        /// Initial_Timer_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // �����ݒ�^�C�}�[����
            this.Initial_Timer.Enabled = false;

            // �����t�H�[�J�X�ʒu�w��
            this.uGrid_SelectBLCodeChg.Focus();
            this.uGrid_SelectBLCodeChg.Rows[0].Selected = true;
        }

        /// <summary>
        /// uButton_Close_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>ESC�ŉ�ʏI�����s���Ƃ��Ɏg�p</remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            // �{�^���͉B��Ă܂�
            this.SetDialogRes(DialogResult.Cancel);
            this.CloseForm();
        }

        /// <summary>
        /// tToolbarsManager1_ToolClick
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
                // �m��
                //--------------------------------------------
                case "ButtonTool_Decision":
                    {
                        this.SetDialogRes(DialogResult.OK);
                        this.CloseForm();
                        break;
                    }
            }
        }

        /// <summary>
        /// ultraGrid1_InitializeLayout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_SelectBLCodeChg.DisplayLayout.Bands[0].Columns;

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
            this.uGrid_SelectBLCodeChg.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;
            this.uGrid_SelectBLCodeChg.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Extended;
            this.uGrid_SelectBLCodeChg.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_SelectBLCodeChg.DisplayLayout.Bands[0].Override.RowSizing = Infragistics.Win.UltraWinGrid.RowSizing.Fixed;
            this.uGrid_SelectBLCodeChg.DisplayLayout.Bands[0].Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free;// None;
            this.uGrid_SelectBLCodeChg.DisplayLayout.Bands[0].Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            // ��
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].Header.Fixed = true;				// �Œ荀��
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.BackColor2;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.ForeColor;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].Hidden = false;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].Width = 25;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.BackColor;
            Columns[this._blCodeChgDataTable.RowNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;

            // �I���t���O
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].Header.Fixed = true;		    // �Œ荀��
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].Hidden = true;
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].Width = 30;
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].AutoEdit = true;
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._blCodeChgDataTable.CheckedColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // �a�k�R�[�h
            Columns[this._blCodeChgDataTable.ChgTbsPartsCodeColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._blCodeChgDataTable.ChgTbsPartsCodeColumn.ColumnName].Hidden = false;
            Columns[this._blCodeChgDataTable.ChgTbsPartsCodeColumn.ColumnName].Width = 40;
            Columns[this._blCodeChgDataTable.ChgTbsPartsCodeColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._blCodeChgDataTable.ChgTbsPartsCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // �a�k�R�[�h�}��
            Columns[this._blCodeChgDataTable.ChgTbsPartsCdDerivedNoColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._blCodeChgDataTable.ChgTbsPartsCdDerivedNoColumn.ColumnName].Hidden = true;
            Columns[this._blCodeChgDataTable.ChgTbsPartsCdDerivedNoColumn.ColumnName].Width = 40;
            Columns[this._blCodeChgDataTable.ChgTbsPartsCdDerivedNoColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._blCodeChgDataTable.ChgTbsPartsCdDerivedNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            // �i��
            Columns[this._blCodeChgDataTable.TbsPartsFullNameColumn.ColumnName].Header.Fixed = false;				// �Œ荀��
            Columns[this._blCodeChgDataTable.TbsPartsFullNameColumn.ColumnName].Hidden = false;
            Columns[this._blCodeChgDataTable.TbsPartsFullNameColumn.ColumnName].Width = 150;
            Columns[this._blCodeChgDataTable.TbsPartsFullNameColumn.ColumnName].Header.VisiblePosition = visiblePosition++;
            Columns[this._blCodeChgDataTable.TbsPartsFullNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            // �Œ���؂���ݒ�
            this.uGrid_SelectBLCodeChg.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_SelectBLCodeChg.DisplayLayout.Override.HeaderAppearance.BackColor2;

        }

        /// <summary>
        /// uGrid_SelectBLGoodsDr_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_SelectSelectBLCodeChg_Click(object sender, EventArgs e)
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
            if (objCell == objRow.Cells[this._blCodeChgDataTable.CheckedColumn.ColumnName])
            {
                this.ChangedSelect(objRow);
            }
        }

        /// <summary>
        /// uGrid_SelectBLGoodsDr_DoubleClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_SelectSelectBLCodeChg_DoubleClick(object sender, EventArgs e)
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

            if (this.SelectedCheck(objRow))
            {
                this.SetDialogRes(DialogResult.OK);
                this.CloseForm();
            }
        }

        /// <summary>
        /// timer_SelectRow_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_SelectRow_Tick(object sender, EventArgs e)
        {
            this.timer_SelectRow.Enabled = false;
            if (this.uGrid_SelectBLCodeChg.ActiveRow != null)
            {
                // �I�� or ����
                this.ChangedSelect(this.uGrid_SelectBLCodeChg.ActiveRow);

                if (this.SelectedCheck(this.uGrid_SelectBLCodeChg.ActiveRow))
                {
                    this.SetDialogRes(DialogResult.OK);
                    this.CloseForm();
                }
            }
        }

        /// <summary>
        /// uGrid_SelectBLGoodsDr_KeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_SelectSelectBLCodeChg_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
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
        }

        /// <summary>
        /// ��ʏI������
        /// </summary>
        private void CloseForm()
        {
            this._salesSlipInputAcs.BLCodeChgDataTable = this._blCodeChgDataTable;
            this.DialogResult = this._dialogRes;
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
        /// �I���E��I��ύX�����i���]�j
        /// </summary>
        /// <param name="gridRow"></param>
        private void ChangedSelect(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            bool newSelectedValue = !(bool)gridRow.Cells[this._blCodeChgDataTable.CheckedColumn.ColumnName].Value;

            // �e�[�u���X�V
            gridRow.Cells[this._blCodeChgDataTable.CheckedColumn.ColumnName].Value = newSelectedValue;

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
        # endregion

        /// <summary>
        /// �I���`�F�b�N����
        /// </summary>
        /// <param name="gridRow"></param>
        /// <returns></returns>
        private bool SelectedCheck(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            bool selectedValue = (bool)gridRow.Cells[this._blCodeChgDataTable.CheckedColumn.ColumnName].Value;
            return selectedValue;
        }
        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region Public Methods
        /// <summary>
        /// �ϊ��O���ݒ菈��
        /// </summary>
        /// <param name="blCode"></param>
        /// <param name="name"></param>
        public void SettingOrgInfo(int blCode, string name)
        {
            if (blCode != 0)
            {
                this.uLabel_beforeBLCodeInfo.Text = blCode.ToString() + "�F" + name;
            }
            else
            {
                this.uLabel_beforeBLCodeInfo.Text = string.Empty;
            }
        }

        #endregion
    }
}