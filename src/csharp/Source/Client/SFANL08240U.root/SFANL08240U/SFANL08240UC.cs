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
    /// ソート順位初期設定フォーム
    /// </summary>
    public partial class SFANL08240UC : Form
    {
        // 共通ファイルヘッダー
        private const string COL_COMMON_CREATEDATETIME = "CreateDateTime";		// 作成日時
        private const string COL_COMMON_UPDATEDATETIME = "UpdateDateTime";		// 更新日時
        private const string COL_COMMON_LOGICALDELETECODE = "LogicalDeleteCode";	// 論理削除区分
        // 自由帳票ソート順位初期値
        //private const string COL_FPSORTINIT_CREATEDATETIME = "CreateDateTime"; // 作成日時
        //private const string COL_FPSORTINIT_UPDATEDATETIME = "UpdateDateTime"; // 更新日時
        //private const string COL_FPSORTINIT_LOGICALDELETECODE = "LogicalDeleteCode"; // 論理削除区分
        private const string COL_FPSORTINIT_FREEPRTPPRITEMGRPCD = "FreePrtPprItemGrpCd"; // 自由帳票項目グループコード
        private const string COL_FPSORTINIT_FREEPRTPPRSCHMGRPCD = "FreePrtPprSchmGrpCd"; // 自由帳票スキーマグループコード
        private const string COL_FPSORTINIT_SORTINGORDERCODE = "SortingOrderCode"; // ソート順位コード
        private const string COL_FPSORTINIT_SORTINGORDER = "SortingOrder"; // ソート順位
        private const string COL_FPSORTINIT_FREEPRTPAPERITEMNM = "FreePrtPaperItemNm"; // 自由帳票項目名称
        private const string COL_FPSORTINIT_DDNAME = "DDName"; // DD名称
        private const string COL_FPSORTINIT_FILENM = "FileNm"; // ファイル名称
        private const string COL_FPSORTINIT_SORTINGORDERDIVCD = "SortingOrderDivCd"; // 昇順降順区分

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
        public SFANL08240UC( DataTable table, int groupCd )
        {
            InitializeComponent();

            _targetTable = table;
            _groupCd = groupCd;

            //this.label_Target.Text = _groupCd.ToString();

            DataView view = new DataView( _targetTable );
            view.RowFilter = string.Format( "{0}='{1}'", COL_FPSORTINIT_FREEPRTPPRITEMGRPCD, groupCd );
            this.gridFPSortInit.DataSource = view;

            # region [グリッド表示設定]

            // Disabledカラー
            //this.gridFPSortInit.DisplayLayout.Appearance.BackColorDisabled = Color.Gray;
            //this.gridFPSortInit.DisplayLayout.Appearance.ForeColorDisabled = Color.Black;


            // 全カラム非表示化
            Infragistics.Win.UltraWinGrid.ColumnsCollection columns = this.gridFPSortInit.DisplayLayout.Bands[0].Columns;
            foreach ( Infragistics.Win.UltraWinGrid.UltraGridColumn column in columns )
            {
                column.Hidden = true;    
            }

            int position = 0;

            // ソート順コード(ID№)
            columns[COL_FPSORTINIT_SORTINGORDERCODE].Header.Caption = "コード";
            columns[COL_FPSORTINIT_SORTINGORDERCODE].Width = 70;
            columns[COL_FPSORTINIT_SORTINGORDERCODE].Hidden = false;
            columns[COL_FPSORTINIT_SORTINGORDERCODE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[COL_FPSORTINIT_SORTINGORDERCODE].CellAppearance.BackColor = Color.LightGray;
            columns[COL_FPSORTINIT_SORTINGORDERCODE].Header.VisiblePosition = position++;
            
            // 項目名
            columns[COL_FPSORTINIT_FREEPRTPAPERITEMNM].Header.Caption = "項目名";
            columns[COL_FPSORTINIT_FREEPRTPAPERITEMNM].Width = 200;
            columns[COL_FPSORTINIT_FREEPRTPAPERITEMNM].Hidden = false;
            columns[COL_FPSORTINIT_FREEPRTPAPERITEMNM].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[COL_FPSORTINIT_FREEPRTPAPERITEMNM].CellAppearance.BackColor = Color.LightGray;
            columns[COL_FPSORTINIT_FREEPRTPAPERITEMNM].Header.VisiblePosition = position++;
            
            // ファイル名
            columns[COL_FPSORTINIT_FILENM].Header.Caption = "ファイル名";
            columns[COL_FPSORTINIT_FILENM].Width = 150;
            columns[COL_FPSORTINIT_FILENM].Hidden = false;
            columns[COL_FPSORTINIT_FILENM].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[COL_FPSORTINIT_FILENM].CellAppearance.BackColor = Color.LightGray;
            columns[COL_FPSORTINIT_FILENM].Header.VisiblePosition = position++;
            
            // ＤＤ名
            columns[COL_FPSORTINIT_DDNAME].Header.Caption = "ＤＤ名";
            columns[COL_FPSORTINIT_DDNAME].Width = 180;
            columns[COL_FPSORTINIT_DDNAME].Hidden = false;
            columns[COL_FPSORTINIT_DDNAME].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            columns[COL_FPSORTINIT_DDNAME].CellAppearance.BackColor = Color.LightGray;
            columns[COL_FPSORTINIT_DDNAME].Header.VisiblePosition = position++;

            // ソート順位
            columns[COL_FPSORTINIT_SORTINGORDER].Header.Caption = "初期ソート順";
            columns[COL_FPSORTINIT_SORTINGORDER].Width = 90;
            columns[COL_FPSORTINIT_SORTINGORDER].Hidden = false;
            columns[COL_FPSORTINIT_SORTINGORDER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            columns[COL_FPSORTINIT_SORTINGORDER].Header.VisiblePosition = position++;

            // ソート区分
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].Header.Caption = "初期ソート区分";
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].Width = 150;
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].Hidden = false;
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].Header.VisiblePosition = position++;
            // (ソート区分 区分値リスト)
            Infragistics.Win.ValueList valueList = new Infragistics.Win.ValueList();
            valueList.ValueListItems.Add( -1, "(設定不可)" );
            valueList.ValueListItems.Add( 0, "ソート無" );
            valueList.ValueListItems.Add( 1, "昇順" );
            valueList.ValueListItems.Add( 2, "降順" );
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].ValueList = valueList;
            columns[COL_FPSORTINIT_SORTINGORDERDIVCD].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;

            # endregion
        }

        /// <summary>
        /// チェンジフォーカスイベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus( object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e )
        {

        }
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ultraButton1_Click( object sender, EventArgs e )
        {
            this.Close();
        }
    }
}