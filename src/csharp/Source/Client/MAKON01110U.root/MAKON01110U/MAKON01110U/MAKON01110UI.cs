using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ����ŗ��ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����ŗ��ݒ�t�H�[���N���X�ł��B</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2020/02/24</br>
    /// <br></br>
    /// </remarks>
    public partial class MAKON01110UI : Form
    {
        private double _taxRate = 0;
        private StockSlipInputInitDataAcs _stockSlipInputInitDataAcs;
        string pgId = "MAKON01110UI";
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region ��Constructor
        public MAKON01110UI(double taxRate)
        {
            InitializeComponent();
            this._stockSlipInputInitDataAcs = StockSlipInputInitDataAcs.GetInstance();
            double temp = taxRate * 100;
            int temInt = (int)temp;
            this.TaxRate_tNedit.Text = temInt.ToString();
        }
        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        #region ��Property
        /// <summary>
        /// �ŗ��v���p�e�B
        /// </summary>
        public double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }
        #endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods

        /// <summary>
        /// �m��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �m��{�^���N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            if (TaxRate_tNedit.GetValue() == 0)
            {
                string message = "����ŗ�����͂��Ă��������B";
                // �G���[���b�Z�[�W������Ε\��
                TMsgDisp.Show(this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            pgId,
                            message,
                            0,
                            MessageBoxButtons.OK);
                TaxRate_tNedit.Focus();
            }
            else
            {
                this._stockSlipInputInitDataAcs.TaxRateValue = TaxRate_tNedit.GetValue()/100;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        /// <summary>
        /// ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ����{�^���N���b�N���ɔ������܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2020/02/24</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            if (!e.ShiftKey && e.Key == Keys.Enter)
            {
                switch (e.PrevCtrl.Name)
                {
                    // ��ʐŗ��Ɗm��{�^���ɃJ�[�\��������ꍇ
                    case "TaxRate_tNedit":
                    case "uButton_Save":
                        {
                            uButton_Save.PerformClick();
                            e.NextCtrl = TaxRate_tNedit;
                            break;
                        }
                    // ����{�^���ɃJ�[�\��������ꍇ
                    case "uButton_Close":
                        {
                            uButton_Close.PerformClick();

                            break;
                        }
                }
            }
        }
        #endregion
    }
}