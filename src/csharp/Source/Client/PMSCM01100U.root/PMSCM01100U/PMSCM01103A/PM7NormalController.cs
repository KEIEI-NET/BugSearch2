//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/06/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PM7�p�P�̋N�����[�h�񓚑��M�����R���g���[���N���X
    /// </summary>
    public sealed class PM7NormalController : NormalModeController
    {
        #region <Override>

        #region <SCMIO����>
        /// <summary>
        /// SCM I/O�𐶐����܂��B
        /// </summary>
        /// <param name="dataPath">�f�[�^�p�X</param>
        /// <returns>PM7��SCM I/O</returns>
        /// <see cref="SCMSendController"/>
        protected override SCMIOAgent CreateSCMIO(string dataPath)
        {
            return new PM7IOAgent(dataPath);
        }
        #endregion

        #region <���M��X�V����>
        /// <summary>
        /// SCM�󒍃f�[�^���X�V���܂��B(PMNSNormal�Ɠ���)
        /// </summary>
        /// <returns>���ʃR�[�h</returns>
        /// <see cref="SCMSendController"/>
        protected override int UpdateAfterSend()
        {
            if (((List<ISCMOrderHeaderRecord>)SCMWebDB.WritedResult.First).Count == 0)
            {
                // �Ώ�0��
                WriteLog("�X�V�Ώۃ��R�[�h��0���ł��B");
                return 0;
            }

            List<ISCMOrderHeaderRecord> userSCMOrderHeaderRecordList = (List<ISCMOrderHeaderRecord>)SCMWebDB.WritedResult.First;
            List<ISCMOrderCarRecord> userSCMOrderCarRecordList = (List<ISCMOrderCarRecord>)SCMWebDB.WritedResult.Second;
            List<ISCMOrderAnswerRecord> userSCMOrderAnswerRecordList = (List<ISCMOrderAnswerRecord>)SCMWebDB.WritedResult.Third;

            // �^�ϊ�
            List<SCMAcOdrDataWork> writeHeaderList = new List<SCMAcOdrDataWork>();
            foreach (UserSCMOrderHeaderRecord userSCMOrderHeaderRecord in userSCMOrderHeaderRecordList)
            {
                writeHeaderList.Add(userSCMOrderHeaderRecord.RealRecord);
            }

            List<SCMAcOdrDtCarWork> writeCarList = new List<SCMAcOdrDtCarWork>();
            foreach (UserSCMOrderCarRecord userSCMOrderCarRecord in userSCMOrderCarRecordList)
            {
                writeCarList.Add(userSCMOrderCarRecord.RealRecord);
            }

            List<SCMAcOdrDtlAsWork> writeAnswerList = new List<SCMAcOdrDtlAsWork>();
            foreach (UserSCMOrderAnswerRecord userSCMOrderAnswerRecord in userSCMOrderAnswerRecordList)
            {
                writeAnswerList.Add(userSCMOrderAnswerRecord.RealRecord);
            }

            // IOWriter�̈���
            CustomSerializeArrayList writeList = new CustomSerializeArrayList();
            foreach (SCMAcOdrDataWork header in writeHeaderList)
            {
                SCMAcOdrDtCarWork car;
                List<SCMAcOdrDtlAsWork> answerList;

                // �w�b�_�ɕR�Â��f�[�^���擾
                this.GetRelatedSCMOdrData(header, writeAnswerList, writeCarList,
                                                out answerList, out car);

                ArrayList answerArrayList = new ArrayList();
                answerArrayList.AddRange(answerList);

                // 1�X�V�������X�g�ɒǉ�
                CustomSerializeArrayList oneWriteList = new CustomSerializeArrayList();

                oneWriteList.Add(header); // �󒍃f�[�^
                oneWriteList.Add(car); // �󒍃f�[�^(�ԗ�)
                oneWriteList.Add(answerArrayList); // �󒍖��׃f�[�^(��)

                writeList.Add(oneWriteList);
            }

            // �X�V�������s
            object writePara = writeList;

            // Write���s
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = SCMIO.UpdateData(writePara);

            return status;
        }
        #endregion

        #region <�폜�{�^���������̍폜����>
        /// <summary>
        /// �폜�{�^���������̍폜����(PMNSNormal�ƈꏏ)
        /// </summary>
        /// <returns></returns>
        protected override int ExecuteDelete(DataRowView drv)
        {
            // �L�[�̎擾
            string inqOriginalEpCd = drv.Row[SendingHeaderTable.InqOriginalEpCdColumn.ColumnName].ToString().Trim();//@@@@20230303
            string inqOriginalSecCd = drv.Row[SendingHeaderTable.InqOriginalSecCdColumn.ColumnName].ToString();
            string inqOtherEpCd = drv.Row[SendingHeaderTable.InqOtherEpCdColumn.ColumnName].ToString();
            string inqOtherSecCd = drv.Row[SendingHeaderTable.InqOtherSecCdColumn.ColumnName].ToString();
            Int64 inquiryNumber = (Int64)drv.Row[SendingHeaderTable.InquiryNumberColumn.ColumnName];
            Int32 inqOrdDivCd = (Int32)drv.Row[SendingHeaderTable.InqOrdDivCdColumn.ColumnName];
            Int32 acptAnOdrStatus = (Int32)drv.Row[SendingHeaderTable.AcptAnOdrStatusColumn.ColumnName];
            string salesSlipNum = drv.Row[SendingHeaderTable.SalesSlipNumColumn.ColumnName].ToString();

            // �Y���f�[�^�̎擾
            List<SCMAcOdrDataWork> allHeader = SCMIO.CreateUserHeaderRecordList();
            List<SCMAcOdrDtCarWork> allCar = SCMIO.CreateUserCarRecordList();
            List<SCMAcOdrDtlAsWork> allAnswer = SCMIO.CreateUserAnswerRecordList();

            SCMAcOdrDataWork header = allHeader.Find(
                delegate(SCMAcOdrDataWork headerWork)
                {
                    if (headerWork.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && headerWork.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && headerWork.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && headerWork.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && headerWork.InquiryNumber == inquiryNumber
                        && headerWork.InqOrdDivCd == inqOrdDivCd
                        && headerWork.AcptAnOdrStatus == acptAnOdrStatus
                        && headerWork.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            SCMAcOdrDtCarWork car = allCar.Find(
                delegate(SCMAcOdrDtCarWork carWork)
                {
                    if (carWork.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && carWork.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && carWork.InquiryNumber == inquiryNumber
                        && carWork.AcptAnOdrStatus == acptAnOdrStatus
                        && carWork.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            List<SCMAcOdrDtlAsWork> answerList = allAnswer.FindAll(
                delegate(SCMAcOdrDtlAsWork answerWork)
                {
                    if (answerWork.InqOriginalEpCd.Trim() == inqOriginalEpCd.Trim()
                        && answerWork.InqOriginalSecCd.Trim() == inqOriginalSecCd.Trim()
                        && answerWork.InqOtherEpCd.Trim() == inqOtherEpCd.Trim()
                        && answerWork.InqOtherSecCd.Trim() == inqOtherSecCd.Trim()
                        && answerWork.InquiryNumber == inquiryNumber
                        && answerWork.InqOrdDivCd == inqOrdDivCd
                        && answerWork.AcptAnOdrStatus == acptAnOdrStatus
                        && answerWork.SalesSlipNum == salesSlipNum)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // �X�V�N�����̍X�V
            DateTime updateDate = DateTime.Now;
            Int32 updateTime = updateDate.Hour * 10000000 + updateDate.Minute * 100000 + updateDate.Second * 1000 + updateDate.Millisecond;

            header.UpdateDate = updateDate;
            header.UpdateTime = updateTime;

            foreach (SCMAcOdrDtlAsWork answer in answerList)
            {
                answer.UpdateDate = updateDate;
                answer.UpdateTime = updateTime;
            }

            ArrayList answerArrayList = new ArrayList();
            answerArrayList.AddRange(answerList);

            // IOWriter�̈���
            CustomSerializeArrayList writeList = new CustomSerializeArrayList();

            // 1�X�V�������X�g�ɒǉ�
            CustomSerializeArrayList oneWriteList = new CustomSerializeArrayList();

            oneWriteList.Add(header); // �󒍃f�[�^
            if (car != null)
            {
                oneWriteList.Add(car); // �󒍃f�[�^(�ԗ�)
            }
            oneWriteList.Add(answerArrayList); // �󒍖��׃f�[�^(��)

            writeList.Add(oneWriteList);

            object writePara = writeList;

            int status = SCMIO.UpdateData(writePara);

            return status;
        }
        #endregion

        #region <�ۑ������؂�XML�t�@�C���̍폜����>
        /// <summary>
        /// �ۑ����Ԃ��߂����f�[�^�̍폜����
        /// </summary>
        /// <returns></returns>
        protected override int DeleteExpiredData(DateTime limitdate)
        {
            SCMIO.DeletePassedPeriodXMLFiles(limitdate);

            return 0;
        }
        #endregion

        #endregion // </Override>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PM7NormalController() : base()
        {
            // SCM�S�̐ݒ�}�X�^����p�X�̐ݒ���s��
            SCMTotalSettingAgent scmTotalSettingDB = new SCMTotalSettingAgent();
            {
                SCMTtlSt scmTtlSt = scmTotalSettingDB.Find(
                    LoginInfoAcquisition.EnterpriseCode,
                    LoginInfoAcquisition.Employee.BelongSectionCode
                );
                if (
                    scmTtlSt != null
                        && !string.IsNullOrEmpty(scmTtlSt.EnterpriseCode.Trim())
                        && !string.IsNullOrEmpty(scmTtlSt.SectionCode.Trim())
                        && scmTtlSt.LogicalDeleteCode.Equals(0)
                )
                {
                    // ���V�X�e���A�g�敪���u1:����(PM7SP)�v ��0:���Ȃ�(PM.NS)
                    if (scmTtlSt.OldSysCooperatDiv.Equals(1))
                    {
                        SettingInfo.SCMDataPath = SCMConfig.GetSCMSendingDataPath(scmTtlSt);
                        _logFilePath = Path.Combine(SettingInfo.SCMDataPath, LOG_FILE_NAME);
                    }
                }
            }
        }

        #endregion // </Constructor>
    }
}
