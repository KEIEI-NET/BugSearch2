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
    /// �����_�ݒ�}�X�^�N���X                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����_�ݒ�}�X�^�̃t�H�[���N���X�ł��B</br>      
    /// <br>Programmer : �����</br>                                  
    /// <br>Date       : 2009.03.31</br> 
    /// </remarks>
    public partial class PMHAT09000UA : Form
    {
        # region �R���X�g���N�^
        /// <summary>
        /// �����_�ݒ�}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����_�ݒ�}�X�^�̃R���X�g���N�^�ł��B</br>      
        /// <br>Programmer : �����</br>                                  
        /// <br>Date       : 2009.03.31</br> 
        /// </remarks>
        public PMHAT09000UA()
        {
            InitializeComponent();
        }
        # endregion

        # region private Member
        /// <summary>�����_�ݒ�}�X�^�̃t�H�[���N���X</summary>             
        /// <remarks>�Ȃ�</remarks>�@
        PMHAT09001UA _mPMHAT09001UAForm;
        # endregion

        # region �C�x���g
        /// <summary>
        /// ���[�h�C�x���g                                            
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                            
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ����[�h���ɔ������܂��B</br>      
        /// <br>Programmer : �����</br>                                  
        /// <br>Date       : 2009.03.31</br> 
        /// </remarks>
        private void PMHAT09000UA_Load(object sender, EventArgs e)
        {
            this._mPMHAT09001UAForm = new PMHAT09001UA();
            this._mPMHAT09001UAForm.TopLevel = false;
            this._mPMHAT09001UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMHAT09001UAForm.Show();
            this._mPMHAT09001UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMHAT09001UAForm.Text;
            this.Controls.Add(this._mPMHAT09001UAForm);

            this._mPMHAT09001UAForm.FormClosed += new FormClosedEventHandler(this.PMHAT09001U_FormClosed);
        }

        /// <summary>
        /// ����C�x���g                                        
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                           
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ����鎞�ɔ������܂��B</br>      
        /// <br>Programmer : �����</br>                                  
        /// <br>Date       : 2009.03.31</br> 
        /// </remarks>
        private void PMHAT09001U_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        # endregion
    }
}