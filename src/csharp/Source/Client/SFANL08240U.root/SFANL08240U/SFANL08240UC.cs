using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �\�[�g���ʏ����ݒ�t�H�[��
    /// </summary>
    public partial class SFANL08240UC : Form
    {
        // ���ʃt�@�C���w�b�_�[
        private const string COL_COMMON_CREATEDATETIME = "CreateDateTime";		// �쐬����
        private const string COL_COMMON_UPDATEDATETIME = "UpdateDateTime";		// �X�V����
        private const string COL_COMMON_LOGICALDELETECODE = "LogicalDeleteCode";	// �_���폜�敪
        // ���R���[�\�[�g���ʏ����l
        //private const string COL_FPSORTINIT_CREATEDATETIME = "CreateDateTime"; // �쐬����
        //private const string COL_FPSORTINIT_UPDATEDATETIME = "UpdateDateTime"; // �X�V����
        //private const string COL_FPSORTINIT_LOGICALDELETECODE = "LogicalDeleteCode"; // �_���폜�敪
        private const string COL_FPSORTINIT_FREEPRTPPRITEMGRPCD = "FreePrtPprItemGrpCd"; // ���R���[���ڃO���[�v�R�[�h
        private const string COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD = "FreePrtPprSchmGrpCd"; // ���R���[�X�L�[�}�O���[�v�R�[�h
        private const string COL_FPSORTINIT_SORTINGORDERCODE = "SortingOrderCode"; // �\�[�g���ʃR�[�h
        private const string COL_FPSORTINIT_SORTINGORDER = "SortingOrder"; // �\�[�g����
        private const string COL_FPSORTINIT_FREEPRTPAPERITEMNM = "FreePrtPaperItemNm"; // ���R���[���ږ���
        private const string COL_FPSORTINIT_DDNAME = "DDName"; // DD����
        private const string COL_FPSORTINIT_FILENM = "FileNm"; // �t�@�C������
        private const string COL_FPSORTINIT_SORTINGORDERDIVCD = "SortingOrderDivCd"; // �����~���敪

        private int _groupCd;
        private DataTable _targetTable;

        /// <summary>
        /// ���R���[�O���[�v�R�[�h
        /// </summary>
        public int GroupCd
        {
            get { return _groupCd; }
            //set 
            //{ 
            //    _groupCd = value;
            //}
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="table"></param>
        /// <param name="groupCd"></param>
        public SFANL08240UC( DataTable table, int groupCd )
        {
            InitializeComponent();

            _targetTable = table;
            _groupCd = groupCd;

            //this.label_Target.Text = _groupCd.ToString();

            DataView view = new DataView( _targetTable );
            view.RowFilter = string.Format( "{0}='{1}'", COL_FPSORTINIT_FREEPRTPPRITEMGRPCD, groupCd );
            this.gridFPSortInit.DataSource = view;

            # region [�O���b�h�\���ݒ�]

            // Disabled�J���[
            //this.gridFPSortInit.DisplayLayout.Appearance.BackColorDisabled = Color.Gray;
            //this.gridFPSortInit.DisplayLayout.Appearance.ForeColorDisabled = Color.Black;


            // �S�J������\����
            Infragistics.Win.UltraWinGrid.ColumnsCollection columns = this.gridFPSortInit.DisplayLayout.Bands[0].Columns;
            foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns )
            {
                column.Hidden = true;    
            }

            int position = 0;

            // �\�[�g���R�[�h(ID��)
            columns[COL_FPSORTINIT_SORTINGORDERCODE].Header.Caption = "�R�[�h";
            columns[COL_FPSORTINIT_SORTINGORDERCODE].Width = 70;
            columns[COL_FPSORTINIT_SORTINGORDERCODE].Hidden = false;
            columns[COL_FPSORTINIT_SORTINGORDERCODE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[COL_FPSORTINIT_SORTINGORDERCODE].CellAppearance.BackColor = Color.LightGray;
            columns[COL_FPSORTINIT_SORTINGORDERCODE].Header.VisiblePosition = position++;
            
            // ���ږ�
            columns[COL_FPSORTINIT_FREEPRTPAPERITEMNM].Header.Caption = "���ږ�";
            columns[COL_FPSORTINIT_FREEPRTPAPERITEMNM].Width = 200;
            columns[COL_FPSORTINIT_FREEPRTPAPERITEMNM].Hidden = false;
            columns[COL_FPSORTINIT_FREEPRTPAPERITEMNM].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[COL_FPSORTINIT_FREEPRTPAPERITEMNM].CellAppearance.BackColor = Color.LightGray;
            columns[COL_FPSORTINIT_FREEPRTPAPERITEMNM].Header.VisiblePosition = position++;
            
            // �t�@�C����
            columns[COL_FPSORTINIT_FILENM].Header.Caption = "�t�@�C����";
            columns[COL_FPSORTINIT_FILENM].Width = 150;
            columns[COL_FPSORTINIT_FILENM].Hidden = false;
            columns[COL_FPSORTINIT_FILENM].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[COL_FPSORTINIT_FILENM].CellAppearance.BackColor = Color.LightGray;
            columns[COL_FPSORTINIT_FILENM].Header.VisiblePosition = position++;
            
            // �c�c��
            columns[COL_FPSORTINIT_DDNAME].Header.Caption = "�c�c��";
            columns[COL_FPSORTINIT_DDNAME].Width = 180;
            columns[COL_FPSORTINIT_DDNAME].Hidden = false;
            columns[COL_FPSORTINIT_DDNAME].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[COL_FPSORTINIT_DDNAME].CellAppearance.BackColor = Color.LightGray;
            columns[COL_FPSORTINIT_DDNAME].Header.VisiblePosition = position++;

            // �\�[�g����
            columns[COL_FPSORTINIT_SORTINGORDER].Header.Caption = "�����\�[�g��";
            columns[COL_FPSORTINIT_SORTINGORDER].Width = 90;
            columns[COL_FPSORTINIT_SORTINGORDER].Hidden = false;
            columns[COL_FPSORTINIT_SORTINGORDER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            columns[COL_FPSORTINIT_SORTINGORDER].Header.VisiblePosition = position++;

            // �\�[�g�敪
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].Header.Caption = "�����\�[�g�敪";
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].Width = 150;
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].Hidden = false;
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].Header.VisiblePosition = position++;
            // (�\�[�g�敪 �敪�l���X�g)
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
            valueList.ValueListItems.Add( -1, "(�ݒ�s��)" );
            valueList.ValueListItems.Add( 0, "�\�[�g��" );
            valueList.ValueListItems.Add( 1, "����" );
            valueList.ValueListItems.Add( 2, "�~��" );
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].ValueList = valueList;
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            # endregion
        }

        /// <summary>
        /// �`�F���W�t�H�[�J�X�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {

        }
        /// <summary>
        /// ����{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton1_Click( object sender, EventArgs e )
        {
            this.Close();
        }
    }
}