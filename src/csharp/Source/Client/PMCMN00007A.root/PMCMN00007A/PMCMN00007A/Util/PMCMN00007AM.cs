using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// ���b�Z�[�W���[�e�B���e�B
    /// </summary>
    public static class MsgUtil
    {
        /// <summary>
        /// �������擾���܂��B
        /// </summary>
        /// <param name="operationLimit">�I�y���[�V���������l</param>
        /// <returns>���쌠�����i�Y������I�y���[�V���������l���Ȃ��ꍇ�A<code>string.Empty</code>��Ԃ��܂��j</returns>
        public static string GetAdmissionName(OperationLimit operationLimit)
        {
            switch (operationLimit)
            {
                //case OperationLimit.Enable:
                //    return "��";            // LITERAL:
                case OperationLimit.EnableWithLog:
                    return "��(���O�L�^)";  // LITERAL:
                case OperationLimit.Disable:
                    return "�s��";          // LITERAL:
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// ���O��ʖ����擾���܂��B
        /// </summary>
        /// <param name="logDataKind">���O��ʒl</param>
        /// <returns>���O��ʖ��i�Y�����郍�O��ʒl���Ȃ��ꍇ�A<code>string.Empty</code>��Ԃ��܂��j</returns>
        public static string GetLogDataKindName(LogDataKind logDataKind)
        {
            switch (logDataKind)
            {
                case LogDataKind.OperationLog:
                    return "����";      // LITERAL:
                case LogDataKind.ErrorLog:
                    return "�G���[";    // LITERAL:
                case LogDataKind.SystemLog:
                    return "�V�X�e��";  // LITERAL:
                case LogDataKind.UoeDspLog:
                    return "UOE(DSP)";  // LITERAL:
                case LogDataKind.UoeCommLog:
                    return "UOE(�ʐM)"; // LITERAL:
                default:
                    return string.Empty;
            }
        }

        #region [GetMsg]
        /// <summary>
        /// ���b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="status">�X�e�[�^�X�R�[�h</param>
        /// <param name="str">������</param>
        /// <returns>"�X�e�[�^�X�F[{0}]�@������F[{1}]"</returns>
        public static string GetMsg(
            int status,
            string str
        )
        {
            const string FORMAT = "�X�e�[�^�X�F[{0}]�@������F[{1}]";
            return string.Format(FORMAT, status, str);
        }

        /// <summary>
        /// ���b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="status">�X�e�[�^�X�R�[�h</param>
        /// <param name="number">���l</param>
        /// <returns>"�X�e�[�^�X�F[{0}]�@���l�F[{1}]"</returns>
        public static string GetMsg(
            int status,
            int number
        )
        {
            const string FORMAT = "�X�e�[�^�X�F[{0}]�@���l�F[{1}]";
            return string.Format(FORMAT, status, number);
        }

        /// <summary>
        /// ���b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="status">�X�e�[�^�X�R�[�h</param>
        /// <param name="categoryCode">�J�e�S���R�[�h</param>
        /// <param name="pgId">�v���O����ID</param>
        /// <returns>"�X�e�[�^�X�F[{0}]�@�J�e�S���R�[�h�F[{1}]�@�v���O����ID�F[{2}]"</returns>
        public static string GetMsg(
            int status,
            int categoryCode,
            string pgId
        )
        {
            const string FORMAT = "�X�e�[�^�X�F[{0}]�@�J�e�S���R�[�h�F[{1}]�@�v���O����ID�F[{2}]";
            return string.Format(FORMAT, status, categoryCode, pgId);
        }
        #endregion
    }
}
