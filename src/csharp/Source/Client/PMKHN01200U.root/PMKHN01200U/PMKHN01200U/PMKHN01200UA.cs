//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �񋟃}�X�^�폜����
// �v���O�����T�v   : �񋟃f�[�^�d�����郆�[�U�[�����A�Z�b�g�}�X�^�̃��R�[�h���폜����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/06/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2009/07/10  �C�����e : �_�C�A���O�̒ǉ�
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
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �񋟃}�X�^�폜����
    /// </summary>
    /// <remarks>
    /// Note       : �񋟃}�X�^�폜�����ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009.06.18<br />
    /// </remarks>
    public partial class PMKHN01200UA : Form
    {
        #region �� Const Memebers ��
        // �e�[�u������
        private const string DETAILS_TABLE = "OfferMstDelTable";
        private const string PROGRAM_ID = "PMKHN01200U";
        private const string MARK_MARU = "��";
        private const string MARK_EMPTY = "";
        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string NUMBER_TITLE = "NO.";
        private const string OBJECT_GROUP_TITLE = "�Ώ�";
        private const string OBJECT_TITLE = "�Ώۃ^�C�g��";
        private const string PROC_OBJECT_TITLE = "�����Ώ�";
        private const string DEL_COUNT_TITLE = "�폜����";
        private const string PROC_RESULT_TITLE = "��������";
        private const string JOINPARTS_MST = "�����}�X�^";
        private const string SETPARTS_MST = "�Z�b�g�}�X�^";
        #endregion

        # region �� private field ��
        private static readonly Color DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color DISABLE_FONT_COLOR = Color.Black;
        private ControlScreenSkin _controlScreenSkin;
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _executeButton;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private OfferMstDelInputAcs _offerMstDelInputAcs;
        private DataTable detailsTable;
        #endregion

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        public PMKHN01200UA()
        {
            InitializeComponent();
            // �ϐ�������
            this.detailsTable = new DataTable(DETAILS_TABLE);
            this._controlScreenSkin = new ControlScreenSkin();
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._executeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Execute"];
            this._offerMstDelInputAcs = OfferMstDelInputAcs.GetInstance();
        }
        #endregion

        # region �� ��ʏ�������C�x���g ��
        /// <summary>
        /// �{�^�������ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �{�^�������ݒ菈���ł�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.20</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._executeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g����\�z�����ł�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            this.detailsTable.Columns.Add(NUMBER_TITLE, typeof(int));
            this.detailsTable.Columns.Add(OBJECT_TITLE, typeof(string));
            this.detailsTable.Columns.Add(PROC_OBJECT_TITLE, typeof(string));
            this.detailsTable.Columns.Add(DEL_COUNT_TITLE, typeof(int));
            this.detailsTable.Columns.Add(PROC_RESULT_TITLE, typeof(string));

            this.uGrid_Details.DataSource = detailsTable;
        }
        #endregion

        # region �� �t�H�[�����[�h ��
        /// <summary>
        /// ��ʂ̏���������
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>   
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: ��ʂ̏��������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void PMKHN01200UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);
            // �{�^�������ݒ菈��
            this.ButtonInitialSetting();
            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();
            // �O���b�h�����ݒ菈��
            this.InitialSettingGridCol();
            // �O���b�h�f�[�^�ݒ菈��
            this.InitialDataGridCol();

            this.uGrid_Details.Rows[0].Cells[1].Activated = true;
        }
        #endregion

        #region �� �O���b�h���b�\�h�֘A ��
        /// <summary>
        /// �񋟃}�X�^�폜�����̃O���b�h�ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �񋟃}�X�^�폜�����̃O���b�h�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void InitialDataGridCol()
        {
            // �����}�X�^
            DataRow dataRow = this.detailsTable.NewRow();
            dataRow[NUMBER_TITLE] = 1;
            dataRow[OBJECT_TITLE] = MARK_MARU;
            dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;
            dataRow[DEL_COUNT_TITLE] = 0;
            dataRow[PROC_RESULT_TITLE] = string.Empty;
            this.detailsTable.Rows.Add(dataRow);
            // �Z�b�g�}�X�^
            dataRow = this.detailsTable.NewRow();
            dataRow[NUMBER_TITLE] = 2;
            dataRow[OBJECT_TITLE] = MARK_MARU;
            dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;
            dataRow[DEL_COUNT_TITLE] = 0;
            dataRow[PROC_RESULT_TITLE] = string.Empty;
            this.detailsTable.Rows.Add(dataRow);
        }

        /// <summary>
        /// �񋟃}�X�^�폜�����̃O���b�h�����ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �񋟃}�X�^�폜�����̃O���b�h�����ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            this.uGrid_Details.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;

            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                //�uNo��v�ȊO�̑S�ẴZ����DiabledColor��ݒ肷��B
                if (!OBJECT_TITLE.Equals(col.Key))
                {
                    col.CellAppearance.BackColorDisabled = DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = DISABLE_FONT_COLOR;
                }
            }

            this.uGrid_Details.DisplayLayout.Bands[0].ColHeadersVisible = false;

            // Filter�ݒ�
            editBand.Columns[NUMBER_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            editBand.Columns[OBJECT_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            editBand.Columns[PROC_OBJECT_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            editBand.Columns[DEL_COUNT_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            editBand.Columns[PROC_RESULT_TITLE].AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // �\�����ݒ�
            editBand.Columns[NUMBER_TITLE].Width = 15;
            editBand.Columns[OBJECT_TITLE].Width = 18;
            editBand.Columns[PROC_OBJECT_TITLE].Width = 120;
            editBand.Columns[DEL_COUNT_TITLE].Width = 50;
            editBand.Columns[PROC_RESULT_TITLE].Width = 100;

            // �Œ��ݒ�
            editBand.Columns[NUMBER_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[NUMBER_TITLE].Header.Fixed = false;
            editBand.Columns[OBJECT_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[OBJECT_TITLE].Header.Fixed = false;
            editBand.Columns[PROC_OBJECT_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[PROC_OBJECT_TITLE].Header.Fixed = false;
            editBand.Columns[DEL_COUNT_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[DEL_COUNT_TITLE].Header.Fixed = false;
            editBand.Columns[PROC_RESULT_TITLE].Header.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;
            editBand.Columns[PROC_RESULT_TITLE].Header.Fixed = false;
            // CellAppearance�ݒ�
            editBand.Columns[NUMBER_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[OBJECT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            editBand.Columns[PROC_OBJECT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            editBand.Columns[DEL_COUNT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            editBand.Columns[PROC_RESULT_TITLE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            // ���͋��ݒ�
            editBand.Columns[NUMBER_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            editBand.Columns[OBJECT_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            editBand.Columns[PROC_OBJECT_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            editBand.Columns[DEL_COUNT_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            editBand.Columns[PROC_RESULT_TITLE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            // �t�H�[�}�b�g
            string format = "#,##0;-#,##0;'0'";
            editBand.Columns[DEL_COUNT_TITLE].Format = format;

            // Style�ݒ�
            editBand.Columns[NUMBER_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            editBand.Columns[OBJECT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            editBand.Columns[PROC_OBJECT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            editBand.Columns[DEL_COUNT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            editBand.Columns[PROC_RESULT_TITLE].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
            editBand.Columns[NUMBER_TITLE].TabStop = false;
            editBand.Columns[PROC_OBJECT_TITLE].TabStop = false;
            editBand.Columns[DEL_COUNT_TITLE].TabStop = false;
            editBand.Columns[PROC_RESULT_TITLE].TabStop = false;

            editBand.Columns[NUMBER_TITLE].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[NUMBER_TITLE].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            editBand.Columns[NUMBER_TITLE].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[NUMBER_TITLE].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[NUMBER_TITLE].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            editBand.Columns[NUMBER_TITLE].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
        }

        /// <summary>
        /// �񋟃}�X�^�폜�����̃O���b�h�񏉊�head�ݒ菈��
        /// </summary>
        /// <remarks>		
        /// <br>Note		: �񋟃}�X�^�폜�����̃O���b�h�񏉊�head�ݒ菈�����s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            // �O���b�h�񏉊�head�ݒ菈��
            this.SetGridHead();
        }

        /// <summary>
        /// �O���b�h�񏉊�head�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʏ������̎��A�O���b�h�񏉊��ݒ���s���܂��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void SetGridHead()
        {
            // �Ώ�
            Infragistics.Win.UltraWinGrid.UltraGridGroup ugg = null;
            ugg = this.uGrid_Details.DisplayLayout.Bands[0].Groups.Add(OBJECT_GROUP_TITLE, OBJECT_GROUP_TITLE);
            ugg.Columns.Add(this.uGrid_Details.DisplayLayout.Bands[0].Columns[NUMBER_TITLE]);
            ugg.Columns.Add(this.uGrid_Details.DisplayLayout.Bands[0].Columns[OBJECT_TITLE]);
            this.uGrid_Details.DisplayLayout.Bands[0].Groups[OBJECT_GROUP_TITLE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;

            // �����Ώ�
            ugg = this.uGrid_Details.DisplayLayout.Bands[0].Groups.Add(PROC_OBJECT_TITLE, PROC_OBJECT_TITLE);
            ugg.Columns.Add(this.uGrid_Details.DisplayLayout.Bands[0].Columns[PROC_OBJECT_TITLE]);
            this.uGrid_Details.DisplayLayout.Bands[0].Groups[PROC_OBJECT_TITLE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            // �폜����
            ugg = this.uGrid_Details.DisplayLayout.Bands[0].Groups.Add(DEL_COUNT_TITLE, DEL_COUNT_TITLE);
            ugg.Columns.Add(this.uGrid_Details.DisplayLayout.Bands[0].Columns[DEL_COUNT_TITLE]);
            this.uGrid_Details.DisplayLayout.Bands[0].Groups[DEL_COUNT_TITLE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
            // ��������
            ugg = this.uGrid_Details.DisplayLayout.Bands[0].Groups.Add(PROC_RESULT_TITLE, PROC_RESULT_TITLE);
            ugg.Columns.Add(this.uGrid_Details.DisplayLayout.Bands[0].Columns[PROC_RESULT_TITLE]);
            this.uGrid_Details.DisplayLayout.Bands[0].Groups[PROC_RESULT_TITLE].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;
        }


        /// <summary>
        /// �񋟃}�X�^�폜�O���b�h�L�[�h���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		:�񋟃}�X�^�폜�O���b�h�L�[�h���C�x���g���s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null && this.uGrid_Details.ActiveCell == this.uGrid_Details.ActiveRow.Cells[OBJECT_TITLE])
            {
                if (e.KeyCode == Keys.Enter)
                {
                    UltraGridCell cell = this.uGrid_Details.ActiveRow.Cells[OBJECT_TITLE];

                    string val = string.Empty;

                    if (MARK_MARU.Equals(cell.Value))
                    {
                        val = MARK_EMPTY;
                    }
                    else
                    {
                        val = MARK_MARU;
                    }

                    cell.Value = val;
                }
            }

            // Shift�L�[�̏ꍇ
            if (e.Shift)
            {
                switch (e.KeyCode)
                {
                    case Keys.Tab:
                        {
                            if (this.uGrid_Details.ActiveRow.Index == 0)
                            {
                                this.uGrid_Details.ActiveCell.Selected = false;
                                this.uGrid_Details.ActiveCell.Activated = false;

                                this.timer_SetFocus2.Enabled = true;
                            }
                            break;
                        }
                    //default:
                    //    break;
                }
            } else if (e.KeyCode == Keys.Tab)
            {
                if (this.uGrid_Details.ActiveRow.Index == 1)
                {
                    this.uGrid_Details.ActiveCell.Selected = false;
                    this.uGrid_Details.ActiveCell.Activated = false;

                    this.timer_SetFocus.Enabled = true;

                }
            }
        }

        /// <summary>
        /// �}�E�X�_�u���N���b�N���f�Z���C�x���g
        /// </summary>
        /// <param name="element">�ΏۃI�u�W�F�N�g</param>
        /// <remarks>		
        /// <br>Note		: �}�E�X�_�u���N���b�N���f�Z���C�x���g���s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        UltraGridCell PrepareCell(UIElement element)
        {
            CellUIElement cellElement = element as CellUIElement;
            if (cellElement == null) return null;
            UltraGridCell cell = cellElement.GetContext(typeof(UltraGridCell)) as UltraGridCell;
            return cell;
        }

        /// <summary>
        /// �񋟃}�X�^�폜�O���b�h�Z���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		:�񋟃}�X�^�폜�O���b�h�Z���C�x���g���s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (NUMBER_TITLE.Equals(e.Cell.Column.Key))
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// �񋟃}�X�^�폜�O���b�h�}�E�X�_�u���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		:�񋟃}�X�^�폜�O���b�h�}�E�X�_�u���N���b�N�C�x���g���s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void uGrid_Details_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UIElement mainElement = ((IUltraControlElement)uGrid_Details).MainUIElement;
            UltraGridCell cell = null;

            UIElement element = mainElement.ElementFromPoint(new Point(e.X, e.Y));
            while (element != null && cell == null)
            {
                cell = PrepareCell(element);

                if (cell == null)
                    element = element.Parent;
            }
            if (cell == null)
                return;


            if (this.uGrid_Details.ActiveCell != null)
            {
                if (this.uGrid_Details.ActiveCell == this.uGrid_Details.ActiveRow.Cells[OBJECT_TITLE])
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        UltraGridCell ultraGridCell = this.uGrid_Details.ActiveRow.Cells[OBJECT_TITLE];

                        string val = string.Empty;

                        if (MARK_MARU.Equals(ultraGridCell.Value))
                        {
                            val = MARK_EMPTY;
                        }
                        else
                        {
                            val = MARK_MARU;
                        }

                        ultraGridCell.Value = val;
                    }
                }
            }
        }
        /// <summary>
        /// �Z���̃t�H�[�J�X�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �Z���̃t�H�[�J�X�C�x���g�����������܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.06.20</br>
        /// </remarks>
        private void timer_SetFocus_Tick(object sender, EventArgs e)
        {
            this.uGrid_Details.Rows[0].Activated = true;
            this.uGrid_Details.Rows[0].Cells[1].Activated = true;
            this.timer_SetFocus.Enabled = false;
        }

        /// <summary>
        /// �Z���̃t�H�[�J�X�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note		: �Z���̃t�H�[�J�X�C�x���g�����������܂��B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.06.20</br>
        /// </remarks>
        private void timer_SetFocus2_Tick(object sender, EventArgs e)
        {
            this.uGrid_Details.Rows[1].Activated = true;
            this.uGrid_Details.Rows[1].Cells[1].Activated = true;
            this.timer_SetFocus2.Enabled = false;
        }
        #endregion

        #region �� �񋟃}�X�^�폜�������b�\�h�֘A ��
        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>		
        /// <br>Note		: �Ȃ��B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // �I������
                        this.Close();
                        break;
                    }
                case "ButtonTool_Execute":
                    {
                        // ���s����
                        bool inputCheck = false;

                        inputCheck = this.ExecuteBeforeCheck();

                        if (inputCheck)
                        {
                            this.ExecuteProcess();
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// �񋟃}�X�^�폜�����̓��̓`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note		: �񋟃}�X�^�폜�����̓��̓`�F�b�N�������s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        /// <returns>�X�e�[�^�X</returns>
        private bool ExecuteBeforeCheck()
        {
            bool status = true;

            string errMessage = "";

            // ��ʃf�[�^�`�F�b�N����
            if (!this.ScreenInputCheck(ref errMessage))
            {

                DialogResult dialogResult = TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PROGRAM_ID,
                    "",
                    "",
                    "",
                    errMessage,
                    0,
                    null,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                if (dialogResult == DialogResult.OK)
                {
                    this.detailsTable.Clear();
                    DataRow dataRow;
                    dataRow = this.detailsTable.NewRow();
                    dataRow[NUMBER_TITLE] = 1;
                    dataRow[OBJECT_TITLE] = string.Empty;
                    dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;
                    dataRow[DEL_COUNT_TITLE] = 0;
                    dataRow[PROC_RESULT_TITLE] = string.Empty;
                    this.detailsTable.Rows.Add(dataRow);

                    dataRow = this.detailsTable.NewRow();
                    dataRow[NUMBER_TITLE] = 2;
                    dataRow[OBJECT_TITLE] = string.Empty;
                    dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;
                    dataRow[DEL_COUNT_TITLE] = 0;
                    dataRow[PROC_RESULT_TITLE] = string.Empty;
                    this.detailsTable.Rows.Add(dataRow);

                    //this.uGrid_Details.ActiveCell.Selected = false;
                    this.uGrid_Details.ActiveCell = this.uGrid_Details.Rows[0].Cells[OBJECT_TITLE];
                }

                status = false;
                return status;
            }
            return status;
        }

        /// <summary>
        /// �񋟃}�X�^�폜�̃`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note		: �񋟃}�X�^�폜�̃`�F�b�N�������s���B</br>
        /// <br>Programmer	: 杍^</br>
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        /// <returns>True:OK, False:NG</returns>
        private bool ScreenInputCheck(ref string errMessage)
        {
            bool status = true;

            const string ct_NoInput = "�폜�Ώۂ��I������Ă��܂���B";

            if (this.uGrid_Details.Rows[0].Cells[OBJECT_TITLE].Value.ToString().Trim() == string.Empty
                && this.uGrid_Details.Rows[1].Cells[OBJECT_TITLE].Value.ToString().Trim() == string.Empty)
            {
                errMessage = ct_NoInput;
                status = false;

                return status;
            }
            return status;
        }

        /// <summary>
        /// �񋟃}�X�^�폜����
        /// </summary>
        /// <remarks>		
        /// <br>Note		:�񋟃}�X�^�폜�������s���B</br>
        /// <br>Programmer	: 杍^</br>	
        /// <br>Date		: 2009.06.18</br>
        /// </remarks>
        private void ExecuteProcess()
        {
            
            DataRow dataRow;
            // �����}�X�^�폜����
            int joinCount = 0;
            // �Z�b�g�}�X�^�폜����
            int setCount = 0;
            int joinStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int setStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�񋟃}�X�^�폜����";
            form.Message = "���݁A�폜�������ł��B";

            this.Cursor = Cursors.WaitCursor;
            // �_�C�A���O�\��
            form.Show(); 

            string joinFlag = this.uGrid_Details.Rows[0].Cells[OBJECT_TITLE].Value.ToString();
            string setFlag = this.uGrid_Details.Rows[1].Cells[OBJECT_TITLE].Value.ToString();

            this.detailsTable.Clear();
            if (MARK_MARU.Equals(joinFlag) && MARK_EMPTY.Equals(setFlag))
            {
                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 1;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = "�����A�������ł��D�D�D";
                this.detailsTable.Rows.Add(dataRow);

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 2;
                dataRow[OBJECT_TITLE] = string.Empty;
                dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = string.Empty;
                this.detailsTable.Rows.Add(dataRow);

                this.uGrid_Details.Refresh();

                // �����}�X�^�폜����
                joinStatus = _offerMstDelInputAcs.DeleteJoinProc(_enterpriseCode, out joinCount);

                this.detailsTable.Clear();

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 1;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;

                if (joinStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || joinStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    dataRow[DEL_COUNT_TITLE] = joinCount;
                    dataRow[PROC_RESULT_TITLE] = "����I��";
                }
                else
                {
                    dataRow[DEL_COUNT_TITLE] = joinCount;
                    dataRow[PROC_RESULT_TITLE] = "�X�V�����Ɏ��s���܂����B";
                }

                this.detailsTable.Rows.Add(dataRow);

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 2;
                dataRow[OBJECT_TITLE] = string.Empty;
                dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = string.Empty;
                this.detailsTable.Rows.Add(dataRow);
            }
            else if (MARK_EMPTY.Equals(joinFlag) && MARK_MARU.Equals(setFlag))
            {
                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 1;
                dataRow[OBJECT_TITLE] = string.Empty;
                dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = string.Empty;
                this.detailsTable.Rows.Add(dataRow);

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 2;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = "�����A�������ł��D�D�D";
                this.detailsTable.Rows.Add(dataRow);

                this.uGrid_Details.Refresh();

                // �Z�b�g�}�X�^�폜����
                setStatus = _offerMstDelInputAcs.DeleteSetProc(_enterpriseCode, out setCount);

                this.detailsTable.Clear();

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 1;
                dataRow[OBJECT_TITLE] = string.Empty;
                dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = string.Empty;
                this.detailsTable.Rows.Add(dataRow);


                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 2;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;

                if (setStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || setStatus == (int)ConstantManagement.DB_Status.ctDB_EOF
                    || setStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    dataRow[DEL_COUNT_TITLE] = setCount;
                    dataRow[PROC_RESULT_TITLE] = "����I��";
                }
                else
                {
                    dataRow[DEL_COUNT_TITLE] = setCount;
                    dataRow[PROC_RESULT_TITLE] = "�X�V�����Ɏ��s���܂����B";
                }
                this.detailsTable.Rows.Add(dataRow);
            }
            else
            {
                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 1;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = "�����A�������ł��D�D�D";
                this.detailsTable.Rows.Add(dataRow);

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 2;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;
                dataRow[DEL_COUNT_TITLE] = 0;
                dataRow[PROC_RESULT_TITLE] = "�����A�������ł��D�D�D";
                this.detailsTable.Rows.Add(dataRow);

                this.uGrid_Details.Refresh();

                // �����}�X�^�폜����
                joinStatus = _offerMstDelInputAcs.DeleteJoinProc(_enterpriseCode, out joinCount);
                // �Z�b�g�}�X�^�폜����
                setStatus = _offerMstDelInputAcs.DeleteSetProc(_enterpriseCode, out setCount);


                this.detailsTable.Clear();

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 1;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = JOINPARTS_MST;

                if (joinStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || joinStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    dataRow[DEL_COUNT_TITLE] = joinCount;
                    dataRow[PROC_RESULT_TITLE] = "����I��";
                }
                else
                {
                    dataRow[DEL_COUNT_TITLE] = joinCount;
                    dataRow[PROC_RESULT_TITLE] = "�X�V�����Ɏ��s���܂����B";
                }

                this.detailsTable.Rows.Add(dataRow);

                dataRow = this.detailsTable.NewRow();
                dataRow[NUMBER_TITLE] = 2;
                dataRow[OBJECT_TITLE] = MARK_MARU;
                dataRow[PROC_OBJECT_TITLE] = SETPARTS_MST;

                if (setStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || setStatus == (int)ConstantManagement.DB_Status.ctDB_EOF
                    || setStatus == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    dataRow[DEL_COUNT_TITLE] = setCount;
                    dataRow[PROC_RESULT_TITLE] = "����I��";
                }
                else
                {
                    dataRow[DEL_COUNT_TITLE] = setCount;
                    dataRow[PROC_RESULT_TITLE] = "�X�V�����Ɏ��s���܂����B";
                }
                this.detailsTable.Rows.Add(dataRow);
            }
            // �_�C�A���O�����
            form.Close();

            this.uGrid_Details.Rows[0].Cells[1].Activated = true;
            this.Cursor = Cursors.Default;
        }
        #endregion
    }
}