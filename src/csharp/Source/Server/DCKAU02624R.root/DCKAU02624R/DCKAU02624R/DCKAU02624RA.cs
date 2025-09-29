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
    /// ���|����ō��ٕ\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���|����ō��ٕ\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 980081�@�R�c ���F</br>
    /// <br>Date       : 2007.11.13</br>
    /// <br></br>
    /// <br>Update Note: 2008.01.08  980081 �R�c ���F</br>
    /// <br>           : ����Œ����z�̎擾���ύX(TaxAdjustRF��SalsePriceConsTaxRF)</br>
    /// <br>Update Note: 2008.09.30  22008 ���� ���n PM.NS�p�ɏC��</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class AccRecConsTaxDiffDB : RemoteDB, IAccRecConsTaxDiffDB
    {
        /// <summary>
        /// ���|����ō��ٕ\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 980081�@�R�c ���F</br>
        /// <br>Date       : 2007.11.13</br>
        /// </remarks>
        public AccRecConsTaxDiffDB()
            :
            base("DCKAU02626D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_AccRecConsTaxDiffWork", "SALESSLIPRF")
        {
        }

        /// <summary>
        /// �w�肳�ꂽ�����̔��|����ō��ٕ\LIST��߂��܂�
        /// </summary>
        /// <param name="accRecConsTaxDiffWork">��������</param>
        /// <param name="paraAccRecConsTaxDiffWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|����ō��ٕ\LIST��߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.11.13</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.08  980081 �R�c ���F</br>
        /// <br>           : ����Œ����z�̎擾���ύX(TaxAdjustRF��SalsePriceConsTaxRF)</br>
        public int SearchAccRecConsTaxDiffProc(out object accRecConsTaxDiffWork, object paraAccRecConsTaxDiffWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            accRecConsTaxDiffWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchAccRecConsTaxDiffProc(out accRecConsTaxDiffWork, paraAccRecConsTaxDiffWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "AccRecConsTaxDiffDB.SearchAccRecConsTaxDiffProc");
                accRecConsTaxDiffWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̔��|����ō��ٕ\LIST��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objAccRecConsTaxDiffWork">��������</param>
        /// <param name="paraAccRecConsTaxDiffWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|����ō��ٕ\LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.11.13</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.08  980081 �R�c ���F</br>
        /// <br>           : ����Œ����z�̎擾���ύX(TaxAdjustRF��SalsePriceConsTaxRF)</br>
        public int SearchAccRecConsTaxDiffProc(out object objAccRecConsTaxDiffWork, object paraAccRecConsTaxDiffWork, ref SqlConnection sqlConnection)
        {
            ExtrInfo_AccRecConsTaxDiffWork extrInfo_AccRecConsTaxDiffWork = null;

            ArrayList paraAccRecConsTaxDiffWorkList = paraAccRecConsTaxDiffWork as ArrayList;
            ArrayList accRecConsTaxDiffWorkList = new ArrayList();

            if (paraAccRecConsTaxDiffWorkList == null)
            {
                extrInfo_AccRecConsTaxDiffWork = paraAccRecConsTaxDiffWork as ExtrInfo_AccRecConsTaxDiffWork;
            }
            else
            {
                if (paraAccRecConsTaxDiffWorkList.Count > 0)
                    extrInfo_AccRecConsTaxDiffWork = paraAccRecConsTaxDiffWorkList[0] as ExtrInfo_AccRecConsTaxDiffWork;
            }

            int status = SearchAccRecConsTaxDiffProc(out accRecConsTaxDiffWorkList, extrInfo_AccRecConsTaxDiffWork, ref sqlConnection);
            objAccRecConsTaxDiffWork = accRecConsTaxDiffWorkList;
            return status;

        }

        /// <summary>
        /// �w�肳�ꂽ�����̔��|����ō��ٕ\LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="accRecConsTaxDiffWorkList">��������</param>
        /// <param name="extrInfo_AccRecConsTaxDiffWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��|����ō��ٕ\LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.11.13</br>
        /// <br></br>
        /// <br>Update Note: 2008.01.08  980081 �R�c ���F</br>
        /// <br>           : ����Œ����z�̎擾���ύX(TaxAdjustRF��SalsePriceConsTaxRF)</br>
        public int SearchAccRecConsTaxDiffProc(out ArrayList accRecConsTaxDiffWorkList, ExtrInfo_AccRecConsTaxDiffWork extrInfo_AccRecConsTaxDiffWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);
                sqlCommand.CommandText += MakeSelectString(ref sqlCommand, extrInfo_AccRecConsTaxDiffWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    al.Add(CopyToAccRecConsTaxDiffWorkFromReader(ref myReader, extrInfo_AccRecConsTaxDiffWork));

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

            accRecConsTaxDiffWorkList = al;

            return status;
        }

        /// <summary>
        /// SQL����
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="accRecConsTaxDiffWork">���������i�[�N���X</param>
        /// <returns>���|����ō��ٕ\��SQL������</returns>
        /// <br>Note       : ���|����ō��ٕ\��SQL���쐬���Ė߂��܂�</br>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.11.13</br>
        private string MakeSelectString(ref SqlCommand sqlCommand, ExtrInfo_AccRecConsTaxDiffWork accRecConsTaxDiffWork)
        {
            #region Select��
            string sqlString = "";
            sqlString += "SELECT" + Environment.NewLine;
            sqlString += "   SAL.RESULTSADDUPSECCDRF" + Environment.NewLine;
            sqlString += "  ,SEC.SECTIONGUIDESNMRF" + Environment.NewLine;
            sqlString += "  ,SAL.SALESDATERF" + Environment.NewLine;
            sqlString += "  ,SAL.CLAIMCODERF" + Environment.NewLine;
            sqlString += "  ,SAL.CLAIMSNMRF" + Environment.NewLine;
            sqlString += "  ,SAL.SALESSUBTOTALTAXRF" + Environment.NewLine;
            sqlString += "  ,SAL.SALESGOODSCDRF" + Environment.NewLine;
            sqlString += "FROM SALESSLIPRF SAL" + Environment.NewLine;
            sqlString += "LEFT JOIN SECINFOSETRF SEC ON(SEC.ENTERPRISECODERF = SAL.ENTERPRISECODERF AND SEC.SECTIONCODERF = SAL.SECTIONCODERF)" + Environment.NewLine;
            #endregion

            #region Where��
            sqlString += "WHERE ";

            //��ƃR�[�h
            sqlString += "SAL.ENTERPRISECODERF=@ENTERPRISECODE ";
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(accRecConsTaxDiffWork.EnterpriseCode);

            //�_���폜�敪
            sqlString += "AND SAL.LOGICALDELETECODERF=0 ";

            //�󒍃X�e�[�^�X
            sqlString += "AND SAL.ACPTANODRSTATUSRF=30 ";

            //���㏤�i�敪
            sqlString += "AND SAL.SALESGOODSCDRF IN (4,10) ";

            //0�~�ȊO��ΏۂƂ���
            sqlString += "AND SAL.SALESSUBTOTALTAXRF!=0 ";

            //���ьv�㋒�_�R�[�h
            if (accRecConsTaxDiffWork.SecCodeList != null)
            {
                string sectionString = "";
                foreach (string sectionCode in accRecConsTaxDiffWork.SecCodeList)
                {
                    if (sectionCode != "")
                    {
                        if (sectionString != "") sectionString += ",";
                        sectionString += "'" + sectionCode + "'";
                    }
                }
                if (sectionString != "")
                {
                    sqlString += "AND SAL.RESULTSADDUPSECCDRF IN (" + sectionString + ") ";
                }
            }

            //������t(�J�n)
            if (accRecConsTaxDiffWork.St_SalesDate != 0)
            {
                sqlString += "AND SAL.SALESDATERF>=@ST_SALESDATE ";
                SqlParameter paraSt_SalesDate = sqlCommand.Parameters.Add("@ST_SALESDATE", SqlDbType.Int);
                paraSt_SalesDate.Value = SqlDataMediator.SqlSetInt32(accRecConsTaxDiffWork.St_SalesDate);
            }

            //������t(�I��)
            if (accRecConsTaxDiffWork.Ed_SalesDate != 0)
            {
                sqlString += "AND SAL.SALESDATERF<=@ED_SALESDATE ";
                SqlParameter paraEd_SalesDate = sqlCommand.Parameters.Add("@ED_SALESDATE", SqlDbType.Int);
                paraEd_SalesDate.Value = SqlDataMediator.SqlSetInt32(accRecConsTaxDiffWork.Ed_SalesDate);
            }

            #endregion

            sqlString += "ORDER BY SAL.SECTIONCODERF, SAL.SALESDATERF, SAL.CLAIMCODERF, SAL.SALESSLIPNUMRF ";

            return sqlString;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� RsltInfo_AccRecConsTaxDiffWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="extrInfo_AccRecConsTaxDiffWork">�����p�����[�^</param>
        /// <returns>RsltInfo_AccRecConsTaxDiffWork</returns>
        /// <remarks>
        /// <br>Programmer : 980081  �R�c ���F</br>
        /// <br>Date       : 2007.11.13</br>
        /// </remarks>
        private RsltInfo_AccRecConsTaxDiffWork CopyToAccRecConsTaxDiffWorkFromReader(ref SqlDataReader myReader, ExtrInfo_AccRecConsTaxDiffWork extrInfo_AccRecConsTaxDiffWork)
        {
            RsltInfo_AccRecConsTaxDiffWork wkAccRecConsTaxDiffWork = new RsltInfo_AccRecConsTaxDiffWork();

            #region �N���X�֊i�[
            wkAccRecConsTaxDiffWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
            wkAccRecConsTaxDiffWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
            wkAccRecConsTaxDiffWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
            wkAccRecConsTaxDiffWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            wkAccRecConsTaxDiffWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            wkAccRecConsTaxDiffWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
            wkAccRecConsTaxDiffWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
            //����Ŕ��l
            if (wkAccRecConsTaxDiffWork.SalesGoodsCd == 4)
            {
                wkAccRecConsTaxDiffWork.TaxNote = "���|�p����Œ���";
            }
            else if (wkAccRecConsTaxDiffWork.SalesGoodsCd == 10)
            {
                wkAccRecConsTaxDiffWork.TaxNote = "���|�p����Œ���(����)";
            }
            #endregion

            return wkAccRecConsTaxDiffWork;
        }

        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 980081�@�R�c ���F</br>
        /// <br>Date       : 2007.11.13</br>
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
    }
}
