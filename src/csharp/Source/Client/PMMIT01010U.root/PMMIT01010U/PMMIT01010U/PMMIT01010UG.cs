using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �J���[�E�g�����E�������I���R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���q���̃J���[�E�g�����E�������̑I�����s���R���g���[���N���X�ł��B�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2008.05.13</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2008.05.13 ���n ��� �V�K�쐬</br>
    /// <br>UpDate:  2011/02/14 杍^</br>
    /// <br> �@�@�@�@�C���ďo���́u�J���[�E�g�����E�����v���̐���ύX</br>
    /// </remarks>
    public partial class PMMIT01010UG : UserControl
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        #region Private Members
        private EstimateInputAcs _salesSlipInputAcs;
        private PMKEN01010E.ColorCdInfoDataTable _colorCdInfoDataTable;
        private PMKEN01010E.TrimCdInfoDataTable _trimCdInfoDataTable;
        private PMKEN01010E.CEqpDefDspInfoDataTable _cEqpDefDspInfoDataTable;
        private Guid _carRelationGuid;

        private readonly Color _selectedBackColor = Color.FromArgb(216, 235, 253);
        private readonly Color _selectedBackColor2 = Color.FromArgb(101, 144, 218);

        // --- ADD 2011/02/14 -------- >>>>>
        private bool colorGridFlag = false;
        private bool trimGridFlag = false;
        // --- ADD 2011/02/14 -------- <<<<<
        #endregion

        // ===================================================================================== //
        // �f���Q�[�g
        // ===================================================================================== //
        #region Delegate
        /// <summary>
        /// �J���[���ݒ�f���Q�[�g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="colorCode"></param>
        internal delegate void SettingColorEventHandler(object sender, string colorCode);

        /// <summary>
        /// �g�������ݒ�f���Q�[�g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="trimCode"></param>
        internal delegate void SettingTrimEventHandler(object sender, string trimCode);
        #endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region Event
        /// <summary>�J���[���ݒ�C�x���g</summary>
        internal event SettingColorEventHandler SettingColorInfo;
        /// <summary>�g�������ݒ�C�x���g</summary>
        internal event SettingTrimEventHandler SettingTrimInfo;
        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region Properties
        /// <summary>
        /// �J���[���f�[�^�e�[�u��
        /// </summary>
        public PMKEN01010E.ColorCdInfoDataTable ColorCdInfoDataTable
        {
            set
            {
                this._colorCdInfoDataTable = value;
                this.uGrid_ColorInfo.DataSource = this._colorCdInfoDataTable;
            }
            get { return this._colorCdInfoDataTable; }
        }
        /// <summary>
        /// �g�������f�[�^�e�[�u��
        /// </summary>
        public PMKEN01010E.TrimCdInfoDataTable TrimCdInfoDataTable
        {
            set
            {
                this._trimCdInfoDataTable = value;
                this.uGrid_TrimInfo.DataSource = this._trimCdInfoDataTable;
            }
            get { return this._trimCdInfoDataTable; }
        }
        /// <summary>
        /// �������f�[�^�e�[�u��
        /// </summary>
		public PMKEN01010E.CEqpDefDspInfoDataTable CEqpDefDspInfoDataTable
		{
			set { this._cEqpDefDspInfoDataTable = value; }
			get { return this._cEqpDefDspInfoDataTable; }
		}

        /// <summary>
        /// ���q��񋤒ʃL�[
        /// </summary>
        public Guid CarRelationGuid
        {
            set { this._carRelationGuid = value; }
            get { return this._carRelationGuid; }
        }
        #endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region Constructors
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public PMMIT01010UG( EstimateInputAcs estimateInputAcs )
		{
            InitializeComponent();

			this._salesSlipInputAcs = estimateInputAcs;

			this._colorCdInfoDataTable = new PMKEN01010E.ColorCdInfoDataTable();
			this._trimCdInfoDataTable = new PMKEN01010E.TrimCdInfoDataTable();
			this._cEqpDefDspInfoDataTable = new PMKEN01010E.CEqpDefDspInfoDataTable();
			
		}
        #endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        #region Event
        /// <summary>
        /// �R���g���[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// �O���b�h���C�A�E�g�������C�x���g(�J���[���)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_ColorInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;

                if ((col.Key == this._colorCdInfoDataTable.ColorCodeColumn.ColumnName) ||
                    (col.Key == this._colorCdInfoDataTable.ColorName1Column.ColumnName) ||
                    (col.Key == this._colorCdInfoDataTable.SelectionStateColumn.ColumnName))
                {
                    col.Hidden = false;
                }
            }

            // �����������ݒ�
            this.uGrid_ColorInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // �Œ���؂���ݒ�
            this.uGrid_ColorInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_ColorInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// �O���b�h���C�A�E�g�������C�x���g(�g�������)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid2_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_TrimInfo.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // �S�Ă̗�����������\���ɂ���B
                col.Hidden = true;

                if ((col.Key == this._trimCdInfoDataTable.TrimCodeColumn.ColumnName) ||
                    (col.Key == this._trimCdInfoDataTable.TrimNameColumn.ColumnName) ||
                    (col.Key == this._trimCdInfoDataTable.SelectionStateColumn.ColumnName))
                {
                    col.Hidden = false;
                }
            }

            // �����������ݒ�
            this.uGrid_TrimInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // �Œ���؂���ݒ�
            this.uGrid_TrimInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_ColorInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// �O���b�h���C�A�E�g�������C�x���g(�������)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid3_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �����������ݒ�
            this.uGrid_EquipInfo.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;// ExtendLastColumn;

            // �Œ���؂���ݒ�
            this.uGrid_EquipInfo.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_ColorInfo.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        /// <summary>
        /// �O���b�h�N���b�N�C�x���g(�J���[���)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid1_Click(object sender, EventArgs e)
        {
            // --- ADD 2011/02/14 -------- >>>>>
            if (!colorGridFlag)
            {
                return;
            }
            // --- ADD 2011/02/14 -------- <<<<<

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

            string colorCode = (string)objRow.Cells[this._colorCdInfoDataTable.ColorCodeColumn.ColumnName].Value;

            //-----------------------------------------------------------
            // �J���[���ݒ菈��
            //-----------------------------------------------------------
            this.SettingColorInfoProc(colorCode);
        }

        /// <summary>
        /// �O���b�h�N���b�N�C�x���g(�g�������)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraGrid2_Click(object sender, EventArgs e)
        {
            // --- ADD 2011/02/14 -------- >>>>>
            if (!trimGridFlag)
            {
                return;
            }
            // --- ADD 2011/02/14 -------- <<<<<

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

            this.SettingTrimEventCall((string)objRow.Cells[this._trimCdInfoDataTable.TrimCodeColumn.ColumnName].Value);

            string trimCode = (string)objRow.Cells[this._trimCdInfoDataTable.TrimCodeColumn.ColumnName].Value;
            
            //-----------------------------------------------------------
            // �g�������ݒ菈��
            //-----------------------------------------------------------
            this.SettingTrimInfoProc(trimCode);
        }
        
        /// <summary>
        /// �Z�����X�g�Z���N�g�C�x���g(�������)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_EquipInfo_CellListSelect( object sender, CellEventArgs e )
        {

            int rowIndex = e.Cell.Row.Index;
            string key = (string)this.uGrid_EquipInfo.Rows[rowIndex].Cells["kind"].Value;
            Infragistics.Win.ValueList valueList = (Infragistics.Win.ValueList)this.uGrid_EquipInfo.Rows[rowIndex].Cells["value"].ValueList;
            int selectedIndex = 0;
            if (valueList != null) selectedIndex = valueList.SelectedIndex;

            //-----------------------------------------------------------
            // �������ݒ菈��
            //-----------------------------------------------------------
            this.SettingEquipInfoProc(key, selectedIndex);
        }


        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region Private Methods
        /// <summary>
        /// �J���[���ݒ菈��
        /// </summary>
        /// <param name="colorCode"></param>
        private void SettingColorInfoProc( string colorCode )
        {
            this.SettingColorEventCall(colorCode);
            this._salesSlipInputAcs.SelectColorInfo(this._carRelationGuid, colorCode);
        }

        /// <summary>
        /// �g�������ݒ菈��
        /// </summary>
        /// <param name="trimCode"></param>
        private void SettingTrimInfoProc( string trimCode )
        {
            this.SettingTrimEventCall(trimCode);
            this._salesSlipInputAcs.SelectTrimInfo(this._carRelationGuid, trimCode);
        }

        /// <summary>
        /// �������ݒ菈��
        /// </summary>
        /// <param name="equipmentGenreCd"></param>
        /// <param name="selectIndex"></param>
        private void SettingEquipInfoProc( string equipmentGenreCd, int selectIndex )
        {
            this._salesSlipInputAcs.SelectEquipInfo(this._carRelationGuid, equipmentGenreCd, selectIndex);
        }

        /// <summary>
        /// �J���[���ݒ�C�x���g�R�[��
        /// </summary>
        /// <param name="colorCode">�J���[�R�[�h</param>
        private void SettingColorEventCall( string colorCode )
        {
            if (this.SettingColorInfo != null) this.SettingColorInfo(this, colorCode);
        }

        /// <summary>
        /// �g�������ݒ�C�x���g�R�[��
        /// </summary>
        /// <param name="trimCode">�g�����R�[�h</param>
        private void SettingTrimEventCall( string trimCode )
        {
            if (this.SettingTrimInfo != null) this.SettingTrimInfo(this, trimCode);
        }
        /// <summary>
        /// �����O���b�h���C�A�E�g�ݒ菈��
        /// </summary>
        public void SettingEquipGridLayout()
        {
            
            if (( this._cEqpDefDspInfoDataTable != null ) && ( this._cEqpDefDspInfoDataTable.Count != 0 ))
            {
                this._cEqpDefDspInfoDataTable.BeginLoadData();
                try
                {
                    this.ultraDataSource1.Rows.Clear();
                    Dictionary<string, Infragistics.Win.ValueList> lst = this._cEqpDefDspInfoDataTable.GetEquipUIInfo();
                    foreach (string key in lst.Keys)
                    {
                        UltraGridRow row = this.uGrid_EquipInfo.DisplayLayout.Bands[0].AddNew();
                        row.Cells[0].Value = key;
                        row.Cells[1].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                        row.Cells[1].ValueList = lst[key];
                        if (lst[key].SelectedItem != null)
                        {
                            row.Cells[1].Value = lst[key].SelectedItem.ToString();
                        }
                    }
                }
                finally
                {
                    this._cEqpDefDspInfoDataTable.EndLoadData();
                }
            }
            else
            {
                this.ultraDataSource1.Rows.Clear();
            }
        }
        
        /// <summary>
        /// Return�L�[�_�E������
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        internal bool ReturnKeyDown(Control ctrl)
        {
            if (!(ctrl is UltraGrid)) return false;

            UltraGrid gridCtrl = (UltraGrid)ctrl;
            UltraGridRow row = null;
            if (gridCtrl.ActiveRow != null) row = gridCtrl.ActiveRow;

            switch (gridCtrl.Name)
            {
                //---------------------------------------------------------------
                // �J���[���O���b�h
                //---------------------------------------------------------------
                case "uGrid_ColorInfo":
                    {
                        string colorCode = string.Empty;
                        if (row != null)
                        {
                            colorCode = (string)row.Cells[this._colorCdInfoDataTable.ColorCodeColumn.ColumnName].Value;
                            this.SettingColorInfoProc(colorCode);
                        }
                        break;
                    }
                //---------------------------------------------------------------
                // �g�������O���b�h
                //---------------------------------------------------------------
                case "uGrid_TrimInfo":
                    {
                        string trimCode = string.Empty;
                        if (row != null)
                        {
                            trimCode = (string)row.Cells[this._trimCdInfoDataTable.TrimCodeColumn.ColumnName].Value;
                            this.SettingTrimInfoProc(trimCode);
                        }
                        break;
                    }
                //---------------------------------------------------------------
                // �������O���b�h
                //---------------------------------------------------------------
                case "uGrid_EquipInfo":
                    {
                        if (this.uGrid_EquipInfo.ActiveCell != null)
                        {
                            int rowIndex = this.uGrid_EquipInfo.ActiveCell.Row.Index;
                            string key = (string)this.uGrid_EquipInfo.Rows[rowIndex].Cells["kind"].Value;
                            Infragistics.Win.ValueList valueList = (Infragistics.Win.ValueList)this.uGrid_EquipInfo.Rows[rowIndex].Cells["value"].ValueList;
                            int selectedIndex = 0;
                            if (valueList != null) selectedIndex = valueList.SelectedIndex;
                            this.SettingEquipInfoProc(key, selectedIndex);
                        }
                        this.uGrid_EquipInfo.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        break;
                    }
            }

            return true;
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
        private void ChangedSelectColorAll(bool isSelected, Infragistics.Win.UltraWinGrid.UltraGrid ultraGrid)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in ultraGrid.Rows)
            {
                ChangedSelectColor(isSelected, row);
            }
        }
        #endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region Public Methods

        // --- ADD 2011/02/14 -------- >>>>>
        /// <summary>
        /// �J���[������ݒ菈��
        /// </summary>
        /// <param name="enableFlg"></param>
        public void uGrid_ColorInfoEnableSet(bool enableFlg)
        {
            if (enableFlg)
            {
                colorGridFlag = true;
            }
            else
            {
                colorGridFlag = false;
            }
        }

        /// <summary>
        /// �g����������ݒ菈��
        /// </summary>
        /// <param name="enableFlg"></param>
        public void uGrid_TrimInfoEnableSet(bool enableFlg)
        {
            if (enableFlg)
            {
                trimGridFlag = true;
            }
            else
            {
                trimGridFlag = false;
            }
        }

        /// <summary>
        /// ����������ݒ菈��
        /// </summary>
        /// <param name="enableFlg"></param>
        public void uGrid_EquipInfoEnableSet(bool enableFlg)
        {
            if (enableFlg)
            {
                this.uGrid_EquipInfo.DisplayLayout.Bands[0].Columns[1].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            }
            else
            {
                this.uGrid_EquipInfo.DisplayLayout.Bands[0].Columns[1].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
        }
        // --- ADD 2011/02/14 -------- <<<<<

        #endregion

    }
}
