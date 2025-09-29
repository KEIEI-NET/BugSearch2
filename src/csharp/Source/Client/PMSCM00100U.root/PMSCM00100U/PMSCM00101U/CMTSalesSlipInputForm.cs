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
    /// CMT�p����`�[���̓t�H�[��
    /// </summary>
    public partial class CMTSalesSlipInputForm : MAHNB01010UA
    {
        #region Constructor

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="commandLineParameter">�R�}���h���C����������̃p�����[�^</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
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