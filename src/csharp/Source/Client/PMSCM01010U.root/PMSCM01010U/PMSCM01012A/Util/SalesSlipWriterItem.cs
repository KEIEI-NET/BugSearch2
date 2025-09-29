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
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS�̗���
// �� �� ��  2011/08/10  �C�����e : �����񓚑Ή��ASCM�Z�b�g�}�X�^���M�ł��邽��
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�J�X�^���R���X�g���N�^��ǉ�����
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// ���`�����[�g�p�����[�^�̓`�[���ڂ̃��b�p�[�N���X
    /// </summary>
    public sealed class SalesSlipWriterItem
    {
        #region <����`�[���ڃ��X�g>

        /// <summary>����`�[���ڃ��X�g</summary>
        private readonly CustomSerializeArrayList _salesSlipItemList;
        /// <summary>����`�[���ڃ��X�g���擾���܂��B</summary>
        private CustomSerializeArrayList SalesSlipItemList { get { return _salesSlipItemList; } }

        #endregion // </����`�[���ڃ��X�g>

        #region <����f�[�^>

        /// <summary>����f�[�^</summary>
        private SalesSlipWork _salesSlip;
        /// <summary>����f�[�^���擾���܂��B</summary>
        private SalesSlipWork SalesSlip
        {
            get
            {
                if (_salesSlip == null)
                {
                    _salesSlip = ListUtil.FindFirstFrom<SalesSlipWork>(SalesSlipItemList);
                }
                return _salesSlip;
            }
        }

        #endregion // </����f�[�^>

        #region <SCM�󒍃f�[�^>

        /// <summary>SCM�󒍃f�[�^</summary>
        private SCMAcOdrDataWork _scmOrderData;
        /// <summary>SCM�󒍃f�[�^���擾���܂��B</summary>
        public SCMAcOdrDataWork SCMOrderData
        {
            get
            {
                if (_scmOrderData == null)
                {
                    _scmOrderData = ListUtil.FindFirstFrom<SCMAcOdrDataWork>(SalesSlipItemList);
                }
                return _scmOrderData;
            }
        }

        #endregion // </SCM�󒍃f�[�^>

        #region <SCM�󒍃f�[�^(�ԗ����)>

        /// <summary>SCM�󒍃f�[�^(�ԗ����)</summary>
        private SCMAcOdrDtCarWork _scmOrderCarData;
        /// <summary>SCM�󒍃f�[�^(�ԗ����)���擾���܂��B</summary>
        public SCMAcOdrDtCarWork SCMOrderCarData
        {
            get
            {
                if (_scmOrderCarData == null)
                {
                    _scmOrderCarData = ListUtil.FindFirstFrom<SCMAcOdrDtCarWork>(SalesSlipItemList);
                }
                return _scmOrderCarData;
            }
        }

        #endregion // </SCM�󒍃f�[�^(�ԗ����)>

        #region <SCM�󒍖��׃f�[�^(�⍇���E����)>

        /// <summary>SCM�󒍖��׃f�[�^(�⍇���E����)�̃��X�g</summary>
        private IList<SCMAcOdrDtlIqWork> _scmOrderDataDetailList;
        /// <summary>SCM�󒍖��׃f�[�^(�⍇���E����)�̃��X�g���擾���܂��B</summary>
        public IList<SCMAcOdrDtlIqWork> SCMOrderDataDetailList
        {
            get
            {
                if (_scmOrderDataDetailList == null)
                {
                    _scmOrderDataDetailList = GetChildList<SCMAcOdrDtlIqWork>(SalesSlipItemList);
                }
                return _scmOrderDataDetailList;
            }
        }

        #endregion // </SCM�󒍖��׃f�[�^(�⍇���E����)>

        #region <SCM�󒍖��׃f�[�^(��)>

        /// <summary>SCM�󒍖��׃f�[�^(��)�̃��X�g</summary>
        private IList<SCMAcOdrDtlAsWork> _scmOrderDataAnswerList;
        /// <summary>SCM�󒍖��׃f�[�^(��)�̃��X�g���擾���܂��B</summary>
        public IList<SCMAcOdrDtlAsWork> ScmOrderDataAnswerList
        {
            get
            {
                if (_scmOrderDataAnswerList == null)
                {
                    _scmOrderDataAnswerList = GetChildList<SCMAcOdrDtlAsWork>(SalesSlipItemList);
                }
                return _scmOrderDataAnswerList;
            }
        }

        #endregion // </SCM�󒍖��׃f�[�^(��)>

        // -- ADD 2011/08/10   ------ >>>>>>
        #region <SCM�Z�b�g���i�f�[�^>

        /// <summary>
        /// SCM�Z�b�g���i�f�[�^�̃��X�g
        /// </summary>
        private IList<SCMAcOdSetDtWork> _scmOrderDataSetDtList;

        /// <summary>
        /// SCM�Z�b�g���i�f�[�^�̃��X�g���擾���܂��B
        /// </summary>
        public IList<SCMAcOdSetDtWork> ScmOrderDataSetDtList
        {
            get
            {
                if (_scmOrderDataSetDtList == null)
                {
                    _scmOrderDataSetDtList = GetChildList<SCMAcOdSetDtWork>(SalesSlipItemList);
                }
                return _scmOrderDataSetDtList;
            }
        }

        #endregion // </SCM�Z�b�g���i�f�[�^>
        // -- ADD 2011/08/10   ------ <<<<<<
        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="slipItemList">�`�[���ڃ��X�g</param>
        public SalesSlipWriterItem(CustomSerializeArrayList slipItemList)
        {
            _salesSlipItemList = slipItemList;
        }

        #endregion // </Constructor>

        /// <summary>
        /// ���׌n�T�u�f�[�^���X�g���擾���܂��B
        /// </summary>
        /// <typeparam name="T">���׌n�T�u�f�[�^�̌^</typeparam>
        /// <param name="parentList">�e���X�g</param>
        /// <returns>���׌n�T�u�f�[�^���X�g</returns>
        private static IList<T> GetChildList<T>(ArrayList parentList) where T : class
        {
            IList<T> foundList = null;
            {
                foreach (object item in parentList)
                {
                    if (item is ArrayList)
                    {
                        if (ListUtil.IsNullOrEmpty((ArrayList)item)) continue;

                        if (((ArrayList)item)[0] is T)
                        {
                            foundList = ListUtil.FindFrom<T>((ArrayList)item);
                            break;
                        }
                    }
                }
            }
            return foundList ?? new List<T>();
        }
    }
}
