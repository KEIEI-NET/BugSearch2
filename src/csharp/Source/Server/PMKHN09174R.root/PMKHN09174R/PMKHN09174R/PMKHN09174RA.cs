//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���Ӑ�(�|���O���[�v)�}�X�^DB�����[�g�I�u�W�F�N�g
//                  :   PMKHN09174R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   23012 ���� �[���N
// Date             :   2008.10.07
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
// �Ǘ��ԍ�  11770032-00 �쐬�S�� : 30809 ���X�� �j
// �C �� ��  2021/03/25  �C�����e : �R�`���i��Q�Ή��i��s�z�M�j
//                                  �@�I�u�W�F�N�g�Q�ƃG���[�Ή�
//                                    �E���׌y���̂���READUNCOMMITTED�ǉ�
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�(�|���O���[�v)�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�(�|���O���[�v)�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.10.07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CustRateGroupDB : RemoteWithAppLockDB, ICustRateGroupDB
    {
        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        public CustRateGroupDB(): base("PMKHN09176D", "Broadleaf.Application.Remoting.ParamData.CustRateGroupWork", "CustRateGroupRF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P��̓��Ӑ�(�|���O���[�v)�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="custRateGroupObj">CustRateGroupWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�(�|���O���[�v)�}�X�^�̃L�[�l����v���链�Ӑ�(�|���O���[�v)�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        public int Read(ref object custRateGroupObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                CustRateGroupWork custRateGroupWork = custRateGroupObj as CustRateGroupWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref custRateGroupWork, readMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �P��̓��Ӑ�(�|���O���[�v)�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="custRateGroupWork">CustRateGroupWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�(�|���O���[�v)�}�X�^�̃L�[�l����v���链�Ӑ�(�|���O���[�v)�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        public int Read(ref CustRateGroupWork custRateGroupWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref custRateGroupWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P��̓��Ӑ�(�|���O���[�v)�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="custRateGroupWork">CustRateGroupWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�(�|���O���[�v)�}�X�^�̃L�[�l����v���链�Ӑ�(�|���O���[�v)�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        private int ReadProc(ref CustRateGroupWork custRateGroupWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += " SELECT  CUSTGR.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.PURECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.CUSTRATEGRPCODERF" + Environment.NewLine;
                sqlText += "        ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                sqlText += " FROM CUSTRATEGROUPRF AS CUSTGR" + Environment.NewLine;
                sqlText += "LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTGR.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND CUST.CUSTOMERCODERF=CUSTGR.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "  CUSTGR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND CUSTGR.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                sqlText += "  AND CUSTGR.PURECODERF = @FINDPURECODE " + Environment.NewLine;
                sqlText += "  AND CUSTGR.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                SqlParameter findParaPureCode = sqlCommand.Parameters.Add("@FINDPURECODE", SqlDbType.Int);
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custRateGroupWork.EnterpriseCode);
                findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.CustomerCode);
                findParaPureCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.PureCode);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.GoodsMakerCd);


#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToCustRateGroupWorkFromReader(ref myReader, ref custRateGroupWork);
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            return status;
        }
        # endregion

        # region [Delete]
        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="custRateGroupList">�����폜���链�Ӑ�(�|���O���[�v)�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�(�|���O���[�v)�}�X�^�̃L�[�l����v���链�Ӑ�(�|���O���[�v)�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        public int Delete(object custRateGroupList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //// �p�����[�^�̃L���X�g
                //ArrayList paraList = custRateGroupList as ArrayList;
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(custRateGroupList);
                if (paraList == null) return status;


                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.Delete(paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return status;
        }

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�(�|���O���[�v)�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custRateGroupList �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        public int Delete(ArrayList custRateGroupList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(custRateGroupList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�(�|���O���[�v)�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : custRateGroupList �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        private int DeleteProc(ArrayList custRateGroupList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (custRateGroupList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < custRateGroupList.Count; i++)
                    {
                        CustRateGroupWork custRateGroupWork = custRateGroupList[i] as CustRateGroupWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CUSTGR.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTRATEGROUPRF AS CUSTGR" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CUSTGR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTGR.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTGR.PURECODERF = @FINDPURECODE " + Environment.NewLine;
                        sqlText += "  AND CUSTGR.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        sqlCommand.Parameters.Clear();

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaPureCode = sqlCommand.Parameters.Add("@FINDPURECODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custRateGroupWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.CustomerCode);
                        findParaPureCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.PureCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.GoodsMakerCd);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != custRateGroupWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  CUSTRATEGROUPRF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND PURECODERF = @FINDPURECODE " + Environment.NewLine;
                            sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custRateGroupWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.CustomerCode);
                            findParaPureCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.PureCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.GoodsMakerCd);

                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        sqlCommand.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            return status;
        }
        # endregion

        # region [Search]
        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="custRateGroupList">��������</param>
        /// <param name="custRateGroupObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�(�|���O���[�v)�}�X�^�̃L�[�l����v����A�S�Ă̓��Ӑ�(�|���O���[�v)�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        public int Search(ref object custRateGroupList, object custRateGroupObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList custRateGroupArray = custRateGroupList as ArrayList;
                
                if (custRateGroupArray == null)
                {
                    custRateGroupArray = new ArrayList();
                }
                
                CustRateGroupWork custRateGroupWork = custRateGroupObj as CustRateGroupWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref custRateGroupArray, custRateGroupWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
                custRateGroupList = custRateGroupArray;
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�(�|���O���[�v)�}�X�^�����i�[���� ArrayList</param>
        /// <param name="custRateGroupWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�(�|���O���[�v)�}�X�^�̃L�[�l����v����A�S�Ă̓��Ӑ�(�|���O���[�v)�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        public int Search(ref ArrayList custRateGroupList, CustRateGroupWork custRateGroupWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref custRateGroupList, custRateGroupWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�(�|���O���[�v)�}�X�^�����i�[���� ArrayList</param>
        /// <param name="custRateGroupWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�(�|���O���[�v)�}�X�^�̃L�[�l����v����A�S�Ă̓��Ӑ�(�|���O���[�v)�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        /// <br>Update Note: 11770032-00 �R�`���i��Q�Ή��i��s�Ή��j �I�u�W�F�N�g�Q�ƃG���[�Ή��i���׌y���̂���READUNCOMMITTED�ǉ��j</br>
        /// <br>Programmer : 30809 ���X�� �j</br>
        /// <br>Date       : 2021/03/25</br>
        private int SearchProc(ref ArrayList custRateGroupList, CustRateGroupWork custRateGroupWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += " SELECT  CUSTGR.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.CUSTOMERCODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.PURECODERF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "        ,CUSTGR.CUSTRATEGRPCODERF" + Environment.NewLine;
                sqlText += "        ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
                //---UPD�@30809 ���X�؁@�j�@2021/03/25 11770032-00�@�I�u�W�F�N�g�Q�ƃG���[�Ή� ------>>>>>
                //sqlText += " FROM CUSTRATEGROUPRF AS CUSTGR" + Environment.NewLine;
                //sqlText += " LEFT JOIN CUSTOMERRF CUST ON CUST.ENTERPRISECODERF=CUSTGR.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " FROM CUSTRATEGROUPRF AS CUSTGR WITH(READUNCOMMITTED) " + Environment.NewLine;
                sqlText += " LEFT JOIN CUSTOMERRF AS CUST WITH(READUNCOMMITTED) ON CUST.ENTERPRISECODERF=CUSTGR.ENTERPRISECODERF " + Environment.NewLine;
                //---UPD�@30809 ���X�؁@�j�@2021/03/25 11770032-00�@�I�u�W�F�N�g�Q�ƃG���[�Ή� ------<<<<<
                sqlText += "    AND CUST.CUSTOMERCODERF=CUSTGR.CUSTOMERCODERF" + Environment.NewLine;
                # endregion

                #region WHERE�吶��

                sqlText += "WHERE" + Environment.NewLine;

                // ��ƃR�[�h
                sqlText += "  CUSTGR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findEnterpriseCode.Value = SqlDataMediator.SqlSetString(custRateGroupWork.EnterpriseCode);

                // ���ӃR�[�h
                if (custRateGroupWork.CustomerCode == 0)
                {
                    sqlText += "  AND CUSTGR.CUSTOMERCODERF = CUSTGR.CUSTOMERCODERF" + Environment.NewLine;
                }
                else
                {
                    sqlText += "  AND CUSTGR.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                    SqlParameter findCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(custRateGroupWork.CustomerCode);
                }

                // �_���폜�敪
                string wkstring = "";
                if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                    (logicalMode == ConstantManagement.LogicalMode.GetData3))
                {
                    wkstring = "  AND CUSTGR.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
                }
                else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                         (logicalMode == ConstantManagement.LogicalMode.GetData012))
                {
                    wkstring = "  AND CUSTGR.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
                }

                if (wkstring != "")
                {
                    sqlText += wkstring;
                    SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
                }

                #endregion
                sqlCommand.CommandText = sqlText;

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    custRateGroupList.Add(this.CopyToCustRateGroupWorkFromReader(ref myReader));
                }

                if (custRateGroupList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            return status;
        }
        # endregion

        # region [Write]
        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pustRateGroupList">�ǉ��E�X�V���链�Ӑ�(�|���O���[�v)�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupList �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        public int Write(ref object pustRateGroupList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pustRateGroupList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                // write���s
                status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pustRateGroupList">�ǉ��E�X�V���链�Ӑ�(�|���O���[�v)�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupList �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        public int Write(ref ArrayList pustRateGroupList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref pustRateGroupList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pustRateGroupList">�ǉ��E�X�V���链�Ӑ�(�|���O���[�v)�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupList �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        private int WriteProc(ref ArrayList pustRateGroupList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pustRateGroupList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < pustRateGroupList.Count; i++)
                    {
                        CustRateGroupWork pustRateGroupWork = pustRateGroupList[i] as CustRateGroupWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CUSTGR.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTRATEGROUPRF AS CUSTGR" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CUSTGR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTGR.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTGR.PURECODERF = @FINDPURECODE " + Environment.NewLine;
                        sqlText += "  AND CUSTGR.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaPureCode = sqlCommand.Parameters.Add("@FINDPURECODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.CustomerCode);
                        findParaPureCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.PureCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.GoodsMakerCd);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != pustRateGroupWork.UpdateDateTime)
                            {
                                if (pustRateGroupWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    // �V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    // �����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += " UPDATE " + Environment.NewLine;
                            sqlText += "   CUSTRATEGROUPRF " + Environment.NewLine;
                            sqlText += " SET " + Environment.NewLine;
                            sqlText += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " , CUSTOMERCODERF=@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += " , PURECODERF=@PURECODE" + Environment.NewLine;
                            sqlText += " , GOODSMAKERCDRF=@GOODSMAKERCD" + Environment.NewLine;
                            sqlText += " , CUSTRATEGRPCODERF=@CUSTRATEGRPCODE" + Environment.NewLine;
                            sqlText += " WHERE " + Environment.NewLine;
                            sqlText += "   ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "   AND CUSTOMERCODERF=@FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "   AND PURECODERF = @FINDPURECODE " + Environment.NewLine;
                            sqlText += "   AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.CustomerCode);
                            findParaPureCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.PureCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.GoodsMakerCd);


                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pustRateGroupWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (pustRateGroupWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO CUSTRATEGROUPRF" + Environment.NewLine;
                            sqlText += " (" + Environment.NewLine;
                            sqlText += "    CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,CUSTOMERCODERF" + Environment.NewLine;
                            sqlText += "    ,PURECODERF" + Environment.NewLine;
                            sqlText += "    ,GOODSMAKERCDRF" + Environment.NewLine;
                            sqlText += "    ,CUSTRATEGRPCODERF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (" + Environment.NewLine;
                            sqlText += "     @CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,@CUSTOMERCODE" + Environment.NewLine;
                            sqlText += "    ,@PURECODE" + Environment.NewLine;
                            sqlText += "    ,@GOODSMAKERCD" + Environment.NewLine;
                            sqlText += "    ,@CUSTRATEGRPCODE" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pustRateGroupWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                        SqlParameter paraPureCode = sqlCommand.Parameters.Add("@PURECODE", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                        SqlParameter paraCustRateGrpCode = sqlCommand.Parameters.Add("@CUSTRATEGRPCODE", SqlDbType.Int);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pustRateGroupWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pustRateGroupWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(pustRateGroupWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.LogicalDeleteCode);
                        paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.CustomerCode);
                        paraPureCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.PureCode);
                        paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.GoodsMakerCd);
                        paraCustRateGrpCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.CustRateGrpCode);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pustRateGroupWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            pustRateGroupList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="pustRateGroupList">�_���폜���链�Ӑ�(�|���O���[�v)�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupWork �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        public int LogicalDelete(ref object pustRateGroupList)
        {
            return this.LogicalDelete(ref pustRateGroupList, 0);
        }

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="pustRateGroupList">�_���폜���������链�Ӑ�(�|���O���[�v)�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupWork �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        public int RevivalLogicalDelete(ref object pustRateGroupList)
        {
            return this.LogicalDelete(ref pustRateGroupList, 1);
        }

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="pustRateGroupList">�_���폜�𑀍삷�链�Ӑ�(�|���O���[�v)�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupWork �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        private int LogicalDelete(ref object pustRateGroupList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = pustRateGroupList as ArrayList;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                status = this.LogicalDelete(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            // ���[���o�b�N
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="pustRateGroupList">�_���폜�𑀍삷�链�Ӑ�(�|���O���[�v)�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupWork �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        public int LogicalDelete(ref ArrayList pustRateGroupList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref pustRateGroupList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���Ӑ�(�|���O���[�v)�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="pustRateGroupList">�_���폜�𑀍삷�链�Ӑ�(�|���O���[�v)�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pustRateGroupWork �Ɋi�[����Ă��链�Ӑ�(�|���O���[�v)�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        private int LogicalDeleteProc(ref ArrayList pustRateGroupList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (pustRateGroupList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < pustRateGroupList.Count; i++)
                    {
                        CustRateGroupWork pustRateGroupWork = pustRateGroupList[i] as CustRateGroupWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  CUSTGR.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,CUSTGR.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  CUSTRATEGROUPRF AS CUSTGR" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  CUSTGR.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTGR.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND CUSTGR.PURECODERF = @FINDPURECODE " + Environment.NewLine;
                        sqlText += "  AND CUSTGR.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        SqlParameter findParaPureCode = sqlCommand.Parameters.Add("@FINDPURECODE", SqlDbType.Int);
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.EnterpriseCode);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.CustomerCode);
                        findParaPureCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.PureCode);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.GoodsMakerCd);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != pustRateGroupWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }
                            
                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  CUSTRATEGROUPRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                            sqlText += "  AND PURECODERF = @FINDPURECODE " + Environment.NewLine;
                            sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.EnterpriseCode);
                            findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.CustomerCode);
                            findParaPureCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.PureCode);
                            findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.GoodsMakerCd);


                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)pustRateGroupWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            return status;
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        // �_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;       // ���ɍ폜�ς݂̏ꍇ����
                                return status;
                            }
                            else if (logicalDelCd == 0) pustRateGroupWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else pustRateGroupWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                pustRateGroupWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // ���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  // ���S�폜�̓f�[�^�Ȃ���߂�
                                }

                                return status;
                            }
                        }

                        // Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(pustRateGroupWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(pustRateGroupWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(pustRateGroupWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(pustRateGroupWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
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

            pustRateGroupList = al;

            return status;
        }
        # endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 23012�@���� �[���N</br>
        /// <br>Date       : 2008.10.01</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            CustRateGroupWork[] CustRateGroupWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is CustRateGroupWork)
                    {
                        CustRateGroupWork wkCustRateGroupWork = paraobj as CustRateGroupWork;
                        if (wkCustRateGroupWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkCustRateGroupWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            CustRateGroupWorkArray = (CustRateGroupWork[])XmlByteSerializer.Deserialize(byteArray, typeof(CustRateGroupWork[]));
                        }
                        catch (Exception) { }
                        if (CustRateGroupWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(CustRateGroupWorkArray);
                        }
                        else
                        {
                            try
                            {
                                CustRateGroupWork wkCustRateGroupWork = (CustRateGroupWork)XmlByteSerializer.Deserialize(byteArray, typeof(CustRateGroupWork));
                                if (wkCustRateGroupWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkCustRateGroupWork);
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                }
                catch (Exception)
                {
                    //���ɉ������Ȃ�
                }

            return retal;
        }
        #endregion


        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� CustRateGroupWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>CustRateGroupWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        private CustRateGroupWork CopyToCustRateGroupWorkFromReader(ref SqlDataReader myReader)
        {
            CustRateGroupWork pustRateGroupWork = new CustRateGroupWork();

            this.CopyToCustRateGroupWorkFromReader(ref myReader, ref pustRateGroupWork);

            return pustRateGroupWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� CustRateGroupWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="pustRateGroupWork">CustRateGroupWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.07</br>
        /// </remarks>
        private void CopyToCustRateGroupWorkFromReader(ref SqlDataReader myReader, ref CustRateGroupWork pustRateGroupWork)
        {
            if (myReader != null && pustRateGroupWork != null)
            {
                # region �N���X�֊i�[
                pustRateGroupWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                pustRateGroupWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                pustRateGroupWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                pustRateGroupWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                pustRateGroupWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                pustRateGroupWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                pustRateGroupWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                pustRateGroupWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                pustRateGroupWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                pustRateGroupWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                pustRateGroupWork.PureCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PURECODERF"));
                pustRateGroupWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                pustRateGroupWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                # endregion
            }
        }
        # endregion
    }
}
