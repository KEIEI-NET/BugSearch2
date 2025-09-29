//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`�����ʕ\DB�����[�g�I�u�W�F�N�g
// �v���O�����T�v   : ��`�����ʕ\���f�[�^������s���N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���J��
// �� �� ��  2010/4/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Data.SqlTypes;
using System.Data.SqlClient;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Library.Resources;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ��`�����ʕ\ �����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��`�����ʕ\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���J��</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    [Serializable]
    public class TegataTorihikisakiListReportResultDB : RemoteDB , ITegataTorihikisakiListReportResultDB
    {
       #region �N���X�R���X�g���N�^
        /// <summary>
        /// ��`�����ʕ\�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public TegataTorihikisakiListReportResultDB()
            : base("PMTEG02509D", "Broadleaf.Application.Remoting.ParamData.TegataTorihikisakiListReportResultWork", "TegataTorihikisakiListReportRESULT")
        {

        }
        #endregion

       #region [Search]
        #region �w�肳�ꂽ�����̎�`�����ʕ\�ꗗ�\���LIST�̎擾����
        /// <summary>
        /// �w�肳�ꂽ�����̎�`�����ʕ\�ꗗ�\���LIST��߂��܂�
        /// </summary>
        /// <param name="TegataTorihikisakiListReportResultWork">��������</param>
        /// <param name="TegataTorihikisakiListReportParaWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̎�`�����ʕ\���LIST��߂��܂�</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public int Search(out object TegataTorihikisakiListReportResultWork, object TegataTorihikisakiListReportParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            TegataTorihikisakiListReportResultWork = new ArrayList();
            try
            {
                //�R���N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                // �������s��
                status = SearchProc(out TegataTorihikisakiListReportResultWork, TegataTorihikisakiListReportParaWork, ref sqlConnection);
                
            }
            catch (SqlException exSql)
            {
                base.WriteErrorLog(exSql, "TegataTorihikisakiListReportResultDB.Search");
                TegataTorihikisakiListReportResultWork = new ArrayList();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "TegataTorihikisakiListReportResultDB.Search");
                TegataTorihikisakiListReportResultWork = new ArrayList();
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
        #endregion

        #region �w�肳�ꂽ�����̎�`�����ʕ\�ꗗ�\���LIST(�O�������SqlConnection���g�p)
        /// <summary>
        /// �w�肳�ꂽ�����̎�`�����ʕ\�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="retList">�������ʌ����p�����[�^</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����̎�`�����ʕ\�ꗗ�\���LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private int SearchProc(out object retList, object paraObj, ref SqlConnection sqlConnection)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            TegataTorihikisakiListReportParaWork paraWork = null;
            paraWork = paraObj as TegataTorihikisakiListReportParaWork;

            retList = new ArrayList();
            ArrayList al = new ArrayList();

            // ����`�f�[�^sql
            StringBuilder selectTxt1 = new StringBuilder(string.Empty);
            // �x����`�f�[�^sql
            StringBuilder selectTxt2 = new StringBuilder(string.Empty);

            StringBuilder selectTxt = new StringBuilder(string.Empty);

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                // ��ʎw��̎�`�敪���u����`�v�̏ꍇ
                if (0 == paraWork.DraftDivide)
                {
                    selectTxt = MakeSearchSQL1(ref selectTxt1, ref sqlCommand, paraWork);

                }
                // ��ʎw��̎�`�敪���u�x����`�v�̏ꍇ
                else if (1 == paraWork.DraftDivide)
                {
                    selectTxt.Append(MakeSearchSQL2(ref selectTxt2, ref sqlCommand, paraWork));
                }
                if (0 == paraWork.DraftDivide)
                {
                    //���_�R�[�h
                    selectTxt.Append("ORDER BY A.SECTIONCODERF, ");
                    //���Ӑ�R�[�h
                    selectTxt.Append("A.CUSTOMERCODERF,  ");
                    //�L������
                    selectTxt.Append("A.VALIDITYTERMRF  ");
                }
                else
                {
                    //���_�R�[�h
                    selectTxt.Append("ORDER BY A.SECTIONCODERF, ");
                    //�d����R�[�h
                    selectTxt.Append("A.SUPPLIERCDRF,  ");
                    //�L������
                    selectTxt.Append("A.VALIDITYTERMRF  ");
 
                }

                sqlCommand.CommandText= selectTxt.ToString();
                myReader = sqlCommand.ExecuteReader();
                while (myReader.Read())
                {
                    al.Add(CopyToTegataTorihikisakiListReportResultWorkFromReader(ref myReader));
                }

                // �������ʂ�����ꍇ
                if (al.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                
            }
            catch (SqlException sqlex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(sqlex, "TegataTorihikisakiListReportResultDB.SearchProc", sqlex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "TegataTorihikisakiListReportResultDB.SearchProc" + status);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }
                }
            }
            retList = al;
            return status;
        }
        #endregion

        #region �����p����`�f�[�^�擾����
        /// <summary>
        /// �����p����`�f�[�^�擾����
        /// </summary>
        /// <param name="selectTxt1">sql��</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : �����p����`�f�[�^���擾���܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL1(ref StringBuilder selectTxt1, ref SqlCommand sqlCommand, TegataTorihikisakiListReportParaWork paraWork)
        {
            #region [�擾����]
            selectTxt1 = SelectRow(paraWork, selectTxt1);    
            #endregion
            #region [�e�[�u��]
            selectTxt1.Append("FROM ");
            selectTxt1.Append("RCVDRAFTDATARF A ");               // ����`�f�[�^
            #endregion
            #region [���o����]
            MakeWhereString1(ref selectTxt1, ref sqlCommand, paraWork);
            #endregion

            return selectTxt1;
            
        }
        #endregion

        #region �����p�x����`�f�[�^�擾����
        /// <summary>
        /// �����p�x����`�f�[�^�擾����
        /// </summary>
        /// <param name="selectTxt2">sql��</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : �����p�x����`�f�[�^���擾���܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks> 
        private StringBuilder MakeSearchSQL2(ref StringBuilder selectTxt2, ref SqlCommand sqlCommand, TegataTorihikisakiListReportParaWork paraWork)
        {
            #region [�擾����]
            selectTxt2 = SelectRow(paraWork, selectTxt2);
            #endregion
            #region [�e�[�u��]
            selectTxt2.Append("FROM ");
            selectTxt2.Append("PAYDRAFTDATARF A "); // �x����`�f�[�^
            #endregion
            #region [���o����]
            MakeWhereString2(ref selectTxt2, ref sqlCommand, paraWork);
            #endregion

            return selectTxt2;
        }
        #endregion

        #region [�擾����]
        /// <summary>
        /// �擾����
        /// </summary>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="selectTxt">sql��</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private StringBuilder SelectRow(TegataTorihikisakiListReportParaWork paraWork, StringBuilder selectTxt)
        {
            //�@��`�敪������`
            if (0 == paraWork.DraftDivide)
            {
                selectTxt.Append("SELECT ");
                selectTxt.Append("A.CUSTOMERCODERF CUSTOMERCODERF, ");            // ���Ӑ�R�[�h
                selectTxt.Append("A.CUSTOMERSNMRF CUSTOMERSNMRF, ");            // ���Ӑ旪��
                selectTxt.Append("A.SECTIONCODERF SECTIONCODERF, ");            // ���_�R�[�h
                selectTxt.Append("A.VALIDITYTERMRF VALIDITYTERMRF, ");            // �L������
                selectTxt.Append("A.DRAFTDIVIDERF DRAFTDIVIDERF, ");            // ��`�敪
                selectTxt.Append("A.DEPOSITRF DEPOSITRF ");                  // �������z
            }
            //�@��`�敪���x����`
            else if (1 == paraWork.DraftDivide)
            {
                selectTxt.Append("SELECT ");
                selectTxt.Append("A.SUPPLIERCDRF CUSTOMERCODERF, ");            // �d����R�[�h
                selectTxt.Append("A.SUPPLIERSNMRF CUSTOMERSNMRF, ");            // �d���旪��
                selectTxt.Append("A.SECTIONCODERF SECTIONCODERF, ");            // ���_�R�[�h
                selectTxt.Append("A.VALIDITYTERMRF VALIDITYTERMRF, ");            // �L������
                selectTxt.Append("A.DRAFTDIVIDERF DRAFTDIVIDERF, ");            // ��`�敪
                selectTxt.Append("A.PAYMENTRF DEPOSITRF ");                  // �x�����z
            }
            return selectTxt;
        }
        #endregion [�擾����]

        #region [Where���쐬����]
        /// <summary>
        /// ����`�f�[�^�������������񐶐������Ə����l�ݒ菈��
        /// </summary>
        /// <param name="sql">sql��</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private StringBuilder MakeWhereString1(ref StringBuilder sql, ref SqlCommand sqlCommand, TegataTorihikisakiListReportParaWork paraWork)
        {
            // �_���폜�敪
            sql.Append(" WHERE A.LOGICALDELETECODERF = 0 ");
            // ��ƃR�[�h=�p�����[�^.��ƃR�[�h
            sql.Append(" AND A.ENTERPRISECODERF=@ENTERPRISECODE1 ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE1", SqlDbType.NChar);
            ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

            // ���_�R�[�h
            if (paraWork.SectionCodes != null)
            {
                string sectionString = "";
                foreach (string sectionCode in paraWork.SectionCodes)
                {
                    if (!string.Empty.Equals(sectionCode))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // ���_�R�[�h
                    sql.Append(" AND A.SECTIONCODERF IN (" + sectionString + ")  ");

                }
            }

            // �L������ 
            if (paraWork.SalesDate != DateTime.MinValue)
            {
                // �L������ >= ����͈͔N��
                sql.Append(" AND A.VALIDITYTERMRF >= @FINDSTARTYEARDATE ");
                SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@FINDSTARTYEARDATE", SqlDbType.Int);
                paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.SalesDate);
            }
            // ��ʂ̎����(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeSt)) �@
            {
                sql.Append(" AND A.CUSTOMERCODERF >= @FINDSTCUSTOMERCODE ");
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeSt));
            }
            // ��ʂ̎����(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeEd)) �@
            {
                sql.Append(" AND A.CUSTOMERCODERF <= @FINDEDCUSTOMERCODE  ");
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeEd));
            }

            return sql;
        }

        /// <summary>
        /// �x����`�f�[�^�������������񐶐������Ə����l�ݒ菈��
        /// </summary>
        /// <param name="sql">sql��</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="paraWork">���������i�[�N���X</param>
        /// <returns>sql��</returns>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private StringBuilder MakeWhereString2(ref StringBuilder sql, ref SqlCommand sqlCommand, TegataTorihikisakiListReportParaWork paraWork)
        {
            // �_���폜�敪
            sql.Append(" WHERE A.LOGICALDELETECODERF = 0 ");

            // ��ƃR�[�h=�p�����[�^.��ƃR�[�h
            sql.Append(" AND A.ENTERPRISECODERF=@ENTERPRISECODE2 ");
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE2", SqlDbType.NChar);
            ServerLoginInfoAcquisition acquisition = new ServerLoginInfoAcquisition();
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(acquisition.EnterpriseCode);

            // ���_�R�[�h
            if (paraWork.SectionCodes != null)
            {
                string sectionString = "";
                foreach (string sectionCode in paraWork.SectionCodes)
                {
                    if (!string.Empty.Equals(sectionCode))
                    {
                        if (!string.Empty.Equals(sectionString))
                        {
                            sectionString += ",";
                        }
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (!string.Empty.Equals(sectionString))
                {
                    // ���_�R�[�h
                    sql.Append(" AND A.SECTIONCODERF IN (" + sectionString + ")  ");

                }
            }
            // �L������
            if (paraWork.SalesDate != DateTime.MinValue)
            {
                // �L������ >= ����͈͔N��
                sql.Append(" AND A.VALIDITYTERMRF >= @FINDSTARTYEARDATE ");
                SqlParameter paraSalesDate = sqlCommand.Parameters.Add("@FINDSTARTYEARDATE", SqlDbType.Int);
                paraSalesDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(paraWork.SalesDate);
            }

            // ��ʂ̎����(�J�n)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeSt))
            {
                sql.Append(" AND A.SUPPLIERCDRF >= @FINDSTCUSTOMERCODE2 ");
                SqlParameter paraStCustomerCode = sqlCommand.Parameters.Add("@FINDSTCUSTOMERCODE2", SqlDbType.Int);
                paraStCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeSt));
            }
            // ��ʂ̎����(�I��)�����͂��ꂽ�ꍇ
            if (!string.IsNullOrEmpty(paraWork.CustomerCodeEd))
            {
                sql.Append(" AND A.SUPPLIERCDRF <= @FINDEDCUSTOMERCODE2  ");
                SqlParameter paraEdCustomerCode = sqlCommand.Parameters.Add("@FINDEDCUSTOMERCODE2", SqlDbType.Int);
                paraEdCustomerCode.Value = SqlDataMediator.SqlSetInt32(Convert.ToInt32(paraWork.CustomerCodeEd));
            }
            return sql;
        }
        #endregion

        #endregion

       #region �N���X�i�[����
        /// <summary>
        /// �N���X�i�[���� Reader �� TegataTorihikisakiListReportResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>Result</returns>
        /// <remarks>
        /// <br>Note       : Reader����TegataTorihikisakiListReportResultWork�֕ϊ����܂��B</br>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        private TegataTorihikisakiListReportResultWork CopyToTegataTorihikisakiListReportResultWorkFromReader(ref SqlDataReader myReader)
        {
            TegataTorihikisakiListReportResultWork listWork = new TegataTorihikisakiListReportResultWork();
            #region �N���X�֊i�[

            // ���_
            listWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
            // ���Ӑ�R�[�h
            listWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            // ���Ӑ旪��
            listWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            // ��`�敪
            listWork.DraftDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DRAFTDIVIDERF"));
            // �L������
            listWork.ValidityTerm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("VALIDITYTERMRF"));
            // �������z
            listWork.Deposit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITRF"));

            return listWork;
            #endregion
        }
        #endregion  �N���X�i�[����

       #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���J��</br>
        /// <br>Date       : 2010.04.21</br>
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
