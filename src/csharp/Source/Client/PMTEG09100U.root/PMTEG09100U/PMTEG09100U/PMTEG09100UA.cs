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
    /// ��`�f�[�^�}�X�^�N���X                                                         
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`�f�[�^�}�X�^�̃t�H�[���N���X�ł��B</br>      
    /// <br>Programmer : ���R</br>                                  
    /// <br>Date       : 2010.04.22</br> 
    /// </remarks>
    public partial class PMTEG09100UA : Form
    {
        # region �R���X�g���N�^
        /// <summary>
        /// ��`�f�[�^�}�X�^�t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��`�f�[�^�}�X�^�̃R���X�g���N�^�ł��B</br>      
        /// <br>Programmer : ���R</br>                                  
        /// <br>Date       : 2010.04.22</br> 
        /// </remarks>
        public PMTEG09100UA()
        {
            InitializeComponent();
        }
        # endregion

        # region private Member
        /// <summary>��`�f�[�^�}�X�^�̃t�H�[���N���X</summary>             
        /// <remarks>�Ȃ�</remarks>�@
        PMTEG09101UA _mPMTEG09101UAForm;
        # endregion

        # region �C�x���g
        /// <summary>
        /// ���[�h�C�x���g                                            
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                            
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ����[�h���ɔ������܂��B</br>      
        /// <br>Programmer : ���R</br>                                  
        /// <br>Date       : 2010.04.22</br> 
        /// </remarks>
        private void PMTEG09100UA_Load(object sender, EventArgs e)
        {
            this._mPMTEG09101UAForm = new PMTEG09101UA();
            this._mPMTEG09101UAForm.TopLevel = false;
            this._mPMTEG09101UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMTEG09101UAForm.Show();
            this._mPMTEG09101UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMTEG09101UAForm.Text;
            this.Controls.Add(this._mPMTEG09101UAForm);

            this._mPMTEG09101UAForm.FormClosed += new FormClosedEventHandler(this.PPMTEG09101U_FormClosed);
        }

        /// <summary>
        /// ����C�x���g                                        
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                           
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ����鎞�ɔ������܂��B</br>      
        /// <br>Programmer : ���R</br>                                  
        /// <br>Date       : 2010.04.22</br> 
        /// </remarks>
        private void PPMTEG09101U_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        # endregion
    }
}