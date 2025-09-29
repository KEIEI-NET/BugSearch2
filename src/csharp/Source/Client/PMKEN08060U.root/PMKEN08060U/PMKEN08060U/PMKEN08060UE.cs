using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Library.Windows.Forms
{
    internal partial class FrmJoinPartsInfo : Form
    {
        private dsPartsSel.UsrJoinPartsDataTable primeParts = new dsPartsSel.UsrJoinPartsDataTable();
        private PartsInfoDataSet _orgDataSet;
        private int _makerCd;
        private string _partsNo;
        public int JoinSrcMakerCd
        {
            set
            {
                _makerCd = value;
            }
        }
        public string JoinSrcPartsNo
        {
            set
            {
                _partsNo = value;
                string filter = string.Format("{0}={1} AND {2}='{3}' AND {4}=true",
                    primeParts.JoinSourceMakerCodeColumn.ColumnName, _makerCd,
                    primeParts.JoinSrcPartsNoWithHColumn.ColumnName, _partsNo,
                    _orgDataSet.UsrJoinParts.PrmSettingFlgColumn.ColumnName);
                GridPrimeParts.BeginUpdate();
                primeParts.DefaultView.RowFilter = filter;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/18 ADD
                primeParts.DefaultView.Sort = string.Format( "{0}",
                    primeParts.JoinDispOrderColumn.ColumnName );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/18 ADD
                GridPrimeParts.EndUpdate();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_orgData">部品データセット</param>
        public FrmJoinPartsInfo(PartsInfoDataSet _orgData)
        {
            InitializeComponent();
            _orgDataSet = _orgData;
            primeParts.Merge(_orgData.UsrJoinParts, false, MissingSchemaAction.Ignore);
            GridPrimeParts.DataSource = primeParts.DefaultView;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner">オーナーフォーム</param>
        ///// <param name="makerCd">結合元部品のメーカーコード</param>
        ///// <param name="partsNo">結合元部品の品番</param>
        new void Show(IWin32Window owner)//, int makerCd, string partsNo)
        {
            string filter = string.Format("{0}={1} AND {2}='{3}' AND {4}=true",
                primeParts.JoinSourceMakerCodeColumn.ColumnName, _makerCd,
                primeParts.JoinSrcPartsNoWithHColumn.ColumnName, _partsNo,
                _orgDataSet.UsrJoinParts.PrmSettingFlgColumn.ColumnName);
            GridPrimeParts.BeginUpdate();
            primeParts.DefaultView.RowFilter = filter;
            GridPrimeParts.EndUpdate();
            Show(owner);
        }

        private void GridPrimeParts_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            e.Layout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            e.Layout.Override.RowSizing = RowSizing.Fixed;
            e.Layout.Override.AllowColSizing = AllowColSizing.None;
            e.Layout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            UltraGridBand band = e.Layout.Bands[0];
            band.UseRowLayout = true;

            band.Columns[primeParts.JoinSourceMakerCodeColumn.ColumnName].Hidden = true;
            band.Columns[primeParts.JoinSrcPartsNoWithHColumn.ColumnName].Hidden = true;
            band.Columns[primeParts.PrmSettingFlgColumn.ColumnName].Hidden = true;
            for (int Index = 0; Index < band.Columns.Count; Index++)
            {
                // 水平表示位置
                if ((band.Columns[Index].DataType == typeof(int)) ||
                   (band.Columns[Index].DataType == typeof(Int32)) ||
                   (band.Columns[Index].DataType == typeof(Int64)))
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
                else if (band.Columns[Index].DataType == typeof(Image))
                {
                    band.Columns[Index].CellAppearance.ImageHAlign = Infragistics.Win.HAlign.Center;
                    band.Columns[Index].CellAppearance.ImageVAlign = Infragistics.Win.VAlign.Middle;
                }
                else
                {
                    band.Columns[Index].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
                }
                band.Columns[Index].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                // 垂直表示位置
                band.Columns[Index].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
            }
            SelectionParts.ColInfo.SetColInfo(band, primeParts.JoinDestMakerCdColumn.ColumnName, 2, 0, 2, 2, 30, 18);
            SelectionParts.ColInfo.SetColInfo(band, primeParts.JoinDestPartsNoColumn.ColumnName, 4, 0, 3, 2, 50, 18);
            SelectionParts.ColInfo.SetColInfo(band, primeParts.JoinSpecialNoteColumn.ColumnName, 7, 0, 2, 2, 100, 18);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/18 ADD
            band.Columns[primeParts.JoinDispOrderColumn.ColumnName].Hidden = true; // 表示順:非表示
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/18 ADD
        }

    }
}