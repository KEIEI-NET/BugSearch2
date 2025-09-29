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
// �� �� ��  2009/07/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/04/05  �C�����e : �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬����
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// ���X�g���[�e�B���e�B
    /// </summary>
    public static class ListUtil
    {
        /// <summary>
        /// <c>null</c>�܂��͋�ł��邩���f���܂��B
        /// </summary>
        /// <typeparam name="T">���ڂ̌^</typeparam>
        /// <param name="list">���X�g</param>
        /// <returns>
        /// <c>true</c> :<c>null</c>�܂��͋�ł��B<br/>
        /// <c>false</c>:���ڂ������܂��B
        /// </returns>
        public static bool IsNullOrEmpty<T>(ICollection<T> list)
        {
            return list == null || list.Count.Equals(0);
        }

        /// <summary>
        /// <c>null</c>�܂��͋�ł��邩���f���܂��B
        /// </summary>
        /// <remarks>
        /// <c>ICollection</c>�̃X�y�V�����o�[�W����
        /// </remarks>
        /// <param name="collection">���X�g</param>
        /// <returns>
        /// <c>true</c> :<c>null</c>�܂��͋�ł��B<br/>
        /// <c>false</c>:���ڂ������܂��B
        /// </returns>
        public static bool IsNullOrEmpty(ICollection collection)
        {
            return collection == null || collection.Count.Equals(0);
        }

        // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ---------->>>>>
        /// <summary>
        /// <c>null</c>�܂��͋�ł��邩���f���܂��B
        /// </summary>
        /// <remarks>
        /// <c>List&lt;T&gt;</c>�̃X�y�V�����o�[�W����
        /// </remarks>
        /// <param name="list">���X�g</param>
        /// <returns>
        /// <c>true</c> :<c>null</c>�܂��͋�ł��B<br/>
        /// <c>false</c>:���ڂ������܂��B
        /// </returns>
        public static bool IsNullOrEmpty<T>(List<T> list)
        {
            return list == null || list.Count.Equals(0);
        }
        // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ----------<<<<<

        /// <summary>
        /// �R���N�V�����������̃N���X���������܂��B
        /// </summary>
        /// <typeparam name="T">��������N���X�̌^</typeparam>
        /// <param name="collection">�R���N�V����</param>
        /// <returns>�ŏ��Ɍ������ꂽ�N���X ���Y���N���X�����݂��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        public static T FindFirstFrom<T>(ICollection collection) where T : class
        {
            foreach (object item in collection)
            {
                if (item is T) return (T)item;
            }
            return null;
        }

        /// <summary>
        /// �R���N�V�����������̃N���X���������܂��B
        /// </summary>
        /// <typeparam name="T">��������N���X�̌^</typeparam>
        /// <param name="collection">�R���N�V����</param>
        /// <returns>�������ꂽ�N���X�̃��X�g</returns>
        public static IList<T> FindFrom<T>(ICollection collection) where T : class
        {
            IList<T> foundList = new List<T>();
            {
                foreach (object item in collection)
                {
                    if (item is T) foundList.Add((T)item);
                }
            }
            return foundList;
        }
    }
}
