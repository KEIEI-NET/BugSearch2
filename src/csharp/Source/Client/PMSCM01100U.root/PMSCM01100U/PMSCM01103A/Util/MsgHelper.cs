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
// �� �� ��  2009/07/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// ���O�̃w���p�N���X
    /// </summary>
    public static class MsgHelper
    {
        private const string RUN        = "��N����";
        private const string START      = "�y�J�n�z";
        private const string END        = "�y�����z";
        private const string ERROR      = "�y�ُ�z";
        private const string EXCEPTION  = "�y��O�z";
        private const string INFO       = "\t[���]";
        private const string ALERT      = "\t<�x��>";
        private const string DEBUG      = "\t(Debug)";
        private const string AT         = "�F";

        #region <���b�Z�[�W>

        /// <summary>
        /// �N�����b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>�N�����b�Z�[�W</returns>
        public static string GetRunMsg(string msg)
        {
            return RUN + msg;
        }

        /// <summary>
        /// �J�n���b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>�J�n���b�Z�[�W</returns>
        public static string GetStartMsg(string msg)
        {
            return START + msg;
        }

        /// <summary>
        /// �������b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="status"></param>
        /// <returns>�������b�Z�[�W</returns>
        public static string GetEndMsg(
            string msg,
            int status
        )
        {
            return END + msg + AT + status.ToString();
        }

        /// <summary>
        /// �ُ탁�b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="status">�����X�e�[�^�X</param>
        /// <returns>�ُ탁�b�Z�[�W + "�F" + �����X�e�[�^�X</returns>
        public static string GetErrorMsg(
            string msg,
            int status
        )
        {
            return ERROR + msg + AT + status.ToString();
        }

        /// <summary>
        /// ��O���b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="ex">��O</param>
        /// <returns>��O���b�Z�[�W + <c>ex.Message</c></returns>
        public static string GetExceptionMsg(
            string msg,
            Exception ex
        )
        {
            if (ex == null) return EXCEPTION + msg;
            return EXCEPTION + msg + Environment.NewLine + ex.Message;
        }

        /// <summary>
        /// ��񃁃b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>��񃁃b�Z�[�W</returns>
        public static string GetInfoMsg(string msg)
        {
            return INFO + msg;
        }

        /// <summary>
        /// �x�����b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>�x�����b�Z�[�W</returns>
        public static string GetAlertMsg(string msg)
        {
            return ALERT + msg;
        }

        /// <summary>
        /// �f�o�b�O���b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>�f�o�b�O���b�Z�[�W</returns>
        public static string GetDebugMsg(string msg)
        {
            return DEBUG + msg;
        }

        #endregion // </���b�Z�[�W>

        /// <summary>
        /// ��O���O���o�͂��܂��B
        /// </summary>
        /// <param name="className">�N���X����</param>
        /// <param name="methodName">���\�b�h����</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="ex">��O</param>
        public static void WriteExceptionLog(
            string className,
            string methodName,
            string msg,
            Exception ex
        )
        {
            SimpleLogger.Write(className, methodName, GetExceptionMsg(msg, ex));

            string info = EXCEPTION + msg;
            if (ex != null) info = EXCEPTION + msg + Environment.NewLine + ex.ToString();
            SimpleLogger.WriteDebugLog(className, methodName, info);
        }

        /// <summary>
        /// �f�[�^���b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="title">�^�C�g��</param>
        /// <param name="scmHeaderRecordList">SCM�󒍃f�[�^�̃��R�[�h���X�g</param>
        /// <param name="scmCarRecordList">SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h���X�g</param>
        /// <param name="scmDetailRecordList">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h���X�g</param>
        /// <returns>���R�[�h��CSV�ɕϊ�</returns>
        public static string GetDataMsg(
            string title,
            IList<ISCMOrderHeaderRecord> scmHeaderRecordList,
            IList<ISCMOrderCarRecord> scmCarRecordList,
            IList<ISCMOrderDetailRecord> scmDetailRecordList
        )
        {
            return GetDataMsg(title, scmHeaderRecordList, scmCarRecordList, scmDetailRecordList, null);
        }

        /// <summary>
        /// �f�[�^���b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="title">�^�C�g��</param>
        /// <param name="scmHeaderRecordList">SCM�󒍃f�[�^�̃��R�[�h���X�g</param>
        /// <param name="scmCarRecordList">SCM�󒍃f�[�^(�ԗ����)�̃��R�[�h���X�g</param>
        /// <param name="scmDetailRecordList">SCM�󒍖��׃f�[�^(�⍇���E����)�̃��R�[�h���X�g</param>
        /// <param name="scmAnswerRecordList">SCM�󒍖��׃f�[�^(��)�̃��R�[�h���X�g</param>
        /// <returns>���R�[�h��CSV�ɕϊ�</returns>
        public static string GetDataMsg(
            string title,
            IList<ISCMOrderHeaderRecord> scmHeaderRecordList,
            IList<ISCMOrderCarRecord> scmCarRecordList,
            IList<ISCMOrderDetailRecord> scmDetailRecordList,
            IList<ISCMOrderAnswerRecord> scmAnswerRecordList
        )
        {
            StringBuilder msg = new StringBuilder();
            {
                msg.Append(DEBUG).Append(title).Append(Environment.NewLine);
                msg.Append(Environment.NewLine);
                if (scmHeaderRecordList != null)
                {
                    msg.Append("[SCM�󒍃f�[�^]").Append(Environment.NewLine);
                    msg.Append(SCMEntityUtil.ConvertCSV(scmHeaderRecordList));
                }
                if (scmCarRecordList != null)
                {
                    msg.Append("[SCM�󒍃f�[�^(�ԗ����)]").Append(Environment.NewLine);
                    msg.Append(SCMEntityUtil.ConvertCSV(scmCarRecordList));
                }
                if (scmDetailRecordList != null)
                {
                    msg.Append("[SCM�󒍖��׃f�[�^(�⍇���E����)]").Append(Environment.NewLine);
                    msg.Append(SCMEntityUtil.ConvertCSV(scmDetailRecordList));
                }
                if (scmAnswerRecordList != null)
                {
                    msg.Append("[SCM�󒍖��׃f�[�^(��)]").Append(Environment.NewLine);
                    msg.Append(SCMEntityUtil.ConvertCSV(scmAnswerRecordList));
                }
            }
            return msg.ToString();
        }
    }
}
