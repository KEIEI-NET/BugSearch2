//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�U�[���i�E�����ꊇ�ݒ�
// �v���O�����T�v   : ���[�U�[���i�E�����ꊇ�ݒ�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
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
    /// ���[�U�[���i�E�����ꊇ�ݒ胊���[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�U�[���i�E�����ꊇ�ݒ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class UserPriceDB : RemoteDB, IUserPriceDB
    {
        #region ��private member
        /// <summary>
        /// ���i�����[�g
        /// </summary>
        private GoodsPriceUDB _goodsPriceUDB = new GoodsPriceUDB();
        private RateDB _rateDB = new RateDB();
        #endregion

        #region ��write
        /// <summary>
        /// ���i�ݒ�
        /// </summary>
        /// <param name="rateList">�|���}�X�^</param>
        /// <param name="goodsPriceUList">���i�}�X�^</param>
        /// <param name="rateDelList">�|���}�X�^�폜���X�g</param>
        /// <param name="goodsPriceUDelList">���i�}�X�^�폜���X�g</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.05</br>
        /// </remarks>
        public int Write(object rateList, object goodsPriceUList, object rateDelList, object goodsPriceUDelList, ref string msg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraRateList = rateList as ArrayList;
                ArrayList paraGoodsPriceUList = goodsPriceUList as ArrayList;
                ArrayList paraDelList = rateDelList as ArrayList;
                ArrayList paraGoodsPriceUDelList = goodsPriceUDelList as ArrayList;
                if (paraRateList == null) return status;
                if (paraGoodsPriceUList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                ArrayList writeErrorList;
                // �|���}�X�^
                // �����폜����
                if (paraDelList != null && paraDelList.Count != 0)
                {
                    status = _rateDB.DeleteSubSectionProc(paraDelList, ref sqlConnection, ref sqlTransaction);
                }
                // ����o�^����
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (paraRateList != null && paraRateList.Count != 0)
                    {
                        status = _rateDB.WriteSubSectionProc(ref paraRateList, ref sqlConnection, ref sqlTransaction);
                    }
                }
                // ���i�}�X�^
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (paraGoodsPriceUDelList != null && paraGoodsPriceUDelList.Count != 0)
                    {
                        status = _goodsPriceUDB.DeleteGoodsPriceProc(paraGoodsPriceUDelList, ref sqlConnection, ref sqlTransaction);
                    }
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (paraGoodsPriceUList != null && paraGoodsPriceUList.Count != 0)
                    {
                        status = _goodsPriceUDB.WriteGoodsPriceProc(ref paraGoodsPriceUList, out writeErrorList, ref sqlConnection, ref sqlTransaction);
                    }
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
                base.WriteErrorLog(e, "UserPriceDB.Write(ref object GoodsPriceUWork)");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "UserPriceDB.Write(ref object GoodsPriceUWork)");
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
        /// <br>Programmer : ���m</br>
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
