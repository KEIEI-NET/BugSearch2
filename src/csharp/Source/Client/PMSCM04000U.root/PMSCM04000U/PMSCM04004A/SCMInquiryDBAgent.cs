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
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �� �� ��  2010/04/23  �C�����e : ���ו\�����s���Ƃr�e�œ��͂������׏��ԂƋt���ŕ\�������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H��
// �� �� ��  2010/06/17  �C�����e : �L�����Z���ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024 ���X�� ��
// �� �� ��  2010/02/09  �C�����e : �o�l���ōs�ǉ��������ׂ�\���ł���悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10900690-00 �쐬�S�� : qijh
// �� �� ��  2013/02/27  �C�����e : 2013/06/18�z�M Redmine#34752 �uPMSCM��No.10385�vBLP�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    using SearchedResultPair = KeyValuePair<List<SCMInquiryDtlInqResultWork>, List<SCMInquiryDtlAnsResultWork>>;

    /// <summary>
    /// �⍇���E������ʗ񋓌^
    /// </summary>
    internal enum InqOrdDivCd : int
    {
        /// <summary>1:�⍇��</summary>
        Inquiry = 1,
        /// <summary>2:����</summary>
        Ordering = 2
    }

    /// <summary>
    /// �񓚋敪�񋓌^
    /// </summary>
    public enum AnswerDivCd : int
    {
        /// <summary>0:�A�N�V�����Ȃ�</summary>
        NoAction = 0,
        /// <summary>10:�ꕔ��</summary>
        PartAnswer = 10,
        /// <summary>20:�񓚊���</summary>
        AnswerCompletion = 20,
        /// <summary>30:���F</summary>
        Approval = 30,
        /// <summary>99:�L�����Z��</summary>
        Cancel = 99
    }

    /// <summary>
    /// �󒍃X�e�[�^�X
    /// </summary>
    internal enum AcptAnOdrStatusState : int
    {
        /// <summary>����</summary>
        Estimate = 10,
        /// <summary>�P������</summary>
        UnitPriceEstimate = 15,
        /// <summary>��������</summary>
        SearchEstimate = 16,
        /// <summary>��</summary>
        AcceptAnOrder = 20,
        /// <summary>����</summary>
        Sales = 30,
        /// <summary>�ݏo</summary>
        Shipment = 40,
    }

    // ADD 2010/06/17 �L�����Z���ǉ��Ή� ---------->>>>>
    /// <summary>
    /// �L�����Z����ԋ敪
    /// </summary>
    public enum CancelCndtinDiv : short
    {
        /// <summary>0:�L�����Z���Ȃ�</summary>
        None = 0,
        /// <summary>10:�L�����Z���v��</summary>
        Cancelling = 10,
        /// <summary>20:�L�����Z���p��</summary>
        Rejected = 20,
        /// <summary>30:�L�����Z���m��</summary>
        Cancelled = 30
    }
    // ADD 2010/06/17 �L�����Z���ǉ��Ή� ----------<<<<<

    /// <summary>
    /// SCM�󒍌n�f�[�^�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public sealed class SCMInquiryDBAgent
    {
        #region �{���̃A�N�Z�T

        /// <summary>�{���̃A�N�Z�T</summary>
        private readonly ISCMInquiryDB _realAccesser = (ISCMInquiryDB)MediationSCMInquiryResultDB.GetSCMInquiryDB();
        /// <summary>�{���̃A�N�Z�T���擾���܂��B</summary>
        internal ISCMInquiryDB RealAccesser { get { return _realAccesser; } }

        #endregion // �{���̃A�N�Z�T

        #region �L�����Z������

        // 2011/02/14 Del >>>
        ///// <summary>�L�����Z������</summary>
        //private readonly SCMCanceler _canceler;
        ///// <summary>�L�����Z���������擾���܂��B</summary>
        //public SCMCanceler Canceler { get { return _canceler; } }
        // 2011/02/14 Del <<<

        #endregion // �L�����Z������

        #region Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SCMInquiryDBAgent()
        {
            // 2011/02/14 >>>
            //_canceler = new SCMCanceler(this);
            // 2011/02/14 <<<
        }
        
        #endregion // Constructor

        #region SCM�󒍃f�[�^

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="scmInquiryResultWork">��������</param>
        /// <param name="scmInquiryOrderWork">��������</param>
        /// <param name="readMode">�Ǎ����[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        public int Search(
            out object scmInquiryResultWork,    // CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryResultWork>>
            object scmInquiryOrderWork,         // SCMInquiryOrderWork
            int readMode,
            ConstantManagement.LogicalMode logicalMode
        )
        {
            // 2011/02/14 >>>
            //Canceler.ClearEntry((SCMInquiryOrderWork)scmInquiryOrderWork);
            // 2011/02/14 <<<
            return RealAccesser.Search(out scmInquiryResultWork, scmInquiryOrderWork, readMode, logicalMode);
        }

        #endregion // SCM�󒍃f�[�^

        #region SCM�󒍖��׃f�[�^(�⍇���E����)�^SCM�󒍖��׃f�[�^(��)

        /// <summary>
        /// ���׏����������܂��B
        /// </summary>
        /// <param name="scmInquiryResultWork">���׏��</param>
        /// <param name="objscmInquiryResultWork">��������</param>
        /// <param name="readMode">�Ǎ����[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        public int SearchDetail(
            out object scmInquiryResultWork,// CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryDtlAnsResultWork �܂��� SCMInquiryDtlInqResultWork>>
            object objscmInquiryResultWork, // SCMInquiryResultWork
            int readMode,
            ConstantManagement.LogicalMode logicalMode
        )
        {
            return RealAccesser.SearchDetail(out scmInquiryResultWork, objscmInquiryResultWork, readMode, logicalMode);
        }

        /// <summary>
        /// 1�̓`�[�ł��邩���f���܂��B
        /// </summary>
        /// <param name="header">�w�b�_�f�[�^</param>
        /// <returns>
        /// <c>true</c> :1�̓`�[�܂��͓`�[�͓o�^����Ă��܂���B<br/>
        /// <c>false</c>:�����̓`�[�ł��B
        /// </returns>
        public bool IsOneSlip(SCMInquiryResultWork header)
        {
            object detailData = null;   // 1�p����
            SCMInquiryResultWork searchingCondition = ConvertSearchingDetailCondition(header);  // 2�p����

            int status = SearchDetail(out detailData, searchingCondition, 0, ConstantManagement.LogicalMode.GetData0);

            CustomSerializeArrayList searchedDetailList = detailData as CustomSerializeArrayList;
            if (searchedDetailList == null) return true;

            string salesSlipNum = header.SalesSlipNum;
            foreach (CustomSerializeArrayList detailList in searchedDetailList)
            {
                foreach (object detail in detailList)
                {
                    string detailSalesSlipNum = GetSalesSlipNum(detail);
                    // ���񓚂̃f�[�^�͓`�[�ԍ����Ȃ��̂ŁA����
                    if (string.IsNullOrEmpty(detailSalesSlipNum)) continue;
                    // �`�[�ԍ����ω������̂ŁA�����`�[
                    if (!detailSalesSlipNum.Equals(salesSlipNum)) return false;
                }
            }

            return true;
        }

        /// <summary>
        /// �w�b�_�f�[�^�𖾍׃f�[�^�̌��������ɕϊ����܂��B
        /// </summary>
        /// <param name="header">�w�b�_�f�[�^</param>
        /// <returns>���׃f�[�^�̌�������</returns>
        private static SCMInquiryResultWork ConvertSearchingDetailCondition(SCMInquiryResultWork header)
        {
            SCMInquiryResultWork searchingCondition = new SCMInquiryResultWork();
            {
                searchingCondition.AcptAnOdrStatus = header.AcptAnOdrStatus;
                searchingCondition.AnswerDivCd = header.AnswerDivCd;
                searchingCondition.EnterpriseCode = header.EnterpriseCode;
                searchingCondition.InqOrdDivCd = header.InqOrdDivCd;
                searchingCondition.InqOriginalEpCd = header.InqOtherEpCd.Trim();//@@@@20230303
                searchingCondition.InqOriginalSecCd = header.InqOriginalSecCd;
                searchingCondition.InqOtherEpCd = header.InqOtherEpCd;
                searchingCondition.InqOtherSecCd = header.InqOtherSecCd;
                searchingCondition.InquiryNumber = header.InquiryNumber;
                searchingCondition.UpdateDate = header.UpdateDate;
                searchingCondition.UpdateTime = header.UpdateTime;
                // FIXME:���׃f�[�^�̌��������ɓ`�[�ԍ��͕K�v�H
                searchingCondition.SalesSlipNum = header.SalesSlipNum;
            }
            return searchingCondition;
        }

        /// <summary>
        /// ���׏����������܂��B
        /// </summary>
        /// <param name="scmInquiryResultWork">���׏��</param>
        /// <param name="scmInquiryResultWorkCancel">���׏��(�L�����Z����)</param>
        /// <param name="objscmInquiryResultWork">��������</param>
        /// <param name="readMode">�Ǎ����[�h</param>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        public int SearchDetailAll(
            out object scmInquiryResultWork,        // CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryDtlAnsResultWork �܂��� SCMInquiryDtlInqResultWork>>
            out object scmInquiryResultWorkCancel,  // CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryDtlAnsResultWork �܂��� SCMInquiryDtlInqResultWork>>
            object objscmInquiryResultWork, // SCMInquiryResultWork
            int readMode,
            ConstantManagement.LogicalMode logicalMode
        )
        {
            return RealAccesser.SearchDetailAll(
                out scmInquiryResultWork,
                out scmInquiryResultWorkCancel,
                objscmInquiryResultWork,
                readMode,
                logicalMode
            );
        }

        #endregion // SCM�󒍖��׃f�[�^(�⍇���E����)�^SCM�󒍖��׃f�[�^(��)

        #region �Ώی���

        /// <summary>
        /// �Ώی������������܂��B
        /// </summary>
        /// <param name="readCnt">�Ώی���</param>
        /// <param name="objscmInquiryOrderWork">��������</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        public int SearchCnt(
            out int readCnt,
            object objscmInquiryOrderWork
        )
        {
            return RealAccesser.SearchCnt(out readCnt, objscmInquiryOrderWork);
        }

        #endregion // �Ώی���

        /// <summary>
        /// ����`�[�ԍ����擾���܂��B
        /// </summary>
        /// <param name="data">�w�b�_�f�[�^�܂��͖��׃f�[�^</param>
        /// <returns>SalesSlipNum�v���p�e�B��Ԃ��܂��B</returns>
        private static string GetSalesSlipNum(object data)
        {
            if (data is SCMInquiryResultWork) return ((SCMInquiryResultWork)data).SalesSlipNum;
            if (data is SCMInquiryDtlInqResultWork) return ((SCMInquiryDtlInqResultWork)data).SalesSlipNum;
            if (data is SCMInquiryDtlAnsResultWork) return ((SCMInquiryDtlAnsResultWork)data).SalesSlipNum;
            return string.Empty;
        }

        /// <summary>
        /// �񓚋敪�̖��̂��擾���܂��B
        /// </summary>
        /// <param name="answerDivCd">�񓚋敪</param>
        /// <returns>�Y������񓚋敪�̖���</returns>
        public static string GetAnswerDivCdName(int answerDivCd)
        {
            if (answerDivCd.Equals((int)AnswerDivCd.NoAction)) return "����";
            if (answerDivCd.Equals((int)AnswerDivCd.PartAnswer)) return "�ꕔ��";
            if (answerDivCd.Equals((int)AnswerDivCd.AnswerCompletion)) return "�񓚊���";
            if (answerDivCd.Equals((int)AnswerDivCd.Approval)) return "���F";
            if (answerDivCd.Equals((int)AnswerDivCd.Cancel)) return "�L�����Z��";
            return string.Empty;
        }

        /// <summary>
        /// �`�[���̂��擾���܂��B
        /// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <returns>�Y������`�[����</returns>
        public static string GetSlipName(int acptAnOdrStatus)
        {
            if (acptAnOdrStatus.Equals((int)AcptAnOdrStatusState.Estimate)) return "����";
            if (acptAnOdrStatus.Equals((int)AcptAnOdrStatusState.UnitPriceEstimate)) return "�P������";
            if (acptAnOdrStatus.Equals((int)AcptAnOdrStatusState.SearchEstimate)) return "��������";
            if (acptAnOdrStatus.Equals((int)AcptAnOdrStatusState.AcceptAnOrder)) return "��";
            if (acptAnOdrStatus.Equals((int)AcptAnOdrStatusState.Sales)) return "����";
            if (acptAnOdrStatus.Equals((int)AcptAnOdrStatusState.Shipment)) return "�ݏo";
            return string.Empty;
        }

        // ADD 2010/04/23 ���ו\�����s���Ƃr�e�œ��͂������׏��ԂƋt���ŕ\������� ---------->>>>>
        /// <summary>
        /// ���׃f�[�^�̌������ʂ��������܂��B
        /// </summary>
        /// <param name="searchedDetailResult">���׃f�[�^�̌�������</param>
        /// <returns>�񓚃f�[�^ + �񓚃f�[�^�Ɋ܂܂�Ȃ�(���׃f�[�^)�̃��X�g</returns>
        // 2011/02/14 >>>
        //public static SortedList<string, object> JoinSearchedDetailResult(CustomSerializeArrayList searchedDetailResult)
        public static SortedList<string, object> JoinSearchedDetailResult(SCMInquiryResultWork condition, CustomSerializeArrayList searchedDetailResult, CustomSerializeArrayList searchedDetailResultCancel)
        // 2011/02/14 <<<
        {
            SortedList<string, object> joinList = new SortedList<string, object>();
            {
                // 2011/02/14 >>>
#if False
                SearchedResultPair searchedResult = SCMSearchedResultState.SplitSearchedResult(searchedDetailResult);
                // �񓚃f�[�^�����݂���ꍇ�A�񓚃f�[�^��D��I�ɐݒ�
                if (searchedResult.Value.Count > 0)
                {
                #region �񓚃f�[�^�̂�

                    if (searchedResult.Key.Count.Equals(0))
                    {
                        // �񓚃f�[�^�݂̂̏ꍇ
                        searchedResult.Value.ForEach(delegate(SCMInquiryDtlAnsResultWork ans)
                        {
                            joinList.Add(GetResultSortKey(ans), ans);

                        });
                        return joinList;
                    }

                    #endregion // �񓚃f�[�^�̂�

                    // ���׃f�[�^�Ɖ񓚃f�[�^�����݂��Ă���ꍇ
                    searchedResult.Key.ForEach(delegate(SCMInquiryDtlInqResultWork inq)
                    {
                        int ansIndex = searchedResult.Value.FindIndex(delegate(SCMInquiryDtlAnsResultWork ans)
                        {
                            // �����[�g�̌������ʂ�O��Ƃ��Ă���̂ŁA�⍇���s�ԍ��Ɩ⍇���s�ԍ��}�Ԃ݂̂̔�r
                            return SCMSearchedResultState.IsParenthood(ans, inq);
                        });
                        if (ansIndex >= 0)
                        {
                            joinList.Add(GetResultSortKey(searchedResult.Value[ansIndex]), searchedResult.Value[ansIndex]);
                        }
                        else
                        {
                            joinList.Add(GetDetailSortKey(inq), inq);
                        }
                    });

                    return joinList;
                }

                #region ���׃f�[�^�̂�

                // ���׃f�[�^�݂̂̏ꍇ
                searchedResult.Key.ForEach(delegate(SCMInquiryDtlInqResultWork inq)
                {
                    joinList.Add(GetDetailSortKey(inq), inq);
                });

                #endregion // ���׃f�[�^�̂�
#endif
                List<SCMInquiryDtlInqResultWork> inqListAll = new List<SCMInquiryDtlInqResultWork>();
                List<SCMInquiryDtlAnsResultWork> ansListAll = new List<SCMInquiryDtlAnsResultWork>();

                // �⍇�����𕪊�
                CustomSerializeArrayList inqList = null;
                CustomSerializeArrayList ansList = null;
                SplitSearchedResult(searchedDetailResult, out inqList, out ansList);

                // �L�����Z�����𕪊�
                CustomSerializeArrayList inqList2 = null;
                CustomSerializeArrayList ansList2 = null;
                SplitSearchedResult(searchedDetailResultCancel, out inqList2, out ansList2);

                if (condition.AnswerDivCd != (int)AnswerDivCd.Cancel)
                {
                    if (inqList != null && inqList.Count > 0)
                    {
                        foreach (SCMInquiryDtlInqResultWork inq in inqList)
                        {
                            inqListAll.Add(inq);
                        }
                    }
                }
                else
                {
                    if (inqList2 != null && inqList2.Count > 0)
                    {
                        foreach (SCMInquiryDtlInqResultWork inq in inqList2)
                        {
                            inqListAll.Add(inq);
                        }
                    }
                }

                if (condition.AnswerDivCd != (int)AnswerDivCd.Cancel)
                {
                    if (ansList != null && ansList.Count > 0)
                    {
                        foreach (SCMInquiryDtlAnsResultWork ans in ansList)
                        {
                            if (ans.CancelCndtinDiv != (int)CancelCndtinDiv.None)
                            {
                                continue;
                            }
                            ansListAll.Add(ans);
                        }
                    }
                }
                else
                {
                    // ���̃��X�g�͎��ۓ����Ă��Ȃ�...
                    if (ansList2 != null && ansList2.Count > 0)
                    {
                        foreach (SCMInquiryDtlAnsResultWork ans in ansList2)
                        {
                            ansListAll.Add(ans);
                        }
                    }
                    // ���̎��_�ŁA�ʏ�ƃL�����Z���̑S���ׂ̃��X�g�����������
                }

                // �⍇�����s�ԍ������A�A�X�V���t�E�X�V���ԍ~���Ƀ\�[�g
                inqListAll.Sort(new InqCompare());
                // �񓚂��s�ԍ������A�󒍃X�e�[�^�X�A�X�V���t�E�X�V���ԍ~���Ƀ\�[�g
                ansListAll.Sort(new AnsCompare());


                // ��ɖ⍇�����ׂ��烊�X�g�𐶐�
                foreach (SCMInquiryDtlInqResultWork inq in inqListAll)
                {
                    string key = GetDetailSortKey(inq);
                    if (joinList.ContainsKey(key)) continue;
                    joinList.Add(key, inq);
                }

                // �񓚂��烊�X�g���X�V
                foreach (SCMInquiryDtlAnsResultWork ans in ansListAll)
                {
                    string key = GetResultSortKey(ans);

                    if (joinList.ContainsKey(key))
                    {
                        if (joinList[key] is SCMInquiryDtlInqResultWork)
                        {
                            SCMInquiryDtlInqResultWork inq = (SCMInquiryDtlInqResultWork)joinList[key];
                            if (( ans.UpdateDate > inq.UpdateDate ) ||
                                ( ( ans.UpdateDate == inq.UpdateDate ) && ( ans.UpdateTime >= inq.UpdateTime ) )
                                )
                            {
                                joinList[key] = ans;
                            }
                        }
                        // ------------ ADD START 2013/02/27 qijh #34752 ---------- >>>>>>
                        else
                        {
                            SCMInquiryDtlAnsResultWork sCMInquiryDtlAnsResultWork = (SCMInquiryDtlAnsResultWork)joinList[key];
                            if (sCMInquiryDtlAnsResultWork.InqRowNumber == ans.InqRowNumber &&
                                sCMInquiryDtlAnsResultWork.InqRowNumDerivedNo == ans.InqRowNumDerivedNo)
                            {
                                // PM��ǌ��݌� 
                                sCMInquiryDtlAnsResultWork.PmMainMngPrsntCount = ans.PmMainMngPrsntCount;
                                // PM��ǒI��
                                sCMInquiryDtlAnsResultWork.PmMainMngShelfNo = ans.PmMainMngShelfNo;
                                // PM��Ǒq�ɃR�[�h
                                sCMInquiryDtlAnsResultWork.PmMainMngWarehouseCd = ans.PmMainMngWarehouseCd;
                                // PM��Ǒq�ɖ���
                                sCMInquiryDtlAnsResultWork.PmMainMngWarehouseName = ans.PmMainMngWarehouseName;
                                joinList[key] = sCMInquiryDtlAnsResultWork;
                            }
                        }
                        // ------------ ADD END 2013/02/27 qijh #34752 ---------- <<<<<<
                    }
                    else
                    {
                        joinList.Add(key, ans);
                    }
                }
                // 2011/02/14 <<<
            }
            return joinList;

        }

        // 2011/02/14 Add >>>
        /// <summary>
        /// �⍇�����׃f�[�^���\�[�g���܂��B(�⍇���s�ԍ��A�⍇���s�ԍ��}�Ԃ̏����A�X�V���t�A�X�V���Ԃ͍~���j
        /// </summary>
        private class InqCompare : Comparer<SCMInquiryDtlInqResultWork>
        {
            public override int Compare(SCMInquiryDtlInqResultWork x, SCMInquiryDtlInqResultWork y)
            {
                int result = x.InqRowNumber.CompareTo(y.InqRowNumber);
                if (result != 0) return result;

                result = x.InqRowNumDerivedNo.CompareTo(y.InqRowNumDerivedNo);
                if (result != 0) return result;

                result = y.UpdateDate.CompareTo(x.UpdateDate);
                if (result != 0) return result;

                result = y.UpdateTime.CompareTo(x.UpdateTime);
                if (result != 0) return result;

                return result;
            }
        }

        /// <summary>
        /// �񓚖��׃f�[�^���\�[�g���܂��B(�⍇���s�ԍ��A�⍇���s�ԍ��}�Ԃ̏����A�󒍃X�e�[�^�X�A�X�V���t�A�X�V���Ԃ͍~���j
        /// </summary>
        private class AnsCompare : Comparer<SCMInquiryDtlAnsResultWork>
        {
            public override int Compare(SCMInquiryDtlAnsResultWork x, SCMInquiryDtlAnsResultWork y)
            {
                int result = x.InqRowNumber.CompareTo(y.InqRowNumber);
                if (result != 0) return result;

                result = x.InqRowNumDerivedNo.CompareTo(y.InqRowNumDerivedNo);
                if (result != 0) return result;

                result = y.AcptAnOdrStatus.CompareTo(x.AcptAnOdrStatus);
                if (result != 0) return result;


                result = y.UpdateDate.CompareTo(x.UpdateDate);
                if (result != 0) return result;

                result = y.UpdateTime.CompareTo(x.UpdateTime);
                if (result != 0) return result;
                return result;
            }
        }

        /// <summary>
        /// �������ʂ̕�������
        /// </summary>
        /// <param name="inqList"></param>
        /// <param name="cancelList"></param>
        internal  static void SplitSearchedResult(CustomSerializeArrayList searchedList, out CustomSerializeArrayList inqList, out CustomSerializeArrayList answerList)
        {
            inqList = null;
            answerList = null;
            if (searchedList == null) return;
            for (int index = 0; index < searchedList.Count; index++)
            {
                if (( (CustomSerializeArrayList)searchedList[index] ).Count > 0)
                {
                    if (( (CustomSerializeArrayList)searchedList[index] )[0] is SCMInquiryDtlInqResultWork)
                    {
                        inqList = (CustomSerializeArrayList)searchedList[index];
                    }
                    else if (( (CustomSerializeArrayList)searchedList[index] )[0] is SCMInquiryDtlAnsResultWork)
                    {
                        answerList = (CustomSerializeArrayList)searchedList[index];
                    }
                }
            }
        }
        // 2011/02/14 Add <<<


        /// <summary>
        /// ���׃f�[�^�̌������ʂ̃\�[�g�L�[���擾���܂��B
        /// </summary>
        /// <param name="ans">�������ʂ̉񓚃f�[�^</param>
        /// <returns>�⍇���s�ԍ�("00") + �⍇���s�ԍ��}��("00")</returns>
        private static string GetResultSortKey(SCMInquiryDtlAnsResultWork ans)
        {
            return ans.InqRowNumber.ToString("d2") + ans.InqRowNumDerivedNo.ToString("d2");
        }

        /// <summary>
        /// ���׃f�[�^�̌������ʂ̃\�[�g�L�[���擾���܂��B
        /// </summary>
        /// <param name="inq">�������ʂ̖��׃f�[�^</param>
        /// <returns>�⍇���s�ԍ�("00") + �⍇���s�ԍ��}��("00")</returns>
        private static string GetDetailSortKey(SCMInquiryDtlInqResultWork inq)
        {
            return inq.InqRowNumber.ToString("d2") + inq.InqRowNumDerivedNo.ToString("d2");
        }
        // ADD 2010/04/23 ���ו\�����s���Ƃr�e�œ��͂������׏��ԂƋt���ŕ\������� ----------<<<<<
        // ADD 2010/06/17 �L�����Z���ǉ��Ή� ---------->>>>>
        /// <summary>
        /// �L�����Z����ԋ敪�̖��̂��擾���܂��B
        /// </summary>
        /// <param name="cancelCndtinDiv">�L�����Z����ԋ敪</param>
        /// <returns>
        /// <c>0</c> :""
        /// <c>10</c>:"�L�����Z���v��"
        /// <c>20</c>:"�L�����Z������"
        /// <c>30</c>:"�L�����Z����t"
        /// </returns>
        public static string GetCancelCndtinDivName(short cancelCndtinDiv)
        {
            switch (cancelCndtinDiv)
            {
                case (short)CancelCndtinDiv.Cancelling:
                    return "�L�����Z���v��";
                case (short)CancelCndtinDiv.Rejected:
                    return "�L�����Z������";
                case (short)CancelCndtinDiv.Cancelled:
                    return "�L�����Z����t";
                default:
                    return string.Empty;
            }
        }
        // ADD 2010/06/17 �L�����Z���ǉ��Ή� ----------<<<<<
    }
}
