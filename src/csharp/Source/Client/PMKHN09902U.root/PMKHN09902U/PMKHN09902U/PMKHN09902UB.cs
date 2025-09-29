//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�|���ꊇ�o�^�E�C���U
// �v���O�����T�v   �F�|���}�X�^�̓o�^�E�C�������ꊇ�ōs��
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F���j��
// �C����    2013/02/19     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �|���ꊇ�o�^�E�C���UUI�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �|���ꊇ�o�^�E�C���UUI�t�H�[���N���X</br>
    /// <br>Programmer  : donggy</br>
    /// <br>Date        : 2013/02/19</br>
    /// </remarks>
    public partial class PMKHN09902UB : Form
    {
        #region �� Constants

        // �A�Z���u��ID
        private const string ASSEMBLY_ID = "PMKHN09902U";


        // ��ʏ�ԕۑ��p�t�@�C����
        private const string XML_FILE_INITIAL_DATA = "PMKHN09902U.dat";

        // �O���b�h��
        /// <summary>
        /// �s�ԍ�
        /// </summary>
        public const string COLUMN_NO = "No";
        /// <summary>
        /// ���i�|���O���[�v
        /// </summary>
        public const string COLUMN_GOODSRATEGRPCODE = "GoodsRateGrpCode";
        /// <summary>
        /// �w��
        /// </summary>
        public const string COLUMN_GOODSRATERANK = "GoodsRateRank";
        /// <summary>
        /// BL�O���[�v�R�[�h
        /// </summary>
        public const string COLUMN_GLCD = "Glcd";
        /// <summary>
        /// BL�R�[�h
        /// </summary>
        public const string COLUMN_BLCD = "Blcd";
        /// <summary>
        /// BL�R�[�h���EBL�O���[�v���E���i�|���O���[�v���E�w�ʖ�
        /// </summary>
        public const string COLUMN_NAME = "Name";
        /// <summary>
        /// ���[�J�[�R�[�h
        /// </summary>
        public const string COLUMN_MAKERCODE = "MakerCode";
        /// <summary>
        /// ���[�J�[��
        /// </summary>
        public const string COLUMN_MAKERNAME = "MakerName";
        /// <summary>
        /// �d����R�[�h
        /// </summary>
        public const string COLUMN_SUPPLIERCODE = "SupplierCode";
        /// <summary>
        /// �d����
        /// </summary>
        public const string COLUMN_COSTRATE = "CostRate";
        /// <summary>
        /// ���Ӑ����
        /// </summary>
        public const string COLUMN_SEARCHCONDTION = "SearchCondtion";
        /// <summary>
        /// ������
        /// </summary>
        public const string COLUMN_SALERATE = "SaleRate";
        /// <summary>
        /// �����t�o��
        /// </summary>
        public const string COLUMN_UPRATE = "UpRate";
        /// <summary>
        /// �e���m�ۗ�
        /// </summary>
        public const string COLUMN_GRSPROFITSECURERAT = "GrsProfitSecureRat";
 
        private const string CUSTOMER_MODE1 = "���Ӑ�|���f";
        private const string CUSTOMER_MODE2 = "���Ӑ�";

        private const string RATE_TITLE_RATEVAL = "������";
        private const string RATE_TITLE_UPRATE = "����UP��";
        private const string RATE_TITLE_GRSPROFITSECURERAT = "�e���m�ۗ�";

        #endregion �� Constants
        /// <summary>
        /// Excel�o�͗p�N���X
        /// </summary>
        public PMKHN09902UB()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Excel�o�́F�f�[�^�̍쐬
        /// </summary>
        /// <param name="parmGrid">��ʕ\���pGrid</param>
        /// <param name="resultGrid">Execl�o�͗pGrid</param>
        public void SetExcelOutputDataGrid(UltraGrid parmGrid, out UltraGrid resultGrid )
        {
            resultGrid = new UltraGrid();
            this.tempUltraGrid.BeginUpdate();
            ColumnsCollection parmGridColumns = parmGrid.DisplayLayout.Bands[0].Columns;
            DataTable dataTable = new DataTable();
            DataRow titleRow = dataTable.NewRow();//�^�C�g���s
            // Execl�o�̓t�@�C���̃^�C�g���s�ݒ�iExecl�o�͗pGrid���ו��̑�P�s�j
            foreach (UltraGridColumn column in parmGridColumns)
            {
                string colKey = column.Key;

                if (!parmGridColumns[colKey].Hidden)
                {
                    if (!dataTable.Columns.Contains(colKey))
                    {
                        dataTable.Columns.Add(colKey, typeof(string));
                        // ����̕\�������̐ݒ�
                        if (colKey.Contains(COLUMN_SALERATE))
                        {
                            titleRow[colKey] = RATE_TITLE_RATEVAL;// ������
                            continue;
                        }
                        else if (colKey.Contains(COLUMN_UPRATE))
                        {
                            titleRow[colKey] = RATE_TITLE_UPRATE;// ����UP��
                            continue;
                        }
                        else if (colKey.Contains(COLUMN_GRSPROFITSECURERAT))
                        {
                            titleRow[colKey] = RATE_TITLE_GRSPROFITSECURERAT;// �e���m�ۗ�
                            continue;
                        }
                        else if (colKey.Equals(COLUMN_GOODSRATEGRPCODE))
                        {
                            titleRow[colKey] = "���i�|��G";
                        }
                        else if (colKey.Equals(COLUMN_GLCD))
                        {
                            titleRow[colKey] = "GRCD";
                        }
                        else if (colKey.Equals(COLUMN_BLCD))
                        {
                            titleRow[colKey] = "BL����";
                        }
                        else
                        {
                            titleRow[colKey] = parmGridColumns[colKey].Header.Caption;
                        }

                        if (parmGrid.DisplayLayout.Bands[0].Groups[colKey].Hidden)
                        {
                            dataTable.Columns.Remove(colKey);//��\����̍폜
                        }
                        
                    }
                }
                else
                {
                    if (colKey.Contains(COLUMN_SUPPLIERCODE) || colKey.Contains(COLUMN_MAKERCODE) || colKey.Contains(COLUMN_MAKERNAME))
                    {
                        dataTable.Columns.Add(colKey, typeof(string));
                        titleRow[colKey] = parmGridColumns[colKey].Header.Caption;
                    }
                }
            }
            dataTable.Rows.Add(titleRow);
            // Execl�o�͂̃f�[�^�擾�i�����擾�̑S�ăf�[�^�j
            DataTable sourceDataTable = (DataTable)parmGrid.DataSource;// ��ʕ\���pGrid��DataSource
            DataRow dataRow = null;
            foreach (DataRow sourceRow in sourceDataTable.Rows)
            {
                dataRow = dataTable.NewRow();
                foreach (DataColumn column in dataTable.Columns)
                {
                    dataRow[column.ColumnName] = sourceRow[column.ColumnName];
                }
                dataTable.Rows.Add(dataRow);
            }
            
            dataTable.Columns.Remove(dataTable.Columns[COLUMN_NO]);// No��̍폜
            dataTable.Columns.Remove(dataTable.Columns[COLUMN_MAKERNAME]);// ���[�J�[����̍폜
            this.tempUltraGrid.DataSource = dataTable;
            this.tempUltraGrid.DisplayLayout.CopyFrom(parmGrid.DisplayLayout);

            // ���i�|��G�Ƒw�ʂ͍�����
            ColumnsCollection columns = tempUltraGrid.DisplayLayout.Bands[0].Columns;
            columns[0].CellAppearance.TextHAlign = HAlign.Left;

           // ���ו��̗l�̐ݒ�
            for (int rowIndex = 0; rowIndex < parmGrid.Rows.Count; rowIndex++)
            {
                CellsCollection cells = this.tempUltraGrid.Rows[rowIndex+1].Cells;
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    cells[dataColumn.ColumnName].Appearance = parmGrid.Rows[rowIndex].Cells[dataColumn.ColumnName].Appearance;// ���׍s�̗l�Ɖ�ʂ̖��׍s�̓���
                    cells[dataColumn.ColumnName].Activation = parmGrid.Rows[rowIndex].Cells[dataColumn.ColumnName].Activation;// �����s�̃Z������
                }
                
            }
            // �^�C�g���s�̗l�̐ݒ�
            foreach (UltraGridColumn gridColumn in this.tempUltraGrid.DisplayLayout.Bands[0].Columns)
            {
                if (gridColumn.Index > 7)
                {
                    // ���Ӑ挟�������̃^�C�g���̃J���[�ݒ�
                    this.tempUltraGrid.DisplayLayout.Bands[0].Columns[gridColumn.Key].Header.Appearance.BackColor = Color.FromArgb(89, 135, 214);// blue
                    this.tempUltraGrid.DisplayLayout.Bands[0].Columns[gridColumn.Key].Header.Appearance.BackColor2 = Color.FromArgb(7, 59, 150);
                }
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.BackColor = Color.FromArgb(89, 135, 214);
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.BackColor2 = Color.FromArgb(7, 59, 150);
                // �^�C�g���s�̃Z���̏����ݒ�i�����ʒu�E�J���[�ƃ{�[�_�[�J���[�j
                this.tempUltraGrid.DisplayLayout.Bands[0].Columns[gridColumn.Key].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.ForeColor = Color.White;
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.BorderColor = Color.Black;
                this.tempUltraGrid.DisplayLayout.Bands[0].Columns[gridColumn.Key].Hidden = false;
                // �|���ȊO�̔�\���s���\���ɐݒ肷��
                if (gridColumn.Index < 7)
                {
                    this.tempUltraGrid.DisplayLayout.Bands[0].Groups[gridColumn.Key].Hidden = false;
                }
            }
            this.tempUltraGrid.DisplayLayout.Bands[0].ColHeadersVisible = true;
            resultGrid = this.tempUltraGrid;
        }
    }
}