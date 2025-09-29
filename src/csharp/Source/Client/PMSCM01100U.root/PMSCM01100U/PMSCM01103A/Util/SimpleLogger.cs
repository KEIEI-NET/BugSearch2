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
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2014/04/09  �C�����e : SCM�d�|�ꗗ��10641�Ή�
//----------------------------------------------------------------------------//
using System;
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
    public static class SimpleLogger
    {
        /// <summary>�f�t�H���g�����ݎҖ���(�����񓚏���)</summary>
        private const string DEFAULT_NAME = "PMSCM01100U";  // �񓚑��M�p�ɕύX

        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DEFAULT_ENCODE = "shift_jis";

        /// <summary>�f�o�b�O���O��INI�t�@�C��</summary>
        private const string DEBUG_FILE_INI = "_DEBUG_.ini";
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
            if (!File.Exists(DEBUG_FILE_INI)) return;
            Write(className, methodName, msg);
        }

        // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ------------------------------------------>>>>>
        /// <summary>
        /// ���M�G���[���̃f�[�^�������O�ɏo�͂��܂�
        /// </summary>
        /// <remarks></remarks>
        /// <param name="scmDataPath">���O�t�@�C���p�X</param>
        /// <param name="msg">���b�Z�[�W</param>
        public static void WriteSlipNumLog(
            string scmDataPath,
            string msg
        )
        {
            // �t�@�C����
            // PMSCM01100U_�V�X�e�����t(yyyyMMddHHMMSSsss).txt
            DateTime writingDateTime = DateTime.Now;
            Int32 updateTime = writingDateTime.Hour * 10000000 + writingDateTime.Minute * 100000 + writingDateTime.Second * 1000 + writingDateTime.Millisecond;

            string fileName = Path.Combine(scmDataPath, Name + "_" +  string.Format("{0:yyyyMMdd}", writingDateTime) + updateTime.ToString() + ".txt");
            FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(Encode));
            writer.WriteLine(string.Format("{0}", msg));
            if (writer != null) writer.Close();
            if (fileStream != null) fileStream.Close();
        }
        // ADD 2014/04/09 SCM�d�|�ꗗ��10641�Ή� ------------------------------------------<<<<<

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

        /// <summary>�t�@�C���T�C�Y�̌��E�l[Byte]</summary>
        private const long FILE_SIZE_LIMIT = 4000000;

        /// <summary>
        /// �����t���Ń��O���o�b�N�A�b�v���܂��B
        /// </summary>
        /// <remarks>
        /// ���O�t�@�C����4[MB]�ȏ�ł���Εʖ��ŕۑ����܂��B
        /// </remarks>
        /// <param name="logPathName">���O�t�@�C���̃p�X</param>
        /// <returns>
        /// �o�b�N�A�b�v�����t�@�C���� ���o�b�N�A�b�v���s��Ȃ������ꍇ�A<c>string.Empty</c>��Ԃ��܂��B
        /// </returns>
        public static string BackupLogIf(string logPathName)
        {
            #region <Guard Phrase>

            if (!File.Exists(logPathName)) return string.Empty;

            #endregion // </Guard Phrase>

            FileInfo logInfo = new FileInfo(logPathName);
            {
                if (logInfo.Length < FILE_SIZE_LIMIT) return string.Empty;
            }
            string backupedName = Path.GetFileNameWithoutExtension(logPathName)
                + DateTime.Now.ToString("yyyyMMddHHmmss")
                + Path.GetExtension(logPathName);
            {
                File.Copy(logPathName, Path.Combine(Path.GetDirectoryName(logPathName), backupedName), true);
            }
            return backupedName;
        }
    }
}
