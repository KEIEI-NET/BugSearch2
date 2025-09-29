//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン目標設定マスタ（印刷）
// プログラム概要   : キャンペーン目標設定マスタで設定した内容を一覧出力し
//                    確認する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 楊明俊
// 作 成 日  2011/04/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// キャンペーン目標設定マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン目標設定マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 楊明俊</br>
    /// <br>Date       : 2011/04/25</br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    public class CampaignTargetSetAcs 
    {
        #region ■ Constructor
        /// <summary>
        /// キャンペーン目標設定マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        public CampaignTargetSetAcs()
        {
            this._iCampTrgtPrintResultDB = (ICampTrgtPrintResultDB)MediationCampTrgtPrintResultDB.GetCampTrgtPrintResultDB();
        }

        /// <summary>
        /// キャンペーン目標設定マスタ印刷アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定マスタ印刷アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        static CampaignTargetSetAcs()
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
        ICampTrgtPrintResultDB _iCampTrgtPrintResultDB;
        #endregion ■ Private Member

        /// <summary>
        /// キャンペーン目標設定マスタ全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, CampaignTargetPrintWork campaignTargetPrintWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, campaignTargetPrintWork);
        }

        /// <summary>
        /// キャンペーン目標設定マスタ検索処理（論理削除）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン目標設定マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        public int SearchDelete(out ArrayList retList, string enterpriseCode, CampaignTargetPrintWork campaignTargetPrintWork)
        {

            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData1, 0, campaignTargetPrintWork);
        }

        /// <summary>
        /// キャンペーン目標設定マスタ検索処理
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
        /// <br>Note       : キャンペーン目標設定マスタの検索処理を行います。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// <br>Update Note: </br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, CampaignTargetPrintWork campaignTargetPrintWork)
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
                CampTrgtPrintParamWork campTrgtPrintParamWork = new CampTrgtPrintParamWork();
                // 抽出条件展開  --------------------------------------------------------------
                status = this.DevReatCndtn(campaignTargetPrintWork, enterpriseCode, out campTrgtPrintParamWork);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  ----------------------------------------------------------------
                object retReatList = null;

                status = this._iCampTrgtPrintResultDB.Search(out retReatList, campTrgtPrintParamWork, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevReatData(campaignTargetPrintWork, (ArrayList)retReatList, out retList);

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
        /// <param name="campaignTargetPrintWork">UI抽出条件クラス</param>
        /// <param name="salTrgtPrintParamWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        private int DevReatCndtn(CampaignTargetPrintWork campaignTargetPrintWork, string enterpriseCode, out CampTrgtPrintParamWork campTrgtPrintParamWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            campTrgtPrintParamWork = new CampTrgtPrintParamWork();
            try
            {
                campTrgtPrintParamWork.StartMonth = campaignTargetPrintWork.StartMonth;

                campTrgtPrintParamWork.EnterpriseCode = enterpriseCode;  // 企業コード
                // 抽出条件パラメータセット
                campTrgtPrintParamWork.SectionCodes = null;
                // 拠点の相関処理
                campTrgtPrintParamWork.SectionCodeSt = campaignTargetPrintWork.SectionCodeSt;
                campTrgtPrintParamWork.SectionCodeEd = campaignTargetPrintWork.SectionCodeEd;

                campTrgtPrintParamWork.PrintType = campaignTargetPrintWork.PrintType;
                switch (campaignTargetPrintWork.PrintType)
                {
                    case 0: //拠点
                        campTrgtPrintParamWork.PrintType = 10;
                        campTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 1: //拠点-得意先  
                        campTrgtPrintParamWork.PrintType = 30;
                        campTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 2: //拠点-担当者 
                        campTrgtPrintParamWork.PrintType = 22;
                        campTrgtPrintParamWork.EmployeeDivCd = 10;
                        break;
                    case 3://拠点-受注者 
                        campTrgtPrintParamWork.PrintType = 22;
                        campTrgtPrintParamWork.EmployeeDivCd = 20;
                        break;
                    case 4://拠点-発行者 
                        campTrgtPrintParamWork.PrintType = 22;
                        campTrgtPrintParamWork.EmployeeDivCd = 30;
                        break;
                    case 5://拠点-地区
                        campTrgtPrintParamWork.PrintType = 32;
                        campTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 6://拠点+ｸﾞﾙｰﾌﾟｺｰﾄﾞ,
                        campTrgtPrintParamWork.PrintType = 50;
                        campTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 7://拠点+BLｺｰﾄﾞ 
                        campTrgtPrintParamWork.PrintType = 60;
                        campTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                    case 8://拠点-販売区分 
                        campTrgtPrintParamWork.PrintType = 44;
                        campTrgtPrintParamWork.EmployeeDivCd = 0;
                        break;
                }
                campTrgtPrintParamWork.CampaignCodeSt = campaignTargetPrintWork.CampaignCodeSt;
                if (campaignTargetPrintWork.CampaignCodeEd == 0)
                {
                    campTrgtPrintParamWork.CampaignCodeEd = 999999;
                }
                else
                {
                    campTrgtPrintParamWork.CampaignCodeEd = campaignTargetPrintWork.CampaignCodeEd;
                }

                campTrgtPrintParamWork.BlGoodsCdSt = campaignTargetPrintWork.BlGoodsCdSt;
                if (campaignTargetPrintWork.BlGoodsCdEd == 0)
                {
                    campTrgtPrintParamWork.BlGoodsCdEd = 99999999;
                }
                else
                {
                    campTrgtPrintParamWork.BlGoodsCdEd = campaignTargetPrintWork.BlGoodsCdEd;
                }
                campTrgtPrintParamWork.EmployeeCodeSt = campaignTargetPrintWork.EmployeeCodeSt;
                campTrgtPrintParamWork.EmployeeCodeEd = campaignTargetPrintWork.EmployeeCodeEd;

                campTrgtPrintParamWork.SalesCodeSt = campaignTargetPrintWork.SalesCodeSt;
                if (campaignTargetPrintWork.SalesCodeEd == 0)
                {
                    campTrgtPrintParamWork.SalesCodeEd = 9999;
                }
                else
                {
                    campTrgtPrintParamWork.SalesCodeEd = campaignTargetPrintWork.SalesCodeEd;
                }

                campTrgtPrintParamWork.BlGroupCodeSt = campaignTargetPrintWork.BlGroupCodeSt;
                if (campaignTargetPrintWork.BlGroupCodeEd == 0)
                {
                    campTrgtPrintParamWork.BlGroupCodeEd = 99999;
                }
                else
                {
                    campTrgtPrintParamWork.BlGroupCodeEd = campaignTargetPrintWork.BlGroupCodeEd;
                }

                campTrgtPrintParamWork.CustomerCodeSt = campaignTargetPrintWork.CustomerCodeSt;
                if (campaignTargetPrintWork.CustomerCodeEd == 0)
                {
                    campTrgtPrintParamWork.CustomerCodeEd = 99999999;
                }
                else
                {
                    campTrgtPrintParamWork.CustomerCodeEd = campaignTargetPrintWork.CustomerCodeEd;
                }

                campTrgtPrintParamWork.SalesAreaCodeSt = campaignTargetPrintWork.SalesAreaCodeSt;
                if (campaignTargetPrintWork.SalesAreaCodeEd == 0)
                {
                    campTrgtPrintParamWork.SalesAreaCodeEd = 9999;
                }
                else
                {
                    campTrgtPrintParamWork.SalesAreaCodeEd = campaignTargetPrintWork.SalesAreaCodeEd;
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
        /// <param name="campaignTargetPrintWork">UI抽出条件クラス</param>
        /// <param name="retaWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2011/04/25</br>
        /// </remarks>
        private void DevReatData(CampaignTargetPrintWork campaignTargetPrintWork, ArrayList retaWork, out ArrayList retList)
        {

            retList = new ArrayList();

            foreach (CampTrgtPrintResultWork campTrgtPrintResultWork in retaWork)
            {
                if (DataCheck(campTrgtPrintResultWork, campaignTargetPrintWork) == 0)
                {
                    CampaignTargetSet campaignTargetSet = new CampaignTargetSet();

                    campaignTargetSet.CampaignCode = campTrgtPrintResultWork.CampaignCode.ToString();
                    campaignTargetSet.CampaignCodeName = campTrgtPrintResultWork.CampaignName;
                    campaignTargetSet.SectionCode = campTrgtPrintResultWork.SectionCode;
                    campaignTargetSet.SectionGuideSnm = campTrgtPrintResultWork.SectionGuideSnm;
                    campaignTargetSet.BlGoodsCode = campTrgtPrintResultWork.BLGoodsCode;
                    campaignTargetSet.BlGoodsCodeName = campTrgtPrintResultWork.BLGoodsHalfName;
                    if (campTrgtPrintResultWork.EmployeeDivCd == 10)
                    {
                        campaignTargetSet.SalesEmployeeCd = campTrgtPrintResultWork.EmployeeCode;
                        campaignTargetSet.SalesEmployeeNm = campTrgtPrintResultWork.Name;
                    }
                    else if (campTrgtPrintResultWork.EmployeeDivCd == 20)
                    {
                        campaignTargetSet.FrontEmployeeCd = campTrgtPrintResultWork.EmployeeCode;
                        campaignTargetSet.FrontEmployeeNm = campTrgtPrintResultWork.Name;
                    }
                    else if (campTrgtPrintResultWork.EmployeeDivCd == 30)
                    {
                        campaignTargetSet.SalesInputCode = campTrgtPrintResultWork.EmployeeCode;
                        campaignTargetSet.SalesInputName = campTrgtPrintResultWork.Name;
                    }
                    campaignTargetSet.SalesCode = campTrgtPrintResultWork.SalesCode;
                    campaignTargetSet.SalesCodeName = campTrgtPrintResultWork.SalesCodeName;
                    campaignTargetSet.BlGroupCode = campTrgtPrintResultWork.BLGroupCode;
                    campaignTargetSet.BlGroupCodeName = campTrgtPrintResultWork.BLGroupKanaName;
                    campaignTargetSet.CustomerCode = campTrgtPrintResultWork.CustomerCode;
                    campaignTargetSet.CustomerSnm = campTrgtPrintResultWork.CustomerSnm;
                    campaignTargetSet.SalesAreaCode = campTrgtPrintResultWork.SalesAreaCode;
                    campaignTargetSet.SalesAreaCodeName = campTrgtPrintResultWork.SalesAreaName;

                    campaignTargetSet.SalesTargetMoney1 = campTrgtPrintResultWork.SalesTargetMoney1;
                    campaignTargetSet.SalesTargetMoney2 = campTrgtPrintResultWork.SalesTargetMoney2;
                    campaignTargetSet.SalesTargetMoney3 = campTrgtPrintResultWork.SalesTargetMoney3;
                    campaignTargetSet.SalesTargetMoney4 = campTrgtPrintResultWork.SalesTargetMoney4;
                    campaignTargetSet.SalesTargetMoney5 = campTrgtPrintResultWork.SalesTargetMoney5;
                    campaignTargetSet.SalesTargetMoney6 = campTrgtPrintResultWork.SalesTargetMoney6;
                    campaignTargetSet.SalesTargetMoney7 = campTrgtPrintResultWork.SalesTargetMoney7;
                    campaignTargetSet.SalesTargetMoney8 = campTrgtPrintResultWork.SalesTargetMoney8;
                    campaignTargetSet.SalesTargetMoney9 = campTrgtPrintResultWork.SalesTargetMoney9;
                    campaignTargetSet.SalesTargetMoney10 = campTrgtPrintResultWork.SalesTargetMoney10;
                    campaignTargetSet.SalesTargetMoney11 = campTrgtPrintResultWork.SalesTargetMoney11;
                    campaignTargetSet.SalesTargetMoney12 = campTrgtPrintResultWork.SalesTargetMoney12;
                    campaignTargetSet.MonthlySalesTarget = campTrgtPrintResultWork.MonthlySalesTarget;
                    campaignTargetSet.TermSalesTarget = campTrgtPrintResultWork.TermSalesTarget;

                    campaignTargetSet.SalesTargetProfit1 = campTrgtPrintResultWork.SalesTargetProfit1;
                    campaignTargetSet.SalesTargetProfit2 = campTrgtPrintResultWork.SalesTargetProfit2;
                    campaignTargetSet.SalesTargetProfit3 = campTrgtPrintResultWork.SalesTargetProfit3;
                    campaignTargetSet.SalesTargetProfit4 = campTrgtPrintResultWork.SalesTargetProfit4;
                    campaignTargetSet.SalesTargetProfit5 = campTrgtPrintResultWork.SalesTargetProfit5;
                    campaignTargetSet.SalesTargetProfit6 = campTrgtPrintResultWork.SalesTargetProfit6;
                    campaignTargetSet.SalesTargetProfit7 = campTrgtPrintResultWork.SalesTargetProfit7;
                    campaignTargetSet.SalesTargetProfit8 = campTrgtPrintResultWork.SalesTargetProfit8;
                    campaignTargetSet.SalesTargetProfit9 = campTrgtPrintResultWork.SalesTargetProfit9;
                    campaignTargetSet.SalesTargetProfit10 = campTrgtPrintResultWork.SalesTargetProfit10;
                    campaignTargetSet.SalesTargetProfit11 = campTrgtPrintResultWork.SalesTargetProfit11;
                    campaignTargetSet.SalesTargetProfit12 = campTrgtPrintResultWork.SalesTargetProfit12;
                    campaignTargetSet.MonthlySalesTargetProfit = campTrgtPrintResultWork.MonthlySalesTargetProfit;
                    campaignTargetSet.TermSalesTargetProfit = campTrgtPrintResultWork.TermSalesTargetProfit;

                    campaignTargetSet.SalesTargetCount1 = campTrgtPrintResultWork.SalesTargetCount1;
                    campaignTargetSet.SalesTargetCount2 = campTrgtPrintResultWork.SalesTargetCount2;
                    campaignTargetSet.SalesTargetCount3 = campTrgtPrintResultWork.SalesTargetCount3;
                    campaignTargetSet.SalesTargetCount4 = campTrgtPrintResultWork.SalesTargetCount4;
                    campaignTargetSet.SalesTargetCount5 = campTrgtPrintResultWork.SalesTargetCount5;
                    campaignTargetSet.SalesTargetCount6 = campTrgtPrintResultWork.SalesTargetCount6;
                    campaignTargetSet.SalesTargetCount7 = campTrgtPrintResultWork.SalesTargetCount7;
                    campaignTargetSet.SalesTargetCount8 = campTrgtPrintResultWork.SalesTargetCount8;
                    campaignTargetSet.SalesTargetCount9 = campTrgtPrintResultWork.SalesTargetCount9;
                    campaignTargetSet.SalesTargetCount10 = campTrgtPrintResultWork.SalesTargetCount10;
                    campaignTargetSet.SalesTargetCount11 = campTrgtPrintResultWork.SalesTargetCount11;
                    campaignTargetSet.SalesTargetCount12 = campTrgtPrintResultWork.SalesTargetCount12;
                    campaignTargetSet.MonthlySalesTargetCount = campTrgtPrintResultWork.MonthlySalesTargetCount;
                    campaignTargetSet.TermSalesTargetCount = campTrgtPrintResultWork.TermSalesTargetCount;

                    campaignTargetSet.ApplyStaDate = campTrgtPrintResultWork.ApplyStaDate;
                    campaignTargetSet.ApplyEndDate = campTrgtPrintResultWork.ApplyEndDate;
                    retList.Add(campaignTargetSet);
                }

            }

        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(CampTrgtPrintResultWork campTrgtPrintResultWork, CampaignTargetPrintWork campaignTargetPrintWork)
        {
            int status = 0;

            string upDateTime = campTrgtPrintResultWork.UpdateDateTime.Year.ToString("0000") +
                                campTrgtPrintResultWork.UpdateDateTime.Month.ToString("00") +
                                campTrgtPrintResultWork.UpdateDateTime.Day.ToString("00");

            if (campaignTargetPrintWork.LogicalDeleteCode == 1 &&
                campaignTargetPrintWork.DeleteDateTimeSt != 0 &&
                campaignTargetPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < campaignTargetPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > campaignTargetPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (campaignTargetPrintWork.LogicalDeleteCode == 1 &&
                        campaignTargetPrintWork.DeleteDateTimeSt != 0 &&
                        campaignTargetPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < campaignTargetPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (campaignTargetPrintWork.LogicalDeleteCode == 1 &&
                   campaignTargetPrintWork.DeleteDateTimeSt == 0 &&
                   campaignTargetPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > campaignTargetPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            return status;
        }

    }
}
