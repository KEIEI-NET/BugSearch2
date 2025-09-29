using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	internal partial class PMKEN09010UD :Form
	{
		# region Constractor
        public PMKEN09010UD(DataView dv)
		{
			InitializeComponent();
            DeleteGrid.DataSource = dv;
        }
		# endregion

		# region Private Members

		# endregion

		# region Consts

        # endregion

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ADD 2008/10/28 不具合対応[6964]---------->>>>>
        /// <summary>
        /// データグリッドのInitializeLayoutイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private void DeleteGrid_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //バンドを取得
            Infragistics.Win.UltraWinGrid.UltraGridBand band = this.DeleteGrid.DisplayLayout.Bands[0];
            
            // タイトル表示位置はセンタリング
            for (int i = 0; i < band.Columns.Count; i++)
            {
                band.Columns[i].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            }
        }
        // ADD 2008/10/28 不具合対応[6964]----------<<<<<
    }
}