//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώێ����X�V�����e�i���X
// �v���O�����T�v   : �R���o�[�g�Ώێ����X�V���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ����
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.Security.Cryptography;
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �R���o�[�g�Ώێ����X�V�O�o�b�N�A�b�v
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώێ����X�V�O�̃o�b�N�A�b�v���s���N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ConvObjBackupDB
    {

        #region �񋓑�

        /// <summary>
        /// �R���o�[�g�Ώێ����X�V�̌��ʃX�e�[�^�X�񋓑�
        /// </summary>
        private enum StatusCode
        {
            /// <summary>����</summary>
            Normal = 0
          , /// <summary>�����i�R���o�[�g�Ȃ��j</summary>
            NormalNotFound = 4
          , /// <summary>���i�}�X�^�擾</summary>
            MstGet = 2000
          , /// <summary>DataTable�W�J</summary>
            DataTableDeploy = 2010
          , /// <summary>DataTable�ϊ�</summary>
            DataTableConv = 2020
          , /// <summary>�ꎞ�e�[�u���쐬</summary>
            TempTableCreate = 2030
          , /// <summary>�ꎞ�e�[�u���o�^</summary>
            TempTableIns = 2040
          , /// <summary>�}�X�^�X�V</summary>
            MstUpd = 2050
          , /// <summary>�o�[�W�����Ǘ��}�X�^�X�V</summary>
            VerObjMstUpd = 2100
          , /// <summary>��O�G���[(3000)</summary>
            Error3000 = 3000
          , /// <summary>��O�G���[(3001)</summary>
            Error3001 = 3001
          , /// <summary>��O�G���[(3002)</summary>
            Error3002 = 3002
          , /// <summary>��O�G���[(3003)</summary>
            Error3003 = 3003
          , /// <summary>��O�G���[(3004)</summary>
            Error3004 = 3004
        };

        #endregion //�񋓑�

        #region �萔

        /// <summary>
        /// �R���o�[�g�Ώێ����X�V�����ŗ�O���������܂����B
        /// </summary>
        private const string ErrorTextUpdateProcFaild = "�R���o�[�g�Ώێ����X�V�����ŗ�O���������܂����B";

        /// <summary>
        /// �ݒ�t�@�C����
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00143R_Setting.xml";

        /// <summary>
        /// �^�C���A�E�g�����l�i�b�j
        /// </summary>
        private const int TIMEOUT_DEFAULT_TIME = 1800;

        /// <summary>
        /// �o�b�N�A�b�v�t�H���_�p�X
        /// </summary>
        private const string BACKUP_PATH = @"Log\BACKUP";

        /// <summary>
        /// �o�b�N�A�b�v�t�@�C����
        /// </summary>
        private const string ZIP_FILE_NAME = "ConvObjBackup";

        /// <summary>
        /// USER_AP���W�X�g���L�[�@���[�g
        /// </summary>
        private const string RegistryKeyUSER_APMain = @"SOFTWARE\Broadleaf\Service\Partsman\USER_AP";

        /// <summary>
        /// USER_AP���W�X�g���L�[�@��ƃp�X
        /// </summary>
        private const string RegistryKeyUSER_APInstallDirectory = "InstallDirectory";

        /// <summary>
        /// ��ƃp�X�f�t�H���g
        /// </summary>
        private const string WorkingDirDefault = @"C:\Program Files\Partsman\USER_AP";

        #endregion //�萔

        #region �v���C�x�[�g�t�B�[���h

        /// <summary>
        /// �p�����[�^
        /// </summary>
        private ConvObjDBParam codbp = null;

        /// <summary>
        /// CLC���O�o��
        /// </summary>
        private ConvObjCLCLogDB coclcldb = null;

        /// <summary>
        /// �t�@�C�����p���ݓ���
        /// </summary>
        private string nowDateTime;

        /// <summary>
        /// ��ƃf�B���N�g��
        /// </summary>
        private string workDir;

        /// <summary>
        /// �o�b�N�A�b�v�t�@�C���쐬�pStream
        /// </summary>
        StreamWriter fs = null;

        /// <summary>
        /// �����s��
        /// </summary>
        int procRowCnt;

        #endregion //�v���C�x�[�g�t�B�[���h

        #region �R���X�g���N�^

        /// <summary>
        /// �R���o�[�g�Ώێ����X�V�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjBackupDB()
        {
            int status = (int)ConvObjDBParam.StatusCode.Normal;
            try
            {
                // �p�����[�^
                codbp = new ConvObjDBParam();

                // CLC���O�o��
                coclcldb = new ConvObjCLCLogDB();

                // �����s��
                procRowCnt = 0;

                // �t�@�C�����p���ݎ����ݒ�
                nowDateTime = DateTime.Now.Year.ToString("0000") +
                    DateTime.Now.Month.ToString("00") +
                    DateTime.Now.Day.ToString("00") +
                    DateTime.Now.Hour.ToString("00") +
                    DateTime.Now.Minute.ToString("00") +
                    DateTime.Now.Second.ToString("00");

                #region ��ƃf�B���N�g���擾

                status = (int)ConvObjDBParam.StatusCode.BkGetDirectory;

                // ���W�X�g���L�[�擾
                RegistryKey key = Registry.LocalMachine.OpenSubKey(RegistryKeyUSER_APMain);

                // ��ƃf�B���N�g���擾
                if (key == null) // �����Ă͂����Ȃ��P�[�X
                {
                    workDir = WorkingDirDefault; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
                }
                else
                {
                    workDir = key.GetValue(RegistryKeyUSER_APInstallDirectory, WorkingDirDefault).ToString();
                }

                #endregion // ��ƃf�B���N�g���擾

                #region �o�b�N�A�b�v�t�@�C��������
                // �t�@�C���i�[�p�X��`
                string fileDirectory = Path.Combine(workDir.TrimEnd('\\'), BACKUP_PATH);

                // �t�H���_�����݂��Ȃ��ꍇ�쐬����
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory);
                }

                string filePath = Path.Combine(fileDirectory, ZIP_FILE_NAME + "_" + nowDateTime);

                status = (int)ConvObjDBParam.StatusCode.BkStream;

                // �������݌^��Stream����
                fs = new StreamWriter(filePath, false);

                #endregion // �o�b�N�A�b�v�t�@�C��������

            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00143RB ConvObjBackupDB Exception", status.ToString(), ex.Message));
                throw ex;
            }
            finally
            {
            }
        }
        #endregion //�R���X�g���N�^

        #region ConvObjBackup
        /// <summary>
        /// �R���o�[�g�Ώێ����X�V�O�̃o�b�N�A�b�v���s���܂��B
        /// </summary>
        /// <param name="mstData">�o�b�N�A�b�v�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώێ����X�V�O�̃o�b�N�A�b�v���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int ConvObjBackup(DataRow mstData)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            int procStatus = (int)ConvObjDBParam.StatusCode.Normal;
            int colCnt = 0;
            StringBuilder txtData = new StringBuilder();
            string encryptData = string.Empty;

            try
            {
                #region �o�b�N�A�b�v�f�[�^������ϊ�

                // �o�b�N�A�b�v�f�[�^���^�u��؂�̕�����ɕϊ�

                procStatus = (int)ConvObjDBParam.StatusCode.BkConvStr;

                // �o�b�N�A�b�v�f�[�^���^�u��؂�̕�����ɕϊ�
                colCnt = 0;

                foreach (object col in mstData.ItemArray)
                {
                    if (colCnt != 0)
                    {
                        // 2��ڈȍ~�̓^�u��؂�Őݒ�
                        txtData.Append('\t');
                    }

                    txtData.Append("\"");
                    txtData.Append(col.ToString());
                    txtData.Append("\"");

                    colCnt++;
                }
                procRowCnt++;

                #endregion // �o�b�N�A�b�v�f�[�^������ϊ�

                // �e�L�X�g�f�[�^�Í���
                procStatus = (int)ConvObjDBParam.StatusCode.BkEncrypt;

                encryptData = EncryptionEntry(txtData.ToString());

                // �������m�ۂ̂��ߕϐ�������
                txtData = null;

                #region �������ݏ���

                // zip�t�@�C����������
                procStatus = (int)ConvObjDBParam.StatusCode.BkWrite;
                fs.WriteLine(encryptData);

                // �������m�ۂ̂��ߕϐ�������
                encryptData = null;

                #endregion // �������ݏ���

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch(Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},procStatus:{1},procRowCnt:{2},ex:{3}", "ERR PMCMN00143RB ConvObjBackup Exception", procStatus.ToString(), procRowCnt.ToString(), ex.Message));
                throw ex;
            }

            return status;
        }

        #endregion // ConvObjBackup

        #region private ���\�b�h

        #region �f�[�^�Í���

        /// <summary>
        /// �f�[�^�Í���
        /// </summary>
        /// <param name="source">�Í����Ώۃf�[�^</param>
        /// <remarks>
        /// <br>Note       : ������̈Í������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private string EncryptionEntry(string source)
        {
            byte[] encrypted = null;
            string retStr = string.Empty;

            try
            {

                // AES�Í����I�u�W�F�N�g�𐶐����܂�
                using (RijndaelManaged rijndael = new RijndaelManaged())
                {
                    // �������x�N�g���A�Í�������`

                    rijndael.IV = Encoding.UTF8.GetBytes(AESEncryptInfo.AES_IV);
                    rijndael.Key = Encoding.UTF8.GetBytes(AESEncryptInfo.AES_Key);

                    // �Í����I�u�W�F�N�g����
                    ICryptoTransform encryptor = rijndael.CreateEncryptor(rijndael.Key, rijndael.IV);

                    // Stream����ŕ����񂩂�Í������Byte�z��𐶐�
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                // CryptoStream�p��StreamWriter��Stream�ɏ�������
                                swEncrypt.Write(source);
                            }

                            // string�����񂪏������܂ꂽStream����MemoryStream�ɂ��Byte�z��𐶐�
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }
                
                retStr = Convert.ToBase64String(encrypted);
            }
            catch(Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RB EncryptionEntry Exception", ex.Message));
                throw ex;
            }

            return retStr;
        }

        #endregion // �f�[�^�Í���

        #region CLC���O�o��
        /// <summary>
        /// CLC���O�o�͎���
        /// </summary>
        /// <param name="message">���O�o�͏��</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���샍�O�e�[�u���Ƀ��O���o�͂���</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private void ClcLogOutputProc(string message)
        {
            if (codbp.ClcLogOutputInfo == (int)ConvObjDBParam.OutputCode.ON)
            {
                try
                {
                    // CLC���O�o��
                    coclcldb.ClcLogOutput(message);
                }
                catch
                {
                }
                finally
                {
                }
            }
        }
        #endregion  // CLC���O�o��

        #endregion // private���\�b�h

        #region Dispose
        /// <summary>
        /// �������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �������</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public void Dispose()
        {
            try
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00143RB Dispose Exception", ex.Message));
                throw ex;
            }
            finally
            {
            }
        }
        #endregion // Dispose
    }


}
