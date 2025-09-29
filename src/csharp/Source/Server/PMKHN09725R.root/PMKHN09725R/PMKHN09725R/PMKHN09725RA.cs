//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ���[���O���[�v���̐ݒ�}�X�^                    //
//                      �����[�g�I�u�W�F�N�g                            //
//                  :   PMKHN09725R.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting                  //
// Programmer       :   30746 ���� ��                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

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
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���[���O���[�v���̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30746 ���� ��</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class RoleGroupNameStDB : RemoteDB, IRoleGroupNameStDB
    {
        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public RoleGroupNameStDB()
            : base("PMKHN09727D", "Broadleaf.Application.Remoting.ParamData.RoleGroupNameStWork", "ROLEGROUPNAMESTRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="roleGroupNameStWork">��������</param>
        /// <param name="pararoleGroupNameStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int Search(out object roleGroupNameStWork, object pararoleGroupNameStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            roleGroupNameStWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchRoleGroupNameStProc(out roleGroupNameStWork, pararoleGroupNameStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RoleGroupNameStDB.Search");
                roleGroupNameStWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objroleGroupNameStWork">��������</param>
        /// <param name="pararoleGroupNameStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int SearchRoleGroupNameStProc(out object objroleGroupNameStWork, object pararoleGroupNameStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            RoleGroupNameStWork roleGroupNameStWork = null;

            ArrayList roleGroupNameStWorkList = pararoleGroupNameStWork as ArrayList;
            if (roleGroupNameStWorkList == null)
            {
                roleGroupNameStWork = pararoleGroupNameStWork as RoleGroupNameStWork;
            }
            else
            {
                if (roleGroupNameStWorkList.Count > 0)
                    roleGroupNameStWork = roleGroupNameStWorkList[0] as RoleGroupNameStWork;
            }

            int status = SearchRoleGroupNameStProc(out roleGroupNameStWorkList, roleGroupNameStWork, readMode, logicalMode, ref sqlConnection);
            objroleGroupNameStWork = roleGroupNameStWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">��������</param>
        /// <param name="roleGroupNameStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int SearchRoleGroupNameStProc(out ArrayList roleGroupNameStWorkList, RoleGroupNameStWork roleGroupNameStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchRoleGroupNameStProcProc(out roleGroupNameStWorkList, roleGroupNameStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">��������</param>
        /// <param name="roleGroupNameStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private int SearchRoleGroupNameStProcProc(out ArrayList roleGroupNameStWorkList, RoleGroupNameStWork roleGroupNameStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT��
                selectTxt += "SELECT  CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,   FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "    ,   UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,   UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "    ,   UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "    ,   LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "    ,   ROLEGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,   ROLEGROUPNAMERF" + Environment.NewLine;
                selectTxt += "FROM    ROLEGRPNAMESTRF" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, roleGroupNameStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToRoleGroupNameStWorkFromReader(ref myReader));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            roleGroupNameStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">RoleGroupNameStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                RoleGroupNameStWork roleGroupNameStWork = new RoleGroupNameStWork();

                // XML�̓ǂݍ���
                roleGroupNameStWork = (RoleGroupNameStWork)XmlByteSerializer.Deserialize(parabyte, typeof(RoleGroupNameStWork));
                if (roleGroupNameStWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref roleGroupNameStWork, readMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(roleGroupNameStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RoleGroupNameStDB.Read");
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
        /// �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="roleGroupNameStWork">RoleGroupNameStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int ReadProc(ref RoleGroupNameStWork roleGroupNameStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref roleGroupNameStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="roleGroupNameStWork">RoleGroupNameStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��[���O���[�v���̐ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private int ReadProcProc(ref RoleGroupNameStWork roleGroupNameStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            try
            {
                string selectTxt = string.Empty;

                #region SELECT��
                selectTxt += "SELECT  CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,   FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "    ,   UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,   UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "    ,   UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "    ,   LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "    ,   ROLEGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,   ROLEGROUPNAMERF" + Environment.NewLine;
                selectTxt += "FROM    ROLEGRPNAMESTRF" + Environment.NewLine;
                selectTxt += "WHERE   ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND   ROLEGROUPCODERF  = @FINDROLEGROUPCODE" + Environment.NewLine;
                #endregion

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // ��ƃR�[�h
                    SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ���[���O���[�v�R�[�h

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);            // ��ƃR�[�h
                    findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);               // ���[���O���[�v�R�[�h

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        roleGroupNameStWork = CopyToRoleGroupNameStWorkFromReader(ref myReader);
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="roleGroupNameStWork">RoleGroupNameStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int Write(ref object roleGroupNameStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(roleGroupNameStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteRoleGroupNameStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                RoleGroupNameStWork paraWork = paraList[0] as RoleGroupNameStWork;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                roleGroupNameStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RoleGroupNameStDB.Write(ref object roleGroupNameStWork)");
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
        /// ���[���O���[�v���̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int WriteRoleGroupNameStProc(ref ArrayList roleGroupNameStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteRoleGroupNameStProcProc(ref roleGroupNameStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private int WriteRoleGroupNameStProcProc(ref ArrayList roleGroupNameStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (roleGroupNameStWorkList != null)
                {
                    foreach (RoleGroupNameStWork roleGroupNameStWork in roleGroupNameStWorkList)
                    {
                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM ROLEGRPNAMESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // ��ƃR�[�h
                        SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ���[���O���[�v�R�[�h

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);            // ��ƃR�[�h
                        findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);               // ���[���O���[�v�R�[�h

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //�X�V����
                            if (_updateDateTime != roleGroupNameStWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (roleGroupNameStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �X�V����SQL������
                            string sqlText = string.Empty;
                            sqlText += "UPDATE  ROLEGRPNAMESTRF" + Environment.NewLine;
                            sqlText += "SET     CREATEDATETIMERF    = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   UPDATEDATETIMERF    = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   ENTERPRISECODERF    = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,   FILEHEADERGUIDRF    = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,   UPDEMPLOYEECODERF   = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID1RF    = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID2RF    = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,   LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,   ROLEGROUPCODERF     = @ROLEGROUPCODE" + Environment.NewLine;
                            sqlText += "    ,   ROLEGROUPNAMERF     = @ROLEGROUPNAME" + Environment.NewLine;
                            sqlText += "WHERE   ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND   ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);    // ��ƃR�[�h
                            findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);       // ���[���O���[�v�R�[�h

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)roleGroupNameStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (roleGroupNameStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �V�K�쐬����SQL���𐶐�
                            string sqlText = string.Empty;
                            sqlText += "INSERT INTO ROLEGRPNAMESTRF (" + Environment.NewLine;
                            sqlText += "        CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,   UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,   ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,   FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,   UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,   LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,   ROLEGROUPCODERF" + Environment.NewLine;
                            sqlText += "    ,   ROLEGROUPNAMERF" + Environment.NewLine;
                            sqlText += ") VALUES (" + Environment.NewLine;
                            sqlText += "        @CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,   @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,   @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,   @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,   @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,   @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,   @ROLEGROUPCODE" + Environment.NewLine;
                            sqlText += "    ,   @ROLEGROUPNAME" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)roleGroupNameStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

                        #region Parameter�I�u�W�F�N�g�̍쐬(�X�V�p)
                        SqlParameter paraCreateDateTime = sqlCommand.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);           // �쐬����
                        SqlParameter paraUpdateDateTime = sqlCommand.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);           // �X�V����
                        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);            // ��ƃR�[�h
                        SqlParameter paraFileHeaderGuid = sqlCommand.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier); // GUID
                        SqlParameter paraUpdEmployeeCode = sqlCommand.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);          // �X�V�]�ƈ��R�[�h
                        SqlParameter paraUpdAssemblyId1 = sqlCommand.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);         // �X�V�A�Z���u��ID1
                        SqlParameter paraUpdAssemblyId2 = sqlCommand.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);         // �X�V�A�Z���u��ID2
                        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);        // �_���폜�敪
                        SqlParameter paraRoleGroupCode = sqlCommand.Parameters.Add("@ROLEGROUPCODE", SqlDbType.Int);                // ���[���O���[�v�R�[�h
                        SqlParameter paraRoleGroupName = sqlCommand.Parameters.Add("@ROLEGROUPNAME", SqlDbType.NVarChar);           // ���[���O���[�v����
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(roleGroupNameStWork.CreateDateTime);     // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(roleGroupNameStWork.UpdateDateTime);     // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);                // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(roleGroupNameStWork.FileHeaderGuid);                  // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.UpdEmployeeCode);              // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.UpdAssemblyId1);                // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.UpdAssemblyId2);                // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.LogicalDeleteCode);           // �_���폜�敪
                        paraRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);                   // ���[���O���[�v�R�[�h
                        paraRoleGroupName.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.RoleGroupName);                  // ���[���O���[�v����
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(roleGroupNameStWork);
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
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            roleGroupNameStWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="roleGroupNameStWork">roleGroupNameStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int LogicalDelete(ref object roleGroupNameStWork)
        {
            return LogicalDeleteRoleGroupNameSt(ref roleGroupNameStWork, 0);
        }

        /// <summary>
        /// �_���폜���[���O���[�v���̐ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="roleGroupNameStWork">roleGroupNameStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���[���O���[�v���̐ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int RevivalLogicalDelete(ref object roleGroupNameStWork)
        {
            return LogicalDeleteRoleGroupNameSt(ref roleGroupNameStWork, 1);
        }

        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="roleGroupNameStWork">roleGroupNameStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private int LogicalDeleteRoleGroupNameSt(ref object roleGroupNameStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(roleGroupNameStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteRoleGroupNameStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                string procModestr = "";
                if (procMode == 0)
                    procModestr = "LogicalDelete";
                else
                    procModestr = "RevivalLogicalDelete";
                base.WriteErrorLog(ex, "RoleGroupNameStDB.LogicalDeleteRoleGroupNameSt :" + procModestr);

                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
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
        /// ���[���O���[�v���̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">roleGroupNameStWorkList�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int LogicalDeleteRoleGroupNameStProc(ref ArrayList roleGroupNameStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteRoleGroupNameStProcProc(ref roleGroupNameStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">roleGroupNameStWorkList�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private int LogicalDeleteRoleGroupNameStProcProc(ref ArrayList roleGroupNameStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (roleGroupNameStWorkList != null)
                {
                    for (int i = 0; i < roleGroupNameStWorkList.Count; i++)
                    {
                        RoleGroupNameStWork roleGroupNameStWork = roleGroupNameStWorkList[i] as RoleGroupNameStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM ROLEGRPNAMESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // ��ƃR�[�h
                        SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ���[���O���[�v�R�[�h

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);            // ��ƃR�[�h
                        findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);               // ���[���O���[�v�R�[�h

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != roleGroupNameStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE ROLEGRPNAMESTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE";

                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);    // ��ƃR�[�h
                            findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);       // ���[���O���[�v�R�[�h

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)roleGroupNameStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                            sqlCommand.Cancel();
                            return status;
                        }
                        sqlCommand.Cancel();
                        if (myReader.IsClosed == false) myReader.Close();

                        //�_���폜���[�h�̏ꍇ
                        if (procMode == 0)
                        {
                            if (logicalDelCd == 3)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;//���ɍ폜�ς݂̏ꍇ����
                                sqlCommand.Cancel();
                                return status;
                            }
                            else if (logicalDelCd == 0) roleGroupNameStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else roleGroupNameStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) roleGroupNameStWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;    //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
                                else status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;//���S�폜�̓f�[�^�Ȃ���߂�
                                sqlCommand.Cancel();
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(roleGroupNameStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(roleGroupNameStWork);
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            roleGroupNameStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">���[���O���[�v���̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int Delete(byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(parabyte);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = DeleteRoleGroupNameStProc(paraList, ref sqlConnection, ref sqlTransaction);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "RoleGroupNameStDB.Delete");
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
        /// ���[���O���[�v���̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">���[���O���[�v���̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        public int DeleteRoleGroupNameStProc(ArrayList roleGroupNameStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteRoleGroupNameStProcProc(roleGroupNameStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="roleGroupNameStWorkList">���[���O���[�v���̐ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : ���[���O���[�v���̐ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private int DeleteRoleGroupNameStProcProc(ArrayList roleGroupNameStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < roleGroupNameStWorkList.Count; i++)
                {
                    RoleGroupNameStWork roleGroupNameStWork = roleGroupNameStWorkList[i] as RoleGroupNameStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM ROLEGRPNAMESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // ��ƃR�[�h
                    SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ���[���O���[�v�R�[�h

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);            // ��ƃR�[�h
                    findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);               // ���[���O���[�v�R�[�h

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != roleGroupNameStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM ROLEGRPNAMESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE";

                        //KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);        // ��ƃR�[�h
                        findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);           // ���[���O���[�v�R�[�h
                    }
                    else
                    {
                        //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                        status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                        sqlCommand.Cancel();
                        return status;
                    }
                    if (myReader.IsClosed == false) myReader.Close();

                    sqlCommand.ExecuteNonQuery();
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
                if (myReader != null)
                {
                    if (myReader.IsClosed == false) myReader.Close();
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
        /// <param name="roleGroupNameStWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, RoleGroupNameStWork roleGroupNameStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE   ";

            //��ƃR�[�h
            retstring += "ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(roleGroupNameStWork.EnterpriseCode);

            //���[���O���[�v�R�[�h
            if (roleGroupNameStWork.RoleGroupCode != 0)
            {
                retstring += "  AND   ROLEGROUPCODERF = @FINDROLEGROUPCODE" + Environment.NewLine;
                SqlParameter paraRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                paraRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(roleGroupNameStWork.RoleGroupCode);
            }

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND   LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND   LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            if (wkstring != "")
            {
                retstring += wkstring;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }

            return retstring;
        }
        #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� RoleGroupNameStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>RoleGroupNameStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private RoleGroupNameStWork CopyToRoleGroupNameStWorkFromReader(ref SqlDataReader myReader)
        {
            RoleGroupNameStWork wkRoleGroupNameStWork = new RoleGroupNameStWork();

            #region �N���X�֊i�[
            wkRoleGroupNameStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));  // �쐬����
            wkRoleGroupNameStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  // �X�V����
            wkRoleGroupNameStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));             // ��ƃR�[�h
            wkRoleGroupNameStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));               // GUID
            wkRoleGroupNameStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));           // �X�V�]�ƈ��R�[�h
            wkRoleGroupNameStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));             // �X�V�A�Z���u��ID1
            wkRoleGroupNameStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));             // �X�V�A�Z���u��ID2
            wkRoleGroupNameStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));        // �_���폜�敪
            wkRoleGroupNameStWork.RoleGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLEGROUPCODERF"));               // ���[���O���[�v�R�[�h
            wkRoleGroupNameStWork.RoleGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ROLEGROUPNAMERF"));                // ���[���O���[�v����
            #endregion

            return wkRoleGroupNameStWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            RoleGroupNameStWork[] RoleGroupNameStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is RoleGroupNameStWork)
                    {
                        RoleGroupNameStWork wkRoleGroupNameStWork = paraobj as RoleGroupNameStWork;
                        if (wkRoleGroupNameStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkRoleGroupNameStWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            RoleGroupNameStWorkArray = (RoleGroupNameStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(RoleGroupNameStWork[]));
                        }
                        catch (Exception) { }
                        if (RoleGroupNameStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(RoleGroupNameStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                RoleGroupNameStWork wkRoleGroupNameStWork = (RoleGroupNameStWork)XmlByteSerializer.Deserialize(byteArray, typeof(RoleGroupNameStWork));
                                if (wkRoleGroupNameStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkRoleGroupNameStWork);
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

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
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
        #endregion
    }
}