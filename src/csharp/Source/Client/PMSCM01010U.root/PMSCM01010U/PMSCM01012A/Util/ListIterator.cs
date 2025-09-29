//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/06/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// IList&lt;T&gt;�̔����q�N���X
    /// </summary>
    public class ListIterator<T> : IIterator<T> where T : class
    {
        #region <IIterator<T> �����o>

        /// <summary>
        /// ���̔����q���擾���܂��B
        /// </summary>
        /// <returns>���̔����q</returns>
        public T GetNext()
        {
            return Agreegate[_nextIndex++];
        }

        /// <summary>
        /// ���̔����q�����邩���肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :����<br/>
        /// <c>false</c>:�Ȃ�
        /// </returns>
        public bool HasNext()
        {
            return _nextIndex < Agreegate.Count;
        }

        #endregion // </IIterator<T> �����o>

        #region <�W����>

        /// <summary>�W����</summary>
        private readonly IList<T> _agreegate;
        /// <summary>�W���̂��擾���܂��B</summary>
        private IList<T> Agreegate { get { return _agreegate; } }

        /// <summary>���̃C���f�b�N�X</summary>
        private int _nextIndex;

        #endregion // </�W����>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="agreegate">�W����</param>
        public ListIterator(IList<T> agreegate)
        {
            _agreegate = agreegate;
        }

        #endregion // </Constructor>
    }
}
