//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : ���i�}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/06/24  �C�����e : PVCS265 �o�͎d�l�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  2010/05/12  �C�����e : Mantis.15352�@�������x���x�����̏C���i�V�K�����[�g�g�p�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ���� ���n
// �� �� ��  2011/05/17  �C�����e : ���o���̒񋟋敪�ł̔�����폜
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Library.Globarization;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

// 2010/05/12 Add >>>
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
// 2010/05/12 Add <<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�}�X�^�i�G�N�X�|�[�g�j�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�i�G�N�X�|�[�g�j�C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class GoodsExportAcs
    {
        #region �� Private Member
        private const string PRINTSET_TABLE = "GoodsExp";
        private IGoodsExportDB _iGoodsExportDB = null;
        #endregion

        # region ��Constracter
        /// <summary>
        /// ���i�}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X�B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public GoodsExportAcs()
        {
        }
        #endregion

        #region �� ���i�}�X�^��񌟍�
        /// <summary>
        /// ���i�}�X�^�f�[�^�擾����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="dataTable">�����f�[�^</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ���i�}�X�^�f�[�^�擾�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        // 2010/05/12 Del >>>
        #region [Del]
        //public int Search(GoodsExportWork condition, out DataTable dataTable)
        //{
        //    int status = 0;
        //    int checkStatus = 0;
        //    dataTable = new DataTable(PRINTSET_TABLE);
        //    CreateDataTable(ref dataTable);

        //    // ADD 2009/06/24 --->>>
        //    // �o�͎d�l�̏C��
        //    PriceChgSetAcs priceChgSetAcs = new PriceChgSetAcs();

        //    ArrayList priceChgSets = null;
        //    status = priceChgSetAcs.Search(
        //                    out priceChgSets,
        //                    condition.EnterpriseCode, PriceChgSetAcs.SearchMode.Remote);

        //    if (status == 0)
        //    {
        //        int priceMngCnt = 0;
        //        foreach (PriceChgSet prevPriceChgSet in priceChgSets)
        //        {
        //            priceMngCnt = prevPriceChgSet.PriceMngCnt;
        //        }
        //        // ADD 2009/06/24 ---<<<
        //        ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;
        //        GoodsAcs goodsAcs = new GoodsAcs();
        //        GoodsCndtn goodsCndtn = new GoodsCndtn();
        //        goodsCndtn.EnterpriseCode = condition.EnterpriseCode;
        //        goodsCndtn.GoodsKindCode = 9;
        //        List<GoodsUnitData> al = new List<GoodsUnitData>();
        //        string msg = null;
        //        status = goodsAcs.Search(goodsCndtn, logicalMode, out al, out msg);

        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            foreach (GoodsUnitData goodsUnitData in al)
        //            {
        //                checkStatus = DataCheck(condition, goodsUnitData);
        //                if (checkStatus == 0)
        //                {
        //                    // MODIFY 2009/06/24 --->>>
        //                    // �o�͎d�l�̏C��
        //                    //ConverToDataSetCustomerInf(goodsUnitData, ref dataTable);
        //                    ConverToDataSetCustomerInf(goodsUnitData, ref dataTable, priceMngCnt);
        //                    // MODIFY 2009/06/24 ---<<<
        //                }
        //            }
        //        }
        //        // ADD 2009/06/24 --->>>
        //        // �o�͎d�l�̏C��
        //    }
        //    // ADD 2009/06/24 ---<<<
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
        //    {
        //        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        //    }

        //    return status;
        //}
        #endregion [Del]
        // 2010/05/12 Del <<<
        // 2010/05/12 Add >>>
        public int Search(GoodsExportWork condition, out DataTable dataTable)
        {
            int status = 0;
            int checkStatus = 0;
            dataTable = new DataTable(PRINTSET_TABLE);
            CreateDataTable(ref dataTable);

            if (_iGoodsExportDB == null)
                _iGoodsExportDB = (IGoodsExportDB)MediationGoodsExportDB.GetGoodsExportDB();
            try
            {
                GoodsExportParamWork goodsExportParamWork = new GoodsExportParamWork();
                object retReadList = null;

                // ���o�����Z�b�g
                goodsExportParamWork.EnterpriseCode = condition.EnterpriseCode;

                if (condition.BLGoodsCodeSt > 0)
                    goodsExportParamWork.BLGoodsCodeSt = condition.BLGoodsCodeSt;
                if (condition.BLGoodsCodeEd > 0)
                    goodsExportParamWork.BLGoodsCodeEd = condition.BLGoodsCodeEd;
                else
                    goodsExportParamWork.BLGoodsCodeEd = 99999;

                if (condition.GoodsMakerCdSt > 0)
                    goodsExportParamWork.GoodsMakerCdSt = condition.GoodsMakerCdSt;
                if (condition.GoodsMakerCdEd > 0)
                    goodsExportParamWork.GoodsMakerCdEd = condition.GoodsMakerCdEd;
                else
                    goodsExportParamWork.GoodsMakerCdEd = 9999;

                if (!string.IsNullOrEmpty(condition.GoodsNoSt))
                    goodsExportParamWork.GoodsNoSt = condition.GoodsNoSt;
                if (!string.IsNullOrEmpty(condition.GoodsNoEd))
                    goodsExportParamWork.GoodsNoEd = condition.GoodsNoEd;

                status = _iGoodsExportDB.Search(out retReadList, goodsExportParamWork, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // �f�[�^�W�J����
                        ArrayList retArrayList = new ArrayList();
                        retArrayList = (ArrayList)retReadList;
                        List<GoodsExportResultWork> goodsUnitDataList = new List<GoodsExportResultWork>();
                        string workGoodsNo = string.Empty;
                        int workMakerCode = 0;
                        foreach (GoodsExportResultWork goodsUnitData in retArrayList)
                        {
                            if (goodsUnitData.GoodsNo != workGoodsNo || goodsUnitData.GoodsMakerCd != workMakerCode)
                            {
                                if (goodsUnitDataList.Count > 0)
                                {
                                    // �f�[�^�e�[�u���ɒǉ�����
                                    ConverToDataSetCustomerInf(goodsUnitDataList, ref dataTable);
                                }
                                goodsUnitDataList.Clear();
                                workGoodsNo = goodsUnitData.GoodsNo;
                                workMakerCode = goodsUnitData.GoodsMakerCd;
                            }
                            checkStatus = DataCheck(condition, goodsUnitData);
                            if (checkStatus == 0)
                            {
                                goodsUnitDataList.Add(goodsUnitData);
                            }
                        }
                        if (goodsUnitDataList.Count > 0)
                        {
                            // �f�[�^�e�[�u���ɒǉ�����
                            ConverToDataSetCustomerInf(goodsUnitDataList, ref dataTable);
                        }
                        if (dataTable.Rows.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            finally
            {
                
            }
            return status;
        }
        // 2010/05/12 Add <<<
        #endregion

        #region �� Private Methods
        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="condition">��������</param>
        /// <param name="goodsUnitData">���i�f�[�^</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ���o�������s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        // 2010/05/12 >>>
        //private int DataCheck(GoodsExportWork condition, GoodsUnitData goodsUnitData)
        private int DataCheck(GoodsExportWork condition, GoodsExportResultWork goodsUnitData)
        // 2010/05/12 <<<
        {
            int status = 0;

            // -- DEL 2011/05/17 -------------------->>>
            //if (goodsUnitData.OfferDataDiv != 0)
            //{
            //    status = -1;
            //    return status;
            //}
            // -- DEL 2011/05/17 --------------------<<<

            // 2010/05/12 Del >>>
            #region [Del]
            //if (!String.IsNullOrEmpty(condition.GoodsNoSt.Trim()) && !String.IsNullOrEmpty(goodsUnitData.GoodsNo.Trim())
            //    && condition.GoodsNoSt.Trim().CompareTo(goodsUnitData.GoodsNo.Trim()) == 1)
            //{
            //    status = -1;
            //    return status;
            //}

            //if (!String.IsNullOrEmpty(condition.GoodsNoEd.Trim()) && !String.IsNullOrEmpty(goodsUnitData.GoodsNo.Trim())
            //    && condition.GoodsNoEd.Trim().CompareTo(goodsUnitData.GoodsNo.Trim()) == -1)
            //{
            //    status = -1;
            //    return status;
            //}

            //if (condition.GoodsMakerCdSt != 0 && goodsUnitData.GoodsMakerCd < condition.GoodsMakerCdSt)
            //{
            //    status = -1;
            //    return status;
            //}
            //if (condition.GoodsMakerCdEd != 0 && goodsUnitData.GoodsMakerCd > condition.GoodsMakerCdEd)
            //{
            //    status = -1;
            //    return status;
            //}

            //if (condition.BLGoodsCodeSt != 0 && goodsUnitData.BLGoodsCode < condition.BLGoodsCodeSt)
            //{
            //    status = -1;
            //    return status;
            //}
            //if (condition.BLGoodsCodeEd != 0 && goodsUnitData.BLGoodsCode > condition.BLGoodsCodeEd)
            //{
            //    status = -1;
            //    return status;
            //}
            #endregion [Del]
            // 2010/05/12 Del <<<

            return status;

        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="goodsUnitDataList">��������</param>
        /// <param name="dataTable">����</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        // MODIFY 2009/06/24 --->>>
        // �o�͎d�l�̏C��
        //private void ConverToDataSetCustomerInf(GoodsUnitData goodsUnitData, ref DataTable dataTable)
        // 2010/05/12 >>>
        //private void ConverToDataSetCustomerInf(GoodsUnitData goodsUnitData, ref DataTable dataTable, int priceMngCnt)
        private void ConverToDataSetCustomerInf(List<GoodsExportResultWork> goodsUnitDataList, ref DataTable dataTable)
        // 2010/05/12 <<<
        // MODIFY 2009/06/24 ---<<<
        {
            DataRow dataRow = dataTable.NewRow();
            // 2010/05/12 Add >>>
            GoodsExportResultWork goodsUnitData = new GoodsExportResultWork();
            goodsUnitData = goodsUnitDataList[0];
            // 2010/05/12 Add <<<
            dataRow["GoodsNoRF"] = GetSubString(goodsUnitData.GoodsNo, 24);
            dataRow["GoodsMakerCdRF"] = AppendZero(goodsUnitData.GoodsMakerCd.ToString(), 4);
            dataRow["GoodsNameRF"] = GetSubString(goodsUnitData.GoodsName, 40);
            dataRow["GoodsNameKanaRF"] = GetSubString(goodsUnitData.GoodsNameKana, 40);
            dataRow["JanRF"] = goodsUnitData.Jan;
            dataRow["BLGoodsCodeRF"] = AppendZero(goodsUnitData.BLGoodsCode.ToString(), 5);
            dataRow["EnterpriseGanreCodeRF"] = AppendZero(goodsUnitData.EnterpriseGanreCode.ToString(), 4);
            dataRow["GoodsRateRankRF"] = GetSubString(goodsUnitData.GoodsRateRank, 2);
            dataRow["GoodsKindCodeRF"] = goodsUnitData.GoodsKindCode;
            dataRow["TaxationDivCdRF"] = goodsUnitData.TaxationDivCd;
            dataRow["GoodsNote1RF"] = GetSubString(goodsUnitData.GoodsNote1, 40);
            dataRow["GoodsNote2RF"] = GetSubString(goodsUnitData.GoodsNote2, 40);
            dataRow["GoodsSpecialNoteRF"] = GetSubString(goodsUnitData.GoodsSpecialNote, 40);
            int index = 0;
            // 2010/05/12 Add >>>
            int priceMngCnt = goodsUnitDataList.Count;
            int startIndex = 0;
            // 2010/05/12 Add <<<
            // 2010/05/12 Del >>>
            //if (goodsUnitData.GoodsPriceList.Count > 0)
            //{
            // 2010/05/12 Del <<<
            // 2010/05/12 >>>
            //foreach (GoodsPrice goodsPrice in goodsUnitData.GoodsPriceList)
            foreach (GoodsExportResultWork goodsPrice in goodsUnitDataList)
            // 2010/05/12 <<<
            {
                // ADD 2009/06/24 --->>>
                // �o�͎d�l�̏C��
                if (index == priceMngCnt)
                {
                    break;
                }
                else
                {
                    // ADD 2009/06/24 ---<<<
                    if (index == 0)
                    {
                        if (goodsPrice.PriceStartDate == DateTime.MinValue)
                        {
                            // MODIFY 2009/06/24 --->>>
                            // �o�͎d�l�̏C��
                            //dataRow["PriceStartDateRF1"] = DBNull.Value;
                            dataRow["PriceStartDateRF1"] = 0;
                            // MODIFY 2009/06/24 ---<<<
                        }
                        else
                        {
                            dataRow["PriceStartDateRF1"] = TDateTime.DateTimeToLongDate("YYYYMMDD", goodsPrice.PriceStartDate);
                            startIndex++;   // 2010/05/12 Add
                        }
                        dataRow["ListPriceRF1"] = goodsPrice.ListPrice;
                        dataRow["OpenPriceDivRF1"] = goodsPrice.OpenPriceDiv;
                        dataRow["StockRateRF1"] = goodsPrice.StockRate.ToString("##0.00");
                        dataRow["SalesUnitCostRF1"] = goodsPrice.SalesUnitCost.ToString("##0.00");
                    }
                    else if (index == 1)
                    {
                        if (goodsPrice.PriceStartDate == DateTime.MinValue)
                        {
                            // MODIFY 2009/06/24 --->>>
                            // �o�͎d�l�̏C��
                            //dataRow["PriceStartDateRF2"] = DBNull.Value;
                            dataRow["PriceStartDateRF2"] = 0;
                            // MODIFY 2009/06/24 ---<<<
                        }
                        else
                        {
                            dataRow["PriceStartDateRF2"] = TDateTime.DateTimeToLongDate("YYYYMMDD", goodsPrice.PriceStartDate);
                            startIndex++;   // 2010/05/12 Add
                        }
                        dataRow["ListPriceRF2"] = goodsPrice.ListPrice;
                        dataRow["OpenPriceDivRF2"] = goodsPrice.OpenPriceDiv;
                        dataRow["StockRateRF2"] = goodsPrice.StockRate.ToString("##0.00");
                        dataRow["SalesUnitCostRF2"] = goodsPrice.SalesUnitCost.ToString("##0.00");
                    }
                    else if (index == 2)
                    {
                        if (goodsPrice.PriceStartDate == DateTime.MinValue)
                        {
                            // MODIFY 2009/06/24 --->>>
                            // �o�͎d�l�̏C��
                            //dataRow["PriceStartDateRF3"] = DBNull.Value;
                            dataRow["PriceStartDateRF3"] = 0;
                            // MODIFY 2009/06/24 ---<<<
                        }
                        else
                        {
                            dataRow["PriceStartDateRF3"] = TDateTime.DateTimeToLongDate("YYYYMMDD", goodsPrice.PriceStartDate);
                            startIndex++;   // 2010/05/12 Add
                        }
                        dataRow["ListPriceRF3"] = goodsPrice.ListPrice;
                        dataRow["OpenPriceDivRF3"] = goodsPrice.OpenPriceDiv;
                        dataRow["StockRateRF3"] = goodsPrice.StockRate.ToString("##0.00");
                        dataRow["SalesUnitCostRF3"] = goodsPrice.SalesUnitCost.ToString("##0.00");
                    }
                    // ADD 2009/06/24 --->>>
                    // �o�͎d�l�̏C��
                    else if (index == 3)
                    {
                        if (goodsPrice.PriceStartDate == DateTime.MinValue)
                        {
                            dataRow["PriceStartDateRF4"] = 0;
                        }
                        else
                        {
                            dataRow["PriceStartDateRF4"] = TDateTime.DateTimeToLongDate("YYYYMMDD", goodsPrice.PriceStartDate);
                            startIndex++;   // 2010/05/12 Add
                        }
                        dataRow["ListPriceRF4"] = goodsPrice.ListPrice;
                        dataRow["OpenPriceDivRF4"] = goodsPrice.OpenPriceDiv;
                        dataRow["StockRateRF4"] = goodsPrice.StockRate.ToString("##0.00");
                        dataRow["SalesUnitCostRF4"] = goodsPrice.SalesUnitCost.ToString("##0.00");
                    }
                    else if (index == 4)
                    {
                        if (goodsPrice.PriceStartDate == DateTime.MinValue)
                        {
                            dataRow["PriceStartDateRF5"] = 0;
                        }
                        else
                        {
                            dataRow["PriceStartDateRF5"] = TDateTime.DateTimeToLongDate("YYYYMMDD", goodsPrice.PriceStartDate);
                            startIndex++;   // 2010/05/12 Add
                        }
                        dataRow["ListPriceRF5"] = goodsPrice.ListPrice;
                        dataRow["OpenPriceDivRF5"] = goodsPrice.OpenPriceDiv;
                        dataRow["StockRateRF5"] = goodsPrice.StockRate.ToString("##0.00");
                        dataRow["SalesUnitCostRF5"] = goodsPrice.SalesUnitCost.ToString("##0.00");
                    }
                    // ADD 2009/06/24 ---<<<
                }
                index++;
            }
            //}   // 2010/05/12 Del

            // ADD 2009/06/24 --->>>
            // �o�͎d�l�̏C��
            string PriceStartDateRF = "";
            string ListPriceRF = "";
            string OpenPriceDivRF = "";
            string StockRateRF = "";
            string SalesUnitCostRF = "";
            // 2010/05/12 Del >>>
            //int startIndex = 0;
            //if (goodsUnitData.GoodsPriceList.Count > priceMngCnt)
            //{
            //    startIndex = priceMngCnt;
            //}
            //else
            //{
            //    startIndex = goodsUnitData.GoodsPriceList.Count;
            //}
            // 2010/05/12 Del <<<
            for (int i = startIndex; i < 5; i++)
            {
                PriceStartDateRF = "PriceStartDateRF";
                ListPriceRF = "ListPriceRF";
                OpenPriceDivRF = "OpenPriceDivRF";
                StockRateRF = "StockRateRF";
                SalesUnitCostRF = "SalesUnitCostRF";

                PriceStartDateRF += (i + 1);
                ListPriceRF += (i + 1);
                OpenPriceDivRF += (i + 1);
                StockRateRF += (i + 1);
                SalesUnitCostRF += (i + 1);

                dataRow[PriceStartDateRF] = 0;
                dataRow[ListPriceRF] = 0;
                dataRow[OpenPriceDivRF] = 0;
                dataRow[StockRateRF] = "0.00";
                dataRow[SalesUnitCostRF] = "0.00";
            }
            // ADD 2009/06/24 ---<<<
            dataTable.Rows.Add(dataRow);
        }

        #region �� Private Methods

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("GoodsNoRF", typeof(string));                  //  ���i�ԍ�
            dataTable.Columns.Add("GoodsMakerCdRF", typeof(string));             //  ���i���[�J�[�R�[�h
            dataTable.Columns.Add("GoodsNameRF", typeof(string));                //  ���i����
            dataTable.Columns.Add("GoodsNameKanaRF", typeof(string));            //  ���i���̃J�i
            dataTable.Columns.Add("JanRF", typeof(string));                      //  JAN�R�[�h

            dataTable.Columns.Add("BLGoodsCodeRF", typeof(string));              //  BL���i�R�[�h
            dataTable.Columns.Add("EnterpriseGanreCodeRF", typeof(string));      // ���Е��ރR�[�h
            dataTable.Columns.Add("GoodsRateRankRF", typeof(string));            //  ���i�|�������N
            dataTable.Columns.Add("GoodsKindCodeRF", typeof(Int32));            //  ���i����
            dataTable.Columns.Add("TaxationDivCdRF", typeof(Int32));            //  �ېŋ敪
            dataTable.Columns.Add("GoodsNote1RF", typeof(string));               //  ���i���l�P
            dataTable.Columns.Add("GoodsNote2RF", typeof(string));               //  ���i���l�Q
            dataTable.Columns.Add("GoodsSpecialNoteRF", typeof(string));         //  ���i�K�i�E���L����

            dataTable.Columns.Add("PriceStartDateRF1", typeof(Int32));           //  ���i�J�n���P
            dataTable.Columns.Add("ListPriceRF1", typeof(Double));                //  �艿�i�����j�P
            dataTable.Columns.Add("OpenPriceDivRF1", typeof(Int32));             //  �I�[�v�����i�敪�P
            dataTable.Columns.Add("StockRateRF1", typeof(string));                //  �d�����P
            dataTable.Columns.Add("SalesUnitCostRF1", typeof(string));            //  �����P���P

            dataTable.Columns.Add("PriceStartDateRF2", typeof(Int32));           //  ���i�J�n���Q
            dataTable.Columns.Add("ListPriceRF2", typeof(Double));                //  �艿�i�����j�Q
            dataTable.Columns.Add("OpenPriceDivRF2", typeof(Int32));             //  �I�[�v�����i�敪�Q
            dataTable.Columns.Add("StockRateRF2", typeof(string));                //  �d�����Q
            dataTable.Columns.Add("SalesUnitCostRF2", typeof(string));            //  �����P���Q

            dataTable.Columns.Add("PriceStartDateRF3", typeof(Int32));           //  ���i�J�n���R
            dataTable.Columns.Add("ListPriceRF3", typeof(Double));                //  �艿�i�����j�R
            dataTable.Columns.Add("OpenPriceDivRF3", typeof(Int32));             //  �I�[�v�����i�敪�R
            dataTable.Columns.Add("StockRateRF3", typeof(string));                //  �d�����R
            dataTable.Columns.Add("SalesUnitCostRF3", typeof(string));            //  �����P���R
            // ADD 2009/06/24 --->>>
            // �o�͎d�l�̏C��
            dataTable.Columns.Add("PriceStartDateRF4", typeof(Int32));           //  ���i�J�n���S
            dataTable.Columns.Add("ListPriceRF4", typeof(Double));                //  �艿�i�����j�S
            dataTable.Columns.Add("OpenPriceDivRF4", typeof(Int32));             //  �I�[�v�����i�敪�S
            dataTable.Columns.Add("StockRateRF4", typeof(string));                //  �d�����S
            dataTable.Columns.Add("SalesUnitCostRF4", typeof(string));            //  �����P���S

            dataTable.Columns.Add("PriceStartDateRF5", typeof(Int32));           //  ���i�J�n���T
            dataTable.Columns.Add("ListPriceRF5", typeof(Double));                //  �艿�i�����j�T
            dataTable.Columns.Add("OpenPriceDivRF5", typeof(Int32));             //  �I�[�v�����i�敪�T
            dataTable.Columns.Add("StockRateRF5", typeof(string));                //  �d�����T
            dataTable.Columns.Add("SalesUnitCostRF5", typeof(string));            //  �����P���T
            // ADD 2009/06/24 ---<<<
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">��</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendZero(string bfString, int maxSize)
        {
            bfString = bfString.Trim();
            StringBuilder tempBuild = new StringBuilder();
            if (bfString != "0")
            {
                if (!String.IsNullOrEmpty(bfString.Trim()) && !bfString.Trim().Equals("0"))
                {
                    for (int i = bfString.Length; i < maxSize; i++)
                    {
                        tempBuild.Append("0");
                    }
                    tempBuild.Append(bfString);
                }
            }
            else
            {
                tempBuild.Append("0");
            }
            return tempBuild.ToString().Trim();
        }

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">��</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            string afString = "";
            bfString = bfString.Trim();
            if (bfString.Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">��</param>
        /// <remarks>
        /// <br>Note       : AppendZero�s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string AppendStrZero(string bfString, int maxSize)
        {
            StringBuilder tempBuild = new StringBuilder();
            if (String.IsNullOrEmpty(bfString.Trim()) || bfString.Trim().Length == 0)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
            }
            else
            {
                for (int i = bfString.Length; i < maxSize; i++)
                {
                    tempBuild.Append("0");
                }
                tempBuild.Append(bfString);
            }
            return tempBuild.ToString().Trim();
        }
        #endregion

        #endregion
    }
}
