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
    /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.04.13</br>
    /// <br></br>
    /// <br>Update Note: 2007.09.28  980081 �R�c ���F</br>
    /// <br>           : ���ʊ�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2007.11.27  980081 �R�c ���F</br>
    /// <br>           : �]�ƈ��敪�ǉ�</br>
    /// <br></br>
    /// <br>Update Note: 2007.12.06  ����</br>
    /// <br>           : �]�ƈ��R�[�h null�΍�</br>
    /// <br>Update Note: 2008.06.17  ����</br>
    /// <br>           : PM.NS�p�ɏC��</br>
    /// <br>Update Note: 2010/12/20 ������</br>
    /// <br>             ��Q���ǑΉ��P�Q��</br>
    /// </remarks>
    [Serializable]
    public class EmpSalesTargetDB : RemoteDB, IEmpSalesTargetDB
    {
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        public EmpSalesTargetDB()
            :
            base("MAMOK09116D", "Broadleaf.Application.Remoting.ParamData.EmpSalesTargetWork", "EMPSALESTARGETRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�
        /// </summary>
        /// <param name="empsalestargetWork">��������</param>
        /// <param name="paraempsalestargetWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        public int Search(out object empsalestargetWork, object paraempsalestargetWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            empsalestargetWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchEmpSalesTargetProc(out empsalestargetWork, paraempsalestargetWork, readMode, logicalMode, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Search");
                empsalestargetWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objempsalestargetWork">��������</param>
        /// <param name="searchEmpSalesTargetParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        public int SearchEmpSalesTargetProc(out object objempsalestargetWork, object searchEmpSalesTargetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            SearchEmpSalesTargetParaWork empSalesTargetParaWork = null;

            ArrayList empsalestargetWorkList = searchEmpSalesTargetParaWork as ArrayList;
            if (empsalestargetWorkList == null)
            {
                empSalesTargetParaWork = searchEmpSalesTargetParaWork as SearchEmpSalesTargetParaWork;
            }
            else
            {
                if (empsalestargetWorkList.Count > 0)
                    empSalesTargetParaWork = empsalestargetWorkList[0] as SearchEmpSalesTargetParaWork;
            }

            int status = SearchEmpSalesTargetProc(out empsalestargetWorkList, empSalesTargetParaWork, readMode, logicalMode, ref sqlConnection);
            objempsalestargetWork = empsalestargetWorkList;
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="empsalestargetWorkList">��������</param>
        /// <param name="searchEmpSalesTargetParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        public int SearchEmpSalesTargetProc(out ArrayList empsalestargetWorkList, SearchEmpSalesTargetParaWork searchEmpSalesTargetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            return this.SearchEmpSalesTargetProcProc(out empsalestargetWorkList, searchEmpSalesTargetParaWork, readMode, logicalMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="empsalestargetWorkList">��������</param>
        /// <param name="searchEmpSalesTargetParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        private int SearchEmpSalesTargetProcProc( out ArrayList empsalestargetWorkList, SearchEmpSalesTargetParaWork searchEmpSalesTargetParaWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            string selectTxt = string.Empty;

            try
            {
                selectTxt += "SELECT ESG.* , SEC.SECTIONGUIDENMRF, EMP.NAMERF AS EMPLOYEENAMERF, SUB.SUBSECTIONNAMERF FROM EMPSALESTARGETRF AS ESG" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += " ESG.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND ESG.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN EMPLOYEERF AS EMP" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += " ESG.ENTERPRISECODERF=EMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND ESG.EMPLOYEECODERF=EMP.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SUBSECTIONRF AS SUB" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += " ESG.ENTERPRISECODERF=SUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND ESG.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, searchEmpSalesTargetParaWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(CopyToEmpSalesTargetWorkFromReader(ref myReader));

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
                    if (!myReader.IsClosed) myReader.Close();
            }

            empsalestargetWorkList = al;

            return status;
        }
        #endregion

        #region [Read]
        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^��߂��܂�
        /// </summary>
        /// <param name="parabyte">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        public int Read(ref byte[] parabyte, int readMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;

            try
            {
                EmpSalesTargetWork empsalestargetWork = new EmpSalesTargetWork();

                // XML�̓ǂݍ���
                empsalestargetWork = (EmpSalesTargetWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmpSalesTargetWork));
                if (empsalestargetWork == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                status = ReadProc(ref empsalestargetWork, readMode, ref sqlConnection);

                // XML�֕ϊ����A������̃o�C�i����
                parabyte = XmlByteSerializer.Serialize(empsalestargetWork);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Read");
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
        /// �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
      	/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 �R�c ���F</br>
        /// <br>           : �]�ƈ��敪�ǉ�</br>
        public int ReadProc(ref EmpSalesTargetWork empsalestargetWork, int readMode, ref SqlConnection sqlConnection)
        {
            return this.ReadProcProc(ref empsalestargetWork, readMode, ref sqlConnection);
        }

        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏]�ƈ��ʔ���ڕW�ݒ�}�X�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 �R�c ���F</br>
        /// <br>           : �]�ƈ��敪�ǉ�</br>
        private int ReadProcProc( ref EmpSalesTargetWork empsalestargetWork, int readMode, ref SqlConnection sqlConnection )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;

            string selectTxt = string.Empty;

            try
            {
                selectTxt += "SELECT ESG.* , SEC.SECTIONGUIDENMRF, EMP.NAMERF AS EMPLOYEENAMERF, SUB.SUBSECTIONNAMERF FROM EMPSALESTARGETRF AS ESG" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF AS SEC" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += " ESG.ENTERPRISECODERF=SEC.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND ESG.SECTIONCODERF=SEC.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN EMPLOYEERF AS EMP" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += " ESG.ENTERPRISECODERF=EMP.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND ESG.EMPLOYEECODERF=EMP.EMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SUBSECTIONRF AS SUB" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += " ESG.ENTERPRISECODERF=SUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND ESG.SUBSECTIONCODERF=SUB.SUBSECTIONCODERF" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                selectTxt += " AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD" + Environment.NewLine;
                selectTxt += " AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                //Select�R�}���h�̐���
                using (SqlCommand sqlCommand = new SqlCommand(selectTxt, sqlConnection))
                {

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                    SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                    findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                    findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                    findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;

                    myReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (myReader.Read())
                    {
                        empsalestargetWork = CopyToEmpSalesTargetWorkFromReader(ref myReader);
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
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region [Write]
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        public int Write(ref object empsalestargetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(empsalestargetWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //write���s
                status = WriteEmpSalesTargetProc(ref paraList, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                empsalestargetWork = paraList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Write(ref object empsalestargetWork)");
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
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="empsalestargetWorkList">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 �R�c ���F</br>
        /// <br>           : �]�ƈ��敪�ǉ�</br>
        public int WriteEmpSalesTargetProc(ref ArrayList empsalestargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.WriteEmpSalesTargetProcProc(ref empsalestargetWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="empsalestargetWorkList">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^����o�^�A�X�V���܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 �R�c ���F</br>
        /// <br>           : �]�ƈ��敪�ǉ�</br>
        private int WriteEmpSalesTargetProcProc( ref ArrayList empsalestargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;
            try
            {
                if (empsalestargetWorkList != null)
                {
                    for (int i = 0; i < empsalestargetWorkList.Count; i++)
                    {
                        EmpSalesTargetWork empsalestargetWork = empsalestargetWorkList[i] as EmpSalesTargetWork;

                        selectTxt = string.Empty;
                        selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF FROM EMPSALESTARGETRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                        selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                        selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                        selectTxt += " AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD" + Environment.NewLine;
                        selectTxt += " AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                        selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                        //Select�R�}���h�̐���
                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                        findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                        findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                        findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != empsalestargetWork.UpdateDateTime)
                            {
                                //�V�K�o�^�ŊY���f�[�^�L��̏ꍇ�ɂ͏d��
                                if (empsalestargetWork.UpdateDateTime == DateTime.MinValue) status = (int)ConstantManagement.DB_Status.ctDB_DUPLICATE;
                                //�����f�[�^�ōX�V�����Ⴂ�̏ꍇ�ɂ͔r��
                                else status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            selectTxt = string.Empty;
                            selectTxt += "UPDATE EMPSALESTARGETRF SET CREATEDATETIMERF=@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += " , UPDATEDATETIMERF=@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += " , ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += " , FILEHEADERGUIDRF=@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += " , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID1RF=@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += " , UPDASSEMBLYID2RF=@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += " , LOGICALDELETECODERF=@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += " , SECTIONCODERF=@SECTIONCODE" + Environment.NewLine;
                            selectTxt += " , TARGETSETCDRF=@TARGETSETCD" + Environment.NewLine;
                            selectTxt += " , TARGETCONTRASTCDRF=@TARGETCONTRASTCD" + Environment.NewLine;
                            selectTxt += " , TARGETDIVIDECODERF=@TARGETDIVIDECODE" + Environment.NewLine;
                            selectTxt += " , TARGETDIVIDENAMERF=@TARGETDIVIDENAME" + Environment.NewLine;
                            selectTxt += " , EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD" + Environment.NewLine;
                            selectTxt += " , SUBSECTIONCODERF=@SUBSECTIONCODE" + Environment.NewLine;
                            selectTxt += " , EMPLOYEECODERF=@EMPLOYEECODE" + Environment.NewLine;
                            selectTxt += " , APPLYSTADATERF=@APPLYSTADATE" + Environment.NewLine;
                            selectTxt += " , APPLYENDDATERF=@APPLYENDDATE" + Environment.NewLine;
                            selectTxt += " , SALESTARGETMONEYRF=@SALESTARGETMONEY" + Environment.NewLine;
                            selectTxt += " , SALESTARGETPROFITRF=@SALESTARGETPROFIT" + Environment.NewLine;
                            selectTxt += " , SALESTARGETCOUNTRF=@SALESTARGETCOUNT" + Environment.NewLine;
                            selectTxt += " WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                            selectTxt += "  AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                            selectTxt += "  AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                            selectTxt += "  AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD" + Environment.NewLine;
                            selectTxt += "  AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                            sqlCommand.CommandText = selectTxt;

                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                            findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                            findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                            findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)empsalestargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            //����GUID�f�[�^�������ꍇ�ōX�V�������X�V�Ώۃf�[�^�ɓ����Ă���ꍇ�͂��łɍ폜����Ă���Ӗ��Ŕr����߂�
                            if (empsalestargetWork.UpdateDateTime > DateTime.MinValue)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                                sqlCommand.Cancel();
                                if (myReader.IsClosed == false) myReader.Close();
                                return status;
                            }

                            selectTxt = string.Empty;
                            selectTxt += "INSERT INTO EMPSALESTARGETRF" + Environment.NewLine;
                            selectTxt += " (CREATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,UPDATEDATETIMERF" + Environment.NewLine;
                            selectTxt += "  ,ENTERPRISECODERF" + Environment.NewLine;
                            selectTxt += "  ,FILEHEADERGUIDRF" + Environment.NewLine;
                            selectTxt += "  ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            selectTxt += "  ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            selectTxt += "  ,LOGICALDELETECODERF" + Environment.NewLine;
                            selectTxt += "  ,SECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,TARGETSETCDRF" + Environment.NewLine;
                            selectTxt += "  ,TARGETCONTRASTCDRF" + Environment.NewLine;
                            selectTxt += "  ,TARGETDIVIDECODERF" + Environment.NewLine;
                            selectTxt += "  ,TARGETDIVIDENAMERF" + Environment.NewLine;
                            selectTxt += "  ,EMPLOYEEDIVCDRF" + Environment.NewLine;
                            selectTxt += "  ,SUBSECTIONCODERF" + Environment.NewLine;
                            selectTxt += "  ,EMPLOYEECODERF" + Environment.NewLine;
                            selectTxt += "  ,APPLYSTADATERF" + Environment.NewLine;
                            selectTxt += "  ,APPLYENDDATERF" + Environment.NewLine;
                            selectTxt += "  ,SALESTARGETMONEYRF" + Environment.NewLine;
                            selectTxt += "  ,SALESTARGETPROFITRF" + Environment.NewLine;
                            selectTxt += "  ,SALESTARGETCOUNTRF" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;
                            selectTxt += " VALUES" + Environment.NewLine;
                            selectTxt += " (@CREATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@UPDATEDATETIME" + Environment.NewLine;
                            selectTxt += "  ,@ENTERPRISECODE" + Environment.NewLine;
                            selectTxt += "  ,@FILEHEADERGUID" + Environment.NewLine;
                            selectTxt += "  ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID1" + Environment.NewLine;
                            selectTxt += "  ,@UPDASSEMBLYID2" + Environment.NewLine;
                            selectTxt += "  ,@LOGICALDELETECODE" + Environment.NewLine;
                            selectTxt += "  ,@SECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@TARGETSETCD" + Environment.NewLine;
                            selectTxt += "  ,@TARGETCONTRASTCD" + Environment.NewLine;
                            selectTxt += "  ,@TARGETDIVIDECODE" + Environment.NewLine;
                            selectTxt += "  ,@TARGETDIVIDENAME" + Environment.NewLine;
                            selectTxt += "  ,@EMPLOYEEDIVCD" + Environment.NewLine;
                            selectTxt += "  ,@SUBSECTIONCODE" + Environment.NewLine;
                            selectTxt += "  ,@EMPLOYEECODE" + Environment.NewLine;
                            selectTxt += "  ,@APPLYSTADATE" + Environment.NewLine;
                            selectTxt += "  ,@APPLYENDDATE" + Environment.NewLine;
                            selectTxt += "  ,@SALESTARGETMONEY" + Environment.NewLine;
                            selectTxt += "  ,@SALESTARGETPROFIT" + Environment.NewLine;
                            selectTxt += "  ,@SALESTARGETCOUNT" + Environment.NewLine;
                            selectTxt += " )" + Environment.NewLine;

                            //�V�K�쐬����SQL���𐶐�
                            sqlCommand.CommandText = selectTxt;
                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)empsalestargetWork;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }
                        if (myReader.IsClosed == false) myReader.Close();

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
                        SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
                        SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter paraTargetDivideCode = sqlCommand.Parameters.Add("@TARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter paraTargetDivideName = sqlCommand.Parameters.Add("@TARGETDIVIDENAME", SqlDbType.NVarChar);
                        SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                        SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
                        SqlParameter paraApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
                        SqlParameter paraSalesTargetMoney = sqlCommand.Parameters.Add("@SALESTARGETMONEY", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetProfit = sqlCommand.Parameters.Add("@SALESTARGETPROFIT", SqlDbType.BigInt);
                        SqlParameter paraSalesTargetCount = sqlCommand.Parameters.Add("@SALESTARGETCOUNT", SqlDbType.Float);

                        #endregion

                        #region Parameter�I�u�W�F�N�g�֒l�ݒ�(�X�V�p)
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(empsalestargetWork.CreateDateTime);
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(empsalestargetWork.UpdateDateTime);
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(empsalestargetWork.FileHeaderGuid);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(empsalestargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(empsalestargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.LogicalDeleteCode);
                        paraSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                        paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                        paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                        paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                        paraTargetDivideName.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideName);
                        paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                        paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                        paraEmployeeCode.Value = empsalestargetWork.EmployeeCode;
                        paraApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(empsalestargetWork.ApplyStaDate);
                        paraApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(empsalestargetWork.ApplyEndDate);
                        paraSalesTargetMoney.Value = SqlDataMediator.SqlSetInt64(empsalestargetWork.SalesTargetMoney);
                        paraSalesTargetProfit.Value = SqlDataMediator.SqlSetInt64(empsalestargetWork.SalesTargetProfit);
                        paraSalesTargetCount.Value = SqlDataMediator.SqlSetDouble(empsalestargetWork.SalesTargetCount);
                        #endregion

                        sqlCommand.ExecuteNonQuery();
                        al.Add(empsalestargetWork);
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
                    if (myReader.IsClosed == false) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            empsalestargetWorkList = al;

            return status;
        }
        #endregion

        // ---ADD 2010/12/20--------->>>>>
        #region [WriteProc]
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^�����X�V���܂�
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWork�I�u�W�F�N�g(write�p)</param>
        /// <param name="parabyte">EmpSalesTargetWork�I�u�W�F�N�g(delete�p)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^�����X�V���܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/12/20</br>
        public int WriteProc(ref object empsalestargetWork, byte[] parabyte)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraWriteList = CastToArrayListFromPara(empsalestargetWork);
                if (paraWriteList == null) return status;

                ArrayList paraDeleteList = CastToArrayListFromPara(parabyte);
                if (paraDeleteList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                //delete���s
                status = DeleteEmpSalesTargetProcProc(paraDeleteList, ref sqlConnection, ref sqlTransaction);

                //write���s
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = WriteEmpSalesTargetProcProc(ref paraWriteList, ref sqlConnection, ref sqlTransaction);
                }
                else
                {
                    //�Ȃ��B
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // �R�~�b�g
                    sqlTransaction.Commit();
                else
                {
                    // ���[���o�b�N
                    if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                }
                //�߂�l�Z�b�g
                empsalestargetWork = paraWriteList;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Write(ref object empsalestargetWork)");
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
        #endregion
        // ---ADD 2010/12/20---------<<<<<

        #region [LogicalDelete]
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^����_���폜���܂�
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        public int LogicalDelete(ref object empsalestargetWork)
        {
            return LogicalDeleteEmpSalesTarget(ref empsalestargetWork, 0);
        }

        /// <summary>
        /// �_���폜�]�ƈ��ʔ���ڕW�ݒ�}�X�^���𕜊����܂�
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�]�ƈ��ʔ���ڕW�ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        public int RevivalLogicalDelete(ref object empsalestargetWork)
        {
            return LogicalDeleteEmpSalesTarget(ref empsalestargetWork, 1);
        }

        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�
        /// </summary>
        /// <param name="empsalestargetWork">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        private int LogicalDeleteEmpSalesTarget(ref object empsalestargetWork, int procMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            try
            {
                //�p�����[�^�̃L���X�g
                ArrayList paraList = CastToArrayListFromPara(empsalestargetWork);
                if (paraList == null) return status;

                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                // �g�����U�N�V�����J�n
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                status = LogicalDeleteEmpSalesTargetProc(ref paraList, procMode, ref sqlConnection, ref sqlTransaction);

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
                base.WriteErrorLog(ex, "EmpSalesTargetDB.LogicalDeleteEmpSalesTarget :" + procModestr);

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
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="empsalestargetWorkList">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 �R�c ���F</br>
        /// <br>           : �]�ƈ��敪�ǉ�</br>
        public int LogicalDeleteEmpSalesTargetProc(ref ArrayList empsalestargetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.LogicalDeleteEmpSalesTargetProcProc(ref empsalestargetWorkList, procMode, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)
        /// </summary>
        /// <param name="empsalestargetWorkList">EmpSalesTargetWork�I�u�W�F�N�g</param>
        /// <param name="procMode">�֐��敪 0:�_���폜 1:����</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^���̘_���폜�𑀍삵�܂�(�O�������SqlConnection + SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 �R�c ���F</br>
        /// <br>           : �]�ƈ��敪�ǉ�</br>
        private int LogicalDeleteEmpSalesTargetProcProc( ref ArrayList empsalestargetWorkList, int procMode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            int logicalDelCd = 0;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();

            string selectTxt = string.Empty;
            try
            {
                if (empsalestargetWorkList != null)
                {
                    for (int i = 0; i < empsalestargetWorkList.Count; i++)
                    {
                        EmpSalesTargetWork empsalestargetWork = empsalestargetWorkList[i] as EmpSalesTargetWork;

                        //Select�R�}���h�̐���
                        selectTxt = string.Empty;
                        selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM EMPSALESTARGETRF" + Environment.NewLine;
                        selectTxt += "WHERE" + Environment.NewLine;
                        selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                        selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                        selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                        selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                        selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                        selectTxt += " AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD" + Environment.NewLine;
                        selectTxt += " AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                        selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                        sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                        //Prameter�I�u�W�F�N�g�̍쐬
                        SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                        SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                        SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                        SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                        SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                        //Parameter�I�u�W�F�N�g�֒l�ݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                        findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                        findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                        findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;

                        myReader = sqlCommand.ExecuteReader();
                        if (myReader.Read())
                        {
                            //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                            DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                            if (_updateDateTime != empsalestargetWork.UpdateDateTime)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                                sqlCommand.Cancel();
                                return status;
                            }
                            //���݂̘_���폜�敪���擾
                            logicalDelCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));

                            sqlCommand.CommandText = "UPDATE EMPSALESTARGETRF SET UPDATEDATETIMERF=@UPDATEDATETIME , UPDEMPLOYEECODERF=@UPDEMPLOYEECODE , UPDASSEMBLYID1RF=@UPDASSEMBLYID1 , UPDASSEMBLYID2RF=@UPDASSEMBLYID2 , LOGICALDELETECODERF=@LOGICALDELETECODE WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                            //KEY�R�}���h���Đݒ�
                            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                            findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                            findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                            findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                            findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                            findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                            findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                            findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)empsalestargetWork;
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
                            else if (logicalDelCd == 0) empsalestargetWork.LogicalDeleteCode = 1;//�_���폜�t���O���Z�b�g
                            else empsalestargetWork.LogicalDeleteCode = 3;//���S�폜�t���O���Z�b�g
                        }
                        else
                        {
                            if (logicalDelCd == 1) empsalestargetWork.LogicalDeleteCode = 0;//�_���폜�t���O������
                            else
                            {
                                if (logicalDelCd == 0) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;	  //���ɕ������Ă���ꍇ�͂��̂܂ܐ����߂�
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
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(empsalestargetWork.UpdateDateTime);
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.UpdEmployeeCode);
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(empsalestargetWork.UpdAssemblyId1);
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(empsalestargetWork.UpdAssemblyId2);
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.LogicalDeleteCode);

                        sqlCommand.ExecuteNonQuery();
                        al.Add(empsalestargetWork);
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
                    if (!myReader.IsClosed) myReader.Close();
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            empsalestargetWorkList = al;

            return status;

        }
        #endregion

        #region [Delete]
        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">�]�ƈ��ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
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

                status = DeleteEmpSalesTargetProc(paraList, ref sqlConnection, ref sqlTransaction);
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
                base.WriteErrorLog(ex, "EmpSalesTargetDB.Delete");
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
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="empsalestargetWorkList">�]�ƈ��ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 �R�c ���F</br>
        /// <br>           : �]�ƈ��敪�ǉ�</br>
        public int DeleteEmpSalesTargetProc(ArrayList empsalestargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            return this.DeleteEmpSalesTargetProcProc(empsalestargetWorkList, ref sqlConnection, ref sqlTransaction);
        }

        /// <summary>
        /// �]�ƈ��ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)
        /// </summary>
        /// <param name="empsalestargetWorkList">�]�ƈ��ʔ���ڕW�ݒ�}�X�^���I�u�W�F�N�g</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^���𕨗��폜���܂�(�O�������SqlConnection SqlTranaction���g�p)</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 �R�c ���F</br>
        /// <br>           : �]�ƈ��敪�ǉ�</br>
        private int DeleteEmpSalesTargetProcProc( ArrayList empsalestargetWorkList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            string selectTxt = string.Empty;
            try
            {

                for (int i = 0; i < empsalestargetWorkList.Count; i++)
                {
                    EmpSalesTargetWork empsalestargetWork = empsalestargetWorkList[i] as EmpSalesTargetWork;

                    selectTxt = string.Empty;
                    selectTxt += "SELECT UPDATEDATETIMERF, ENTERPRISECODERF,LOGICALDELETECODERF FROM EMPSALESTARGETRF" + Environment.NewLine;
                    selectTxt += "WHERE" + Environment.NewLine;
                    selectTxt += " ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                    selectTxt += " AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                    selectTxt += " AND TARGETSETCDRF=@FINDTARGETSETCD" + Environment.NewLine;
                    selectTxt += " AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD" + Environment.NewLine;
                    selectTxt += " AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE" + Environment.NewLine;
                    selectTxt += " AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD" + Environment.NewLine;
                    selectTxt += " AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE" + Environment.NewLine;
                    selectTxt += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE" + Environment.NewLine;

                    sqlCommand = new SqlCommand(selectTxt, sqlConnection, sqlTransaction);

                    //Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                    SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                    SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);

                    //Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                    findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                    findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                    findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;

                    myReader = sqlCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        //����GUID�f�[�^������ꍇ�ōX�V�������قȂ�ꍇ�͔r���G���[�Ŗ߂�
                        DateTime _updateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));//�X�V����
                        if (_updateDateTime != empsalestargetWork.UpdateDateTime)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                            sqlCommand.Cancel();
                            return status;
                        }

                        sqlCommand.CommandText = "DELETE FROM EMPSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND SECTIONCODERF=@FINDSECTIONCODE AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE AND EMPLOYEECODERF=@FINDEMPLOYEECODE";
                        //KEY�R�}���h���Đݒ�
                        findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                        findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                        findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                        findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                        findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                        findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);
                        findParaEmployeeCode.Value = empsalestargetWork.EmployeeCode;
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
                    if (myReader.IsClosed == false) myReader.Close();
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
        /// <param name="searchEmpSalesTargetParaWork">���������i�[�N���X</param>
	    /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
	    /// <returns>Where����������</returns>
	    /// <br>Note       : Where����쐬���Ė߂��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 �R�c ���F</br>
        /// <br>           : �]�ƈ��敪�ǉ�</br>
        /// <br>Update Note: 2010/12/20  ������</br>
        /// <br>           : ���В�����ύX��ɁA�Ăяo�����s���Ǝ擾�o���Ȃ����R�[�h�����錻�ۂ̏C��</br>
        private string MakeWhereString(ref SqlCommand sqlCommand, SearchEmpSalesTargetParaWork searchEmpSalesTargetParaWork, ConstantManagement.LogicalMode logicalMode)
	    {
		    string wkstring = "";
		    string retstring = "WHERE ";

		    //��ƃR�[�h
		    retstring += "ESG.ENTERPRISECODERF=@ENTERPRISECODE ";
		    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
		    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(searchEmpSalesTargetParaWork.EnterpriseCode);

		    //�_���폜�敪
		    wkstring = "";
		    if ((logicalMode == ConstantManagement.LogicalMode.GetData0)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData1)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData2)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData3))
		    {
                wkstring = "AND ESG.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
		    }
		    else if	(	(logicalMode == ConstantManagement.LogicalMode.GetData01)||
			    (logicalMode == ConstantManagement.LogicalMode.GetData012))
		    {
                wkstring = "AND ESG.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
		    }
		    if(wkstring != "")
		    {
			    retstring += wkstring;
			    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
			    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
		    }

            //���_�R�[�h
            if (searchEmpSalesTargetParaWork.AllSecSelEpUnit == false && searchEmpSalesTargetParaWork.AllSecSelSecUnit == false)
            {
                if (searchEmpSalesTargetParaWork.SelectSectCd != null)
                {
                    wkstring = "";
                    foreach (string seccdstr in searchEmpSalesTargetParaWork.SelectSectCd)
                    {
                        if (wkstring != "") wkstring += ",";
                        wkstring += "'" + seccdstr + "'";
                    }
                    if (wkstring != "")
                    {
                        retstring += "AND ESG.SECTIONCODERF IN (" + wkstring + ") ";
                    }
                }
            }

            //�ڕW�ݒ�敪
            if (searchEmpSalesTargetParaWork.TargetSetCd > 0)
            {
                retstring += "AND ESG.TARGETSETCDRF=@TARGETSETCD ";
                SqlParameter paraTargetSetCd = sqlCommand.Parameters.Add("@TARGETSETCD", SqlDbType.Int);
                paraTargetSetCd.Value = SqlDataMediator.SqlSetInt32(searchEmpSalesTargetParaWork.TargetSetCd);
            }

            //�ڕW�Δ�敪
            if (searchEmpSalesTargetParaWork.TargetContrastCd > 0)
            {
                retstring += "AND ESG.TARGETCONTRASTCDRF=@TARGETCONTRASTCD ";
                SqlParameter paraTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                paraTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(searchEmpSalesTargetParaWork.TargetContrastCd);
            }
            // ---UPD 2010/12/20--------->>>>>
            ////�ڕW�敪�R�[�h
            //if (searchEmpSalesTargetParaWork.TargetDivideCode != "")
            //{
            //    retstring += "AND ESG.TARGETDIVIDECODERF=@TARGETDIVIDECODE ";
            //    SqlParameter paraTargetDivideCode = sqlCommand.Parameters.Add("@TARGETDIVIDECODE", SqlDbType.NChar);
            //    paraTargetDivideCode.Value = SqlDataMediator.SqlSetString(searchEmpSalesTargetParaWork.TargetDivideCode);
            //}

            //�ڕW�敪�R�[�h
            if (searchEmpSalesTargetParaWork.TargetDivideCode != "")
            {
                retstring += "AND ESG.TARGETDIVIDECODERF>=@TARGETDIVIDECODE1 ";
                retstring += "AND ESG.TARGETDIVIDECODERF<=@TARGETDIVIDECODE2 ";
                SqlParameter paraTargetDivideCode1 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE1", SqlDbType.NChar);
                SqlParameter paraTargetDivideCode2 = sqlCommand.Parameters.Add("@TARGETDIVIDECODE2", SqlDbType.NChar);
                paraTargetDivideCode1.Value = SqlDataMediator.SqlSetString(searchEmpSalesTargetParaWork.TargetDivideCode);
                int endYearMonth = Convert.ToInt32(searchEmpSalesTargetParaWork.TargetDivideCode) + 99;
                if (endYearMonth % 100 == 0)
                {
                    endYearMonth = Convert.ToInt32(searchEmpSalesTargetParaWork.TargetDivideCode) + 11;
                }
                paraTargetDivideCode2.Value = SqlDataMediator.SqlSetString(endYearMonth.ToString());
            }
            // ---UPD 2010/12/20---------<<<<<
            //�ڕW�敪����
            if (searchEmpSalesTargetParaWork.TargetDivideName != "")
            {
                retstring += "AND ESG.TARGETDIVIDENAMERF LIKE @TARGETDIVIDENAME ";
                SqlParameter paraTargetDivideName = sqlCommand.Parameters.Add("@TARGETDIVIDENAME", SqlDbType.NVarChar);
                paraTargetDivideName.Value = SqlDataMediator.SqlSetString("%" + searchEmpSalesTargetParaWork.TargetDivideName + "%");
            }

            //�]�ƈ��敪
            if (searchEmpSalesTargetParaWork.EmployeeDivCd > 0)
            {
                retstring += "AND ESG.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ";
                SqlParameter paraEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(searchEmpSalesTargetParaWork.EmployeeDivCd);
            }

            //����R�[�h
            if (searchEmpSalesTargetParaWork.SubSectionCode > 0)
            {
                retstring += "AND ESG.SUBSECTIONCODERF=@SUBSECTIONCODE ";
                SqlParameter paraSubSectionCode = sqlCommand.Parameters.Add("@SUBSECTIONCODE", SqlDbType.Int);
                paraSubSectionCode.Value = SqlDataMediator.SqlSetInt32(searchEmpSalesTargetParaWork.SubSectionCode);
            }

            //�]�ƈ��R�[�h
            if (searchEmpSalesTargetParaWork.EmployeeCode != "")
            {
                retstring += "AND ESG.EMPLOYEECODERF=@EMPLOYEECODE ";
                SqlParameter paraEmployeeCode = sqlCommand.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                paraEmployeeCode.Value = searchEmpSalesTargetParaWork.EmployeeCode;
            }
            // ---DEL 2010/12/20--------->>>>>
            ////�K�p�J�n���i�J�n�j
            //if (searchEmpSalesTargetParaWork.StartApplyStaDate > DateTime.MinValue)
            //{
            //    retstring += "AND ESG.APPLYSTADATERF>=@APPLYSTADATE ";
            //    SqlParameter paraStartApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            //    paraStartApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchEmpSalesTargetParaWork.StartApplyStaDate);
            //}

            ////�K�p�J�n���i�I���j
            //if (searchEmpSalesTargetParaWork.EndApplyStaDate > DateTime.MinValue)
            //{
            //    retstring += "AND ESG.APPLYSTADATERF<=@APPLYSTADATE ";
            //    SqlParameter paraEndApplyStaDate = sqlCommand.Parameters.Add("@APPLYSTADATE", SqlDbType.Int);
            //    paraEndApplyStaDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchEmpSalesTargetParaWork.EndApplyStaDate);
            //}

            ////�K�p�I�����i�J�n�j
            //if (searchEmpSalesTargetParaWork.StartApplyEndDate > DateTime.MinValue)
            //{
            //    retstring += "AND ESG.APPLYENDDATERF>=@APPLYENDDATE ";
            //    SqlParameter paraStartApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            //    paraStartApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchEmpSalesTargetParaWork.StartApplyEndDate);
            //}

            ////�K�p�I�����i�I���j
            //if (searchEmpSalesTargetParaWork.EndApplyEndDate > DateTime.MinValue)
            //{
            //    retstring += "AND ESG.APPLYENDDATERF<=@APPLYENDDATE ";
            //    SqlParameter paraEndApplyEndDate = sqlCommand.Parameters.Add("@APPLYENDDATE", SqlDbType.Int);
            //    paraEndApplyEndDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(searchEmpSalesTargetParaWork.EndApplyEndDate);
            //}
            // ---DEL 2010/12/20---------<<<<<
            //�\�[�g����
            retstring += "ORDER BY ESG.SECTIONCODERF,ESG.APPLYSTADATERF,ESG.APPLYENDDATERF,ESG.EMPLOYEEDIVCDRF,ESG.SUBSECTIONCODERF,ESG.EMPLOYEECODERF ";

		    return retstring;
		}
	    #endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� EmpSalesTargetWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>EmpSalesTargetWork</returns>
        /// <remarks>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.28  980081 �R�c ���F</br>
        /// <br>           : ���ʊ�Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2007.11.27  980081 �R�c ���F</br>
        /// <br>           : �]�ƈ��敪�ǉ�</br>
        /// </remarks>
        private EmpSalesTargetWork CopyToEmpSalesTargetWorkFromReader(ref SqlDataReader myReader)
        {
            EmpSalesTargetWork wkEmpSalesTargetWork = new EmpSalesTargetWork();

            #region �N���X�֊i�[
            wkEmpSalesTargetWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
            wkEmpSalesTargetWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
            wkEmpSalesTargetWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
            wkEmpSalesTargetWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
            wkEmpSalesTargetWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
            wkEmpSalesTargetWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
            wkEmpSalesTargetWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
            wkEmpSalesTargetWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            wkEmpSalesTargetWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            wkEmpSalesTargetWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
            wkEmpSalesTargetWork.TargetSetCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETSETCDRF"));
            wkEmpSalesTargetWork.TargetContrastCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TARGETCONTRASTCDRF"));
            wkEmpSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
            wkEmpSalesTargetWork.TargetDivideName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDENAMERF"));
            wkEmpSalesTargetWork.EmployeeDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("EMPLOYEEDIVCDRF"));
            wkEmpSalesTargetWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
            wkEmpSalesTargetWork.SubSectionName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUBSECTIONNAMERF"));
            wkEmpSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            wkEmpSalesTargetWork.EmployeeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEENAMERF"));
            wkEmpSalesTargetWork.ApplyStaDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYSTADATERF"));
            wkEmpSalesTargetWork.ApplyEndDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("APPLYENDDATERF"));
            wkEmpSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETMONEYRF"));
            wkEmpSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTARGETPROFITRF"));
            wkEmpSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESTARGETCOUNTRF"));
            #endregion

            return wkEmpSalesTargetWork;
        }
        #endregion

        #region [�p�����[�^�L���X�g����]
        /// <summary>
        /// �p�����[�^�L���X�g����
        /// </summary>
        /// <param name="paraobj">�p�����[�^</param>
        /// <returns>ArrayList</returns>
        /// <remarks>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        private ArrayList CastToArrayListFromPara(object paraobj)
        {
            ArrayList retal = null;
            EmpSalesTargetWork[] EmpSalesTargetWorkArray = null;

            if (paraobj != null)
                try
                {
                    //ArrayList�̏ꍇ
                    if (paraobj is ArrayList)
                    {
                        retal = paraobj as ArrayList;
                    }

                    //�p�����[�^�N���X�̏ꍇ
                    if (paraobj is EmpSalesTargetWork)
                    {
                        EmpSalesTargetWork wkEmpSalesTargetWork = paraobj as EmpSalesTargetWork;
                        if (wkEmpSalesTargetWork != null)
                        {
                            retal = new ArrayList();
                            retal.Add(wkEmpSalesTargetWork);
                        }
                    }

                    //byte[]�̏ꍇ
                    if (paraobj is byte[])
                    {
                        byte[] byteArray = paraobj as byte[];
                        try
                        {
                            EmpSalesTargetWorkArray = (EmpSalesTargetWork[])XmlByteSerializer.Deserialize(byteArray, typeof(EmpSalesTargetWork[]));
                        }
                        catch (Exception) { }
                        if (EmpSalesTargetWorkArray != null)
                        {
                            retal = new ArrayList();
                            retal.AddRange(EmpSalesTargetWorkArray);
                        }
                        else
                        {
                            try
                            {
                                EmpSalesTargetWork wkEmpSalesTargetWork = (EmpSalesTargetWork)XmlByteSerializer.Deserialize(byteArray, typeof(EmpSalesTargetWork));
                                if (wkEmpSalesTargetWork != null)
                                {
                                    retal = new ArrayList();
                                    retal.Add(wkEmpSalesTargetWork);
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
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.13</br>
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
