using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �ȈՃI�X�X���I��
    /// </summary>
    public partial class RecommendForm : Form
    {
        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public RecommendForm()
        {
            InitializeComponent();
        }
        #endregion

        #region �����o
        /// <summary>�I������</summary>
        public int _count;
        /// <summary>�Ώ�(1:���i���A2�F�����H��)</summary>
        public int _target;
        #endregion

        #region Public
        /// <summary>
        /// �N������
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowRecomendForm(int bootMode, long categoryId, string categoryName)
        {
            if (bootMode == 2)
            {
                this.Target1_panel.Visible = false;
                this.SF_Lable.Visible = true;
                this.PM_Label.Visible = false;
            }
            else
            {
                this.Target1_ComboEditor.Items.Add(2,"�����H��");
                this.Target1_ComboEditor.Items.Add(1, "���i��");
                this.Target1_ComboEditor.SelectedIndex = 0;
                this.SF_Lable.Visible = false;
                this.PM_Label.Visible = true;
            }

            this.Target2_ComboEditor.Items.Add(1, "1");
            this.Target2_ComboEditor.Items.Add(2, "2");
            this.Target2_ComboEditor.Items.Add(3, "3");
            this.Target2_ComboEditor.SelectedIndex = 0;

            this.Category_textBox.Text = categoryName;

            switch (categoryId)
            {
                case 1: // �^�C��
                    this.Cndition_Lable.Text = "�e�T�C�Y�̒���";
                    break;
                case 2: // �o�b�e��
                    this.Cndition_Lable.Text = "�e�K�i�̒���";
                    break;
                case 3: // �I�C��
                    this.Cndition_Lable.Text = "�e�S�x�̒���";
                    break;
            }
            return this.ShowDialog();
        }
        #endregion

        #region Private
        /// <summary>
        /// ���l���̓`�F�b�N����
        /// </summary>
        /// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
        /// <param name="priod">�����_�ȉ�����</param>
        /// <param name="prevVal">���݂̕�����</param>
        /// <param name="key">���͂��ꂽ�L�[�l</param>
        /// <param name="selstart">�J�[�\���ʒu</param>
        /// <param name="sellength">�I�𕶎���</param>
        /// <param name="minusFlg">�}�C�i�X���͉H</param>
        /// <returns>true=���͉�,false=���͕s��</returns>
        private Boolean KeyPressCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // ����L�[�������ꂽ�H
            if (Char.IsControl(key) == true)
            {
                return true;
            }
            // ���l�ȊO�́A�m�f
            if (Char.IsNumber(key) == false)
            {
                // �����_�܂��́A�}�C�i�X�ȊO
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
            string _strResult = "";
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // �}�C�i�X�̃`�F�b�N
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // �����_�̃`�F�b�N
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // �L�[�������ꂽ���ʂ̕�����𐶐�����B
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // �����`�F�b�N�I
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // �����_�ȉ��̃`�F�b�N
            if (priod > 0)
            {
                // �����_�̈ʒu����
                int _pointPos = _strResult.IndexOf('.');

                // �������ɓ��͉\�Ȍ���������I
                int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // �������̌������`�F�b�N
                if (_pointPos != -1)
                {
                    // �������̌������v�Z
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

        #region Event
        /// <summary>
        /// �m��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            this._count = Convert.ToInt32(this.Target2_ComboEditor.Value);

            if (this._count == 0)
            {
                // ���b�Z�[�W��\��
                TMsgDisp.Show(
                this,							        // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                "SFMIT010201U",					        // �A�Z���u��ID�܂��̓N���XID
                 "��������͂��ĉ������B", 	            // �\�����郁�b�Z�[�W 
                0,								        // �X�e�[�^�X�l
                   MessageBoxButtons.OK);
                this.Target2_ComboEditor.Focus();
                return;
            }

            if (this.Target1_panel.Visible)
            {
                this._target = (int)this.Target1_ComboEditor.Value;
            }

            

            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// �L�����Z��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// tComboEditor1_KeyPress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!KeyPressCheck(2, 0, this.Target2_ComboEditor.Text, e.KeyChar, this.Target2_ComboEditor.SelectionStart, this.Target2_ComboEditor.SelectionLength, false))
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}