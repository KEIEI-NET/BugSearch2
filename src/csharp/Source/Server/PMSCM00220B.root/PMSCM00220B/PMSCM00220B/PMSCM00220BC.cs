using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Broadleaf.Application.Controller
{
    public class ReplicaDBAccessUtils
    {
        /// <summary>
        /// �R���X�g���N�^�B
        /// </summary>
        private ReplicaDBAccessUtils()
        {
        }

        /// <summary>
        /// �I�u�W�F�N�g�̔j�����s���܂��B
        /// ��O���������Ă��������܂��B
        /// </summary>
        /// <param name="obj"></param>
        public static void CloseQuietly(IDisposable obj)
        {
            try
            {
                if (obj != null)
                {
                    obj.Dispose();
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// ���O�o��
        /// </summary>
        /// <param name="logCotents">���O</param>
        /// <remarks>
        /// <br>Note       : ���O�o�͂��s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/11</br>
        /// </remarks>
        public static void LogOutput(string file, string message)
        {
            StreamWriter writer = null;
            const string msgFmt = "{0} {1}\r\n";
            try
            {
                // ÷��۸ޏ�����
                writer = new StreamWriter(file, true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(string.Format(msgFmt, DateTime.Now, message));
                writer.Flush();
                if (writer != null) writer.Close();
            }
            catch
            {
            }
        }


        /// <summary>
        /// ���O�o��
        /// </summary>
        /// <param name="logCotents">���O</param>
        /// <remarks>
        /// <br>Note       : ���O�o�͂��s���B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2014/08/11</br>
        /// </remarks>
        public static void LogOutput(string file, string message, Exception ex)
        {
            StreamWriter writer = null;
            const string msgFmt = "{0} {1} {2} MSG:{3}\r\nSTACK:{4}\r\n";
            try
            {
                // ÷��۸ޏ�����
                writer = new StreamWriter(file, true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(string.Format(msgFmt, DateTime.Now, message,ex.GetType().ToString(), ex.Message, ex.StackTrace));
                writer.Flush();
                if (writer != null) writer.Close();
            }
            catch
            {
            }
        }
    }
}
