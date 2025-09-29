//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^�N���A����
// �v���O�����T�v   : �f�[�^�N���A����DB�����[�g�I�u�W�F�N�g
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/06/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �f�[�^�N���A����DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �f�[�^�N���A�����̎��s�������s���N���X�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.06.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Date       : </br>
    /// <br>           : </br>
    /// </remarks>
    [Serializable]
    public class DataClearDB : RemoteDB, IDataClearDB
    {
        /// <summary>
        /// �f�[�^�N���A����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        public DataClearDB()
            :
            base("PMKHN01006D", "Broadleaf.Application.Remoting.ParamData.DataClearWork", "")
        {
        }

        #region [Clear]
        /// <summary>
        /// �f�[�^�N���A�������s��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="delYM">�폜�N��</param>
        /// <param name="delYMD">�폜�N���J�n��</param>
        /// <param name="dataClearList">�f�[�^�N���A���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.16</br>
        public int Clear(string enterpriseCode, Int32 delYM, Int32 delYMD, ref object dataClearList, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            errMsg = string.Empty;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return ClearProc(enterpriseCode, delYM, delYMD, ref dataClearList, ref sqlConnection, out errMsg);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.Clear");
                errMsg = ex.Message;
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
        #endregion

        #region [ClearProc]
        /// <summary>
        /// �w�肳�ꂽ�����̃f�[�^�N���A�����f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="delYM">�폜�N��</param>
        /// <param name="delYMD">�폜�N���J�n��</param>
        /// <param name="dataClearList">�f�[�^�N���A���X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃f�[�^�N���A�����f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearProc(string enterpriseCode, Int32 delYM, Int32 delYMD, ref object dataClearList, ref SqlConnection sqlConnection, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMsg = string.Empty;

            try
            {
                // �[���敪�̎擾
                Int32 fractionProcCd = GetFractionProcCd(enterpriseCode, ref sqlConnection);

                ArrayList list = dataClearList as ArrayList;
                for (int i = 0; i < list.Count; i++)
                {
                    int subStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    DataClearWork work = (DataClearWork)list[i];

                    // �I�����ꂽ�Ώۂ̂�
                    if (work.IsChecked)
                    {
                        // �����R�[�h�ɂ��A�N���A�������s��
                        switch (work.ClearCode)
                        {
                            case 0: // �����R�[�h��0�F�������N���A
                                subStatus = ClearDataByCode0(enterpriseCode, work.TableId, ref sqlConnection);
                                break;
                            case 1: // �����R�[�h��1�F�N���w��N���A�P�i�N���j
                                subStatus = ClearDataByCode1(enterpriseCode, work.TableId, work.FileId, delYM, ref sqlConnection);
                                break;
                            case 2: // �����R�[�h��2�F�N���w��N���A�Q�i�N�����j
                                subStatus = ClearDataByCode2(enterpriseCode, work.TableId, work.FileId, delYMD, ref sqlConnection);
                                break;
                            case 3: // �����R�[�h��3�F�݌ɗ����N���A
                                subStatus = ClearDataByCode3(enterpriseCode, work.TableId, delYM, delYMD, fractionProcCd, ref sqlConnection);
                                break;
                            case 4: // �����R�[�h��4�F�ԍ��Ǘ��ݒ�N���A
                                subStatus = ClearDataByCode4(enterpriseCode, work.TableId, ref sqlConnection);
                                break;
                        }

                        // �������ʂ̐ݒ�
                        if (subStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            work.Result = "OK";
                        }
                        else
                        {
                            work.Result = "NG";
                        }
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearProc");
                errMsg = ex.Message;
            }

            return status;
        }
        #endregion

        #region �����R�[�h��0�F�������N���A
        /// <summary>
        /// �����R�[�h��0�F�������N���A�̏���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��0�F�������N���A�̏���(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode0(string enterpriseCode, string tableId, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �g�����U�N�V�����J�n
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // �N���A����
                status = ClearDataByCode0Proc(enterpriseCode, tableId, ref sqlConnection, ref sqlTransaction);
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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode0");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }

        /// <summary>
        /// �����R�[�h��0�F�������N���A�̏���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��0�F�������N���A�̏���(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode0Proc(string enterpriseCode, string tableId, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            StringBuilder sql = new StringBuilder();
            try
            {               
                sql.Append("DELETE FROM ");
                sql.Append(tableId);
                sql.Append(" WHERE ENTERPRISECODERF = @FINDENTERPRISECODE");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // ���R�[�h�폜����Timeout�̐ݒ�
                // ADD 2009/07/13 PVCS342
                sqlCommand.CommandTimeout = 3600;

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode0Proc");
            }

            return status;
        }
        #endregion �����R�[�h��0�F�������N���A

        #region �����R�[�h��1�F�N���w��N���A�P�i�N���j
        /// <summary>
        /// �����R�[�h��1�F�N���w��N���A�P�i�N���j�̏���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="fileId">�t�B�[���hID</param>
        /// <param name="delYM">�폜�N��</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��1�F�N���w��N���A�P�i�N���j�̏���(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode1(string enterpriseCode, string tableId, string fileId, Int32 delYM, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �g�����U�N�V�����J�n
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // �N���A����
                status = ClearDataByCode1Proc(enterpriseCode, tableId, fileId, delYM, ref sqlConnection, ref sqlTransaction);
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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode1");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }

        /// <summary>
        /// �����R�[�h��1�F�N���w��N���A�P�i�N���j�̏���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="fileId">�t�B�[���hID</param>
        /// <param name="delYM">�폜�N��</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��1�F�N���w��N���A�P�i�N���j�̏���(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode1Proc(string enterpriseCode, string tableId, string fileId, Int32 delYM, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("DELETE FROM ");
                sql.Append(tableId);
                sql.Append(" WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND ");
                sql.Append(fileId);
                sql.Append(" >= @FINDADDUPYEARMONTH");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
                findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(delYM);

                // ���R�[�h�폜����Timeout�̐ݒ�
                // ADD 2009/07/13 PVCS342
                sqlCommand.CommandTimeout = 3600;

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode1Proc");
            }

            return status;
        }
        #endregion �����R�[�h��1�F�N���w��N���A�P�i�N���j

        #region �����R�[�h��2�F�N���w��N���A�Q�i�N�����j
        /// <summary>
        /// �����R�[�h��2�F�N���w��N���A�Q�i�N�����j�̏���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="fileId">�t�B�[���hID</param>
        /// <param name="delYMD">�폜�N���J�n��</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��2�F�N���w��N���A�Q�i�N�����j�̏���(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode2(string enterpriseCode, string tableId, string fileId, Int32 delYMD, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �g�����U�N�V�����J�n
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // �N���A����
                status = ClearDataByCode2Proc(enterpriseCode, tableId, fileId, delYMD, ref sqlConnection, ref sqlTransaction);
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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode2");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }

        /// <summary>
        /// �����R�[�h��2�F�N���w��N���A�Q�i�N�����j�̏���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="fileId">�t�B�[���hID</param>
        /// <param name="delYMD">�폜�N���J�n��</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��2�F�N���w��N���A�Q�i�N�����j�̏���(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode2Proc(string enterpriseCode, string tableId, string fileId, Int32 delYMD, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("DELETE FROM ");
                sql.Append(tableId);
                sql.Append(" WHERE ENTERPRISECODERF = @FINDENTERPRISECODE AND ");
                sql.Append(fileId);
                sql.Append(" >= @FINDADDUPDATE");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
                findParaAddUpDate.Value = SqlDataMediator.SqlSetInt32(delYMD);

                // ���R�[�h�폜����Timeout�̐ݒ�
                // ADD 2009/07/13 PVCS342
                sqlCommand.CommandTimeout = 3600;

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode2Proc");
            }

            return status;
        }
        #endregion �����R�[�h��2�F�N���w��N���A�Q�i�N�����j

        #region �����R�[�h��3�F�݌ɗ����N���A
        /// <summary>
        /// �����R�[�h��3�F�݌ɗ����N���A�̏���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="delYM">�폜�N��</param>
        /// <param name="delYMD">�폜�N���J�n��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��3�F�݌ɗ����N���A�̏���(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode3(string enterpriseCode, string tableId, Int32 delYM, Int32 delYMD, Int32 fractionProcCd, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                // �N���A����
                status = ClearDataByCode3Proc(enterpriseCode, tableId, delYM, delYMD, fractionProcCd, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode3");
            }

            return status;
        }

        /// <summary>
        /// �����R�[�h��3�F�݌ɗ����N���A�̏���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="delYM">�폜�N��</param>
        /// <param name="delYMD">�폜�N���J�n��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��3�F�݌ɗ����N���A�̏���(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode3Proc(string enterpriseCode, string tableId, Int32 delYM, Int32 delYMD, Int32 fractionProcCd, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            StringBuilder sql = new StringBuilder();
            List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();
            SqlTransaction sqlTransaction = null;
            try
            {
                // �g�����U�N�V�����J�n
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // �݌ɗ����f�[�^�̃N���A�폜����
                status = ClearStockHistory(enterpriseCode, tableId, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                    return status;
                }

                // �݌Ƀ}�X�^���R�[�h�̌�������
                status = SearchData(enterpriseCode, delYM, delYMD, fractionProcCd, out stockHistoryWorkList, ref sqlConnection, ref sqlTransaction);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // �g�����U�N�V�����J�n
                sqlTransaction = CreateTransaction(ref sqlConnection);
                // �݌ɗ����f�[�^�̐V�K����
                status = WriteStockHistory(ref stockHistoryWorkList, ref sqlConnection, ref sqlTransaction);
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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode3Proc");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }

        /// <summary>
        /// �݌ɗ����f�[�^�̃N���A�폜����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɗ����f�[�^�̃N���A�폜����</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearStockHistory(string enterpriseCode, string tableId, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("DELETE FROM ");
                sql.Append(tableId);
                sql.Append(" WHERE ENTERPRISECODERF = @FINDENTERPRISECODE");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // ���R�[�h�폜����Timeout�̐ݒ�
                // ADD 2009/07/13 PVCS342
                sqlCommand.CommandTimeout = 3600;

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearStockHistory");
            }

            return status;
        }

        /// <summary>
        /// �݌Ƀ}�X�^�̌�������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="delYM">�폜�N��</param>
        /// <param name="delYMD">�폜�N���J�n��</param>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <param name="stockHistoryWorkList">�݌ɗ����f�[�^���X�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀ}�X�^�̌����������s���܂�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int SearchData(string enterpriseCode, Int32 delYM, Int32 delYMD, Int32 fractionProcCd, out List<StockHistoryWork> stockHistoryWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            SqlDataReader myReader = null;
            StringBuilder sql = new StringBuilder();
            stockHistoryWorkList = new List<StockHistoryWork>();
            List<GoodsSupplierDataWork> goodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();
            List<UnitPriceCalcParamWork> UnitPriceCalcParamWorkList = new List<UnitPriceCalcParamWork>();
            List<GoodsUnitDataWork> GoodsUnitDataWorkList = new List<GoodsUnitDataWork>();
            try
            {
                // �폜�N���̑O��
                DateTime addUpYearMonth = new DateTime(delYM / 100, delYM % 100, 1).AddMonths(-1);

                // �폜�N���J�n���̂P������
                DateTime priceApplyDate = new DateTime(delYMD / 10000, (delYMD % 10000) / 100, delYMD % 100).AddMonths(1);

                sql.Append("SELECT ");
                sql.Append("    A.WAREHOUSECODERF, ");
                sql.Append("    B.WAREHOUSENAMERF, ");
                sql.Append("    A.SECTIONCODERF, ");
                sql.Append("    A.GOODSNORF, ");
                sql.Append("    D.GOODSNAMERF, ");
                sql.Append("    A.GOODSMAKERCDRF, ");
                sql.Append("    C.MAKERNAMERF, ");
                sql.Append("    A.SHIPMENTPOSCNTRF, ");
                sql.Append("    A.SHIPMENTPOSCNTRF + A.SHIPMENTCNTRF - A.ARRIVALCNTRF PROPERTYSTOCKCNTRF, ");
                sql.Append("    D.BLGOODSCODERF, ");
                sql.Append("    E.BLGROUPCODERF, ");
                sql.Append("    F.GOODSMGROUPRF ");
                sql.Append("FROM ");
                sql.Append("    STOCKRF A ");
                sql.Append("    LEFT JOIN WAREHOUSERF B ");
                sql.Append("    ON A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sql.Append("    AND A.WAREHOUSECODERF = B.WAREHOUSECODERF ");
                sql.Append("    LEFT JOIN MAKERURF C ");
                sql.Append("    ON A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sql.Append("    AND A.GOODSMAKERCDRF = C.GOODSMAKERCDRF ");
                sql.Append("    LEFT JOIN GOODSURF D ");
                sql.Append("    ON A.ENTERPRISECODERF = D.ENTERPRISECODERF ");
                sql.Append("    AND A.GOODSMAKERCDRF = D.GOODSMAKERCDRF ");
                sql.Append("    AND A.GOODSNORF = D.GOODSNORF ");
                sql.Append("    LEFT JOIN BLGOODSCDURF E ");
                sql.Append("    ON D.ENTERPRISECODERF = E.ENTERPRISECODERF ");
                sql.Append("    AND D.BLGOODSCODERF = E.BLGOODSCODERF ");
                sql.Append("    LEFT JOIN BLGROUPURF F ");
                sql.Append("    ON E.ENTERPRISECODERF = F.ENTERPRISECODERF ");
                sql.Append("    AND E.BLGROUPCODERF = F.BLGROUPCODERF ");
                sql.Append("WHERE ");
                sql.Append("    A.ENTERPRISECODERF = @FINDENTERPRISECODE ");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // �݌ɗ����f�[�^���X�g�쐬
                    StockHistoryWork stockHistoryWork = new StockHistoryWork();
                    stockHistoryWork.EnterpriseCode = enterpriseCode;
                    stockHistoryWork.AddUpYearMonth = addUpYearMonth;
                    stockHistoryWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockHistoryWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockHistoryWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    stockHistoryWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockHistoryWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockHistoryWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockHistoryWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockHistoryWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    stockHistoryWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    stockHistoryWork.PropertyStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PROPERTYSTOCKCNTRF"));
                    stockHistoryWorkList.Add(stockHistoryWork);

                    // ���i�d���擾�p�����[�^���X�g����
                    GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                    goodsSupplierDataWork.EnterpriseCode = enterpriseCode;
                    goodsSupplierDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    goodsSupplierDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    goodsSupplierDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsSupplierDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    goodsSupplierDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    goodsSupplierDataWorkList.Add(goodsSupplierDataWork);

                    // �P���Z�o�p�����[�^���X�g����
                    UnitPriceCalcParamWork unitPriceCalcParamWork = new UnitPriceCalcParamWork();
                    unitPriceCalcParamWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    unitPriceCalcParamWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    unitPriceCalcParamWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    unitPriceCalcParamWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    unitPriceCalcParamWork.GoodsRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    unitPriceCalcParamWork.PriceApplyDate = priceApplyDate;
                    UnitPriceCalcParamWorkList.Add(unitPriceCalcParamWork);

                    // ���i�A����񃊃X�g����
                    GoodsUnitDataWork goodsUnitDataWork = new GoodsUnitDataWork();
                    goodsUnitDataWork.EnterpriseCode = enterpriseCode;
                    goodsUnitDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    goodsUnitDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    GoodsUnitDataWorkList.Add(goodsUnitDataWork);
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }

                // ���i�d����̎擾
                // �i�d����擾���i�̌Ăяo��
                GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
                goodsSupplierGetter.GetGoodsMngInfo(ref goodsSupplierDataWorkList);

                // �P���Z�o�p�����[�^�̍X�V
                foreach (GoodsSupplierDataWork goodsSupplierDataWork in goodsSupplierDataWorkList)
                {
                    foreach (UnitPriceCalcParamWork unitPriceCalcParamWork in UnitPriceCalcParamWorkList)
                    {
                        if (goodsSupplierDataWork.GoodsMakerCd == unitPriceCalcParamWork.GoodsMakerCd
                            && goodsSupplierDataWork.GoodsNo == unitPriceCalcParamWork.GoodsNo
                            && goodsSupplierDataWork.BLGoodsCode == unitPriceCalcParamWork.BLGoodsCode)
                        {
                            unitPriceCalcParamWork.SupplierCd = goodsSupplierDataWork.SupplierCd;
                        }
                    }
                }

                // �d���P���̎擾
                // �P���Z�o���W���[���̌Ăяo��
                UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
                List<UnitPriceCalcRetWork> unitPriceCalcRetWorkList = new List<UnitPriceCalcRetWork>();
                unitPriceCalculation.CalculateUnitCost(UnitPriceCalcParamWorkList, GoodsUnitDataWorkList, out unitPriceCalcRetWorkList);

                // �d���P���̃Z�b�g
                foreach (UnitPriceCalcRetWork unitPriceCalcRetWork in unitPriceCalcRetWorkList) 
                {
                    foreach (StockHistoryWork stockHistoryWork in stockHistoryWorkList)
                    {
                        if (stockHistoryWork.GoodsMakerCd == unitPriceCalcRetWork.GoodsMakerCd
                            && stockHistoryWork.GoodsNo == unitPriceCalcRetWork.GoodsNo)
                        {
                            // �d���P���i�Ŕ��C�����j
                            stockHistoryWork.StockUnitPriceFl = unitPriceCalcRetWork.UnitPriceTaxExcFl;
                        }
                    }
                }

                // ���z�̐ݒ�
                double fractionUnit = 1.00d;
                Int64 resultMoney;
                foreach (StockHistoryWork stockHistoryWork in stockHistoryWorkList)
                {
                    // �݌ɑ����ɑ΂�����z
                    double stockMashinePrice = stockHistoryWork.StockUnitPriceFl * stockHistoryWork.StockTotal;
                    FractionCalculate.FracCalcMoney(stockMashinePrice, fractionUnit, fractionProcCd, out resultMoney);
                    stockHistoryWork.StockMashinePrice = resultMoney;
                    stockHistoryWork.AdjustPrice = resultMoney;

                    // ���Ѝ݌ɐ��ɑ΂�����z
                    double propertyStockPrice = stockHistoryWork.StockUnitPriceFl * stockHistoryWork.PropertyStockCnt;
                    FractionCalculate.FracCalcMoney(propertyStockPrice, fractionUnit, fractionProcCd, out resultMoney);
                    stockHistoryWork.PropertyStockPrice = resultMoney;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearStockHistory");
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// �݌ɗ����f�[�^���X�V���܂�
        /// </summary>
        /// <param name="stockHistoryWorkList">�݌ɗ����f�[�^List</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="sqlTransaction">sql�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌ɗ����f�[�^���X�V���܂�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        private int WriteStockHistory(ref List<StockHistoryWork> stockHistoryWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            StringBuilder sql = new StringBuilder();

            try
            {
                for (int i = 0; i < stockHistoryWorkList.Count; i++)
                {
                    StockHistoryWork stockHistoryWork = stockHistoryWorkList[i] as StockHistoryWork;

                    #region [Insert���쐬]
                    sql = new StringBuilder();
                    sql.Append("INSERT INTO STOCKHISTORYRF").Append(Environment.NewLine);
                    sql.Append(" (").Append(Environment.NewLine);
                    sql.Append("     CREATEDATETIMERF").Append(Environment.NewLine);
                    sql.Append("    ,UPDATEDATETIMERF").Append(Environment.NewLine);
                    sql.Append("    ,ENTERPRISECODERF").Append(Environment.NewLine);
                    sql.Append("    ,FILEHEADERGUIDRF").Append(Environment.NewLine);
                    sql.Append("    ,UPDEMPLOYEECODERF").Append(Environment.NewLine);
                    sql.Append("    ,UPDASSEMBLYID1RF").Append(Environment.NewLine);
                    sql.Append("    ,UPDASSEMBLYID2RF").Append(Environment.NewLine);
                    sql.Append("    ,LOGICALDELETECODERF").Append(Environment.NewLine);
                    sql.Append("    ,ADDUPYEARMONTHRF").Append(Environment.NewLine);
                    sql.Append("    ,WAREHOUSECODERF").Append(Environment.NewLine);
                    sql.Append("    ,WAREHOUSENAMERF").Append(Environment.NewLine);
                    sql.Append("    ,SECTIONCODERF").Append(Environment.NewLine);
                    sql.Append("    ,GOODSNORF").Append(Environment.NewLine);
                    sql.Append("    ,GOODSNAMERF").Append(Environment.NewLine);
                    sql.Append("    ,GOODSMAKERCDRF").Append(Environment.NewLine);
                    sql.Append("    ,MAKERNAMERF").Append(Environment.NewLine);
                    sql.Append("    ,LMONTHSTOCKCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,LMONTHSTOCKPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,LMONTHPPTYSTOCKCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,LMONTHPPTYSTOCKPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,SALESTIMESRF").Append(Environment.NewLine);
                    sql.Append("    ,SALESCOUNTRF").Append(Environment.NewLine);
                    sql.Append("    ,SALESMONEYTAXEXCRF").Append(Environment.NewLine);
                    sql.Append("    ,SALESRETGOODSTIMESRF").Append(Environment.NewLine);
                    sql.Append("    ,SALESRETGOODSCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,SALESRETGOODSPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,GROSSPROFITRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKTIMESRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKCOUNTRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKPRICETAXEXCRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKRETGOODSTIMESRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKRETGOODSCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKRETGOODSPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,MOVEARRIVALCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,MOVEARRIVALPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,MOVESHIPMENTCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,MOVESHIPMENTPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,ADJUSTCOUNTRF").Append(Environment.NewLine);
                    sql.Append("    ,ADJUSTPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,ARRIVALCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,ARRIVALPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,SHIPMENTCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,SHIPMENTPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,TOTALARRIVALCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,TOTALARRIVALPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,TOTALSHIPMENTCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,TOTALSHIPMENTPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKUNITPRICEFLRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKTOTALRF").Append(Environment.NewLine);
                    sql.Append("    ,STOCKMASHINEPRICERF").Append(Environment.NewLine);
                    sql.Append("    ,PROPERTYSTOCKCNTRF").Append(Environment.NewLine);
                    sql.Append("    ,PROPERTYSTOCKPRICERF").Append(Environment.NewLine);
                    sql.Append(" )").Append(Environment.NewLine);
                    sql.Append(" VALUES").Append(Environment.NewLine);
                    sql.Append(" (").Append(Environment.NewLine);
                    sql.Append("     @CREATEDATETIME").Append(Environment.NewLine);
                    sql.Append("    ,@UPDATEDATETIME").Append(Environment.NewLine);
                    sql.Append("    ,@ENTERPRISECODE").Append(Environment.NewLine);
                    sql.Append("    ,@FILEHEADERGUID").Append(Environment.NewLine);
                    sql.Append("    ,@UPDEMPLOYEECODE").Append(Environment.NewLine);
                    sql.Append("    ,@UPDASSEMBLYID1").Append(Environment.NewLine);
                    sql.Append("    ,@UPDASSEMBLYID2").Append(Environment.NewLine);
                    sql.Append("    ,@LOGICALDELETECODE").Append(Environment.NewLine);
                    sql.Append("    ,@ADDUPYEARMONTH").Append(Environment.NewLine);
                    sql.Append("    ,@WAREHOUSECODE").Append(Environment.NewLine);
                    sql.Append("    ,@WAREHOUSENAME").Append(Environment.NewLine);
                    sql.Append("    ,@SECTIONCODE").Append(Environment.NewLine);
                    sql.Append("    ,@GOODSNO").Append(Environment.NewLine);
                    sql.Append("    ,@GOODSNAME").Append(Environment.NewLine);
                    sql.Append("    ,@GOODSMAKERCD").Append(Environment.NewLine);
                    sql.Append("    ,@MAKERNAME").Append(Environment.NewLine);
                    sql.Append("    ,@LMONTHSTOCKCNT").Append(Environment.NewLine);
                    sql.Append("    ,@LMONTHSTOCKPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@LMONTHPPTYSTOCKCNT").Append(Environment.NewLine);
                    sql.Append("    ,@LMONTHPPTYSTOCKPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@SALESTIMES").Append(Environment.NewLine);
                    sql.Append("    ,@SALESCOUNT").Append(Environment.NewLine);
                    sql.Append("    ,@SALESMONEYTAXEXC").Append(Environment.NewLine);
                    sql.Append("    ,@SALESRETGOODSTIMES").Append(Environment.NewLine);
                    sql.Append("    ,@SALESRETGOODSCNT").Append(Environment.NewLine);
                    sql.Append("    ,@SALESRETGOODSPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@GROSSPROFIT").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKTIMES").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKCOUNT").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKPRICETAXEXC").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKRETGOODSTIMES").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKRETGOODSCNT").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKRETGOODSPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@MOVEARRIVALCNT").Append(Environment.NewLine);
                    sql.Append("    ,@MOVEARRIVALPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@MOVESHIPMENTCNT").Append(Environment.NewLine);
                    sql.Append("    ,@MOVESHIPMENTPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@ADJUSTCOUNT").Append(Environment.NewLine);
                    sql.Append("    ,@ADJUSTPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@ARRIVALCNT").Append(Environment.NewLine);
                    sql.Append("    ,@ARRIVALPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@SHIPMENTCNT").Append(Environment.NewLine);
                    sql.Append("    ,@SHIPMENTPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@TOTALARRIVALCNT").Append(Environment.NewLine);
                    sql.Append("    ,@TOTALARRIVALPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@TOTALSHIPMENTCNT").Append(Environment.NewLine);
                    sql.Append("    ,@TOTALSHIPMENTPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKUNITPRICEFL").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKTOTAL").Append(Environment.NewLine);
                    sql.Append("    ,@STOCKMASHINEPRICE").Append(Environment.NewLine);
                    sql.Append("    ,@PROPERTYSTOCKCNT").Append(Environment.NewLine);
                    sql.Append("    ,@PROPERTYSTOCKPRICE").Append(Environment.NewLine);
                    sql.Append(" )").Append(Environment.NewLine);
                    #endregion  //[Insert���쐬]

                    using (SqlCommand sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction))
                    {
                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)stockHistoryWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameter�I�u�W�F�N�g�쐬
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                        SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                        SqlParameter paraWarehouseName = sqlCommand.Parameters.Add("@WAREHOUSENAME", SqlDbType.NVarChar);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraGoodsName = sqlCommand.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraMakerName = sqlCommand.Parameters.Add("@MAKERNAME", SqlDbType.NVarChar);
                        SqlParameter paraLMonthStockCnt = sqlCommand.Parameters.Add("@LMONTHSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraLMonthStockPrice = sqlCommand.Parameters.Add("@LMONTHSTOCKPRICE", SqlDbType.BigInt);
                        SqlParameter paraLMonthPptyStockCnt = sqlCommand.Parameters.Add("@LMONTHPPTYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraLMonthPptyStockPrice = sqlCommand.Parameters.Add("@LMONTHPPTYSTOCKPRICE", SqlDbType.BigInt);
                        SqlParameter paraSalesTimes = sqlCommand.Parameters.Add("@SALESTIMES", SqlDbType.Int);
                        SqlParameter paraSalesCount = sqlCommand.Parameters.Add("@SALESCOUNT", SqlDbType.Float);
                        SqlParameter paraSalesMoneyTaxExc = sqlCommand.Parameters.Add("@SALESMONEYTAXEXC", SqlDbType.BigInt);
                        SqlParameter paraSalesRetGoodsTimes = sqlCommand.Parameters.Add("@SALESRETGOODSTIMES", SqlDbType.Int);
                        SqlParameter paraSalesRetGoodsCnt = sqlCommand.Parameters.Add("@SALESRETGOODSCNT", SqlDbType.Float);
                        SqlParameter paraSalesRetGoodsPrice = sqlCommand.Parameters.Add("@SALESRETGOODSPRICE", SqlDbType.BigInt);
                        SqlParameter paraGrossProfit = sqlCommand.Parameters.Add("@GROSSPROFIT", SqlDbType.BigInt);
                        SqlParameter paraStockTimes = sqlCommand.Parameters.Add("@STOCKTIMES", SqlDbType.Int);
                        SqlParameter paraStockCount = sqlCommand.Parameters.Add("@STOCKCOUNT", SqlDbType.Float);
                        SqlParameter paraStockPriceTaxExc = sqlCommand.Parameters.Add("@STOCKPRICETAXEXC", SqlDbType.BigInt);
                        SqlParameter paraStockRetGoodsTimes = sqlCommand.Parameters.Add("@STOCKRETGOODSTIMES", SqlDbType.Int);
                        SqlParameter paraStockRetGoodsCnt = sqlCommand.Parameters.Add("@STOCKRETGOODSCNT", SqlDbType.Float);
                        SqlParameter paraStockRetGoodsPrice = sqlCommand.Parameters.Add("@STOCKRETGOODSPRICE", SqlDbType.BigInt);
                        SqlParameter paraMoveArrivalCnt = sqlCommand.Parameters.Add("@MOVEARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraMoveArrivalPrice = sqlCommand.Parameters.Add("@MOVEARRIVALPRICE", SqlDbType.BigInt);
                        SqlParameter paraMoveShipmentCnt = sqlCommand.Parameters.Add("@MOVESHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraMoveShipmentPrice = sqlCommand.Parameters.Add("@MOVESHIPMENTPRICE", SqlDbType.BigInt);
                        SqlParameter paraAdjustCount = sqlCommand.Parameters.Add("@ADJUSTCOUNT", SqlDbType.Float);
                        SqlParameter paraAdjustPrice = sqlCommand.Parameters.Add("@ADJUSTPRICE", SqlDbType.BigInt);
                        SqlParameter paraArrivalCnt = sqlCommand.Parameters.Add("@ARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraArrivalPrice = sqlCommand.Parameters.Add("@ARRIVALPRICE", SqlDbType.BigInt);
                        SqlParameter paraShipmentCnt = sqlCommand.Parameters.Add("@SHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraShipmentPrice = sqlCommand.Parameters.Add("@SHIPMENTPRICE", SqlDbType.BigInt);
                        SqlParameter paraTotalArrivalCnt = sqlCommand.Parameters.Add("@TOTALARRIVALCNT", SqlDbType.Float);
                        SqlParameter paraTotalArrivalPrice = sqlCommand.Parameters.Add("@TOTALARRIVALPRICE", SqlDbType.BigInt);
                        SqlParameter paraTotalShipmentCnt = sqlCommand.Parameters.Add("@TOTALSHIPMENTCNT", SqlDbType.Float);
                        SqlParameter paraTotalShipmentPrice = sqlCommand.Parameters.Add("@TOTALSHIPMENTPRICE", SqlDbType.BigInt);
                        SqlParameter paraStockUnitPriceFl = sqlCommand.Parameters.Add("@STOCKUNITPRICEFL", SqlDbType.Float);
                        SqlParameter paraStockTotal = sqlCommand.Parameters.Add("@STOCKTOTAL", SqlDbType.Float);
                        SqlParameter paraStockMashinePrice = sqlCommand.Parameters.Add("@STOCKMASHINEPRICE", SqlDbType.BigInt);
                        SqlParameter paraPropertyStockCnt = sqlCommand.Parameters.Add("@PROPERTYSTOCKCNT", SqlDbType.Float);
                        SqlParameter paraPropertyStockPrice = sqlCommand.Parameters.Add("@PROPERTYSTOCKPRICE", SqlDbType.BigInt);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�ݒ�
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockHistoryWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockHistoryWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(stockHistoryWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.LogicalDeleteCode);
                        paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(stockHistoryWork.AddUpYearMonth);
                        paraWarehouseCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.WarehouseCode);
                        paraWarehouseName.Value = SqlDataMediator.SqlSetString(stockHistoryWork.WarehouseName);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.SectionCode);
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(stockHistoryWork.GoodsNo);
                        paraGoodsName.Value = SqlDataMediator.SqlSetString(stockHistoryWork.GoodsName);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.GoodsMakerCd);
                        paraMakerName.Value = SqlDataMediator.SqlSetString(stockHistoryWork.MakerName);
                        paraLMonthStockCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.LMonthStockCnt);
                        paraLMonthStockPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.LMonthStockPrice);
                        paraLMonthPptyStockCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.LMonthPptyStockCnt);
                        paraLMonthPptyStockPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.LMonthPptyStockPrice);
                        paraSalesTimes.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.SalesTimes);
                        paraSalesCount.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.SalesCount);
                        paraSalesMoneyTaxExc.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.SalesMoneyTaxExc);
                        paraSalesRetGoodsTimes.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.SalesRetGoodsTimes);
                        paraSalesRetGoodsCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.SalesRetGoodsCnt);
                        paraSalesRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.SalesRetGoodsPrice);
                        paraGrossProfit.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.GrossProfit);
                        paraStockTimes.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.StockTimes);
                        paraStockCount.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.StockCount);
                        paraStockPriceTaxExc.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.StockPriceTaxExc);
                        paraStockRetGoodsTimes.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.StockRetGoodsTimes);
                        paraStockRetGoodsCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.StockRetGoodsCnt);
                        paraStockRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.StockRetGoodsPrice);
                        paraMoveArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.MoveArrivalCnt);
                        paraMoveArrivalPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.MoveArrivalPrice);
                        paraMoveShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.MoveShipmentCnt);
                        paraMoveShipmentPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.MoveShipmentPrice);
                        paraAdjustCount.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.AdjustCount);
                        paraAdjustPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.AdjustPrice);
                        paraArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.ArrivalCnt);
                        paraArrivalPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.ArrivalPrice);
                        paraShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.ShipmentCnt);
                        paraShipmentPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.ShipmentPrice);
                        paraTotalArrivalCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.TotalArrivalCnt);
                        paraTotalArrivalPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.TotalArrivalPrice);
                        paraTotalShipmentCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.TotalShipmentCnt);
                        paraTotalShipmentPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.TotalShipmentPrice);
                        paraStockUnitPriceFl.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.StockUnitPriceFl);
                        paraStockTotal.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.StockTotal);
                        paraStockMashinePrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.StockMashinePrice);
                        paraPropertyStockCnt.Value = SqlDataMediator.SqlSetDouble(stockHistoryWork.PropertyStockCnt);
                        paraPropertyStockPrice.Value = SqlDataMediator.SqlSetInt64(stockHistoryWork.PropertyStockPrice);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                base.WriteErrorLog(ex, "DataClearDB.WriteStockHistory");
            }

            return status;
        }
        #endregion �����R�[�h��3�F�݌ɗ����N���A

        #region �����R�[�h��4�F�ԍ��Ǘ��ݒ�N���A
        /// <summary>
        /// �����R�[�h��4�F�ԍ��Ǘ��ݒ�N���A�̏���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��4�F�ԍ��Ǘ��ݒ�N���A�̏���(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode4(string enterpriseCode, string tableId, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlTransaction sqlTransaction = null;
            try
            {
                // �g�����U�N�V�����J�n
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // �N���A����
                status = ClearDataByCode4Proc(enterpriseCode, tableId, ref sqlConnection, ref sqlTransaction);
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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode4");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
            }

            return status;
        }

        /// <summary>
        /// �����R�[�h��4�F�ԍ��Ǘ��ݒ�N���A�̏���(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��4�F�ԍ��Ǘ��ݒ�N���A�̏���(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode4Proc(string enterpriseCode, string tableId, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("UPDATE ");
                sql.Append(tableId);
                sql.Append(" SET NOPRESENTVALRF = 0,").Append(Environment.NewLine);
                sql.Append(" UPDATEDATETIMERF = @UPDATEDATETIME,").Append(Environment.NewLine);
                sql.Append(" UPDEMPLOYEECODERF = @UPDEMPLOYEECODE,").Append(Environment.NewLine);
                sql.Append(" UPDASSEMBLYID1RF = @UPDASSEMBLYID1,").Append(Environment.NewLine);
                sql.Append(" UPDASSEMBLYID2RF = @UPDASSEMBLYID2,").Append(Environment.NewLine);
                sql.Append(" LOGICALDELETECODERF = @LOGICALDELETECODE").Append(Environment.NewLine);
                sql.Append(" WHERE ENTERPRISECODERF = @ENTERPRISECODE");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //�o�^�w�b�_����ݒ�
                StockHistoryWork stockHistoryWork = new StockHistoryWork();
                object obj = (object)this;
                IFileHeader flhd = (IFileHeader)stockHistoryWork;
                FileHeader fileHeader = new FileHeader(obj);
                fileHeader.SetUpdateHeader(ref flhd, obj);
                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);

                paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(stockHistoryWork.UpdateDateTime);
                paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdEmployeeCode);
                paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdAssemblyId1);
                paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(stockHistoryWork.UpdAssemblyId2);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(stockHistoryWork.LogicalDeleteCode);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode4Proc");
            }

            return status;
        }
        #endregion �����R�[�h��4�F�ԍ��Ǘ��ݒ�N���A

        #region �����R�[�h��9�F���i���������f�[�^�N���A�i�񋟃f�[�^�폜�����p�j
        /// <summary>
        /// �����R�[�h��9�F���i���������f�[�^�N���A�i�񋟃f�[�^�폜�����p�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��9�F���i���������f�[�^�N���A�̏����i�񋟃f�[�^�폜�����p�j</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        public int ClearDataByCode9(string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = CreateTransaction(ref sqlConnection);

                // �N���A����
                status = ClearDataByCode9Proc(enterpriseCode, ref sqlConnection, ref sqlTransaction);
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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode9");
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
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

        /// <summary>
        /// �����R�[�h��9�F���i���������f�[�^�N���A�̏����i�񋟃f�[�^�폜�����p�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��9�F���i���������f�[�^�N���A�̏����i�񋟃f�[�^�폜�����p�j</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private int ClearDataByCode9Proc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("DELETE FROM PRIUPDHISRF ");
                sql.Append("WHERE ENTERPRISECODERF = @FINDENTERPRISECODE ");
                sql.Append("AND OFFERVERSIONRF IS NOT NULL ");
                sql.Append("AND LEN(OFFERVERSIONRF) > 0 ");

                sqlCommand = new SqlCommand(sql.ToString(), sqlConnection, sqlTransaction);

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                // ���R�[�h�폜����Timeout�̐ݒ�
                // ADD 2009/07/13 PVCS342
                sqlCommand.CommandTimeout = 3600;

                sqlCommand.ExecuteNonQuery();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DataClearDB.ClearDataByCode9Proc");
            }

            return status;
        }
        #endregion �����R�[�h��9�F���i���������f�[�^�N���A�i�񋟃f�[�^�폜�����p�j

        #region �[�������敪�̎擾����
        /// <summary>
        /// �[�������敪�̎擾����(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>�[�������敪</returns>
        /// <br>Note       : �[�������敪�̎擾�����i���_�R�[�h��"00"�̃��R�[�h���擾����j</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        private Int32 GetFractionProcCd(string enterpriseCode, ref SqlConnection sqlConnection)
        {
            Int32 fractionProcess = 0;
            StockMngTtlStDB stockMngTtlStDB = new StockMngTtlStDB();
            StockMngTtlStWork paraStockMngTtlStWork = new StockMngTtlStWork();
            paraStockMngTtlStWork.EnterpriseCode = enterpriseCode;
            paraStockMngTtlStWork.SectionCode = "00";
            Object objStockMngTtlStWorkList = new object();
            Object objParaStockMngTtlStWork = paraStockMngTtlStWork as object;

            // ��������
            stockMngTtlStDB.SearchStockMngTtlStProc(out objStockMngTtlStWorkList, objParaStockMngTtlStWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);
            ArrayList stockMngTtlStWorkList = objStockMngTtlStWorkList as ArrayList;
            if (stockMngTtlStWorkList.Count > 0)
            {
                fractionProcess = ((StockMngTtlStWork)stockMngTtlStWorkList[0]).FractionProcCd;
            }

            return fractionProcess;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
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
        #endregion  //�R�l�N�V������������

        #region [�g�����U�N�V�����쐬����]
        /// <summary>
        /// �g�����U�N�V�����쐬����
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        /// </remarks>
        private SqlTransaction CreateTransaction(ref SqlConnection sqlConnection)
        {
            // �g�����U�N�V�����J�n
#if DEBUG
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif
            return sqlTransaction;
        }
        #endregion //�g�����U�N�V�����쐬����
    }

}
