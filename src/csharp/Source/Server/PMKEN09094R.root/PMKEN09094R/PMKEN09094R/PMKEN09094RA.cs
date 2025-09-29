//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���i��փ}�X�^DB�����[�g�I�u�W�F�N�g
//                  :   PMKEN09094R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008�@���� ���n
// Date             :   2008.06.10
//----------------------------------------------------------------------
// Update Note      :
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
    /// ���i��փ}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i��փ}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PartsSubstUDB : RemoteWithAppLockDB, IPartsSubstUDB
    {
        /// <summary>
        /// ���i��փ}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        public PartsSubstUDB() : base("PMKEN09096D", "Broadleaf.Application.Remoting.ParamData.PartsSubstUWork", "PARTSSUBSTURF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P��̕��i��փ}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="partsSubstUObj">PartsSubstUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i��փ}�X�^�̃L�[�l����v���镔�i��փ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        public int Read(ref object partsSubstUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                PartsSubstUWork partsSubstUWork = partsSubstUObj as PartsSubstUWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref partsSubstUWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// �P��̕��i��փ}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="partsSubstUWork">PartsSubstUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i��փ}�X�^�̃L�[�l����v���镔�i��փ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        public int Read(ref PartsSubstUWork partsSubstUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref partsSubstUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P��̕��i��փ}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="partsSubstUWork">PartsSubstUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i��փ}�X�^�̃L�[�l����v���镔�i��փ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        private int ReadProc(ref PartsSubstUWork partsSubstUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   PRT.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,PRT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,PRT.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,PRT.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGSRCMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGSRCGOODSNORF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGSRCGOODSNONONEHPRF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGDESTGOODSNORF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGDESTGOODSNONONEHPRF" + Environment.NewLine;
                sqlText += "  ,PRT.APPLYSTADATERF" + Environment.NewLine;
                sqlText += "  ,PRT.APPLYENDDATERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS CHGSRCGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS CHGDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS CHGSRCMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS CHGDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM PARTSSUBSTURF AS PRT" + Environment.NewLine;

                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGSRCGOODSNORF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND PRT.CHGSRCMAKERCDRF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGDESTGOODSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND PRT.CHGDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGSRCMAKERCDRF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;

                sqlText += " WHERE PRT.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND PRT.CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD" + Environment.NewLine;
                sqlText += "  AND PRT.CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
                SqlParameter findParaChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);


                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);


#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToPartsSubstUWorkFromReader(ref myReader, ref partsSubstUWork);
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
        /// ���i��փ}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="partsSubstUList">�����폜���镔�i��փ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i��փ}�X�^�̃L�[�l����v���镔�i��փ}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        public int Delete(object partsSubstUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = partsSubstUList as ArrayList;

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
        /// ���i��փ}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="partsSubstUList">���i��փ}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUList �Ɋi�[����Ă��镔�i��փ}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        public int Delete(ArrayList partsSubstUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(partsSubstUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i��փ}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="partsSubstUList">���i��փ}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUList �Ɋi�[����Ă��镔�i��փ}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        private int DeleteProc(ArrayList partsSubstUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (partsSubstUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < partsSubstUList.Count; i++)
                    {
                        PartsSubstUWork partsSubstUWork = partsSubstUList[i] as PartsSubstUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSSUBSTURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
                        SqlParameter findParaChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                        findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                        findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != partsSubstUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  PARTSSUBSTURF" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                            findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                            findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);

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
        /// ���i��փ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="partsSubstUList">��������</param>
        /// <param name="partsSubstUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i��փ}�X�^�̃L�[�l����v����A�S�Ă̕��i��փ}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        public int Search(ref object partsSubstUList, object partsSubstUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList partsSubstUArray = partsSubstUList as ArrayList;
                
                if (partsSubstUArray == null)
                {
                    partsSubstUArray = new ArrayList();
                }
                
                PartsSubstUWork partsSubstUWork = partsSubstUObj as PartsSubstUWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref partsSubstUArray, partsSubstUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// ���i��փ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="partsSubstUList">���i��փ}�X�^�����i�[���� ArrayList</param>
        /// <param name="partsSubstUWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i��փ}�X�^�̃L�[�l����v����A�S�Ă̕��i��փ}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        public int Search(ref ArrayList partsSubstUList, PartsSubstUWork partsSubstUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref partsSubstUList, partsSubstUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i��փ}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="partsSubstUList">���i��փ}�X�^�����i�[���� ArrayList</param>
        /// <param name="partsSubstUWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i��փ}�X�^�̃L�[�l����v����A�S�Ă̕��i��փ}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        private int SearchProc(ref ArrayList partsSubstUList, PartsSubstUWork partsSubstUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "   PRT.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,PRT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,PRT.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,PRT.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,PRT.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGSRCMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGSRCGOODSNORF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGSRCGOODSNONONEHPRF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGDESTGOODSNORF" + Environment.NewLine;
                sqlText += "  ,PRT.CHGDESTGOODSNONONEHPRF" + Environment.NewLine;
                sqlText += "  ,PRT.APPLYSTADATERF" + Environment.NewLine;
                sqlText += "  ,PRT.APPLYENDDATERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS CHGSRCGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS CHGDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS CHGSRCMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS CHGDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM PARTSSUBSTURF AS PRT" + Environment.NewLine;

                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGSRCGOODSNORF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND PRT.CHGSRCMAKERCDRF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGDESTGOODSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND PRT.CHGDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGSRCMAKERCDRF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     PRT.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND PRT.CHGDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, partsSubstUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    partsSubstUList.Add(this.CopyToPartsSubstUWorkFromReader(ref myReader));
                }

                if (partsSubstUList.Count > 0)
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
        /// ���i��փ}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="partsSubstUList">�ǉ��E�X�V���镔�i��փ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUList �Ɋi�[����Ă��镔�i��փ}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        public int Write(ref object partsSubstUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = partsSubstUList as ArrayList;

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
        /// ���i��փ}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="partsSubstUList">�ǉ��E�X�V���镔�i��փ}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUList �Ɋi�[����Ă��镔�i��փ}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        public int Write(ref ArrayList partsSubstUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref partsSubstUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i��փ}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="partsSubstUList">�ǉ��E�X�V���镔�i��փ}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUList �Ɋi�[����Ă��镔�i��փ}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        private int WriteProc(ref ArrayList partsSubstUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (partsSubstUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < partsSubstUList.Count; i++)
                    {
                        PartsSubstUWork partsSubstUWork = partsSubstUList[i] as PartsSubstUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSSUBSTURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
                        SqlParameter findParaChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                        findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                        findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != partsSubstUWork.UpdateDateTime)
                            {
                                if (partsSubstUWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = "UPDATE PARTSSUBSTURF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , CHGSRCMAKERCDRF=@CHGSRCMAKERCD , CHGSRCGOODSNORF=@CHGSRCGOODSNO , CHGSRCGOODSNONONEHPRF=@CHGSRCGOODSNONONEHP , CHGDESTMAKERCDRF=@CHGDESTMAKERCD , CHGDESTGOODSNORF=@CHGDESTGOODSNO , CHGDESTGOODSNONONEHPRF=@CHGDESTGOODSNONONEHP , APPLYSTADATERF=@APPLYSTADATE , APPLYENDDATERF=@APPLYENDDATE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                            findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                            findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);


                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsSubstUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (partsSubstUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO PARTSSUBSTURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, CHGSRCMAKERCDRF, CHGSRCGOODSNORF, CHGSRCGOODSNONONEHPRF, CHGDESTMAKERCDRF, CHGDESTGOODSNORF, CHGDESTGOODSNONONEHPRF, APPLYSTADATERF, APPLYENDDATERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @CHGSRCMAKERCD, @CHGSRCGOODSNO, @CHGSRCGOODSNONONEHP, @CHGDESTMAKERCD, @CHGDESTGOODSNO, @CHGDESTGOODSNONONEHP, @APPLYSTADATE, @APPLYENDDATE)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsSubstUWork;
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
                        SqlParameter paraChgSrcMakerCd = sqlCommand.Parameters.Add("@CHGSRCMAKERCD", SqlDbType.Int);
                        SqlParameter paraChgSrcGoodsNo = sqlCommand.Parameters.Add("@CHGSRCGOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraChgSrcGoodsNoNoneHp = sqlCommand.Parameters.Add("@CHGSRCGOODSNONONEHP", SqlDbType.NVarChar);
                        SqlParameter paraChgDestMakerCd = sqlCommand.Parameters.Add("@CHGDESTMAKERCD", SqlDbType.Int);
                        SqlParameter paraChgDestGoodsNo = sqlCommand.Parameters.Add("@CHGDESTGOODSNO", SqlDbType.NVarChar);
                        SqlParameter paraChgDestGoodsNoNoneHp = sqlCommand.Parameters.Add("@CHGDESTGOODSNONONEHP", SqlDbType.NVarChar);
                        SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);


                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsSubstUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsSubstUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(partsSubstUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(partsSubstUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(partsSubstUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.LogicalDeleteCode);
                        paraChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                        paraChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);
                        paraChgSrcGoodsNoNoneHp.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNoNoneHp);
                        paraChgDestMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgDestMakerCd);
                        paraChgDestGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgDestGoodsNo);
                        paraChgDestGoodsNoNoneHp.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgDestGoodsNoNoneHp);
                        paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(partsSubstUWork.ApplyStaDate);
                        paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(partsSubstUWork.ApplyEndDate);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(partsSubstUWork);
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

            partsSubstUList = al;

            return status;
        }
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// ���i��փ}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="partsSubstUList">�_���폜���镔�i��փ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork �Ɋi�[����Ă��镔�i��փ}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        public int LogicalDelete(ref object partsSubstUList)
        {
            return this.LogicalDelete(ref partsSubstUList, 0);
        }

        /// <summary>
        /// ���i��փ}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="partsSubstUList">�_���폜���������镔�i��փ}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork �Ɋi�[����Ă��镔�i��փ}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        public int RevivalLogicalDelete(ref object partsSubstUList)
        {
            return this.LogicalDelete(ref partsSubstUList, 1);
        }

        /// <summary>
        /// ���i��փ}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="partsSubstUList">�_���폜�𑀍삷�镔�i��փ}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork �Ɋi�[����Ă��镔�i��փ}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        private int LogicalDelete(ref object partsSubstUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = partsSubstUList as ArrayList;

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
        /// ���i��փ}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="partsSubstUList">�_���폜�𑀍삷�镔�i��փ}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork �Ɋi�[����Ă��镔�i��փ}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        public int LogicalDelete(ref ArrayList partsSubstUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref partsSubstUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���i��փ}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="partsSubstUList">�_���폜�𑀍삷�镔�i��փ}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : partsSubstUWork �Ɋi�[����Ă��镔�i��փ}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        private int LogicalDeleteProc(ref ArrayList partsSubstUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (partsSubstUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < partsSubstUList.Count; i++)
                    {
                        PartsSubstUWork partsSubstUWork = partsSubstUList[i] as PartsSubstUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  PARTSSUBSTURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
                        SqlParameter findParaChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                        findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                        findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != partsSubstUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  PARTSSUBSTURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD AND CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);
                            findParaChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
                            findParaChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);


                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)partsSubstUWork;
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
                            else if (logicalDelCd == 0) partsSubstUWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else partsSubstUWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                partsSubstUWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(partsSubstUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(partsSubstUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(partsSubstUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(partsSubstUWork);
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

            partsSubstUList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="partsSubstUWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, PartsSubstUWork partsSubstUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  PRT.ENTERPRISECODERF = @FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(partsSubstUWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND PRT.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND PRT.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //�ϊ������[�J�[
            if (partsSubstUWork.ChgSrcMakerCd != 0)
            {
                retstring += "AND PRT.CHGSRCMAKERCDRF=@FINDCHGSRCMAKERCD ";
                SqlParameter paraChgSrcMakerCd = sqlCommand.Parameters.Add("@FINDCHGSRCMAKERCD", SqlDbType.Int);
                paraChgSrcMakerCd.Value = SqlDataMediator.SqlSetInt32(partsSubstUWork.ChgSrcMakerCd);
            }

            //�ϊ������i�ԍ�
            if (partsSubstUWork.ChgSrcGoodsNo != "")
            {
                retstring += "AND PRT.CHGSRCGOODSNORF=@FINDCHGSRCGOODSNO ";
                SqlParameter paraChgSrcGoodsNo = sqlCommand.Parameters.Add("@FINDCHGSRCGOODSNO", SqlDbType.NVarChar);
                paraChgSrcGoodsNo.Value = SqlDataMediator.SqlSetString(partsSubstUWork.ChgSrcGoodsNo);
            }

            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� PartsSubstUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>PartsSubstUWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        private PartsSubstUWork CopyToPartsSubstUWorkFromReader(ref SqlDataReader myReader)
        {
            PartsSubstUWork partsSubstUWork = new PartsSubstUWork();

            this.CopyToPartsSubstUWorkFromReader(ref myReader, ref partsSubstUWork);

            return partsSubstUWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� PartsSubstUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="partsSubstUWork">PartsSubstUWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008�@���� ���n</br>
        /// <br>Date       : 2008.06.10</br>
        /// </remarks>
        private void CopyToPartsSubstUWorkFromReader(ref SqlDataReader myReader, ref PartsSubstUWork partsSubstUWork)
        {
            if (myReader != null && partsSubstUWork != null)
            {
                # region �N���X�֊i�[
                partsSubstUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                partsSubstUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                partsSubstUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                partsSubstUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                partsSubstUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                partsSubstUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                partsSubstUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                partsSubstUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                partsSubstUWork.ChgSrcMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGSRCMAKERCDRF"));
                partsSubstUWork.ChgSrcGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNORF"));
                partsSubstUWork.ChgSrcGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNONONEHPRF"));
                partsSubstUWork.ChgDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CHGDESTMAKERCDRF"));
                partsSubstUWork.ChgDestGoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNORF"));
                partsSubstUWork.ChgDestGoodsNoNoneHp = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNONONEHPRF"));
                partsSubstUWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
                partsSubstUWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
                partsSubstUWork.ChgSrcGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCGOODSNAMERF"));
                partsSubstUWork.ChgDestGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTGOODSNAMERF"));
                partsSubstUWork.ChgSrcMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGSRCMAKERNAMERF"));
                partsSubstUWork.ChgDestMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CHGDESTMAKERNAMERF"));
                # endregion
            }
        }
        # endregion
    }
}
