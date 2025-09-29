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
// �� �� ��  2009/05/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30745 �g�� �F��
// �� �� ��  2014/01/17  �C�����e : SCM�d�|�ꗗ��10628�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// �ȈՃ��O�N���X
    /// </summary>
    /// <remarks>MAHNB01012AD.cs::SalesSlipInputInitDataAcs.LogWrite()���Q�l</remarks>
    public static class EasyLogger
    {
        /// <summary>�f�t�H���g�����ݎҖ���(�����񓚏���)</summary>
        private const string DEFAULT_NAME = "PMSCM01010U";

        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DEFAULT_ENCODE = "shift_jis";

        /// <summary>�f�o�b�O���O��INI�t�@�C��</summary>
        private const string DEBUG_FILE_INI = "_DEBUG_.ini";
        /// <summary>�_���v�t�H���_��</summary>
        private const string DUMP_DIR = "_DUMP_";

        // ADD 2014/01/17 SCM��Q��10628 �g�� �z�M������ �����񓚑��x���P --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> �f�o�b�O���O��INI�t�@�C���Ǎ���� �@
        /// -1:���Ǎ� 
        ///  0:�t�@�C������(�f�o�b�O���O�o�͖���)  
        ///  1:�t�@�C���L��(�f�o�b�O���O�o�͗L��)  </summary>
        public static sbyte debugIniFlg = -1;
        // ADD 2014/01/17 SCM��Q��10628 �g�� �z�M������ �����񓚑��x���P ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        #region <��{���>

        /// <summary>���O�����ݎ҂̖���</summary>
        private static string _name = DEFAULT_NAME;
        /// <summary>���O�����ݎ҂̖��̂��擾���܂��B</summary>
        public static string Name { get { return _name; } }

        /// <summary>
        /// �t�@�C�����̂��擾���܂��B
        /// </summary>
        public static string FileName { get { return Name + ".log"; } }

        /// <summary>�G���R�[�h</summary>
        private static string _encode = DEFAULT_ENCODE;
        /// <summary>
        /// �G���R�[�h���擾���܂��B
        /// </summary>
        public static string Encode { get { return _encode; } }

        #endregion // </��{���>

        /// <summary>
        /// ���O���o�͂��܂��B
        /// </summary>
        /// <remarks>MAHNB01012AD.cs::SalesSlipInputInitDataAcs.LogWrite()���Q�l</remarks>
        /// <param name="className">�N���X����</param>
        /// <param name="methodName">���\�b�h����</param>
        /// <param name="msg">���b�Z�[�W</param>
        public static void Write(
            string className,
            string methodName,
            string msg
        )
        {
            FileStream fileStream = new FileStream(FileName, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(Encode));
            DateTime writingDateTime = DateTime.Now;
            writer.WriteLine(string.Format(
                "{0,-19} {1,-5} ==> {2,-70} {3}",   // yyyy/MM/dd hh:mm:ss
                writingDateTime,
                writingDateTime.Millisecond,
                className + "." + methodName,
                msg
            ));
            if (writer != null) writer.Close();
            if (fileStream != null) fileStream.Close();
        }

        /// <summary>
        /// �f�o�b�O���O���o�͂��܂��B
        /// </summary>
        /// <remarks>MAHNB01012AD.cs::SalesSlipInputInitDataAcs.LogWrite()���Q�l</remarks>
        /// <param name="className">�N���X����</param>
        /// <param name="methodName">���\�b�h����</param>
        /// <param name="msg">���b�Z�[�W</param>
        public static void WriteDebugLog(
            string className,
            string methodName,
            string msg
        )
        {
            // UPD 2014/01/17 SCM��Q��10628 �g�� �z�M������ �����񓚑��x���P --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //if (!File.Exists(DEBUG_FILE_INI)) return;
            //Write(className, methodName, msg);

            if (debugIniFlg.Equals(-1))
            {
                // ���Ǎ��ꍇ�̂ݓǍ���
                if (File.Exists(DEBUG_FILE_INI))
                {
                    debugIniFlg = 1;
                }
                else
                {
                    debugIniFlg = 0;
                }
            }

            if (debugIniFlg.Equals(1)) Write(className, methodName, msg);
            // UPD 2014/01/17 SCM��Q��10628 �g�� �z�M������ �����񓚑��x���P ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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
            if (!Directory.Exists(DUMP_DIR)) return;
            if (data == null) return;

            string fileName = keyword + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
            string filePathName = Path.Combine(DUMP_DIR, fileName);
            data.WriteXml(filePathName);
        }

        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
#if DEBUG
            System.IO.FileStream _fs;										// �t�@�C���X�g���[��
            System.IO.StreamWriter _sw;										// �X�g���[��writer
            _fs = new FileStream("d:\\ddd.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
#endif
        }

    }
}
