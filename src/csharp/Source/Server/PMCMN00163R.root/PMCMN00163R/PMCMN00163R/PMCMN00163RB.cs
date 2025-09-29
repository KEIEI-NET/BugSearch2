//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �R���o�[�g�Ώۃo�b�N�A�b�v�����e�i���X
// �v���O�����T�v   : �R���o�[�g�Ώۃo�b�N�A�b�v���s��
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
    /// �R���o�[�g�Ώۃo�b�N�A�b�v�O�o�b�N�A�b�v
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�v�O�̃o�b�N�A�b�v���s���N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ConvObjBkCreateDB
    {

        #region �񋓑�

        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v�̌��ʃX�e�[�^�X�񋓑�
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
            MstBk = 2050
          , /// <summary>�o�[�W�����Ǘ��}�X�^�X�V</summary>
            VerObjMstBk = 2100
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
        /// �o�b�N�A�b�v�t�H���_�p�X
        /// </summary>
        private const string BACKUP_PATH = @"Log\BACKUP";

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
        private ConvObjSingleBkDBParam _cosbdbp = null;

        /// <summary>
        /// CLC���O�o��
        /// </summary>
        private ConvObjSingleBkCLCLogDB _coclcldb = null;

        /// <summary>
        /// ��ƃf�B���N�g��
        /// </summary>
        private string _fileDirectory;

        /// <summary>
        /// �o�b�N�A�b�v�t�@�C���쐬�pStream
        /// </summary>
        StreamWriter _fs = null;

        /// <summary>
        /// �����s��
        /// </summary>
        int _procRowCnt;

        /// <summary>
        /// txt�t�@�C���p�X
        /// </summary>
        string _txtFilePath;

        /// <summary>
        /// txt�t�@�C����
        /// </summary>
        string _txtFileName;

        #endregion //�v���C�x�[�g�t�B�[���h

        #region �R���X�g���N�^

        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjBkCreateDB()
        {
        }

        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="bkFileName">�o�b�N�A�b�v�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjBkCreateDB(string bkFileName)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            string workDir = string.Empty;
            try
            {
                // �p�����[�^
                _cosbdbp = new ConvObjSingleBkDBParam();

                // CLC���O�o��
                _coclcldb = new ConvObjSingleBkCLCLogDB();

                // �����s��
                _procRowCnt = 0;

                #region ��ƃf�B���N�g���擾

                status = (int)ConvObjSingleBkDBParam.StatusCode.BkGetDirectory;

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
                _fileDirectory = Path.Combine(workDir.TrimEnd('\\'), BACKUP_PATH);

                // �t�H���_�����݂��Ȃ��ꍇ�쐬����
                if (!Directory.Exists(_fileDirectory))
                {
                    Directory.CreateDirectory(_fileDirectory);
                }

                // �g���q.txt�̃t�@�C�����擾
                _txtFileName = bkFileName.Replace(@".zip", @".txt");
                _txtFilePath = Path.Combine(_fileDirectory, _txtFileName);

                status = (int)ConvObjSingleBkDBParam.StatusCode.BkStream;

                // �������݌^��Stream����
                _fs = new StreamWriter(_txtFilePath, false);

                #endregion // �o�b�N�A�b�v�t�@�C��������

            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},status:{1},ex:{2}", "ERR PMCMN00163RB ConvObjBkCreateDB Exception", status.ToString(), ex.Message));
                throw;
            }
            finally
            {
            }
        }
        #endregion //�R���X�g���N�^

        #region ConvObjBackup
        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v�O�̃o�b�N�A�b�v���s���܂��B
        /// </summary>
        /// <param name="mstData">�o�b�N�A�b�v�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�v�O�̃o�b�N�A�b�v���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int ConvObjBackup(DataRow mstData)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            int procStatus = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            int colCnt = 0;
            StringBuilder txtData = new StringBuilder();
            string encryptData = string.Empty;

            try
            {
                #region �o�b�N�A�b�v�f�[�^������ϊ�

                // �o�b�N�A�b�v�f�[�^���^�u��؂�̕�����ɕϊ�

                procStatus = (int)ConvObjSingleBkDBParam.StatusCode.BkConvStr;

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
                _procRowCnt++;

                #endregion // �o�b�N�A�b�v�f�[�^������ϊ�

                // �e�L�X�g�f�[�^�Í���
                procStatus = (int)ConvObjSingleBkDBParam.StatusCode.BkEncrypt;

                encryptData = EncryptionEntry(txtData.ToString());

                // �������m�ۂ̂��ߕϐ�������
                txtData = null;

                #region �������ݏ���

                // zip�t�@�C����������
                procStatus = (int)ConvObjSingleBkDBParam.StatusCode.BkWrite;
                _fs.WriteLine(encryptData);

                // �������m�ۂ̂��ߕϐ�������
                encryptData = null;

                #endregion // �������ݏ���

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch(Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},procStatus:{1},procRowCnt:{2},ex:{3}", "ERR PMCMN00163RB ConvObjBackup Exception", procStatus.ToString(), _procRowCnt.ToString(), ex.Message));
                throw ex;
            }

            return status;
        }

        #endregion // ConvObjBackup

        #region �o�b�N�A�b�v�t�@�C�����k
        /// <summary>
        /// �o�b�N�A�b�v�t�@�C�����k���s���܂��B
        /// </summary>
        /// <param name="bkFileName">�o�b�N�A�b�v�t�@�C����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�b�N�A�b�v�t�@�C�����k���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int BackupZipCreate(string bkFileName)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            int procStatus = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            string zipFilePath = string.Empty;

            try
            {
                // �쐬�I�������t�@�C�����
                if (_fs != null)
                {
                    _fs.Close();
                    _fs.Dispose();
                    _fs = null;
                }

                // zip�t�@�C���p�X�ݒ�
                zipFilePath = Path.Combine(_fileDirectory, bkFileName);

                // zip���ɂ�Stream
                using (FileStream zfs = new FileStream(zipFilePath, FileMode.Create, FileAccess.Write))
                {
                    // ZipOutputStream���쐬
                    using (ZipOutputStream zos = new ZipOutputStream(zfs))
                    {
                        // ���k���x�����ō����k�ɐݒ�
                        zos.SetLevel(9);

                        // �p�X���[�h�ݒ�
                        zos.Password = AESEncryptInfo.ZIP_PASSWORD;

                        // ZipEntry���쐬
                        ZipEntry ze = new ZipEntry(_txtFileName);

                        procStatus = (int)ConvObjSingleBkDBParam.StatusCode.BkEntryPut;

                        // �V�����G���g���̒ǉ����J�n
                        zos.PutNextEntry(ze);

                        // ���k����t�@�C����ǂݍ���
                        using (FileStream tfs = new FileStream(_txtFilePath, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[208];
                            int len;
                            while ((len = tfs.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                // ���ɂɏ�������
                                zos.Write(buffer, 0, len);
                            }

                            tfs.Close();
                        }
                        zos.Finish();
                        zos.Close();
                    }
                    zfs.Close();
                }

                // ���k���t�@�C���폜
                status = BackupDelete();

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},procStatus:{1},ex:{2}", "ERR PMCMN00163RB BackupZipCreate Exception", procStatus.ToString(), ex.Message));
                throw ex;
            }

            return status;
        }

        #endregion // �o�b�N�A�b�v�t�@�C�����k

        #region �o�b�N�A�b�v�t�@�C���폜
        /// <summary>
        /// �o�b�N�A�b�v�t�@�C���폜���s���܂��B
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�b�N�A�b�v�t�@�C�����k���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int BackupDelete()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                // �e�L�X�g�t�@�C�����c���Ă���ꍇ�͍폜����
                if (File.Exists(_txtFilePath))
                {
                    File.Delete(_txtFilePath);
                }

                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00163RB BackupDelete Exception", ex.Message));
                throw;
            }

            return status;
        }

        #endregion // �o�b�N�A�b�v�t�@�C���폜

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
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00163RB EncryptionEntry Exception", ex.Message));
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private void ClcLogOutputProc(string message)
        {
            if (_cosbdbp.ClcLogOutputInfo == (int)ConvObjSingleBkDBParam.OutputCode.ON)
            {
                try
                {
                    // CLC���O�o��
                    _coclcldb.ClcLogOutput(message);
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
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public void Dispose()
        {
            try
            {
                if (_fs != null)
                {
                    _fs.Close();
                    _fs.Dispose();
                    _fs = null;
                }

                BackupDelete();

            }
            catch (Exception ex)
            {
                ClcLogOutputProc(string.Format("{0},ex:{1}", "ERR PMCMN00163RB Dispose Exception", ex.Message));
                throw ex;
            }
            finally
            {
            }
        }
        #endregion // Dispose
    }


}
