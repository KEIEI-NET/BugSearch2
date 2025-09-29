//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����Model
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024 ���X�� ��
// �� �� ��  2009/10/09  �C�����e : ��M�̊Y���f�[�^�����Ή�
//----------------------------------------------------------------------------//

using System;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ���ʃ��[�e�B���e�B
    /// </summary>
    public static class Result
    {
        // UNDONE:���ʒ萔���Q��
        /// <summary>
        /// �����[�g�̏������ʗ񋓑�
        /// </summary>
        public enum RemoteStatus : int
        {
            /// <summary>����</summary>
            Normal = 0,
            /// <summary>����0</summary>
            NotFound = 4,

            /// <summary>��ƃ��b�N</summary>
            EnterpriseLock = 850,
            /// <summary>���_���b�N</summary>
            SectionLock = 851,
            /// <summary>�q�Ƀ��b�N</summary>
            WarehouseLock = 852,

            /// <summary>�ُ�</summary>
            Error = 1000
        }

        /// <summary>
        /// ���ʃR�[�h
        /// </summary>
        public enum Code : int
        {
            /// <summary>����</summary>
            Normal,
            /// <summary>�ُ�</summary>
            Error,
            /// <summary>���~</summary>
            Abort,
            /// <summary>�d�������d���f�[�^</summary>
            ExistSlip
        }

        // 2009/10/09 Add >>>
        /// <summary>
        /// ����ID
        /// </summary>
        public enum ProcessID : int
        {
            /// <summary>��������(�����l)</summary>
            None,
            /// <summary>�d����M</summary>
            ReceiveStock,
            /// <summary>�d���񓚃f�[�^�쐬</summary>
            MakeStockAnswerData,
            /// <summary>�v��f�[�^�쐬</summary>
            MakeSumUpData,
            /// <summary>�݌ɒ����쐬</summary>
            MakeStockAdjust,
            /// <summary>�񓚕\��</summary>
            ShowAnswer
        }
        // 2009/10/09 Add <<<

        /// <summary>
        /// �G���[���b�Z�[�W�ɕϊ����܂��B
        /// </summary>
        /// <param name="status">���ʃR�[�h</param>
        /// <param name="processID">����ID</param>
        /// <returns>�Y�����郁�b�Z�[�W</returns>
        // 2009/10/09 Add >>>
        //public static string ToErrorMessage(int status)
        public static string ToErrorMessage(int status, Result.ProcessID processID)
        // 2009/10/09 Add <<<
        {
            const string PLEASE_RETRY = "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B";

            StringBuilder msg = new StringBuilder("�����Ɏ��s���܂����B");
            switch (status)
            {
                case (int)Result.Code.ExistSlip:    // �d���f�[�^�̏d��
                    msg.Append(Environment.NewLine).Append("�d�������d���f�[�^�����݂��܂��B");
                    break;
                case (int)Result.RemoteStatus.EnterpriseLock:   // ��ƃ��b�N
                {
                    msg.Append("�V�F�A�`�F�b�N�G���[(��ƃ��b�N)�ł��B").Append(Environment.NewLine);
                    msg.Append("�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B").Append(Environment.NewLine);
                    msg.Append(PLEASE_RETRY);
                    break;
                }
                case (int)Result.RemoteStatus.SectionLock:      // ���_���b�N
                {
                    msg.Append("�V�F�A�`�F�b�N�G���[(���_���b�N)�ł��B").Append(Environment.NewLine);
                    msg.Append("���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B").Append(Environment.NewLine);
                    msg.Append(PLEASE_RETRY);
                    break;
                }
                case (int)Result.RemoteStatus.WarehouseLock:    // �q�Ƀ��b�N
                {
                    msg.Append("�V�F�A�`�F�b�N�G���[(�q�Ƀ��b�N)�ł��B").Append(Environment.NewLine);
                    msg.Append("�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B").Append(Environment.NewLine);
                    msg.Append(PLEASE_RETRY);
                    break;
                }
                // 2009/10/09 Add >>>
                case (int)Result.RemoteStatus.NotFound:         // �Y���f�[�^����
                {
                    // ��M�����̏ꍇ�̃��b�Z�[�W
                    if (processID == ProcessID.ReceiveStock)
                    {
                        msg = new StringBuilder("��M�Ώۂ̃f�[�^������܂���ł����B");
                    }
                    break;
                }
                // 2009/10/09 Add <<<
            }
            return msg.ToString();
        }
    }
}
