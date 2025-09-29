//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���ݒ�A�N�Z�X
// �v���O�����T�v   : DB�A�N�Z�X�̃A�N�Z�X���ʂ�ێ����܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// DB�A�N�Z�X�N���X�̑㗝�l�N���X
    /// </summary>
    /// <typeparam name="TDBAccess">DB�̃A�N�Z�X�N���X�̌^</typeparam>
    /// <typeparam name="TDBRecord">DB�̃��R�[�h�N���X�̌^</typeparam>
    /// <typeparam name="TDataSet">DB�̃f�[�^�Z�b�g�̌^</typeparam>
    public abstract class DBAccessAgent<
        TDBAccess,
        TDBRecord,
        TDataSet
    > : IDisposable   
        where TDBAccess : class, new()
        where TDBRecord : class, new()
        where TDataSet  : DataSet, new()
    {
        #region <IDisposable Member/>

        /// <summary>�����ς݃t���O</summary>
        private bool _disposed;
        /// <summary>
        /// �����ς݃t���O���擾���܂��B
        /// </summary>
        public bool Disposed { get { return _disposed; } }

        /// <summary>
        /// �������܂��B
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            _disposed = true;
        }

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="disposing">�}�l�[�W�I�u�W�F�N�g�̏����t���O</param>
        protected virtual void Dispose(bool disposing)
        {
            #region <Guard Phrase/>

            if (Disposed) return;

            #endregion  // <Guard Phrase/>

            // ���}�l�[�W�I�u�W�F�N�g
            if (disposing)
            {
                Reset();
            }
            // ���A���}�l�[�W�I�u�W�F�N�g
        }

        /// <summary>
        /// �f�X�g���N�^
        /// </summary>
        ~DBAccessAgent()
        {
            Dispose(false);
        }

        #endregion  // <IDisposable Member/>

        /// <summary>DB�̃A�N�Z�T</summary>
        private TDBAccess _realAccesser;
        /// <summary>
        /// DB�̃A�N�Z�T���擾���܂��B
        /// </summary>
        /// <value>DB�̃A�N�Z�T</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public TDBAccess RealAccesser
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_realAccesser == null)
                {
                    _realAccesser = new TDBAccess();
                }
                return _realAccesser;
            }
        }

        /// <summary>DB�̃��R�[�h���X�g</summary>
        private List<TDBRecord> _recordList;
        /// <summary>
        /// DB�̃��R�[�h���擾���܂��B
        /// </summary>
        /// <value>DB�̃��R�[�h���X�g</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public List<TDBRecord> RecordList
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_recordList == null)
                {
                    _recordList = new List<TDBRecord>();
                    Initialize();
                }
                return _recordList;
            }
        }

        /// <summary>DB�̃f�[�^�Z�b�g</summary>
        private TDataSet _db;
        /// <summary>
        /// DB�̃f�[�^�Z�b�g���擾���܂��B
        /// </summary>
        /// <value>DB�̃f�^�Z�b�g</value>
        /// <exception cref="ObjectDisposedException">�����ς݂ł��B</exception>
        public TDataSet DB
        {
            get
            {
                #region <Guard Phrase/>

                if (Disposed) throw new ObjectDisposedException("This instance is disposed.");

                #endregion  // <Guard Phrase/>

                if (_db == null)
                {
                    _db = new TDataSet();
                    if (_recordList == null)
                    {
                        _recordList = new List<TDBRecord>();
                        Initialize();
                    }
                }
                return _db;
            }
        }

        /// <summary>
        /// ���Z�b�g���܂��B
        /// </summary>
        public void Reset()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
            if (_recordList != null)
            {
                _recordList.Clear();
                _recordList = null;
            }
            _realAccesser = null;
        }

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        protected DBAccessAgent() { }

        /// <summary>
        /// ���������܂��B
        /// </summary>
        protected abstract void Initialize();
    }
}
