//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : Tablet�p���O�o�̓N���X
// �v���O�����T�v   : Tablet�p���O�o�͂��s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �C����  �F2013/07/29
// �C����  �F�g��
// �C�����e�F���O������
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ȈՃ��O�N���X
    /// </summary>
    /// <remarks></remarks>
    public static class EasyLogger
    {
        /// <summary>�f�t�H���g�����ݎҖ���</summary>
        private const string DEFAULT_NAME = "PMTAB00152A_";

        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DEFAULT_ENCODE = "shift_jis";

        /// <summary>�_���v�t�H���_��</summary>
        private const string DUMP_DIR = "_DUMP_";

        #region <��{���>

        /// <summary>���O�����ݎ҂̖���</summary>
        private static string _name = DEFAULT_NAME;
        /// <summary>���O�����ݎ҂̖��̂��擾���܂��B</summary>
        public static string Name { get { return _name; } }

        /// <summary>
        /// �t�@�C�����̂��擾���܂��B
        /// </summary>
        public static string FileName { get { return Name + DateTime.Now.ToString("yyyyMMdd") + ".log"; } }
        /// <summary>�G���R�[�h</summary>
        private static string _encode = DEFAULT_ENCODE;
        /// <summary>
        /// �G���R�[�h���擾���܂��B
        /// </summary>
        public static string Encode { get { return _encode; } }

        private const string _path = @"\Log\PmTablet";

        #endregion // </��{���>

        /// <summary>
        /// ���O�o�͗p�p�X
        /// </summary>
        public static string OutPutPath
        {
            get { return System.IO.Directory.GetCurrentDirectory() + _path; }
        }


        /// <summary>
        /// ���O���o�͂��܂��B
        /// </summary>
        /// <param name="className">�N���X����</param>
        /// <param name="methodName">���\�b�h����</param>
        /// <param name="msg">���b�Z�[�W</param>
        public static void Write(
            string className,
            string methodName,
            string msg
        )
        {
            FileStream fileStream = new FileStream(Path.Combine( OutPutPath ,FileName), FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(Encode));
            DateTime writingDateTime = DateTime.Now;
            writer.WriteLine(string.Format(
                // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // "{0,-19} {1,-5} ==> {2,-70} {3}",   // yyyy/MM/dd hh:mm:ss
                "{0,-19} {1,-5} {2,-70} {3}",   // yyyy/MM/dd hh:mm:ss
                // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                writingDateTime,
                writingDateTime.Millisecond,
                // UPD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // className + "." + methodName,
                methodName,
                // UPD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                msg
            ));
            if (writer != null) writer.Close();
            if (fileStream != null) fileStream.Close();
        }


        /// <summary>
        /// �_���v���܂��B
        /// </summary>
        /// <param name="data">�f�[�^</param>
        /// <param name="keyword">XML�t�@�C�����̃L�[���[�h</param>
        public static void Dump(
            DataSet data,
            string keyword
        )
        {
            if (data == null) return;

            string fileName = keyword + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
            string filePathName = Path.Combine(OutPutPath, fileName);
            data.WriteXml(filePathName);
        }

        /// <summary>
        /// ���O���[�e�B���e�B
        /// int�^�z�񂩂�csv�`���ɕϊ�
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string LogUtlIntAryToCsv(int[] target)
        {
            // string�^�̔z��ɕϊ�
            string[] stringArray = Array.ConvertAll<int, string>(target, delegate(int value)
            {
                return value.ToString();
            });

            // �z���CSV������ɕϊ�
            return string.Join(",", stringArray);
        }
        /// <summary>
        /// ���O���[�e�B���e�B
        /// byte�^�z�񂩂�csv�`���ɕϊ�
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string LogUtlByteAryToCsv(byte[] target)
        {
            // string�^�̔z��ɕϊ�
            string[] stringArray = Array.ConvertAll<byte, string>(target, delegate(byte value)
            {
                return value.ToString();
            });

            // �z���CSV������ɕϊ�
            return string.Join(",", stringArray);
        }
    }
}
