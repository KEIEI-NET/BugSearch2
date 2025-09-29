//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ������
// �v���O�����T�v   : ���������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11670219-00 �쐬�S�� : ���X�ؘj
// �� �� ��  2020/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data;
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ������DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���X�ؘj</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>�Ǘ��ԍ�   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class EnvSurvObjDB : RemoteWithAppLockDB, IEnvSurvObjDB
    {

        #region �񋓑�

        /// <summary>
        /// �������̌��ʃX�e�[�^�X�񋓑�
        /// </summary>
        private enum StatusCode
        {
            /// <summary>����</summary>
            Normal = 0
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
        /// DB��
        /// </summary>
        private const string PMUSERDBName = "PM_USER_DB";

        /// <summary>
        /// �����������ŗ�O���������܂����B
        /// </summary>
        private const string ErrorTextUpdateProcFaild = "���������������ŗ�O���������܂����B";

        /// <summary>
        /// �ݒ�t�@�C����
        /// </summary>
        private const string XML_FILE_NAME = "PMCMN00153R_Setting.xml";

        /// <summary>
        /// �^�C���A�E�g�����l�i�b�j
        /// </summary>
        private const int TIMEOUT_DEFAULT_TIME = 1800;

        #endregion //�萔

        #region �v���C�x�[�g�t�B�[���h

        /// <summary>
        /// �^�C���A�E�g
        /// </summary>
        private int _timeOut;

        /// <summary>
        /// ����
        /// </summary>
        private static EnvSurvCommn esc = null;

        #endregion //�v���C�x�[�g�t�B�[���h

        #region �R���X�g���N�^

        /// <summary>
        /// �����������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public EnvSurvObjDB()
            : base("PMCMN00155D", "Broadleaf.Application.Remoting.ParamData.EnvSurvObjWork", "ENVSURVOBJRF")
        {
            #region �^�C���A�E�g

            // �^�C���A�E�g�����l
            _timeOut = TIMEOUT_DEFAULT_TIME;

            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            if (reader.IsStartElement("Timeout"))
                            {
                                _timeOut = reader.ReadElementContentAsInt();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //���O�o��
                    base.WriteErrorLog(ex, "EnvSurvObjDB.EnvSurvObjDB XMLReader");
                }
            }
            #endregion // �^�C���A�E�g

        }
        #endregion //�R���X�g���N�^

        #region IEnvSurvObjDB �����o

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� EnvFullBackupInfWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>EnvSurvObjWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private EnvFullBackupInfWork CopyToEnvFullBackupInfWorkReader(ref SqlDataReader myReader)
        {
            EnvFullBackupInfWork envFullBackupInfWork = new EnvFullBackupInfWork();

            this.CopyToEnvFullBackupInfWorkFromReader(ref myReader, ref envFullBackupInfWork);

            return envFullBackupInfWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� EnvFullBackupInfWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="envFullBackupInfWork">EnvFullBackupInfWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private void CopyToEnvFullBackupInfWorkFromReader(ref SqlDataReader myReader, ref EnvFullBackupInfWork envFullBackupInfWork)
        {
            if (myReader != null && envFullBackupInfWork != null)
            {
                # region �N���X�֊i�[
                envFullBackupInfWork.DatabaseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BS_DATABASE_NAME"));
                envFullBackupInfWork.PhysicalDeviceName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BMF_PHYSICAL_DEVICE_NAME"));
                envFullBackupInfWork.BackupStartDate = SqlDataMediator.SqlGetDateTime(myReader, myReader.GetOrdinal("BS_BACKUP_START_DATE"));
                envFullBackupInfWork.BackupFinishDate = SqlDataMediator.SqlGetDateTime(myReader, myReader.GetOrdinal("BS_BACKUP_FINISH_DATE"));
                if (myReader.IsDBNull(myReader.GetOrdinal("BS_BACKUP_SIZE")))
                {
                    envFullBackupInfWork.BackupSize = (double)0.0;
                }
                else
                {
                    envFullBackupInfWork.BackupSize = (double)myReader.GetDecimal(myReader.GetOrdinal("BS_BACKUP_SIZE"));
                }
                envFullBackupInfWork.BackupType = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BS_TYPE"));
                envFullBackupInfWork.ServerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BS_SERVER_NAME"));
                envFullBackupInfWork.MachineName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BS_MACHINE_NAME"));
                # endregion
            }
        }

        # endregion // [�N���X�i�[����]

        #region EnvFullBackupInfSearch
        /// <summary>
        /// �S�̃o�b�N�A�b�v���擾
        /// </summary>
        /// <param name="envFullBackupInf">�S�̃o�b�N�A�b�v���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int EnvFullBackupInfSearch(out object envFullBackupInf)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList envFullBackupInfList = null;

            envFullBackupInf = new CustomSerializeArrayList();

            status = EnvFullBackupInfSearchProc(out envFullBackupInfList);

            if (envFullBackupInfList != null && envFullBackupInfList.Count != 0)
            {
                (envFullBackupInf as CustomSerializeArrayList).AddRange(envFullBackupInfList);
            }

            return status;
        }

        /// <summary>
        /// �S�̃o�b�N�A�b�v���擾
        /// </summary>
        /// <param name="envFullBackupInfList">�S�̃o�b�N�A�b�v���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int EnvFullBackupInfSearchProc(out ArrayList envFullBackupInfList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                StringBuilder sqlText = new StringBuilder();
                sqlText.Append("SELECT bs.database_name AS BS_DATABASE_NAME " + Environment.NewLine);
                sqlText.Append("    ,bmf.physical_device_name AS BMF_PHYSICAL_DEVICE_NAME " + Environment.NewLine);
                sqlText.Append("    ,bs.backup_start_date AS BS_BACKUP_START_DATE " + Environment.NewLine);
                sqlText.Append("    ,bs.backup_finish_date AS BS_BACKUP_FINISH_DATE " + Environment.NewLine);
                sqlText.Append("    ,bs.backup_size AS BS_BACKUP_SIZE " + Environment.NewLine);
                sqlText.Append("    ,bs.type AS BS_TYPE " + Environment.NewLine);
                sqlText.Append("    ,bs.server_name AS BS_SERVER_NAME " + Environment.NewLine);
                sqlText.Append("    ,bs.machine_name AS BS_MACHINE_NAME " + Environment.NewLine);
                sqlText.Append(" FROM msdb.dbo.backupmediafamily bmf " + Environment.NewLine);
                sqlText.Append(" INNER JOIN msdb.dbo.backupset bs ON bs.media_set_id  = bmf.media_set_id " + Environment.NewLine);
                sqlText.Append(" WHERE bs.database_name = @FINDDATABESENAME " + Environment.NewLine);
                sqlText.Append(" ORDER BY bs.backup_finish_date DESC " + Environment.NewLine);
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaDatabaseName = sqlCommand.Parameters.Add("@FINDDATABESENAME", SqlDbType.NChar);

                findParaDatabaseName.Value = SqlDataMediator.SqlSetString(PMUSERDBName);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    // 1���̂�
                    al.Add(this.CopyToEnvFullBackupInfWorkReader(ref myReader));
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "EnvSurvObjDB.EnvFullBackupInfSearchProc SqlException", status);

                if (esc == null)
                {
                    // ���ʃN���X
                    esc = new EnvSurvCommn();
                }
                esc.ClcLogOutput(String.Format("{0}:{1}", "ERR PMCMN00153RA EnvFullBackupInfSearchProc SqlException", sqlex.Message));

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "EnvSurvObjDB.EnvFullBackupInfSearchProc", status);

                if (esc == null)
                {
                    // ���ʃN���X
                    esc = new EnvSurvCommn();
                }
                esc.ClcLogOutput(String.Format("{0}:{1}", "ERR PMCMN00153RA EnvFullBackupInfSearchProc Exception", ex.Message));
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            envFullBackupInfList = al;

            return status;
        }
        #endregion // EnvFullBackupInfSearch

        #region PriceMstInfCntSearch
        /// <summary>
        /// �}�X�^�����擾
        /// </summary>
        /// <param name="mstCount">�}�X�^����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        public int PriceMstInfCntSearch(out Int32 mstCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            status = PriceMstInfCntSearchProc(out mstCount);

            return status;
        }

        /// <summary>
        /// �}�X�^�����擾
        /// </summary>
        /// <param name="mstCount">�}�X�^����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>�Ǘ��ԍ�   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        private int PriceMstInfCntSearchProc(out Int32 mstCount)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            mstCount = 0;

            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;

            try
            {
                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                StringBuilder sqlText = new StringBuilder();
                sqlText.Append("SELECT COUNT(*) " + Environment.NewLine);
                sqlText.Append(" FROM GOODSPRICEURF WITH (READUNCOMMITTED) " + Environment.NewLine);
                sqlCommand = new SqlCommand(sqlText.ToString(), sqlConnection);
                myReader = sqlCommand.ExecuteReader();

                // �K���擾����1�s�ƂȂ�
                if (myReader.Read())
                {
                    // �擾����1��݂̂̂���0��ڂ��擾
                    mstCount = myReader.GetInt32(0);
                    if (mstCount > 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "EnvSurvObjDB.PriceMstInfCntSearchProc SqlException", status);

                if (esc == null)
                {
                    // ���ʃN���X
                    esc = new EnvSurvCommn();
                }
                esc.ClcLogOutput(String.Format("{0}:{1}", "ERR PMCMN00153RA PriceMstInfCntSearchProc SqlException", sqlex.Message));

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "EnvSurvObjDB.PriceMstInfCntSearchProc", status);
                
                if (esc == null)
                {
                    // ���ʃN���X
                    esc = new EnvSurvCommn();
                }
                esc.ClcLogOutput(String.Format("{0}:{1}", "ERR PMCMN00153RA PriceMstInfCntSearchProc Exception", ex.Message));

            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion // PriceMstInfCntSearch

        #region XML�t�@�C������
        /// <summary>
        /// XML�t�@�C���ݒ���擾����
        /// �t�@�C�������݂��Ȃ��ꍇ�͋󕶎���߂�
        /// </summary>
        /// <returns>�t���p�X�t�@�C����</returns>
        /// <remarks>
        /// <br>Programmer : ���X�ؘj</br>
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
            catch (Exception ex)
            {
                //���O�o��
                base.WriteErrorLog(ex, "EnvSurvObjDB.InitializeXmlSettings");
                if (esc == null)
                {
                    // ���ʃN���X
                    esc = new EnvSurvCommn();
                }
                esc.ClcLogOutput(String.Format("{0}:{1}", "ERR PMCMN00153RA InitializeXmlSettings Exception", ex.Message));
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
        /// <br>Programmer : ���X�ؘj</br>
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
            catch (Exception ex)
            {
                //���O�o��
                base.WriteErrorLog(ex, "EnvSurvObjDB.GetCurrentDirectory");
                if (esc == null)
                {
                    // ���ʃN���X
                    esc = new EnvSurvCommn();
                }
                esc.ClcLogOutput(String.Format("{0}:{1}", "ERR PMCMN00153RA GetCurrentDirectory Exception", ex.Message));

                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }

            return homeDir;
        }
        #endregion // private���\�b�h

        #endregion // IEnvSurvObjDB �����o

    }


}
