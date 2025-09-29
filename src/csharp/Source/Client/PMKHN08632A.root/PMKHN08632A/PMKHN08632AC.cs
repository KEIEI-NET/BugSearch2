using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 売上目標設定マスタテーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上目標設定マスタテーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
    /// <br>Update Note: 2009/03/06 30452 上野 俊治</br>
    /// <br>            ・障害対応12219</br>
	/// <br></br>
    /// </remarks>
	public class SalesTargetSetAcs 
	{
        #region ■ Constructor
        /// <summary>
        /// 売上目標設定マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上目標設定マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public SalesTargetSetAcs()
        {
            this._iSalTrgtPrintResultDB = (ISalTrgtPrintResultDB)MediationSalTrgtPrintResultDB.GetSalTrgtPrintResultDB();

        }

        /// <summary>
        /// 売上目標設定マスタ印刷アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上目標設定マスタ印刷アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.15</br>
        /// </remarks>
        static SalesTargetSetAcs()
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
        ISalTrgtPrintResultDB _iSalTrgtPrintResultDB;
        #endregion ■ Private Member

		/// <summary>
		/// 売上目標設定マスタ全検索処理（論理削除除く）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 売上目標設定マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, SalesTargetPrintWork salesTargetPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, salesTargetPrintWork);
		}

		/// <summary>
		/// 売上目標設定マスタ検索処理（論理削除）
		/// </summary>
		/// <param name="retList">読込結果コレクション</param>
		/// <param name="enterpriseCode">企業コード</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 売上目標設定マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int SearchDelete(out ArrayList retList, string enterpriseCode, SalesTargetPrintWork salesTargetPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData1, 0, salesTargetPrintWork);
		}


		/// <summary>
		/// 売上目標設定マスタ検索処理
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
		/// <br>Note       : 売上目標設定マスタの検索処理を行います。</br>
		/// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SalesTargetPrintWork salesTargetPrintWork)
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
                SalTrgtPrintParamWork salTrgtPrintParamWork = new SalTrgtPrintParamWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevReatCndtn(salesTargetPrintWork, enterpriseCode, out salTrgtPrintParamWork);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retReatList = null;

                status = this._iSalTrgtPrintResultDB.Search(out retReatList, salTrgtPrintParamWork, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevReatData(salesTargetPrintWork, (ArrayList)retReatList, out retList);

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
        /// <param name="salesTargetPrintWork">UI抽出条件クラス</param>
        /// <param name="salTrgtPrintParamWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevReatCndtn(SalesTargetPrintWork salesTargetPrintWork, string enterpriseCode, out SalTrgtPrintParamWork salTrgtPrintParamWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            salTrgtPrintParamWork = new SalTrgtPrintParamWork();
            try
            {
                salTrgtPrintParamWork.EnterpriseCode = enterpriseCode;  // 企業コード
                // 抽出条件パラメータセット
                salTrgtPrintParamWork.SectionCodes = null;
                salTrgtPrintParamWork.PrintType = salesTargetPrintWork.PrintType;
                switch (salesTargetPrintWork.PrintType)
                {
                    case 0: //拠点
                        salTrgtPrintParamWork.PrintType = 10;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 1: //拠点-部門 
                        salTrgtPrintParamWork.PrintType = 20;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 2: //拠点-担当者 
                        salTrgtPrintParamWork.PrintType = 22;
                        salTrgtPrintParamWork.EmployeeDivCd = 10;
                        break;
                    case 3://拠点-受注者 
                        salTrgtPrintParamWork.PrintType = 22;
                        salTrgtPrintParamWork.EmployeeDivCd = 20;
                        break;
                    case 4://拠点-発行者 
                        salTrgtPrintParamWork.PrintType = 22;
                        salTrgtPrintParamWork.EmployeeDivCd = 30;
                        break;
                    case 5://拠点-販売区分 
                        salTrgtPrintParamWork.PrintType = 44;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 6://拠点-商品区分 
                        salTrgtPrintParamWork.PrintType = 45;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 7://拠点-得意先 
                        salTrgtPrintParamWork.PrintType = 30;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 8://拠点-業種 
                        salTrgtPrintParamWork.PrintType = 31;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 9://拠点-地区
                        salTrgtPrintParamWork.PrintType = 32;
                        salTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                }
                salTrgtPrintParamWork.SearchDiv = 0;
                salTrgtPrintParamWork.TargetDivideCodeSt = salesTargetPrintWork.TargetDivideCodeSt;
                salTrgtPrintParamWork.TargetDivideCodeEd = salesTargetPrintWork.TargetDivideCodeEd;
                salTrgtPrintParamWork.SubSectionCodeSt = salesTargetPrintWork.SubSectionCodeSt;
                if (salesTargetPrintWork.SubSectionCodeEd == 0)
                {
                    salTrgtPrintParamWork.SubSectionCodeEd = 99;
                }
                else
                {
                    salTrgtPrintParamWork.SubSectionCodeEd = salesTargetPrintWork.SubSectionCodeEd;
                }
                salTrgtPrintParamWork.EmployeeCodeSt = salesTargetPrintWork.EmployeeCodeSt;
                salTrgtPrintParamWork.EmployeeCodeEd = salesTargetPrintWork.EmployeeCodeEd;
                salTrgtPrintParamWork.SalesCodeSt = salesTargetPrintWork.SalesCodeSt;
                if (salesTargetPrintWork.SalesCodeEd == 0)
                {
                    salTrgtPrintParamWork.SalesCodeEd = 9999;
                }
                else
                {
                    salTrgtPrintParamWork.SalesCodeEd = salesTargetPrintWork.SalesCodeEd;
                }
                salTrgtPrintParamWork.EnterpriseGanreCodeSt = salesTargetPrintWork.EnterpriseGanreCodeSt;
                if (salesTargetPrintWork.EnterpriseGanreCodeEd == 0)
                {
                    salTrgtPrintParamWork.EnterpriseGanreCodeEd = 9999;
                }
                else
                {
                    salTrgtPrintParamWork.EnterpriseGanreCodeEd = salesTargetPrintWork.EnterpriseGanreCodeEd;
                }
                salTrgtPrintParamWork.CustomerCodeSt = salesTargetPrintWork.CustomerCodeSt;
                if (salesTargetPrintWork.CustomerCodeEd == 0)
                {
                    salTrgtPrintParamWork.CustomerCodeEd = 99999999;
                }
                else
                {
                    salTrgtPrintParamWork.CustomerCodeEd = salesTargetPrintWork.CustomerCodeEd;
                }
                salTrgtPrintParamWork.BusinessTypeCodeSt = salesTargetPrintWork.BusinessTypeCodeSt;
                if (salesTargetPrintWork.BusinessTypeCodeEd == 0)
                {
                    salTrgtPrintParamWork.BusinessTypeCodeEd = 9999;
                }
                else
                {
                    salTrgtPrintParamWork.BusinessTypeCodeEd = salesTargetPrintWork.BusinessTypeCodeEd;
                }
                salTrgtPrintParamWork.SalesAreaCodeSt = salesTargetPrintWork.SalesAreaCodeSt;
                if (salesTargetPrintWork.SalesAreaCodeEd == 0)
                {
                    salTrgtPrintParamWork.SalesAreaCodeEd = 9999;
                }
                else
                {
                    salTrgtPrintParamWork.SalesAreaCodeEd = salesTargetPrintWork.SalesAreaCodeEd;
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
        /// <param name="salesTargetPrintWork">UI抽出条件クラス</param>
        /// <param name="retaWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 30462 行澤 仁美</br>
        /// <br>Date       : 2008.07.17</br>
        /// </remarks>
        private void DevReatData(SalesTargetPrintWork salesTargetPrintWork, ArrayList retaWork, out ArrayList retList)
        {

            retList = new ArrayList();

            foreach (SalTrgtPrintResultWork salTrgtPrintResultWork in retaWork)
            {
                if (DataCheck(salTrgtPrintResultWork, salesTargetPrintWork) == 0)
                {
                    SalesTargetSet salesTargetSet = new SalesTargetSet();

                    salesTargetSet.SectionCode = salTrgtPrintResultWork.SectionCode;
                    salesTargetSet.SectionGuideSnm = salTrgtPrintResultWork.SectionGuideSnm;
                    salesTargetSet.SubSectionCode = salTrgtPrintResultWork.SubSectionCode;
                    salesTargetSet.SubSectionName = salTrgtPrintResultWork.SubSectionName;
                    salesTargetSet.SalesEmployeeCd = salTrgtPrintResultWork.SalesEmployeeCd;
                    salesTargetSet.SalesEmployeeNm = salTrgtPrintResultWork.SalesEmployeeNm;
                    salesTargetSet.FrontEmployeeCd = salTrgtPrintResultWork.FrontEmployeeCd;
                    salesTargetSet.FrontEmployeeNm = salTrgtPrintResultWork.FrontEmployeeNm;
                    salesTargetSet.SalesInputCode = salTrgtPrintResultWork.SalesInputCode;
                    salesTargetSet.SalesInputName = salTrgtPrintResultWork.SalesInputName;
                    salesTargetSet.SalesCode = salTrgtPrintResultWork.SalesCode;
                    salesTargetSet.SalesCodeName = salTrgtPrintResultWork.SalesCodeName;
                    salesTargetSet.EnterpriseGanreCode = salTrgtPrintResultWork.EnterpriseGanreCode;
                    salesTargetSet.EnterpriseGanreCodeName = salTrgtPrintResultWork.EnterpriseGanreCodeName;
                    salesTargetSet.CustomerCode = salTrgtPrintResultWork.CustomerCode;
                    salesTargetSet.CustomerSnm = salTrgtPrintResultWork.CustomerSnm;
                    salesTargetSet.BusinessTypeCode = salTrgtPrintResultWork.BusinessTypeCode;
                    salesTargetSet.BusinessTypeCodeName = salTrgtPrintResultWork.BusinessTypeCodeName;
                    salesTargetSet.SalesAreaCode = salTrgtPrintResultWork.SalesAreaCode;
                    salesTargetSet.SalesAreaCodeName = salTrgtPrintResultWork.SalesAreaCodeName;
                    salesTargetSet.SalesTargetMoney1 = salTrgtPrintResultWork.SalesTargetMoney1;
                    salesTargetSet.SalesTargetMoney2 = salTrgtPrintResultWork.SalesTargetMoney2;
                    salesTargetSet.SalesTargetMoney3 = salTrgtPrintResultWork.SalesTargetMoney3;
                    salesTargetSet.SalesTargetMoney4 = salTrgtPrintResultWork.SalesTargetMoney4;
                    salesTargetSet.SalesTargetMoney5 = salTrgtPrintResultWork.SalesTargetMoney5;
                    salesTargetSet.SalesTargetMoney6 = salTrgtPrintResultWork.SalesTargetMoney6;
                    salesTargetSet.SalesTargetMoney7 = salTrgtPrintResultWork.SalesTargetMoney7;
                    salesTargetSet.SalesTargetMoney8 = salTrgtPrintResultWork.SalesTargetMoney8;
                    salesTargetSet.SalesTargetMoney9 = salTrgtPrintResultWork.SalesTargetMoney9;
                    salesTargetSet.SalesTargetMoney10 = salTrgtPrintResultWork.SalesTargetMoney10;
                    salesTargetSet.SalesTargetMoney11 = salTrgtPrintResultWork.SalesTargetMoney11;
                    salesTargetSet.SalesTargetMoney12 = salTrgtPrintResultWork.SalesTargetMoney12;
                    salesTargetSet.SalesTargetProfit1 = salTrgtPrintResultWork.SalesTargetProfit1;
                    salesTargetSet.SalesTargetProfit2 = salTrgtPrintResultWork.SalesTargetProfit2;
                    salesTargetSet.SalesTargetProfit3 = salTrgtPrintResultWork.SalesTargetProfit3;
                    salesTargetSet.SalesTargetProfit4 = salTrgtPrintResultWork.SalesTargetProfit4;
                    salesTargetSet.SalesTargetProfit5 = salTrgtPrintResultWork.SalesTargetProfit5;
                    salesTargetSet.SalesTargetProfit6 = salTrgtPrintResultWork.SalesTargetProfit6;
                    salesTargetSet.SalesTargetProfit7 = salTrgtPrintResultWork.SalesTargetProfit7;
                    salesTargetSet.SalesTargetProfit8 = salTrgtPrintResultWork.SalesTargetProfit8;
                    salesTargetSet.SalesTargetProfit9 = salTrgtPrintResultWork.SalesTargetProfit9;
                    salesTargetSet.SalesTargetProfit10 = salTrgtPrintResultWork.SalesTargetProfit10;
                    salesTargetSet.SalesTargetProfit11 = salTrgtPrintResultWork.SalesTargetProfit11;
                    salesTargetSet.SalesTargetProfit12 = salTrgtPrintResultWork.SalesTargetProfit12;

                    retList.Add(salesTargetSet);
                }

            }

        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(SalTrgtPrintResultWork salTrgtPrintResultWork, SalesTargetPrintWork salesTargetPrintWork)
        {
            int status = 0;

            string upDateTime = salTrgtPrintResultWork.UpdateDateTime.Year.ToString("0000") +
                                salTrgtPrintResultWork.UpdateDateTime.Month.ToString("00") +
                                salTrgtPrintResultWork.UpdateDateTime.Day.ToString("00");

            if (salesTargetPrintWork.LogicalDeleteCode == 1 &&
                salesTargetPrintWork.DeleteDateTimeSt != 0 &&
                salesTargetPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < salesTargetPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > salesTargetPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (salesTargetPrintWork.LogicalDeleteCode == 1 &&
                        salesTargetPrintWork.DeleteDateTimeSt != 0 &&
                        salesTargetPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < salesTargetPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (salesTargetPrintWork.LogicalDeleteCode == 1 &&
                   salesTargetPrintWork.DeleteDateTimeSt == 0 &&
                   salesTargetPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > salesTargetPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }

            // --- DEL 2009/03/06 -------------------------------->>>>>
            //if (Int32.Parse(salTrgtPrintResultWork.SectionCode) < Int32.Parse(salesTargetPrintWork.SectionCodeSt) ||
            //        Int32.Parse(salTrgtPrintResultWork.SectionCode) > Int32.Parse(salesTargetPrintWork.SectionCodeEd))
            //{
            //    status = -1;
            //    return status;
            //}
            // --- DEL 2009/03/06 --------------------------------<<<<<
            // --- ADD 2009/03/06 -------------------------------->>>>>
            // 拠点の抽出条件
            int st_SectionCode = 0;
            int ed_SectionCode = 0;
            Int32.TryParse(salesTargetPrintWork.SectionCodeSt, out st_SectionCode);
            Int32.TryParse(salesTargetPrintWork.SectionCodeEd, out ed_SectionCode);

            int result_SectionCode = 0;
            Int32.TryParse(salTrgtPrintResultWork.SectionCode, out result_SectionCode);

            if (st_SectionCode != 0)
            {
                if (result_SectionCode < st_SectionCode)
                {
                    status = -1;
                    return status;
                }
            }

            if (ed_SectionCode != 0)
            {
                if (result_SectionCode > ed_SectionCode)
                {
                    status = -1;
                    return status;
                }
            }
            // --- ADD 2009/03/06 --------------------------------<<<<<

            return status;
        }
    }
}
