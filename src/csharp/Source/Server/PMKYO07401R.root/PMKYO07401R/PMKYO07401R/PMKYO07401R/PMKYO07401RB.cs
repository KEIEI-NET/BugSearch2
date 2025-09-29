using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���b�N�G�X�J���[�V�����h�~���i
    /// </summary>
    /// <remarks>
    /// <br>Note       : �C���e���g�r�����b�N�������ă��b�N�G�X�J���[�V�������N�����Ȃ��悤�ɂ��܂��B</br>
    /// <br>Programmer : qijh</br>
    /// <br>Date       : 2011.08.22</br>
    /// </remarks>
    public class IntentExclusiveLockComponent : RemoteDB
    {
        #region Constructor

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public IntentExclusiveLockComponent()
        {
        }

        #endregion

        #region PrivateMember

        private SqlConnection _sqlConnection   = null;
        private SqlTransaction _sqlTransaction = null;

        #endregion

        #region IntentLock

        /// <summary>
        /// �C���e���g�r�����b�N
        /// </summary>
        /// <param name="targetTables">�Ώۂ̃e�[�u��</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �e�[�u���ɃC���e���g�r�����b�N�������ă��b�N�G�X�J���[�V������h���܂�</br>
        /// <br>Programmer : qijh</br>
        /// <br>Date       : 2011.08.10</br>
        /// </remarks>
        public int IntentLock(string[] targetTables)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // �R�l�N�V����������擾
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);
                if (connectionText == null || connectionText == "") return status;

                // �R�l�N�V�����N���X�C���X�^���X
                this._sqlConnection = new SqlConnection(connectionText);
                // �R�l�N�V�����I�[�v��
                this._sqlConnection.Open();
                // �g�����U�N�V�����J�n
                this._sqlTransaction = this._sqlConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                // SQL�R�}���h�N���X�C���X�^���X
                SqlCommand sqlCommand = new SqlCommand();
                // �R�l�N�V�����A�g�����U�N�V�������v���p�e�B�ɃZ�b�g
                sqlCommand.Connection  = this._sqlConnection;
                sqlCommand.Transaction = this._sqlTransaction;
                foreach( string item in targetTables )
                {
                    // �C���e���g�r�����b�N��������
                    sqlCommand.CommandText = "SELECT * FROM " + item + " WITH(UPDLOCK,HOLDLOCK) WHERE 1 = 0 ";
                    //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                    sqlCommand.CommandTimeout = 600;
                    //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                    // �R�}���h���s
                    sqlCommand.ExecuteNonQuery();
                    // �m�[�}���X�e�[�^�X���Z�b�g
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch( SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex , "IntentExclusiveLockComponent.IntentLock",status);
                FinalProc();
            }
            catch( Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex , "IntentExclusiveLockComponent.IntentLock",status);
                FinalProc();
            }
            finally
            {
            }

            return status;
        }

        #endregion

        #region UnLock

        /// <summary>
        /// ���b�N����
        /// </summary>
        /// <returns>status</returns>
        public int UnLock()
        {
            FinalProc();
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        #endregion

        #region FinalProc

        /// <summary>
        /// �I������
        /// </summary>
        private void FinalProc()
        {
            if (this._sqlConnection != null)
            {
                if (this._sqlTransaction != null)
                {
                    this._sqlTransaction.Rollback();
                    this._sqlTransaction.Dispose();
                }
                this._sqlConnection.Close();
                this._sqlConnection.Dispose();
                this._sqlConnection = null;
            }
        }

        #endregion
    }
}
