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
    /// 明細複写フォーム
    /// </summary>
    public partial class SFANL08240UB : Form
    {
        private int _groupCd;
        private DataTable _targetTable;

        /// <summary>
        /// 自由帳票グループコード
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
        /// コンストラクタ
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
        /// チェンジフォーカスイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {
            if ( e.PrevCtrl == this.tNedit_Source )
            {
                //-----------------------------------------
                // コピー元
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
                // コピー先　開始
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
                // コピー先　終了
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
        /// 行view取得処理
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
        /// キャンセルボタンクリックイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton2_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        /// <summary>
        /// コピー実行処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton1_Click( object sender, EventArgs e )
        {
            int startIndex = this.tNedit_CopySt.GetInt();
            int endIndex = this.tNedit_CopyEd.GetInt();

            // 入力エラーチェック
            # region [入力エラーチェック]
            if ( startIndex <= 0 )
            {
                MessageBox.Show( "開始ＩＤを入力して下さい。", "警告" );
                return;
            }
            if ( endIndex <= 0 )
            {
                MessageBox.Show( "終了ＩＤを入力して下さい。", "警告" );
                return;
            }
            if ( endIndex < startIndex )
            {
                MessageBox.Show( "開始≦終了となるように入力して下さい。", "警告" );
                return;
            }
            # endregion

            // コピー元取得
            # region [コピー元取得]
            DataRowView sourceRow = GetRow( this.tNedit_Source.GetInt() );
            if ( sourceRow == null )
            {
                MessageBox.Show( "コピー元が正しく選択されていません。", "警告" );
                return;
            }
            # endregion

            // コピー項目一覧取得
            # region [コピー項目一覧取得]
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
                // チェックされているcolumn名称のみをコピーする。
                if ( checkList_Columns.GetItemChecked( index ) )
                {
                    copyColumnList.Add( columnList[index] );
                }
            }
            # endregion


            // コピー先にコピー
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
        /// 全選択ボタン
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
        /// 全解除ボタン
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