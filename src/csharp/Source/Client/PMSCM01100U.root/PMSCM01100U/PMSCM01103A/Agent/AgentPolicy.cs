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
// �� �� ��  2009/05/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller.Agent
{
    /// <summary>
    /// �㗝�l�|���V�[�N���X
    /// </summary>
    /// <typeparam name="TRealAccesser">�{���̃A�N�Z�T�̌^</typeparam>
    /// <typeparam name="TRecord">���R�[�h�̌^</typeparam>
    public abstract class AgentPolicy<TRealAccesser, TRecord> where TRealAccesser : new()
    {
        #region <�{���̃A�N�Z�T>

        /// <summary>�{���̃A�N�Z�T</summary>
        private TRealAccesser _realAccesser;
        /// <summary>�{���̃A�N�Z�T���擾���܂��B</summary>
        public TRealAccesser RealAccesser
        {
            get
            {
                if (_realAccesser == null)
                {
                    _realAccesser = new TRealAccesser();
                }
                return _realAccesser;
            }
        }

        #endregion // </�{���̃A�N�Z�T>

        #region <�L���b�V��>

        /// <summary>�����ς݃��R�[�h�̃}�b�v</summary>
        private IDictionary<string, TRecord> _foundRecordMap;
        /// <summary>�����ς݃��R�[�h�̃}�b�v���擾���܂��B</summary>
        protected IDictionary<string, TRecord> FoundRecordMap
        {
            get
            {
                if (_foundRecordMap == null)
                {
                    _foundRecordMap = new Dictionary<string, TRecord>();
                }
                return _foundRecordMap;
            }
        }

        #endregion // </�L���b�V��>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        protected AgentPolicy() { }

        #endregion // </Constructor>
    }
}
