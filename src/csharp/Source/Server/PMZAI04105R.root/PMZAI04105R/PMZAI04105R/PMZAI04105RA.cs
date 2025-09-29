
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
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ɏ��яƉ�DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɏ��яƉ�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.11</br>
    /// <br></br>
    /// <br>Update Note: �݌ɗ������A���W�v���̌Ăяo�����\�b�h�̕ύX�i�P���擾���s��Ȃ����\�b�h�j</br>
    /// <br>Programmer : 22008</br>
    /// <br>Date       : 2010/06/02</br>
    /// <br>Update Note: 2010/07/20 ������ �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2010/08/12 chenyd</br>
    /// <br>            �E��QID:13055 �e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2010/09/19 tianjw</br>
    /// <br>            �E�e�L�X�g�o�͑Ή�</br>
    /// <br>Update Note: 2011/03/22 ������</br>
    /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
    /// <br>Update Note: 2017/05/10 �v��</br>
    /// <br>             REDMINE#49285 �݌ɗ����f�[�^�쐬�����@�J�n���ɑO���������܂܂���Q�Ή�</br>
    /// <br>Update Note: �݌ɔN�Ԏ��яƉ�\����</br>
    /// <br>Programmer : ��ؑn</br>
    /// <br>Date       : 2021.11.10</br>
    /// </remarks>
    [Serializable]
    public class StockHisDspDB : RemoteWithAppLockDB, IStockHisDspDB
    {
        /// <summary>
        /// �݌Ɏ��яƉ�DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        /// <br></br>
        /// <br>UpdateNote : ���_�R�[�h���o�����̍폜</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2009.06.24</br>
        /// </remarks>
        public StockHisDspDB()
            :
            base("PMZAI04107D", "Broadleaf.Application.Remoting.ParamData.StockHistoryDspSearchResultWork", "STOCKHISTORYRF")
        {
        }

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�
        /// </summary>
        /// <param name="StockHistoryDspSearchResultWork">��������</param>
        /// <param name="StockHistoryDspSearchParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        public int Search(out object stockHistoryDspSearchResultWork, object StockHistoryDspSearchParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockHistoryDspSearchResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();

                return SearchStockHisDsp(out stockHistoryDspSearchResultWork, StockHistoryDspSearchParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockHisDspDB.Search");
                stockHistoryDspSearchResultWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objStockHistoryDspSearchResultWork">��������</param>
        /// <param name="objStockHistoryDspSearchParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        private int SearchStockHisDsp(out object objStockHistoryDspSearchResultWork, object objStockHistoryDspSearchParamWork, ref SqlConnection sqlConnection)
        {
            StockHistoryDspSearchParamWork paramWork = null;

            ArrayList paramWorkList = objStockHistoryDspSearchParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objStockHistoryDspSearchParamWork as StockHistoryDspSearchParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as StockHistoryDspSearchParamWork;
            }

            ArrayList stockHistoryDspSearchResultWork = null;

            // ---ADD 2011/03/22---------->>>>>
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
            oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, paramWork.EnterpriseCode, "�݌ɔN�Ԏ��яƉ�", "���o�J�n");
            // ---ADD 2011/03/22----------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // �݌Ɏ��яƉ�f�[�^���擾(����-�݌Ɏ󕥃f�[�^)
            status = SearchStockAcPayHistProc(out stockHistoryDspSearchResultWork, paramWork, ref sqlConnection);

            // �݌Ɏ��яƉ�f�[�^���擾(�ߋ�-�݌ɗ����f�[�^)
            status = SearchStockHisDspProc(ref stockHistoryDspSearchResultWork, paramWork, ref sqlConnection);

            // ---ADD 2011/03/22---------->>>>>
            oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, paramWork.EnterpriseCode, "�݌ɔN�Ԏ��яƉ�", "���o�I��");
            // ---ADD 2011/03/22----------<<<<<

            if (stockHistoryDspSearchResultWork.Count > 0) status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            objStockHistoryDspSearchResultWork = stockHistoryDspSearchResultWork;
            return status;

        }
        #endregion  //Search

        #region [SearchStockAcPayHistProc]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockHistoryDspSearchResultWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        /// <br>Update Note : 2010/09/13 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: �v�� 2017/05/10</br>
        /// <br>             REDMINE#49285 �݌ɗ����f�[�^�쐬�����@�J�n���ɑO���������܂܂���Q�Ή�</br>
        /// <br>Update Note: �݌ɔN�Ԏ��яƉ�\����</br>
        /// <br>Programmer : ��ؑn</br>
        /// <br>Date       : 2021.11.10</br>
        private int SearchStockAcPayHistProc(out ArrayList stockHistoryDspSearchResultWorkList, StockHistoryDspSearchParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            ArrayList al = new ArrayList();
            //�݌ɗ����f�[�^List
            List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();
            MonthlyAddUpDB
                monthlyAddUpDB = new MonthlyAddUpDB();
            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();

            #region DEL 2009/06/24 
            /*
            #region �S�Аݒ�
            if ((paramWork.SectionCodes.Length == 0) || (paramWork.SectionCodes[0] == ""))
            {
                // �S�Ћ��ʂ̏ꍇ
                CustomSerializeArrayList sectionList = new CustomSerializeArrayList();
                SectionInfo sectionInfo = new SectionInfo();
                SecInfoSetWork sectionInfoSetWork = new SecInfoSetWork();
                sectionInfoSetWork.EnterpriseCode = paramWork.EnterpriseCode;
                sectionInfoSetWork.LogicalDeleteCode = 0;

                sectionInfo.Search(out sectionList, sectionInfoSetWork, ref sqlConnection, 0, ConstantManagement.LogicalMode.GetDataAll);
                ArrayList paraList = ListUtils.Find(sectionList, typeof(SecInfoSetWork), ListUtils.FindType.Array) as ArrayList;
                string[] str = new string[paraList.Count];
                int i = 0;
                foreach (SecInfoSetWork sec in paraList)
                {
                    // ArrayList���當����ɑ��
                    str[i] = sec.SectionCode;
                    i++;
                }
                if (str.Length != 0)
                {
                    paramWork.SectionCodes = str;
                }
            }
            #endregion
            */
            #endregion

            try
            {

                StockHistoryDspSearchResultWork ResultWork = new StockHistoryDspSearchResultWork();
                foreach (string sectionCode in paramWork.SectionCodes)
                {
                    stockHistoryWorkList = new List<StockHistoryWork>();
                    string retMsg = null;
                    bool msgDiv = false;//���b�Z�[�W�Ȃ��Ffalse

                    monthlyAddUpWork.EnterpriseCode = paramWork.EnterpriseCode;
                    // UPD 2017/05/10 �v�� FOR REDMINE#49285 �݌ɗ����f�[�^�쐬�����@�J�n���ɑO���������܂܂���Q�Ή� ---->>>>>
                    //monthlyAddUpWork.AddUpDateSt = TDateTime.LongDateToDateTime(paramWork.StAddUpADate).AddDays(-1);
                    monthlyAddUpWork.AddUpDateSt = TDateTime.LongDateToDateTime(paramWork.StAddUpADate);
                    // UPD 2017/05/10 �v�� FOR REDMINE#49285 �݌ɗ����f�[�^�쐬�����@�J�n���ɑO���������܂܂���Q�Ή� ----<<<<<
                    monthlyAddUpWork.AddUpDateEd = TDateTime.LongDateToDateTime(paramWork.EdAddUpADate);
                    monthlyAddUpWork.AddUpDate = TDateTime.LongDateToDateTime(paramWork.EdAddUpADate);
                    monthlyAddUpWork.LstMonAddUpProcDay = TDateTime.LongDateToDateTime(paramWork.EdAddUpYearMonth * 100 + 1);
                    monthlyAddUpWork.AddUpYearMonth = TDateTime.LongDateToDateTime(paramWork.EdAddUpYearMonth * 100 + 1);
                    // �C�� 2009/06/24 >>>
                    //monthlyAddUpWork.AddUpSecCode = sectionCode;
                    if ((sectionCode != "00") && (sectionCode != ""))
                    {
                        monthlyAddUpWork.AddUpSecCode = sectionCode;
                    }
                    // UPD 2021.11.10 >>>
                    // �C�� 2009/06/24 <<<
                    // -- UPD 2010/06/02 ------------------------------------------------>>>
                    //status = monthlyAddUpDB.MakeStockHistoryParameters(ref  monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection);
                    //status = monthlyAddUpDB.MakeStockHistoryNotGetCost(ref  monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection);
                    // -- UPD 2010/06/02 ------------------------------------------------<<<

                    // MAKAU00133R.MakeStockHistoryNotGetCost���R�s�[���݌ɔN�Ԏ��яƉ�p�̃��\�b�h�Ƃ��Ď����B
                    status = MakeStockHistoryPMZAI04100(ref  monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection, paramWork.WarehouseCode.Trim(), paramWork.GoodsNo.Trim(), paramWork.GoodsMakerCd);
                    // UPD 2021.11.10 <<<

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        for (int i = 0; i < stockHistoryWorkList.Count; i++)
                        {
                            // UPD 2021.11.10 >>>
                            // �{�����̓N�G����Where��ɂĎ��{���邽�ߕs�v�B
                            //if ((stockHistoryWorkList[i].WarehouseCode.Trim() == paramWork.WarehouseCode.Trim()) &&
                            //    (stockHistoryWorkList[i].GoodsMakerCd == paramWork.GoodsMakerCd) &&
                            //    (stockHistoryWorkList[i].GoodsNo.Trim() == paramWork.GoodsNo.Trim()))
                            //{
                            // UPD 2021.11.10 <<<
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            # region �N���X�֊i�[
                            ResultWork.EnterpriseCode = paramWork.EnterpriseCode.Trim();
                            ResultWork.SectionCode = stockHistoryWorkList[i].SectionCode.Trim();
                            ResultWork.AddUpYearMonth = TDateTime.LongDateToDateTime(paramWork.EdAddUpADate);
                            ResultWork.WarehouseCode = paramWork.WarehouseCode;
                            ResultWork.GoodsNo = paramWork.GoodsNo.Trim();
                            ResultWork.GoodsMakerCd = paramWork.GoodsMakerCd;

                            ResultWork.SalesTimes += stockHistoryWorkList[i].SalesTimes;
                            ResultWork.SalesCount += stockHistoryWorkList[i].SalesCount;
                            ResultWork.SalesMoneyTaxExc += stockHistoryWorkList[i].SalesMoneyTaxExc;
                            ResultWork.StockTimes += stockHistoryWorkList[i].StockTimes;
                            ResultWork.StockCount += stockHistoryWorkList[i].StockCount;
                            ResultWork.StockPriceTaxExc += stockHistoryWorkList[i].StockPriceTaxExc;
                            ResultWork.GrossProfit += stockHistoryWorkList[i].GrossProfit;
                            ResultWork.MoveArrivalCnt += stockHistoryWorkList[i].MoveArrivalCnt;
                            ResultWork.MoveArrivalPrice += stockHistoryWorkList[i].MoveArrivalPrice;
                            ResultWork.MoveShipmentCnt += stockHistoryWorkList[i].MoveShipmentCnt;
                            ResultWork.MoveShipmentPrice += stockHistoryWorkList[i].MoveShipmentPrice;
                            ResultWork.SearchDiv = 0;
                            // ------------------------------ ADD 2010/09/14 ------------------------------>>>>>
                            ResultWork.SalesCount += stockHistoryWorkList[i].SalesRetGoodsCnt;
                            ResultWork.SalesMoneyTaxExc += stockHistoryWorkList[i].SalesRetGoodsPrice;
                            ResultWork.StockCount += stockHistoryWorkList[i].StockRetGoodsCnt;
                            ResultWork.StockPriceTaxExc += stockHistoryWorkList[i].StockRetGoodsPrice;
                            // ------------------------------ ADD 2010/09/14 ------------------------------<<<<<
                            # endregion
                            // UPD 2021.11.10 >>>
                            // �{�����̓N�G����Where��ɂĎ��{���邽�ߕs�v�B
                            //}
                            // UPD 2021.11.10 <<<
                        }
                    }
                }
                al.Add(ResultWork);
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

            stockHistoryDspSearchResultWorkList = al;

            return status;
        }
        #endregion

        #region [SearchStockHisDspProc]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockHistoryDspSearchResultWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        /// <br>Update Note : 2010/09/13 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        private int SearchStockHisDspProc(ref ArrayList stockHistoryDspSearchResultWorkList, StockHistoryDspSearchParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            //ArrayList al = new ArrayList();

            string sqlText = string.Empty;

            try
            {
                // DEL 2009/06/24 >>>
                //foreach (string sectionCode in paramWork.SectionCodes)
                //{
                // DEL 2009/06/24 <<<
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [SELECT]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "	STOCKHIS.ENTERPRISECODE AS ENTERPRISECODE" + Environment.NewLine;
                sqlText += "	,STOCKHIS.ADDUPYEARMONTH AS ADDUPYEARMONTH" + Environment.NewLine;
                sqlText += "	,STOCKHIS.WAREHOUSECODE AS WAREHOUSECODE" + Environment.NewLine;
                sqlText += "	,STOCKHIS.SECTIONCODE AS SECTIONCODE" + Environment.NewLine;
                sqlText += "	,STOCKHIS.GOODSNO AS GOODSNO" + Environment.NewLine;
                sqlText += "	,STOCKHIS.GOODSMAKERCD AS GOODSMAKERCD" + Environment.NewLine;
                sqlText += "	,STOCKHIS.SALESTIMES AS SALESTIMES" + Environment.NewLine;
                sqlText += "	,STOCKHIS.SALESCOUNT AS SALESCOUNT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.SALESMONEYTAXEXC AS SALESMONEYTAXEXC" + Environment.NewLine;
                sqlText += "	,STOCKHIS.GROSSPROFIT AS GROSSPROFIT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.STOCKTIMES AS STOCKTIMES" + Environment.NewLine;
                sqlText += "	,STOCKHIS.STOCKCOUNT AS STOCKCOUNT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.STOCKPRICETAXEXC AS STOCKPRICETAXEXC" + Environment.NewLine;
                sqlText += "	,STOCKHIS.MOVEARRIVALCNT AS MOVEARRIVALCNT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.MOVEARRIVALPRICE AS MOVEARRIVALPRICE" + Environment.NewLine;
                sqlText += "	,STOCKHIS.MOVESHIPMENTCNT AS MOVESHIPMENTCNT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.MOVESHIPMENTPRICE AS MOVESHIPMENTPRICE" + Environment.NewLine;
                sqlText += "	,STOCK.STOCKSUPPLIERCODE AS STOCKSUPPLIERCODE" + Environment.NewLine;
                sqlText += "	,STOCK.STOCKCREATEDATE AS STOCKCREATEDATE" + Environment.NewLine;
                sqlText += "	,STOCK.LASTSALESDATE AS LASTSALESDATE" + Environment.NewLine;
                sqlText += "	,STOCK.LASTSTOCKDATE AS LASTSTOCKDATE" + Environment.NewLine;
                // ---------------------- ADD 2010/09/14 --------------------------------------------->>>>>
                sqlText += "	,STOCKHIS.SALESRETGOODSCNT AS SALESRETGOODSCNT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.SALESRETGOODSPRICE AS SALESRETGOODSPRICE" + Environment.NewLine;
                sqlText += "	,STOCKHIS.STOCKRETGOODSCNT AS STOCKRETGOODSCNT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.STOCKRETGOODSPRICE AS STOCKRETGOODSPRICE" + Environment.NewLine;
                // ---------------------- ADD 2010/09/14 ---------------------------------------------<<<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "(" + Environment.NewLine;
                sqlText += "	SELECT" + Environment.NewLine;
                sqlText += "		ENTERPRISECODERF AS ENTERPRISECODE" + Environment.NewLine;
                sqlText += "		,ADDUPYEARMONTHRF AS ADDUPYEARMONTH" + Environment.NewLine;
                sqlText += "		,WAREHOUSECODERF AS WAREHOUSECODE" + Environment.NewLine;
                sqlText += "		,SECTIONCODERF AS SECTIONCODE" + Environment.NewLine;
                sqlText += "		,GOODSNORF AS GOODSNO" + Environment.NewLine;
                sqlText += "		,GOODSMAKERCDRF AS GOODSMAKERCD" + Environment.NewLine;
                sqlText += "		,SALESTIMESRF AS SALESTIMES" + Environment.NewLine;
                sqlText += "		,SALESCOUNTRF AS SALESCOUNT" + Environment.NewLine;
                sqlText += "		,SALESMONEYTAXEXCRF AS SALESMONEYTAXEXC" + Environment.NewLine;
                sqlText += "		,GROSSPROFITRF AS GROSSPROFIT" + Environment.NewLine;
                sqlText += "		,STOCKTIMESRF AS STOCKTIMES" + Environment.NewLine;
                sqlText += "		,STOCKCOUNTRF AS STOCKCOUNT" + Environment.NewLine;
                sqlText += "		,STOCKPRICETAXEXCRF AS STOCKPRICETAXEXC" + Environment.NewLine;
                sqlText += "		,MOVEARRIVALCNTRF AS MOVEARRIVALCNT" + Environment.NewLine;
                sqlText += "		,MOVEARRIVALPRICERF AS MOVEARRIVALPRICE" + Environment.NewLine;
                sqlText += "		,MOVESHIPMENTCNTRF AS MOVESHIPMENTCNT" + Environment.NewLine;
                sqlText += "		,MOVESHIPMENTPRICERF AS MOVESHIPMENTPRICE" + Environment.NewLine;
                // ---------------------- ADD 2010/09/13 --------------------------------------------->>>>>
                sqlText += "		,SALESRETGOODSCNTRF AS SALESRETGOODSCNT" + Environment.NewLine;
                sqlText += "		,SALESRETGOODSPRICERF AS SALESRETGOODSPRICE" + Environment.NewLine;
                sqlText += "		,STOCKRETGOODSCNTRF AS STOCKRETGOODSCNT" + Environment.NewLine;
                sqlText += "		,STOCKRETGOODSPRICERF AS STOCKRETGOODSPRICE" + Environment.NewLine;
                // ---------------------- ADD 2010/09/13 ---------------------------------------------<<<<<
                sqlText += "	FROM" + Environment.NewLine;
                sqlText += "		STOCKHISTORYRF " + Environment.NewLine;
                sqlText += "	WHERE" + Environment.NewLine;
                sqlText += "		ENTERPRISECODERF     = @HISENTERPRISECODE" + Environment.NewLine;
                sqlText += "        AND LOGICALDELETECODERF=0 " + Environment.NewLine;
                sqlText += "		AND ADDUPYEARMONTHRF >= @STADDUPYEARMONTH" + Environment.NewLine;
                sqlText += "		AND ADDUPYEARMONTHRF <= @EDADDUPYEARMONTH" + Environment.NewLine;
                //sqlText += "		AND SECTIONCODERF = @SECTIONCODE" + Environment.NewLine; // DEL 2009/06/24 
                sqlText += ") AS STOCKHIS" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "(" + Environment.NewLine;
                sqlText += "	SELECT" + Environment.NewLine;
                sqlText += "		 ENTERPRISECODERF AS ENTERPRISECODE" + Environment.NewLine;
                sqlText += "		,SECTIONCODERF AS SECTIONCODE" + Environment.NewLine;
                sqlText += "		,WAREHOUSECODERF AS WAREHOUSECODE" + Environment.NewLine;
                sqlText += "		,GOODSMAKERCDRF AS GOODSMAKERCD" + Environment.NewLine;
                sqlText += "		,GOODSNORF AS GOODSNO" + Environment.NewLine;
                sqlText += "		,STOCKSUPPLIERCODERF AS STOCKSUPPLIERCODE" + Environment.NewLine;
                sqlText += "		,STOCKCREATEDATERF AS STOCKCREATEDATE" + Environment.NewLine;
                sqlText += "		,LASTSALESDATERF AS LASTSALESDATE" + Environment.NewLine;
                sqlText += "		,LASTSTOCKDATERF AS LASTSTOCKDATE" + Environment.NewLine;
                sqlText += "	FROM" + Environment.NewLine;
                sqlText += "		STOCKRF" + Environment.NewLine;
                sqlText += "	WHERE" + Environment.NewLine;
                sqlText += "		ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                sqlText += "        AND LOGICALDELETECODERF=0 " + Environment.NewLine;
                sqlText += "		AND WAREHOUSECODERF = @WAREHOUSECODE" + Environment.NewLine;
                sqlText += "		AND GOODSMAKERCDRF = @GOODSMAKERCD" + Environment.NewLine;
                sqlText += "		AND GOODSNORF = @GOODSNO" + Environment.NewLine;
                sqlText += ") AS STOCK" + Environment.NewLine;
                sqlText += "ON" + Environment.NewLine;
                sqlText += "	STOCKHIS.ENTERPRISECODE = STOCK.ENTERPRISECODE" + Environment.NewLine;
                //sqlText += "	AND STOCKHIS.SECTIONCODE = STOCK.SECTIONCODE" + Environment.NewLine; // DEL 2008.12.05
                sqlText += "	AND STOCKHIS.WAREHOUSECODE = STOCK.WAREHOUSECODE" + Environment.NewLine;
                sqlText += "	AND STOCKHIS.GOODSMAKERCD = STOCK.GOODSMAKERCD" + Environment.NewLine;
                sqlText += "	AND STOCKHIS.GOODSNO = STOCK.GOODSNO" + Environment.NewLine;
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "	STOCK.ENTERPRISECODE IS NOT null" + Environment.NewLine;
                sqlText += "ORDER BY " + Environment.NewLine;
                sqlText += "	ADDUPYEARMONTH ASC" + Environment.NewLine;
                #endregion

                sqlCommand.CommandText = sqlText;
                SqlParameter paraHisEnterpriseCode = sqlCommand.Parameters.Add("@HISENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                SqlParameter paraGoodsMakerCd = sqlCommand.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                SqlParameter paraWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                //SqlParameter paraSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar); // DEL 2009/06/24 

                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
                paraHisEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(paramWork.StAddUpYearMonth);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(paramWork.EdAddUpYearMonth);
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(paramWork.GoodsNo);
                paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(paramWork.GoodsMakerCd);
                paraWarehouseCode.Value = SqlDataMediator.SqlSetString(paramWork.WarehouseCode);
                //paraSectionCode.Value = SqlDataMediator.SqlSetString(sectionCode); // DEL 2009/06/24

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockHistoryDspSearchResultWorkList.Add(CopyToStockHisDspWorkFromReader(ref myReader, paramWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (!myReader.IsClosed) myReader.Close();
                //} // DEL 2009/06/24 
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

            //stockHistoryDspSearchResultWorkList = al;

            return status;
        }
        #endregion  //SearchStockHisDspProc     

        /// <summary>
        /// �N���X�i�[���� Reader �� StockHistoryDspSearchResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>StockHistoryDspSearchResultWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
        /// <br>Update Note : 2010/09/13 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private StockHistoryDspSearchResultWork CopyToStockHisDspWorkFromReader(ref SqlDataReader myReader, StockHistoryDspSearchParamWork paramWork)
        {
            StockHistoryDspSearchResultWork stockHistoryDspSearchResultWork = new StockHistoryDspSearchResultWork();

            if (myReader != null)
            {
                # region �N���X�֊i�[
                stockHistoryDspSearchResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODE"));
                stockHistoryDspSearchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODE"));
                stockHistoryDspSearchResultWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTH"));
                stockHistoryDspSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));
                stockHistoryDspSearchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNO"));
                stockHistoryDspSearchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD"));
                stockHistoryDspSearchResultWork.SalesTimes += SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES"));
                stockHistoryDspSearchResultWork.SalesCount += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNT"));
                // ------------------------------ ADD 2010/09/14 -------------------------------------------------------->>>>>
                stockHistoryDspSearchResultWork.SalesCount += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRETGOODSCNT"));
                stockHistoryDspSearchResultWork.SalesMoneyTaxExc += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICE"));
                stockHistoryDspSearchResultWork.StockCount += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRETGOODSCNT"));
                stockHistoryDspSearchResultWork.StockPriceTaxExc += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKRETGOODSPRICE"));
                // ------------------------------ ADD 2010/09/14 --------------------------------------------------------<<<<<
                stockHistoryDspSearchResultWork.SalesMoneyTaxExc += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXC"));
                stockHistoryDspSearchResultWork.StockTimes += SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKTIMES"));
                stockHistoryDspSearchResultWork.StockCount += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNT"));
                stockHistoryDspSearchResultWork.StockPriceTaxExc += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXC"));
                stockHistoryDspSearchResultWork.GrossProfit += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFIT"));
                stockHistoryDspSearchResultWork.MoveArrivalCnt += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVEARRIVALCNT"));
                stockHistoryDspSearchResultWork.MoveArrivalPrice += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVEARRIVALPRICE"));
                stockHistoryDspSearchResultWork.MoveShipmentCnt += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVESHIPMENTCNT"));
                stockHistoryDspSearchResultWork.MoveShipmentPrice += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVESHIPMENTPRICE"));
                stockHistoryDspSearchResultWork.SearchDiv = 1;
                # endregion
            }

            return stockHistoryDspSearchResultWork;
        }

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        #region [SearchAll]
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�
        /// </summary>
        /// <param name="StockHistoryDspSearchResultWork">��������</param>
        /// <param name="StockHistoryDspSearchParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/07/20</br>
        public int SearchAll(out object stockHistoryDspSearchResultWork, object StockHistoryDspSearchParamWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            stockHistoryDspSearchResultWork = null;
            try
            {
                //�R�l�N�V��������
                sqlConnection = CreateSqlConnection();
                if (sqlConnection == null) return status;
                sqlConnection.Open();
                return SearchStockHisDspAll(out stockHistoryDspSearchResultWork, StockHistoryDspSearchParamWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockHisDspDB.Search");
                stockHistoryDspSearchResultWork = new ArrayList();
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
        /// �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��S�Ė߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="objStockHistoryDspSearchResultWork">��������</param>
        /// <param name="objStockHistoryDspSearchParamWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2011/03/22 ������</br>
        /// <br>             �Ɖ�v���O�����̃��O�o�͑Ή�</br>
        private int SearchStockHisDspAll(out object objStockHistoryDspSearchResultWork, object objStockHistoryDspSearchParamWork, ref SqlConnection sqlConnection)
        {
            StockHistoryDspSearchParamWork paramWork = null;

            ArrayList paramWorkList = objStockHistoryDspSearchParamWork as ArrayList;

            if (paramWorkList == null)
            {
                paramWork = objStockHistoryDspSearchParamWork as StockHistoryDspSearchParamWork;
            }
            else
            {
                if (paramWorkList.Count > 0)
                    paramWork = paramWorkList[0] as StockHistoryDspSearchParamWork;
            }

            ArrayList stockHistoryDspSearchResultWork = null;

            // ---ADD 2011/03/22---------->>>>>
            OprtnHisLogDB oprtnHisLogDB = new OprtnHisLogDB();
            oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, paramWork.EnterpriseCode, "�݌ɔN�Ԏ��яƉ�", "���o�J�n");
            // ---ADD 2011/03/22----------<<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            // �݌Ɏ��яƉ�f�[�^���擾(����-�݌Ɏ󕥃f�[�^)
            status = SearchStockAcPayHistAllProc(out stockHistoryDspSearchResultWork, paramWork, ref sqlConnection);

            // �݌Ɏ��яƉ�f�[�^���擾(�ߋ�-�݌ɗ����f�[�^)
            status = SearchStockHisDspAllProc(ref stockHistoryDspSearchResultWork, paramWork, ref sqlConnection);

            // ---ADD 2011/03/22---------->>>>>
            oprtnHisLogDB.WriteOprtnHisLogForReference(ref sqlConnection, paramWork.EnterpriseCode, "�݌ɔN�Ԏ��яƉ�", "���o�I��");
            // ---ADD 2011/03/22----------<<<<<

            if (stockHistoryDspSearchResultWork.Count > 0) status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            objStockHistoryDspSearchResultWork = stockHistoryDspSearchResultWork;
            return status;

        }

        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockHistoryDspSearchResultWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note : 2010/09/13 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note : 2010/09/28 tianjw</br>
        /// <br>            �Eredmine#15612 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note : 2010/10/26 tianjw</br>
        /// <br>            �Eredmine#16275 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note: �v�� 2017/05/10</br>
        /// <br>             REDMINE#49285 �݌ɗ����f�[�^�쐬�����@�J�n���ɑO���������܂܂���Q�Ή�</br>
        /// <br>Update Note: �݌ɔN�Ԏ��яƉ�\����</br>
        /// <br>Programmer : ��ؑn</br>
        /// <br>Date       : 2021.11.10</br>
        private int SearchStockAcPayHistAllProc(out ArrayList stockHistoryDspSearchResultWorkList, StockHistoryDspSearchParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            ArrayList arrReturn = new ArrayList();
            //�݌ɗ����f�[�^List
            List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();
            List<StockHistoryWork> stockHistoryWorkFilterList = new List<StockHistoryWork>();
            MonthlyAddUpDB monthlyAddUpDB = new MonthlyAddUpDB();
            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();

            try
            {
                StockHistoryDspSearchResultWork ResultWork = null;

                stockHistoryWorkList = new List<StockHistoryWork>();
                string retMsg = null;
                bool msgDiv = false;//���b�Z�[�W�Ȃ��Ffalse

                monthlyAddUpWork.EnterpriseCode = paramWork.EnterpriseCode;
                // UPD 2017/05/10 �v�� FOR REDMINE#49285 �݌ɗ����f�[�^�쐬�����@�J�n���ɑO���������܂܂���Q�Ή� ---->>>>>
                //monthlyAddUpWork.AddUpDateSt = TDateTime.LongDateToDateTime(paramWork.StAddUpADate).AddDays(-1);
                monthlyAddUpWork.AddUpDateSt = TDateTime.LongDateToDateTime(paramWork.StAddUpADate);
                // UPD 2017/05/10 �v�� FOR REDMINE#49285 �݌ɗ����f�[�^�쐬�����@�J�n���ɑO���������܂܂���Q�Ή� ----<<<<<
                monthlyAddUpWork.AddUpDateEd = TDateTime.LongDateToDateTime(paramWork.EdAddUpADate);
                monthlyAddUpWork.AddUpDate = TDateTime.LongDateToDateTime(paramWork.EdAddUpADate);
                monthlyAddUpWork.LstMonAddUpProcDay = TDateTime.LongDateToDateTime(paramWork.EdAddUpYearMonth * 100 + 1);
                monthlyAddUpWork.AddUpYearMonth = TDateTime.LongDateToDateTime(paramWork.EdAddUpYearMonth * 100 + 1);

                // UPD 2021.11.10 >>>
                //status = monthlyAddUpDB.MakeStockHistoryNotGetCost(ref monthlyAddUpWork, 
                //            ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection);

                // MAKAU00133R.MakeStockHistoryNotGetCost���R�s�[���݌ɔN�Ԏ��яƉ�p�̃��\�b�h�Ƃ��Ď����B
                status = MakeStockHistoryPMZAI04100CsvAndExcel(
                              ref monthlyAddUpWork, ref stockHistoryWorkFilterList, out msgDiv, out retMsg, ref sqlConnection,
                              paramWork.WarehouseCodeList, paramWork.WarehouseShelfNoList, paramWork.MakerCodeList, paramWork.BlGoodsCodeList, paramWork.GoodsNoList);
                // UPD 2021.11.10 <<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // UPD 2021.11.10 >>>
                    // �{�����̓N�G����Where��ɂĎ��{���邽�ߕs�v�B
                    #region DEL
                    //List<string> warehouseCodeList = paramWork.WarehouseCodeList;
                    //List<Int32> makerCodeList = paramWork.MakerCodeList;
                    //List<string> goodsNoList = paramWork.GoodsNoList;
                    //List<int> blGoodsCodeList = paramWork.BlGoodsCodeList;// ADD 2010/09/21
                    //List<string> warehouseShelfNoList= paramWork.WarehouseShelfNoList;// ADD 2010/09/21
                    //for (int i = 0; i < stockHistoryWorkList.Count; i++)
                    //{

                    //    // -----------UPD 2010/09/21----------->>>>>
                    //    // ���o�Ώۂ͈͓̔��̔���
                    //    // ------------------------------ UPD 2010/09/19 --------------------------------------------------------------------------------------------------------->>>>>
                    //    // ---------- UPD 2010/09/28 ----------->>>>>
                    //    // �q��
                    //    bool warehouseState = false;
                    //    if (warehouseCodeList != null && warehouseCodeList.Count > 0 && !string.Empty.Equals(warehouseCodeList[0]) && !string.Empty.Equals(warehouseCodeList[1]))
                    //    {
                    //        warehouseState = stockHistoryWorkList[i].WarehouseCode.Trim().CompareTo(warehouseCodeList[0]) >= 0
                    //            //&& stockHistoryWorkList[i].WarehouseCode.Trim().CompareTo(warehouseCodeList[1]) <= 0;
                    //                && stockHistoryWorkList[i].WarehouseCode.Trim().CompareTo(warehouseCodeList[1]) <= 0
                    //            //&& !string.IsNullOrEmpty(stockHistoryWorkList[i].WarehouseName.Trim());
                    //        && !string.IsNullOrEmpty(stockHistoryWorkList[i].WarehouseName.Trim())
                    //        && !string.IsNullOrEmpty(stockHistoryWorkList[i].WareHouseCd.Trim());
                    //    }
                    //    else if (warehouseCodeList != null && warehouseCodeList.Count > 0 && string.Empty.Equals(warehouseCodeList[0]) && !string.Empty.Equals(warehouseCodeList[1]))
                    //    {
                    //        //warehouseState = stockHistoryWorkList[i].WarehouseCode.Trim().CompareTo(warehouseCodeList[1]) <= 0;
                    //        warehouseState = stockHistoryWorkList[i].WarehouseCode.Trim().CompareTo(warehouseCodeList[1]) <= 0
                    //            //&& !string.IsNullOrEmpty(stockHistoryWorkList[i].WarehouseName.Trim());
                    //        && !string.IsNullOrEmpty(stockHistoryWorkList[i].WarehouseName.Trim())
                    //        && !string.IsNullOrEmpty(stockHistoryWorkList[i].WareHouseCd.Trim());
                    //    }
                    //    else if (warehouseCodeList != null && warehouseCodeList.Count > 0 && !string.Empty.Equals(warehouseCodeList[0]) && string.Empty.Equals(warehouseCodeList[1]))
                    //    {
                    //        //warehouseState = stockHistoryWorkList[i].WarehouseCode.Trim().CompareTo(warehouseCodeList[0]) >= 0;
                    //        warehouseState = stockHistoryWorkList[i].WarehouseCode.Trim().CompareTo(warehouseCodeList[0]) >= 0
                    //            //&& !string.IsNullOrEmpty(stockHistoryWorkList[i].WarehouseName.Trim());
                    //        && !string.IsNullOrEmpty(stockHistoryWorkList[i].WarehouseName.Trim())
                    //        && !string.IsNullOrEmpty(stockHistoryWorkList[i].WareHouseCd.Trim());
                    //    }
                    //    else if (warehouseCodeList == null || warehouseCodeList.Count == 0)
                    //    {
                    //        //warehouseState = true;
                    //        //if (!string.IsNullOrEmpty(stockHistoryWorkList[i].WarehouseName.Trim()))
                    //        if (!string.IsNullOrEmpty(stockHistoryWorkList[i].WarehouseName.Trim()) && !string.IsNullOrEmpty(stockHistoryWorkList[i].WareHouseCd.Trim()))
                    //        {
                    //            warehouseState = true;
                    //        }
                    //    }
                    //    // ---------- UPD 2010/09/28 -----------<<<<<

                    //    // ���[�J�[
                    //    bool makerCodeState = false;
                    //    if (makerCodeList != null && makerCodeList.Count > 0 && makerCodeList[0] != 0 && makerCodeList[1] != 0)
                    //    {
                    //        makerCodeState = stockHistoryWorkList[i].GoodsMakerCd >= makerCodeList[0]
                    //                  //&& stockHistoryWorkList[i].GoodsMakerCd <= makerCodeList[1];
                    //                    && stockHistoryWorkList[i].GoodsMakerCd <= makerCodeList[1]
                    //                    && !string.IsNullOrEmpty(stockHistoryWorkList[i].MakerName.Trim());
                    //    }
                    //    else if (makerCodeList != null && makerCodeList.Count > 0 && makerCodeList[0] == 0 && makerCodeList[1] != 0)
                    //    {
                    //        //makerCodeState = stockHistoryWorkList[i].GoodsMakerCd <= makerCodeList[1];
                    //        makerCodeState = stockHistoryWorkList[i].GoodsMakerCd <= makerCodeList[1]
                    //            && !string.IsNullOrEmpty(stockHistoryWorkList[i].MakerName.Trim());
                    //    }
                    //    else if (makerCodeList != null && makerCodeList.Count > 0 && makerCodeList[0] != 0 && makerCodeList[1] == 0)
                    //    {
                    //        //makerCodeState = stockHistoryWorkList[i].GoodsMakerCd >= makerCodeList[0];
                    //        makerCodeState = stockHistoryWorkList[i].GoodsMakerCd >= makerCodeList[0]
                    //            && !string.IsNullOrEmpty(stockHistoryWorkList[i].MakerName.Trim());
                    //    }
                    //    else if (makerCodeList == null || makerCodeList.Count == 0)
                    //    {
                    //        //makerCodeState = true;
                    //        if (!string.IsNullOrEmpty(stockHistoryWorkList[i].MakerName.Trim()))
                    //        {
                    //            makerCodeState = true;
                    //        }
                            
                    //    }

                    //    //�@�i��
                    //    bool goodsNoListState = false;
                    //    if (goodsNoList != null && goodsNoList.Count > 0 && !string.Empty.Equals(goodsNoList[0]) && !string.Empty.Equals(goodsNoList[1]))
                    //    {
                    //        goodsNoListState = stockHistoryWorkList[i].GoodsNo.Trim().CompareTo(goodsNoList[0]) >= 0
                    //                   //&& stockHistoryWorkList[i].GoodsNo.Trim().CompareTo(goodsNoList[1]) <= 0;
                    //                   && stockHistoryWorkList[i].GoodsNo.Trim().CompareTo(goodsNoList[1]) <= 0
                    //                   && !string.IsNullOrEmpty( stockHistoryWorkList[i].GoodsName.Trim());
                    //    }
                    //    else if (goodsNoList != null && goodsNoList.Count > 0 && string.Empty.Equals(goodsNoList[0]) && !string.Empty.Equals(goodsNoList[1]))
                    //    {
                    //        //goodsNoListState = stockHistoryWorkList[i].GoodsNo.Trim().CompareTo(goodsNoList[1]) <= 0;
                    //        goodsNoListState = stockHistoryWorkList[i].GoodsNo.Trim().CompareTo(goodsNoList[1]) <= 0
                    //            && !string.IsNullOrEmpty(stockHistoryWorkList[i].GoodsName.Trim());
                    //    }
                    //    else if (goodsNoList != null && goodsNoList.Count > 0 && !string.Empty.Equals(goodsNoList[0]) && string.Empty.Equals(goodsNoList[1]))
                    //    {
                    //        //goodsNoListState = stockHistoryWorkList[i].GoodsNo.Trim().CompareTo(goodsNoList[0]) >= 0;
                    //        goodsNoListState = stockHistoryWorkList[i].GoodsNo.Trim().CompareTo(goodsNoList[0]) >= 0
                    //            && !string.IsNullOrEmpty(stockHistoryWorkList[i].GoodsName.Trim());
                    //    }
                    //    else if (goodsNoList == null || goodsNoList.Count == 0)
                    //    {
                    //        //goodsNoListState = true;
                    //        if (!string.IsNullOrEmpty(stockHistoryWorkList[i].GoodsName.Trim()))
                    //        {
                    //            goodsNoListState = true;
                    //        }
                    //    }

                    //    // BL�R�[�h
                    //    bool blGoodsCodeListState = false;
                    //    if (blGoodsCodeList != null && blGoodsCodeList.Count > 0 && blGoodsCodeList[0] != 0 && blGoodsCodeList[1] != 0)
                    //    {
                    //        // ----- UPD 2010/10/26 --------------------------------->>>>>
                    //        // ���i�}�X�^��BL�R�[�h���ݒ肳��Ă��Ȃ����i�A���i�}�X�^��BL�R�[�h�̊���l���u0�v
                    //        if (stockHistoryWorkList[i].BLGoodsCode == 0)
                    //        {
                    //            blGoodsCodeListState = true;
                    //        }
                    //        else
                    //        {
                    //            blGoodsCodeListState = stockHistoryWorkList[i].BLGoodsCode >= blGoodsCodeList[0]
                    //                    && stockHistoryWorkList[i].BLGoodsCode <= blGoodsCodeList[1]
                    //                    && !string.IsNullOrEmpty(stockHistoryWorkList[i].BLGoodsHalfName.Trim());
                    //        }
                    //        //blGoodsCodeListState = stockHistoryWorkList[i].BLGoodsCode >= blGoodsCodeList[0]
                    //        //            && stockHistoryWorkList[i].BLGoodsCode <= blGoodsCodeList[1]
                    //        //            && !string.IsNullOrEmpty(stockHistoryWorkList[i].BLGoodsHalfName.Trim());
                    //        // ----- UPD 2010/10/26 ---------------------------------<<<<<
                    //    }
                    //    else if (blGoodsCodeList != null && blGoodsCodeList.Count > 0 && blGoodsCodeList[0] == 0 && blGoodsCodeList[1] != 0)
                    //    {
                    //        // ----- UPD 2010/10/26 --------------------------------->>>>>
                    //        // ���i�}�X�^��BL�R�[�h���ݒ肳��Ă��Ȃ����i�A���i�}�X�^��BL�R�[�h�̊���l���u0�v
                    //        if (stockHistoryWorkList[i].BLGoodsCode == 0)
                    //        {
                    //            blGoodsCodeListState = true;
                    //        }
                    //        else
                    //        {
                    //            blGoodsCodeListState = stockHistoryWorkList[i].BLGoodsCode <= blGoodsCodeList[1]
                    //                    && !string.IsNullOrEmpty(stockHistoryWorkList[i].BLGoodsHalfName.Trim());
                    //        }
                    //        //blGoodsCodeListState = stockHistoryWorkList[i].BLGoodsCode <= blGoodsCodeList[1]
                    //        //    && !string.IsNullOrEmpty(stockHistoryWorkList[i].BLGoodsHalfName.Trim());
                    //        // ----- UPD 2010/10/26 ---------------------------------<<<<<
                    //    }
                    //    else if (blGoodsCodeList != null && blGoodsCodeList.Count > 0 && blGoodsCodeList[0] != 0 && blGoodsCodeList[1] == 0)
                    //    {
                    //        // ----- UPD 2010/10/26 --------------------------------->>>>>
                    //        // ���i�}�X�^��BL�R�[�h���ݒ肳��Ă��Ȃ����i�A���i�}�X�^��BL�R�[�h�̊���l���u0�v
                    //        if (stockHistoryWorkList[i].BLGoodsCode == 0)
                    //        {
                    //            blGoodsCodeListState = true;
                    //        }
                    //        else
                    //        {
                    //            blGoodsCodeListState = stockHistoryWorkList[i].BLGoodsCode >= blGoodsCodeList[0]
                    //                    && !string.IsNullOrEmpty(stockHistoryWorkList[i].BLGoodsHalfName.Trim());
                    //        }
                    //        //blGoodsCodeListState = stockHistoryWorkList[i].BLGoodsCode >= blGoodsCodeList[0]
                    //        //    && !string.IsNullOrEmpty(stockHistoryWorkList[i].BLGoodsHalfName.Trim());
                    //        // ----- UPD 2010/10/26 ---------------------------------<<<<<
                    //    }
                    //    else if (blGoodsCodeList == null || blGoodsCodeList.Count == 0)
                    //    {
                    //        // ----- UPD 2010/10/26 --------------------------------->>>>>
                    //        // ���i�}�X�^��BL�R�[�h���ݒ肳��Ă��Ȃ����i�A���i�}�X�^��BL�R�[�h�̊���l���u0�v
                    //        if (stockHistoryWorkList[i].BLGoodsCode == 0)
                    //        {
                    //            blGoodsCodeListState = true;
                    //        }
                    //        else
                    //        {
                    //            if (!string.IsNullOrEmpty(stockHistoryWorkList[i].BLGoodsHalfName.Trim()))
                    //            {
                    //                blGoodsCodeListState = true;
                    //            }
                    //            else
                    //            {
                    //                // �Ȃ�
                    //            }
                    //        }
                    //        //if (!string.IsNullOrEmpty(stockHistoryWorkList[i].BLGoodsHalfName.Trim()))
                    //        //{
                    //        //    blGoodsCodeListState = true;
                    //        //}
                    //        // ----- UPD 2010/10/26 ---------------------------------<<<<<
                    //    }
                        
                    //    // �I��
                    //    bool warehouseShelfNoListStatus = false;
                    //    if (warehouseShelfNoList != null && warehouseShelfNoList.Count > 0 && !string.Empty.Equals(warehouseShelfNoList[0]) && !string.Empty.Equals(warehouseShelfNoList[1]))
                    //    {
                    //        warehouseShelfNoListStatus = stockHistoryWorkList[i].WarehouseShelfNo.Trim().CompareTo(warehouseShelfNoList[0]) >= 0
                    //                   && stockHistoryWorkList[i].WarehouseShelfNo.Trim().CompareTo(warehouseShelfNoList[1]) <= 0;
                    //    }
                    //    else if (warehouseShelfNoList != null && warehouseShelfNoList.Count > 0 && string.Empty.Equals(warehouseShelfNoList[0]) && !string.Empty.Equals(warehouseShelfNoList[1]))
                    //    {
                    //        warehouseShelfNoListStatus = stockHistoryWorkList[i].WarehouseShelfNo.Trim().CompareTo(warehouseShelfNoList[1]) <= 0;
                    //    }
                    //    else if (warehouseShelfNoList != null && warehouseShelfNoList.Count > 0 && !string.Empty.Equals(warehouseShelfNoList[0]) && string.Empty.Equals(warehouseShelfNoList[1]))
                    //    {
                    //        warehouseShelfNoListStatus = stockHistoryWorkList[i].WarehouseShelfNo.Trim().CompareTo(warehouseShelfNoList[0]) >= 0;
                    //    }
                    //    else if (warehouseShelfNoList == null || warehouseShelfNoList.Count == 0)
                    //    {
                    //        warehouseShelfNoListStatus = true;
                    //    }
                    //    //if (warehouseState && makerCodeState && goodsNoListState)
                    //    //if (((warehouseCodeList != null && warehouseCodeList.Count > 0
                    //    //    && stockHistoryWorkList[i].WarehouseCode.Trim().CompareTo(warehouseCodeList[0]) >= 0
                    //    //    && stockHistoryWorkList[i].WarehouseCode.Trim().CompareTo(warehouseCodeList[1]) <= 0) || (warehouseCodeList == null || warehouseCodeList.Count == 0))
                    //    //    && ((makerCodeList != null && makerCodeList.Count > 0
                    //    //    && stockHistoryWorkList[i].GoodsMakerCd >= makerCodeList[0]
                    //    //    && stockHistoryWorkList[i].GoodsMakerCd <= makerCodeList[1]) || (makerCodeList == null || makerCodeList.Count == 0))
                    //    //    && ((goodsNoList != null && goodsNoList.Count > 0
                    //    //    && stockHistoryWorkList[i].GoodsNo.Trim().CompareTo(goodsNoList[0]) >= 0
                    //    //    && stockHistoryWorkList[i].GoodsNo.Trim().CompareTo(goodsNoList[1]) <= 0) || (goodsNoList == null || goodsNoList.Count == 0)))
                    //    // ------------------------------ UPD 2010/09/19 ---------------------------------------------------------------------------------------------------------<<<<<
                    //    if (warehouseState && makerCodeState && goodsNoListState && blGoodsCodeListState && warehouseShelfNoListStatus)
                    //    {
                    //        stockHistoryWorkFilterList.Add(stockHistoryWorkList[i]);
                    //    }

                    //    // -----------UPD 2010/09/21----------->>>>>

                    //}
                    #endregion
                    // UPD 2021.11.10 <<<

                    StockHistoryDspSearchResultWork tempSaveResultWork;
                    bool _isExist = false;

                    for (int i = 0; i < stockHistoryWorkFilterList.Count; i++)
                    {
                        _isExist = false;

                        for (int j = 0; j < arrReturn.Count; j++)
                        {
                            tempSaveResultWork = (StockHistoryDspSearchResultWork)arrReturn[j];

                            // �L�[�������ȏꍇ�A
                            if ((stockHistoryWorkFilterList[i].WarehouseCode.Trim() == tempSaveResultWork.WarehouseCode.Trim()) &&
                                (stockHistoryWorkFilterList[i].GoodsMakerCd == tempSaveResultWork.GoodsMakerCd) &&
                                (stockHistoryWorkFilterList[i].GoodsNo.Trim() == tempSaveResultWork.GoodsNo.Trim()))
                            {
                                tempSaveResultWork.SalesTimes += stockHistoryWorkFilterList[i].SalesTimes;
                                tempSaveResultWork.SalesCount += stockHistoryWorkFilterList[i].SalesCount;
                                tempSaveResultWork.SalesMoneyTaxExc += stockHistoryWorkFilterList[i].SalesMoneyTaxExc;
                                tempSaveResultWork.StockTimes += stockHistoryWorkFilterList[i].StockTimes;
                                tempSaveResultWork.StockCount += stockHistoryWorkFilterList[i].StockCount;
                                tempSaveResultWork.StockPriceTaxExc += stockHistoryWorkFilterList[i].StockPriceTaxExc;
                                tempSaveResultWork.GrossProfit += stockHistoryWorkFilterList[i].GrossProfit;
                                tempSaveResultWork.MoveArrivalCnt += stockHistoryWorkFilterList[i].MoveArrivalCnt;
                                tempSaveResultWork.MoveArrivalPrice += stockHistoryWorkFilterList[i].MoveArrivalPrice;
                                tempSaveResultWork.MoveShipmentCnt += stockHistoryWorkFilterList[i].MoveShipmentCnt;
                                tempSaveResultWork.MoveShipmentPrice += stockHistoryWorkFilterList[i].MoveShipmentPrice;
                                // ------------------------------ ADD 2010/09/13 ------------------------------>>>>>
                                tempSaveResultWork.SalesCount += stockHistoryWorkFilterList[i].SalesRetGoodsCnt;
                                tempSaveResultWork.SalesMoneyTaxExc += stockHistoryWorkFilterList[i].SalesRetGoodsPrice;
                                tempSaveResultWork.StockCount += stockHistoryWorkFilterList[i].StockRetGoodsCnt;
                                tempSaveResultWork.StockPriceTaxExc += stockHistoryWorkFilterList[i].StockRetGoodsPrice;
                                // ------------------------------ ADD 2010/09/13 ------------------------------<<<<<

                                _isExist = true;
                            }
                        }

                        // �L�[�����݂��Ȃ��ꍇ�A
                        if (!_isExist)
                        {
                            ResultWork = new StockHistoryDspSearchResultWork();

                            ResultWork.EnterpriseCode = paramWork.EnterpriseCode.Trim();
                            ResultWork.SectionCode = stockHistoryWorkFilterList[i].SectionCode.Trim();
                            ResultWork.AddUpYearMonth = TDateTime.LongDateToDateTime(paramWork.EdAddUpADate);
                            ResultWork.WarehouseCode = stockHistoryWorkFilterList[i].WarehouseCode;
                            ResultWork.GoodsNo = stockHistoryWorkFilterList[i].GoodsNo.Trim();
                            ResultWork.GoodsName = stockHistoryWorkFilterList[i].GoodsName.Trim();
                            ResultWork.GoodsMakerCd = stockHistoryWorkFilterList[i].GoodsMakerCd;
                            ResultWork.SalesTimes = stockHistoryWorkFilterList[i].SalesTimes;
                            ResultWork.SalesCount = stockHistoryWorkFilterList[i].SalesCount;
                            ResultWork.SalesMoneyTaxExc = stockHistoryWorkFilterList[i].SalesMoneyTaxExc;
                            ResultWork.StockTimes = stockHistoryWorkFilterList[i].StockTimes;
                            ResultWork.StockCount = stockHistoryWorkFilterList[i].StockCount;
                            ResultWork.StockPriceTaxExc = stockHistoryWorkFilterList[i].StockPriceTaxExc;
                            ResultWork.GrossProfit = stockHistoryWorkFilterList[i].GrossProfit;
                            ResultWork.MoveArrivalCnt = stockHistoryWorkFilterList[i].MoveArrivalCnt;
                            ResultWork.MoveArrivalPrice = stockHistoryWorkFilterList[i].MoveArrivalPrice;
                            ResultWork.MoveShipmentCnt = stockHistoryWorkFilterList[i].MoveShipmentCnt;
                            ResultWork.MoveShipmentPrice = stockHistoryWorkFilterList[i].MoveShipmentPrice;
                            // --- UPD 2010/09/17 ------------------------------>>>>>
                            //ResultWork.WarehouseShelfNo = string.Empty;
                            //ResultWork.BlGoodsCode = 0;
                            ResultWork.WarehouseShelfNo = stockHistoryWorkFilterList[i].WarehouseShelfNo;
                            ResultWork.BlGoodsCode = stockHistoryWorkFilterList[i].BLGoodsCode;
                            ResultWork.StockCreateDate = stockHistoryWorkFilterList[i].StockCreateDate;
                            ResultWork.LastSalesDate = stockHistoryWorkFilterList[i].LastSalesDate;
                            ResultWork.LastStockDate = stockHistoryWorkFilterList[i].LastStockDate;
                            // --- UPD 2010/09/17 ------------------------------<<<<<
                            ResultWork.SearchDiv = 0;
                            // ------------------------------ ADD 2010/09/13 ------------------------------>>>>>
                            ResultWork.SalesCount += stockHistoryWorkFilterList[i].SalesRetGoodsCnt;
                            ResultWork.SalesMoneyTaxExc += stockHistoryWorkFilterList[i].SalesRetGoodsPrice;
                            ResultWork.StockCount += stockHistoryWorkFilterList[i].StockRetGoodsCnt;
                            ResultWork.StockPriceTaxExc += stockHistoryWorkFilterList[i].StockRetGoodsPrice;
                            // ------------------------------ ADD 2010/09/13 ------------------------------<<<<<
                            arrReturn.Add(ResultWork);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {

            }

            stockHistoryDspSearchResultWorkList = arrReturn;

            return status;
        }
        
        /// <summary>
        /// �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="stockHistoryDspSearchResultWorkList">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̍݌Ɏ��яƉ�f�[�^��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note: 2010/08/12 chenyd</br>
        /// <br>            �E��QID:13055 �e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note : 2010/09/13 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note : 2010/09/21 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        /// <br>Update Note : 2010/10/26 tianjw</br>
        /// <br>            �E��QID:#16275�e�L�X�g�o�͑Ή�</br>
        private int SearchStockHisDspAllProc(ref ArrayList stockHistoryDspSearchResultWorkList, StockHistoryDspSearchParamWork paramWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;

            List<string> warehouseCodeList = paramWork.WarehouseCodeList;
            List<Int32> makerCodeList = paramWork.MakerCodeList;
            List<string> goodsNoList = paramWork.GoodsNoList;
            List<string> warehouseShelfNoList = paramWork.WarehouseShelfNoList;
            List<Int32> blGoodsCodeList = paramWork.BlGoodsCodeList;

            string sqlText = string.Empty;

            try
            {
                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                #region [SELECT]
                sqlText += "SELECT" + Environment.NewLine;
                sqlText += "	STOCKHIS.ENTERPRISECODE AS ENTERPRISECODE" + Environment.NewLine;
                sqlText += "	,STOCKHIS.ADDUPYEARMONTH AS ADDUPYEARMONTH" + Environment.NewLine;
                sqlText += "	,STOCKHIS.WAREHOUSECODE AS WAREHOUSECODE" + Environment.NewLine;
                sqlText += "	,STOCKHIS.SECTIONCODE AS SECTIONCODE" + Environment.NewLine;
                sqlText += "	,STOCKHIS.GOODSNO AS GOODSNO" + Environment.NewLine;
                sqlText += "	,STOCKHIS.GOODSNAME AS GOODSNAME" + Environment.NewLine;
                sqlText += "	,STOCKHIS.GOODSMAKERCD AS GOODSMAKERCD" + Environment.NewLine;
                sqlText += "	,STOCKHIS.SALESTIMES AS SALESTIMES" + Environment.NewLine;
                sqlText += "	,STOCKHIS.SALESCOUNT AS SALESCOUNT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.SALESMONEYTAXEXC AS SALESMONEYTAXEXC" + Environment.NewLine;
                sqlText += "	,STOCKHIS.GROSSPROFIT AS GROSSPROFIT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.STOCKTIMES AS STOCKTIMES" + Environment.NewLine;
                sqlText += "	,STOCKHIS.STOCKCOUNT AS STOCKCOUNT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.STOCKPRICETAXEXC AS STOCKPRICETAXEXC" + Environment.NewLine;
                sqlText += "	,STOCKHIS.MOVEARRIVALCNT AS MOVEARRIVALCNT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.MOVEARRIVALPRICE AS MOVEARRIVALPRICE" + Environment.NewLine;
                sqlText += "	,STOCKHIS.MOVESHIPMENTCNT AS MOVESHIPMENTCNT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.MOVESHIPMENTPRICE AS MOVESHIPMENTPRICE" + Environment.NewLine;
                sqlText += "	,STOCK.STOCKSUPPLIERCODE AS STOCKSUPPLIERCODE" + Environment.NewLine;
                sqlText += "	,STOCK.STOCKCREATEDATE AS STOCKCREATEDATE" + Environment.NewLine;
                sqlText += "	,STOCK.LASTSALESDATE AS LASTSALESDATE" + Environment.NewLine;
                sqlText += "	,STOCK.LASTSTOCKDATE AS LASTSTOCKDATE" + Environment.NewLine;
                sqlText += "	,STOCK.WAREHOUSESHELFNO AS WAREHOUSESHELFNO" + Environment.NewLine;
                sqlText += "	,GOODSURF.BLGOODSCODERF AS BLGOODSCODE" + Environment.NewLine;
                // ---------------------- ADD 2010/09/14 --------------------------------------->>>>>
                sqlText += "	,STOCKHIS.SALESRETGOODSCNT AS SALESRETGOODSCNT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.SALESRETGOODSPRICE AS SALESRETGOODSPRICE" + Environment.NewLine;
                sqlText += "	,STOCKHIS.STOCKRETGOODSCNT AS STOCKRETGOODSCNT" + Environment.NewLine;
                sqlText += "	,STOCKHIS.STOCKRETGOODSPRICE AS STOCKRETGOODSPRICE" + Environment.NewLine;
                // ---------------------- ADD 2010/09/14 ---------------------------------------<<<<<
                sqlText += "FROM" + Environment.NewLine;
                sqlText += "(" + Environment.NewLine;
                sqlText += "	SELECT" + Environment.NewLine;
                sqlText += "		ENTERPRISECODERF AS ENTERPRISECODE" + Environment.NewLine;
                sqlText += "		,ADDUPYEARMONTHRF AS ADDUPYEARMONTH" + Environment.NewLine;
                sqlText += "		,WAREHOUSECODERF AS WAREHOUSECODE" + Environment.NewLine;
                sqlText += "		,SECTIONCODERF AS SECTIONCODE" + Environment.NewLine;
                sqlText += "		,GOODSNORF AS GOODSNO" + Environment.NewLine;
                sqlText += "		,GOODSNAMERF AS GOODSNAME" + Environment.NewLine;
                sqlText += "		,GOODSMAKERCDRF AS GOODSMAKERCD" + Environment.NewLine;
                sqlText += "		,SALESTIMESRF AS SALESTIMES" + Environment.NewLine;
                sqlText += "		,SALESCOUNTRF AS SALESCOUNT" + Environment.NewLine;
                sqlText += "		,SALESMONEYTAXEXCRF AS SALESMONEYTAXEXC" + Environment.NewLine;
                sqlText += "		,GROSSPROFITRF AS GROSSPROFIT" + Environment.NewLine;
                sqlText += "		,STOCKTIMESRF AS STOCKTIMES" + Environment.NewLine;
                sqlText += "		,STOCKCOUNTRF AS STOCKCOUNT" + Environment.NewLine;
                sqlText += "		,STOCKPRICETAXEXCRF AS STOCKPRICETAXEXC" + Environment.NewLine;
                sqlText += "		,MOVEARRIVALCNTRF AS MOVEARRIVALCNT" + Environment.NewLine;
                sqlText += "		,MOVEARRIVALPRICERF AS MOVEARRIVALPRICE" + Environment.NewLine;
                sqlText += "		,MOVESHIPMENTCNTRF AS MOVESHIPMENTCNT" + Environment.NewLine;
                sqlText += "		,MOVESHIPMENTPRICERF AS MOVESHIPMENTPRICE" + Environment.NewLine;
                // ---------------------- ADD 2010/09/14 --------------------------------------->>>>>
                sqlText += "		,SALESRETGOODSCNTRF AS SALESRETGOODSCNT" + Environment.NewLine;
                sqlText += "		,SALESRETGOODSPRICERF AS SALESRETGOODSPRICE" + Environment.NewLine;
                sqlText += "		,STOCKRETGOODSCNTRF AS STOCKRETGOODSCNT" + Environment.NewLine;
                sqlText += "		,STOCKRETGOODSPRICERF AS STOCKRETGOODSPRICE" + Environment.NewLine;
                // ---------------------- ADD 2010/09/14 ---------------------------------------<<<<<
                sqlText += "	FROM" + Environment.NewLine;
                sqlText += "		STOCKHISTORYRF " + Environment.NewLine;
                sqlText += "	WHERE" + Environment.NewLine;
                sqlText += "		ENTERPRISECODERF     = @HISENTERPRISECODE" + Environment.NewLine;
                sqlText += "        AND LOGICALDELETECODERF=0 " + Environment.NewLine;
                sqlText += "		AND ADDUPYEARMONTHRF >= @STADDUPYEARMONTH" + Environment.NewLine;
                sqlText += "		AND ADDUPYEARMONTHRF <= @EDADDUPYEARMONTH" + Environment.NewLine;
                sqlText += ") AS STOCKHIS" + Environment.NewLine;
                sqlText += "LEFT JOIN" + Environment.NewLine;
                sqlText += "(" + Environment.NewLine;
                sqlText += "	SELECT" + Environment.NewLine;
                sqlText += "		 ENTERPRISECODERF AS ENTERPRISECODE" + Environment.NewLine;
                sqlText += "		,SECTIONCODERF AS SECTIONCODE" + Environment.NewLine;
                sqlText += "		,WAREHOUSECODERF AS WAREHOUSECODE" + Environment.NewLine;
                sqlText += "		,WAREHOUSESHELFNORF AS WAREHOUSESHELFNO" + Environment.NewLine;
                sqlText += "		,GOODSMAKERCDRF AS GOODSMAKERCD" + Environment.NewLine;
                sqlText += "		,GOODSNORF AS GOODSNO" + Environment.NewLine;
                sqlText += "		,STOCKSUPPLIERCODERF AS STOCKSUPPLIERCODE" + Environment.NewLine;
                sqlText += "		,STOCKCREATEDATERF AS STOCKCREATEDATE" + Environment.NewLine;
                sqlText += "		,LASTSALESDATERF AS LASTSALESDATE" + Environment.NewLine;
                sqlText += "		,LASTSTOCKDATERF AS LASTSTOCKDATE" + Environment.NewLine;
                sqlText += "	FROM" + Environment.NewLine;
                sqlText += "		STOCKRF" + Environment.NewLine;
                sqlText += "	WHERE" + Environment.NewLine;
                sqlText += "		ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                sqlText += "        AND LOGICALDELETECODERF=0 " + Environment.NewLine;
                if (warehouseCodeList != null && warehouseCodeList.Count > 0)
                {
                    // -------- UPD 2010/09/19 ---------------------------->>>>>
                    if (warehouseCodeList[0] == string.Empty && warehouseCodeList[1] != string.Empty)
                    {
                        sqlText += "		AND WAREHOUSECODERF <= @WAREHOUSECODEED" + Environment.NewLine;
                    }
                    else if (warehouseCodeList[0] != string.Empty && warehouseCodeList[1] == string.Empty)
                    {
                        sqlText += "		AND WAREHOUSECODERF >= @WAREHOUSECODEST" + Environment.NewLine;
                    }
                    else
                    {
                        sqlText += "		AND WAREHOUSECODERF >= @WAREHOUSECODEST" + Environment.NewLine;
                        sqlText += "		AND WAREHOUSECODERF <= @WAREHOUSECODEED" + Environment.NewLine;
                    }
                    //sqlText += "		AND WAREHOUSECODERF >= @WAREHOUSECODEST" + Environment.NewLine;
                    //sqlText += "		AND WAREHOUSECODERF <= @WAREHOUSECODEED" + Environment.NewLine;
                    // -------- UPD 2010/09/19 ----------------------------<<<<<
                }
                sqlText += "		AND WAREHOUSECODERF IN (SELECT DISTINCT WAREHOUSECODERF FROM WAREHOUSERF WHERE ENTERPRISECODERF = @ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine;// ADD 2010/09/19
                if (makerCodeList != null && makerCodeList.Count > 0)
                {
                    // -------- UPD 2010/09/19 ---------------------------->>>>>
                    if (makerCodeList[0] == 0 && makerCodeList[1] != 0)
                    {
                        sqlText += "		AND GOODSMAKERCDRF <= @GOODSMAKERCDED" + Environment.NewLine;
                    }
                    else if (makerCodeList[0] != 0 && makerCodeList[1] == 0)
                    {
                        sqlText += "		AND GOODSMAKERCDRF >= @GOODSMAKERCDST" + Environment.NewLine;
                    }
                    else
                    {
                        sqlText += "		AND GOODSMAKERCDRF >= @GOODSMAKERCDST" + Environment.NewLine;
                        sqlText += "		AND GOODSMAKERCDRF <= @GOODSMAKERCDED" + Environment.NewLine;
                    }
                    //sqlText += "		AND GOODSMAKERCDRF >= @GOODSMAKERCDST" + Environment.NewLine;
                    //sqlText += "		AND GOODSMAKERCDRF <= @GOODSMAKERCDED" + Environment.NewLine;
                    // -------- UPD 2010/09/19 ----------------------------<<<<<
                }
                sqlText += "		AND GOODSMAKERCDRF IN (SELECT DISTINCT GOODSMAKERCDRF FROM MAKERURF WHERE ENTERPRISECODERF = @ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine;// ADD 2010/09/19

                if (goodsNoList != null && goodsNoList.Count > 0)
                {
                    // -------- UPD 2010/09/19 ---------------------------->>>>>
                    if (goodsNoList[0] == string.Empty && goodsNoList[1] != string.Empty)
                    {
                        sqlText += "		AND GOODSNORF <= @GOODSNOED" + Environment.NewLine;
                    }
                    else if (goodsNoList[0] != string.Empty && goodsNoList[1] == string.Empty)
                    {
                        sqlText += "		AND GOODSNORF >= @GOODSNOST" + Environment.NewLine;
                    }
                    else
                    {
                        sqlText += "		AND GOODSNORF >= @GOODSNOST" + Environment.NewLine;
                        sqlText += "		AND GOODSNORF <= @GOODSNOED" + Environment.NewLine;
                    }
                    //sqlText += "		AND GOODSNORF >= @GOODSNOST" + Environment.NewLine;
                    //sqlText += "		AND GOODSNORF <= @GOODSNOED" + Environment.NewLine;
                    // -------- UPD 2010/09/19 ----------------------------<<<<<
                }
                sqlText += "		AND GOODSNORF IN (SELECT DISTINCT GOODSNORF FROM GOODSURF WHERE ENTERPRISECODERF = @ENTERPRISECODE AND LOGICALDELETECODERF = 0)" + Environment.NewLine;// ADD 2010/09/19

                if (warehouseShelfNoList != null && warehouseShelfNoList.Count > 0)
                {
                    // -------- UPD 2010/09/19 ---------------------------->>>>>
                    if (warehouseShelfNoList[0] == string.Empty && warehouseShelfNoList[1] != string.Empty)
                    {
                        sqlText += "		AND WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOED" + Environment.NewLine;
                    }
                    else if (warehouseShelfNoList[0] != string.Empty && warehouseShelfNoList[1] == string.Empty)
                    {
                        sqlText += "		AND WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOST" + Environment.NewLine;
                    }
                    else
                    {
                        sqlText += "		AND WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOST" + Environment.NewLine;
                        sqlText += "		AND WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOED" + Environment.NewLine;
                    }
                    //sqlText += "		AND WAREHOUSESHELFNORF >= @WAREHOUSESHELFNOST" + Environment.NewLine;
                    //sqlText += "		AND WAREHOUSESHELFNORF <= @WAREHOUSESHELFNOED" + Environment.NewLine;
                    // -------- UPD 2010/09/19 ----------------------------<<<<<
                }
                sqlText += ") AS STOCK" + Environment.NewLine;
                sqlText += "ON" + Environment.NewLine;
                sqlText += "	STOCKHIS.ENTERPRISECODE = STOCK.ENTERPRISECODE" + Environment.NewLine;
                sqlText += "	AND STOCKHIS.WAREHOUSECODE = STOCK.WAREHOUSECODE" + Environment.NewLine;
                sqlText += "	AND STOCKHIS.GOODSMAKERCD = STOCK.GOODSMAKERCD" + Environment.NewLine;
                sqlText += "	AND STOCKHIS.GOODSNO = STOCK.GOODSNO " + Environment.NewLine;
                //sqlText += "LEFT JOIN GOODSURF" + Environment.NewLine; // DEL 2010/08/12 ��QID:13055�Ή�
                sqlText += " JOIN GOODSURF" + Environment.NewLine;// ADD 2010/08/12 ��QID:13055�Ή�
                sqlText += "ON" + Environment.NewLine;
                sqlText += "	STOCKHIS.GOODSMAKERCD = GOODSURF.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "	AND STOCKHIS.GOODSNO = GOODSURF.GOODSNORF " + Environment.NewLine;
                sqlText += "	AND STOCKHIS.ENTERPRISECODE =  GOODSURF.ENTERPRISECODERF" + Environment.NewLine;// ADD 2010/08/12 ��QID:13055�Ή�
                sqlText += "	AND GOODSURF.LOGICALDELETECODERF=0  " + Environment.NewLine; // ADD 2010/08/12 ��QID:13055�Ή�
                // ----- UPD 2010/10/26 ----------------->>>>>
                //sqlText += "	AND GOODSURF.BLGOODSCODERF IN (SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE ENTERPRISECODERF = @ENTERPRISECODE AND LOGICALDELETECODERF = 0) " + Environment.NewLine; // ADD 2010/09/21
                sqlText += "	AND (GOODSURF.BLGOODSCODERF IN (SELECT BLGOODSCODERF FROM BLGOODSCDURF WHERE ENTERPRISECODERF = @ENTERPRISECODE AND LOGICALDELETECODERF = 0) " + Environment.NewLine;
                sqlText += "	OR GOODSURF.BLGOODSCODERF  = 0 )" + Environment.NewLine; // ���i�}�X�^��BL�R�[�h���ݒ肳��Ă��Ȃ����i�A���i�}�X�^��BL�R�[�h�̊���l���u0�v
                // ----- UPD 2010/10/26 -----------------<<<<<
                if (blGoodsCodeList != null && blGoodsCodeList.Count > 0)
                {
                    // -------- UPD 2010/09/19 ---------------------------->>>>>
                    if (blGoodsCodeList[0] == 0 && blGoodsCodeList[1] != 0)
                    {
                        sqlText += "	AND GOODSURF.BLGOODSCODERF <= @BLGOODSCODEED" + Environment.NewLine;
                    }
                    else if (blGoodsCodeList[0] != 0 && blGoodsCodeList[1] == 0)
                    {
                        sqlText += "	AND GOODSURF.BLGOODSCODERF >= @BLGOODSCODEST" + Environment.NewLine;
                    }
                    else
                    {
                        sqlText += "	AND GOODSURF.BLGOODSCODERF >= @BLGOODSCODEST" + Environment.NewLine;
                        sqlText += "	AND GOODSURF.BLGOODSCODERF <= @BLGOODSCODEED" + Environment.NewLine;
                    }
                    //sqlText += "	AND GOODSURF.BLGOODSCODERF >= @BLGOODSCODEST" + Environment.NewLine;
                    //sqlText += "	AND GOODSURF.BLGOODSCODERF <= @BLGOODSCODEED" + Environment.NewLine;
                    // -------- UPD 2010/09/19 ----------------------------<<<<<
                }
                sqlText += "WHERE" + Environment.NewLine;
                sqlText += "	STOCK.ENTERPRISECODE IS NOT NULL" + Environment.NewLine;
                sqlText += "ORDER BY " + Environment.NewLine;
                sqlText += "	WAREHOUSECODE ASC, GOODSNO ASC, GOODSMAKERCD ASC," + Environment.NewLine;
                sqlText += "	WAREHOUSESHELFNO ASC, BLGOODSCODERF ASC, ADDUPYEARMONTH ASC" + Environment.NewLine;
                #endregion

                sqlCommand.CommandText = sqlText;
                SqlParameter paraHisEnterpriseCode = sqlCommand.Parameters.Add("@HISENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
                SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
                paraHisEnterpriseCode.Value = SqlDataMediator.SqlSetString(paramWork.EnterpriseCode);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(paramWork.StAddUpYearMonth);
                paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(paramWork.EdAddUpYearMonth);
                if (warehouseCodeList != null && warehouseCodeList.Count > 0)
                {
                    // -------- UPD 2010/09/19 ---------------------------->>>>>
                    if (warehouseCodeList[0] == string.Empty && warehouseCodeList[1] != string.Empty)
                    {
                        SqlParameter paraWarehouseCodeEd = sqlCommand.Parameters.Add("@WAREHOUSECODEED", SqlDbType.NChar);
                        paraWarehouseCodeEd.Value = SqlDataMediator.SqlSetString(warehouseCodeList[1]);
                    }
                    else if (warehouseCodeList[0] != string.Empty && warehouseCodeList[1] == string.Empty)
                    {
                        SqlParameter paraWarehouseCodeSt = sqlCommand.Parameters.Add("@WAREHOUSECODEST", SqlDbType.NChar);
                        paraWarehouseCodeSt.Value = SqlDataMediator.SqlSetString(warehouseCodeList[0]);
                    }
                    else
                    {
                        SqlParameter paraWarehouseCodeSt = sqlCommand.Parameters.Add("@WAREHOUSECODEST", SqlDbType.NChar);
                        SqlParameter paraWarehouseCodeEd = sqlCommand.Parameters.Add("@WAREHOUSECODEED", SqlDbType.NChar);
                        paraWarehouseCodeSt.Value = SqlDataMediator.SqlSetString(warehouseCodeList[0]);
                        paraWarehouseCodeEd.Value = SqlDataMediator.SqlSetString(warehouseCodeList[1]);
                    }
                    //SqlParameter paraWarehouseCodeSt = sqlCommand.Parameters.Add("@WAREHOUSECODEST", SqlDbType.NChar);
                    //SqlParameter paraWarehouseCodeEd = sqlCommand.Parameters.Add("@WAREHOUSECODEED", SqlDbType.NChar);
                    //paraWarehouseCodeSt.Value = SqlDataMediator.SqlSetString(warehouseCodeList[0]);
                    //paraWarehouseCodeEd.Value = SqlDataMediator.SqlSetString(warehouseCodeList[1]);
                    // -------- UPD 2010/09/19 ----------------------------<<<<<
                }
                if (makerCodeList != null && makerCodeList.Count > 0)
                {
                    // -------- UPD 2010/09/19 ---------------------------->>>>>
                    if (makerCodeList[0] == 0 && makerCodeList[1] != 0)
                    {
                        SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                        paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(makerCodeList[1]);
                    }
                    else if (makerCodeList[0] != 0 && makerCodeList[1] == 0)
                    {

                        SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                        paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(makerCodeList[0]);
                    }
                    else
                    {

                        SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                        SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                        paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(makerCodeList[0]);
                        paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(makerCodeList[1]);
                    }
                    //SqlParameter paraGoodsMakerCdSt = sqlCommand.Parameters.Add("@GOODSMAKERCDST", SqlDbType.Int);
                    //SqlParameter paraGoodsMakerCdEd = sqlCommand.Parameters.Add("@GOODSMAKERCDED", SqlDbType.Int);
                    //paraGoodsMakerCdSt.Value = SqlDataMediator.SqlSetInt32(makerCodeList[0]);
                    //paraGoodsMakerCdEd.Value = SqlDataMediator.SqlSetInt32(makerCodeList[1]);
                    // -------- UPD 2010/09/19 ----------------------------<<<<<
                }
                if (goodsNoList != null && goodsNoList.Count > 0)
                {
                    // -------- UPD 2010/09/19 ---------------------------->>>>>
                    if (goodsNoList[0] == string.Empty && goodsNoList[1] != string.Empty)
                    {
                        SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                        paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(goodsNoList[1]);
                    }
                    else if (goodsNoList[0] != string.Empty && goodsNoList[1] == string.Empty)
                    {
                        SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                        paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(goodsNoList[0]);
                    }
                    else
                    {
                        SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                        SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                        paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(goodsNoList[0]);
                        paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(goodsNoList[1]);
                    }
                    //SqlParameter paraGoodsNoSt = sqlCommand.Parameters.Add("@GOODSNOST", SqlDbType.NVarChar);
                    //SqlParameter paraGoodsNoEd = sqlCommand.Parameters.Add("@GOODSNOED", SqlDbType.NVarChar);
                    //paraGoodsNoSt.Value = SqlDataMediator.SqlSetString(goodsNoList[0]);
                    //paraGoodsNoEd.Value = SqlDataMediator.SqlSetString(goodsNoList[1]);
                    // -------- UPD 2010/09/19 ----------------------------<<<<<
                }
                if (warehouseShelfNoList != null && warehouseShelfNoList.Count > 0)
                {
                    // -------- UPD 2010/09/19 ---------------------------->>>>>
                    if (warehouseShelfNoList[0] == string.Empty && warehouseShelfNoList[1] != string.Empty)
                    {
                        SqlParameter paraWarehouseShelfNoEd = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOED", SqlDbType.NChar);
                        paraWarehouseShelfNoEd.Value = SqlDataMediator.SqlSetString(warehouseShelfNoList[1]);
                    }
                    else if (warehouseShelfNoList[0] != string.Empty && warehouseShelfNoList[1] == string.Empty)
                    {
                        SqlParameter paraWarehouseShelfNoSt = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOST", SqlDbType.NChar);
                        paraWarehouseShelfNoSt.Value = SqlDataMediator.SqlSetString(warehouseShelfNoList[0]);
                    }
                    else
                    {
                        SqlParameter paraWarehouseShelfNoSt = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOST", SqlDbType.NChar);
                        SqlParameter paraWarehouseShelfNoEd = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOED", SqlDbType.NChar);
                        paraWarehouseShelfNoSt.Value = SqlDataMediator.SqlSetString(warehouseShelfNoList[0]);
                        paraWarehouseShelfNoEd.Value = SqlDataMediator.SqlSetString(warehouseShelfNoList[1]);
                    }
                    //SqlParameter paraWarehouseShelfNoSt = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOST", SqlDbType.NChar);
                    //SqlParameter paraWarehouseShelfNoEd = sqlCommand.Parameters.Add("@WAREHOUSESHELFNOED", SqlDbType.NChar);
                    //paraWarehouseShelfNoSt.Value = SqlDataMediator.SqlSetString(warehouseShelfNoList[0]);
                    //paraWarehouseShelfNoEd.Value = SqlDataMediator.SqlSetString(warehouseShelfNoList[1]);
                    // -------- UPD 2010/09/19 ----------------------------<<<<<
                }
                if (blGoodsCodeList != null && blGoodsCodeList.Count > 0)
                {
                    // -------- UPD 2010/09/19 ---------------------------->>>>>
                    if (blGoodsCodeList[0] == 0 && blGoodsCodeList[1] != 0)
                    {
                        SqlParameter paraBlGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                        paraBlGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeList[1]);
                    }
                    else if (blGoodsCodeList[0] != 0 && blGoodsCodeList[1] == 0)
                    {
                        SqlParameter paraBlGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                        paraBlGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeList[0]);
                    }
                    else
                    {
                        SqlParameter paraBlGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                        SqlParameter paraBlGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                        paraBlGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeList[0]);
                        paraBlGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeList[1]);
                    }
                    //SqlParameter paraBlGoodsCodeSt = sqlCommand.Parameters.Add("@BLGOODSCODEST", SqlDbType.Int);
                    //SqlParameter paraBlGoodsCodeEd = sqlCommand.Parameters.Add("@BLGOODSCODEED", SqlDbType.Int);
                    //paraBlGoodsCodeSt.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeList[0]);
                    //paraBlGoodsCodeEd.Value = SqlDataMediator.SqlSetInt32(blGoodsCodeList[1]);
                    // -------- UPD 2010/09/19 ----------------------------<<<<<
                }

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    stockHistoryDspSearchResultWorkList.Add(CopyToStockHisDspAllWorkFromReader(ref myReader, paramWork));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (!myReader.IsClosed) myReader.Close();
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

            return status;
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockHistoryDspSearchResultWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>StockHistoryDspSearchResultWork �I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/07/20</br>
        /// <br>Update Note : 2010/09/13 tianjw</br>
        /// <br>            �E�e�L�X�g�o�͑Ή�</br>
        /// </remarks>
        private StockHistoryDspSearchResultWork CopyToStockHisDspAllWorkFromReader(ref SqlDataReader myReader, StockHistoryDspSearchParamWork paramWork)
        {
            StockHistoryDspSearchResultWork stockHistoryDspSearchResultWork = new StockHistoryDspSearchResultWork();

            if (myReader != null)
            {
                # region �N���X�֊i�[
                stockHistoryDspSearchResultWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODE"));
                stockHistoryDspSearchResultWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODE"));
                stockHistoryDspSearchResultWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTH"));
                stockHistoryDspSearchResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));
                stockHistoryDspSearchResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNO"));
                stockHistoryDspSearchResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAME"));
                stockHistoryDspSearchResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCD"));
                stockHistoryDspSearchResultWork.SalesTimes += SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMES"));
                stockHistoryDspSearchResultWork.SalesCount += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNT"));
                // ------------------------------ ADD 2010/09/14 -------------------------------------------------------->>>>>
                stockHistoryDspSearchResultWork.SalesCount += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRETGOODSCNT"));
                stockHistoryDspSearchResultWork.SalesMoneyTaxExc += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICE"));
                stockHistoryDspSearchResultWork.StockCount += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRETGOODSCNT"));
                stockHistoryDspSearchResultWork.StockPriceTaxExc += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKRETGOODSPRICE"));
                // ------------------------------ ADD 2010/09/14 --------------------------------------------------------<<<<<
                stockHistoryDspSearchResultWork.SalesMoneyTaxExc += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXC"));
                stockHistoryDspSearchResultWork.StockTimes += SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKTIMES"));
                stockHistoryDspSearchResultWork.StockCount += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNT"));
                stockHistoryDspSearchResultWork.StockPriceTaxExc += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXC"));
                stockHistoryDspSearchResultWork.GrossProfit += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFIT"));
                stockHistoryDspSearchResultWork.MoveArrivalCnt += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVEARRIVALCNT"));
                stockHistoryDspSearchResultWork.MoveArrivalPrice += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVEARRIVALPRICE"));
                stockHistoryDspSearchResultWork.MoveShipmentCnt += SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVESHIPMENTCNT"));
                stockHistoryDspSearchResultWork.MoveShipmentPrice += SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVESHIPMENTPRICE"));
                stockHistoryDspSearchResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNO"));
                stockHistoryDspSearchResultWork.BlGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODE"));
                stockHistoryDspSearchResultWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATE"));
                stockHistoryDspSearchResultWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATE"));
                stockHistoryDspSearchResultWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATE"));
                stockHistoryDspSearchResultWork.SearchDiv = 1;
                # endregion
            }

            return stockHistoryDspSearchResultWork;
        }
        #endregion
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

        #region [�R�l�N�V������������]
        /// <summary>
        /// SqlConnection��������
        /// </summary>
        /// <returns>SqlConnection</returns>
        /// <remarks>
        /// <br>Programmer : 23012 ���� �[���N</br>
        /// <br>Date       : 2008.10.03</br>
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

        // ADD 2021.11.10 >>>
        #region �݌ɔN�Ԏ��яƉ�p�f�[�^�擾

        #region �݌ɔN�Ԏ��яƉ�(����)
        /// <summary>
        /// �݌ɔN�Ԏ��яƉ�List�𐶐����܂��B
        /// </summary>
        /// <param name="monthlyAddUpWork">�����X�V�p�����[�^</param>
        /// <param name="stockHistoryWorkList">�݌ɗ����X�VList</param>
        /// <param name="msgDiv">�G���[���b�Z�[�W�L���敪</param>
        /// <param name="retMsg">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌ɔN�Ԏ��яƉ�\����</br>
        /// <br>Programmer : ��ؑn</br>
        /// <br>Date       : 2021.11.10</br>
        /// �݌ɔN�Ԏ��яƉ�p�Ɋ�����MakeStockHistoryNotGetCost()���R�s�[�������\�b�h�B
        /// �q�ɃR�[�h�A�i�ԁA���[�J�[�R�[�h���w�肷�邱�ƂŐ��\�����}�����B
        /// </remarks>
        private int MakeStockHistoryPMZAI04100(ref MonthlyAddUpWork monthlyAddUpWork,
                                              ref List<StockHistoryWork> stockHistoryWorkList,
                                              out bool msgDiv,
                                              out string retMsg,
                                              ref SqlConnection sqlConnection,
                                              string warehouseCode,
                                              string goodsNo,
                                              int goodsMakerCode)
        {

            //��STATUS������
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            msgDiv = false;
            retMsg = null;
            try
            {
                //�݌Ɏ󕥗����f�[�^�W�v & �O�����擾
                status = GetStockAcPayHistPMZAI04100(ref monthlyAddUpWork, ref stockHistoryWorkList, ref sqlConnection, warehouseCode, goodsNo, goodsMakerCode);

                //���s��STATUS�ł���Ώ����I��
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    msgDiv = true;
                    retMsg = "�݌ɗ����f�[�^���o���ɃG���[���������܂����B�ēx��蒼���Ă��������B";
                    return (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MonthlyAddUpDB.MakeMonthlyAddUpParameters Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }


        /// <summary>
        /// �݌Ɏ󕥗����f�[�^���擾���܂�(�݌ɔN�Ԏ��яƉ�p)
        /// </summary>
        /// <param name="monthlyAddUpWork">�����X�V�p�����[�^�N���X���[�N</param>
        /// <param name="stockHistoryWorkList">�݌Ɏ󕥗����f�[�^List</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌ɔN�Ԏ��яƉ�\����</br>
        /// <br>Programmer : ��ؑn</br>
        /// <br>Date       : 2021.11.10</br>
        /// �݌ɔN�Ԏ��яƉ�p�Ɋ�����GetStockAcPayHistMain()���R�s�[�������\�b�h
        /// Where��ɑq�ɃR�[�h�A�i�ԁA���[�J�[�R�[�h���w�肷�邱�ƂŁA���\�����}�����B
        /// </remarks>
        private int GetStockAcPayHistPMZAI04100(ref MonthlyAddUpWork monthlyAddUpWork,
                                                ref List<StockHistoryWork> stockHistoryWorkList,
                                                ref SqlConnection sqlConnection,
                                                string warehouseCode,
                                                string goodsNo,
                                                int goodsMakerCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;

            string sqlText = string.Empty;
            // �d����擾�p
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            // �����Z�o�p
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>(); // �����v�Z�p�����[�^�I�u�W�F�N�g���X�g
            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();                // ���i�A���f�[�^�I�u�W�F�N�g���X�g
            List<UnitPriceCalcRetWork> unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();       // �����v�Z���ʃ��X�g 

            int FractionProcCd = 0;
            long calcPrice = 0;

            try
            {
                #region SELECT��
                sqlText += "  SELECT" + Environment.NewLine;
                sqlText += "   STOCKHISTORYPAY.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "   STOCKHISTORYPAY.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "   WARE.WAREHOUSENAMERF," + Environment.NewLine;
                sqlText += "   '00' AS SECTIONCODERF," + Environment.NewLine;
                sqlText += "   STOCKHISTORYPAY.GOODSNORF," + Environment.NewLine;
                sqlText += "   GOODS.GOODSNAMERF," + Environment.NewLine;
                sqlText += "   STOCKHISTORYPAY.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "   MAKER.MAKERNAMERF," + Environment.NewLine;
                sqlText += "   STOCKHIS.LMONTHSTOCKCNTRF,--�O�����݌ɐ�" + Environment.NewLine;
                sqlText += "   STOCKHIS.LMONTHSTOCKPRICERF,--�O�����݌Ɋz" + Environment.NewLine;
                sqlText += "   STOCKHIS.LMONTHPPTYSTOCKCNTRF,--�O�������Ѝ݌ɐ�" + Environment.NewLine;
                sqlText += "   STOCKHIS.LMONTHPPTYSTOCKPRICERF,--�O�������Ѝ݌ɋ��z  " + Environment.NewLine;
                sqlText += "   STOCKHACCNT.SALESTIMESRF,--�����" + Environment.NewLine;
                sqlText += "   STOCKHAC.SALESCOUNTRF,--���㐔" + Environment.NewLine;
                sqlText += "   STOCKHAC.SALESMONEYTAXEXCRF,--������z�i�Ŕ����j " + Environment.NewLine;
                sqlText += "   STOCKHACCNT.SALESRETGOODSTIMESRF,--����ԕi��" + Environment.NewLine;
                sqlText += "   STOCKHAC.SALESRETGOODSCNTRF,--����ԕi��" + Environment.NewLine;
                sqlText += "   STOCKHAC.SALESRETGOODSPRICERF,--����ԕi�z" + Environment.NewLine;
                sqlText += "   STOCKHAC.GROSSPROFITRF,--�e�����z" + Environment.NewLine;
                sqlText += "   STOCKHACCNT.STOCKTIMESRF,--�d����" + Environment.NewLine;
                sqlText += "   STOCKHAC.STOCKCOUNTRF,--�d����  " + Environment.NewLine;
                sqlText += "   STOCKHAC.STOCKPRICETAXEXCRF,--�d�����z�i�Ŕ����j " + Environment.NewLine;
                sqlText += "   STOCKHACCNT.STOCKRETGOODSTIMESRF,--�d���ԕi��" + Environment.NewLine;
                sqlText += "   STOCKHAC.STOCKRETGOODSCNTRF,--�d���ԕi��" + Environment.NewLine;
                sqlText += "   STOCKHAC.STOCKRETGOODSPRICERF,--�d���ԕi�z " + Environment.NewLine;
                sqlText += "   STOCKHAC.MOVEARRIVALCNTRF,--�ړ����א�" + Environment.NewLine;
                sqlText += "   STOCKHAC.MOVEARRIVALPRICERF,--�ړ����׊z" + Environment.NewLine;
                sqlText += "   STOCKHAC.MOVESHIPMENTCNTRF,--�ړ��o�א�" + Environment.NewLine;
                sqlText += "   STOCKHAC.MOVESHIPMENTPRICERF,--�ړ��o�׊z" + Environment.NewLine;
                sqlText += "   (STOCKHAC.ADJUSTCOUNTRF1 - STOCKHAC.ADJUSTCOUNTRF2) AS ADJUSTCOUNTRF,--������" + Environment.NewLine;
                sqlText += "   (STOCKHAC.ADJUSTPRICERF1 - STOCKHAC.ADJUSTPRICERF2) AS ADJUSTPRICERF,--�������z" + Environment.NewLine;
                sqlText += "   STOCKHAC.ARRIVALCNTRF,--���א�" + Environment.NewLine;
                sqlText += "   STOCKHAC.ARRIVALPRICERF,--���׋��z" + Environment.NewLine;
                sqlText += "   STOCKHAC.SHIPMENTCNTRF,--�o�א�" + Environment.NewLine;
                sqlText += "   STOCKHAC.SHIPMENTPRICERF,--�o�׋��z" + Environment.NewLine;
                sqlText += "   STOCKHAC.TOTALARRIVALCNTRF,--�����א�" + Environment.NewLine;
                sqlText += "   STOCKHAC.TOTALARRIVALPRICERF,--�����׋��z" + Environment.NewLine;
                sqlText += "   STOCKHAC.TOTALSHIPMENTCNTRF,--���o�א�" + Environment.NewLine;
                sqlText += "   STOCKHAC.TOTALSHIPMENTPRICERF,--���o�׋��z   " + Environment.NewLine;
                sqlText += "   GOODS.BLGOODSCODERF,  -- BL���i�R�[�h" + Environment.NewLine;
                sqlText += "   BL.BLGOODSHALFNAMERF, -- BL���i�R�[�h���́i���p�j" + Environment.NewLine;
                sqlText += "   BL.BLGROUPCODERF, -- BL�O���[�v�R�[�h" + Environment.NewLine;
                sqlText += "   BLG.GOODSMGROUPRF, -- ���i������" + Environment.NewLine;
                sqlText += "   STOCKMNGTTL.FRACTIONPROCCDRF -- �[�������敪" + Environment.NewLine;
                sqlText += "   ,STOCK.STOCKCREATEDATE -- �݌ɓo�^��" + Environment.NewLine;
                sqlText += "   ,STOCK.LASTSALESDATE -- �ŏI�����" + Environment.NewLine;
                sqlText += "   ,STOCK.LASTSTOCKDATE -- �ŏI�d����" + Environment.NewLine;
                sqlText += "   ,STOCK.WAREHOUSESHELFNO -- �I��" + Environment.NewLine;
                sqlText += "   ,STOCK.WAREHOUSECODE --�q�ɃR�[�h" + Environment.NewLine;
                sqlText += "  FROM" + Environment.NewLine;

                #region SUB�N�G��

                #region �O���݌ɗ����ƍ݌Ɏ󕥃f�[�^���猋��KEY���擾
                sqlText += "  (" + Environment.NewLine;
                sqlText += "    SELECT DISTINCT" + Environment.NewLine;
                sqlText += "     ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "     WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "     GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "     GOODSNORF" + Environment.NewLine;
                sqlText += "    FROM" + Environment.NewLine;
                sqlText += "     STOCKHISTORYRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "     AND LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "     AND ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                {
                    sqlText += "     AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "    UNION SELECT DISTINCT" + Environment.NewLine;
                sqlText += "     ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "     WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "     GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "     GOODSNORF" + Environment.NewLine;
                sqlText += "    FROM" + Environment.NewLine;
                sqlText += "     STOCKACPAYHISTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                {
                    sqlText += "     AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "     AND LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "     AND( ( CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END ) >= @FINDADDUPDATEST  AND (CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END )   <=@FINDADDUPDATEED)" + Environment.NewLine;
                sqlText += "  ) AS STOCKHISTORYPAY" + Environment.NewLine;
                #endregion

                #region �݌ɊǗ��S�̐ݒ�}�X�^ ����
                sqlText += "  --�݌ɊǗ��S�̐ݒ�}�X�^ ����" + Environment.NewLine;
                sqlText += "  LEFT JOIN STOCKMNGTTLSTRF AS STOCKMNGTTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "   ON STOCKHISTORYPAY.ENTERPRISECODERF = STOCKMNGTTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "   AND STOCKMNGTTL.SECTIONCODERF = '00'" + Environment.NewLine;
                #endregion

                #region �݌Ƀ}�X�^ ����
                sqlText += "  --�݌Ƀ}�X�^ ����" + Environment.NewLine;
                sqlText += "  LEFT JOIN ( " + Environment.NewLine;
                sqlText += "  SELECT " + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF AS ENTERPRISECODE " + Environment.NewLine;
                sqlText += "  ,SECTIONCODERF AS SECTIONCODE " + Environment.NewLine;
                sqlText += "  ,WAREHOUSECODERF AS WAREHOUSECODE " + Environment.NewLine;
                sqlText += "  ,WAREHOUSESHELFNORF AS WAREHOUSESHELFNO " + Environment.NewLine;
                sqlText += "  ,GOODSMAKERCDRF AS GOODSMAKERCD " + Environment.NewLine;
                sqlText += "  ,GOODSNORF AS GOODSNO " + Environment.NewLine;
                sqlText += "  ,STOCKSUPPLIERCODERF AS STOCKSUPPLIERCODE " + Environment.NewLine;
                sqlText += "  ,STOCKCREATEDATERF AS STOCKCREATEDATE " + Environment.NewLine;
                sqlText += "  ,LASTSALESDATERF AS LASTSALESDATE " + Environment.NewLine;
                sqlText += "  ,LASTSTOCKDATERF AS LASTSTOCKDATE " + Environment.NewLine;
                sqlText += "  FROM " + Environment.NewLine;
                sqlText += "  STOCKRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "  WHERE " + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND LOGICALDELETECODERF=0 " + Environment.NewLine;
                sqlText += "  ) AS STOCK " + Environment.NewLine;
                sqlText += "  ON " + Environment.NewLine;
                sqlText += "  STOCKHISTORYPAY.ENTERPRISECODERF = STOCK.ENTERPRISECODE " + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.WAREHOUSECODERF = STOCK.WAREHOUSECODE " + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSMAKERCDRF = STOCK.GOODSMAKERCD " + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSNORF = STOCK.GOODSNO  " + Environment.NewLine;
                #endregion

                #region �݌Ɏ󕥃f�[�^�W�v��� ����
                sqlText += "  LEFT JOIN " + Environment.NewLine;
                sqlText += "  ( " + Environment.NewLine;
                sqlText += "   SELECT" + Environment.NewLine;
                sqlText += "    STPAY.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "    STPAY.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "    STPAY.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "    STPAY.GOODSNORF," + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=10  ) ) THEN STPAY.SHIPMENTCNTRF + STPAY.DELSHIPMENTCNTRF ELSE 0 END) AS SALESCOUNTRF,--���㐔" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=10 ) ) THEN STPAY.SALESMONEYRF + STPAY.DELSALESMONEYRF ELSE 0 END) AS SALESMONEYTAXEXCRF,--������z�i�Ŕ����j" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20 ) ) THEN 1 ELSE 0 END) AS SALESRETGOODSTIMESRF,--����ԕi��" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20 ) ) THEN STPAY.SHIPMENTCNTRF + STPAY.DELSHIPMENTCNTRF ELSE 0 END) AS SALESRETGOODSCNTRF,--����ԕi��" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20 ) ) THEN STPAY.SALESMONEYRF + STPAY.DELSALESMONEYRF ELSE 0 END) AS SALESRETGOODSPRICERF,--����ԕi�z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=10 OR STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20 ) ) THEN ((STPAY.SALESMONEYRF+STPAY.DELSALESMONEYRF) - (STPAY.STOCKPRICERF +STPAY.DELSTOCKPRICERF)) ELSE 0 END) AS GROSSPROFITRF,--�e�����z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN ((STPAY.ACPAYSLIPCDRF=10 AND (STPAY.ACPAYTRANSCDRF=10 OR STPAY.ACPAYTRANSCDRF=21))OR(STPAY.ACPAYSLIPCDRF=13 AND (STPAY.ACPAYTRANSCDRF=10 OR STPAY.ACPAYTRANSCDRF=30)) ) THEN STPAY.ARRIVALCNTRF+STPAY.DELARRIVALCNTRF ELSE 0 END) AS STOCKCOUNTRF,--�d����" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN ((STPAY.ACPAYSLIPCDRF=10 AND (STPAY.ACPAYTRANSCDRF=10 OR STPAY.ACPAYTRANSCDRF=21))OR(STPAY.ACPAYSLIPCDRF=13 AND (STPAY.ACPAYTRANSCDRF=10 OR STPAY.ACPAYTRANSCDRF=30)) ) THEN STPAY.STOCKPRICERF+STPAY.DELSTOCKPRICERF ELSE 0 END) AS STOCKPRICETAXEXCRF,--�d�����z�i�Ŕ����j" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=10 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20 OR STPAY.ACPAYTRANSCDRF=21)) THEN 1 ELSE 0 END) AS STOCKRETGOODSTIMESRF,--�d���ԕi��  " + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=10 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20) ) THEN STPAY.ARRIVALCNTRF+STPAY.DELARRIVALCNTRF ELSE 0 END) AS STOCKRETGOODSCNTRF,--�d���ԕi��" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=10 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20) ) THEN STPAY.STOCKPRICERF+STPAY.DELSTOCKPRICERF ELSE 0 END) AS STOCKRETGOODSPRICERF,--�d���ԕi�z " + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=31) THEN STPAY.ARRIVALCNTRF + STPAY.DELARRIVALCNTRF ELSE 0 END) AS MOVEARRIVALCNTRF,--�ړ����א�" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=31) THEN STPAY.STOCKPRICERF + STPAY.DELSTOCKPRICERF ELSE 0 END) AS MOVEARRIVALPRICERF,--�ړ����׊z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=30) THEN STPAY.SHIPMENTCNTRF + STPAY.DELSHIPMENTCNTRF ELSE 0 END) AS MOVESHIPMENTCNTRF,--�ړ��o�א�" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=30) THEN STPAY.SALESMONEYRF + STPAY.DELSALESMONEYRF ELSE 0 END) AS MOVESHIPMENTPRICERF,--�ړ��o�׊z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=42 OR STPAY.ACPAYSLIPCDRF=50 OR " + Environment.NewLine;
                sqlText += "                   STPAY.ACPAYSLIPCDRF=60 OR STPAY.ACPAYSLIPCDRF=61 OR STPAY.ACPAYSLIPCDRF=70) THEN STPAY.ARRIVALCNTRF ELSE 0 END) AS ADJUSTCOUNTRF1,--������1" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=71) THEN STPAY.SHIPMENTCNTRF ELSE 0 END) AS ADJUSTCOUNTRF2,--������2" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=42 OR STPAY.ACPAYSLIPCDRF=50 OR " + Environment.NewLine;
                sqlText += "                   STPAY.ACPAYSLIPCDRF=60 OR STPAY.ACPAYSLIPCDRF=61 OR STPAY.ACPAYSLIPCDRF=70) THEN STPAY.STOCKPRICERF ELSE 0 END) AS ADJUSTPRICERF1,--�������z1" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=71) THEN STPAY.SALESMONEYRF ELSE 0 END) AS ADJUSTPRICERF2,--�������z2  " + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=11) THEN STPAY.ARRIVALCNTRF ELSE 0 END) AS ARRIVALCNTRF,--���א�" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=11) THEN STPAY.STOCKPRICERF ELSE 0 END) AS ARRIVALPRICERF,--���׋��z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=22) THEN STPAY.SHIPMENTCNTRF ELSE 0 END) AS SHIPMENTCNTRF,--�o�א�" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=22) THEN STPAY.SALESMONEYRF ELSE 0 END) AS SHIPMENTPRICERF,--�o�׋��z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=10 OR STPAY.ACPAYSLIPCDRF=11 OR STPAY.ACPAYSLIPCDRF=13 OR STPAY.ACPAYSLIPCDRF=31) THEN STPAY.ARRIVALCNT2RF + STPAY.DELARRIVALCNT2RF ELSE 0 END) AS TOTALARRIVALCNTRF,--�����א�" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=10 OR STPAY.ACPAYSLIPCDRF=11 OR STPAY.ACPAYSLIPCDRF=13 OR STPAY.ACPAYSLIPCDRF=31) THEN STPAY.STOCKPRICE2RF + STPAY.DELSTOCKPRICE2RF ELSE 0 END) AS TOTALARRIVALPRICERF,--�����׋��z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 OR STPAY.ACPAYSLIPCDRF=22 OR STPAY.ACPAYSLIPCDRF=30) THEN STPAY.SHIPMENTCNT2RF + STPAY.DELSHIPMENTCNT2RF ELSE 0 END) AS TOTALSHIPMENTCNTRF,--���o�א�" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 OR STPAY.ACPAYSLIPCDRF=22 OR STPAY.ACPAYSLIPCDRF=30) THEN STPAY.SALESMONEY2RF + STPAY.DELSALESMONEY2RF ELSE 0 END) AS TOTALSHIPMENTPRICERF --���o�׋��z " + Environment.NewLine;
                sqlText += "   FROM" + Environment.NewLine;
                sqlText += "   (" + Environment.NewLine;
                sqlText += "    select" + Environment.NewLine;
                sqlText += "      STACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "      STACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "      STACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "      STACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "      STACPAYHIST.GOODSNORF," + Environment.NewLine;
                sqlText += "      STACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                sqlText += "      STACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                sqlText += "      STACPAYHIST.ACPAYTRANSCDRF, --�󕥌�����敪" + Environment.NewLine;
                sqlText += "      STACPAYHIST.ARRIVALCNTRF ,   --���א�" + Environment.NewLine;
                sqlText += "      STACPAYHIST.SHIPMENTCNTRF,  --�o�א�" + Environment.NewLine;
                sqlText += "      STACPAYHIST.STOCKPRICERF,   --�d�����z" + Environment.NewLine;
                sqlText += "      STACPAYHIST.SALESMONEYRF,    --������z      " + Environment.NewLine;
                sqlText += "      STACPAYHIST.ARRIVALCNT2RF,   --�����v�p���א�" + Environment.NewLine;
                sqlText += "      STACPAYHIST.SHIPMENTCNT2RF,  --�����v�p�o�א�" + Environment.NewLine;
                sqlText += "      STACPAYHIST.STOCKPRICE2RF,   --�����v�p�d�����z" + Environment.NewLine;
                sqlText += "      STACPAYHIST.SALESMONEY2RF,   --�����v�p������z      " + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.ACPAYTRANSCDRF IS NULL THEN 0 ELSE STACPAYHISTDEL.ACPAYTRANSCDRF END)  AS DELACPAYTRANSCDRF,--�󕥌�����敪" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.ARRIVALCNTRF IS NULL THEN 0 ELSE STACPAYHISTDEL.ARRIVALCNTRF END ) AS DELARRIVALCNTRF,      --���א�" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.SHIPMENTCNTRF IS NULL THEN 0 ELSE STACPAYHISTDEL.SHIPMENTCNTRF END ) AS DELSHIPMENTCNTRF,   --�o�א�" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.STOCKPRICERF IS NULL THEN 0 ELSE STACPAYHISTDEL.STOCKPRICERF END ) AS DELSTOCKPRICERF,      --�d�����z" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.SALESMONEYRF IS NULL THEN 0 ELSE STACPAYHISTDEL.SALESMONEYRF END) AS DELSALESMONEYRF,       --������z     " + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.ARRIVALCNT2RF IS NULL THEN 0 ELSE STACPAYHISTDEL.ARRIVALCNT2RF END)  AS DELARRIVALCNT2RF, --�����v�p���א�" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.SHIPMENTCNT2RF IS NULL THEN 0 ELSE STACPAYHISTDEL.SHIPMENTCNT2RF END ) AS DELSHIPMENTCNT2RF, --�����v�p�o�א�" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.STOCKPRICE2RF IS NULL THEN 0 ELSE STACPAYHISTDEL.STOCKPRICE2RF END ) AS DELSTOCKPRICE2RF,  --�����v�p�d�����z" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.SALESMONEY2RF IS NULL THEN 0 ELSE STACPAYHISTDEL.SALESMONEY2RF END ) AS DELSALESMONEY2RF    --�����v�p������z" + Environment.NewLine;
                sqlText += "    from" + Environment.NewLine;
                sqlText += "    (" + Environment.NewLine;
                sqlText += "     SELECT" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYTRANSCDRF, --�󕥌�����敪" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.ARRIVALCNTRF) AS ARRIVALCNTRF ,   --���א�" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.SHIPMENTCNTRF) AS SHIPMENTCNTRF,  --�o�א�" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.STOCKPRICERF) AS STOCKPRICERF,   --�d�����z" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.SALESMONEYRF) AS SALESMONEYRF,    --������z" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 10 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.ARRIVALCNTRF END)) AS ARRIVALCNT2RF,   --�����v�p���א�" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 20 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.SHIPMENTCNTRF END))AS SHIPMENTCNT2RF,  --�����v�p�o�א�" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 10 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.STOCKPRICERF END)) AS STOCKPRICE2RF,   --�����v�p�d�����z" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 20 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.SALESMONEYRF END)) AS SALESMONEY2RF   --�����v�p������z" + Environment.NewLine;
                sqlText += "     FROM" + Environment.NewLine;
                sqlText += "      STOCKACPAYHISTRF AS STOCKACPAYHIST WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "     WHERE " + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHIST.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "     AND( ( CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END ) >= @FINDADDUPDATEST  AND (CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END )<=@FINDADDUPDATEED)" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHIST.ACPAYTRANSCDRF  != 21" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHIST.ACPAYTRANSCDRF  != 90" + Environment.NewLine;
                if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                {
                    sqlText += "      AND STOCKACPAYHIST.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "     GROUP BY" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYTRANSCDRF --�󕥌�����敪" + Environment.NewLine;
                sqlText += "     ) AS STACPAYHIST" + Environment.NewLine;
                sqlText += "     LEFT JOIN" + Environment.NewLine;
                sqlText += "     (" + Environment.NewLine;
                sqlText += "     SELECT" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYTRANSCDRF, --�󕥌�����敪" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.ARRIVALCNTRF) AS ARRIVALCNTRF ,   --���א�" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.SHIPMENTCNTRF) AS SHIPMENTCNTRF,  --�o�א�" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.STOCKPRICERF) AS STOCKPRICERF,   --�d�����z" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.SALESMONEYRF) AS SALESMONEYRF,    --������z" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 10 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.ARRIVALCNTRF END)) AS ARRIVALCNT2RF,   --�����v�p���א�" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 20 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.SHIPMENTCNTRF END))AS SHIPMENTCNT2RF,  --�����v�p�o�א�" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 10 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.STOCKPRICERF END)) AS STOCKPRICE2RF,   --�����v�p�d�����z" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 20 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.SALESMONEYRF END)) AS SALESMONEY2RF   --�����v�p������z" + Environment.NewLine;
                sqlText += "     FROM" + Environment.NewLine;
                sqlText += "      STOCKACPAYHISTRF AS STOCKACPAYHIST WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "     WHERE " + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHIST.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "     AND( ( CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END ) >= @FINDADDUPDATEST  AND (CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END )<=@FINDADDUPDATEED)" + Environment.NewLine;
                sqlText += "      AND (STOCKACPAYHIST.ACPAYTRANSCDRF  = 21 OR STOCKACPAYHIST.ACPAYTRANSCDRF  = 90)" + Environment.NewLine;
                if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                {
                    sqlText += "      AND STOCKACPAYHIST.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "     GROUP BY" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYTRANSCDRF --�󕥌�����敪" + Environment.NewLine;
                sqlText += "     ) AS STACPAYHISTDEL" + Environment.NewLine;
                sqlText += "     ON STACPAYHIST.ENTERPRISECODERF = STACPAYHISTDEL.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += "     AND STACPAYHIST.WAREHOUSECODERF = STACPAYHISTDEL.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "     AND STACPAYHIST.GOODSMAKERCDRF = STACPAYHISTDEL.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "     AND STACPAYHIST.GOODSNORF = STACPAYHISTDEL.GOODSNORF" + Environment.NewLine;
                sqlText += "     AND STACPAYHIST.ACPAYSLIPNUMRF = STACPAYHISTDEL.ACPAYSLIPNUMRF" + Environment.NewLine;
                sqlText += "     AND STACPAYHIST.ACPAYSLIPCDRF = STACPAYHISTDEL.ACPAYSLIPCDRF    " + Environment.NewLine;
                sqlText += "    )AS STPAY" + Environment.NewLine;
                sqlText += "    GROUP  BY" + Environment.NewLine;
                sqlText += "     STPAY.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "     STPAY.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "     STPAY.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "     STPAY.GOODSNORF" + Environment.NewLine;
                sqlText += "  ) AS STOCKHAC" + Environment.NewLine;
                sqlText += "  ON  STOCKHISTORYPAY.ENTERPRISECODERF = STOCKHAC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.WAREHOUSECODERF = STOCKHAC.WAREHOUSECODERF" + Environment.NewLine;
                //sqlText += "  AND STOCKHISTORYPAY.SECTIONCODERF = STOCKHAC.SECTIONCODERF" + Environment.NewLine; // DEL 2009/04/02
                sqlText += "  AND STOCKHISTORYPAY.GOODSMAKERCDRF = STOCKHAC.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSNORF = STOCKHAC.GOODSNORF" + Environment.NewLine;

                #endregion �݌Ɏ󕥃f�[�^�W�v��� ����

                #region �݌Ɏ󕥃f�[�^�W�v���( �����,�d����)�@����
                sqlText += "  LEFT JOIN " + Environment.NewLine;
                sqlText += "  (" + Environment.NewLine;
                sqlText += "   SELECT" + Environment.NewLine;
                sqlText += "    STPAYCNT.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "    STPAYCNT.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "    STPAYCNT.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "    STPAYCNT.GOODSNORF," + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN ((STPAYCNT.ACPAYSLIPCDRF=20 AND STPAYCNT.ACPAYTRANSCDRF=10) AND DELSLIPNUM IS NULL) THEN 1 ELSE 0 END) AS SALESTIMESRF,--�����" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAYCNT.ACPAYSLIPCDRF=20 AND (STPAYCNT.ACPAYTRANSCDRF=11 OR STPAYCNT.ACPAYTRANSCDRF=20)AND DELSLIPNUM IS NULL ) THEN 1 ELSE 0 END) AS SALESRETGOODSTIMESRF,--����ԕi��" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN ((STPAYCNT.ACPAYSLIPCDRF=10 AND STPAYCNT.ACPAYTRANSCDRF=10 AND DELSLIPNUM IS NULL) OR (STPAYCNT.ACPAYSLIPCDRF=13 AND( STPAYCNT.ACPAYTRANSCDRF=10 OR STPAYCNT.ACPAYTRANSCDRF=30)AND DELSLIPNUM IS NULL )) THEN 1 ELSE 0 END) AS STOCKTIMESRF, --�d����" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAYCNT.ACPAYSLIPCDRF=10 AND (STPAYCNT.ACPAYTRANSCDRF=11 OR STPAYCNT.ACPAYTRANSCDRF=20)AND DELSLIPNUM IS NULL ) THEN 1 ELSE 0 END) AS STOCKRETGOODSTIMESRF--�d���ԕi��" + Environment.NewLine;
                sqlText += "   FROM  " + Environment.NewLine;
                sqlText += "   (" + Environment.NewLine;
                sqlText += "      SELECT " + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.ACPAYSLIPNUMRF, --�`�[�ԍ�" + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.ACPAYTRANSCDRF,  --�󕥌�����敪" + Environment.NewLine;
                sqlText += "       DELSTOCKACPAYHIST.ACPAYSLIPNUMRF AS DELSLIPNUM --�`�[�ԍ�" + Environment.NewLine;
                sqlText += "      FROM" + Environment.NewLine;
                sqlText += "       STOCKACPAYHISTRF AS STOCKACPAYHIST WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "     LEFT JOIN" + Environment.NewLine;
                sqlText += "      (" + Environment.NewLine;
                sqlText += "        SELECT" + Environment.NewLine;
                sqlText += "         LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "         ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "         WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "         GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "         GOODSNORF," + Environment.NewLine;
                sqlText += "         ACPAYSLIPNUMRF --�󕥌��`�[�ԍ�" + Environment.NewLine;
                sqlText += "        FROM" + Environment.NewLine;
                sqlText += "         STOCKACPAYHISTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "        WHERE" + Environment.NewLine;
                sqlText += "         ENTERPRISECODERF=@FINDENTERPRISECODE AND " + Environment.NewLine;
                sqlText += "         LOGICALDELETECODERF=0 AND " + Environment.NewLine;
                sqlText += "         ACPAYTRANSCDRF = 21 " + Environment.NewLine;
                sqlText += "      ) AS DELSTOCKACPAYHIST" + Environment.NewLine;
                sqlText += "       ON  STOCKACPAYHIST.ENTERPRISECODERF = DELSTOCKACPAYHIST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "       AND STOCKACPAYHIST.WAREHOUSECODERF = DELSTOCKACPAYHIST.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "       AND STOCKACPAYHIST.GOODSMAKERCDRF = DELSTOCKACPAYHIST.GOODSMAKERCDRF " + Environment.NewLine;
                sqlText += "       AND STOCKACPAYHIST.GOODSNORF = DELSTOCKACPAYHIST.GOODSNORF" + Environment.NewLine;
                sqlText += "       AND STOCKACPAYHIST.ACPAYSLIPNUMRF = DELSTOCKACPAYHIST.ACPAYSLIPNUMRF          " + Environment.NewLine;
                sqlText += "      WHERE STOCKACPAYHIST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                {
                    sqlText += "       AND STOCKACPAYHIST.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "       AND STOCKACPAYHIST.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "     AND( ( CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END ) >= @FINDADDUPDATEST  AND (CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END )<=@FINDADDUPDATEED)" + Environment.NewLine;                //ADD by Liangsd     2011/08/23
                sqlText += "   ) AS STPAYCNT" + Environment.NewLine;
                sqlText += "   GROUP BY" + Environment.NewLine;
                sqlText += "    STPAYCNT.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "    STPAYCNT.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "    STPAYCNT.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "    STPAYCNT.GOODSNORF" + Environment.NewLine;
                sqlText += "  ) AS STOCKHACCNT" + Environment.NewLine;
                sqlText += "   ON  STOCKHISTORYPAY.ENTERPRISECODERF = STOCKHACCNT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "   AND STOCKHISTORYPAY.WAREHOUSECODERF = STOCKHACCNT.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "   AND STOCKHISTORYPAY.GOODSMAKERCDRF = STOCKHACCNT.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "   AND STOCKHISTORYPAY.GOODSNORF = STOCKHACCNT.GOODSNORF" + Environment.NewLine;
                #endregion

                #region �݌ɗ����}�X�^�O����� ����
                sqlText += "  LEFT JOIN" + Environment.NewLine;
                sqlText += "  (" + Environment.NewLine;
                sqlText += "    SELECT " + Environment.NewLine;
                sqlText += "     ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "     WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "     GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "     GOODSNORF," + Environment.NewLine;
                sqlText += "     STOCKTOTALRF AS LMONTHSTOCKCNTRF,--�O�����݌ɐ�" + Environment.NewLine;
                sqlText += "     STOCKMASHINEPRICERF AS LMONTHSTOCKPRICERF,--�O�����݌Ɋz" + Environment.NewLine;
                sqlText += "     PROPERTYSTOCKCNTRF AS LMONTHPPTYSTOCKCNTRF,--�O�������Ѝ݌ɐ�" + Environment.NewLine;
                sqlText += "     PROPERTYSTOCKPRICERF AS LMONTHPPTYSTOCKPRICERF,--�O�������Ѝ݌ɋ��z" + Environment.NewLine;
                sqlText += "     STOCKUNITPRICEFLRF AS STOCKUNITPRICEFLRF --�d���P��" + Environment.NewLine;
                sqlText += "    FROM" + Environment.NewLine;
                sqlText += "     STOCKHISTORYRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "     AND LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "     AND ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                {
                    sqlText += "     AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "  ) AS STOCKHIS" + Environment.NewLine;
                sqlText += "  ON  STOCKHISTORYPAY.ENTERPRISECODERF = STOCKHIS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.WAREHOUSECODERF = STOCKHIS.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSMAKERCDRF = STOCKHIS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSNORF = STOCKHIS.GOODSNORF" + Environment.NewLine;
                #endregion �O����� ����

                #endregion

                #region JOIN��
                sqlText += " LEFT JOIN MAKERURF AS MAKER WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "  ON  STOCKHISTORYPAY.ENTERPRISECODERF = MAKER.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSMAKERCDRF = MAKER.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  AND MAKER.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += " LEFT JOIN  WAREHOUSERF AS WARE WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "  ON STOCKHISTORYPAY.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.WAREHOUSECODERF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  AND WARE.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += " LEFT JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "  ON  STOCKHISTORYPAY.ENTERPRISECODERF = GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSMAKERCDRF = GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSNORF = GOODS.GOODSNORF" + Environment.NewLine;
                sqlText += "  AND GOODS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += " LEFT JOIN BLGOODSCDURF AS BL WITH (READUNCOMMITTED) -- BL�}�X�^" + Environment.NewLine;
                sqlText += "  ON  STOCKHISTORYPAY.ENTERPRISECODERF = BL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND GOODS.BLGOODSCODERF = BL.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  AND BL.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += " LEFT JOIN BLGROUPURF AS BLG WITH (READUNCOMMITTED) -- BL�O���[�v�R�[�h�}�X�^" + Environment.NewLine;
                sqlText += "  ON STOCKHISTORYPAY.ENTERPRISECODERF = BLG.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND BL.BLGROUPCODERF = BLG.BLGROUPCODERF" + Environment.NewLine;
                #endregion

                #region WHERE��
                sqlText += @" WHERE
  STOCKHISTORYPAY.WAREHOUSECODERF = @WAREHOUSECODE
  AND STOCKHISTORYPAY.GOODSNORF = @GOODSNO
  AND STOCKHISTORYPAY.GOODSMAKERCDRF = @GOODSMAKERCODE";
                #endregion

                #endregion

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {
                    #region Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@WAREHOUSECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCode = sqlCommand.Parameters.Add("@GOODSMAKERCODE", SqlDbType.Int);
                    SqlParameter findParaAddUpDateSt = sqlCommand.Parameters.Add("@FINDADDUPDATEST", SqlDbType.Int);
                    SqlParameter findParaAddUpDateEd = sqlCommand.Parameters.Add("@FINDADDUPDATEED", SqlDbType.Int);
                    SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(monthlyAddUpWork.EnterpriseCode);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(warehouseCode);
                    findParaGoodsNo.Value = SqlDataMediator.SqlSetString(goodsNo);
                    findParaGoodsMakerCode.Value = SqlDataMediator.SqlSetString(goodsMakerCode.ToString());

                    if (monthlyAddUpWork.AddUpDateSt == DateTime.MinValue)
                    {
                        findParaAddUpDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(new DateTime(1000, 01, 01));
                    }
                    else
                    {
                        findParaAddUpDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(monthlyAddUpWork.AddUpDateSt);
                    }

                    findParaAddUpDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(monthlyAddUpWork.AddUpDate);
                    if (monthlyAddUpWork.LstMonAddUpProcDay == DateTime.MinValue)
                    {
                        findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(new DateTime(1000, 01, 01));
                    }
                    else
                    {
                        findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(monthlyAddUpWork.LstMonAddUpProcDay); // ADD 2008.12.22
                    }

                    // �S���_���Ή�
                    if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                    {
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(monthlyAddUpWork.AddUpSecCode);
                    }

                    #endregion

                    sqlCommand.CommandTimeout = 3600;
                    myReader = sqlCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        StockHistoryWork wkstockHistoryWork = new StockHistoryWork();
                        GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                        UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                        GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // ���i�A���f�[�^�I�u�W�F�N�g���X�g

                        #region ���ʃZ�b�g

                        #region �݌ɗ����f�[�^�N���X
                        FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); // �[�������敪
                        wkstockHistoryWork.EnterpriseCode = monthlyAddUpWork.EnterpriseCode;
                        wkstockHistoryWork.AddUpYearMonth = monthlyAddUpWork.AddUpYearMonth;
                        wkstockHistoryWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                        wkstockHistoryWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                        wkstockHistoryWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                        wkstockHistoryWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                        wkstockHistoryWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                        wkstockHistoryWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                        wkstockHistoryWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                        wkstockHistoryWork.LMonthStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LMONTHSTOCKCNTRF"));
                        wkstockHistoryWork.LMonthStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LMONTHSTOCKPRICERF"));
                        wkstockHistoryWork.LMonthPptyStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LMONTHPPTYSTOCKCNTRF"));
                        wkstockHistoryWork.LMonthPptyStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LMONTHPPTYSTOCKPRICERF"));
                        wkstockHistoryWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMESRF"));
                        wkstockHistoryWork.SalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        wkstockHistoryWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                        wkstockHistoryWork.SalesRetGoodsTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESRETGOODSTIMESRF"));
                        wkstockHistoryWork.SalesRetGoodsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRETGOODSCNTRF"));
                        wkstockHistoryWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        wkstockHistoryWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITRF"));
                        wkstockHistoryWork.StockTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKTIMESRF"));
                        wkstockHistoryWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
                        wkstockHistoryWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                        wkstockHistoryWork.StockRetGoodsTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKRETGOODSTIMESRF"));
                        wkstockHistoryWork.StockRetGoodsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRETGOODSCNTRF"));
                        wkstockHistoryWork.StockRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKRETGOODSPRICERF"));
                        wkstockHistoryWork.MoveArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVEARRIVALCNTRF"));
                        wkstockHistoryWork.MoveArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVEARRIVALPRICERF"));
                        wkstockHistoryWork.MoveShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVESHIPMENTCNTRF"));
                        wkstockHistoryWork.MoveShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVESHIPMENTPRICERF"));
                        wkstockHistoryWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                        wkstockHistoryWork.AdjustPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ADJUSTPRICERF"));
                        wkstockHistoryWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                        wkstockHistoryWork.ArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ARRIVALPRICERF"));
                        wkstockHistoryWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                        wkstockHistoryWork.ShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SHIPMENTPRICERF"));
                        wkstockHistoryWork.TotalArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALARRIVALCNTRF"));
                        wkstockHistoryWork.TotalArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALARRIVALPRICERF"));
                        wkstockHistoryWork.TotalShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSHIPMENTCNTRF"));
                        wkstockHistoryWork.TotalShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALSHIPMENTPRICERF"));
                        wkstockHistoryWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                        wkstockHistoryWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                        wkstockHistoryWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNO"));
                        wkstockHistoryWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATE"));
                        wkstockHistoryWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATE"));
                        wkstockHistoryWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATE"));
                        wkstockHistoryWork.WareHouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));

                        // �݌ɑ��� =  �O�����݌ɐ�+�����א� - ���o�א� + ������ ���ݏo�E���ׂ��܂�
                        wkstockHistoryWork.StockTotal = wkstockHistoryWork.LMonthStockCnt + wkstockHistoryWork.TotalArrivalCnt - wkstockHistoryWork.TotalShipmentCnt + wkstockHistoryWork.AdjustCount;

                        // ���Ѝ݌ɐ� =  �O�������Ѝ݌ɐ� + �����א� - ���o�א� + ������ + �o�א�(�ݏo) - ���א� ���ݏo�E���ׂ͊܂܂Ȃ�
                        wkstockHistoryWork.PropertyStockCnt = wkstockHistoryWork.LMonthPptyStockCnt + wkstockHistoryWork.TotalArrivalCnt - wkstockHistoryWork.TotalShipmentCnt + wkstockHistoryWork.AdjustCount - wkstockHistoryWork.ArrivalCnt + wkstockHistoryWork.ShipmentCnt;

                        stockHistoryWorkList.Add(wkstockHistoryWork);
                        #endregion

                        #endregion

                    }

                    if (GoodsSupplierDataWorkList.Count > 0)
                    {
                        // ���i�d������擾���� ���s
                        goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                        // ���i�d������擾�����ɂ��擾�����d�����
                        // �P���Z�o�p�����[�^�ɃZ�b�g
                        for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // ���i�d���擾�f�[�^�N���X
                        {
                            for (int j = 0; j < unitPriceCalcParamList.Count; j++) // �P���Z�o���W���[���v�Z�p�p�����[�^
                            {
                                if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[j].GoodsMakerCd) && // ���i���[�J�[
                                    (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[j].GoodsNo) &&           // ���i�ԍ�
                                    (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[j].BLGoodsCode))     // BL���i�R�[�h
                                {
                                    if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                                    {
                                        unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g
                                    }
                                }
                            }
                        }

                        //�����Z�o���� ���s
                        unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

                        // �����Z�o�����ɂ��擾����������
                        // �݌ɗ����f�[�^�N���X�ɃZ�b�g
                        for (int i = 0; i < unitPriceCalcRetList.Count; i++) // �P���v�Z����
                        {
                            for (int j = 0; j < stockHistoryWorkList.Count; j++) // �݌ɗ����f�[�^�N���X
                            {
                                if ((unitPriceCalcRetList[i].GoodsMakerCd == stockHistoryWorkList[j].GoodsMakerCd) && // ���i���[�J�[
                                    (unitPriceCalcRetList[i].GoodsNo == stockHistoryWorkList[j].GoodsNo))     // BL���i�R�[�h
                                {
                                    // �d���P���i�Ŕ��C�����j
                                    stockHistoryWorkList[j].StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                                    // �}�V���݌Ɋz = �݌ɑ��� �~ �d���P��
                                    FracCalc((stockHistoryWorkList[j].StockTotal * stockHistoryWorkList[j].StockUnitPriceFl), 1, FractionProcCd, out calcPrice);
                                    stockHistoryWorkList[j].StockMashinePrice = calcPrice;

                                    // ���Ѝ݌ɋ��z = ���Ѝ݌ɐ� �~�d���P��
                                    FracCalc(stockHistoryWorkList[j].PropertyStockCnt * stockHistoryWorkList[j].StockUnitPriceFl, 1, FractionProcCd, out calcPrice);
                                    stockHistoryWorkList[j].PropertyStockPrice = calcPrice;

                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }
        #endregion

        #region �݌ɔN�Ԏ��яƉ�(÷�ďo�́�Excel�o��)
        /// <summary>
        /// �݌ɔN�Ԏ��яƉ�List�𐶐����܂��B(÷�ďo�́�Excel�o��)
        /// </summary>
        /// <param name="monthlyAddUpWork">�����X�V�p�����[�^</param>
        /// <param name="stockHistoryWorkList">�݌ɗ����X�VList</param>
        /// <param name="msgDiv">�G���[���b�Z�[�W�L���敪</param>
        /// <param name="retMsg">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="warehouseShelfNo">�I��</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌ɔN�Ԏ��яƉ�\����</br>
        /// <br>Programmer : ��ؑn</br>
        /// <br>Date       : 2021.11.10</br>
        /// �݌ɔN�Ԏ��яƉ�p�Ɋ�����MakeStockHistoryNotGetCost()���R�s�[�������\�b�h�B
        /// �q�ɃR�[�h�A�I�ԁA���[�J�[�R�[�h�ABL�R�[�h�A�i�Ԃ��w�肷�邱�ƂŐ��\�����}�����B
        /// </remarks>
        private int MakeStockHistoryPMZAI04100CsvAndExcel(ref MonthlyAddUpWork monthlyAddUpWork,
                                                         ref List<StockHistoryWork> stockHistoryWorkList,
                                                         out bool msgDiv,
                                                         out string retMsg,
                                                         ref SqlConnection sqlConnection,
                                                         List<string> warehouseCode,
                                                         List<string> warehouseShelfNo,
                                                         List<Int32> makerCode,
                                                         List<int> blGoodsCode,
                                                         List<string> goodsNo)
        {

            //��STATUS������
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            msgDiv = false;
            retMsg = null;
            try
            {
                //�݌Ɏ󕥗����f�[�^�W�v & �O�����擾
                status = GetStockAcPayHistPMZAI04100CsvAndExcel(ref monthlyAddUpWork, ref stockHistoryWorkList, ref sqlConnection, warehouseCode, warehouseShelfNo, makerCode, blGoodsCode, goodsNo);

                //���s��STATUS�ł���Ώ����I��
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    msgDiv = true;
                    retMsg = "�݌ɗ����f�[�^���o���ɃG���[���������܂����B�ēx��蒼���Ă��������B";
                    return (int)ConstantManagement.DB_Status.ctDB_WARNING;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MonthlyAddUpDB.MakeMonthlyAddUpParameters Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }


        /// <summary>
        /// �݌Ɏ󕥗����f�[�^���擾���܂�(÷�ďo�́�Excel�o��)
        /// </summary>
        /// <param name="monthlyAddUpWork">�����X�V�p�����[�^�N���X���[�N</param>
        /// <param name="stockHistoryWorkList">�݌Ɏ󕥗����f�[�^List</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="warehouseShelfNo">�I��</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌ɔN�Ԏ��яƉ�\����</br>
        /// <br>Programmer : ��ؑn</br>
        /// <br>Date       : 2021.11.10</br>
        /// �݌ɔN�Ԏ��яƉ�p�Ɋ�����GetStockAcPayHistMain()���R�s�[�������\�b�h
        /// Where��ɑq�ɃR�[�h�A�I�ԁA���[�J�[�R�[�h�ABL�R�[�h�A�i�Ԃ��w�肷�邱�ƂŁA���\�����}�����B
        /// </remarks>
        private int GetStockAcPayHistPMZAI04100CsvAndExcel(ref MonthlyAddUpWork monthlyAddUpWork,
                                                           ref List<StockHistoryWork> stockHistoryWorkList,
                                                           ref SqlConnection sqlConnection,
                                                           List<string> warehouseCode,
                                                           List<string> warehouseShelfNo,
                                                           List<Int32> makerCode,
                                                           List<int> blGoodsCode,
                                                           List<string> goodsNo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            SqlDataReader myReader = null;

            string sqlText = string.Empty;
            // �d����擾�p
            GoodsSupplierGetter goodsSupplierGetter = new GoodsSupplierGetter();
            List<GoodsSupplierDataWork> GoodsSupplierDataWorkList = new List<GoodsSupplierDataWork>();

            // �����Z�o�p
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            List<UnitPriceCalcParamWork> unitPriceCalcParamList = new List<UnitPriceCalcParamWork>(); // �����v�Z�p�����[�^�I�u�W�F�N�g���X�g
            List<GoodsUnitDataWork> goodsUnitDataList = new List<GoodsUnitDataWork>();                // ���i�A���f�[�^�I�u�W�F�N�g���X�g
            List<UnitPriceCalcRetWork> unitPriceCalcRetList = new List<UnitPriceCalcRetWork>();       // �����v�Z���ʃ��X�g 

            int FractionProcCd = 0;
            long calcPrice = 0;

            try
            {
                #region SELECT��
                sqlText += "  SELECT" + Environment.NewLine;
                sqlText += "   STOCKHISTORYPAY.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "   STOCKHISTORYPAY.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "   WARE.WAREHOUSENAMERF," + Environment.NewLine;
                sqlText += "   '00' AS SECTIONCODERF," + Environment.NewLine;
                sqlText += "   STOCKHISTORYPAY.GOODSNORF," + Environment.NewLine;
                sqlText += "   GOODS.GOODSNAMERF," + Environment.NewLine;
                sqlText += "   STOCKHISTORYPAY.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "   MAKER.MAKERNAMERF," + Environment.NewLine;
                sqlText += "   STOCKHIS.LMONTHSTOCKCNTRF,--�O�����݌ɐ�" + Environment.NewLine;
                sqlText += "   STOCKHIS.LMONTHSTOCKPRICERF,--�O�����݌Ɋz" + Environment.NewLine;
                sqlText += "   STOCKHIS.LMONTHPPTYSTOCKCNTRF,--�O�������Ѝ݌ɐ�" + Environment.NewLine;
                sqlText += "   STOCKHIS.LMONTHPPTYSTOCKPRICERF,--�O�������Ѝ݌ɋ��z  " + Environment.NewLine;
                sqlText += "   STOCKHACCNT.SALESTIMESRF,--�����" + Environment.NewLine;
                sqlText += "   STOCKHAC.SALESCOUNTRF,--���㐔" + Environment.NewLine;
                sqlText += "   STOCKHAC.SALESMONEYTAXEXCRF,--������z�i�Ŕ����j " + Environment.NewLine;
                sqlText += "   STOCKHACCNT.SALESRETGOODSTIMESRF,--����ԕi��" + Environment.NewLine;
                sqlText += "   STOCKHAC.SALESRETGOODSCNTRF,--����ԕi��" + Environment.NewLine;
                sqlText += "   STOCKHAC.SALESRETGOODSPRICERF,--����ԕi�z" + Environment.NewLine;
                sqlText += "   STOCKHAC.GROSSPROFITRF,--�e�����z" + Environment.NewLine;
                sqlText += "   STOCKHACCNT.STOCKTIMESRF,--�d����" + Environment.NewLine;
                sqlText += "   STOCKHAC.STOCKCOUNTRF,--�d����  " + Environment.NewLine;
                sqlText += "   STOCKHAC.STOCKPRICETAXEXCRF,--�d�����z�i�Ŕ����j " + Environment.NewLine;
                sqlText += "   STOCKHACCNT.STOCKRETGOODSTIMESRF,--�d���ԕi��" + Environment.NewLine;
                sqlText += "   STOCKHAC.STOCKRETGOODSCNTRF,--�d���ԕi��" + Environment.NewLine;
                sqlText += "   STOCKHAC.STOCKRETGOODSPRICERF,--�d���ԕi�z " + Environment.NewLine;
                sqlText += "   STOCKHAC.MOVEARRIVALCNTRF,--�ړ����א�" + Environment.NewLine;
                sqlText += "   STOCKHAC.MOVEARRIVALPRICERF,--�ړ����׊z" + Environment.NewLine;
                sqlText += "   STOCKHAC.MOVESHIPMENTCNTRF,--�ړ��o�א�" + Environment.NewLine;
                sqlText += "   STOCKHAC.MOVESHIPMENTPRICERF,--�ړ��o�׊z" + Environment.NewLine;
                sqlText += "   (STOCKHAC.ADJUSTCOUNTRF1 - STOCKHAC.ADJUSTCOUNTRF2) AS ADJUSTCOUNTRF,--������" + Environment.NewLine;
                sqlText += "   (STOCKHAC.ADJUSTPRICERF1 - STOCKHAC.ADJUSTPRICERF2) AS ADJUSTPRICERF,--�������z" + Environment.NewLine;
                sqlText += "   STOCKHAC.ARRIVALCNTRF,--���א�" + Environment.NewLine;
                sqlText += "   STOCKHAC.ARRIVALPRICERF,--���׋��z" + Environment.NewLine;
                sqlText += "   STOCKHAC.SHIPMENTCNTRF,--�o�א�" + Environment.NewLine;
                sqlText += "   STOCKHAC.SHIPMENTPRICERF,--�o�׋��z" + Environment.NewLine;
                sqlText += "   STOCKHAC.TOTALARRIVALCNTRF,--�����א�" + Environment.NewLine;
                sqlText += "   STOCKHAC.TOTALARRIVALPRICERF,--�����׋��z" + Environment.NewLine;
                sqlText += "   STOCKHAC.TOTALSHIPMENTCNTRF,--���o�א�" + Environment.NewLine;
                sqlText += "   STOCKHAC.TOTALSHIPMENTPRICERF,--���o�׋��z   " + Environment.NewLine;
                sqlText += "   GOODS.BLGOODSCODERF,  -- BL���i�R�[�h" + Environment.NewLine;
                sqlText += "   BL.BLGOODSHALFNAMERF, -- BL���i�R�[�h���́i���p�j" + Environment.NewLine;
                sqlText += "   BL.BLGROUPCODERF, -- BL�O���[�v�R�[�h" + Environment.NewLine;
                sqlText += "   BLG.GOODSMGROUPRF, -- ���i������" + Environment.NewLine;
                sqlText += "   STOCKMNGTTL.FRACTIONPROCCDRF -- �[�������敪" + Environment.NewLine;
                sqlText += "   ,STOCK.STOCKCREATEDATE -- �݌ɓo�^��" + Environment.NewLine;
                sqlText += "   ,STOCK.LASTSALESDATE -- �ŏI�����" + Environment.NewLine;
                sqlText += "   ,STOCK.LASTSTOCKDATE -- �ŏI�d����" + Environment.NewLine;
                sqlText += "   ,STOCK.WAREHOUSESHELFNO -- �I��" + Environment.NewLine;
                sqlText += "   ,STOCK.WAREHOUSECODE --�q�ɃR�[�h" + Environment.NewLine;
                sqlText += "  FROM" + Environment.NewLine;

                #region SUB�N�G��

                #region �O���݌ɗ����ƍ݌Ɏ󕥃f�[�^���猋��KEY���擾
                sqlText += "  (" + Environment.NewLine;
                sqlText += "    SELECT DISTINCT" + Environment.NewLine;
                sqlText += "     ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "     WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "     GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "     GOODSNORF" + Environment.NewLine;
                sqlText += "    FROM" + Environment.NewLine;
                sqlText += "     STOCKHISTORYRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "     AND LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "     AND ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                {
                    sqlText += "     AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "    UNION SELECT DISTINCT" + Environment.NewLine;
                sqlText += "     ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "     WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "     GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "     GOODSNORF" + Environment.NewLine;
                sqlText += "    FROM" + Environment.NewLine;
                sqlText += "     STOCKACPAYHISTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                {
                    sqlText += "     AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "     AND LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "     AND( ( CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END ) >= @FINDADDUPDATEST  AND (CASE WHEN ADDUPADATERF IS NULL THEN IOGOODSDAYRF ELSE ADDUPADATERF END )   <=@FINDADDUPDATEED)" + Environment.NewLine;
                sqlText += "  ) AS STOCKHISTORYPAY" + Environment.NewLine;
                #endregion

                #region �݌ɊǗ��S�̐ݒ�}�X�^ ����
                sqlText += "  --�݌ɊǗ��S�̐ݒ�}�X�^ ����" + Environment.NewLine;
                sqlText += "  LEFT JOIN STOCKMNGTTLSTRF AS STOCKMNGTTL WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "   ON STOCKHISTORYPAY.ENTERPRISECODERF = STOCKMNGTTL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "   AND STOCKMNGTTL.SECTIONCODERF = '00'" + Environment.NewLine;
                #endregion

                #region �݌Ƀ}�X�^ ����
                sqlText += "  --�݌Ƀ}�X�^ ����" + Environment.NewLine;
                sqlText += "  LEFT JOIN ( " + Environment.NewLine;
                sqlText += "  SELECT " + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF AS ENTERPRISECODE " + Environment.NewLine;
                sqlText += "  ,SECTIONCODERF AS SECTIONCODE " + Environment.NewLine;
                sqlText += "  ,WAREHOUSECODERF AS WAREHOUSECODE " + Environment.NewLine;
                sqlText += "  ,WAREHOUSESHELFNORF AS WAREHOUSESHELFNO " + Environment.NewLine;
                sqlText += "  ,GOODSMAKERCDRF AS GOODSMAKERCD " + Environment.NewLine;
                sqlText += "  ,GOODSNORF AS GOODSNO " + Environment.NewLine;
                sqlText += "  ,STOCKSUPPLIERCODERF AS STOCKSUPPLIERCODE " + Environment.NewLine;
                sqlText += "  ,STOCKCREATEDATERF AS STOCKCREATEDATE " + Environment.NewLine;
                sqlText += "  ,LASTSALESDATERF AS LASTSALESDATE " + Environment.NewLine;
                sqlText += "  ,LASTSTOCKDATERF AS LASTSTOCKDATE " + Environment.NewLine;
                sqlText += "  FROM " + Environment.NewLine;
                sqlText += "  STOCKRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "  WHERE " + Environment.NewLine;
                sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "  AND LOGICALDELETECODERF=0 " + Environment.NewLine;
                sqlText += "  ) AS STOCK " + Environment.NewLine;
                sqlText += "  ON " + Environment.NewLine;
                sqlText += "  STOCKHISTORYPAY.ENTERPRISECODERF = STOCK.ENTERPRISECODE " + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.WAREHOUSECODERF = STOCK.WAREHOUSECODE " + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSMAKERCDRF = STOCK.GOODSMAKERCD " + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSNORF = STOCK.GOODSNO  " + Environment.NewLine;
                #endregion

                #region �݌Ɏ󕥃f�[�^�W�v��� ����
                sqlText += "  LEFT JOIN " + Environment.NewLine;
                sqlText += "  ( " + Environment.NewLine;
                sqlText += "   SELECT" + Environment.NewLine;
                sqlText += "    STPAY.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "    STPAY.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "    STPAY.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "    STPAY.GOODSNORF," + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=10  ) ) THEN STPAY.SHIPMENTCNTRF + STPAY.DELSHIPMENTCNTRF ELSE 0 END) AS SALESCOUNTRF,--���㐔" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=10 ) ) THEN STPAY.SALESMONEYRF + STPAY.DELSALESMONEYRF ELSE 0 END) AS SALESMONEYTAXEXCRF,--������z�i�Ŕ����j" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20 ) ) THEN 1 ELSE 0 END) AS SALESRETGOODSTIMESRF,--����ԕi��" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20 ) ) THEN STPAY.SHIPMENTCNTRF + STPAY.DELSHIPMENTCNTRF ELSE 0 END) AS SALESRETGOODSCNTRF,--����ԕi��" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20 ) ) THEN STPAY.SALESMONEYRF + STPAY.DELSALESMONEYRF ELSE 0 END) AS SALESRETGOODSPRICERF,--����ԕi�z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 AND (STPAY.ACPAYTRANSCDRF=10 OR STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20 ) ) THEN ((STPAY.SALESMONEYRF+STPAY.DELSALESMONEYRF) - (STPAY.STOCKPRICERF +STPAY.DELSTOCKPRICERF)) ELSE 0 END) AS GROSSPROFITRF,--�e�����z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN ((STPAY.ACPAYSLIPCDRF=10 AND (STPAY.ACPAYTRANSCDRF=10 OR STPAY.ACPAYTRANSCDRF=21))OR(STPAY.ACPAYSLIPCDRF=13 AND (STPAY.ACPAYTRANSCDRF=10 OR STPAY.ACPAYTRANSCDRF=30)) ) THEN STPAY.ARRIVALCNTRF+STPAY.DELARRIVALCNTRF ELSE 0 END) AS STOCKCOUNTRF,--�d����" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN ((STPAY.ACPAYSLIPCDRF=10 AND (STPAY.ACPAYTRANSCDRF=10 OR STPAY.ACPAYTRANSCDRF=21))OR(STPAY.ACPAYSLIPCDRF=13 AND (STPAY.ACPAYTRANSCDRF=10 OR STPAY.ACPAYTRANSCDRF=30)) ) THEN STPAY.STOCKPRICERF+STPAY.DELSTOCKPRICERF ELSE 0 END) AS STOCKPRICETAXEXCRF,--�d�����z�i�Ŕ����j" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=10 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20 OR STPAY.ACPAYTRANSCDRF=21)) THEN 1 ELSE 0 END) AS STOCKRETGOODSTIMESRF,--�d���ԕi��  " + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=10 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20) ) THEN STPAY.ARRIVALCNTRF+STPAY.DELARRIVALCNTRF ELSE 0 END) AS STOCKRETGOODSCNTRF,--�d���ԕi��" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=10 AND (STPAY.ACPAYTRANSCDRF=11 OR STPAY.ACPAYTRANSCDRF=20) ) THEN STPAY.STOCKPRICERF+STPAY.DELSTOCKPRICERF ELSE 0 END) AS STOCKRETGOODSPRICERF,--�d���ԕi�z " + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=31) THEN STPAY.ARRIVALCNTRF + STPAY.DELARRIVALCNTRF ELSE 0 END) AS MOVEARRIVALCNTRF,--�ړ����א�" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=31) THEN STPAY.STOCKPRICERF + STPAY.DELSTOCKPRICERF ELSE 0 END) AS MOVEARRIVALPRICERF,--�ړ����׊z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=30) THEN STPAY.SHIPMENTCNTRF + STPAY.DELSHIPMENTCNTRF ELSE 0 END) AS MOVESHIPMENTCNTRF,--�ړ��o�א�" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=30) THEN STPAY.SALESMONEYRF + STPAY.DELSALESMONEYRF ELSE 0 END) AS MOVESHIPMENTPRICERF,--�ړ��o�׊z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=42 OR STPAY.ACPAYSLIPCDRF=50 OR " + Environment.NewLine;
                sqlText += "                   STPAY.ACPAYSLIPCDRF=60 OR STPAY.ACPAYSLIPCDRF=61 OR STPAY.ACPAYSLIPCDRF=70) THEN STPAY.ARRIVALCNTRF ELSE 0 END) AS ADJUSTCOUNTRF1,--������1" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=71) THEN STPAY.SHIPMENTCNTRF ELSE 0 END) AS ADJUSTCOUNTRF2,--������2" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=42 OR STPAY.ACPAYSLIPCDRF=50 OR " + Environment.NewLine;
                sqlText += "                   STPAY.ACPAYSLIPCDRF=60 OR STPAY.ACPAYSLIPCDRF=61 OR STPAY.ACPAYSLIPCDRF=70) THEN STPAY.STOCKPRICERF ELSE 0 END) AS ADJUSTPRICERF1,--�������z1" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=71) THEN STPAY.SALESMONEYRF ELSE 0 END) AS ADJUSTPRICERF2,--�������z2  " + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=11) THEN STPAY.ARRIVALCNTRF ELSE 0 END) AS ARRIVALCNTRF,--���א�" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=11) THEN STPAY.STOCKPRICERF ELSE 0 END) AS ARRIVALPRICERF,--���׋��z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=22) THEN STPAY.SHIPMENTCNTRF ELSE 0 END) AS SHIPMENTCNTRF,--�o�א�" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=22) THEN STPAY.SALESMONEYRF ELSE 0 END) AS SHIPMENTPRICERF,--�o�׋��z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=10 OR STPAY.ACPAYSLIPCDRF=11 OR STPAY.ACPAYSLIPCDRF=13 OR STPAY.ACPAYSLIPCDRF=31) THEN STPAY.ARRIVALCNT2RF + STPAY.DELARRIVALCNT2RF ELSE 0 END) AS TOTALARRIVALCNTRF,--�����א�" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=10 OR STPAY.ACPAYSLIPCDRF=11 OR STPAY.ACPAYSLIPCDRF=13 OR STPAY.ACPAYSLIPCDRF=31) THEN STPAY.STOCKPRICE2RF + STPAY.DELSTOCKPRICE2RF ELSE 0 END) AS TOTALARRIVALPRICERF,--�����׋��z" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 OR STPAY.ACPAYSLIPCDRF=22 OR STPAY.ACPAYSLIPCDRF=30) THEN STPAY.SHIPMENTCNT2RF + STPAY.DELSHIPMENTCNT2RF ELSE 0 END) AS TOTALSHIPMENTCNTRF,--���o�א�" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAY.ACPAYSLIPCDRF=20 OR STPAY.ACPAYSLIPCDRF=22 OR STPAY.ACPAYSLIPCDRF=30) THEN STPAY.SALESMONEY2RF + STPAY.DELSALESMONEY2RF ELSE 0 END) AS TOTALSHIPMENTPRICERF --���o�׋��z " + Environment.NewLine;
                sqlText += "   FROM" + Environment.NewLine;
                sqlText += "   (" + Environment.NewLine;
                sqlText += "    select" + Environment.NewLine;
                sqlText += "      STACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "      STACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "      STACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "      STACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "      STACPAYHIST.GOODSNORF," + Environment.NewLine;
                sqlText += "      STACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                sqlText += "      STACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                sqlText += "      STACPAYHIST.ACPAYTRANSCDRF, --�󕥌�����敪" + Environment.NewLine;
                sqlText += "      STACPAYHIST.ARRIVALCNTRF ,   --���א�" + Environment.NewLine;
                sqlText += "      STACPAYHIST.SHIPMENTCNTRF,  --�o�א�" + Environment.NewLine;
                sqlText += "      STACPAYHIST.STOCKPRICERF,   --�d�����z" + Environment.NewLine;
                sqlText += "      STACPAYHIST.SALESMONEYRF,    --������z      " + Environment.NewLine;
                sqlText += "      STACPAYHIST.ARRIVALCNT2RF,   --�����v�p���א�" + Environment.NewLine;
                sqlText += "      STACPAYHIST.SHIPMENTCNT2RF,  --�����v�p�o�א�" + Environment.NewLine;
                sqlText += "      STACPAYHIST.STOCKPRICE2RF,   --�����v�p�d�����z" + Environment.NewLine;
                sqlText += "      STACPAYHIST.SALESMONEY2RF,   --�����v�p������z      " + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.ACPAYTRANSCDRF IS NULL THEN 0 ELSE STACPAYHISTDEL.ACPAYTRANSCDRF END)  AS DELACPAYTRANSCDRF,--�󕥌�����敪" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.ARRIVALCNTRF IS NULL THEN 0 ELSE STACPAYHISTDEL.ARRIVALCNTRF END ) AS DELARRIVALCNTRF,      --���א�" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.SHIPMENTCNTRF IS NULL THEN 0 ELSE STACPAYHISTDEL.SHIPMENTCNTRF END ) AS DELSHIPMENTCNTRF,   --�o�א�" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.STOCKPRICERF IS NULL THEN 0 ELSE STACPAYHISTDEL.STOCKPRICERF END ) AS DELSTOCKPRICERF,      --�d�����z" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.SALESMONEYRF IS NULL THEN 0 ELSE STACPAYHISTDEL.SALESMONEYRF END) AS DELSALESMONEYRF,       --������z     " + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.ARRIVALCNT2RF IS NULL THEN 0 ELSE STACPAYHISTDEL.ARRIVALCNT2RF END)  AS DELARRIVALCNT2RF, --�����v�p���א�" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.SHIPMENTCNT2RF IS NULL THEN 0 ELSE STACPAYHISTDEL.SHIPMENTCNT2RF END ) AS DELSHIPMENTCNT2RF, --�����v�p�o�א�" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.STOCKPRICE2RF IS NULL THEN 0 ELSE STACPAYHISTDEL.STOCKPRICE2RF END ) AS DELSTOCKPRICE2RF,  --�����v�p�d�����z" + Environment.NewLine;
                sqlText += "      (CASE WHEN STACPAYHISTDEL.SALESMONEY2RF IS NULL THEN 0 ELSE STACPAYHISTDEL.SALESMONEY2RF END ) AS DELSALESMONEY2RF    --�����v�p������z" + Environment.NewLine;
                sqlText += "    from" + Environment.NewLine;
                sqlText += "    (" + Environment.NewLine;
                sqlText += "     SELECT" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYTRANSCDRF, --�󕥌�����敪" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.ARRIVALCNTRF) AS ARRIVALCNTRF ,   --���א�" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.SHIPMENTCNTRF) AS SHIPMENTCNTRF,  --�o�א�" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.STOCKPRICERF) AS STOCKPRICERF,   --�d�����z" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.SALESMONEYRF) AS SALESMONEYRF,    --������z" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 10 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.ARRIVALCNTRF END)) AS ARRIVALCNT2RF,   --�����v�p���א�" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 20 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.SHIPMENTCNTRF END))AS SHIPMENTCNT2RF,  --�����v�p�o�א�" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 10 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.STOCKPRICERF END)) AS STOCKPRICE2RF,   --�����v�p�d�����z" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 20 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.SALESMONEYRF END)) AS SALESMONEY2RF   --�����v�p������z" + Environment.NewLine;
                sqlText += "     FROM" + Environment.NewLine;
                sqlText += "      STOCKACPAYHISTRF AS STOCKACPAYHIST WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "     WHERE " + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHIST.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "     AND( ( CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END ) >= @FINDADDUPDATEST  AND (CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END )<=@FINDADDUPDATEED)" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHIST.ACPAYTRANSCDRF  != 21" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHIST.ACPAYTRANSCDRF  != 90" + Environment.NewLine;
                if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                {
                    sqlText += "      AND STOCKACPAYHIST.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "     GROUP BY" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYTRANSCDRF --�󕥌�����敪" + Environment.NewLine;
                sqlText += "     ) AS STACPAYHIST" + Environment.NewLine;
                sqlText += "     LEFT JOIN" + Environment.NewLine;
                sqlText += "     (" + Environment.NewLine;
                sqlText += "     SELECT" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYTRANSCDRF, --�󕥌�����敪" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.ARRIVALCNTRF) AS ARRIVALCNTRF ,   --���א�" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.SHIPMENTCNTRF) AS SHIPMENTCNTRF,  --�o�א�" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.STOCKPRICERF) AS STOCKPRICERF,   --�d�����z" + Environment.NewLine;
                sqlText += "      SUM(STOCKACPAYHIST.SALESMONEYRF) AS SALESMONEYRF,    --������z" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 10 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.ARRIVALCNTRF END)) AS ARRIVALCNT2RF,   --�����v�p���א�" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 20 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.SHIPMENTCNTRF END))AS SHIPMENTCNT2RF,  --�����v�p�o�א�" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 10 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.STOCKPRICERF END)) AS STOCKPRICE2RF,   --�����v�p�d�����z" + Environment.NewLine;
                sqlText += "      SUM((CASE WHEN STOCKACPAYHIST.ACPAYSLIPCDRF = 20 AND STOCKACPAYHIST.IOGOODSDAYRF IS NULL THEN 0 ELSE STOCKACPAYHIST.SALESMONEYRF END)) AS SALESMONEY2RF   --�����v�p������z" + Environment.NewLine;
                sqlText += "     FROM" + Environment.NewLine;
                sqlText += "      STOCKACPAYHISTRF AS STOCKACPAYHIST WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "     WHERE " + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "      AND STOCKACPAYHIST.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "     AND( ( CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END ) >= @FINDADDUPDATEST  AND (CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END )<=@FINDADDUPDATEED)" + Environment.NewLine;
                sqlText += "      AND (STOCKACPAYHIST.ACPAYTRANSCDRF  = 21 OR STOCKACPAYHIST.ACPAYTRANSCDRF  = 90)" + Environment.NewLine;
                if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                {
                    sqlText += "      AND STOCKACPAYHIST.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "     GROUP BY" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPNUMRF, --�󕥌��`�[�ԍ�" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                sqlText += "      STOCKACPAYHIST.ACPAYTRANSCDRF --�󕥌�����敪" + Environment.NewLine;
                sqlText += "     ) AS STACPAYHISTDEL" + Environment.NewLine;
                sqlText += "     ON STACPAYHIST.ENTERPRISECODERF = STACPAYHISTDEL.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += "     AND STACPAYHIST.WAREHOUSECODERF = STACPAYHISTDEL.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "     AND STACPAYHIST.GOODSMAKERCDRF = STACPAYHISTDEL.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "     AND STACPAYHIST.GOODSNORF = STACPAYHISTDEL.GOODSNORF" + Environment.NewLine;
                sqlText += "     AND STACPAYHIST.ACPAYSLIPNUMRF = STACPAYHISTDEL.ACPAYSLIPNUMRF" + Environment.NewLine;
                sqlText += "     AND STACPAYHIST.ACPAYSLIPCDRF = STACPAYHISTDEL.ACPAYSLIPCDRF    " + Environment.NewLine;
                sqlText += "    )AS STPAY" + Environment.NewLine;
                sqlText += "    GROUP  BY" + Environment.NewLine;
                sqlText += "     STPAY.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "     STPAY.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "     STPAY.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "     STPAY.GOODSNORF" + Environment.NewLine;
                sqlText += "  ) AS STOCKHAC" + Environment.NewLine;
                sqlText += "  ON  STOCKHISTORYPAY.ENTERPRISECODERF = STOCKHAC.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.WAREHOUSECODERF = STOCKHAC.WAREHOUSECODERF" + Environment.NewLine;
                //sqlText += "  AND STOCKHISTORYPAY.SECTIONCODERF = STOCKHAC.SECTIONCODERF" + Environment.NewLine; // DEL 2009/04/02
                sqlText += "  AND STOCKHISTORYPAY.GOODSMAKERCDRF = STOCKHAC.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSNORF = STOCKHAC.GOODSNORF" + Environment.NewLine;

                #endregion �݌Ɏ󕥃f�[�^�W�v��� ����

                #region �݌Ɏ󕥃f�[�^�W�v���( �����,�d����)�@����
                sqlText += "  LEFT JOIN " + Environment.NewLine;
                sqlText += "  (" + Environment.NewLine;
                sqlText += "   SELECT" + Environment.NewLine;
                sqlText += "    STPAYCNT.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "    STPAYCNT.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "    STPAYCNT.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "    STPAYCNT.GOODSNORF," + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN ((STPAYCNT.ACPAYSLIPCDRF=20 AND STPAYCNT.ACPAYTRANSCDRF=10) AND DELSLIPNUM IS NULL) THEN 1 ELSE 0 END) AS SALESTIMESRF,--�����" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAYCNT.ACPAYSLIPCDRF=20 AND (STPAYCNT.ACPAYTRANSCDRF=11 OR STPAYCNT.ACPAYTRANSCDRF=20)AND DELSLIPNUM IS NULL ) THEN 1 ELSE 0 END) AS SALESRETGOODSTIMESRF,--����ԕi��" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN ((STPAYCNT.ACPAYSLIPCDRF=10 AND STPAYCNT.ACPAYTRANSCDRF=10 AND DELSLIPNUM IS NULL) OR (STPAYCNT.ACPAYSLIPCDRF=13 AND( STPAYCNT.ACPAYTRANSCDRF=10 OR STPAYCNT.ACPAYTRANSCDRF=30)AND DELSLIPNUM IS NULL )) THEN 1 ELSE 0 END) AS STOCKTIMESRF, --�d����" + Environment.NewLine;
                sqlText += "    SUM(CASE WHEN (STPAYCNT.ACPAYSLIPCDRF=10 AND (STPAYCNT.ACPAYTRANSCDRF=11 OR STPAYCNT.ACPAYTRANSCDRF=20)AND DELSLIPNUM IS NULL ) THEN 1 ELSE 0 END) AS STOCKRETGOODSTIMESRF--�d���ԕi��" + Environment.NewLine;
                sqlText += "   FROM  " + Environment.NewLine;
                sqlText += "   (" + Environment.NewLine;
                sqlText += "      SELECT " + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.ACPAYSLIPNUMRF, --�`�[�ԍ�" + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                sqlText += "       STOCKACPAYHIST.ACPAYTRANSCDRF,  --�󕥌�����敪" + Environment.NewLine;
                sqlText += "       DELSTOCKACPAYHIST.ACPAYSLIPNUMRF AS DELSLIPNUM --�`�[�ԍ�" + Environment.NewLine;
                sqlText += "      FROM" + Environment.NewLine;
                sqlText += "       STOCKACPAYHISTRF AS STOCKACPAYHIST WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "     LEFT JOIN" + Environment.NewLine;
                sqlText += "      (" + Environment.NewLine;
                sqlText += "        SELECT" + Environment.NewLine;
                sqlText += "         LOGICALDELETECODERF," + Environment.NewLine;
                sqlText += "         ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "         WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "         GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "         GOODSNORF," + Environment.NewLine;
                sqlText += "         ACPAYSLIPNUMRF --�󕥌��`�[�ԍ�" + Environment.NewLine;
                sqlText += "        FROM" + Environment.NewLine;
                sqlText += "         STOCKACPAYHISTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "        WHERE" + Environment.NewLine;
                sqlText += "         ENTERPRISECODERF=@FINDENTERPRISECODE AND " + Environment.NewLine;
                sqlText += "         LOGICALDELETECODERF=0 AND " + Environment.NewLine;
                sqlText += "         ACPAYTRANSCDRF = 21 " + Environment.NewLine;
                sqlText += "      ) AS DELSTOCKACPAYHIST" + Environment.NewLine;
                sqlText += "       ON  STOCKACPAYHIST.ENTERPRISECODERF = DELSTOCKACPAYHIST.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "       AND STOCKACPAYHIST.WAREHOUSECODERF = DELSTOCKACPAYHIST.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "       AND STOCKACPAYHIST.GOODSMAKERCDRF = DELSTOCKACPAYHIST.GOODSMAKERCDRF " + Environment.NewLine;
                sqlText += "       AND STOCKACPAYHIST.GOODSNORF = DELSTOCKACPAYHIST.GOODSNORF" + Environment.NewLine;
                sqlText += "       AND STOCKACPAYHIST.ACPAYSLIPNUMRF = DELSTOCKACPAYHIST.ACPAYSLIPNUMRF          " + Environment.NewLine;
                sqlText += "      WHERE STOCKACPAYHIST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                {
                    sqlText += "       AND STOCKACPAYHIST.SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "       AND STOCKACPAYHIST.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "     AND( ( CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END ) >= @FINDADDUPDATEST  AND (CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END )<=@FINDADDUPDATEED)" + Environment.NewLine;                //ADD by Liangsd     2011/08/23
                sqlText += "   ) AS STPAYCNT" + Environment.NewLine;
                sqlText += "   GROUP BY" + Environment.NewLine;
                sqlText += "    STPAYCNT.ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "    STPAYCNT.WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "    STPAYCNT.GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "    STPAYCNT.GOODSNORF" + Environment.NewLine;
                sqlText += "  ) AS STOCKHACCNT" + Environment.NewLine;
                sqlText += "   ON  STOCKHISTORYPAY.ENTERPRISECODERF = STOCKHACCNT.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "   AND STOCKHISTORYPAY.WAREHOUSECODERF = STOCKHACCNT.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "   AND STOCKHISTORYPAY.GOODSMAKERCDRF = STOCKHACCNT.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "   AND STOCKHISTORYPAY.GOODSNORF = STOCKHACCNT.GOODSNORF" + Environment.NewLine;
                #endregion

                #region �݌ɗ����}�X�^�O����� ����
                sqlText += "  LEFT JOIN" + Environment.NewLine;
                sqlText += "  (" + Environment.NewLine;
                sqlText += "    SELECT " + Environment.NewLine;
                sqlText += "     ENTERPRISECODERF," + Environment.NewLine;
                sqlText += "     WAREHOUSECODERF," + Environment.NewLine;
                sqlText += "     GOODSMAKERCDRF," + Environment.NewLine;
                sqlText += "     GOODSNORF," + Environment.NewLine;
                sqlText += "     STOCKTOTALRF AS LMONTHSTOCKCNTRF,--�O�����݌ɐ�" + Environment.NewLine;
                sqlText += "     STOCKMASHINEPRICERF AS LMONTHSTOCKPRICERF,--�O�����݌Ɋz" + Environment.NewLine;
                sqlText += "     PROPERTYSTOCKCNTRF AS LMONTHPPTYSTOCKCNTRF,--�O�������Ѝ݌ɐ�" + Environment.NewLine;
                sqlText += "     PROPERTYSTOCKPRICERF AS LMONTHPPTYSTOCKPRICERF,--�O�������Ѝ݌ɋ��z" + Environment.NewLine;
                sqlText += "     STOCKUNITPRICEFLRF AS STOCKUNITPRICEFLRF --�d���P��" + Environment.NewLine;
                sqlText += "    FROM" + Environment.NewLine;
                sqlText += "     STOCKHISTORYRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "    WHERE ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                sqlText += "     AND LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += "     AND ADDUPYEARMONTHRF=@ADDUPYEARMONTH" + Environment.NewLine;
                if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                {
                    sqlText += "     AND SECTIONCODERF=@FINDSECTIONCODE" + Environment.NewLine;
                }
                sqlText += "  ) AS STOCKHIS" + Environment.NewLine;
                sqlText += "  ON  STOCKHISTORYPAY.ENTERPRISECODERF = STOCKHIS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.WAREHOUSECODERF = STOCKHIS.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSMAKERCDRF = STOCKHIS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSNORF = STOCKHIS.GOODSNORF" + Environment.NewLine;
                #endregion �O����� ����

                #endregion

                #region JOIN��
                sqlText += " LEFT JOIN MAKERURF AS MAKER WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "  ON  STOCKHISTORYPAY.ENTERPRISECODERF = MAKER.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSMAKERCDRF = MAKER.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  AND MAKER.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += " LEFT JOIN  WAREHOUSERF AS WARE WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "  ON STOCKHISTORYPAY.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.WAREHOUSECODERF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                sqlText += "  AND WARE.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += " LEFT JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED)" + Environment.NewLine;
                sqlText += "  ON  STOCKHISTORYPAY.ENTERPRISECODERF = GOODS.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSMAKERCDRF = GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                sqlText += "  AND STOCKHISTORYPAY.GOODSNORF = GOODS.GOODSNORF" + Environment.NewLine;
                sqlText += "  AND GOODS.LOGICALDELETECODERF=0" + Environment.NewLine;
                sqlText += " LEFT JOIN BLGOODSCDURF AS BL WITH (READUNCOMMITTED) -- BL�}�X�^" + Environment.NewLine;
                sqlText += "  ON  STOCKHISTORYPAY.ENTERPRISECODERF = BL.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND GOODS.BLGOODSCODERF = BL.BLGOODSCODERF" + Environment.NewLine;
                sqlText += "  AND BL.LOGICALDELETECODERF = 0" + Environment.NewLine;
                sqlText += " LEFT JOIN BLGROUPURF AS BLG WITH (READUNCOMMITTED) -- BL�O���[�v�R�[�h�}�X�^" + Environment.NewLine;
                sqlText += "  ON STOCKHISTORYPAY.ENTERPRISECODERF = BLG.ENTERPRISECODERF" + Environment.NewLine;
                sqlText += "  AND BL.BLGROUPCODERF = BLG.BLGROUPCODERF" + Environment.NewLine;
                #endregion

                #region WHERE��
                sqlText += @" WHERE
  STOCK.WAREHOUSECODE IS NOT NULL 
  AND WARE.WAREHOUSENAMERF IS NOT NULL
  AND MAKER.MAKERNAMERF IS NOT NULL
  AND GOODS.GOODSNAMERF IS NOT NULL
  AND (GOODS.BLGOODSCODERF = 0 OR BL.BLGOODSHALFNAMERF IS NOT NULL)";
                #endregion

                #endregion

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))
                {

                    #region ���o�����̐ݒ�
                    List<string> whereSql = new List<string>();

                    // �q�ɃR�[�h��Where��쐬
                    string whereWarehouse = MakeWhereWarehouse(warehouseCode, sqlCommand);
                    if (whereWarehouse != string.Empty) whereSql.Add(whereWarehouse);
                    // �I�ԃR�[�h��Where��쐬
                    string whereWarehouseShelfNo = MakeWhereWarehouseShelfNo(warehouseShelfNo, sqlCommand);
                    if (whereWarehouseShelfNo != string.Empty) whereSql.Add(whereWarehouseShelfNo);
                    // ���[�J�[�R�[�h��Where��쐬
                    string whereMakerCode = MakeWhereMakerCode(makerCode, sqlCommand);
                    if (whereMakerCode != string.Empty) whereSql.Add(whereMakerCode);
                    // BL�R�[�h��Where��쐬
                    string whereBlGoodsCode = MakeWhereBlGoodsCode(blGoodsCode, sqlCommand);
                    if (whereBlGoodsCode != String.Empty) whereSql.Add(whereBlGoodsCode);
                    // �i�Ԃ�Where��쐬
                    string whereGoodsNo = MakeWhereGoodsNo(goodsNo, sqlCommand);
                    if (whereGoodsNo != string.Empty) whereSql.Add(whereGoodsNo);

                    //�����������w�肳��Ă��Ȃ��ꍇ�AWhere����쐬���Ȃ�
                    if (whereSql.Count != 0)
                    {
                        sqlText += " AND " + Environment.NewLine;
                        sqlText += string.Join(" AND "+ Environment.NewLine, whereSql.ToArray());
                    }
                    #endregion

                    #region Prameter�I�u�W�F�N�g�̍쐬
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    SqlParameter findParaAddUpDateSt = sqlCommand.Parameters.Add("@FINDADDUPDATEST", SqlDbType.Int);
                    SqlParameter findParaAddUpDateEd = sqlCommand.Parameters.Add("@FINDADDUPDATEED", SqlDbType.Int);
                    SqlParameter findParaAddUpYearMonth = sqlCommand.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    #endregion

                    #region Parameter�I�u�W�F�N�g�֒l�ݒ�
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(monthlyAddUpWork.EnterpriseCode);

                    if (monthlyAddUpWork.AddUpDateSt == DateTime.MinValue)
                    {
                        findParaAddUpDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(new DateTime(1000, 01, 01));
                    }
                    else
                    {
                        findParaAddUpDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(monthlyAddUpWork.AddUpDateSt);
                    }

                    findParaAddUpDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(monthlyAddUpWork.AddUpDate);
                    if (monthlyAddUpWork.LstMonAddUpProcDay == DateTime.MinValue)
                    {
                        findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(new DateTime(1000, 01, 01));
                    }
                    else
                    {
                        findParaAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(monthlyAddUpWork.LstMonAddUpProcDay); // ADD 2008.12.22
                    }

                    // �S���_���Ή�
                    if (monthlyAddUpWork.AddUpSecCode != "00" && monthlyAddUpWork.AddUpSecCode != "")
                    {
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(monthlyAddUpWork.AddUpSecCode);
                    }

                    #endregion

                    sqlCommand.CommandText = sqlText;
                    sqlCommand.CommandTimeout = 3600;
                    myReader = sqlCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        StockHistoryWork wkstockHistoryWork = new StockHistoryWork();
                        GoodsSupplierDataWork goodsSupplierDataWork = new GoodsSupplierDataWork();
                        UnitPriceCalcParamWork unitPriceCalcParam = new UnitPriceCalcParamWork();
                        GoodsUnitDataWork goodsUnitData = new GoodsUnitDataWork(); // ���i�A���f�[�^�I�u�W�F�N�g���X�g

                        #region ���ʃZ�b�g

                        #region �݌ɗ����f�[�^�N���X
                        FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF")); // �[�������敪
                        wkstockHistoryWork.EnterpriseCode = monthlyAddUpWork.EnterpriseCode;
                        wkstockHistoryWork.AddUpYearMonth = monthlyAddUpWork.AddUpYearMonth;
                        wkstockHistoryWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                        wkstockHistoryWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                        wkstockHistoryWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                        wkstockHistoryWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                        wkstockHistoryWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                        wkstockHistoryWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                        wkstockHistoryWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                        wkstockHistoryWork.LMonthStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LMONTHSTOCKCNTRF"));
                        wkstockHistoryWork.LMonthStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LMONTHSTOCKPRICERF"));
                        wkstockHistoryWork.LMonthPptyStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LMONTHPPTYSTOCKCNTRF"));
                        wkstockHistoryWork.LMonthPptyStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LMONTHPPTYSTOCKPRICERF"));
                        wkstockHistoryWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMESRF"));
                        wkstockHistoryWork.SalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        wkstockHistoryWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                        wkstockHistoryWork.SalesRetGoodsTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESRETGOODSTIMESRF"));
                        wkstockHistoryWork.SalesRetGoodsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRETGOODSCNTRF"));
                        wkstockHistoryWork.SalesRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        wkstockHistoryWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("GROSSPROFITRF"));
                        wkstockHistoryWork.StockTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKTIMESRF"));
                        wkstockHistoryWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
                        wkstockHistoryWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                        wkstockHistoryWork.StockRetGoodsTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKRETGOODSTIMESRF"));
                        wkstockHistoryWork.StockRetGoodsCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRETGOODSCNTRF"));
                        wkstockHistoryWork.StockRetGoodsPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKRETGOODSPRICERF"));
                        wkstockHistoryWork.MoveArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVEARRIVALCNTRF"));
                        wkstockHistoryWork.MoveArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVEARRIVALPRICERF"));
                        wkstockHistoryWork.MoveShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVESHIPMENTCNTRF"));
                        wkstockHistoryWork.MoveShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MOVESHIPMENTPRICERF"));
                        wkstockHistoryWork.AdjustCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                        wkstockHistoryWork.AdjustPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ADJUSTPRICERF"));
                        wkstockHistoryWork.ArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ARRIVALCNTRF"));
                        wkstockHistoryWork.ArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ARRIVALPRICERF"));
                        wkstockHistoryWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                        wkstockHistoryWork.ShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SHIPMENTPRICERF"));
                        wkstockHistoryWork.TotalArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALARRIVALCNTRF"));
                        wkstockHistoryWork.TotalArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALARRIVALPRICERF"));
                        wkstockHistoryWork.TotalShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("TOTALSHIPMENTCNTRF"));
                        wkstockHistoryWork.TotalShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALSHIPMENTPRICERF"));
                        wkstockHistoryWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                        wkstockHistoryWork.BLGoodsHalfName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSHALFNAMERF"));
                        wkstockHistoryWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNO"));
                        wkstockHistoryWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATE"));
                        wkstockHistoryWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATE"));
                        wkstockHistoryWork.LastStockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSTOCKDATE"));
                        wkstockHistoryWork.WareHouseCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODE"));

                        // �݌ɑ��� =  �O�����݌ɐ�+�����א� - ���o�א� + ������ ���ݏo�E���ׂ��܂�
                        wkstockHistoryWork.StockTotal = wkstockHistoryWork.LMonthStockCnt + wkstockHistoryWork.TotalArrivalCnt - wkstockHistoryWork.TotalShipmentCnt + wkstockHistoryWork.AdjustCount;

                        // ���Ѝ݌ɐ� =  �O�������Ѝ݌ɐ� + �����א� - ���o�א� + ������ + �o�א�(�ݏo) - ���א� ���ݏo�E���ׂ͊܂܂Ȃ�
                        wkstockHistoryWork.PropertyStockCnt = wkstockHistoryWork.LMonthPptyStockCnt + wkstockHistoryWork.TotalArrivalCnt - wkstockHistoryWork.TotalShipmentCnt + wkstockHistoryWork.AdjustCount - wkstockHistoryWork.ArrivalCnt + wkstockHistoryWork.ShipmentCnt;

                        stockHistoryWorkList.Add(wkstockHistoryWork);
                        #endregion

                        #endregion

                    }

                    if (GoodsSupplierDataWorkList.Count > 0)
                    {
                        // ���i�d������擾���� ���s
                        goodsSupplierGetter.GetGoodsMngInfo(ref GoodsSupplierDataWorkList);

                        // ���i�d������擾�����ɂ��擾�����d�����
                        // �P���Z�o�p�����[�^�ɃZ�b�g
                        for (int i = 0; i < GoodsSupplierDataWorkList.Count; i++) // ���i�d���擾�f�[�^�N���X
                        {
                            for (int j = 0; j < unitPriceCalcParamList.Count; j++) // �P���Z�o���W���[���v�Z�p�p�����[�^
                            {
                                if ((GoodsSupplierDataWorkList[i].GoodsMakerCd == unitPriceCalcParamList[j].GoodsMakerCd) && // ���i���[�J�[
                                    (GoodsSupplierDataWorkList[i].GoodsNo == unitPriceCalcParamList[j].GoodsNo) &&           // ���i�ԍ�
                                    (GoodsSupplierDataWorkList[i].BLGoodsCode == unitPriceCalcParamList[j].BLGoodsCode))     // BL���i�R�[�h
                                {
                                    if (GoodsSupplierDataWorkList[i].SupplierCd != 0)
                                    {
                                        unitPriceCalcParamList[j].SupplierCd = GoodsSupplierDataWorkList[i].SupplierCd; // �d����Z�b�g
                                    }
                                }
                            }
                        }

                        //�����Z�o���� ���s
                        unitPriceCalculation.CalculateUnitCost(unitPriceCalcParamList, goodsUnitDataList, out unitPriceCalcRetList);

                        // �����Z�o�����ɂ��擾����������
                        // �݌ɗ����f�[�^�N���X�ɃZ�b�g
                        for (int i = 0; i < unitPriceCalcRetList.Count; i++) // �P���v�Z����
                        {
                            for (int j = 0; j < stockHistoryWorkList.Count; j++) // �݌ɗ����f�[�^�N���X
                            {
                                if ((unitPriceCalcRetList[i].GoodsMakerCd == stockHistoryWorkList[j].GoodsMakerCd) && // ���i���[�J�[
                                    (unitPriceCalcRetList[i].GoodsNo == stockHistoryWorkList[j].GoodsNo))     // BL���i�R�[�h
                                {
                                    // �d���P���i�Ŕ��C�����j
                                    stockHistoryWorkList[j].StockUnitPriceFl = unitPriceCalcRetList[i].UnitPriceTaxExcFl;
                                    // �}�V���݌Ɋz = �݌ɑ��� �~ �d���P��
                                    FracCalc((stockHistoryWorkList[j].StockTotal * stockHistoryWorkList[j].StockUnitPriceFl), 1, FractionProcCd, out calcPrice);
                                    stockHistoryWorkList[j].StockMashinePrice = calcPrice;

                                    // ���Ѝ݌ɋ��z = ���Ѝ݌ɐ� �~�d���P��
                                    FracCalc(stockHistoryWorkList[j].PropertyStockCnt * stockHistoryWorkList[j].StockUnitPriceFl, 1, FractionProcCd, out calcPrice);
                                    stockHistoryWorkList[j].PropertyStockPrice = calcPrice;

                                }
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (!myReader.IsClosed) myReader.Close();
                myReader.Dispose();
            }

            return status;
        }

        #endregion

        /// <summary>
        /// �q�ɃR�[�hWhere��쐬
        /// </summary>
        /// <param name="warehouseCode">�q�ɃR�[�h</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <returns>������</returns>
        /// <remarks>
        /// <br>Note       : �݌ɔN�Ԏ��яƉ�\����</br>
        /// <br>Programmer : ��ؑn</br>
        /// <br>Date       : 2021.11.10</br>
        /// </remarks>
        private string MakeWhereWarehouse(List<string> warehouseCode, SqlCommand sqlCommand)
        {

            List<string> sqlText = new List<string>();

            // ���o�����������w�肳��Ȃ��ꍇ�AWhere��͉����w�肵�Ȃ�
            if (warehouseCode == null || warehouseCode.Count == 0) return string.Empty;

            // ���o����From���w�肳��Ă���ꍇ�AWhere��ɉ������w�肷��
            if (!string.Empty.Equals(warehouseCode[0]))
            {
                sqlText.Add("  STOCKHISTORYPAY.WAREHOUSECODERF >= @FROMWAREHOUSECODE");
                SqlParameter p = sqlCommand.Parameters.Add("@FROMWAREHOUSECODE", SqlDbType.NChar);
                p.Value = SqlDataMediator.SqlSetString(warehouseCode[0]);
            }

            // ���o����To���w�肳��Ă���ꍇ�AWhere��ɏ�����w�肷��
            if (!string.Empty.Equals(warehouseCode[1]))
            {
                sqlText.Add("  STOCKHISTORYPAY.WAREHOUSECODERF <= @TOWAREHOUSECODE");
                SqlParameter p = sqlCommand.Parameters.Add("@TOWAREHOUSECODE", SqlDbType.NChar);
                p.Value = SqlDataMediator.SqlSetString(warehouseCode[1]);
            }

            // ������" AND "�Ō�������
            return String.Join(" AND " + Environment.NewLine, sqlText.ToArray());
        }

        /// <summary>
        /// �I��Where��쐬
        /// </summary>
        /// <param name="warehouseCode">�I��</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <returns>������</returns>
        /// <remarks>
        /// <br>Note       : �݌ɔN�Ԏ��яƉ�\����</br>
        /// <br>Programmer : ��ؑn</br>
        /// <br>Date       : 2021.11.10</br>
        /// </remarks>
        private string MakeWhereWarehouseShelfNo(List<string> warehouseShelfNo, SqlCommand sqlCommand)
        {

            List<string> sqlText = new List<string>();

            // ���o�����������w�肳��Ȃ��ꍇ�AWhere��͉����w�肵�Ȃ�
            if (warehouseShelfNo == null || warehouseShelfNo.Count == 0) return string.Empty;

            // ���o����From���w�肳��Ă���ꍇ�AWhere��ɉ������w�肷��
            if (!string.Empty.Equals(warehouseShelfNo[0]))
            {
                sqlText.Add("  STOCK.WAREHOUSESHELFNO  >= @FROMWAREHOUSESHELFNO");
                SqlParameter p = sqlCommand.Parameters.Add("@FROMWAREHOUSESHELFNO", SqlDbType.NChar);
                p.Value = SqlDataMediator.SqlSetString(warehouseShelfNo[0]);
            }

            // ���o����To���w�肳��Ă���ꍇ�AWhere��ɏ�����w�肷��
            if (!string.Empty.Equals(warehouseShelfNo[1]))
            {
                // ���o����From���w�肳��ĂȂ��ꍇ�A�I�Ԃ�NULL�̃f�[�^���擾����
                // �����̎d�l�ɍ��킹��
                if (sqlText.Count == 0)
                {
                    sqlText.Add("  (STOCK.WAREHOUSESHELFNO IS NULL OR STOCK.WAREHOUSESHELFNO  <= @TOWAREHOUSESHELFNO)");
                }
                //����ȊO�̏ꍇ�͒P���ɏ����ݒ肷��
                else
                {
                    sqlText.Add("  STOCK.WAREHOUSESHELFNO  <= @TOWAREHOUSESHELFNO");
                }
                SqlParameter p = sqlCommand.Parameters.Add("@TOWAREHOUSESHELFNO", SqlDbType.NChar);
                p.Value = SqlDataMediator.SqlSetString(warehouseShelfNo[1]);
            }

            // ������" AND "�Ō�������
            return String.Join(" AND " + Environment.NewLine, sqlText.ToArray());
        }

        /// <summary>
        /// ���[�J�[�R�[�hWhere��쐬
        /// </summary>
        /// <param name="warehouseCode">���[�J�[�R�[�h</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <returns>������</returns>
        /// <remarks>
        /// <br>Note       : �݌ɔN�Ԏ��яƉ�\����</br>
        /// <br>Programmer : ��ؑn</br>
        /// <br>Date       : 2021.11.10</br>
        /// </remarks>
        private string MakeWhereMakerCode(List<Int32> makerCode, SqlCommand sqlCommand)
        {

            List<string> sqlText = new List<string>();

            // ���o�����������w�肳��Ȃ��ꍇ�AWhere��͉����w�肵�Ȃ�
            if (makerCode == null || makerCode.Count == 0) return string.Empty;

            // ���o����From���w�肳��Ă���ꍇ�AWhere��ɉ������w�肷��
            if (makerCode[0] != 0)
            {
                sqlText.Add("  STOCKHISTORYPAY.GOODSMAKERCDRF >= @FROMGOODSMAKERCODE");
                SqlParameter p = sqlCommand.Parameters.Add("@FROMGOODSMAKERCODE", SqlDbType.Int);
                p.Value = SqlDataMediator.SqlSetString(makerCode[0].ToString());
            }

            // ���o����To���w�肳��Ă���ꍇ�AWhere��ɏ�����w�肷��
            if (makerCode[1] != 0)
            {
                sqlText.Add("  STOCKHISTORYPAY.GOODSMAKERCDRF <= @TOGOODSMAKERCODE");
                SqlParameter p = sqlCommand.Parameters.Add("@TOGOODSMAKERCODE", SqlDbType.Int);
                p.Value = SqlDataMediator.SqlSetString(makerCode[1].ToString());
            }

            // ������" AND "�Ō�������
            return String.Join(" AND " + Environment.NewLine, sqlText.ToArray());
        }

        /// <summary>
        /// BL�R�[�hWhere��쐬
        /// </summary>
        /// <param name="warehouseCode">BL�R�[�h</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <returns>������</returns>
        /// <remarks>
        /// <br>Note       : �݌ɔN�Ԏ��яƉ�\����</br>
        /// <br>Programmer : ��ؑn</br>
        /// <br>Date       : 2021.11.10</br>
        /// </remarks>
        private string MakeWhereBlGoodsCode(List<Int32> blGoodsCode, SqlCommand sqlCommand)
        {

            List<string> sqlText = new List<string>();

            // ���o�����������w�肳��Ȃ��ꍇ�AWhere��͉����w�肵�Ȃ�
            if (blGoodsCode == null || blGoodsCode.Count == 0) return string.Empty;

            // ���o����From���w�肳��Ă���ꍇ�AWhere��ɉ������w�肷��
            if (blGoodsCode[0] != 0)
            {
                sqlText.Add("  (GOODS.BLGOODSCODERF >= @FROMBLGOODSCODE OR GOODS.BLGOODSCODERF = 0)");
                SqlParameter p = sqlCommand.Parameters.Add("@FROMBLGOODSCODE", SqlDbType.Int);
                p.Value = SqlDataMediator.SqlSetString(blGoodsCode[0].ToString());
            }

            // ���o����To���w�肳��Ă���ꍇ�AWhere��ɏ�����w�肷��
            if (blGoodsCode[1] != 0)
            {
                sqlText.Add("  (GOODS.BLGOODSCODERF <= @TOBLGOODSCODE OR GOODS.BLGOODSCODERF = 0)");
                SqlParameter p = sqlCommand.Parameters.Add("@TOBLGOODSCODE", SqlDbType.Int);
                p.Value = SqlDataMediator.SqlSetString(blGoodsCode[1].ToString());
            }

            // ������" AND "�Ō�������
            return String.Join(" AND " + Environment.NewLine, sqlText.ToArray());
        }

        /// <summary>
        /// �i��Where��쐬
        /// </summary>
        /// <param name="warehouseCode">�i��</param>
        /// <param name="sqlConnection">sql�R�l�N�V����</param>
        /// <returns>������</returns>
        /// <remarks>
        /// <br>Note       : �݌ɔN�Ԏ��яƉ�\����</br>
        /// <br>Programmer : ��ؑn</br>
        /// <br>Date       : 2021.11.10</br>
        /// </remarks>
        private string MakeWhereGoodsNo(List<string> goodsNo, SqlCommand sqlCommand)
        {

            List<string> sqlText = new List<string>();

            // ���o�����������w�肳��Ȃ��ꍇ�AWhere��͉����w�肵�Ȃ�
            if (goodsNo == null || goodsNo.Count == 0) return string.Empty;

            // ���o����From���w�肳��Ă���ꍇ�AWhere��ɉ������w�肷��
            if (!string.Empty.Equals(goodsNo[0]))
            {
                sqlText.Add("  STOCKHISTORYPAY.GOODSNORF >= @FROMGOODSNO");
                SqlParameter p = sqlCommand.Parameters.Add("@FROMGOODSNO", SqlDbType.NChar);
                p.Value = SqlDataMediator.SqlSetString(goodsNo[0]);
            }

            // ���o����To���w�肳��Ă���ꍇ�AWhere��ɏ�����w�肷��
            if (!string.Empty.Equals(goodsNo[1]))
            {
                sqlText.Add("  STOCKHISTORYPAY.GOODSNORF <= @TOGOODSNO");
                SqlParameter p = sqlCommand.Parameters.Add("@TOGOODSNO", SqlDbType.NChar);
                p.Value = SqlDataMediator.SqlSetString(goodsNo[1]);
            }

            // ������" AND "�Ō�������
            return String.Join(" AND " + Environment.NewLine, sqlText.ToArray());
        }

        #region [FracCalc ����Œ[������]
        /// <summary>
        /// �[������
        /// </summary>
        /// <param name="inputNumerical">���l</param>
        /// <param name="fractionUnit">�[�������P��</param>
        /// <param name="fractionProcess">�[�������i1:�؎� 2:�l�̌ܓ� 3:�؏�j</param>
        /// <param name="resultNumerical">�Z�o���z</param>
        private void FracCalc(double inputNumerical, double fractionUnit, Int32 fractionProcess, out Int64 resultNumerical)
        {
            // �����l�Z�b�g
            resultNumerical = (Int64)inputNumerical;

            inputNumerical = (double)((decimal)inputNumerical - ((decimal)inputNumerical % (decimal)0.000001));	// �����_6���ȉ��؎�
            fractionUnit = (double)((decimal)fractionUnit - ((decimal)fractionUnit % (decimal)0.000001));		// �����_6���ȉ��؎�

            // �[���P�ʂŏ��Z
            decimal tmpKin = (decimal)inputNumerical / (decimal)fractionUnit;

            // �}�C�i�X�␳
            bool sign = false;
            if (tmpKin < 0)
            {
                sign = true;
                tmpKin = tmpKin * (-1);
            }

            // ������1���擾
            decimal tmpDecimal = (tmpKin - (decimal)((long)tmpKin)) * 10;

            // tmpKin �[���w��
            bool wRoundFlg = true; // �؎�
            switch (fractionProcess)
            {
                //--------------------------------------
                // 1:�؎�
                //--------------------------------------
                case 1:
                    {
                        wRoundFlg = true; // �؎�
                        break;
                    }
                //--------------------------------------
                // 2:�l�̌ܓ�
                //--------------------------------------
                case 2: // �l�̌ܓ�
                    {
                        if (tmpDecimal >= 5)
                        {
                            wRoundFlg = false; // �؏�
                        }
                        break;
                    }
                //--------------------------------------
                // 3:�؏�
                //--------------------------------------
                case 3: // �؏�
                    {
                        if (tmpDecimal > 0)
                        {
                            wRoundFlg = false; // �؏�
                        }
                        break;
                    }
            }

            // �[������
            if (wRoundFlg == false)
            {
                tmpKin = tmpKin + 1;
            }

            // �������؎�
            tmpKin = (decimal)(long)tmpKin;

            // �}�C�i�X�␳
            if (sign == true)
            {
                tmpKin = tmpKin * (-1);
            }

            decimal a = tmpKin * (decimal)fractionUnit;

            // �Z�o�l�Z�b�g
            resultNumerical = (Int64)((decimal)tmpKin * (decimal)fractionUnit);

        }
        #endregion

        #endregion
        // ADD 2021.11.10 <<<


    }

}
