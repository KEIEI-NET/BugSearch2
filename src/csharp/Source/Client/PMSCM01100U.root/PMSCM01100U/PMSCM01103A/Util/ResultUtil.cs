//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// ���ʃ��[�e�B���e�B
    /// </summary>
    public static class ResultUtil
    {
        /// <summary>
        /// ���ʃR�[�h�񋓌^
        /// </summary>
        public enum ResultCode : int
        {
            /// <summary>����</summary>
            Normal = 0,
            /// <summary>����0</summary>
            NotFound = 4,
            /// <summary>���f</summary>
            Abort = 99,
            /// <summary>DB�G���[</summary>
            DBError = 1000,
            /// <summary>�G���[</summary>
            Error = -1
        }
    }
}
