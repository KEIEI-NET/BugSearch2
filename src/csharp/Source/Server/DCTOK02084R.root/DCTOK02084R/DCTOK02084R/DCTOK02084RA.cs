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
    /// �d�����ڕ\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�����ڕ\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �R�c ���F</br>
    /// <br>Date       : 2007.11.30</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// <br>Date       : </br>
    /// <br>           : </br>
    /// </remarks>
    [Serializable]
    public class StockTransListResultDB : RemoteDB, IStockTransListResultDB
    {
        /// <summary>
        /// �d�����ڕ\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �R�c ���F</br>
        /// <br>Date       : 2007.11.30</br>
        /// </remarks>
        public StockTransListResultDB()
            :
            base("DCTOK02086D", "Broadleaf.Application.Remoting.ParamData.StockTransListResultWork", "STOCKTRANSLISTRESULTRF")
        {
        }

        IMTtlStSlip mTtlStSlip;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̎d�����ڕ\�f�[�^��߂��܂�
        /// </summary>
        /// <param name="stockTransListResultWork">��������</param>
        /// <param name="stockRsltListCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d�����ڕ\�f�[�^��߂��܂�</br>
        /// <br>Programmer : �R�c ���F</br>
        /// <br>Date       : 2007.11.30</br>
        public int Search(out object stockTransListResultWork, object stockRsltListCndtnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockTransListResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStock12MonthsListData(out stockTransListResultWork, stockRsltListCndtnWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockTransListResultWorkDB.Search");
                stockTransListResultWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̎d�����ڕ\�f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objStockTransListResultWork">��������</param>
        /// <param name="objStockTransListCndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d�����ڕ\�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �R�c ���F</br>
        /// <br>Date       : 2007.11.30</br>
        private int SearchStock12MonthsListData(out object objStockTransListResultWork, object objStockTransListCndtnWork, ref SqlConnection sqlConnection)
        {
            StockTransListCndtnWork CndtnWork = null;

            ArrayList CndtnWorkList = objStockTransListCndtnWork as ArrayList;

            if (CndtnWorkList == null)
            {
                CndtnWork = objStockTransListCndtnWork as StockTransListCndtnWork;
            }
            else
            {
                if (CndtnWorkList.Count > 0)
                    CndtnWork = CndtnWorkList[0] as StockTransListCndtnWork;
            }

            ArrayList stockReportWorkList = null;

            switch (CndtnWork.PrintSelectDiv)
            {
                case 0:     //���i��
                    mTtlStSlip = new MTtlStSlipGoods();
                    break;
                case 1:     //�d�����
                    mTtlStSlip = new MTtlStSlipSupl();
                    break;
                case 2:     //�S���ҕ�
                    mTtlStSlip = new MTtlStSlipEmp();
                    break;
                default:
                    mTtlStSlip = new MTtlStSlipGoods();
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // �d�����ڕ\�f�[�^���捞��
            status = SearchStockHistoryDataProc(out stockReportWorkList, CndtnWork, ref sqlConnection);

            objStockTransListResultWork = stockReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchStockHistoryDataProc]
        /// <summary>
        /// �w�肳�ꂽ�����̎d�����ڕ\�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockHistoryWorkList">��������</param>
        /// <param name="cndtnWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎d�����ڕ\�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �R�c ���F</br>
        /// <br>Date       : 2007.11.30</br>
        private int SearchStockHistoryDataProc(out ArrayList stockHistoryWorkList, StockTransListCndtnWork cndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlStSlip.MakeSelectString(ref sqlCommand, cndtnWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(mTtlStSlip.CopyToStockRsltListResultWorkFromReader(ref myReader, cndtnWork));

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

            stockHistoryWorkList = al;

            return status;
        }
        #endregion  //SearchStockHistoryDataProc


        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : �R�c ���F</br>
        /// <br>Date       : 2007.11.30</br>
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
