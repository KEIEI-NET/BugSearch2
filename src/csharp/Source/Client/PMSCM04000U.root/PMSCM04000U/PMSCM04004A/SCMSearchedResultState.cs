//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �⍇���ꗗ/�󒍌����E�B���h�E
// �v���O�����T�v   : �⍇���ꗗ�A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �� �� ��  2010/04/16  �C�����e : �L�����Z���Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    using SearchedResultPair = KeyValuePair<List<SCMInquiryDtlInqResultWork>, List<SCMInquiryDtlAnsResultWork>>;

    /// <summary>
    /// SCM�󒍃f�[�^�̌������ʂ̏�ԃN���X
    /// </summary>
    public abstract class SCMSearchedResultState
    {
        #region ��������

        /// <summary>�⍇���ԍ�</summary>
        private readonly long _inquiryNumber;
        /// <summary>�⍇���ԍ����擾���܂��B</summary>
        protected long InquiryNumber { get { return _inquiryNumber; } }

        /// <summary>�񓚋敪</summary>
        private readonly int _answerDivCode;
        /// <summary>�񓚋敪���擾���܂��B</summary>
        protected int AnswerDivCode { get { return _answerDivCode; } }

        #endregion // ��������

        #region ��������

        /// <summary>���׃f�[�^�̌�������</summary>
        private readonly CustomSerializeArrayList _searchedDetailList;
        /// <summary>���׃f�[�^�̌������ʂ��擾���܂��B</summary>
        protected CustomSerializeArrayList SearchedDetailList { get { return _searchedDetailList; } } 

        /// <summary>�L�����Z�����׃f�[�^�̌�������</summary>
        private readonly CustomSerializeArrayList _searchedCancelList;
        /// <summary>�L�����Z�����׃f�[�^�̌������ʂ��擾���܂��B</summary>
        protected CustomSerializeArrayList SearchedCancelList { get { return _searchedCancelList; } }

        #endregion // ��������

        #region Constructor

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="inquiryNumber">�⍇���ԍ�</param>
        /// <param name="answerDivCd">�񓚋敪</param>
        /// <param name="searchedDetailList">���׃f�[�^�̌�������</param>
        /// <param name="searchedCancelList">�L�����Z�����׃f�[�^�̌�������</param>
        protected SCMSearchedResultState(
            long inquiryNumber,
            int answerDivCd,
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
        {
            _inquiryNumber = inquiryNumber;
            _answerDivCode = answerDivCd;
            _searchedDetailList = searchedDetailList;
            _searchedCancelList = searchedCancelList;
        }

        #endregion // Constructor

        /// <summary>
        /// ����`�[���͂��\�ł��邩���f���܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :����`�[���͂��\�ł��B<br/>
        /// <c>false</c>:����`�[���͂��t���ł��B
        /// </returns>
        public abstract bool CanInputSalesSlip();

        /// <summary>
        /// �񓚋敪���u�񓚊����v�ł��邩���f���܂��B
        /// </summary>
        /// <param name="answerDivCd">�񓚋敪</param>
        /// <returns>
        /// <c>true</c> :�u�񓚊����v�ł��B<br/>
        /// <c>false</c>:�u�񓚊����v�ł͂���܂���B
        /// </returns>
        public static bool IsAnswerCompletion(int answerDivCd)
        {
            return answerDivCd.Equals((int)AnswerDivCd.AnswerCompletion);
        }

        /// <summary>
        /// �񓚋敪���u�L�����Z���v�ł��邩���f���܂��B
        /// </summary>
        /// <param name="answerDivCd">�񓚋敪</param>
        /// <returns>
        /// <c>true</c> :�u�L�����Z���v�ł��B<br/>
        /// <c>false</c>:�u�L�����Z���v�ł͂���܂���B
        /// </returns>
        public static bool IsCancel(int answerDivCd)
        {
            return answerDivCd.Equals((int)AnswerDivCd.Cancel);
        }

        /// <summary>
        /// �⍇���B������ʂ��u�����v�ł��邩���f���܂��B
        /// </summary>
        /// <param name="inqOrdDivCd">�⍇���E�������</param>
        /// <returns>
        /// <c>true</c> :�u�����v�ł��B<br/>
        /// <c>false</c>:�u�����v�ł͂���܂���B
        /// </returns>
        protected static bool IsOrdering(int inqOrdDivCd)
        {
            return inqOrdDivCd.Equals((int)InqOrdDivCd.Ordering);
        }

        /// <summary>
        /// ���׃f�[�^�����݂��邩���f���܂��B
        /// </summary>
        /// <param name="searchedResultList">���׃f�[�^(�L�����Z�����׃f�[�^)�̌�������</param>
        /// <returns>
        /// <c>true</c> :���׃f�[�^�����݂��܂��B<br/>
        /// <c>false</c>:���׃f�[�^�����݂��܂���B
        /// </returns>
        protected static bool ExistsDetailData(CustomSerializeArrayList searchedResultList)
        {
            // searchedDetailList:CustomSerializeArrayList
            // ��[0]:CustomSerializeArrayList<SCMInquiryDtlInqResultWork>�c���׃f�[�^�i�⍇���E�����j
            // ��[1]:CustomSerializeArrayList<SCMInquiryDtlAnsResultWork>�c���׃f�[�^�i�񓚁j

            if (searchedResultList == null || searchedResultList.Count.Equals(0)) return false;

            return true;
        }

        /// <summary>
        /// �񓚃f�[�^�����݂��邩���f���܂��B
        /// </summary>
        /// <param name="searchedResultList">���׃f�[�^(�L�����Z�����׃f�[�^)�̌�������</param>
        /// <returns>
        /// <c>true</c> :�񓚃f�[�^�����݂��܂��B<br/>
        /// <c>false</c>:�񓚃f�[�^�����݂��܂���B
        /// </returns>
        protected static bool ExistsAnswerData(CustomSerializeArrayList searchedResultList)
        {
            // searchedDetailList:CustomSerializeArrayList
            // ��[0]:CustomSerializeArrayList<SCMInquiryDtlInqResultWork>�c���׃f�[�^�i�⍇���E�����j
            // ��[1]:CustomSerializeArrayList<SCMInquiryDtlAnsResultWork>�c���׃f�[�^�i�񓚁j

            if (searchedResultList == null || searchedResultList.Count < 2) return false;

            return true;
        }

        #region �Ή����邩�̔���

        /// <summary>
        /// �Ή����邩���肵�܂��B
        /// </summary>
        /// <param name="ans">�������ʂ̉񓚃f�[�^</param>
        /// <param name="inq">�������ʂ̖��׃f�[�^</param>
        /// <returns>
        /// �������[�g�̌������ʂ�O��Ƃ��Ă邽�߁A�⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ̔�r�݂̂ł��E
        /// <c>true</c> :�Ή����܂��B<br/>
        /// <c>false</c>:�Ή����܂���B
        /// </returns>
        internal static bool IsParenthood(
            SCMInquiryDtlAnsResultWork ans,
            SCMInquiryDtlInqResultWork inq
        )
        {
            // 2011/01/11 >>>
            //return ans.InqRowNumber.Equals(inq.InqRowNumber) && ans.InqRowNumDerivedNo.Equals(inq.InqRowNumDerivedNo);
            if (ans.InqRowNumber.Equals(inq.InqRowNumber) && ans.InqRowNumDerivedNo.Equals(inq.InqRowNumDerivedNo))
            {
                if (ans.UpdateDate > inq.UpdateDate)
                {
                    return true;
                }
                else if (ans.UpdateDate == inq.UpdateDate)
                {
                    return ( ans.UpdateTime > inq.UpdateTime );
                }
            }
            return false;
            // 2011/01/11 <<<
        }

        /// <summary>
        /// �Ή����邩���肵�܂��B
        /// </summary>
        /// <param name="inq">�������ʂ̖��׃f�[�^</param>
        /// <param name="ans">�������ʂ̉񓚃f�[�^</param>
        /// <returns>
        /// �������[�g�̌������ʂ�O��Ƃ��Ă邽�߁A�⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ̔�r�݂̂ł��E
        /// <c>true</c> :�Ή����܂��B<br/>
        /// <c>false</c>:�Ή����܂���B
        /// </returns>
        internal static bool IsParenthood(
            SCMInquiryDtlInqResultWork inq,
            SCMInquiryDtlAnsResultWork ans
        )
        {
            return IsParenthood(ans, inq);
        }

        /// <summary>
        /// �Ή����邩���肵�܂��B
        /// </summary>
        /// <param name="lhs">�������ʂ̖��׃f�[�^</param>
        /// <param name="rhs">�������ʂ̖��׃f�[�^</param>
        /// <returns>
        /// �������[�g�̌������ʂ�O��Ƃ��Ă邽�߁A�⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ̔�r�݂̂ł��E
        /// <c>true</c> :�Ή����܂��B<br/>
        /// <c>false</c>:�Ή����܂���B
        /// </returns>
        protected static bool IsParenthood(
            SCMInquiryDtlInqResultWork lhs,
            SCMInquiryDtlInqResultWork rhs
        )
        {
            return lhs.InqRowNumber.Equals(rhs.InqRowNumber) && lhs.InqRowNumDerivedNo.Equals(rhs.InqRowNumDerivedNo);
        }

        /// <summary>
        /// �Ή����邩���肵�܂��B
        /// </summary>
        /// <param name="lhs">�������ʂ̉񓚃f�[�^</param>
        /// <param name="rhs">�������ʂ̉񓚃f�[�^</param>
        /// <returns>
        /// �������[�g�̌������ʂ�O��Ƃ��Ă邽�߁A�⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ̔�r�݂̂ł��E
        /// <c>true</c> :�Ή����܂��B<br/>
        /// <c>false</c>:�Ή����܂���B
        /// </returns>
        protected static bool IsParenthood(
            SCMInquiryDtlAnsResultWork lhs,
            SCMInquiryDtlAnsResultWork rhs
        )
        {
            return lhs.InqRowNumber.Equals(rhs.InqRowNumber) && lhs.InqRowNumDerivedNo.Equals(rhs.InqRowNumDerivedNo);
        }

        #endregion // �Ή����邩�̔���

        /// <summary>
        /// ���׃f�[�^(�L�����Z�����׃f�[�^)�ɑ΂��ĉ񓚃f�[�^���S�đ��݂��邩���f���܂��B
        /// </summary>
        /// <param name="searchedResultList">���׃f�[�^(�L�����Z�����׃f�[�^)�̌�������</param>
        /// <returns>
        /// <c>true</c> :���׃f�[�^(�L�����Z�����׃f�[�^)�ɑ΂��ĉ񓚃f�[�^���S�đ��݂��܂��B<br/>
        /// <c>false</c>:���񓚂̖��׃f�[�^(�L�����Z�����׃f�[�^)�����݂��܂��B
        /// </returns>
        protected static bool ExistsAllAnswer(CustomSerializeArrayList searchedResultList)
        {
            #region Guard Phrase

            if (searchedResultList == null || searchedResultList.Count <= 1) return false;

            #endregion // Guard Phrase

            // searchedResultList:CustomSerializeArrayList
            // ��[0]:CustomSerializeArrayList<SCMInquiryDtlInqResultWork>�c���׃f�[�^�i�⍇���E�����j
            // ��[1]:CustomSerializeArrayList<SCMInquiryDtlAnsResultWork>�c���׃f�[�^�i�񓚁j
            CustomSerializeArrayList inqList = searchedResultList[0] as CustomSerializeArrayList;
            CustomSerializeArrayList ansList = searchedResultList[1] as CustomSerializeArrayList;

            if (inqList == null || inqList.Count.Equals(0)) return true;
            if (ansList == null || ansList.Count.Equals(0)) return false;

            int targetInqCount = 0;
            int foundAnsCount = 0;
            foreach (SCMInquiryDtlInqResultWork inq in inqList)
            {
                // �⍇���E�����敪���u�����v�̂��̂�Ώ�
                if (!IsOrdering(inq.InqOrdDivCd)) continue;

                targetInqCount++;

                foreach (SCMInquiryDtlAnsResultWork ans in ansList)
                {
                    // �⍇���E�����敪���u�����v�̂��̂�Ώ�
                    if (!IsOrdering(ans.InqOrdDivCd)) continue;

                    // �����̓����[�g�̌������ʂ�O��Ƃ��Ă��邽�߁A�⍇���ԍ����ƃR�[�h���͓���Ƃ݂Ȃ�
                    // ���⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ̔�r�̂�
                    if (IsParenthood(ans, inq))
                    {
                        foundAnsCount++;
                        break;
                    }
                }
            }
            return foundAnsCount.Equals(targetInqCount);
        }

        /// <summary>
        /// �������ʂ��疾�׃f�[�^�Ɖ񓚃f�[�^�𕪊����܂��B
        /// </summary>
        /// <param name="searchedResultList">��������</param>
        /// <returns>Key:���׃f�[�^��Value:�񓚃f�[�^</returns>
        internal static SearchedResultPair SplitSearchedResult(CustomSerializeArrayList searchedResultList)
        {
            List<SCMInquiryDtlInqResultWork> detailList = new List<SCMInquiryDtlInqResultWork>();
            List<SCMInquiryDtlAnsResultWork> answerList = new List<SCMInquiryDtlAnsResultWork>();
            {
                foreach (CustomSerializeArrayList resultList in searchedResultList)
                {
                    if (resultList == null || resultList.Count.Equals(0)) continue;

                    if (resultList[0] is SCMInquiryDtlInqResultWork)
                    {
                        foreach (SCMInquiryDtlInqResultWork inquiry in resultList)
                        {
                            detailList.Add(inquiry);
                        }
                    }
                    else
                    {
                        foreach (SCMInquiryDtlAnsResultWork answer in resultList)
                        {
                            answerList.Add(answer);
                        }
                    }
                }
            }
            return new SearchedResultPair(detailList, answerList);
        }

        #region ����(���l)

        /// <summary>
        /// ����(���l)���擾���܂��B
        /// </summary>
        /// <param name="inq">��������(���׃f�[�^)</param>
        /// <returns>�X�V���t(yyyyMMdd) + �X�V����(HHmmssxxx)</returns>
        protected static long GetUpdateDateAndTime(SCMInquiryDtlInqResultWork inq)
        {
            return long.Parse(inq.UpdateDate.ToString("yyyyMMdd") + inq.UpdateTime.ToString("d9"));
        }

        /// <summary>
        /// ����(���l)���擾���܂��B
        /// </summary>
        /// <param name="inq">��������(�񓚃f�[�^)</param>
        /// <returns>�X�V���t(yyyyMMdd) + �X�V����(HHmmssxxx)</returns>
        protected static long GetUpdateDateAndTime(SCMInquiryDtlAnsResultWork ans)
        {
            return long.Parse(ans.UpdateDate.ToString("yyyyMMdd") + ans.UpdateTime.ToString("d9"));
        }

        #endregion // ����(���l)
    }

    #region �u���񓚁v

    /// <summary>
    /// SCM�󒍃f�[�^�̌������ʂ́u���񓚁v��ԃN���X
    /// </summary>
    public sealed class SCMNoActionState : SCMSearchedResultState
    {
        #region Constructor

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="inquiryNumber">�⍇���ԍ�</param>
        /// <param name="answerDivCd">�񓚋敪</param>
        /// <param name="searchedDetailList">���׃f�[�^�̌�������</param>
        /// <param name="searchedCancelList">�L�����Z�����׃f�[�^�̌�������</param>
        public SCMNoActionState(
            long inquiryNumber,
            int answerDivCd,
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
            : base(inquiryNumber, answerDivCd, searchedDetailList, searchedCancelList) { }

        #endregion // Constructor

        /// <summary>
        /// ����`�[���͂��\�ł��邩���f���܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :����`�[���͂��\�ł��B<br/>
        /// <c>false</c>:����`�[���͂��t���ł��B
        /// </returns>
        /// <see cref="SCMSearchedResultState"/>
        public override bool CanInputSalesSlip()
        {
            // �񓚋敪���u�񓚊����v�c�񓚂���K�v���Ȃ�
            if (IsAnswerCompletion(AnswerDivCode)) return false;

            // �񓚋敪���u�L�����Z���v�c�ԕi����K�v���Ȃ��斢�񓚁i�񓚃f�[�^�����݂��Ȃ��j
            if (IsCancel(AnswerDivCode)) return false;

            // 2011/02/14 Add >>>
            if (!IsExistsNoAnswerData(SearchedDetailList)) return false;
            // 2011/02/14 Add <<<

            // �񓚋敪���u���񓚁v
            // ���׃f�[�^�ƃL�����Z�����׃f�[�^���r���A�S�ăL�����Z�����׃f�[�^�ɊY�������ꍇ�A
            // �񓚂���K�v���Ȃ��i���񓚂őS�L�����Z���͉񓚂̕K�v�Ȃ��j
            return !IsAllNotAnsweredCancel(SearchedDetailList, SearchedCancelList);
        }

        // 2011/02/14 Add >>>
        /// <summary>
        /// ���񓚃f�[�^�̑��݃`�F�b�N
        /// </summary>
        /// <param name="searchedDetailList"></param>
        /// <param name="searchedCancelList"></param>
        /// <returns>True:���񓚃f�[�^�����݂��܂�</returns>
        private static bool IsExistsNoAnswerData(CustomSerializeArrayList searchedDetailList)
        {
            // �񓚃f�[�^�����݂��炵�Ȃ��ꍇ��False
            if (( searchedDetailList != null ) && ( searchedDetailList.Count == 0 ))
            {
                return false;
            }
            CustomSerializeArrayList searchedDetailItemList = (CustomSerializeArrayList)searchedDetailList[0];

            CustomSerializeArrayList searchedAnswerItemList = ( searchedDetailList.Count > 1 ) ? (CustomSerializeArrayList)searchedDetailList[1] : new CustomSerializeArrayList();

            bool noAnswerExists = false;
            foreach (SCMInquiryDtlInqResultWork detail in searchedDetailItemList)
            {
                if (detail.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled) continue;

                bool existsAnswer = false;
                foreach (SCMInquiryDtlAnsResultWork answer in searchedAnswerItemList)
                {
                    // ���⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ̔�r�̂�
                    if (IsParenthood(detail, answer))
                    {
                        existsAnswer = true;
                        break;
                    }
                }
                if (!existsAnswer)
                {
                    noAnswerExists = true;
                }
            }

            return noAnswerExists;
        }
        // 2011/02/14 Add <<<

        /// <summary>
        /// ���񓚂̖��׃f�[�^���S�ăL�����Z������Ă��邩���f���܂��B�i�u���񓚁v�ł��邱�Ƃ��O��j
        /// </summary>
        /// <param name="searchedDetailList">���׃f�[�^�̌�������</param>
        /// <param name="searchedCancelList">�L�����Z�����׃f�[�^�̌�������</param>
        /// <returns>
        /// <c>true</c> :���񓚂̖��׃f�[�^���S�ăL�����Z������Ă��܂��B<br/>
        /// <c>false</c>:�񓚃f�[�^�����݂��܂��B�܂��͉񓚂̕K�v�Ȗ��׃f�[�^�����݂��܂��B
        /// </returns>
        private static bool IsAllNotAnsweredCancel(
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
        {
            // ���������L�����Z�����Ă��Ȃ�
            if (searchedCancelList == null || searchedCancelList.Count.Equals(0)) return false;

            // �񓚃f�[�^�̑���
            if (SCMSearchedResultState.ExistsAnswerData(searchedDetailList)) return false; // �񓚃f�[�^�����݂���
            if (SCMSearchedResultState.ExistsAnswerData(searchedCancelList)) return false; // �ԕi�f�[�^�����݂���(���񓚂ł͂Ȃ�)

            // ���׃f�[�^�ƃL�����Z�����׃f�[�^�̑Ή��֌W
            // searchedDetailList:CustomSerializeArrayList
            // ��[0]:CustomSerializeArrayList<SCMInquiryDtlInqResultWork>�c���׃f�[�^�i�⍇���E�����j
            // ��[1]:CustomSerializeArrayList<SCMInquiryDtlAnsResultWork>�c���׃f�[�^�i�񓚁j
            CustomSerializeArrayList searchedDetailItemList = (CustomSerializeArrayList)searchedDetailList[0];
            CustomSerializeArrayList searchedCancelItemList = (CustomSerializeArrayList)searchedCancelList[0];
            int foundCanceledDetailCount = 0;  // �L�����Z���ƂȂ������א�
            foreach (SCMInquiryDtlInqResultWork detail in searchedDetailItemList)
            {
                foreach (SCMInquiryDtlInqResultWork cancel in searchedCancelItemList)
                {
                    // �����̓����[�g�̌������ʂ�O��Ƃ��Ă��邽�߁A�⍇���ԍ����ƃR�[�h���͓���Ƃ݂Ȃ�
                    // ���⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ̔�r�̂�
                    if (IsParenthood(detail, cancel))
                    {
                        foundCanceledDetailCount++;
                        break;
                    }
                }
            }
            return foundCanceledDetailCount.Equals(searchedDetailItemList.Count);
        }

        /// <summary>
        /// �u���񓚁v��Ԃł��邩���f���܂��B
        /// </summary>
        /// <param name="searchedDetailList">���׃f�[�^�̌�������</param>
        /// <returns>
        /// <c>true</c> :�u���񓚁v��Ԃł��B<br/>
        /// <c>false</c>:�u���񓚁v��Ԃł͂���܂���B
        /// </returns>
        public static bool IsNoActionState(CustomSerializeArrayList searchedDetailList)
        {
            return !ExistsAnswerData(searchedDetailList);
        }
    }

    #endregion // �u���񓚁v

    #region �u�񓚊����v

    /// <summary>
    /// SCM�󒍃f�[�^�̌������ʂ́u�񓚊����v��ԃN���X
    /// </summary>
    public sealed class SCMAnswerCompletionState : SCMSearchedResultState
    {
        #region Constructor

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="inquiryNumber">�⍇���ԍ�</param>
        /// <param name="answerDivCd">�񓚋敪</param>
        /// <param name="searchedDetailList">���׃f�[�^�̌�������</param>
        /// <param name="searchedCancelList">�L�����Z�����׃f�[�^�̌�������</param>
        public SCMAnswerCompletionState(
            long inquiryNumber,
            int answerDivCd,
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
            : base(inquiryNumber, answerDivCd, searchedDetailList, searchedCancelList) { }

        #endregion // Constructor

        /// <summary>
        /// ����`�[���͂��\�ł��邩���f���܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :����`�[���͂��\�ł��B<br/>
        /// <c>false</c>:����`�[���͂��t���ł��B
        /// </returns>
        /// <see cref="SCMSearchedResultState"/>
        public override bool CanInputSalesSlip()
        {
            // �񓚋敪���u�񓚊����v�c�񓚂���K�v���Ȃ�
            if (IsAnswerCompletion(AnswerDivCode)) return false;

            // �񓚋敪���u�L�����Z���v�c�ԕi����K�v������
            // �S�ĕԕi�ς݂̏ꍇ�A�ԕi�̕K�v�Ȃ�
            return !IsAllReturnedGoods(SearchedDetailList, SearchedCancelList);
        }

        /// <summary>
        /// �񓚃f�[�^���S�ăL�����Z��(�ԕi)����Ă��邩���f���܂��B�i�u�񓚊����v�ł��邱�Ƃ��O��j
        /// </summary>
        /// <param name="searchedDetailList">���׃f�[�^�̌�������</param>
        /// <param name="searchedCancelList">�L�����Z�����׃f�[�^�̌�������</param>
        /// <returns>
        /// <c>true</c> :�񓚃f�[�^���S�ăL�����Z��(�ԕi)����Ă��܂��B<br/>
        /// <c>false</c>:�ԕi�f�[�^�����݂��܂���B�܂��͕ԕi�̕K�v�ȉ񓚃f�[�^�����݂��܂��B
        /// </returns>
        private static bool IsAllReturnedGoods(
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
        {
            // �ԕi�f�[�^�̑���
            if (!SCMSearchedResultState.ExistsAnswerData(searchedCancelList))
            {
                // �ԕi�f�[�^�����݂��Ȃ�
                // 2011/02/14 >>>
                //// �ߋ��ɃL�����Z�����ꂽ�f�[�^�ł��邩����
                //long cancelingDateTime = GetLatestDateTime(searchedCancelList); // ���߂̃L�����Z������

                //SearchedResultPair searchedDetailResult = SplitSearchedResult(searchedDetailList);
                //long answeringDateTime = GetLatsetAnswerDateTime(searchedDetailResult.Value);   // ���߂̉񓚓���

                //// �L�����Z������̉񓚂Łu�񓚊����v�ƂȂ��Ă���̂ŁA�ԕi�ςƂ݂Ȃ���
                //return answeringDateTime > cancelingDateTime;

                CustomSerializeArrayList cancelList = (CustomSerializeArrayList)searchedCancelList[0];

                bool existsNoAnswer=false;
                foreach (SCMInquiryDtlInqResultWork cancel in cancelList)
                {
                    if (( cancel.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelling ) ||
                        ( cancel.CancelCndtinDiv == (int)CancelCndtinDiv.None ))
                    {
                        existsNoAnswer = true;
                        break;
                    }
                }
                return !existsNoAnswer;
                // 2011/02/14 <<<
            }
            if (!SCMSearchedResultState.ExistsAnswerData(searchedDetailList)) return false; // �񓚃f�[�^�����݂��Ȃ�

            // 2011/02/14 >>>
            //// �񓚃f�[�^�ƃL�����Z����(�ԕi)�f�[�^�̑Ή��֌W
            //// searchedDetailList:CustomSerializeArrayList
            //// ��[0]:CustomSerializeArrayList<SCMInquiryDtlInqResultWork>�c���׃f�[�^�i�⍇���E�����j
            //// ��[1]:CustomSerializeArrayList<SCMInquiryDtlAnsResultWork>�c���׃f�[�^�i�񓚁j
            //CustomSerializeArrayList searchedDetailItemList = (CustomSerializeArrayList)searchedDetailList[1];
            //CustomSerializeArrayList searchedCancelItemList = (CustomSerializeArrayList)searchedCancelList[1];
            //int targetDetailCount = 0;          // �ΏۂƂ��閾�א�
            //int foundReturnedDetailCount = 0;   // �ԕi�ƂȂ������א�
            //foreach (SCMInquiryDtlAnsResultWork detail in searchedDetailItemList)
            //{
            //    // �⍇���E������ʂ��u�����v�̂��̂�Ώ�
            //    if (!detail.InqOrdDivCd.Equals((int)InqOrdDivCd.Ordering)) continue;

            //    targetDetailCount++;

            //    foreach (SCMInquiryDtlAnsResultWork cancel in searchedCancelItemList)
            //    {
            //        // �⍇���E������ʂ��u�����v�̂��̂�Ώ�
            //        if (!cancel.InqOrdDivCd.Equals((int)InqOrdDivCd.Ordering)) continue;

            //        // �����̓����[�g�̌������ʂ�O��Ƃ��Ă��邽�߁A�⍇���ԍ����ƃR�[�h���͓���Ƃ݂Ȃ�
            //        // ���⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ̔�r�̂�
            //        if (IsParenthood(detail, cancel))
            //        {
            //            foundReturnedDetailCount++;
            //            break;
            //        }
            //    }
            //}
            //return foundReturnedDetailCount.Equals(targetDetailCount);
            return !IsExistsNoAnswerData(searchedCancelList);
            // 2011/02/14 <<<
        }

        // 2011/02/14 Add >>>
        /// <summary>
        /// ���񓚃f�[�^�̑��݃`�F�b�N
        /// </summary>
        /// <param name="searchedDetailList"></param>
        /// <param name="searchedCancelList"></param>
        /// <returns>True:���񓚃f�[�^�����݂��܂�</returns>
        private static bool IsExistsNoAnswerData(CustomSerializeArrayList searchedDetailList)
        {
            // �񓚃f�[�^�����݂��炵�Ȃ��ꍇ��False
            if (( searchedDetailList != null ) && ( searchedDetailList.Count == 0 ))
            {
                return false;
            }
            CustomSerializeArrayList searchedDetailItemList = (CustomSerializeArrayList)searchedDetailList[0];

            CustomSerializeArrayList searchedAnswerItemList = ( searchedDetailList.Count > 1 ) ? (CustomSerializeArrayList)searchedDetailList[1] : new CustomSerializeArrayList();

            bool noAnswerExists = false;
            foreach (SCMInquiryDtlInqResultWork detail in searchedDetailItemList)
            {
                if (detail.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled) continue;

                bool existsAnswer = false;
                foreach (SCMInquiryDtlAnsResultWork answer in searchedAnswerItemList)
                {
                    // ���⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ̔�r�̂�
                    if (IsParenthood(detail, answer))
                    {
                        existsAnswer = true;
                        break;
                    }
                }
                if (!existsAnswer)
                {
                    noAnswerExists = true;
                }
            }

            return noAnswerExists;
        }
        // 2011/02/14 Add <<<

        // 2011/02/14 Del >>>
        ///// <summary>
        ///// �ŐV�̓���(���l)���擾���܂��B
        ///// </summary>
        ///// <param name="searchedResultList">��������</param>
        ///// <returns>
        ///// �������ʂ̖��׃f�[�^�Ɖ񓚃f�[�^�̒�����ŐV�̓���(���l:yyyyMMddHHmmssxxx)��Ԃ��܂��B
        ///// </returns>
        //private static long GetLatestDateTime(CustomSerializeArrayList searchedResultList)
        //{
        //    SearchedResultPair searchedResult = SplitSearchedResult(searchedResultList);

        //    long latestDateTime = 0;
        //    searchedResult.Key.ForEach(delegate(SCMInquiryDtlInqResultWork inq)
        //    {
        //        long inqDateTime = GetUpdateDateAndTime(inq);
        //        if (inqDateTime >= latestDateTime)
        //        {
        //            latestDateTime = inqDateTime;
        //        }
        //    });
        //    searchedResult.Value.ForEach(delegate(SCMInquiryDtlAnsResultWork ans)
        //    {
        //        long ansDateTime = GetUpdateDateAndTime(ans);
        //        if (ansDateTime >= latestDateTime)
        //        {
        //            latestDateTime = ansDateTime;
        //        }
        //    });
        //    return latestDateTime;
        //}
        // 2011/02/14 Del <<<

        /// <summary>
        /// ��������(�񓚃f�[�^)����ŐV�̓���(���l)���擾���܂��B
        /// </summary>
        /// <param name="answerList">��������(�񓚃f�[�^)</param>
        /// <returns>��������(�񓚃f�[�^)����ŐV�̓���(���l)</returns>
        private static long GetLatsetAnswerDateTime(List<SCMInquiryDtlAnsResultWork> answerList)
        {
            long latestDateTime = 0;
            answerList.ForEach(delegate(SCMInquiryDtlAnsResultWork ans)
            {
                long ansDateTime = GetUpdateDateAndTime(ans);
                if (ansDateTime >= latestDateTime)
                {
                    latestDateTime = ansDateTime;
                }
            });
            return latestDateTime;
        }

        /// <summary>
        /// �u�񓚊����v��Ԃł��邩���f���܂��B
        /// </summary>
        /// <param name="searchedDetailList">���׃f�[�^�̌�������</param>
        /// <returns>
        /// <c>true</c> :�u�񓚊����v��Ԃł��B<br/>
        /// <c>false</c>:�u�񓚊����v��Ԃł͂���܂���B
        /// </returns>
        public static bool IsAnswerCompletionState(CustomSerializeArrayList searchedDetailList)
        {
            return ExistsAllAnswer(searchedDetailList);
        }
    }

    #endregion // �u�񓚊����v

    #region �u�ꕔ�񓚁v

    /// <summary>
    /// SCM�󒍃f�[�^�̌������ʂ́u�ꕔ�񓚁v��ԃN���X
    /// </summary>
    public sealed class SCMPartAnswerState : SCMSearchedResultState
    {
        #region Constructor

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="inquiryNumber">�⍇���ԍ�</param>
        /// <param name="answerDivCd">�񓚋敪</param>
        /// <param name="searchedDetailList">���׃f�[�^�̌�������</param>
        /// <param name="searchedCancelList">�L�����Z�����׃f�[�^�̌�������</param>
        public SCMPartAnswerState(
            long inquiryNumber,
            int answerDivCd,
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        ) : base(inquiryNumber, answerDivCd, searchedDetailList, searchedCancelList) { }

        #endregion // Constructor

        /// <summary>
        /// ����`�[���͂��\�ł��邩���f���܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :����`�[���͂��\�ł��B<br/>
        /// <c>false</c>:����`�[���͂��t���ł��B
        /// </returns>
        /// <see cref="SCMSearchedResultState"/>
        public override bool CanInputSalesSlip()
        {
            // �񓚋敪���u�񓚊����v�c���`�ɖ߂�K�v�Ȃ�
            if (IsAnswerCompletion(AnswerDivCode)) return false;

            // �񓚋敪���u�L�����Z���v��I�����Ă���
            if (IsCancel(AnswerDivCode))
            {
                // �񓚃f�[�^�����݂��Ȃ���΁A���`�ɖ߂�K�v�Ȃ�
                // (�L�����Z�����ɑ΂��ĉ������Ȃ��Ă悢�j
                if (!ExistsAnswerData(SearchedDetailList)) return false;
                
                // �L�����Z�����̉񓚃f�[�^���S�đ��݂���΁A���`�ɖ߂�K�v�Ȃ�
                // (�S�ĕԕi���Ă��邽�߁A�L�����Z�����ɑ΂��ĉ������Ȃ��Ă悢�j
                if (ExistsAllAnswer(SearchedCancelList)) return false;

                // �ԕi���K�v�ȃL�����Z�����׃f�[�^���擾
                List<SCMInquiryDtlInqResultWork> cancelingDataList = FindCancelingData(
                    SearchedDetailList,
                    SearchedCancelList
                );

                // �ԕi���K�v�ȃL�����Z�����׃f�[�^������΁A���`�ɖ߂�
                return cancelingDataList.Count > 0;
            }

            // �񓚋敪���u�ꕔ�񓚁v��I�����Ă���

            if (!IsExistsNoAnswerData(SearchedDetailList, SearchedCancelList)) return false; // 2011/02/14 Add

            // �L�����Z���f�[�^�����݂��Ȃ���΁A���`�ɖ߂�
            if (!ExistsDetailData(SearchedCancelList)) return true;

            // �񓚂��K�v�Ȗ��׃f�[�^���擾
            List<SCMInquiryDtlInqResultWork> answeringDataList = FindAnsweringData(
                SearchedDetailList,
                SearchedCancelList
            );

            // �񓚂��K�v�Ȗ��׃f�[�^������ꍇ�A���`�ɖ߂�
            return answeringDataList.Count > 0;
        }

        // 2011/02/14 Add >>>
        /// <summary>
        /// ���񓚃f�[�^�̑��݃`�F�b�N
        /// </summary>
        /// <param name="searchedDetailList"></param>
        /// <param name="searchedCancelList"></param>
        /// <returns>True:���񓚃f�[�^�����݂��܂�</returns>
        private static bool IsExistsNoAnswerData(CustomSerializeArrayList searchedDetailList, CustomSerializeArrayList searchedCancelList)
        {
            // �񓚃f�[�^�����݂��炵�Ȃ��ꍇ��False
            if (( searchedDetailList != null ) && ( searchedDetailList.Count == 0 ))
            {
                return false;
            }
            CustomSerializeArrayList searchedDetailItemList = (CustomSerializeArrayList)searchedDetailList[0];

            CustomSerializeArrayList searchedAnswerItemList = ( searchedDetailList.Count > 1 ) ? (CustomSerializeArrayList)searchedDetailList[1] : new CustomSerializeArrayList();

            bool noAnswerExists = false;
            foreach (SCMInquiryDtlInqResultWork detail in searchedDetailItemList)
            {
                if (detail.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled) continue;

                bool existsAnswer = false;
                foreach (SCMInquiryDtlAnsResultWork answer in searchedAnswerItemList)
                {
                    // ���⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ̔�r�̂�
                    if (IsParenthood(detail, answer))
                    {
                        existsAnswer = true;
                        break;
                    }
                }
                if (!existsAnswer)
                {
                    noAnswerExists = true;
                }
            }

            return noAnswerExists;
        }
        // 2011/02/14 Add <<<

        /// <summary>
        /// �񓚂��K�v�ȃL�����Z�����׃f�[�^���擾���܂��B
        /// </summary>
        /// <param name="searchedDetailList">���׃f�[�^�̌�������</param>
        /// <param name="searchedCancelList">�L�����Z�����׃f�[�^�̌�������</param>
        /// <returns>
        /// �񓚍ς݂ł͂Ȃ����׃f�[�^�ƃL�����Z�����׃f�[�^�̌������ʂ��r���A�Y�����Ȃ����̂�Ԃ��܂��B
        /// </returns>
        private static List<SCMInquiryDtlInqResultWork> FindAnsweringData(
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
        {
            List<SCMInquiryDtlInqResultWork> foundList = new List<SCMInquiryDtlInqResultWork>();
            {
                List<SCMInquiryDtlInqResultWork> notAnsweringDataList = FindNotAnsweredInqData(searchedDetailList);
                {
                    notAnsweringDataList.ForEach(delegate(SCMInquiryDtlInqResultWork notAnsweringData)
                    {
                        bool found = false;
                        CustomSerializeArrayList cancelList = (CustomSerializeArrayList)searchedCancelList[0];
                        foreach (SCMInquiryDtlInqResultWork cancelData in cancelList)
                        {
                            // �����[�g�̌������ʂł��邱�Ƃ�O��Ƃ��Ă��邽�߁A�⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ݂̂��r
                            if (
                                cancelData.InqRowNumber.Equals(notAnsweringData.InqRowNumber)
                                    &&
                                cancelData.InqRowNumDerivedNo.Equals(notAnsweringData.InqRowNumDerivedNo)
                            )
                            {
                                // �⍇���E������ʂ��u�����v�̂��̂�Ώ�
                                if (IsOrdering(cancelData.InqOrdDivCd))
                                {
                                    found = true;
                                    break;
                                }
                            }
                        }
                        if (!found) foundList.Add(notAnsweringData);
                    });
                }
            }
            return foundList;
        }

        /// <summary>
        /// �ԕi���K�v�ȃL�����Z�����׃f�[�^���擾���܂��B
        /// </summary>
        /// <param name="searchedDetailList">���׃f�[�^�̌�������</param>
        /// <param name="searchedCancelList">�L�����Z�����׃f�[�^�̌�������</param>
        /// <returns>
        /// �ԕi�ς݂ł͂Ȃ��L�����Z�����׃f�[�^�Ɖ񓚃f�[�^�̌������ʂ��r���A�Y��������̂�Ԃ��܂��B
        /// </returns>
        private static List<SCMInquiryDtlInqResultWork> FindCancelingData(
            CustomSerializeArrayList searchedDetailList,
            CustomSerializeArrayList searchedCancelList
        )
        {
            List<SCMInquiryDtlInqResultWork> foundList = new List<SCMInquiryDtlInqResultWork>();
            {
                List<SCMInquiryDtlInqResultWork> notReturningDataList = FindNotAnsweredInqData(searchedCancelList);
                {
                    notReturningDataList.ForEach(delegate(SCMInquiryDtlInqResultWork notReturningData)
                    {
                        bool found = false;
                        CustomSerializeArrayList searchedAnswerList = (CustomSerializeArrayList)searchedDetailList[1];
                        foreach (SCMInquiryDtlAnsResultWork answerData in searchedAnswerList)
                        {
                            // �����[�g�̌������ʂł��邱�Ƃ�O��Ƃ��Ă��邽�߁A�⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ݂̂��r
                            if (
                                answerData.InqRowNumber.Equals(notReturningData.InqRowNumber)
                                    &&
                                answerData.InqRowNumDerivedNo.Equals(notReturningData.InqRowNumDerivedNo)
                            )
                            {
                                found = true;
                                break;
                            }
                        }
                        if (found) foundList.Add(notReturningData);
                    });
                }
            }
            return foundList;
        }

        /// <summary>
        /// �񓚍ς݂ł͂Ȃ����׃f�[�^���擾���܂��B
        /// </summary>
        /// <param name="searchedDetailList">���׃f�[�^�̌�������</param>
        /// <returns>
        /// ���׃f�[�^�̌������ʂ̉񓚃f�[�^�ɑ��݂��Ȃ����׃f�[�^�̃��X�g��Ԃ��܂��B
        /// </returns>
        private static List<SCMInquiryDtlInqResultWork> FindNotAnsweredInqData(CustomSerializeArrayList searchedDetailList)
        {
            List<SCMInquiryDtlInqResultWork> foundList = new List<SCMInquiryDtlInqResultWork>();
            {
                foreach (SCMInquiryDtlInqResultWork detailData in (CustomSerializeArrayList)searchedDetailList[0])
                {
                    // �⍇���E������ʂ��u�����v�̂��̂�Ώ�
                    if (!IsOrdering(detailData.InqOrdDivCd)) continue;

                    if (searchedDetailList.Count <= 1)
                    {
                        // �񓚃f�[�^�����݂��Ȃ�
                        foundList.Add(detailData);
                        continue;
                    }

                    bool founds = false;
                    CustomSerializeArrayList searchedAnswerList = (CustomSerializeArrayList)searchedDetailList[1];
                    foreach (SCMInquiryDtlAnsResultWork answerData in searchedAnswerList)
                    {
                        // �����[�g�̌������ʂł��邱�Ƃ�O��Ƃ��Ă��邽�߁A�⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ݂̂��r
                        if (
                            answerData.InqRowNumber.Equals(detailData.InqRowNumber)
                                &&
                            answerData.InqRowNumDerivedNo.Equals(detailData.InqRowNumDerivedNo)
                        )
                        {
                            founds = true;
                            break;
                        }
                    }   // foreach (SCMInquiryDtlAnsResultWork answerData in (CustomSerializeArrayList)searchedCancelList[1])
                    if (!founds) foundList.Add(detailData);
                }   // foreach (SCMInquiryDtlInqResultWork cancelData in (CustomSerializeArrayList)searchedCancelList[0])
            }
            return foundList;
        }
    }

    #endregion // �u�ꕔ�񓚁v

    #region �t�@�N�g���N���X

    /// <summary>
    /// SCM�󒍃f�[�^�̌������ʂ̏�Ԃ̃t�@�N�g���N���X
    /// </summary>
    public static class SCMSearchedResultStateFactory
    {
        /// <summary>
        /// SCM�󒍃f�[�^�̌������ʂ̏�Ԃ𐶐����܂��B
        /// </summary>
        /// <param name="inquiryNumber">�⍇���ԍ�</param>
        /// <param name="answerDivCd">�񓚋敪</param>
        /// <param name="searchingHeader">��������</param>
        /// <param name="searchedDerailData">���׃f�[�^�̌�������</param>
        /// <param name="searchedCancelData">�L�����Z�����׃f�[�^�̌�������</param>
        /// <returns>
        /// �u���񓚁v�܂��́u�񓚊����v�܂��́u�ꕔ�񓚁v
        /// </returns>
        public static SCMSearchedResultState Create(
            long inquiryNumber,
            int answerDivCd,
            SCMInquiryResultWork searchingHeader,
            CustomSerializeArrayList searchedDerailData,
            CustomSerializeArrayList searchedCancelData
        )
        {
            switch (searchingHeader.AnswerDivCd) // ���������̉񓚋敪��...
            {
                case (int)AnswerDivCd.NoAction:         // �u���񓚁v
                    return new SCMNoActionState(inquiryNumber, answerDivCd, searchedDerailData, searchedCancelData);

                case (int)AnswerDivCd.AnswerCompletion: // �u�񓚊����v
                    return new SCMAnswerCompletionState(inquiryNumber, answerDivCd, searchedDerailData, searchedCancelData);

                case (int)AnswerDivCd.PartAnswer:       // �u�ꕔ�񓚁v
                    return new SCMPartAnswerState(inquiryNumber, answerDivCd, searchedDerailData, searchedCancelData);
                default:
                    break;
            }

            // �u���񓚁v
            if (SCMNoActionState.IsNoActionState(searchedDerailData))
            {
                return new SCMNoActionState(inquiryNumber, answerDivCd, searchedDerailData, searchedCancelData);
            }

            // �u�񓚊����v
            if (SCMAnswerCompletionState.IsAnswerCompletionState(searchedDerailData))
            {
                return new SCMAnswerCompletionState(inquiryNumber, answerDivCd, searchedDerailData, searchedCancelData);
            }

            // �u�ꕔ�񓚁v
            return new SCMPartAnswerState(inquiryNumber, answerDivCd, searchedDerailData, searchedCancelData);
        }
    }

    #endregion // �t�@�N�g���N���X
}
