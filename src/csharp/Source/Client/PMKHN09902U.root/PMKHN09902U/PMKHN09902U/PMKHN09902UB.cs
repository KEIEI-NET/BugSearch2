//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：掛率一括登録・修正Ⅱ
// プログラム概要   ：掛率マスタの登録・修正をを一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：董桂鈺
// 修正日    2013/02/19     修正内容：新規作成
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
    /// 掛率一括登録・修正ⅡUIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 掛率一括登録・修正ⅡUIフォームクラス</br>
    /// <br>Programmer  : donggy</br>
    /// <br>Date        : 2013/02/19</br>
    /// </remarks>
    public partial class PMKHN09902UB : Form
    {
        #region ■ Constants

        // アセンブリID
        private const string ASSEMBLY_ID = "PMKHN09902U";


        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMKHN09902U.dat";

        // グリッド列
        /// <summary>
        /// 行番号
        /// </summary>
        public const string COLUMN_NO = "No";
        /// <summary>
        /// 商品掛率グループ
        /// </summary>
        public const string COLUMN_GOODSRATEGRPCODE = "GoodsRateGrpCode";
        /// <summary>
        /// 層別
        /// </summary>
        public const string COLUMN_GOODSRATERANK = "GoodsRateRank";
        /// <summary>
        /// BLグループコード
        /// </summary>
        public const string COLUMN_GLCD = "Glcd";
        /// <summary>
        /// BLコード
        /// </summary>
        public const string COLUMN_BLCD = "Blcd";
        /// <summary>
        /// BLコード名・BLグループ名・商品掛率グループ名・層別名
        /// </summary>
        public const string COLUMN_NAME = "Name";
        /// <summary>
        /// メーカーコード
        /// </summary>
        public const string COLUMN_MAKERCODE = "MakerCode";
        /// <summary>
        /// メーカー名
        /// </summary>
        public const string COLUMN_MAKERNAME = "MakerName";
        /// <summary>
        /// 仕入先コード
        /// </summary>
        public const string COLUMN_SUPPLIERCODE = "SupplierCode";
        /// <summary>
        /// 仕入率
        /// </summary>
        public const string COLUMN_COSTRATE = "CostRate";
        /// <summary>
        /// 得意先条件
        /// </summary>
        public const string COLUMN_SEARCHCONDTION = "SearchCondtion";
        /// <summary>
        /// 売価率
        /// </summary>
        public const string COLUMN_SALERATE = "SaleRate";
        /// <summary>
        /// 原価ＵＰ率
        /// </summary>
        public const string COLUMN_UPRATE = "UpRate";
        /// <summary>
        /// 粗利確保率
        /// </summary>
        public const string COLUMN_GRSPROFITSECURERAT = "GrsProfitSecureRat";
 
        private const string CUSTOMER_MODE1 = "得意先掛率Ｇ";
        private const string CUSTOMER_MODE2 = "得意先";

        private const string RATE_TITLE_RATEVAL = "売価率";
        private const string RATE_TITLE_UPRATE = "原価UP率";
        private const string RATE_TITLE_GRSPROFITSECURERAT = "粗利確保率";

        #endregion ■ Constants
        /// <summary>
        /// Excel出力用クラス
        /// </summary>
        public PMKHN09902UB()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Excel出力：データの作成
        /// </summary>
        /// <param name="parmGrid">画面表示用Grid</param>
        /// <param name="resultGrid">Execl出力用Grid</param>
        public void SetExcelOutputDataGrid(UltraGrid parmGrid, out UltraGrid resultGrid )
        {
            resultGrid = new UltraGrid();
            this.tempUltraGrid.BeginUpdate();
            ColumnsCollection parmGridColumns = parmGrid.DisplayLayout.Bands[0].Columns;
            DataTable dataTable = new DataTable();
            DataRow titleRow = dataTable.NewRow();//タイトル行
            // Execl出力ファイルのタイトル行設定（Execl出力用Grid明細部の第１行）
            foreach (UltraGridColumn column in parmGridColumns)
            {
                string colKey = column.Key;

                if (!parmGridColumns[colKey].Hidden)
                {
                    if (!dataTable.Columns.Contains(colKey))
                    {
                        dataTable.Columns.Add(colKey, typeof(string));
                        // 毎列の表示文字の設定
                        if (colKey.Contains(COLUMN_SALERATE))
                        {
                            titleRow[colKey] = RATE_TITLE_RATEVAL;// 売価率
                            continue;
                        }
                        else if (colKey.Contains(COLUMN_UPRATE))
                        {
                            titleRow[colKey] = RATE_TITLE_UPRATE;// 原価UP率
                            continue;
                        }
                        else if (colKey.Contains(COLUMN_GRSPROFITSECURERAT))
                        {
                            titleRow[colKey] = RATE_TITLE_GRSPROFITSECURERAT;// 粗利確保率
                            continue;
                        }
                        else if (colKey.Equals(COLUMN_GOODSRATEGRPCODE))
                        {
                            titleRow[colKey] = "商品掛率G";
                        }
                        else if (colKey.Equals(COLUMN_GLCD))
                        {
                            titleRow[colKey] = "GRCD";
                        }
                        else if (colKey.Equals(COLUMN_BLCD))
                        {
                            titleRow[colKey] = "BLｺｰﾄﾞ";
                        }
                        else
                        {
                            titleRow[colKey] = parmGridColumns[colKey].Header.Caption;
                        }

                        if (parmGrid.DisplayLayout.Bands[0].Groups[colKey].Hidden)
                        {
                            dataTable.Columns.Remove(colKey);//非表示列の削除
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
            // Execl出力のデータ取得（検索取得の全てデータ）
            DataTable sourceDataTable = (DataTable)parmGrid.DataSource;// 画面表示用GridのDataSource
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
            
            dataTable.Columns.Remove(dataTable.Columns[COLUMN_NO]);// No列の削除
            dataTable.Columns.Remove(dataTable.Columns[COLUMN_MAKERNAME]);// メーカー名列の削除
            this.tempUltraGrid.DataSource = dataTable;
            this.tempUltraGrid.DisplayLayout.CopyFrom(parmGrid.DisplayLayout);

            // 商品掛率Gと層別は左揃え
            ColumnsCollection columns = tempUltraGrid.DisplayLayout.Bands[0].Columns;
            columns[0].CellAppearance.TextHAlign = HAlign.Left;

           // 明細部の様の設定
            for (int rowIndex = 0; rowIndex < parmGrid.Rows.Count; rowIndex++)
            {
                CellsCollection cells = this.tempUltraGrid.Rows[rowIndex+1].Cells;
                foreach (DataColumn dataColumn in dataTable.Columns)
                {
                    cells[dataColumn.ColumnName].Appearance = parmGrid.Rows[rowIndex].Cells[dataColumn.ColumnName].Appearance;// 明細行の様と画面の明細行の同じ
                    cells[dataColumn.ColumnName].Activation = parmGrid.Rows[rowIndex].Cells[dataColumn.ColumnName].Activation;// 検索行のセル制御
                }
                
            }
            // タイトル行の様の設定
            foreach (UltraGridColumn gridColumn in this.tempUltraGrid.DisplayLayout.Bands[0].Columns)
            {
                if (gridColumn.Index > 7)
                {
                    // 得意先検索条件のタイトルのカラー設定
                    this.tempUltraGrid.DisplayLayout.Bands[0].Columns[gridColumn.Key].Header.Appearance.BackColor = Color.FromArgb(89, 135, 214);// blue
                    this.tempUltraGrid.DisplayLayout.Bands[0].Columns[gridColumn.Key].Header.Appearance.BackColor2 = Color.FromArgb(7, 59, 150);
                }
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.BackColor = Color.FromArgb(89, 135, 214);
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.BackColor2 = Color.FromArgb(7, 59, 150);
                // タイトル行のセルの書式設定（文字位置・カラーとボーダーカラー）
                this.tempUltraGrid.DisplayLayout.Bands[0].Columns[gridColumn.Key].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.ForeColor = Color.White;
                this.tempUltraGrid.Rows[0].Cells[gridColumn.Key].Appearance.BorderColor = Color.Black;
                this.tempUltraGrid.DisplayLayout.Bands[0].Columns[gridColumn.Key].Hidden = false;
                // 掛率以外の非表示行が表示に設定する
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