//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���ώ�`��������
// �v���O�����T�v   : ���ώ�`��������DB�����[�g�I�u�W�F�N�g�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���`
// �� �� ��  2010/04/22  �C�����e : �V�K�쐬
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
    /// ���ώ�`�������������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ώ�`���������̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���`</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    [Serializable]
    public class SettlementBillDelDB : RemoteWithAppLockDB, ISettlementBillDelDB
    {
        # region �� Constructor ��
        /// <summary>
        /// ���ώ�`������������READDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ώ�`������������READ�̎��f�[�^������s���N���X�ł��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>
        public SettlementBillDelDB()
        {
        }
        #endregion


        #region �� ���ώ�`������������ ��
        /// <summary>
        /// ���ώ�`��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="processDate">������</param>
        /// <param name="prevTotalMonth">�O���������</param>
        /// <param name="billDiv">��`�敪0:����`;1:�x����`</param>
        /// <param name="pieceDelete">�폜����</param>
        /// <param name="totalpiece">���o����</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: ���ώ�`�����������s���B</br>
        /// <br>Programmer	: ���`</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        public int SettlementBillDelProc(string enterpriseCode, int processDate, int prevTotalMonth, int billDiv, out int pieceDelete, out int totalpiece)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pieceDelete = 0;
            totalpiece = 0;
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
                info.Keys.Add(enterpriseCode, ShareCheckType.Enterprise, "", "");
                status = this.ShareCheck(info, LockControl.Locke, sqlConnection, sqlTransaction);

                if (status != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT;
                    return status;
                }
                #endregion
                //��`�敪0:����`
                if (billDiv == 0)
                {
                    status = SearchRcvDraftDataPieces(enterpriseCode, out totalpiece, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    //��`�敪1:�x����`
                    status = SearchPayDraftDataPieces(enterpriseCode, out totalpiece, ref sqlConnection, ref sqlTransaction);
                }
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //��`�敪0:����`
                    if (billDiv == 0)
                    {
                        status = DeleteRcvDraftData(enterpriseCode, processDate, prevTotalMonth, out pieceDelete, ref sqlConnection, ref sqlTransaction);
                    }
                    else
                    {
                        //��`�敪1:�x����`
                        status = DeletePayDraftData(enterpriseCode, processDate, prevTotalMonth, out pieceDelete, ref sqlConnection, ref sqlTransaction);
                    }
                }
            }
            catch (Exception ex)
            {
                // ���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "InspectDateUpdDB.InspectDateUpdProc Exception=" + ex.Message);
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


        /// <summary>
        /// �w�肳�ꂽ�����̎���`�f�[�^����߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="totalPieces">����</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>  
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̎���`�f�[�^����߂��܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>        
        private int SearchRcvDraftDataPieces(string enterpriseCode, out int totalPieces, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //�ϐ��̐錾
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            totalPieces = 0;

            //�ϐ��̏�����
            ArrayList dataList = new ArrayList();

            if (sqlConnection == null)
            {
                return status;
            }

            if (sqlTransaction == null)
            {
                return status;
            }

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, RCVDRAFTNORF FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                //�p�����[�^��ݒ肷��
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);


                //�ǂݍ���
                myReader = sqlCommand.ExecuteReader();
                //�ǂݍ��߂��ꍇ
                while (myReader.Read())
                {
                    totalPieces++;
                    //�߂�l��ݒ肷��
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SettlementBillDelDB.SearchRcvDraftData");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎x����`�f�[�^����߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="totalPieces">����</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>  
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̎x����`�f�[�^����߂��܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>        
        private int SearchPayDraftDataPieces(string enterpriseCode, out int totalPieces, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //�ϐ��̐錾
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            totalPieces = 0;

            //�ϐ��̏�����
            ArrayList dataList = new ArrayList();

            if (sqlConnection == null)
            {
                return status;
            }

            if (sqlTransaction == null)
            {
                return status;
            }

            SqlCommand sqlCommand = new SqlCommand();
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                sqlCommand = new SqlCommand("SELECT CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, PAYDRAFTNORF FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE", sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);

                //�p�����[�^��ݒ肷��
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);


                //�ǂݍ���
                myReader = sqlCommand.ExecuteReader();
                //�ǂݍ��߂��ꍇ
                while (myReader.Read())
                {
                    totalPieces++;
                    //�߂�l��ݒ肷��
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SettlementBillDelDB.SearchPayDraftData");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }


        /// <summary>
        /// �w�肳�ꂽ�����̎���`�f�[�^���폜���܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="processDate">������</param>
        /// <param name="prevTotalMonth">�O���������</param>
        /// <param name="pieceDelete">�폜����</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>  
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̎���`�f�[�^���폜���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>        
        private int DeleteRcvDraftData(string enterpriseCode, int processDate, int prevTotalMonth, out int pieceDelete, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //�ϐ��̐錾
            int status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;

            pieceDelete = 0;

            if (sqlConnection == null)
            {
                return status;
            }

            if (sqlTransaction == null)
            {
                return status;
            }

            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                //Delete�R�}���h�̐���
                sqlCommand = new SqlCommand("DELETE FROM RCVDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND DRAFTKINDCDRF!=@FINDDRAFTKINDCD AND VALIDITYTERMRF<=@FINDVALIDITYTERM AND DEPOSITDATERF<=@FINDDEPOSITDATE", sqlConnection, sqlTransaction);
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findParaDraftKindCd = sqlCommand.Parameters.Add("@FINDDRAFTKINDCD", SqlDbType.Int);
                SqlParameter findParaValidityTerm = sqlCommand.Parameters.Add("@FINDVALIDITYTERM", SqlDbType.Int);
                SqlParameter findParaDepositDate = sqlCommand.Parameters.Add("@FINDDEPOSITDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findParaDraftKindCd.Value = SqlDataMediator.SqlSetInt32(5);
                findParaValidityTerm.Value = SqlDataMediator.SqlSetInt32(processDate);
                findParaDepositDate.Value = SqlDataMediator.SqlSetInt32(prevTotalMonth);

                pieceDelete = sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SettlementBillDelDB.DeleteRcvDraftData");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̎x����`�f�[�^���폜���܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="processDate">������</param>
        /// <param name="prevTotalMonth">�O���������</param>
        /// <param name="pieceDelete">�폜����</param>
        /// <param name="sqlConnection">�c�a�ڑ��I�u�W�F�N�g</param>  
        /// <param name="sqlTransaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̎x����`�f�[�^���폜���܂��B</br>
        /// <br>Programmer : ���`</br>
        /// <br>Date       : 2010/04/22</br>
        /// </remarks>        
        private int DeletePayDraftData(string enterpriseCode, int processDate, int prevTotalMonth, out int pieceDelete, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            //�ϐ��̐錾
            int status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;

            pieceDelete = 0;

            if (sqlConnection == null)
            {
                return status;
            }

            if (sqlTransaction == null)
            {
                return status;
            }

            SqlCommand sqlCommand = new SqlCommand();

            try
            {
                //Delete�R�}���h�̐���
                sqlCommand = new SqlCommand("DELETE FROM PAYDRAFTDATARF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE AND DRAFTKINDCDRF!=@FINDDRAFTKINDCD AND VALIDITYTERMRF<=@FINDVALIDITYTERM AND PAYMENTDATERF<=@FINDPAYMENTDATE", sqlConnection, sqlTransaction);
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findParaDraftKindCd = sqlCommand.Parameters.Add("@FINDDRAFTKINDCD", SqlDbType.Int);
                SqlParameter findParaValidityTerm = sqlCommand.Parameters.Add("@FINDVALIDITYTERM", SqlDbType.Int);
                SqlParameter findParaPaymentDate = sqlCommand.Parameters.Add("@FINDPAYMENTDATE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findParaDraftKindCd.Value = SqlDataMediator.SqlSetInt32(5);
                findParaValidityTerm.Value = SqlDataMediator.SqlSetInt32(processDate);
                findParaPaymentDate.Value = SqlDataMediator.SqlSetInt32(prevTotalMonth);

                pieceDelete = sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SettlementBillDelDB.DeletePayDraftData");
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
            }

            return status;
        }
        #endregion
    }
}
