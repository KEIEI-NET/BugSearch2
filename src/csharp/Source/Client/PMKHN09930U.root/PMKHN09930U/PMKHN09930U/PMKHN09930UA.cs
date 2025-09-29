using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �|���D��ݒ莩���o�^�@���C���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �|���D��ݒ莩���o�^UI�N���X��\�����܂��B</br>
    /// <br>Programmer  : Miwa Honda</br>
    /// <br>Date        : 2013/11/06</br>
    /// <br>UpDate        : 2014.09.19 Miwa Honda�@�T�|�[�g�̊Ǘ����_(1)���Ȃ��Ƃ��G���[</br>
    /// </remarks>
    public partial class PMKHN09930UA : Form
    {
        public PMKHN09930UA()
        {
            InitializeComponent();
        }

        private RateProtyMngConvertClass _convertClass;

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private void PMKHN09930UA_Load(object sender, EventArgs e)
        {
            try
            {
                // �]�ƈ�
               Employee employee = LoginInfoAcquisition.Employee;
                string belongSectionName = employee.BelongSectionName;

                // ���_���擾
                SecInfoAcs secInfoAcs = new SecInfoAcs();


                this._convertClass = new RateProtyMngConvertClass();
                _convertClass.SecInfoSetList = secInfoAcs.SecInfoSetList;

                // ���_�R���{�{�b�N�X
                this.UtilityDiv_tComboEditor.Items.Clear();
                this.UtilityDiv_tComboEditor.Items.Add(RateProtyMngCnvConst.ALL_SECTION_CODE, RateProtyMngCnvConst.ALL_MODE);
                this.UtilityDiv_tComboEditor.Items.Add(RateProtyMngCnvConst.COM_SECTION_CODE, RateProtyMngCnvConst.COMMON_MODE);
                foreach (SecInfoSet secInfoSet in _convertClass.SecInfoSetList)
                {
                    this.UtilityDiv_tComboEditor.Items.Add(secInfoSet.SectionCode.Trim().PadLeft(2, '0'), secInfoSet.SectionGuideNm);
                }

                // �S�Ћ��ʂ�ݒ肷��@�@
                this.UtilityDiv_tComboEditor.Value = RateProtyMngCnvConst.ALL_SECTION_CODE;�@// 2014.09.19 add honda
                // �����_�������\������
                //this.UtilityDiv_tComboEditor.Value = employee.BelongSectionCode.Trim().PadLeft(2, '0'); // 2014.09.19 del honda
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// �o�^�{�^���@�N���b�N�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            // �R���{�{�b�N�X���ݒ�̏ꍇ
            // 2014.09.19 add honda sta ---
            if (this.UtilityDiv_tComboEditor.Value == null)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "���_��I�����Ă��������B\r\n" ,0, MessageBoxButtons.OK);
                return;         
            }
            // 2014.09.19 add honda sta ---

            //�����J�n
            this._convertClass.SectionCode = this.UtilityDiv_tComboEditor.Value.ToString().Trim();
            if (this._convertClass.SectionCode == RateProtyMngCnvConst.ALL_SECTION_CODE)
                this._convertClass.SelectAllSecFlg = true;
            else
                this._convertClass.SelectAllSecFlg = false;

            this._convertClass.Confirmation_checkBox = Confirmation_checkBox.Checked;

            int status = this._convertClass.StartProc(this);

            this.UtilityDiv_tComboEditor.Dispose();
            Close();

            return;

        }

        /// <summary>
        /// �I���{�^���@�N���b�N�C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// ValueChanged �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ���_��ύX�����ꍇ�ɔ������܂��B</br>
        /// </remarks>
        private void UtilityDiv_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (this.UtilityDiv_tComboEditor.Value == null) return;   // 2014.09.19 add honda 

            if (UtilityDiv_tComboEditor.Value.ToString() == "")
                Warning_label.Text = "�����o�Ɏ��Ԃ�������ꍇ������܂��B";
            else
                Warning_label.Text = "";
        }

        /// <summary>
        /// ValueChanged �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: �`�F�b�N���ύX�����ꍇ�ɔ������܂��B</br>
        /// </remarks>
        private void Confirmation_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Confirmation_checkBox.Checked)
            {
                Ok_Button.Text = "��ʕ\��(&S)";
            }
            else
            {
                Ok_Button.Text = "�o�^(&S)";

            }
        }
    }
}