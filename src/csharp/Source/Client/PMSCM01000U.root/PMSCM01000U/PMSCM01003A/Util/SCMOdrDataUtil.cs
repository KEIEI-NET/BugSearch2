//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���ρE�󒍃f�[�^��M
// �v���O�����T�v   : ���ρE�󒍃f�[�^�̎�M�����̑�����s���܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2011/02/18  �C�����e : �@Web����f�[�^�擾���ɁA�Ώۖ⍇���ԍ��̃f�[�^��S���擾����
//                                 �APM7,�����񓚂ɑ΂��āA���ׂ��ŐV�̕��̂ݑΏۃf�[�^�Ƃ��ēn�� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070184-00 �쐬�S�� : ���N�n��
// �� �� ��  2014/10/07  �C�����e : SCM�d�| ��10662�@RedMine#43047 2014/10/16�z�M�V�X�e���e�X�g��Q��10�Ή�
//                                  �`�[�ԍ��I����ʂŁu�V�K�⍇���v�œo�^��ASF���Ŏ�����s���ƁA
//                                  PM���ɐV���ʒm�̃|�b�v�A�b�v���\��������Q�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.WebDB;
using Broadleaf.Application.Common; // 2010/03/30 Add

#if DEBUG
// �_�~�[�Q��
//using ScmOdrData = Broadleaf.Application.UIData.StubDB.ScmOdrData;
//using ScmOdDtInq = Broadleaf.Application.UIData.StubDB.ScmOdDtInq;
//using ScmOdDtAns = Broadleaf.Application.UIData.StubDB.ScmOdDtAns;
//using ScmOdDtCar = Broadleaf.Application.UIData.StubDB.ScmOdDtCar;

//using SCMAcOdrData = Broadleaf.Application.UIData.StubDB.SCMAcOdrData;
//using SCMAcOdrDtlIq = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtlIq;
//using SCMAcOdrDtlAs = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtlAs;
//using SCMAcOdrDtCar = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtCar;

using ScmOdrData = Broadleaf.Application.UIData.ScmOdrData;
using ScmOdDtInq = Broadleaf.Application.UIData.ScmOdDtInq;
using ScmOdDtAns = Broadleaf.Application.UIData.ScmOdDtAns;
using ScmOdDtCar = Broadleaf.Application.UIData.ScmOdDtCar;

using SCMAcOdrData = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
using SCMAcOdrDtlIq = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
using SCMAcOdrDtlAs = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
using SCMAcOdrDtCar = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;

#else
    using ScmOdrData = Broadleaf.Application.UIData.ScmOdrData;
    using ScmOdDtInq = Broadleaf.Application.UIData.ScmOdDtInq;
    using ScmOdDtAns = Broadleaf.Application.UIData.ScmOdDtAns;
    using ScmOdDtCar = Broadleaf.Application.UIData.ScmOdDtCar;

    using SCMAcOdrData = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
    using SCMAcOdrDtlIq = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
    using SCMAcOdrDtlAs = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
    using SCMAcOdrDtCar = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;
#endif

namespace Broadleaf.Application.Controller.Util
{
    // ADD 2010/06/29 PM7�A�g����SCM�n�f�[�^��DB�ɏ����Ȃ� ---------->>>>>
    using SCMTotalSettingServer = SingletonInstance<SCMTotalSettingAgent>;  // SCM�S�̐ݒ�}�X�^
    // ADD 2010/06/29 PM7�A�g����SCM�n�f�[�^��DB�ɏ����Ȃ� ----------<<<<<

    /// <summary>
    /// SCM�󒍃f�[�^�ASCM�󒍖��׃f�[�^�ASCM�󒍃f�[�^(�ԗ����)����N���X
    /// </summary>
    public class SCMOdrDataUtil
    {
        #region �w�b�_�ɕR�Â����ׁA�ԗ����̎擾
        /// <summary>
        /// SCM�󔭒��f�[�^�Ɠ��L�[�̖��׃��X�g�A�ԗ������擾����B(Web�^)
        /// </summary>
        /// <param name="scmOdrData"></param>
        /// <param name="scmOdDtInqList"></param>
        /// <param name="scmOdDtCarList"></param>
        /// <param name="relatedSCMOdDtInqList"></param>
        /// <param name="relatedSCMOdDtCar"></param>
        public static void GetRelatedSCMOdrData(
            ScmOdrData scmOdrData, List<ScmOdDtInq> scmOdDtInqList, List<ScmOdDtCar> scmOdDtCarList,
            out List<ScmOdDtInq> relatedSCMOdDtInqList, out ScmOdDtCar relatedSCMOdDtCar)
        {
            relatedSCMOdDtInqList = new List<ScmOdDtInq>();
            relatedSCMOdDtCar = new ScmOdDtCar();

            // �L�[���ڂ̎擾
            string inqOriginalEpCd = scmOdrData.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
            string inqOriginalSecCd = scmOdrData.InqOriginalSecCd; // �⍇�������_�R�[�h
            string inqOtherEpCd = scmOdrData.InqOtherEpCd; // �⍇�����ƃR�[�h
            string inqOtherSecCd = scmOdrData.InqOtherSecCd; // �⍇���拒�_�R�[�h

            Int64 inquiryNumber = scmOdrData.InquiryNumber; // �⍇���ԍ�
            Int32 inqOrdDivCd = scmOdrData.InqOrdDivCd;

            // ����(�⍇���E��)�f�[�^�擾
            relatedSCMOdDtInqList = scmOdDtInqList.FindAll(
                delegate(ScmOdDtInq scmOdDtInq)
                {
                    if (scmOdDtInq.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && scmOdDtInq.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && scmOdDtInq.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && scmOdDtInq.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && scmOdDtInq.InquiryNumber == inquiryNumber
                        && scmOdDtInq.InqOrdDivCd == inqOrdDivCd
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

             // �ԗ����擾
            relatedSCMOdDtCar = scmOdDtCarList.Find(
                delegate(ScmOdDtCar scmOdDtCar)
                {
                    if (scmOdDtCar.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim() //@@@@20230303
                        && scmOdDtCar.InqOriginalSecCd == inqOriginalSecCd
                        && scmOdDtCar.InquiryNumber == inquiryNumber)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
        }

        /// <summary>
        /// SCM�󒍃f�[�^�Ɠ��L�[�̖��׃��X�g�A�ԗ������擾����B(���[�U�^)
        /// </summary>
        /// <param name="mode">0:��M�����`�F�b�N�����A1:��M�����`�F�b�N�L��</param>
        public static void GetRelatedSCMOdrAcData(
            // 2011/02/18 Add >>>
            int mode,
            // 2011/02/18 Add <<<
            ISCMOrderHeaderRecord scmAcOdrData, List<ISCMOrderDetailRecord> scmAcOdrDtlIqList,List<ISCMOrderCarRecord> scmAcOdrDtCarList,
            out List<ISCMOrderDetailRecord> relatedSCMAcOdrDtlIqList, out ISCMOrderCarRecord relatedSCMAcOdrDtCar)
        {
            relatedSCMAcOdrDtlIqList = new List<ISCMOrderDetailRecord>();

            // �L�[���ڂ̎擾
            string inqOriginalEpCd = scmAcOdrData.InqOriginalEpCd.Trim(); // �⍇������ƃR�[�h//@@@@20230303
            string inqOriginalSecCd = scmAcOdrData.InqOriginalSecCd; // �⍇�������_�R�[�h
            string inqOtherEpCd = scmAcOdrData.InqOtherEpCd; // �⍇�����ƃR�[�h
            string inqOtherSecCd = scmAcOdrData.InqOtherSecCd; // �⍇���拒�_�R�[�h

            Int64 inquiryNumber = scmAcOdrData.InquiryNumber; // �⍇���ԍ�

            Int32 acptAnOdrStatus = scmAcOdrData.AcptAnOdrStatus; // �󒍃X�e�[�^�X
            string salesSlipNum = scmAcOdrData.SalesSlipNum; // ����`�[�ԍ�

            Int32 inqOrdDivCd = scmAcOdrData.InqOrdDivCd;   // �⍇���E�������
            // 2011/02/18 Add >>>
            DateTime updateDate = scmAcOdrData.UpdateDate;
            int updateTime = scmAcOdrData.UpdateTime;
            // 2011/02/18 Add <<<

            // ����(�⍇���E��)�f�[�^�擾
            relatedSCMAcOdrDtlIqList = scmAcOdrDtlIqList.FindAll(
                delegate(ISCMOrderDetailRecord userSCMOrderDetailRecord)
                {
                    if (userSCMOrderDetailRecord.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && userSCMOrderDetailRecord.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && userSCMOrderDetailRecord.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && userSCMOrderDetailRecord.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && userSCMOrderDetailRecord.InquiryNumber == inquiryNumber
                        && userSCMOrderDetailRecord.InqOrdDivCd == inqOrdDivCd
                        // 2011/02/18 Add >>>
                        && ( mode == 0 || ( ( mode == 1 ) && ( userSCMOrderDetailRecord.UpdateDate == updateDate && userSCMOrderDetailRecord.UpdateTime == updateTime ) ) )
                        // 2011/02/18 Add <<<
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // �ԗ����擾
            relatedSCMAcOdrDtCar = scmAcOdrDtCarList.Find(
                delegate(ISCMOrderCarRecord userSCMOrderCarRecord)
                {
                    if (userSCMOrderCarRecord.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && userSCMOrderCarRecord.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && userSCMOrderCarRecord.InquiryNumber == inquiryNumber
                        && userSCMOrderCarRecord.AcptAnOdrStatus == acptAnOdrStatus
                        && userSCMOrderCarRecord.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
        }
        #endregion

        /// <summary>
        /// ���V�X�e���A�g�L���ɂ�胊�X�g�𕪂���
        /// </summary>
        public static void FilterByLegacySection(
            // 2010/12/27 >>>
            //Dictionary<string, string> legacySectionList,
            //// 2010/03/30 Add >>>
            //List<SimplInqCnectInfo> simplInqCnectInfoList,
            //// 2010/03/30 Add <<<
            Dictionary<string, int> scmTargetList,
            // 2010/12/27 <<<
            // 2011/02/18 Add >>>
            List<string> newDataKeyList,
            // 2011/02/18 Add <<<
            List<ISCMOrderHeaderRecord> userSCMOrderHeaderRecordList, List<ISCMOrderDetailRecord> userSCMOrderDetailRecordList, List<ISCMOrderCarRecord> userSCMOrderCarRecordList,
            out List<ISCMOrderHeaderRecord> notLegacySCMAcOdrDataList, out List<ISCMOrderDetailRecord> notLegacySCMAcOdrDtlIqList, out List<ISCMOrderCarRecord> notLegacySCMAcOdrDtCarList,
            out List<ISCMOrderHeaderRecord> legacySCMAcOdrDataList, out List<ISCMOrderDetailRecord> legacySCMAcOdrDtlIqList, out List<ISCMOrderCarRecord> legacySCMAcOdrDtCarList)
        {
            notLegacySCMAcOdrDataList = new List<ISCMOrderHeaderRecord>();
            notLegacySCMAcOdrDtlIqList = new List<ISCMOrderDetailRecord>();
            notLegacySCMAcOdrDtCarList = new List<ISCMOrderCarRecord>();

            legacySCMAcOdrDataList = new List<ISCMOrderHeaderRecord>();
            legacySCMAcOdrDtlIqList = new List<ISCMOrderDetailRecord>();
            legacySCMAcOdrDtCarList = new List<ISCMOrderCarRecord>();

            foreach (UserSCMOrderHeaderWrapper userSCMOrderHeaderWrapper in userSCMOrderHeaderRecordList)
            {
                // �󒍃f�[�^�Ɠ��L�[�̊e���ڂ��擾
                List<ISCMOrderDetailRecord> tmpUserSCMOrderDetailRecordList = new List<ISCMOrderDetailRecord>();
                ISCMOrderCarRecord tmpUserSCMOrderCarRecord;

                // 2011/02/18 >>>
                //GetRelatedSCMOdrAcData(userSCMOrderHeaderWrapper, userSCMOrderDetailRecordList, userSCMOrderCarRecordList,
                //    out tmpUserSCMOrderDetailRecordList, out tmpUserSCMOrderCarRecord);
                // 2011/02/18 <<<

                // 2010/12/27 >>>
                //if (!legacySectionList.ContainsKey(userSCMOrderHeaderWrapper.InqOtherSecCd.Trim().PadLeft(2, '0')))
                if (IsNsTargetData(scmTargetList, userSCMOrderHeaderWrapper.InqOtherSecCd.Trim()))
                // 2010/12/27 <<<
                {
                    // 2010/12/27 Del >>>
                    //// 2010/03/30 Add >>>
                    //// CMT�ڑ����X�g���瓾�Ӑ�̌���(1���ł���v���R�[�h������Ύ����񓚑ΏۊO)
                    //SimplInqCnectInfo info = simplInqCnectInfoList.Find(
                    //    delegate(SimplInqCnectInfo rec)
                    //    {
                    //        if (rec.CustomerCode == userSCMOrderHeaderWrapper.CustomerCode) return true;
                    //        return false;
                    //    });

                    //// �ڑ���񂪂������ꍇ�͏������Ȃ�
                    //if (info != null) continue;
                    //// 2010/03/30 Add <<<
                    // 2010/12/27 Del <<<

                    // ���V�X�e���A�g�Ȃ�
                    // 2011/02/18 Add >>>
                    GetRelatedSCMOdrAcData(
                        1,
                        userSCMOrderHeaderWrapper,
                        userSCMOrderDetailRecordList,
                        userSCMOrderCarRecordList,
                        out tmpUserSCMOrderDetailRecordList,
                        out tmpUserSCMOrderCarRecord
                    );
                    // 2011/02/18 Add <<<
                    notLegacySCMAcOdrDataList.Add(userSCMOrderHeaderWrapper);

                    foreach (UserSCMOrderDetailRecord tmpUserSCMOrderDetailRecord in tmpUserSCMOrderDetailRecordList)
                    {
                        notLegacySCMAcOdrDtlIqList.Add(tmpUserSCMOrderDetailRecord);
                    }

                    notLegacySCMAcOdrDtCarList.Add(tmpUserSCMOrderCarRecord);
                }
                else
                {
                    // ���V�X�e���A�g����
                    // 2011/02/18 Add >>>
                    // �ŐV�f�[�^�łȂ��ꍇ�̓��X�g�ɒǉ����Ȃ�
                    if (!newDataKeyList.Contains(SCMOdrDataToKey(userSCMOrderHeaderWrapper))) continue;
                    GetRelatedSCMOdrAcData(
                        0,
                        userSCMOrderHeaderWrapper,
                        userSCMOrderDetailRecordList,
                        userSCMOrderCarRecordList,
                        out tmpUserSCMOrderDetailRecordList,
                        out tmpUserSCMOrderCarRecord
                    );
                    // 2011/02/18 Add <<<

                    legacySCMAcOdrDataList.Add(userSCMOrderHeaderWrapper);

                    foreach (UserSCMOrderDetailRecord tmpUserSCMOrderDetailRecord in tmpUserSCMOrderDetailRecordList)
                    {
                        legacySCMAcOdrDtlIqList.Add(tmpUserSCMOrderDetailRecord);
                    }

                    legacySCMAcOdrDtCarList.Add(tmpUserSCMOrderCarRecord);
                }
            }
        }

        // 2010/12/27 Add >>>
        /// <summary>
        /// NS�Ώۃf�[�^�����f
        /// </summary>
        /// <param name="scmSettingList">SCM�ݒ胊�X�g(key:���_,value:SCM�S�̐ݒ�.���V�X�e���A�g�敪)</param>
        /// <param name="sectionCode">�Ώۋ��_</param>
        /// <returns>True:NS�Ώۋ��_</returns>
        private static bool IsNsTargetData(Dictionary<string, int> scmSettingList, string sectionCode)
        {
            bool ret = false;

            // ���_�P�ʂ̐ݒ肪����ꍇ
            if (scmSettingList.ContainsKey(sectionCode.Trim()))
            {
                ret = ( scmSettingList[sectionCode.Trim()] == 0 );

            }
            // �S�Аݒ肪����ꍇ
            else if (scmSettingList.ContainsKey("00"))
            {
                ret = ( scmSettingList["00"] == 0 );
            }
            return ret;
        }
        // 2010/12/27 Add <<<

        // ADD 2010/06/16 �L�����Z���f�[�^�p�̕␳������ǉ� ---------->>>>>
        /// <summary>
        /// SCM�󒍖��׃f�[�^(�⍇���E����)���u�񓚋敪�v���擾���܂��B
        /// </summary>
        /// <param name="scmOrderDetailRecordList">SCM�󒍖��׃f�[�^(�⍇���E����)</param>
        /// <param name="defaultAnswerDivCd">�L�����Z���f�[�^�ł͂Ȃ��ꍇ�̉񓚋敪�̒l</param>
        /// <returns>
        /// SCM�󒍖��׃f�[�^(�⍇���E����)���ȉ��̏ꍇ�A�u99:�L�����Z���v��Ԃ��܂��B
        /// 1.�u�L�����Z����ԋ敪�v�� 10:�L�����Z���v��
        /// 2.�u�󒍃X�e�[�^�X�v �� 30:����
        /// 3.�u����`�[�ԍ��v�� 0 �ȊO
        /// </returns>
        public static int GetAnswerDivCdIfCanceling(
            List<ISCMOrderDetailRecord> scmOrderDetailRecordList,
            int defaultAnswerDivCd
        )
        {
            #region Guard Phrase

            if (scmOrderDetailRecordList == null || scmOrderDetailRecordList.Count.Equals(0)) return defaultAnswerDivCd;

            #endregion // Guard Phrase

            // �u�L�����Z����ԋ敪�v�Ŕ���
            List<ISCMOrderDetailRecord> foundDetailList = scmOrderDetailRecordList.FindAll(
                delegate(ISCMOrderDetailRecord item)
                {
                    // 0:�L�����Z���Ȃ� 10:�L�����Z���v�� 20:�L�����Z���p�� 30:�L�����Z���m��
                    return item.CancelCndtinDiv.Equals(10);
                }
            );
            if (foundDetailList == null || foundDetailList.Count.Equals(0)) return defaultAnswerDivCd;

            // �u�󒍃X�e�[�^�X�v�Ŕ���
            foundDetailList = foundDetailList.FindAll(delegate(ISCMOrderDetailRecord item)
            {
                // 10:���� 20:�� 30:����
                return item.AcptAnOdrStatus.Equals(30);
            });
            if (foundDetailList == null || foundDetailList.Count.Equals(0)) return defaultAnswerDivCd;

            // �u����`�[�ԍ��v�Ŕ���
            foundDetailList = foundDetailList.FindAll(delegate(ISCMOrderDetailRecord item)
            {
                long salesSlipNum = -1;
                if (!long.TryParse(item.SalesSlipNum.Trim(), out salesSlipNum))
                {
                    return false;
                }
                return salesSlipNum > 0;
            });
            // 0:�A�N�V�����Ȃ� 10:�ꕔ�� 20:�񓚊��� 30:���F 99:�L�����Z��
            return (foundDetailList == null || foundDetailList.Count.Equals(0)) ? defaultAnswerDivCd : 99;
        }
        // ADD 2010/06/16 �L�����Z���f�[�^�p�̕␳������ǉ� ----------<<<<<
        // ADD 2010/06/29 PM7�A�g����SCM�n�f�[�^��DB�ɏ����Ȃ� ---------->>>>>
        /// <summary>
        /// ���V�X�e���A�g�f�[�^�ł��邩���f���܂��B
        /// </summary>
        /// <param name="headerRecord">SCM�󒍃f�[�^</param>
        /// <returns>
        /// �Y������SCM�S�̐ݒ�̋��V�X�e���A�g�敪���u1:����(PM7SP)�v�̏ꍇ�A<c>true</c>��Ԃ��܂��B
        /// </returns>
        public static bool IsLegacyHeaderRecord(ISCMOrderHeaderRecord headerRecord)
        {
            if (headerRecord == null) return false;

            SCMTtlSt foundTotalSetting = SCMTotalSettingServer.Singleton.Instance.Find(
                headerRecord.InqOtherEpCd,
                headerRecord.InqOtherSecCd
            );
            if (!SCMDataHelper.IsAvailableRecord(foundTotalSetting)) foundTotalSetting = null;
            if (foundTotalSetting != null)
            {
                return foundTotalSetting.OldSysCooperatDiv.Equals(1);  // �u0:���Ȃ�(PM.NS)�v�u1:����(PM7SP)�v
            }

            return false;
        }
        // ADD 2010/06/29 PM7�A�g����SCM�n�f�[�^��DB�ɏ����Ȃ� ----------<<<<<


        // 2011/02/18 Add >>>
        /// <summary>
        /// SCM�󒍃f�[�^�̃L�[�ɕϊ����܂�
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        internal static string SCMOdrDataToKey(ScmOdrData scmOdrData)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}",
                scmOdrData.InqOriginalEpCd.Trim(),
                scmOdrData.InqOriginalSecCd.Trim(),
                scmOdrData.InqOtherEpCd.Trim(),
                scmOdrData.InqOtherSecCd.Trim(),
                scmOdrData.InquiryNumber,
                scmOdrData.UpdateTime,
                scmOdrData.UpdateTime);
        }

        /// <summary>
        /// SCM�󒍃f�[�^�̃L�[�ɕϊ����܂�
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        internal static string SCMOdrDataToKey(UserSCMOrderHeaderWrapper scmOdrData)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}",
                scmOdrData.InqOriginalEpCd.Trim(),
                scmOdrData.InqOriginalSecCd.Trim(),
                scmOdrData.InqOtherEpCd.Trim(),
                scmOdrData.InqOtherSecCd.Trim(),
                scmOdrData.InquiryNumber,
                scmOdrData.UpdateTime,
                scmOdrData.UpdateTime);
        }

        /// <summary>
        /// SCM�󒍃f�[�^�����j�[�N�L�[�ɕϊ����܂�
        /// </summary>
        /// <param name="scmOdrData"></param>
        /// <returns></returns>
        internal static string SCMOdrDataToUniqueKey(UserSCMOrderHeaderWrapper scmOdrData)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}",
              scmOdrData.InqOriginalEpCd.Trim(),
              scmOdrData.InqOriginalSecCd.Trim(),
              scmOdrData.InqOtherEpCd.Trim(),
              scmOdrData.InqOtherSecCd.Trim(),
              scmOdrData.InquiryNumber,
              scmOdrData.InqOrdDivCd,
              scmOdrData.CancelDiv);
        }
        /// <summary>
        /// SCM�󒍃f�[�^�����j�[�N�L�[�ɕϊ����܂�
        /// </summary>
        /// <param name="scmOdrData"></param>
        /// <returns></returns>
        internal static string SCMOdrDataToUniqueKey(ISCMOrderHeaderRecord scmOdrData)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}",
              scmOdrData.InqOriginalEpCd.Trim(),
              scmOdrData.InqOriginalSecCd.Trim(),
              scmOdrData.InqOtherEpCd.Trim(),
              scmOdrData.InqOtherSecCd.Trim(),
              scmOdrData.InquiryNumber,
              scmOdrData.InqOrdDivCd,
              scmOdrData.CancelDiv);
        }

        // --- ADD 2014/10/07 ���N�n�� �d�|��10662 �V�X�e���e�X�g��Q��10---------->>>>>
        /// <summary>
        /// SCM�󒍖��׃f�[�^(��)��r�N���X(����ԍ�(�~��))
        /// </summary>
        ///<remarks>
        /// <br>Update Note: 2014/10/07 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 11070184-00�@SCM�d�| ��10662�@RedMine#43047</br>
        /// <br>�@�@         2014/10/16�z�M�V�X�e���e�X�g��Q��10�Ή�</br>
        /// <br>             �`�[�ԍ��I����ʂŁu�V�K�⍇���v�œo�^��ASF���Ŏ�����s���ƁAPM���ɐV���ʒm�̃|�b�v�A�b�v���\��������Q�Ή�</br>
        ///</remarks>
        private class SCMAcOdrDtlAsComparer : Comparer<SCMAcOdrDtlAs>
        {
            public override int Compare(SCMAcOdrDtlAs x, SCMAcOdrDtlAs y)
            {
                int result = y.SalesSlipNum.CompareTo(x.SalesSlipNum);
                return result;
            }
        }
        // --- ADD 2014/10/07 ���N�n�� �d�|��10662 �V�X�e���e�X�g��Q��10----------<<<<<

        /// <summary>
        /// �s�ԍ��A�}�Ԗ��ŁA�񓚁A���񓚂����ʂł���f�B�N�V���i���𐶐����܂��B
        /// </summary>
        /// <param name="detailList"></param>
        /// <param name="answerList"></param>
        /// <returns></returns>
        internal static Dictionary<string, bool> CreateAnswerdCheckDictionary(int cancelDiv, List<SCMAcOdrDtlIq> detailIqList, List<SCMAcOdrDtlAs> detailAsList)
        {
            Dictionary<string, bool> andweredCheckDictionary = new Dictionary<string, bool>();

            // --- ADD 2014/10/07 ���N�n�� �d�|��10662 �V�X�e���e�X�g��Q��10---------->>>>>
            List<SCMAcOdrDtlAs> detailAsList2 = new List<SCMAcOdrDtlAs>();
            // SCM�󒍖��׃f�[�^(��)��r�N���X(����ԍ�(�~��))
            detailAsList.Sort(new SCMAcOdrDtlAsComparer());
            Dictionary<string, string> scmAcOdrDtlAsDic = new Dictionary<string, string>();
            // SF��ʂ�SCM�󒍖��׃f�[�^(��)�f�[�^�̃t�B���^�[
            foreach (SCMAcOdrDtlAs ans in detailAsList)
            {
                string key = string.Format("{0},{1}", ans.InqRowNumber, ans.InqRowNumDerivedNo);
                if (!scmAcOdrDtlAsDic.ContainsKey(key))
                {
                    detailAsList2.Add(ans);
                    scmAcOdrDtlAsDic.Add(key, key);
                }
            }

            // --- ADD 2014/10/07 ���N�n�� �d�|��10662 �V�X�e���e�X�g��Q��10----------<<<<<

            //foreach (SCMAcOdrDtlAs ans in detailAsList)// DEL 2014/10/07 ���N�n�� �d�|��10662 �V�X�e���e�X�g��Q��10
            foreach (SCMAcOdrDtlAs ans in detailAsList2)// ADD 2014/10/07 ���N�n�� �d�|��10662 �V�X�e���e�X�g��Q��10
            {
                if (cancelDiv == 1 && ans.CancelCndtinDiv == 0) continue;
                if (cancelDiv == 0 && ans.CancelCndtinDiv != 0) continue;
                string key = string.Format("{0},{1}", ans.InqRowNumber, ans.InqRowNumDerivedNo);
                if (!andweredCheckDictionary.ContainsKey(key)) andweredCheckDictionary.Add(key, true);

                SCMAcOdrDtlIq detailInq = detailIqList.Find(
                    delegate(SCMAcOdrDtlIq inq)
                    {
                        return ( ( inq.InqRowNumber == ans.InqRowNumber ) && ( inq.InqRowNumDerivedNo == ans.InqRowNumDerivedNo ) );
                    });

                if (detailInq != null)
                {
                    // �L�����Z���m�肵�����ׂ͉񓚍ς݈���
                    if (detailInq.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled) continue;

                    // �⍇�����ׂ̕����V������΁A����
                    if (( detailInq.UpdateDate > ans.UpdateDate ) || ( ( detailInq.UpdateDate == ans.UpdateDate ) && ( detailInq.UpdateTime > ans.UpdateTime ) ))
                    {
                        andweredCheckDictionary[key] = false;
                    }
                }
            }

            foreach (SCMAcOdrDtlIq inq in detailIqList)
            {
                string key = string.Format("{0},{1}", inq.InqRowNumber, inq.InqRowNumDerivedNo);
                if (andweredCheckDictionary.ContainsKey(key)) continue;

                andweredCheckDictionary.Add(key, ( inq.CancelCndtinDiv == (int)CancelCndtinDiv.Cancelled ));
            }

            return andweredCheckDictionary;
        }
        // 2011/02/18 Add <<<
    }
}
