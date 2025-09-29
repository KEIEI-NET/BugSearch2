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
    /// CMT用売上伝票入力フォーム
    /// </summary>
    public partial class CMTSalesSlipInputForm : MAHNB01010UA
    {
        #region Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="commandLineParameter">コマンドライン引数からのパラメータ</param>
        /// <param name="customerCode">得意先コード</param>
        public CMTSalesSlipInputForm(
            string commandLineParameter,
            int customerCode
        ) : base(
            commandLineParameter,
            0,
            0,
            "000000000",
            string.Empty,
            string.Empty,
            0,
            customerCode
        ) { }

        #endregion // Constructor
    }
}