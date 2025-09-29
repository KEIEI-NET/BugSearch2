using System;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �A�v���P�[�V���� ���\�[�X�ɑ΂��郍�b�N�@�\��L���� RemoteDB �N���X�ł��B
    /// </summary>
    /// <remarks>
    /// �{�N���X�̓A�v���P�[�V���� ���\�[�X���b�N���s���ۂɃC���X�^���X�����ĊY�����\�b�h��
    /// ���s���Ă��\���܂��񂵁ARemoteDB �̑ւ��Ɍp�����Ƃ��Ďw�肵�ĊY�����\�b�h�����s
    /// ���Ă��\���܂���B
    /// </remarks>
    public partial class RemoteWithAppLockDB : RemoteDB
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public RemoteWithAppLockDB()
            : base()
        {

        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="parmClassName"></param>
        /// <param name="BaseTableName"></param>
        public RemoteWithAppLockDB(string assemblyName, string parmClassName, string BaseTableName)
            : base(assemblyName, parmClassName, BaseTableName)
        {

        }

        # region [�R�l�N�V�����E�g�����U�N�V�����֌W]

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        public SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <param name="open">true:DB�֐ڑ�����@false:DB�֐ڑ����Ȃ�</param>
        /// <returns>�������ꂽSqlConnection�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.12.09</br>
        /// </remarks>
        public SqlConnection CreateConnection(bool open)
        {
            // CreateTransaction �ɖ��O�𕹂��������c
            return this.CreateSqlConnection(open);
        }

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection">�f�[�^�x�[�X�ڑ����</param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        public SqlTransaction CreateTransaction(ref SqlConnection sqlconnection)
        {
            return this.CreateTransaction(ref sqlconnection, ConstantManagement.DB_IsolationLevel.ctDB_Default);
        }

        /// <summary>
        /// SqlTransaction��������
        /// </summary>
        /// <param name="sqlconnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="isolationLevel">�g�����U�N�V�����������x�����w��</param>
        /// <returns>�������ꂽSqlTransaction�A�����Ɏ��s�����ꍇ��Null��Ԃ��B</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc</br>
        /// <br>Date       : 2008.06.02</br>
        /// </remarks>
        public SqlTransaction CreateTransaction(ref SqlConnection sqlconnection, ConstantManagement.DB_IsolationLevel isolationLevel)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DB�ɐڑ�����Ă��Ȃ��ꍇ�͂����Őڑ�����
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // �g�����U�N�V�����̐���(�J�n)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)isolationLevel);
            }

            return retSqlTransaction;
        }

        # endregion

        # region [�V�X�e�����b�N�֌W]

        // �f�t�H���g�̃^�C���A�E�g���Ԃ��_�b�Ŏw�肷��
        private const int DEFAULT_TIMEOUT = 300000;  //  5��

        /// <summary>
        /// ���b�N ���\�[�X�����擾���܂��B
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h</param>
        /// <returns>���b�N ���\�[�X��</returns>
        public string GetResourceName(string enterprisecode)
        {
            return string.Format("{0}-{1}-{2}", enterprisecode,
                                                ConstantManagement_SF_PRO.ProductCode,
                                                this.GetType().FullName);
        }

        /// <summary>
        /// �A�v���P�[�V���� ���\�[�X�Ƀ��b�N��ݒ肵�܂��B
        /// </summary>
        /// <param name="resourcename">���b�N ���\�[�X�����w�肵�܂��B</param>
        /// <param name="connection">�f�[�^�x�[�X�̐ڑ������w�肵�܂��B</param>
        /// <param name="transaction">�g�����U�N�V���������w�肵�܂��B</param>
        /// <remarks>���b�N �^�C���A�E�g�̓f�t�H���g �^�C���A�E�g�ɏ������܂��B</remarks>
        /// <returns>STATUS</returns>
        public int Lock(string resourcename, SqlConnection connection, SqlTransaction transaction)
        {
            return ExclusiveLockControl(LockControl.Locke, connection, transaction, resourcename, DEFAULT_TIMEOUT);
        }

        /// <summary>
        /// �A�v���P�[�V���� ���\�[�X�Ƀ��b�N��ݒ肵�܂��B
        /// </summary>
        /// <param name="resourcename">���b�N ���\�[�X�����w�肵�܂��B</param>
        /// <param name="timeout">���b�N �^�C���A�E�g�l���~���b�P�ʂŎw�肵�܂��B�@���b�N��ҋ@���Ȃ��ꍇ�� <b>0</b> ���w�肵�܂��B</param>
        /// <param name="connection">�f�[�^�x�[�X�̐ڑ������w�肵�܂��B</param>
        /// <param name="transaction">�g�����U�N�V���������w�肵�܂��B</param>
        /// <returns>STATUS</returns>
        public int Lock(string resourcename, int timeout, SqlConnection connection, SqlTransaction transaction)
        {
            return ExclusiveLockControl(LockControl.Locke, connection, transaction, resourcename, timeout);
        }

        /// <summary>
        /// �A�v���P�[�V���� ���\�[�X�̃��b�N��������܂��B
        /// </summary>
        /// <param name="resourcename">���b�N ���\�[�X�����w�肵�܂��B</param>
        /// <param name="connection">�f�[�^�x�[�X�̐ڑ������w�肵�܂��B</param>
        /// <param name="transaction">�g�����U�N�V���������w�肵�܂��B</param>
        /// <returns>STATUS</returns>
        public int Release(string resourcename, SqlConnection connection, SqlTransaction transaction)
        {
            return ExclusiveLockControl(LockControl.Release, connection, transaction, resourcename, 0);
        }

        # endregion

        /// <summary>
        /// �r��������w�肷��񋓑̂ł��B
        /// </summary>
        public enum LockControl
        {
            /// <summary>���b�N���w�肵�܂��B</summary>
            Locke,
            /// <summary>���b�N�������w�肵�܂��B</summary>
            Release
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="resourcename"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        private int ExclusiveLockControl(LockControl mode, SqlConnection connection, SqlTransaction transaction, string resourcename, int timeout)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlCommand command = null;

            try
            {
                command = new SqlCommand("", connection, transaction);
                command.CommandType = CommandType.StoredProcedure;                                                // �R�}���h�^�C�v�̐ݒ�(�X�g�A�h�v���V�[�W��)

                // �R�}���h�^�C���A�E�g���w�胍�b�N�^�C���A�E�g(�b�ϊ�)�{10�b�ɐݒ�
                // ���R�}���h�^�C���A�E�g�̕W���l��30�b�ׁ̈A�w�胍�b�N�^�C���A�E�g��30�b�ȏ�ɐݒ肳����
                //   ���b�N�^�C���A�E�g������ɃR�}���h�^�C���A�E�g���������Ă��܂��̂��������B
                command.CommandTimeout = (int)(timeout / 1000) + 10;

                // �߂�l���󂯎��p�����[�^���w��
                command.Parameters.Add("ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                // sp_getapplock, sp_releaseapplock ���ʃp�����[�^
                command.Parameters.Add("@Resource", SqlDbType.NVarChar).Value = SqlDataMediator.SqlSetString(resourcename);
                command.Parameters.Add("@LockOwner ", SqlDbType.NVarChar).Value = SqlDataMediator.SqlSetString("Transaction");

                if (mode == LockControl.Locke)
                {
                    // ���b�N��������
                    command.CommandText = "sp_getapplock";
                    command.Parameters.Add("@LockMode ", SqlDbType.NVarChar).Value = SqlDataMediator.SqlSetString("Exclusive");
                    command.Parameters.Add("@LockTimeout ", SqlDbType.Int).Value = SqlDataMediator.SqlSetInt(timeout);
                }
                else
                {
                    // ���b�N���J������
                    command.CommandText = "sp_releaseapplock";
                }

                command.ExecuteNonQuery();

                int execRet = Convert.ToInt32(command.Parameters["ReturnValue"].Value);

                if (execRet == 0)
                {
                    // �߂�l�� 0 �̏ꍇ�� Lock, Release ���ɏ�������
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else if (mode == LockControl.Locke && execRet == 1)
                {
                    // �݊����̖������̃��b�N����������̂�ҋ@���Ă���A���b�N��������܂����B
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else if (mode == LockControl.Locke && execRet == -1)
                {
                    // ���b�N�^�C���A�E�g
                    status = (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT;
                }
                else
                {
                    // ���̑��̃G���[
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            catch (SqlException ex)
            {
                status = this.WriteSQLErrorLog(ex, string.Format(" {0}.{1} ResourceName:{2} ", this.GetType().Name, mode.ToString(), resourcename), ex.Number);
            }
            catch (Exception ex)
            {
                this.WriteErrorLog(ex, string.Format(" {0}.{1} ResourceName:{2} ", this.GetType().Name, mode.ToString(), resourcename), status);
            }
            finally
            {
                if (command != null)       
                {
                    command.Cancel();
                    command.Dispose();
                }
            }

            return status;
        }
    }
}
