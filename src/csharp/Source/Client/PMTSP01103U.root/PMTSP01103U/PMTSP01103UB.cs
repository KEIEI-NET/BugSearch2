using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using System.Collections.Specialized;

namespace Broadleaf.Windows.Forms
{
	public partial class PMTSP01103UB : Form
	{
		#region コンストラクタ
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
        public PMTSP01103UB(TspSdRvDt dt,TspSdRvDtl[] dtl)
		{
			InitializeComponent();
            this._TspSdRvDtl = dtl;
            this.DetailGrid.Text = String.Format("伝票番号[{0}] 伝票合計金額[ \\{1}]", dt.PmSlipNo, dt.TspTotalSlipPrice.ToString("n0")  );
		}

		#endregion

		#region フィールド

		/// <summary>
		/// 明細データ
		/// </summary>
        private Broadleaf.Application.UIData.TspSdRvDtl[] _TspSdRvDtl = null;
		
		#endregion

		#region プロパティ

        private const string BLPartsCode = "DTL_0001";	//BLコード
        private const string PartsNoWithHyphen = "DTL_0002";	//品番（ハイフン付）
        private const string PmPartsNameKana = "DTL_0003";//品名
        private const string DeliveredGoodsCount = "DTL_0004";//数量
        private const string UnitPrice = "DTL_0005";	//単価
        private const string LinePrice = "DTL_0006";	//金額（数量×単価）
		
		#endregion

		#region ・コントロールイベント

		private void PMTSP01103UB_Load(object sender, EventArgs e)
        {
            SetTSPDtlList();
            DetailGrid_InitializeLayout();
        }

        private void SetTSPDtlList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(CreateColumn(BLPartsCode, typeof(int), "BLｺｰﾄﾞ"));	
            dt.Columns.Add(CreateColumn(PartsNoWithHyphen, typeof(string), "品番"));
            dt.Columns.Add(CreateColumn(PmPartsNameKana, typeof(string), "品名"));
            dt.Columns.Add(CreateColumn(DeliveredGoodsCount, typeof(int), "数量"));
            dt.Columns.Add(CreateColumn(UnitPrice, typeof(int), "単価"));
            dt.Columns.Add(CreateColumn(LinePrice, typeof(int), "金額"));

            foreach (Broadleaf.Application.UIData.TspSdRvDtl td in _TspSdRvDtl)
            {
                DataRow dtl_dr = dt.NewRow();
                if (td.TbsPartsCode < 0) dtl_dr[BLPartsCode] = 0;
                else dtl_dr[BLPartsCode] = td.TbsPartsCode;
                dtl_dr[PartsNoWithHyphen] = td.PartsNoWithHyphen;
                dtl_dr[PmPartsNameKana] = td.PmPartsNameKana;
                dtl_dr[DeliveredGoodsCount] = td.DeliveredGoodsCount;
                dtl_dr[UnitPrice] = td.UnitPrice;
                dtl_dr[LinePrice] = (td.UnitPrice * td.DeliveredGoodsCount);

                dt.Rows.Add(dtl_dr);

            }

            DetailGrid.DataSource = dt;

        }

        private DataColumn CreateColumn(string columnName, Type type, string caption)
        {
            DataColumn dc = new DataColumn();

            dc.ColumnName = columnName;
            dc.DataType = type;
            dc.Caption = caption;

            return dc;
        }

        private void DetailGrid_InitializeLayout()
        {

            Infragistics.Win.UltraWinGrid.UltraGrid grid = DetailGrid;

            //バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band = grid.DisplayLayout.Bands[0];

            //列幅自動調整
            grid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;

            band.Columns[BLPartsCode].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled;//BLコード
            band.Columns[PartsNoWithHyphen].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled; ;	//品番
            band.Columns[PmPartsNameKana].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled; ;	//品名
            band.Columns[DeliveredGoodsCount].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled; ;	//数量
            band.Columns[UnitPrice].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled; ;	//単価
            band.Columns[LinePrice].SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Disabled; ;	//合計

            band.Columns[BLPartsCode].Width = 60;	//BLコード
            band.Columns[PartsNoWithHyphen].Width = 180;	//品番
            band.Columns[PmPartsNameKana].Width = 240;	//品名
            band.Columns[DeliveredGoodsCount].Width = 50;	//数量
            band.Columns[UnitPrice].Width = 90;	//単価
            band.Columns[LinePrice].Width = 90;	//合計

            // 表示順
            band.Columns[BLPartsCode].Header.VisiblePosition = 0;	//BLコード
            band.Columns[PartsNoWithHyphen].Header.VisiblePosition = 1;	//品番
            band.Columns[PmPartsNameKana].Header.VisiblePosition = 2;	//品名
            band.Columns[DeliveredGoodsCount].Header.VisiblePosition = 3;	//数量
            band.Columns[UnitPrice].Header.VisiblePosition = 4;	//単価
            band.Columns[LinePrice].Header.VisiblePosition = 5;	//合計

            // 書式
            band.Columns[UnitPrice].Format = "#,##0;-#,##0;";	//単価
            band.Columns[LinePrice].Format = "#,##0;-#,##0;";	//合計
            band.Columns[BLPartsCode].Format = "#####;";	//BLコード

            // 表示位置
            band.Columns[BLPartsCode].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	//BLコード
            band.Columns[PartsNoWithHyphen].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//品番
            band.Columns[PmPartsNameKana].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;	//品名
            band.Columns[DeliveredGoodsCount].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	//数量
            band.Columns[UnitPrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	//単価
            band.Columns[LinePrice].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	//合計

            // キー動作マッピングを追加
            grid.KeyActionMappings.Add(
                new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(
                    Keys.Enter,	//Enterキー
                    Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab,
                    0,
                    Infragistics.Win.UltraWinGrid.UltraGridState.Cell,
                    Infragistics.Win.SpecialKeys.All,
                    0)
                );

        }

		#endregion
	}
}