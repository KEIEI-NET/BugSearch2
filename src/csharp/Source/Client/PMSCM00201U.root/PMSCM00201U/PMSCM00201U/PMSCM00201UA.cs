//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ȒP�⍇���ڑ����t�H�[���N���X
// �v���O�����T�v   : �ȒP�⍇���ڑ�����\���E�N���A����
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10601193-00  �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/03/25  �C�����e : 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Broadleaf.Library.Windows.Forms;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �ȒP�⍇���ڑ����t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �V�K�쐬</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/03/25</br>
    /// </remarks>
    public partial class PMSCM00201UA : Form
    {

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region �� Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public PMSCM00201UA()
        {
            InitializeComponent();
            // �ϐ�������
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            this._clearButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Clear"];
            this._sectionTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionTitle"];
            this._sectionNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_SectionName"];
            this._loginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginTitle"];
            this._loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolbarsManager_MainMenu.Tools["LabelTool_LoginName"];
            // ���O�C���S����
            this._loginNameLabel.SharedProps.Caption = LoginInfoAcquisition.Employee.Name;
            this._controlScreenSkin = new ControlScreenSkin();
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Member

        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;          // �I���{�^��
        private Infragistics.Win.UltraWinToolbars.ButtonTool _clearButton;          // �N���A�{�^��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginTitleLabel;       // ���O�C���S���҃��x��
        private Infragistics.Win.UltraWinToolbars.LabelTool _loginNameLabel;		// ���O�C���S���Җ���
        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionTitleLabel;     // ���O�C���S���҃��x��
        private Infragistics.Win.UltraWinToolbars.LabelTool _sectionNameLabel;		// ���O�C���S���Җ���
        private SimplInqCnectInfoAcs _simplInqCnectInfoAcs = new SimplInqCnectInfoAcs();
        private ControlScreenSkin _controlScreenSkin;
        private DataView _dataView;
        private bool closeFlg = true;

        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Method

        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolbarsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._clearButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            this._loginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            this._sectionTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            // ���_����
            this._sectionNameLabel.SharedProps.Caption = this._simplInqCnectInfoAcs.GetOwnSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        private int Clear()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ��ʃN���A
            this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.Clear();

            // ����������
            status = this._simplInqCnectInfoAcs.Search(LoginInfoAcquisition.EnterpriseCode);
            this.uCheckEditor_Own.Checked = true;

            if (this.uGrid_Result.Rows.Count > 0)
            {
                this.uGrid_Result.Select();
                this.uGrid_Result.Rows[0].Selected = true;
                this.uGrid_Result.Rows[0].Activate();
            }

            return status;
        }

        /// <summary>
        /// ��ʕۑ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        private void Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.AcceptChanges();
            // �ۑ��`�F�b�N
            bool check = this.CheckSaveData();

            if (!check)
            {
                return;
            }

            DialogResult ret = TMsgDisp.Show(
                this,
                emErrorLevel.ERR_LEVEL_INFO,
                this.Name,
                "�I�����ꂽ�ڑ������N���A���܂��B" + Environment.NewLine + "��낵���ł����H",
                -1, MessageBoxButtons.YesNo,
                MessageBoxDefaultButton.Button2);

            if (ret == DialogResult.Yes)
            {
                // �ۑ�����
                status = this._simplInqCnectInfoAcs.Save(LoginInfoAcquisition.EnterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_INFO,
                       this.Name,
                       "�ڑ������N���A���܂����B",
                       -1,
                       MessageBoxButtons.OK);

                    this.Clear();
                }
                else
                {
                    // ���b�Z�[�W���Ăяo��
                    TMsgDisp.Show(
                       this,
                       emErrorLevel.ERR_LEVEL_STOPDISP,
                       this.Name,
                       "�ڑ������N���A�Ɏ��s���܂����B",
                       -1,
                       MessageBoxButtons.OK);
                    // �󔒍s��ǉ�����
                }
            }
        }

        /// <summary>
        /// �ۑ��O�`�F�b�N
        /// </summary>
        /// <returns>�t���O</returns>
        /// <remarks>
        /// <br>Note       : �V�K�쐬</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        private bool CheckSaveData()
        {
            // ���݃t���O
            bool isExistFlg = false;

            string defFilter = this._dataView.RowFilter;
            string filter = this._dataView.RowFilter;

            this.uGrid_Result.BeginUpdate();
            try
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";

                filter += string.Format("{0} = True", this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName);

                this._dataView.RowFilter = filter;


                isExistFlg = ( this._dataView.Count > 0 );
            }
            finally
            {
                this._dataView.RowFilter = defFilter;
                this.uGrid_Result.EndUpdate();
            }
            if (!isExistFlg)
            {
                 TMsgDisp.Show(
                           this,
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           this.Name,
                           "�f�[�^���I������Ă��܂���B",
                           -1,
                           MessageBoxButtons.OK);

                 return false;
            }

            return true;
        }

        /// <summary>
        /// �f�[�^�Ƀt�B���^�������܂��B
        /// </summary>
        /// <param name="mode">0:���[���̃f�[�^�̂݁A1:�S�ĕ\��</param>
        private void DataFilter(int mode)
        {
            string filter = string.Empty;

            // ��U�S���I������������
            this.button_AllCancel_Click(this.button_AllCancel, new EventArgs());

            switch (mode)
            {
                case 0:
                    filter = string.Format("{0}={1}", this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CashRegisterNoColumn.ColumnName, this._simplInqCnectInfoAcs.GetOwnCashRegisterNo(LoginInfoAcquisition.EnterpriseCode));
                    break;
                case 1:
                    break;
            }
            this._dataView.RowFilter = filter;
        }

        /// <summary>
        /// �I���E��I��ύX�����i���]�j
        /// </summary>
        /// <param name="gridRow"></param>
        private void ChangedSelect(Infragistics.Win.UltraWinGrid.UltraGridRow gridRow)
        {
            bool newSelectedValue = !(bool)gridRow.Cells[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName].Value;

            gridRow.Cells[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName].Value = newSelectedValue;
        }

        #endregion

        // ===================================================================================== //
        // �e�R���g���[���C�x���g����
        // ===================================================================================== //
        # region ��Control Event Methods
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void PMKYO09301UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.uGroupBox_ExtractInfo.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);
            this._controlScreenSkin.SettingScreenSkin(this.uGrid_Result);

            this._dataView = this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.DefaultView;
            this._dataView.Sort = string.Format("{0},{1}", this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CashRegisterNoColumn.ColumnName, this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerCodeColumn.ColumnName);
            this.uGrid_Result.DataSource = this._dataView;

            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();

            // ����������
            closeFlg = true;
            int status = this.Clear();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this.closeFlg = false;
                return;
            }

            this.timer_setFocus.Enabled = true;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uGrid_Result_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Result.DisplayLayout.Bands[0];
            if (editBand == null) return;

            // �O���b�h
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CashRegisterNoColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.MachineNameColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerCodeColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerSnmColumn.ColumnName].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;

            // CellAppearance�ݒ�
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CashRegisterNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.MachineNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerSnmColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;

            //// �\�����ݒ�
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName].Width = 60;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CashRegisterNoColumn.ColumnName].Width = 80;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.MachineNameColumn.ColumnName].Width = 170;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerCodeColumn.ColumnName].Width = 164;
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerSnmColumn.ColumnName].Width = 240;

            // �t�H�[�}�b�g
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CashRegisterNoColumn.ColumnName].Format = "000";
            this.uGrid_Result.DisplayLayout.Bands[0].Columns[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.CustomerCodeColumn.ColumnName].Format = "00000000";

            // �Œ���؂���ݒ�
            //this.uGrid_Result.DisplayLayout.Override.FixedCellSeparatorColor = this.uGrid_Result.DisplayLayout.Override.HeaderAppearance.BackColor2;
        }

        
        /// <summary>
        /// ChangeFocus�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "uGrid_Result":
                    {
                        
                        break;
                    }
                default:
                    break;
            }

            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "uGrid_Result":
                        {
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            {
                                if (e.NextCtrl == this.uGrid_Result)
                                {
                                }
                            }
                            break;
                        }
                    default:
                        break;
                }
            }

            // �폜�{�^����Ԑݒ�
           this.DelButtonSetting();
        }

        /// <summary>
        /// �폜�{�^����Ԑݒ�
        /// </summary>
        private void DelButtonSetting()
        {
            Infragistics.Win.UltraWinGrid.UltraGridCell cell = this.uGrid_Result.ActiveCell;
            Infragistics.Win.UltraWinGrid.SelectedRowsCollection rows = this.uGrid_Result.Selected.Rows;
            if ((cell == null) && (rows == null || rows.Count == 0)) return;

            // �A�N�e�B�u�s�擾
            int activeRowIndex;
            if (this.uGrid_Result.ActiveRow != null)
            {
                activeRowIndex = this.uGrid_Result.ActiveRow.Index;
            }
            else
            {
                if (this.uGrid_Result.ActiveCell != null)
                {
                    activeRowIndex = this.uGrid_Result.ActiveCell.Row.Index;
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void timer_setFocus_Tick(object sender, EventArgs e)
        {
            if (closeFlg)
            {
                // �t�H�[�J�X�ݒ�
                this.uGrid_Result.PerformAction(UltraGridAction.EnterEditMode);
            }

            this.timer_setFocus.Enabled = false;
        }

        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // ��ʂ����
                        this.Close();
                        break;
                    }
                case "ButtonTool_Clear":
                    {
                        this.Save();
                        break;
                    }
            }
        }

        /// <summary>
        /// �`�F�b�N�G�f�B�^ �`�F�b�N�ύX�������C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uCheckEditor_Own_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == this.uCheckEditor_Own )
            {
                if (this.uCheckEditor_Own.Checked)
                {
                    this.DataFilter(0);
                    this.uCheckEditor_All.Checked = false;
                }
                else
                {
                    if (!this.uCheckEditor_All.Checked)
                    {
                        this.uCheckEditor_Own.Checked = true;
                    }
                }
            }
            else if (sender == this.uCheckEditor_All)
            {
                if (this.uCheckEditor_All.Checked)
                {
                    this.DataFilter(1);
                    this.uCheckEditor_Own.Checked = false;
                }
                else
                {
                    if (!this.uCheckEditor_Own.Checked)
                    {
                        this.uCheckEditor_All.Checked = true;
                    }
                }
            }
        }

        /// <summary>
        /// �S�đI���{�^�� �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AllSelect_Click(object sender, EventArgs e)
        {
            this.uGrid_Result.BeginUpdate();
            foreach (DataRowView dv in this._dataView)
            {
                dv[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName] = true;
            }

            this.uGrid_Result.EndUpdate();
        }

        /// <summary>
        /// �S�ĉ����{�^�� �N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AllCancel_Click(object sender, EventArgs e)
        {
            this.uGrid_Result.BeginUpdate();
            foreach (DataRowView dv in this._dataView)
            {
                dv[this._simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName] = false;
            }
            this.uGrid_Result.EndUpdate();
        }


        /// <summary>
        /// �}�E�X�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Result_DoubleClick(object sender, EventArgs e)
        {

            Infragistics.Win.UltraWinGrid.UltraGrid targetGrid = (Infragistics.Win.UltraWinGrid.UltraGrid)sender;

            // �}�E�X���������Ō�̗v�f���擾���܂��B
            Infragistics.Win.UIElement lastElementEntered = targetGrid.DisplayLayout.UIElement.LastElementEntered;

            // �`�F�[������ RowUIElement �����邩�ǂ����𒲂ׂ܂��B
            Infragistics.Win.UltraWinGrid.RowUIElement rowElement;
            if (lastElementEntered is Infragistics.Win.UltraWinGrid.RowUIElement)
                rowElement = (Infragistics.Win.UltraWinGrid.RowUIElement)lastElementEntered;
            else
            {
                rowElement = (Infragistics.Win.UltraWinGrid.RowUIElement)lastElementEntered.GetAncestor(typeof(Infragistics.Win.UltraWinGrid.RowUIElement));
            }

            if (rowElement == null) return;

            // �v�f����s���擾���܂��B
            Infragistics.Win.UltraWinGrid.UltraGridRow objRow = (Infragistics.Win.UltraWinGrid.UltraGridRow)rowElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridRow));

            // �s���Ԃ���Ȃ������ꍇ�A�}�E�X�͍s�̏�ɂ���܂���B
            if (objRow == null)
                return;

            // �}�E�X�͍s�̏�ɂ���܂��B

            // ���̕����̓I�v�V�����ł��B�������A���[�U�[���s�Z���N�^�Ԃ̍s��
            // �_�u���N���b�N�����ꍇ�A�f�t�H���g�ōs�̃T�C�Y�������������܂��B
            // ���̏ꍇ�A�ʏ�A�_�u���N���b�N�R�[�h�͋L�q���܂���B

            // ���݂̃}�E�X�|�C���^�̈ʒu���擾���ăO���b�h���W�ɕϊ����܂��B
            Point MousePosition = targetGrid.PointToClient(Control.MousePosition);
            // ���W�_�� AdjustableElement ��ɂ��邩�ǂ����𒲂ׂ܂��B���Ȃ킿�A
            // ���[�U�[���s�Z���N�^��̍s���N���b�N���Ă��邩�ǂ����B
            if (lastElementEntered.AdjustableElementFromPoint(MousePosition) != null)
                return;

            if (objRow != null)
            {
                this.ChangedSelect(objRow);
            }
        }


        /// <summary>
        /// �O���b�h�@�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Result_Click(object sender, EventArgs e)
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

            if (objRow != null)
            {
                // �}�E�X�|�C���^�[������L���Z����ɂ��邩�H
                Infragistics.Win.UltraWinGrid.UltraGridCell objCell =
                  (Infragistics.Win.UltraWinGrid.UltraGridCell)objUIElement.GetContext(typeof(Infragistics.Win.UltraWinGrid.UltraGridCell));
                if (objCell != null)
                {
                    // ����t���O��
                    if (objCell.Column.Key == _simplInqCnectInfoAcs.SimplInqCnectInfoTable.SelectedColumn.ColumnName)
                    {
                        this.ChangedSelect(objRow);
                    }
                }

            }
        }

        /// <summary>
        /// �O���b�h�@�L�[�_�E���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Result_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Shift && !e.Control && !e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.Space:
                        if (this.uGrid_Result.ActiveRow != null)
                        {
                            this.ChangedSelect(this.uGrid_Result.ActiveRow);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion
    }
}