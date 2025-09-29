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
    /// ���ו��ʃt�H�[��
    /// </summary>
    public partial class SFANL08240UB : Form
    {
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
        public SFANL08240UB(DataTable table, int groupCd)
        {
            InitializeComponent();

            _targetTable = table;
            _groupCd = groupCd;

            this.label_Target.Text = _groupCd.ToString();
        }

        /// <summary>
        /// �`�F���W�t�H�[�J�X�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
            if ( e.PrevCtrl == this.tNedit_Source )
            {
                //-----------------------------------------
                // �R�s�[��
                //-----------------------------------------
                this.label_Source.Text = string.Empty;
                DataRowView rowView = GetRow( tNedit_Source.GetInt() );
                if ( rowView != null )
                {
                    this.label_Source.Text = (string)rowView["FreePrtPaperItemNm"];
                }
            }
            else if ( e.PrevCtrl == this.tNedit_CopySt )
            {
                //-----------------------------------------
                // �R�s�[��@�J�n
                //-----------------------------------------
                this.label_CopySt.Text = string.Empty;
                DataRowView rowView = GetRow( tNedit_CopySt.GetInt() );
                if ( rowView != null )
                {
                    this.label_CopySt.Text = (string)rowView["FreePrtPaperItemNm"];
                }
            }
            else if ( e.PrevCtrl == this.tNedit_CopyEd )
            {
                //-----------------------------------------
                // �R�s�[��@�I��
                //-----------------------------------------
                this.label_CopyEd.Text = string.Empty;
                DataRowView rowView = GetRow( tNedit_CopyEd.GetInt() );
                if ( rowView != null )
                {
                    this.label_CopyEd.Text = (string)rowView["FreePrtPaperItemNm"];
                }
            }
        }
        /// <summary>
        /// �sview�擾����
        /// </summary>
        /// <param name="itemCd"></param>
        /// <returns></returns>
        private DataRowView GetRow( int itemCd )
        {
            DataView view = new DataView( _targetTable );
            view.RowFilter = string.Format( "{0}='{1}' AND {2}='{3}'", "FreePrtPprItemGrpCd", this.GroupCd, "FreePrtPaperItemCd", itemCd );
            if ( view.Count == 1 )
            {
                return view[0];
            }
            return null;
        }

        /// <summary>
        /// �L�����Z���{�^���N���b�N�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton2_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        /// <summary>
        /// �R�s�[���s����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton1_Click( object sender, EventArgs e )
        {
            int startIndex = this.tNedit_CopySt.GetInt();
            int endIndex = this.tNedit_CopyEd.GetInt();

            // ���̓G���[�`�F�b�N
            # region [���̓G���[�`�F�b�N]
            if ( startIndex <= 0 )
            {
                MessageBox.Show( "�J�n�h�c����͂��ĉ������B", "�x��" );
                return;
            }
            if ( endIndex <= 0 )
            {
                MessageBox.Show( "�I���h�c����͂��ĉ������B", "�x��" );
                return;
            }
            if ( endIndex < startIndex )
            {
                MessageBox.Show( "�J�n���I���ƂȂ�悤�ɓ��͂��ĉ������B", "�x��" );
                return;
            }
            # endregion

            // �R�s�[���擾
            # region [�R�s�[���擾]
            DataRowView sourceRow = GetRow( this.tNedit_Source.GetInt() );
            if ( sourceRow == null )
            {
                MessageBox.Show( "�R�s�[�����������I������Ă��܂���B", "�x��" );
                return;
            }
            # endregion

            // �R�s�[���ڈꗗ�擾
            # region [�R�s�[���ڈꗗ�擾]
            List<string> columnList = new List<string>( new string[] 
            { 
                "FileNm",
                "DDCharCnt",
                "DDName",
                "ReportControlCode",
                "HeaderUseDivCd",
                "DetailUseDivCd",
                "FooterUseDivCd",
                "ExtraConditionDivCd",
                "ExtraConditionTypeCd",
                "CommaEditExistCd",
                "PrintPageCtrlDivCd",
                "SystemDivCd",
                "OptionCode",
                "ExtraCondDetailGrpCd",
                "TotalItemDivCd",
                "FormFeedItemDivCd",
                "FreePrtPprDispGrpCd",
                "NecessaryExtraCondCd",
                "CipherFlg",
                "ExtractionItdedFlg",
                "GroupSuppressCd",
                "DtlColorChangeCd",
                "HeightAdjustDivCd",
                "AddItemUseDivCd",
                "InputCharCnt",
                "BarCodeStyle"
            } );
            List<string> copyColumnList = new List<string>();
            for ( int index = 0; index < columnList.Count; index++ )
            {
                // �`�F�b�N����Ă���column���݂̂̂��R�s�[����B
                if ( checkList_Columns.GetItemChecked( index ) )
                {
                    copyColumnList.Add( columnList[index] );
                }
            }
            # endregion


            // �R�s�[��ɃR�s�[
            DataView view = new DataView( _targetTable );
            view.RowFilter = string.Format( "{0}='{1}' AND ({2}>='{3}' AND {2}<='{4}')", "FreePrtPprItemGrpCd", this.GroupCd, "FreePrtPaperItemCd", startIndex, endIndex );
            foreach ( DataRowView rowView in view )
            {
                if ( rowView["FreePrtPaperItemCd"] != sourceRow["FreePrtPaperItemCd"] )
                {
                    foreach ( string columnName in copyColumnList )
                    {
                        rowView[columnName] = sourceRow[columnName];
                    }
                }
            }
        }

        /// <summary>
        /// �S�I���{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AllCheck_Click( object sender, EventArgs e )
        {
            for ( int index = 0; index < checkList_Columns.Items.Count; index++ )
            {
                checkList_Columns.SetItemChecked( index, true );
            }
        }
        /// <summary>
        /// �S�����{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_AllCancel_Click( object sender, EventArgs e )
        {
            for ( int index = 0; index < checkList_Columns.Items.Count; index++ )
            {
                checkList_Columns.SetItemChecked( index, false );
            }
        }

        private void ultraExpandableGroupBox1_ExpandedStateChanged( object sender, EventArgs e )
        {
            panel1.Top = ultraExpandableGroupBox1.Bottom;
            this.Height = panel1.Bottom + 50;
        }
    }
}