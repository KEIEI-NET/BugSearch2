//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����Model
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

using Broadleaf.Application.Controller.Util;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �����ƌ��ʃR�[�h�̃y�A�N���X
    /// </summary>
    public class CountResultPair : Pair<int, int>
    {
        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="count">����</param>
        /// <param name="resultCode">���ʃR�[�h</param>
        public CountResultPair(int count, int resultCode) : base(count, resultCode) { }

        #endregion  // <Constructor/>

        /// <summary>
        /// �������擾���܂��B
        /// </summary>
        /// <value>����</value>
        public int Count
        {
            get { return First; }
        }

        /// <summary>
        /// ���ʃR�[�h���擾���܂��B
        /// </summary>
        /// <value>���ʃR�[�h</value>
        public int ResultCode
        {
            get { return Second; }
        }

        /// <summary>
        /// �G���[�����肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�G���[�ł���B<br/>
        /// <c>false</c>:�G���[�ł͂Ȃ��B
        /// </returns>
        public bool IsError()
        {
            return !ResultCode.Equals((int)Result.Code.Normal);
        }
    }
}
