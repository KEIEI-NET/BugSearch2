
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
using System.Collections.Generic;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ɍ���N��@�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɍ���N����f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.07.17</br>
    /// <br></br>
    /// <br>Update Note: ���x�`���[�j���O</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/05/10</br>
    /// <br>Update Note: ��QNo.1078�̑Ή� </br>
    /// <br>Programmer : �� ��</br>
    /// <br>Date       : 2012.8.2</br>
    /// <br>Update Note: 2015/09/28 ����</br>
    /// <br>�Ǘ��ԍ�  : 11175324-00 Redmine#47299 �݌ɏ�񂪕s���̑Ή�</br>
    /// <br>Update Note: Redmine#47299 �q�ɖ��̂���ѕi���͂��ꂼ��}�X�^����擾����̑Ή� </br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2015/10/02</br>
    /// </remarks>
    [Serializable]
    public class StockMonthYearReportDataWorkDB : RemoteWithAppLockDB, IStockMonthYearReportDataWorkDB
    {

        /// <summary>
        /// �݌Ɍ���N��@�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.17</br>
        /// </remarks>
        public StockMonthYearReportDataWorkDB()
            :
        base("PMZAI02016D", "Broadleaf.Application.Remoting.ParamData.StockMonthYearReportDataWork", "STOCKHISTORYRF") //���N���X�̃R���X�g���N�^
        {
        }
        /// <summary>���|/���|���z�}�X�^�X�V�����[�g�I�u�W�F�N�g</summary>
        private MonthlyAddUpDB _monthlyAddUpDB = new MonthlyAddUpDB();
        private TtlDayCalcDB _ttlDayCalcDB = new TtlDayCalcDB();
        private CompanyInfDB _companyInfDB = new CompanyInfDB();
        private DateTime DummyYearMonth = DateTime.MinValue;

        #region [Search]
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌Ɍ���N��LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="stockMonthYearReportDataWork">��������</param>
        /// <param name="stockMonthYearReportWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɖ��o�׈ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.17</br>
        public int Search(out object stockMonthYearReportDataWork, object stockMonthYearReportWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockMonthYearReportDataWork = null;

            StockMonthYearReportWork _stockMonthYearReportWork = stockMonthYearReportWork as StockMonthYearReportWork;

            try
            {
                status = SearchProc(out stockMonthYearReportDataWork, _stockMonthYearReportWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMonthYearReportDataWorkDB.Search Exception=" + ex.Message);
                stockMonthYearReportDataWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌Ɍ���N��LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockMonthYearReportDataWork">��������</param>
        /// <param name="_stockMonthYearReportWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌Ɍ���N��LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 30350 �N�� ����</br>
        /// <br>Date       : 2008.10.31</br>
        /// <br></br>
        /// <br>Update Note: ��QNo.1078�̑Ή� </br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2012.8.2</br>
        private int SearchProc(out object stockMonthYearReportDataWork, StockMonthYearReportWork _stockMonthYearReportWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            stockMonthYearReportDataWork = null;
   
            bool OneCountFrg = true;

            ArrayList resultList = new ArrayList();
            ArrayList lastKey = new ArrayList();
            Dictionary<string, StockMonthYearReportDataWork> dictionary = new Dictionary<string, StockMonthYearReportDataWork>();


            StockMonthYearReportDataWork resultwork = new StockMonthYearReportDataWork();
            int month = 0;

            Dictionary<string, StockMonthYearReportDataWork> dic = new Dictionary<string, StockMonthYearReportDataWork>();
            try
            {
                // �R�l�N�V��������
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //�@SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // �݌Ƀ}�X�^���猋�ʒ��o
                ArrayList stockHistoryList = new ArrayList();

                #region �S�Аݒ�

                //if ((_stockMonthYearReportWork.SectionCodes.Length == 0) ||
                //    (_stockMonthYearReportWork.SectionCodes[0] == ""))
                //{
                //    // �S�Ћ��ʂ̏ꍇ
                //    CustomSerializeArrayList sectionList = new CustomSerializeArrayList();
                //    SectionInfo sectionInfo = new SectionInfo();
                //    SecInfoSetWork sectionInfoSetWork = new SecInfoSetWork();
                //    sectionInfoSetWork.EnterpriseCode = _stockMonthYearReportWork.EnterpriseCode;
                //    sectionInfoSetWork.LogicalDeleteCode = 0;

                //    sectionInfo.Search(out sectionList, sectionInfoSetWork, ref sqlConnection, readMode, logicalMode);
                //    ArrayList paraList = ListUtils.Find(sectionList, typeof(SecInfoSetWork), ListUtils.FindType.Array) as ArrayList;
                //    string[] str = new string[paraList.Count];
                //    int i = 0;
                //    foreach (SecInfoSetWork sec in paraList)
                //    {
                //        // ArrayList���當����ɑ��
                //        str[i] = sec.SectionCode;
                //        i++;
                //    }
                //    if (str.Length != 0)
                //    {
                //        _stockMonthYearReportWork.SectionCodes = str;
                //    }
                //}
                #endregion

                if (_stockMonthYearReportWork.Ed_AddUpYearMonth.Month < _stockMonthYearReportWork.St_AddUpYearMonth.Month)
                {
                    month = 12 - _stockMonthYearReportWork.St_AddUpYearMonth.Month + _stockMonthYearReportWork.Ed_AddUpYearMonth.Month;
                }
                else
                {
                    month = _stockMonthYearReportWork.Ed_AddUpYearMonth.Month - _stockMonthYearReportWork.St_AddUpYearMonth.Month;
                }
                //foreach (string sectionCode in _stockMonthYearReportWork.SectionCodes)
                //{
                    DummyYearMonth = _stockMonthYearReportWork.St_AddUpYearMonth;
                    for (int i = 0; i <= month; i++)
                    {
                        List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();

                        Dictionary<string, StockMonthYearReportDataWork> dicHist = new Dictionary<string, StockMonthYearReportDataWork>();
                        Dictionary<string, StockMonthYearReportDataWork> dicStock = new Dictionary<string, StockMonthYearReportDataWork>();

                        ArrayList keyStockList = new ArrayList();
                        ArrayList histKey = new ArrayList();

                        #region �����`�F�b�N����

                        // �����`�F�b�N����
                        List<TtlDayCalcRetWork> retList = new List<TtlDayCalcRetWork>();
                        TtlDayCalcParaWork para = new TtlDayCalcParaWork();

                        DateTime stMonth = new DateTime();
                        DateTime edMonth = new DateTime();

                        para.EnterpriseCode = _stockMonthYearReportWork.EnterpriseCode;
                        //para.SectionCode = sectionCode;
                        Int32 iAddUpDate = Int32.Parse(DummyYearMonth.ToString("yyyyMMdd")); //�v��N����

                        bool sale = false, buy = false;

                        // ���|
                        status = _ttlDayCalcDB.SearchHisMonthlyAccRec(out retList, para, ref sqlConnection);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retList[0].TotalDay < iAddUpDate)
                        {
                            sale = true;

                        }
                        retList.Clear();
                        // ���|
                        status = _ttlDayCalcDB.SearchHisMonthlyAccPay(out retList, para, ref sqlConnection);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retList[0].TotalDay < iAddUpDate)
                        {
                            buy = true;
                        }
                        if (sale == true || buy == true)
                        #endregion

                        {
                            if (stockHistoryList.Count == 0)
                            {
                                #region ���ߔ͈͓��t�擾
                                ArrayList list = new ArrayList();
                                CompanyInfWork companyInfWork = new CompanyInfWork();

                                //���ߔ͈͓��t�擾
                                companyInfWork.EnterpriseCode = _stockMonthYearReportWork.EnterpriseCode;
                                status = _companyInfDB.Search(out list, companyInfWork, ref sqlConnection);

                                companyInfWork = list[0] as CompanyInfWork;

                                FinYearTableGenerator fin = new FinYearTableGenerator(companyInfWork);

                                fin.GetDaysFromMonth(DummyYearMonth, out stMonth, out edMonth);
                                #endregion

                                #region �݌Ƀ}�X�^�ǂݍ��ݏ���
                                if (dic.Count == 0)
                                {
                                    // �݌Ƀ}�X�^ Search
                                    status = SearchStockProc(ref dic, ref sqlConnection, _stockMonthYearReportWork, logicalMode);
                                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                                        (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                                    {
                                        //�Y���f�[�^�Ȃ�
                                        return status;
                                    }
                                    else if (status != 0)
                                    {
                                        //�擾���s
                                        throw new Exception("�݌Ƀ}�X�^�Ǎ����s�B");
                                    }
                                    if (dic.Count == 0)
                                    {

                                        //�Y���f�[�^�Ȃ�
                                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                    }
                                }
                                #endregion
                            }

                            #region �����X�V�����[�g�ǂݍ��ݏ���
                            StockHistoryWork stockHistoryWork = new StockHistoryWork();
                            MonthlyAddUpWork monthlyAddUpWork = new MonthlyAddUpWork();

                            //���|���E���|���W�v���W���[���p�����[�^�Z�b�g
                            monthlyAddUpWork.EnterpriseCode = _stockMonthYearReportWork.EnterpriseCode;
                            //monthlyAddUpWork.AddUpDateSt = stMonth.AddDays(-1); // DEL BY ��� ON 2012/8/2 FOR ��QNo.1078�̑Ή�
                            monthlyAddUpWork.AddUpDateSt = stMonth; // ADD BY ��� ON 2012/8/2 FOR ��QNo.1078�̑Ή�
                            monthlyAddUpWork.AddUpDateEd = edMonth;
                            //monthlyAddUpWork.AddUpSecCode = sectionCode;
                            monthlyAddUpWork.AddUpDate = edMonth;
                            monthlyAddUpWork.LstMonAddUpProcDay = DummyYearMonth.AddMonths(-1);
                            monthlyAddUpWork.AddUpYearMonth = DummyYearMonth.AddMonths(-1);

                            string retMsg = null;
                            bool msgDiv = true;

                            // �����X�V�����[�g�݌ɏW�v���\�b�h�Ăяo��
                            status = _monthlyAddUpDB.MakeStockHistoryParameters(ref monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection);
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // �N���X�i�[���\�b�h
                                status = StockStorage(ref dicStock, ref dic, ref keyStockList, ref lastKey, ref stockHistoryWorkList, _stockMonthYearReportWork);
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
                                throw new Exception("���|���E���|���W�v���W���[������̎擾�Ɏ��s�B");
                            }
                            #endregion
                        }
                        // ���ߏ�������Ă���
                        else
                        {
                            if (OneCountFrg == true)
                            {
                                status = SearchStockNoShipmentProc(ref dicHist, ref histKey, ref lastKey, ref sqlConnection, _stockMonthYearReportWork, logicalMode/* ,sectionCode*/);
                                OneCountFrg = false;
                            }
                        }

                        #region ���ʏW�v
                        if (dicHist.Count != 0)
                        {

                            foreach (string k in histKey)
                            {
                                if (dictionary.ContainsKey(k) == true)
                                {
                                    dictionary[k].StockCount += dicHist[k].StockCount;
                                    dictionary[k].MoveArrivalCnt += dicHist[k].MoveArrivalCnt;
                                    dictionary[k].TotalArrivalCnt += dicHist[k].TotalArrivalCnt;
                                    dictionary[k].SalesCount += dicHist[k].SalesCount;
                                    dictionary[k].MoveShipmentCnt += dicHist[k].MoveShipmentCnt;
                                    dictionary[k].TotalShipmentCnt += dicHist[k].TotalShipmentCnt;
                                    dictionary[k].StockPriceTaxExc += dicHist[k].StockPriceTaxExc;
                                    dictionary[k].MoveArrivalPrice += dicHist[k].MoveArrivalPrice;
                                    dictionary[k].TotalArrivalPrice += dicHist[k].TotalArrivalPrice;
                                    dictionary[k].SalesMoneyTaxExc += dicHist[k].SalesMoneyTaxExc;
                                    dictionary[k].MoveShipmentPrice += dicHist[k].MoveShipmentPrice;
                                    dictionary[k].TotalShipmentPrice += dicHist[k].TotalShipmentPrice;
                                    dictionary[k].StockTotal += dicHist[k].StockTotal;
                                    dictionary[k].StockMashinePrice += dicHist[k].StockMashinePrice;
                                    dictionary[k].GrossProfit += dicHist[k].GrossProfit;
                                    dictionary[k].SalesCost += dicHist[k].SalesCost;
                                    if (i == 0)
                                    {
                                        //�O���c�����ŏ����̂�
                                        dictionary[k].LMonthStockPrice += dicHist[k].LMonthStockPrice;
                                        dictionary[k].LMonthStockCnt += dicHist[k].LMonthStockCnt;
                                    }
                                    if ((dictionary[k].SalesMoneyTaxExc != 0) && (dictionary[k].GrossProfit != 0))
                                    {
                                        double dGrossProfit = dictionary[k].GrossProfit;
                                        double dSalesMoneyTaxExc = dictionary[k].SalesMoneyTaxExc;
                                        double dGrossProfitRate = (dGrossProfit / dSalesMoneyTaxExc) * 100;
                                        dictionary[k].GrossProfitRate = dGrossProfitRate;
                                    }
                                }
                                else
                                {
                                    dictionary[k] = dicHist[k];
                                }
                            }

                        }
                        else if (dicStock.Count != 0)
                        {
                            foreach (string k2 in keyStockList)
                            {
                                if (dictionary.ContainsKey(k2) == true)
                                {
                                    dictionary[k2].StockCount += dicStock[k2].StockCount;
                                    dictionary[k2].MoveArrivalCnt += dicStock[k2].MoveArrivalCnt;
                                    dictionary[k2].TotalArrivalCnt += dicStock[k2].TotalArrivalCnt;
                                    dictionary[k2].SalesCount += dicStock[k2].SalesCount;
                                    dictionary[k2].MoveShipmentCnt += dicStock[k2].MoveShipmentCnt;
                                    dictionary[k2].TotalShipmentCnt += dicStock[k2].TotalShipmentCnt;

                                    dictionary[k2].StockPriceTaxExc += dicStock[k2].StockPriceTaxExc;
                                    dictionary[k2].MoveArrivalPrice += dicStock[k2].MoveArrivalPrice;
                                    dictionary[k2].TotalArrivalPrice += dicStock[k2].TotalArrivalPrice;
                                    dictionary[k2].SalesMoneyTaxExc += dicStock[k2].SalesMoneyTaxExc;
                                    dictionary[k2].MoveShipmentPrice += dicStock[k2].MoveShipmentPrice;
                                    dictionary[k2].TotalShipmentPrice += dicStock[k2].TotalShipmentPrice;
                                    //dictionary[k2].StockTotal = dicStock[k2].StockTotal;
                                    //dictionary[k2].StockMashinePrice = dicStock[k2].StockMashinePrice;
                                    dictionary[k2].GrossProfit += dicStock[k2].GrossProfit;
                                    dictionary[k2].SalesCost += dicStock[k2].SalesCost;
                                    if (i == 0)
                                    {
                                        //�O���c�����ŏ��̌��̂�
                                        dictionary[k2].LMonthStockCnt = dicStock[k2].LMonthStockCnt;
                                        dictionary[k2].LMonthStockPrice = dicStock[k2].LMonthStockPrice;
                                    }
                                    if ((dictionary[k2].SalesMoneyTaxExc != 0) && (dictionary[k2].GrossProfit != 0))
                                    {
                                        double dGrossProfit = dictionary[k2].GrossProfit;
                                        double dSalesMoneyTaxExc = dictionary[k2].SalesMoneyTaxExc;
                                        double dGrossProfitRate = (dGrossProfit / dSalesMoneyTaxExc) * 100;
                                        dictionary[k2].GrossProfitRate = dGrossProfitRate;
                                    }
                                }
                                else
                                {
                                    dictionary[k2] = dicStock[k2];
                                }
                            }
                        }
                        #endregion

                        DummyYearMonth = DummyYearMonth.AddMonths(1);
                    }
                ////}
                for (int j = 0; j < lastKey.Count; j++)
                {
                    string key3 = lastKey[j] as string;
                    if (dictionary.ContainsKey(key3) == true)
                    {
                        dictionary.TryGetValue(key3, out resultwork);
                        resultList.Add(resultwork);
                    }
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockMonthYearReportDataWorkDB.SearchProc Exception=" + ex.Message);
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

            stockMonthYearReportDataWork = resultList;

            return status;
        }

        #region [�N���X�i�[����]
        /// <summary>
        /// �������ʃN���X�i�[����
        /// </summary>
        /// <param name="al">���ʊi�[ArrayList</param>
        /// <param name="stockHistoryWorkList">�����X�V���X�g</param>
        private int StockStorage(ref Dictionary<string, StockMonthYearReportDataWork> dicStock, ref Dictionary<string, StockMonthYearReportDataWork> dic, ref ArrayList keyStockList, ref ArrayList lastKey, ref List<StockHistoryWork> stockHistoryWorkList, StockMonthYearReportWork _stockMonthYearReportWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            string key = string.Empty;
            string key2 = string.Empty;

            foreach (StockHistoryWork st in stockHistoryWorkList)
            {
                #region ���o����-�l�Z�b�g
                StockMonthYearReportDataWork stockMonthYearResultwork = new StockMonthYearReportDataWork();

                // ���_�R�[�h
                //if (_stockMonthYearReportWork.SectionCodes != null)
                //{
                //    string Sec = "";
                //    foreach (string Secstr in _stockMonthYearReportWork.SectionCodes)
                //    {
                //        if (Sec != "")
                //        {
                //            Sec += ",";
                //        }
                //        Sec += "'" + Secstr + "'";
                //    }

                //    if (Sec != "")
                //    {
                //        if (Sec.Contains(st.SectionCode.Trim()))
                //        {
                //            //stockMonthYearResultwork.SectionCode = st.SectionCode;
                //            stockMonthYearResultwork.SectionCode = 0;
                //        }
                //        else
                //        {
                //            continue;
                //        }
                //    }
                //    else
                //    {
                //        continue;
                //    }
                //}

                // �q�ɃR�[�h�E����
                if (_stockMonthYearReportWork.St_WarehouseCode != "")
                {
                    //if (_stockMonthYearReportWork.St_WarehouseCode.CompareTo(st.WarehouseCode) == 0 ||
                    //    _stockMonthYearReportWork.St_WarehouseCode.CompareTo(st.WarehouseCode) > 0)
                    if (_stockMonthYearReportWork.St_WarehouseCode.Trim().CompareTo(st.WarehouseCode.Trim()) <= 0)
                    {
                        stockMonthYearResultwork.WarehouseCode = st.WarehouseCode;
                        stockMonthYearResultwork.WarehouseName = st.WarehouseName;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockMonthYearReportWork.Ed_WarehouseCode != "")
                {
                    //if (_stockMonthYearReportWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode) == 0 ||
                    //    _stockMonthYearReportWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode) > 0)
                    if (_stockMonthYearReportWork.Ed_WarehouseCode.Trim().CompareTo(st.WarehouseCode.Trim()) >= 0)
                    {
                        stockMonthYearResultwork.WarehouseCode = st.WarehouseCode;
                        stockMonthYearResultwork.WarehouseName = st.WarehouseName;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockMonthYearReportWork.St_WarehouseCode == "" && _stockMonthYearReportWork.Ed_WarehouseCode == "")
                {
                    stockMonthYearResultwork.WarehouseCode = st.WarehouseCode;
                    stockMonthYearResultwork.WarehouseName = st.WarehouseName;
                }

                // ���[�J�[�R�[�h
                if (_stockMonthYearReportWork.St_GoodsMakerCd != 0)
                {
                    if (_stockMonthYearReportWork.St_GoodsMakerCd == st.GoodsMakerCd ||
                        _stockMonthYearReportWork.St_GoodsMakerCd < st.GoodsMakerCd)
                    {
                        stockMonthYearResultwork.GoodsMakerCd = st.GoodsMakerCd;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockMonthYearReportWork.Ed_GoodsMakerCd != 0)
                {
                    if (_stockMonthYearReportWork.Ed_GoodsMakerCd == st.GoodsMakerCd ||
                        _stockMonthYearReportWork.Ed_GoodsMakerCd > st.GoodsMakerCd)
                    {
                        stockMonthYearResultwork.GoodsMakerCd = st.GoodsMakerCd;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockMonthYearReportWork.St_GoodsMakerCd == 0 && _stockMonthYearReportWork.Ed_GoodsMakerCd == 0)
                {
                    stockMonthYearResultwork.GoodsMakerCd = st.GoodsMakerCd;
                }

                // �i��
                if (_stockMonthYearReportWork.St_GoodsNo != "")
                {
                    if (_stockMonthYearReportWork.St_GoodsNo.CompareTo(st.GoodsNo) == 0 ||
                        _stockMonthYearReportWork.St_GoodsNo.CompareTo(st.GoodsNo) < 0)
                    {
                        stockMonthYearResultwork.GoodsNo = st.GoodsNo;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockMonthYearReportWork.Ed_GoodsNo != "")
                {
                    if (_stockMonthYearReportWork.Ed_GoodsNo.CompareTo(st.GoodsNo) == 0 ||
                        _stockMonthYearReportWork.Ed_GoodsNo.CompareTo(st.GoodsNo) > 0)
                    {
                        stockMonthYearResultwork.GoodsNo = st.GoodsNo;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockMonthYearReportWork.St_GoodsNo == "" && _stockMonthYearReportWork.Ed_GoodsNo == "")
                {
                    stockMonthYearResultwork.GoodsNo = st.GoodsNo;
                }


                // �i��
                stockMonthYearResultwork.GoodsName = st.GoodsName;
                // �O�����݌ɐ�
                stockMonthYearResultwork.LMonthStockCnt = st.LMonthPptyStockCnt;

                key = st.WarehouseCode.Trim() + "," + st.GoodsNo.Trim() + "," + st.GoodsMakerCd.ToString("").Trim();
                if (dic.ContainsKey(key) == true)
                {
                    StockMonthYearReportDataWork stockWork = dic[key] as StockMonthYearReportDataWork;

                    // ���i�Ǘ��敪1
                    if (_stockMonthYearReportWork.PartsManagementDivide1 != null)
                    {
                        string div1 = "";
                        foreach (string Divide1str in _stockMonthYearReportWork.PartsManagementDivide1)
                        {
                            if (div1 != "")
                            {
                                div1 += ",";
                            }
                            div1 += "'" + Divide1str + "'";
                        }

                        if (div1 != "")
                        {
                            if (stockWork.PartsManagementDivide1 == "") stockWork.PartsManagementDivide1 = "-1";
                            if (!(div1.Contains(stockWork.PartsManagementDivide1.Trim())))
                            {
                                continue;
                            }
                         }
                    }
                
                    // ���i�Ǘ��敪2
                    if (_stockMonthYearReportWork.PartsManagementDivide2 != null)
                    {
                        string div2 = "";
                        foreach (string Divide1str in _stockMonthYearReportWork.PartsManagementDivide2)
                        {
                            if (div2 != "")
                            {
                                div2 += ",";
                            }
                            div2 += "'" + Divide1str + "'";
                        }

                        if (div2 != "")
                        {
                            if(stockWork.PartsManagementDivide2 == "") stockWork.PartsManagementDivide2 = "-1";
                            if (!(div2.Contains(stockWork.PartsManagementDivide2.Trim())))
                            {
                                continue;
                            }
                        }
                    }

                    // �I��
                    stockMonthYearResultwork.WarehouseShelfNo = stockWork.WarehouseShelfNo;

                    //�d����R�[�h
                    //if (_stockMonthYearReportWork.St_SupplierCd != 0)
                    //{
                    //    if (_stockMonthYearReportWork.St_SupplierCd == stockWork.StockSupplierCode ||
                    //        _stockMonthYearReportWork.St_SupplierCd < stockWork.StockSupplierCode)
                    //    {
                    //        stockMonthYearResultwork.StockSupplierCode = 0;
                    //    }
                    //    else
                    //    {
                    //        continue;
                    //    }
                    //}
                    //if (_stockMonthYearReportWork.Ed_SupplierCd != 0)
                    //{
                    //    if (_stockMonthYearReportWork.Ed_SupplierCd == stockWork.StockSupplierCode ||
                    //        _stockMonthYearReportWork.Ed_SupplierCd > stockWork.StockSupplierCode)
                    //    {
                    //        stockMonthYearResultwork.StockSupplierCode = 0;
                    //    }
                    //    else
                    //    {
                    //        continue;
                    //    }
                    //}

                    if (_stockMonthYearReportWork.St_SupplierCd == 0 && _stockMonthYearReportWork.Ed_SupplierCd == 0)
                    {
                        stockMonthYearResultwork.StockSupplierCode = 0;
                    }
                    // �ō��݌ɐ�
                    stockMonthYearResultwork.MaximumStockCnt = stockWork.MaximumStockCnt;
                    // �Œ�݌ɐ�
                    stockMonthYearResultwork.MinimumStockCnt = stockWork.MinimumStockCnt;
                    // BL�R�[�h
                    stockMonthYearResultwork.BLGoodsCode = stockWork.BLGoodsCode;
                    // ���[�J�[����
                    stockMonthYearResultwork.MakerShortName = stockWork.MakerShortName;
                    // �d���旪��
                    stockMonthYearResultwork.SupplierSnm = "";
                    // �Ǘ����_
                    stockMonthYearResultwork.SectionCode = stockWork.SectionCode;

                    // ���v�l�̌v�Z
                    key2 = st.WarehouseCode.Trim() + "," + st.GoodsNo.Trim() + "," + st.GoodsMakerCd.ToString("").Trim();
                    if (dicStock.ContainsKey(key2) == true)
                    {
                        dicStock[key2].StockCount += (st.StockCount + st.StockRetGoodsCnt);
                        dicStock[key2].MoveArrivalCnt += st.MoveArrivalCnt;
                        dicStock[key2].TotalArrivalCnt += st.TotalArrivalCnt;
                        dicStock[key2].SalesCount += (st.SalesCount + st.SalesRetGoodsCnt);
                        dicStock[key2].MoveShipmentCnt += st.MoveShipmentCnt;
                        dicStock[key2].TotalShipmentCnt += st.TotalShipmentCnt;
                        dicStock[key2].LMonthStockPrice += st.LMonthPptyStockPrice;
                        dicStock[key2].StockPriceTaxExc += (st.StockPriceTaxExc + st.StockRetGoodsPrice);
                        dicStock[key2].MoveArrivalPrice += st.MoveArrivalPrice;
                        dicStock[key2].TotalArrivalPrice += st.TotalArrivalPrice;
                        dicStock[key2].SalesMoneyTaxExc += (st.SalesMoneyTaxExc + st.SalesRetGoodsPrice);
                        dicStock[key2].MoveShipmentPrice += st.MoveShipmentPrice;
                        dicStock[key2].TotalShipmentPrice += st.TotalShipmentPrice;
                        //dicStock[key2].StockTotal += st.StockTotal;
                        dicStock[key2].StockTotal += st.PropertyStockCnt;
                        dicStock[key2].StockMashinePrice += st.PropertyStockPrice;
                        dicStock[key2].GrossProfit += st.GrossProfit;
                        dicStock[key2].SalesCost = st.StockUnitPriceFl;

                        //dicStock[key2].SalesCost = dicStock[key2].SalesMoneyTaxExc - dicStock[key2].GrossProfit;
                        //dicStock[key2].MaximumStockCnt = stockMonthYearResultwork.MaximumStockCnt;
                        //dicStock[key2].MinimumStockCnt = stockMonthYearResultwork.MinimumStockCnt;
                        if ((dicStock[key2].SalesMoneyTaxExc != 0) && (dicStock[key2].GrossProfit != 0))
                        {
                            double dGrossProfit = dicStock[key2].GrossProfit;
                            double dSalesMoneyTaxExc = dicStock[key2].SalesMoneyTaxExc;
                            double dGrossProfitRate = (dGrossProfit / dSalesMoneyTaxExc) * 100;
                            dicStock[key2].GrossProfitRate = dGrossProfitRate;
                        }
                        else
                        {
                            dicStock[key2].GrossProfitRate = 0;
                        }
                    }
                    else
                    {
                        stockMonthYearResultwork.StockCount = (st.StockCount + st.StockRetGoodsCnt);
                        stockMonthYearResultwork.MoveArrivalCnt = st.MoveArrivalCnt;
                        stockMonthYearResultwork.TotalArrivalCnt = st.TotalArrivalCnt;
                        stockMonthYearResultwork.SalesCount = (st.SalesCount + st.SalesRetGoodsCnt);
                        stockMonthYearResultwork.MoveShipmentCnt = st.MoveShipmentCnt;
                        stockMonthYearResultwork.TotalShipmentCnt = st.TotalShipmentCnt;
                        stockMonthYearResultwork.LMonthStockPrice = st.LMonthPptyStockPrice;
                        stockMonthYearResultwork.StockPriceTaxExc = (st.StockPriceTaxExc + st.StockRetGoodsPrice);
                        stockMonthYearResultwork.MoveArrivalPrice = st.MoveArrivalPrice;
                        stockMonthYearResultwork.TotalArrivalPrice = st.TotalArrivalPrice;
                        stockMonthYearResultwork.SalesMoneyTaxExc = (st.SalesMoneyTaxExc + st.SalesRetGoodsPrice);
                        stockMonthYearResultwork.MoveShipmentPrice = st.MoveShipmentPrice;
                        stockMonthYearResultwork.TotalShipmentPrice = st.TotalShipmentPrice;
                        //stockMonthYearResultwork.StockTotal = st.StockTotal;
                        stockMonthYearResultwork.StockTotal = st.PropertyStockCnt;
                        stockMonthYearResultwork.StockMashinePrice = st.PropertyStockPrice;
                        stockMonthYearResultwork.GrossProfit = st.GrossProfit;
                        //stockMonthYearResultwork.SalesCost = stockMonthYearResultwork.SalesMoneyTaxExc - stockMonthYearResultwork.GrossProfit;
                        stockMonthYearResultwork.SalesCost = st.StockUnitPriceFl;
                        if ((stockMonthYearResultwork.SalesMoneyTaxExc != 0) && (stockMonthYearResultwork.GrossProfit != 0))
                        {
                            double dGrossProfit = stockMonthYearResultwork.GrossProfit;
                            double dSalesMoneyTaxExc = stockMonthYearResultwork.SalesMoneyTaxExc;
                            double dGrossProfitRate = (dGrossProfit / dSalesMoneyTaxExc) * 100;
                            stockMonthYearResultwork.GrossProfitRate = dGrossProfitRate;
                        }
                        else
                        {
                            stockMonthYearResultwork.GrossProfitRate = 0;
                        }

                        keyStockList.Add(key2);

                        if (lastKey.Contains(key2) == false)
                        {
                            lastKey.Add(key2);
                        }
                        dicStock.Add(key2, stockMonthYearResultwork);
                    }

                }


                
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                #endregion
            }
            return status;
        }
        #endregion

        #region SearchStockNoShipmentProc
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_stockMonthYearReportWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <br>Update Note: 2015/09/28 ����</br>
        /// <br>�Ǘ��ԍ�  : 11175324-00 Redmine#47299 �݌ɏ�񂪕s���̑Ή�</br>
        /// <returns>STATUS</returns>
        private int SearchStockNoShipmentProc(ref Dictionary<string, StockMonthYearReportDataWork> dicHist, ref ArrayList histKey, ref ArrayList lastKey, ref SqlConnection sqlConnection, StockMonthYearReportWork _stockMonthYearReportWork, ConstantManagement.LogicalMode logicalMode/*, string sectionCode*/)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string hKey = string.Empty;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // STOCKHISTORYRF STHIS  �݌ɗ����f�[�^
                // STOCKRF        STOCK  �݌Ƀ}�X�^
                // SUPPLIERRF     SUPPL  �d����}�X�^
                // GOODSURF       GDSU   ���i�}�X�^
                // MAKERURF       MAKER  ���[�J�[�}�X�^(���[�U�[�o�^��)

                #region Select���쐬
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "  STHIS1.WAREHOUSECODERF" + Environment.NewLine;
                //selectTxt += " ,STHIS1.WAREHOUSENAMERF" + Environment.NewLine;// --- DEL 2015/09/28 ���� FOR MK�A�V�X�g 11175324-00 Redmine#47299 �݌ɏ�񂪕s���̑Ή�
                //selectTxt += " ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                //selectTxt += " ,SUPPL.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += " ,STHIS1.GOODSNORF" + Environment.NewLine;
                //selectTxt += " ,STHIS1.GOODSNAMERF" + Environment.NewLine;// --- DEL 2015/09/28 ���� FOR MK�A�V�X�g 11175324-00 Redmine#47299 �݌ɏ�񂪕s���̑Ή�
                // --- DEL 2015/10/02 Redmine#47299�s��Ή� --------------------------------------->>>>>
                // --- ADD 2015/09/28 ���� FOR MK�A�V�X�g 11175324-00 Redmine#47299 �݌ɏ�񂪕s���̑Ή� --->>>>>
                //selectTxt += " ,STHIS2.WAREHOUSENAMERF" + Environment.NewLine;
                //selectTxt += " ,STHIS2.GOODSNAMERF" + Environment.NewLine;
                // --- ADD 2015/09/28 ���� FOR MK�A�V�X�g 11175324-00 Redmine#47299 �݌ɏ�񂪕s���̑Ή� ---<<<<<
                // --- DEL 2015/10/02 Redmine#47299�s��Ή� ---------------------------------------<<<<<
                // --- ADD 2015/10/02 Redmine#47299�s��Ή� --------------------------------------->>>>>
                selectTxt += " ,WRHS.WAREHOUSENAMERF AS WAREHOUSENAMERF " + Environment.NewLine;
                selectTxt += " ,GDSU.GOODSNAMERF AS GOODSNAMERF " + Environment.NewLine;
                // --- ADD 2015/10/02 Redmine#47299�s��Ή� ---------------------------------------<<<<<
                selectTxt += " ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += " ,STHIS2.PROPERTYSTOCKCNTRF AS LMONTHSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STHIS1.SUMSTOCKCOUNT" + Environment.NewLine;
                selectTxt += " ,STHIS1.SUMMOVEARRIVALCNT" + Environment.NewLine;
                selectTxt += " ,STHIS1.SUMTOTALARRIVALCNT" + Environment.NewLine;
                selectTxt += " ,STHIS1.SUMSALESCOUNT" + Environment.NewLine;
                selectTxt += " ,STHIS1.SUMMOVESHIPMENTCNT" + Environment.NewLine;
                selectTxt += " ,STHIS1.SUMTOTALSHIPMENTCNT" + Environment.NewLine;
                selectTxt += " ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STHIS2.PROPERTYSTOCKPRICERF AS LMONTHSTOCKPRICERF" + Environment.NewLine;

                selectTxt += " ,STHIS1.SUMSTOCKPRICETAXEXC" + Environment.NewLine;
                selectTxt += " ,STHIS1.SUMMOVEARRIVALPRICE" + Environment.NewLine;
                selectTxt += " ,STHIS1.SUMTOTALARRIVALPRICE" + Environment.NewLine;
                selectTxt += " ,STHIS1.SUMSALESMONEYTAXEXC" + Environment.NewLine;
                selectTxt += " ,STHIS1.SUMMOVESHIPMENTPRICE" + Environment.NewLine;
                selectTxt += " ,STHIS1.SUMTOTALSHIPMENTPRICE" + Environment.NewLine;
                selectTxt += " ,STHIS1.SUMGROSSPROFIT" + Environment.NewLine;
                selectTxt += " ,STOCK2.PROPERTYSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK2.PROPERTYSTOCKPRICERF" + Environment.NewLine;
                selectTxt += " ,GDSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,STHIS1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,MAKER.MAKERNAMERF" + Environment.NewLine;
                selectTxt += " ,BLGO.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += " ,GROU.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += " ,GROU.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += " ,STHIS1.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += " ,STOCK2.STOCKUNITPRICEFLRF" + Environment.NewLine;
                //selectTxt += " ,STHIS1.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,STOCK.SECTIONCODERF" + Environment.NewLine;

                //�݌ɗ����f�[�^�P(�e���ڂ̏W�v)
                selectTxt += " FROM (" + Environment.NewLine;
                selectTxt += " SELECT" + Environment.NewLine;
                selectTxt += "  STHISSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.LOGICALDELETECODERF" + Environment.NewLine;
                //selectTxt += " ,STHISSUB1.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.GOODSNORF" + Environment.NewLine;
                // --- DEL 2015/09/28 ���� FOR MK�A�V�X�g 11175324-00 Redmine#47299 �݌ɏ�񂪕s���̑Ή� --->>>>>
                //selectTxt += " ,STHISSUB1.WAREHOUSENAMERF" + Environment.NewLine;
                //selectTxt += " ,STHISSUB1.GOODSNAMERF" + Environment.NewLine;
                // --- DEL 2015/09/28 ���� FOR MK�A�V�X�g 11175324-00 Redmine#47299 �݌ɏ�񂪕s���̑Ή� ---<<<<<
                selectTxt += " ,MAX(STHISSUB1.ADDUPYEARMONTHRF) AS ADDUPYEARMONTHRF" + Environment.NewLine;
                //STOCKCOUNTRF = SUMSTOCKCOUNT(�d����)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN (STHISSUB1.STOCKCOUNTRF+STHISSUB1.STOCKRETGOODSCNTRF) ELSE 0 END) AS SUMSTOCKCOUNT" + Environment.NewLine;
                //MOVEARRIVALCNTRF = SUMMOVEARRIVALCNT(�ړ����א�)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.MOVEARRIVALCNTRF ELSE 0 END) AS SUMMOVEARRIVALCNT" + Environment.NewLine;
                //TOTALARRIVALCNTRF = SUMTOTALARRIVALCNT(�����א�)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.TOTALARRIVALCNTRF ELSE 0 END) AS SUMTOTALARRIVALCNT" + Environment.NewLine;
                //SALESCOUNTRF = SUMSALESCOUNT(���㐔)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN (STHISSUB1.SALESCOUNTRF+STHISSUB1.SALESRETGOODSCNTRF) ELSE 0 END) AS SUMSALESCOUNT" + Environment.NewLine;
                //MOVESHIPMENTCNTRF = SUMMOVESHIPMENTCNT(�ړ��o�א�)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.MOVESHIPMENTCNTRF ELSE 0 END) AS SUMMOVESHIPMENTCNT" + Environment.NewLine;
                //TOTALSHIPMENTCNTRF = SUMTOTALSHIPMENTCNT(���o�א�)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.TOTALSHIPMENTCNTRF ELSE 0 END) AS SUMTOTALSHIPMENTCNT" + Environment.NewLine;
                //STOCKPRICETAXEXCRF = SUMSTOCKPRICETAXEXC(�d�����z�i�Ŕ����j)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN (STHISSUB1.STOCKPRICETAXEXCRF+STHISSUB1.STOCKRETGOODSPRICERF) ELSE 0 END) AS SUMSTOCKPRICETAXEXC" + Environment.NewLine;
                //MOVEARRIVALPRICERF = SUMMOVEARRIVALPRICE(�ړ����׊z)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.MOVEARRIVALPRICERF ELSE 0 END) AS SUMMOVEARRIVALPRICE" + Environment.NewLine;
                //TOTALARRIVALPRICERF = SUMTOTALARRIVALPRICE(�����׋��z)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.TOTALARRIVALPRICERF ELSE 0 END) AS SUMTOTALARRIVALPRICE" + Environment.NewLine;
                //SALESMONEYTAXEXCRF = SUMSALESMONEYTAXEXC(������z�i�Ŕ����j)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN (STHISSUB1.SALESMONEYTAXEXCRF+STHISSUB1.SALESRETGOODSPRICERF) ELSE 0 END) AS SUMSALESMONEYTAXEXC" + Environment.NewLine;
                //MOVESHIPMENTPRICERF = SUMMOVESHIPMENTPRICE(�ړ��o�׊z)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.MOVESHIPMENTPRICERF ELSE 0 END) AS SUMMOVESHIPMENTPRICE" + Environment.NewLine;
                //TOTALSHIPMENTPRICERF = SUMTOTALSHIPMENTPRICE(���o�׋��z)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.TOTALSHIPMENTPRICERF ELSE 0 END) AS SUMTOTALSHIPMENTPRICE" + Environment.NewLine;
                //GROSSPROFITRF = SUMGROSSPROFIT(�e�����z)
                selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @STADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                selectTxt += "      THEN STHISSUB1.GROSSPROFITRF ELSE 0 END) AS SUMGROSSPROFIT" + Environment.NewLine;
                ////STOCKTOTALRF = SUMSTOCKTOTAL(�݌ɑ���)
                //selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @EDADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                //selectTxt += "      THEN STHISSUB1.STOCKTOTALRF ELSE 0 END) AS SUMSTOCKTOTAL" + Environment.NewLine;
                ////STOCKMASHINEPRICERF =  SUMSTOCKMASHINEPRICE(�}�V���݌Ɋz)
                //selectTxt += " ,SUM(CASE WHEN STHISSUB1.ADDUPYEARMONTHRF BETWEEN @EDADDUPYEARMONTH AND @EDADDUPYEARMONTH " + Environment.NewLine;
                //selectTxt += "      THEN STHISSUB1.STOCKMASHINEPRICERF ELSE 0 END) AS SUMSTOCKMASHINEPRICE" + Environment.NewLine;
                selectTxt += " FROM STOCKHISTORYRF AS STHISSUB1" + Environment.NewLine;
                // -- UPD 2010/05/10 --------------------------------------->>>
                //selectTxt += " WHERE ADDUPYEARMONTHRF >= @STADDUPYEARMONTH" + Environment.NewLine;
                //--selectTxt += "   AND ADDUPYEARMONTHRF <= @EDADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += " WHERE ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                selectTxt += "   AND ADDUPYEARMONTHRF >= @STADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += "   AND ADDUPYEARMONTHRF <= @EDADDUPYEARMONTH" + Environment.NewLine;
                // -- UPD 2010/05/10 ---------------------------------------<<<
                selectTxt += " GROUP BY" + Environment.NewLine;
                selectTxt += "  STHISSUB1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.LOGICALDELETECODERF" + Environment.NewLine;
                //selectTxt += " ,STHISSUB1.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB1.GOODSNORF" + Environment.NewLine;
                // --- DEL 2015/09/28 ���� FOR MK�A�V�X�g 11175324-00 Redmine#47299 �݌ɏ�񂪕s���̑Ή� --->>>>>
                //selectTxt += " ,STHISSUB1.WAREHOUSENAMERF" + Environment.NewLine;
                //selectTxt += " ,STHISSUB1.GOODSNAMERF" + Environment.NewLine;
                // --- DEL 2015/09/28 ���� FOR MK�A�V�X�g 11175324-00 Redmine#47299 �݌ɏ�񂪕s���̑Ή� ---<<<<<
                selectTxt += " ) AS STHIS1" + Environment.NewLine;

                //�݌ɗ����f�[�^�Q("�O�����݌ɐ�"��"�O�����݌Ɋz"���擾)
                selectTxt += " LEFT JOIN" + Environment.NewLine;
                selectTxt += "(" + Environment.NewLine;
                selectTxt += " SELECT" + Environment.NewLine;
                selectTxt += "  STHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " ,STHISSUB2.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.PROPERTYSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.PROPERTYSTOCKPRICERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.ADDUPYEARMONTHRF" + Environment.NewLine;
                // --- ADD 2015/09/28 ���� FOR MK�A�V�X�g 11175324-00 Redmine#47299 �݌ɏ�񂪕s���̑Ή� --->>>>>
                selectTxt += " ,STHISSUB2.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += " ,STHISSUB2.GOODSNAMERF" + Environment.NewLine;
                // --- ADD 2015/09/28 ���� FOR MK�A�V�X�g 11175324-00 Redmine#47299 �݌ɏ�񂪕s���̑Ή� ---<<<<<
                selectTxt += " FROM STOCKHISTORYRF AS STHISSUB2" + Environment.NewLine;
                selectTxt += " WHERE" + Environment.NewLine;
                selectTxt += "     STHISSUB2.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                selectTxt += " AND STHISSUB2.ADDUPYEARMONTHRF=@LSTADDUPYEARMONTH" + Environment.NewLine;
                //selectTxt += " AND STHISSUB2.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                //selectTxt += " AND STHISSUB2.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += " ) AS STHIS2" + Environment.NewLine;
                selectTxt += " ON  STHIS2.ENTERPRISECODERF=STHIS1.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND STHIS2.SECTIONCODERF=STHIS1.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " AND STHIS2.WAREHOUSECODERF=STHIS1.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " AND STHIS2.GOODSMAKERCDRF=STHIS1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND STHIS2.GOODSNORF=STHIS1.GOODSNORF" + Environment.NewLine;
                //selectTxt += " AND STHIS2.ADDUPYEARMONTHRF=STHIS1.ADDUPYEARMONTHRF" + Environment.NewLine;

                //�݌Ƀ}�X�^
                selectTxt += " LEFT JOIN STOCKRF STOCK" + Environment.NewLine;
                selectTxt += " ON  STOCK.ENTERPRISECODERF=STHIS1.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND STOCK.SECTIONCODERF=STHIS1.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.WAREHOUSECODERF=STHIS1.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSMAKERCDRF=STHIS1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND STOCK.GOODSNORF=STHIS1.GOODSNORF" + Environment.NewLine;

                ////�d����}�X�^
                //selectTxt += "LEFT JOIN SUPPLIERRF AS SUPPL" + Environment.NewLine;
                //selectTxt += " ON  SUPPL.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND SUPPL.SUPPLIERCDRF=STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;

                //���i�}�X�^
                selectTxt += "LEFT JOIN GOODSURF AS GDSU" + Environment.NewLine;
                selectTxt += " ON  GDSU.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GDSU.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GDSU.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;

                // --- ADD 2015/10/02 Redmine#47299�s��Ή� --------------------------------------->>>>>
                //�q�Ƀ}�X�^
                selectTxt += "LEFT JOIN WAREHOUSERF AS WRHS" + Environment.NewLine;
                selectTxt += " ON  WRHS.ENTERPRISECODERF=STHIS1.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND WRHS.WAREHOUSECODERF=STHIS1.WAREHOUSECODERF" + Environment.NewLine;
                // --- ADD 2015/10/02 Redmine#47299�s��Ή� ---------------------------------------<<<<<

                //���[�J�[�}�X�^(���[�U�[�o�^��)
                selectTxt += "LEFT JOIN MAKERURF AS MAKER" + Environment.NewLine;
                selectTxt += " ON  MAKER.ENTERPRISECODERF=STHIS2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND MAKER.GOODSMAKERCDRF=STHIS2.GOODSMAKERCDRF" + Environment.NewLine;

                //BL�R�[�h�}�X�^
                selectTxt += " LEFT JOIN BLGOODSCDURF AS BLGO" + Environment.NewLine;
                selectTxt += " ON  BLGO.ENTERPRISECODERF=GDSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGO.BLGOODSCODERF=GDSU.BLGOODSCODERF" + Environment.NewLine;

                //�O���[�v�R�[�h�}�X�^
                selectTxt += "LEFT JOIN BLGROUPURF AS GROU" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += " GROU.ENTERPRISECODERF=BLGO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GROU.BLGROUPCODERF = BLGO.BLGROUPCODERF" + Environment.NewLine;

                //���݌ɗp�݌ɗ���
                // -- UPD 2010/05/10 --------------------------------->>>
                //selectTxt += " LEFT JOIN STOCKHISTORYRF AS STOCK2" + Environment.NewLine;
                selectTxt += " LEFT JOIN" + Environment.NewLine;
                selectTxt += " (" + Environment.NewLine;
                selectTxt += " SELECT " + Environment.NewLine;
                selectTxt += "    ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   ,WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "   ,GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "   ,GOODSNORF" + Environment.NewLine;
                selectTxt += "   ,ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += "   ,PROPERTYSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "   ,PROPERTYSTOCKPRICERF" + Environment.NewLine;
                selectTxt += "   ,STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += " FROM STOCKHISTORYRF                               " + Environment.NewLine;
                selectTxt += " WHERE " + Environment.NewLine;
                selectTxt += "       STOCKHISTORYRF.ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                selectTxt += "   AND STOCKHISTORYRF.ADDUPYEARMONTHRF >= @STADDUPYEARMONTH  " + Environment.NewLine;
                selectTxt += "   AND STOCKHISTORYRF.ADDUPYEARMONTHRF <= @EDADDUPYEARMONTH  " + Environment.NewLine;
                selectTxt += " ) AS STOCK2" + Environment.NewLine;
                // -- UPD 2010/05/10 ---------------------------------<<<
                selectTxt += "  ON  STOCK2.ENTERPRISECODERF=STHIS1.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += "  AND STOCK2.SECTIONCODERF=STHIS1.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  AND STOCK2.WAREHOUSECODERF=STHIS1.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  AND STOCK2.GOODSMAKERCDRF=STHIS1.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND STOCK2.GOODSNORF=STHIS1.GOODSNORF" + Environment.NewLine;
                selectTxt += "  AND STOCK2.ADDUPYEARMONTHRF=STHIS1.ADDUPYEARMONTHRF" + Environment.NewLine;
                //WHERE���̍쐬
                selectTxt += MakeWhereString(ref sqlCommand, _stockMonthYearReportWork, logicalMode);

                // �O���c�p
                SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@LSTADDUPYEARMONTH", SqlDbType.Int);
                paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(DummyYearMonth.AddMonths(-1));

                #endregion

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StockMonthYearReportDataWork wkStockMonthYearReportDataWork = new StockMonthYearReportDataWork();

                    //�݌ɗ����i�[����
                    //wkStockMonthYearReportDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkStockMonthYearReportDataWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkStockMonthYearReportDataWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkStockMonthYearReportDataWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    //wkStockMonthYearReportDataWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    //wkStockMonthYearReportDataWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkStockMonthYearReportDataWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockMonthYearReportDataWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStockMonthYearReportDataWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkStockMonthYearReportDataWork.LMonthStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LMONTHSTOCKCNTRF"));
                    wkStockMonthYearReportDataWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUMSTOCKCOUNT"));
                    wkStockMonthYearReportDataWork.MoveArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUMMOVEARRIVALCNT"));
                    wkStockMonthYearReportDataWork.TotalArrivalCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUMTOTALARRIVALCNT"));
                    wkStockMonthYearReportDataWork.SalesCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUMSALESCOUNT"));
                    wkStockMonthYearReportDataWork.MoveShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUMMOVESHIPMENTCNT"));
                    wkStockMonthYearReportDataWork.TotalShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUMTOTALSHIPMENTCNT"));
                    wkStockMonthYearReportDataWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkStockMonthYearReportDataWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkStockMonthYearReportDataWork.LMonthStockPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LMONTHSTOCKPRICERF"));
                    wkStockMonthYearReportDataWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSTOCKPRICETAXEXC"));
                    wkStockMonthYearReportDataWork.MoveArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMMOVEARRIVALPRICE"));
                    wkStockMonthYearReportDataWork.TotalArrivalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMTOTALARRIVALPRICE"));
                    wkStockMonthYearReportDataWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESMONEYTAXEXC"));
                    wkStockMonthYearReportDataWork.MoveShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMMOVESHIPMENTPRICE"));
                    wkStockMonthYearReportDataWork.TotalShipmentPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMTOTALSHIPMENTPRICE"));
                    wkStockMonthYearReportDataWork.GrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMGROSSPROFIT"));
                    //wkStockMonthYearReportDataWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUMSTOCKTOTAL"));
                    //wkStockMonthYearReportDataWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSTOCKMASHINEPRICE"));
                    wkStockMonthYearReportDataWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PROPERTYSTOCKCNTRF"));
                    wkStockMonthYearReportDataWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROPERTYSTOCKPRICERF"));
                    wkStockMonthYearReportDataWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkStockMonthYearReportDataWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockMonthYearReportDataWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkStockMonthYearReportDataWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    wkStockMonthYearReportDataWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    wkStockMonthYearReportDataWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    //���� = ������z - �e�����z
                    //wkStockMonthYearReportDataWork.SalesCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESMONEYTAXEXC")) - SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMGROSSPROFIT"));
                    wkStockMonthYearReportDataWork.SalesCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                    //�e���� = �e�����z / ������z * 100
                    if ((SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMGROSSPROFIT")) != 0) &&
                        (SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESMONEYTAXEXC")) != 0))
                    {
                        double dGrossProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMGROSSPROFIT"));
                        double dSalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SUMSALESMONEYTAXEXC"));
                        double dGrossProfitRate = (dGrossProfit / dSalesMoneyTaxExc) * 100;
                        wkStockMonthYearReportDataWork.GrossProfitRate = dGrossProfitRate;
                    }
                    else
                    {
                        wkStockMonthYearReportDataWork.GrossProfitRate = 0;
                    }
                    #endregion

                    //hKey = sectionCode + wkStockMonthYearReportDataWork.WarehouseCode + wkStockMonthYearReportDataWork.GoodsMakerCd + wkStockMonthYearReportDataWork.GoodsNo;
                    hKey = wkStockMonthYearReportDataWork.WarehouseCode.Trim() + "," + wkStockMonthYearReportDataWork.GoodsNo.Trim() + "," + wkStockMonthYearReportDataWork.GoodsMakerCd.ToString("").Trim();
                    if (dicHist.ContainsKey(hKey) == false)
                    {
                        histKey.Add(hKey);
                        dicHist.Add(hKey, wkStockMonthYearReportDataWork);
                    }
                    else
                    {
                        dicHist[hKey].LMonthStockCnt += wkStockMonthYearReportDataWork.LMonthStockCnt;
                        dicHist[hKey].StockCount += wkStockMonthYearReportDataWork.StockCount;
                        dicHist[hKey].MoveArrivalCnt += wkStockMonthYearReportDataWork.MoveArrivalCnt;
                        dicHist[hKey].TotalArrivalCnt += wkStockMonthYearReportDataWork.TotalArrivalCnt;
                        dicHist[hKey].SalesCount += wkStockMonthYearReportDataWork.SalesCount;
                        dicHist[hKey].MoveShipmentCnt += wkStockMonthYearReportDataWork.MoveShipmentCnt;
                        dicHist[hKey].TotalShipmentCnt += wkStockMonthYearReportDataWork.TotalShipmentCnt;
                        dicHist[hKey].MaximumStockCnt += wkStockMonthYearReportDataWork.MaximumStockCnt;
                        dicHist[hKey].MinimumStockCnt += wkStockMonthYearReportDataWork.MinimumStockCnt;
                        dicHist[hKey].LMonthStockPrice += wkStockMonthYearReportDataWork.LMonthStockPrice;
                        dicHist[hKey].StockPriceTaxExc += wkStockMonthYearReportDataWork.StockPriceTaxExc;
                        dicHist[hKey].MoveArrivalPrice += wkStockMonthYearReportDataWork.MoveArrivalPrice;
                        dicHist[hKey].TotalArrivalPrice += wkStockMonthYearReportDataWork.TotalArrivalPrice;
                        dicHist[hKey].SalesMoneyTaxExc += wkStockMonthYearReportDataWork.SalesMoneyTaxExc;
                        dicHist[hKey].MoveShipmentPrice += wkStockMonthYearReportDataWork.MoveShipmentPrice;
                        dicHist[hKey].TotalShipmentPrice += wkStockMonthYearReportDataWork.TotalShipmentPrice;
                        dicHist[hKey].GrossProfit += wkStockMonthYearReportDataWork.GrossProfit;
                        dicHist[hKey].StockTotal += wkStockMonthYearReportDataWork.StockTotal;
                        dicHist[hKey].StockMashinePrice += wkStockMonthYearReportDataWork.StockMashinePrice;

                        //���� = ������z - �e�����z
                        dicHist[hKey].SalesCost += wkStockMonthYearReportDataWork.SalesCost;
                        //�e���� = �e�����z / ������z * 100
                        if (dicHist[hKey].GrossProfit != 0 && dicHist[hKey].SalesMoneyTaxExc != 0)
                        {
                            double dGrossProfit = dicHist[hKey].GrossProfit;
                            double dSalesMoneyTaxExc = dicHist[hKey].SalesMoneyTaxExc;
                            double dGrossProfitRate = (dGrossProfit / dSalesMoneyTaxExc) * 100;
                            dicHist[hKey].GrossProfitRate = dGrossProfitRate;
                        }
                        else
                        {
                            dicHist[hKey].GrossProfitRate = 0;
                        }
                    }
                    if (lastKey.Contains(hKey) == false)
                    {
                        lastKey.Add(hKey);
                    }

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
                base.WriteErrorLog(ex, "StockMonthYearReportDataWorkDB.SearchStockNoShipmentProc Exception=" + ex.Message);
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

        #region SearchStockProc
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="stockHistoryList">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// <param name="_stockMonthYearReportWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        private int SearchStockProc(ref Dictionary<string, StockMonthYearReportDataWork> dic, ref SqlConnection sqlConnection, StockMonthYearReportWork _stockMonthYearReportWork, ConstantManagement.LogicalMode logicalMode)
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
                selectTxt += "	       STOCK.CREATEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.UPDATEDATETIMERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.FILEHEADERGUIDRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.UPDEMPLOYEECODERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.UPDASSEMBLYID1RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.UPDASSEMBLYID2RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKUNITPRICEFLRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.SUPPLIERSTOCKRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.ACPODRCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.MONTHORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.SALESORDERCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKDIVRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.MOVINGSUPLISTOCKRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.SHIPMENTPOSCNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKTOTALPRICERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.LASTSTOCKDATERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.LASTINVENTORYUPDATERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.NMLSALODRCOUNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.SALESORDERUNITRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.GOODSNONONEHYPHENRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "        ,STOCK.DUPLICATIONSHELFNO1RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.DUPLICATIONSHELFNO2RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKNOTE1RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKNOTE2RF" + Environment.NewLine;
                selectTxt += "        ,STOCK.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.ARRIVALCNTRF" + Environment.NewLine;
                selectTxt += "        ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "        ,STOCK.UPDATEDATERF" + Environment.NewLine;
                selectTxt += "        ,SUPPL.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "        ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "        ,MAKER.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "        ,BLGO.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "        ,GROU.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "        ,GROU.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += " FROM STOCKRF AS STOCK" + Environment.NewLine;
                selectTxt += "LEFT JOIN SUPPLIERRF AS SUPPL" + Environment.NewLine;
                selectTxt += " ON   SUPPL.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SUPPL.SUPPLIERCDRF=STOCK.STOCKSUPPLIERCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN GOODSURF AS GOODS" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GOODS.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GOODS.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND GOODS.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "LEFT JOIN MAKERURF AS MAKER" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      MAKER.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND MAKER.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN BLGOODSCDURF AS BLGO" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      BLGO.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND BLGO.BLGOODSCODERF=GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN BLGROUPURF AS GROU" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GROU.ENTERPRISECODERF=BLGO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GROU.BLGROUPCODERF=BLGO.BLGROUPCODERF" + Environment.NewLine;

                selectTxt += MakeWhereStockString(ref sqlCommand, _stockMonthYearReportWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    StockMonthYearReportDataWork wkstockWork = new StockMonthYearReportDataWork();

                    // �i�[����
                    #region ���o���ʊi�[����

                    wkstockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkstockWork.StockSupplierCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSUPPLIERCODERF"));
                    wkstockWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkstockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkstockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkstockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkstockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkstockWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkstockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkstockWork.MakerShortName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkstockWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    wkstockWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    wkstockWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkstockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkstockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF")); 
                    wkstockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));


                    #endregion

                    key = wkstockWork.WarehouseCode.Trim() + "," + wkstockWork.GoodsNo.Trim() + "," + wkstockWork.GoodsMakerCd.ToString("").Trim();

                    dic.Add(key, wkstockWork);
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
                base.WriteErrorLog(ex, "StockMonthYearReportWorkDB.SearchHistoryProc Exception=" + ex.Message);
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

        #endregion

        #region [�݌ɗ����f�[�^ WHERE��]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockMoveListCndtnWork">���������i�[�N���X</param>
        /// <param name="_productNumberOutPutDiv">���Ԓ��o�敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockMonthYearReportWork _stockMonthYearReportWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = "WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " STHIS1.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockMonthYearReportWork.EnterpriseCode);

            //if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
            //    (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            //{
            //    retstring += " AND STHIS1.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            //    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            //}
            //else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            //{
            //    retstring += " AND STHIS1.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
            //    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
            //    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            //}

            retstring += " AND STHIS1.LOGICALDELETECODERF=0" + Environment.NewLine;

            retstring += " AND STOCK.LOGICALDELETECODERF=0" + Environment.NewLine;

            //�N���x�ݒ�
            SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
            paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(DummyYearMonth);

            SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
            paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockMonthYearReportWork.Ed_AddUpYearMonth);

            //���_�R�[�h
            //if (_stockMonthYearReportWork.SectionCodes != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _stockMonthYearReportWork.SectionCodes)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }
            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND STHIS1.SECTIONCODERF IN (" + sectionCodestr + ") ";
            //    }
            //    retstring += Environment.NewLine;
            //}

            //�q�ɃR�[�h�ݒ�
            if (_stockMonthYearReportWork.St_WarehouseCode != "")
            {
                retstring += " AND STHIS1.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockMonthYearReportWork.St_WarehouseCode);
            }
            if (_stockMonthYearReportWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STHIS1.WAREHOUSECODERF<=@EDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockMonthYearReportWork.Ed_WarehouseCode);
            }

            ////�d����R�[�h�ݒ�
            //if (_stockMonthYearReportWork.St_SupplierCd != 0)
            //{
            //    retstring += " AND SUPPL.SUPPLIERCDRF>=@STSUPPLIERCD" + Environment.NewLine;
            //    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
            //    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockMonthYearReportWork.St_SupplierCd);
            //}
            //if (_stockMonthYearReportWork.Ed_SupplierCd != 999999)
            //{
            //    retstring += " AND SUPPL.SUPPLIERCDRF<=@EDSUPPLIERCD" + Environment.NewLine;
            //    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
            //    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockMonthYearReportWork.Ed_SupplierCd);
            //}

            //���[�J�[�R�[�h�ݒ�
            if (_stockMonthYearReportWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STHIS1.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockMonthYearReportWork.St_GoodsMakerCd);
            }
            if (_stockMonthYearReportWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STHIS1.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockMonthYearReportWork.Ed_GoodsMakerCd);
            }

            //���i�ԍ��ݒ�
            if (_stockMonthYearReportWork.St_GoodsNo != "")
            {
                retstring += " AND STHIS1.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsCd = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsCd.Value = SqlDataMediator.SqlSetString(_stockMonthYearReportWork.St_GoodsNo);
            }
            if (_stockMonthYearReportWork.Ed_GoodsNo != "")
            {
                retstring += " AND STHIS1.GOODSNORF<=@EDGOODSNO" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockMonthYearReportWork.Ed_GoodsNo);
            }

            //���i�Ǘ��敪�P  ���z��ŕ����w�肳���
            if (_stockMonthYearReportWork.PartsManagementDivide1 != null)
            {
                string Divied1 = "";
                foreach (string Divide1str in _stockMonthYearReportWork.PartsManagementDivide1)
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
            if (_stockMonthYearReportWork.PartsManagementDivide2 != null)
            {
                string Divied2 = "";
                foreach (string Divide2str in _stockMonthYearReportWork.PartsManagementDivide2)
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

            #endregion
            return retstring;
        }
        #endregion

        #region [�݌Ƀ}�X�^ WHERE��]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockMoveListCndtnWork">���������i�[�N���X</param>
        /// <param name="_productNumberOutPutDiv">���Ԓ��o�敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereStockString(ref SqlCommand sqlCommand, StockMonthYearReportWork _stockMonthYearReportWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE" + Environment.NewLine;

            // ��ƃR�[�h
            retstring += " STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockMonthYearReportWork.EnterpriseCode);

            // �_���폜�敪
            //if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
            //   (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            //{
            //    retstring += " AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
            //    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            //}
            //else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            //{

            //    retstring += " AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
            //    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            //    if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
            //    else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            //}

            retstring += " AND STOCK.LOGICALDELETECODERF=0" + Environment.NewLine;

            //�q�ɃR�[�h�ݒ�
            if (_stockMonthYearReportWork.St_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockMonthYearReportWork.St_WarehouseCode);
            }
            if (_stockMonthYearReportWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockMonthYearReportWork.Ed_WarehouseCode);
            }

            //���[�J�[�R�[�h�ݒ�
            if (_stockMonthYearReportWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockMonthYearReportWork.St_GoodsMakerCd);
            }
            if (_stockMonthYearReportWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockMonthYearReportWork.Ed_GoodsMakerCd);
            }

            //���i�ԍ��ݒ�
            if (_stockMonthYearReportWork.St_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsCd = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsCd.Value = SqlDataMediator.SqlSetString(_stockMonthYearReportWork.St_GoodsNo);
            }
            if (_stockMonthYearReportWork.Ed_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF<=@EDGOODSNO" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockMonthYearReportWork.Ed_GoodsNo);
            }
            return retstring;
        }
        #endregion
    }
}
