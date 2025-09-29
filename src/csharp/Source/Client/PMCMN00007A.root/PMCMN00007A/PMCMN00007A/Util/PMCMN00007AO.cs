//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �}�X�^�����e�i���X
// �v���O�����T�v   : �}�X�^�����e�i���X�̐���S�ʂ��s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �C �� ��  2008/09/02  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// �V���O���g��������N���X
    /// </summary>
    /// <typeparam name="T">�V���O���g���Ƃ���N���X</typeparam>
    public sealed class SingletonPolicy<T> where T : class, new()
    {
        #region <Singleton Idiom/>

        /// <summary>�����I�u�W�F�N�g</summary>
        private static readonly object _syncRoot = new object();

        /// <summary>�V���O���g���C���X�^���X</summary>
        private static SingletonPolicy<T> _instance;
        /// <summary>
        /// �V���O���g���C���X�^���X���擾���܂��B
        /// </summary>
        /// <value>�V���O���g���C���X�^���X</value>
        public static SingletonPolicy<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonPolicy<T>();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        private SingletonPolicy()
        {
            _policy = new T();
        }

        #endregion  // <Singleton Idiom/>

        /// <summary>�V���O���g���Ƃ���C���X�^���X</summary>
        private readonly T _policy;
        /// <summary>
        /// �V���O���g���Ƃ���C���X�^���X���擾���܂��B
        /// </summary>
        /// <value>�V���O���g���Ƃ���C���X�^���X</value>
        public T Policy
        {
            get { return _policy; }
        }
    }

    /// <summary>
    /// �~���̔�r�҃N���X
    /// </summary>
    /// <typeparam name="T">�ΏۃI�u�W�F�N�g�̌^</typeparam>
    public class ReverseComparer<T> : IComparer<T> where T : IComparable<T>
    {
        #region <IComparer<T> �����o/>

        /// <summary>
        /// ��r���܂��B
        /// </summary>
        /// <param name="x">����</param>
        /// <param name="y">�E��</param>
        /// <returns><c>x.ComapreTo(y) * (-1)</c></returns>
        public int Compare(T x, T y)
        {
            return x.CompareTo(y) * (-1);
        }

        #endregion  // <IComparer<T> �����o/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public ReverseComparer() { }

        #endregion  // <Constructor/>
    }
}
