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
    /// ����ڕW�ݒ�}�X�^���DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����ڕW�ݒ�}�X�^����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// <br>Programmer :</br>
    /// <br>Date       :</br>
    /// </remarks>
    [Serializable]
    public class SalTrgtPrintResultDB : RemoteDB, ISalTrgtPrintResultDB
    {
        /// <summary>
        /// ����ڕW�ݒ�}�X�^���DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        /// </remarks>
        public SalTrgtPrintResultDB()
            :
            base("PMKHN08637D", "Broadleaf.Application.Remoting.ParamData.SalTrgtPrintResultWork", "EMPSALESTARGETRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̔���ڕW�ݒ�}�X�^����f�[�^��߂��܂�
        /// </summary>
        /// <param name="salesRsltListResultWorkk">��������</param>
        /// <param name="salTrgtPrintParamWork">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���ڕW�ݒ�}�X�^����f�[�^��߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2007.11.26</br>
        public int Search(out object salTrgtPrintResultWork, object salTrgtPrintParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salTrgtPrintResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSales12MonthsListData(out salTrgtPrintResultWork, salTrgtPrintParamWork, ref sqlConnection, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalTrgtPrintResultWorkDB.Search");
                salTrgtPrintResultWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̔���ڕW�ݒ�}�X�^����f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">��������</param>
        /// <param name="objSalesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���ڕW�ݒ�}�X�^����f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        private int SearchSales12MonthsListData(out object objSalTrgtPrintResultWork, object objSalTrgtPrintParamWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            SalTrgtPrintParamWork CndtnWork = null;

            ArrayList CndtnWorkList = objSalTrgtPrintParamWork as ArrayList;

            if (CndtnWorkList == null)
            {
                CndtnWork = objSalTrgtPrintParamWork as SalTrgtPrintParamWork;
            }
            else
            {
                if (CndtnWorkList.Count > 0)
                    CndtnWork = CndtnWorkList[0] as SalTrgtPrintParamWork;
            }

            ArrayList salesReportWorkList = null;

            //���i��
            if ((CndtnWork.PrintType == 44) || (CndtnWork.PrintType == 45))
            {
                mTtlSaSlip = new MTtlSaSlipGoods();
            }
            //���Ӑ��
            else if (CndtnWork.PrintType >= 30 && CndtnWork.PrintType <= 32)
            {
                mTtlSaSlip = new MTtlSaSlipCust();
            }
            //�S���ҕ�
            else if ((CndtnWork.PrintType == 10) || (CndtnWork.PrintType == 20) || (CndtnWork.PrintType == 22))
            {
                mTtlSaSlip = new MTtlSaSlipEmp();
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // ����ڕW�ݒ�}�X�^����f�[�^���捞��
            status = SearchSalesTargetDataProc(out salesReportWorkList, CndtnWork, ref sqlConnection,logicalMode);

            objSalTrgtPrintResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesTargetDataProc]
        /// <summary>
        /// �w�肳�ꂽ�����̔���ڕW�ݒ�}�X�^����f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">��������</param>
        /// <param name="salesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔���ڕW�ݒ�}�X�^����f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.11</br>
        /// <br></br>
        private int SearchSalesTargetDataProc(out ArrayList SalesTargetWorkList, SalTrgtPrintParamWork CndtnWork, ref SqlConnection sqlConnection, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlSaSlip.MakeSelectString(ref sqlCommand, CndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(mTtlSaSlip.CopyToSalesRsltListResultWorkFromReader(ref myReader, CndtnWork));

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
                base.WriteErrorLog(ex, "SalesRsltListResultDB.SearchSalesTargetDataProc");
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

            SalesTargetWorkList = al;

            return status;
        }
        #endregion  //SearchSalesTargetDataProc

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
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
