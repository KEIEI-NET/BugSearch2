//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��ď��i��ʋN���v���O����
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270029-00  �쐬�S�� : 3H �≓
// �� �� �� : 2016/06/06   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Windows.Forms;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.UIData;

namespace Broadleaf.Library.Forms
{
    /// <summary>
    /// ��ď��i��ʋN���v���O�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ��ď��i��ʋN���v���O�����̃N���X�ł��B</br>
    /// <br>Programmer  : 3H �≓</br>
    /// <br>Date        : 2016/06/06</br>
    /// <br></br>
    class PMKHN01710U : ApplicationContext
    {
        /// <summary>
        /// ��ď��i��ʋN���v���O����
        /// </summary>
        /// <param name="main">��ď��i�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ��ď��i��ʋN���v���O����</br>
        /// <br>Programmer : 3H �≓</br>
        /// <br>Date       : 2016/06/06</br>
        /// </remarks>
        public PMKHN01710U(Propose_Para_Main main)
        {
            SFMIT10201U obj = new SFMIT10201U();
            obj.FormClosed += new FormClosedEventHandler(OnFormClosed);
            obj.Show(main);
        }
        
        private void OnFormClosed(object sender, EventArgs e)
        {
            // �X���b�h�̃��b�Z�[�W���[�v�I���̌ďo
            ExitThread();
        }
    }
}
