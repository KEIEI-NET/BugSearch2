//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   TBO�����}�X�^(���[�U�[�o�^)DB�����[�g�I�u�W�F�N�g
//                  :   PMKEN09114R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.11.17
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
    /// TBO�����}�X�^(���[�U�[�o�^)DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : TBO�����}�X�^(���[�U�[�o�^)�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2008.11.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class TBOSearchUDB : RemoteWithAppLockDB, ITBOSearchUDB
    {
        /// <summary>
        /// TBO�����}�X�^(���[�U�[�o�^)DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        /// </remarks>
        public TBOSearchUDB()
            : base("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork", "TBOSEARCHURF")
        {

        }

        # region [Read]
        /// <summary>
        /// �P���TBO�����}�X�^(���[�U�[�o�^)�����擾���܂��B
        /// </summary>
        /// <param name="tboSearchUObj">TBOSearchUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^(���[�U�[�o�^)�̃L�[�l����v����TBO�����}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int Read(ref object tboSearchUObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                TBOSearchUWork tboSearchUWork = tboSearchUObj as TBOSearchUWork;

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref tboSearchUWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// �P���TBO�����}�X�^(���[�U�[�o�^)�����擾���܂��B
        /// </summary>
        /// <param name="tboSearchUWork">TBOSearchUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^(���[�U�[�o�^)�̃L�[�l����v����TBO�����}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int Read(ref TBOSearchUWork tboSearchUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref tboSearchUWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P���TBO�����}�X�^(���[�U�[�o�^)�����擾���܂��B
        /// </summary>
        /// <param name="tboSearchUWork">TBOSearchUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^(���[�U�[�o�^)�̃L�[�l����v����TBO�����}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        private int ReadProc(ref TBOSearchUWork tboSearchUWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "   TBO.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,TBO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,TBO.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPGENRECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPNAMERF" + Environment.NewLine;
                sqlText += "  ,TBO.CARINFOJOINDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,TBO.JOINDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,TBO.JOINDESTPARTSNORF" + Environment.NewLine;
                sqlText += "  ,TBO.JOINQTYRF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS JOINDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS JOINDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM TBOSEARCHURF AS TBO" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     TBO.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND TBO.JOINDESTPARTSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND TBO.JOINDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     TBO.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND TBO.JOINDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;
                sqlText += "  AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                sqlText += "  AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                sqlCommand.CommandText = sqlText;
                # endregion

                // Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
                SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);

                // Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToTBOSearchUWorkFromReader(ref myReader, ref tboSearchUWork, 0);
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
        /// TBO�����}�X�^(���[�U�[�o�^)���𕨗��폜���܂�
        /// </summary>
        /// <param name="tboSearchUList">�����폜����TBO�����}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^(���[�U�[�o�^)�̃L�[�l����v����TBO�����}�X�^(���[�U�[�o�^)���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int Delete(object tboSearchUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = tboSearchUList as ArrayList;

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
        /// TBO�����}�X�^(���[�U�[�o�^)���𕨗��폜���܂�
        /// </summary>
        /// <param name="tboSearchUList">TBO�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int Delete(ArrayList tboSearchUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(tboSearchUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// TBO�����}�X�^(���[�U�[�o�^)���𕨗��폜���܂�
        /// </summary>
        /// <param name="tboSearchUList">TBO�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)���𕨗��폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        private int DeleteProc(ArrayList tboSearchUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (tboSearchUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < tboSearchUList.Count; i++)
                    {
                        TBOSearchUWork tboSearchUWork = tboSearchUList[i] as TBOSearchUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  TBOSEARCHURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                        sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;
                        sqlText += "  AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                        sqlText += "  AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                        SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
                        SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                        findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                        findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                        findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                        findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);


                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != tboSearchUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += "FROM" + Environment.NewLine;
                            sqlText += "  TBOSEARCHURF" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                            sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;
                            sqlText += "  AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                            sqlText += "  AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                            findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                            findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                            findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                            findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);

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
        /// TBO�����}�X�^(���[�U�[�o�^)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="tboSearchUList">��������</param>
        /// <param name="tboSearchUObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^(���[�U�[�o�^)�̃L�[�l����v����A�S�Ă�TBO�����}�X�^(���[�U�[�o�^)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int Search(ref object tboSearchUList, object tboSearchUObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                ArrayList tboSearchUArray = tboSearchUList as ArrayList;
                ArrayList paraList = tboSearchUObj as ArrayList;
                
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    TBOSearchUWork tboSearchUWork = tboSearchUObj as TBOSearchUWork;
                    paraList.Add(tboSearchUWork);

                }

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref tboSearchUArray, paraList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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
        /// TBO�����}�X�^(���[�U�[�o�^)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="tboSearchUList">TBO�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="paraList">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^(���[�U�[�o�^)�̃L�[�l����v����A�S�Ă�TBO�����}�X�^(���[�U�[�o�^)��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int Search(ref ArrayList tboSearchUList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref tboSearchUList, paraList, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// TBO�����}�X�^(���[�U�[�o�^)���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="tboSearchUList">TBO�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="paraList">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^(���[�U�[�o�^)�̃L�[�l����v����A�S�Ă�TBO�����}�X�^(���[�U�[�o�^)��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        private int SearchProc(ref ArrayList tboSearchUList, ArrayList paraList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                sqlText += "   TBO.CREATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDATEDATETIMERF" + Environment.NewLine;
                sqlText += "  ,TBO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.FILEHEADERGUIDRF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDEMPLOYEECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDASSEMBLYID1RF" + Environment.NewLine;
                sqlText += "  ,TBO.UPDASSEMBLYID2RF" + Environment.NewLine;
                sqlText += "  ,TBO.LOGICALDELETECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPGENRECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPNAMERF" + Environment.NewLine;
                sqlText += "  ,TBO.CARINFOJOINDISPORDERRF" + Environment.NewLine;
                sqlText += "  ,TBO.JOINDESTMAKERCDRF" + Environment.NewLine;
                sqlText += "  ,TBO.JOINDESTPARTSNORF" + Environment.NewLine;
                sqlText += "  ,TBO.JOINQTYRF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPSPECIALNOTERF" + Environment.NewLine;
                sqlText += "  ,GOODSD.GOODSNAMERF AS JOINDESTGOODSNAMERF" + Environment.NewLine;
                sqlText += "  ,MAKERD.MAKERNAMERF AS JOINDESTMAKERNAMERF" + Environment.NewLine;
                sqlText += " FROM TBOSEARCHURF AS TBO" + Environment.NewLine;
                sqlText += "LEFT JOIN GOODSURF AS GOODSD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     TBO.ENTERPRISECODERF=GOODSD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND TBO.JOINDESTPARTSNORF=GOODSD.GOODSNORF" + Environment.NewLine;
                sqlText += " AND TBO.JOINDESTMAKERCDRF=GOODSD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND GOODSD.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "LEFT JOIN MAKERURF AS MAKERD" + Environment.NewLine;
                sqlText += "ON " + Environment.NewLine;
                sqlText += "     TBO.ENTERPRISECODERF=MAKERD.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += " AND TBO.JOINDESTMAKERCDRF=MAKERD.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += " AND MAKERD.LOGICALDELETECODERF=0" + Environment.NewLine;

                foreach (TBOSearchUWork tboSearchUWork in paraList)
                {
                    sqlCommand.Parameters.Clear();

                    sqlCommand.CommandText = sqlText;
                    sqlCommand.CommandText += MakeWhereString(ref sqlCommand, tboSearchUWork, logicalMode);
                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        tboSearchUList.Add(this.CopyToTBOSearchUWorkFromReader(ref myReader, 0));
                    }

                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }

                if (tboSearchUList.Count > 0)
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

        # region [SearchEquipNameGuide]
        /// <summary>
        /// �������̃K�C�h�p�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="tboSearchUList">��������</param>
        /// <param name="tboSearchUObj">��������</param>
        /// <param name="equipNameSrchTyp">�������̌����^�C�v 0:���S��v,1:�O����v����,2:�����v����,3:�B������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������̃K�C�h�p�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int SearchEquipNameGuide(ref object tboSearchUList, object tboSearchUObj, int equipNameSrchTyp)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            TBOSearchUWork tboSearchUWork = null;

            ArrayList tboSearchUArray = new ArrayList();
            ArrayList paraList = tboSearchUObj as ArrayList;

            if (paraList == null)
            {
                tboSearchUWork = tboSearchUObj as TBOSearchUWork;
            }
            else
            {
                if (paraList.Count > 0)
                    tboSearchUWork = paraList[0] as TBOSearchUWork;
            }

            try
            {

                // �R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.SearchEquipNameGuide(ref tboSearchUArray, tboSearchUWork, equipNameSrchTyp, ref sqlConnection, ref sqlTransaction);

                tboSearchUList = tboSearchUArray;
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
        /// �������̃K�C�h�p�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="tboSearchUList">TBO�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="tboSearchUWork">��������</param>
        /// <param name="equipNameSrchTyp">�������̌����^�C�v 0:���S��v,1:�O����v����,2:�����v����,3:�B������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������̃K�C�h�p�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int SearchEquipNameGuide(ref ArrayList tboSearchUList, TBOSearchUWork tboSearchUWork, int equipNameSrchTyp, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchEquipNameGuideProc(ref tboSearchUList, tboSearchUWork, equipNameSrchTyp, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �������̃K�C�h�p�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="tboSearchUList">TBO�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="tboSearchUWork">��������</param>
        /// <param name="equipNameSrchTyp">�������̌����^�C�v 0:���S��v,1:�O����v����,2:�����v����,3:�B������</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �������̃K�C�h�p�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        private int SearchEquipNameGuideProc(ref ArrayList tboSearchUList, TBOSearchUWork tboSearchUWork, int equipNameSrchTyp, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string sqlText = string.Empty;
                sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                # region [SELECT��]
                sqlText += "SELECT DISTINCT" + Environment.NewLine;
                sqlText += "   TBO.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPGENRECODERF" + Environment.NewLine;
                sqlText += "  ,TBO.EQUIPNAMERF" + Environment.NewLine;
                sqlText += " FROM TBOSEARCHURF AS TBO" + Environment.NewLine;

                sqlCommand.CommandText = sqlText;

                sqlText = string.Empty;
                sqlText += "WHERE" + Environment.NewLine;

                //��ƃR�[�h
                sqlText += "      TBO.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);

                //�_���폜�敪
                sqlText += "  AND TBO.LOGICALDELETECODERF = 0" + Environment.NewLine;

                //��������
                if (tboSearchUWork.EquipGenreCode != 0)
                {
                    sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                    SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                    findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                }

                //��������
                if (string.IsNullOrEmpty(tboSearchUWork.EquipName) == false)
                {
                    sqlText += "  AND EQUIPNAMERF LIKE @FINDEQUIPNAME";
                    SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
                    //�O����v�����̏ꍇ
                    if (equipNameSrchTyp == 1) tboSearchUWork.EquipName = tboSearchUWork.EquipName + "%";
                    //�����v�����̏ꍇ
                    if (equipNameSrchTyp == 2) tboSearchUWork.EquipName = "%" + tboSearchUWork.EquipName;
                    //�B�������̏ꍇ
                    if (equipNameSrchTyp == 3) tboSearchUWork.EquipName = "%" + tboSearchUWork.EquipName + "%";

                    findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                }

                sqlCommand.CommandText += sqlText;

                # endregion

#if DEBUG
                Console.Clear();
                Console.WriteLine(NSDebug.GetSqlCommand(sqlCommand));
#endif

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    TBOSearchUWork tbowork = new TBOSearchUWork();

                    tbowork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    tbowork.EquipGenreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRECODERF"));
                    tbowork.EquipName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPNAMERF"));

                    tboSearchUList.Add(tbowork);
                }

                if (tboSearchUList.Count > 0)
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
        /// TBO�����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="tboSearchUList">�ǉ��E�X�V����TBO�����}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int Write(ref object tboSearchUList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = tboSearchUList as ArrayList;

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
        /// TBO�����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="tboSearchUList">�ǉ��E�X�V����TBO�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int Write(ref ArrayList tboSearchUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return WriteProc(ref tboSearchUList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// TBO�����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="tboSearchUList">�ǉ��E�X�V����TBO�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        private int WriteProc(ref ArrayList tboSearchUList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (tboSearchUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < tboSearchUList.Count; i++)
                    {
                        TBOSearchUWork tboSearchUWork = tboSearchUList[i] as TBOSearchUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  TBOSEARCHURF " + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                        sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;
                        sqlText += "  AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                        sqlText += "  AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                        SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
                        SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                        findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                        findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                        findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                        findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != tboSearchUWork.UpdateDateTime)
                            {
                                if (tboSearchUWork.UpdateDateTime == DateTime.MinValue)
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
                            sqlText = "UPDATE TBOSEARCHURF SET CREATEDATETIMERF=@CREATEDATETIME , UPDATEDATETIMERF=@UPDATEDATETIME , ENTERPRISECODERF=@ENTERPRISECODE , FILEHEADERGUIDRF=@FILEHEADERGUID , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE , BLGOODSCODERF=@BLGOODSCODE , EQUIPGENRECODERF=@EQUIPGENRECODE , EQUIPNAMERF=@EQUIPNAME , CARINFOJOINDISPORDERRF=@CARINFOJOINDISPORDER , JOINDESTMAKERCDRF=@JOINDESTMAKERCD , JOINDESTPARTSNORF=@JOINDESTPARTSNO , JOINQTYRF=@JOINQTY , EQUIPSPECIALNOTERF=@EQUIPSPECIALNOTE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE AND EQUIPNAMERF=@FINDEQUIPNAME AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                            findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                            findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                            findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                            findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);


                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)tboSearchUWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            // ����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (tboSearchUWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText = "INSERT INTO TBOSEARCHURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, BLGOODSCODERF, EQUIPGENRECODERF, EQUIPNAMERF, CARINFOJOINDISPORDERRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, EQUIPSPECIALNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @BLGOODSCODE, @EQUIPGENRECODE, @EQUIPNAME, @CARINFOJOINDISPORDER, @JOINDESTMAKERCD, @JOINDESTPARTSNO, @JOINQTY, @EQUIPSPECIALNOTE)";
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // �o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)tboSearchUWork;
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
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraEquipGenreCode = sqlCommand.Parameters.Add("@EQUIPGENRECODE", SqlDbType.Int);
                        SqlParameter paraEquipName = sqlCommand.Parameters.Add("@EQUIPNAME", SqlDbType.NVarChar);
                        SqlParameter paraCarInfoJoinDispOrder = sqlCommand.Parameters.Add("@CARINFOJOINDISPORDER", SqlDbType.Int);
                        SqlParameter paraJoinDestMakerCd = sqlCommand.Parameters.Add("@JOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter paraJoinDestPartsNo = sqlCommand.Parameters.Add("@JOINDESTPARTSNO", SqlDbType.NVarChar);
                        SqlParameter paraJoinQty = sqlCommand.Parameters.Add("@JOINQTY", SqlDbType.Float);
                        SqlParameter paraEquipSpecialNote = sqlCommand.Parameters.Add("@EQUIPSPECIALNOTE", SqlDbType.NVarChar);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tboSearchUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tboSearchUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(tboSearchUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.LogicalDeleteCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.BLGoodsCode);
                        paraEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                        paraEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                        paraCarInfoJoinDispOrder.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.CarInfoJoinDispOrder);
                        paraJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                        paraJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);
                        paraJoinQty.Value = SqlDataMediator.SqlSetDouble(tboSearchUWork.JoinQty);
                        paraEquipSpecialNote.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipSpecialNote);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(tboSearchUWork);
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

            tboSearchUList = al;

            return status;
        }

        /// <summary>
        /// <br>TBO�����}�X�^����o�^�A�X�V���܂�</br>
        /// <br>���ꑕ�����́A���[�J�[�R�[�h�̃f�[�^����������DELETE���A�V�K�œ��e��o�^���܂�</br>
        /// </summary>
        /// <param name="tboSearchUWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="equipGenreCode">��������</param>
        /// <param name="equipName">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int Write(ref object tboSearchUWork, string enterpriseCode, Int32 equipGenreCode, string equipName)
        {
            return this.WriteProc(ref tboSearchUWork, enterpriseCode, equipGenreCode, equipName);
        }

        /// <summary>
        /// <br>TBO�����}�X�^����o�^�A�X�V���܂�</br>
        /// <br>���ꑕ�����́A�������ނ̃f�[�^����������DELETE���A�V�K�œ��e��o�^���܂�</br>
        /// </summary>
        /// <param name="tboSearchUWork">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="equipGenreCode">��������</param>
        /// <param name="equipName">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO�����}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        private int WriteProc(ref object tboSearchUWork, string enterpriseCode, Int32 equipGenreCode, string equipName)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = tboSearchUWork as ArrayList;
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                // �g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //DELETE & INSERT ��Write���s
                status = DeleteInsert(ref paraList, enterpriseCode, equipGenreCode, equipName, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    status = this.Write(ref paraList, ref sqlConnection, ref sqlTransaction);

                //�߂�l�Z�b�g
                tboSearchUWork = paraList;
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
        /// �������́A�������ނ��w�肵�ăf�[�^��DELETE���A���̌�INSERT���܂�
        /// </summary>
        /// <param name="tboSearchUWorkList">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="equipGenreCode">��������</param>
        /// <param name="equipName">��������</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int DeleteInsert(ref ArrayList tboSearchUWorkList, string enterpriseCode, Int32 equipGenreCode, string equipName, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return DeleteInsertProc(ref tboSearchUWorkList, enterpriseCode, equipGenreCode, equipName, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �������́A�������ނ��w�肵�ăf�[�^��DELETE���A���̌�INSERT���܂�
        /// </summary>
        /// <param name="tboSearchUWorkList">GoodsSetWork�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="equipGenreCode">��������</param>
        /// <param name="equipName">��������</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <param name="sqlTransaction">SQL�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUList �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        private int DeleteInsertProc(ref ArrayList tboSearchUWorkList, string enterpriseCode, Int32 equipGenreCode, string equipName, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction) 
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string sqlText = string.Empty;
            
            try
            {
                if (tboSearchUWorkList != null)
                {
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  TBOSEARCHURF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                    sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;

                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    // Prameter�I�u�W�F�N�g�̍쐬
                    sqlCommand.Parameters.Clear();
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                    SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);

                    // Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                    findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(equipGenreCode);
                    findParaEquipName.Value = SqlDataMediator.SqlSetString(equipName);

                    sqlCommand.ExecuteNonQuery();

                    //�V�K�쐬����SQL���𐶐�
                    sqlText = string.Empty;
                    sqlText = "INSERT INTO TBOSEARCHURF (CREATEDATETIMERF, UPDATEDATETIMERF, ENTERPRISECODERF, FILEHEADERGUIDRF, UPDEMPLOYEECODERF, UPDASSEMBLYID1RF, UPDASSEMBLYID2RF, LOGICALDELETECODERF, BLGOODSCODERF, EQUIPGENRECODERF, EQUIPNAMERF, CARINFOJOINDISPORDERRF, JOINDESTMAKERCDRF, JOINDESTPARTSNORF, JOINQTYRF, EQUIPSPECIALNOTERF) VALUES (@CREATEDATETIME, @UPDATEDATETIME, @ENTERPRISECODE, @FILEHEADERGUID, @UPDEMPLOYEECODE, @UPDASSEMBLYID1, @UPDASSEMBLYID2, @LOGICALDELETECODE, @BLGOODSCODE, @EQUIPGENRECODE, @EQUIPNAME, @CARINFOJOINDISPORDER, @JOINDESTMAKERCD, @JOINDESTPARTSNO, @JOINQTY, @EQUIPSPECIALNOTE)";
                    
                    sqlCommand.CommandText = sqlText;

                    # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                    SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                    SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                    SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraEquipGenreCode = sqlCommand.Parameters.Add("@EQUIPGENRECODE", SqlDbType.Int);
                    SqlParameter paraEquipName = sqlCommand.Parameters.Add("@EQUIPNAME", SqlDbType.NVarChar);
                    SqlParameter paraCarInfoJoinDispOrder = sqlCommand.Parameters.Add("@CARINFOJOINDISPORDER", SqlDbType.Int);
                    SqlParameter paraJoinDestMakerCd = sqlCommand.Parameters.Add("@JOINDESTMAKERCD", SqlDbType.Int);
                    SqlParameter paraJoinDestPartsNo = sqlCommand.Parameters.Add("@JOINDESTPARTSNO", SqlDbType.NVarChar);
                    SqlParameter paraJoinQty = sqlCommand.Parameters.Add("@JOINQTY", SqlDbType.Float);
                    SqlParameter paraEquipSpecialNote = sqlCommand.Parameters.Add("@EQUIPSPECIALNOTE", SqlDbType.NVarChar);
                    # endregion

                    for (int i = 0; i < tboSearchUWorkList.Count; i++)
                    {
                        TBOSearchUWork tboSearchUWork = tboSearchUWorkList[i] as TBOSearchUWork;

                        //�o�^�w�b�_����ݒ�
                        object obj = (object)this;
                        IFileHeader flhd = (IFileHeader)tboSearchUWork;
                        FileHeader fileHeader = new FileHeader(obj);
                        fileHeader.SetInsertHeader(ref flhd, obj);

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tboSearchUWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tboSearchUWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(tboSearchUWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.LogicalDeleteCode);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.BLGoodsCode);
                        paraEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                        paraEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                        paraCarInfoJoinDispOrder.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.CarInfoJoinDispOrder);
                        paraJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                        paraJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);
                        paraJoinQty.Value = SqlDataMediator.SqlSetDouble(tboSearchUWork.JoinQty);
                        paraEquipSpecialNote.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipSpecialNote);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(tboSearchUWork);
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
        /// TBO�����}�X�^(���[�U�[�o�^)����_���폜���܂��B
        /// </summary>
        /// <param name="tboSearchUList">�_���폜����TBO�����}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUWork �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)����_���폜���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int LogicalDelete(ref object tboSearchUList)
        {
            return this.LogicalDelete(ref tboSearchUList, 0);
        }

        /// <summary>
        /// TBO�����}�X�^(���[�U�[�o�^)���̘_���폜���������܂��B
        /// </summary>
        /// <param name="tboSearchUList">�_���폜����������TBO�����}�X�^(���[�U�[�o�^)�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUUWork �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)���̘_���폜���������܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int RevivalLogicalDelete(ref object tboSearchUList)
        {
            return this.LogicalDelete(ref tboSearchUList, 1);
        }

        /// <summary>
        /// TBO�����}�X�^(���[�U�[�o�^)���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="tboSearchUList">�_���폜�𑀍삷��TBO�����}�X�^(���[�U�[�o�^)���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUWork �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        private int LogicalDelete(ref object tboSearchUList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                // �p�����[�^�̃L���X�g
                ArrayList paraList = tboSearchUList as ArrayList;

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
        /// TBO�����}�X�^(���[�U�[�o�^)���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="tboSearchUList">�_���폜�𑀍삷��TBO�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUWork �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        public int LogicalDelete(ref ArrayList tboSearchUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref tboSearchUList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// TBO�����}�X�^(���[�U�[�o�^)���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="tboSearchUList">�_���폜�𑀍삷��TBO�����}�X�^(���[�U�[�o�^)�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : tboSearchUWork �Ɋi�[����Ă���TBO�����}�X�^(���[�U�[�o�^)���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        private int LogicalDeleteProc(ref ArrayList tboSearchUList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (tboSearchUList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < tboSearchUList.Count; i++)
                    {
                        TBOSearchUWork tboSearchUWork = tboSearchUList[i] as TBOSearchUWork;

                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  TBOSEARCHURF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                        sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;
                        sqlText += "  AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                        sqlText += "  AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                        sqlCommand.CommandText = sqlText;
                        # endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                        SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
                        SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                        SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);

                        // Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                        findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                        findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                        findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                        findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            // ����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));// �X�V����

                            if (_updateDateTime != tboSearchUWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            // ���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE" + Environment.NewLine;
                            sqlText += "  TBOSEARCHURF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND EQUIPGENRECODERF=@FINDEQUIPGENRECODE" + Environment.NewLine;
                            sqlText += "  AND EQUIPNAMERF=@FINDEQUIPNAME" + Environment.NewLine;
                            sqlText += "  AND JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD" + Environment.NewLine;
                            sqlText += "  AND JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);
                            findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
                            findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
                            findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
                            findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)tboSearchUWork;
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
                            else if (logicalDelCd == 0) tboSearchUWork.LogicalDeleteCode = 1;  // �_���폜�t���O���Z�b�g
                            else tboSearchUWork.LogicalDeleteCode = 3;                         // ���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                tboSearchUWork.LogicalDeleteCode = 0;                          // �_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(tboSearchUWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(tboSearchUWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(tboSearchUWork);
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

            tboSearchUList = al;

            return status;
        }
        # endregion

        # region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="tboSearchUWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, TBOSearchUWork tboSearchUWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE" + Environment.NewLine;;

            // ��ƃR�[�h
            retstring += "  TBO.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EnterpriseCode);

            // �_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring += "  AND TBO.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring += "  AND TBO.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter findLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            
            //��������
            if (tboSearchUWork.EquipGenreCode != 0)
            {
                retstring += "AND TBO.EQUIPGENRECODERF=@FINDEQUIPGENRECODE " + Environment.NewLine;
                SqlParameter findParaEquipGenreCode = sqlCommand.Parameters.Add("@FINDEQUIPGENRECODE", SqlDbType.Int);
                findParaEquipGenreCode.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.EquipGenreCode);
            }
            
            //��������
            if (string.IsNullOrEmpty(tboSearchUWork.EquipName) == false)
            {
                retstring += "AND TBO.EQUIPNAMERF=@FINDEQUIPNAME " + Environment.NewLine;
                SqlParameter findParaEquipName = sqlCommand.Parameters.Add("@FINDEQUIPNAME", SqlDbType.NVarChar);
                findParaEquipName.Value = SqlDataMediator.SqlSetString(tboSearchUWork.EquipName);
            }
            
            //�����惁�[�J�[�R�[�h
            if (tboSearchUWork.JoinDestMakerCd != 0)
            {
                retstring += "AND TBO.JOINDESTMAKERCDRF=@FINDJOINDESTMAKERCD " + Environment.NewLine;
                SqlParameter findParaJoinDestMakerCd = sqlCommand.Parameters.Add("@FINDJOINDESTMAKERCD", SqlDbType.Int);
                findParaJoinDestMakerCd.Value = SqlDataMediator.SqlSetInt32(tboSearchUWork.JoinDestMakerCd);
            }
            
            //������i��
            if (string.IsNullOrEmpty(tboSearchUWork.JoinDestPartsNo) == false)
            {
                retstring += "AND TBO.JOINDESTPARTSNORF=@FINDJOINDESTPARTSNO " + Environment.NewLine;
                SqlParameter findParaJoinDestPartsNo = sqlCommand.Parameters.Add("@FINDJOINDESTPARTSNO", SqlDbType.NVarChar);
                findParaJoinDestPartsNo.Value = SqlDataMediator.SqlSetString(tboSearchUWork.JoinDestPartsNo);
            }

            retstring += "ORDER BY TBO.ENTERPRISECODERF, TBO.EQUIPGENRECODERF, TBO.EQUIPNAMERF, TBO.CARINFOJOINDISPORDERRF, TBO.JOINDESTMAKERCDRF, TBO.JOINDESTPARTSNORF";
            
            return retstring;
        }
        # endregion

        # region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� TBOSearchUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="mode">mode</param>
        /// <returns>TBOSearchUWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        /// </remarks>
        private TBOSearchUWork CopyToTBOSearchUWorkFromReader(ref SqlDataReader myReader, int mode)
        {
            TBOSearchUWork tboSearchUWork = new TBOSearchUWork();

            this.CopyToTBOSearchUWorkFromReader(ref myReader, ref tboSearchUWork, mode);

            return tboSearchUWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� TBOSearchUWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="tboSearchUWork">TBOSearchUWork �I�u�W�F�N�g</param>
        /// <param name="mode">mode</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.11.17</br>
        /// </remarks>
        private void CopyToTBOSearchUWorkFromReader(ref SqlDataReader myReader, ref TBOSearchUWork tboSearchUWork, int mode)
        {
            if (myReader != null && tboSearchUWork != null)
            {
                # region �N���X�֊i�[
                tboSearchUWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                tboSearchUWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                tboSearchUWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                tboSearchUWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                tboSearchUWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                tboSearchUWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                tboSearchUWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                tboSearchUWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                tboSearchUWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                tboSearchUWork.EquipGenreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EQUIPGENRECODERF"));
                tboSearchUWork.EquipName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPNAMERF"));
                tboSearchUWork.CarInfoJoinDispOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CARINFOJOINDISPORDERRF"));
                tboSearchUWork.JoinDestMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("JOINDESTMAKERCDRF"));
                tboSearchUWork.JoinDestPartsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTPARTSNORF"));
                tboSearchUWork.JoinQty = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("JOINQTYRF"));
                tboSearchUWork.EquipSpecialNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EQUIPSPECIALNOTERF"));

                if (mode == 0)
                {
                    tboSearchUWork.JoinDestMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTMAKERNAMERF"));
                    tboSearchUWork.JoinDestGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("JOINDESTGOODSNAMERF"));
                }
                # endregion

            }
        }
        # endregion
    }
}
