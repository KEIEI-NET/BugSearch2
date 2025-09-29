//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M������O
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.UIData.Exception
{
    /// <summary>
    /// �����d����M������O�N���X
    /// </summary>
    public class OroshishoStockReceptionException : ApplicationException
    {
        #region <��������/>

        /// <summary>��������</summary>
        private readonly int _status;
        /// <summary>
        /// �������ʂ��擾���܂��B
        /// </summary>
        /// <value>��������</value>
        public int Status { get { return _status; } }

        #endregion  // <��������/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">��������</param>
        public OroshishoStockReceptionException(
            string message, 
            int status
        ) : base(message)
        {
            _status = status;
        }

        #endregion  // <Constructor/>
    }
}
