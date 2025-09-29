using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Broadleaf.Application.Batch
{
    /// <summary>
    /// �C�x���g���O����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �C�x���g���O�Ƀ��b�Z�[�W��ݒ肵�܂��B</br>
    /// <br>Programmer : ���X�� �j</br>
    /// <br>Date       : 2015/05/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class EventLogControl
    {
        /// <summary>
        /// �C�x���g���O�Ƀ��b�Z�[�W���o�͂���
        /// </summary>
        /// <param name="className">�N���X��</param>
        /// <param name="methodName">���\�b�h��</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        public static void SetEventLogOut(string className, string methodName, string errorMessage)
        {
            string source = Path.GetFileNameWithoutExtension(Environment.GetCommandLineArgs()[0]);
            string message = string.Format("[{0}].[{1}] {2} Loginfo:PgId[{3}]", className, methodName, errorMessage, source);
            try
            {
                // �C�x���g���O�o��
                EventLog.WriteEntry(source, message, EventLogEntryType.Error);
            }
            catch
            {
                //�C�x���g���O�ɏo�͂ł��Ȃ��ꍇ�A�G���[�ɂ͂��Ȃ�
            }
        }
    }
}
