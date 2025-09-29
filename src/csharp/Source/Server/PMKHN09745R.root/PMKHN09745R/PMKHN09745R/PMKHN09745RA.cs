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
    /// �]�ƈ����[���ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �]�ƈ����[���ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30747 �O�ˁ@�L��</br>
    /// <br>Date       : 2013/02/07</br>
    /// </remarks>
    [Serializable]
    public class EmployeeRoleStDB : RemoteDB, IEmployeeRoleStDB
    {
        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        public EmployeeRoleStDB()
            :
            base("PMKHN09747D", "Broadleaf.Application.Remoting.ParamData.EmployeeRoleStWork", "EMPLOYEEROLESTRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="employeeRoleStWork">��������</param>
        /// <param name="paraemployeeRoleStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int Search(out object employeeRoleStWork, object paraemployeeRoleStWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            employeeRoleStWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchEmployeeRoleStProc(out employeeRoleStWork, paraemployeeRoleStWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeRoleStDB.Search");
                employeeRoleStWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objemployeeRoleStWork">��������</param>
        /// <param name="paraemployeeRoleStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int SearchEmployeeRoleStProc(out object objemployeeRoleStWork, object paraemployeeRoleStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            EmployeeRoleStWork employeeRoleStWork = null;

            ArrayList employeeRoleStWorkList = paraemployeeRoleStWork as ArrayList;
            if (employeeRoleStWorkList == null)
            {
                employeeRoleStWork = paraemployeeRoleStWork as EmployeeRoleStWork;
            }
            else
            {
                if (employeeRoleStWorkList.Count > 0)
                    employeeRoleStWork = employeeRoleStWorkList[0] as EmployeeRoleStWork;
            }

            int status = SearchEmployeeRoleStProc(out employeeRoleStWorkList, employeeRoleStWork, readMode, logicalMode, ref sqlConnection);
            objemployeeRoleStWork = employeeRoleStWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="employeeRoleStWorkList">��������</param>
        /// <param name="employeeRoleStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int SearchEmployeeRoleStProc(out ArrayList employeeRoleStWorkList, EmployeeRoleStWork employeeRoleStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchEmployeeRoleStProcProc(out employeeRoleStWorkList, employeeRoleStWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="employeeRoleStWorkList">��������</param>
        /// <param name="employeeRoleStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        private int SearchEmployeeRoleStProcProc(out ArrayList employeeRoleStWorkList, EmployeeRoleStWork employeeRoleStWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                string selectTxt = string.Empty;

                #region SELECT��
                selectTxt += "SELECT  A.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   A.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "    ,   A.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,   A.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "    ,   A.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,   A.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "    ,   A.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "    ,   A.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "    ,   A.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,   A.ROLEGROUPCODERF" + Environment.NewLine;
                selectTxt += "    ,   B.ROLEGROUPNAMERF" + Environment.NewLine;
                selectTxt += "    ,   C.NAMERF" + Environment.NewLine;
                selectTxt += "FROM    EMPLOYEEROLESTRF  A" + Environment.NewLine;
                selectTxt += "LEFT JOIN ROLEGRPNAMESTRF B" + Environment.NewLine;
                selectTxt += " ON  A.ENTERPRISECODERF = B.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND A.ROLEGROUPCODERF  = B.ROLEGROUPCODERF" + Environment.NewLine;
                selectTxt += " AND B.LOGICALDELETECODERF = 0" + Environment.NewLine;
                selectTxt += "LEFT JOIN EMPLOYEERF      C" + Environment.NewLine;
                selectTxt += " ON  A.ENTERPRISECODERF = C.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND A.EMPLOYEECODERF   = C.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += " AND C.LOGICALDELETECODERF = 0" + Environment.NewLine;
                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, employeeRoleStWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToEmployeeRoleStWorkFromReader(ref myReader));

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

            employeeRoleStWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">EmployeeRoleStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                EmployeeRoleStWork employeeRoleStWork = new EmployeeRoleStWork();

                // XML�̓ǂݍ���
                employeeRoleStWork = (EmployeeRoleStWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeRoleStWork));
                if (employeeRoleStWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref employeeRoleStWork, readMode, ref sqlConnection, ref sqlTransaction);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(employeeRoleStWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeRoleStDB.Read");
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
        /// �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="employeeRoleStWork">EmployeeRoleStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int ReadProc(ref EmployeeRoleStWork employeeRoleStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.ReadProcProc(ref employeeRoleStWork, readMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="employeeRoleStWork">EmployeeRoleStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="sqlTransaction">SqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ����[���ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        private int ReadProcProc(ref EmployeeRoleStWork employeeRoleStWork, int readMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
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
                selectTxt += "    ,   EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "    ,   ROLEGROUPCODERF" + Environment.NewLine;
                selectTxt += "FROM    EMPLOYEEROLESTRF" + Environment.NewLine;
                selectTxt += "WHERE   ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "  AND   EMPLOYEECODERF  = @FINDEMPLOYEECODE" + Environment.NewLine;
                selectTxt += "  AND   ROLEGROUPCODERF  = @FINDROLEGROUPCODE" + Environment.NewLine;
                #endregion

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {
                    if (sqlTransaction != null) sqlCommand.Transaction = sqlTransaction;

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // ��ƃR�[�h
                    SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);        // �]�ƈ��R�[�h
                    SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ���[���O���[�v�R�[�h

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);             // ��ƃR�[�h
                    findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);                 // �]�ƈ��R�[�h
                    findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);                // ���[���O���[�v�R�[�h

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        employeeRoleStWork = CopyToEmployeeRoleStWorkFromReader(ref myReader);
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
        /// �]�ƈ����[���ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="employeeRoleStWork">EmployeeRoleStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int Write(ref object employeeRoleStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(employeeRoleStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteEmployeeRoleStProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                EmployeeRoleStWork paraWork = paraList[0] as EmployeeRoleStWork;

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                employeeRoleStWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmployeeRoleStDB.Write(ref object employeeRoleStWork)");
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
        /// �]�ƈ����[���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="employeeRoleStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int WriteEmployeeRoleStProc(ref ArrayList employeeRoleStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteEmployeeRoleStProcProc(ref employeeRoleStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="employeeRoleStWorkList">StockMngTtlStWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        private int WriteEmployeeRoleStProcProc(ref ArrayList employeeRoleStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            try
            {
                if (employeeRoleStWorkList != null)
                {
                    foreach (EmployeeRoleStWork employeeRoleStWork in employeeRoleStWorkList)
                    {
                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM EMPLOYEEROLESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF = @FINDEMPLOYEECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // ��ƃR�[�h
                        SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);        // �]�ƈ��R�[�h
                        SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ���[���O���[�v�R�[�h

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);             // ��ƃR�[�h
                        findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);                 // �]�ƈ��R�[�h
                        findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);                // ���[���O���[�v�R�[�h

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));  //�X�V����
                            if (_updateDateTime != employeeRoleStWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (employeeRoleStWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �X�V����SQL������
                            string sqlText = string.Empty;
                            sqlText += "UPDATE  EMPLOYEEROLESTRF" + Environment.NewLine;
                            sqlText += "SET     CREATEDATETIMERF    = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   UPDATEDATETIMERF    = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   ENTERPRISECODERF    = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,   FILEHEADERGUIDRF    = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,   UPDEMPLOYEECODERF   = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID1RF    = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID2RF    = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,   LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,   EMPLOYEECODERF      = @EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,   ROLEGROUPCODERF     = @ROLEGROUPCODE" + Environment.NewLine;
                            sqlText += "WHERE   ENTERPRISECODERF    = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND   EMPLOYEECODERF      = @FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  AND   ROLEGROUPCODERF     = @FINDROLEGROUPCODE" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);     // ��ƃR�[�h
                            findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);         // �]�ƈ��R�[�h
                            findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);        // ���[���O���[�v�R�[�h

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)employeeRoleStWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (employeeRoleStWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            # region �V�K�쐬����SQL���𐶐�
                            string sqlText = string.Empty;
                            sqlText += "INSERT INTO EMPLOYEEROLESTRF (" + Environment.NewLine;
                            sqlText += "        CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,   UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += "    ,   ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += "    ,   FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += "    ,   UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += "    ,   UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += "    ,   LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += "    ,   EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += "    ,   ROLEGROUPCODERF" + Environment.NewLine;
                            sqlText += ") VALUES (" + Environment.NewLine;
                            sqlText += "        @CREATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += "    ,   @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += "    ,   @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += "    ,   @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,   @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += "    ,   @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += "    ,   @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += "    ,   @EMPLOYEECODE" + Environment.NewLine;
                            sqlText += "    ,   @ROLEGROUPCODE" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;

                            sqlCommand.CommandText = sqlText;
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)employeeRoleStWork;
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
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);                // �]�ƈ��R�[�h
                        SqlParameter paraRoleGroupCode = sqlCommand.Parameters.Add("@ROLEGROUPCODE", SqlDbType.Int);                // ���[���O���[�v�R�[�h
                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeRoleStWork.CreateDateTime);      // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeRoleStWork.UpdateDateTime);      // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);                 // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(employeeRoleStWork.FileHeaderGuid);                   // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.UpdEmployeeCode);               // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.UpdAssemblyId1);                 // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.UpdAssemblyId2);                 // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.LogicalDeleteCode);            // �_���폜�敪
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);                     // �]�ƈ��R�[�h
                        paraRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);                    // ���[���O���[�v�R�[�h
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(employeeRoleStWork);
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

            employeeRoleStWorkList = al;

            return status;
        }
        #endregion

        #region [LogicalDelete]
        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="employeeRoleStWork">employeeRoleStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int LogicalDelete(ref object employeeRoleStWork)
        {
            return LogicalDeleteEmployeeRoleSt(ref employeeRoleStWork, 0);
        }

        /// <summary>
        /// �_���폜�]�ƈ����[���ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="employeeRoleStWork">employeeRoleStWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�]�ƈ����[���ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int RevivalLogicalDelete(ref object employeeRoleStWork)
        {
            return LogicalDeleteEmployeeRoleSt(ref employeeRoleStWork, 1);
        }

        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="employeeRoleStWork">employeeRoleStWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        private int LogicalDeleteEmployeeRoleSt(ref object employeeRoleStWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(employeeRoleStWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteEmployeeRoleStProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "EmployeeRoleStDB.LogicalDeleteEmployeeRoleSt :" + procModestr);

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
        /// �]�ƈ����[���ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="employeeRoleStWorkList">employeeRoleStWorkList�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int LogicalDeleteEmployeeRoleStProc(ref ArrayList employeeRoleStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteEmployeeRoleStProcProc(ref employeeRoleStWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="employeeRoleStWorkList">employeeRoleStWorkList�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        private int LogicalDeleteEmployeeRoleStProcProc(ref ArrayList employeeRoleStWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            try
            {
                if (employeeRoleStWorkList != null)
                {
                    for (int i = 0; i < employeeRoleStWorkList.Count; i++)
                    {
                        EmployeeRoleStWork employeeRoleStWork = employeeRoleStWorkList[i] as EmployeeRoleStWork;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM EMPLOYEEROLESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF = @FINDEMPLOYEECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE", sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // ��ƃR�[�h
                        SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);        // �]�ƈ��R�[�h
                        SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ���[���O���[�v�R�[�h

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);             // ��ƃR�[�h
                        findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);                 // �]�ƈ��R�[�h
                        findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);                // ���[���O���[�v�R�[�h

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != employeeRoleStWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE EMPLOYEEROLESTRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF = @FINDEMPLOYEECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE";

                            //KEY�R�}���h���Đݒ�
                            findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);         // ��ƃR�[�h
                            findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);             // �]�ƈ��R�[�h
                            findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);            // ���[���O���[�v�R�[�h

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)employeeRoleStWork;
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
                            else if (logicalDelCd == 0) employeeRoleStWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else employeeRoleStWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) employeeRoleStWork.LogicalDeleteCode = 0;//�_���폜�t���O������
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(employeeRoleStWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(employeeRoleStWork);
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

            employeeRoleStWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�]�ƈ����[���ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
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

                status = DeleteEmployeeRoleStProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "EmployeeRoleStDB.Delete");
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
        /// �]�ƈ����[���ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="employeeRoleStWorkList">�]�ƈ����[���ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        public int DeleteEmployeeRoleStProc(ArrayList employeeRoleStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteEmployeeRoleStProcProc(employeeRoleStWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="employeeRoleStWorkList">�]�ƈ����[���ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �]�ƈ����[���ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        private int DeleteEmployeeRoleStProcProc(ArrayList employeeRoleStWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            try
            {

                for (int i = 0; i < employeeRoleStWorkList.Count; i++)
                {
                    EmployeeRoleStWork employeeRoleStWork = employeeRoleStWorkList[i] as EmployeeRoleStWork;
                    sqlCommand = new SqlCommand("SELECT UPDATEDATETIMERF, LOGICALDELETECODERF FROM EMPLOYEEROLESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF = @FINDEMPLOYEECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE", sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);    // ��ƃR�[�h
                    SqlParameter findEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);        // �]�ƈ��R�[�h
                    SqlParameter findRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);        // ���[���O���[�v�R�[�h

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);             // ��ƃR�[�h
                    findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);                 // �]�ƈ��R�[�h
                    findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);                // ���[���O���[�v�R�[�h

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != employeeRoleStWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM EMPLOYEEROLESTRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND EMPLOYEECODERF = @FINDEMPLOYEECODE AND ROLEGROUPCODERF = @FINDROLEGROUPCODE";

                        //KEY�R�}���h���Đݒ�
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);         // ��ƃR�[�h
                        findEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);             // �]�ƈ��R�[�h
                        findRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);            // ���[���O���[�v�R�[�h
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
        /// <param name="employeeRoleStWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, EmployeeRoleStWork employeeRoleStWork, ConstantManagement.LogicalMode logicalMode)
        {
            string wkstring = "";
            string retstring = "WHERE   ";

            //��ƃR�[�h
            retstring += "A.ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EnterpriseCode);

            //�]�ƈ��R�[�h
            if (employeeRoleStWork.EmployeeCode != "")
            {
                retstring += "  AND   A.EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                paraEmployeeCode.Value = SqlDataMediator.SqlSetString(employeeRoleStWork.EmployeeCode);
            }

            //���[���O���[�v�R�[�h
            if (employeeRoleStWork.RoleGroupCode != 0)
            {
                retstring += "  AND   A.ROLEGROUPCODERF = @FINDROLEGROUPCODE" + Environment.NewLine;
                SqlParameter paraRoleGroupCode = sqlCommand.Parameters.Add("@FINDROLEGROUPCODE", SqlDbType.Int);
                paraRoleGroupCode.Value = SqlDataMediator.SqlSetInt32(employeeRoleStWork.RoleGroupCode);
            }

            //�_���폜�敪
            wkstring = "";
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                wkstring = "  AND   A.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                wkstring = "  AND   A.LOGICALDELETECODERF < @FINDLOGICALDELETECODE" + Environment.NewLine;
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
        /// �N���X�i�[���� Reader �� EmployeeRoleStWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>EmployeeRoleStWork</returns>
        /// <remarks>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        private EmployeeRoleStWork CopyToEmployeeRoleStWorkFromReader(ref SqlDataReader myReader)
        {
            EmployeeRoleStWork wkEmployeeRoleStWork = new EmployeeRoleStWork();

            #region �N���X�֊i�[
            wkEmployeeRoleStWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));   // �쐬����
            wkEmployeeRoleStWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));   // �X�V����
            wkEmployeeRoleStWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));              // ��ƃR�[�h
            wkEmployeeRoleStWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));                // GUID
            wkEmployeeRoleStWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));            // �X�V�]�ƈ��R�[�h
            wkEmployeeRoleStWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));              // �X�V�A�Z���u��ID1
            wkEmployeeRoleStWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));              // �X�V�A�Z���u��ID2
            wkEmployeeRoleStWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));         // �_���폜�敪
            wkEmployeeRoleStWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));                  // �]�ƈ��R�[�h
            wkEmployeeRoleStWork.RoleGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ROLEGROUPCODERF"));                 // ���[���O���[�v�R�[�h
            wkEmployeeRoleStWork.RoleGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ROLEGROUPNAMERF"));                // ���[���O���[�v����
            wkEmployeeRoleStWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));                          // �]�ƈ�����
            #endregion

            return wkEmployeeRoleStWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            EmployeeRoleStWork[] EmployeeRoleStWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is EmployeeRoleStWork)
                    {
                        EmployeeRoleStWork wkEmployeeRoleStWork = paraobj as EmployeeRoleStWork;
                        if (wkEmployeeRoleStWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkEmployeeRoleStWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            EmployeeRoleStWorkArray = (EmployeeRoleStWork[])XmlByteSerializer.Deserialize(byteArray, typeof(EmployeeRoleStWork[]));
                        }
                        catch (Exception) { }
                        if (EmployeeRoleStWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(EmployeeRoleStWorkArray);
                        }
                        else
                        {
                            try
                            {
                                EmployeeRoleStWork wkEmployeeRoleStWork = (EmployeeRoleStWork)XmlByteSerializer.Deserialize(byteArray, typeof(EmployeeRoleStWork));
                                if (wkEmployeeRoleStWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkEmployeeRoleStWork);
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
        /// <br>Programmer : 30747 �O�ˁ@�L��</br>
        /// <br>Date       : 2013/02/07</br>
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
