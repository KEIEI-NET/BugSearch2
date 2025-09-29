using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Common;


namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    /// �I���K�C�h
    /// </summary>
    /// <remarks>
    /// <br>�{�N���X��internal�Ő錾����Ă���ׁA�O���A�Z���u������͒��ڎQ�Ƃł��Ȃ��B</br>
    /// <br>�O���A�Z���u������{�N���X�ɃA�N�Z�X����ꍇ�́A����N���X�ɃC���^�[�t�F�[�X</br>
    /// <br>�ƂȂ郁�\�b�h��v���p�e�B���쐬���鎖</br>
    /// </remarks>
    internal partial class SelectionForm : Form
    {
        # region �e��ϐ��A�萔�錾
        private const string COL_RW = "OrgRow";  // �� �Œ薼�̂Ƃ���B
        private const string COL_CTGRYMODEL = "CategoryModel";  // �� �Œ薼�̂Ƃ���B

        //private CategoryDataDataTable DataDestTable = null;
        private CategoryDataDataTable DataSourceTable = null;

        # endregion

        /// <summary>
        /// �I����ʃR���X�g���N�^
        /// </summary>
        /// <param name="dtSource">�O���b�h�ɕ\������f�[�^���w�肵�܂��B</param>
        public SelectionForm(CategoryDataDataTable dtSource)
        {
            InitializeComponent();

            // DataTable �̐ݒ�
            DataSourceTable = dtSource;

            InitializeData();

            // �X�e�[�^�X�o�[�̏�����
            StatusBar.Panels[0].Text = "";
            // �c�[���o�[�̃C���[�W(16x16)�⃁�b�Z�[�W��ݒ肷��
            ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
            ToolbarsManager.Tools["Button_Back"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
            // �擪�s��I����Ԃɂ���
            this.DataGrid.Rows[0].Selected = true;
            this.DataGrid.Rows[0].Activate();

        }

        /// <summary>
        /// �f�[�^�e�[�u���̗���쐬����
        /// </summary>
        /// <param name="columnName">��</param>
        /// <param name="type">�^</param>
        /// <param name="caption">�L���v�V����</param>
        /// <returns></returns>
        private DataColumn CreateColumn(string columnName, Type type, string caption)
        {
            #region �J�����쐬
            DataColumn dc = new DataColumn();

            dc.ColumnName = columnName;
            dc.DataType = type;
            dc.Caption = caption;

            return dc;
            #endregion
        }

        /// <summary>
        /// InitializeLayout �C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>�O���b�h�̃��C�A�E�g����������</br>
        /// </remarks>
        private void DataGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            // �񕝂̎����������@
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.SelectTypeRow = SelectType.Single;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            e.Layout.Override.RowSelectorWidth = 24;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;

            // �o���h�̎擾
            UltraGridBand Band = e.Layout.Bands[0];
            Band.Override.RowSizing = RowSizing.Fixed;
            Band.Override.AllowColSizing = AllowColSizing.None;
            Band.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            // �����\���ʒu
            Band.Columns[0].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            // �����\���ʒu
            Band.Columns[0].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            Band.Columns[0].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
          
        }

        /// <summary>
        /// �\���p�f�[�^��DataTable�ɓo�^
        /// </summary>
        private void InitializeData()
        {
            //DataDestTable = new DsCategoryData.CategoryDataDataTable();            

            //for (int i = 0; i < DataSourceTable.Rows.Count; i++)
            //{
            //    PMKEN01010E.CtgyMdlLnkInfoRow wkRow = DataSourceTable[i];
            //    string categoryModel = String.Format("{0,5}-{1,4}", wkRow[0], wkRow[1]);
            //    DataDestTable.AddCategoryDataRow(categoryModel);
            //}

            DataGrid.DataSource = DataSourceTable;
            
        }


        /// <summary>
        /// �c�[���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {

                case "Button_Back":
                    // �O�̉�ʂɖ߂�
                    DialogResult = DialogResult.Cancel;
                    break;
          
            }
        }

        /// <summary>
        /// �c�[���o�[��ł̃L�[�����C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarsManager_ToolKeyDown(object sender, ToolKeyEventArgs e)
        {

        }

        /// <summary>
        /// �A�N�e�B�u�s�ύX��C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {

        }

        /// <summary>
        /// �O���b�h���Enter�L�[�������ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// �s���_�u���N���b�N���ꂽ�ꍇ�́A���̍s��I������B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// �f�[�^���\������Ă��Ȃ��s���_�u���N���b�N���Ă��{�C�x���g�͔������Ȃ��B
        /// </remarks>
        private void DataGrid_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            
        }

        /// <summary>
        /// ESC�L�[�����ɂ��I������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

    }
}