using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Application.UIData
{
    internal static class ColInfo
    {

        public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int width)
        {
            Size sizeHeader = new Size();
            Size sizeCell = new Size();

            Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
            Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

            Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
            Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
            Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;

            sizeCell.Height = 24;
            sizeCell.Width = width;
            Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            sizeHeader.Height = 24;
            sizeHeader.Width = width;
            Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

        }
        public static void SetColInfo(UltraGridBand Band, string colname, int originX, int originY, int spanX, int spanY, int width)
        {
            Size sizeHeader = new Size();
            Size sizeCell = new Size();

            Band.RowLayoutLabelPosition = Infragistics.Win.UltraWinGrid.LabelPosition.Top;
            Band.RowLayoutLabelStyle = Infragistics.Win.UltraWinGrid.RowLayoutLabelStyle.Separate;

            Band.Columns[colname].RowLayoutColumnInfo.LabelSpan = 2;
            Band.Columns[colname].RowLayoutColumnInfo.OriginX = originX;
            Band.Columns[colname].RowLayoutColumnInfo.OriginY = originY;
            Band.Columns[colname].RowLayoutColumnInfo.SpanX = spanX;
            Band.Columns[colname].RowLayoutColumnInfo.SpanY = spanY;

            sizeCell.Height = 24;
            sizeCell.Width = width;
            Band.Columns[colname].RowLayoutColumnInfo.PreferredCellSize = sizeCell;
            sizeHeader.Height = 24;
            sizeHeader.Width = width;
            Band.Columns[colname].RowLayoutColumnInfo.PreferredLabelSize = sizeHeader;

        }
    }
}
