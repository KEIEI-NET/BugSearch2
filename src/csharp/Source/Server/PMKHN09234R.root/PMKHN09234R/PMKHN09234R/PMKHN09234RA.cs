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
    /// BL�R�[�h�K�C�h�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23015�@�X�{ ��P</br>
    /// <br>Date       : 2008.09.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class BLCodeGuideDB : RemoteWithAppLockDB, IBLCodeGuideDB
    {
        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        /// </remarks>
        public BLCodeGuideDB()
            : base("PMKHN09236D", "Broadleaf.Application.Remoting.ParamData.BLCodeGuideWork", "BLCODEGUIDERF")
        {

        }

        #region [Read]
        /// <summary>
        /// �P���BL�R�[�h�K�C�h�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="bLCodeGuideObj">BLCodeGuideWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�̃L�[�l����v����BL�R�[�h�K�C�h�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        public int Read(ref object bLCodeGuideObj, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                BLCodeGuideWork bLCodeGuideWork = bLCodeGuideObj as BLCodeGuideWork;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Read(ref bLCodeGuideWork, readMode, ref sqlConnection, ref sqlTransaction);
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
        /// �P���BL�R�[�h�K�C�h�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="bLCodeGuideWork">BLCodeGuideWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�̃L�[�l����v����BL�R�[�h�K�C�h�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        public int Read(ref BLCodeGuideWork bLCodeGuideWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProc(ref bLCodeGuideWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �P���BL�R�[�h�K�C�h�}�X�^�����擾���܂��B
        /// </summary>
        /// <param name="bLCodeGuideWork">BLCodeGuideWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�̃L�[�l����v����BL�R�[�h�K�C�h�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        private int ReadProc(ref BLCodeGuideWork bLCodeGuideWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                #region [SELECT��]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,BLCODEDSPPAGERF" + Environment.NewLine;
                selectTxt += "  ,BLCODEDSPROWRF" + Environment.NewLine;
                selectTxt += "  ,BLCODEDSPCOLRF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSNAMERF" + Environment.NewLine;
                selectTxt += " FROM BLCODEGUIDERF" + Environment.NewLine;
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;
                #endregion  //[SELECT��]

                //Prameter�I�u�W�F�N�g�̍쐬
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                SqlParameter findParaBLCodeDspPage = sqlCommand.Parameters.Add("@FINDBLCODEDSPPAGE", SqlDbType.Int);
                SqlParameter findParaBLCodeDspRow = sqlCommand.Parameters.Add("@FINDBLCODEDSPROW", SqlDbType.Int);
                SqlParameter findParaBLCodeDspCol = sqlCommand.Parameters.Add("@FINDBLCODEDSPCOL", SqlDbType.Int);
                SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                //Parameter�I�u�W�F�N�g�֒l�ݒ�
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    this.CopyToBLCodeGuideWorkFromReader(ref myReader, ref bLCodeGuideWork);
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
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLCodeGuideDB.ReadProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        #endregion  //[Read]

        #region [Search]
        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="bLCodeGuideList">��������</param>
        /// <param name="bLCodeGuideObj">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�̃L�[�l����v����A�S�Ă�BL�R�[�h�K�C�h�}�X�^�����擾���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        public int Search(ref object bLCodeGuideList, object bLCodeGuideObj, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList bLCodeGuideArray = new ArrayList();

            try
            {
                BLCodeGuideWork bLCodeGuideWork = bLCodeGuideObj as BLCodeGuideWork;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                status = this.Search(ref bLCodeGuideArray, bLCodeGuideWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
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

            bLCodeGuideList = bLCodeGuideArray;

            return status;
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="bLCodeGuideWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�̃L�[�l����v����A�S�Ă�BL�R�[�h�K�C�h�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        public int Search(ref ArrayList bLCodeGuideList, BLCodeGuideWork bLCodeGuideWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.SearchProc(ref bLCodeGuideList, bLCodeGuideWork, readMode, logicalMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="bLCodeGuideWork">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�敪(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�̃L�[�l����v����A�S�Ă�BL�R�[�h�K�C�h�}�X�^��񂪊i�[����Ă��� ArrayList ���擾���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        private int SearchProc(ref ArrayList bLCodeGuideList, BLCodeGuideWork bLCodeGuideWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = string.Empty;
                sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                #region [SELECT��]
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,BLCODEDSPPAGERF" + Environment.NewLine;
                selectTxt += "  ,BLCODEDSPROWRF" + Environment.NewLine;
                selectTxt += "  ,BLCODEDSPCOLRF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,BLGOODSNAMERF" + Environment.NewLine;
                selectTxt += " FROM BLCODEGUIDERF" + Environment.NewLine;
                selectTxt += MakeWhereString(ref sqlCommand, bLCodeGuideWork, logicalMode);

                sqlCommand.CommandText = selectTxt;
                #endregion  //[SELECT��]

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    bLCodeGuideList.Add(this.CopyToBLCodeGuideWorkFromReader(ref myReader));
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLCodeGuideDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        #endregion  //[Search]

        #region [Write]
        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="bLCodeGuideList">�ǉ��E�X�V����BL�R�[�h�K�C�h�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideList �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        public int Write(ref object bLCodeGuideList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = bLCodeGuideList as ArrayList;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                //�g�����U�N�V�����J�n
                sqlTransaction = this.CreateTransaction(ref sqlConnection);

                //write���s
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
        /// BL�R�[�h�K�C�h�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="bLCodeGuideList">�ǉ��E�X�V����BL�R�[�h�K�C�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideList �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        public int Write(ref ArrayList bLCodeGuideList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteProc(ref bLCodeGuideList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="bLCodeGuideList">�ǉ��E�X�V����BL�R�[�h�K�C�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideList �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        private int WriteProc(ref ArrayList bLCodeGuideList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (bLCodeGuideList != null)
                {
                    string selectTxt = string.Empty;
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    for (int i = 0; i < bLCodeGuideList.Count; i++)
                    {
                        BLCodeGuideWork bLCodeGuideWork = bLCodeGuideList[i] as BLCodeGuideWork;

                        #region [SELECT��]
                        selectTxt = string.Empty;

                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " FROM BLCODEGUIDERF" + Environment.NewLine;
                        selectTxt += " WHERE" + Environment.NewLine;
                        selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                        selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;

                        sqlCommand.CommandText = selectTxt;
                        #endregion  //[SELECT��]

                        sqlCommand.Parameters.Clear();

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaBLCodeDspPage = sqlCommand.Parameters.Add("@FINDBLCODEDSPPAGE", SqlDbType.Int);
                        SqlParameter findParaBLCodeDspRow = sqlCommand.Parameters.Add("@FINDBLCODEDSPROW", SqlDbType.Int);
                        SqlParameter findParaBLCodeDspCol = sqlCommand.Parameters.Add("@FINDBLCODEDSPCOL", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                        findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                        findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                        findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //�X�V����

                            if (_updateDateTime != bLCodeGuideWork.UpdateDateTime)
                            {
                                if (bLCodeGuideWork.UpdateDateTime == DateTime.MinValue)
                                {
                                    //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                    status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                }
                                else
                                {
                                    //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                }

                                return status;
                            }

                            #region [UPDATE��]
                            selectTxt = string.Empty;

                            selectTxt += "UPDATE BLCODEGUIDERF SET" + Environment.NewLine;
                            selectTxt += "   CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,BLCODEDSPPAGERF=@BLCODEDSPPAGE" + Environment.NewLine;
                            selectTxt += "  ,BLCODEDSPROWRF=@BLCODEDSPROW" + Environment.NewLine;
                            selectTxt += "  ,BLCODEDSPCOLRF=@BLCODEDSPCOL" + Environment.NewLine;
                            selectTxt += "  ,BLGOODSCODERF=@BLGOODSCODE" + Environment.NewLine;
                            selectTxt += "  ,BLGOODSNAMERF=@BLGOODSNAME" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                            selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            #endregion  //[UPDATE��]

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                            findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                            findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                            findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bLCodeGuideWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (bLCodeGuideWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                return status;
                            }

                            #region [INSERT��]
                            selectTxt = string.Empty;

                            selectTxt += "INSERT INTO BLCODEGUIDERF" + Environment.NewLine;
                            selectTxt += " ( CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,BLCODEDSPPAGERF" + Environment.NewLine;
                            selectTxt += "  ,BLCODEDSPROWRF" + Environment.NewLine;
                            selectTxt += "  ,BLCODEDSPCOLRF" + Environment.NewLine;
                            selectTxt += "  ,BLGOODSCODERF" + Environment.NewLine;
                            selectTxt += "  ,BLGOODSNAMERF" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            selectTxt += " VALUES" + Environment.NewLine;
                            selectTxt += " ( @CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@BLCODEDSPPAGE" + Environment.NewLine;
                            selectTxt += "  ,@BLCODEDSPROW" + Environment.NewLine;
                            selectTxt += "  ,@BLCODEDSPCOL" + Environment.NewLine;
                            selectTxt += "  ,@BLGOODSCODE" + Environment.NewLine;
                            selectTxt += "  ,@BLGOODSNAME" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            #endregion  //[INSERT��]

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bLCodeGuideWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        if (!myReader.IsClosed)
                        {
                            myReader.Close();
                        }

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                        SqlParameter paraBLCodeDspPage = sqlCommand.Parameters.Add("@BLCODEDSPPAGE", SqlDbType.Int);
                        SqlParameter paraBLCodeDspRow = sqlCommand.Parameters.Add("@BLCODEDSPROW", SqlDbType.Int);
                        SqlParameter paraBLCodeDspCol = sqlCommand.Parameters.Add("@BLCODEDSPCOL", SqlDbType.Int);
                        SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                        SqlParameter paraBLGoodsName = sqlCommand.Parameters.Add("@BLGOODSNAME", SqlDbType.NVarChar);
                        #endregion  //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bLCodeGuideWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bLCodeGuideWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(bLCodeGuideWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                        paraBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                        paraBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                        paraBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                        paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);
                        paraBLGoodsName.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.BLGoodsName);
                        #endregion  //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)

                        sqlCommand.ExecuteNonQuery();
                        al.Add(bLCodeGuideWork);
                    }
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLCodeGuideDB.WriteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

            bLCodeGuideList = al;

            return status;
        }
        #endregion  //[Write]

        #region [Delete]
        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="bLCodeGuideList">�����폜����BL�R�[�h�K�C�h�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : BL�R�[�h�K�C�h�}�X�^�̃L�[�l����v����BL�R�[�h�K�C�h�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        public int Delete(object bLCodeGuideList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = bLCodeGuideList as ArrayList;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                //�g�����U�N�V�����J�n
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
        /// BL�R�[�h�K�C�h�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideList �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        public int Delete(ArrayList bLCodeGuideList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteProc(bLCodeGuideList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="bLCodeGuideList">BL�R�[�h�K�C�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideList �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^���𕨗��폜���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        private int DeleteProc(ArrayList bLCodeGuideList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                if (bLCodeGuideList != null)
                {
                    string selectTxt = string.Empty;
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    for (int i = 0; i < bLCodeGuideList.Count; i++)
                    {
                        BLCodeGuideWork bLCodeGuideWork = bLCodeGuideList[i] as BLCodeGuideWork;

                        #region [SELECT��]
                        selectTxt = string.Empty;

                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += " FROM BLCODEGUIDERF" + Environment.NewLine;
                        selectTxt += " WHERE" + Environment.NewLine;
                        selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                        selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        
                        sqlCommand.CommandText = selectTxt;
                        #endregion  //[SELECT��]

                        sqlCommand.Parameters.Clear();

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaBLCodeDspPage = sqlCommand.Parameters.Add("@FINDBLCODEDSPPAGE", SqlDbType.Int);
                        SqlParameter findParaBLCodeDspRow = sqlCommand.Parameters.Add("@FINDBLCODEDSPROW", SqlDbType.Int);
                        SqlParameter findParaBLCodeDspCol = sqlCommand.Parameters.Add("@FINDBLCODEDSPCOL", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                        findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                        findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                        findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //�X�V����

                            if (_updateDateTime != bLCodeGuideWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            #region [DELETE��]
                            selectTxt = string.Empty;

                            selectTxt += "DELETE" + Environment.NewLine;
                            selectTxt += " FROM BLCODEGUIDERF" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                            selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                            
                            sqlCommand.CommandText = selectTxt;
                            #endregion  //[DELETE��]

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                            findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                            findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                            findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);
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
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLCodeGuideDB.DeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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
        #endregion  //[DELETE]

        #region [LogicalDelete]
        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^����_���폜���܂��B
        /// </summary>
        /// <param name="bLCodeGuideList">�_���폜����BL�R�[�h�K�C�h�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        public int LogicalDelete(ref object bLCodeGuideList)
        {
            return this.LogicalDelete(ref bLCodeGuideList, 0);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^���̘_���폜���������܂��B
        /// </summary>
        /// <param name="bLCodeGuideList">�_���폜����������BL�R�[�h�K�C�h�}�X�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        public int RevivalLogicalDelete(ref object bLCodeGuideList)
        {
            return this.LogicalDelete(ref bLCodeGuideList, 1);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="bLCodeGuideList">�_���폜�𑀍삷��BL�R�[�h�K�C�h�}�X�^���</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        private int LogicalDelete(ref object bLCodeGuideList, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = bLCodeGuideList as ArrayList;

                //�R�l�N�V��������
                sqlConnection = this.CreateSqlConnection(true);

                //�g�����U�N�V�����J�n
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
        /// BL�R�[�h�K�C�h�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="bLCodeGuideList">�_���폜�𑀍삷��BL�R�[�h�K�C�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        public int LogicalDelete(ref ArrayList bLCodeGuideList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteProc(ref bLCodeGuideList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�}�X�^���̘_���폜�𑀍삵�܂��B
        /// </summary>
        /// <param name="bLCodeGuideList">�_���폜�𑀍삷��BL�R�[�h�K�C�h�}�X�^�����i�[���� ArrayList</param>
        /// <param name="procMode">0:�_���폜 1:����</param>
        /// <param name="sqlConnection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="sqlTransaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : bLCodeGuideWork �Ɋi�[����Ă���BL�R�[�h�K�C�h�}�X�^���̘_���폜�𑀍삵�܂��B</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        private int LogicalDeleteProc(ref ArrayList bLCodeGuideList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int logicalDelCd = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();

            try
            {
                if (bLCodeGuideList != null)
                {
                    string selectTxt = string.Empty;
                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    for (int i = 0; i < bLCodeGuideList.Count; i++)
                    {
                        BLCodeGuideWork bLCodeGuideWork = bLCodeGuideList[i] as BLCodeGuideWork;

                        #region [SELECT��]
                        selectTxt = string.Empty;

                        selectTxt += "SELECT" + Environment.NewLine;
                        selectTxt += "   UPDATEDATETIMERF" + Environment.NewLine;
                        selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                        selectTxt += " FROM BLCODEGUIDERF" + Environment.NewLine;
                        selectTxt += " WHERE" + Environment.NewLine;
                        selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                        selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                        selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;
                        
                        sqlCommand.CommandText = selectTxt;
                        #endregion  //[SELECT��]

                        sqlCommand.Parameters.Clear();

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaBLCodeDspPage = sqlCommand.Parameters.Add("@FINDBLCODEDSPPAGE", SqlDbType.Int);
                        SqlParameter findParaBLCodeDspRow = sqlCommand.Parameters.Add("@FINDBLCODEDSPROW", SqlDbType.Int);
                        SqlParameter findParaBLCodeDspCol = sqlCommand.Parameters.Add("@FINDBLCODEDSPCOL", SqlDbType.Int);
                        SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                        findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                        findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                        findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                        findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);

                        myReader = sqlCommand.ExecuteReader();

                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //�X�V����

                            if (_updateDateTime != bLCodeGuideWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                return status;
                            }

                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            #region [UPDATE��]
                            selectTxt = string.Empty;

                            selectTxt += "UPDATE BLCODEGUIDERF SET" + Environment.NewLine;
                            selectTxt += "   UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " WHERE" + Environment.NewLine;
                            selectTxt += "      ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPROWRF=@FINDBLCODEDSPROW" + Environment.NewLine;
                            selectTxt += "  AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL" + Environment.NewLine;
                            selectTxt += "  AND BLGOODSCODERF=@FINDBLGOODSCODE" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;
                            #endregion  //[UPDATE��]

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
                            findParaBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
                            findParaBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
                            findParaBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
                            findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);

                            // �X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)bLCodeGuideWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
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

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;         //���ɍ폜�ς݂̏ꍇ����
                                return status;
                            }
                            else if (logicalDelCd == 0) bLCodeGuideWork.LogicalDeleteCode = 1;  //�_���폜�t���O���Z�b�g
                            else bLCodeGuideWork.LogicalDeleteCode = 3;                         //���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1)
                            {
                                bLCodeGuideWork.LogicalDeleteCode = 0;                          //�_���폜�t���O������
                            }
                            else
                            {
                                if (logicalDelCd == 0)
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                }
                                else
                                {
                                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;  //���S�폜�̓f�[�^�Ȃ���߂�
                                }

                                return status;
                            }
                        }

                        //Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(bLCodeGuideWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(bLCodeGuideWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "BLCodeGuideDB.LogicalDeleteProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

            bLCodeGuideList = al;

            return status;
        }
        #endregion  //[LogicalDelete]

        #region [Where���쐬����]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="bLCodeGuideWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, BLCodeGuideWork bLCodeGuideWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string wkstring = "";
            string retstring = " WHERE" + Environment.NewLine;;

            //��ƃR�[�h
            retstring += " ENTERPRISECODERF=@FINDENTERPRISECODE"  + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.EnterpriseCode);

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
                (logicalMode == ConstantManagement.LogicalMode.GetData1)||
                (logicalMode == ConstantManagement.LogicalMode.GetData2)||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = " AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01)||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = " AND LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
            }

            if(wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            //���_�R�[�h
            if (bLCodeGuideWork.SectionCode != "")
            {
                retstring += " AND SECTIONCODERF=@FINDSECTIONCODE";
                SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                paraSectionCode.Value = SqlDataMediator.SqlSetString(bLCodeGuideWork.SectionCode);
            }

            //BL�R�[�h�\����
            if (bLCodeGuideWork.BLCodeDspPage != 0)
            {
                retstring += " AND BLCODEDSPPAGERF=@FINDBLCODEDSPPAGE";
                SqlParameter paraBLCodeDspPage = sqlCommand.Parameters.Add("@FINDBLCODEDSPPAGE", SqlDbType.Int);
                paraBLCodeDspPage.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspPage);
            }

            //BL�R�[�h�\���s
            if (bLCodeGuideWork.BLCodeDspRow != 0)
            {
                retstring += " AND BLCODEDSPROWRF=@FINDBLCODEDSPROW";
                SqlParameter paraBLCodeDspRow = sqlCommand.Parameters.Add("@FINDBLCODEDSPROW", SqlDbType.Int);
                paraBLCodeDspRow.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspRow);
            }

            //BL�R�[�h�\����
            if (bLCodeGuideWork.BLCodeDspCol != 0)
            {
                retstring += " AND BLCODEDSPCOLRF=@FINDBLCODEDSPCOL";
                SqlParameter paraBLCodeDspCol = sqlCommand.Parameters.Add("@FINDBLCODEDSPCOL", SqlDbType.Int);
                paraBLCodeDspCol.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLCodeDspCol);
            }

            //BL���i�R�[�h
            if (bLCodeGuideWork.BLGoodsCode != 0)
            {
                retstring += " AND BLGOODSCODERF=@FINDBLGOODSCODE";
                SqlParameter paraBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(bLCodeGuideWork.BLGoodsCode);
            }
            #endregion  //WHERE���쐬

            return retstring;
        }
        #endregion  //[Where���쐬����]

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� BLCodeGuideWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>BLCodeGuideWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        /// </remarks>
        private BLCodeGuideWork CopyToBLCodeGuideWorkFromReader(ref SqlDataReader myReader)
        {
            BLCodeGuideWork bLCodeGuideWork = new BLCodeGuideWork();

            this.CopyToBLCodeGuideWorkFromReader(ref myReader, ref bLCodeGuideWork);

            return bLCodeGuideWork;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� BLCodeGuideWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="bLCodeGuideWork">BLCodeGuideWork �I�u�W�F�N�g</param>
        /// <returns>void</returns>
        /// <remarks>
        /// <br>Programmer : 23015�@�X�{ ��P</br>
        /// <br>Date       : 2008.09.26</br>
        /// </remarks>
        private void CopyToBLCodeGuideWorkFromReader(ref SqlDataReader myReader, ref BLCodeGuideWork bLCodeGuideWork)
        {
            if (myReader != null && bLCodeGuideWork != null)
            {
                #region �N���X�֊i�[
                bLCodeGuideWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                bLCodeGuideWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                bLCodeGuideWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                bLCodeGuideWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                bLCodeGuideWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                bLCodeGuideWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                bLCodeGuideWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                bLCodeGuideWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                bLCodeGuideWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                bLCodeGuideWork.BLCodeDspPage = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCODEDSPPAGERF"));
                bLCodeGuideWork.BLCodeDspRow = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCODEDSPROWRF"));
                bLCodeGuideWork.BLCodeDspCol = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLCODEDSPCOLRF"));
                bLCodeGuideWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                bLCodeGuideWork.BLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSNAMERF"));
                #endregion  //�N���X�֊i�[
            }
        }
        #endregion  //[�N���X�i�[����]
    }
}
