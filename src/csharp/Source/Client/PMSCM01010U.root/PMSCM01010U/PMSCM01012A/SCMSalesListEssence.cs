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
// �� �� ��  2009/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2010/03/31  �C�����e : �񓚋敪�ɂ��āA�ߋ��̗������l�����ăZ�b�g����悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30434�@�H�� �b�D 
// �� �� ��  2010/04/21  �C�����e : ���όv��̏ꍇ�A�����A�g�l�����A�L�����y�[���l�����͍s��Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517�@�Ė� �x�� 
// �� �� ��  2010/07/07  �C�����e : ������z�A�������łɂ��Ď����A�g�l�������K�p����Ă��Ȃ��s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024�@���X�� ��
// �� �� ��  2011/02/14  �C�����e : �����񓚎��A����f�[�^���l�����ĉ񓚋敪���Z�b�g����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS�̗���
// �� �� ��  2011/08/10  �C�����e : �����񓚑Ή��ASCM�Z�b�g�}�X�^���M�ł��邽��
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�J�X�^���R���X�g���N�^��ǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LDNS�̎��R
// �� �� ��  2011/09/29  �C�����e : ��Q�� #25633�@PM���@�Ė⍇�����̎�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : LIUSY
// �� �� ��  2011/10/10  �C�����e : Redmine#25754 25755�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�10707327-00   �쐬�S�� : ���N�n��
// �� �� ��  2012/01/12 �C�����e : Redmine#27954
//			                            PMSF�A�g�^PCCforNS BL�߰µ��ް ��Q�Ή��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10800003-00 �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2012/01/16  �C�����e : SCM���ǑΉ��E���L�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 20056 ���n ���
// �� �� ��  2012/04/09  �C�����e : BL-P�_�C���N�g�����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�� �L��
// �� �� ��  2012/08/24  �C�����e : 2012/09/12�z�M�V�X�e����Q��16 �Ή� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/09/12  �C�����e : 2012/09/12�z�M�V�X�e����Q��38 �Ή� 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�ˁ@�L��
// �� �� ��  2013/04/17  �C�����e : 2013/05/22�z�M SCM��Q��10520�Ή� �L�����y�[���l����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �e�c ���V
// �� �� ��  2013/08/07  �C�����e : PM-SCM�d�|�ꗗ��10556�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g��
// �� �� ��  2013/08/07  �C�����e : PM-SCM�d�|�ꗗ��10556�Ή����̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �����M
// �� �� ��  2013/04/17  �C�����e : �z�M���Ȃ���  Redmine#35271
//			                        No.184 �o�l���G���g���[ �Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g���@�F��
// �� �� ��  2013/06/05  �C�����e : 2013/06/18�z�M ��10385�P�̃e�X�g��Q�Ή�(������Q)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/01/30  �C�����e : Redmine#41771 ��Q��13�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070076-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2014/05/08  �C�����e : PM-SCM���x���� �t�F�[�Y�Q�Ή�
//                                : 01.���i�����A�N�Z�X�N���X�␳�����v���p�e�B�Ή�
//                                : 02.���Ӑ�|���O���[�v�}�X�^�擾���ǑΉ��i�񓚔��莞�j
//                                : 03.�ύX�O�P���v�Z�ďo�񐔉��ǑΉ�
//                                : 04.�L�����y�[�������ݒ�}�X�^�擾���ǑΉ�
//                                : 05.���Ӑ�}�X�^�i�`�[�Ǘ��j�擾���ǑΉ�
//                                : 06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j
//                                : 07.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�E�L�����y�[���Ή��j
//                                : 08.����f�[�^�������̃V�X�e�����t�擾�Ή�
//                                : 09.���Ӑ�|���O���[�v�}�X�^�擾���ǑΉ��i����f�[�^�������j
//                                : 10.�P���v�Z�ďo�񐔉���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : duzg
// �� �� ��  2014/08/11  �C�����e : ���؁^�����e�X�g��QNo.5
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/08/13  �C�����e : 11070147-00 �V�X�e���e�X�g��Q��5�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30744 ���� ����q
// �C �� ��  2015/01/19  �C�����e : ���R�����h�Ή� ���R�����h�������A�����A�g�l���E�L�����y�[���l���Ή����s��Ȃ�
//----------------------------------------------------------------------------//

#define _ENABLED_SCM_           // SCM�f�[�^�L���t���O ���ʏ�͗L���I
//#define _ENABLED_SCM_DETAIL_    // SCM�󒍖��׃f�[�^(�⍇���E����)�L���t���O ���ʏ�͖����I

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    using USBOptionServer   = SingletonInstance<USBOptionAgent>;    // USB�̃I�v�V����
    using SlipPrtSetServer  = SingletonInstance<SlipPrtSetAgent>;   // �`�[����ݒ�}�X�^

    /// <summary>
    /// ���ナ�X�g�̐����N���X
    /// </summary>
    public class SCMSalesListEssence
    {
        #region <���O�p�萔>

        /// <summary>�N���X����</summary>
        private const string MY_NAME = "SCMSalesListEssence";

        #endregion // </���O�p�萔>

        #region <����f�[�^>

        /// <summary>����f�[�^</summary>
        private SalesSlip _salesSlipData;
        /// <summary>����f�[�^���擾���܂��B</summary>
        public SalesSlip SalesSlipData
        {
            get { return _salesSlipData; }
            set
            {
                _salesSlipData = value;

                if (_salesSlipData != null)
                {
                    // ���׍s���̃f�t�H���g�l��ݒ�
                    _salesSlipData.DetailRowCount = SalesDetailDataList.Count;
                }
            }
        }

        #endregion // </����f�[�^>

        #region <���㖾�׃f�[�^>

        /// <summary>���㖾�׃f�[�^�̃��X�g</summary>
        private IList<SalesDetail> _salesDetailDataList;
        /// <summary>���㖾�׃f�[�^�̃��X�g���擾���܂��B</summary>
        private IList<SalesDetail> SalesDetailDataList
        {
            get
            {
                if (_salesDetailDataList == null)
                {
                    _salesDetailDataList = new List<SalesDetail>();
                }
                return _salesDetailDataList;
            }
        }

        /// <summary>��������p�̔��㖾�גʔԂ̃J�E���^</summary>
        private long _localSalesSlipDtlNumCount = 0;

        /// <summary>
        /// ���㖾�׃f�[�^��ǉ����܂��B
        /// </summary>
        /// <param name="salesDetailData">���㖾�׃f�[�^</param>
        /// <param name="answerRecord">���ƂȂ���SCM�󒍖��׃f�[�^(��)�̃��R�[�h</param>
        public void AddSalesDetailData(
            SalesDetail salesDetailData,
            ISCMOrderAnswerRecord answerRecord
        )
        {
            // ��������p�Ɉꎞ�I�ɔ��㖾�גʔԂ�ݒ�
            salesDetailData.SalesSlipDtlNum = ++_localSalesSlipDtlNumCount;

            SalesDetailDataList.Add(salesDetailData);

            // SCM�󒍖��׃f�[�^(��)�Ƃ̊֘A�}�b�v�ɒǉ�
            string key = SCMDataHelper.GetSalesDetailKey(salesDetailData);
            if (!SalesDetailAnswerMap.ContainsKey(key))
            {
                SalesDetailAnswerMap.Add(key, answerRecord);
            }
        }

        /// <summary>���㖾�׃f�[�^��SCM�󒍖��׃f�[�^(��)�̊֘A�}�b�v</summary>
        private IDictionary<string, ISCMOrderAnswerRecord> _salesDetailAnswerMap;
        /// <summary>���㖾�׃f�[�^��SCM�󒍖��׃f�[�^(��)�̊֘A�}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�F���㖾�׃f�[�^�L�[</remarks>
        private IDictionary<string, ISCMOrderAnswerRecord> SalesDetailAnswerMap
        {
            get
            {
                if (_salesDetailAnswerMap == null)
                {
                    _salesDetailAnswerMap = new Dictionary<string, ISCMOrderAnswerRecord>();
                }
                return _salesDetailAnswerMap;
            }
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^(��)�̃��R�[�h���擾���܂��B
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <returns>�Ή�����SCM�󒍖��׃f�[�^(��)�̃��R�[�h</returns>
        protected ISCMOrderAnswerRecord GetSCMAnswerRecord(SalesDetail salesDetail)
        {
            string salesDetailKey = SCMDataHelper.GetSalesDetailKey(salesDetail);
            return SalesDetailAnswerMap[salesDetailKey];
        }

        #endregion // </���㖾�׃f�[�^>

        #region <�ԗ��Ǘ��f�[�^>

        /// <summary>�ԗ��Ǘ��f�[�^�̃��X�g</summary>
        private IList<CarManagementWork> _carManagementList;
        /// <summary>�ԗ��Ǘ��f�[�^�̃��X�g���擾���܂��B</summary>
        private IList<CarManagementWork> CarManagementList
        {
            get
            {
                if (_carManagementList == null)
                {
                    _carManagementList = new List<CarManagementWork>();
                }
                return _carManagementList;
            }
        }

        /// <summary>
        /// �ԗ��Ǘ��f�[�^��ǉ����܂��B
        /// </summary>
        /// <param name="carManagementData">�ԗ��Ǘ��f�[�^</param>
        public void AddCarManagementData(CarManagementWork carManagementData)
        {
            CarManagementList.Add(carManagementData);
        }

        #endregion // </�ԗ��Ǘ��f�[�^>

        #region <�����[�g�Q�Ɨp���׃p�����[�^>

        /// <summary>�����[�g�Q�Ɨp���׃p�����[�^�̃��X�g</summary>
        private IList<SlipDetailAddInfoWork> _slipDetailAddInfoList;
        /// <summary>�����[�g�Q�Ɨp���׃p�����[�^�̃��X�g���擾���܂��B</summary>
        private IList<SlipDetailAddInfoWork> SlipDetailAddInfoList
        {
            get
            {
                if (_slipDetailAddInfoList == null)
                {
                    _slipDetailAddInfoList = new List<SlipDetailAddInfoWork>();
                }
                return _slipDetailAddInfoList;
            }
        }

        /// <summary>
        /// �����[�g�Q�Ɨp���׃p�����[�^��ǉ����܂��B
        /// </summary>
        /// <param name="slipDetailAddInfo">�����[�g�Q�Ɨp���׃p�����[�^</param>
        /// <param name="answerRecord">���ƂȂ���SCM�󒍖��׃f�[�^(��)�̃��R�[�h</param>
        public void AddSlipDetailAddInfo(
            SlipDetailAddInfoWork slipDetailAddInfo,
            ISCMOrderAnswerRecord answerRecord
        )
        {
            SlipDetailAddInfoList.Add(slipDetailAddInfo);

            // SCM�󒍖��׃f�[�^(��)�ƃ����[�g�Q�Ɨp�p�����[�^�̊֘A�}�b�v�ɒǉ�
            if (!AnswerSlipDetailAddInfoMap.ContainsKey(answerRecord.SalesRelationId))
            {
                AnswerSlipDetailAddInfoMap.Add(answerRecord.SalesRelationId, slipDetailAddInfo);
            }
        }

        /// <summary>SCM�󒍖��׃f�[�^(��)�ƃ����[�g�Q�Ɨp�p�����[�^�̊֘A�}�b�v</summary>
        private IDictionary<Guid, SlipDetailAddInfoWork> _answerSlipDetailAddInfoMap;
        /// <summary>SCM�󒍖��׃f�[�^(��)�ƃ����[�g�Q�Ɨp�p�����[�^�̊֘A�}�b�v���擾���܂��B</summary>
        private IDictionary<Guid, SlipDetailAddInfoWork> AnswerSlipDetailAddInfoMap
        {
            get
            {
                if (_answerSlipDetailAddInfoMap == null)
                {
                    _answerSlipDetailAddInfoMap = new Dictionary<Guid, SlipDetailAddInfoWork>();
                }
                return _answerSlipDetailAddInfoMap;
            }
        }

        /// <summary>
        /// �����[�g�Q�Ɨp�p�����[�^���擾���܂��B
        /// </summary>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)�̃��R�[�h</param>
        /// <returns>�Ή����郊���[�g�Q�Ɨp�p�����[�^</returns>
        private SlipDetailAddInfoWork GetSlipDetailAddInfo(ISCMOrderAnswerRecord answerRecord)
        {
            if (AnswerSlipDetailAddInfoMap.ContainsKey(answerRecord.SalesRelationId))
            {
                return AnswerSlipDetailAddInfoMap[answerRecord.SalesRelationId];
            }
            return null;
        }

        #endregion // </�����[�g�Q�Ɨp���׃p�����[�^>

        #region <SCM�󒍃f�[�^>

        /// <summary>SCM�󒍃f�[�^�̃��R�[�h</summary>
        private ISCMOrderHeaderRecord _scmHeaderRecord;
        /// <summary>SCM�󒍃f�[�^�̃��R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public ISCMOrderHeaderRecord SCMHeaderRecord
        {
            get { return _scmHeaderRecord; }
            set { _scmHeaderRecord = value; }
        }

        /// <summary>
        /// SCM�󒍃f�[�^�̉񓚋敪��ݒ肵�܂��B
        /// </summary>
        // 2010/03/31 >>>
        //public void SetAnswerDivCdOfSCMHeader()
        public void SetAnswerDivCdOfSCMHeader(List<ISCMOrderAnswerRecord> answerlist, List<ISCMOrderDetailRecord> detailList)
        // 2010/03/31 <<<
        {
            #region <Guard Phrase>

            if (SCMHeaderRecord == null) return;
            if (SCMAnswerRecordList.Count.Equals(0)) return;

            #endregion // </Guard Phrase>

            // 2010/03/31 >>>
            //// ���׃f�[�^���Ɖ񓚃f�[�^�������׃f�[�^���������ꍇ�A20:�񓚊���
            //// ����ȊO�� 10:�ꕔ��
            //if (SCMAnswerRecordList.Count >= SCMDetailRecordMax)
            //{
            //    SCMHeaderRecord.AnswerDivCd = (int)AnswerDivCd.AnswerCompletion;
            //}
            //else
            //{
            //    SCMHeaderRecord.AnswerDivCd = (int)AnswerDivCd.PartAnswer;
            //}

            bool insufficiency = false;

            foreach (ISCMOrderDetailRecord detail in detailList)
            {
                // 2011/02/14 Add >>>
                // �L�����Z���m��́A�񓚍ς݈���
                if (detail.CancelCndtinDiv == (short)CancelCndtinDiv.Cancelled) continue;
                // 2011/02/14 Add <<<

                // ����f�[�^����̌���
                List<ISCMOrderAnswerRecord> newAnswers = ( (List<ISCMOrderAnswerRecord>)SCMAnswerRecordList ).FindAll(
                    delegate(ISCMOrderAnswerRecord target)
                    {
                        // �⍇������ƃR�[�h�Ⴂ
                        if (!target.InqOriginalEpCd.Trim().Equals(detail.InqOriginalEpCd.Trim())) return false;
                        // �⍇�������_�Ⴂ
                        if (!target.InqOriginalSecCd.Trim().Equals(detail.InqOriginalSecCd.Trim())) return false;
                        // �⍇�����ƃR�[�h�Ⴂ
                        if (!target.InqOtherEpCd.Trim().Equals(detail.InqOtherEpCd.Trim())) return false;
                        // �⍇���拒�_�Ⴂ
                        if (!target.InqOtherSecCd.Trim().Equals(detail.InqOtherSecCd.Trim())) return false;
                        // �⍇���ԍ��Ⴂ
                        if (!target.InquiryNumber.Equals(detail.InquiryNumber)) return false;
                        // �⍇���E������ʈႢ
                        if (!target.InqOrdDivCd.Equals(detail.InqOrdDivCd)) return false;

                        // �⍇���s�ԍ��Ⴂ
                        if (!target.InqRowNumber.Equals(detail.InqRowNumber)) return false;

                        // �s�}�Ԃ�����ꍇ�́A�s�}�ԈႢ
                        if (detail.InqRowNumDerivedNo != 0)
                        {
                            if (!target.InqRowNumDerivedNo.Equals(detail.InqRowNumDerivedNo)) return false;
                        }

                        return true;
                    });
                // ����񓚃f�[�^�Ɋ܂܂��ꍇ�͉񓚍ς݈���
                if (newAnswers != null && newAnswers.Count > 0) continue;

                // �ߋ��̉񓚃f�[�^����̌���
                List<ISCMOrderAnswerRecord> oldAnswers = ( (List<ISCMOrderAnswerRecord>)answerlist ).FindAll(
                    delegate(ISCMOrderAnswerRecord target)
                    {
                        // �⍇������ƃR�[�h�Ⴂ
                        if (!target.InqOriginalEpCd.Trim().Equals(detail.InqOriginalEpCd.Trim())) return false;
                        // �⍇�������_�Ⴂ
                        if (!target.InqOriginalSecCd.Trim().Equals(detail.InqOriginalSecCd.Trim())) return false;
                        // �⍇�����ƃR�[�h�Ⴂ
                        if (!target.InqOtherEpCd.Trim().Equals(detail.InqOtherEpCd.Trim())) return false;
                        // �⍇���拒�_�Ⴂ
                        if (!target.InqOtherSecCd.Trim().Equals(detail.InqOtherSecCd.Trim())) return false;
                        // �⍇���ԍ��Ⴂ
                        if (!target.InquiryNumber.Equals(detail.InquiryNumber)) return false;
                        // �⍇���E������ʈႢ
                        if (!target.InqOrdDivCd.Equals(detail.InqOrdDivCd)) return false;

                        // �⍇���s�ԍ��Ⴂ
                        if (!target.InqRowNumber.Equals(detail.InqRowNumber)) return false;

                        // �s�}�Ԃ�����ꍇ�́A�s�}�ԈႢ
                        if (detail.InqRowNumDerivedNo != 0)
                        {
                            if (!target.InqRowNumDerivedNo.Equals(detail.InqRowNumDerivedNo)) return false;
                        }

                        // �Ė⍇���̃`�F�b�N
                        // �@��M���� �ߋ��̉� < ����⍇��
                        // �A��M���������ꍇ�́A��M������ �ߋ��̉� < ����⍇��
                        if (target.UpdateDate < detail.UpdateDate) return false;
                        if (target.UpdateDate == detail.UpdateDate && target.UpdateTime < detail.UpdateTime) return false;

                        return true;
                    });
                // �ߋ��̉񓚂ɁA���ׂɑΉ�����񓚂����݂����ꍇ�͉񓚍ς݈���
                if (oldAnswers != null && oldAnswers.Count > 0) continue;

                insufficiency = true;
                break;
            }

            // ���񓚃f�[�^���܂܂��ꍇ�͈ꕔ�񓚂Ƃ���
            SCMHeaderRecord.AnswerDivCd = ( insufficiency ) ? (int)AnswerDivCd.PartAnswer : (int)AnswerDivCd.AnswerCompletion;
            // 2010/03/31 <<<
        }

        #endregion // </SCM�󒍃f�[�^>

        #region <SCM�󒍃f�[�^(�ԗ����)>

        /// <summary>SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h</summary>
        private ISCMOrderCarRecord _scmCarRecord;
        /// <summary>SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h���擾�܂��͐ݒ肵�܂��B</summary>
        public ISCMOrderCarRecord SCMCarRecord
        {
            get { return _scmCarRecord; }
            set { _scmCarRecord = value; }
        }

        #endregion // </SCM�󒍃f�[�^(�ԗ����)>

        #region <SCM�󒍖��׃f�[�^(�⍇���E����)>

        /// <summary>SCM�󒍖��׃f�[�^(�⍇���E����)�̍ő僌�R�[�h��</summary>
        private int _scmDetailRecordMax = int.MaxValue;
        /// <summary>SCM�󒍖��׃f�[�^(�⍇���E����)�̍ő僌�R�[�h�����擾�܂��͐ݒ肵�܂��B</summary>
        /// <remarks><c>SCMSalesDataMaker.MakeAnswerDataAndSalesData()</c>���ݒ肳��܂��B</remarks>
        public int SCMDetailRecordMax
        {
            get { return _scmDetailRecordMax; }
            set
            {
                _scmDetailRecordMax = value;
                // 2010/03/31 >>>
                //SetAnswerDivCdOfSCMHeader();    // SCM�󒍃f�[�^�̉񓚋敪��ݒ�
                // 2010/03/31 <<<
            }
        }

        /// <summary>SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h�̃��X�g</summary>
        private IList<ISCMOrderDetailRecord> _scmDetailRecordList;
        /// <summary>SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h�̃��X�g���擾���܂��B</summary>
        private IList<ISCMOrderDetailRecord> SCMDetailRecordList
        {
            get
            {
                if (_scmDetailRecordList == null)
                {
                    _scmDetailRecordList = new List<ISCMOrderDetailRecord>();
                }
                return _scmDetailRecordList;
            }
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h��ǉ����܂��B
        /// </summary>
        /// <param name="scmDetailRecord">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <exception cref="ArgumentNullException">�ǉ�����SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h��null�ł��B</exception>
        public void AddSCMDetailRecord(ISCMOrderDetailRecord scmDetailRecord)
        {
            #region <Guard Phrase>

            if (scmDetailRecord == null)
            {
                throw new ArgumentNullException("scmDetailRecord", "�ǉ�����SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h��null�ł��B");
            }

            #endregion // </Guard Phrase>

            string scmDetailKey = SCMEntityUtil.GetDetailRecordKey(scmDetailRecord);
            if (!EntrySCMDetailRecordMap.ContainsKey(scmDetailKey))
            {
                SCMDetailRecordList.Add(scmDetailRecord);
                EntrySCMDetailRecordMap.Add(scmDetailKey, scmDetailRecord);
            }
        }

        /// <summary>�o�^����Ă���SCM�󒍖��׃f�[�^(�⍇���E����)�̃}�b�v</summary>
        private IDictionary<string, ISCMOrderDetailRecord> _entrySCMDetailRecordMap;
        /// <summary>�o�^����Ă���SCM�󒍖��׃f�[�^(�⍇���E����)�̃}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�FSCM�󒍖��׃f�[�^(�⍇���E����)�̃L�[</remarks>
        private IDictionary<string, ISCMOrderDetailRecord> EntrySCMDetailRecordMap
        {
            get
            {
                if (_entrySCMDetailRecordMap == null)
                {
                    _entrySCMDetailRecordMap = new Dictionary<string, ISCMOrderDetailRecord>();
                }
                return _entrySCMDetailRecordMap;
            }
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^(�⍇���E����)�̔����q�𐶐����܂��B
        /// </summary>
        /// <returns>SCM�󒍖��׃f�[�^(�⍇���E����)�̔����q</returns>
        public ListIterator<ISCMOrderDetailRecord> CreateSCMDetailIterator()
        {
            return new ListIterator<ISCMOrderDetailRecord>(SCMDetailRecordList);
        }

        #endregion // </SCM�󒍖��׃f�[�^(�⍇���E����)>

        #region <SCM�󒍖��׃f�[�^(��)>

        /// <summary>SCM�󒍖��׃f�[�^(��)�̃��R�[�h�̃��X�g</summary>
        private IList<ISCMOrderAnswerRecord> _scmAnswerRecordList;
        /// <summary>SCM�󒍖��׃f�[�^(��)�̃��R�[�h�̃��X�g���擾���܂��B</summary>
        private IList<ISCMOrderAnswerRecord> SCMAnswerRecordList
        {
            get
            {
                if (_scmAnswerRecordList == null)
                {
                    _scmAnswerRecordList = new List<ISCMOrderAnswerRecord>();
                }
                return _scmAnswerRecordList;
            }
        }

        /// <summary>SCM�󒍖��׃f�[�^(��)��SCM�󒍖��׃f�[�^(�⍇���E����)�̊֘A�}�b�v</summary>
        private IDictionary<Guid, ISCMOrderDetailRecord> _answerDetailMap;
        /// <summary>SCM�󒍖��׃f�[�^(��)��SCM�󒍖��׃f�[�^(�⍇���E����)�̊֘A�}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�F�񓚃f�[�^�̊֘AGUID</remarks>
        private IDictionary<Guid, ISCMOrderDetailRecord> AnswerDetailMap
        {
            get
            {
                if (_answerDetailMap == null)
                {
                    _answerDetailMap = new Dictionary<Guid, ISCMOrderDetailRecord>();
                }
                return _answerDetailMap;
            }
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^(��)�̃��R�[�h��ǉ����܂��B
        /// </summary>
        /// <param name="scmAnswerRecord">SCM�󒍖��׃f�[�^(��)�̃��R�[�h</param>
        /// <param name="sourceDetailRecord">���ƂȂ���SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</param>
        /// <exception cref="ArgumentNullException">
        /// �ǉ�����SCM�󒍖��׃f�[�^(��)�̃��R�[�h��null�ł��B<br/>
        /// ���ƂȂ���SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h��null�ł��B
        /// </exception>
        public void AddSCMAnswerRecord(
            ISCMOrderAnswerRecord scmAnswerRecord,
            ISCMOrderDetailRecord sourceDetailRecord
        )
        {
            #region <Guard Phrase>

            if (scmAnswerRecord == null)
            {
                throw new ArgumentNullException("scmAnswerRecord", "�ǉ�����SCM�󒍖��׃f�[�^(��)�̃��R�[�h��null�ł��B");
            }
            if (sourceDetailRecord == null)
            {
                throw new ArgumentNullException("sourceDetailRecord", "���ƂȂ���SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h��null�ł��B");
            }

            #endregion // </Guard Phrase>

            SCMAnswerRecordList.Add(scmAnswerRecord);

            // SCM�󒍖��׃f�[�^(��)��SCM�󒍖��׃f�[�^(�⍇���E����)�̃}�b�v�ɒǉ�
            if (!AnswerDetailMap.ContainsKey(scmAnswerRecord.SalesRelationId))
            {
                AnswerDetailMap.Add(scmAnswerRecord.SalesRelationId, sourceDetailRecord);
            }
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h���擾���܂��B
        /// </summary>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)�̃��R�[�h</param>
        /// <returns>�Ή�����SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</returns>
        private ISCMOrderDetailRecord GetSCMDetailRecord(ISCMOrderAnswerRecord answerRecord)
        {
            if (AnswerDetailMap.ContainsKey(answerRecord.SalesRelationId))
            {
                return AnswerDetailMap[answerRecord.SalesRelationId];
            }
            return null;
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^(��)�̔����q�𐶐����܂��B
        /// </summary>
        /// <returns>SCM�󒍖��׃f�[�^(��)�̔����q</returns>
        public ListIterator<ISCMOrderAnswerRecord> CreateSCMAnswerIterator()
        {
            return new ListIterator<ISCMOrderAnswerRecord>(SCMAnswerRecordList);
        }

        #endregion // <SCM�󒍖��׃f�[�^(��)>

        // -- ADD 2011/08/10   ------ >>>>>>
        #region <SCM�Z�b�g���i�f�[�^>

        /// <summary>
        /// SCM�Z�b�g���i�f�[�^�̃��R�[�h�̃��X�g
        /// </summary>
        private IList<ISCMAcOdSetDtRecord> _scmSetDtRecordList;

        /// <summary>
        /// SCM�Z�b�g���i�f�[�^�̃��R�[�h�̃��X�g���擾���܂��B
        /// </summary>
        private IList<ISCMAcOdSetDtRecord> SCMSetDtRecordList
        {
            get
            {
                if (_scmSetDtRecordList == null)
                {
                    _scmSetDtRecordList = new List<ISCMAcOdSetDtRecord>();
                }
                return _scmSetDtRecordList;
            }
        }

        /// <summary>
        /// SCM�Z�b�g���i�f�[�^�̃��R�[�h��ǉ����܂��B
        /// </summary>
        /// <param name="scmSetDtRecord">SCM�Z�b�g���i�f�[�^�̃��R�[�h</param>
        /// <exception cref="ArgumentNullException">
        /// �ǉ�����SCM�Z�b�g���i�f�[�^�̃��R�[�h��null�ł��B<br/>
        /// </exception>
        public void AddSCMSetRecord(ISCMAcOdSetDtRecord scmSetDtRecord)
        {
            #region <Guard Phrase>

            if (scmSetDtRecord == null)
            {
                throw new ArgumentNullException("scmSetDtRecord", "�ǉ�����Z�b�g���i�f�[�^�̃��R�[�h��null�ł��B");
            }
                
            #endregion // </Guard Phrase>

            SCMSetDtRecordList.Add(scmSetDtRecord);
        }

        /// <summary>
        /// SCM�Z�b�g���i�f�[�^�̔����q�𐶐����܂��B
        /// </summary>
        /// <returns>�Z�b�g���i�f�[�^�̔����q</returns>
        public ListIterator<ISCMAcOdSetDtRecord> CreateSCMSetDtIterator()
        {
            return new ListIterator<ISCMAcOdSetDtRecord>(SCMSetDtRecordList);
        }

        /// <summary>
        /// SCM�󒍃Z�b�g���i�f�[�^�̃��R�[�h���擾���܂��B
        /// </summary>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)</param>
        /// <returns>�Ή�����SCM�󒍃Z�b�g�f�[�^(��)�̃��R�[�h</returns>
        protected List<ISCMAcOdSetDtRecord> GetSCMSetRecord(ISCMOrderAnswerRecord answerRecord)
        {
            return SetDetailMap[answerRecord.SalesRelationId];
        }
        #endregion // <SCM�Z�b�g���i�f�[�^>
        // -- ADD 2011/08/10   ------ <<<<<<

        // ADD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j ---------------------------------->>>>>
        #region <���i�Z�o�N���X>
        private SCMPriceCalculator _priceCalculator;

        /// <summary>
        /// ���i�Z�o�N���X
        /// </summary>
        public SCMPriceCalculator PriceCalculator
        {
            get
            {
                if (this._priceCalculator == null)
                {
                    this._priceCalculator = new SCMPriceCalculator();
                }
                return this._priceCalculator;
            }
            set
            {
                this._priceCalculator = value;
            }
        }
        #endregion // <SCM�Z�b�g���i�f�[�^>
        // ADD 2014/05/08 PM-SCM���x���� �t�F�[�Y�Q��06.���Ӑ�}�X�^�擾���ǑΉ��i���z�v�Z�N���X�j ----------------------------------<<<<<

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        protected SCMSalesListEssence() { }

        #endregion // </Constructor>

        #region <USB�̃I�v�V����>

        /// <summary>
        /// USB�̃I�v�V�������擾���܂��B
        /// </summary>
        private static USBOptionAgent USBOption
        {
            get { return USBOptionServer.Singleton.Instance; }
        }

        #endregion // </USB�̃I�v�V����>

        #region <�`�[����ݒ�}�X�^>

        /// <summary>
        /// �`�[����ݒ�}�X�^���擾���܂��B
        /// </summary>
        private static SlipPrtSetAgent SlipPrtSetDB
        {
            get { return SlipPrtSetServer.Singleton.Instance; }
        }

        #endregion // </�`�[����ݒ�}�X�^>

        #region <�����[�g�p���[�N�f�[�^>

        #region <����f�[�^���[�N>

        /// <summary>
        /// �����[�g�p����f�[�^�𐶐����܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>�����[�g�p����f�[�^</returns>
        protected static SalesSlipWork CreateSalesSlipWork(SalesSlip salesSlip)
        {
            SalesSlipWork salesSlipWork = new SalesSlipWork();
            {
                salesSlipWork.CreateDateTime = salesSlip.CreateDateTime; // �쐬����
                salesSlipWork.UpdateDateTime = salesSlip.UpdateDateTime; // �X�V����
                salesSlipWork.EnterpriseCode = salesSlip.EnterpriseCode; // ��ƃR�[�h
                salesSlipWork.FileHeaderGuid = salesSlip.FileHeaderGuid; // GUID
                salesSlipWork.UpdEmployeeCode = salesSlip.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                salesSlipWork.UpdAssemblyId1 = salesSlip.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                salesSlipWork.UpdAssemblyId2 = salesSlip.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                salesSlipWork.LogicalDeleteCode = salesSlip.LogicalDeleteCode; // �_���폜�敪
                salesSlipWork.AcptAnOdrStatus = salesSlip.AcptAnOdrStatus; // �󒍃X�e�[�^�X
                salesSlipWork.SalesSlipNum = salesSlip.SalesSlipNum; // ����`�[�ԍ�
                salesSlipWork.SectionCode = salesSlip.SectionCode; // ���_�R�[�h
                salesSlipWork.SubSectionCode = salesSlip.SubSectionCode; // ����R�[�h
                salesSlipWork.DebitNoteDiv = salesSlip.DebitNoteDiv; // �ԓ`�敪
                salesSlipWork.DebitNLnkSalesSlNum = salesSlip.DebitNLnkSalesSlNum; // �ԍ��A������`�[�ԍ�
                salesSlipWork.SalesSlipCd = salesSlip.SalesSlipCd; // ����`�[�敪
                salesSlipWork.SalesGoodsCd = salesSlip.SalesGoodsCd; // ���㏤�i�敪
                salesSlipWork.AccRecDivCd = salesSlip.AccRecDivCd; // ���|�敪
                salesSlipWork.SalesInpSecCd = salesSlip.SalesInpSecCd; // ������͋��_�R�[�h
                salesSlipWork.DemandAddUpSecCd = salesSlip.DemandAddUpSecCd; // �����v�㋒�_�R�[�h
                salesSlipWork.ResultsAddUpSecCd = salesSlip.ResultsAddUpSecCd; // ���ьv�㋒�_�R�[�h
                salesSlipWork.UpdateSecCd = salesSlip.UpdateSecCd; // �X�V���_�R�[�h
                salesSlipWork.SalesSlipUpdateCd = salesSlip.SalesSlipUpdateCd; // ����`�[�X�V�敪
                salesSlipWork.SearchSlipDate = salesSlip.SearchSlipDate; // �`�[�������t
                salesSlipWork.ShipmentDay = salesSlip.ShipmentDay; // �o�ד��t
                salesSlipWork.SalesDate = salesSlip.SalesDate; // ������t
                salesSlipWork.AddUpADate = salesSlip.AddUpADate; // �v����t
                salesSlipWork.DelayPaymentDiv = salesSlip.DelayPaymentDiv; // �����敪
                salesSlipWork.EstimateFormNo = salesSlip.EstimateFormNo; // ���Ϗ��ԍ�
                salesSlipWork.EstimateDivide = salesSlip.EstimateDivide; // ���ϋ敪
                salesSlipWork.InputAgenCd = salesSlip.InputAgenCd; // ���͒S���҃R�[�h
                salesSlipWork.InputAgenNm = salesSlip.InputAgenNm; // ���͒S���Җ���
                salesSlipWork.SalesInputCode = salesSlip.SalesInputCode; // ������͎҃R�[�h
                salesSlipWork.SalesInputName = salesSlip.SalesInputName; // ������͎Җ���
                salesSlipWork.FrontEmployeeCd = salesSlip.FrontEmployeeCd; // ��t�]�ƈ��R�[�h
                salesSlipWork.FrontEmployeeNm = salesSlip.FrontEmployeeNm; // ��t�]�ƈ�����
                salesSlipWork.SalesEmployeeCd = salesSlip.SalesEmployeeCd; // �̔��]�ƈ��R�[�h
                salesSlipWork.SalesEmployeeNm = salesSlip.SalesEmployeeNm; // �̔��]�ƈ�����
                salesSlipWork.TotalAmountDispWayCd = salesSlip.TotalAmountDispWayCd; // ���z�\�����@�敪
                salesSlipWork.TtlAmntDispRateApy = salesSlip.TtlAmntDispRateApy; // ���z�\���|���K�p�敪
                salesSlipWork.SalesTotalTaxInc = salesSlip.SalesTotalTaxInc; // ����`�[���v�i�ō��݁j
                salesSlipWork.SalesTotalTaxExc = salesSlip.SalesTotalTaxExc; // ����`�[���v�i�Ŕ����j
                salesSlipWork.SalesPrtTotalTaxInc = salesSlip.SalesPrtTotalTaxInc; // ���㕔�i���v�i�ō��݁j
                salesSlipWork.SalesPrtTotalTaxExc = salesSlip.SalesPrtTotalTaxExc; // ���㕔�i���v�i�Ŕ����j
                salesSlipWork.SalesWorkTotalTaxInc = salesSlip.SalesWorkTotalTaxInc; // �����ƍ��v�i�ō��݁j
                salesSlipWork.SalesWorkTotalTaxExc = salesSlip.SalesWorkTotalTaxExc; // �����ƍ��v�i�Ŕ����j
                salesSlipWork.SalesSubtotalTaxInc = salesSlip.SalesSubtotalTaxInc; // ���㏬�v�i�ō��݁j
                salesSlipWork.SalesSubtotalTaxExc = salesSlip.SalesSubtotalTaxExc; // ���㏬�v�i�Ŕ����j
                salesSlipWork.SalesPrtSubttlInc = salesSlip.SalesPrtSubttlInc; // ���㕔�i���v�i�ō��݁j
                salesSlipWork.SalesPrtSubttlExc = salesSlip.SalesPrtSubttlExc; // ���㕔�i���v�i�Ŕ����j
                salesSlipWork.SalesWorkSubttlInc = salesSlip.SalesWorkSubttlInc; // �����Ə��v�i�ō��݁j
                salesSlipWork.SalesWorkSubttlExc = salesSlip.SalesWorkSubttlExc; // �����Ə��v�i�Ŕ����j
                salesSlipWork.SalesNetPrice = salesSlip.SalesNetPrice; // ���㐳�����z
                salesSlipWork.SalesSubtotalTax = salesSlip.SalesSubtotalTax; // ���㏬�v�i�Łj
                salesSlipWork.ItdedSalesOutTax = salesSlip.ItdedSalesOutTax; // ����O�őΏۊz
                salesSlipWork.ItdedSalesInTax = salesSlip.ItdedSalesInTax; // ������őΏۊz
                salesSlipWork.SalSubttlSubToTaxFre = salesSlip.SalSubttlSubToTaxFre; // ���㏬�v��ېőΏۊz
                salesSlipWork.SalesOutTax = salesSlip.SalesOutTax; // ������z����Ŋz�i�O�Łj
                salesSlipWork.SalAmntConsTaxInclu = salesSlip.SalAmntConsTaxInclu; // ������z����Ŋz�i���Łj
                salesSlipWork.SalesDisTtlTaxExc = salesSlip.SalesDisTtlTaxExc; // ����l�����z�v�i�Ŕ����j
                salesSlipWork.ItdedSalesDisOutTax = salesSlip.ItdedSalesDisOutTax; // ����l���O�őΏۊz���v
                salesSlipWork.ItdedSalesDisInTax = salesSlip.ItdedSalesDisInTax; // ����l�����őΏۊz���v
                salesSlipWork.ItdedPartsDisOutTax = salesSlip.ItdedPartsDisOutTax; // ���i�l���Ώۊz���v�i�Ŕ����j
                salesSlipWork.ItdedPartsDisInTax = salesSlip.ItdedPartsDisInTax; // ���i�l���Ώۊz���v�i�ō��݁j
                salesSlipWork.ItdedWorkDisOutTax = salesSlip.ItdedWorkDisOutTax; // ��ƒl���Ώۊz���v�i�Ŕ����j
                salesSlipWork.ItdedWorkDisInTax = salesSlip.ItdedWorkDisInTax; // ��ƒl���Ώۊz���v�i�ō��݁j
                salesSlipWork.ItdedSalesDisTaxFre = salesSlip.ItdedSalesDisTaxFre; // ����l����ېőΏۊz���v
                salesSlipWork.SalesDisOutTax = salesSlip.SalesDisOutTax; // ����l������Ŋz�i�O�Łj
                salesSlipWork.SalesDisTtlTaxInclu = salesSlip.SalesDisTtlTaxInclu; // ����l������Ŋz�i���Łj
                salesSlipWork.PartsDiscountRate = salesSlip.PartsDiscountRate; // ���i�l����
                salesSlipWork.RavorDiscountRate = salesSlip.RavorDiscountRate; // �H���l����
                salesSlipWork.TotalCost = salesSlip.TotalCost; // �������z�v
                salesSlipWork.ConsTaxLayMethod = salesSlip.ConsTaxLayMethod; // ����œ]�ŕ���
                salesSlipWork.ConsTaxRate = salesSlip.ConsTaxRate; // ����Őŗ�
                salesSlipWork.FractionProcCd = salesSlip.FractionProcCd; // �[�������敪
                salesSlipWork.AccRecConsTax = salesSlip.AccRecConsTax; // ���|�����
                salesSlipWork.AutoDepositCd = salesSlip.AutoDepositCd; // ���������敪
                salesSlipWork.AutoDepositSlipNo = salesSlip.AutoDepositSlipNo; // ���������`�[�ԍ�
                salesSlipWork.DepositAllowanceTtl = salesSlip.DepositAllowanceTtl; // �����������v�z
                salesSlipWork.DepositAlwcBlnce = salesSlip.DepositAlwcBlnce; // ���������c��
                salesSlipWork.ClaimCode = salesSlip.ClaimCode; // ������R�[�h
                salesSlipWork.ClaimSnm = salesSlip.ClaimSnm; // �����旪��
                salesSlipWork.CustomerCode = salesSlip.CustomerCode; // ���Ӑ�R�[�h
                salesSlipWork.CustomerName = salesSlip.CustomerName; // ���Ӑ於��
                salesSlipWork.CustomerName2 = salesSlip.CustomerName2; // ���Ӑ於��2
                salesSlipWork.CustomerSnm = salesSlip.CustomerSnm; // ���Ӑ旪��
                salesSlipWork.HonorificTitle = salesSlip.HonorificTitle; // �h��
                salesSlipWork.OutputNameCode = salesSlip.OutputNameCode; // �����R�[�h
                salesSlipWork.OutputName = salesSlip.OutputName; // ��������
                salesSlipWork.CustSlipNo = salesSlip.CustSlipNo; // ���Ӑ�`�[�ԍ�
                salesSlipWork.SlipAddressDiv = salesSlip.SlipAddressDiv; // �`�[�Z���敪
                salesSlipWork.AddresseeCode = salesSlip.AddresseeCode; // �[�i��R�[�h
                salesSlipWork.AddresseeName = salesSlip.AddresseeName; // �[�i�於��
                salesSlipWork.AddresseeName2 = salesSlip.AddresseeName2; // �[�i�於��2
                salesSlipWork.AddresseePostNo = salesSlip.AddresseePostNo; // �[�i��X�֔ԍ�
                salesSlipWork.AddresseeAddr1 = salesSlip.AddresseeAddr1; // �[�i��Z��1(�s���{���s��S�E�����E��)
                salesSlipWork.AddresseeAddr3 = salesSlip.AddresseeAddr3; // �[�i��Z��3(�Ԓn)
                salesSlipWork.AddresseeAddr4 = salesSlip.AddresseeAddr4; // �[�i��Z��4(�A�p�[�g����)
                salesSlipWork.AddresseeTelNo = salesSlip.AddresseeTelNo; // �[�i��d�b�ԍ�
                salesSlipWork.AddresseeFaxNo = salesSlip.AddresseeFaxNo; // �[�i��FAX�ԍ�
                salesSlipWork.PartySaleSlipNum = salesSlip.PartySaleSlipNum; // �����`�[�ԍ�
                salesSlipWork.SlipNote = salesSlip.SlipNote; // �`�[���l
                salesSlipWork.SlipNote2 = salesSlip.SlipNote2; // �`�[���l�Q
                salesSlipWork.SlipNote3 = salesSlip.SlipNote3; // �`�[���l�R
                salesSlipWork.RetGoodsReasonDiv = salesSlip.RetGoodsReasonDiv; // �ԕi���R�R�[�h
                salesSlipWork.RetGoodsReason = salesSlip.RetGoodsReason; // �ԕi���R
                salesSlipWork.RegiProcDate = salesSlip.RegiProcDate; // ���W������
                salesSlipWork.CashRegisterNo = salesSlip.CashRegisterNo; // ���W�ԍ�
                salesSlipWork.PosReceiptNo = salesSlip.PosReceiptNo; // POS���V�[�g�ԍ�
                salesSlipWork.DetailRowCount = salesSlip.DetailRowCount; // ���׍s��
                salesSlipWork.EdiSendDate = salesSlip.EdiSendDate; // �d�c�h���M��
                salesSlipWork.EdiTakeInDate = salesSlip.EdiTakeInDate; // �d�c�h�捞��
                salesSlipWork.UoeRemark1 = salesSlip.UoeRemark1; // �t�n�d���}�[�N�P
                salesSlipWork.UoeRemark2 = salesSlip.UoeRemark2; // �t�n�d���}�[�N�Q
                salesSlipWork.SlipPrintDivCd = salesSlip.SlipPrintDivCd; // �`�[���s�敪
                salesSlipWork.SlipPrintFinishCd = salesSlip.SlipPrintFinishCd; // �`�[���s�ϋ敪
                salesSlipWork.SalesSlipPrintDate = salesSlip.SalesSlipPrintDate; // ����`�[���s��
                salesSlipWork.BusinessTypeCode = salesSlip.BusinessTypeCode; // �Ǝ�R�[�h
                salesSlipWork.BusinessTypeName = salesSlip.BusinessTypeName; // �Ǝ햼��
                salesSlipWork.OrderNumber = salesSlip.OrderNumber; // �����ԍ�
                salesSlipWork.DeliveredGoodsDiv = salesSlip.DeliveredGoodsDiv; // �[�i�敪
                salesSlipWork.DeliveredGoodsDivNm = salesSlip.DeliveredGoodsDivNm; // �[�i�敪����
                salesSlipWork.SalesAreaCode = salesSlip.SalesAreaCode; // �̔��G���A�R�[�h
                salesSlipWork.SalesAreaName = salesSlip.SalesAreaName; // �̔��G���A����
                salesSlipWork.ReconcileFlag = salesSlip.ReconcileFlag; // �����t���O
                salesSlipWork.SlipPrtSetPaperId = salesSlip.SlipPrtSetPaperId; // �`�[����ݒ�p���[ID
                salesSlipWork.CompleteCd = salesSlip.CompleteCd; // �ꎮ�`�[�敪
                salesSlipWork.SalesPriceFracProcCd = salesSlip.SalesPriceFracProcCd; // ������z�[�������敪
                salesSlipWork.StockGoodsTtlTaxExc = salesSlip.StockGoodsTtlTaxExc; // �݌ɏ��i���v���z�i�Ŕ��j
                salesSlipWork.PureGoodsTtlTaxExc = salesSlip.PureGoodsTtlTaxExc; // �������i���v���z�i�Ŕ��j
                salesSlipWork.ListPricePrintDiv = salesSlip.ListPricePrintDiv; // �艿����敪
                salesSlipWork.EraNameDispCd1 = salesSlip.EraNameDispCd1; // �����\���敪�P
                salesSlipWork.EstimaTaxDivCd = salesSlip.EstimaTaxDivCd; // ���Ϗ���ŋ敪
                salesSlipWork.EstimateFormPrtCd = salesSlip.EstimateFormPrtCd; // ���Ϗ�����敪
                salesSlipWork.EstimateSubject = salesSlip.EstimateSubject; // ���ό���
                salesSlipWork.Footnotes1 = salesSlip.Footnotes1; // �r���P
                salesSlipWork.Footnotes2 = salesSlip.Footnotes2; // �r���Q
                salesSlipWork.EstimateTitle1 = salesSlip.EstimateTitle1; // ���σ^�C�g���P
                salesSlipWork.EstimateTitle2 = salesSlip.EstimateTitle2; // ���σ^�C�g���Q
                salesSlipWork.EstimateTitle3 = salesSlip.EstimateTitle3; // ���σ^�C�g���R
                salesSlipWork.EstimateTitle4 = salesSlip.EstimateTitle4; // ���σ^�C�g���S
                salesSlipWork.EstimateTitle5 = salesSlip.EstimateTitle5; // ���σ^�C�g���T
                salesSlipWork.EstimateNote1 = salesSlip.EstimateNote1; // ���ϔ��l�P
                salesSlipWork.EstimateNote2 = salesSlip.EstimateNote2; // ���ϔ��l�Q
                salesSlipWork.EstimateNote3 = salesSlip.EstimateNote3; // ���ϔ��l�R
                salesSlipWork.EstimateNote4 = salesSlip.EstimateNote4; // ���ϔ��l�S
                salesSlipWork.EstimateNote5 = salesSlip.EstimateNote5; // ���ϔ��l�T
                salesSlipWork.EstimateValidityDate = salesSlip.EstimateValidityDate; // ���ϗL������
                salesSlipWork.PartsNoPrtCd = salesSlip.PartsNoPrtCd; // �i�Ԉ󎚋敪
                salesSlipWork.OptionPringDivCd = salesSlip.OptionPringDivCd; // �I�v�V�����󎚋敪
                salesSlipWork.RateUseCode = salesSlip.RateUseCode; // �|���g�p�敪
            }
            return salesSlipWork;
        }

        #endregion // </����f�[�^���[�N>

        #region <���㖾�׃f�[�^���[�N>

        /// <summary>
        /// �����[�g�p���㖾�׃f�[�^�𐶐����܂��B
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <returns>�����[�g�p���㖾�׃f�[�^</returns>
        protected static SalesDetailWork CreateSalesDetailWork(SalesDetail salesDetail)
        {
            SalesDetailWork salesDetailWork = new SalesDetailWork();
            {
                salesDetailWork.CreateDateTime = salesDetail.CreateDateTime; // �쐬����
                salesDetailWork.UpdateDateTime = salesDetail.UpdateDateTime; // �X�V����
                salesDetailWork.EnterpriseCode = salesDetail.EnterpriseCode; // ��ƃR�[�h
                salesDetailWork.FileHeaderGuid = salesDetail.FileHeaderGuid; // GUID
                salesDetailWork.UpdEmployeeCode = salesDetail.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                salesDetailWork.UpdAssemblyId1 = salesDetail.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                salesDetailWork.UpdAssemblyId2 = salesDetail.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                salesDetailWork.LogicalDeleteCode = salesDetail.LogicalDeleteCode; // �_���폜�敪
                salesDetailWork.AcceptAnOrderNo = salesDetail.AcceptAnOrderNo; // �󒍔ԍ�
                salesDetailWork.AcptAnOdrStatus = salesDetail.AcptAnOdrStatus; // �󒍃X�e�[�^�X
                salesDetailWork.SalesSlipNum = salesDetail.SalesSlipNum; // ����`�[�ԍ�
                salesDetailWork.SalesRowNo = salesDetail.SalesRowNo; // ����s�ԍ�
                salesDetailWork.SalesRowDerivNo = salesDetail.SalesRowDerivNo; // ����s�ԍ��}��
                salesDetailWork.SectionCode = salesDetail.SectionCode; // ���_�R�[�h
                salesDetailWork.SubSectionCode = salesDetail.SubSectionCode; // ����R�[�h
                salesDetailWork.SalesDate = salesDetail.SalesDate; // ������t
                salesDetailWork.CommonSeqNo = salesDetail.CommonSeqNo; // ���ʒʔ�
                salesDetailWork.SalesSlipDtlNum = salesDetail.SalesSlipDtlNum; // ���㖾�גʔ�
                salesDetailWork.AcptAnOdrStatusSrc = salesDetail.AcptAnOdrStatusSrc; // �󒍃X�e�[�^�X�i���j
                salesDetailWork.SalesSlipDtlNumSrc = salesDetail.SalesSlipDtlNumSrc; // ���㖾�גʔԁi���j
                salesDetailWork.SupplierFormalSync = salesDetail.SupplierFormalSync; // �d���`���i�����j
                salesDetailWork.StockSlipDtlNumSync = salesDetail.StockSlipDtlNumSync; // �d�����גʔԁi�����j
                salesDetailWork.SalesSlipCdDtl = salesDetail.SalesSlipCdDtl; // ����`�[�敪�i���ׁj
                salesDetailWork.DeliGdsCmpltDueDate = salesDetail.DeliGdsCmpltDueDate; // �[�i�����\���
                salesDetailWork.GoodsKindCode = salesDetail.GoodsKindCode; // ���i����
                salesDetailWork.GoodsSearchDivCd = salesDetail.GoodsSearchDivCd; // ���i�����敪
                salesDetailWork.GoodsMakerCd = salesDetail.GoodsMakerCd; // ���i���[�J�[�R�[�h
                salesDetailWork.MakerName = salesDetail.MakerName; // ���[�J�[����
                salesDetailWork.MakerKanaName = salesDetail.MakerKanaName; // ���[�J�[�J�i����
                salesDetailWork.CmpltMakerKanaName = salesDetail.CmpltMakerKanaName; // ���[�J�[�J�i���́i�ꎮ�j
                salesDetailWork.GoodsNo = salesDetail.GoodsNo; // ���i�ԍ�
                salesDetailWork.GoodsName = salesDetail.GoodsName; // ���i����
                salesDetailWork.GoodsNameKana = salesDetail.GoodsNameKana; // ���i���̃J�i
                salesDetailWork.GoodsLGroup = salesDetail.GoodsLGroup; // ���i�啪�ރR�[�h
                salesDetailWork.GoodsLGroupName = salesDetail.GoodsLGroupName; // ���i�啪�ޖ���
                salesDetailWork.GoodsMGroup = salesDetail.GoodsMGroup; // ���i�����ރR�[�h
                salesDetailWork.GoodsMGroupName = salesDetail.GoodsMGroupName; // ���i�����ޖ���
                salesDetailWork.BLGroupCode = salesDetail.BLGroupCode; // BL�O���[�v�R�[�h
                salesDetailWork.BLGroupName = salesDetail.BLGroupName; // BL�O���[�v�R�[�h����
                salesDetailWork.BLGoodsCode = salesDetail.BLGoodsCode; // BL���i�R�[�h
                salesDetailWork.BLGoodsFullName = salesDetail.BLGoodsFullName; // BL���i�R�[�h���́i�S�p�j
                salesDetailWork.EnterpriseGanreCode = salesDetail.EnterpriseGanreCode; // ���Е��ރR�[�h
                salesDetailWork.EnterpriseGanreName = salesDetail.EnterpriseGanreName; // ���Е��ޖ���
                salesDetailWork.WarehouseCode = salesDetail.WarehouseCode; // �q�ɃR�[�h
                salesDetailWork.WarehouseName = salesDetail.WarehouseName; // �q�ɖ���
                salesDetailWork.WarehouseShelfNo = salesDetail.WarehouseShelfNo; // �q�ɒI��
                salesDetailWork.SalesOrderDivCd = salesDetail.SalesOrderDivCd; // ����݌Ɏ�񂹋敪
                salesDetailWork.OpenPriceDiv = salesDetail.OpenPriceDiv; // �I�[�v�����i�敪
                salesDetailWork.GoodsRateRank = salesDetail.GoodsRateRank; // ���i�|�������N
                salesDetailWork.CustRateGrpCode = salesDetail.CustRateGrpCode; // ���Ӑ�|���O���[�v�R�[�h
                salesDetailWork.ListPriceRate = salesDetail.ListPriceRate; // �艿��
                salesDetailWork.RateSectPriceUnPrc = salesDetail.RateSectPriceUnPrc; // �|���ݒ苒�_�i�艿�j
                salesDetailWork.RateDivLPrice = salesDetail.RateDivLPrice; // �|���ݒ�敪�i�艿�j
                salesDetailWork.UnPrcCalcCdLPrice = salesDetail.UnPrcCalcCdLPrice; // �P���Z�o�敪�i�艿�j
                salesDetailWork.PriceCdLPrice = salesDetail.PriceCdLPrice; // ���i�敪�i�艿�j
                salesDetailWork.StdUnPrcLPrice = salesDetail.StdUnPrcLPrice; // ��P���i�艿�j
                salesDetailWork.FracProcUnitLPrice = salesDetail.FracProcUnitLPrice; // �[�������P�ʁi�艿�j
                salesDetailWork.FracProcLPrice = salesDetail.FracProcLPrice; // �[�������i�艿�j
                salesDetailWork.ListPriceTaxIncFl = salesDetail.ListPriceTaxIncFl; // �艿�i�ō��C�����j
                salesDetailWork.ListPriceTaxExcFl = salesDetail.ListPriceTaxExcFl; // �艿�i�Ŕ��C�����j
                salesDetailWork.ListPriceChngCd = salesDetail.ListPriceChngCd; // �艿�ύX�敪
                salesDetailWork.SalesRate = salesDetail.SalesRate; // ������
                salesDetailWork.RateSectSalUnPrc = salesDetail.RateSectSalUnPrc; // �|���ݒ苒�_�i����P���j
                salesDetailWork.RateDivSalUnPrc = salesDetail.RateDivSalUnPrc; // �|���ݒ�敪�i����P���j
                salesDetailWork.UnPrcCalcCdSalUnPrc = salesDetail.UnPrcCalcCdSalUnPrc; // �P���Z�o�敪�i����P���j
                salesDetailWork.PriceCdSalUnPrc = salesDetail.PriceCdSalUnPrc; // ���i�敪�i����P���j
                salesDetailWork.StdUnPrcSalUnPrc = salesDetail.StdUnPrcSalUnPrc; // ��P���i����P���j
                salesDetailWork.FracProcUnitSalUnPrc = salesDetail.FracProcUnitSalUnPrc; // �[�������P�ʁi����P���j
                salesDetailWork.FracProcSalUnPrc = salesDetail.FracProcSalUnPrc; // �[�������i����P���j
                salesDetailWork.SalesUnPrcTaxIncFl = salesDetail.SalesUnPrcTaxIncFl; // ����P���i�ō��C�����j
                salesDetailWork.SalesUnPrcTaxExcFl = salesDetail.SalesUnPrcTaxExcFl; // ����P���i�Ŕ��C�����j
                salesDetailWork.SalesUnPrcChngCd = salesDetail.SalesUnPrcChngCd; // ����P���ύX�敪
                salesDetailWork.CostRate = salesDetail.CostRate; // ������
                salesDetailWork.RateSectCstUnPrc = salesDetail.RateSectCstUnPrc; // �|���ݒ苒�_�i�����P���j
                salesDetailWork.RateDivUnCst = salesDetail.RateDivUnCst; // �|���ݒ�敪�i�����P���j
                salesDetailWork.UnPrcCalcCdUnCst = salesDetail.UnPrcCalcCdUnCst; // �P���Z�o�敪�i�����P���j
                salesDetailWork.PriceCdUnCst = salesDetail.PriceCdUnCst; // ���i�敪�i�����P���j
                salesDetailWork.StdUnPrcUnCst = salesDetail.StdUnPrcUnCst; // ��P���i�����P���j
                salesDetailWork.FracProcUnitUnCst = salesDetail.FracProcUnitUnCst; // �[�������P�ʁi�����P���j
                salesDetailWork.FracProcUnCst = salesDetail.FracProcUnCst; // �[�������i�����P���j
                salesDetailWork.SalesUnitCost = salesDetail.SalesUnitCost; // �����P��
                salesDetailWork.SalesUnitCostChngDiv = salesDetail.SalesUnitCostChngDiv; // �����P���ύX�敪
                salesDetailWork.RateBLGoodsCode = salesDetail.RateBLGoodsCode; // BL���i�R�[�h�i�|���j
                salesDetailWork.RateBLGoodsName = salesDetail.RateBLGoodsName; // BL���i�R�[�h���́i�|���j
                salesDetailWork.RateGoodsRateGrpCd = salesDetail.RateGoodsRateGrpCd; // ���i�|���O���[�v�R�[�h�i�|���j
                salesDetailWork.RateGoodsRateGrpNm = salesDetail.RateGoodsRateGrpNm; // ���i�|���O���[�v���́i�|���j
                salesDetailWork.RateBLGroupCode = salesDetail.RateBLGroupCode; // BL�O���[�v�R�[�h�i�|���j
                salesDetailWork.RateBLGroupName = salesDetail.RateBLGroupName; // BL�O���[�v���́i�|���j
                salesDetailWork.PrtBLGoodsCode = salesDetail.PrtBLGoodsCode; // BL���i�R�[�h�i����j
                salesDetailWork.PrtBLGoodsName = salesDetail.PrtBLGoodsName; // BL���i�R�[�h���́i����j
                salesDetailWork.SalesCode = salesDetail.SalesCode; // �̔��敪�R�[�h
                salesDetailWork.SalesCdNm = salesDetail.SalesCdNm; // �̔��敪����
                salesDetailWork.WorkManHour = salesDetail.WorkManHour; // ��ƍH��
                salesDetailWork.ShipmentCnt = salesDetail.ShipmentCnt; // �o�א�
                salesDetailWork.AcceptAnOrderCnt = salesDetail.AcceptAnOrderCnt; // �󒍐���
                salesDetailWork.AcptAnOdrAdjustCnt = salesDetail.AcptAnOdrAdjustCnt; // �󒍒�����
                salesDetailWork.AcptAnOdrRemainCnt = salesDetail.AcptAnOdrRemainCnt; // �󒍎c��
                salesDetailWork.RemainCntUpdDate = salesDetail.RemainCntUpdDate; // �c���X�V��
                salesDetailWork.SalesMoneyTaxInc = salesDetail.SalesMoneyTaxInc; // ������z�i�ō��݁j
                salesDetailWork.SalesMoneyTaxExc = salesDetail.SalesMoneyTaxExc; // ������z�i�Ŕ����j
                salesDetailWork.Cost = salesDetail.Cost; // ����
                salesDetailWork.GrsProfitChkDiv = salesDetail.GrsProfitChkDiv; // �e���`�F�b�N�敪
                salesDetailWork.SalesGoodsCd = salesDetail.SalesGoodsCd; // ���㏤�i�敪
                salesDetailWork.SalesPriceConsTax = salesDetail.SalesPriceConsTax; // ������z����Ŋz
                salesDetailWork.TaxationDivCd = salesDetail.TaxationDivCd; // �ېŋ敪
                salesDetailWork.PartySlipNumDtl = salesDetail.PartySlipNumDtl; // �����`�[�ԍ��i���ׁj
                salesDetailWork.DtlNote = salesDetail.DtlNote; // ���ה��l
                salesDetailWork.SupplierCd = salesDetail.SupplierCd; // �d����R�[�h
                salesDetailWork.SupplierSnm = salesDetail.SupplierSnm; // �d���旪��
                salesDetailWork.OrderNumber = salesDetail.OrderNumber; // �����ԍ�
                salesDetailWork.WayToOrder = salesDetail.WayToOrder; // �������@
                salesDetailWork.SlipMemo1 = salesDetail.SlipMemo1; // �`�[�����P
                salesDetailWork.SlipMemo2 = salesDetail.SlipMemo2; // �`�[�����Q
                salesDetailWork.SlipMemo3 = salesDetail.SlipMemo3; // �`�[�����R
                salesDetailWork.InsideMemo1 = salesDetail.InsideMemo1; // �Г������P
                salesDetailWork.InsideMemo2 = salesDetail.InsideMemo2; // �Г������Q
                salesDetailWork.InsideMemo3 = salesDetail.InsideMemo3; // �Г������R
                salesDetailWork.BfListPrice = salesDetail.BfListPrice; // �ύX�O�艿
                salesDetailWork.BfSalesUnitPrice = salesDetail.BfSalesUnitPrice; // �ύX�O����
                salesDetailWork.BfUnitCost = salesDetail.BfUnitCost; // �ύX�O����
                salesDetailWork.CmpltSalesRowNo = salesDetail.CmpltSalesRowNo; // �ꎮ���הԍ�
                salesDetailWork.CmpltGoodsMakerCd = salesDetail.CmpltGoodsMakerCd; // ���[�J�[�R�[�h�i�ꎮ�j
                salesDetailWork.CmpltMakerName = salesDetail.CmpltMakerName; // ���[�J�[���́i�ꎮ�j
                salesDetailWork.CmpltGoodsName = salesDetail.CmpltGoodsName; // ���i���́i�ꎮ�j
                salesDetailWork.CmpltShipmentCnt = salesDetail.CmpltShipmentCnt; // ���ʁi�ꎮ�j
                salesDetailWork.CmpltSalesUnPrcFl = salesDetail.CmpltSalesUnPrcFl; // ����P���i�ꎮ�j
                salesDetailWork.CmpltSalesMoney = salesDetail.CmpltSalesMoney; // ������z�i�ꎮ�j
                salesDetailWork.CmpltSalesUnitCost = salesDetail.CmpltSalesUnitCost; // �����P���i�ꎮ�j
                salesDetailWork.CmpltCost = salesDetail.CmpltCost; // �������z�i�ꎮ�j
                salesDetailWork.CmpltPartySalSlNum = salesDetail.CmpltPartySalSlNum; // �����`�[�ԍ��i�ꎮ�j
                salesDetailWork.CmpltNote = salesDetail.CmpltNote; // �ꎮ���l
                salesDetailWork.PrtGoodsNo = salesDetail.PrtGoodsNo; // ����p�i��
                salesDetailWork.PrtMakerCode = salesDetail.PrtMakerCode; // ����p���[�J�[�R�[�h
                salesDetailWork.PrtMakerName = salesDetail.PrtMakerName; // ����p���[�J�[����
                salesDetailWork.DtlRelationGuid = salesDetail.DtlRelationGuid; // ���ʃL�[
                // --- ADD 2011/08/10 ---------->>>>>
                salesDetailWork.AcceptOrOrderKind = salesDetail.AcceptOrOrderKind;// �󔭒����
                salesDetailWork.InquiryNumber = salesDetail.InquiryNumber; // �⍇���ԍ�
                salesDetailWork.InqRowNumber = salesDetail.InqRowNumber; // �⍇���s�ԍ�
                salesDetailWork.AutoAnswerDivSCM = salesDetail.AutoAnswerDivSCM; // �����񓚋敪(SCM)
                // --- ADD 2011/08/10 ----------<<<<<
                salesDetailWork.AnswerDelivDate = salesDetail.AnswerDelivDate; // �񓚔[��// ADD 2011/09/29 
                salesDetailWork.WayToAcptOdr = salesDetail.WayToAcptOdr; //ADD  ���N�n�� 2012/01/12   Redmine#27954
                // 2012/01/16 Add >>>
                salesDetailWork.GoodsSpecialNote = salesDetail.GoodsSpecialNote; // ���L����
                // 2012/01/16 Add <<<
                // ADD 2013/06/05 �g�� 2013/06/18�z�M SCM��Q��10385�P�̃e�X�g����Q(����) --------->>>>>>>>>>>>>>>>>>>>>>>>>
                salesDetailWork.CampaignCode = salesDetail.CampaignCode; // �L�����y�[���R�[�h
                // ADD 2013/06/05 �g�� 2013/06/18�z�M SCM��Q��10385�P�̃e�X�g����Q(����) ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            }
            return salesDetailWork;
        }

        #endregion // </���㖾�׃f�[�^���[�N>

        #endregion // </�����[�g�p���[�N�f�[�^>

        /// <summary>
        /// ���ナ�X�g�𐶐����܂��B
        /// </summary>
        /// <param name="canEntryCarMng">�ԗ��Ǘ��}�X�^�ɓo�^����t���O</param>
        /// <returns>���ナ�X�g</returns>
        public CustomSerializeArrayList CreateSalesList(out bool canEntryCarMng)
        {
            const string METHOD_NAME = "CreateSalesList(out bool)"; // ���O�p

            // �񓚂��Ă悢���̔���
            if (!CanCreateSalesList(SCMHeaderRecord))
            {
                #region <Log>

                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(
                    "SCM�S�̐ݒ�}�X�^.�����񓚋敪���u2:�S�ĉ񓚉\�ȏꍇ�v�̂��߁A�񓚂��s���܂���B"
                ));

                #endregion // </Log>

                canEntryCarMng = false;
                return new CustomSerializeArrayList();
            }

            // ���ナ�X�g
            CustomSerializeArrayList salesList = new CustomSerializeArrayList();
            {
                #region <����f�[�^>

                // ���㖾�׃f�[�^���W�v
                AddItUpSalesDetailData();

                // ����f�[�^��␳
                canEntryCarMng = ReviseSalesSlip();

                //>>>2010/07/07 del
                //// ����f�[�^
                //AddSalesSlipDataToSalesList(salesList, SalesSlipData);
                //<<<2010/07/07 del

                #endregion // </����f�[�^>

                #region <���㖾�׃��X�g>

                // ���㖾�׃��X�g
                AddSalesDetailToSalesList(salesList, SalesDetailDataList);

                #endregion // </���㖾�׃��X�g>

                //>>>2010/07/07 add
                // ���㖾�׃f�[�^���W�v
                AddItUpSalesDetailData();

                // ����f�[�^
                AddSalesSlipDataToSalesList(salesList, SalesSlipData);
                //<<<2010/07/07 add

                #region <�����f�[�^�Ɠ��������f�[�^>

                // �󒍃X�e�[�^�X������ && ���|�敪�����i �̏ꍇ�ɐݒ�
                if (
                    SalesSlipData.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Sales)
                        &&
                    SalesSlipData.AccRecDivCd.Equals(0) // 0:���i �������񓚏����ł͂��̒l�ŌŒ�
                )
                {
                    // �����f�[�^
                    DepsitMainWork depsitMainWork = null;
                    // ���������f�[�^
                    DepositAlwWork depositAlwWork = null;
                    // �����Ɏ擾
                    TakeDepositParameter(ref _salesSlipData, out depsitMainWork, out depositAlwWork);

                    salesList.Add(depsitMainWork);  // �����f�[�^
                    salesList.Add(depositAlwWork);  // ���������f�[�^
                }

                #endregion // </�����f�[�^�Ɠ��������f�[�^>

                #region <�ԗ��Ǘ����X�g>

                // �ԗ��Ǘ����X�g
                ArrayList carManagementWorkList = new ArrayList();
                foreach (CarManagementWork carManagementWork in CarManagementList)
                {
                    carManagementWorkList.Add(carManagementWork);
                }
                salesList.Add(carManagementWorkList);

                #endregion // </�ԗ��Ǘ����X�g>

                #region <�����[�g�Q�Ɨp���׃��X�g>

                // �����[�g�Q�Ɨp���׃��X�g
                ArrayList slipDetailAddInfoWorkList = new ArrayList();
                foreach (SlipDetailAddInfoWork slipDetailAddInfoWork in SlipDetailAddInfoList)
                {
                    slipDetailAddInfoWorkList.Add(slipDetailAddInfoWork);
                }
                salesList.Add(slipDetailAddInfoWorkList);

                #endregion // </�����[�g�Q�Ɨp���׃��X�g>

            #if _ENABLED_SCM_

                // �󒍃X�e�[�^�X���u20:�󒍁v�̏ꍇ�ASCM�󒍌n�f�[�^�͑��M���Ȃ��B
                // �������A����f�[�^�͍쐬����̂ŁA
                // SCM�󒍌n�f�[�^�̍X�V�N�����A�X�V�����b�~���b�͐ݒ肵�Ă����B
                DateTime updateDate = DateTime.Now;                         // �X�V�N����
                int updateTime = SCMDataHelper.GetUpdateTime(updateDate);   // �X�V�����b�~���b

                #region <SCM�󒍃f�[�^>

                UserSCMOrderHeaderRecord userHeader = SCMHeaderRecord as UserSCMOrderHeaderRecord;
                if (userHeader != null)
                {
                    // �󒍃X�e�[�^�X�͍݌ɂ̏�Ԃŕω�����̂ŁA�ŏI�I�Ȍ��ʂňˑ�����t�B�[���h���Đݒ�
                    // �u20:�󒍁v�̏ꍇ�A�X�V�N�����A�X�V�����b�~���b��ݒ�
                    if (userHeader.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                    {
                        userHeader.UpdateDate = updateDate; // 017.�X�V�N����
                        userHeader.UpdateTime = updateTime; // 018.�X�V�����b�~���b
                    }
                    // 036.�񓚍쐬�敪
                    // 2011/02/18 >>>
                    //userHeader.AnswerCreateDiv = SCMSalesDataMaker.GetAnswerCreateDiv(userHeader.AcptAnOdrStatus);
                    userHeader.AnswerCreateDiv = GetAnswerCreateDiv(userHeader.AcptAnOdrStatus);
                    // 2011/02/18 <<<

                    userHeader.SalesTotalTaxInc = SalesSlipData.SalesTotalTaxInc;   // 031.����`�[���v(�ō���)
                    userHeader.SalesSubtotalTax = SalesSlipData.SalesSubtotalTax;   // 032.���㏬�v(��)

                    salesList.Add(userHeader.RealRecord);   
                }
                else
                {
                    Debug.Assert(false, "User�^��SCM�󒍃f�[�^�ł͂���܂���B");
                }

                #endregion // </SCM�󒍃f�[�^>

                #region <SCM�󒍃f�[�^(�ԗ����)>

                // SCM�󒍃f�[�^(�ԗ����)
                UserSCMOrderCarRecord userCar = SCMCarRecord as UserSCMOrderCarRecord;
                if (userCar != null)
                {
                    salesList.Add(userCar.RealRecord);
                }
                else
                {
                    Debug.Assert(false, "User�^��SCM�󒍃f�[�^(�ԗ����)�ł͂���܂���B");
                }

                #endregion // </SCM�󒍃f�[�^(�ԗ����)>

                #region <SCM�󒍖��׃f�[�^(�⍇���E����)>

                #if _ENABLED_SCM_DETAIL_

                // �u20:�󒍁v�̏ꍇ�ASCM�󒍖��׃f�[�^(�⍇���E����)��������
                if (userHeader.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                {
                    // SCM�󒍖��׃f�[�^(�⍇���E����)
                    ArrayList userDetailList = new ArrayList();
                    foreach (ISCMOrderDetailRecord detailRecord in SCMDetailRecordList)
                    {
                        UserSCMOrderDetailRecord userDetail = detailRecord as UserSCMOrderDetailRecord;
                        if (userDetail != null)
                        {
                            userDetail.UpdateDate = updateDate; // �X�V�N����
                            userDetail.UpdateTime = updateTime; // �X�V�����b�~���b

                            userDetailList.Add(userDetail.RealRecord);
                        }
                        else
                        {
                            Debug.Assert(false, "User�^��SCM�󒍖��׃f�[�^(�⍇���E����)�ł͂���܂���B");
                        }
                    }
                    salesList.Add(userDetailList);
                }

                #endif

                #endregion // </SCM�󒍖��׃f�[�^(�⍇���E����)>

                #region <SCM�󒍖��׃f�[�^(��)>

                // SCM�󒍖��׃f�[�^(��)
                int salesRowNoCount = 0;
                ArrayList userAnswerList = new ArrayList();
                foreach (ISCMOrderAnswerRecord answerRecord in SCMAnswerRecordList)
                {
                    UserSCMOrderAnswerRecord userAnswer = answerRecord as UserSCMOrderAnswerRecord;
                    if (userAnswer != null)
                    {
                        // �u20:�󒍁v�̏ꍇ�A�X�V�N�����A�X�V�����b�~���b��ݒ�
                        if (userHeader.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                        {
                            userAnswer.UpdateDate = updateDate;
                            userAnswer.UpdateTime = updateTime;
                        }
                        userAnswer.SalesRowNo = ++salesRowNoCount;  // 055.����s�ԍ��c�A�ԕt��(����`�[�ԍ��P��)
                        userAnswerList.Add(userAnswer.RealRecord);
                    }
                    else
                    {
                        Debug.Assert(false, "User�^��SCM�󒍖��׃f�[�^(��)�ł͂���܂���B");
                    }
                }

                // DEL 2014/08/13 11070147-00 �V�X�e���e�X�g��Q��5�Ή� ----------------------------------->>>>>
                // Add 2014/08/11 duzg For ���؁^�����e�X�g��QNo.5 -------------------->>>>>>>>>>>>>>>>>>>
                // �i�ԓ��͌����̎��A��ʃR�[�h�A���̂́A�󔒂Őݒ肵�Ă��܂�
                //if (SalesDetailDataList != null && SalesDetailDataList.Count != 0)
                //{
                //    for (int i = 0; i < SalesDetailDataList.Count; i++ )
                //    {
                //        SalesDetail detail = SalesDetailDataList[i];
                //        SCMAcOdrDtlAsWork userAnswer = null;
                //        if (userAnswerList.Count > i)
                //        {
                //            userAnswer = userAnswerList[i] as SCMAcOdrDtlAsWork;
                //        }
                //        if (userAnswer != null)
                //        {
                //            if (detail.GoodsSearchDivCd == 1
                //                && detail.GoodsNo == userAnswer.GoodsNo)
                //            {
                //                userAnswer.PrmSetDtlName2 = string.Empty;
                //                userAnswer.PrmSetDtlNo2 = 0;
                //            }
                //        }
                //    }
                //}
                // Add 2014/08/11 duzg For ���؁^�����e�X�g��QNo.5 --------------------<<<<<<<<<<<<<<<<<<<
                // DEL 2014/08/13 11070147-00 �V�X�e���e�X�g��Q��5�Ή� -----------------------------------<<<<<

                salesList.Add(userAnswerList);
                #endregion // </SCM�󒍖��׃f�[�^(��)>

                // -- ADD 2011/08/10   ------ >>>>>>
                // �݌Ɋm�F�̏ꍇ
                if (userHeader.InqOrdDivCd.Equals((int)InqOrdDivCdValue.Inquiry))
                {
                    #region <SCM�󒍃Z�b�g�f�[�^>
                    // SCM�󒍖��׃f�[�^(��)
                    int setRowNoCount = 0;
                    ArrayList userSetList = new ArrayList();

                    foreach (ISCMAcOdSetDtRecord setRecord in SCMSetDtRecordList)
                    {
                        UserSCMAcOdSetDtRecord userSet = setRecord as UserSCMAcOdSetDtRecord;
                        if (userSet != null)
                        {
                            // �u20:�󒍁v�̏ꍇ�A�X�V�N�����A�X�V�����b�~���b��ݒ�
                            if (userHeader.AcptAnOdrStatus.Equals((int)AcptAnOdrStatus.Order))
                            {
                                userSet.UpdateDateTime = updateDate;
                            }
                            userSet.PMSalesRowNo = ++setRowNoCount;  // 055.����s�ԍ��c�A�ԕt��(����`�[�ԍ��P��)
                            userSetList.Add(userSet.RealRecord);
                        }
                        else
                        {
                            Debug.Assert(false, "User�^��SCM�󒍃Z�b�g�f�[�^�ł͂���܂���B");
                        }
                    }
                    salesList.Add(userSetList);
                    #endregion // </SCM�󒍃Z�b�g�f�[�^>
                }
                // -- ADD 2011/08/10   ------ <<<<<<
            #endif
            }
            return salesList;
        }

        // 2011/02/18 Add >>>
        /// <summary>
        /// �񓚍쐬�敪���擾���܂��B
        /// </summary>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <returns>
        /// �󒍃X�e�[�^�X���u10:���ρv�u30:����v�̏ꍇ�A�u0:�����v��Ԃ��܂��B<br/>
        /// ����ȊO�i�u20:�󒍁v�j�̏ꍇ�A�u1:�蓮(Web)�v��Ԃ��܂��B
        /// </returns>
        protected virtual int GetAnswerCreateDiv(int acptAnOdrStatus)
        {
            return (int)Broadleaf.Application.UIData.Util.AnswerCreateDivValue.ManualWeb;
        }
        // 2011/02/18 Add <<<

        /// <summary>
        /// ���ナ�X�g�𐶐��ł��邩���f���܂��B
        /// </summary>
        /// <param name="scmHeaderRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        /// <returns>
        /// <c>true</c> :���ナ�X�g�𐶐��ł��܂��B<br/>
        /// <c>false</c>:���ナ�X�g�𐶐��ł��܂���B
        /// </returns>
        protected virtual bool CanCreateSalesList(ISCMOrderHeaderRecord scmHeaderRecord)
        {
            return true;
        }

        /// <summary>
        /// ����f�[�^�𔄏ナ�X�g�ɒǉ����܂��B
        /// </summary>
        /// <param name="salesList">���ナ�X�g</param>
        /// <param name="salesSlip">����f�[�^</param>
        protected virtual void AddSalesSlipDataToSalesList(
            CustomSerializeArrayList salesList,
            SalesSlip salesSlip
        )
        {
            salesList.Add(salesSlip);
        }

        /// <summary>
        /// ���㖾�׃f�[�^�𔄏ナ�X�g�ɒǉ����܂��B
        /// </summary>
        /// <remarks>
        /// �����A�g�l�����ƃL�����y�[���𔽉f���ASCM�󒍖��׃f�[�^(��)�ւ̓W�J���s���܂��B
        /// </remarks>
        /// <param name="salesList">���ナ�X�g</param>
        /// <param name="salesDetailDataList">���㖾�׃f�[�^�̃��X�g</param>
        protected virtual void AddSalesDetailToSalesList(
            CustomSerializeArrayList salesList,
            IList<SalesDetail> salesDetailDataList
        )
        {
            const string METHOD_NAME = "AddSalesDetailToSalesList()";   // ���O�p

            int salesRowNoCount = 0;
            ArrayList salesDetailWorkList = new ArrayList();
            foreach (SalesDetail salesDetail in salesDetailDataList)
            {
                bool isDiscountApply = false; // ADD �����M 2013/04/17 for Redmine#35271
                // DEL 2010/04/21 ���όv��̏ꍇ�A�����A�g�l�����A�L�����y�[���l�����͍s��Ȃ� ---------->>>>>
                #region �폜�R�[�h

                //// �����A�g�l�����ƃL�����y�[���𔽉f
                //SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
                //{
                //    priceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail);
                //    PriceValue priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, SalesSlipData);
                //    if (!(priceValue.TaxInc.Equals(0.0) && priceValue.TaxExc.Equals(0.0)))
                //    {
                //        salesDetail.SalesUnPrcTaxIncFl = priceValue.TaxInc; // 069.����P��(�ō�, ����)
                //        salesDetail.SalesUnPrcTaxExcFl = priceValue.TaxExc; // 070.����P��(�Ŕ�, ����)
                //    }
                //}

                #endregion // �폜�R�[�h
                // DEL 2010/04/21 ���όv��̏ꍇ�A�����A�g�l�����A�L�����y�[���l�����͍s��Ȃ� ----------<<<<<
                // ADD 2010/04/21 ���όv��̏ꍇ�A�����A�g�l�����A�L�����y�[���l�����͍s��Ȃ� ---------->>>>>
                // 2011/01/11 >>>
                // UPD 2015/01/19 ���R�����h�Ή� --------------------------------------------------->>>>>
                #region �폜
                //// ���όv��ƕԕi�͎����A�g�l���A�L�����y�[���l���ΏۊO
                ////if (!IsEstimateAddingUp(salesDetail))
                //// SCM�i�ڐݒ�ŉ��i���񓚂��Ȃ��P�[�X������̂ŁA�P��������ꍇ�̂�
                //ISCMOrderAnswerRecord answerRecord = GetSCMAnswerRecord(salesDetail);
                //if (!IsEstimateAddingUp(salesDetail) &&
                //    !IsRetuanSlip(salesDetail))
                //    // 2011/01/11 <<<
                #endregion // �폜
                // SCM�i�ڐݒ�ŉ��i���񓚂��Ȃ��P�[�X������̂ŁA�P��������ꍇ�̂�
                ISCMOrderAnswerRecord answerRecord = GetSCMAnswerRecord(salesDetail);
                // ���όv��ƕԕi�A���R�����h�������͎����A�g�l���A�L�����y�[���l���ΏۊO
                if (!IsEstimateAddingUp(salesDetail) &&
                    !IsRetuanSlip(salesDetail) &&
                    !IsRecommend(salesDetail, answerRecord))
                // UPD 2015/01/19 ���R�����h�Ή� ---------------------------------------------------<<<<<
                if (!IsEstimateAddingUp(salesDetail))
                {
                    // �����A�g�l�����ƃL�����y�[���𔽉f
                    SCMPriceCalculator priceCalculator = new SCMPriceCalculator();
                    {
                        // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------>>>>>
                        //priceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail);
                        priceCalculator.SetCurrentSCMOrderData(SalesSlipData.CustomerCode, salesDetail,
                            (answerRecord.CancelCndtinDiv != 0) ? (short)1 : (short)0,
                            salesDetail.SalesDate);
                        // UPD 2014/01/30 Redmine#41771-��Q��13�Ή� ------------------------------------------------------<<<<<
                        PriceValue priceValue;
                        //>>>2012/04/09
                        //if (salesDetail.AcceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE &&answerRecord.InqOrdDivCd == (int)InqOrdDivCd.Order)
                        //{
                        //    priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail.TaxationDivCd, SalesSlipData.TotalAmountDispWayCd, salesDetail.SalesUnPrcTaxExcFl);

                        //}
                        //else
                        //{
                        //    priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, SalesSlipData);
                        //}

                        priceValue = priceCalculator.CalcTaxExcAndTaxInc(salesDetail, SalesSlipData);
                        //<<<2012/04/09

                        if (!(priceValue.TaxInc.Equals(0.0) && priceValue.TaxExc.Equals(0.0)))
                        {
                            // UPD 2012/08/24 �O�� 2012/09/12�z�M�V�X�e����Q��16 �Ή� ---------->>>>>>>>>>>>>>>>>>>>>>>
                            //salesDetail.SalesUnPrcTaxIncFl = priceValue.TaxInc; // 069.����P��(�ō�, ����)
                            //salesDetail.SalesUnPrcTaxExcFl = priceValue.TaxExc; // 070.����P��(�Ŕ�, ����)
                            // --- DEL 2013/04/17 �O�� 2013/05/22�z�M�� SCM��Q��10520 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            //if (answerRecord.UnitPrice > 0)
                            //{
                            // --- DEL 2013/04/17 �O�� 2013/05/22�z�M�� SCM��Q��10520 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            // UPD 2012/09/12 ���� ��Q�Ή�--------------------->>>>>
                            //salesDetail.SalesUnPrcTaxIncFl = salesDetail.ListPriceTaxIncFl; // 069.����(�ō�,����)
                            //salesDetail.SalesUnPrcTaxExcFl = salesDetail.ListPriceTaxExcFl; // 070.����(�Ŕ�,����)
                            salesDetail.SalesUnPrcTaxIncFl = priceValue.TaxInc; // 069.����(�ō�,����)
                            salesDetail.SalesUnPrcTaxExcFl = priceValue.TaxExc; // 070.����(�Ŕ�,����)
                            // UPD 2012/09/12 ���� ��Q�Ή�---------------------<<<<<
                            isDiscountApply = priceCalculator.IsDiscountApply; // ADD �����M 2013/04/17 for Redmine#35271
                            // --- DEL 2013/04/17 �O�� 2013/05/22�z�M�� SCM��Q��10520 --------->>>>>>>>>>>>>>>>>>>>>>>>
                            //}
                            // --- DEL 2013/04/17 �O�� 2013/05/22�z�M�� SCM��Q��10520 ---------<<<<<<<<<<<<<<<<<<<<<<<<
                            // UPD 2012/08/24 �O�� 2012/09/12�z�M�V�X�e����Q��16 �Ή� ----------<<<<<<<<<<<<<<<<<<<<<<<
                        }
                    }
                }
                else
                {
                    #region <Log>

                    EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("�����A�g�l�����ƃL�����y�[���͔��f���܂���B�挩�ςŉ񓚍ςݏ��i�ł�"));

                    #endregion // </Log>
                }
                // ADD 2010/04/21 ���όv��̏ꍇ�A�����A�g�l�����A�L�����y�[���l�����͍s��Ȃ� ----------<<<<<
                SalesDetail salesDetailWork = salesDetail;
                {
                    salesDetailWork.SalesRowNo = ++salesRowNoCount; // 012.����s�ԍ�
                    salesDetailWork.SalesSlipDtlNum = 0;            // 018.���㖾�גʔ�
                }
                // --- ADD �����M 2013/04/17 for Redmine#35271 --------->>>>>
                if (isDiscountApply)
                {
                    salesDetailWork.SalesRate = 0.0;
                }
                // --- ADD �����M 2013/04/17 for Redmine#35271 ---------<<<<<
                salesDetailWorkList.Add(salesDetailWork);

                // TODO:SCM�󒍖��׃f�[�^(��)�֓W�J�c���`���ł�SCM�󒍌n�f�[�^�͗��p���ĂȂ��̂ŁA�������Ȃ��ł���
                //ISCMOrderAnswerRecord answerRecord = GetSCMAnswerRecord(salesDetail);
                //answerRecord.UnitPrice = (long)salesDetail.SalesUnPrcTaxIncFl;
                // �������s���ꍇ�A����f�[�^������SCM�󒍌n�f�[�^���C���v�b�g�f�[�^�̂Ƃ��ɗ�O����������̂ŁA��������C���邱��
                // �q���g�FGetSCMAnswerRecord()�Ń}�b�v�ɓo�^����Ă���L�[��salesDetail���琶������L�[������Ȃ�
            }
            salesList.Add(salesDetailWorkList);
        }

        // ADD 2010/04/21 ���όv��̏ꍇ�A�����A�g�l�����A�L�����y�[���l�����͍s��Ȃ� ---------->>>>>
        /// <summary>
        /// ���όv��̔��㖾�׃f�[�^�ł��邩���f���܂��B
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <returns>
        /// <c>true</c> :���όv��̔��㖾�׃f�[�^�ł��B<br/>
        /// <c>false</c>:���όv��̔��㖾�׃f�[�^�ł͂���܂���B
        /// </returns>
        protected static bool IsEstimateAddingUp(SalesDetail salesDetail)
        {
            // �v�㌳�󒍃X�e�[�^�X�����ςŁA�v�㌳���גʔԂɒl������
            return salesDetail.AcptAnOdrStatusSrc.Equals((int)AcptAnOdrStatus.Estimate) && salesDetail.SalesSlipDtlNumSrc > 0;
        }
        // ADD 2010/04/21 ���όv��̏ꍇ�A�����A�g�l�����A�L�����y�[���l�����͍s��Ȃ� ----------<<<<<

        // 2011/01/11 Add >>>
        /// <summary>
        /// �ԕi���ׂł��邩���f���܂��B
        /// </summary>
        /// <param name="salesDetail"></param>
        /// <returns>
        /// <c>true</c> :�ԕi�̔��㖾�׃f�[�^�ł��B<br/>
        /// <c>false</c>:�ԕi�̔��㖾�׃f�[�^�ł͂���܂���B
        /// </returns>
        protected static bool IsRetuanSlip(SalesDetail salesDetail)
        {
            // �v�㌳�󒍃X�e�[�^�X�����ςŁA�v�㌳���גʔԂɒl������
            return salesDetail.AcptAnOdrStatusSrc.Equals((int)AcptAnOdrStatus.Sales) && salesDetail.SalesSlipDtlNumSrc > 0;
        }
        // 2011/01/11 Add <<<
        
        // 2015/01/19 ���R�����h�Ή� ------------------------------------->>>>>
        /// <summary>
        /// ���R�����h�����ł��邩���f���܂��B
        /// </summary>
        /// <param name="salesDetail">���㖾�׃f�[�^</param>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)�f�[�^</param>
        /// <returns>
        /// <c>true</c> :���R�����h�����̔��㖾�׃f�[�^�ł��B<br/>
        /// <c>false</c>:���R�����h�����̔��㖾�׃f�[�^�ł͂���܂���B
        /// </returns>
        protected static bool IsRecommend(SalesDetail salesDetail, ISCMOrderAnswerRecord answerRecord)
        {
            // �O��񓚃f�[�^���Ȃ��A�����������i�I���敪���u1:�����������i�v�̎�
            return salesDetail.AcptAnOdrStatusSrc.Equals(0) && answerRecord.BgnGoodsDiv == (short)BgnGoodsDiv.BargainItem;
        }
        // 2015/01/19 ���R�����h�Ή� -------------------------------------<<<<<

        #region <�W�v����>

        /// <summary>
        /// ���㖾�׃f�[�^���W�v���܂��B
        /// </summary>
        private void AddItUpSalesDetailData()
        {
            SalesSlipData.DetailRowCount = SalesDetailDataList.Count;   // 109.���׍s��

            OtherAppComponent otherComponent = new OtherAppComponent(
                SalesSlipData.EnterpriseCode,
                SalesSlipData.SectionCode
            );

            #region <�߂�l�̐錾>

            long salesTotalTaxInc;      // ����`�[���v�i�ō��j
            long salesTotalTaxExc;      // ����`�[���v�i�Ŕ��j
            long salesSubtotalTax;      // ���㏬�v�i�Łj
            long itdedSalesOutTax;      // ����O�őΏۊz
            long itdedSalesInTax;       // ������őΏۊz
            long salSubttlSubToTaxFre;  // ���㏬�v��ېőΏۊz
            long salesOutTax;           // ������z����Ŋz�i�O�Łj
            long salAmntConsTaxInclu;   // ������z����Ŋz�i���Łj
            long salesDisTtlTaxExc;     // ����l�����z�v�i�Ŕ��j
            long itdedSalesDisOutTax;   // ����l���O�őΏۊz���v
            long itdedSalesDisInTax;    // ����l�����őΏۊz���v
            long itdedSalesDisTaxFre;   // ����l����ېőΏۊz���v
            long salesDisOutTax;        // ����l������Ŋz�i�O�Łj
            long salesDisTtlTaxInclu;   // ����l������Ŋz�i���Łj
            long totalCost;             // �������z�v

            long stockGoodsTtlTaxExc;   // �݌ɏ��i���v���z(�Ŕ�)   �c����f�[�^�ɖ����H
            long pureGoodsTtlTaxExc;    // �������i���v���z(�Ŕ�)   �c����f�[�^�ɖ����H
            long balanceAdjust;         // ����Œ����z             �c����f�[�^�ɖ����H
            long taxAdjust;             // �c�������z               �c����f�[�^�ɖ����H

            long salesPrtSubttlInc;     // ���㕔�i���v�i�ō��j
            long salesPrtSubttlExc;     // ���㕔�i���v�i�Ŕ��j
            long salesWorkSubttlInc;    // �����Ə��v�i�ō��j
            long salesWorkSubttlExc;    // �����Ə��v�i�Ŕ��j
            long itdedPartsDisInTax;    // ���i�l���Ώۊz���v�i�ō��j
            long itdedPartsDisOutTax;   // ���i�l���Ώۊz���v�i�Ŕ��j
            long itdedWorkDisInTax;     // ��ƒl���Ώۊz���v�i�ō��j
            long itdedWorkDisOutTax;    // ��ƒl���Ώۊz���v�i�Ŕ��j

            long totalMoneyForGrossProfit;  // �e���v�Z�p������z   �c����f�[�^�ɖ����H

            #endregion // </�߂�l�̐錾>

            // --- DEL 2013/08/07 T.Yoshioka ��10556 ---------->>>>>
            #region ���\�[�X
            //// --- ADD 2013/08/07 Y.Wakita ---------->>>>>
            //int taxFracProcCd;
            //// --- ADD 2013/08/07 Y.Wakita ----------<<<<<
            #endregion
            // --- DEL 2013/08/07 T.Yoshioka ��10556 ----------<<<<<
            // --- ADD 2013/08/07 T.Yoshioka ��10556 ---------->>>>>
            // ����Œ[�������R�[�h �𓾈Ӑ��񂩂�擾
            CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
            SalesSlipData.FractionProcCd = customerInfoAcs.GetSalesFractionProcCd(SalesSlipData.EnterpriseCode, SalesSlipData.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // --- ADD 2013/08/07 T.Yoshioka ��10556 ----------<<<<<
            #region <�ďo��>

            otherComponent.CalculationSalesTotalPrice(
                (List<SalesDetail>)SalesDetailDataList, // ���㖾�׃f�[�^���X�g
                SalesSlipData.ConsTaxRate,              // ����Őŗ�
                SalesSlipData.FractionProcCd,           // ����Œ[�������R�[�h
                SalesSlipData.TotalAmountDispWayCd,     // ���z�\�����@�敪
                SalesSlipData.ConsTaxLayMethod,         // ����œ]�ŕ���
                // --- DEL 2013/08/07 T.Yoshioka ��10556 ---------->>>>>
                #region ���\�[�X
                //// --- ADD 2013/08/07 Y.Wakita ---------->>>>>
                //SalesSlipData.EnterpriseCode,           // ��ƃR�[�h
                //SalesSlipData.CustomerCode,             // ���Ӑ�R�[�h

                //out taxFracProcCd,                      // �[�������敪
                //// --- ADD 2013/08/07 Y.Wakita ----------<<<<<
                #endregion
                // --- DEL 2013/08/07 T.Yoshioka ��10556 ----------<<<<<

                out salesTotalTaxInc,       // ����`�[���v�i�ō��j
                out salesTotalTaxExc,       // ����`�[���v�i�Ŕ��j
                out salesSubtotalTax,       // ���㏬�v�i�Łj
                out itdedSalesOutTax,       // ����O�őΏۊz
                out itdedSalesInTax,        // ������őΏۊz
                out salSubttlSubToTaxFre,   // ���㏬�v��ېőΏۊz
                out salesOutTax,            // ������z����Ŋz�i�O�Łj
                out salAmntConsTaxInclu,    // ������z����Ŋz�i���Łj
                out salesDisTtlTaxExc,      // ����l�����z�v�i�Ŕ��j
                out itdedSalesDisOutTax,    // ����l���O�őΏۊz���v
                out itdedSalesDisInTax,     // ����l�����őΏۊz���v
                out itdedSalesDisTaxFre,    // ����l����ېőΏۊz���v
                out salesDisOutTax,         // ����l������Ŋz�i�O�Łj
                out salesDisTtlTaxInclu,    // ����l������Ŋz�i���Łj
                out totalCost,              // �������z�v

                out stockGoodsTtlTaxExc,    // �݌ɏ��i���v���z(�Ŕ�)   �c����f�[�^�ɖ����H
                out pureGoodsTtlTaxExc,     // �������i���v���z(�Ŕ�)   �c����f�[�^�ɖ����H
                out balanceAdjust,          // ����Œ����z             �c����f�[�^�ɖ����H
                out taxAdjust,              // �c�������z               �c����f�[�^�ɖ����H

                out salesPrtSubttlInc,      // ���㕔�i���v�i�ō��j
                out salesPrtSubttlExc,      // ���㕔�i���v�i�Ŕ��j
                out salesWorkSubttlInc,     // �����Ə��v�i�ō��j
                out salesWorkSubttlExc,     // �����Ə��v�i�Ŕ��j
                out itdedPartsDisInTax,     // ���i�l���Ώۊz���v�i�ō��j
                out itdedPartsDisOutTax,    // ���i�l���Ώۊz���v�i�Ŕ��j
                out itdedWorkDisInTax,      // ��ƒl���Ώۊz���v�i�ō��j
                out itdedWorkDisOutTax,     // ��ƒl���Ώۊz���v�i�Ŕ��j

                out totalMoneyForGrossProfit    // �e���v�Z�p������z   �c����f�[�^�ɖ����H
            );

            #endregion // </�ďo��>

            #region <�߂�l����>
            // --- DEL 2013/08/07 T.Yoshioka ��10556 ---------->>>>>
            #region ���\�[�X
            //// --- ADD 2013/08/07 Y.Wakita ---------->>>>>
            //SalesSlipData.FractionProcCd = taxFracProcCd;
            //// --- ADD 2013/08/07 Y.Wakita ----------<<<<<
            #endregion
            // --- DEL 2013/08/07 T.Yoshioka ��10556 ----------<<<<<

            // --- UPD 2013/08/07 Y.Wakita ---------->>>>>
            //SalesSlipData.SalesTotalTaxInc = salesTotalTaxInc;          // 040.����`�[���v�i�ō��j
            //SalesSlipData.SalesTotalTaxExc = salesTotalTaxExc;          // 041.����`�[���v�i�Ŕ��j
            SalesSlipData.SalesTotalTaxInc = salesTotalTaxInc + salSubttlSubToTaxFre;          // 040.����`�[���v�i�ō��j
            SalesSlipData.SalesTotalTaxExc = salesTotalTaxExc + salSubttlSubToTaxFre;          // 041.����`�[���v�i�Ŕ��j
            // --- UPD 2013/08/07 Y.Wakita ----------<<<<<
            SalesSlipData.SalesSubtotalTax = salesSubtotalTax;          // 046.���㏬�v�i�Łj
            SalesSlipData.ItdedSalesOutTax = itdedSalesOutTax;          // 054.����O�őΏۊz
            SalesSlipData.ItdedSalesInTax = itdedSalesInTax;            // 055.������őΏۊz
            SalesSlipData.SalSubttlSubToTaxFre = salSubttlSubToTaxFre;  // 056.���㏬�v��ېőΏۊz
            SalesSlipData.SalesOutTax = salesOutTax;                    // 057.������z����Ŋz�i�O�Łj
            SalesSlipData.SalAmntConsTaxInclu = salAmntConsTaxInclu;    // 058.������z����Ŋz�i���Łj
            SalesSlipData.SalesDisTtlTaxExc = salesDisTtlTaxExc;        // 059.����l�����z�v�i�Ŕ��j
            SalesSlipData.ItdedSalesDisOutTax = itdedSalesDisOutTax;    // 060.����l���O�őΏۊz���v
            SalesSlipData.ItdedSalesDisInTax = itdedSalesDisInTax;      // 061.����l�����őΏۊz���v
            SalesSlipData.ItdedSalesDisTaxFre = itdedSalesDisTaxFre;    // 066.����l����ېőΏۊz���v
            SalesSlipData.SalesDisOutTax = salesDisOutTax;              // 067.����l������Ŋz�i�O�Łj
            SalesSlipData.SalesDisTtlTaxInclu = salesDisTtlTaxInclu;    // 068.����l������Ŋz�i���Łj
            SalesSlipData.TotalCost = totalCost;                        // 071.�������z�v
            SalesSlipData.SalesPrtSubttlInc = salesPrtSubttlInc;        // 048.���㕔�i���v�i�ō��j
            SalesSlipData.SalesPrtSubttlExc = salesPrtSubttlExc;        // 049.���㕔�i���v�i�Ŕ��j
            SalesSlipData.SalesWorkSubttlInc = salesWorkSubttlInc;      // 050.�����Ə��v�i�ō��j
            SalesSlipData.SalesWorkSubttlExc = salesWorkSubttlExc;      // 051.�����Ə��v�i�Ŕ��j
            SalesSlipData.ItdedPartsDisInTax = itdedPartsDisInTax;      // 063.���i�l���Ώۊz���v�i�ō��j
            SalesSlipData.ItdedPartsDisOutTax = itdedPartsDisOutTax;    // 062.���i�l���Ώۊz���v�i�Ŕ��j
            SalesSlipData.ItdedWorkDisInTax = itdedWorkDisInTax;        // 065.��ƒl���Ώۊz���v�i�ō��j
            SalesSlipData.ItdedWorkDisOutTax = itdedWorkDisOutTax;      // 064.��ƒl���Ώۊz���v�i�Ŕ��j

            #endregion // </�߂�l����>

            // 042.���㕔�i���v(�ō���)�c���㕔�i���v(�ō���) + ���i�l���Ώۊz���v(�ō���)
            SalesSlipData.SalesPrtTotalTaxInc = SCMSlipDataFactory.GetSalesPrtTotalTaxInc(SalesSlipData);
            // 043.���㕔�i���v(�Ŕ���)�c���㕔�i���v(�Ŕ���) + ���i�l���Ώۊz���v(�Ŕ���)
            SalesSlipData.SalesPrtTotalTaxExc = SCMSlipDataFactory.GetSalesPrtTotalTaxExc(SalesSlipData);
            // 044.�����ƍ��v(�ō���)�c�����Ə��v(�ō���) + ��ƒl���Ώۊz���v(�ō���)
            SalesSlipData.SalesWorkTotalTaxInc = SCMSlipDataFactory.GetSalesWorkTotalTaxInc(SalesSlipData);
            // 045.�����ƍ��v(�Ŕ���)�c�����Ə��v(�Ŕ���) + ��ƒl���Ώۊz���v(�Ŕ���)
            SalesSlipData.SalesWorkTotalTaxExc = SCMSlipDataFactory.GetSalesWorkTotalTaxExc(SalesSlipData);

            // 046.���㏬�v(�ō���)�c�l������̖��׋��z�̍��v(��ېŊ܂܂�)
            // ������`�[���v(�ō���) - ���㏬�v��ېőΏۊz + ����l����ېőΏۊz���v
            SalesSlipData.SalesSubtotalTaxInc = SCMSlipDataFactory.GetSalesSubtotalTaxInc(SalesSlipData);
            // 047.���㏬�v(�Ŕ���)�c�l������̖��׋��z�̍��v(��ېŊ܂܂�)
            // ������`�[���v(�Ŕ���) - ���㏬�v��ېőΏۊz + ����l����ېőΏۊz���v
            SalesSlipData.SalesSubtotalTaxExc = SCMSlipDataFactory.GetSalesSubtotalTaxExc(SalesSlipData);

            // 052.���㐳�����z�c����`�[���v(�Ŕ���) - ����l�����z�v(�Ŕ���)
            SalesSlipData.SalesNetPrice = SCMSlipDataFactory.GetSalesNetPrice(SalesSlipData);

            // 069.���i�l�����c���v�ɑ΂��Ă̕��i�l����
            // �����i�l���Ώۊz���v(�ō���) / ���㕔�i���v(�ō���)
            SalesSlipData.PartsDiscountRate = SCMSlipDataFactory.GetPartsDiscountRate(SalesSlipData);

            // UNDONE:070.�H���l�����c���v�ɑ΂��Ă̍H���l����
            // ����ƒl���Ώۊz���v(�ō���) / �����Ə��v(�ō���)
            SalesSlipData.RavorDiscountRate = SCMSlipDataFactory.GetRavorDiscountRate(SalesSlipData);

            // UNDONE:075.���|����Łc�Z�o

            // 079.���������c���c����`�[���v(�ō�) ����œ]�ŕ������u�����]�ŁA��ېŁv�̏ꍇ�͐Ŕ����z
            SalesSlipData.DepositAlwcBlnce = SCMSlipDataFactory.GetConsTaxLayMethod(SalesSlipData);

            // 128.�݌ɏ��i���v���z(�Ŕ�)�c�Z�o
            SalesSlipData.StockGoodsTtlTaxExc = SCMSlipDataFactory.GetStockGoodsTtlTaxExc(SalesDetailDataList);
            // 129.�݌ɏ��i���v���z(�ō�)�c�Z�o
            SalesSlipData.PureGoodsTtlTaxExc = SCMSlipDataFactory.GetPureGoodsTtlTaxExc(SalesDetailDataList);

            // 2010/07/07 Add >>>
            SalesSlipData.AccRecConsTax = salesSubtotalTax;
            // 2010/07/07 Add <<<
        }

        #endregion // </�W�v����>

        #region <�␳����>

        /// <summary>
        /// ����f�[�^��␳���܂��B
        /// </summary>
        /// <remarks>MAHNB01010UA.cs MAHNB01010UA.ReviseSalesSlip() 3028�s�ڂ��ڐA</remarks>
        /// <returns>�ԗ��Ǘ��}�X�^�ɓo�^����t���O</returns>
        private bool ReviseSalesSlip()
        {
            #region <�ԗ��Ǘ��I�v�V����>

            if (USBOption.EnabledCarManagementOption())
            {
                #region <�ԗ��Ǘ��敪(0:���Ȃ� 1:�o�^(�m�F) 2:�o�^(����) 3:�o�^��)>

                if (CarManagementList.Count > 0)
                {
                    switch (SalesSlipData.CarMngDivCd)
                    {
                        case 0: // ���Ȃ�
                            SalesSlipData.CarMngDivCd = 0;  // ���Ȃ�
                            break;
                        case 1: // HACK:�o�^(�m�F) �������񓚏����ł͕K�v�H
                            SalesSlipData.CarMngDivCd = 1;  // ����
                            break;
                        case 2: // �o�^(����)
                            SalesSlipData.CarMngDivCd = 1;  // ����
                            break;
                        case 3: // �o�^��
                            SalesSlipData.CarMngDivCd = 0;  // ���Ȃ�
                            break;
                    }
                }
                else
                {
                    SalesSlipData.CarMngDivCd = 0;  // ���Ȃ�
                }

                #endregion // </�ԗ��Ǘ��敪(0:���Ȃ� 1:�o�^(�m�F) 2:�o�^(����) 3:�o�^��)>
            }
            else
            {
                SalesSlipData.CarMngDivCd = 0;  // ���Ȃ�
            }

            #endregion // </�ԗ��Ǘ��I�v�V����>

            return SalesSlipData.CarMngDivCd.Equals(1);
        }

        #endregion // </�␳����>

        #region <�����f�[�^/���������f�[�^>

        /// <summary>
        /// �����n�p�����[�^(�����f�[�^/���������f�[�^)���擾���܂��B
        /// </summary>
        /// <param name="salesSlip">����f�[�^</param>
        /// <param name="depsitMainWork">�����f�[�^</param>
        /// <param name="depositAlwWork">���������f�[�^</param>
        private static void TakeDepositParameter(
            ref SalesSlip salesSlip,
            out DepsitMainWork depsitMainWork,
            out DepositAlwWork depositAlwWork
        )
        {
            OtherAppComponent otherComponent = new OtherAppComponent(
                salesSlip.EnterpriseCode,
                salesSlip.SectionCode
            );

            SearchDepsitMain searchDepsitMain = null;   // �����f�[�^
            SearchDepositAlw searchDepositAlw = null;   // ���������f�[�^

            otherComponent.GetCurrentDepsitMain(ref salesSlip, out searchDepsitMain, out searchDepositAlw);

            // ���[�N�^�ɕϊ�
            OtherAppComponent.ParamDataFromUIDataProc(searchDepsitMain, out depsitMainWork);
            depositAlwWork = OtherAppComponent.ConvertWork(searchDepositAlw);
        }

        #endregion // </�����f�[�^/���������f�[�^>

        #region <��������>

        /// <summary>
        /// �����p�̃C���X�^���X�𐶐����܂��B
        /// </summary>
        /// <returns>�����p�̃C���X�^���X</returns>
        protected virtual SCMSalesListEssence CreateSplitedEssence()
        {
            return new SCMSalesListEssence();
        }

        /// <summary>
        /// ����f�[�^�𕪊����܂��B
        /// </summary>
        /// <returns>�������ꂽ����f�[�^</returns>
        public IList<SCMSalesListEssence> Split()
        {
            // ���㖾�׃f�[�^�̍ő吔
            int salesDetailMax = GetMaxRowCount(SalesSlipData);

            // �\�[�g�ςݔ��㖾�׃f�[�^���X�g
            IList<SalesDetail> sortedSalesDetailList = SortedSalesDetailListFactory.CreateSortedSalesDetailList(
                SalesSlipData,
                SalesDetailDataList
            );

            IList<SCMSalesListEssence> splitedEssenceList = new List<SCMSalesListEssence>();
            {
                int salesDetailCount = salesDetailMax;

                int currentEssenceIndex = -1;
                foreach (SalesDetail salesDetail in sortedSalesDetailList)
                {
                    // ���㖾�׃f�[�^���ő吔�ɂȂ�����A�ʓ`�[(����f�[�^)
                    if (salesDetailCount >= salesDetailMax)
                    {
                        splitedEssenceList.Add(CreateSplitedEssence());
                        currentEssenceIndex++;
                        salesDetailCount = 0;
                    }

                    // ���㖾�׃f�[�^�ɑΉ�����SCM�󒍖��׃f�[�^(��)���擾
                    ISCMOrderAnswerRecord answerRecord = GetSCMAnswerRecord(salesDetail);

                    // SCM�󒍖��׃f�[�^(��)�ɑΉ�����SCM�󒍖��׃f�[�^(�⍇���E����)���擾
                    ISCMOrderDetailRecord detailRecord = GetSCMDetailRecord(answerRecord);

                    // SCM�󒍖��׃f�[�^(��)��ǉ�
                    splitedEssenceList[currentEssenceIndex].AddSCMAnswerRecord(answerRecord, detailRecord);

                    // ���㖾�׃f�[�^��ǉ�
                    splitedEssenceList[currentEssenceIndex].AddSalesDetailData(salesDetail.Clone(), answerRecord);

                    // �����[�g�Q�Ɨp���׃p�����[�^��ǉ�
                    SlipDetailAddInfoWork slipDetailAddInfo = GetSlipDetailAddInfo(answerRecord);
                    splitedEssenceList[currentEssenceIndex].AddSlipDetailAddInfo(slipDetailAddInfo, answerRecord);

                    // SCM�󒍖��׃f�[�^(�⍇���E����)��ǉ�
                    splitedEssenceList[currentEssenceIndex].AddSCMDetailRecord(detailRecord);

                    // ----- ADD 2011/08/10 ----- >>>>>
                    // SCM�󒍃Z�b�g�f�[�^��ǉ�
                    // ����Z�b�g�f�[�^�ɑΉ�����SCM�󒍃Z�b�g�f�[�^���擾
                    List<ISCMAcOdSetDtRecord> setRecordList = GetSCMSetRecord(answerRecord);
                    if (setRecordList != null && setRecordList.Count > 0)
                    {
                        foreach (ISCMAcOdSetDtRecord SetDtRecord in setRecordList)
                        {
                            splitedEssenceList[currentEssenceIndex].AddSCMSetRecord(SetDtRecord);
                        }
                    }
                    // ----- ADD 2011/08/10 ----- <<<<<

                    salesDetailCount++; // ���㖾�׃f�[�^���J�E���g
                }   // foreach (SalesDetail salesDetail in SalesDetailDataList)

                // ���������`�[(����f�[�^)�ŋ��ʂ̏���ݒ�
                foreach (SCMSalesListEssence salesListEssence in splitedEssenceList)
                {
                    // SCM�󒍃f�[�^��ǉ�
                    // SCM�󒍃f�[�^ : ����f�[�^ = n : 1 �ɂȂ�̂ŁA�R�s�[��ݒ肷��
                    salesListEssence.SCMHeaderRecord = new UserSCMOrderHeaderRecord(
                        SCMHeaderRecord as UserSCMOrderHeaderRecord
                    );

                    // SCM�󒍃f�[�^(�ԗ����)��ǉ�
                    // SCM�󒍃f�[�^(�ԗ����) : ����f�[�^ = n : 1�ɂȂ�̂ŁA�R�s�[��ݒ肷��
                    salesListEssence.SCMCarRecord = new UserSCMOrderCarRecord(
                        SCMCarRecord as UserSCMOrderCarRecord
                    );

                    // ����f�[�^��ǉ�
                    salesListEssence.SalesSlipData = SalesSlipData.Clone();
                    
                    // �ԗ��Ǘ��f�[�^��ǉ�
                    foreach (CarManagementWork carMng in CarManagementList)
                    {
                        salesListEssence.AddCarManagementData(carMng);
                    }
                }   // foreach (SCMSalesListEssence salesListEssence in splitedEssenceList)
            }

            // ����񓚕���ǉ�����i��̏ꍇ�A����񓚂݂̂̏��������삷��̂Ŗ����j
            if (!ListUtil.IsNullOrEmpty(splitedEssenceList))
            {
                int lastEssenceIndex = splitedEssenceList.Count - 1;
                foreach (ISCMOrderAnswerRecord answerRecord in SCMAnswerRecordList)
                {
                    if (!IsSobaAnswer(answerRecord)) continue;

                    // SCM�󒍖��׃f�[�^(��)�ɑΉ�����SCM�󒍖��׃f�[�^(�⍇���E����)���擾
                    ISCMOrderDetailRecord detailRecord = GetSCMDetailRecord(answerRecord);

                    // SCM�󒍖��׃f�[�^(��)��ǉ�
                    splitedEssenceList[lastEssenceIndex].AddSCMAnswerRecord(answerRecord, detailRecord);
                }
            }
            return splitedEssenceList;
        }

        /// <summary>
        /// ����񓚂ł��邩���f���܂��B
        /// </summary>
        /// <param name="answerRecord">SCM�󒍖��׃f�[�^(��)�̃��R�[�h</param>
        /// <returns>
        /// <c>true</c> :����񓚂ł��B<br/>
        /// <c>false</c>:����񓚂ł͂���܂���B
        /// </returns>
        private static bool IsSobaAnswer(ISCMOrderAnswerRecord answerRecord)
        {
            if (
                answerRecord.GoodsDivCd.Equals((int)GoodsDivCd.MarketPrice)
                    ||
                answerRecord.GoodsDivCd.Equals((int)GoodsDivCd.Recycle)
            )
            {
                return true;
            }
            return false;
        }

        #endregion // </��������>

        #region <���㖾�ׂ̍ő�s��>

        /// <summary>�f�t�H���g�ő喾�׍s��</summary>
        public static readonly int DEFAULT_MAX_ROW_COUNT = 9999;

        /// <summary>
        /// ���׍ő�s�����擾���܂��B
        /// </summary>
        /// <remarks>
        /// MAHNB01012AA.cs SalesSlipInputAcs.GetMaxRowCount() 14110�s�ڂ��ڐA
        /// </remarks>
        /// <param name="salesSlip">����f�[�^</param>
        /// <returns>���׍ő�s��</returns>
        private static int GetMaxRowCount(SalesSlip salesSlip)
        {
            int maxRowCount = DEFAULT_MAX_ROW_COUNT;
            {
                SlipPrtSet slipPrtSet = null;
                // FIXME:switch ((AcptAnOdrStatus)salesSlip.AcptAnOdrStatusDisplay)
                switch ((AcptAnOdrStatus)salesSlip.AcptAnOdrStatus)
                {
                    case AcptAnOdrStatus.Estimate:  // ����
                        slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.EstimateSlip, salesSlip);
                        break;
                    case AcptAnOdrStatus.Order:     // ��
                        slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.AcceptSlip, salesSlip);
                        break;
                    case AcptAnOdrStatus.Sales:     // ����
                        slipPrtSet = SlipPrtSetDB.GetPrtSlipSet(SlipTypeController.SlipKind.SalesSlip, salesSlip);
                        break;
                }
                if ((slipPrtSet != null) && (slipPrtSet.DetailRowCount > 0)) maxRowCount = slipPrtSet.DetailRowCount;
            }
            return maxRowCount;
        }

        #endregion // </���㖾�ׂ̍ő�s��>

        // -- ADD 2011/08/10   ------ >>>>>>
        #region <SCM�󒍃Z�b�g�f�[�^>

        /// <summary>SCM�󒍃Z�b�g�f�[�^��SCM�󒍖��׃f�[�^(�⍇���E����)�̊֘A�}�b�v</summary>
        private IDictionary<Guid, List<ISCMAcOdSetDtRecord>> _SetDetailMap;
        /// <summary>SCM�󒍃Z�b�g�f�[�^��SCM�󒍖��׃f�[�^(�⍇���E����)�̊֘A�}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�F�񓚃f�[�^�̊֘AGUID</remarks>
        private IDictionary<Guid, List<ISCMAcOdSetDtRecord>> SetDetailMap
        {
            get
            {
                if (_SetDetailMap == null)
                {
                    _SetDetailMap = new Dictionary<Guid, List<ISCMAcOdSetDtRecord>>();
                }
                return _SetDetailMap;
            }
        }

        /// <summary>
        /// SCM�󒍃Z�b�g�f�[�^�̃��R�[�h��ǉ����܂��B
        /// </summary>
        /// <param name="scmAnswerRecord">CM�󒍖��׃f�[�^(��)�̃��R�[�h</param>
        /// <param name="OdSetDtRecordList">SCM�󒍃Z�b�g�f�[�^�̃��R�[�h���X�g</param>
        /// <exception cref="ArgumentNullException">
        /// �ǉ�����SCM�󒍃Z�b�g�f�[�^�̃��R�[�h��null�ł��B<br/>
        /// ���ƂȂ���SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h��null�ł��B
        /// </exception>
        public void AddSCMSetRecord(
            ISCMOrderAnswerRecord scmAnswerRecord,
            List<ISCMAcOdSetDtRecord> OdSetDtRecordList
        )
        {
            #region <Guard Phrase>

            if (scmAnswerRecord == null)
            {
                throw new ArgumentNullException("scmAnswerRecord", "�ǉ�����SCM�󒍃Z�b�g�f�[�^�̃��R�[�h��null�ł��B");
            }
            if (OdSetDtRecordList == null)
            {
                throw new ArgumentNullException("OdSetDtRecordList", "�󒍃Z�b�g�f�[�^�̃��R�[�h��null�ł��B");
            }

            #endregion // </Guard Phrase>
            for (int i = 0; i < OdSetDtRecordList.Count; i++)
            {
                AddSCMSetRecord(OdSetDtRecordList[i]);
            }
            // SCM�󒍃Z�b�g�f�[�^��SCM�󒍖��׃f�[�^(�⍇���E����)�̃}�b�v�ɒǉ�
            if (!SetDetailMap.ContainsKey(scmAnswerRecord.SalesRelationId))
            {
                SetDetailMap.Add(scmAnswerRecord.SalesRelationId, OdSetDtRecordList);
            }
        }

        /// <summary>
        /// SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h���擾���܂��B
        /// </summary>
        /// <param name="scmAnswerRecord">SCM�󒍃Z�b�g�f�[�^�̃��R�[�h</param>
        /// <returns>�Ή�����SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h</returns>
        public  List<ISCMAcOdSetDtRecord> GetSCMSetRecordList(ISCMOrderAnswerRecord scmAnswerRecord)
        {
            if (SetDetailMap.ContainsKey(scmAnswerRecord.SalesRelationId))
            {
                return SetDetailMap[scmAnswerRecord.SalesRelationId];
            }
            return null;
        }

        #endregion // <SCM�󒍃Z�b�g�f�[�^>
        // -- ADD 2011/08/10   ------ <<<<<<
    }
}
