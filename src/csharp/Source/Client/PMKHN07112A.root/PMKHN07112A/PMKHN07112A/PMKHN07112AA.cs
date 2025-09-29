//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先マスタ（エクスポート）
// プログラム概要   : 仕入先マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 仕入先マスタ（エクスポート）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先マスタ（エクスポート）インスタンスの作成を行う。</br>
    /// <br>Programmer : 朱宝軍</br>
    /// <br>Date       : 2009.05.12</br>
    /// </remarks>
    public class SupplierExportAcs
    {
        #region ■ Private Member
        private const string PRINTSET_TABLE = "SupplierExp";
        #endregion

        # region ■Constracter
        /// <summary>
        /// 仕入先マスタ（エクスポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入先マスタ（エクスポート）アクセスクラス。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public SupplierExportAcs()
        {
        }
        # endregion

        #region ■ 仕入先マスタ情報検索
        /// <summary>
        /// 仕入先マスタデータ取得処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">検索データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 仕入先マスタデータ取得処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Search(SupplierExportWork condition, out DataTable dataTable)
        {
            int status = 0;
            ArrayList retList = null;
            dataTable = new DataTable(PRINTSET_TABLE);
            // DataTableのColumnsを追加する
            CreateDataTable(ref dataTable);
            // 仕入先アクセスクラス
            SupplierAcs supplierAcs = new SupplierAcs();
            // 検索
            status = supplierAcs.Search(out retList, condition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 検索結果をConvertToDataTable
                ConverToDataSetSupplierInf(retList, condition, ref dataTable);
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        # endregion

        #region ■ Private Methods

        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("SupplierCdRF", typeof(string));      //  仕入先コード
            dataTable.Columns.Add("SupplierNm1RF", typeof(string));	        //  仕入先名1
            dataTable.Columns.Add("SupplierNm2RF", typeof(string));	    //  仕入先名2
            dataTable.Columns.Add("SupplierSnmRF", typeof(string));	    //  仕入先略称
            dataTable.Columns.Add("SupplierKanaRF", typeof(string));	    //  仕入先カナ
            dataTable.Columns.Add("SuppHonorificTitleRF", typeof(string));	    //  仕入先敬称
            dataTable.Columns.Add("OrderHonorificTtlRF", typeof(string));	    //  発注書敬称
            dataTable.Columns.Add("MngSectionCodeRF", typeof(string));           //  管理拠点コード
            dataTable.Columns.Add("StockAgentCodeRF", typeof(string));	    //  仕入担当者コード
            dataTable.Columns.Add("PureCodeRF", typeof(Int32));	    //  純正区分

            dataTable.Columns.Add("SupplierAttributeDivRF", typeof(Int32));	    //  仕入先属性区分
            dataTable.Columns.Add("BusinessTypeCodeRF", typeof(string));	    //  業種コード
            dataTable.Columns.Add("SalesAreaCodeRF", typeof(string));	    //  販売エリアコード
            dataTable.Columns.Add("PaymentSectionCodeRF", typeof(string));	        //  支払拠点コード
            dataTable.Columns.Add("PayeeCodeRF", typeof(string));	    //  支払先コード
            dataTable.Columns.Add("PaymentTotalDayRF", typeof(string));	    //  支払締日
            dataTable.Columns.Add("PaymentMonthCodeRF", typeof(Int32));	    //  支払月区分コード
            dataTable.Columns.Add("PaymentDayRF", typeof(string));	    //  支払日
            dataTable.Columns.Add("PaymentCondRF", typeof(string));	    //  支払条件
            dataTable.Columns.Add("PaymentSightRF", typeof(string));	    //  支払サイト

            dataTable.Columns.Add("NTimeCalcStDateRF", typeof(string));	    //  次回勘定開始日
            dataTable.Columns.Add("SuppCTaxLayRefCdRF", typeof(Int32));	    //  仕入先消費税転嫁方式参照区分
            dataTable.Columns.Add("SuppCTaxLayCdRF", typeof(Int32));	    //  仕入先消費税転嫁方式コード
            dataTable.Columns.Add("StockUnPrcFrcProcCdRF", typeof(Int32));	        //  仕入単価端数処理コード
            dataTable.Columns.Add("StockMoneyFrcProcCdRF", typeof(Int32));	        //  仕入金額端数処理コード
            dataTable.Columns.Add("StockCnsTaxFrcProcCdRF", typeof(Int32));	    //  仕入消費税端数処理コード
            dataTable.Columns.Add("SupplierPostNoRF", typeof(string));	    //  仕入先郵便番号
            dataTable.Columns.Add("SupplierAddr1RF", typeof(string));	        //  仕入先住所1（都道府県市区郡・町村・字）
            dataTable.Columns.Add("SupplierAddr3RF", typeof(string));	        //  仕入先住所3（番地）
            dataTable.Columns.Add("SupplierAddr4RF", typeof(string));	    //  仕入先住所4（アパート名称）

            dataTable.Columns.Add("SupplierTelNoRF", typeof(string));	    //  仕入先電話番号
            dataTable.Columns.Add("SupplierTelNo1RF", typeof(string));	    //  仕入先電話番号1
            dataTable.Columns.Add("SupplierTelNo2RF", typeof(string));	    //  仕入先電話番号2
            dataTable.Columns.Add("SupplierNote1RF", typeof(string));	    //  仕入先備考1
            dataTable.Columns.Add("SupplierNote2RF", typeof(string));	    //  仕入先備考2
            dataTable.Columns.Add("SupplierNote3RF", typeof(string));	    //  仕入先備考3
            dataTable.Columns.Add("SupplierNote4RF", typeof(string));	    //  仕入先備考4
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="postcardEnvelopeDMWork">検索条件</param>
        /// <param name="dataTable">結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ConverToDataSetSupplierInf(ArrayList retList, SupplierExportWork supplierExportWork, ref DataTable dataTable)
        {
            foreach (Supplier supplier in retList)
            {
                int checkstatus = DataCheck(supplier, supplierExportWork);
                if (checkstatus == 0)
                {
                    DataRow dataRow = dataTable.NewRow();
                    dataRow["SupplierCdRF"] = AppendZero(supplier.SupplierCd.ToString(), 6);
                    dataRow["SupplierNm1RF"] = GetSubString(supplier.SupplierNm1, 30);
                    dataRow["SupplierNm2RF"] = GetSubString(supplier.SupplierNm2, 30);
                    dataRow["SupplierSnmRF"] = GetSubString(supplier.SupplierSnm, 20);
                    dataRow["SupplierKanaRF"] = GetSubString(supplier.SupplierKana, 30);
                    dataRow["SuppHonorificTitleRF"] = GetSubString(supplier.SuppHonorificTitle, 4);
                    dataRow["OrderHonorificTtlRF"] = GetSubString(supplier.OrderHonorificTtl, 4);
                    dataRow["MngSectionCodeRF"] = AppendStrZero(supplier.MngSectionCode, 2);
                    dataRow["StockAgentCodeRF"] = supplier.StockAgentCode.Trim();
                    dataRow["PureCodeRF"] = supplier.PureCode;

                    dataRow["SupplierAttributeDivRF"] = supplier.SupplierAttributeDiv;

                    dataRow["BusinessTypeCodeRF"] = AppendZero(supplier.BusinessTypeCode.ToString(), 4);
                    dataRow["SalesAreaCodeRF"] = AppendZero(supplier.SalesAreaCode.ToString(), 4);
                    dataRow["PaymentSectionCodeRF"] = AppendStrZero(supplier.PaymentSectionCode, 2);
                    dataRow["PayeeCodeRF"] = AppendZero(supplier.PayeeCode.ToString(), 6);
                    if (supplier.PaymentTotalDay == 0)
                    {
                        dataRow["PaymentTotalDayRF"] = DBNull.Value;
                    }
                    else
                    {
                        dataRow["PaymentTotalDayRF"] = supplier.PaymentTotalDay.ToString();
                    }
                    
                    dataRow["PaymentMonthCodeRF"] = supplier.PaymentMonthCode;
                    if (supplier.PaymentDay == 0)
                    {
                        dataRow["PaymentDayRF"] = DBNull.Value;
                    }
                    else
                    {
                        dataRow["PaymentDayRF"] = supplier.PaymentDay.ToString();
                    }
                    dataRow["PaymentCondRF"] = GetSubString(supplier.PaymentCond.ToString(), 2);
                    dataRow["PaymentSightRF"] = GetSubString(supplier.PaymentSight.ToString(), 3);
                    if (supplier.NTimeCalcStDate == 0)
                    {
                        dataRow["NTimeCalcStDateRF"] = DBNull.Value;
                    }
                    else
                    {
                        dataRow["NTimeCalcStDateRF"] = supplier.NTimeCalcStDate.ToString();
                    }
                    dataRow["SuppCTaxLayRefCdRF"] = supplier.SuppCTaxLayRefCd;
                    dataRow["SuppCTaxLayCdRF"] = supplier.SuppCTaxLayCd;
                    dataRow["StockUnPrcFrcProcCdRF"] = supplier.StockUnPrcFrcProcCd;
                    dataRow["StockMoneyFrcProcCdRF"] = supplier.StockMoneyFrcProcCd;
                    dataRow["StockCnsTaxFrcProcCdRF"] = supplier.StockCnsTaxFrcProcCd;

                    dataRow["SupplierPostNoRF"] = GetSubString(supplier.SupplierPostNo, 10);
                    dataRow["SupplierAddr1RF"] = GetSubString(supplier.SupplierAddr1, 30);
                    dataRow["SupplierAddr3RF"] = GetSubString(supplier.SupplierAddr3, 22);
                    dataRow["SupplierAddr4RF"] = GetSubString(supplier.SupplierAddr4, 30);
                    dataRow["SupplierTelNoRF"] = GetSubString(supplier.SupplierTelNo, 16);
                    dataRow["SupplierTelNo1RF"] = GetSubString(supplier.SupplierTelNo1, 16);
                    dataRow["SupplierTelNo2RF"] = GetSubString(supplier.SupplierTelNo2, 16);
                    dataRow["SupplierNote1RF"] = GetSubString(supplier.SupplierNote1, 20);
                    dataRow["SupplierNote2RF"] = GetSubString(supplier.SupplierNote2, 20);
                    dataRow["SupplierNote3RF"] = GetSubString(supplier.SupplierNote3, 20);
                    dataRow["SupplierNote4RF"] = GetSubString(supplier.SupplierNote4, 20);
                    dataTable.Rows.Add(dataRow);
                }
            }
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="supplier">仕入先データ</param>
        /// <param name="postcardEnvelopeDMWork">検索条件</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        private int DataCheck(Supplier supplier, SupplierExportWork supplierExportWork)
        {
            int status = 0;
            // 仕入先コード
            if (supplier.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }
            int stSupplierCd = supplierExportWork.SupplierCdSt;
            int edSupplierCd = supplierExportWork.SupplierCdEd;

            if (stSupplierCd != 0 && supplier.SupplierCd < stSupplierCd)
            {
                status = -1;
                return status;

            }
            if (edSupplierCd != 0 && supplier.SupplierCd > edSupplierCd)
            {
                status = -1;
                return status;

            }
            // 拠点コード
            if (String.IsNullOrEmpty(supplier.MngSectionCode))
            {
                status = -1;
                return status;
            }
            else
            {
                int supplierSectionCd = System.Convert.ToInt32(supplier.MngSectionCode.Trim());
                if (!String.IsNullOrEmpty(supplierExportWork.SectionCdSt.Trim()) && supplierSectionCd < Int32.Parse(supplierExportWork.SectionCdSt.Trim()))
                {
                    status = -1;
                    return status;
                }
                if (!String.IsNullOrEmpty(supplierExportWork.SectionCdEd.Trim()) && supplierSectionCd > Int32.Parse(supplierExportWork.SectionCdEd.Trim()))
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }

        /// <summary>
        /// AppendZero
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="maxSize">桁</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : 朱宝軍</br>
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
        /// <param name="length">桁</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataSetに行う。</br>
        /// <br>Programmer : 朱宝軍</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            bfString = bfString.Trim();
            string afString = "";
            if (bfString.Trim().Length > length)
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
        /// <param name="maxSize">桁</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : 朱宝軍</br>
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
        # endregion

    }
}
