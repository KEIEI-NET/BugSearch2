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
    /// �������x���}�X�^���[�J��DB�A�N�Z�X�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������x���}�X�^���[�J��DB���f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.07.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    public class AuthorityLevelLcDB
    {
        /// <summary>
        /// �������x���}�X�^���[�J��DB�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        /// </remarks>
        public AuthorityLevelLcDB()
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̌������x���}�X�^LC���LIST��߂��܂�
        /// </summary>
        /// <param name="authorityLevelList">��������</param>
        /// <param name="paraAuthorityLevelObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌������x���}�X�^LC���LIST��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        public int Search(ref object authorityLevelList, object paraAuthorityLevelObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (paraAuthorityLevelObj == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList authorityLevelArray = authorityLevelList as ArrayList;
                if (authorityLevelArray == null)
                {
                    authorityLevelArray = new ArrayList();
                }

                AuthorityLevel authorityLevelWork = paraAuthorityLevelObj as AuthorityLevel;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Search���s
                status = SearchProc(ref authorityLevelArray, authorityLevelWork, readMode, logicalMode, ref sqlConnection);
                authorityLevelList = authorityLevelArray;
                return status;
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AuthorityLevelLcDB.Search", 0);
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
        /// �w�肳�ꂽ�����̌������x���}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="authorityLevelList">��������</param>
        /// <param name="authorityLevelWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌������x���}�X�^LC���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        private int SearchProc(ref ArrayList authorityLevelList, AuthorityLevel authorityLevelWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
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
                sqlText += " ,AUTHORITYLEVELDIVRF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVELCDRF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVELNMRF" + Environment.NewLine;
                sqlText += " FROM AUTHORITYLEVELRF" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, authorityLevelWork, logicalMode);
                #endregion

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    authorityLevelList.Add(CopyToAuthorityLevelWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AuthorityLevelLcDB.SearchProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AuthorityLevelLcDB.SearchProc", 0);
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
        /// �w�肳�ꂽ�����̌������x���}�X�^LC��߂��܂�
        /// </summary>
        /// <param name="paraAuthorityLevelObj">AuthorityLevel�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌������x���}�X�^LC��߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        public int Read(ref object paraAuthorityLevelObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (paraAuthorityLevelObj == null) return status;

                //�p�����[�^�̃L���X�g
                AuthorityLevel authorityLevelWork = paraAuthorityLevelObj as AuthorityLevel;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                //Read���s
                status = ReadProc(ref authorityLevelWork, readMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AuthorityLevelLcDB.Read", 0);
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
        /// �w�肳�ꂽ�����̌������x���}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="authorityLevelWork">blGoodsCdUWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̌������x���}�X�^LC��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        private int ReadProc(ref AuthorityLevel authorityLevelWork, int readMode, ref SqlConnection sqlConnection)
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
                sqlText += " ,AUTHORITYLEVELDIVRF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVELCDRF" + Environment.NewLine;
                sqlText += " ,AUTHORITYLEVELNMRF" + Environment.NewLine;
                sqlText += " FROM AUTHORITYLEVELRF" + Environment.NewLine;
                sqlText += " WHERE" + Environment.NewLine;
                sqlText += "     AUTHORITYLEVELDIVRF=@FINDAUTHORITYLEVELDIV" + Environment.NewLine;
                sqlText += " AND AUTHORITYLEVELCDRF=@FINDAUTHORITYLEVELCD" + Environment.NewLine;
                #endregion

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaAuthorityLevelDiv = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELDIV", SqlDbType.Int);
                    SqlParameter findParaAuthorityLevelCd = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELCD", SqlDbType.Int);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);
                    findParaAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    
                    if (myReader.Read())
                    {
                        authorityLevelWork = CopyToAuthorityLevelWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AuthorityLevelLcDB.ReadProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AuthorityLevelLcDB.ReadProc", 0);
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
        /// �������x���}�X�^���[�J������ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="authorityLevelList">�ǉ��E�X�V����AuthorityLevel�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : AuthorityLevelList �Ɋi�[����Ă���AuthorityLevel����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        public int Write(ref object authorityLevelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (authorityLevelList == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList paraList = authorityLevelList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    AuthorityLevel authorityLevelWork = authorityLevelList as AuthorityLevel;
                    paraList.Add(authorityLevelWork);
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
                WriteErrorLog(ex, "AuthorityLevelLcDB.Write", 0);
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
        /// �������x���}�X�^���[�J������ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="authorityLevelList">�ǉ��E�X�V����AuthorityLevel�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : AuthorityLevelList �Ɋi�[����Ă���AuthorityLevel����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        private int WriteProc(ref ArrayList authorityLevelList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (authorityLevelList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < authorityLevelList.Count; i++)
                    {
                        AuthorityLevel authorityLevelWork = authorityLevelList[i] as AuthorityLevel;

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  OFFERDATERF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVELDIVRF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVELCDRF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVELNMRF" + Environment.NewLine;
                        sqlText += " FROM AUTHORITYLEVELRF" + Environment.NewLine;
                        sqlText += " WHERE" + Environment.NewLine;
                        sqlText += "     AUTHORITYLEVELDIVRF=@FINDAUTHORITYLEVELDIV" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVELCDRF=@FINDAUTHORITYLEVELCD" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        //Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaAuthorityLevelDiv = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELDIV", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevelCd = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELCD", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);
                        findParaAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //Update�R�}���h�̐���
                            #region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE AUTHORITYLEVELRF" + Environment.NewLine;
                            sqlText += " SET" + Environment.NewLine;
                            sqlText += "  OFFERDATERF=@OFFERDATE" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVELDIVRF=@AUTHORITYLEVELDIV" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVELCDRF=@AUTHORITYLEVELCD" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVELNMRF=@AUTHORITYLEVELNM" + Environment.NewLine;
                            sqlText += " WHERE AUTHORITYLEVELDIVRF=@FINDAUTHORITYLEVELDIV" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVELCDRF=@FINDAUTHORITYLEVELCD" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEY�R�}���h���Đݒ�
                            findParaAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);
                            findParaAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);
                        }
                        else
                        {
                            //Insert�R�}���h�̐���
                            #region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO AUTHORITYLEVELRF" + Environment.NewLine;
                            sqlText += " (OFFERDATERF" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVELDIVRF" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVELCDRF" + Environment.NewLine;
                            sqlText += " ,AUTHORITYLEVELNMRF" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;
                            sqlText += " VALUES" + Environment.NewLine;
                            sqlText += " (@OFFERDATE" + Environment.NewLine;
                            sqlText += " ,@AUTHORITYLEVELDIV" + Environment.NewLine;
                            sqlText += " ,@AUTHORITYLEVELCD" + Environment.NewLine;
                            sqlText += " ,@AUTHORITYLEVELNM" + Environment.NewLine;
                            sqlText += " )" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@OFFERDATE", SqlDbType.Int);
                        SqlParameter paraAuthorityLevelDiv = sqlCommand.Parameters.Add("@AUTHORITYLEVELDIV", SqlDbType.Int);
                        SqlParameter paraAuthorityLevelCd = sqlCommand.Parameters.Add("@AUTHORITYLEVELCD", SqlDbType.Int);
                        SqlParameter paraAuthorityLevelNm = sqlCommand.Parameters.Add("@AUTHORITYLEVELNM", SqlDbType.NVarChar);
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraOfferDate.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.OfferDate);
                        paraAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);
                        paraAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);
                        paraAuthorityLevelNm.Value = SqlDataMediator.SqlSetString(authorityLevelWork.AuthorityLevelNm);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(authorityLevelWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                status = WriteSQLErrorLog(ex, "AuthorityLevelLcDB.WriteProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AuthorityLevelLcDB.WriteProc", 0);
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

            authorityLevelList = al;

            return status;
        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �������x���}�X�^���[�J�����𕨗��폜���܂�
        /// </summary>
        /// <param name="authorityLevelList">�����폜����AuthorityLevel�����܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : AuthorityLevel�̃L�[�l����v����AuthorityLevel���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        public int Delete(object authorityLevelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�`�F�b�N
                if (authorityLevelList == null) return status;

                //�p�����[�^�̃L���X�g
                ArrayList paraList = authorityLevelList as ArrayList;
                if (paraList == null)
                {
                    paraList = new ArrayList();
                    AuthorityLevel authorityLevelWork = authorityLevelList as AuthorityLevel;
                    paraList.Add(authorityLevelWork);
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
                WriteErrorLog(ex, "AuthorityLevelLcDB.Delete", 0);
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
        /// �������x���}�X�^���[�J�����𕨗��폜���܂�
        /// </summary>
        /// <param name="authorityLevelList">AuthorityLevel�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : AuthorityLevelList �Ɋi�[����Ă���AuthorityLevel���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        private int DeleteProc(ArrayList authorityLevelList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (authorityLevelList != null)
                {
                    string sqlText = string.Empty;
                    sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

                    for (int i = 0; i < authorityLevelList.Count; i++)
                    {
                        AuthorityLevel authorityLevelWork = authorityLevelList[i] as AuthorityLevel;

                        //Select�R�}���h�̐���
                        #region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  OFFERDATERF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVELDIVRF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVELCDRF" + Environment.NewLine;
                        sqlText += " ,AUTHORITYLEVELNMRF" + Environment.NewLine;
                        sqlText += " FROM AUTHORITYLEVELRF" + Environment.NewLine;
                        sqlText += " WHERE" + Environment.NewLine;
                        sqlText += "     AUTHORITYLEVELDIVRF=@FINDAUTHORITYLEVELDIV" + Environment.NewLine;
                        sqlText += " AND AUTHORITYLEVELCDRF=@FINDAUTHORITYLEVELCD" + Environment.NewLine;

                        sqlCommand.CommandText = sqlText;
                        #endregion

                        // Prameter�I�u�W�F�N�g�̍쐬
                        sqlCommand.Parameters.Clear();
                        SqlParameter findParaAuthorityLevelDiv = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELDIV", SqlDbType.Int);
                        SqlParameter findParaAuthorityLevelCd = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELCD", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);
                        findParaAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //Delete�R�}���h�̐���
                            #region [DELETE��]
                            sqlText = string.Empty;
                            sqlText += "DELETE" + Environment.NewLine;
                            sqlText += " FROM AUTHORITYLEVELRF" + Environment.NewLine;
                            sqlText += " WHERE" + Environment.NewLine;
                            sqlText += "     AUTHORITYLEVELDIVRF=@FINDAUTHORITYLEVELDIV" + Environment.NewLine;
                            sqlText += " AND AUTHORITYLEVELCDRF=@FINDAUTHORITYLEVELCD" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            #endregion

                            //KEY�R�}���h���Đݒ�
                            findParaAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);
                            findParaAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
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
                status = WriteSQLErrorLog(ex, "AuthorityLevelLcDB.DeleteProc", 0);
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex, "AuthorityLevelLcDB.DeleteProc", 0);
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
        /// <param name="authorityLevelWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, AuthorityLevel authorityLevelWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE ";

            //�������x���敪
            retstring += "AUTHORITYLEVELDIVRF=@FINDAUTHORITYLEVELDIV ";
            SqlParameter paraAuthorityLevelDiv = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELDIV", SqlDbType.Int);
            paraAuthorityLevelDiv.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelDiv);

            //�������x���R�[�h
            if (authorityLevelWork.AuthorityLevelCd != 0)
            {
                retstring += "AND AUTHORITYLEVELCDRF=@FINDAUTHORITYLEVELCD ";
                SqlParameter paraAuthorityLevelCd = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELCD", SqlDbType.Int);
                paraAuthorityLevelCd.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.AuthorityLevelCd);
            }

            //�񋟓��t
            if (authorityLevelWork.OfferDate != 0)
            {
                retstring += "AND OFFERDATERF=@FINDOFFERDATE ";
                SqlParameter paraOfferDate = sqlCommand.Parameters.Add("@FINDOFFERDATE", SqlDbType.Int);
                paraOfferDate.Value = SqlDataMediator.SqlSetInt32(authorityLevelWork.OfferDate);
            }

            //�������x������
            if (authorityLevelWork.AuthorityLevelNm != "")
            {
                retstring += "AND AUTHORITYLEVELNMRF=@FINDAUTHORITYLEVELNM ";
                SqlParameter paraAuthorityLevelNm = sqlCommand.Parameters.Add("@FINDAUTHORITYLEVELNM", SqlDbType.NVarChar);
                paraAuthorityLevelNm.Value = SqlDataMediator.SqlSetString(authorityLevelWork.AuthorityLevelNm);
            }

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� AuthorityLevel
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>AuthorityLevelWork</returns>
        /// <remarks>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.18</br>
        /// </remarks>
        private AuthorityLevel CopyToAuthorityLevelWorkFromReader(ref SqlDataReader myReader)
        {
            AuthorityLevel wkAuthorityLevelWork = new AuthorityLevel();

            #region �N���X�֊i�[
            wkAuthorityLevelWork.OfferDate = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OFFERDATERF"));
            wkAuthorityLevelWork.AuthorityLevelDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVELDIVRF"));
            wkAuthorityLevelWork.AuthorityLevelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTHORITYLEVELCDRF"));
            wkAuthorityLevelWork.AuthorityLevelNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AUTHORITYLEVELNMRF"));
            #endregion

            return wkAuthorityLevelWork;
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
