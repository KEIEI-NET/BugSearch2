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
    /// ���z�ꊇ�v�Z�N���X
    /// </summary>
    public partial class CalcPriceForm : Form
    {
        public CalcPriceForm(int bootMode)
        {
            InitializeComponent();
            this._percentage_PM = 0;
            this._percentage_SF = 0;
            this._originCol_PM = "";
            this._originCol_SF = "";
            this._targetCol_PM = "";
            this._targetCol_SF = "";
            this._bootMode = 0;
            this._calcDiv = true;


            // �v�Z�Ώۂ͍��̂Ƃ���Œ�
            this._targetCol_SF = COL_SHOP_PRICE;
            this._targetCol_PM = COL_TRADE_PRICE;

            this.SF_TARGET_ComboEditor.Items.Add(1, COL_SUGGEST_PRICE);
            if (bootMode == 2)
            {
                // �����H�ꃂ�[�h �����H�ꃂ�[�h�̏ꍇ�͕W�����i�Ǝd������
                this.SF_TARGET_ComboEditor.Items.Add(2, COL_PURCHASE_COST);
            }
            else
            {
                // ���i�����[�h ���i�����[�h�̏ꍇ�͕W�����i�Ɣ���
                this.SF_TARGET_ComboEditor.Items.Add(2, COL_TRADE_PRICE);
            }

            this.SF_TARGET_ComboEditor.Value = 1;

            // ���i������
            this.PM_TARGET_ComboEditor.Items.Add(1, COL_SUGGEST_PRICE);
            this.PM_TARGET_ComboEditor.Items.Add(2, COL_PURCHASE_COST);
            this.PM_TARGET_ComboEditor.Value = 2;

            // �[�������敪
            this.Digit_ComboEditor.Value = -12;
        }

        /// <summary>
        /// �N������
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowCalcPriceForm()
        {
            if (this._bootMode == 2)
            {
                // �����H�ꃂ�[�h
                this.SFModeTitle_Lable.Visible = true;
                this.SF_CheckEditor.Visible = false;
                this.PMTITLE_panel.Visible = false;
                this.PMCALC_panel.Visible = false;

                this.Size = new Size(490, 220);

                // �v�Z�Ώ�
                if ((int)this.SF_TARGET_ComboEditor.Value == 1)
                {
                    this._originCol_SF = COL_SUGGEST_PRICE;
                }
                else
                {
                    // �����H�ꃂ�[�h�̏ꍇ�͔������d�������ƂȂ��
                    this._originCol_SF = COL_TRADE_PRICE;
                }
            }
            else
            {
                // ���i�����[�h
                this.Size = new Size(490, 310);

                // �v�Z�Ώ�
                if ((int)this.PM_TARGET_ComboEditor.Value == 1)
                {
                    this._originCol_PM = COL_SUGGEST_PRICE;
                }
                else
                {
                    this._originCol_PM = COL_PURCHASE_COST;
                }

                if ((int)this.SF_TARGET_ComboEditor.Value == 1)
                {
                    this._originCol_SF = COL_SUGGEST_PRICE;
                }
                else
                {
                    this._originCol_SF = COL_TRADE_PRICE;
                }
            }

            // ����
            this._percentage_PM = this.PM_TARGET_tNedit.GetInt();
            this._percentage_SF = this.SF_TARGET_tNedit.GetInt();

            // ���z���͕��̂݃`�F�b�N
            if (this.CalcDiv_CheckEditor.Checked)
            {
                this._calcDiv = true;
            }
            else
            {
                this._calcDiv = false;
            }

            // �[�������敪
            this._fracCd = Convert.ToInt32(this.Digit_ComboEditor.Value);

            return this.ShowDialog();
        }

        private const string CT_ASSEMBLYID = "SFMIT10201U";

        private const string COL_SUGGEST_PRICE = "�W�����i";
        private const string COL_TRADE_PRICE = "����";
        private const string COL_PURCHASE_COST = "�d������";
        private const string COL_SHOP_PRICE = "�X�����i";


        // �N�����[�h
        public int _bootMode;

        // �v�Z���J����
        public string _originCol_SF;
        public string _originCol_PM;

        // �v�Z�ΏۃJ����
        public string _targetCol_SF;
        public string _targetCol_PM;


        // �p�[�Z���e�[�W
        public int _percentage_SF;
        public int _percentage_PM;

        // �[�������敪
        public bool _calcDiv;

        // �[�������敪
        public int _fracCd;

        /// <summary>
        /// SF_CheckEditor_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SF_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.SF_CheckEditor.Checked)
            {
                this.SF_TARGET_ComboEditor.Enabled = true;
                this.SF_TARGET_tNedit.Enabled = true;
            }
            else
            {
                this.SF_TARGET_ComboEditor.Enabled = false;
                this.SF_TARGET_tNedit.Enabled = false;
            }
        }
        /// <summary>
        /// PM_CheckEditor_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PM_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.PM_CheckEditor.Checked)
            {
                this.PM_TARGET_ComboEditor.Enabled = true;
                this.PM_TARGET_tNedit.Enabled = true;
            }
            else
            {
                this.PM_TARGET_ComboEditor.Enabled = false;
                this.PM_TARGET_tNedit.Enabled = false;
            }
        }



        /// <summary>
        /// ����{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �v�Z���s�{�^��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (this._bootMode == 1)
            {
                // ���i�����[�h

                if (this.PM_CheckEditor.Checked)
                {
                    if (this.PM_TARGET_tNedit.GetInt() == 0)
                    {
                        // ���b�Z�[�W��\��
                        TMsgDisp.Show(
                           this,							        // �e�E�B���h�E�t�H�[��
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                           CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                           "�p�[�Z���e�[�W����͂��ĉ������B",	    // �\�����郁�b�Z�[�W 
                           0,								        // �X�e�[�^�X�l
                           MessageBoxButtons.OK);
                        this.PM_TARGET_tNedit.Focus();
                        return;
                    }
                }


                if (this.SF_CheckEditor.Checked)
                {
                    if (this.SF_TARGET_tNedit.GetInt() == 0)
                    {
                        // ���b�Z�[�W��\��
                        TMsgDisp.Show(
                           this,							        // �e�E�B���h�E�t�H�[��
                           emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                           CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                           "�p�[�Z���e�[�W����͂��ĉ������B",	    // �\�����郁�b�Z�[�W 
                           0,								        // �X�e�[�^�X�l
                           MessageBoxButtons.OK);
                         this.SF_TARGET_tNedit.Focus();
                         return;
                    }
                }
              
                if (this.SF_CheckEditor.Checked == false && this.PM_CheckEditor.Checked == false)
                {
                    // ���b�Z�[�W��\��
                    TMsgDisp.Show(
                       this,							        // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                       CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                       "�v�Z�Ώۂ�I�����ĉ������B",	        // �\�����郁�b�Z�[�W 
                       0,								        // �X�e�[�^�X�l
                       MessageBoxButtons.OK);
                    this.SF_CheckEditor.Focus();
                    return;
                }

                if (this.SF_CheckEditor.Checked)
                {
                    if ((int)this.SF_TARGET_ComboEditor.Value == 1)
                    {
                        this._originCol_SF = COL_SUGGEST_PRICE;
                    }
                    else
                    {
                        this._originCol_SF = COL_TRADE_PRICE;
                    }
                    this._percentage_SF = this.SF_TARGET_tNedit.GetInt();
                }

                if (this.PM_CheckEditor.Checked)
                {
                    if ((int)this.PM_TARGET_ComboEditor.Value == 1)
                    {
                        this._originCol_PM = COL_SUGGEST_PRICE;
                    }
                    else
                    {
                        this._originCol_PM = COL_PURCHASE_COST;
                    }
                    this._percentage_PM = this.PM_TARGET_tNedit.GetInt();
                }
            }
            else
            {
                // �����H�ꃂ�[�h
                if (this.SF_TARGET_tNedit.GetInt() == 0)
                {
                    // ���b�Z�[�W��\��
                    TMsgDisp.Show(
                       this,							        // �e�E�B���h�E�t�H�[��
                       emErrorLevel.ERR_LEVEL_EXCLAMATION,	    // �G���[���x��
                       CT_ASSEMBLYID,					        // �A�Z���u��ID�܂��̓N���XID
                       "�p�[�Z���e�[�W����͂��ĉ������B",	    // �\�����郁�b�Z�[�W 
                       0,								        // �X�e�[�^�X�l
                       MessageBoxButtons.OK);
                    this.SF_TARGET_tNedit.Focus();
                    return;
                }

                if ((int)this.SF_TARGET_ComboEditor.Value == 1)
                {
                    this._originCol_SF = COL_SUGGEST_PRICE;
                }
                else
                {
                    // �����H�ꃂ�[�h�̏ꍇ�͔������d�������ƂȂ��
                    this._originCol_SF = COL_TRADE_PRICE;
                }
                this._percentage_SF = this.SF_TARGET_tNedit.GetInt();
            }

            // �[�������敪
            this._fracCd = Convert.ToInt32(this.Digit_ComboEditor.Value);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// CalcDiv_CheckEditor_CheckedChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcDiv_CheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if(this.CalcDiv_CheckEditor.Checked)
            {
                this._calcDiv = true;
            }
            else
            {
                this._calcDiv = false;
            }
        }
    }
}