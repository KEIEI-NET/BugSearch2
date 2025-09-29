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
using Broadleaf.Application.Common;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ɉꗗ�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɉꗗ�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2007.07.08</br>
    /// <br></br>
    /// <br>Update Note: 2009.05.11 22008 ���� MANTIS 12374</br>
    /// <br></br>
    /// <br>Update Note: 2009.05.28 22008 ���� MANTIS�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2009.06.10 22008 ���� MANTIS 13447</br>
    /// <br></br>
    /// <br>Update Note: 2009.06.15 22008 ���� MANTIS 13503</br>
    /// <br></br>
    /// <br>Update Note: 2011/03/14 22008 ���� ���x�`���[�j���O</br>
    /// <br></br>
    /// <br>Update Note: 2012/12/03 30810 �{�{ �݌ɓo�^����[NULL]�̃f�[�^�������ΏۂƂ���</br>
    /// </remarks>
    [Serializable]
    public class StockListWorkDB : RemoteDB, IStockListWorkDB
    {
        /// <summary>
        /// �݌Ɉꗗ�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2007.07.08</br>
        /// </remarks>
        public StockListWorkDB()
            :
        base("MAZAI02076D", "Broadleaf.Application.Remoting.ParamData.StockListResultWork", "STOCKRF") //���N���X�̃R���X�g���N�^
        {
        }

        #region Search
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌Ɉꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="stockListResultWork">��������</param>
        /// <param name="stockListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌Ɉꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2007.07.08</br>
        public int Search(out object stockListResultWork, object stockListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection sqlConnection = null;

            stockListResultWork = new ArrayList();
            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                status = Search(ref stockListResultWork, stockListCndtnWork, readMode, logicalMode, ref sqlConnection);
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌Ɉꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="stockListResultWork">��������</param>
        /// <param name="stockListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌Ɉꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2007.07.08</br>
        private int Search(ref object stockListResultWork, object stockListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockListResultWork = null;
            ArrayList stockListResultWorkList = null;

            ArrayList resultList = new ArrayList(); ;
            StockListCndtnWork _stockListCndtnWork = stockListCndtnWork as StockListCndtnWork;

            MonthlyAddUpDB monthlyAddUpDB = new MonthlyAddUpDB();
            CompanyInfDB companyInfDB = new CompanyInfDB();

            // 2009/06/15 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //DateTime st_Date = _stockListCndtnWork.St_LastStockDate.AddMonths(-6); //�U�J���O���󎚂���̂��߁A�U�J���O����擾
            DateTime st_Date = _stockListCndtnWork.St_LastStockDate.AddMonths(-5); //�J�n�����܂߂ĂU�����Ƃ���
            // 2009/06/15 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            DateTime ed_Date = _stockListCndtnWork.Ed_LastStockDate;
            int lastStockHisYm = 0;

            //�J�n�A�I���N���̑Ώۊ���
            Int32 monthRange = ((ed_Date.Year) - (st_Date.Year)) * 12 + (ed_Date.Month) - (st_Date.Month) + 1;

            try
            {
                //�ŏI�������N�����擾
                lastStockHisYm = GetLastStockHisYm(_stockListCndtnWork, ref sqlConnection);

                for (int i = 0; i < monthRange; i++)
                {
                    stockListResultWorkList = new ArrayList();

                    //�ŏI�N�����O�̏ꍇ�i���߂��s���Ă��Ȃ��j�A�����ߔN���̓��A���W�v�Ώ�
                    if (lastStockHisYm == 0 || lastStockHisYm < st_Date.Year * 100 + st_Date.Month)
                    {
                        //�ΏۂƂȂ�݌Ƀ}�X�^��ǂݍ���
                        status = SearchStockProc(ref stockListResultWorkList,_stockListCndtnWork,logicalMode,ref sqlConnection);

                        //�݌Ƀ}�X�^���擾�o�����ꍇ�̂ݏ�������
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {

                            ArrayList companyInfList = new ArrayList();
                            CompanyInfWork companyInfWork = new CompanyInfWork();

                            //���Џ��ǂݍ���
                            companyInfWork.EnterpriseCode = _stockListCndtnWork.EnterpriseCode;
                            status = companyInfDB.Search(out companyInfList, companyInfWork, ref sqlConnection);
                            companyInfWork = companyInfList[0] as CompanyInfWork;

                            //���Џ����A�Ώ۔N���̊J�n�I�������擾
                            DateTime monthStart = DateTime.MinValue;
                            DateTime monthEnd = DateTime.MinValue;

                            FinYearTableGenerator finYearTableGenerator = new FinYearTableGenerator(companyInfWork);
                            finYearTableGenerator.GetDaysFromMonth(st_Date, out monthStart, out monthEnd);

                            //���A���W�v���\�b�h�Ăяo��
                            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork(); //�����W�v���\�b�h�p�p�����[�^
                            monthlyAddUpWork.EnterpriseCode = _stockListCndtnWork.EnterpriseCode;
                            // 2009/05/28 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //monthlyAddUpWork.AddUpDateSt = monthStart;    //�����J�n���t���Z�b�g
                            monthlyAddUpWork.AddUpDateSt = monthStart.AddDays(-1);    //�����J�n���t���Z�b�g
                            // 2009/05/28 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            monthlyAddUpWork.AddUpDateEd = monthEnd;
                            monthlyAddUpWork.AddUpDate = monthEnd;        //�����I�����t���Z�b�g
                            monthlyAddUpWork.LstMonAddUpProcDay = st_Date.AddMonths(-1);  //�O�񗚗��擾�p�ɑO�����Z�b�g
                            monthlyAddUpWork.AddUpYearMonth = st_Date;

                            List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();
                            // -- UPD 2011/03/14 -------------------->>>
                            //string retMsg = null;
                            //bool msgDiv = true;

                            //status = monthlyAddUpDB.MakeStockHistoryParameters(ref monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection);
                            status = GetShipmentProc(ref stockHistoryWorkList, monthlyAddUpWork, _stockListCndtnWork, ref sqlConnection);
                            // -- UPD 2011/03/14 --------------------<<<
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // �N���X�i�[���\�b�h
                                CopyToStockListResultWorkFromStockHistoryWork(ref stockListResultWorkList, stockHistoryWorkList);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                            {
                                //NOT_FOUND,EOF�̏ꍇ�͎���
                            }
                            else
                            {
                                //�擾���s
                                // -- UPD 2011/03/14 ---------------------------->>>
                                //throw new Exception("�݌ɗ����W�v���W���[������̎擾�Ɏ��s�B");
                                return status;
                                // -- UPD 2011/03/14 ----------------------------<<<
                            }
                        }
                    }
                    else
                    {
                        //���ߍςݕ��͍݌ɗ������擾
                        _stockListCndtnWork.St_LastStockDate = st_Date; //�P�����P�ʂœǂݍ��݂��s�����߁A�J�n�N�����㏑��
                        _stockListCndtnWork.Ed_LastStockDate = st_Date; //�P�����P�ʂœǂݍ��݂��s�����߁A�I���N�����㏑��

                        status = SearchProc(out stockListResultWorkList, _stockListCndtnWork, readMode, logicalMode, ref sqlConnection);
                    }

                    resultList.AddRange(stockListResultWorkList);

                    st_Date = st_Date.AddMonths(1);
                }

                if (resultList.Count == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockListWorkDB.Search Exception=" + ex.Message);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            stockListResultWork = resultList;

            return status;
        }

        /// <summary>
        /// ���ʃ��X�g��������
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="extrInfo_PrevYearComparisonWork">���o����</param>
        /// <returns>RsltInfo_PrevYearComparisonWork</returns>
        /// <remarks>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.03.30</br>
        /// <br></br>
        /// </remarks>
        private void CopyToStockListResultWorkFromStockHistoryWork(ref ArrayList stockListResultWorkList, List<StockHistoryWork> stockHistoryList)
        {
            //�݌Ƀ}�X�^���X�g�ɑΉ�����݌ɗ������擾���āA���ʃ��X�g�ɃZ�b�g����
            foreach (StockListResultWork stockListResultWork in stockListResultWorkList)
            {
                StockHistoryWork sthisWork = stockHistoryList.Find(delegate(StockHistoryWork paraHisWork)
                {
                    return paraHisWork.GoodsMakerCd == stockListResultWork.GoodsMakerCd &&
                            paraHisWork.GoodsNo == stockListResultWork.GoodsNo &&
                            paraHisWork.WarehouseCode == stockListResultWork.WarehouseCode;
                }
                );

                if (sthisWork != null)
                {
                    //�݌ɗ�������擾���鍀�ڂ��Z�b�g
                    // -- DEL 2011/03/14 �i���Ƒq�ɖ��͍̂݌Ɏ擾���Ɏ擾����悤�ɏC��----------->>>
                    //stockListResultWork.WarehouseName = sthisWork.WarehouseName;  
                    //stockListResultWork.GoodsName = sthisWork.GoodsName;
                    // -- DEL 2011/03/14 ---------------------------------------------------------<<<
                    stockListResultWork.AddUpYearMonth = sthisWork.AddUpYearMonth;
                    stockListResultWork.ShipmentCnt = sthisWork.SalesCount + sthisWork.SalesRetGoodsCnt;
                    stockListResultWork.ShipmentPrice = sthisWork.SalesMoneyTaxExc + sthisWork.SalesRetGoodsPrice;
                }
            }
        }

        #region SearchStockProc
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="stockHistoryList">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_stockMonthYearReportWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchStockProc(ref ArrayList stockListResultWorkList, StockListCndtnWork _stockListCndtnWork, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string key = string.Empty;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                #region SELECT��
                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "   STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.SECTIONCODERF" + Environment.NewLine; // 2009/06/10
                selectTxt += "  ,GDSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,GDSU.GOODSNAMERF" + Environment.NewLine;  // ADD 2011/03/14
                selectTxt += "  ,WARE.WAREHOUSENAMERF" + Environment.NewLine;  // ADD 2011/03/14
                // -- UPD 2011/03/14 --------------------------->>>
                //selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                //selectTxt += "LEFT JOIN GOODSURF AS GDSU" + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSURF AS GDSU WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/14 ---------------------------<<<
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GDSU.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GDSU.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND GDSU.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;
                // -- UPD 2011/03/14 --------------------------->>>
                selectTxt += " LEFT JOIN WAREHOUSERF WARE WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += " ON WARE.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND WARE.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;
                // -- UPD 2011/03/14 ---------------------------<<<

                selectTxt += MakeWhereStockString(ref sqlCommand, _stockListCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    StockListResultWork wkStockListResultWork = new StockListResultWork();

                    // �i�[����
                    #region ���o���ʊi�[����
                    wkStockListResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkStockListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockListResultWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    wkStockListResultWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    wkStockListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkStockListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockListResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkStockListResultWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkStockListResultWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkStockListResultWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    wkStockListResultWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    wkStockListResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // 2009/06/10
                    // -- UPD 2011/03/14 --------------------------->>>
                    wkStockListResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF")); 
                    wkStockListResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    // -- UPD 2011/03/14 ---------------------------<<<
                    #endregion

                    stockListResultWorkList.Add(wkStockListResultWork);

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                #endregion
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockListWorkDB.SearchStockProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
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

            return status;
        }

        #endregion

        /// <summary>
        /// �ŏI�̍݌ɗ������R�[�h�N����߂��܂�
        /// </summary>
        /// <param name="_stockListCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ŏI�̍݌ɗ������R�[�h�N����߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.03.30</br>
        /// <br></br>
        private int GetLastStockHisYm(StockListCndtnWork _stockListCndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            int retYm = 0;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {

                string selectTxt = "";

                selectTxt += "SELECT " + Environment.NewLine;
                selectTxt += "  MAX(STOCKHIS.ADDUPYEARMONTHRF) AS ADDUPYEARMONTHRF" + Environment.NewLine;
                // -- UPD 2011/03/14 --------------------->>>
                //selectTxt += " FROM STOCKHISTORYRF AS STOCKHIS" + Environment.NewLine;
                selectTxt += " FROM STOCKHISTORYRF AS STOCKHIS WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/14 ---------------------<<<
                selectTxt += "WHERE" + Environment.NewLine;
                selectTxt += " STOCKHIS.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.EnterpriseCode);

                myReader = sqlCommand.ExecuteReader();

                if (myReader.Read())
                {
                    //�ŏI�v��N�����擾
                    retYm = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                }

                //�擾�o���Ȃ��ꍇ������Ƃ���
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockListWorkDB.GetLastStockHisYm Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();

            }
            return retYm;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌Ɉꗗ�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockListResultWork">��������</param>
        /// <param name="_stockListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌Ɉꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.20</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.09 ���� DC.NS�p�ɏC��</br>
        private int SearchProc(out ArrayList stockListResultWork, StockListCndtnWork _stockListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            stockListResultWork = null;
            ArrayList al = new ArrayList();   //���o����

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {

                // �Ώۃe�[�u��
                // STOCKRF        STOCK  �݌Ƀ}�X�^
                // STOCKHISTORYRF STCH   �݌ɗ����f�[�^
                // WAREHOUSERF    WAH    �q�Ƀ}�X�^
                // SUPPLIERRF     SUP    �d���}�X�^
                // GOODSURF       GDSU   ���i�}�X�^(���[�U�[�o�^��)

                string selectTxt = "";

                #region Select���쐬
                //���ʎ擾
                //�݌Ƀ}�X�^�擾����
                selectTxt += "SELECT" + Environment.NewLine;
                //selectTxt += "  STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "  STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,WAH.WAREHOUSENAMERF" + Environment.NewLine;
                //selectTxt += " ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += " ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += " ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += " ,GDSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,GDSU.GOODSNAMERF" + Environment.NewLine;
                selectTxt += " ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += " ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += " ,STOCK.SECTIONCODERF" + Environment.NewLine;  // 2009/06/10
                selectTxt += " ,STCH.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += " ,(STCH.SALESCOUNTRF + STCH.SALESRETGOODSCNTRF) AS TOTALCNTRF" + Environment.NewLine;
                selectTxt += " ,(STCH.SALESMONEYTAXEXCRF + STCH.SALESRETGOODSPRICERF) AS TOTALPRICERF" + Environment.NewLine;
                // -- UPD 2011/03/14 ------------------------->>>
                //selectTxt += " FROM STOCKRF AS STOCK" + Environment.NewLine;
                selectTxt += " FROM STOCKRF AS STOCK WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/14 -------------------------<<<

                //�q�Ƀ}�X�^
                // -- UPD 2011/03/14 ------------------------->>>
                //selectTxt += " LEFT JOIN WAREHOUSERF WAH" + Environment.NewLine;
                selectTxt += " LEFT JOIN WAREHOUSERF WAH WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/14 -------------------------<<<
                selectTxt += " ON WAH.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND WAH.WAREHOUSECODERF = STOCK.WAREHOUSECODERF" + Environment.NewLine;

                ////�d����}�X�^
                //selectTxt += " LEFT JOIN SUPPLIERRF SUP" + Environment.NewLine;
                //selectTxt += " ON SUP.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND SUP.SUPPLIERCDRF = STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;

                //���i�}�X�^
                // -- UPD 2011/03/14 ------------------------->>>
                //selectTxt += " LEFT JOIN GOODSURF GDSU ON" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF GDSU WITH (READUNCOMMITTED) ON " + Environment.NewLine;
                // -- UPD 2011/03/14 -------------------------<<<
                selectTxt += " GDSU.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GDSU.GOODSMAKERCDRF = STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GDSU.GOODSNORF = STOCK.GOODSNORF" + Environment.NewLine;

                //�݌ɗ����f�[�^
                // -- UPD 2011/03/14 ------------------------->>>
                //selectTxt += " LEFT JOIN STOCKHISTORYRF STCH" + Environment.NewLine;
                selectTxt += " LEFT JOIN STOCKHISTORYRF STCH WITH (READUNCOMMITTED)" + Environment.NewLine;
                // -- UPD 2011/03/14 -------------------------<<<
                selectTxt += " ON  STCH.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND STCH.SECTIONCODERF=STOCK.SECTIONCODERF" + Environment.NewLine;  // 2009/05/11
                selectTxt += " AND STCH.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND STCH.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += " AND STCH.WAREHOUSECODERF=STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " AND (STCH.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH)" + Environment.NewLine;

                #endregion

                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                //WHERE���̍쐬
                sqlCommand.CommandText += MakeWhereString(ref sqlCommand, _stockListCndtnWork, logicalMode);

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StockListResultWork wkStockListResultWork = new StockListResultWork();

                    //�݌Ƀ}�X�^�i�[����
                    wkStockListResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkStockListResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    //wkStockListResultWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    //wkStockListResultWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkStockListResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockListResultWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    wkStockListResultWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    wkStockListResultWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkStockListResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockListResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStockListResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkStockListResultWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkStockListResultWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkStockListResultWork.ShipmentPosCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    wkStockListResultWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    wkStockListResultWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                    wkStockListResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF")); // 2009/06/10
                    
                    if (wkStockListResultWork.AddUpYearMonth == DateTime.MinValue)
                    {
                        wkStockListResultWork.AddUpYearMonth = _stockListCndtnWork.St_LastStockDate;
                    }
                    wkStockListResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALCNTRF"));
                    wkStockListResultWork.ShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALPRICERF"));
                    #endregion

                    al.Add(wkStockListResultWork);

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
                base.WriteErrorLog(ex, "StockListWorkDB.SearchProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            stockListResultWork = al;

            return status;
        }
        #endregion

        #region[WHERE��]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param> 
        /// <param name="_stockListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockListCndtnWork _stockListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE";

            //��ƃR�[�h
            retstring += " STOCK.ENTERPRISECODERF=@ENTERPRISECODE";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            ////���_�R�[�h  ���z��ŕ����w�肳���
            //if (_stockListCndtnWork.DepositStockSecCodeList != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _stockListCndtnWork.DepositStockSecCodeList)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }

            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND STOCK.SECTIONCODERF IN (" + sectionCodestr + ") ";
            //    }
            //}

            //�݌ɓo�^��
            if (_stockListCndtnWork.StockCreateDate != DateTime.MinValue)
            {
                int startymdStockCreateDate = TDateTime.DateTimeToLongDate(_stockListCndtnWork.StockCreateDate);
                if (_stockListCndtnWork.StockCreateDateFlg == 0)
                {
                    // --- UPD 2012/12/03 T.MIyamoto ------------------------------>>>>>
                    //retstring += " AND STOCK.STOCKCREATEDATERF <= " + startymdStockCreateDate.ToString();
                    retstring += " AND (CASE WHEN STOCK.STOCKCREATEDATERF IS NULL THEN 0 ELSE STOCK.STOCKCREATEDATERF END) <= " + startymdStockCreateDate.ToString();
                    // --- UPD 2012/12/03 T.MIyamoto ------------------------------<<<<<
                }
                else
                {
                    // --- UPD 2012/12/03 T.MIyamoto ------------------------------>>>>>
                    //retstring += " AND STOCK.STOCKCREATEDATERF >= " + startymdStockCreateDate.ToString();
                    retstring += " AND (CASE WHEN STOCK.STOCKCREATEDATERF IS NULL THEN 0 ELSE STOCK.STOCKCREATEDATERF END) >= " + startymdStockCreateDate.ToString();
                    // --- UPD 2012/12/03 T.MIyamoto ------------------------------<<<<<
                }
            }

            //�o�א�
            //if (_stockListCndtnWork.St_ShipmentPosCnt != 0)
            //{
            //    retstring += " AND STCH.TOTALSHIPMENTCNTRF>=@STTOTALSHIPMENTCNTRF";
            //    SqlParameter paraStShipmentPosCnt = sqlCommand.Parameters.Add("@STTOTALSHIPMENTCNTRF", SqlDbType.Float);
            //    paraStShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(_stockListCndtnWork.St_ShipmentPosCnt);
            //}
            //if (_stockListCndtnWork.Ed_ShipmentPosCnt != 0)
            //{
            //    if (_stockListCndtnWork.St_ShipmentPosCnt > 0)
            //    {
            //        retstring += " AND STCH.TOTALSHIPMENTCNTRF<=@EDTOTALSHIPMENTCNTRF";
            //    }
            //    else
            //    {
            //        retstring += " AND (STCH.TOTALSHIPMENTCNTRF<=@EDTOTALSHIPMENTCNTRF OR STCH.TOTALSHIPMENTCNTRF IS NULL)";
            //    }

            //    SqlParameter paraEdShipmentPosCnt = sqlCommand.Parameters.Add("@EDTOTALSHIPMENTCNTRF", SqlDbType.Float);
            //    paraEdShipmentPosCnt.Value = SqlDataMediator.SqlSetDouble(_stockListCndtnWork.Ed_ShipmentPosCnt);
            //}

            //���i�Ǘ��敪�P  ���z��ŕ����w�肳���
            if (_stockListCndtnWork.PartsManagementDivide1 != null)
            {
                string Divied1 = "";
                foreach (string Divide1str in _stockListCndtnWork.PartsManagementDivide1)
                {
                    if (Divied1 != "")
                    {
                        Divied1 += ",";
                    }
                    Divied1 += "'" + Divide1str + "'";
                }

                if (Divied1 != "")
                {
                    retstring += " AND STOCK.PARTSMANAGEMENTDIVIDE1RF IN (" + Divied1 + ") ";
                }
            }

            //���i�Ǘ��敪�Q  ���z��ŕ����w�肳���
            if (_stockListCndtnWork.PartsManagementDivide2 != null)
            {
                string Divied2 = "";
                foreach (string Divide2str in _stockListCndtnWork.PartsManagementDivide2)
                {
                    if (Divied2 != "")
                    {
                        Divied2 += ",";
                    }
                    Divied2 += "'" + Divide2str + "'";
                }

                if (Divied2 != "")
                {
                    retstring += " AND STOCK.PARTSMANAGEMENTDIVIDE2RF IN (" + Divied2 + ") ";
                }
            }

            /*
            //�ŏI�d���N����
            if (_stockListCndtnWork.St_LastStockDate != DateTime.MinValue)
            {
                int startymdLastStockDate = TDateTime.DateTimeToLongDate(_stockListCndtnWork.St_LastStockDate);
                retstring += " AND STOCK.LASTSTOCKDATERF >= " + startymdLastStockDate.ToString();
            }
            if (_stockListCndtnWork.Ed_LastStockDate != DateTime.MinValue)
            {
                if (_stockListCndtnWork.St_LastStockDate == DateTime.MinValue)
                {
                    retstring += " AND (STOCK.LASTSTOCKDATERF IS NULL OR";
                }
                else
                {
                    retstring += " AND";
                }

                int endymdLastStockDate = TDateTime.DateTimeToLongDate(_stockListCndtnWork.Ed_LastStockDate);
                retstring += " STOCK.LASTSTOCKDATERF <= " + endymdLastStockDate.ToString();

                if (_stockListCndtnWork.St_LastStockDate == DateTime.MinValue)
                {
                    retstring += " ) ";
                }
            }
            */ 

            //�q�ɃR�[�h
            if (_stockListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE";
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.St_WarehouseCode);
            }
            if (_stockListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND (STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE OR STOCK.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)";
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.Ed_WarehouseCode);
            }

            ////�݌ɔ�����R�[�h
            //if (_stockListCndtnWork.St_StockSupplierCode != 0)
            //{
            //    retstring += " AND STOCK.STOCKSUPPLIERCODERF>=@STSTOCKSUPPLIERCODE";
            //    SqlParameter paraStStockSupplierCode = sqlCommand.Parameters.Add("@STSTOCKSUPPLIERCODE", SqlDbType.Int);
            //    paraStStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(_stockListCndtnWork.St_StockSupplierCode);
            //}
            //if (_stockListCndtnWork.Ed_StockSupplierCode != 999999)
            //{
            //    retstring += " AND STOCK.STOCKSUPPLIERCODERF<=@EDSTOCKSUPPLIERCODERF";
            //    SqlParameter paraEdStockSupplierCode = sqlCommand.Parameters.Add("@EDSTOCKSUPPLIERCODERF", SqlDbType.Int);
            //    paraEdStockSupplierCode.Value = SqlDataMediator.SqlSetInt32(_stockListCndtnWork.Ed_StockSupplierCode);
            //}

            //�I��
            if (_stockListCndtnWork.St_WarehouseShelfNo != "")
            {
                retstring += " AND STOCK.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNORF";
                SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNORF", SqlDbType.NVarChar);
                paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.St_WarehouseShelfNo);
            }
            if (_stockListCndtnWork.Ed_WarehouseShelfNo != "")
            {
                if (_stockListCndtnWork.St_WarehouseShelfNo != "")
                {
                    retstring += " AND STOCK.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNORF";
                }
                else
                {
                    retstring += " AND (STOCK.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNORF OR STOCK.WAREHOUSESHELFNORF IS NULL)";
                }

                SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNORF", SqlDbType.NVarChar);
                paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.Ed_WarehouseShelfNo);
            }

            //���[�J�[�R�[�h
            if (_stockListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF>=@STGOODSMAKERCD";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF<=@EDGOODSMAKERCD";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockListCndtnWork.Ed_GoodsMakerCd);
            }

            //BL���i�R�[�h
            if (_stockListCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND GDSU.BLGOODSCODERF>=@STBLGOODSCODE";
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockListCndtnWork.St_BLGoodsCode);
            }
            if (_stockListCndtnWork.Ed_BLGoodsCode != 99999)
            {
                retstring += " AND GDSU.BLGOODSCODERF<=@EDBLGOODSCODE";
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockListCndtnWork.Ed_BLGoodsCode);
            }

            //���i�ԍ�
            if (_stockListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF>=@STGOODSNO";
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.St_GoodsNo);
            }
            if (_stockListCndtnWork.Ed_GoodsNo != "")
            {
				retstring += " AND STOCK.GOODSNORF<=@EDGOODSNO";
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
				paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.Ed_GoodsNo);
			}

            //�݌ɗ����f�[�^
            SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
            paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockListCndtnWork.St_LastStockDate);   //�J�n�N��
            SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
            paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockListCndtnWork.Ed_LastStockDate);   //��ʏI���N��

            #endregion

            return retstring;
        }
        #endregion

        #region [�݌Ƀ}�X�^ WHERE��]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param> 
        /// <param name="_stockListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereStockString(ref SqlCommand sqlCommand, StockListCndtnWork _stockListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE";

            //��ƃR�[�h
            retstring += " STOCK.ENTERPRISECODERF=@ENTERPRISECODE";
            SqlParameter paraEnterPriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterPriseCode.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE ";
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            ////���_�R�[�h  ���z��ŕ����w�肳���
            //if (_stockListCndtnWork.DepositStockSecCodeList != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _stockListCndtnWork.DepositStockSecCodeList)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }

            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND STOCK.SECTIONCODERF IN (" + sectionCodestr + ") ";
            //    }
            //}

            //�݌ɓo�^��
            if (_stockListCndtnWork.StockCreateDate != DateTime.MinValue)
            {
                int startymdStockCreateDate = TDateTime.DateTimeToLongDate(_stockListCndtnWork.StockCreateDate);
                if (_stockListCndtnWork.StockCreateDateFlg == 0)
                {
                    // --- UPD 2012/12/03 T.MIyamoto ------------------------------>>>>>
                    //retstring += " AND STOCK.STOCKCREATEDATERF <= " + startymdStockCreateDate.ToString();
                    retstring += " AND (CASE WHEN STOCK.STOCKCREATEDATERF IS NULL THEN 0 ELSE STOCK.STOCKCREATEDATERF END) <= " + startymdStockCreateDate.ToString();
                    // --- UPD 2012/12/03 T.MIyamoto ------------------------------<<<<<
                }
                else
                {
                    // --- UPD 2012/12/03 T.MIyamoto ------------------------------>>>>>
                    //retstring += " AND STOCK.STOCKCREATEDATERF >= " + startymdStockCreateDate.ToString();
                    retstring += " AND (CASE WHEN STOCK.STOCKCREATEDATERF IS NULL THEN 0 ELSE STOCK.STOCKCREATEDATERF END) >= " + startymdStockCreateDate.ToString();
                    // --- UPD 2012/12/03 T.MIyamoto ------------------------------<<<<<
                }
            }

            //���i�Ǘ��敪�P  ���z��ŕ����w�肳���
            if (_stockListCndtnWork.PartsManagementDivide1 != null)
            {
                string Divied1 = "";
                foreach (string Divide1str in _stockListCndtnWork.PartsManagementDivide1)
                {
                    if (Divied1 != "")
                    {
                        Divied1 += ",";
                    }
                    Divied1 += "'" + Divide1str + "'";
                }

                if (Divied1 != "")
                {
                    retstring += " AND STOCK.PARTSMANAGEMENTDIVIDE1RF IN (" + Divied1 + ") ";
                }
            }

            //���i�Ǘ��敪�Q  ���z��ŕ����w�肳���
            if (_stockListCndtnWork.PartsManagementDivide2 != null)
            {
                string Divied2 = "";
                foreach (string Divide2str in _stockListCndtnWork.PartsManagementDivide2)
                {
                    if (Divied2 != "")
                    {
                        Divied2 += ",";
                    }
                    Divied2 += "'" + Divide2str + "'";
                }

                if (Divied2 != "")
                {
                    retstring += " AND STOCK.PARTSMANAGEMENTDIVIDE2RF IN (" + Divied2 + ") ";
                }
            }

            //�q�ɃR�[�h
            if (_stockListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE";
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.St_WarehouseCode);
            }
            if (_stockListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND (STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE OR STOCK.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)";
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.Ed_WarehouseCode);
            }

            //�I��
            if (_stockListCndtnWork.St_WarehouseShelfNo != "")
            {
                retstring += " AND STOCK.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNORF";
                SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNORF", SqlDbType.NVarChar);
                paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.St_WarehouseShelfNo);
            }
            if (_stockListCndtnWork.Ed_WarehouseShelfNo != "")
            {
                if (_stockListCndtnWork.St_WarehouseShelfNo != "")
                {
                    retstring += " AND STOCK.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNORF";
                }
                else
                {
                    retstring += " AND (STOCK.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNORF OR STOCK.WAREHOUSESHELFNORF IS NULL)";
                }

                SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNORF", SqlDbType.NVarChar);
                paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.Ed_WarehouseShelfNo);
            }

            //���[�J�[�R�[�h
            if (_stockListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF>=@STGOODSMAKERCD";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF<=@EDGOODSMAKERCD";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockListCndtnWork.Ed_GoodsMakerCd);
            }

            //BL���i�R�[�h
            if (_stockListCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND GDSU.BLGOODSCODERF>=@STBLGOODSCODE";
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockListCndtnWork.St_BLGoodsCode);
            }
            if (_stockListCndtnWork.Ed_BLGoodsCode != 99999)
            {
                retstring += " AND GDSU.BLGOODSCODERF<=@EDBLGOODSCODE";
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockListCndtnWork.Ed_BLGoodsCode);
            }

            //���i�ԍ�
            if (_stockListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF>=@STGOODSNO";
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.St_GoodsNo);
            }
            if (_stockListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF<=@EDGOODSNO";
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.Ed_GoodsNo);
            }

            #endregion

            return retstring;
        }
        #endregion

        // -- ADD 2011/03/14 ------------------------------>>>
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɉߏ�ꗗ�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retStockOverList">��������</param>
        /// <param name="_stockOverListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɉߏ�ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.04.23</br>
        private int GetShipmentProc(ref List<StockHistoryWork> retStockHistoryList, MonthlyAddUpWork monthlyAddUpWork, StockListCndtnWork _stockListCndtnWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            try
            {

                string selectTxt = "";
                sqlCommand = new SqlCommand("", sqlConnection);

                #region Select���쐬
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "    STPAY.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "    STPAY.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "    STPAY.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "    STPAY.GOODSNORF," + Environment.NewLine;
                selectTxt += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=10  ) ) THEN STPAY.SHIPMENTCNTRF + STPAY.DELSHIPMENTCNTRF ELSE 0 END) AS SALESCOUNTRF,--���㐔" + Environment.NewLine;
                selectTxt += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=10 ) ) THEN STPAY.SALESMONEYRF + STPAY.DELSALESMONEYRF ELSE 0 END) AS SALESMONEYTAXEXCRF,--������z�i�Ŕ����j" + Environment.NewLine;
                selectTxt += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20 ) ) THEN STPAY.SHIPMENTCNTRF + STPAY.DELSHIPMENTCNTRF ELSE 0 END) AS SALESRETGOODSCNTRF,--����ԕi��" + Environment.NewLine;
                selectTxt += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20 ) ) THEN STPAY.SALESMONEYRF + STPAY.DELSALESMONEYRF ELSE 0 END) AS SALESRETGOODSPRICERF--����ԕi�z" + Environment.NewLine;
                selectTxt += "" + Environment.NewLine;
                selectTxt += "   FROM" + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                selectTxt += "    select" + Environment.NewLine;
                selectTxt += "      STACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                selectTxt += "      STACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "      STACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "      STACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "      STACPAYHIST.GOODSNORF," + Environment.NewLine;
                selectTxt += "      STACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                selectTxt += "      STACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                selectTxt += "      STACPAYHIST.ACPAYTRANSCDRF, --�󕥌�����敪" + Environment.NewLine;
                selectTxt += "      STACPAYHIST.SHIPMENTCNTRF,  --�o�א�" + Environment.NewLine;
                selectTxt += "      STACPAYHIST.SALESMONEYRF,    --������z      " + Environment.NewLine;
                selectTxt += "      (CASE WHEN STACPAYHISTDEL.SHIPMENTCNTRF IS NULL THEN 0 ELSE STACPAYHISTDEL.SHIPMENTCNTRF END ) AS DELSHIPMENTCNTRF,   --�o�א�" + Environment.NewLine;
                selectTxt += "      (CASE WHEN STACPAYHISTDEL.SALESMONEYRF IS NULL THEN 0 ELSE STACPAYHISTDEL.SALESMONEYRF END) AS DELSALESMONEYRF       --������z     " + Environment.NewLine;
                selectTxt += "    from" + Environment.NewLine;
                selectTxt += "    (" + Environment.NewLine;
                selectTxt += "     SELECT" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ACPAYTRANSCDRF, --�󕥌�����敪" + Environment.NewLine;
                selectTxt += "      SUM(STOCKACPAYHIST.SHIPMENTCNTRF) AS SHIPMENTCNTRF,  --�o�א�" + Environment.NewLine;
                selectTxt += "      SUM(STOCKACPAYHIST.SALESMONEYRF) AS SALESMONEYRF    --������z" + Environment.NewLine;
                selectTxt += "     FROM" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHISTRF AS STOCKACPAYHIST WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "     WHERE " + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "      AND STOCKACPAYHIST.LOGICALDELETECODERF=0" + Environment.NewLine;
                selectTxt += "     AND( ( CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END ) >@FINDADDUPDATEST  AND (CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END )<=@FINDADDUPDATEED)" + Environment.NewLine;
                selectTxt += "      AND STOCKACPAYHIST.ACPAYTRANSCDRF  != 21" + Environment.NewLine;
                selectTxt += "      AND STOCKACPAYHIST.ACPAYTRANSCDRF  != 90" + Environment.NewLine;
                selectTxt += "     GROUP BY" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ACPAYTRANSCDRF --�󕥌�����敪" + Environment.NewLine;
                selectTxt += "     ) AS STACPAYHIST" + Environment.NewLine;
                selectTxt += "     LEFT JOIN" + Environment.NewLine;
                selectTxt += "     (" + Environment.NewLine;
                selectTxt += "     SELECT" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ACPAYTRANSCDRF, --�󕥌�����敪" + Environment.NewLine;
                selectTxt += "      SUM(STOCKACPAYHIST.SHIPMENTCNTRF) AS SHIPMENTCNTRF,  --�o�א�" + Environment.NewLine;
                selectTxt += "      SUM(STOCKACPAYHIST.SALESMONEYRF) AS SALESMONEYRF    --������z" + Environment.NewLine;
                selectTxt += "     FROM" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHISTRF AS STOCKACPAYHIST WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "     WHERE " + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "      AND STOCKACPAYHIST.LOGICALDELETECODERF=0" + Environment.NewLine;
                selectTxt += "     AND( ( CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END ) >@FINDADDUPDATEST  AND (CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END )<=@FINDADDUPDATEED)" + Environment.NewLine;
                selectTxt += "      AND (STOCKACPAYHIST.ACPAYTRANSCDRF  = 21 OR STOCKACPAYHIST.ACPAYTRANSCDRF  = 90)" + Environment.NewLine;
                selectTxt += "     GROUP BY" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                selectTxt += "      STOCKACPAYHIST.ACPAYTRANSCDRF --�󕥌�����敪" + Environment.NewLine;
                selectTxt += "     ) AS STACPAYHISTDEL" + Environment.NewLine;
                selectTxt += "     ON STACPAYHIST.ENTERPRISECODERF = STACPAYHISTDEL.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "     AND STACPAYHIST.WAREHOUSECODERF = STACPAYHISTDEL.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "     AND STACPAYHIST.GOODSMAKERCDRF = STACPAYHISTDEL.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "     AND STACPAYHIST.GOODSNORF = STACPAYHISTDEL.GOODSNORF" + Environment.NewLine;
                selectTxt += "     AND STACPAYHIST.ACPAYSLIPNUMRF = STACPAYHISTDEL.ACPAYSLIPNUMRF" + Environment.NewLine;
                selectTxt += "     AND STACPAYHIST.ACPAYSLIPCDRF = STACPAYHISTDEL.ACPAYSLIPCDRF    " + Environment.NewLine;
                selectTxt += "    )AS STPAY" + Environment.NewLine;

                //WHERE���̍쐬
                selectTxt += MakeWhereStringShipment(ref sqlCommand, monthlyAddUpWork, _stockListCndtnWork);

                selectTxt += "    GROUP  BY" + Environment.NewLine;
                selectTxt += "     STPAY.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "     STPAY.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "     STPAY.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "     STPAY.GOODSNORF" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;
                #endregion



                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StockHistoryWork stockhisWork = new StockHistoryWork();

                    //�i�[����
                    stockhisWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockhisWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockhisWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockhisWork.AddUpYearMonth = monthlyAddUpWork.AddUpYearMonth;
                    stockhisWork.SalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                    stockhisWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                    stockhisWork.SalesRetGoodsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRETGOODSCNTRF"));
                    stockhisWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));

                    #endregion

                    retStockHistoryList.Add(stockhisWork);

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
                base.WriteErrorLog(ex, "StockOverListWorkDB.GetSalesTimesProc Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (myReader != null)
                {
                    if (!myReader.IsClosed)
                    {
                        myReader.Close();
                    }

                    myReader.Dispose();
                    myReader = null;
                }

                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                    sqlCommand = null;
                }
            }

            return status;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockOverListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereStringShipment(ref SqlCommand sqlCommand, MonthlyAddUpWork monthlyAddUpWork, StockListCndtnWork _stockListCndtnWork)
        {
            #region WHERE���쐬
            string retstring = " WHERE " + Environment.NewLine;

            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaAddUpDateSt = sqlCommand.Parameters.Add("@FINDADDUPDATEST", SqlDbType.Int);
            SqlParameter findParaAddUpDateEd = sqlCommand.Parameters.Add("@FINDADDUPDATEED", SqlDbType.Int);

            findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(monthlyAddUpWork.EnterpriseCode);
            findParaAddUpDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(monthlyAddUpWork.AddUpDateSt);
            findParaAddUpDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(monthlyAddUpWork.AddUpDate);

            //��ƃR�[�h
            retstring += " STPAY.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

            //�q�ɃR�[�h�ݒ�
            if (_stockListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STPAY.WAREHOUSECODERF>=@STWAREHOUSECODE";
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.St_WarehouseCode);
            }
            if (_stockListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STPAY.WAREHOUSECODERF<=@EDWAREHOUSECODE";
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.Ed_WarehouseCode);
            }

            //���[�J�[�R�[�h�ݒ�
            if (_stockListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STPAY.GOODSMAKERCDRF>=@STGOODSMAKERCD";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STPAY.GOODSMAKERCDRF<=@EDGOODSMAKERCD";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockListCndtnWork.Ed_GoodsMakerCd);
            }

            //���i�ԍ��ݒ�
            if (_stockListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STPAY.GOODSNORF>=@STGOODSNO";
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.St_GoodsNo);
            }
            if (_stockListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STPAY.GOODSNORF<=@EDGOODSNO";
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockListCndtnWork.Ed_GoodsNo);
            }
            #endregion
            return retstring;
        }
        // -- ADD 2011/03/14 ------------------------------<<<
    
    }
}
