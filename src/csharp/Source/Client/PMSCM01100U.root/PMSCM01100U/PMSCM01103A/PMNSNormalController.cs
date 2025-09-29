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
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/03/30  �C�����e : ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��� ���b
// �� �� ��  2011/02/22  �C�����e : �񓚋敪�̃Z�b�g�d�l���C���B(�񓚍ς�or�ꕔ�񓚂̔��f)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/04/09  �C�����e : SCM�d�|�ꗗ��10641�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting; // ADD m.suzuki 2011/02/22
using Broadleaf.Application.Remoting.Adapter; // ADD m.suzuki 2011/02/22

using Broadleaf.Application.Controller.Agent;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PM.NS�p�P�̋N�����[�h�񓚑��M�����R���g���[���N���X
    /// </summary>
    public sealed class PMNSNormalController : NormalModeController
    {
        // --- ADD m.suzuki 2011/02/22 ---------->>>>>
        private IIOWriteScmDB _ioWriteScmDB;

        /// <summary>
        /// SCM-IOWriter
        /// </summary>
        protected IIOWriteScmDB IOWriteScmDB
        {
            get
            {
                if ( _ioWriteScmDB == null )
                {
                    _ioWriteScmDB = (IIOWriteScmDB)MediationIOWriteScmDB.GetIOWriteScmDB();
                }
                return _ioWriteScmDB;
            }
        }
        // --- ADD m.suzuki 2011/02/22 ----------<<<<<

        #region <Override>

        #region <SCMIO����>
        /// <summary>
        /// SCM I/O�𐶐����܂��B
        /// </summary>
        /// <param name="dataPath">�f�[�^�p�X</param>
        /// <returns>PM.NS��SCM I/O</returns>
        /// <see cref="SCMSendController"/>
        protected override SCMIOAgent CreateSCMIO(string dataPath)
        {
            // DEL 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ---------->>>>>
            //return new PMNSIOAgent();
            // DEL 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ----------<<<<<
            // ADD 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ---------->>>>>
            return new PMNSIOAgent(false);   // ���Ӑ��񂪕K�v
            // ADD 2010/03/30 ���Ӑ�����擾���鏈�������X�x���̂ŁA��ʕ\�������Ȃ��ꍇ�͓��Ӑ�����擾���Ȃ� ----------<<<<<
        }
        #endregion

        #region <���M��X�V����>
        /// <summary>
        /// SCM�󒍃f�[�^���X�V���܂��B
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
            // --- UPD m.suzuki 2011/02/22 ---------->>>>>
            //foreach (SCMAcOdrDataWork header in writeHeaderList)
            for ( int index = 0; index < writeHeaderList.Count; index++ )
            // --- UPD m.suzuki 2011/02/22 ----------<<<<<
            {
                // --- ADD m.suzuki 2011/02/22 ---------->>>>>
                SCMAcOdrDataWork header = writeHeaderList[index];
                // --- ADD m.suzuki 2011/02/22 ----------<<<<<

                SCMAcOdrDtCarWork car;
                List<SCMAcOdrDtlAsWork> answerList;

                // �w�b�_�ɕR�Â��f�[�^���擾
                this.GetRelatedSCMOdrData(header, writeAnswerList, writeCarList,
                                                out answerList, out car);

                // --- ADD m.suzuki 2011/02/22 ---------->>>>>
                // �o�^�pSCM�󒍃f�[�^(header)�̍X�V
                this.ReflectSCMAcOdrData( ref header, answerList );
                // --- ADD m.suzuki 2011/02/22 ----------<<<<<

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
        // --- ADD m.suzuki 2011/02/22 ---------->>>>>
        /// <summary>
        /// �o�^�pSCM�󒍃f�[�^�X�V(header)
        /// </summary>
        /// <param name="header"></param>
        /// <param name="answerList"></param>
        private void ReflectSCMAcOdrData( ref SCMAcOdrDataWork header, List<SCMAcOdrDtlAsWork> answerList )
        {
            //----------------------------------------
            // UserDB�ǂݍ���
            //----------------------------------------
            # region [UserDB�ǂݍ���]
            // �����ݒ�
            IOWriteSCMReadWork readPara = new IOWriteSCMReadWork();
            readPara.EnterpriseCode = header.EnterpriseCode;
            readPara.InquiryNumber = header.InquiryNumber;
            readPara.InqOtherSecCd = header.InqOtherSecCd;
            readPara.InqOriginalEpCd = header.InqOriginalEpCd.Trim();//@@@@20230303
            readPara.InqOriginalSecCd = header.InqOriginalSecCd;
            readPara.AnswerDivCds = new int[] { 0, 10, 20 }; // 0:�A�N�V�����Ȃ�,10:�ꕔ��,20:�񓚊���
            // (���⍇���E�����E�ԕi����ʂ���)
            readPara.InqOrdDivCd = header.InqOrdDivCd;
            readPara.CancelDivs = new short[] { header.CancelDiv };

            // �ǂݍ���
            object retObj = new CustomSerializeArrayList();
            int status = this.IOWriteScmDB.ScmRead( ref retObj, (object)readPara );

            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) return;
            SCMAcOdrDataWork scmHeaderWork;
            SCMAcOdrDtCarWork scmCarWork;
            List<SCMAcOdrDtlIqWork> scmDetailWorkList;
            List<SCMAcOdrDtlAsWork> scmAnswerWorkList;

            // �f�[�^����
            IOWriterUtil.ExpandSCMReadRet( retObj, out scmHeaderWork, out scmDetailWorkList, out scmAnswerWorkList, out scmCarWork );
            # endregion

            //----------------------------------------
            // �₢���킹�Ɖ񓚂̕t�����킹
            //----------------------------------------
            bool existsAllAnswer = this.ExistsAllAnswer( header, answerList, scmDetailWorkList, scmAnswerWorkList );

            //----------------------------------------
            // header�X�V
            //----------------------------------------
            // �񓚋敪(10:�ꕔ��,20:�񓚊���)
            if ( existsAllAnswer )
            {
                header.AnswerDivCd = 20; // 20:�񓚊���
            }
            else
            {
                header.AnswerDivCd = 10; // 10:�ꕔ��
            }
        }

        /// <summary>
        /// �񓚍ς݃`�F�b�N��������
        /// </summary>
        /// <param name="header"></param>
        /// <param name="answerList"></param>
        /// <param name="scmDetailWorkList"></param>
        /// <param name="scmAnswerWorkList"></param>
        /// <returns>true: ���ׂɑ΂��ĉ񓚂��S�đ��݂���B�^false: �܂����񓚂̖��ׂ�����B</returns>
        private bool ExistsAllAnswer( SCMAcOdrDataWork header, List<SCMAcOdrDtlAsWork> answerList, List<SCMAcOdrDtlIqWork> scmDetailWorkList, List<SCMAcOdrDtlAsWork> scmAnswerWorkList )
        {
            // �₢���킹�[�����Ȃ�S�ĉ񓚍ς݂Ƃ݂Ȃ�
            if ( scmDetailWorkList == null || scmDetailWorkList.Count.Equals( 0 ) ) return true;

            // ����ȊO�ŉ񓚃[�����Ȃ疢�񓚂���Ƃ݂Ȃ��B
            if ( (answerList == null || answerList.Count.Equals( 0 )) &&
                 (scmAnswerWorkList == null || scmAnswerWorkList.Count.Equals( 0 )) ) return false;


            foreach ( SCMAcOdrDtlIqWork inq in scmDetailWorkList )
            {
                // 30:�L�����Z���m��̓`�F�b�N�ΏۊO(�񓚕s�v�̈�)
                if ( inq.CancelCndtinDiv == 30 ) continue;

                bool existsAns = false;

                // ����X�V����񓚃��X�g����T��
                foreach ( SCMAcOdrDtlAsWork ans in answerList )
                {
                    if ( IsParenthoodRowNumber( ans, inq ) )
                    {
                        existsAns = true;
                        break;
                    }
                }

                if ( !existsAns )
                {
                    // ����UserDB�ɑ��݂���񓚃��X�g����T��
                    foreach ( SCMAcOdrDtlAsWork ans in scmAnswerWorkList )
                    {
                        if ( IsParenthood( ans, inq ) )
                        {
                            existsAns = true;
                            break;
                        }
                    }
                }

                // �񓚂��������ׂ��P���ł������false �� �ꕔ��
                if ( !existsAns )
                {
                    return false;
                }
            }

            // �S���񓚂����� �� �񓚍ς�
            return true;
        }
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
        internal static bool IsParenthood( SCMAcOdrDtlAsWork ans, SCMAcOdrDtlIqWork inq )
        {
            if ( ans.InqRowNumber.Equals( inq.InqRowNumber ) && ans.InqRowNumDerivedNo.Equals( inq.InqRowNumDerivedNo ) )
            {
                if ( ans.UpdateDate > inq.UpdateDate )
                {
                    return true;
                }
                else if ( ans.UpdateDate == inq.UpdateDate )
                {
                    return (ans.UpdateTime > inq.UpdateTime);
                }
            }
            return false;
        }
        /// <summary>
        /// �Ή����邩���肵�܂��B(�s�ԍ��E�s�ԍ��}�Ԃ݂̂Ŕ���)
        /// </summary>
        /// <param name="ans"></param>
        /// <param name="inq"></param>
        /// <returns></returns>
        internal static bool IsParenthoodRowNumber( SCMAcOdrDtlAsWork ans, SCMAcOdrDtlIqWork inq )
        {
            if ( ans.InqRowNumber.Equals( inq.InqRowNumber ) && ans.InqRowNumDerivedNo.Equals( inq.InqRowNumDerivedNo ) )
            {
                return true;
            }
            return false;
        }
        // --- ADD m.suzuki 2011/02/22 ----------<<<<<
        #endregion

        #region <�폜�{�^���������̍폜����>
        /// <summary>
        /// �폜�{�^���������̍폜����
        /// </summary>
        /// <returns></returns>
        protected override int ExecuteDelete(DataRowView drv)
        {
            // �L�[�̎擾
            string inqOriginalEpCd = drv.Row[SendingHeaderTable.InqOriginalEpCdColumn.ColumnName].ToString().Trim();	//@@@@20230303
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

            // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ---------------------------------->>>>>
            // �⍇���ԍ����[���i�_�C���N�g�񓚁j���͕����폜���s��
            if (header.InquiryNumber == 0)
            {
                header.LogicalDeleteCode = 1;
                if (car != null)
                {
                    car.LogicalDeleteCode = 1;
                }
            }
            // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ----------------------------------<<<<<

            header.UpdateDate = updateDate;
            header.UpdateTime = updateTime;

            foreach (SCMAcOdrDtlAsWork answer in answerList)
            {
                // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ---------------------------------->>>>>
                // �⍇���ԍ����[���i�_�C���N�g�񓚁j���͕����폜���s��
                if (header.InquiryNumber == 0)
                {
                    answer.LogicalDeleteCode = 1;
                }
                // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ----------------------------------<<<<<
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

        #endregion // </Override>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PMNSNormalController() : base() { }

        #endregion // </Constructor>
    }
}
