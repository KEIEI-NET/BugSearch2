//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �g���^�񓚃f�[�^�捞����
// �v���O�����T�v   : UOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A
//                    ����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10507391-00 �쐬�S�� : �����
// �� �� ��  2010/01/04  �C�����e : �V�K�쐬
//                                 �y�v��No.6�zUOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A����E�d���f�[�^�̍쐬���s��
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
    /// �g���^�񓚃f�[�^�捞�����t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �g���^�񓚃f�[�^�捞�����̃t���[���N���X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2010/01/04</br>
    /// <br></br>
    /// </remarks>
    public partial class PMUOE01610UA : Form
    {
        # region �R���X�g���N�^
        /// <summary>
        /// �g���^�񓚃f�[�^�捞�����t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �g���^�񓚃f�[�^�捞�����̃R���X�g���N�^�ł��B</br>      
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2010/01/04</br>
        /// </remarks>
        public PMUOE01610UA()
        {
            InitializeComponent();
        }

        # endregion

        # region private Member
        /// <summary>�g���^�񓚃f�[�^�捞�������̓t�H�[���N���X</summary>             
        /// <remarks>�Ȃ�</remarks>�@
        PMUOE01611UA _mPMUOE01611UAForm;
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
        /// <br>Date       : 2010/01/04</br> 
        /// </remarks>
        private void PMUOE01610UA_Load(object sender, EventArgs e)
        {

            this._mPMUOE01611UAForm = new PMUOE01611UA();

            this._mPMUOE01611UAForm.TopLevel = false;
            this._mPMUOE01611UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMUOE01611UAForm.Show();
            this._mPMUOE01611UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMUOE01611UAForm.Text;
            this.Controls.Add(this._mPMUOE01611UAForm);

            this._mPMUOE01611UAForm.FormClosed += new FormClosedEventHandler(this.PMUOE01610UA_FormClosed);
        }

        /// <summary>
        /// ����C�x���g                                        
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                           
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ����鎞�ɔ������܂��B</br>      
        /// <br>Programmer : �����</br>                                  
        /// <br>Date       : 2010/01/04</br> 
        /// </remarks>
        private void PMUOE01610UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        # endregion
    }
}