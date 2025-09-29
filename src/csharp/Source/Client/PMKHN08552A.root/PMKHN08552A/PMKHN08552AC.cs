using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;
namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 得意先マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class CustomerSetAcs
    {
        #region ■ Constructor
        /// <summary>
        /// 得意先マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public CustomerSetAcs()
        {
            this._iCustomerCustomerChangeDB = (ICustomerCustomerChangeDB)MediationCustomerCustomerChangeDB.GetCustomerCustomerChangeDB();
        }

        /// <summary>
        /// 得意先マスタ印刷アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ印刷アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.15</br>
        /// </remarks>
        static CustomerSetAcs()
        {
            stc_Employee = null;
            stc_PrtOutSetAcs = new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs = new SecInfoAcs(1);         // 拠点アクセスクラス
            stc_SectionDic = new Dictionary<string, SecInfoSet>();  // 拠点Dictionary

            Employee loginWorker = null;
            string ownSectionCode = "";

            if (LoginInfoAcquisition.Employee != null)
            {
                loginWorker = LoginInfoAcquisition.Employee.Clone();
                ownSectionCode = loginWorker.BelongSectionCode;
            }


            // ログイン拠点取得
            Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
            if (loginEmployee != null)
            {
                stc_Employee = loginEmployee.Clone();
            }

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach (SecInfoSet secInfoSet in secInfoSetList)
            {
                // 既存でなければ
                if (!stc_SectionDic.ContainsKey(secInfoSet.SectionCode))
                {
                    // 追加
                    stc_SectionDic.Add(secInfoSet.SectionCode, secInfoSet);
                }
            }
        }
        #endregion ■ Constructor

        #region ■ Static Member
        private static Employee stc_Employee;
        private static PrtOutSetAcs stc_PrtOutSetAcs;	                // 帳票出力設定アクセスクラス
        private static SecInfoAcs stc_SecInfoAcs;                       // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
        #endregion ■ Static Member

        #region ■ Private Member
        private ICustomerCustomerChangeDB _iCustomerCustomerChangeDB;
        #endregion ■ Private Member

		/// <summary>
		/// 得意先マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, CustomerPrintWork customerPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, customerPrintWork);
		}

		/// <summary>
		/// 得意先マスタ検索処理（論理削除含む）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchDelete(out ArrayList retList, string enterpriseCode, CustomerPrintWork customerPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData1, 0, customerPrintWork);
		}

		

		/// <summary>
		/// 得意先マスタ検索処理
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
		/// <param name="nextData">次データ有無</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
		/// <param name="readCnt">読込件数</param>
        /// <param name="sectionPrintWork">抽出条件</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 得意先マスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, CustomerPrintWork customerPrintWork)
		{

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            try
            {
                CustomerCustomerChangeParamWork customerCustomerChangeParamWork = new CustomerCustomerChangeParamWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevReatCndtn(customerPrintWork, enterpriseCode, out customerCustomerChangeParamWork);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retReatList = null;

                status = this._iCustomerCustomerChangeDB.Search(ref retReatList, customerCustomerChangeParamWork,0 ,logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevReatData(customerPrintWork, (ArrayList)retReatList, out retList);

                        if (retList.Count == 0)
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
            return status;
		}

        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="goodsPrintWork">UI抽出条件クラス</param>
        /// <param name="goodsPrintParamWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevReatCndtn(CustomerPrintWork customerPrintWork, string enterpriseCode, out CustomerCustomerChangeParamWork customerCustomerChangeParamWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            customerCustomerChangeParamWork = new CustomerCustomerChangeParamWork();
            try
            {
                customerCustomerChangeParamWork.EnterpriseCode = enterpriseCode;  // 企業コード
                // 抽出条件パラメータセット
                // DEL 2008/11/28 不具合対応[8306] ---------->>>>>
                //if (customerPrintWork.MngSectionCodeSt.Trim().Equals(string.Empty))
                //{
                //    customerCustomerChangeParamWork.StMngSectionCode = 0;
                //}
                //else
                //{
                //    customerCustomerChangeParamWork.StMngSectionCode = customerPrintWork.MngSectionCodeSt.Trim().PadLeft(2,'0');
                //}
                //if (customerPrintWork.MngSectionCodeEd.Trim().Equals(string.Empty))
                //{
                //    customerCustomerChangeParamWork.EdMngSectionCode = 99;
                //}
                //else
                //{
                //    customerCustomerChangeParamWork.EdMngSectionCode = Int32.Parse(customerPrintWork.MngSectionCodeEd);
                //}
                // DEL 2008/11/28 不具合対応[8306] ----------<<<<<
                // ADD 2008/11/28 不具合対応[8306] ---------->>>>>
                customerCustomerChangeParamWork.StMngSectionCode = customerPrintWork.MngSectionCodeSt.Trim().PadLeft(2, '0');
                if (customerPrintWork.MngSectionCodeEd.Trim().Equals(string.Empty))
                {
                    customerCustomerChangeParamWork.EdMngSectionCode = "99";
                }
                else
                {
                    customerCustomerChangeParamWork.EdMngSectionCode = customerPrintWork.MngSectionCodeEd.Trim().PadLeft(2,'0');
                }
                // ADD 2008/11/28 不具合対応[8306] ----------<<<<<
                customerCustomerChangeParamWork.StCustomerCode = customerPrintWork.CustomerCodeSt;
                if (customerPrintWork.CustomerCodeEd == 0)
                {
                    customerCustomerChangeParamWork.EdCustomerCode = 99999999;
                }
                else
                {
                    customerCustomerChangeParamWork.EdCustomerCode = customerPrintWork.CustomerCodeEd;
                }
                customerCustomerChangeParamWork.StKana = customerPrintWork.KanaSt;
                customerCustomerChangeParamWork.EdKana = customerPrintWork.KanaEd;
                customerCustomerChangeParamWork.StCustomerAgentCd = customerPrintWork.CustomerAgentCdSt;
                customerCustomerChangeParamWork.EdCustomerAgentCd = customerPrintWork.CustomerAgentCdEd;
                customerCustomerChangeParamWork.StSalesAreaCode = customerPrintWork.SalesAreaCodeSt;
                if (customerPrintWork.SalesAreaCodeEd == 0)
                {
                    customerCustomerChangeParamWork.EdSalesAreaCode = 9999;
                }
                else
                {
                    customerCustomerChangeParamWork.EdSalesAreaCode = customerPrintWork.SalesAreaCodeEd;
                }
                customerCustomerChangeParamWork.StBusinessTypeCode = customerPrintWork.BusinessTypeCodeSt;
                if (customerPrintWork.BusinessTypeCodeEd == 0)
                {
                    customerCustomerChangeParamWork.EdBusinessTypeCode = 9999;
                }
                else
                {
                    customerCustomerChangeParamWork.EdBusinessTypeCode = customerPrintWork.BusinessTypeCodeEd;
                }

                if (customerPrintWork.PrintType == 2)
                {
                    customerCustomerChangeParamWork.SearchDiv = 1;
                }
                else
                {
                    customerCustomerChangeParamWork.SearchDiv = 0;
                }

            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="goodsPrintWork">UI抽出条件クラス</param>
        /// <param name="retaWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.07.17</br>
        /// </remarks>
        private void DevReatData(CustomerPrintWork customerPrintWork, ArrayList retaWork, out ArrayList retList)
        {

            retList = new ArrayList();

            foreach (CustomerCustomerChangeResultWork customerCustomerChangeResultWork in retaWork)
            {
                if (DataCheck(customerCustomerChangeResultWork, customerPrintWork) == 0)
                {
                    CustomerSet customerSet = new CustomerSet();

                    customerSet.CustomerCode = customerCustomerChangeResultWork.CustomerCode;
                    customerSet.Kana = customerCustomerChangeResultWork.Kana;
                    customerSet.OfficeTelNo = customerCustomerChangeResultWork.OfficeTelNo;
                    customerSet.PortableTelNo = customerCustomerChangeResultWork.PortableTelNo;
                    customerSet.OfficeFaxNo = customerCustomerChangeResultWork.OfficeFaxNo;
                    customerSet.TotalDay = customerCustomerChangeResultWork.TotalDay;
                    customerSet.CollectMoneyName = customerCustomerChangeResultWork.CollectMoneyName;
                    customerSet.CollectMoneyDay = customerCustomerChangeResultWork.CollectMoneyDay;
                    customerSet.CustomerAgentCd = customerCustomerChangeResultWork.CustomerAgentCd;
                    customerSet.CustomerAgentName = customerCustomerChangeResultWork.CustomerAgentNm;
                    customerSet.SalesAreaCode = customerCustomerChangeResultWork.SalesAreaCode;
                    customerSet.SalesAreaName = customerCustomerChangeResultWork.SalesAreaName;
                    customerSet.BusinessTypeCode = customerCustomerChangeResultWork.BusinessTypeCode;
                    customerSet.BusinessTypeName = customerCustomerChangeResultWork.BusinessTypeName;
                    customerSet.ClaimSectionCode = customerCustomerChangeResultWork.ClaimSectionCode;
                    customerSet.ClaimCode = customerCustomerChangeResultWork.ClaimCode;
                    customerSet.BillCollecterCd = customerCustomerChangeResultWork.BillCollecterCd;
                    customerSet.PostNo = customerCustomerChangeResultWork.PostNo;
                    customerSet.Address1 = customerCustomerChangeResultWork.Address1;
                    customerSet.Address3 = customerCustomerChangeResultWork.Address3;
                    customerSet.Address4 = customerCustomerChangeResultWork.Address4;
                    customerSet.MngSectionCode = customerCustomerChangeResultWork.MngSectionCode;
                    customerSet.SectionGuideSnm = customerCustomerChangeResultWork.MngSectionName;
                    customerSet.CustWarehouseCd = customerCustomerChangeResultWork.CustWarehouseCd;
                    customerSet.Name = customerCustomerChangeResultWork.Name;
                    customerSet.Name2 = customerCustomerChangeResultWork.Name2;
                    customerSet.CustomerSnm = customerCustomerChangeResultWork.CustomerSnm;
                    customerSet.PureCode = customerCustomerChangeResultWork.RateGPureCode;
                    customerSet.GoodsMakerCd = customerCustomerChangeResultWork.GoodsMakerCd;
                    customerSet.CustRateGrpCode = customerCustomerChangeResultWork.CustRateGrpCode;
                    retList.Add(customerSet);
                }

            }

        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(CustomerCustomerChangeResultWork customerCustomerChangeResultWork, CustomerPrintWork customerPrintWork)
        {
            int status = 0;

            string upDateTime = customerCustomerChangeResultWork.UpdateDateTime.Year.ToString("0000") +
                                customerCustomerChangeResultWork.UpdateDateTime.Month.ToString("00") +
                                customerCustomerChangeResultWork.UpdateDateTime.Day.ToString("00");

            if (customerPrintWork.LogicalDeleteCode == 1 &&
                customerPrintWork.DeleteDateTimeSt != 0 &&
                customerPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < customerPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > customerPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (customerPrintWork.LogicalDeleteCode == 1 &&
                        customerPrintWork.DeleteDateTimeSt != 0 &&
                        customerPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < customerPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (customerPrintWork.LogicalDeleteCode == 1 &&
                 customerPrintWork.DeleteDateTimeSt == 0 &&
                 customerPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > customerPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            // 掛率グループ設定の場合、不要データは不可とする
            if (customerPrintWork.PrintType == 2)
            {
                // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                // TODO:if (customerCustomerChangeResultWork.CustRateGrpCode == 0)
                // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<
                // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                if (customerCustomerChangeResultWork.CustRateGrpCode < 0)
                // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }
               
        #region 掛率グループ読込
        ///// <summary>
        ///// 純正区分取得処理
        ///// </summary>
        ///// <param name="makerCode">得意先コード</param>
        ///// <returns>純正区分</returns>
        ///// <remarks>
        ///// <br>Note       : 純正区分を取得します。</br>
        ///// </remarks>
        //private int GetPureCodeCd(int customerCode, string enterpriseCode)
        //{
        //    int PureCodeCd = 0;
        //    ReadCustRateGroup(enterpriseCode);
        //    if (this._CustRateGroupDic.ContainsKey(customerCode))
        //    {
        //        PureCodeCd = this._CustRateGroupDic[customerCode].PureCode;
        //    }

        //    return PureCodeCd;
        //}

        ///// <summary>
        ///// メーカーコード取得処理
        ///// </summary>
        ///// <param name="makerCode">得意先コード</param>
        ///// <returns>メーカーコードコード</returns>
        ///// <remarks>
        ///// <br>Note       : メーカーコードを取得します。</br>
        ///// </remarks>
        //private int GetGoodsMakerCd(int customerCode, string enterpriseCode)
        //{
        //    int goodsMakerCd = 0;
        //    ReadCustRateGroup(enterpriseCode);
        //    if (this._CustRateGroupDic.ContainsKey(customerCode))
        //    {
        //        goodsMakerCd = this._CustRateGroupDic[customerCode].GoodsMakerCd;
        //    }

        //    return goodsMakerCd;
        //}

        ///// <summary>
        ///// 掛率グループコード取得処理
        ///// </summary>
        ///// <param name="makerCode">得意先コード</param>
        ///// <returns>掛率グループコード</returns>
        ///// <remarks>
        ///// <br>Note       : 掛率グループコードを取得します。</br>
        ///// </remarks>
        //private int GetCustRateGrpCode(int customerCode, string enterpriseCode)
        //{
        //    int custRateGrpCode = 0;
        //    ReadCustRateGroup(enterpriseCode);
        //    if (this._CustRateGroupDic.ContainsKey(customerCode))
        //    {
        //        custRateGrpCode = this._CustRateGroupDic[customerCode].CustRateGrpCode;
        //    }

        //    return custRateGrpCode;
        //}

        ///// <summary>
        ///// メーカー読込処理
        ///// </summary>
        ///// <remarks>
        ///// <br>Note       : メーカー一覧を読み込みます。</br>
        ///// </remarks>
        //private void ReadCustRateGroup(string enterpriseCode)
        //{
        //    try
        //    {
        //        if (this._CustRateGroupDic.Count == 0)
        //        {
        //            this._CustRateGroupDic = new Dictionary<int, CustRateGroup>();

        //            ArrayList retList;

        //            int status = this._CustRateGroupAcs.Search(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        //            if (status == 0)
        //            {
        //                foreach (CustRateGroup custRateGroup in retList)
        //                {
        //                    if (custRateGroup.LogicalDeleteCode == 0)
        //                    {
        //                        this._CustRateGroupDic.Add(custRateGroup.CustomerCode, custRateGroup);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        this._CustRateGroupDic = new Dictionary<int, CustRateGroup>();

        //        ArrayList retList;

        //        int status = this._CustRateGroupAcs.Search(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        //        if (status == 0)
        //        {
        //            foreach (CustRateGroup custRateGroup in retList)
        //            {
        //                if (custRateGroup.LogicalDeleteCode == 0)
        //                {
        //                    this._CustRateGroupDic.Add(custRateGroup.CustomerCode, custRateGroup);
        //                }
        //            }
        //        }
        //    }
        //    return;
        //}
        #endregion 掛率グループ読込

    }
}
