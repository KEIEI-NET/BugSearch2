using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.LocalAccess
{
    /// <summary>
    /// �I�y���[�V�����}�X�^���[�J��DB�A�N�Z�X�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �I�y���[�V�����}�X�^���[�J��DB���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.07.18</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/02 ������ �Z�L�����e�B�Ǘ����i�̍��������ǑΉ�</br>
    /// <br></br>
    /// </remarks>
    public class OperationLcDB
    {
        /// <summary>
        /// �I�y���[�V�����}�X�^���[�J��DB�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        /// <br>Update Note: 2010/04/02 ������ �Z�L�����e�B�Ǘ����i�̍��������ǑΉ�</br>
        /// </remarks>
        public OperationLcDB()
        {
        }

        // ----------ADD 2010/04/02---------->>>>>
        #region [SearchAll]
        /// <summary>
        /// �I�y���[�V�����}�X�^���̑S���擾
        /// </summary>
        /// <param name="operationList">��������</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�y���[�V�����}�X�^���̑S���擾���s���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/04/02</br>
        public int SearchAll(ref object operationList, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList operationArray = operationList as ArrayList;
                if (operationArray == null)
                {
                    operationArray = new ArrayList();
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Search���s
                status = SearchAllProc(ref operationArray, readMode, logicalMode, ref sqlConnection);
                operationList = operationArray;
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.SearchAll", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �I�y���[�V�����}�X�^���̑S���擾(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="operationList">��������</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I�y���[�V�����}�X�^���̑S���擾���s���܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/04/02</br>
        private int SearchAllProc(ref ArrayList operationList, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //Select�R�}���h�̐���
                #region [SELECT��]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  OFFERDATERF" + Environment.NewLine;
                sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                sqlText += " ,CATEGORYNAMERF" + Environment.NewLine;
                sqlText += " ,CATEGORYDSPODRRF" + Environment.NewLine;
                sqlText += " ,PGIDRF" + Environment.NewLine;
                sqlText += " ,PGNAMERF" + Environment.NewLine;
                sqlText += " ,PGDSPODRRF" + Environment.NewLine;
                sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                sqlText += " ,OPERATIONNAMERF" + Environment.NewLine;
                sqlText += " ,OPERATIONDSPODRRF" + Environment.NewLine;
                sqlText += " FROM OPERATIONRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    operationList.Add(CopyToOperationWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "OperationLcDB.SearchAllProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.SearchAllProc", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
            }

            return status;
        }
        #endregion
        // ----------ADD 2010/04/02----------<<<<<
        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̃I�y���[�V�����}�X�^LC���LIST��߂��܂�
        /// </summary>
        /// <param name="operationList">��������</param>
        /// <param name="paraOperationObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃I�y���[�V�����}�X�^LC���LIST��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        public int Search(ref object operationList, object paraOperationObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (paraOperationObj == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList operationArray = operationList as ArrayList;
                if (operationArray == null)
                {
                    operationArray = new ArrayList();
                }

                Operation operationWork = paraOperationObj as Operation;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Search���s
                status = SearchProc(ref operationArray, operationWork, readMode, logicalMode, ref sqlConnection);
                operationList = operationArray;
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.Search", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃I�y���[�V�����}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="operationList">��������</param>
        /// <param name="operationWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃I�y���[�V�����}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        private int SearchProc(ref ArrayList operationList, Operation operationWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                //Select�R�}���h�̐���
                #region [SELECT��]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  OFFERDATERF" + Environment.NewLine;
                sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                sqlText += " ,CATEGORYNAMERF" + Environment.NewLine;
                sqlText += " ,CATEGORYDSPODRRF" + Environment.NewLine;
                sqlText += " ,PGIDRF" + Environment.NewLine;
                sqlText += " ,PGNAMERF" + Environment.NewLine;
                sqlText += " ,PGDSPODRRF" + Environment.NewLine;
                sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                sqlText += " ,OPERATIONNAMERF" + Environment.NewLine;
                sqlText += " ,OPERATIONDSPODRRF" + Environment.NewLine;
                sqlText += " FROM OPERATIONRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, operationWork, logicalMode);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    operationList.Add(CopyToOperationWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "OperationLcDB.SearchProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.SearchProc", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
            }

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̃I�y���[�V�����}�X�^LC��߂��܂�
        /// </summary>
        /// <param name="paraOperationObj">Operation�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃I�y���[�V�����}�X�^LC��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        public int Read(ref object paraOperationObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (paraOperationObj == null) return status;

                //�p�����[�^�̃L���X�g
                Operation operationWork = paraOperationObj as Operation;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Read���s
                status = ReadProc(ref operationWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.Read", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

        /// <summary>
        /// �w�肳�ꂽ�����̃I�y���[�V�����}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="operationWork">blGoodsCdUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃I�y���[�V�����}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        private int ReadProc(ref Operation operationWork, int readMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                //Select�R�}���h�̐���
                #region [SELECT��]
                string sqlText = string.Empty;
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "  OFFERDATERF" + Environment.NewLine;
                sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                sqlText += " ,CATEGORYNAMERF" + Environment.NewLine;
                sqlText += " ,CATEGORYDSPODRRF" + Environment.NewLine;
                sqlText += " ,PGIDRF" + Environment.NewLine;
                sqlText += " ,PGNAMERF" + Environment.NewLine;
                sqlText += " ,PGDSPODRRF" + Environment.NewLine;
                sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                sqlText += " ,OPERATIONNAMERF" + Environment.NewLine;
                sqlText += " ,OPERATIONDSPODRRF" + Environment.NewLine;
                sqlText += " FROM OPERATIONRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "     CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                #endregion

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))    
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                    SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                    SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);
                    findParaPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
                    findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        operationWork = CopyToOperationWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "OperationLcDB.ReadProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.ReadProc", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// �I�y���[�V�����}�X�^���[�J������ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="operationList">�ǉ��E�X�V����Operation�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationList �Ɋi�[����Ă���Operation����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        public int Write(ref object operationList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (operationList == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList paraList = operationList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    Operation operationWork = operationList as Operation;
                    paraList.Add(operationWork);
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //Write���s
                status = WriteProc(ref paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.Write", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// �I�y���[�V�����}�X�^���[�J������ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="operationList">�ǉ��E�X�V����Operation�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationList �Ɋi�[����Ă���Operation����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        private int WriteProc(ref ArrayList operationList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (operationList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < operationList.Count; i++)
                    {
                        Operation operationWork = operationList[i] as Operation;

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  OFFERDATERF" + Environment.NewLine;
                        sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                        sqlText += " ,CATEGORYNAMERF" + Environment.NewLine;
                        sqlText += " ,CATEGORYDSPODRRF" + Environment.NewLine;
                        sqlText += " ,PGIDRF" + Environment.NewLine;
                        sqlText += " ,PGNAMERF" + Environment.NewLine;
                        sqlText += " ,PGDSPODRRF" + Environment.NewLine;
                        sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                        sqlText += " ,OPERATIONNAMERF" + Environment.NewLine;
                        sqlText += " ,OPERATIONDSPODRRF" + Environment.NewLine;
                        sqlText += " FROM OPERATIONRF" + Environment.NewLine;
                        sqlText += " WHERE CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                        sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                        sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                        SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                        SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);
                        findParaPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
                        findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //Update�R�}���h�̐���
                            #region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE OPERATIONRF" + Environment.NewLine;
                            sqlText += " SET" + Environment.NewLine;
                            sqlText += "  OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                            sqlText += " ,CATEGORYCODERF=@CATEGORYCODE" + Environment.NewLine;
                            sqlText += " ,CATEGORYNAMERF=@CATEGORYNAME" + Environment.NewLine;
                            sqlText += " ,CATEGORYDSPODRRF=@CATEGORYDSPODR" + Environment.NewLine;
                            sqlText += " ,PGIDRF=@PGID" + Environment.NewLine;
                            sqlText += " ,PGNAMERF=@PGNAME" + Environment.NewLine;
                            sqlText += " ,PGDSPODRRF=@PGDSPODR" + Environment.NewLine;
                            sqlText += " ,OPERATIONCODERF=@OPERATIONCODE" + Environment.NewLine;
                            sqlText += " ,OPERATIONNAMERF=@OPERATIONNAME" + Environment.NewLine;
                            sqlText += " ,OPERATIONDSPODRRF=@OPERATIONDSPODR" + Environment.NewLine;
                            sqlText += " WHERE CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                            sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                            sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;
                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEY�R�}���h���Đݒ�
                            findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);
                            findParaPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
                            findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);
                        }
                        else
                        {
                            //Insert�R�}���h�̐���
                            #region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO OPERATIONRF" + Environment.NewLine;
                            sqlText += " (OFFERDATERF" + Environment.NewLine;
                            sqlText += " ,CATEGORYCODERF" + Environment.NewLine;
                            sqlText += " ,CATEGORYNAMERF" + Environment.NewLine;
                            sqlText += " ,CATEGORYDSPODRRF" + Environment.NewLine;
                            sqlText += " ,PGIDRF" + Environment.NewLine;
                            sqlText += " ,PGNAMERF" + Environment.NewLine;
                            sqlText += " ,PGDSPODRRF" + Environment.NewLine;
                            sqlText += " ,OPERATIONCODERF" + Environment.NewLine;
                            sqlText += " ,OPERATIONNAMERF" + Environment.NewLine;
                            sqlText += " ,OPERATIONDSPODRRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@OFFERDATE" + Environment.NewLine;
                            sqlText += " ,@CATEGORYCODE" + Environment.NewLine;
                            sqlText += " ,@CATEGORYNAME" + Environment.NewLine;
                            sqlText += " ,@CATEGORYDSPODR" + Environment.NewLine;
                            sqlText += " ,@PGID" + Environment.NewLine;
                            sqlText += " ,@PGNAME" + Environment.NewLine;
                            sqlText += " ,@PGDSPODR" + Environment.NewLine;
                            sqlText += " ,@OPERATIONCODE" + Environment.NewLine;
                            sqlText += " ,@OPERATIONNAME" + Environment.NewLine;
                            sqlText += " ,@OPERATIONDSPODR" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        # region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        SqlParameter paraCategoryCode = sqlCommand.Parameters.Add("@CATEGORYCODE", SqlDbType.Int);
                        SqlParameter paraCategoryName = sqlCommand.Parameters.Add("@CATEGORYNAME", SqlDbType.NVarChar);
                        SqlParameter paraCategoryDspOdr = sqlCommand.Parameters.Add("@CATEGORYDSPODR", SqlDbType.Int);
                        SqlParameter paraPgId = sqlCommand.Parameters.Add("@PGID", SqlDbType.NVarChar);
                        SqlParameter paraPgName = sqlCommand.Parameters.Add("@PGNAME", SqlDbType.NVarChar);
                        SqlParameter paraPgDspOdr = sqlCommand.Parameters.Add("@PGDSPODR", SqlDbType.Int);
                        SqlParameter paraOperationCode = sqlCommand.Parameters.Add("@OPERATIONCODE", SqlDbType.Int);
                        SqlParameter paraOperationName = sqlCommand.Parameters.Add("@OPERATIONNAME", SqlDbType.NVarChar);
                        SqlParameter paraOperationDspOdr = sqlCommand.Parameters.Add("@OPERATIONDSPODR", SqlDbType.Int);
                        # endregion

                        # region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraOfferDate.Value = SqlDataMediator.SqlSetInt32(operationWork.OfferDate);
                        paraCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);
                        paraCategoryName.Value = SqlDataMediator.SqlSetString(operationWork.CategoryName);
                        paraCategoryDspOdr.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryDspOdr);
                        paraPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
                        paraPgName.Value = SqlDataMediator.SqlSetString(operationWork.PgName);
                        paraPgDspOdr.Value = SqlDataMediator.SqlSetInt32(operationWork.PgDspOdr);
                        paraOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);
                        paraOperationName.Value = SqlDataMediator.SqlSetString(operationWork.OperationName);
                        paraOperationDspOdr.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationDspOdr);
                        # endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(operationWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "OperationLcDB.WriteProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.WriteProc", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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

            operationList = al;

            return status;
        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �I�y���[�V�����}�X�^���[�J�����𕨗��폜���܂�
        /// </summary>
        /// <param name="operationList">�����폜����Operation�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : Operation�̃L�[�l����v����Operation���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        public int Delete(object operationList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (operationList == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList paraList = operationList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    Operation operationWork = operationList as Operation;
                    paraList.Add(operationWork);
                }

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //�g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //Delete���s
                status = DeleteProc(paraList, ref sqlConnection, ref sqlTransaction);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.Delete", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            //�R�~�b�g
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            //���[���o�b�N
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
        /// �I�y���[�V�����}�X�^���[�J�����𕨗��폜���܂�
        /// </summary>
        /// <param name="operationList">Operation�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : OperationList �Ɋi�[����Ă���Operation���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        private int DeleteProc(ArrayList operationList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (operationList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < operationList.Count; i++)
                    {
                        Operation operationWork = operationList[i] as Operation;

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT OFFERDATERF" + Environment.NewLine;
                        sqlText += " FROM OPERATIONRF" + Environment.NewLine;
                        sqlText += " WHERE CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                        sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                        sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
                        SqlParameter findParaPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                        SqlParameter findParaOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);
                        findParaPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
                        findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //Delete�R�}���h�̐���
                            # region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM OPERATIONRF" + Environment.NewLine;
                            sqlText += " WHERE CATEGORYCODERF=@FINDCATEGORYCODE" + Environment.NewLine;
                            sqlText += " AND PGIDRF=@FINDPGID" + Environment.NewLine;
                            sqlText += " AND OPERATIONCODERF=@FINDOPERATIONCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            // KEY�R�}���h���Đݒ�
                            findParaCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);
                            findParaPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
                            findParaOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);
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
                status = WriteSQLErrorLog(ex, "OperationLcDB.DeleteProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "OperationLcDB.DeleteProc", 0);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        #endregion

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="operationWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, Operation operationWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE ";

            //�J�e�S���R�[�h
            retstring += "CATEGORYCODERF=@FINDCATEGORYCODE ";
            SqlParameter paraCategoryCode = sqlCommand.Parameters.Add("@FINDCATEGORYCODE", SqlDbType.Int);
            paraCategoryCode.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryCode);

            //�v���O�����h�c
            if (operationWork.PgId != "")
            {
                retstring += "AND PGIDRF=@FINDPGID ";
                SqlParameter paraPgId = sqlCommand.Parameters.Add("@FINDPGID", SqlDbType.NVarChar);
                paraPgId.Value = SqlDataMediator.SqlSetString(operationWork.PgId);
            }

            //�I�y���[�V�����R�[�h
            if (operationWork.OperationCode != -1)
            {
                retstring += "AND OPERATIONCODERF=@FINDOPERATIONCODE ";
                SqlParameter paraOperationCode = sqlCommand.Parameters.Add("@FINDOPERATIONCODE", SqlDbType.Int);
                paraOperationCode.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationCode);
            }

            //�񋟓��t
            if (operationWork.OfferDate != 0)
            {
                retstring += "AND OFFERDATERF=@FINDOFFERDATE ";
                SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int);
                paraOfferDate.Value = SqlDataMediator.SqlSetInt32(operationWork.OfferDate);
            }

            //�J�e�S������
            if (operationWork.CategoryName != "")
            {
                retstring += "AND CATEGORYNAMERF=@FINDCATEGORYNAME ";
                SqlParameter paraCategoryName = sqlCommand.Parameters.Add("@FINDCATEGORYNAME", SqlDbType.NVarChar);
                paraCategoryName.Value = SqlDataMediator.SqlSetString(operationWork.CategoryName);
            }

            //�J�e�S���\������
            if (operationWork.CategoryDspOdr != 0)
            {
                retstring += "AND CATEGORYDSPODRRF=@FINDCATEGORYDSPODR ";
                SqlParameter paraCategoryDspOdr = sqlCommand.Parameters.Add("@FINDCATEGORYDSPODR", SqlDbType.Int);
                paraCategoryDspOdr.Value = SqlDataMediator.SqlSetInt32(operationWork.CategoryDspOdr);
            }

            //�v���O��������
            if (operationWork.PgName != "")
            {
                retstring += "AND PGNAMERF=@FINDPGNAME ";
                SqlParameter paraPgName = sqlCommand.Parameters.Add("@FINDPGNAME", SqlDbType.NVarChar);
                paraPgName.Value = SqlDataMediator.SqlSetString(operationWork.PgName);
            }

            //�v���O�����\������
            if (operationWork.PgDspOdr != 0)
            {
                retstring += "AND PGDSPODRRF=@FINDPGDSPODR ";
                SqlParameter paraPgDspOdr = sqlCommand.Parameters.Add("@FINDPGDSPODR", SqlDbType.Int);
                paraPgDspOdr.Value = SqlDataMediator.SqlSetInt32(operationWork.PgDspOdr);
            }

            //�I�y���[�V��������
            if (operationWork.OperationName != "")
            {
                retstring += "AND OPERATIONNAMERF=@FINDOPERATIONNAME ";
                SqlParameter paraOperationName = sqlCommand.Parameters.Add("@FINDOPERATIONNAME", SqlDbType.NVarChar);
                paraOperationName.Value = SqlDataMediator.SqlSetString(operationWork.OperationName);
            }

            //�I�y���[�V�����\������
            if (operationWork.OperationDspOdr != 0)
            {
                retstring += "AND OPERATIONDSPODRRF=@FINDOPERATIONDSPODR ";
                SqlParameter paraOperationDspOdr = sqlCommand.Parameters.Add("@FINDOPERATIONDSPODR", SqlDbType.Int);
                paraOperationDspOdr.Value = SqlDataMediator.SqlSetInt32(operationWork.OperationDspOdr);
            }

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� Operation
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>OperationWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        /// </remarks>
        private Operation CopyToOperationWorkFromReader(ref SqlDataReader myReader)
        {
            Operation wkOperationWork = new Operation();

            #region �N���X�֊i�[
            wkOperationWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkOperationWork.CategoryCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYCODERF"));
            wkOperationWork.CategoryName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CATEGORYNAMERF"));
            wkOperationWork.CategoryDspOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CATEGORYDSPODRRF"));
            wkOperationWork.PgId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PGIDRF"));
            wkOperationWork.PgName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PGNAMERF"));
            wkOperationWork.PgDspOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PGDSPODRRF"));
            wkOperationWork.OperationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPERATIONCODERF"));
            wkOperationWork.OperationName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OPERATIONNAMERF"));
            wkOperationWork.OperationDspOdr = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPERATIONDSPODRRF"));
            #endregion

            return wkOperationWork;
        }
        #endregion

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection()
        {
            SqlConnection retSqlConnection = null;
            ClientSqlConnectionInfo clientSqlConnectionInfo = new ClientSqlConnectionInfo();
            string connectionText = clientSqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Local_OfferDB);
            if (connectionText == null || connectionText == "") return null;
            retSqlConnection = new SqlConnection(connectionText);
            return retSqlConnection;
        }
        #endregion

        #region [�G���[���O�o�͏���]
        private void WriteErrorLog(Exception ex, string errorText, int status)
        {
            string message = "";
            if (ex != null)
            {
                if (ex is SqlException)
                {
                    this.WriteSQLErrorLog((SqlException)ex, errorText, status);
                }
                else
                {
                    message = string.Concat(new object[] { "Index #", 0, "\nMessage: ", ex.Message, "\n", errorText, "\nSource: ", ex.Source, "\nStatus = ", status.ToString(), "\n" });
                    new ClientLogTextOut().Output(ex.Source, message, status, ex);
                }
            }
            else
            {
                new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, errorText, status);
            }
        }

        private int WriteSQLErrorLog(SqlException ex, string errorText, int status)
        {
            string message = "";
            for (int i = 0; i < ex.Errors.Count; i++)
            {
                object obj2 = message;
                message = string.Concat(new object[] { obj2, "Index #", i, "\nMessage: ", ex.Errors[i].Message, "\nLineNumber: ", ex.Errors[i].LineNumber, "\nSource: ", ex.Errors[i].Source, "\nProcedure: ", ex.Errors[i].Procedure, "\n" });
            }
            if (!errorText.Trim().Equals(""))
            {
                message = message + errorText + "\n";
            }
            message = message + "Status = " + status.ToString() + "\n";
            new ClientLogTextOut().Output(base.GetType().Assembly.GetName().Name, message, status);
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_DUPLICATE)
            {
                return (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
            }
            if (ex.Number == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
            {
                return (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT;
            }
            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
        }
        #endregion

    }
}
