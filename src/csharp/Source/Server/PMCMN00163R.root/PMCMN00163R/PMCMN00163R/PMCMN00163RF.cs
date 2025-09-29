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
// �Ǘ��ԍ�  11601223-00 �쐬�S�� : ����
// �C �� ��  2021/09/09  �C�����e : ���[�J���t�@�C���폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11970089-00 �쐬�S�� : �c������
// �C �� ��  2023/05/29  �C�����e : AWS TLS1.2�Ή�
//----------------------------------------------------------------------------//
using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Text;
using System.Xml;
using Broadleaf.Application.Common;
using System.Security.Cryptography;
using Broadleaf.Application.Remoting;
using Amazon.S3;
using Amazon;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using Broadleaf.Application.Remoting.ParamData;
using System.Data.SqlClient;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;

// ------ ADD 2023/05/29 �c������ AWS TLS1.2�Ή� -------->>>>>
using Broadleaf.Application.Resources;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
// ------ ADD 2023/05/29 �c������ AWS TLS1.2�Ή� --------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �R���o�[�g�Ώۃo�b�N�A�b�v�t�@�C������
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�v�t�@�C������</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br>Update Note: ���[�J���t�@�C���폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2021/09/09</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00</br>
    /// <br></br>
    /// </remarks>
    public class ConvObjSingleBkFileMngDB : RemoteWithAppLockDB
    {
        #region �񋓑�

        /// <summary>
        /// �o�b�N�A�b�v�폜�R�[�h
        /// </summary>
        public enum BkDelCode
        {
            /// <summary>�L��</summary>
            Enable = 0
          , /// <summary>����</summary>
            Disable = 1
        };

        #endregion // �񋓑�

        #region �萔

        /// <summary>
        /// �ݒ�t�@�C����
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00163R_SendSetting.xml";

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

        #endregion // �萔

        #region �v���C�x�[�g�t�B�[���h

        /// <summary>
        /// �o�P�b�g��
        /// </summary>
        private string _bucketName;

        /// <summary>
        /// �A�N�Z�X�L�[ID
        /// </summary>
        private string _accessKeyID;

        /// <summary>
        /// �V�[�N���b�g�A�N�Z�X�L�[
        /// </summary>
        private string _secretAccessKey;

        /// <summary>
        /// ��ƃf�B���N�g��
        /// </summary>
        private string _fileDirectory;

        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v�p�����[�^
        /// </summary>
        ConvObjSingleBkDBParam _cosbdbp = null;

        /// <summary>
        /// CLC���O�o��
        /// </summary>
        private ConvObjSingleBkCLCLogDB _coclcldb = null;

        #endregion //�v���C�x�[�g�t�B�[���h

        #region �R���X�g���N�^

        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�vAWS����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public ConvObjSingleBkFileMngDB()
        {
            _bucketName = string.Empty;
            _accessKeyID = string.Empty;
            _secretAccessKey = string.Empty;

            try
            {
                _cosbdbp = new ConvObjSingleBkDBParam();
                _coclcldb = new ConvObjSingleBkCLCLogDB();
                
                #region �ݒ�t�@�C���擾

                string fileName = this.InitializeXmlSettings();

                if (fileName != string.Empty)
                {
                    XmlReaderSettings settings = new XmlReaderSettings();

                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement("BucketName")) _bucketName = DecryptionEntry(reader.ReadElementContentAsString()).Trim('\0');
                            if (reader.IsStartElement("AccessKeyID")) _accessKeyID = DecryptionEntry(reader.ReadElementContentAsString()).Trim('\0');
                            if (reader.IsStartElement("SecretAccessKey")) _secretAccessKey = DecryptionEntry(reader.ReadElementContentAsString()).Trim('\0');
                        }
                    }
                }
                else
                {
                    // �ݒ�t�@�C�����Ȃ��ꍇ�G���[���O�o��
                    base.WriteErrorLog("ConvObjSingleBkFileMngDB XmlNotFound");
                }
                #endregion // �ݒ�t�@�C���擾

                #region ��ƃf�B���N�g���擾

                // ���W�X�g���L�[�擾
                RegistryKey key = Registry.LocalMachine.OpenSubKey(RegistryKeyUSER_APMain);

                string workDir = string.Empty;

                // ��ƃf�B���N�g���擾
                if (key == null) // �����Ă͂����Ȃ��P�[�X
                {
                    workDir = WorkingDirDefault; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
                }
                else
                {
                    workDir = key.GetValue(RegistryKeyUSER_APInstallDirectory, WorkingDirDefault).ToString();
                }

                // �t�@�C���i�[���p�X��`
                _fileDirectory = Path.Combine(workDir.TrimEnd('\\'), BACKUP_PATH);

                #endregion // ��ƃf�B���N�g���擾


            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB Exception");
            }
        }

        #endregion //�R���X�g���N�^

        #region AWS�A�b�v���[�h

        /// <summary>
        /// AWS�A�b�v���[�h
        /// </summary>
        /// <param name="bkFileName"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : AWS�A�b�v���[�h���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br>Update Note: AWS TLS1.2�Ή�</br>
        /// <br>Programmer : �c������</br>
        /// <br>Date       : 2023/05/29</br>
        /// <br>�Ǘ��ԍ�   : 11970089-00</br>
        /// <br></br>
        /// </remarks>
        public int AWSUpload(string bkFileName)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.Error;

            if (string.IsNullOrEmpty(_bucketName) || string.IsNullOrEmpty(_accessKeyID) || string.IsNullOrEmpty(_secretAccessKey))
            {
                // �ݒ�t�@�C����񂪂Ȃ��ꍇ�I��
                // ���g���C���Ă����ʂ��ς��Ȃ����ߐ���Ŗ߂�
                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                return status;
            }

            if (string.IsNullOrEmpty(bkFileName))
            {
                // �o�b�N�A�b�v�t�@�C�����Ȃ��ꍇ�ُ�I��
                return status;
            }

            try
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.AWSUpload;
                
	            // ------ ADD 2023/05/29 �c������ AWS TLS1.2�Ή� -------->>>>>
                string strSslPolErrMsg;
	            // Partsman Product�萔��`�N���X(PMCMN00500C.dll)����Z�L�����e�B�v���g�R�����擾����B
	            ServicePointManager.SecurityProtocol = ConstantManagement_PM_PRO.ScrtyPrtcl;
	
	            // �ؖ����̌��؊m�F�ǉ�
	            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate(
	                Object certsender,
	                X509Certificate certificate,
	                X509Chain chain,
	                SslPolicyErrors sslPolicyErrors)
	            {
	                return AddServerCertificateValidation(certsender, certificate, chain, sslPolicyErrors, out strSslPolErrMsg);
	            });
                // ------ ADD 2023/05/29 �c������ AWS TLS1.2�Ή� --------<<<<<
                
                AmazonS3Config clientConfig = new AmazonS3Config();

                // The Asia Pacific (Tokyo) endpoint.
                clientConfig.RegionEndpoint = RegionEndpoint.APNortheast1;
                using (AmazonS3Client s3 = new AmazonS3Client(_accessKeyID, _secretAccessKey, clientConfig))
                {
                    using (TransferUtility tranUtility = new TransferUtility(s3))
                    {
                        // �Ǎ��t�@�C���X�g���[������
                        string filePath = Path.Combine(_fileDirectory, bkFileName);
                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            // AWS�փA�b�v���[�h
                            tranUtility.Upload(fs, _bucketName, bkFileName);
                        }
                    }
                }

                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.AWSUploadExError;
                ClcLogOutputProc(string.Format("{0},status:{1},_bucketName:{2},_accessKeyID:{3},_secretAccessKey:{4},ex:{5}", "ERR PMCMN00163RF AWSUpload Exception", status.ToString(), _bucketName, _accessKeyID, _secretAccessKey, ex.ToString()));
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.AWSUpload Exception", status);
            }

            return status;
        }

        // ------ ADD 2023/05/29 �c������ AWS TLS1.2�Ή� -------->>>>>
        /// <summary>
        /// �T�[�o�ؖ����L�����`�F�b�N
        /// </summary>
        /// <param name="certsender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <param name="strSslPolErrMsg"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : AWS TLS1.2�Ή�</br>
        /// <br>Programmer : �c������</br>
        /// <br>Date       : 2023/05/29</br>
        /// <br>�Ǘ��ԍ�   : 11970089-00</br>
        /// <br></br>
        /// </remarks>
        private bool AddServerCertificateValidation(Object certsender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors, out string strSslPolErrMsg)
        {
            strSslPolErrMsg = string.Empty;
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                strSslPolErrMsg = "�T�[�o�[�ؖ����̌��؂ɐ������܂����B";
                return true;
            }
            else
            {
                strSslPolErrMsg = "�T�[�o�[�ؖ����̌��؂Ɏ��s���܂����B";

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) ==
                    SslPolicyErrors.RemoteCertificateChainErrors)
                {
                    strSslPolErrMsg += "ChainStatus���A��łȂ��z���Ԃ��܂����B";
                    strSslPolErrMsg += "[";
                    foreach (X509ChainStatus C509CS in chain.ChainStatus)
                    {
                        strSslPolErrMsg += string.Format("{0}:{1} ", C509CS.Status, C509CS.StatusInformation);
                    }
                    strSslPolErrMsg += "]";
                }

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNameMismatch) ==
                    SslPolicyErrors.RemoteCertificateNameMismatch)
                {
                    strSslPolErrMsg += "�ؖ��������s��v�ł��B";
                }

                if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) ==
                    SslPolicyErrors.RemoteCertificateNotAvailable)
                {
                    strSslPolErrMsg += "�ؖ��������p�ł��܂���B";
                }
                return false;
            }
        }
        // ------ ADD 2023/05/29 �c������ AWS TLS1.2�Ή� --------<<<<<<

        #endregion // AWS�A�b�v���[�h

        #region ���o�b�N�A�b�v�폜

        /// <summary>
        /// ���o�b�N�A�b�v�폜
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���o�b�N�A�b�v�폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br>Update Note: ���[�J���t�@�C���폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        public int OldBkDelete(ConvObjSingleBkWork convObjSingleBkWork)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.Error;
            int statusProc = (int)ConvObjSingleBkDBParam.StatusCode.Error;
            int statusAWS = (int)ConvObjSingleBkDBParam.StatusCode.Error;
            int statusLocal = (int)ConvObjSingleBkDBParam.StatusCode.Error;
            SqlConnection sqlConnection = null;
            DataTable dt = null;
            // ------ ADD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
            string[] localFiles = new string[0];
            // ------ ADD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<

            try
            {
                // �f�[�^�x�[�X�ڑ�
                statusProc = GetDataBaseConnect(ref sqlConnection);

                if (statusProc != (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    base.WriteErrorLog("ConvObjSingleBkFileMngDB.AWSDelete GetDataBaseConnectError", statusProc);
                    // �f�[�^�x�[�X�ڑ����s�̏ꍇ���f����
                    return status;
                }

                // ------ ADD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
                // ���݊i�[����Ă���S���[�J���o�b�N�t�@�C���p�X�擾
                localFiles = GetLocalFiles();
                // ------ ADD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<

                // �R���o�[�g�Ώۃo�b�N�A�b�v�Ǘ��}�X�^�擾
                statusProc = GetConvObjBkMng(convObjSingleBkWork, sqlConnection, ref dt);

                if (statusProc == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // �������s
                }
                else if (statusProc == (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound)
                {
                    // �폜�Ώۃt�@�C�����Ȃ����ߐ���I��
                    status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                    return status;
                }
                else
                {
                    base.WriteErrorLog("ConvObjSingleBkFileMngDB.AWSDelete GetDataBaseConnectError", statusProc);
                    // �}�X�^�擾�Ɏ��s�����ꍇ���f����
                    return status;
                }

                if (!string.IsNullOrEmpty(_bucketName) && !string.IsNullOrEmpty(_accessKeyID) && !string.IsNullOrEmpty(_secretAccessKey))
                {
                    // �ݒ�t�@�C����񂪂���ꍇ�̂ݎ��s
                    // AWS�t�@�C���폜
                    // �t�@�C���폜���s�͌㑱�����ɉe�����Ȃ����߁A���g���C�Ώۂ��Ȃ�
                    statusAWS = AWSDelete(dt);

                }
                else
                {
                    // �ݒ�t�@�C�����Ȃ��ꍇ���[�J���̂ݑ��삷�邽�ߐ���
                    statusAWS = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                }

                // ���[�J���t�@�C���폜
                // �t�@�C���폜���s�͌㑱�����ɉe�����Ȃ����߁A���g���C�Ώۂ��Ȃ�
                // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
                //statusLocal = LocalDelete(dt);
                statusLocal = LocalDelete(dt, localFiles);
                // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<

                if (statusAWS == (int)ConvObjSingleBkDBParam.StatusCode.Normal && statusLocal == (int)ConvObjSingleBkDBParam.StatusCode.Normal)
                {
                    // �t�@�C���폜�����������ꍇ�R���o�[�g�Ώۃo�b�N�A�b�v�Ǘ��}�X�^�X�V
                    statusProc = UpdConvObjBkMng(convObjSingleBkWork, sqlConnection, dt);
                }

                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteExError;
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.AWSDelete Exception", status);
            }
            finally
            {
                // �f�[�^�e�[�u�����
                if (dt != null)
                {
                    dt.Clear();
                    dt.Dispose();
                    dt = null;
                }

                // �f�[�^�x�[�X�ڑ�����
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlConnection = null;
                }
            }

            return status;
        }

        #endregion // ���o�b�N�A�b�v�폜

        #region ���[�J���s���t�@�C���폜

        /// <summary>
        /// ���[�J���t�@�C���폜
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�J���t�@�C���폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br>Update Note: ���[�J���t�@�C���폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        public int LocalExDelete()
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteLocalDeleteError;

            try
            {
                // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
                //string[] txtFileList = Directory.GetFiles(_fileDirectory, "*.txt");
                //foreach (string txtFile in txtFileList)
                //{
                //    base.WriteErrorLog(txtFile);
                //    File.Delete(txtFile);
                //}
                if (Directory.Exists(_fileDirectory))
                {
                    string[] txtFileList = Directory.GetFiles(_fileDirectory, "*.txt");
                    foreach (string txtFile in txtFileList)
                    {
                        base.WriteErrorLog(txtFile);
                        File.Delete(txtFile);
                    }
                }
                // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<

                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteLocalDeleteExError;
                // ���O�o��
                base.WriteErrorLog(ex, "LocalExDelete Exception", status);
            }
            finally
            {
            }

            return status;
        }

        #endregion // ���[�J���t�@�C���폜


        #region �� Private Methods

        #region �R���o�[�g�Ώۃo�b�N�A�b�v�Ǘ��}�X�^�X�V

        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v�Ǘ��}�X�^�X�V
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�v�Ǘ��}�X�^�X�V���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br>Update Note: ���[�J���t�@�C���폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        private int UpdConvObjBkMng(ConvObjSingleBkWork convObjSingleBkWork, SqlConnection sqlConnection, DataTable dt)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteUpdConvObjBkMngError;
            // ------ DEL 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>        
            //int statusProc = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            // ------ DEL 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<
            StringBuilder sqlText;
            int iRowCnt = 0;

            try
            {
                // ------ DEL 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
                //foreach (DataRow dr in dt.Rows)
                //{
                // ------ DEL 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<
                sqlText = new StringBuilder();
                sqlText.AppendLine("UPDATE ");
                sqlText.AppendLine(" CONVOBJBKMNGRF ");
                sqlText.AppendLine("SET ");
                sqlText.AppendLine(" BKDELCODERF = @BKDELCODE ");
                sqlText.AppendLine("WHERE ");
                sqlText.AppendLine("     ENTERPRISECODERF = @ENTERPRISECODE ");
                // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
                //sqlText.AppendLine(" AND BKCREGENERATIONRF = @BKCREGENERATION ");
                sqlText.AppendLine(" AND BKDELCODERF = @BKDELCODE_CND ");
                sqlText.AppendLine(" AND BKCREGENERATIONRF <= @BKCREGENERATION ");
                // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<

                using (SqlCommand sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection))
                {
                    sqlCommand.CommandTimeout = _cosbdbp.DbCommandTimeout;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    // ------ ADD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
                    SqlParameter paraDelCodeCnd = sqlCommand.Parameters.Add("@BKDELCODE_CND", SqlDbType.Int);
                    // ------ ADD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<
                    SqlParameter paraBkCreGeneration = sqlCommand.Parameters.Add("@BKCREGENERATION", SqlDbType.Int);
                    SqlParameter paraDelCode = sqlCommand.Parameters.Add("@BKDELCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.EnterpriseCode);
                    // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
                    //paraBkCreGeneration.Value = SqlDataMediator.SqlSetInt32((int)dr["BKCREGENERATIONRF"]);
                    paraDelCodeCnd.Value = SqlDataMediator.SqlSetInt32((int)BkDelCode.Enable);
                    paraBkCreGeneration.Value = SqlDataMediator.SqlSetInt32(convObjSingleBkWork.BkCreGeneration - _cosbdbp.BkGeneration);
                    // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<
                    paraDelCode.Value = SqlDataMediator.SqlSetInt32((int)BkDelCode.Disable);

                    iRowCnt = sqlCommand.ExecuteNonQuery();

                    // ------ DEL 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
                    //if (iRowCnt == 0)
                    //{
                    //    statusProc = (int)ConvObjSingleBkDBParam.StatusCode.Error;
                    //    base.WriteErrorLog(string.Format("{0},BKCREGENERATIONRF:{1}", "ConvObjSingleBkFileMngDB.UpdConvObjBkMng UpdNotFound", dr["BKCREGENERATIONRF"].ToString()), statusProc);
                    //}
                    // ------ DEL 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<
                }
                // ------ DEL 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
                //}
                // ------ DEL 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<

                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;

            }
            catch (SqlException sqlex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteUpdConvObjBkMngSqlExError;
                base.WriteSQLErrorLog(sqlex, "ConvObjSingleBkFileMngDB.UpdConvObjBkMng SqlException", status);
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteUpdConvObjBkMngExError;
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.UpdConvObjBkMng Exception", status);
            }
            finally
            {
            }

            return status;
        }

        #endregion // �R���o�[�g�Ώۃo�b�N�A�b�v�Ǘ��}�X�^�X�V

        #region AWS�t�@�C���폜

        /// <summary>
        /// AWS�t�@�C���폜
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : AWS�t�@�C���폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br>Update Note: AWS TLS1.2�Ή�</br>
        /// <br>Programmer : �c������</br>
        /// <br>Date       : 2023/05/29</br>
        /// <br>�Ǘ��ԍ�   : 11970089-00</br>
        /// <br></br>
        /// </remarks>
        private int AWSDelete(DataTable dt)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteAWSDeleteError;

            try
            {
	            // ------ ADD 2023/05/29 �c������ AWS TLS1.2�Ή� -------->>>>>
                string strSslPolErrMsg;
	            // Partsman Product�萔��`�N���X(PMCMN00500C.dll)����Z�L�����e�B�v���g�R�����擾����B
	            ServicePointManager.SecurityProtocol = ConstantManagement_PM_PRO.ScrtyPrtcl;
	
	            // �ؖ����̌��؊m�F�ǉ�
	            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate(
	                Object certsender,
	                X509Certificate certificate,
	                X509Chain chain,
	                SslPolicyErrors sslPolicyErrors)
	            {
	                return AddServerCertificateValidation(certsender, certificate, chain, sslPolicyErrors, out strSslPolErrMsg);
	            });
	            // ------ ADD 2023/05/29 �c������ AWS TLS1.2�Ή� --------<<<<<

                AmazonS3Config clientConfig = new AmazonS3Config();

                // The Asia Pacific (Tokyo) endpoint.
                clientConfig.RegionEndpoint = RegionEndpoint.APNortheast1;

                DeleteObjectsRequest deleteOBjectsRequest = new DeleteObjectsRequest();

                // �o�P�b�g���ݒ�
                deleteOBjectsRequest.BucketName = _bucketName;

                // �폜�Ώۃt�@�C�����L�[���X�g�ɒǉ�
                foreach (DataRow dr in dt.Rows)
                {
                    deleteOBjectsRequest.AddKey(dr["BKFILENAMERF"].ToString());
                }

                using (AmazonS3Client s3 = new AmazonS3Client(_accessKeyID, _secretAccessKey, clientConfig))
                {
                    // �t�@�C���폜
                    s3.DeleteObjects(deleteOBjectsRequest);
                }

                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteAWSDeleteExError;
                // ���O�o��
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.AWSDelete Exception", status);
            }
            finally
            {
            }

            return status;
        }

        #endregion // AWS�t�@�C���폜

        #region ���[�J���t�@�C���폜

        /// <summary>
        /// ���[�J���t�@�C���폜
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[�J���t�@�C���폜���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br>Update Note: ���[�J���t�@�C���폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
        //private int LocalDelete(DataTable dt)
        private int LocalDelete(DataTable dt, string[] localFiles)
        // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteLocalDeleteError;

            // ------ ADD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
            bool delExec = true;
            string filePath = string.Empty;
            // ------ ADD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<

            try
            {
                // ���[�J���t�@�C���폜
                // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
                //foreach (DataRow dr in dt.Rows)
                //{
                //    string filePath = Path.Combine(_fileDirectory, dr["BKFILENAMERF"].ToString());
                //    if (File.Exists(filePath))
                //    {
                //        File.Delete(filePath);
                //    }
                //}
                // ���݊i�[����Ă��郍�[�J���o�b�N�A�b�v�t�@�C�������[�v
                foreach (string localFile in localFiles)
                {
                    delExec = true;

                    foreach (DataRow dr in dt.Rows)
                    {
                        filePath = Path.Combine(_fileDirectory, dr["BKFILENAMERF"].ToString());

                        // ���[�J���t�@�C�����L���ȃt�@�C�����m�F
                        if (filePath == localFile)
                        {
                            // �ێ�������̗L���ȃt�@�C���̏ꍇ�폜�ΏۊO
                            delExec = false;
                        }
                    }

                    // �L���ȃt�@�C���Ƀq�b�g���Ȃ��ꍇ�폜
                    if (delExec)
                    {
                        // �O�̂��߃t�@�C���̑��݃`�F�b�N���폜
                        if (File.Exists(localFile))
                        {
                            File.Delete(localFile);
                        }
                    }
                }
                // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<

                status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteLocalDeleteExError;
                // ���O�o��
                base.WriteErrorLog(ex, "LocalDelete.AWSDelete Exception", status);
            }
            finally
            {
            }

            return status;
        }

        #endregion // ���[�J���t�@�C���폜

        // ------ ADD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
        #region ���[�J���o�b�N�A�b�v�t�@�C���p�X�擾
        /// <summary>
        /// ���[�J���o�b�N�A�b�v�t�@�C���p�X�擾
        /// </summary>
        /// <returns>���[�J���o�b�N�A�b�v�t�@�C���p�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J���o�b�N�A�b�v�t�@�C���p�X�擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        public string[] GetLocalFiles()
        {
            string[] files = new string[0];
            try
            {
                if (Directory.Exists(_fileDirectory))
                {
                    files = Directory.GetFiles(_fileDirectory, "*.zip");
                }
            }
            catch (Exception ex)
            {
                // ���O�o��
                base.WriteErrorLog(ex, "GetLocalFiles Exception", (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteGetLocalFilesExError);
            }
            finally
            {
            }

            return files;
        }
        #endregion
        // ------ ADD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<

        #region �f�[�^�x�[�X�ڑ�

        /// <summary>
        /// �f�[�^�x�[�X�ڑ�
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�x�[�X�ڑ�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date	   : 2020/06/15</br>
        /// </remarks>
        private int GetDataBaseConnect(ref SqlConnection sqlConnection)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.AWSGetDataBaseConnectError;

            sqlConnection = null;
                
            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateConnection(true);

                if (sqlConnection != null)
                {
                    // ����
                    status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                }
            }
            catch (Exception ex)
            {
                // ��O�G���[
                status = (int)ConvObjSingleBkDBParam.StatusCode.AWSGetDataBaseConnectExError;
                // ���O�o��
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.GetDataBaseConnect Exception", status);
            }
            finally
            {
                // ������
            }

            return status;
        }

        #endregion //�f�[�^�x�[�X�ڑ�

        #region �R���o�[�g�Ώۃo�b�N�A�b�v�Ǘ��}�X�^�擾

        /// <summary>
        /// �R���o�[�g�Ώۃo�b�N�A�b�v�Ǘ��}�X�^�擾
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �R���o�[�g�Ώۃo�b�N�A�b�v�Ǘ��}�X�^�擾���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br>Update Note: ���[�J���t�@�C���폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2021/09/09</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br></br>
        /// </remarks>
        private int GetConvObjBkMng(ConvObjSingleBkWork convObjSingleBkWork, SqlConnection sqlConnection, ref DataTable dt)
        {
            int status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteGetConvObjBkMngError;

            StringBuilder sqlText = new StringBuilder();
            int iRowCnt = 0;

            try
            {
                sqlText.AppendLine("SELECT ");
                sqlText.AppendLine(" BKCREGENERATIONRF, ");
                sqlText.AppendLine(" BKFILENAMERF ");
                sqlText.AppendLine("FROM ");
                sqlText.AppendLine(" CONVOBJBKMNGRF ");
                sqlText.AppendLine("WHERE ");
                sqlText.AppendLine("     ENTERPRISECODERF = @ENTERPRISECODE ");
                // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�-------->>>>>
                //sqlText.AppendLine(" AND BKCREGENERATIONRF <= @BKCREGENERATION ");
                // �L���ȃt�@�C���̂ݎ擾����
                sqlText.AppendLine(" AND BKCREGENERATIONRF > @BKCREGENERATION ");
                // ------ UPD 2021/09/09 ���� �o�b�N�A�b�v�폜�R��A�s�v�ȗ�O�o�͗}�~�Ή�--------<<<<<
                sqlText.AppendLine(" AND LOGICALDELETECODERF = @LOGICALDELETECODE ");
                sqlText.AppendLine(" AND BKDELCODERF = @BKDELCODE ");

                using (SqlCommand sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection))
                {
                    sqlCommand.CommandTimeout = _cosbdbp.DbCommandTimeout;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraBkCreGeneration = sqlCommand.Parameters.Add("@BKCREGENERATION", SqlDbType.Int);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraDelCode = sqlCommand.Parameters.Add("@BKDELCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    // �ێ�����ȑO�̃t�@�C�����폜�ΏۂƂ���
                    int bkCreGeneration = convObjSingleBkWork.BkCreGeneration - _cosbdbp.BkGeneration;

                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(convObjSingleBkWork.EnterpriseCode);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((int)ConstantManagement.LogicalMode.GetData0);
                    paraBkCreGeneration.Value = SqlDataMediator.SqlSetInt32(bkCreGeneration);
                    paraDelCode.Value = SqlDataMediator.SqlSetInt32((int)BkDelCode.Enable);

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        sda.SelectCommand = sqlCommand;

                        dt = new DataTable();
                        iRowCnt = sda.Fill(dt);
                    }
                }

                if (iRowCnt == 0)
                {
                    // �폜�Ώۃt�@�C���Ȃ�
                    status = (int)ConvObjSingleBkDBParam.StatusCode.NormalNotFound;
                }
                else
                {
                    status = (int)ConvObjSingleBkDBParam.StatusCode.Normal;
                }

            }
            catch (SqlException sqlex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteGetConvObjBkMngSqlError;
                base.WriteSQLErrorLog(sqlex, "ConvObjSingleBkFileMngDB.GetConvObjBkMng SqlException", status);
            }
            catch (Exception ex)
            {
                status = (int)ConvObjSingleBkDBParam.StatusCode.OldBkDeleteGetConvObjBkMngExError;
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.GetConvObjBkMng Exception", status);
            }
            finally
            {
            }

            return status;
        }

        #endregion // �R���o�[�g�Ώۃo�b�N�A�b�v�Ǘ��}�X�^�擾

        #region XML�t�@�C������

        /// <summary>
        /// XML�t�@�C���ݒ���擾����
        /// �t�@�C�������݂��Ȃ��ꍇ�͋󕶎���߂�
        /// </summary>
        /// <returns>�t���p�X�t�@�C����</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C������A��
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // �t�@�C�������݂��Ȃ��ꍇ�͋󔒂ɂ���
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch
            {
                //���O�o��
            }

            return path;
        }
        #endregion  //XML�t�@�C������

        #region �J�����g�t�H���_
        /// <summary>
        /// �J�����g�t�H���_�̃p�X�擾
        /// �t�H���_�����݂��Ȃ��ꍇ�͋󕶎���߂�
        /// </summary>
        /// <returns>�t���p�X�t�@�C����</returns>
        /// <remarks>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML�i�[�f�B���N�g���擾
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g��
                        // �^�p�゠�肦�Ȃ��P�[�X
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch
            {
                //���O�o��
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }

            return homeDir;
        }
        #endregion // �J�����g�t�H���_

        #region DecryptionEntry

        /// <summary>
        /// �f�[�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������̕��������s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private string DecryptionEntry(string source)
        {
            string decrypted = string.Empty;
            byte[] decByte;

            try
            {
                // AES�Í����I�u�W�F�N�g�𐶐����܂�
                using (RijndaelManaged rijndael = new RijndaelManaged())
                {
                    // �������x�N�g���A�Í�������`
                    rijndael.IV = Encoding.UTF8.GetBytes(AESEncryptInfo.AES_IV);
                    rijndael.Key = Encoding.UTF8.GetBytes(AESEncryptInfo.AES_Key);
                    rijndael.Padding = PaddingMode.Zeros;

                    // �Í����I�u�W�F�N�g����
                    ICryptoTransform decryptor = rijndael.CreateDecryptor(rijndael.Key, rijndael.IV);

                    // �Í����������byte�z��ɕϊ�
                    decByte = Convert.FromBase64String(source);

                    // Stream����ŕ����񂩂�Í������Byte�z��𐶐�
                    using (MemoryStream msDecrypt = new MemoryStream(decByte))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                // CryptoStream�p��Streamreader�ŕ�����������Ǎ�
                                decrypted = srDecrypt.ReadToEnd();
                            }

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                base.WriteErrorLog(ex, "ConvObjSingleBkFileMngDB.DecryptionEntry Exception");
                throw;
            }

            return decrypted;
        }

        #endregion // �f�[�^������

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

        #endregion // �� Private Methods


    }
}
