//**********************************************************************//
// �V�X�e��         �FPM.NS
// �v���O��������   �FPMTAB �����񓚏���(����) �e�[�u���A�N�Z�X�N���X
// �v���O�����T�v   �FPMTAB�풓�������p�����[�^�Ŏԗ��A���i�����������n�����
//                    �ԗ��A���i�����������ԗ��A���i�̌������s���A
//                    �擾��������SCM_DB�̌������ʊ֘A�̃e�[�u���ɏ�����
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01  �쐬�S�� : songg
// �� �� ��  2013/05/29   �쐬���e : PMTAB �����񓚏���(����)
//----------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// �V���O���g��������N���X
    /// </summary>
    /// <typeparam name="T">�V���O���g���Ƃ���N���X�̌^</typeparam>
    public class SingletonInstanceForTablet<T> where T : class, new()
    {
        #region <Singleton Idiom/>

        /// <summary>�����I�u�W�F�N�g</summary>
        private static readonly object _syncRoot = new object();

        /// <summary>�V���O���g���C���X�^���X</summary>
        private static SingletonInstanceForTablet<T> _singleton;
        /// <summary>
        /// �V���O���g���C���X�^���X���擾���܂��B
        /// </summary>
        /// <value>�V���O���g���C���X�^���X</value>
        public static SingletonInstanceForTablet<T> Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    lock (_syncRoot)
                    {
                        if (_singleton == null)
                        {
                            _singleton = new SingletonInstanceForTablet<T>();
                        }
                    }
                }
                return _singleton;
            }
        }

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        private SingletonInstanceForTablet()
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
