
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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌ɖ��o�׈ꗗ�\DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɖ��o�׈ꗗ�\�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2007.10.01</br>
    /// <br></br>
    /// <br>Update Note: 2008.07.14 �X�{ ��P</br>
    /// <br>           : PM.NS�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/26 30517 �Ė� �x��</br>
    /// <br>           : Mantis.15333</br>
    /// <br>Update Note: 2014/08/11 cheny</br>
    /// <br>�Ǘ��ԍ�   : 11000127-00 redmine #43095 �݌ɖ��o�׈ꗗ�\��ʕ\���s��</br>
    /// <br>Update Note: 2014/09/09 cheny</br>
    /// <br>�Ǘ��ԍ�   : 11000127-00 redmine #43095 </br>
    /// <br>           : �����X�V���Ȃ��ꍇ�A�݌ɖ��o�׈ꗗ�\��ʏC��</br>
    /// <br>Update Note: 2019/11/06 ���V��</br>
    /// <br>�Ǘ��ԍ�   : 11570226-00 PMKOBETSU-2425 </br>
    /// <br>           : �Ώ۔N���̊��Ԏw����R�N�Ƃ���Ή�</br>
    /// </remarks>
    [Serializable]
    public class StockNoShipmentListWorkDB : RemoteDB, IStockNoShipmentListWorkDB
    {

        /// <summary>
        /// �݌ɖ��o�׈ꗗ�\DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : DB�T�[�o�[�R�l�N�V���������擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.10.01</br>
        /// </remarks>
        public StockNoShipmentListWorkDB()
            :
        base("DCZAI02173D", "Broadleaf.Application.Remoting.ParamData.StockNoShipmentListWork", "STOCKHISTORYRF") //���N���X�̃R���X�g���N�^
        {
        }

        /// <summary>���|/���|���z�}�X�^�X�V�����[�g�I�u�W�F�N�g</summary>
        private MonthlyAddUpDB _monthlyAddUpDB = new MonthlyAddUpDB();
        private TtlDayCalcDB ttlDayCalcDB = new TtlDayCalcDB();
        private CompanyInfDB _companyInfDB = new CompanyInfDB();
        private Dictionary<string, int> _addCountList = new Dictionary<string, int>();  // 2010/04/26 Add

        #region �݌ɖ��o�׈ꗗ�\
        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɖ��o�׈ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="stockNoShipmentListResultWork">��������</param>
        /// <param name="stockNoShipmentListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɖ��o�׈ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.10.01</br>
        public int Search(out object stockNoShipmentListWork, object stockNoShipmentListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            stockNoShipmentListWork = null;

            StockNoShipmentListCndtnWork _stockNoShipmentListCndtnWork = stockNoShipmentListCndtnWork as StockNoShipmentListCndtnWork;

            try
            {
                status = SearchProc(out stockNoShipmentListWork, _stockNoShipmentListCndtnWork, readMode, logicalMode);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockNoShipmentListWorkDB.Search Exception=" + ex.Message);
                stockNoShipmentListWork = new ArrayList();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̍݌ɖ��o�׈ꗗ�\LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="stockNoShipmentListResultWork">��������</param>
        /// <param name="_stockNoShipmentListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̍݌ɖ��o�׈ꗗ�\LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2007.10.01</br>
        /// <br></br>
        /// <br>Update Note: 2007.10.01 ���� DC.NS�p�ɏC��</br>
        /// <br>Update Note: 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.07.14</br>
        /// <br>Update Note: redmine #43095 �݌ɖ��o�׈ꗗ�\��ʕ\���s��</br>
        /// <br>Programmer : cheny</br>
        /// <br>Date       : 2014/08/11</br>
        /// <br>Update Note: redmine #43095 �����X�V���Ȃ��ꍇ�A�݌ɖ��o�׈ꗗ�\��ʏC��</br>
        /// <br>Programmer : cheny</br>
        /// <br>Date       : 2014/09/09</br>
        /// <br>Note       : �Ώ۔N���̊��Ԏw����R�N�Ƃ���Ή�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2019/11/06</br>
        private int SearchProc(out object stockNoShipmentListWork, StockNoShipmentListCndtnWork _stockNoShipmentListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;

            _addCountList = new Dictionary<string, int>();  // 2010/04/26 Add

            stockNoShipmentListWork = null;

            ArrayList resultList = new ArrayList();   //���o����
            ArrayList lastKey = new ArrayList();
            
            StockNoShipmentListWork resultwork = new StockNoShipmentListWork();

            int month = 0;
            Dictionary<string, StockNoShipmentListWork> dic = new Dictionary<string, StockNoShipmentListWork>();

            bool Firstflg = false; // �݌ɗ�����1�񂾂��ł����̂�

            try
            {
                //���\�b�h�J�n���ɃR�l�N�V������������擾(SFCMN00615C�̒�`���烆�[�U�[DB[IndexCode_UserDB]���w�肵�ăR�l�N�V������������擾)
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (connectionText == null || connectionText == "") return status;

                //SQL������
                sqlConnection = new SqlConnection(connectionText);
                sqlConnection.Open();

                // �݌Ƀ}�X�^���猋�ʒ��o
                ArrayList stockHistoryList = new ArrayList();
                Dictionary<string, StockNoShipmentListWork> dictionary = new Dictionary<string, StockNoShipmentListWork>(); 

                #region �S�Аݒ�

                //if ((_stockNoShipmentListCndtnWork.SectionCodes.Length == 0) ||
                //    (_stockNoShipmentListCndtnWork.SectionCodes[0] == "")) 
                //{
                //    // �S�Ћ��ʂ̏ꍇ
                //    CustomSerializeArrayList sectionList = new CustomSerializeArrayList();
                //    SectionInfo sectionInfo = new SectionInfo();
                //    SecInfoSetWork sectionInfoSetWork = new SecInfoSetWork();
                //    sectionInfoSetWork.EnterpriseCode = _stockNoShipmentListCndtnWork.EnterpriseCode;
                //    sectionInfoSetWork.LogicalDeleteCode = 0;

                //    sectionInfo.Search(out sectionList, sectionInfoSetWork, ref sqlConnection, readMode, logicalMode);
                //    ArrayList paraList = ListUtils.Find(sectionList, typeof(SecInfoSetWork), ListUtils.FindType.Array) as ArrayList;
                //    string[] str = new string[paraList.Count];
                //    int num = 0;
                //    foreach (SecInfoSetWork sec in paraList)
                //    {
                //        // ArrayList���當����ɑ��
                //        str[num] = sec.SectionCode;
                //        num++;
                //    }
                //    if (str.Length != 0)
                //    {
                //        _stockNoShipmentListCndtnWork.SectionCodes = str;
                //    }
                //}
                #endregion

                if (_stockNoShipmentListCndtnWork.Ed_AddUpYearMonth.Month < _stockNoShipmentListCndtnWork.St_AddUpYearMonth.Month)
                {
                    //----- UPD 2019/11/06 ���V�� PMKOBETSU-2425 �Ώ۔N���̊��Ԏw����R�N�Ƃ���Ή� ----->>>>>
                    //month = 12 - _stockNoShipmentListCndtnWork.St_AddUpYearMonth.Month + _stockNoShipmentListCndtnWork.Ed_AddUpYearMonth.Month;
                    month = (_stockNoShipmentListCndtnWork.Ed_AddUpYearMonth.Year - _stockNoShipmentListCndtnWork.St_AddUpYearMonth.Year) * 12 - _stockNoShipmentListCndtnWork.St_AddUpYearMonth.Month + _stockNoShipmentListCndtnWork.Ed_AddUpYearMonth.Month;
                    //----- UPD 2019/11/06 ���V�� PMKOBETSU-2425 �Ώ۔N���̊��Ԏw����R�N�Ƃ���Ή� -----<<<<<
                }
                else
                {
                    //----- UPD 2019/11/06 ���V�� PMKOBETSU-2425 �Ώ۔N���̊��Ԏw����R�N�Ƃ���Ή� ----->>>>>
                    //month = _stockNoShipmentListCndtnWork.Ed_AddUpYearMonth.Month - _stockNoShipmentListCndtnWork.St_AddUpYearMonth.Month;
                    month = (_stockNoShipmentListCndtnWork.Ed_AddUpYearMonth.Year - _stockNoShipmentListCndtnWork.St_AddUpYearMonth.Year) * 12 + _stockNoShipmentListCndtnWork.Ed_AddUpYearMonth.Month - _stockNoShipmentListCndtnWork.St_AddUpYearMonth.Month;
                    //----- UPD 2019/11/06 ���V�� PMKOBETSU-2425 �Ώ۔N���̊��Ԏw����R�N�Ƃ���Ή� -----<<<<<
                }
                //foreach (string sectionCode in _stockNoShipmentListCndtnWork.SectionCodes)
                //{
                    DateTime AddUpYear = _stockNoShipmentListCndtnWork.St_AddUpYearMonth;

                    int noFirstCount = 0;// 2010/04/26 Add

                    for (int i = 0; i <= month; i++)
                    {
                        Dictionary<string, StockNoShipmentListWork> dicStock = new Dictionary<string, StockNoShipmentListWork>();
                        Dictionary<string, StockNoShipmentListWork> al = new Dictionary<string, StockNoShipmentListWork>();

                        ArrayList keystockList = new ArrayList();
                        ArrayList alkey = new ArrayList();
                        List<StockHistoryWork> stockHistoryWorkList = new List<StockHistoryWork>();

                        List<TtlDayCalcRetWork> retList = new List<TtlDayCalcRetWork>();
                        TtlDayCalcParaWork para = new TtlDayCalcParaWork();

                        # region�@�����`�F�b�N����
                        DateTime stMonth = new DateTime();
                        DateTime edMonth = new DateTime();

                        para.EnterpriseCode = _stockNoShipmentListCndtnWork.EnterpriseCode;
                        //para.SectionCode = sectionCode;
                        Int32 iAddUpDate = Int32.Parse(AddUpYear.ToString("yyyyMMdd")); //�v��N����

                        bool sale = false, buy = false;

                        // ���|
                        status = ttlDayCalcDB.SearchHisMonthlyAccRec(out retList, para, ref sqlConnection);
                        //int iAddUpDateRec = Int32.Parse(iAddUpDate.ToString().Substring(0, 6)) * 100 + Int32.Parse(retList[0].TotalDay.ToString().Substring(6, 2)) + 1;// ADD BY cheny 2014/08/11 FOR redmine43095// DEL BY cheny 2014/09/09 FOR redmine#43095

                        // ADD BY cheny 2014/09/09 FOR redmine#43095---->>>>
                        int iAddUpDateRec = 0;
                        if(iAddUpDate != 0 && retList.Count != 0)
                        {
                            iAddUpDateRec = Int32.Parse(iAddUpDate.ToString().Substring(0, 6)) * 100 + Int32.Parse(retList[0].TotalDay.ToString().Substring(6, 2)) + 1;
                        }
                        // ADD BY cheny 2014/09/09 FOR redmine#43095----<<<<

                        //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retList[0].TotalDay < iAddUpDate)// DEL BY cheny 2014/08/11 FOR redmine43095
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retList[0].TotalDay < iAddUpDateRec)// ADD BY cheny 2014/08/11 FOR redmine43095
                        {
                            sale = true;
                        }
                        retList.Clear();
                        // ���|
                        status = ttlDayCalcDB.SearchHisMonthlyAccPay(out retList, para, ref sqlConnection);
                        //int iAddUpDatePay = Int32.Parse(iAddUpDate.ToString().Substring(0, 6)) * 100 + Int32.Parse(retList[0].TotalDay.ToString().Substring(6, 2)) + 1;// ADD BY cheny 2014/08/11 FOR redmine43095// DEL BY cheny 2014/09/09 FOR redmine#43095
                        // ADD BY cheny 2014/09/09 FOR redmine#43095---->>>>
                        int iAddUpDatePay = 0;
                        if (iAddUpDate != 0 && retList.Count != 0)
                        {
                             iAddUpDatePay = Int32.Parse(iAddUpDate.ToString().Substring(0, 6)) * 100 + Int32.Parse(retList[0].TotalDay.ToString().Substring(6, 2)) + 1;
                        }
                        // ADD BY cheny 2014/09/09 FOR redmine#43095----<<<<

                        //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retList[0].TotalDay < iAddUpDate)// DEL BY cheny 2014/08/11 FOR redmine43095
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL || retList[0].TotalDay < iAddUpDatePay)// ADD BY cheny 2014/08/11 FOR redmine43095
                        {
                            buy = true;
                        }
                        #endregion

                        if (sale == true || buy == true)
                        {
                            if (stockHistoryList.Count == 0)
                            {
                                #region ���ߔ͈͓��t�擾
                                ArrayList list = new ArrayList();
                                CompanyInfWork companyInfWork = new CompanyInfWork();
                                CompanyInfWork companyinfWork = new CompanyInfWork();

                                companyinfWork.EnterpriseCode = _stockNoShipmentListCndtnWork.EnterpriseCode;
                                status = _companyInfDB.Search(out list, companyinfWork, ref sqlConnection);
                                
                                companyinfWork = list[0] as CompanyInfWork;

                                FinYearTableGenerator fin = new FinYearTableGenerator(companyinfWork);

                                fin.GetDaysFromMonth(AddUpYear, out stMonth, out edMonth);
                                #endregion

                                #region �݌Ƀ}�X�^�ǂݍ��ݏ���
                                if (dic.Count == 0)
                                {
                                    // �݌Ƀ}�X�^ Search
                                    status = SearchStockProc(ref dic, ref sqlConnection, _stockNoShipmentListCndtnWork, logicalMode);
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
                            monthlyAddUpWork.EnterpriseCode = _stockNoShipmentListCndtnWork.EnterpriseCode;
                            monthlyAddUpWork.AddUpDateSt = stMonth;
                            monthlyAddUpWork.AddUpDateEd = edMonth;
                            //monthlyAddUpWork.AddUpSecCode = sectionCode;
                            monthlyAddUpWork.AddUpDate = edMonth;
                            monthlyAddUpWork.LstMonAddUpProcDay = AddUpYear.AddMonths(-1);
                            monthlyAddUpWork.AddUpYearMonth = AddUpYear.AddMonths(-1);
                            //monthlyAddUpWork.AddUpYearMonth = edMonth;

                            // -- UPD 2011/05/18 ----------------------------->>>
                            //string retMsg = null;
                            //bool msgDiv = true;

                            // �����X�V�����[�g�݌ɏW�v���\�b�h�Ăяo��
                            //status = _monthlyAddUpDB.MakeStockHistoryParameters(ref monthlyAddUpWork, ref stockHistoryWorkList, out msgDiv, out retMsg, ref sqlConnection);
                            status = GetSalesTimesProc(ref stockHistoryWorkList, monthlyAddUpWork, _stockNoShipmentListCndtnWork, ref sqlConnection);
                            // -- UPD 2011/05/18 -----------------------------<<<
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // �N���X�i�[���\�b�h
                                // 2010/04/26 >>>
                                //status = StockStorage(ref dicStock, ref keystockList, ref lastKey, ref dic, ref stockHistoryWorkList, _stockNoShipmentListCndtnWork);
                                status = StockStorage(ref dicStock, ref keystockList, ref lastKey, ref dic, ref stockHistoryWorkList, _stockNoShipmentListCndtnWork, ref sqlConnection);
                                // 2010/04/26 <<<

                               status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            }
                            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                            {
                                //NOT_FOUND,EOF�̏ꍇ�͎���
                                // ADD BY cheny 2014/08/11 FOR redmine43095---->>>>
                                //NOT_FOUND,EOF�̏ꍇ���N���X�i�[����
                                status = StockStorage(ref dicStock, ref keystockList, ref lastKey, ref dic, ref stockHistoryWorkList, _stockNoShipmentListCndtnWork, ref sqlConnection);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                // ADD BY cheny 2014/08/11 FOR redmine43095----<<<<
                            }
                            else

                            {
                                // -- UPD 2011/05/18 --------------------------------->>>
                                ////�擾���s
                                //throw new Exception("���|���E���|���W�v���W���[������̎擾�Ɏ��s�B");

                                return status;
                                // -- UPD 2011/05/18 ---------------------------------<<<
                            }
                            #endregion
                        }
                        // ���ߏ�������Ă���
                        else
                        {
                            if (Firstflg == false)
                            {
                                status = SearchStockNoShipmentProc(ref al, ref alkey, ref lastKey, ref sqlConnection, _stockNoShipmentListCndtnWork, logicalMode);
                                if (al.Count != 0)
                                {
                                    foreach (string k in alkey)
                                    {
                                        if (dictionary.ContainsKey(k) == true)
                                        {
                                            // 2010/04/26 Del >>>
                                            //dictionary[k].StockTotal += al[k].StockTotal;
                                            //dictionary[k].TotalShipmentCnt += al[k].TotalShipmentCnt;
                                            //dictionary[k].StockMashinePrice += al[k].StockMashinePrice;
                                            // 2010/04/26 Del <<<
                                            if (dictionary[k].SalesTimes == 0)
                                            {
                                                dictionary[k].SalesTimes = al[k].SalesTimes;
                                            }

                                        }
                                        else
                                        {
                                            dictionary[k] = al[k];
                                        }
                                    }
                                }
                                Firstflg = true;
                            }
                            // 2010/04/26 Add >>>
                            else
                            {
                                // ����������2��ڈȍ~�̏�����
                                noFirstCount++;
                            }
                            // 2010/04/26 Add <<<
                        }

                        if (dicStock.Count != 0)
                        {
                            foreach (string k2 in keystockList)
                            {
                                if (dictionary.ContainsKey(k2) == true)
                                {
                                    // 2010/04/26 Del >>>
                                    //dictionary[k2].StockTotal += dicStock[k2].StockTotal;
                                    //dictionary[k2].TotalShipmentCnt += dicStock[k2].TotalShipmentCnt;
                                    //dictionary[k2].StockMashinePrice += dicStock[k2].StockMashinePrice;
                                    // 2010/04/26 Del <<<
                                    if (dictionary[k2].SalesTimes == 0)
                                    {
                                        dictionary[k2].SalesTimes = dicStock[k2].SalesTimes;
                                    }
                                }
                                else
                                {
                                    dictionary[k2] = dicStock[k2];
                                }
                            }
                        }
                        AddUpYear = AddUpYear.AddMonths(1);
                    }
                //}
                for (int j = 0; j < lastKey.Count; j++)
                {
                    string key3 = lastKey[j] as string;
                    dictionary.TryGetValue(key3, out resultwork);
                    if (resultwork.SalesTimes == 0)
                    {
                        // 2010/04/26 Add >>>
                        if (_addCountList[key3] + noFirstCount == month + 1)
                            // 2010/04/26 Add <<<
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
                base.WriteErrorLog(ex, "StockNoShipmentListWorkDB.SearchProc Exception=" + ex.Message);
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
            if (resultList.Count > 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            stockNoShipmentListWork = resultList;
            return status;
        }


        #region [�N���X�i�[����]
        /// <summary>
        /// �������ʃN���X�i�[����
        /// </summary>
        /// <param name="al">���ʊi�[ArrayList</param>sqlConnection
        /// <param name="stockHistoryWorkList">�����X�V���X�g</param>
        // 2010/04/26 >>>
        //private int StockStorage(ref Dictionary<string, StockNoShipmentListWork> dicstock, ref ArrayList keystockList, ref ArrayList lastKey, ref Dictionary<string, StockNoShipmentListWork> dic, ref List<StockHistoryWork> stockHistoryWorkList, StockNoShipmentListCndtnWork _stockNoShipmentListCndtnWork)
        private int StockStorage(ref Dictionary<string, StockNoShipmentListWork> dicstock, ref ArrayList keystockList, ref ArrayList lastKey, ref Dictionary<string, StockNoShipmentListWork> dic, ref List<StockHistoryWork> stockHistoryWorkList, StockNoShipmentListCndtnWork _stockNoShipmentListCndtnWork, ref SqlConnection sqlConnection)
        // 2010/04/26 <<<
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string key = string.Empty;
            string keystock = string.Empty;
            Dictionary<string, int> checkGoodsList = new Dictionary<string, int>();  // 2010/04/26 Add

            //�݌ɗ����i�[����
            foreach (StockHistoryWork st in stockHistoryWorkList)
            {
                StockNoShipmentListWork stshipwork = new StockNoShipmentListWork();

                //if (st.SalesTimes > 0)
                //{
                //    continue;
                //}


                // ���_�R�[�h
                //if (_stockNoShipmentListCndtnWork.SectionCodes != null)
                //{
                //    string Sec = "";
                //    foreach (string Secstr in _stockNoShipmentListCndtnWork.SectionCodes)
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
                //            stshipwork.SectionCode = st.SectionCode.Trim();
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
                if (_stockNoShipmentListCndtnWork.St_WarehouseCode != "")
                {
                    if (_stockNoShipmentListCndtnWork.St_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) == 0 ||
                        _stockNoShipmentListCndtnWork.St_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) < 0)
                    {
                        stshipwork.WarehouseCode = st.WarehouseCode;
                        stshipwork.WarehouseName = st.WarehouseName;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockNoShipmentListCndtnWork.Ed_WarehouseCode != "")
                {
                    if (_stockNoShipmentListCndtnWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) == 0 ||
                        _stockNoShipmentListCndtnWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) > 0)
                    {
                        stshipwork.WarehouseCode = st.WarehouseCode;
                        stshipwork.WarehouseName = st.WarehouseName;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockNoShipmentListCndtnWork.St_WarehouseCode == "" && _stockNoShipmentListCndtnWork.Ed_WarehouseCode == "")
                {
                    stshipwork.WarehouseCode = st.WarehouseCode.Trim();
                    stshipwork.WarehouseName = st.WarehouseName.Trim();
                }

                // ���[�J�[�R�[�h
                if (_stockNoShipmentListCndtnWork.St_GoodsMakerCd != 0)
                {
                    if (_stockNoShipmentListCndtnWork.St_GoodsMakerCd == st.GoodsMakerCd ||
                        _stockNoShipmentListCndtnWork.St_GoodsMakerCd < st.GoodsMakerCd)
                    {
                        stshipwork.GoodsMakerCd = st.GoodsMakerCd;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockNoShipmentListCndtnWork.Ed_GoodsMakerCd != 0)
                {
                    if (_stockNoShipmentListCndtnWork.Ed_GoodsMakerCd == st.GoodsMakerCd ||
                        _stockNoShipmentListCndtnWork.Ed_GoodsMakerCd > st.GoodsMakerCd)
                    {
                        stshipwork.GoodsMakerCd = st.GoodsMakerCd;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockNoShipmentListCndtnWork.St_GoodsMakerCd == 0 && _stockNoShipmentListCndtnWork.Ed_GoodsMakerCd == 0)
                {
                    stshipwork.GoodsMakerCd = st.GoodsMakerCd;
                }
                
                // ���[�J�[����
                stshipwork.MakerName = st.MakerName;

                // �i��
                if (_stockNoShipmentListCndtnWork.St_GoodsNo != "")
                {
                    if (_stockNoShipmentListCndtnWork.St_GoodsNo.CompareTo(st.GoodsNo.Trim()) == 0 ||
                        _stockNoShipmentListCndtnWork.St_GoodsNo.CompareTo(st.GoodsNo.Trim()) < 0)
                    {
                        stshipwork.GoodsNo = st.GoodsNo.Trim();
                    }
                    else 
                    {
                        continue;
                    }
                }
                if (_stockNoShipmentListCndtnWork.Ed_GoodsNo != "")
                {
                    if (_stockNoShipmentListCndtnWork.Ed_GoodsNo.CompareTo(st.GoodsNo.Trim()) == 0 ||
                        _stockNoShipmentListCndtnWork.Ed_GoodsNo.CompareTo(st.GoodsNo.Trim()) > 0)
                    {
                        stshipwork.GoodsNo = st.GoodsNo.Trim();
                    }
                    else
                    {
                        continue;
                    }
                }
                if (_stockNoShipmentListCndtnWork.St_GoodsNo == "" && _stockNoShipmentListCndtnWork.Ed_GoodsNo == "")
                {
                    stshipwork.GoodsNo = st.GoodsNo.Trim();
                }

                // �i��
                stshipwork.GoodsName = st.GoodsName;

                stshipwork.SalesTimes = st.SalesTimes;
                
                //// ���݌ɐ�
                //stshipwork.StockTotal = st.StockTotal;
                
                //// ���o�א�
                //stshipwork.TotalShipmentCnt = st.TotalShipmentCnt;

                // 2010/04/26 >>>
                //key = st.WarehouseCode + st.GoodsNo + st.GoodsMakerCd.ToString("0000");
                key = string.Format("{0:D4}", Convert.ToInt32(st.WarehouseCode.Trim())) + st.GoodsMakerCd.ToString("0000") + st.GoodsNo;
                // 2010/04/26 <<<
                if (dic.ContainsKey(key) == true)
                {
                    // 2010/04/26 Add �����X�V���X�g�Ƀf�[�^������΃��X�g�ɒǉ� >>>
                    if (checkGoodsList.ContainsKey(key) == false)
                        checkGoodsList.Add(key, 1);
                    // 2010/04/26 Add <<<
                    StockNoShipmentListWork stockWork = dic[key] as StockNoShipmentListWork;

                    // ���݌ɐ�
                    stshipwork.StockTotal = stockWork.StockTotal;

                    // ���o�א�
                    stshipwork.TotalShipmentCnt = stockWork.TotalShipmentCnt;

                    // ���_����
                    stshipwork.SectionGuideNm = stockWork.SectionGuideNm;

                    ////�d����R�[�h
                    //if (_stockNoShipmentListCndtnWork.St_SupplierCd != 0)
                    //{
                    //    if (_stockNoShipmentListCndtnWork.St_SupplierCd == stockWork.SupplierCd ||
                    //        _stockNoShipmentListCndtnWork.St_SupplierCd < stockWork.SupplierCd)
                    //    {
                    //        stshipwork.SupplierCd = stockWork.SupplierCd;
                    //    }
                    //    else
                    //    {
                    //        continue;
                    //    }
                    //}
                    //if (_stockNoShipmentListCndtnWork.Ed_SupplierCd != 0)
                    //{
                    //    if (_stockNoShipmentListCndtnWork.Ed_SupplierCd == stockWork.SupplierCd ||
                    //        _stockNoShipmentListCndtnWork.Ed_SupplierCd > stockWork.SupplierCd)
                    //    {
                    //        stshipwork.SupplierCd = stockWork.SupplierCd;
                    //    }
                    //    else
                    //    {
                    //        continue;
                    //    }
                    //}
                    //if(_stockNoShipmentListCndtnWork.St_SupplierCd == 0 && _stockNoShipmentListCndtnWork.Ed_SupplierCd ==0)
                    //{
                    //    stshipwork.SupplierCd = stockWork.SupplierCd;
                    //}

                    // �d���旪��
                    //stshipwork.SupplierSnm = stockWork.SupplierSnm;

                    // ���i�Ǘ��敪�P
                    if (_stockNoShipmentListCndtnWork.PartsManagementDivide1 != null)
                    {
                        string Divied1 = "";
                        foreach (string Divide1str in _stockNoShipmentListCndtnWork.PartsManagementDivide1)
                        {
                            if (Divied1 != "")
                            {
                                Divied1 += ",";
                            }
                            Divied1 += "'" + Divide1str + "'";
                        }

                        if (Divied1 != "")
                        {
                            if (stockWork.PartsManagementDivide1 == "") continue;
                            if (Divied1.Contains(stockWork.PartsManagementDivide1.Trim()))
                            {
                                stshipwork.PartsManagementDivide1 = stockWork.PartsManagementDivide1.Trim();
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            stshipwork.PartsManagementDivide1 = stockWork.PartsManagementDivide1.Trim();
                        }

                    }

                    // ���i�Ǘ��敪�Q
                    if (_stockNoShipmentListCndtnWork.PartsManagementDivide2 != null)
                    {
                        string Divied2 = "";
                        foreach (string Divide2str in _stockNoShipmentListCndtnWork.PartsManagementDivide2)
                        {
                            if (Divied2 != "")
                            {
                                Divied2 += ",";
                            }
                            Divied2 += "'" + Divide2str + "'";
                        }

                        if (Divied2 != "")
                        {
                            if (stockWork.PartsManagementDivide2 == "") continue;
                            if (Divied2.Contains(stockWork.PartsManagementDivide2.Trim()))
                            {
                                stshipwork.PartsManagementDivide2 = stockWork.PartsManagementDivide2.Trim();
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            stshipwork.PartsManagementDivide2 = stockWork.PartsManagementDivide2.Trim();
                        }
                    }



                    // ���i�敪
                    if (_stockNoShipmentListCndtnWork.St_EnterpriseGanreCode != 0)
                    {
                        if (_stockNoShipmentListCndtnWork.St_EnterpriseGanreCode > stockWork.EnterpriseGanreCode)
                        {
                            continue;
                        }
                        else
                        {
                            stshipwork.EnterpriseGanreCode = stockWork.EnterpriseGanreCode;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.Ed_EnterpriseGanreCode != 0)
                    {
                        if (_stockNoShipmentListCndtnWork.Ed_EnterpriseGanreCode < stockWork.EnterpriseGanreCode)
                        {
                            continue;
                        }
                        else
                        {
                            stshipwork.EnterpriseGanreCode = stockWork.EnterpriseGanreCode;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.St_EnterpriseGanreCode == 0 && _stockNoShipmentListCndtnWork.Ed_EnterpriseGanreCode == 0)
                    {
                        stshipwork.EnterpriseGanreCode = stockWork.EnterpriseGanreCode;
                    }

                    // ���i�啪��
                    if (_stockNoShipmentListCndtnWork.St_GoodsLGroup != 0)
                    {
                        if (_stockNoShipmentListCndtnWork.St_GoodsLGroup > stockWork.GoodsLGroup)
                        {
                            continue;
                        }
                        else
                        {
                            stshipwork.GoodsLGroup = stockWork.GoodsLGroup;
                        }

                    }
                    if (_stockNoShipmentListCndtnWork.Ed_GoodsLGroup != 0)
                    {
                        if (_stockNoShipmentListCndtnWork.Ed_GoodsLGroup < stockWork.GoodsLGroup)
                        {
                            continue;
                        }
                        else
                        {
                            stshipwork.GoodsLGroup = stockWork.GoodsLGroup;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.St_GoodsLGroup == 0 && _stockNoShipmentListCndtnWork.Ed_GoodsLGroup == 0)
                    {
                        stshipwork.GoodsLGroup = stockWork.GoodsLGroup;
                    }

                    // ���i������
                    if (_stockNoShipmentListCndtnWork.St_GoodsMGroup != 0)
                    {
                        if (_stockNoShipmentListCndtnWork.St_GoodsMGroup > stockWork.GoodsMGroup)
                        {
                            continue;
                        }
                        else
                        {
                            stshipwork.GoodsMGroup = stockWork.GoodsMGroup;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.Ed_GoodsMGroup != 0)
                    {
                        if (_stockNoShipmentListCndtnWork.Ed_GoodsMGroup < stockWork.GoodsMGroup)
                        {
                            continue;
                        }
                        else
                        {
                            stshipwork.GoodsMGroup = stockWork.GoodsMGroup;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.St_GoodsMGroup == 0 && _stockNoShipmentListCndtnWork.Ed_GoodsMGroup == 0)
                    {
                        stshipwork.GoodsMGroup = stockWork.GoodsMGroup;
                    }

                    // �O���[�v�R�[�h
                    if (_stockNoShipmentListCndtnWork.St_BLGroupCode != 0)
                    {
                        if (_stockNoShipmentListCndtnWork.St_BLGroupCode > stockWork.BLGroupCode)
                        {
                            continue;
                        }
                        else
                        {
                            stshipwork.BLGroupCode = stockWork.BLGroupCode;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.Ed_BLGroupCode != 0)
                    {
                        if (_stockNoShipmentListCndtnWork.Ed_BLGroupCode < stockWork.BLGroupCode)
                        {
                            continue;
                        }
                        else
                        {
                            stshipwork.BLGroupCode = stockWork.BLGroupCode;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.St_BLGoodsCode == 0 && _stockNoShipmentListCndtnWork.Ed_BLGoodsCode == 0)
                    {
                        stshipwork.BLGroupCode = stockWork.BLGroupCode;
                    }

                    // BL�R�[�h
                    if (_stockNoShipmentListCndtnWork.St_BLGoodsCode != 0)
                    {
                        if (_stockNoShipmentListCndtnWork.St_BLGoodsCode == stockWork.BLGoodsCode ||
                            _stockNoShipmentListCndtnWork.St_BLGoodsCode < stockWork.BLGoodsCode)
                        {
                            stshipwork.BLGoodsCode = stockWork.BLGoodsCode;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.Ed_BLGoodsCode != 0)
                    {
                        if (_stockNoShipmentListCndtnWork.Ed_BLGoodsCode == stockWork.BLGoodsCode ||
                            _stockNoShipmentListCndtnWork.Ed_BLGoodsCode > stockWork.BLGoodsCode)
                        {
                            stshipwork.BLGoodsCode = stockWork.BLGoodsCode;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.St_BLGoodsCode == 0 && _stockNoShipmentListCndtnWork.Ed_BLGoodsCode == 0)
                    {
                        stshipwork.BLGoodsCode = stockWork.BLGoodsCode;
                    }

                    //�I��
                    if (_stockNoShipmentListCndtnWork.St_WarehouseShelfNo != "")
                    {
                        if (_stockNoShipmentListCndtnWork.St_WarehouseShelfNo.CompareTo(stockWork.WarehouseShelfNo) == 0 ||
                            _stockNoShipmentListCndtnWork.St_WarehouseShelfNo.CompareTo(stockWork.WarehouseShelfNo) < 0)
                        {
                            stshipwork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo != "")
                    {
                        if (_stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo.CompareTo(stockWork.WarehouseShelfNo) == 0 ||
                            _stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo.CompareTo(stockWork.WarehouseShelfNo) > 0)
                        {
                            stshipwork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.St_WarehouseShelfNo == "" && _stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo == "")
                    {
                        stshipwork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                    }

                    // �}�V���݌Ɋz
                    stshipwork.StockMashinePrice = stockWork.StockMashinePrice;

                    // �Œ�݌ɐ�
                    stshipwork.MinimumStockCnt = stockWork.MinimumStockCnt;

                    // �ō��݌ɐ�
                    stshipwork.MaximumStockCnt = stockWork.MaximumStockCnt;

                    // �݌ɓo�^��
                    if (_stockNoShipmentListCndtnWork.StockCreateDate != DateTime.MinValue)
                    {
                        if (_stockNoShipmentListCndtnWork.StockCreateDateDiv == 0 && (_stockNoShipmentListCndtnWork.StockCreateDate == stockWork.StockCreateDate ||
                            _stockNoShipmentListCndtnWork.StockCreateDate > stockWork.StockCreateDate))
                        {
                            stshipwork.StockCreateDate = stockWork.StockCreateDate;
                        }
                        else if (_stockNoShipmentListCndtnWork.StockCreateDateDiv == 1 && (_stockNoShipmentListCndtnWork.StockCreateDate == stockWork.StockCreateDate ||
                            _stockNoShipmentListCndtnWork.StockCreateDate < stockWork.StockCreateDate))
                        {
                            stshipwork.StockCreateDate = stockWork.StockCreateDate;
                        }
                        else
                        {
                            continue;
                        }

                    }
                    else
                    {
                        stshipwork.StockCreateDate = stockWork.StockCreateDate;
                    }

                    // �ŏI�����
                    stshipwork.LastSalesDate = stockWork.LastSalesDate;

                    // 2010/04/26 >>>
                    //keystock = stshipwork.SectionCode + stshipwork.WarehouseCode + stshipwork.GoodsMakerCd + stshipwork.GoodsNo;
                    keystock = string.Format("{0:D4}", Convert.ToInt32(stshipwork.WarehouseCode.Trim())) + stshipwork.GoodsMakerCd.ToString("0000") +stshipwork.GoodsNo.Trim();
                    // 2010/04/26 <<<

                    if (keystockList.Contains(keystock) == false)
                    {
                        keystockList.Add(keystock);
                        dicstock.Add(keystock, stshipwork);
                    }
                    // 2010/04/26 Add >>>
                    if (st.SalesTimes == 0)
                    {
                        if (_addCountList.ContainsKey(keystock))
                        {
                            _addCountList[keystock] = _addCountList[keystock] + 1;
                        }
                        else
                        {
                            _addCountList.Add(keystock, 1);
                        }
                    }
                    // 2010/04/26 Add <<<
                    if (lastKey.Contains(keystock) == false)
                    {
                        lastKey.Add(keystock);
                    }

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            // 2010/04/26 Add >>>
            List<KeyValuePair<string, StockNoShipmentListWork>> list = new List<KeyValuePair<string, StockNoShipmentListWork>>(dic);
            foreach (KeyValuePair<string, StockNoShipmentListWork> checkKey in dic)
            {
                // �����X�V���X�g�Ƀf�[�^���Ȃ���΁A�o�͑Ώ�
                if (checkGoodsList.ContainsKey(checkKey.Key) == false)
                {
                    StockNoShipmentListWork stshipwork = new StockNoShipmentListWork();
                    StockNoShipmentListWork st = new StockNoShipmentListWork();
                    st = checkKey.Value;

                    // �q�ɃR�[�h�E����
                    if (_stockNoShipmentListCndtnWork.St_WarehouseCode != "")
                    {
                        if (_stockNoShipmentListCndtnWork.St_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) == 0 ||
                            _stockNoShipmentListCndtnWork.St_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) < 0)
                        {
                            stshipwork.WarehouseCode = st.WarehouseCode;
                            stshipwork.WarehouseName = st.WarehouseName;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.Ed_WarehouseCode != "")
                    {
                        if (_stockNoShipmentListCndtnWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) == 0 ||
                            _stockNoShipmentListCndtnWork.Ed_WarehouseCode.CompareTo(st.WarehouseCode.Trim()) > 0)
                        {
                            stshipwork.WarehouseCode = st.WarehouseCode;
                            stshipwork.WarehouseName = st.WarehouseName;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.St_WarehouseCode == "" && _stockNoShipmentListCndtnWork.Ed_WarehouseCode == "")
                    {
                        stshipwork.WarehouseCode = st.WarehouseCode.Trim();
                        stshipwork.WarehouseName = st.WarehouseName.Trim();
                    }

                    // ���[�J�[�R�[�h
                    if (_stockNoShipmentListCndtnWork.St_GoodsMakerCd != 0)
                    {
                        if (_stockNoShipmentListCndtnWork.St_GoodsMakerCd == st.GoodsMakerCd ||
                            _stockNoShipmentListCndtnWork.St_GoodsMakerCd < st.GoodsMakerCd)
                        {
                            stshipwork.GoodsMakerCd = st.GoodsMakerCd;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.Ed_GoodsMakerCd != 0)
                    {
                        if (_stockNoShipmentListCndtnWork.Ed_GoodsMakerCd == st.GoodsMakerCd ||
                            _stockNoShipmentListCndtnWork.Ed_GoodsMakerCd > st.GoodsMakerCd)
                        {
                            stshipwork.GoodsMakerCd = st.GoodsMakerCd;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.St_GoodsMakerCd == 0 && _stockNoShipmentListCndtnWork.Ed_GoodsMakerCd == 0)
                    {
                        stshipwork.GoodsMakerCd = st.GoodsMakerCd;
                    }

                    // ���[�J�[����
                    stshipwork.MakerName = st.MakerName;

                    // �i��
                    if (_stockNoShipmentListCndtnWork.St_GoodsNo != "")
                    {
                        if (_stockNoShipmentListCndtnWork.St_GoodsNo.CompareTo(st.GoodsNo.Trim()) == 0 ||
                            _stockNoShipmentListCndtnWork.St_GoodsNo.CompareTo(st.GoodsNo.Trim()) < 0)
                        {
                            stshipwork.GoodsNo = st.GoodsNo.Trim();
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.Ed_GoodsNo != "")
                    {
                        if (_stockNoShipmentListCndtnWork.Ed_GoodsNo.CompareTo(st.GoodsNo.Trim()) == 0 ||
                            _stockNoShipmentListCndtnWork.Ed_GoodsNo.CompareTo(st.GoodsNo.Trim()) > 0)
                        {
                            stshipwork.GoodsNo = st.GoodsNo.Trim();
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (_stockNoShipmentListCndtnWork.St_GoodsNo == "" && _stockNoShipmentListCndtnWork.Ed_GoodsNo == "")
                    {
                        stshipwork.GoodsNo = st.GoodsNo.Trim();
                    }

                    // �i��
                    stshipwork.GoodsName = st.GoodsName;

                    stshipwork.SalesTimes = st.SalesTimes;

                    key = string.Format("{0:D4}", Convert.ToInt32(st.WarehouseCode.Trim())) + st.GoodsMakerCd.ToString("0000") + st.GoodsNo;
                   
                    if (dic.ContainsKey(key) == true)
                    {
                        StockNoShipmentListWork stockWork = checkKey.Value as StockNoShipmentListWork;

                        // ���݌ɐ�
                        stshipwork.StockTotal = stockWork.StockTotal;

                        // ���o�א�
                        stshipwork.TotalShipmentCnt = stockWork.TotalShipmentCnt;

                        // ���_����
                        stshipwork.SectionGuideNm = stockWork.SectionGuideNm;

                        // ���i�Ǘ��敪�P
                        if (_stockNoShipmentListCndtnWork.PartsManagementDivide1 != null)
                        {
                            string Divied1 = "";
                            foreach (string Divide1str in _stockNoShipmentListCndtnWork.PartsManagementDivide1)
                            {
                                if (Divied1 != "")
                                {
                                    Divied1 += ",";
                                }
                                Divied1 += "'" + Divide1str + "'";
                            }

                            if (Divied1 != "")
                            {
                                if (stockWork.PartsManagementDivide1 == "") continue;
                                if (Divied1.Contains(stockWork.PartsManagementDivide1.Trim()))
                                {
                                    stshipwork.PartsManagementDivide1 = stockWork.PartsManagementDivide1.Trim();
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                stshipwork.PartsManagementDivide1 = stockWork.PartsManagementDivide1.Trim();
                            }

                        }

                        // ���i�Ǘ��敪�Q
                        if (_stockNoShipmentListCndtnWork.PartsManagementDivide2 != null)
                        {
                            string Divied2 = "";
                            foreach (string Divide2str in _stockNoShipmentListCndtnWork.PartsManagementDivide2)
                            {
                                if (Divied2 != "")
                                {
                                    Divied2 += ",";
                                }
                                Divied2 += "'" + Divide2str + "'";
                            }

                            if (Divied2 != "")
                            {
                                if (stockWork.PartsManagementDivide2 == "") continue;
                                if (Divied2.Contains(stockWork.PartsManagementDivide2.Trim()))
                                {
                                    stshipwork.PartsManagementDivide2 = stockWork.PartsManagementDivide2.Trim();
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                stshipwork.PartsManagementDivide2 = stockWork.PartsManagementDivide2.Trim();
                            }
                        }



                        // ���i�敪
                        if (_stockNoShipmentListCndtnWork.St_EnterpriseGanreCode != 0)
                        {
                            if (_stockNoShipmentListCndtnWork.St_EnterpriseGanreCode > stockWork.EnterpriseGanreCode)
                            {
                                continue;
                            }
                            else
                            {
                                stshipwork.EnterpriseGanreCode = stockWork.EnterpriseGanreCode;
                            }
                        }
                        if (_stockNoShipmentListCndtnWork.Ed_EnterpriseGanreCode != 0)
                        {
                            if (_stockNoShipmentListCndtnWork.Ed_EnterpriseGanreCode < stockWork.EnterpriseGanreCode)
                            {
                                continue;
                            }
                            else
                            {
                                stshipwork.EnterpriseGanreCode = stockWork.EnterpriseGanreCode;
                            }
                        }
                        if (_stockNoShipmentListCndtnWork.St_EnterpriseGanreCode == 0 && _stockNoShipmentListCndtnWork.Ed_EnterpriseGanreCode == 0)
                        {
                            stshipwork.EnterpriseGanreCode = stockWork.EnterpriseGanreCode;
                        }

                        // ���i�啪��
                        if (_stockNoShipmentListCndtnWork.St_GoodsLGroup != 0)
                        {
                            if (_stockNoShipmentListCndtnWork.St_GoodsLGroup > stockWork.GoodsLGroup)
                            {
                                continue;
                            }
                            else
                            {
                                stshipwork.GoodsLGroup = stockWork.GoodsLGroup;
                            }

                        }
                        if (_stockNoShipmentListCndtnWork.Ed_GoodsLGroup != 0)
                        {
                            if (_stockNoShipmentListCndtnWork.Ed_GoodsLGroup < stockWork.GoodsLGroup)
                            {
                                continue;
                            }
                            else
                            {
                                stshipwork.GoodsLGroup = stockWork.GoodsLGroup;
                            }
                        }
                        if (_stockNoShipmentListCndtnWork.St_GoodsLGroup == 0 && _stockNoShipmentListCndtnWork.Ed_GoodsLGroup == 0)
                        {
                            stshipwork.GoodsLGroup = stockWork.GoodsLGroup;
                        }

                        // ���i������
                        if (_stockNoShipmentListCndtnWork.St_GoodsMGroup != 0)
                        {
                            if (_stockNoShipmentListCndtnWork.St_GoodsMGroup > stockWork.GoodsMGroup)
                            {
                                continue;
                            }
                            else
                            {
                                stshipwork.GoodsMGroup = stockWork.GoodsMGroup;
                            }
                        }
                        if (_stockNoShipmentListCndtnWork.Ed_GoodsMGroup != 0)
                        {
                            if (_stockNoShipmentListCndtnWork.Ed_GoodsMGroup < stockWork.GoodsMGroup)
                            {
                                continue;
                            }
                            else
                            {
                                stshipwork.GoodsMGroup = stockWork.GoodsMGroup;
                            }
                        }
                        if (_stockNoShipmentListCndtnWork.St_GoodsMGroup == 0 && _stockNoShipmentListCndtnWork.Ed_GoodsMGroup == 0)
                        {
                            stshipwork.GoodsMGroup = stockWork.GoodsMGroup;
                        }

                        // �O���[�v�R�[�h
                        if (_stockNoShipmentListCndtnWork.St_BLGroupCode != 0)
                        {
                            if (_stockNoShipmentListCndtnWork.St_BLGroupCode > stockWork.BLGroupCode)
                            {
                                continue;
                            }
                            else
                            {
                                stshipwork.BLGroupCode = stockWork.BLGroupCode;
                            }
                        }
                        if (_stockNoShipmentListCndtnWork.Ed_BLGroupCode != 0)
                        {
                            if (_stockNoShipmentListCndtnWork.Ed_BLGroupCode < stockWork.BLGroupCode)
                            {
                                continue;
                            }
                            else
                            {
                                stshipwork.BLGroupCode = stockWork.BLGroupCode;
                            }
                        }
                        if (_stockNoShipmentListCndtnWork.St_BLGoodsCode == 0 && _stockNoShipmentListCndtnWork.Ed_BLGoodsCode == 0)
                        {
                            stshipwork.BLGroupCode = stockWork.BLGroupCode;
                        }

                        // BL�R�[�h
                        if (_stockNoShipmentListCndtnWork.St_BLGoodsCode != 0)
                        {
                            if (_stockNoShipmentListCndtnWork.St_BLGoodsCode == stockWork.BLGoodsCode ||
                                _stockNoShipmentListCndtnWork.St_BLGoodsCode < stockWork.BLGoodsCode)
                            {
                                stshipwork.BLGoodsCode = stockWork.BLGoodsCode;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (_stockNoShipmentListCndtnWork.Ed_BLGoodsCode != 0)
                        {
                            if (_stockNoShipmentListCndtnWork.Ed_BLGoodsCode == stockWork.BLGoodsCode ||
                                _stockNoShipmentListCndtnWork.Ed_BLGoodsCode > stockWork.BLGoodsCode)
                            {
                                stshipwork.BLGoodsCode = stockWork.BLGoodsCode;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (_stockNoShipmentListCndtnWork.St_BLGoodsCode == 0 && _stockNoShipmentListCndtnWork.Ed_BLGoodsCode == 0)
                        {
                            stshipwork.BLGoodsCode = stockWork.BLGoodsCode;
                        }

                        //�I��
                        if (_stockNoShipmentListCndtnWork.St_WarehouseShelfNo != "")
                        {
                            if (_stockNoShipmentListCndtnWork.St_WarehouseShelfNo.CompareTo(stockWork.WarehouseShelfNo) == 0 ||
                                _stockNoShipmentListCndtnWork.St_WarehouseShelfNo.CompareTo(stockWork.WarehouseShelfNo) < 0)
                            {
                                stshipwork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (_stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo != "")
                        {
                            if (_stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo.CompareTo(stockWork.WarehouseShelfNo) == 0 ||
                                _stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo.CompareTo(stockWork.WarehouseShelfNo) > 0)
                            {
                                stshipwork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (_stockNoShipmentListCndtnWork.St_WarehouseShelfNo == "" && _stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo == "")
                        {
                            stshipwork.WarehouseShelfNo = stockWork.WarehouseShelfNo;
                        }

                        // �}�V���݌Ɋz
                        stshipwork.StockMashinePrice = stockWork.StockMashinePrice;

                        // �Œ�݌ɐ�
                        stshipwork.MinimumStockCnt = stockWork.MinimumStockCnt;

                        // �ō��݌ɐ�
                        stshipwork.MaximumStockCnt = stockWork.MaximumStockCnt;

                        // �݌ɓo�^��
                        if (_stockNoShipmentListCndtnWork.StockCreateDate != DateTime.MinValue)
                        {
                            if (_stockNoShipmentListCndtnWork.StockCreateDateDiv == 0 && (_stockNoShipmentListCndtnWork.StockCreateDate == stockWork.StockCreateDate ||
                                _stockNoShipmentListCndtnWork.StockCreateDate > stockWork.StockCreateDate))
                            {
                                stshipwork.StockCreateDate = stockWork.StockCreateDate;
                            }
                            else if (_stockNoShipmentListCndtnWork.StockCreateDateDiv == 1 && (_stockNoShipmentListCndtnWork.StockCreateDate == stockWork.StockCreateDate ||
                                _stockNoShipmentListCndtnWork.StockCreateDate < stockWork.StockCreateDate))
                            {
                                stshipwork.StockCreateDate = stockWork.StockCreateDate;
                            }
                            else
                            {
                                continue;
                            }

                        }
                        else
                        {
                            stshipwork.StockCreateDate = stockWork.StockCreateDate;
                        }

                        // �ŏI�����
                        stshipwork.LastSalesDate = stockWork.LastSalesDate;

                        // 2010/04/26 >>>
                        //keystock = string.Format("{0:D4}", Convert.ToInt32(stshipwork.WarehouseCode.Trim())) + stshipwork.GoodsMakerCd + stshipwork.GoodsNo.Trim();
                        keystock = string.Format("{0:D4}", Convert.ToInt32(stshipwork.WarehouseCode.Trim())) + stshipwork.GoodsMakerCd.ToString("0000") + stshipwork.GoodsNo.Trim();
                        // 2010/04/26 <<<

                        if (keystockList.Contains(keystock) == false)
                        {
                            keystockList.Add(keystock);
                            dicstock.Add(keystock, stshipwork);
                        }
                        if (st.SalesTimes == 0)
                        {
                            if (_addCountList.ContainsKey(keystock))
                            {
                                _addCountList[keystock] = _addCountList[keystock] + 1;
                            }
                            else
                            {
                                _addCountList.Add(keystock, 1);
                            }
                        }
                        if (lastKey.Contains(keystock) == false)
                        {
                            lastKey.Add(keystock);
                        }
                    }
                }
            }
            // 2010/04/26 Add <<<
            return status;
        }
        #endregion

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="al">��������ArrayList</param>
        /// <param name="sqlConnection">SqlConnection</param>
        /// 
        /// <param name="_stockNoShipmentListCndtnWork">���������i�[�N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Ώ۔N���̊��Ԏw����R�N�Ƃ���Ή�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2019/11/06</br>
        /// </remarks>
        private int SearchStockNoShipmentProc(ref Dictionary<string, StockNoShipmentListWork> Shipmentlst, ref ArrayList alkey, ref ArrayList lastKey, ref SqlConnection sqlConnection, StockNoShipmentListCndtnWork _stockNoShipmentListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string keyHist = string.Empty;

            try
            {
                string selectTxt = "";
                sqlCommand = new SqlCommand(selectTxt, sqlConnection);

                // �Ώۃe�[�u��
                // STOCKHISTORYRF STHIS  �݌ɗ����f�[�^
                // STOCKRF        STOCK  �݌Ƀ}�X�^
                // SECINFOSETRF   SECI   ���_���ݒ�}�X�^
                // GOODSMNGRF     GOODSM ���i�Ǘ����}�X�^
                // SUPPLIERRF     SUP    �d����}�X�^
                // GOODSURF       GDSU   ���i�}�X�^

                #region [Select���쐬]
                #region DELETE
                /*
                selectTxt += "SELECT" + Environment.NewLine;
                selectTxt += "   STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "  ,GOODSM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "  ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "  ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "  ,GDSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKTOTALRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.TOTALSHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKMASHINEPRICERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "  ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,BLGO.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,GROU.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "  ,GROU.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "  ,GDSU.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += " FROM" + Environment.NewLine;
                selectTxt += " (" + Environment.NewLine;

                #region [�݌Ƀf�[�^�{�݌ɗ����f�[�^���oQuery]
                selectTxt += "  SELECT" + Environment.NewLine;
                selectTxt += "    STOCKSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.LOGICALDELETECODERF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "   ,STHIS.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.GOODSNORF" + Environment.NewLine;
                //selectTxt += "   ,STHIS.STOCKTOTALRF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.SHIPMENTPOSCNTRF AS STOCKTOTALRF" + Environment.NewLine;
                selectTxt += "   ,STHIS.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "   ,STHIS.STOCKMASHINEPRICERF" + Environment.NewLine;
                selectTxt += "   ,STHIS.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "   ,STHIS.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "   ,STHIS.GOODSNAMERF" + Environment.NewLine;
                //selectTxt += "   ,STHIS.TOTALSHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "   ,STOCKSUB.SHIPMENTCNTRF AS TOTALSHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "   ,STHIS2.SALESTIMES" + Environment.NewLine;
                selectTxt += "  FROM STOCKRF AS STOCKSUB" + Environment.NewLine;

                #region [�݌ɗ����f�[�^�@]
                selectTxt += "  LEFT JOIN" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     STHISSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,WARESUB.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB.GOODSNORF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB.STOCKTOTALRF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB.SHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB.STOCKMASHINEPRICERF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB.TOTALSHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += "   FROM STOCKHISTORYRF AS STHISSUB" + Environment.NewLine;
                selectTxt += "   LEFT JOIN WAREHOUSERF AS WARESUB" + Environment.NewLine;
                selectTxt += "   ON " + Environment.NewLine;
                selectTxt += "	   WARESUB.ENTERPRISECODERF = STHISSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND WARESUB.WAREHOUSECODERF = STHISSUB.WAREHOUSECODERF	" + Environment.NewLine;
                selectTxt += "   WHERE" + Environment.NewLine;
                selectTxt += "        STHISSUB.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                selectTxt += "    AND STHISSUB.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += "    AND STHISSUB.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += "  ) AS STHIS" + Environment.NewLine;
                selectTxt += "  ON  STHIS.ENTERPRISECODERF=STOCKSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND STHIS.SECTIONCODERF=STOCKSUB.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  AND STHIS.WAREHOUSECODERF=STOCKSUB.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  AND STHIS.GOODSMAKERCDRF=STOCKSUB.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND STHIS.GOODSNORF=STOCKSUB.GOODSNORF" + Environment.NewLine;
                #endregion  //[�݌ɗ����f�[�^�@]

                #region [�݌ɗ����f�[�^�A]
                selectTxt += "  LEFT JOIN" + Environment.NewLine;
                selectTxt += "  (" + Environment.NewLine;
                selectTxt += "   SELECT" + Environment.NewLine;
                selectTxt += "     STHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,WARESUB2.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB2.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB2.GOODSNORF" + Environment.NewLine;
                selectTxt += "    ,SUM(STHISSUB2.SALESTIMESRF) AS SALESTIMES" + Environment.NewLine;
                selectTxt += "   FROM STOCKHISTORYRF AS STHISSUB2" + Environment.NewLine;
                selectTxt += "     LEFT JOIN WAREHOUSERF AS WARESUB2" + Environment.NewLine;
                selectTxt += "   ON " + Environment.NewLine;
                selectTxt += "	     WARESUB2.ENTERPRISECODERF = STHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "   AND WARESUB2.WAREHOUSECODERF = STHISSUB2.WAREHOUSECODERF	" + Environment.NewLine;
                selectTxt += "   WHERE" + Environment.NewLine;
                selectTxt += "        STHISSUB2.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
                selectTxt += "    AND STHISSUB2.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += "    AND STHISSUB2.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "     STHISSUB2.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "    ,WARESUB2.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB2.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB2.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "    ,STHISSUB2.GOODSNORF" + Environment.NewLine;
                selectTxt += "  ) AS STHIS2" + Environment.NewLine;
                selectTxt += "  ON  STHIS2.ENTERPRISECODERF=STHIS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND STHIS2.SECTIONCODERF=STHIS.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  AND STHIS2.WAREHOUSECODERF=STHIS.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  AND STHIS2.GOODSMAKERCDRF=STHIS.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND STHIS2.GOODSNORF=STHIS.GOODSNORF" + Environment.NewLine;
                selectTxt += "  LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                selectTxt += "  ON " + Environment.NewLine;
                selectTxt += "	  WARE.ENTERPRISECODERF = STOCKSUB.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND WARE.WAREHOUSECODERF = STOCKSUB.WAREHOUSECODERF	" + Environment.NewLine;
                #endregion  //[�݌ɗ����f�[�^�A]

                //WHERE��
                selectTxt += MakeWhereString_STOCKSUB(ref sqlCommand, _stockNoShipmentListCndtnWork, logicalMode);

                #endregion  //[�݌Ƀf�[�^�{�݌ɗ����f�[�^���oQuery]

                selectTxt += " ) AS STOCK" + Environment.NewLine;

                #region [JOIN]
                //���_���ݒ�}�X�^
                selectTxt += " LEFT JOIN SECINFOSETRF AS SECI" + Environment.NewLine;
                selectTxt += " ON  SECI.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SECI.SECTIONCODERF=STOCK.SECTIONCODERF" + Environment.NewLine;

                //���i�}�X�^
                selectTxt += " LEFT JOIN GOODSURF AS GDSU" + Environment.NewLine;
                selectTxt += " ON  GDSU.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND GDSU.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GDSU.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;

                //���i�Ǘ����}�X�^
                selectTxt += " LEFT JOIN GOODSMNGRF AS GOODSM" + Environment.NewLine;
                selectTxt += " ON  GOODSM.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                //selectTxt += " AND GOODSM.SECTIONCODERF=STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " AND GOODSM.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " AND GOODSM.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;

                //�d����}�X�^
                selectTxt += " LEFT JOIN SUPPLIERRF AS SUP" + Environment.NewLine;
                selectTxt += " ON  SUP.ENTERPRISECODERF=GOODSM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND SUP.SUPPLIERCDRF=GOODSM.SUPPLIERCDRF" + Environment.NewLine;
                #endregion  //[JOIN]

                //BL�R�[�h�}�X�^
                selectTxt += " LEFT JOIN BLGOODSCDURF AS BLGO" + Environment.NewLine;
                selectTxt += " ON  BLGO.ENTERPRISECODERF=GDSU.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += " AND BLGO.BLGOODSCODERF=GDSU.BLGOODSCODERF" + Environment.NewLine;

                //�O���[�v�R�[�h�}�X�^
                selectTxt += "LEFT JOIN BLGROUPURF AS GROU" + Environment.NewLine;
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GROU.ENTERPRISECODERF=BLGO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GROU.BLGROUPCODERF=BLGO.BLGROUPCODERF" + Environment.NewLine; 

                //WHERE��
                selectTxt += MakeWhereString(ref sqlCommand, _stockNoShipmentListCndtnWork, logicalMode);

                #region [GROUP BY]
                selectTxt += " GROUP BY" + Environment.NewLine;
                selectTxt += "  STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += " ,STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += " ,STOCK.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += " ,GOODSM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += " ,SUP.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += " ,STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += " ,STOCK.MAKERNAMERF" + Environment.NewLine;
                selectTxt += " ,STOCK.PARTSMANAGEMENTDIVIDE1RF" + Environment.NewLine;
                selectTxt += " ,STOCK.PARTSMANAGEMENTDIVIDE2RF" + Environment.NewLine;
                selectTxt += " ,GDSU.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += " ,STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += " ,STOCK.GOODSNAMERF" + Environment.NewLine;
                selectTxt += " ,STOCK.WAREHOUSESHELFNORF" + Environment.NewLine;
                selectTxt += " ,STOCK.MINIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.MAXIMUMSTOCKCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.STOCKTOTALRF" + Environment.NewLine;
                selectTxt += " ,STOCK.TOTALSHIPMENTCNTRF" + Environment.NewLine;
                selectTxt += " ,STOCK.STOCKMASHINEPRICERF" + Environment.NewLine;
                selectTxt += " ,STOCK.STOCKCREATEDATERF" + Environment.NewLine;
                selectTxt += " ,STOCK.LASTSALESDATERF" + Environment.NewLine;
                selectTxt += "  ,BLGO.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "  ,GROU.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "  ,GROU.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "  ,GDSU.ENTERPRISEGANRECODERF" + Environment.NewLine;
                #endregion  //[GROUP BY]
                */
                #endregion DELETE

                selectTxt += " SELECT " + Environment.NewLine;
                selectTxt += "  WARE.SECTIONCODERF " + Environment.NewLine;
                selectTxt += " ,SECI.SECTIONGUIDENMRF " + Environment.NewLine;
                selectTxt += " ,STOCK.WAREHOUSECODERF " + Environment.NewLine;
                selectTxt += " ,WARE.WAREHOUSENAMERF " + Environment.NewLine;
                //selectTxt += " ,GOODSM.SUPPLIERCDRF " + Environment.NewLine;
                //selectTxt += " ,SUP.SUPPLIERSNMRF " + Environment.NewLine;
                selectTxt += " ,STOCK.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += " ,STHI.MAKERNAMERF " + Environment.NewLine;
                selectTxt += " ,STOCK.PARTSMANAGEMENTDIVIDE1RF " + Environment.NewLine;
                selectTxt += " ,STOCK.PARTSMANAGEMENTDIVIDE2RF " + Environment.NewLine;
                selectTxt += " ,GDSU.BLGOODSCODERF " + Environment.NewLine;
                selectTxt += " ,STOCK.GOODSNORF " + Environment.NewLine;
                selectTxt += " ,GDSU.GOODSNAMERF " + Environment.NewLine;
                selectTxt += " ,STOCK.WAREHOUSESHELFNORF " + Environment.NewLine;
                selectTxt += " ,STOCK.MAXIMUMSTOCKCNTRF " + Environment.NewLine;
                selectTxt += " ,STOCK.MINIMUMSTOCKCNTRF " + Environment.NewLine;
                selectTxt += " ,STOCK.SHIPMENTPOSCNTRF " + Environment.NewLine;
                selectTxt += " ,STOCK.SHIPMENTCNTRF " + Environment.NewLine;
                selectTxt += " ,STOCK.STOCKCREATEDATERF " + Environment.NewLine;
                selectTxt += " ,STOCK.LASTSALESDATERF " + Environment.NewLine;
                selectTxt += " ,STHI.SALESTIMESRF" + Environment.NewLine;
                // 2010/04/26 Add >>>
                selectTxt += " ,STHI.ADDUPYEARMONTHRF" + Environment.NewLine;
                selectTxt += " ,MKRU.MAKERNAMERF MAKERNAMERF2" + Environment.NewLine;
                // 2010/04/26 Add <<<
                selectTxt += " FROM STOCKRF AS STOCK " + Environment.NewLine;
                selectTxt += "    WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += " LEFT JOIN SECINFOSETRF AS SECI " + Environment.NewLine;
                selectTxt += "    WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += "  ON  SECI.ENTERPRISECODERF=STOCK.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "  AND SECI.SECTIONCODERF=STOCK.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSURF AS GDSU " + Environment.NewLine;
                selectTxt += "    WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += "  ON  GDSU.ENTERPRISECODERF=STOCK.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "  AND GDSU.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "  AND GDSU.GOODSNORF=STOCK.GOODSNORF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN GOODSMNGRF AS GOODSM " + Environment.NewLine;
                selectTxt += "    WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += "  ON  GOODSM.ENTERPRISECODERF=STOCK.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "  AND GOODSM.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "  AND GOODSM.GOODSNORF=STOCK.GOODSNORF " + Environment.NewLine;
                //selectTxt += "  LEFT JOIN SUPPLIERRF AS SUP " + Environment.NewLine;
                //selectTxt += "  ON  SUP.ENTERPRISECODERF=GOODSM.ENTERPRISECODERF " + Environment.NewLine;
                //selectTxt += "  AND SUP.SUPPLIERCDRF=GOODSM.SUPPLIERCDRF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGOODSCDURF AS BLGO " + Environment.NewLine;
                selectTxt += "    WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += "  ON  BLGO.ENTERPRISECODERF=GDSU.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "  AND BLGO.BLGOODSCODERF=GDSU.BLGOODSCODERF  " + Environment.NewLine;
                selectTxt += "  LEFT JOIN BLGROUPURF AS GROU " + Environment.NewLine;
                selectTxt += "    WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += "  ON  GROU.ENTERPRISECODERF=BLGO.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "  AND GROU.BLGROUPCODERF=BLGO.BLGROUPCODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN WAREHOUSERF AS WARE " + Environment.NewLine;
                selectTxt += "    WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += "  ON	 WARE.ENTERPRISECODERF=STOCK.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "  AND WARE.WAREHOUSECODERF=STOCK.WAREHOUSECODERF " + Environment.NewLine;
                selectTxt += "  LEFT JOIN STOCKHISTORYRF AS STHI " + Environment.NewLine;
                selectTxt += "    WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += "  ON	 STHI.ENTERPRISECODERF=STOCK.ENTERPRISECODERF " + Environment.NewLine;
                //selectTxt += "  AND STHI.SECTIONCODERF=STOCK.SECTIONCODERF " + Environment.NewLine;
                selectTxt += "  AND STHI.WAREHOUSECODERF=STOCK.WAREHOUSECODERF " + Environment.NewLine;
                selectTxt += "  AND STHI.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "  AND STHI.GOODSNORF=STOCK.GOODSNORF " + Environment.NewLine;
                // 2010/04/26 Add >>>
                selectTxt += "  LEFT JOIN MAKERURF AS MKRU " + Environment.NewLine;
                selectTxt += "    WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += "  ON	 STOCK.ENTERPRISECODERF=MKRU.ENTERPRISECODERF " + Environment.NewLine;
                selectTxt += "  AND STOCK.GOODSMAKERCDRF=MKRU.GOODSMAKERCDRF " + Environment.NewLine;
                // 2010/04/26 Add <<<

                selectTxt += MakeWhereStringSTOCK(ref sqlCommand, _stockNoShipmentListCndtnWork, logicalMode);
                
                #endregion  //[Select���쐬]

                sqlCommand.CommandText = selectTxt;
                sqlCommand.CommandTimeout = 3600; // ADD 2019/11/06 ���V�� PMKOBETSU-2425 �Ώ۔N���̊��Ԏw����R�N�Ƃ���Ή�
                myReader = sqlCommand.ExecuteReader();

                ArrayList continueKeyList = new ArrayList();    // 2010/04/26 Add
                ArrayList continuewkStockNoShipmentListWorkList = new ArrayList();  // 2010/04/26 Add

                while (myReader.Read())
                {

                    #region ���o����-�l�Z�b�g
                    StockNoShipmentListWork wkStockNoShipmentListWork = new StockNoShipmentListWork();

                    //�݌ɗ����i�[����
                    wkStockNoShipmentListWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkStockNoShipmentListWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkStockNoShipmentListWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkStockNoShipmentListWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    //wkStockNoShipmentListWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    //wkStockNoShipmentListWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkStockNoShipmentListWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkStockNoShipmentListWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkStockNoShipmentListWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    wkStockNoShipmentListWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    wkStockNoShipmentListWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkStockNoShipmentListWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkStockNoShipmentListWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkStockNoShipmentListWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkStockNoShipmentListWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkStockNoShipmentListWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkStockNoShipmentListWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    wkStockNoShipmentListWork.TotalShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    //wkStockNoShipmentListWork.StockMashinePrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKMASHINEPRICERF"));
                    wkStockNoShipmentListWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    wkStockNoShipmentListWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                    //wkStockNoShipmentListWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    //wkStockNoShipmentListWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    //wkStockNoShipmentListWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    //wkStockNoShipmentListWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                    wkStockNoShipmentListWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMESRF"));
                   

                    #endregion

                    // 2010/04/26 >>>
                    //keyHist = /*wkStockNoShipmentListWork.SectionCode +*/ wkStockNoShipmentListWork.WarehouseCode + wkStockNoShipmentListWork.GoodsMakerCd + wkStockNoShipmentListWork.GoodsNo;
                    keyHist = string.Format("{0:D4}", Convert.ToInt32(wkStockNoShipmentListWork.WarehouseCode.Trim())) + wkStockNoShipmentListWork.GoodsMakerCd.ToString("0000") + wkStockNoShipmentListWork.GoodsNo.Trim();
                    int addUpYearMonth = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
                    if (addUpYearMonth != 0)
                    {
                        int stAddUpYearMonth = _stockNoShipmentListCndtnWork.St_AddUpYearMonth.Year * 100 + _stockNoShipmentListCndtnWork.St_AddUpYearMonth.Month;
                        int edAddUpYearMonth = _stockNoShipmentListCndtnWork.Ed_AddUpYearMonth.Year * 100 + _stockNoShipmentListCndtnWork.Ed_AddUpYearMonth.Month;
                        if (stAddUpYearMonth > addUpYearMonth || addUpYearMonth > edAddUpYearMonth)
                        {
                            object[] containts = new object[2] { null, null };
                            containts[0] = keyHist;
                            containts[1] = wkStockNoShipmentListWork;
                            if (!_addCountList.ContainsKey(keyHist))
                            {
                                wkStockNoShipmentListWork.SalesTimes = 0;
                                continueKeyList.Add(containts);
                            }
                            continue;
                        }
                    }
                    if (string.IsNullOrEmpty(wkStockNoShipmentListWork.MakerName.Trim()))
                    {
                        wkStockNoShipmentListWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF2"));
                    }
                    // 2010/04/26 <<<
                    alkey.Add(keyHist);
                    if (Shipmentlst.ContainsKey(keyHist) == false)
                    {
                        Shipmentlst.Add(keyHist, wkStockNoShipmentListWork);
                    }
                    // 2010/06/29 Add >>>
                    else
                    {
                        if (wkStockNoShipmentListWork.SalesTimes != 0)
                        {
                            Shipmentlst[keyHist].SalesTimes = wkStockNoShipmentListWork.SalesTimes;
                        }
                    }
                    if (wkStockNoShipmentListWork.SalesTimes == 0)
                    {
                        if (_addCountList.ContainsKey(keyHist))
                        {
                            //_addCountList[keyHist] = _addCountList[keyHist] + 1;
                        }
                        else
                        {
                            _addCountList.Add(keyHist, 1);
                        }
                    }
                    // 2010/04/26 Add <<<
                    if (lastKey.Contains(keyHist) == false)
                    {
                        lastKey.Add(keyHist);
                    }
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                // 2010/04/26 Add >>>
                foreach (object[] key in continueKeyList)
                {
                    alkey.Add((string)key[0]);
                    if (!_addCountList.ContainsKey((string)key[0]))
                    {
                        _addCountList.Add((string)key[0], 1);
                    }
                    if (lastKey.Contains((string)key[0]) == false)
                    {
                        lastKey.Add(key[0]);
                    }
                    if (Shipmentlst.ContainsKey((string)key[0]) == false)
                    {
                        Shipmentlst.Add((string)key[0], (StockNoShipmentListWork)key[1]);
                    }
                }
                // 2010/04/26 Add <<<
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "StockNoShipmentListWorkDB.SearchStockNoShipmentProc Exception=" + ex.Message);
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
        private int SearchStockProc(ref Dictionary<string, StockNoShipmentListWork> dic, ref SqlConnection sqlConnection, StockNoShipmentListCndtnWork _stockNoShipmentListCndtnWork, ConstantManagement.LogicalMode logicalMode)
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
                selectTxt += "        ,GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "        ,MAKER.MAKERNAMERF" + Environment.NewLine;
                selectTxt += "        ,SECI.SECTIONGUIDENMRF" + Environment.NewLine;
                selectTxt += "        ,GOODS.GOODSNAMERF" + Environment.NewLine;
                selectTxt += "        ,GOODSM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "        ,SUPP.SUPPLIERSNMRF" + Environment.NewLine;
                selectTxt += "        ,WARE.WAREHOUSENAMERF" + Environment.NewLine;
                selectTxt += "        ,BLGO.BLGROUPCODERF" + Environment.NewLine;
                selectTxt += "        ,GROU.GOODSLGROUPRF" + Environment.NewLine;
                selectTxt += "        ,GROU.GOODSMGROUPRF" + Environment.NewLine;
                selectTxt += "        ,GOODS.ENTERPRISEGANRECODERF" + Environment.NewLine;
                selectTxt += "FROM STOCKRF AS STOCK" + Environment.NewLine;
                selectTxt += "  WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += "LEFT JOIN GOODSURF AS GOODS" + Environment.NewLine;
                selectTxt += "  WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GOODS.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GOODS.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND GOODS.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "LEFT JOIN MAKERURF AS MAKER" + Environment.NewLine;
                selectTxt += "  WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      MAKER.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND MAKER.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SECINFOSETRF SECI" + Environment.NewLine;
                selectTxt += "  WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      SECI.ENTERPRISECODERF = STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SECI.SECTIONCODERF = STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSMNGRF AS GOODSM" + Environment.NewLine;
                selectTxt += "  WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GOODSM.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GOODSM.SECTIONCODERF=STOCK.SECTIONCODERF" + Environment.NewLine;
                selectTxt += "  AND GOODSM.GOODSMAKERCDRF=STOCK.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND GOODSM.GOODSNORF=STOCK.GOODSNORF" + Environment.NewLine;
                selectTxt += "LEFT JOIN SUPPLIERRF AS SUPP" + Environment.NewLine;
                selectTxt += "  WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      SUPP.ENTERPRISECODERF=GOODSM.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND SUPP.SUPPLIERCDRF=GOODSM.SUPPLIERCDRF" + Environment.NewLine;
                selectTxt += "LEFT JOIN WAREHOUSERF AS WARE" + Environment.NewLine;
                selectTxt += "  WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      WARE.ENTERPRISECODERF=STOCK.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND WARE.WAREHOUSECODERF=STOCK.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN BLGOODSCDURF AS BLGO" + Environment.NewLine;
                selectTxt += "  WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      BLGO.ENTERPRISECODERF=GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND BLGO.BLGOODSCODERF=GOODS.BLGOODSCODERF" + Environment.NewLine;
                selectTxt += "LEFT JOIN BLGROUPURF AS GROU" + Environment.NewLine;
                selectTxt += "  WITH (READUNCOMMITTED)" + Environment.NewLine;  // ADD 2011/05/18
                selectTxt += " ON" + Environment.NewLine;
                selectTxt += "      GROU.ENTERPRISECODERF=BLGO.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND GROU.BLGROUPCODERF=BLGO.BLGROUPCODERF" + Environment.NewLine; 

                selectTxt += MakeWhereStockString(ref sqlCommand, _stockNoShipmentListCndtnWork, logicalMode);

                sqlCommand.CommandText = selectTxt;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    StockNoShipmentListWork wkstockWork = new StockNoShipmentListWork();

                    // �i�[����
                    #region ���o���ʊi�[����
                    wkstockWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    wkstockWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkstockWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    wkstockWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    wkstockWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    wkstockWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                    wkstockWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkstockWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    wkstockWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    wkstockWork.PartsManagementDivide1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE1RF"));
                    wkstockWork.PartsManagementDivide2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTSMANAGEMENTDIVIDE2RF"));
                    wkstockWork.StockCreateDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKCREATEDATERF"));
                    wkstockWork.SectionGuideNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
                    wkstockWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    wkstockWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                    wkstockWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                    wkstockWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                    wkstockWork.MinimumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MINIMUMSTOCKCNTRF"));
                    wkstockWork.MaximumStockCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MAXIMUMSTOCKCNTRF"));
                    wkstockWork.LastSalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTSALESDATERF"));
                    wkstockWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                    wkstockWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                    wkstockWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                    wkstockWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                    wkstockWork.StockTotal = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTPOSCNTRF"));
                    wkstockWork.TotalShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                    #endregion

                    // 2010/04/26 >>>
                    //key = wkstockWork.WarehouseCode + wkstockWork.GoodsNo + wkstockWork.GoodsMakerCd.ToString("0000");
                    key = string.Format("{0:D4}", Convert.ToInt32(wkstockWork.WarehouseCode.Trim())) + wkstockWork.GoodsMakerCd.ToString("0000") + wkstockWork.GoodsNo;
                    // 2010/04/26 <<<

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


        #region [�݌ɗ��� WHERE��]

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockMoveListCndtnWork">���������i�[�N���X</param>
        /// <param name="_productNumberOutPutDiv">���Ԓ��o�敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        /// <br>Note       : redmine #43095 �݌ɖ��o�׈ꗗ�\��ʕ\���s��</br>
        /// <br>Programmer : cheny</br>
        /// <br>Date       : 2014/08/11</br>
        private string MakeWhereStringSTOCK(ref SqlCommand sqlCommand, StockNoShipmentListCndtnWork _stockNoShipmentListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE" + Environment.NewLine;

            // ��ƃR�[�h
            retstring += " STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.EnterpriseCode);

            // �_���폜�敪
            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
               (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {

                retstring += " AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }
            // ADD BY cheny 2014/08/11 FOR redmine43095---->>>>
            //���i�敪�ݒ�
            if (_stockNoShipmentListCndtnWork.St_EnterpriseGanreCode != 0)
            {
                retstring += " AND GDSU.ENTERPRISEGANRECODERF>=@STENTERPRISEGANRECODE" + Environment.NewLine;
                SqlParameter paraStEnterpriseGanreCode = sqlCommand.Parameters.Add("@STENTERPRISEGANRECODE", SqlDbType.Int);
                paraStEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_EnterpriseGanreCode);
            }
            if (_stockNoShipmentListCndtnWork.Ed_EnterpriseGanreCode != 999999)
            {
                retstring += " AND GDSU.ENTERPRISEGANRECODERF<=@EDENTERPRISEGANRECODE" + Environment.NewLine;
                SqlParameter paraEdEnterpriseGanreCode = sqlCommand.Parameters.Add("@EDENTERPRISEGANRECODE", SqlDbType.Int);
                paraEdEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_EnterpriseGanreCode);
            }

            //BL�R�[�h�ݒ�
            if (_stockNoShipmentListCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND GDSU.BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_BLGoodsCode);
            }
            if (_stockNoShipmentListCndtnWork.Ed_BLGoodsCode != 99999999)
            {
                retstring += " AND GDSU.BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_BLGoodsCode);
            }
            // ADD BY cheny 2014/08/11 FOR redmine43095----<<<<
            // 2010/04/26 Del >>>
            //retstring += "    AND STHI.ADDUPYEARMONTHRF>=@STADDUPYEARMONTH" + Environment.NewLine;
            //SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
            //paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockNoShipmentListCndtnWork.St_AddUpYearMonth);

            //retstring += "    AND STHI.ADDUPYEARMONTHRF<=@EDADDUPYEARMONTH" + Environment.NewLine;
            //SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
            //paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockNoShipmentListCndtnWork.Ed_AddUpYearMonth);
            // 2010/04/26 Del <<<

            //���_�R�[�h
            //if (_stockNoShipmentListCndtnWork.SectionCodes != null)
            //{
            //    string sectionCodestr = "";
            //    foreach (string seccdstr in _stockNoShipmentListCndtnWork.SectionCodes)
            //    {
            //        if (sectionCodestr != "")
            //        {
            //            sectionCodestr += ",";
            //        }
            //        sectionCodestr += "'" + seccdstr + "'";
            //    }
            //    if (sectionCodestr != "")
            //    {
            //        retstring += " AND WARE.SECTIONCODERF IN (" + sectionCodestr + ") ";
            //    }
            //    retstring += Environment.NewLine;
            //}
        
            //�q�ɃR�[�h�ݒ�
            if (_stockNoShipmentListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.St_WarehouseCode);
            }
            if (_stockNoShipmentListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND (STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE OR STOCK.WAREHOUSECODERF LIKE @EDWAREHOUSECODE)" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.Ed_WarehouseCode + "%");
            }

            ////�d����R�[�h�ݒ�
            //if (_stockNoShipmentListCndtnWork.St_SupplierCd != 0)
            //{
            //    retstring += " AND GOODSM.SUPPLIERCDRF>=@STSUPPLIERCD" + Environment.NewLine;
            //    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@STSUPPLIERCD", SqlDbType.Int);
            //    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_SupplierCd);
            //}
            //if (_stockNoShipmentListCndtnWork.Ed_SupplierCd != 99999999)
            //{
            //    retstring += " AND GOODSM.SUPPLIERCDRF<=@EDSUPPLIERCD" + Environment.NewLine;
            //    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@EDSUPPLIERCD", SqlDbType.Int);
            //    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_SupplierCd);
            //}

            //���[�J�[�R�[�h�ݒ�
            if (_stockNoShipmentListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockNoShipmentListCndtnWork.Ed_GoodsMakerCd != 999999)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_GoodsMakerCd);
            }

            //���i�ԍ��ݒ�
            if (_stockNoShipmentListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsCd = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsCd.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.St_GoodsNo);
            }
            if (_stockNoShipmentListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND (STOCK.GOODSNORF<=@EDGOODSNO OR STOCK.GOODSNORF LIKE @EDGOODSNO)" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.Ed_GoodsNo + "%");
            }

            //�I�Ԑݒ�
            if (_stockNoShipmentListCndtnWork.St_WarehouseShelfNo != "")
            {
                retstring += " AND STOCK.WAREHOUSESHELFNORF>=@STWAREHOUSESHELFNO" + Environment.NewLine;
                SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@STWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.St_WarehouseShelfNo);
            }
            if (_stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo != "")
            {
                retstring += " AND (STOCK.WAREHOUSESHELFNORF<=@EDWAREHOUSESHELFNO OR STOCK.WAREHOUSESHELFNORF LIKE @EDWAREHOUSESHELFNO)" + Environment.NewLine;
                SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@EDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo + "%");
            }

            //�݌ɓo�^��
            if (_stockNoShipmentListCndtnWork.StockCreateDate != DateTime.MinValue)
            {
                if (_stockNoShipmentListCndtnWork.StockCreateDateDiv == 0)
                {
                    retstring += " AND STOCK.STOCKCREATEDATERF<=@STOCKCREATEDATE" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND STOCK.STOCKCREATEDATERF>=@STOCKCREATEDATE" + Environment.NewLine;
                }
                SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@STOCKCREATEDATE", SqlDbType.Int);
                paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockNoShipmentListCndtnWork.StockCreateDate);
            }

            //���i�Ǘ��敪�P  ���z��ŕ����w�肳���
            if (_stockNoShipmentListCndtnWork.PartsManagementDivide1 != null)
            {
                string Divied1 = "";
                foreach (string Divide1str in _stockNoShipmentListCndtnWork.PartsManagementDivide1)
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
            if (_stockNoShipmentListCndtnWork.PartsManagementDivide2 != null)
            {
                string Divied2 = "";
                foreach (string Divide2str in _stockNoShipmentListCndtnWork.PartsManagementDivide2)
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

            //�����
            //retstring += " AND (STHI.SALESTIMESRF=0 OR STHI.SALESTIMESRF IS NULL)" + Environment.NewLine;
            return retstring;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockMoveListCndtnWork">���������i�[�N���X</param>
        /// <param name="_productNumberOutPutDiv">���Ԓ��o�敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString(ref SqlCommand sqlCommand, StockNoShipmentListCndtnWork _stockNoShipmentListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " STOCK.ENTERPRISECODERF=@ENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF=@FINDLOGICALDELETECODE" + Environment.NewLine; 
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STOCK.LOGICALDELETECODERF<@FINDLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //�N���x�ݒ�
            SqlParameter paraStAddUpYearMonth = sqlCommand.Parameters.Add("@STADDUPYEARMONTH", SqlDbType.Int);
            paraStAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockNoShipmentListCndtnWork.St_AddUpYearMonth);

            SqlParameter paraEdAddUpYearMonth = sqlCommand.Parameters.Add("@EDADDUPYEARMONTH", SqlDbType.Int);
            paraEdAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(_stockNoShipmentListCndtnWork.Ed_AddUpYearMonth);

            //���i�敪�ݒ�
            if (_stockNoShipmentListCndtnWork.St_EnterpriseGanreCode != 0)
            {
                retstring += " AND GDSU.ENTERPRISEGANRECODERF>=@STENTERPRISEGANRECODE" + Environment.NewLine;
                SqlParameter paraStEnterpriseGanreCode = sqlCommand.Parameters.Add("@STENTERPRISEGANRECODE", SqlDbType.Int);
                paraStEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_EnterpriseGanreCode);
            }
            if (_stockNoShipmentListCndtnWork.Ed_EnterpriseGanreCode != 999999)
            {
                retstring += " AND GDSU.ENTERPRISEGANRECODERF<=@EDENTERPRISEGANRECODE" + Environment.NewLine;
                SqlParameter paraEdEnterpriseGanreCode = sqlCommand.Parameters.Add("@EDENTERPRISEGANRECODE", SqlDbType.Int);
                paraEdEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_EnterpriseGanreCode);
            }

            //BL�R�[�h�ݒ�
            if (_stockNoShipmentListCndtnWork.St_BLGoodsCode != 0)
            {
                retstring += " AND GDSU.BLGOODSCODERF>=@STBLGOODSCODE" + Environment.NewLine;
                SqlParameter paraStBLGoodsCode = sqlCommand.Parameters.Add("@STBLGOODSCODE", SqlDbType.Int);
                paraStBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_BLGoodsCode);
            }
            if (_stockNoShipmentListCndtnWork.Ed_BLGoodsCode != 99999999)
            {
                retstring += " AND GDSU.BLGOODSCODERF<=@EDBLGOODSCODE" + Environment.NewLine;
                SqlParameter paraEdBLGoodsCode = sqlCommand.Parameters.Add("@EDBLGOODSCODE", SqlDbType.Int);
                paraEdBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_BLGoodsCode);
            }

            //BL�O���[�v�R�[�h�ݒ�
            if (_stockNoShipmentListCndtnWork.St_BLGroupCode != 0)
            {
                retstring += " AND BLGO.BLGROUPCODERF>=@STBLGROUPCODE" + Environment.NewLine;
                SqlParameter paraStBLGroupCode = sqlCommand.Parameters.Add("@STBLGROUPCODE", SqlDbType.Int);
                paraStBLGroupCode.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_BLGroupCode);
            }
            if (_stockNoShipmentListCndtnWork.Ed_BLGoodsCode != 99999999)
            {
                retstring += " AND BLGO.BLGROUPCODERF<=@EDBLGROUPCODE" + Environment.NewLine;
                SqlParameter paraEdBLGroupCode = sqlCommand.Parameters.Add("@EDBLGROUPCODE", SqlDbType.Int);
                paraEdBLGroupCode.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_BLGoodsCode);
            }

            //���i�啪�ސݒ�
            if (_stockNoShipmentListCndtnWork.St_GoodsLGroup != 0)
            {
                retstring += " AND GROU.GOODSLGROUPRF>=@STGOODSLGROUP" + Environment.NewLine;
                SqlParameter paraStGoodsLGroup = sqlCommand.Parameters.Add("@STGOODSLGROUP", SqlDbType.Int);
                paraStGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_GoodsLGroup);
            }
            if (_stockNoShipmentListCndtnWork.Ed_GoodsLGroup != 0)
            {
                retstring += " AND GROU.GOODSLGROUPRF<=@EDGOODSLGROUP" + Environment.NewLine;
                SqlParameter paraEdGoodsLGroup = sqlCommand.Parameters.Add("@EDGOODSLGROUP", SqlDbType.Int);
                paraEdGoodsLGroup.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_GoodsLGroup);
            }

            //���i�����ސݒ�
            if (_stockNoShipmentListCndtnWork.St_GoodsMGroup != 0)
            {
                retstring += " AND GROU.GOODSMGROUPRF>=@STGOODSMGROUP" + Environment.NewLine;
                SqlParameter paraStGoodsMGroup = sqlCommand.Parameters.Add("@STGOODSMGROUP", SqlDbType.Int);
                paraStGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_GoodsMGroup);
            }
            if (_stockNoShipmentListCndtnWork.Ed_GoodsMGroup != 0)
            {
                retstring += " AND GROU.GOODSMGROUPRF<=@EDGOODSMGROUP" + Environment.NewLine;
                SqlParameter paraEdGoodsMGroup = sqlCommand.Parameters.Add("@EDGOODSMGROUP", SqlDbType.Int);
                paraEdGoodsMGroup.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_GoodsMGroup);
            }

            #endregion
            return retstring;
        }

        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockMoveListCndtnWork">���������i�[�N���X</param>
        /// <param name="_productNumberOutPutDiv">���Ԓ��o�敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereString_STOCKSUB(ref SqlCommand sqlCommand, StockNoShipmentListCndtnWork _stockNoShipmentListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            #region WHERE���쐬
            string retstring = " WHERE" + Environment.NewLine;

            //��ƃR�[�h
            retstring += " STHIS.ENTERPRISECODERF=@SUBENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@SUBENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.EnterpriseCode);

            if ((logicalMode == ConstantManagement.LogicalMode.GetData0) || (logicalMode == ConstantManagement.LogicalMode.GetData1) ||
                (logicalMode == ConstantManagement.LogicalMode.GetData2) || (logicalMode == ConstantManagement.LogicalMode.GetData3))
            {
                retstring += " AND STOCKSUB.LOGICALDELETECODERF=@SUBLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@SUBLOGICALDELETECODE", SqlDbType.Int);
                paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)logicalMode);
            }
            else if ((logicalMode == ConstantManagement.LogicalMode.GetData01) || (logicalMode == ConstantManagement.LogicalMode.GetData012))
            {
                retstring += " AND STOCKSUB.LOGICALDELETECODERF<@SUBLOGICALDELETECODE" + Environment.NewLine;
                SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@SUBLOGICALDELETECODE", SqlDbType.Int);
                if (logicalMode == ConstantManagement.LogicalMode.GetData01) paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)2);
                else paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)3);
            }

            //���_�R�[�h
            if (_stockNoShipmentListCndtnWork.SectionCodes != null)
            {
                string sectionCodestr = "";
                foreach (string seccdstr in _stockNoShipmentListCndtnWork.SectionCodes)
                {
                    if (sectionCodestr != "")
                    {
                        sectionCodestr += ",";
                    }
                    sectionCodestr += "'" + seccdstr + "'";
                }
                if (sectionCodestr != "")
                {
                    retstring += " AND WARE.SECTIONCODERF IN (" + sectionCodestr + ") ";
                }
                retstring += Environment.NewLine;
            }

            //�q�ɃR�[�h�ݒ�
            if (_stockNoShipmentListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STOCKSUB.WAREHOUSECODERF>=@SUBSTWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@SUBSTWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.St_WarehouseCode);
            }
            if (_stockNoShipmentListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND (STOCKSUB.WAREHOUSECODERF<=@SUBEDWAREHOUSECODE OR STOCKSUB.WAREHOUSECODERF LIKE @SUBEDWAREHOUSECODE)" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@SUBEDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.Ed_WarehouseCode + "%");
            }

            ////�d����R�[�h�ݒ�
            //if (_stockNoShipmentListCndtnWork.St_SupplierCd != 0)
            //{
            //    retstring += " AND STOCKSUB.STOCKSUPPLIERCODERF>=@SUBSTSUPPLIERCD" + Environment.NewLine;
            //    SqlParameter paraStSupplierCd = sqlCommand.Parameters.Add("@SUBSTSUPPLIERCD", SqlDbType.Int);
            //    paraStSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_SupplierCd);
            //}
            //if (_stockNoShipmentListCndtnWork.Ed_SupplierCd != 99999999)
            //{
            //    retstring += " AND STOCKSUB.STOCKSUPPLIERCODERF<=@SUBEDSUPPLIERCD" + Environment.NewLine;
            //    SqlParameter paraEdSupplierCd = sqlCommand.Parameters.Add("@SUBEDSUPPLIERCD", SqlDbType.Int);
            //    paraEdSupplierCd.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_SupplierCd);
            //}

            //���[�J�[�R�[�h�ݒ�
            if (_stockNoShipmentListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STOCKSUB.GOODSMAKERCDRF>=@SUBSTGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@SUBSTGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockNoShipmentListCndtnWork.Ed_GoodsMakerCd != 999999)
            {
                retstring += " AND STOCKSUB.GOODSMAKERCDRF<=@SUBEDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@SUBEDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_GoodsMakerCd);
            }

            //���i�ԍ��ݒ�
            if (_stockNoShipmentListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STOCKSUB.GOODSNORF>=@SUBSTGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsCd = sqlCommand.Parameters.Add("@SUBSTGOODSNO", SqlDbType.NVarChar);
                paraStGoodsCd.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.St_GoodsNo);
            }
            if (_stockNoShipmentListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND (STOCKSUB.GOODSNORF<=@SUBEDGOODSNO OR STOCKSUB.GOODSNORF LIKE @SUBEDGOODSNO)" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@SUBEDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.Ed_GoodsNo + "%");
            }

            //�I�Ԑݒ�
            if (_stockNoShipmentListCndtnWork.St_WarehouseShelfNo != "")
            {
                retstring += " AND STOCKSUB.WAREHOUSESHELFNORF>=@SUBSTWAREHOUSESHELFNO" + Environment.NewLine;
                SqlParameter paraStWarehouseShelfNo = sqlCommand.Parameters.Add("@SUBSTWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraStWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.St_WarehouseShelfNo);
            }
            if (_stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo != "")
            {
                retstring += " AND (STOCKSUB.WAREHOUSESHELFNORF<=@SUBEDWAREHOUSESHELFNO OR STOCKSUB.WAREHOUSESHELFNORF LIKE @SUBEDWAREHOUSESHELFNO)" + Environment.NewLine;
                SqlParameter paraEdWarehouseShelfNo = sqlCommand.Parameters.Add("@SUBEDWAREHOUSESHELFNO", SqlDbType.NVarChar);
                paraEdWarehouseShelfNo.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo + "%");
            }

            //�݌ɓo�^��
            if (_stockNoShipmentListCndtnWork.StockCreateDate != DateTime.MinValue)
            {
                if (_stockNoShipmentListCndtnWork.StockCreateDateDiv == 0)
                {
                    retstring += " AND STOCKSUB.STOCKCREATEDATERF<=@SUBSTOCKCREATEDATE" + Environment.NewLine;
                }
                else
                {
                    retstring += " AND STOCKSUB.STOCKCREATEDATERF>=@SUBSTOCKCREATEDATE" + Environment.NewLine;
                }
                SqlParameter paraStockCreateDate = sqlCommand.Parameters.Add("@SUBSTOCKCREATEDATE", SqlDbType.Int);
                paraStockCreateDate.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(_stockNoShipmentListCndtnWork.StockCreateDate);
            }

            //���i�Ǘ��敪�P  ���z��ŕ����w�肳���
            if (_stockNoShipmentListCndtnWork.PartsManagementDivide1 != null)
            {
                string Divied1 = "";
                foreach (string Divide1str in _stockNoShipmentListCndtnWork.PartsManagementDivide1)
                {
                    if (Divied1 != "")
                    {
                        Divied1 += ",";
                    }
                    Divied1 += "'" + Divide1str + "'";
                }

                if (Divied1 != "")
                {
                    retstring += " AND STOCKSUB.PARTSMANAGEMENTDIVIDE1RF IN (" + Divied1 + ") ";
                }
            }

            //���i�Ǘ��敪�Q  ���z��ŕ����w�肳���
            if (_stockNoShipmentListCndtnWork.PartsManagementDivide2 != null)
            {
                string Divied2 = "";
                foreach (string Divide2str in _stockNoShipmentListCndtnWork.PartsManagementDivide2)
                {
                    if (Divied2 != "")
                    {
                        Divied2 += ",";
                    }
                    Divied2 += "'" + Divide2str + "'";
                }

                if (Divied2 != "")
                {
                    retstring += " AND STOCKSUB.PARTSMANAGEMENTDIVIDE2RF IN (" + Divied2 + ") ";
                }
            }

            //�����
            retstring += " AND (STHIS2.SALESTIMES<=0 OR STHIS2.SALESTIMES IS NULL)" + Environment.NewLine;

            #endregion
            return retstring;
        }
        #endregion  //[WHERE��]

        #region [�݌Ƀ}�X�^ WHERE��]
        /// <summary>
        /// �������������񐶐��{�����l�ݒ�
        /// </summary>
        /// <param name="sqlCommand">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="_stockMoveListCndtnWork">���������i�[�N���X</param>
        /// <param name="_productNumberOutPutDiv">���Ԓ��o�敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>Where����������</returns>
        private string MakeWhereStockString(ref SqlCommand sqlCommand, StockNoShipmentListCndtnWork _stockNoShipmentListCndtnWork, ConstantManagement.LogicalMode logicalMode)
        {
            string retstring = "WHERE" + Environment.NewLine;

            // ��ƃR�[�h
            retstring += " STOCK.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
            SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
            paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.EnterpriseCode);

            //// �_���폜�敪
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
            if (_stockNoShipmentListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF>=@STWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.St_WarehouseCode);
            }
            if (_stockNoShipmentListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STOCK.WAREHOUSECODERF<=@EDWAREHOUSECODE" + Environment.NewLine;
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.Ed_WarehouseCode);
            }

            //���[�J�[�R�[�h�ݒ�
            if (_stockNoShipmentListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF>=@STGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockNoShipmentListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STOCK.GOODSMAKERCDRF<=@EDGOODSMAKERCD" + Environment.NewLine;
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_GoodsMakerCd);
            }

            //���i�ԍ��ݒ�
            if (_stockNoShipmentListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF>=@STGOODSNO" + Environment.NewLine;
                SqlParameter paraStGoodsCd = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsCd.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.St_GoodsNo);
            }
            if (_stockNoShipmentListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STOCK.GOODSNORF<=@EDGOODSNO" + Environment.NewLine;
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.Ed_GoodsNo);
            }

            return retstring;
        }
        #endregion


        // -- ADD 2011/05/18 ------------------------------>>>
        /// <summary>
        /// �݌ɗ������A���W�v����߂��܂�
        /// </summary>
        /// <param name="retStockHistoryList">��������</param>
        /// <param name="monthlyAddUpWork">���o����</param>
        /// <param name="_stockNoShipmentListCndtnWork">���o����</param>
        /// <param name="sqlConnection">SQL�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �݌ɗ������A���W�v����߂��܂�</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2011/05/18</br>
        /// <br>Note       : �Ώ۔N���̊��Ԏw����R�N�Ƃ���Ή�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2019/11/06</br>
        /// </remarks>
        private int GetSalesTimesProc(ref List<StockHistoryWork> retStockHistoryList, MonthlyAddUpWork monthlyAddUpWork, StockNoShipmentListCndtnWork _stockNoShipmentListCndtnWork, ref SqlConnection sqlConnection)
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
                selectTxt += "    STPAYCNT.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "    WARE.WAREHOUSENAMERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "    GOODS.GOODSNAMERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.GOODSNORF," + Environment.NewLine;
                selectTxt += "    MAKER.MAKERNAMERF," + Environment.NewLine;
                selectTxt += "    SUM(CASE WHEN ((STPAYCNT.ACPAYSLIPCDRF=20 AND STPAYCNT.ACPAYTRANSCDRF=10) AND DELSLIPNUM IS NULL) THEN 1 ELSE 0 END) AS SALESTIMESRF--�����" + Environment.NewLine;
                selectTxt += "   FROM  " + Environment.NewLine;
                selectTxt += "   (" + Environment.NewLine;
                selectTxt += "      SELECT " + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.LOGICALDELETECODERF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.GOODSNORF," + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.ACPAYSLIPNUMRF, --�`�[�ԍ�" + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.ACPAYSLIPCDRF,  --�󕥌��`�[�敪" + Environment.NewLine;
                selectTxt += "       STOCKACPAYHIST.ACPAYTRANSCDRF,  --�󕥌�����敪" + Environment.NewLine;
                selectTxt += "       DELSTOCKACPAYHIST.ACPAYSLIPNUMRF AS DELSLIPNUM --�`�[�ԍ�" + Environment.NewLine;
                selectTxt += "      FROM" + Environment.NewLine;
                selectTxt += "       STOCKACPAYHISTRF AS STOCKACPAYHIST WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "     LEFT JOIN" + Environment.NewLine;
                selectTxt += "      (" + Environment.NewLine;
                selectTxt += "        SELECT" + Environment.NewLine;
                selectTxt += "         LOGICALDELETECODERF," + Environment.NewLine;
                selectTxt += "         ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "         WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "         GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "         GOODSNORF," + Environment.NewLine;
                selectTxt += "         ACPAYSLIPNUMRF --�󕥌��`�[�ԍ�" + Environment.NewLine;
                selectTxt += "        FROM" + Environment.NewLine;
                selectTxt += "         STOCKACPAYHISTRF WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "        WHERE" + Environment.NewLine;
                selectTxt += "            ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine;
                selectTxt += "        AND LOGICALDELETECODERF=0 " + Environment.NewLine;
                selectTxt += "        AND ACPAYTRANSCDRF = 21 " + Environment.NewLine;
                selectTxt += "      ) AS DELSTOCKACPAYHIST" + Environment.NewLine;
                selectTxt += "       ON  STOCKACPAYHIST.ENTERPRISECODERF = DELSTOCKACPAYHIST.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.WAREHOUSECODERF = DELSTOCKACPAYHIST.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.GOODSMAKERCDRF = DELSTOCKACPAYHIST.GOODSMAKERCDRF " + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.GOODSNORF = DELSTOCKACPAYHIST.GOODSNORF" + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.ACPAYSLIPNUMRF = DELSTOCKACPAYHIST.ACPAYSLIPNUMRF          " + Environment.NewLine;
                selectTxt += "      WHERE STOCKACPAYHIST.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;
                selectTxt += "       AND STOCKACPAYHIST.LOGICALDELETECODERF=0" + Environment.NewLine;
                //selectTxt += "     AND( ( CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END ) >@FINDADDUPDATEST  AND (CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END )<=@FINDADDUPDATEED)" + Environment.NewLine;// DEL BY cheny 2014/08/11 FOR redmine43095
                selectTxt += "     AND( ( CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END ) >=@FINDADDUPDATEST  AND (CASE WHEN STOCKACPAYHIST.ADDUPADATERF IS NULL THEN STOCKACPAYHIST.IOGOODSDAYRF ELSE STOCKACPAYHIST.ADDUPADATERF END )<=@FINDADDUPDATEED)" + Environment.NewLine;// ADD BY cheny 2014/08/11 FOR redmine43095
                selectTxt += "   ) AS STPAYCNT" + Environment.NewLine;
                selectTxt += " LEFT JOIN MAKERURF AS MAKER WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "  ON  STPAYCNT.ENTERPRISECODERF = MAKER.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND STPAYCNT.GOODSMAKERCDRF = MAKER.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND MAKER.LOGICALDELETECODERF=0" + Environment.NewLine;
                selectTxt += " LEFT JOIN  WAREHOUSERF AS WARE WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "  ON STPAYCNT.ENTERPRISECODERF = WARE.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND STPAYCNT.WAREHOUSECODERF = WARE.WAREHOUSECODERF" + Environment.NewLine;
                selectTxt += "  AND WARE.LOGICALDELETECODERF=0" + Environment.NewLine;
                selectTxt += " LEFT JOIN GOODSURF AS GOODS WITH (READUNCOMMITTED)" + Environment.NewLine;
                selectTxt += "  ON  STPAYCNT.ENTERPRISECODERF = GOODS.ENTERPRISECODERF" + Environment.NewLine;
                selectTxt += "  AND STPAYCNT.GOODSMAKERCDRF = GOODS.GOODSMAKERCDRF" + Environment.NewLine;
                selectTxt += "  AND STPAYCNT.GOODSNORF = GOODS.GOODSNORF" + Environment.NewLine;
                selectTxt += "  AND GOODS.LOGICALDELETECODERF=0" + Environment.NewLine;

                //WHERE���̍쐬
                selectTxt += MakeWhereStringSalesTime(ref sqlCommand, monthlyAddUpWork, _stockNoShipmentListCndtnWork);

                selectTxt += "   GROUP BY" + Environment.NewLine;
                selectTxt += "    STPAYCNT.ENTERPRISECODERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.WAREHOUSECODERF," + Environment.NewLine;
                selectTxt += "    WARE.WAREHOUSENAMERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.GOODSMAKERCDRF," + Environment.NewLine;
                selectTxt += "    GOODS.GOODSNAMERF," + Environment.NewLine;
                selectTxt += "    STPAYCNT.GOODSNORF," + Environment.NewLine;
                selectTxt += "    MAKER.MAKERNAMERF" + Environment.NewLine;

                sqlCommand.CommandText = selectTxt;
                #endregion
                sqlCommand.CommandTimeout = 3600; // ADD 2019/11/06 ���V�� PMKOBETSU-2425 �Ώ۔N���̊��Ԏw����R�N�Ƃ���Ή�
                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {
                    #region ���o����-�l�Z�b�g
                    StockHistoryWork stockhisWork = new StockHistoryWork();

                    //�i�[����
                    stockhisWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                    stockhisWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                    stockhisWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                    stockhisWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                    stockhisWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                    stockhisWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                    stockhisWork.SalesTimes = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESTIMESRF"));

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
                base.WriteErrorLog(ex, "StockNoShipmentListWorkDB.GetSalesTimesProc Exception=" + ex.Message);
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
        private string MakeWhereStringSalesTime(ref SqlCommand sqlCommand, MonthlyAddUpWork monthlyAddUpWork, StockNoShipmentListCndtnWork _stockNoShipmentListCndtnWork)
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
            retstring += " STPAYCNT.ENTERPRISECODERF=@FINDENTERPRISECODE" + Environment.NewLine;

            //�q�ɃR�[�h�ݒ�
            if (_stockNoShipmentListCndtnWork.St_WarehouseCode != "")
            {
                retstring += " AND STPAYCNT.WAREHOUSECODERF>=@STWAREHOUSECODE";
                SqlParameter paraStWarehouseCode = sqlCommand.Parameters.Add("@STWAREHOUSECODE", SqlDbType.NChar);
                paraStWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.St_WarehouseCode);
            }
            if (_stockNoShipmentListCndtnWork.Ed_WarehouseCode != "")
            {
                retstring += " AND STPAYCNT.WAREHOUSECODERF<=@EDWAREHOUSECODE";
                SqlParameter paraEdWarehouseCode = sqlCommand.Parameters.Add("@EDWAREHOUSECODE", SqlDbType.NChar);
                paraEdWarehouseCode.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.Ed_WarehouseCode);
            }

            //���[�J�[�R�[�h�ݒ�
            if (_stockNoShipmentListCndtnWork.St_GoodsMakerCd != 0)
            {
                retstring += " AND STPAYCNT.GOODSMAKERCDRF>=@STGOODSMAKERCD";
                SqlParameter paraStGoodsMakerCd = sqlCommand.Parameters.Add("@STGOODSMAKERCD", SqlDbType.Int);
                paraStGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.St_GoodsMakerCd);
            }
            if (_stockNoShipmentListCndtnWork.Ed_GoodsMakerCd != 9999)
            {
                retstring += " AND STPAYCNT.GOODSMAKERCDRF<=@EDGOODSMAKERCD";
                SqlParameter paraEdGoodsMakerCd = sqlCommand.Parameters.Add("@EDGOODSMAKERCD", SqlDbType.Int);
                paraEdGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(_stockNoShipmentListCndtnWork.Ed_GoodsMakerCd);
            }

            //���i�ԍ��ݒ�
            if (_stockNoShipmentListCndtnWork.St_GoodsNo != "")
            {
                retstring += " AND STPAYCNT.GOODSNORF>=@STGOODSNO";
                SqlParameter paraStGoodsNo = sqlCommand.Parameters.Add("@STGOODSNO", SqlDbType.NVarChar);
                paraStGoodsNo.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.St_GoodsNo);
            }
            if (_stockNoShipmentListCndtnWork.Ed_GoodsNo != "")
            {
                retstring += " AND STPAYCNT.GOODSNORF<=@EDGOODSNO";
                SqlParameter paraEdGoodsNo = sqlCommand.Parameters.Add("@EDGOODSNO", SqlDbType.NVarChar);
                paraEdGoodsNo.Value = SqlDataMediator.SqlSetString(_stockNoShipmentListCndtnWork.Ed_GoodsNo);
            }
            #endregion
            return retstring;
        }
        // -- ADD 2011/05/18 ------------------------------<<<
    }
}
