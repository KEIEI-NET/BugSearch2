//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�c�_�񓚃f�[�^�捞����
// �v���O�����T�v   : UOE�����f�[�^�Ɣ����񓚃f�[�^�̂����킹���s���A
//                    ����E�d���f�[�^�̍쐬���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : ������
// �� �� ��  2011/05/18  �C�����e : �V�K�쐬
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
    /// �}�c�_�񓚃f�[�^�捞�����t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �}�c�_�񓚃f�[�^�捞�����̃t���[���N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br></br>
    /// </remarks>
    public partial class PMUOE01640UA : Form
    {
        # region �R���X�g���N�^
        /// <summary>
        /// �}�c�_�񓚃f�[�^�捞�����t�H�[���N���X �f�t�H���g�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �}�c�_�񓚃f�[�^�捞�����̃R���X�g���N�^�ł��B</br>      
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/05/18</br>
        /// </remarks>
        public PMUOE01640UA()
        {
            InitializeComponent();
        }

        # endregion

        # region private Member
        /// <summary>�}�c�_�񓚃f�[�^�捞�������̓t�H�[���N���X</summary>             
        /// <remarks>�Ȃ�</remarks>�@
        PMUOE01641UA _mPMUOE01641UAForm;
        # endregion

        # region �C�x���g
        /// <summary>
        /// ���[�h�C�x���g                                            
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                            
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ����[�h���ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2011/05/18</br> 
        /// </remarks>
        private void PMUOE01640UA_Load(object sender, EventArgs e)
        {

            this._mPMUOE01641UAForm = new PMUOE01641UA();

            this._mPMUOE01641UAForm.TopLevel = false;
            this._mPMUOE01641UAForm.FormBorderStyle = FormBorderStyle.None;
            this._mPMUOE01641UAForm.Show();
            this._mPMUOE01641UAForm.Dock = DockStyle.Fill;
            this.Text = this._mPMUOE01641UAForm.Text;
            this.Controls.Add(this._mPMUOE01641UAForm);

            this._mPMUOE01641UAForm.FormClosed += new FormClosedEventHandler(this.PMUOE01640UA_FormClosed);
        }

        /// <summary>
        /// ����C�x���g                                        
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                           
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ����鎞�ɔ������܂��B</br>      
        /// <br>Programmer : ������</br>                                  
        /// <br>Date       : 2011/05/18</br> 
        /// </remarks>
        private void PMUOE01640UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        # endregion
    }
}