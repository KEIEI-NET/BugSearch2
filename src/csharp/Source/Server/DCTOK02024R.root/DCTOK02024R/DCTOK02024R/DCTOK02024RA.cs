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
    /// ������񌎕�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������񌎕�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�Ή�</br>
    /// <br>           : 23015 �X�{ ��P</br>
    /// <br>           : 2008.08.13</br>
    /// <br></br>
    /// <br>Update Note: �s��C��</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br>           : 2008.12.08</br>
    /// <br></br>
    /// <br>Update Note: �s��C��</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br>           : 2009.01.16</br>
    /// <br></br>
    /// <br>Update Note: ���x�`���[�j���O</br>
    /// <br>           : 22008 ���� ���n</br>
    /// <br>           : 2010/05/10</br>
    /// </remarks>
    [Serializable]
    public class SalesDayMonthReportResultDB : RemoteDB, ISalesDayMonthReportResultDB
    {
        /// <summary>
        /// ������񌎕�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.13</br>
        /// </remarks>
        public SalesDayMonthReportResultDB()
            :
            base("DCTOK02026D", "Broadleaf.Application.Remoting.ParamData.SalesDayMonthReportResultWork", "SALESDAYMONTHREPORTRESULTRF")
        {
        }

        ISalesSlipReport m_salesSlipReport;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̔�����񌎕�f�[�^��߂��܂�
        /// </summary>
        /// <param name="salesReportResultWorkk">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔�����񌎕�f�[�^��߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.13</br>
        public int Search(out object salesReportResultWork, object paramWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesReportResultWork = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                #region [�Í����L�[ �ꎞ�R�����g 2008.08.13]
                /*
                // 2008.03.24 Add >>>>>>>>
                // �Í������i��������
                sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                // �Í����L�[OPEN
                sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                // 2008.03.24 Add <<<<<<<<
                 */
                #endregion

                return SearchSalesStockDayMonthReportData(out salesReportResultWork, paramWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesRsltListResultDB.Search");
                salesReportResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                #region [�Í����L�[ �ꎞ�R�����g 2008.08.13]
                /*
                // 2008.03.24 Add >>>>>>>>
                // �Í����L�[�j��
                if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen))
                {
                    sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                }
                // 2008.03.24 Add <<<<<<<<
                 */
                #endregion

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�����̔�����񌎕�f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objSalesStockReportResultWork">��������</param>
        /// <param name="objSalesDayMonthReportParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔�����񌎕�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.13</br>
        private int SearchSalesStockDayMonthReportData(out object objSalesStockReportResultWork, object objSalesDayMonthReportParamWork, ref SqlConnection sqlConnection)
        {
            SalesDayMonthReportParamWork paramWork = null;

            //�p�����[�^�̃L���X�g
            ArrayList paramWorkList = objSalesDayMonthReportParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objSalesDayMonthReportParamWork as SalesDayMonthReportParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as SalesDayMonthReportParamWork;
            }

            ArrayList salesReportWorkList = null;

            //�����^�C�v����
            switch (paramWork.TotalType)
            {
                case (int)TotalType.Agent:             //Agent    = 1 -> �S���ҕ�
                case (int)TotalType.AcpOdr:            //AcpOdr   = 2 -> �󒍎ҕ�
                case (int)TotalType.Pblsher:           //Pblsher  = 3 -> ���s�ҕ�
                    m_salesSlipReport = new SalesSlipReport_Emp();
                    break;
                case (int)TotalType.Customer:          //Customer = 0 -> ���Ӑ��
                case (int)TotalType.Area:              //Area     = 4 -> �n���
                case (int)TotalType.BzType:            //BzType   = 5 -> �Ǝ��
                    m_salesSlipReport = new SalesSlipReport_Cust();
                    break;
                case (int)TotalType.SaleCd:            //SaleCd   = 6 -> �̔��敪��
                    m_salesSlipReport = new SalesSlipReport_Gcd();
                    break;
                default:
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // ������񌎕�f�[�^���捞��
            status = SearchSalesDayMonthReportDataProc(out salesReportWorkList, paramWork, ref sqlConnection);

            objSalesStockReportResultWork = salesReportWorkList;
            
            return status;
        }
        #endregion  //[Search]

        #region [SearchSalesStockHistoryDataProc]
        /// <summary>
        /// �w�肳�ꂽ�����̔�����񌎕�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">��������</param>
        /// <param name="salesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="termDiv">�W�v���ԋ敪  0:�w�茎�͈�  1:�����͈�</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔�����񌎕�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.13</br>
        private int SearchSalesDayMonthReportDataProc(out ArrayList salesHistoryWorkList, SalesDayMonthReportParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT������
                sqlCommand.CommandText = m_salesSlipReport.MakeSelectString(ref sqlCommand, paramWork);

                sqlCommand.CommandTimeout = 3600;
                
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //�擾���ʃZ�b�g
                    al.Add(m_salesSlipReport.CopyToResultWorkFromReader(ref myReader, paramWork));

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

            salesHistoryWorkList = al;

            return status;
        }
        #endregion  //[SearchSalesStockHistoryDataProc]

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.13</br>
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
