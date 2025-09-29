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
using System.Diagnostics;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    // 2011/02/14 ���̃N���X�͎g�p���Ȃ� >>>
    #if False
    /// <summary>
    /// �L�����Z�������N���X
    /// </summary>
    public sealed class SCMCanceler
    {
        #region ��������

        /// <summary>��������</summary>
        private readonly SCMInquiryDBAgent _searcher;
        /// <summary>�����������擾���܂��B</summary>
        private SCMInquiryDBAgent Searcher { get { return _searcher; } }

        #endregion //�@��������

        #region �w�b�_�f�[�^(SCM�󒍃f�[�^)�̌�������

        /// <summary>���݂̃w�b�_�f�[�^(SCM�󒍃f�[�^)�̌�������</summary>
        private SCMInquiryOrderWork _currentSearchingHeaderCondition;
        /// <summary>���݂̃w�b�_�f�[�^(SCM�󒍃f�[�^)�̌����������擾���܂��B</summary>
        private SCMInquiryOrderWork CurrentSearchingHeaderCondition
        {
            get { return _currentSearchingHeaderCondition; }
            set { _currentSearchingHeaderCondition = value; }
        }

        /// <summary>
        /// �w�b�_�f�[�^(SCM�󒍃f�[�^)�̌����������R�s�[���܂��B
        /// </summary>
        /// <param name="src">�R�s�[��</param>
        /// <returns>�R�s�[�����w�b�_�f�[�^(SCM�󒍃f�[�^)�̌�������</returns>
        private static SCMInquiryOrderWork Copy(SCMInquiryOrderWork src)
        {
            SCMInquiryOrderWork copy = new SCMInquiryOrderWork();
            {
                //copy.AcptAnOdrStatus = src.AcptAnOdrStatus;
                copy.AcptAnOdrStatus = new int[src.AcptAnOdrStatus.Length];
                Array.Copy(src.AcptAnOdrStatus, copy.AcptAnOdrStatus, copy.AcptAnOdrStatus.Length);
                
                copy.AnsEmployeeCd      = src.AnsEmployeeCd;
                copy.AnsEmployeeNm      = src.AnsEmployeeNm;

                //copy.AnswerDivCd = src.AnswerDivCd;
                copy.AnswerDivCd = new int[src.AnswerDivCd.Length];
                Array.Copy(src.AnswerDivCd, copy.AnswerDivCd, copy.AnswerDivCd.Length);

                //copy.AwnserMethod = src.AwnserMethod;
                copy.AwnserMethod = new int[src.AwnserMethod.Length];
                Array.Copy(src.AwnserMethod, copy.AwnserMethod, copy.AwnserMethod.Length);

                copy.CustomerCode       = src.CustomerCode;
                copy.Ed_CustomerCode    = src.Ed_CustomerCode;
                copy.Ed_InquiryDate     = src.Ed_InquiryDate;
                copy.Ed_InquiryNumber   = src.Ed_InquiryNumber;
                copy.Ed_SalesSlipNum    = src.Ed_SalesSlipNum;
                copy.EnterpriseCode     = src.EnterpriseCode;
                copy.InqEmployeeCd      = src.InqEmployeeCd;
                copy.InqEmployeeNm      = src.InqEmployeeNm;

                //copy.InqOrdDivCd = src.InqOrdDivCd;
                copy.InqOrdDivCd = new int[src.InqOrdDivCd.Length];
                Array.Copy(src.InqOrdDivCd, copy.InqOrdDivCd, copy.InqOrdDivCd.Length);

                copy.InqOrdNote         = src.InqOrdNote;
                copy.InqOriginalEpCd    = src.InqOriginalEpCd.Trim();//@@@@20230303
                copy.InqOriginalSecCd   = src.InqOriginalSecCd;
                copy.InqOtherEpCd       = src.InqOtherEpCd;
                copy.InqOtherSecCd      = src.InqOtherSecCd;
                copy.JudgementDate      = src.JudgementDate;
                copy.SalesTotalTaxInc   = src.SalesTotalTaxInc;
                copy.St_CustomerCode    = src.St_CustomerCode;
                copy.St_InquiryDate     = src.St_InquiryDate;
                copy.St_InquiryNumber   = src.St_InquiryNumber;
                copy.St_SalesSlipNum    = src.St_SalesSlipNum;
                copy.UpdateDate         = src.UpdateDate;
                copy.UpdateTime         = src.UpdateTime;
            }
            return copy;
        }

        /// <summary>
        /// �w�b�_�f�[�^(SCM�󒍃f�[�^)�̌�������(�L�����Z���ȊO)�𐶐����܂��B
        /// </summary>
        /// <param name="inquiryNumber">�⍇���ԍ�</param>
        /// <returns>���݂̃w�b�_�f�[�^(SCM�󒍃f�[�^)�̌������������ƂɃL�����Z���ȊO�̏����𐶐����܂��B</returns>
        private SCMInquiryOrderWork CreateSearchingHeaderConditionWithoutCancel(long inquiryNumber)
        {
            SCMInquiryOrderWork searchingCondition = Copy(CurrentSearchingHeaderCondition);
            {
                // �񓚋敪
                searchingCondition.AnswerDivCd = new int[] {
                    (int)AnswerDivCd.AnswerCompletion,  // �񓚊���
                    (int)AnswerDivCd.NoAction,          // ����(�A�N�V�����Ȃ�)
                    (int)AnswerDivCd.PartAnswer,        // �ꕔ��
                    (int)AnswerDivCd.Approval           // ���F
                };

                // �⍇���ԍ�
                searchingCondition.St_InquiryNumber = inquiryNumber;
                searchingCondition.Ed_InquiryNumber = inquiryNumber;
            }
            return searchingCondition;
        }

        #endregion // �w�b�_�f�[�^(SCM�󒍃f�[�^)�̌�������

        #region �o�^���ꂽSCM�󒍃f�[�^�̌�������

        /// <summary>�ŏ��ɓo�^���ꂽSCM�󒍃f�[�^�̌������ʃ}�b�v</summary>
        private readonly Dictionary<long, SCMInquiryResultWork> _firstEntryMap = new Dictionary<long, SCMInquiryResultWork>();
        /// <summary>�ŏ��ɓo�^���ꂽSCM�󒍃f�[�^�̌������ʃ}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�F�⍇���ԍ�</remarks>
        private Dictionary<long, SCMInquiryResultWork> FirstEntryMap { get { return _firstEntryMap; } }

        /// <summary>�d�����ēo�^����SCM�󒍃f�[�^�̌�������(�L�����Z��������)�}�b�v</summary>
        private readonly Dictionary<long, SCMInquiryResultWork> _secondEntryMap = new Dictionary<long, SCMInquiryResultWork>();
        /// <summary>�d�����ēo�^����SCM�󒍃f�[�^�̌�������(�L�����Z��������)�}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�F�⍇���ԍ�</remarks>
        private Dictionary<long, SCMInquiryResultWork> SecondEntryMap { get { return _secondEntryMap; } }

        /// <summary>
        /// �o�^���ꂽSCM�󒍃f�[�^�̌������ʂ��N���A���܂��B
        /// </summary>
        /// <param name="currentSearchingHeaderCondition">���݂̃w�b�_�f�[�^(SCM�󒍃f�[�^)�̌�������</param>
        public void ClearEntry(SCMInquiryOrderWork currentSearchingHeaderCondition)
        {
            FirstEntryMap.Clear();
            SecondEntryMap.Clear();
            CurrentSearchingHeaderCondition = Copy(currentSearchingHeaderCondition);
        }

        /// <summary>
        /// SCM�󒍃f�[�^�̌������ʂ�o�^���܂��B
        /// </summary>
        /// <param name="scmHeader">SCM�󒍃f�[�^�̌�������</param>
        public void Entry(SCMInquiryResultWork scmHeader)
        {
            #region Guard Phrase

            if (scmHeader == null) return;

            #endregion // Guard Phrase

            if (!FirstEntryMap.ContainsKey(scmHeader.InquiryNumber))
            {
                FirstEntryMap.Add(scmHeader.InquiryNumber, scmHeader);
                return;
            }

            // �d������SCM�󒍃f�[�^(�L�����Z��������)
            if (!SecondEntryMap.ContainsKey(scmHeader.InquiryNumber))
            {
                SecondEntryMap.Add(scmHeader.InquiryNumber, scmHeader);
                return;
            }
        }

        #endregion // �o�^���ꂽSCM�󒍃f�[�^�̌�������

        #region Constructor

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="searcher">��������</param>
        public SCMCanceler(SCMInquiryDBAgent searcher)
        {
            _searcher = searcher;
        }

        #endregion // Constructor

        /// <summary>
        /// ����`�[���͂��s���邩���f���܂��B
        /// </summary>
        /// <param name="inquiryNumber">�⍇���ԍ�</param>
        /// <param name="answerDivCd">�񓚋敪</param>
        /// <returns>
        /// <c>true</c> :����`�[���͂��s���܂��B
        /// <c>false</c>:�ȉ��̏ꍇ�A����`�[���͂��s���܂���B
        /// �@�񓚋敪����񓚊����
        /// �A�񓚋敪����L�����Z����Łw���񓚃f�[�^���S�ăL�����Z���x�܂��́w�S�ĕԕi�ς݁x
        /// </returns>
        public bool CanInputSalesSlip(
            long inquiryNumber,
            int answerDivCd
        )
        {
            // �񓚋敪���u�񓚊����v�c����`�[���͂��s���K�v�͂Ȃ�
            if (SCMSearchedResultState.IsAnswerCompletion(answerDivCd)) return false;

            // �L�����Z�������܂ޑS���׃f�[�^(�񓚃f�[�^���܂ށj���擾
            object detailData = null;   // 1�p����
            object cancelData = null;   // 2�p����

            // 3�p����
            SCMInquiryResultWork searchingHeader = null;
            if (SecondEntryMap.ContainsKey(inquiryNumber))
            {
                // �񓚋敪�̌��������Ɂu�L�����Z���v���܂ޏꍇ
                SCMInquiryResultWork firstHeader = FirstEntryMap[inquiryNumber];
                SCMInquiryResultWork secondHeader= SecondEntryMap[inquiryNumber];
                // �񓚋敪���L�����Z���ł͂Ȃ������̗p
                searchingHeader = SCMSearchedResultState.IsCancel(firstHeader.AnswerDivCd) ? secondHeader : firstHeader;
            }
            else if (!SCMSearchedResultState.IsCancel(answerDivCd))
            {
                // �񓚋敪���L�����Z���ł͂Ȃ������̗p
                searchingHeader = FirstEntryMap[inquiryNumber];
            }
            else
            {
                // �����������u�L�����Z���v�݂̂̏ꍇ�A���̑΂ƂȂ�w�b�_�f�[�^���擾
                // �悱�̃f�[�^�Ŗ��׃f�[�^���������Ȃ��ƁA�񓚃f�[�^���擾�ł��Ȃ�
                object otherHeaderData = null;  // 1�p����
                SCMInquiryOrderWork searchingOtherHeader = CreateSearchingHeaderConditionWithoutCancel(inquiryNumber);  // 2�p����

                // �㗝�l�Ō�������Ɠo�^�f�[�^���N���A�����̂ŁA�{���Ō���
                Searcher.RealAccesser.Search(out otherHeaderData, searchingOtherHeader, 0, ConstantManagement.LogicalMode.GetData0);
                
                CustomSerializeArrayList searchedOtherHeaderData = otherHeaderData as CustomSerializeArrayList;
                if (searchedOtherHeaderData == null || searchedOtherHeaderData.Count.Equals(0))
                {
                    // ���̃P�[�X�͂��肦�Ȃ�(�L�����Z���w�b�_�̑΂ɂȂ�w�b�_�͕K������͂�)
                    searchingHeader = FirstEntryMap[inquiryNumber];
                }
                CustomSerializeArrayList searchedOtherHeaderList = searchedOtherHeaderData[0] as CustomSerializeArrayList;
                if (searchedOtherHeaderList == null || searchedOtherHeaderList.Count.Equals(0))
                {
                    // ���̃P�[�X�͂��肦�Ȃ�(�L�����Z���w�b�_�̑΂ɂȂ�w�b�_�͕K������͂�)
                    searchingHeader = FirstEntryMap[inquiryNumber];
                }
                Entry((SCMInquiryResultWork)searchedOtherHeaderList[0]);    // �����[�g�͍ŐV�̂��̂�Ԃ��̂ŁA�K��1���̂͂�

                // �Ĕ���
                return CanInputSalesSlip(inquiryNumber, answerDivCd);
            }

            const string FORMAT = "�⍇���ԍ�[{0}]�F{1} -> {2}";
            string debugInfo = string.Format(FORMAT,
                searchingHeader.InquiryNumber,
                SCMInquiryDBAgent.GetAnswerDivCdName(answerDivCd),
                SCMInquiryDBAgent.GetAnswerDivCdName(searchingHeader.AnswerDivCd)
            );

            Debug.WriteLine(debugInfo);
            int status = Searcher.SearchDetailAll(
                out detailData, // CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryDtlInqResultWork �܂��� SCMInquiryDtlAnsResultWork>>
                out cancelData, // CustomSerializeArrayList<CustomSerializeArrayList<SCMInquiryDtlInqResultWork �܂��� SCMInquiryDtlAnsResultWork>>
                searchingHeader,
                0,
                ConstantManagement.LogicalMode.GetData0
            );

            // �������ʂ̏�ԃN���X�𐶐�
            SCMSearchedResultState searchedResultState = SCMSearchedResultStateFactory.Create(
                inquiryNumber, 
                answerDivCd, 
                searchingHeader, 
                (CustomSerializeArrayList)detailData, 
                (CustomSerializeArrayList)cancelData
            );
            return searchedResultState.CanInputSalesSlip();
        }
    }
    #endif
    // 2011/02/14 Del <<<
}

