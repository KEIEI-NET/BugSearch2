//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�Ǘ��}�X�^
// �v���O�����T�v   : ���q�Ǘ��}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/09/07  �C�����e : �V�K�쐬
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
    /// ���q�Ǘ��}�X�^  �t���[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���q�Ǘ��}�X�^�֘A�̈ꗗ�\�����s���t�H�[���N���X�ł��B</br>
    /// <br>Programmer  : �����</br>
    /// <br>Date        : 2009.09.07</br>
    /// <br>Update Note : </br>
    /// </remarks>
    public partial class PMSYA09020UA : Form
    {
        # region �R���X�g���N�^
        /// <summary>
        /// ���q�Ǘ��}�X�^UI�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���q�Ǘ��}�X�^  �t���[���N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        public PMSYA09020UA()
        {
            InitializeComponent();
        }
        # endregion

        # region private Member
        /// <summary>���q�Ǘ��}�X�^ ���̓t�H�[���N���X</summary>             
        /// <remarks>�Ȃ�</remarks>�@
        private PMSYA09021UA _pMSYA09021UA;
        # endregion

        # region �C�x���g
        /// <summary>
        /// ���[�h�C�x���g                                            
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                            
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : ��ʂ����[�h���ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void PMSYA09020UA_Load(object sender, EventArgs e)
        {
            this._pMSYA09021UA = new PMSYA09021UA();
            this._pMSYA09021UA.TopLevel = false;
            this._pMSYA09021UA.FormBorderStyle = FormBorderStyle.None;
            this._pMSYA09021UA.Show();
            this.Controls.Add(this._pMSYA09021UA);
            this._pMSYA09021UA.Dock = DockStyle.Fill;

            this._pMSYA09021UA.FormClosed += new FormClosedEventHandler(this.PMZAI09201UA_FormClosed);
        }

        /// <summary>
        /// ����C�x���g                                        
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                           
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note        : ��ʂ����鎞�ɔ������܂��B</br>      
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.09.07</br>
        /// </remarks>
        private void PMZAI09201UA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        # endregion
    }
}