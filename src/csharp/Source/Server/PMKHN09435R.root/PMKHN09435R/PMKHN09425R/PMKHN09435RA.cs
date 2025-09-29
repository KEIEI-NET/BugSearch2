//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����ꊇ�ݒ�
// �v���O�����T�v   : �����ꊇ�ݒ�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/05/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using Microsoft.Win32;
using System.IO;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����ꊇ�ݒ胊���[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����ꊇ�ݒ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SaleRateDB : RemoteDB, ISaleRateDB
    {
        /// <summary>
        /// �����ꊇ�ݒ�DB�����[�g�I�u�W�F�N�g
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.3.316</br>
        /// </remarks>
        public SaleRateDB()
            :
        base("DCKHN09166D", "Broadleaf.Application.Remoting.ParamData.RateWork", "RATERF")
        {
        }

        #region ��private member
        /// <summary>
        /// �|�������[�g
        /// </summary>
        private RateDB _rateDB = new RateDB();
        #endregion

        #region ��write
        /// <summary>
        /// ���i�ݒ�
        /// </summary>
        /// <param name="delparaObj">�|���}�X�^</param>
        /// <param name="updparaObj">���i�}�X�^</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public int Save(object delparaObj, object updparaObj ,ref string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList delRateList = delparaObj as ArrayList;
                ArrayList updRateList = updparaObj as ArrayList;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // �|���}�X�^
                // �����폜����
                if (delRateList.Count > 0)
                {
                    status = _rateDB.DeleteSubSectionProc(delRateList, ref sqlConnection, ref sqlTransaction);
                }

                // ����o�^����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && updRateList.Count > 0)
                {
                    status = _rateDB.WriteSubSectionProc(ref updRateList, ref sqlConnection, ref sqlTransaction);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (SqlException e)
            {
                base.WriteErrorLog(e, "SaleRateDB.Save(object delparaObj,object updparaObj)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SaleRateDB.Save(object delparaObj,object updparaObj)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region ��[�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
            if (connectionText == null || connectionText == "") return null;

            retSqlConnection = new SqlConnection(connectionText);

            return retSqlConnection;
        }
        #endregion
    }
}
