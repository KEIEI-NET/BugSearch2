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
//#define _ENABLED_DETAIL_    // SCM�󒍖��׃f�[�^(�⍇���E����)�����݂̗L���t���O

using System;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// ���`�����[�g�p�����[�^�̃��b�p�[�N���X
    /// </summary>
    public sealed class SalesSlipWriterParameter
    {
        #region <���`�����[�g�p�����[�^>

        /// <summary>���`�����[�g�p�����[�^</summary>
        private readonly CustomSerializeArrayList _paraList;
        /// <summary>���`�����[�g�p�����[�^���擾���܂��B</summary>
        public CustomSerializeArrayList ParaList { get { return _paraList; } }

        #endregion // </���`�����[�g�p�����[�^>

        #region <����`�[����>

        /// <summary>����`�[���ڃ��X�g</summary>
        private IList<SalesSlipWriterItem> _salesSlipItemList;
        /// <summary>����`�[���ڃ��X�g���擾���܂��B</summary>
        public IList<SalesSlipWriterItem> SalesSlipItemList
        {
            get
            {
                if (_salesSlipItemList == null)
                {
                    _salesSlipItemList = CreateSalesSlipList();
                }
                return _salesSlipItemList;
            }
        }

        /// <summary>
        /// ����`�[���ڃ��X�g�𐶐����܂��B
        /// </summary>
        /// <returns>����`�[���ڃ��X�g</returns>
        private IList<SalesSlipWriterItem> CreateSalesSlipList()
        {
            IList<SalesSlipWriterItem> salesSlipList = new List<SalesSlipWriterItem>();
            {
                foreach (object item in ParaList)
                {
                    if (item is CustomSerializeArrayList)
                    {
                        salesSlipList.Add(new SalesSlipWriterItem((CustomSerializeArrayList)item));
                    }
                }
            }
            return salesSlipList;
        }

        #endregion // </����`�[����>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="paraList">���`�����[�g�p�����[�^</param>
        public SalesSlipWriterParameter(CustomSerializeArrayList paraList)
        {
            _paraList = paraList;
        }

        #endregion // </Constructor>

        #region <SCM I/O Writer�p�p�����[�^>

        /// <summary>
        /// SCM I/O Writer�p�̃p�����[�^�ɕϊ����܂��B
        /// </summary>
        /// <returns>SCM I/O Writer�p�̃p�����[�^</returns>
        public CustomSerializeArrayList ToSCMIOWriterParameter()
        {
            return ConvertSCMIOWriterParameter(this);
        }

        /// <summary>
        /// SCM I/O Writer�p�̃p�����[�^�ɕϊ����܂��B
        /// </summary>
        /// <param name="salesSlipWriterParameter">���`�����[�g�p�����[�^</param>
        /// <returns>SCM I/O Writer�p�̃p�����[�^</returns>
        private static CustomSerializeArrayList ConvertSCMIOWriterParameter(SalesSlipWriterParameter salesSlipWriterParameter)
        {
            CustomSerializeArrayList parameter = new CustomSerializeArrayList();
            {
                foreach (SalesSlipWriterItem salesSlipItem in salesSlipWriterParameter.SalesSlipItemList)
                {
                    if (salesSlipItem.SCMOrderData == null) continue;

                    CustomSerializeArrayList oneSCMOrderList = new CustomSerializeArrayList();
                    {
                        // SCM�󒍃f�[�^
                        oneSCMOrderList.Add(salesSlipItem.SCMOrderData);

                        // SCM�󒍃f�[�^(�ԗ����)
                        oneSCMOrderList.Add(salesSlipItem.SCMOrderCarData);

                    #if _ENABLED_DETAIL_
                        // SCM�󒍖��׃f�[�^(�⍇���E����)
                        ArrayList detailRecordList = new ArrayList();
                        {
                            foreach (SCMAcOdrDtlIqWork detailData in salesSlipItem.SCMOrderDataDetailList)
                            {
                                detailRecordList.Add(detailData);
                            }
                        }
                        oneSCMOrderList.Add(detailRecordList);
                    #endif

                        // SCM�󒍖��׃f�[�^(��)
                        ArrayList answerRecordList = new ArrayList();
                        {
                            foreach (SCMAcOdrDtlAsWork answerData in salesSlipItem.ScmOrderDataAnswerList)
                            {
                                answerRecordList.Add(answerData);
                            }
                        }
                        oneSCMOrderList.Add(answerRecordList);
                    }   // CustomSerializeArrayList oneSCMOrderList = new CustomSerializeArrayList();
                    parameter.Add(oneSCMOrderList);
                }
            }
            return parameter;
        }

        #endregion // </SCM I/O Writer�p�p�����[�^>
    }
}
