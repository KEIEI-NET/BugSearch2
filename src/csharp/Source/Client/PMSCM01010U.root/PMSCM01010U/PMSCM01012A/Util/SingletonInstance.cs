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
// �� �� ��  2009/06/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// �V���O���g��������N���X
    /// </summary>
    /// <typeparam name="T">�V���O���g���Ƃ���N���X�̌^</typeparam>
    public class SingletonInstance<T> where T : class, new()
    {
        #region <Singleton Idiom/>

        /// <summary>�����I�u�W�F�N�g</summary>
        private static readonly object _syncRoot = new object();

        /// <summary>�V���O���g���C���X�^���X</summary>
        private static SingletonInstance<T> _singleton;
        /// <summary>
        /// �V���O���g���C���X�^���X���擾���܂��B
        /// </summary>
        /// <value>�V���O���g���C���X�^���X</value>
        public static SingletonInstance<T> Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    lock (_syncRoot)
                    {
                        if (_singleton == null)
                        {
                            _singleton = new SingletonInstance<T>();
                        }
                    }
                }
                return _singleton;
            }
        }

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        private SingletonInstance()
        {
            _instance = new T();
        }

        #endregion  // <Singleton Idiom/>

        /// <summary>�V���O���g���Ƃ���C���X�^���X</summary>
        private readonly T _instance;
        /// <summary>
        /// �V���O���g���Ƃ���C���X�^���X���擾���܂��B
        /// </summary>
        /// <value>�V���O���g���Ƃ���C���X�^���X</value>
        public T Instance { get { return _instance; } }
    }
}
