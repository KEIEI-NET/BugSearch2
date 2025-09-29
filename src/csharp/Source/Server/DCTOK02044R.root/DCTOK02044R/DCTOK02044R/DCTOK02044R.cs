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
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����d���Δ�\(���񌎕�)DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����d���Δ�\(���񌎕�)�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23012 ���� �[���N</br>
    /// <br>Date       : 2008.11.18</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class SalStcCompReportResultWorkDB : RemoteDB, ISalStcCompReportResultWorkDB
    {
        /// <summary>
        /// ����d���Δ�\(���񌎕�)DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.18</br>
        /// </remarks>
        public SalStcCompReportResultWorkDB()
            :
        base("DCTOK02046D", "Broadleaf.Application.Remoting.ParamData.SalStcCompReportResultWork", "MTTLSALESSTOCKSLIPRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region ����d���Δ�\(���񌎕�)
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔���d���Δ�\(���񌎕�)LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="customInqResultWork">��������</param>
        /// <param name="customInqOrderParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔���d���Δ�\(���񌎕�)LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.18</br>
        public int Search(out object salStcCompReportResultList, object salStcCompReportParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            salStcCompReportResultList = null;

            SalStcCompReportParamWork _salStcCompReportParamWork = salStcCompReportParamWork as SalStcCompReportParamWork;

            try
            {
                status = SearchProc(out salStcCompReportResultList, _salStcCompReportParamWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalStcCompReportResultWorkDB.Search Exception=" + ex.Message);
                salStcCompReportResultList = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔���d���Δ�\(���񌎕�)LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="salStcCompReportResultList">��������</param>
        /// <param name="_salStcCompReportParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔���d���Δ�\(���񌎕�)LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.11.18</br>
        private int SearchProc(out object salStcCompReportResultList, SalStcCompReportParamWork _salStcCompReportParamWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            salStcCompReportResultList = null;

            ArrayList al = new ArrayList();   //���o����

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();


                status = SearchOrderProc(ref al, ref sqlConnection, _salStcCompReportParamWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalStcCompReportResultWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            salStcCompReportResultList = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_salStcCompReportParamWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchOrderProc(ref ArrayList al, ref SqlConnection sqlConnection, SalStcCompReportParamWork _salStcCompReportParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt="";

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                selectTxt = "";

                sqlCommand.Parameters.Clear();
                //SELECT���쐬
                selectTxt += MakeSelectString(ref sqlCommand, _salStcCompReportParamWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    SalStcCompReportResultWork ResultWork = new SalStcCompReportResultWork();
                    //�i�[����
                    ResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                    ResultWork.SecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    ResultWork.SectionGuideSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDESNMRF"));
                    ResultWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    ResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    ResultWork.SalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEY"));
                    ResultWork.SalesMoneyStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYSTOCK"));
                    ResultWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
                    ResultWork.MoveCountSales = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTSALES"));
                    ResultWork.StockUnitPriceFlSales = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLSALES"));
                    ResultWork.StockMovePriceSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMOVEPRICESALES")); // ADD 2009.03.09 
                    ResultWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXC"));
                    ResultWork.StockPriceTaxExcStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCSTOCK"));
                    ResultWork.MoveCountSalesSlip = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTSLIP"));
                    ResultWork.StockUnitPriceFlSalesSlip = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLSLIP"));
                    ResultWork.StockMovePriceSlip = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMOVEPRICESLIP")); // ADD 2009.03.09 
                    ResultWork.MonthSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESMONEY"));
                    ResultWork.MonthSalesMoneyStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSALESMONEYSTOCK"));
                    ResultWork.MonthTotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHTOTALCOSTRF"));
                    ResultWork.MonthMoveCountSales = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHMOVECOUNTSALES"));
                    ResultWork.MonthStockUnitPriceFlSales = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHSTOCKUNITPRICEFLSALES"));
                    ResultWork.MonthStockMovePriceSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSTOCKMOVEPRICESALES")); // ADD 2009.03.09
                    ResultWork.MonthStockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSTOCKPRICETAXEXC"));
                    ResultWork.MonthStockPriceTaxExcStock = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSTOCKPRICETAXEXCSTOCK"));
                    ResultWork.MonthMoveCountSalesSlip = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHMOVECOUNTSLIP"));
                    ResultWork.MonthStockUnitPriceFlSalesSlip = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MONTHSTOCKUNITPRICEFLSLIP"));
                    ResultWork.MonthStockMovePriceSlip = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONTHSTOCKMOVEPRICESLIP")); // ADD 2009.03.09
                    #endregion

                    al.Add(ResultWork);

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
                base.WriteErrorLog(ex, "customInqResultWork.SearchOrderProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        #endregion

        #region SELECT������
        /// <summary>
        /// ���s�^�C�v�ʂ�SELECT�����쐬
        /// </summary>
        /// <param name="printDiv">���s�^�C�v</param>
        /// <returns>SELECT��</returns>
        private string MakeSelectString(ref SqlCommand sqlCommand, SalStcCompReportParamWork _salStcCompReportParamWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retString = string.Empty;
            if (retString == "")
            {
                retString += "SELECT" + Environment.NewLine;
                retString += "JOININF.ENTERPRISECODERF" + Environment.NewLine;
                retString += ",JOININF.SECTIONCODERF" + Environment.NewLine;
                retString += ",SECINF.SECTIONGUIDESNMRF" + Environment.NewLine;
                retString += ",JOININF.SUPPLIERCDRF" + Environment.NewLine;
                retString += ",SUPP.SUPPLIERSNMRF" + Environment.NewLine;
                retString += ",SALESD.TOTALCOSTRF" + Environment.NewLine;
                retString += ",SALESD.SALESMONEY" + Environment.NewLine;
                retString += ",SALESD.SALESMONEYSTOCK" + Environment.NewLine;
                retString += ",SALESSTOCKD.MOVECOUNTRF AS MOVECOUNTSALES" + Environment.NewLine;
                retString += ",SALESSTOCKD.STOCKUNITPRICEFLRF AS STOCKUNITPRICEFLSALES " + Environment.NewLine;
                retString += ",SALESSTOCKD.STOCKMOVEPRICESALES  AS STOCKMOVEPRICESALES " + Environment.NewLine; // ADD 2009.03.09
                retString += ",SLIPD.STOCKPRICETAXEXC" + Environment.NewLine;
                retString += ",SLIPD.STOCKPRICETAXEXCSTOCK" + Environment.NewLine;
                retString += ",SLIPSTOCKD.MOVECOUNTRF AS MOVECOUNTSLIP" + Environment.NewLine;
                retString += ",SLIPSTOCKD.STOCKUNITPRICEFLRF AS STOCKUNITPRICEFLSLIP" + Environment.NewLine;
                retString += ",SLIPSTOCKD.STOCKMOVEPRICESLIP AS STOCKMOVEPRICESLIP" + Environment.NewLine; // ADD 2009.03.09 
                retString += ",SALESM.TOTALCOSTRF AS MONTHTOTALCOSTRF" + Environment.NewLine;
                retString += ",SALESM.SALESMONEY AS MONTHSALESMONEY" + Environment.NewLine;
                retString += ",SALESM.SALESMONEYSTOCK AS MONTHSALESMONEYSTOCK" + Environment.NewLine;
                retString += ",SALESSTOCKM.MOVECOUNTRF AS MONTHMOVECOUNTSALES" + Environment.NewLine;
                retString += ",SALESSTOCKM.STOCKUNITPRICEFLRF AS MONTHSTOCKUNITPRICEFLSALES " + Environment.NewLine;
                retString += ",SALESSTOCKM.MONTHSTOCKMOVEPRICESALES AS MONTHSTOCKMOVEPRICESALES" + Environment.NewLine; // ADD 2009.03.09
                retString += ",SLIPM.STOCKPRICETAXEXC AS MONTHSTOCKPRICETAXEXC" + Environment.NewLine;
                retString += ",SLIPM.STOCKPRICETAXEXCSTOCK AS MONTHSTOCKPRICETAXEXCSTOCK" + Environment.NewLine;
                retString += ",SLIPSTOCKM.MOVECOUNTRF AS MONTHMOVECOUNTSLIP" + Environment.NewLine;
                retString += ",SLIPSTOCKM.STOCKUNITPRICEFLRF AS MONTHSTOCKUNITPRICEFLSLIP" + Environment.NewLine;
                retString += ",SLIPSTOCKM.MONTHSTOCKMOVEPRICESLIP AS  MONTHSTOCKMOVEPRICESLIP" + Environment.NewLine; // ADD 2009.03.09

                #region ���o�Ώہ@���_�E�d����
                retString += "FROM" + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += "  SELECT" + Environment.NewLine;
                retString += "   SALESDTLJ.ENTERPRISECODERF" + Environment.NewLine;
                
                // --- ADD 2009/04/07 ------->>> // �o�͋��_�𔄏���͋��_�ɕύX
                //retString += "   ,SAHIST.SALESINPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
                //retString += "   ,SECTIONCODERF" + Environment.NewLine;
                retString += "     ,SAHIST.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine;�@// ADD 2009.05.20
                // --- ADD 2009/04/07 -------<<<
                
                retString += "   ,SALESDTLJ.SUPPLIERCDRF" + Environment.NewLine;
                retString += "  FROM SALESHISTDTLRF AS SALESDTLJ" + Environment.NewLine;

                // --- ADD 2009/04/07 ------->>> // ���_�p�ɔ��㗚���Q��/WHERE���ύX
                retString += "  LEFT JOIN SALESHISTORYRF AS SAHIST" + Environment.NewLine;
                retString += "  ON  SAHIST.ENTERPRISECODERF = SALESDTLJ.ENTERPRISECODERF" + Environment.NewLine;
                retString += "  AND SAHIST.ACPTANODRSTATUSRF = SALESDTLJ.ACPTANODRSTATUSRF" + Environment.NewLine;
                retString += "  AND SAHIST.SALESSLIPNUMRF = SALESDTLJ.SALESSLIPNUMRF" + Environment.NewLine;
                retString += MakeWhereSalesHist(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "SALESDTLJ", 1, 1);
                //retString += MakeWhereString(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "SALESDTLJ", 1, 1);
                // --- ADD 2009/04/07 -------<<<

                retString += "   AND (SALESDTLJ.SALESSLIPCDDTLRF =0 or  SALESDTLJ.SALESSLIPCDDTLRF =1 or SALESDTLJ.SALESSLIPCDDTLRF =2 )" + Environment.NewLine;
                retString += "  UNION" + Environment.NewLine;
                retString += "  SELECT" + Environment.NewLine;
                retString += "   SLIPHISDTLJ.ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,SLIPHISDTLJ.SECTIONCODERF" + Environment.NewLine;
                retString += "  ,SLIPHISDTLJ.SUPPLIERCDRF " + Environment.NewLine;

                retString += "  FROM" + Environment.NewLine;
                retString += "  (" + Environment.NewLine;
                retString += "	SELECT" + Environment.NewLine;
                retString += "     SLIPDTL.ENTERPRISECODERF" + Environment.NewLine;

                // --- ADD 2009/04/07 ------>>> // �d���v�㋒�_�R�[�h�ɕύX
                //retString += "     ,SLIPHIS.STOCKADDUPSECTIONCDRF AS SECTIONCODERF" + Environment.NewLine; // DEL 2009.05.25
                retString += "     ,SLIPHIS.STOCKSECTIONCDRF AS SECTIONCODERF" + Environment.NewLine; // ADD 2009.05.25
                //retString += "     ,SLIPDTL.SECTIONCODERF" + Environment.NewLine;
                // --- ADD 2009/04/07 -------<<<
                
                retString += "     ,SLIPHIS.SUPPLIERCDRF" + Environment.NewLine;
                retString += "     ,SLIPHIS.STOCKDATERF" + Environment.NewLine;
                retString += "     ,SLIPHIS.LOGICALDELETECODERF" + Environment.NewLine;
                retString += "    FROM STOCKSLHISTDTLRF AS SLIPDTL " + Environment.NewLine;
                retString += "    LEFT JOIN" + Environment.NewLine;
                retString += "     STOCKSLIPHISTRF AS SLIPHIS" + Environment.NewLine;
                retString += "    ON SLIPDTL.ENTERPRISECODERF = SLIPHIS.ENTERPRISECODERF" + Environment.NewLine;
                retString += "     AND SLIPDTL.SECTIONCODERF = SLIPHIS.SECTIONCODERF" + Environment.NewLine;
                retString += "     AND SLIPDTL.SUPPLIERSLIPNORF = SLIPHIS.SUPPLIERSLIPNORF" + Environment.NewLine;
                retString += "     AND SLIPDTL.SUPPLIERFORMALRF = SLIPHIS.SUPPLIERFORMALRF" + Environment.NewLine;
                retString += "  ) AS SLIPHISDTLJ" + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "SLIPHISDTLJ", 2, 1);
                retString += "  UNION" + Environment.NewLine;
                retString += "  SELECT" + Environment.NewLine;
                retString += "   ENTERPRISECODERF" + Environment.NewLine;
                retString += "   ,BFSECTIONCODERF" + Environment.NewLine;
                retString += "   ,SUPPLIERCDRF" + Environment.NewLine;
                retString += "  FROM" + Environment.NewLine;
                retString += "   STOCKMOVERF AS STOCKMBFJ" + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "STOCKMBFJ", 3, 1);               
                retString += "  UNION" + Environment.NewLine;
                retString += "  SELECT" + Environment.NewLine;
                retString += "   ENTERPRISECODERF" + Environment.NewLine;
                retString += "   ,AFSECTIONCODERF" + Environment.NewLine;
                retString += "   ,SUPPLIERCDRF" + Environment.NewLine;
                retString += "  FROM" + Environment.NewLine;
                retString += "   STOCKMOVERF AS STOCKMAFJ " + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "STOCKMAFJ", 4, 1);               
                retString += ") AS JOININF" + Environment.NewLine;

                #endregion

                #region �݌v�f�[�^�W�v
                retString += "LEFT JOIN " + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += "  SELECT " + Environment.NewLine;
                retString += "  SALESDTLM.ENTERPRISECODERF" + Environment.NewLine;
                // --- ADD 2009/04/07 ------->>> // �o�͋��_�𔄏���͋��_�ɕύX
                //retString += "  ,SAHIST.SALESINPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
                retString += "  ,SAHIST.RESULTSADDUPSECCDRF AS SECTIONCODERF" + Environment.NewLine; // ADD 2009.05.20
                
                //retString += "  ,SECTIONCODERF" + Environment.NewLine;
                // --- ADD 2009/04/07 ------->>> 
                retString += "  ,SALESDTLM.SUPPLIERCDRF" + Environment.NewLine;
                retString += "  ,SUM(SALESDTLM.COSTRF) AS TOTALCOSTRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN SALESDTLM.SALESORDERDIVCDRF=0 THEN SALESDTLM.SALESMONEYTAXEXCRF ELSE 0 END) AS SALESMONEY" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN SALESDTLM.SALESORDERDIVCDRF=1 THEN SALESDTLM.SALESMONEYTAXEXCRF ELSE 0 END) AS SALESMONEYSTOCK" + Environment.NewLine;
                retString += "  FROM" + Environment.NewLine;
                retString += "  SALESHISTDTLRF AS  SALESDTLM" + Environment.NewLine;
                // --- ADD 2009/04/07 ------->>> // ���_�p�ɔ��㗚���Q��/WHERE��/GROUPBY�ύX
                retString += "  LEFT JOIN SALESHISTORYRF AS SAHIST" + Environment.NewLine;
                retString += "  ON  SAHIST.ENTERPRISECODERF = SALESDTLM.ENTERPRISECODERF" + Environment.NewLine;
                retString += "  AND SAHIST.ACPTANODRSTATUSRF = SALESDTLM.ACPTANODRSTATUSRF" + Environment.NewLine;
                retString += "  AND SAHIST.SALESSLIPNUMRF = SALESDTLM.SALESSLIPNUMRF" + Environment.NewLine;
                retString += MakeWhereSalesHist(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "SALESDTLM", 1, 1);
                //retString += MakeWhereString(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "SALESDTLM", 1, 1);
                retString += "  AND (SALESDTLM.SALESSLIPCDDTLRF =0 or  SALESDTLM.SALESSLIPCDDTLRF =1 or SALESDTLM.SALESSLIPCDDTLRF =2 )" + Environment.NewLine;
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "  SALESDTLM.ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,SAHIST.RESULTSADDUPSECCDRF" + Environment.NewLine; // ADD 2009.05.20
                //retString += "  ,SAHIST.SALESINPSECCDRF" + Environment.NewLine;�@
                retString += "  ,SALESDTLM.SUPPLIERCDRF  " + Environment.NewLine;
                // --- ADD 2009/04/07 ------->>> 
                retString += ") AS SALESM" + Environment.NewLine;
                retString += "ON JOININF.ENTERPRISECODERF = SALESM.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND JOININF.SECTIONCODERF = SALESM.SECTIONCODERF" + Environment.NewLine;
                retString += "AND JOININF.SUPPLIERCDRF = SALESM.SUPPLIERCDRF" + Environment.NewLine;
                retString += "LEFT JOIN " + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += " SELECT" + Environment.NewLine;
                retString += "   SLIPHISDTLM.ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,SLIPHISDTLM.SECTIONCODERF" + Environment.NewLine;
                retString += "  ,SLIPHISDTLM.SUPPLIERCDRF " + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN STOCKORDERDIVCDRF=0 THEN STOCKPRICETAXEXCRF ELSE 0 END) AS STOCKPRICETAXEXC" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN STOCKORDERDIVCDRF=1 THEN STOCKPRICETAXEXCRF ELSE 0 END) AS STOCKPRICETAXEXCSTOCK" + Environment.NewLine;
                retString += "  FROM" + Environment.NewLine;
                retString += "  (" + Environment.NewLine;
                retString += "   SELECT" + Environment.NewLine;
                retString += "    SLIPDTL.ENTERPRISECODERF" + Environment.NewLine;
                // --- ADD 2009/04/07 ------>>> // �d���v�㋒�_�R�[�h�ɕύX
                //retString += "     ,SLIPHIS.STOCKADDUPSECTIONCDRF AS SECTIONCODERF" + Environment.NewLine; // DEL 2009.05.25  
                retString += "     ,SLIPHIS.STOCKSECTIONCDRF AS SECTIONCODERF" + Environment.NewLine; // ADD 2009.05.25
                //retString += "    ,SLIPDTL.SECTIONCODERF" + Environment.NewLine;
                // --- ADD 2009/04/07 -------<<<
                retString += "    ,SLIPHIS.SUPPLIERCDRF" + Environment.NewLine;
                retString += "    ,SLIPHIS.STOCKDATERF" + Environment.NewLine;
                retString += "    ,SLIPDTL.STOCKORDERDIVCDRF" + Environment.NewLine;
                retString += "    ,SLIPDTL.STOCKPRICETAXEXCRF " + Environment.NewLine;
                retString += "    ,SLIPHIS.LOGICALDELETECODERF " + Environment.NewLine;
                retString += "   FROM" + Environment.NewLine;
                retString += "    STOCKSLHISTDTLRF AS SLIPDTL   " + Environment.NewLine;
                retString += "   LEFT JOIN" + Environment.NewLine;
                retString += "    STOCKSLIPHISTRF AS SLIPHIS" + Environment.NewLine;
                retString += "   ON SLIPDTL.ENTERPRISECODERF = SLIPHIS.ENTERPRISECODERF" + Environment.NewLine;
                retString += "    AND SLIPDTL.SECTIONCODERF = SLIPHIS.SECTIONCODERF" + Environment.NewLine;
                retString += "    AND SLIPDTL.SUPPLIERSLIPNORF = SLIPHIS.SUPPLIERSLIPNORF" + Environment.NewLine;
                retString += "    AND SLIPDTL.SUPPLIERFORMALRF = SLIPHIS.SUPPLIERFORMALRF" + Environment.NewLine;
                retString += "  ) AS  SLIPHISDTLM" + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "SLIPHISDTLM", 2, 1);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "   SLIPHISDTLM.ENTERPRISECODERF" + Environment.NewLine;
                retString += "   ,SLIPHISDTLM.SECTIONCODERF" + Environment.NewLine;
                retString += "   ,SLIPHISDTLM.SUPPLIERCDRF    " + Environment.NewLine;
                retString += ") AS SLIPM " + Environment.NewLine;
                retString += "ON JOININF.ENTERPRISECODERF = SLIPM.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND JOININF.SECTIONCODERF = SLIPM.SECTIONCODERF" + Environment.NewLine;
                retString += "AND JOININF.SUPPLIERCDRF = SLIPM.SUPPLIERCDRF" + Environment.NewLine;
                retString += "LEFT JOIN " + Environment.NewLine;
                retString += "( " + Environment.NewLine;
                retString += "  SELECT" + Environment.NewLine;
                retString += "  STOCKMBFM.ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,STOCKMBFM.BFSECTIONCODERF" + Environment.NewLine;
                retString += "  ,STOCKMBFM.SUPPLIERCDRF" + Environment.NewLine;
                // �C�� 2009/05/25 >>>
                //retString += "  ,SUM(CASE WHEN (STOCKMBFM.MOVESTATUSRF=9 or STOCKMBFM.MOVESTATUSRF=2) THEN STOCKMBFM.MOVECOUNTRF ELSE 0 END) AS MOVECOUNTRF" + Environment.NewLine;
                //retString += "  ,SUM(CASE WHEN (STOCKMBFM.MOVESTATUSRF=9 or STOCKMBFM.MOVESTATUSRF=2) THEN STOCKMBFM.STOCKUNITPRICEFLRF ELSE 0 END) AS STOCKUNITPRICEFLRF" + Environment.NewLine;
                //retString += "  ,SUM(CASE WHEN (STOCKMBFM.MOVESTATUSRF=9 or STOCKMBFM.MOVESTATUSRF=2) THEN STOCKMBFM.STOCKMOVEPRICERF ELSE 0 END) AS MONTHSTOCKMOVEPRICESALES" + Environment.NewLine;�@// ADD 2009.03.09 
                retString += "  ,SUM(CASE WHEN (STOCKMBFM.STOCKMOVEFORMALRF=1 or STOCKMBFM.STOCKMOVEFORMALRF=2) THEN STOCKMBFM.MOVECOUNTRF ELSE 0 END) AS MOVECOUNTRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN (STOCKMBFM.STOCKMOVEFORMALRF=1 or STOCKMBFM.STOCKMOVEFORMALRF=2) THEN STOCKMBFM.STOCKUNITPRICEFLRF ELSE 0 END) AS STOCKUNITPRICEFLRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN (STOCKMBFM.STOCKMOVEFORMALRF=1 or STOCKMBFM.STOCKMOVEFORMALRF=2) THEN STOCKMBFM.STOCKMOVEPRICERF ELSE 0 END) AS MONTHSTOCKMOVEPRICESALES" + Environment.NewLine;�@// ADD 2009.03.09 
                // �C�� 2009/05/25 <<<
                retString += "  FROM" + Environment.NewLine;
                retString += "  STOCKMOVERF AS STOCKMBFM" + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "STOCKMBFM", 3, 1);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "  STOCKMBFM.ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,STOCKMBFM.BFSECTIONCODERF" + Environment.NewLine;
                retString += "  ,STOCKMBFM.SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS SALESSTOCKM" + Environment.NewLine;
                retString += "ON JOININF.ENTERPRISECODERF = SALESSTOCKM.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND JOININF.SECTIONCODERF = SALESSTOCKM.BFSECTIONCODERF" + Environment.NewLine;
                retString += "AND JOININF.SUPPLIERCDRF = SALESSTOCKM.SUPPLIERCDRF" + Environment.NewLine;
                retString += "LEFT JOIN " + Environment.NewLine;
                retString += "( " + Environment.NewLine;
                retString += "  SELECT" + Environment.NewLine;
                retString += "   STOCKMAFM.ENTERPRISECODERF" + Environment.NewLine;
                retString += "   ,STOCKMAFM.AFSECTIONCODERF" + Environment.NewLine;
                retString += "   ,STOCKMAFM.SUPPLIERCDRF" + Environment.NewLine;
                // �C�� 2009/05/25 >>>
                //retString += "   ,SUM(CASE WHEN (STOCKMAFM.MOVESTATUSRF=9) THEN STOCKMAFM.MOVECOUNTRF ELSE 0 END) AS MOVECOUNTRF" + Environment.NewLine;
                //retString += "   ,SUM(CASE WHEN (STOCKMAFM.MOVESTATUSRF=9) THEN STOCKMAFM.STOCKUNITPRICEFLRF ELSE 0 END) AS STOCKUNITPRICEFLRF" + Environment.NewLine;
                //retString += "   ,SUM(CASE WHEN (STOCKMAFM.MOVESTATUSRF=9) THEN STOCKMAFM.STOCKMOVEPRICERF ELSE 0 END) AS MONTHSTOCKMOVEPRICESLIP" + Environment.NewLine; // ADD 2009.03.09
                retString += "   ,SUM(CASE WHEN (STOCKMAFM.STOCKMOVEFORMALRF=3 OR STOCKMAFM.STOCKMOVEFORMALRF=4) THEN STOCKMAFM.MOVECOUNTRF ELSE 0 END) AS MOVECOUNTRF" + Environment.NewLine;
                retString += "   ,SUM(CASE WHEN (STOCKMAFM.STOCKMOVEFORMALRF=3 OR STOCKMAFM.STOCKMOVEFORMALRF=4) THEN STOCKMAFM.STOCKUNITPRICEFLRF ELSE 0 END) AS STOCKUNITPRICEFLRF" + Environment.NewLine;
                retString += "   ,SUM(CASE WHEN (STOCKMAFM.STOCKMOVEFORMALRF=3 OR STOCKMAFM.STOCKMOVEFORMALRF=4) THEN STOCKMAFM.STOCKMOVEPRICERF ELSE 0 END) AS MONTHSTOCKMOVEPRICESLIP" + Environment.NewLine;
                // �C�� 2009/05/25 <<<
                retString += "  FROM" + Environment.NewLine;
                retString += "   STOCKMOVERF AS STOCKMAFM" + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "STOCKMAFM", 4, 1);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "   STOCKMAFM.ENTERPRISECODERF" + Environment.NewLine;
                retString += "   ,STOCKMAFM.AFSECTIONCODERF" + Environment.NewLine;
                retString += "   ,STOCKMAFM.SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS SLIPSTOCKM" + Environment.NewLine;
                retString += "ON JOININF.ENTERPRISECODERF = SLIPSTOCKM.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND JOININF.SECTIONCODERF = SLIPSTOCKM.AFSECTIONCODERF" + Environment.NewLine;
                retString += "AND JOININF.SUPPLIERCDRF = SLIPSTOCKM.SUPPLIERCDRF" + Environment.NewLine;
                #endregion

                #region ���v�f�[�^�W�v
                retString += "LEFT JOIN " + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += "  SELECT " + Environment.NewLine;
                retString += "  SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                // --- ADD 2009/04/07 ------->>> // �o�͋��_�𔄏���͋��_�ɕύX
                //retString += "  ,SAHIST.SALESINPSECCDRF AS SECTIONCODERF" + Environment.NewLine;
                retString += "  ,SAHIST.RESULTSADDUPSECCDRF AS SECTIONCODERF " + Environment.NewLine;�@// ADD 2009.05.20
                // --- ADD 2009/04/07 ------->>>
                retString += "  ,SALESDTL.SUPPLIERCDRF" + Environment.NewLine;
                retString += "  ,SUM(SALESDTL.COSTRF) AS TOTALCOSTRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN SALESDTL.SALESORDERDIVCDRF=0 THEN SALESDTL.SALESMONEYTAXEXCRF ELSE 0 END) AS SALESMONEY" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN SALESDTL.SALESORDERDIVCDRF=1 THEN SALESDTL.SALESMONEYTAXEXCRF ELSE 0 END) AS SALESMONEYSTOCK" + Environment.NewLine;
                retString += "  FROM" + Environment.NewLine;
                retString += "  SALESHISTDTLRF AS  SALESDTL" + Environment.NewLine;
                // --- ADD 2009/04/07 ------->>> // ���_�p�ɔ��㗚���Q��/WHERE��/GROUPBY�ύX
                retString += "  LEFT JOIN SALESHISTORYRF AS SAHIST" + Environment.NewLine;
                retString += "  ON  SAHIST.ENTERPRISECODERF = SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                retString += "  AND SAHIST.ACPTANODRSTATUSRF = SALESDTL.ACPTANODRSTATUSRF" + Environment.NewLine;
                retString += "  AND SAHIST.SALESSLIPNUMRF = SALESDTL.SALESSLIPNUMRF" + Environment.NewLine;
                retString += MakeWhereSalesHist(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "SALESDTL", 1, 0);
                //retString += MakeWhereString(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "SALESDTL", 1, 0);
                retString += "  AND (SALESDTL.SALESSLIPCDDTLRF =0 or  SALESDTL.SALESSLIPCDDTLRF =1 or SALESDTL.SALESSLIPCDDTLRF =2 )" + Environment.NewLine;
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "  SALESDTL.ENTERPRISECODERF" + Environment.NewLine;
                //retString += "  ,SAHIST.SALESINPSECCDRF" + Environment.NewLine;
                retString += "  ,SAHIST.RESULTSADDUPSECCDRF " + Environment.NewLine;  // ADD 2009.05.20
                retString += "  ,SALESDTL.SUPPLIERCDRF  " + Environment.NewLine;
                // --- ADD 2009/04/07 -------<<<
                retString += ") AS SALESD" + Environment.NewLine;
                retString += "ON JOININF.ENTERPRISECODERF = SALESD.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND JOININF.SECTIONCODERF = SALESD.SECTIONCODERF" + Environment.NewLine;
                retString += "AND JOININF.SUPPLIERCDRF = SALESD.SUPPLIERCDRF" + Environment.NewLine;
                retString += "LEFT JOIN " + Environment.NewLine;
                retString += "(" + Environment.NewLine;
                retString += " SELECT" + Environment.NewLine;
                retString += "   SLIPHISDTL.ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,SLIPHISDTL.SECTIONCODERF" + Environment.NewLine;
                retString += "  ,SLIPHISDTL.SUPPLIERCDRF " + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN STOCKORDERDIVCDRF=0 THEN STOCKPRICETAXEXCRF ELSE 0 END) AS STOCKPRICETAXEXC" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN STOCKORDERDIVCDRF=1 THEN STOCKPRICETAXEXCRF ELSE 0 END) AS STOCKPRICETAXEXCSTOCK" + Environment.NewLine;
                retString += "  FROM" + Environment.NewLine;
                retString += "  (" + Environment.NewLine;
                retString += "   SELECT" + Environment.NewLine;
                retString += "    SLIPDTL.ENTERPRISECODERF" + Environment.NewLine;
                // --- ADD 2009/04/07 ------>>> // �d���v�㋒�_�R�[�h�ɕύX
                //retString += "    ,SLIPHIS.STOCKADDUPSECTIONCDRF AS SECTIONCODERF" + Environment.NewLine;// DEL 2009.05.25
                retString += "    ,SLIPHIS.STOCKSECTIONCDRF AS SECTIONCODERF" + Environment.NewLine; // ADD 2009.05.25
                //retString += "    ,SLIPDTL.SECTIONCODERF" + Environment.NewLine;
                // --- ADD 2009/04/07 -------<<<
                retString += "    ,SLIPHIS.SUPPLIERCDRF" + Environment.NewLine;
                retString += "    ,SLIPHIS.STOCKDATERF" + Environment.NewLine;
                retString += "    ,SLIPDTL.STOCKORDERDIVCDRF" + Environment.NewLine;
                retString += "    ,SLIPDTL.STOCKPRICETAXEXCRF " + Environment.NewLine;
                retString += "    ,SLIPHIS.LOGICALDELETECODERF " + Environment.NewLine;
                retString += "   FROM" + Environment.NewLine;
                retString += "    STOCKSLHISTDTLRF AS SLIPDTL   " + Environment.NewLine;
                retString += "   LEFT JOIN" + Environment.NewLine;
                retString += "    STOCKSLIPHISTRF AS SLIPHIS" + Environment.NewLine;
                retString += "   ON SLIPDTL.ENTERPRISECODERF = SLIPHIS.ENTERPRISECODERF" + Environment.NewLine;
                retString += "    AND SLIPDTL.SECTIONCODERF = SLIPHIS.SECTIONCODERF" + Environment.NewLine;
                retString += "    AND SLIPDTL.SUPPLIERSLIPNORF = SLIPHIS.SUPPLIERSLIPNORF" + Environment.NewLine;
                retString += "    AND SLIPDTL.SUPPLIERFORMALRF = SLIPHIS.SUPPLIERFORMALRF" + Environment.NewLine;
                retString += "  ) AS  SLIPHISDTL" + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "SLIPHISDTL", 2, 0);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "   SLIPHISDTL.ENTERPRISECODERF" + Environment.NewLine;
                retString += "   ,SLIPHISDTL.SECTIONCODERF" + Environment.NewLine;
                retString += "   ,SLIPHISDTL.SUPPLIERCDRF    " + Environment.NewLine;
                retString += "   " + Environment.NewLine;
                retString += ") AS SLIPD " + Environment.NewLine;
                retString += "ON JOININF.ENTERPRISECODERF = SLIPD.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND JOININF.SECTIONCODERF = SLIPD.SECTIONCODERF" + Environment.NewLine;
                retString += "AND JOININF.SUPPLIERCDRF = SLIPD.SUPPLIERCDRF" + Environment.NewLine;
                retString += "" + Environment.NewLine;
                retString += "LEFT JOIN " + Environment.NewLine;
                retString += "( " + Environment.NewLine;
                retString += "  SELECT" + Environment.NewLine;
                retString += "  STOCKMBF.ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,STOCKMBF.BFSECTIONCODERF" + Environment.NewLine;
                retString += "  ,STOCKMBF.SUPPLIERCDRF" + Environment.NewLine;
                // �C�� 2009/05/25 >>>
                //retString += "  ,SUM(CASE WHEN (STOCKMBF.MOVESTATUSRF=9 or STOCKMBF.MOVESTATUSRF=2) THEN STOCKMBF.MOVECOUNTRF ELSE 0 END) AS MOVECOUNTRF" + Environment.NewLine;
                //retString += "  ,SUM(CASE WHEN (STOCKMBF.MOVESTATUSRF=9 or STOCKMBF.MOVESTATUSRF=2) THEN STOCKMBF.STOCKUNITPRICEFLRF ELSE 0 END) AS STOCKUNITPRICEFLRF" + Environment.NewLine;
                //retString += "  ,SUM(CASE WHEN (STOCKMBF.MOVESTATUSRF=9 or STOCKMBF.MOVESTATUSRF=2) THEN STOCKMBF.STOCKMOVEPRICERF ELSE 0 END) AS STOCKMOVEPRICESALES" + Environment.NewLine; // ADD 2009.03.09
                retString += "  ,SUM(CASE WHEN (STOCKMBF.STOCKMOVEFORMALRF=1 or STOCKMBF.STOCKMOVEFORMALRF=2) THEN STOCKMBF.MOVECOUNTRF ELSE 0 END) AS MOVECOUNTRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN (STOCKMBF.STOCKMOVEFORMALRF=1 or STOCKMBF.STOCKMOVEFORMALRF=2) THEN STOCKMBF.STOCKUNITPRICEFLRF ELSE 0 END) AS STOCKUNITPRICEFLRF" + Environment.NewLine;
                retString += "  ,SUM(CASE WHEN (STOCKMBF.STOCKMOVEFORMALRF=1 or STOCKMBF.STOCKMOVEFORMALRF=2) THEN STOCKMBF.STOCKMOVEPRICERF ELSE 0 END) AS STOCKMOVEPRICESALES" + Environment.NewLine; 
                // �C�� 2009/05/25 <<<
                retString += "  FROM" + Environment.NewLine;
                retString += "  STOCKMOVERF AS STOCKMBF" + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "STOCKMBF", 3, 0);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "  STOCKMBF.ENTERPRISECODERF" + Environment.NewLine;
                retString += "  ,STOCKMBF.BFSECTIONCODERF" + Environment.NewLine;
                retString += "  ,STOCKMBF.SUPPLIERCDRF" + Environment.NewLine;
                retString += "  " + Environment.NewLine;
                retString += ") AS SALESSTOCKD" + Environment.NewLine;
                retString += "ON JOININF.ENTERPRISECODERF = SALESSTOCKD.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND JOININF.SECTIONCODERF = SALESSTOCKD.BFSECTIONCODERF" + Environment.NewLine;
                retString += "AND JOININF.SUPPLIERCDRF = SALESSTOCKD.SUPPLIERCDRF" + Environment.NewLine;
                retString += "LEFT JOIN " + Environment.NewLine;
                retString += "( " + Environment.NewLine;
                retString += "  SELECT" + Environment.NewLine;
                retString += "   STOCKMAF.ENTERPRISECODERF" + Environment.NewLine;
                retString += "   ,STOCKMAF.AFSECTIONCODERF" + Environment.NewLine;
                retString += "   ,STOCKMAF.SUPPLIERCDRF" + Environment.NewLine;
                // �C�� 2009/05/25 >>>
                //retString += "   ,SUM(CASE WHEN (STOCKMAF.MOVESTATUSRF=9) THEN STOCKMAF.MOVECOUNTRF ELSE 0 END) AS MOVECOUNTRF" + Environment.NewLine;
                //retString += "   ,SUM(CASE WHEN (STOCKMAF.MOVESTATUSRF=9) THEN STOCKMAF.STOCKUNITPRICEFLRF ELSE 0 END) AS STOCKUNITPRICEFLRF" + Environment.NewLine;
                //retString += "   ,SUM(CASE WHEN (STOCKMAF.MOVESTATUSRF=9) THEN STOCKMAF.STOCKMOVEPRICERF ELSE 0 END) AS STOCKMOVEPRICESLIP" + Environment.NewLine; // ADD 2009.03.09
                retString += "   ,SUM(CASE WHEN (STOCKMAF.STOCKMOVEFORMALRF=3 OR STOCKMAF.STOCKMOVEFORMALRF=4) THEN STOCKMAF.MOVECOUNTRF ELSE 0 END) AS MOVECOUNTRF" + Environment.NewLine;
                retString += "   ,SUM(CASE WHEN (STOCKMAF.STOCKMOVEFORMALRF=3 OR STOCKMAF.STOCKMOVEFORMALRF=4) THEN STOCKMAF.STOCKUNITPRICEFLRF ELSE 0 END) AS STOCKUNITPRICEFLRF" + Environment.NewLine;
                retString += "   ,SUM(CASE WHEN (STOCKMAF.STOCKMOVEFORMALRF=3 OR STOCKMAF.STOCKMOVEFORMALRF=4) THEN STOCKMAF.STOCKMOVEPRICERF ELSE 0 END) AS STOCKMOVEPRICESLIP" + Environment.NewLine;
                // �C�� 2009/05/25 <<<
                retString += "  FROM" + Environment.NewLine;
                retString += "   STOCKMOVERF AS STOCKMAF" + Environment.NewLine;
                retString += MakeWhereString(ref sqlCommand, _salStcCompReportParamWork, logicalMode, "STOCKMAF", 4, 0);
                retString += "  GROUP BY" + Environment.NewLine;
                retString += "   STOCKMAF.ENTERPRISECODERF" + Environment.NewLine;
                retString += "   ,STOCKMAF.AFSECTIONCODERF" + Environment.NewLine;
                retString += "   ,STOCKMAF.SUPPLIERCDRF" + Environment.NewLine;
                retString += ") AS SLIPSTOCKD" + Environment.NewLine;
                retString += "ON JOININF.ENTERPRISECODERF = SLIPSTOCKD.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND JOININF.SECTIONCODERF = SLIPSTOCKD.AFSECTIONCODERF" + Environment.NewLine;
                retString += "AND JOININF.SUPPLIERCDRF = SLIPSTOCKD.SUPPLIERCDRF" + Environment.NewLine;
                #endregion

                #region JOIN
                retString += "LEFT JOIN" + Environment.NewLine;
                retString += "SECINFOSETRF AS SECINF" + Environment.NewLine;
                retString += "ON SECINF.ENTERPRISECODERF = JOININF.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND SECINF.SECTIONCODERF = JOININF.SECTIONCODERF" + Environment.NewLine;

                retString += "LEFT JOIN" + Environment.NewLine;
                retString += "SUPPLIERRF AS SUPP" + Environment.NewLine;
                retString += "ON SUPP.ENTERPRISECODERF = JOININF.ENTERPRISECODERF" + Environment.NewLine;
                retString += "AND SUPP.SUPPLIERCDRF = JOININF.SUPPLIERCDRF" + Environment.NewLine;
                #endregion
            }            

            return retString;
        }
        #endregion

        #region �����Q�ƗpWhere�吶��
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_orderListParamWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereSalesHist(ref SqlCommand sqlCommand, SalStcCompReportParamWork _salStcCompReportParamWork, ConstantManagement.LogicalMode logicalMode, String TblNm, int MakeMode, int MakeMode2)
        {
            #region ��������
            String sectionId = "";
            String DateId = "";
            switch (MakeMode)
            {
                case 1:
                    {
                        sectionId = "SECTIONCODERF";
                        DateId = "SALESDATERF";
                        break;
                    }
                case 2:
                    {
                        sectionId = "STOCKSECTIONCDRF";
                        DateId = "STOCKDATERF";
                        break;
                    }
                case 3:
                    {
                        sectionId = "BFSECTIONCODERF";
                        DateId = "SHIPMENTFIXDAYRF";
                        break;
                    }
                case 4:
                    {
                        sectionId = "AFSECTIONCODERF";
                        DateId = "ARRIVALGOODSDAYRF";
                        break;
                    }
                default:
                    break;
            }
            #endregion

            #region WHERE���쐬
            string retstring = "WHERE " + Environment.NewLine;
            //��ƃR�[�h
            retstring += TblNm + "." + "ENTERPRISECODERF=@" + TblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + TblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_salStcCompReportParamWork.EnterpriseCode);

            //�v�㋒�_�R�[�h
            if (_salStcCompReportParamWork.SectionCode != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _salStcCompReportParamWork.SectionCode)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    //retstring += " AND SAHIST.SALESINPSECCDRF IN (" + sectionCodestr + ") " + Environment.NewLine;
                    retstring += " AND SAHIST.RESULTSADDUPSECCDRF IN (" + sectionCodestr + ") " + Environment.NewLine;
                }
            }

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND " + TblNm + "." + "LOGICALDELETECODERF=@" + TblNm + "FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@" + TblNm + "FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND " + TblNm + "." + "LOGICALDELETECODERF<@" + TblNm + "FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@" + TblNm + "FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }


            //�J�n�d����R�[�h
            if (_salStcCompReportParamWork.StSupplierCd != 0)
            {
                retstring += " AND " + TblNm + "." + "SUPPLIERCDRF>=@" + TblNm + "STSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@" + TblNm + "STSUPPLIERCD", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_salStcCompReportParamWork.StSupplierCd);
            }

            //�I���d����R�[�h
            if ((_salStcCompReportParamWork.EdSupplierCd != 0) && (_salStcCompReportParamWork.EdSupplierCd != 999999))
            {
                retstring += " AND " + TblNm + "." + "SUPPLIERCDRF<=@" + TblNm + "EDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@" + TblNm + "EDSUPPLIERCD", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_salStcCompReportParamWork.EdSupplierCd);
            }
            if (MakeMode2 == 0)
            {
                //�Ώۓ��t
                if (_salStcCompReportParamWork.StReportDate != 0)
                {
                    retstring += " AND " + TblNm + "." + DateId + ">=@" + TblNm + "STADDUPDATE" + Environment.NewLine;
                    SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@" + TblNm + "STADDUPDATE", SqlDbType.Int);
                    paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_salStcCompReportParamWork.StReportDate);
                }
                if (_salStcCompReportParamWork.EdReportDate != 0)
                {
                    retstring += " AND " + TblNm + "." + DateId + "<=@" + TblNm + "EDADDUPDATE" + Environment.NewLine;
                    SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@" + TblNm + "EDADDUPDATE", SqlDbType.Int);
                    paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_salStcCompReportParamWork.EdReportDate);
                }
            }
            else
            {
                //�Ώۓ��t
                if (_salStcCompReportParamWork.StMonthReportDate != 0)
                {
                    retstring += " AND " + TblNm + "." + DateId + ">=@" + TblNm + "STADDUPDATE" + Environment.NewLine;
                    SqlParameter paraStAddUpDate = sqlCommand.Parameters.Add("@" + TblNm + "STADDUPDATE", SqlDbType.Int);
                    paraStAddUpDate.Value = SqlDataMediator.SqlSetInt32(_salStcCompReportParamWork.StMonthReportDate);
                }
                if (_salStcCompReportParamWork.EdMonthReportDate != 0)
                {
                    retstring += " AND " + TblNm + "." + DateId + "<=@" + TblNm + "EDADDUPDATE" + Environment.NewLine;
                    SqlParameter paraEdAddUpDate = sqlCommand.Parameters.Add("@" + TblNm + "EDADDUPDATE", SqlDbType.Int);
                    paraEdAddUpDate.Value = SqlDataMediator.SqlSetInt32(_salStcCompReportParamWork.EdMonthReportDate);
                }

            }

            #endregion
            return retstring;
        }
        #endregion

        #region Where�吶��
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_orderListParamWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, SalStcCompReportParamWork _salStcCompReportParamWork, ConstantManagement.LogicalMode logicalMode, String TblNm, int MakeMode, int MakeMode2)
        {

            #region ��������
            String sectionId = "";
            String DateId = "";
            switch (MakeMode)
            {
                case 1:
                    {
                        sectionId = "SECTIONCODERF";
                        DateId = "SALESDATERF";
                        break;
                    }
                case 2:
                    {
                        sectionId = "SECTIONCODERF";
                        DateId = "STOCKDATERF";
                        break;
                    }
                case 3:
                    {
                        sectionId = "BFSECTIONCODERF";
                        DateId = "SHIPMENTFIXDAYRF";
                        break;
                    }
                case 4:
                    {
                        sectionId = "AFSECTIONCODERF";
                        DateId = "ARRIVALGOODSDAYRF";
                        break;
                    }
                default:
                    break;
            }
            #endregion

            #region WHERE���쐬
            string retstring = "WHERE " + Environment.NewLine;
            //��ƃR�[�h
            retstring += TblNm + "." + "ENTERPRISECODERF=@" + TblNm + "ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@" + TblNm + "ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_salStcCompReportParamWork.EnterpriseCode);

            //�v�㋒�_�R�[�h
            if (_salStcCompReportParamWork.SectionCode != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _salStcCompReportParamWork.SectionCode)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }

                if (sectionCodestr != "")
                {
                    retstring += " AND " + TblNm+ "." + sectionId+" IN (" + sectionCodestr + ") " + Environment.NewLine;
                }
            }

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND " + TblNm + "." + "LOGICALDELETECODERF=@" + TblNm + "FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@" + TblNm + "FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND " + TblNm + "." + "LOGICALDELETECODERF<@" + TblNm + "FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@" + TblNm + "FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }


            //�J�n�d����R�[�h
            if (_salStcCompReportParamWork.StSupplierCd != 0)
            {
                retstring += " AND " + TblNm + "." + "SUPPLIERCDRF>=@" + TblNm + "STSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@" + TblNm + "STSUPPLIERCD", SqlDbType.Int);
                paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_salStcCompReportParamWork.StSupplierCd);
            }

            //�I���d����R�[�h
            if ((_salStcCompReportParamWork.EdSupplierCd != 0) && (_salStcCompReportParamWork.EdSupplierCd != 999999))
            {
                retstring += " AND " + TblNm + "." + "SUPPLIERCDRF<=@" + TblNm + "EDSUPPLIERCD" + Environment.NewLine;
                SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@" + TblNm + "EDSUPPLIERCD", SqlDbType.Int);
                paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_salStcCompReportParamWork.EdSupplierCd);
            }
            if (MakeMode2 == 0)
            {
                //�Ώۓ��t
                if (_salStcCompReportParamWork.StReportDate != 0)
                {
                    retstring += " AND " + TblNm + "." + DateId + ">=@" + TblNm + "STADDUPDATE" + Environment.NewLine;
                    SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@" + TblNm + "STADDUPDATE", SqlDbType.Int);
                    paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_salStcCompReportParamWork.StReportDate);
                }
                if (_salStcCompReportParamWork.EdReportDate != 0)
                {
                    retstring += " AND " + TblNm + "." + DateId + "<=@" + TblNm + "EDADDUPDATE" + Environment.NewLine;
                    SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@" + TblNm + "EDADDUPDATE", SqlDbType.Int);
                    paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(_salStcCompReportParamWork.EdReportDate);
                }
            }
            else
            {
                //�Ώۓ��t
                if (_salStcCompReportParamWork.StMonthReportDate != 0)
                {
                    retstring += " AND " + TblNm + "." + DateId + ">=@" + TblNm + "STADDUPDATE" + Environment.NewLine;
                    SqlParameter paraStAddUpDate = sqlCommand.Parameters.Add("@" + TblNm + "STADDUPDATE", SqlDbType.Int);
                    paraStAddUpDate.Value = SqlDataMediator.SqlSetInt32(_salStcCompReportParamWork.StMonthReportDate);
                }
                if (_salStcCompReportParamWork.EdMonthReportDate != 0)
                {
                    retstring += " AND " + TblNm + "." + DateId + "<=@" + TblNm + "EDADDUPDATE" + Environment.NewLine;
                    SqlParameter paraEdAddUpDate = sqlCommand.Parameters.Add("@" + TblNm + "EDADDUPDATE", SqlDbType.Int);
                    paraEdAddUpDate.Value = SqlDataMediator.SqlSetInt32(_salStcCompReportParamWork.EdMonthReportDate);
                }

            }
            // ADD 2009/05/25 >>>
            if (MakeMode == 3)
            {
                retstring += " AND (" + TblNm + ".STOCKMOVEFORMALRF = 1 OR " + TblNm + ".STOCKMOVEFORMALRF = 2)" + Environment.NewLine;
            }
            else if (MakeMode == 4)
            {
                retstring += " AND (" + TblNm + ".STOCKMOVEFORMALRF = 3 OR " + TblNm + ".STOCKMOVEFORMALRF = 4)" + Environment.NewLine;
            }
            // ADD 2009/05/25 <<<

            #endregion
            return retstring;
        }
        #endregion
    }
}

