using System;
using System.Collections;
using System.Collections.Generic;
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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���Ӑ�ʎ�����z�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ʎ�����z�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23012 �����@�[���N</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�Ή�</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br></br>
    /// <br>Update Note: �s��Ή�</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.05</br>
    /// </remarks>
    [Serializable]
    public class CustSalesDistributionReportResultDB : RemoteDB, ICustSalesDistributionReportResultDB
    {
        /// <summary>
        /// ���Ӑ�ʎ�����z�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23012 �����@�[���N</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public CustSalesDistributionReportResultDB()
            :
            base("PMHNB02189D", "Broadleaf.Application.Remoting.ParamData.CustSalesDistributionReportResultWork", "SALESHISTORYRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ�ʎ�����z�\�f�[�^��߂��܂�
        /// </summary>
        /// <param name="salesRsltListResultWorkk">��������</param>
        /// <param name="salesRsltListParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�ʎ�����z�\�f�[�^��߂��܂�</br>
        /// <br>Programmer : 23012 �����@�[���N</br>
        /// <br>Date       : 2007.11.26</br>
        public int Search(out object custSalesDistributionReportResultWork, object salesRsltListParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            custSalesDistributionReportResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSales12MonthsListData(out custSalesDistributionReportResultWork, salesRsltListParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "CustSalesDistributionReportResultWorkDB.Search");
                custSalesDistributionReportResultWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̓��Ӑ�ʎ�����z�\�f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">��������</param>
        /// <param name="objSalesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�ʎ�����z�\�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 �����@�[���N</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.21</br>
        private int SearchSales12MonthsListData(out object objCustSalesDistributionReportResultWork, object objCustSalesDistributionReportParamWork, ref SqlConnection sqlConnection)
        {
            CustSalesDistributionReportParamWork ParamWork = null;

            ArrayList ParamWorkList = objCustSalesDistributionReportParamWork as ArrayList;

            if (ParamWorkList == null)
            {
                ParamWork = objCustSalesDistributionReportParamWork as CustSalesDistributionReportParamWork;
            }
            else
            {
                if (ParamWorkList.Count > 0)
                    ParamWork = ParamWorkList[0] as CustSalesDistributionReportParamWork;
            }

            ArrayList salesReportWorkList = null;

            switch (ParamWork.PrintDiv)
            {
                case (int)TotalType.Customer:  //���Ӑ��
                    mTtlSaSlip = new MTtlSaSlipCust();
                    break;
                case (int)TotalType.Agent:     //�S���ҕ�
                    mTtlSaSlip = new MTtlSaSlipEmp();
                    break;
                case (int)TotalType.Area:     //�n��
                    mTtlSaSlip = new MTtlSaSlipArea();
                    break;
                default:
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // ���Ӑ�ʎ�����z�\�f�[�^���捞��
            status = SearchSalesHistoryDataProc(out salesReportWorkList, ParamWork, ref sqlConnection);

            objCustSalesDistributionReportResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// �w�肳�ꂽ�����̓��Ӑ�ʎ�����z�\�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">��������</param>
        /// <param name="salesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̓��Ӑ�ʎ�����z�\�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 �����@�[���N</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.21</br>
        private int SearchSalesHistoryDataProc(out ArrayList salesHistoryWorkList, CustSalesDistributionReportParamWork ParamWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlSaSlip.MakeSelectString(ref sqlCommand, ParamWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(mTtlSaSlip.CopyToSalesRsltListResultWorkFromReader(ref myReader, ParamWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesRsltListResultDB.SearchSalesHistoryDataProc");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                    sqlCommand.Dispose();

                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                        myReader.Close();
                }
            }

            salesHistoryWorkList = al;

            return status;
        }
        #endregion  //SearchSalesHistoryDataProc

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23012 �����@�[���N</br>
        /// <br>Date       : 2007.11.26</br>
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
        #endregion  //�R�l�N�V������������
    }

}
