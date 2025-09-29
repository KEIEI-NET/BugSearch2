//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �����}�X�^(���[�U�[�o�^)DB�����[�g�I�u�W�F�N�g
//                  :   PMKEN09071R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.06.11
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
    /// �����}�X�^(���[�U�[�o�^)DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.06.11</br>
    /// <br></br>
    /// <br>Update Note: 2010/01/28 30517 �Ė� �x��</br>
    /// <br>             Mantis:14923 �����}�X�^�������ɃG���[�������錏�̏C��</br>
    /// </remarks>
    [Serializable]
    public class JoinPartsUDB : RemoteWithAppLockDB, IJoinPartsUDB
    {
        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        public JoinPartsUDB() : base("PMKEN09073D", "Broadleaf.Application.Remoting.ParamData.JoinPartsUWork", "JOINPARTSURF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P��̌����}�X�^(���[�U�[�o�^)�����擾���܂��B
        /// </summary>
        /// <param name="joinPartsUObj">JoinPartsUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v���錋���}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref object joinPartsUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                JoinPartsUWork joinPartsUWork = joinPartsUObj as JoinPartsUWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref joinPartsUWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// �P��̌����}�X�^(���[�U�[�o�^)�����擾���܂��B
        /// </summary>
        /// <param name="joinPartsUWork">JoinPartsUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v���錋���}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Read(ref JoinPartsUWork joinPartsUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref joinPartsUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P��̌����}�X�^(���[�U�[�o�^)�����擾���܂��B
        /// </summary>
        /// <param name="joinPartsUWork">JoinPartsUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v���錋���}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int ReadProc(ref JoinPartsUWork joinPartsUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "   JOINP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,JOINP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,JOINP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURCEMAKERCODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURPARTSNOWITHHRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURPARTSNONONEHRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDESTPARTSNORF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINQTYRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS JOINSOURGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS JOINDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS JOINSOURMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS JOINDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM JOINPARTSURF AS JOINP" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURPARTSNOWITHHRF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURCEMAKERCODERF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTPARTSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURCEMAKERCODERF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "WHERE JOINP.ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINP.JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINP.JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINP.JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINP.JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToJoinPartsUWorkFromReader(ref myReader, ref joinPartsUWork, 0);
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
        /// �����}�X�^(���[�U�[�o�^)���𕨗��폜���܂�
        /// </summary>
        /// <param name="joinPartsUList">�����폜���錋���}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v���錋���}�X�^(���[�U�[�o�^)���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Delete(object joinPartsUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = joinPartsUList as ArrayList;

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
        /// �����}�X�^(���[�U�[�o�^)���𕨗��폜���܂�
        /// </summary>
        /// <param name="joinPartsUList">�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Delete(ArrayList joinPartsUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(joinPartsUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)���𕨗��폜���܂�
        /// </summary>
        /// <param name="joinPartsUList">�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int DeleteProc(ArrayList joinPartsUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (joinPartsUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < joinPartsUList.Count; i++)
                    {
                        JoinPartsUWork joinPartsUWork = joinPartsUList[i] as JoinPartsUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  JOINPARTSURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                        SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                        SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                        findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                        findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                        findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                        findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != joinPartsUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  JOINPARTSURF" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                            findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                            findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                            findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                            findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);

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
        /// �����}�X�^(���[�U�[�o�^)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="joinPartsUList">��������</param>
        /// <param name="joinPartsUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v����A�S�Ă̌����}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(ref object joinPartsUList, object joinPartsUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList joinPartsUArray = joinPartsUList as ArrayList;
                JoinPartsUWork joinPartsUWork = joinPartsUObj as JoinPartsUWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref joinPartsUArray, joinPartsUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// �����}�X�^(���[�U�[�o�^)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="joinPartsUList">�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="joinPartsUWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v����A�S�Ă̌����}�X�^(���[�U�[�o�^)��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Search(ref ArrayList joinPartsUList, JoinPartsUWork joinPartsUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref joinPartsUList, joinPartsUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="joinPartsUList">�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="joinPartsUWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v����A�S�Ă̌����}�X�^(���[�U�[�o�^)��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int SearchProc(ref ArrayList joinPartsUList, JoinPartsUWork joinPartsUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "   JOINP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,JOINP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,JOINP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURCEMAKERCODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURPARTSNOWITHHRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURPARTSNONONEHRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDESTPARTSNORF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINQTYRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS JOINSOURGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS JOINDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS JOINSOURMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS JOINDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM JOINPARTSURF AS JOINP" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURPARTSNOWITHHRF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURCEMAKERCODERF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTPARTSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSD.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURCEMAKERCODERF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERD.LOGICALDELETECODERF=0" + Environment.NewLine;
                
                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, joinPartsUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    joinPartsUList.Add(this.CopyToJoinPartsUWorkFromReader(ref myReader ,0));
                }

                if (joinPartsUList.Count > 0)
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

        // 2010/01/28 Add >>>
        # region [SearchMstDel]
        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)���̃��X�g�������������擾���܂��B
        /// </summary>
        /// <param name="joinPartsUList">��������</param>
        /// <param name="joinPartsUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="searchCnt">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v����A�S�Ă̌����}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int SearchMstDel(ref object joinPartsUList, object joinPartsUObj, int readMode, ConstantManagement.LogicalMode logicalMode, int searchCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList joinPartsUArray = joinPartsUList as ArrayList;
                JoinPartsUWork joinPartsUWork = joinPartsUObj as JoinPartsUWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchMstDel(ref joinPartsUArray, joinPartsUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, searchCnt);
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
        /// �����}�X�^(���[�U�[�o�^)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="joinPartsUList">�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="joinPartsUWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="searchCnt">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v����A�S�Ă̌����}�X�^(���[�U�[�o�^)��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 30517 �Ė� �x��</br>
        /// <br>Date       : 2010/01/28</br>
        public int SearchMstDel(ref ArrayList joinPartsUList, JoinPartsUWork joinPartsUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,int searchCnt)
        {
            // ����������0�ȉ��Ȃ�S�Ď擾
            if (searchCnt <= 0)
                return this.SearchProc(ref joinPartsUList, joinPartsUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
            else
                return this.SearchMstDelProc(ref joinPartsUList, joinPartsUWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction, searchCnt);
        }

        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="joinPartsUList">�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="joinPartsUWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <param name="searchCnt">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^(���[�U�[�o�^)�̃L�[�l����v����A�S�Ă̌����}�X�^(���[�U�[�o�^)��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 30517 �Ė� �x��</br>
        /// <br>Date       : 2010/01/28</br>
        private int SearchMstDelProc(ref ArrayList joinPartsUList, JoinPartsUWork joinPartsUWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, int searchCnt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT TOP " + searchCnt + Environment.NewLine;
                sqlText += "   JOINP.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,JOINP.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,JOINP.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,JOINP.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURCEMAKERCODERF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURPARTSNOWITHHRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSOURPARTSNONONEHRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINDESTPARTSNORF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINQTYRF" + Environment.NewLine;
                sqlText += "  ,JOINP.JOINSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GOODSS.GOODSNAMERF AS JOINSOURGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS JOINDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERS.MAKERNAMERF AS JOINSOURMAKERNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS JOINDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM JOINPARTSURF AS JOINP" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=GOODSS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURPARTSNOWITHHRF=GOODSS.GOODSNORF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURCEMAKERCODERF=GOODSS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTPARTSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSD.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERS" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=MAKERS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINSOURCEMAKERCODERF=MAKERS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     JOINP.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND JOINP.JOINDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERD.LOGICALDELETECODERF=0" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;
                sqlCommand.CommandText += MakeWhereString2(ref sqlCommand, joinPartsUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    joinPartsUList.Add(this.CopyToJoinPartsUWorkFromReader(ref myReader, 0));
                }

                if (joinPartsUList.Count > 0)
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
        // 2010/01/28 Add <<<

        # region [Write]
        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="joinPartsUList">�ǉ��E�X�V���錋���}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref object joinPartsUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = joinPartsUList as ArrayList;

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
        /// <br>�����}�X�^����o�^�A�X�V���܂�</br>
        /// <br>����e�i�ԁA���[�J�[�R�[�h�̃f�[�^����������DELETE���A�V�K�œ��e��o�^���܂�</br>
        /// </summary>
        /// <param name="joinPartsUWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="joinSourceMakerCode">�e���[�J�[�R�[�h</param>
        /// <param name="joinSourPartsNoWithH">�e���i�Z�b�g�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref object joinPartsUWork, string enterpriseCode, Int32 joinSourceMakerCode, string joinSourPartsNoWithH)
        {
            return this.WriteProc(ref joinPartsUWork, enterpriseCode, joinSourceMakerCode, joinSourPartsNoWithH);
        }

        /// <summary>
        /// <br>�����}�X�^����o�^�A�X�V���܂�</br>
        /// <br>����e�i�ԁA���[�J�[�R�[�h�̃f�[�^����������DELETE���A�V�K�œ��e��o�^���܂�</br>
        /// </summary>
        /// <param name="joinPartsUWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="joinSourceMakerCode">�e���[�J�[�R�[�h</param>
        /// <param name="joinSourPartsNoWithH">�e���i�Z�b�g�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int WriteProc(ref object joinPartsUWork, string enterpriseCode, Int32 joinSourceMakerCode, string joinSourPartsNoWithH)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = joinPartsUWork as ArrayList;
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //DELETE & INSERT ��Write���s
                status = DeleteInsert(ref paraList, enterpriseCode, joinSourceMakerCode, joinSourPartsNoWithH, ref sqlConnection, ref sqlTransaction);

                //�߂�l�Z�b�g
                joinPartsUWork = paraList;
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
        /// �����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="joinPartsUList">�ǉ��E�X�V���錋���}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int Write(ref ArrayList joinPartsUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (joinPartsUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < joinPartsUList.Count; i++)
                    {
                        JoinPartsUWork joinPartsUWork = joinPartsUList[i] as JoinPartsUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  JOINPARTSURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                        SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                        SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);


                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                        findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                        findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                        findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                        findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != joinPartsUWork.UpdateDateTime)
                            {
                                if (joinPartsUWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = "UPDATE JOINPARTSURF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , JOINDISPORDERRF=@JOINDISPORDER , JOINSOURCEMAKERCODERF=@JOINSOURCEMAKERCODE , JOINSOURPARTSNOWITHHRF=@JOINSOURPARTSNOWITHH , JOINSOURPARTSNONONEHRF=@JOINSOURPARTSNONONEH , JOINDESTMAKERCDRF=@JOINDESTMAKERCD , JOINDESTPARTSNORF=@JOINDESTPARTSNO , JOINQTYRF=@JOINQTY , JOINSPECIALNOTERF=@JOINSPECIALNOTE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                            findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                            findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                            findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                            findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);


                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)joinPartsUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (joinPartsUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO JOINPARTSURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, JOINDISPORDERRF, JOINSOURCEMAKERCODERF, JOINSOURPARTSNOWITHHRF, JOINSOURPARTSNONONEHRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, JOINSPECIALNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @JOINDISPORDER, @JOINSOURCEMAKERCODE, @JOINSOURPARTSNOWITHH, @JOINSOURPARTSNONONEH, @JOINDESTMAKERCD, @JOINDESTPARTSNO, @JOINQTY, @JOINSPECIALNOTE)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)joinPartsUWork;
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
                        SqlParameter paraJoinDispOrder = sqlCommand.Parameters.Add("@JOINDISPORDER", SqlDbType.Int);
                        SqlParameter paraJoinSourceMakerCode = sqlCommand.Parameters.Add("@JOINSOURCEMAKERCODE", SqlDbType.Int);
                        SqlParameter paraJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@JOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                        SqlParameter paraJoinSourPartsNoNoneH = sqlCommand.Parameters.Add("@JOINSOURPARTSNONONEH", SqlDbType.NVarChar);
                        SqlParameter paraJoinDestMakerCd = sqlCommand.Parameters.Add("@JOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter paraJoinDestPartsNo = sqlCommand.Parameters.Add("@JOINDESTPARTSNO", SqlDbType.NVarChar);
                        SqlParameter paraJoinQty = sqlCommand.Parameters.Add("@JOINQTY", SqlDbType.Float);
                        SqlParameter paraJoinSpecialNote = sqlCommand.Parameters.Add("@JOINSPECIALNOTE", SqlDbType.NVarChar);

                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(joinPartsUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(joinPartsUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(joinPartsUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.LogicalDeleteCode);
                        paraJoinDispOrder.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDispOrder);
                        paraJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                        paraJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                        paraJoinSourPartsNoNoneH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoNoneH);
                        paraJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                        paraJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);
                        paraJoinQty.Value = SqlDataMediator.SqlSetDouble(joinPartsUWork.JoinQty);
                        paraJoinSpecialNote.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSpecialNote);

                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(joinPartsUWork);
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

            joinPartsUList = al;

            return status;
        }

        /// <summary>
        /// �e�i�ԁA���[�J�[���w�肵�ăf�[�^��DELETE���A���̌�INSERT���܂�
        /// </summary>
        /// <param name="joinPartsUWorkList">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="JoinSourceMakerCode">�e���[�J�[�R�[�h</param>
        /// <param name="JoinSourPartsNoWithH">�e�i��</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int DeleteInsert(ref ArrayList joinPartsUWorkList, string enterpriseCode, Int32 JoinSourceMakerCode, string JoinSourPartsNoWithH, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteInsertProc(ref joinPartsUWorkList, enterpriseCode, JoinSourceMakerCode, JoinSourPartsNoWithH, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �e�i�ԁA���[�J�[���w�肵�ăf�[�^��DELETE���A���̌�INSERT���܂�
        /// </summary>
        /// <param name="joinPartsUWorkList">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="JoinSourceMakerCode">�e���[�J�[�R�[�h</param>
        /// <param name="JoinSourPartsNoWithH">�e�i��</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUList �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int DeleteInsertProc(ref ArrayList joinPartsUWorkList, string enterpriseCode, Int32 JoinSourceMakerCode, string JoinSourPartsNoWithH, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction) 
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string sqlText = string.Empty;
            
            try
            {
                if (joinPartsUWorkList != null)
                {
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  JOINPARTSURF" + Environment.NewLine;
                    sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameter�I�u�W�F�N�g�̍쐬
                    sqlCommand.Parameters.Clear();
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                    SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(JoinSourceMakerCode);
                    findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(JoinSourPartsNoWithH);

                    sqlCommand.ExecuteNonQuery();

                    //�V�K�쐬����SQL���𐶐�
                    sqlText = string.Empty;
                    sqlText = "INSERT INTO JOINPARTSURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, JOINDISPORDERRF, JOINSOURCEMAKERCODERF, JOINSOURPARTSNOWITHHRF, JOINSOURPARTSNONONEHRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, JOINSPECIALNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @JOINDISPORDER, @JOINSOURCEMAKERCODE, @JOINSOURPARTSNOWITHH, @JOINSOURPARTSNONONEH, @JOINDESTMAKERCD, @JOINDESTPARTSNO, @JOINQTY, @JOINSPECIALNOTE)";
                    
                    sqlCommand.CommandText = sqlText;

                    #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraJoinDispOrder = sqlCommand.Parameters.Add("@JOINDISPORDER", SqlDbType.Int);
                    SqlParameter paraJoinSourceMakerCode = sqlCommand.Parameters.Add("@JOINSOURCEMAKERCODE", SqlDbType.Int);
                    SqlParameter paraJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@JOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                    SqlParameter paraJoinSourPartsNoNoneH = sqlCommand.Parameters.Add("@JOINSOURPARTSNONONEH", SqlDbType.NVarChar);
                    SqlParameter paraJoinDestMakerCd = sqlCommand.Parameters.Add("@JOINDESTMAKERCD", SqlDbType.Int);
                    SqlParameter paraJoinDestPartsNo = sqlCommand.Parameters.Add("@JOINDESTPARTSNO", SqlDbType.NVarChar);
                    SqlParameter paraJoinQty = sqlCommand.Parameters.Add("@JOINQTY", SqlDbType.Float);
                    SqlParameter paraJoinSpecialNote = sqlCommand.Parameters.Add("@JOINSPECIALNOTE", SqlDbType.NVarChar);
                    #endregion

                    for (int i = 0; i < joinPartsUWorkList.Count; i++)
                    {
                        JoinPartsUWork joinPartsUWork = joinPartsUWorkList[i] as JoinPartsUWork;

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)joinPartsUWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(joinPartsUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(joinPartsUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(joinPartsUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.LogicalDeleteCode);
                        paraJoinDispOrder.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDispOrder);
                        paraJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                        paraJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                        paraJoinSourPartsNoNoneH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoNoneH);
                        paraJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                        paraJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);
                        paraJoinQty.Value = SqlDataMediator.SqlSetDouble(joinPartsUWork.JoinQty);
                        paraJoinSpecialNote.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSpecialNote);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(joinPartsUWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        
        # endregion

        # region [LogicalDelete]
        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)����_���폜���܂��B
        /// </summary>
        /// <param name="joinPartsUList">�_���폜���錋���}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int LogicalDelete(ref object joinPartsUList)
        {
            return this.LogicalDelete(ref joinPartsUList, 0);
        }

        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)���̘_���폜���������܂��B
        /// </summary>
        /// <param name="joinPartsUList">�_���폜���������錋���}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int RevivalLogicalDelete(ref object joinPartsUList)
        {
            return this.LogicalDelete(ref joinPartsUList, 1);
        }

        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="joinPartsUList">�_���폜�𑀍삷�錋���}�X�^(���[�U�[�o�^)���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int LogicalDelete(ref object joinPartsUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = joinPartsUList as ArrayList;

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
        /// �����}�X�^(���[�U�[�o�^)���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="joinPartsUList">�_���폜�𑀍삷�錋���}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        public int LogicalDelete(ref ArrayList joinPartsUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref joinPartsUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �����}�X�^(���[�U�[�o�^)���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="joinPartsUList">�_���폜�𑀍삷�錋���}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : joinPartsUWork �Ɋi�[����Ă��錋���}�X�^(���[�U�[�o�^)���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        private int LogicalDeleteProc(ref ArrayList joinPartsUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (joinPartsUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < joinPartsUList.Count; i++)
                    {
                        JoinPartsUWork joinPartsUWork = joinPartsUList[i] as JoinPartsUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  JOINPARTSURF" + Environment.NewLine;
                        sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                        SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                        SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                        findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                        findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                        findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                        findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != joinPartsUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  JOINPARTSURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE AND JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);
                            findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                            findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                            findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                            findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)joinPartsUWork;
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
                            else if (logicalDelCd == 0) joinPartsUWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else joinPartsUWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                joinPartsUWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(joinPartsUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(joinPartsUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(joinPartsUWork);
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

            joinPartsUList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="joinPartsUWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, JoinPartsUWork joinPartsUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  JOINP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND JOINP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND JOINP.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            
            //�e���[�J�[�R�[�h
            if (joinPartsUWork.JoinSourceMakerCode != 0)
            {
                retstring += "AND JOINP.JOINSOURCEMAKERCODERF=@FINDJOINSOURCEMAKERCODE " + Environment.NewLine;
                SqlParameter findParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@FINDJOINSOURCEMAKERCODE", SqlDbType.Int);
                findParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
            }
            
            //�e�i��
            if (string.IsNullOrEmpty(joinPartsUWork.JoinSourPartsNoWithH) == false)
            {
                retstring += "AND JOINP.JOINSOURPARTSNOWITHHRF=@FINDJOINSOURPARTSNOWITHH " + Environment.NewLine;
                SqlParameter findParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@FINDJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                findParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
            }
            
            //�q���[�J�[�R�[�h
            if (joinPartsUWork.JoinDestMakerCd != 0)
            {
                retstring += "AND JOINP.JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD " + Environment.NewLine;
                SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
            }
            
            //�q�i��
            if (string.IsNullOrEmpty(joinPartsUWork.JoinDestPartsNo) == false)
            {
                retstring += "AND JOINP.JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO " + Environment.NewLine;
                SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);
                findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);
            }

            retstring += "ORDER BY JOINP.ENTERPRISECODERF, JOINP.JOINDISPORDERRF, JOINP.JOINSOURCEMAKERCODERF, JOINP.JOINSOURPARTSNOWITHHRF, JOINP.JOINDESTMAKERCDRF, JOINP.JOINDESTPARTSNORF";
            
            return retstring;
        }

        // 2010/01/28 Add >>>
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="joinPartsUWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30517 �Ė� �x��</br>
        /// <br>Date       : 2010/01/28</br>
        private string MakeWhereString2(ref SqlCommand sqlCommand, JoinPartsUWork joinPartsUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine; ;

            // ��ƃR�[�h
            retstring += "  JOINP.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(joinPartsUWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND JOINP.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND JOINP.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            if (joinPartsUWork.JoinSourceMakerCode != 0 &&
                string.IsNullOrEmpty(joinPartsUWork.JoinSourPartsNoWithH) == false &&
                joinPartsUWork.JoinDestMakerCd != 0 &&
                string.IsNullOrEmpty(joinPartsUWork.JoinDestPartsNo) == false)
            {
                //�e���[�J�[�R�[�h
                retstring += "AND (( JOINP.JOINSOURCEMAKERCODERF>@SEARCHJOINSOURCEMAKERCODE ) " + Environment.NewLine;
                SqlParameter searchParaJoinSourceMakerCode = sqlCommand.Parameters.Add("@SEARCHJOINSOURCEMAKERCODE", SqlDbType.Int);
                searchParaJoinSourceMakerCode.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinSourceMakerCode);
                //�e�i��
                retstring += "OR ( JOINP.JOINSOURCEMAKERCODERF=@SEARCHJOINSOURCEMAKERCODE AND JOINP.JOINSOURPARTSNOWITHHRF>@SEARCHJOINSOURPARTSNOWITHH ) " + Environment.NewLine;
                SqlParameter searchParaJoinSourPartsNoWithH = sqlCommand.Parameters.Add("@SEARCHJOINSOURPARTSNOWITHH", SqlDbType.NVarChar);
                searchParaJoinSourPartsNoWithH.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinSourPartsNoWithH);
                //�q���[�J�[�R�[�h
                retstring += "OR ( JOINP.JOINSOURCEMAKERCODERF=@SEARCHJOINSOURCEMAKERCODE AND JOINP.JOINSOURPARTSNOWITHHRF=@SEARCHJOINSOURPARTSNOWITHH AND JOINP.JOINDESTMAKERCDRF>@SEARCHJOINDESTMAKERCD ) " + Environment.NewLine;
                SqlParameter searchParaJoinDestMakerCd = sqlCommand.Parameters.Add("@SEARCHJOINDESTMAKERCD", SqlDbType.Int);
                searchParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(joinPartsUWork.JoinDestMakerCd);
                //�q�i��
                retstring += "OR ( JOINP.JOINSOURCEMAKERCODERF=@SEARCHJOINSOURCEMAKERCODE AND JOINP.JOINSOURPARTSNOWITHHRF=@SEARCHJOINSOURPARTSNOWITHH AND JOINP.JOINDESTMAKERCDRF=@SEARCHJOINDESTMAKERCD AND JOINP.JOINDESTPARTSNORF>@SEARCHJOINDESTPARTSNO )) " + Environment.NewLine;
                SqlParameter searchParaJoinDestPartsNo = sqlCommand.Parameters.Add("@SEARCHJOINDESTPARTSNO", SqlDbType.NVarChar);
                searchParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(joinPartsUWork.JoinDestPartsNo);
            }

            retstring += "ORDER BY JOINP.ENTERPRISECODERF, JOINP.JOINSOURCEMAKERCODERF, JOINP.JOINSOURPARTSNOWITHHRF, JOINP.JOINDESTMAKERCDRF, JOINP.JOINDESTPARTSNORF";

            return retstring;
        }
        // 2010/01/28 Add <<<
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� JoinPartsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">mode</param>
        /// <returns>JoinPartsUWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private JoinPartsUWork CopyToJoinPartsUWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            JoinPartsUWork joinPartsUWork = new JoinPartsUWork();

            this.CopyToJoinPartsUWorkFromReader(ref myReader, ref joinPartsUWork, mode);

            return joinPartsUWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� JoinPartsUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="joinPartsUWork">JoinPartsUWork �I�u�W�F�N�g</param>
        /// <param name="mode">mode</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.06.11</br>
        /// </remarks>
        private void CopyToJoinPartsUWorkFromReader(ref SqlDataReader myReader, ref JoinPartsUWork joinPartsUWork, int mode)
        {
            if (myReader != null && joinPartsUWork != null)
            {
                # region �N���X�֊i�[
                joinPartsUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                joinPartsUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                joinPartsUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                joinPartsUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                joinPartsUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                joinPartsUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                joinPartsUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                joinPartsUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                joinPartsUWork.JoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDISPORDERRF"));
                joinPartsUWork.JoinSourceMakerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINSOURCEMAKERCODERF"));
                joinPartsUWork.JoinSourPartsNoWithH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNOWITHHRF"));
                joinPartsUWork.JoinSourPartsNoNoneH = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURPARTSNONONEHRF"));
                joinPartsUWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                joinPartsUWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                joinPartsUWork.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                joinPartsUWork.JoinSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSPECIALNOTERF"));

                if (mode == 0)
                {
                    joinPartsUWork.JoinSourGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURGOODSNAMERF"));
                    joinPartsUWork.JoinDestGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTGOODSNAMERF"));
                    joinPartsUWork.JoinSourMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINSOURMAKERNAMERF"));
                    joinPartsUWork.JoinDestMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTMAKERNAMERF"));
                }
                # endregion

            }
        }
        # endregion
    }
}
