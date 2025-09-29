using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Reflection;

namespace Broadleaf.Library.Diagnostics
{
    /// <summary>
    /// CLC���O�o�͕��i�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : CLC���O���W�c�[���Ŏ��W�\�ȏꏊ�Ƀ��O���e�L�X�g�o�͂���N���X�ł��B</br>
    /// <br>Programmer : 22035 �O�� �O��</br>
    /// <br>Date       : 2015.05.25</br>
    /// <br></br>
    /// </remarks>
    public class CLCLogTextOut
    {
        /// <summary>�X�e�[�^�X(����I��)</summary>
        public const int ST_NOMAL = 0;

        /// <summary>�X�e�[�^�X(�R�s�[���t�@�C�������G���[)</summary>
        public const int ST_COPYFILENOTFOUND = 4;

        /// <summary>�X�e�[�^�X(���������G���[)</summary>
        public const int ST_COPYFAIL = 9;

        /// <summary>�X�e�[�^�X(��O�G���[)</summary>
        public const int ST_COPYEXCEPTION = -1;

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public CLCLogTextOut()
        {
        }

        /// <summary>
        /// CLC���O�o��
        /// </summary>
        /// <param name="pgId">PGID</param>
        /// <param name="productId">�v���_�N�gID</param>
        /// <param name="message">LOG�o�̓��b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="exPara">��O�G���[���e</param>
        /// <returns>CLC���O�o�̓t�@�C������</returns>
        public string OutputClcLog(string pgId, string productId, string message, Int32 status, Exception exPara)
        {
            const string CT_SERVICECODE = "CLCLogTextOut"; // �T�[�r�X�R�[�h�iCLC���O�t�@�C���o�͕��i�g�p���Ɏg�p�j
            string logFileName = string.Empty;             // �o�̓��O�t�@�C�����́iCLC���O�t�@�C���o�͕��i�g�p���Ɏg�p�j
            string outputMessage = string.Empty;           // �o�̓��O���e�iCLC���O�t�@�C���o�͕��i�g�p���Ɏg�p�j

            // PGID�`�F�b�N
            // PGID�����݂��Ȃ��ꍇ�͏����𒆎~����
            if (pgId == null || pgId.Trim().Length == 0) return logFileName;

            //�v���_�N�gID�`�F�b�N
            if (productId == null) productId = "Partsman";

            // ���O�t�@�C�����̍쐬
            // "Client"+DateTime��Ticks+Guid������i�eClient�ɂĐ�������Log�t�@�C���̃o�b�e�B���O�h�~�j
            logFileName = string.Format("Client{0}{1}.log", DateTime.Now.Ticks.ToString(), Guid.NewGuid().ToString());


            // �o�̓��b�Z�[�W�쐬
            outputMessage = message + " status=" + status.ToString();

            // ��O��񂪑��݂���ꍇ�̓��b�Z�[�W�Ɍ�������
            if (exPara != null)
                outputMessage += "\r\n" + exPara.Message;

            // ���O�t�@�C���o�͏���
            // KICLC0001C���g�p���ďo��
            KICLC00001C.LogHeader logHeader = new KICLC00001C.LogHeader();

            int st = logHeader.WriteServiceLogHeader(
                productId,                       // �Ăь�����n���ꂽ�v���_�N�gID�i�󔒂̏ꍇ��Partsman��n���j
                CT_SERVICECODE,                  // �{���\�b�h�ɂč쐬�����T�[�r�X�R�[�h��n��
                logFileName,                     // �{���\�b�h�ɂč쐬�������O�t�@�C�����̂�n���i"Client"+DateTime��Ticks+Guid������j
                String.Format("[{0}] {1}",
                  pgId,                          // �Ăь�����n���ꂽPGID
                  outputMessage                  // �Ăь�����n���ꂽ�o�̓��b�Z�[�W(Exception���e�����݂���ꍇ�́AException���e���o��)
                ));

            // ����ɏo�͂ł����ꍇ�̂݃��O�t�@�C�����̂�Ԃ�
            if (st == ST_NOMAL)
                return logFileName;
            else
                return string.Empty;
        }

        /// <summary>
        /// �t�@�C���ۑ�����
        /// </summary>
        /// <param name="fileFullPath">�R�s�[���t�@�C���̃t���p�X</param>
        /// <returns>�X�e�[�^�X([0:����, 4:�R�s�[���t�@�C�������݂��Ȃ�, 9:�R�s�[���s, -1:��O�G���[)</returns>
        public int CopyClcLogFile(string fileFullPath)
        {
            // CLC���O�o�̓t�H���_(�Ō�̃t�H���_�̓T�[�r�X���Ƃ���)
            const string OUTPUT_CLCLOGFOLDER = "Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

            string ClcServerLogOutPutFolder = null;

            try
            {
                // CLC���O�o�̓t�H���_�ݒ�
                ClcServerLogOutPutFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), // %ALLUSERSPROFILE%�̉��ɍ쐬
                    OUTPUT_CLCLOGFOLDER                                                         // CLC���O�o�͗p�f�B���N�g��
                    );
            }
            catch (ArgumentException)
            {
                // ��O�G���[��
                return ST_COPYEXCEPTION;
            }
            catch (PlatformNotSupportedException)
            {
                // ��O�G���[��
                return ST_COPYEXCEPTION;
            }

            string outPutLogFileName = string.Empty;   // �o�̓��O�t�@�C�����́iCLC���O�t�@�C���o�͕��i�g�p���Ɏg�p�j

            // �R�s�[���t�@�C���̑��݃`�F�b�N
            // �R�s�[�����w��͏����I���A�R�s�[���t�@�C�������݂��Ȃ��ꍇ�̓G���[�Ƃ���
            if (fileFullPath == null)
                return ST_NOMAL;
            else if (!File.Exists(fileFullPath))
                return ST_COPYFILENOTFOUND;

            // �R�s�[��t�@�C���t���p�X�쐬
            outPutLogFileName = Path.Combine(
                ClcServerLogOutPutFolder,          // �{���\�b�h�ɂč쐬����CLCServer�p�f�B���N�g��
                Path.GetFileName(fileFullPath)     // �Ăь�����n���ꂽ�R�s�[���t�@�C�����i�t���p�X����t�@�C�����̂ݎ擾�j
                );

            try
            {
                // �R�s�[��f�B���N�g���̑��݃`�F�b�N
                if (!Directory.Exists(ClcServerLogOutPutFolder))
                    Directory.CreateDirectory(ClcServerLogOutPutFolder);

                // �R�s�[�������s
                File.Copy(
                    fileFullPath,       // �Ăь�����n���ꂽ�R�s�[���t�@�C�����i�t���p�X����t�@�C�����̂ݎ擾�j
                    outPutLogFileName,  // �{���\�b�h�ɂč쐬����CLCLOG�o�͗p�p�X
                    true
                    );
            }
            catch (UnauthorizedAccessException)
            {
                // �����݃G���[��
                return ST_COPYFAIL;
            }
            catch (Exception)
            {
                // ��O�G���[��
                return ST_COPYEXCEPTION;
            }

            return ST_NOMAL;
        }
    }
}
