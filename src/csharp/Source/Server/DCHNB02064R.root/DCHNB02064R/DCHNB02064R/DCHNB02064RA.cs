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
    /// �o�׏��i���ʕ\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�׏��i���ʕ\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.12.03</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�Ή�</br>
    /// <br>           : 23015 �X�{ ��P</br>
    /// <br>           : 2008.08.25</br>
    /// <br></br>
    /// <br>Update Note: �s��Ή�</br>
    /// <br>           : 23012 ���� �[���N</br>
    /// <br>           : 2008.11.04</br>
    /// <br></br>
    /// <br>Update Note: Mantis:14823 ���݈̂�������ꍇ�A����Ɉ������Ȃ����̏C��</br>
    /// <br>           : 30517 �Ė� �x��</br>
    /// <br>           : 2010/01/07</br>
    /// <br></br>
    /// <br>Update Note: �C�X�R�Ή��EREADUNCOMMITTED�Ή�</br>
    /// <br>           : 30517 �Ė� �x��</br>
    /// <br>           : 2011/08/01</br>
    /// </remarks>
    [Serializable]
    public class ShipmGoodsOdrReportResultDB : RemoteDB, IShipmGoodsOdrReportResultDB
    {
        /// <summary>
        /// �o�׏��i���ʕ\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.03</br>
        /// </remarks>
        public ShipmGoodsOdrReportResultDB()
            :
            base("DCHNB02066D", "Broadleaf.Application.Remoting.ParamData.ShipmGoodsOdrReportResultWork", "SHIPMGOODSODRREPORTRESULTRF")
        {
        }

        IMTtlSaSlip mTtlSaSlip;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̏o�׏��i���ʕ\�f�[�^��߂��܂�
        /// </summary>
        /// <param name="salesRsltListResultWorkk">��������</param>
        /// <param name="shipmGoodsOdrReportParam">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏o�׏��i���ʕ\�f�[�^��߂��܂�</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.03</br>
        public int Search(out object shipmGoodsOdrReportResultWork, object shipmGoodsOdrReportParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            shipmGoodsOdrReportResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchSales12MonthsListData(out shipmGoodsOdrReportResultWork, shipmGoodsOdrReportParam, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "ShipmGoodsOdrReportResultWorkDB.Search");
                shipmGoodsOdrReportResultWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̏o�׏��i���ʕ\�f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objSalesAnnualDataSelectResultWork">��������</param>
        /// <param name="objSalesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏o�׏��i���ʕ\�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.03</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.25</br>
        private int SearchSales12MonthsListData(out object objShipmGoodsOdrReportResultWork, object objShipmGoodsOdrReportParamWork, ref SqlConnection sqlConnection)
        {
            ShipmGoodsOdrReportParamWork CndtnWork = null;

            ArrayList CndtnWorkList = objShipmGoodsOdrReportParamWork as ArrayList;

            if (CndtnWorkList == null)
            {
                CndtnWork = objShipmGoodsOdrReportParamWork as ShipmGoodsOdrReportParamWork;
            }
            else
            {
                if (CndtnWorkList.Count > 0)
                    CndtnWork = CndtnWorkList[0] as ShipmGoodsOdrReportParamWork;
            }

            switch (CndtnWork.TotalType)
            {
                case (int)TotalType.Goods:     //���i��
                    mTtlSaSlip = new MTtlSaSlipGoods();
                    break;
                case (int)TotalType.BLCode:    //BL�R�[�h��
                    mTtlSaSlip = new MTtlSaSlipBLCd();
                    break;
                case (int)TotalType.Customer:  //���Ӑ��
                    mTtlSaSlip = new MTtlSaSlipCust();
                    break;
                case (int)TotalType.Agent:     //�S���ҕ�
                    mTtlSaSlip = new MTtlSaSlipEmp();
                    break;
            }

            ArrayList salesReportWorkList = new ArrayList();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            //Search���s
            status = SearchSalesHistoryDataProc(ref salesReportWorkList, CndtnWork, ref sqlConnection);

            objShipmGoodsOdrReportResultWork = salesReportWorkList;
            return status;

        }
        #endregion  //Search

        #region [SearchSalesHistoryDataProc]
        /// <summary>
        /// �w�肳�ꂽ�����̏o�׏��i���ʕ\�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWorkList">��������</param>
        /// <param name="salesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̏o�׏��i���ʕ\�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.12.03</br>
        /// <br></br>
        /// <br>Update Note: PM.NS�Ή�</br>
        /// <br>           : 23015 �X�{ ��P</br>
        /// <br>           : 2008.08.25</br>
        private int SearchSalesHistoryDataProc(ref ArrayList salesHistoryWorkList, ShipmGoodsOdrReportParamWork CndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                sqlCommand = new SqlCommand("", sqlConnection);

                sqlCommand.CommandText = mTtlSaSlip.MakeSelectString(ref sqlCommand, CndtnWork);

                //�^�C���A�E�g���Ԃ̐ݒ�i�b�j
                sqlCommand.CommandTimeout = 3600;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    //���ʎ擾
                    salesHistoryWorkList.Add(mTtlSaSlip.CopyToSalesRsltListResultWorkFromReader(ref myReader, CndtnWork));

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
                base.WriteErrorLog(ex, "ShipmGoodsOdrReportResultDB.SearchSalesHistoryDataProc");
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

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
        /// <br>Date       : 2007.12.03</br>
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
