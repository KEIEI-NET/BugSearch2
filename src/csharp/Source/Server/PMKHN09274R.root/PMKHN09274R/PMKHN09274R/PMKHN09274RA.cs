//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ꊇ���A���X�V
// �v���O�����T�v   : �ꊇ���A���X�VDB�����[�g�I�u�W�F�N�g�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/12/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ꊇ���A���X�VREADDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ꊇ���A���X�VREAD�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    [Serializable]
    public class AllRealUpdToolDB : RemoteWithAppLockDB, IAllRealUpdToolDB
    {
        # region �� Constructor ��
        /// <summary>
        /// �ꊇ���A���X�V����READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ꊇ���A���X�V����READ�̎��f�[�^������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        public AllRealUpdToolDB()
        {
            this._monthlyTtlSalesUpdDB = new MonthlyTtlSalesUpdDB();
            this._monthlyTtlStockUpdDB = new MonthlyTtlStockUpdDB();
        }
        #endregion

        # region �� Private Members ��
        // ���㌎���W�v�f�[�^�X�VDB�����[�g�I�u�W�F�N�g
        MonthlyTtlSalesUpdDB _monthlyTtlSalesUpdDB = null;
        // �d�������W�v�f�[�^�X�V�����[�g�I�u�W�F�N�g
        MonthlyTtlStockUpdDB _monthlyTtlStockUpdDB = null;
        #endregion

        #region �� �ꊇ���A���X�V���� ��
        /// <summary>
        /// �ꊇ���A���X�V����
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">���㌎���W�v�����[�g�p�̃p�����[�^�N���X</param>
        /// <param name="mTtlStockUpdParaWork">�d�������W�v�����[�g�p�̃p�����[�^�N���X</param>
        /// <param name="procDiv">�����敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :  �ꊇ���A���X�V�������s���N���X�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.12.24</br>
        /// </remarks>
        public int AllRealUpdProc(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, MTtlStockUpdParaWork mTtlStockUpdParaWork, int procDiv)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int statusBak = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            //--------------------------
            // �f�[�^�x�[�X�I�[�v��
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ShareCheckInfo info = new ShareCheckInfo();

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();
                //���g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                #region �r������
                //�V�X�e�����b�N(���)
                info.Keys.Add(mTtlSalesUpdParaWork.EnterpriseCode, ShareCheckType.Enterprise, "", "");
                status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

                if (status != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT;
                    return status;
                }
                #endregion

                // �����敪�͔���̏ꍇ�A
                if (procDiv == 0)
                {
                    // ���㌎���W�v�f�[�^�X�V����
                    status = _monthlyTtlSalesUpdDB.ReCountProc(mTtlSalesUpdParaWork, ref sqlConnection, ref sqlTransaction);
                }
                // �����敪�͎d���̏ꍇ�A
                else if (procDiv == 1)
                {
                    // �d�������W�v�f�[�^�X�V����
                    status = _monthlyTtlStockUpdDB.ReCountProc(mTtlStockUpdParaWork, ref sqlConnection, ref sqlTransaction);
                }
                // �����敪�͔���A�d���̏ꍇ�A
                else if (procDiv == 2)
                {
                    // ���㌎���W�v�f�[�^�X�V����
                    status = _monthlyTtlSalesUpdDB.ReCountProc(mTtlSalesUpdParaWork, ref sqlConnection, ref sqlTransaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                        || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            statusBak = (int)ConstantManagement.DB_Status.ctDB_EOF;
                        }
                        // �d�������W�v�f�[�^�X�V����
                        status = _monthlyTtlStockUpdDB.ReCountProc(mTtlStockUpdParaWork, ref sqlConnection, ref sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                                || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_EOF && statusBak == (int)ConstantManagement.DB_Status.ctDB_EOF)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                        }
                    }
                }
                else
                {
                    // �����敪�s��
                }

            }
            catch (Exception ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "AllRealUpdToolDB.AllRealUpdProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        //�V�X�e�����b�N����
                        int st = this.ShareCheck(info, LockControl.Release, sqlConnection, sqlTransaction);

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            status = st;
                        }

                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }
                }

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
    }
}
