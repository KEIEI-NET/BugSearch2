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
    /// �d������N��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d������N��̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Date       : </br>
    /// <br>           : </br>
    /// </remarks>
    [Serializable]
    public class StockMonthYearReportResultDB : RemoteDB, IStockMonthYearReportResultDB
    {
        /// <summary>
        /// �d������N��DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public StockMonthYearReportResultDB()
            :
            base("DCMIT02136D", "Broadleaf.Application.Remoting.ParamData.StockMonthYearReportResultWork", "STOCKMONTHYEARREPORTRESULTRF")
        {
        }

        IMTtlStSlip mTtlStSlip = null;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̎d������N��f�[�^��߂��܂�
        /// </summary>
        /// <param name="stockMonthYearReportResultWork">��������</param>
        /// <param name="stockMonthYearReportParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d������N��f�[�^��߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        public int Search(out object stockMonthYearReportResultWork, object stockMonthYearReportParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockMonthYearReportResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockMonthYearReportData(out stockMonthYearReportResultWork, stockMonthYearReportParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesRsltListResultDB.Search");
                stockMonthYearReportResultWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̎d������N��f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objStockMonthYearReportResultWork">��������</param>
        /// <param name="objStockMonthYearReportParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d������N��f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        private int SearchStockMonthYearReportData(out object objStockMonthYearReportResultWork, object objStockMonthYearReportParamWork, ref SqlConnection sqlConnection)
        {
            StockMonthYearReportParamWork stockMonthYearReportParamWork = null;

            ArrayList stockMonthYearReportParamWorkList = objStockMonthYearReportParamWork as ArrayList;

            if (stockMonthYearReportParamWorkList == null)
            {
                stockMonthYearReportParamWork = objStockMonthYearReportParamWork as StockMonthYearReportParamWork;
            }
            else
            {
                if (stockMonthYearReportParamWorkList.Count > 0)
                    stockMonthYearReportParamWork = stockMonthYearReportParamWorkList[0] as StockMonthYearReportParamWork;
            }

            ArrayList salesReportWorkList = null;

            switch (stockMonthYearReportParamWork.TotalType)
            {
                case 0:     //���_��
                case 4:     //���[�J�[��
                    mTtlStSlip = new MTtlStSlipBL();
                    break;
                case 1:     //�d�����
                case 5:     //�d����ʃ��[�J�[��
                    mTtlStSlip = new MTtlStSlipSupl();
                    break;
                case 2:     //�S���ҕ�
                case 3:     //������
                    mTtlStSlip = new MTtlStSlipEmp();
                    break;
                default:
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // �d������N��f�[�^���捞��
            status = SearchSalesHistoryDataProc(out salesReportWorkList, stockMonthYearReportParamWork, ref sqlConnection);

            objStockMonthYearReportResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// �w�肳�ꂽ�����̎d������N��f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockReportWorkList">��������</param>
        /// <param name="stockMonthYearReportParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d������N��уf�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        private int SearchSalesHistoryDataProc(out ArrayList stockReportWorkList, StockMonthYearReportParamWork stockMonthYearReportParamWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlStSlip.MakeSelectString(ref sqlCommand, stockMonthYearReportParamWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(mTtlStSlip.CopyToResultWorkFromReader(ref myReader, stockMonthYearReportParamWork));

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

            stockReportWorkList = al;

            return status;
        }
        #endregion  //SearchSalesHistoryDataProc


        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���쏹��</br>
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
