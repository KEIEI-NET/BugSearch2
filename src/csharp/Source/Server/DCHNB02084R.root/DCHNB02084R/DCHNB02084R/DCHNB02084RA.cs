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
    /// ���㌎��N��DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㌎��N��̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�Ή�</br>
    /// <br>           : 23015 �X�{ ��P</br>
    /// <br>           : 2008.08.06</br>
    /// </remarks>
    [Serializable]
    public class SalesMonthYearReportResultDB : RemoteDB, ISalesMonthYearReportResultDB
    {
        /// <summary>
        /// ���㌎��N��DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.06</br>
        /// <br></br>
        /// <br>Update Note: �s��Ή�</br>
        /// <br>           : 23012 ���� �[���N</br>
        /// <br>           : 2008.12.08</br>
        /// <br></br>
        /// <br>Update Note: �C�X�R�Ή��EREADUNCOMMITTED�Ή�</br>
        /// <br>           : 30517 �Ė� �x��</br>
        /// <br>           : 2011/07/29</br>
        /// </remarks>
        public SalesMonthYearReportResultDB()
            :
            base("DCHNB02086D", "Broadleaf.Application.Remoting.ParamData.SalesMonthYearReportResultWork", "SALESMONTHYEARREPORTRESULTRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̔��㌎��N��f�[�^��߂��܂�
        /// </summary>
        /// <param name="salesRsltListResultWorkk">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��㌎��N��f�[�^��߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.06</br>
        public int Search(out object salesRsltListResultWork, object paramWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            salesRsltListResultWork = null;
            SqlEncryptInfo sqlEncryptInfo = null;

            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                #region [�Í����L�[ �ꎞ�R�����g 2008.08.06]
                /*
                // 2008.04.02 Add >>>>>>>>
                // �Í������i��������
                sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] { "CUSTOMERRF" });
                // �Í����L�[OPEN
                sqlEncryptInfo.OpenSymKey(ref sqlConnection);
                // 2008.04.02 Add <<<<<<<<
                 */
                #endregion

                return SearchsalesDayMonthReportData(out salesRsltListResultWork, paramWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesRsltListResultDB.Search");
                salesRsltListResultWork = new ArrayList();
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                #region [�Í����L�[ �ꎞ�R�����g 2008.08.06]
                /*
                // 2008.04.02 Add >>>>>>>>
                // �Í����L�[�j��
                if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen))
                {
                    sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                }
                // 2008.04.02 Add <<<<<<<<
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
        /// �w�肳�ꂽ�����̔��㌎��N��f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">��������</param>
        /// <param name="objSalesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��㌎��N��f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.06</br>
        private int SearchsalesDayMonthReportData(out object objSalesRsltListResultWork, object objSalesMonthYearReportParamWork, ref SqlConnection sqlConnection)
        {
            SalesMonthYearReportParamWork paramWork = null;

            //�p�����[�^�̃L���X�g
            ArrayList paramWorkList = objSalesMonthYearReportParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objSalesMonthYearReportParamWork as SalesMonthYearReportParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as SalesMonthYearReportParamWork;
            }

            ArrayList salesReportWorkList = null;

            //�����^�C�v����
            switch (paramWork.TotalType)
            {
                case (int)TotalType.Agent:             //Agent    = 1 -> �S���ҕ�
                case (int)TotalType.AcpOdr:            //AcpOdr   = 2 -> �󒍎ҕ�
                case (int)TotalType.Pblsher:           //Pblsher  = 3 -> ���s�ҕ�
                    mTtlSaSlip = new MTtlSaSlip_Emp();
                    break;
                case (int)TotalType.Customer:          //Customer = 0 -> ���Ӑ��
                case (int)TotalType.Area:              //Area     = 4 -> �n���
                case (int)TotalType.BzType:            //BzType   = 5 -> �Ǝ��
                    mTtlSaSlip = new MTtlSaSlip_Cust();
                    break;
                case (int)TotalType.SaleCd:            //SaleCd   = 6 -> �̔��敪��
                    mTtlSaSlip = new MTtlSaSlip_Gcd();
                    break;
                default:
                    break;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            
            // ���㌎��N��f�[�^���捞��
            status = SearchSalesHistoryDataProc(out salesReportWorkList, paramWork, ref sqlConnection);

            //���s���ʎ擾
            objSalesRsltListResultWork = salesReportWorkList;
            return status;
        }
        #endregion  //[Search]

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// �w�肳�ꂽ�����̔��㌎��N��f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">��������</param>
        /// <param name="salesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="termDiv">�W�v���ԋ敪  0:�w�茎�͈�  1:�����͈�</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̔��㌎��N��f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.11.26</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.06</br>
        private int SearchSalesHistoryDataProc(out ArrayList salesHistoryWorkList, SalesMonthYearReportParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            SalesMonthYearReportResultWork ResultWork = null;

            ArrayList al = new ArrayList();
            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                //SELECT������
                sqlCommand.CommandText = mTtlSaSlip.MakeSelectString(ref sqlCommand, paramWork);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //���o���ʎ擾
                    ResultWork = mTtlSaSlip.CopyToResultWorkFromReader(ref myReader, paramWork);
                    //�擾���ʃZ�b�g
                    al.Add(ResultWork);

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
        #endregion  //[SearchSalesHistoryDataProc]

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
        /// <br>           : 2008.08.06</br>
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
