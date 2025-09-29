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
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PM7�p���M�N�����[�h�񓚑��M�����R���g���[���N���X
    /// </summary>
    public sealed class PM7BatchController : BatchModeController
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

            // TODO:�S�~�|���c���C���^�[�t�F�[�X(/B ...)�̔p�~
            #region <�{�c>
            //// �N���p�����[�^����K�v�ȃf�[�^���擾����
            //string salesSlipNum = _commandLineArgs[1];
            //int acptAnOdrStatus = PM7IOAgent.ConvertAcptAnOdrStatus(Convert.ToInt32(_commandLineArgs[2]));
            //int serverNumber    = Convert.ToInt32(_commandLineArgs[3]);
            //int customerCd      = Convert.ToInt32(_commandLineArgs[4]);

            //return new PM7IOAgent(dataPath, salesSlipNum, acptAnOdrStatus, serverNumber, customerCd);
            #endregion // </�{�c>
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

        #region <�ۑ������؂�f�[�^�폜����>
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

        #region <�R�}���h���C������>

        /// <summary>�R�}���h���C������</summary>
        private readonly string[] _commandLineArgs;
        /// <summary>�R�}���h���C���������擾���܂��B</summary>
        private string[] CommandLineArgs { get { return _commandLineArgs; } }

        #endregion // </�R�}���h���C������>

        #region <Constructor>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="path">�f�[�^�p�X</param>
        public PM7BatchController(string path) : base(path) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="commandLineArgs">�R�}���h���C������</param>
        [Obsolete("PM7�p�̑��M�N�����[�h�̓R���X�g���N�^(string)���g�p���ĉ������B")]
        public PM7BatchController(string[] commandLineArgs) : base(string.Empty)
        {
            _commandLineArgs = commandLineArgs;
        }

        #endregion // </Constructor>
    }
}
