using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ����ŗ��ݒ�R���g���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ŗ��̓��͂��s���R���g���[���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2020/02/24</br>
    /// </remarks>
    public partial class MAHNB01010UR : Form
    {
        DialogResult _result = DialogResult.Cancel;

        public MAHNB01010UR(double taxRate)
        {
            InitializeComponent();
            _taxRate = taxRate;
            this.TaxRate_tNedit.SetValue(taxRate * 100);
        }
        private double _taxRate;

        /// <summary>�ŗ�</summary>
        public double TaxRate
        {
            get { return _taxRate; }
            set { _taxRate = value; }
        }

        /// <summary>
        /// �m��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �m��{�^���N���b�N�C�x���g�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void uButton_Save_Click(object sender, EventArgs e)
        {
            if (this.TaxRate_tNedit.GetValue() == 0.0)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "����ŗ�����͂��Ă��������B",
                    -1,
                    MessageBoxButtons.OK);

                this.TaxRate_tNedit.Focus();
            }
            else
            {
                _taxRate = this.TaxRate_tNedit.GetValue() / 100;
                DialogResult = DialogResult.OK;
                _result = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ����{�^���N���b�N�C�x���g�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void uButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �t�H�[���N���[�Y�㔭���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���[�Y�㔭���C�x���g�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void MAKON01110UR_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = this._result;
        }

        /// <summary>
        /// ���׃O���b�h���[���C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ���׃O���b�h���[���C�x���g�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void TaxRate_tNedit_Leave(object sender, EventArgs e)
        {
            Double value = TaxRate_tNedit.GetValue();
            TaxRate_tNedit.Text = value.ToString("#0");	
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note       : �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/02/24</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
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
    }
}