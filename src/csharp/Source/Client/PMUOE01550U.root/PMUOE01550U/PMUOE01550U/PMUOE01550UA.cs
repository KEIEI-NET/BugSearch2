//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����ꗗ�X�V����
// �v���O�����T�v   : �z���_e-Parts�V�X�e�����u�������ꗗCSV�v����荞�݁A
//                    �񓚏����X�V���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

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
    /// �����ꗗ�X�V�����t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����ꗗ�X�V�����̃t���[���N���X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.05.31</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.05.31 lizc �V�K�쐬</br>
    /// </remarks>
    public partial class PMUOE01550UA : Form
    {
        # region �R���X�g���N�^
        /// <summary>
        /// �����ꗗ�X�V�����t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����ꗗ�X�V�����̃R���X�g���N�^�ł��B</br>      
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.31</br>
        /// </remarks>
        public PMUOE01550UA()
        {
            InitializeComponent();
        }

        # endregion

        # region private Member
        /// <summary>�����ꗗ�X�V�������̓t�H�[���N���X</summary>             
        /// <remarks>�Ȃ�</remarks>�@
        PMUOE01551UA _mPMUOE01551UAForm;
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
        /// <br>Date       : 2009.05.31</br> 
        /// </remarks>
        private void PMUOE01550UA_Load(object sender, EventArgs e)
        {

            this._mPMUOE01551UAForm = new PMUOE01551UA();

            this._mPMUOE01551UAForm.TopLevel = false;
            this._mPMUOE01551UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMUOE01551UAForm.Show();
            this._mPMUOE01551UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMUOE01551UAForm.Text;
            this.Controls.Add(this._mPMUOE01551UAForm);

            this._mPMUOE01551UAForm.FormClosed += new FormClosedEventHandler(this.PMUOE01550UA_FormClosed);
        }

        /// <summary>
        /// ����C�x���g                                        
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                           
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ����鎞�ɔ������܂��B</br>      
        /// <br>Programmer : �����</br>                                  
        /// <br>Date       : 2009.05.31</br> 
        /// </remarks>
        private void PMUOE01550UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        # endregion
    }
}