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
    /// �݌ɊǗ��\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɊǗ��\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    [Serializable]
    public class StockManagementListWorkDB : RemoteDB, IStockManagementListWorkDB
    {
        /// <summary>
        /// �݌ɊǗ��\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public StockManagementListWorkDB()
            :
        base("DCZAI02113D", "Broadleaf.Application.Remoting.ParamData.StockManagementListWork", "STOCKHISTORYRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region �݌ɊǗ��\
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɊǗ��\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="stockManagementListResultWork">��������</param>
        /// <param name="stockManagementListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɊǗ��\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.09.19</br>
        public int Search(out object stockManagementListWork, object stockManagementListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockManagementListWork = null;

            StockManagementListCndtnWork _stockManagementListCndtnWork = stockManagementListCndtnWork as StockManagementListCndtnWork;

            try
            {
                status = SearchProc(out stockManagementListWork, _stockManagementListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockManagementListWorkDB.Search Exception=" + ex.Message);
                stockManagementListWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɊǗ��\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockManagementListResultWork">��������</param>
        /// <param name="_stockManagementListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɊǗ��\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.09.19</br>
        /// <br></br>
        /// <br>Update Note: 2007.09.19 ���� DC.NS�p�ɏC��</br>
        private int SearchProc(out object stockManagementListWork, StockManagementListCndtnWork _stockManagementListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            stockManagementListWork = null;

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


                status = SearchStockManagementProc(ref al, ref sqlConnection, _stockManagementListCndtnWork, logicalMode);
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockManagementListWorkDB.SearchProc Exception=" + ex.Message);
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

            stockManagementListWork = al;

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_stockManagementListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchStockManagementProc(ref ArrayList al, ref SqlConnection sqlConnection, StockManagementListCndtnWork _stockManagementListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region Select���쐬
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  GOODSM.SUPPLIERCD1RF" + Environment.NewLine;
                selectTxt += " ,GOODSM.SUPPLIERNAME1RF" + Environment.NewLine;
                selectTxt += " ,STHIS1.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,STHIS1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STHIS1.MAKERNAMERF" + Environment.NewLine;
                selectTxt += " ,STHIS1.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,STHIS1.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += " ,STHIS1.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,STHIS1.GOODSNAMERF" + Environment.NewLine;
                selectTxt += " ,STHIS2.LMONTHSTOCKCNT" + Environment.NewLine;
                selectTxt += " ,STHIS2.LMONTHSTOCKPRICE" + Environment.NewLine;
                selectTxt += " ,STHIS1.NETSTOCKCNT" + Environment.NewLine;
                selectTxt += " ,STHIS1.NETSTOCKPRICE" + Environment.NewLine;
                selectTxt += " ,STHIS1.NETSALESCNT" + Environment.NewLine;
                selectTxt += " ,STHIS1.NETSALESPRICE" + Environment.NewLine;
                selectTxt += " ,STHIS1.GROSSPROFIT" + Environment.NewLine;
                selectTxt += " ,STHIS1.ADJUSTCOUNT" + Environment.NewLine;
                selectTxt += " ,STHIS1.ADJUSTPRICE" + Environment.NewLine;
                selectTxt += " ,STHIS2.STOCKTOTAL" + Environment.NewLine;
                selectTxt += " ,STHIS2.STOCKUNITPRICEFL" + Environment.NewLine;
                selectTxt += " ,STHIS1.NETSTOCKCNTTOTAL" + Environment.NewLine;
                selectTxt += " ,STHIS1.NETSTOCKPRICETOTAL" + Environment.NewLine;
                selectTxt += " ,STHIS1.NETSALESCNTTOTAL" + Environment.NewLine;
                selectTxt += " ,STHIS1.NETSALESPRICETOTAL" + Environment.NewLine;
                selectTxt += " ,STHIS1.GROSSPROFITTOTAL" + Environment.NewLine;
                selectTxt += " ,STHIS1.ADJUSTCOUNTTOTAL" + Environment.NewLine;
                selectTxt += " ,STHIS1.ADJUSTPRICETOTAL" + Environment.NewLine;
                selectTxt += " ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.LARGEGOODSGANRECODERF" + Environment.NewLine;
                selectTxt += " ,STOCK.LARGEGOODSGANRENAMERF" + Environment.NewLine;
                selectTxt += " ,STOCK.MEDIUMGOODSGANRECODERF" + Environment.NewLine;
                selectTxt += " ,STOCK.MEDIUMGOODSGANRENAMERF" + Environment.NewLine;
                selectTxt += " ,STOCK.DETAILGOODSGANRECODERF" + Environment.NewLine;
                selectTxt += " ,STOCK.DETAILGOODSGANRENAMERF" + Environment.NewLine;
                selectTxt += " ,STOCK.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,STOCK.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += "FROM" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  STHISSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.MAKERNAMERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.GOODSNAMERF" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.SALESCOUNTRF - STHISSUB1.SALESRETGOODSCNTRF ELSE 0 END) AS NETSTOCKCNT" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.STOCKPRICETAXEXCRF - STHISSUB1.STOCKRETGOODSPRICERF ELSE 0 END) AS NETSTOCKPRICE" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.STOCKCOUNTRF - STHISSUB1.STOCKRETGOODSCNTRF ELSE 0 END) AS NETSALESCNT" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.SALESMONEYTAXEXCRF - STHISSUB1.SALESRETGOODSPRICERF ELSE 0 END) AS NETSALESPRICE" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.GROSSPROFITRF ELSE 0 END) AS GROSSPROFIT" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.ADJUSTCOUNTRF ELSE 0 END) AS ADJUSTCOUNT" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.ADJUSTPRICERF ELSE 0 END) AS ADJUSTPRICE" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @KSADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.SALESCOUNTRF - STHISSUB1.SALESRETGOODSCNTRF ELSE 0 END) AS NETSTOCKCNTTOTAL" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @KSADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.STOCKPRICETAXEXCRF - STHISSUB1.STOCKRETGOODSPRICERF ELSE 0 END) AS NETSTOCKPRICETOTAL" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @KSADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.STOCKCOUNTRF - STHISSUB1.STOCKRETGOODSCNTRF ELSE 0 END) AS NETSALESCNTTOTAL" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @KSADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.SALESMONEYTAXEXCRF - STHISSUB1.SALESRETGOODSPRICERF ELSE 0 END) AS NETSALESPRICETOTAL" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @KSADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.GROSSPROFITRF ELSE 0 END) AS GROSSPROFITTOTAL" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @KSADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.ADJUSTCOUNTRF ELSE 0 END) AS ADJUSTCOUNTTOTAL" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @KSADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.ADJUSTPRICERF ELSE 0 END) AS ADJUSTPRICETOTAL" + Environment.NewLine;
                selectTxt += "FROM STOCKHISTORYRF AS STHISSUB1" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "  STHISSUB1.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                selectTxt += "GROUP BY" + Environment.NewLine;
                selectTxt += "  STHISSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.MAKERNAMERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.GOODSNAMERF" + Environment.NewLine;
                selectTxt += ") AS STHIS1" + Environment.NewLine;
                selectTxt += "LEFT JOIN " + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  STHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB2.ADDUPYEARMONTHRF = @STADDUPYEARMONTH THEN STHISSUB2.LMONTHSTOCKCNTRF ELSE 0 END) AS LMONTHSTOCKCNT" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB2.ADDUPYEARMONTHRF = @STADDUPYEARMONTH THEN STHISSUB2.LMONTHSTOCKPRICERF ELSE 0 END) AS LMONTHSTOCKPRICE" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB2.ADDUPYEARMONTHRF = @EDADDUPYEARMONTH THEN STHISSUB2.STOCKTOTALRF ELSE 0 END) AS STOCKTOTAL" + Environment.NewLine;
                selectTxt += " ,SUM(CASE WHEN STHISSUB2.ADDUPYEARMONTHRF = @EDADDUPYEARMONTH THEN STHISSUB2.STOCKUNITPRICEFLRF ELSE 0 END) AS STOCKUNITPRICEFL" + Environment.NewLine;
                selectTxt += "FROM STOCKHISTORYRF AS STHISSUB2" + Environment.NewLine;
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += "  STHISSUB2.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                selectTxt += "GROUP BY" + Environment.NewLine;
                selectTxt += "  STHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.GOODSNORF" + Environment.NewLine;
                selectTxt += ") AS STHIS2" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "    STHIS2.ENTERPRISECODERF=STHIS1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "AND STHIS2.SECTIONCODERF=STHIS1.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "AND STHIS2.WAREHOUSECODERF=STHIS1.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "AND STHIS2.GOODSMAKERCDRF=STHIS1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "AND STHIS2.GOODSNORF=STHIS1.GOODSNORF" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSMNGRF AS GOODSM" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "    GOODSM.ENTERPRISECODERF=STHIS1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "AND GOODSM.SECTIONCODERF=STHIS1.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "AND GOODSM.GOODSMAKERCDRF=STHIS1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "AND GOODSM.GOODSNORF=STHIS1.GOODSNORF" + Environment.NewLine;
                selectTxt += "LEFT JOIN STOCKRF AS STOCK" + Environment.NewLine;
                selectTxt += "ON" + Environment.NewLine;
                selectTxt += "    STOCK.ENTERPRISECODERF=STHIS1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "AND STOCK.SECTIONCODERF=STHIS1.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "AND STOCK.GOODSMAKERCDRF=STHIS1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "AND STOCK.GOODSNORF=STHIS1.GOODSNORF" + Environment.NewLine;
                selectTxt += "AND STOCK.WAREHOUSECODERF=STHIS1.WAREHOUSECODERF" + Environment.NewLine;

                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _stockManagementListCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                #endregion

                myReader = sqlCommand.ExecuteReader();

                 //�����擾
                int mcnt = 0;
                DateTime edm = _stockManagementListCndtnWork.Ed_AddUpYearMonth;
                DateTime compm = _stockManagementListCndtnWork.St_AddUpYearMonth;

                while (true)
                {
                    mcnt += 1;
                    if (edm.Year*100 + edm.Month <= compm.Year*100 + compm.Month) break;
                    compm = compm.AddMonths(1);
                }

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StockManagementListWork wkStockManagementListWork = new StockManagementListWork();
                    
                    //�݌ɗ����i�[����
                    wkStockManagementListWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCD1RF"));
                    wkStockManagementListWork.SupplierName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNAME1RF"));
                    wkStockManagementListWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkStockManagementListWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockManagementListWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkStockManagementListWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkStockManagementListWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkStockManagementListWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockManagementListWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStockManagementListWork.LargeGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRECODERF"));
                    wkStockManagementListWork.LargeGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("LARGEGOODSGANRENAMERF"));
                    wkStockManagementListWork.MediumGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRECODERF"));
                    wkStockManagementListWork.MediumGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MEDIUMGOODSGANRENAMERF"));
                    wkStockManagementListWork.DetailGoodsGanreCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRECODERF"));
                    wkStockManagementListWork.DetailGoodsGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DETAILGOODSGANRENAMERF"));
                    wkStockManagementListWork.LMonthStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LMONTHSTOCKCNT"));
                    wkStockManagementListWork.LMonthStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LMONTHSTOCKPRICE"));
                    wkStockManagementListWork.NetStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NETSTOCKCNT"));
                    wkStockManagementListWork.NetStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NETSTOCKPRICE"));
                    wkStockManagementListWork.NetSalesCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NETSALESCNT"));
                    wkStockManagementListWork.NetSalesPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NETSALESPRICE"));
                    wkStockManagementListWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFIT"));
                    wkStockManagementListWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNT"));
                    wkStockManagementListWork.AdjustPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ADJUSTPRICE"));
                    wkStockManagementListWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKTOTAL"));
                    wkStockManagementListWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFL"));
                    wkStockManagementListWork.NetStockCntTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NETSTOCKCNTTOTAL"));
                    wkStockManagementListWork.NetStockPriceTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NETSTOCKPRICETOTAL"));
                    wkStockManagementListWork.NetSalesCntTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("NETSALESCNTTOTAL"));
                    wkStockManagementListWork.NetSalesPriceTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("NETSALESPRICETOTAL"));
                    wkStockManagementListWork.GrossProfitTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITTOTAL"));
                    wkStockManagementListWork.AdjustCountTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTTOTAL"));
                    wkStockManagementListWork.AdjustPriceTotal = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ADJUSTPRICETOTAL"));

                    Double stockAvg = (SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF")) + SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"))) / 2;
                    
                    Double turnRate = 0;
                    if (stockAvg != 0)
                        turnRate = wkStockManagementListWork.NetSalesCnt / (stockAvg * mcnt) * 100;

                    wkStockManagementListWork.StockAverage = stockAvg;
                    wkStockManagementListWork.TurnRate = turnRate;
                    #endregion

                    al.Add(wkStockManagementListWork);

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
                base.WriteErrorLog(ex, "StockManagementListWorkDB.SearchStockManagementProc Exception=" + ex.Message);
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

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockManagementListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockManagementListCndtnWork _stockManagementListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " STHIS1.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockManagementListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STHIS1.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine; 
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STHIS1.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }
            
            /*
            //�N���x�ݒ�
            if (_stockManagementListCndtnWork.St_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND STHIS1.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
            }
            if (_stockManagementListCndtnWork.Ed_AddUpYearMonth != DateTime.MinValue)
            {
                retstring += " AND STHIS1.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
            }
            */ 

            SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
            paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockManagementListCndtnWork.St_AddUpYearMonth);
            SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
            paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockManagementListCndtnWork.Ed_AddUpYearMonth);

            //���Ѓ}�X�^�����񌎂��擾�@���͂Ƃ肠�����Œ聫��������������������������������������������������������������
            SqlParameter paraKsAddUpYearMonth = sqlCommand.Parameters.Add("@KSADDUPYEARMONTH", SqlDbType.Int);
            paraKsAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(new DateTime(2007,01,01));


            //���_�R�[�h
            if (_stockManagementListCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _stockManagementListCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND STHIS1.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�q�ɃR�[�h�ݒ�
            if (_stockManagementListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STHIS1.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockManagementListCndtnWork.St_WarehouseCode);
            }
            if (_stockManagementListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND (STHIS1.WAREHOUSECODERF<=@EDWAREHOUSECODE OR STHIS1.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockManagementListCndtnWork.Ed_WarehouseCode + "%");
            }

            //���[�J�[�R�[�h�ݒ�
            if (_stockManagementListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STHIS1.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockManagementListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockManagementListCndtnWork.Ed_GoodsMakerCd != 999999)
            {
                retstring += " AND STHIS1.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockManagementListCndtnWork.Ed_GoodsMakerCd);
            }

            //���i�敪�O���[�v�R�[�h�ݒ�
            if (_stockManagementListCndtnWork.St_LargeGoodsGanreCode != "")
            {
                retstring += " AND STOCK.LARGEGOODSGANRECODERF>=@STLARGEGOODSGANRECODE" + Environment.NewLine;
                SqlParameter paraStLargeGoodsGanreCode = sqlCommand.Parameters.Add("@STLARGEGOODSGANRECODE", SqlDbType.NChar);
                paraStLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(_stockManagementListCndtnWork.St_LargeGoodsGanreCode);
            }
            if (_stockManagementListCndtnWork.Ed_LargeGoodsGanreCode != "")
            {
                retstring += " AND (STOCK.LARGEGOODSGANRECODERF<=@EDLARGEGOODSGANRECODE OR STOCK.LARGEGOODSGANRECODERF LIKE @EDLARGEGOODSGANRECODE)" + Environment.NewLine;
                SqlParameter paraEdLargeGoodsGanreCode = sqlCommand.Parameters.Add("@EDLARGEGOODSGANRECODE", SqlDbType.NChar);
                paraEdLargeGoodsGanreCode.Value = SqlDataMediator.SqlSetString(_stockManagementListCndtnWork.Ed_LargeGoodsGanreCode + "%");
            }

            //���i�敪�R�[�h�ݒ�
            if (_stockManagementListCndtnWork.St_MediumGoodsGanreCode != "")
            {
                retstring += " AND STOCK.MEDIUMGOODSGANRECODERF>=@STMEDIUMGOODSGANRECODE" + Environment.NewLine;
                SqlParameter paraStMediumGoodsGanreCode = sqlCommand.Parameters.Add("@STMEDIUMGOODSGANRECODE", SqlDbType.NChar);
                paraStMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(_stockManagementListCndtnWork.St_MediumGoodsGanreCode);
            }
            if (_stockManagementListCndtnWork.Ed_MediumGoodsGanreCode != "")
            {
                retstring += " AND (STOCK.MEDIUMGOODSGANRECODERF<=@EDMEDIUMGOODSGANRECODE OR STOCK.MEDIUMGOODSGANRECODERF LIKE @EDMEDIUMGOODSGANRECODE)" + Environment.NewLine;
                SqlParameter paraEdMediumGoodsGanreCode = sqlCommand.Parameters.Add("@EDMEDIUMGOODSGANRECODE", SqlDbType.NChar);
                paraEdMediumGoodsGanreCode.Value = SqlDataMediator.SqlSetString(_stockManagementListCndtnWork.Ed_MediumGoodsGanreCode + "%");
            }

            //���i�敪�ڍ׃R�[�h�ݒ�
            if (_stockManagementListCndtnWork.St_DetailGoodsGanreCode != "")
            {
                retstring += " AND STOCK.DETAILGOODSGANRECODERF>=@STDETAILGOODSGANRECODE" + Environment.NewLine;
                SqlParameter paraStDetailGoodsGanreCode = sqlCommand.Parameters.Add("@STDETAILGOODSGANRECODE", SqlDbType.NChar);
                paraStDetailGoodsGanreCode.Value = SqlDataMediator.SqlSetString(_stockManagementListCndtnWork.St_DetailGoodsGanreCode);
            }
            if (_stockManagementListCndtnWork.Ed_DetailGoodsGanreCode != "")
            {
                retstring += " AND (STOCK.DETAILGOODSGANRECODERF<=@EDDETAILGOODSGANRECODE OR STOCK.DETAILGOODSGANRECODERF LIKE @EDDETAILGOODSGANRECODE)" + Environment.NewLine;
                SqlParameter paraEdDetailGoodsGanreCode = sqlCommand.Parameters.Add("@EDDETAILGOODSGANRECODE", SqlDbType.NChar);
                paraEdDetailGoodsGanreCode.Value = SqlDataMediator.SqlSetString(_stockManagementListCndtnWork.Ed_DetailGoodsGanreCode + "%");
            }

            //���Е��ރR�[�h�ݒ�
            if (_stockManagementListCndtnWork.St_EnterpriseGanreCode != 0)
            {
                retstring += " AND STOCK.ENTERPRISEGANRECODERF>=@STENTERPRISEGANRECODE" + Environment.NewLine;
                SqlParameter paraStEnterpriseGanreCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockManagementListCndtnWork.St_EnterpriseGanreCode);
            }
            if (_stockManagementListCndtnWork.Ed_EnterpriseGanreCode != 9999)
            {
                retstring += " AND STOCK.ENTERPRISEGANRECODERF<=@EDENTERPRISEGANRECODE" + Environment.NewLine;
                SqlParameter paraEdEnterpriseGanreCode = sqlCommand.Parameters.Add("@EDENTERPRISEGANRECODE", SqlDbType.Int);
                paraEdEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockManagementListCndtnWork.Ed_EnterpriseGanreCode);
            }

            //BL�R�[�h�ݒ�
            if (_stockManagementListCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND STOCK.BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockManagementListCndtnWork.St_BLGoodsCode);
            }
            if (_stockManagementListCndtnWork.Ed_BLGoodsCode != 99999999)
            {
                retstring += " AND STOCK.BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockManagementListCndtnWork.Ed_BLGoodsCode);
            }
            
            #endregion
            return retstring;
        }
    }
}
