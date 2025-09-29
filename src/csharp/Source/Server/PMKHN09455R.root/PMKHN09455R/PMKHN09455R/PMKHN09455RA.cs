//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 目標自動設定
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/06/18  修正内容 : PVCS#203 実績の場合、集計数量と金額が3倍について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2009/07/07  修正内容 : PVCS#261 数量の端数処理方法不正 
//----------------------------------------------------------------------------//
// 管理番号  10801804-00  作成担当 : yangyi
// 修 正 日  2012/11/12   修正内容 : 2012/12/12配信分 
//                        redmine#33218  No.1633 目標自動設定 目標設定は不正がある 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using System.Collections.Generic;
using System.IO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 目標自動設定処理READDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 目標自動設定処理READの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.01</br>
    /// </remarks>
    [Serializable]
    public class ObjAutoSetControlDB : RemoteDB, IObjAutoSetControlDB
    {

        #region ■ Const Memebers ■
        private const Int32 kubun_Section = 1;
        private const Int32 kubun_SubSection = 2;
        private const Int32 kubun_Customer = 3;
        private const Int32 kubun_Tantosya = 4;
        private const Int32 kubun_ReceOrd = 5;
        private const Int32 kubun_Publisher = 6;
        private const Int32 kubun_District = 7;
        private const Int32 kubun_TypeBusiness = 8;
        private const Int32 kubun_SalesCode = 9;
        private const Int32 kubun_ComDivision = 10;
        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// 目標自動設定処理READDBリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 目標自動設定処理READの実データ操作を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.01</br>
        /// </remarks>
        public ObjAutoSetControlDB()
        {
            this._empSalesTargetDB = new EmpSalesTargetDB();
            this._custSalesTargetDB = new CustSalesTargetDB();
            this._gcdSalesTargetDB = new GcdSalesTargetDB();
        }
        #endregion

        # region ■ Private Members ■
        EmpSalesTargetDB _empSalesTargetDB = null;
        CustSalesTargetDB _custSalesTargetDB = null;
        GcdSalesTargetDB _gcdSalesTargetDB = null;
        #endregion

        # region ■ 目標自動設定更新処理 ■
        /// <summary>
        /// 目標自動設定更新処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="pastStartMonthDate">前期適用開始日</param>
        /// <param name="pastEndMonthDate">前期適用終了日</param>
        /// <param name="pastYearMonth">前期月次更新年月</param>
        /// <param name="nowStartMonthDate">今回適用開始日</param>
        /// <param name="nowEndMonthDate">今回適用終了日</param>
        /// <param name="nowYearMonth">今回月次更新年月</param>
        /// <param name="yearMonth">現在処理年月</param>
        /// <param name="objAutoSetWork">検索条件</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 目標自動設定更新処理</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.05.20</br>
        public int ObjAutoSetProc(string enterpriseCode, string baseCode, List<DateTime> pastStartMonthDate, List<DateTime> pastEndMonthDate, List<DateTime> pastYearMonth,
            List<DateTime> nowStartMonthDate, List<DateTime> nowEndMonthDate, List<DateTime> nowYearMonth, DateTime yearMonth, ObjAutoSetWork objAutoSetWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;

            DateTime startMonthDt = new DateTime();
            DateTime endMonthDt = new DateTime();
            Int32 startMonthInt;
            Int32 endMonthInt;

            // 過去*ヶ月
            Int32 pastMonth = objAutoSetWork.Past;


            // 対象期は前期の場合、
            if (objAutoSetWork.ObjPeriodDrp == 0)
            {
                Int32 pastYearMonthCount = pastYearMonth.Count;
                if (null != pastYearMonth && pastYearMonthCount > 0)
                {
                    startMonthDt = pastYearMonth[0];
                    endMonthDt = pastYearMonth[pastYearMonthCount - 1];

                    startMonthInt = this.DateTimeToInt(startMonthDt);
                    endMonthInt = this.DateTimeToInt(endMonthDt);
                }
                else
                {
                    return status;
                }
            }
            // 対象期は今期の場合、
            else
            {
                //Int32 nowYearMonthCount = nowYearMonth.Count;
                //if (null != nowYearMonth && nowYearMonthCount > 0)
                //{
                //    startMonthDt = nowYearMonth[0];
                //    endMonthDt = nowYearMonth[nowYearMonthCount - 1];

                //    startMonthInt = this.DateTimeToInt(startMonthDt);
                //    endMonthInt = this.DateTimeToInt(endMonthDt);
                //}
                //else
                //{
                //    return status;
                //}
                startMonthInt = this.DateTimeToInt(yearMonth.AddMonths(-pastMonth));
                endMonthInt = this.DateTimeToInt(yearMonth.AddMonths(-1));
            }

            // 前期会計年度より、今期会計年度取得
            Hashtable fiscalYear = new Hashtable();
            Hashtable fiscalStartMonth = new Hashtable();
            Hashtable fiscalEndMonth = new Hashtable();
            string fiscalYearKey = string.Empty;
            string fiscalYearValue = string.Empty;
            for ( int i = 0; i < pastYearMonth.Count; i++ )
            {
                fiscalYearKey = Convert.ToString(this.DateTimeToInt(pastYearMonth[i]));
                fiscalYearValue = Convert.ToString(this.DateTimeToInt(nowYearMonth[i]));
                fiscalYear.Add(fiscalYearKey, fiscalYearValue);
                fiscalStartMonth.Add(fiscalYearKey, nowStartMonthDate[i]);
                fiscalEndMonth.Add(fiscalYearKey, nowEndMonthDate[i]);
            }

            // UP率
            Int32 salesTarget = objAutoSetWork.SalesTarget;
            Int32 amountTarget = objAutoSetWork.AmountTarget;
            Int32 groMarginTarget = objAutoSetWork.GroMarginTarget;


            // 単位
            Int32 unit = objAutoSetWork.UnitDrp;
            // 端数処理
            Int32 fractionProc = objAutoSetWork.FractionProcDrp;
            // 対象期区分
            Int32 periodKun = objAutoSetWork.ObjPeriodDrp;


            //--------------------------
            // データベースオープン
            //--------------------------
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            SqlCommand sqlCommand = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string _connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
                if (_connectionText == null || _connectionText == "")
                {
                    return status;
                }

                sqlConnection = new SqlConnection(_connectionText);
                sqlConnection.Open();



#if DEBUG
                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif


                sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);


                // トランザクション
                sqlCommand.Transaction = sqlTransaction;
                // 拠点DRP選択の場合、
                // 拠点が行うの場合、
                if (objAutoSetWork.SecDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // 対象金額が「実績」の場合
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // 売上月次集計データを抽出する
                        status = GetSectionMTtList(baseCode, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // 対象金額が「目標」の場合
                    else
                    {
                        // 従業員別売上目標設定マスタのデータを抽出する
                        status = GetSectionEmpList(baseCode, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);

                            // 拠点目標(従業員別売上目標設定マスタに)削除する。
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 拠点目標(従業員別売上目標設定マスタに)更新
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach(ArrayList empList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 拠点目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 拠点目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // 得意先の目標から再設定の場合、
                else if (objAutoSetWork.SecDrp == 2)
                {
                    ArrayList allDataList = new ArrayList();
                    // 再設定の場合
                    // 従業員別売上目標設定マスタの得意先データを抽出する
                    status = GetMoreSecCustomerEmpList(baseCode, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(従業員別売上目標設定マスタに)更新
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Customer, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // 担当者の目標から再設定の場合、
                else if (objAutoSetWork.SecDrp == 3)
                {
                    ArrayList allDataList = new ArrayList();
                    // 再設定の場合
                    // 従業員別売上目標設定マスタの得意先データを抽出する
                    status = GetMoreSecTantosyaEmpList(baseCode, 10, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 担当者目標(従業員別売上目標設定マスタに)更新
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 担当者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 担当者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 担当者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    }

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        sqlTransaction.Rollback();
                        return status;
                    }
                }
                // 受注者の目標から再設定の場合、
                else if (objAutoSetWork.SecDrp == 4)
                {
                    ArrayList allDataList = new ArrayList();
                    // 再設定の場合
                    // 従業員別売上目標設定マスタの受注者データを抽出する
                    status = GetMoreSecTantosyaEmpList(baseCode, 20, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 受注者目標(従業員別売上目標設定マスタに)更新
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 受注者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 受注者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 受注者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    }

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        sqlTransaction.Rollback();
                        return status;
                    }
                }
                // 発行者の目標から再設定の場合、
                else if (objAutoSetWork.SecDrp == 5)
                {
                    ArrayList allDataList = new ArrayList();
                    // 再設定の場合、
                    // 従業員別売上目標設定マスタの受注者データを抽出する
                    status = GetMoreSecTantosyaEmpList(baseCode, 30, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 発行者目標(従業員別売上目標設定マスタに)更新
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 発行者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 発行者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 発行者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // 地区の目標から再設定の場合、
                else if (objAutoSetWork.SecDrp == 6)
                {
                    ArrayList allDataList = new ArrayList();
                    // 再設定の場合
                    // 従業員別売上目標設定マスタの受注者データを抽出する
                    status = GetMoreDistrictCusList(baseCode, 21, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 地区目標(従業員別売上目標設定マスタに)更新
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 地区目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 地区目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 地区目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // 業種の目標から再設定の場合、
                else if (objAutoSetWork.SecDrp == 7)
                {
                    ArrayList allDataList = new ArrayList();
                    // 再設定の場合、
                    // 得意先別売上目標設定マスタの受注者データを抽出する
                    status = GetMoreTypeBusinessCusList(baseCode, 33, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 業種目標(従業員別売上目標設定マスタに)更新
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 業種目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 業種目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 業種目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // 販売区分の目標から再設定の場合、
                else if (objAutoSetWork.SecDrp == 8)
                {
                    ArrayList allDataList = new ArrayList();
                    // 再設定の場合、
                    // 従業員別売上目標設定マスタの販売区分データを抽出する
                    status = GetMoreSalesDivisionGcdList(baseCode, 71, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 販売区分目標(商品別売上目標設定マスタに)更新
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 販売区分目標(商品別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 販売区分目標(商品別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Section, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 販売区分目標(商品別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // 得意先DRP選択の場合、
                // 得意先が行うの場合、
                if (objAutoSetWork.CustomerDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // 対象金額が「実績」の場合
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // 売上月次集計部門データを抽出する
                        status = GetCustomerMTtList(baseCode, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // 対象金額が「目標」の場合
                    else
                    {
                        // 得意先別売上目標設定マスタの得意先データを抽出する
                        status = GetCustomerCusList(baseCode, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList custSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_Customer, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(得意先別売上目標設定マスタに)更新
                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_Customer, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList custList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_Customer, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_Customer, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // 担当者DRP選択の場合、
                // 担当者が行うの場合、
                if (objAutoSetWork.TantosyaDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // 対象金額が「実績」の場合
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // 売上月次集計担当者データを抽出する
                        status = GetTantosyaMTtList(baseCode, enterpriseCode, 10, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // 対象金額が「目標」の場合
                    else
                    {
                        // 従業員別売上目標設定マスタの担当者データを抽出する
                        status = GetTantosyaEmpList(baseCode, 10, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Tantosya, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 担当者目標(従業員別売上目標設定マスタに)削除
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Tantosya, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 担当者目標(従業員別売上目標設定マスタに)削除
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Tantosya, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 担当者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Tantosya, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 担当者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // 担当者の得意先の目標から再設設定
                else if (objAutoSetWork.TantosyaDrp == 2)
                {
                    ArrayList allDataList = new ArrayList();
                    // 再設定の場合
                    // 従業員別売上目標設定マスタの得意先データを抽出する
                    status = GetMoreCustomerEmpList(baseCode, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Tantosya, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(従業員別売上目標設定マスタに)更新
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Tantosya, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Tantosya, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Tantosya, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // 受注者DRP選択の場合、
                // 受注者が行うの場合、
                if (objAutoSetWork.ReceOrdDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // 対象金額が「実績」の場合
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // 売上月次集計担当者データを抽出する
                        status = GetTantosyaMTtList(baseCode, enterpriseCode, 20, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // 対象金額が「目標」の場合
                    else
                    {
                        // 従業員別売上目標設定マスタの担当者データを抽出する
                        status = GetTantosyaEmpList(baseCode, 20, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_ReceOrd, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 担当者目標(従業員別売上目標設定マスタに)削除
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_ReceOrd, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 担当者目標(従業員別売上目標設定マスタに)削除
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_ReceOrd, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 担当者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_ReceOrd, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 担当者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // 発行者DRP選択の場合、
                // 発行者が行うの場合、
                if (objAutoSetWork.PublisherDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // 対象金額が「実績」の場合
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // 売上月次集計担当者データを抽出する
                        status = GetTantosyaMTtList(baseCode, enterpriseCode, 30, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // 対象金額が「目標」の場合
                    else
                    {
                        // 従業員別売上目標設定マスタの担当者データを抽出する
                        status = GetTantosyaEmpList(baseCode, 30, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList empSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Publisher, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 担当者目標(従業員別売上目標設定マスタに)削除
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Publisher, baseCode, enterpriseCode, empSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 担当者目標(従業員別売上目標設定マスタに)削除
                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList empList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageEmpDate(periodKun, pastMonth, kubun_Publisher, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 担当者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareEmpMonthDate(kubun_Publisher, baseCode, enterpriseCode, empList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 担当者目標(従業員別売上目標設定マスタに)更新

                            status = this.DeleteEmpSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _empSalesTargetDB.WriteEmpSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // 地区DRP選択の場合、
                // 地区が行うの場合、
                if (objAutoSetWork.DistrictDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // 対象金額が「実績」の場合
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // 売上月次集計部門データを抽出する
                        status = GetDistrictMTtList(baseCode, 21, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // 対象金額が「目標」の場合
                    else
                    {
                        // 得意先別売上目標設定マスタの得意先データを抽出する
                        status = GetDistrictDOCusList(baseCode, 21, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList custSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_District, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(得意先別売上目標設定マスタに)更新
                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_District, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList custList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_District, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_District, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // 地区の得意先の目標から再設定
                else if (objAutoSetWork.DistrictDrp == 2)
                {
                    ArrayList allDataList = new ArrayList();
                    // 再設定の場合
                    // 得意先別売上目標設定マスタの地区データを抽出する
                    status = GetDistrictCusList(baseCode, 21, 30, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList custSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_District, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(得意先別売上目標設定マスタに)更新
                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_District, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList custList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_District, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_District, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // 業種DRP選択の場合、
                // 業種が行うの場合、
                if (objAutoSetWork.TypeBusinessDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // 対象金額が「実績」の場合
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // 売上月次集計部門データを抽出する
                        status = GetTypeBusinessMTtList(baseCode, 33, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // 対象金額が「目標」の場合
                    else
                    {
                        // 得意先別売上目標設定マスタの得意先データを抽出する
                        // ユーザーガイドマスタ（業種）33 目標対比区分 31
                        status = GetTypeBusinessTBCusList(baseCode, 33, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList custSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_TypeBusiness, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(得意先別売上目標設定マスタに)更新
                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_TypeBusiness, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList custList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_TypeBusiness, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_TypeBusiness, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }
                // 業種の得意先の目標から再設定
                else if (objAutoSetWork.TypeBusinessDrp == 2)
                {
                    ArrayList allDataList = new ArrayList();
                    // 再設定の場合
                    // 得意先別売上目標設定マスタの得意先データを抽出する
                    status = GetTypeBusinessCusList(baseCode, 33, 30, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList custSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_TypeBusiness, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(得意先別売上目標設定マスタに)更新
                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_TypeBusiness, baseCode, enterpriseCode, custSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList custList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageCusDate(periodKun, pastMonth, kubun_TypeBusiness, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareCusMonthDate(kubun_TypeBusiness, baseCode, enterpriseCode, custList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteCustSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _custSalesTargetDB.WriteCustSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }

                // 販売区分DRP選択の場合、
                // 販売区分が行うの場合、
                if (objAutoSetWork.SalesDivisionDrp == 1)
                {
                    ArrayList allDataList = new ArrayList();
                    // 対象金額が「実績」の場合
                    if (objAutoSetWork.ObjMoneyDrp == 0)
                    {
                        // 売上月次集計部門データを抽出する  ユーザーガイドマスタ（販売区分） 71
                        status = GetSalesDivisionMTtList(baseCode, 71, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }
                    // 対象金額が「目標」の場合
                    else
                    {
                        // 得意先別売上目標設定マスタの得意先データを抽出する
                        status = GetSalesDivisionGcdList(baseCode, 71, enterpriseCode, startMonthInt, endMonthInt, ref sqlConnection, ref sqlTransaction, out allDataList);
                    }

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    // 全社の場合、今期データが削除する。
                    //if ("00".Equals(baseCode))
                    //{
                        ArrayList gcdSalesTargetList = new ArrayList();
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageGcdDate(periodKun, pastMonth, kubun_SalesCode, baseCode, enterpriseCode, gcdSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(得意先別売上目標設定マスタに)更新
                            status = this.DeleteGcdSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareGcdMonthDate(kubun_SalesCode, baseCode, enterpriseCode, gcdSalesTargetList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteGcdSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);
                        }
                    //}

                    // エラーの場合、返る
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                    foreach (ArrayList gcdList in allDataList)
                    {
                        // 比率の設定が「平均」の場合は月別の合計を計算し該当する月数で割る、端数処理の設定に従い計算する。
                        if (objAutoSetWork.RatioDrp == 0)
                        {
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.AverageGcdDate(periodKun, pastMonth, kubun_SalesCode, baseCode, enterpriseCode, gcdList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                nowStartMonthDate, nowEndMonthDate, nowYearMonth, out insertDataList, out delDataList);


                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteGcdSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _gcdSalesTargetDB.WriteGcdSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);

                        }
                        // 比率の設定が「同月比」の場合
                        else
                        {
                            ArrayList compareMonthDataList = new ArrayList();
                            ArrayList insertDataList = new ArrayList();
                            ArrayList delDataList = new ArrayList();
                            this.CompareGcdMonthDate(kubun_SalesCode, baseCode, enterpriseCode, gcdList, unit, fractionProc, salesTarget, amountTarget, groMarginTarget,
                                fiscalYear, fiscalStartMonth, fiscalEndMonth, nowYearMonth, out insertDataList, out delDataList);

                            // 得意先目標(得意先別売上目標設定マスタに)更新

                            status = this.DeleteGcdSalesTargetProc(delDataList, ref sqlConnection, ref sqlTransaction);

                            status = _gcdSalesTargetDB.WriteGcdSalesTargetProc(ref insertDataList, ref sqlConnection, ref sqlTransaction);
                        }

                        // エラーの場合、返る
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Rollback();
                            return status;
                        }
                    }
                }



                // エラーの場合、返る
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    sqlTransaction.Rollback();
                }
                else
                {
                    sqlTransaction.Commit();
                }

            }
            catch (SqlException ex)
            {
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "IOWriteMAHNBDB.Read(Connection付) Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion

        # region ■ 同月比と平均計算処理 ■
        /// <summary>
        /// 従業員別売上目標設定マスタの同月比処理
        /// </summary>
        /// <param name="kubun">処理区分</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="empSalesTargetList">従業員別データリスト</param>
        /// <param name="unit">端数処理の単位</param>
        /// <param name="fractionProc">端数処理区分</param>
        /// <param name="salesTarget">数量</param>
        /// <param name="amountTarget">売上目標</param>
        /// <param name="groMarginTarget">粗利目標</param>
        /// <param name="fiscalYear">会計年度</param>
        /// <param name="fiscalStartMonth">会計年度開始日</param>
        /// <param name="fiscalEndMonth">会計年度終了日</param>
        /// <param name="nowYearMonth">会計年度年月</param>
        /// <param name="compareMonthDataList">同月比データリスト</param>
        /// <param name="delDataList">削除データ</param>
        /// <remarks>
        /// <br>Note       : 従業員別売上目標設定マスタの同月比処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public void CompareEmpMonthDate(Int32 kubun, string baseCode, string enterpriseCode, ArrayList empSalesTargetList, Int32 unit, Int32 fractionProc, Int32 salesTarget,
            Int32 amountTarget, Int32 groMarginTarget, Hashtable fiscalYear, Hashtable fiscalStartMonth, Hashtable fiscalEndMonth,
            List<DateTime> nowYearMonth, out ArrayList compareMonthDataList, out ArrayList delDataList)
        {
            compareMonthDataList = new ArrayList();
            Int32 subSectionCode = 0;
            string employeeCode = string.Empty;
            double fractionUnit = 1;
            Int32 fractionProcess = 1;

            if (null != empSalesTargetList && empSalesTargetList.Count > 0)
            {
                double totalAmount = 0;
                double totalMoney = 0;
                double totalProfit = 0;

                Int32 empSalesTargetCount = empSalesTargetList.Count;

                for (int i = 0; i < empSalesTargetCount; i++)
                {
                    EmpSalesTargetWork empSalesTargetWork = (EmpSalesTargetWork)empSalesTargetList[i];
                    baseCode = empSalesTargetWork.SectionCode;
                    subSectionCode = empSalesTargetWork.SubSectionCode;
                    employeeCode = empSalesTargetWork.EmployeeCode;

                    totalAmount = empSalesTargetWork.SalesTargetCount;
                    totalMoney = (double)empSalesTargetWork.SalesTargetMoney;
                    totalProfit = (double)empSalesTargetWork.SalesTargetProfit;

                    // 単位
                    // 百円、
                    if (unit == 1)
                    {
                        fractionUnit = 100;
                    }
                    // 千円、
                    else if (unit == 2)
                    {
                        fractionUnit = 1000;
                    }
                    // 万円
                    else if (unit == 3)
                    {
                        fractionUnit = 10000;
                    }

                    // 端数処理
                    // 四捨五入
                    if (fractionProc == 0)
                    {
                        fractionProcess = 2;
                    }
                    // 切上
                    else if (fractionProc == 1)
                    {
                        fractionProcess = 3;
                    }
                    // 切捨
                    else
                    {
                        fractionProcess = 1;
                    }

                    // UP率処理
                    totalAmount = totalAmount * amountTarget / 100;
                    totalMoney = totalMoney * salesTarget / 100;
                    totalProfit = totalProfit * groMarginTarget / 100;

                    // MOD 2009/07/07 譚洪 --->>>
                    FractionCalculate.FracCalcMoney(totalAmount, 1, fractionProcess, out totalAmount);
                    // MOD 2009/07/07 譚洪 ---<<<
                    FractionCalculate.FracCalcMoney(totalMoney, fractionUnit, fractionProcess, out totalMoney);
                    FractionCalculate.FracCalcMoney(totalProfit, fractionUnit, fractionProcess, out totalProfit);

                    EmpSalesTargetWork compareMonthDataWork = new EmpSalesTargetWork();
                    // 企業コード
                    compareMonthDataWork.EnterpriseCode = enterpriseCode;
                    // 拠点コード
                    compareMonthDataWork.SectionCode = baseCode;
                    // 目標設定区分
                    compareMonthDataWork.TargetSetCd = 10;
                    // 目標対比区分
                    compareMonthDataWork.TargetContrastCd = 10;
                    // 目標区分コード
                    compareMonthDataWork.TargetDivideCode = Convert.ToString(fiscalYear[empSalesTargetWork.TargetDivideCode.Trim()]);
                    // 目標区分名称
                    compareMonthDataWork.TargetDivideName = string.Empty;
                    // 適用開始日
                    compareMonthDataWork.ApplyStaDate = (DateTime)fiscalStartMonth[empSalesTargetWork.TargetDivideCode.Trim()];
                    // 適用終了日
                    compareMonthDataWork.ApplyEndDate = (DateTime)fiscalEndMonth[empSalesTargetWork.TargetDivideCode.Trim()];
                    // 売上目標数量
                    compareMonthDataWork.SalesTargetCount = totalAmount;
                    // 売上目標金額
                    compareMonthDataWork.SalesTargetMoney = (long)totalMoney;
                    // 売上目標粗利額
                    compareMonthDataWork.SalesTargetProfit = (long)totalProfit;
                    // 拠点目標更新の場合、
                    if (kubun == kubun_Section)
                    {
                        // 目標対比区分
                        compareMonthDataWork.TargetContrastCd = 10;
                        // 部門コード
                        compareMonthDataWork.SubSectionCode = 0;
                        // 従業員区分
                        compareMonthDataWork.EmployeeDivCd = 0;
                        // 従業員コード
                        compareMonthDataWork.EmployeeCode = string.Empty;
                    }
                    // 部門目標更新の場合、
                    else if (kubun == kubun_SubSection)
                    {
                        // 目標対比区分
                        compareMonthDataWork.TargetContrastCd = 20;
                        // 部門コード
                        compareMonthDataWork.SubSectionCode = subSectionCode;
                        // 従業員区分
                        compareMonthDataWork.EmployeeDivCd = 0;
                        // 従業員コード
                        compareMonthDataWork.EmployeeCode = string.Empty;
                    }
                    // 担当者目標更新の場合、
                    else if (kubun == kubun_Tantosya)
                    {
                        // 目標対比区分
                        compareMonthDataWork.TargetContrastCd = 22;
                        // 部門コード
                        compareMonthDataWork.SubSectionCode = 0;
                        // 従業員区分
                        compareMonthDataWork.EmployeeDivCd = 10;
                        // 従業員コード
                        compareMonthDataWork.EmployeeCode = employeeCode;
                    }
                    // 受注者目標更新の場合、
                    else if (kubun == kubun_ReceOrd)
                    {
                        // 目標対比区分
                        compareMonthDataWork.TargetContrastCd = 22;
                        // 部門コード
                        compareMonthDataWork.SubSectionCode = 0;
                        // 従業員区分
                        compareMonthDataWork.EmployeeDivCd = 20;
                        // 従業員コード
                        compareMonthDataWork.EmployeeCode = employeeCode;
                    }
                    // 発行者目標更新の場合、
                    else if (kubun == kubun_Publisher)
                    {
                        // 目標対比区分
                        compareMonthDataWork.TargetContrastCd = 22;
                        // 部門コード
                        compareMonthDataWork.SubSectionCode = 0;
                        // 従業員区分
                        compareMonthDataWork.EmployeeDivCd = 30;
                        // 従業員コード
                        compareMonthDataWork.EmployeeCode = employeeCode;
                    }
                    compareMonthDataList.Add(compareMonthDataWork);
                }
            }

            // 削除用ワーク
            delDataList = new ArrayList();
            EmpSalesTargetWork delDataWork = null;
            Int32 nowYearMonthInt = 0;
            for (int i = 0; i < 12; i++)
            {
                delDataWork = new EmpSalesTargetWork();
                // 企業コード
                delDataWork.EnterpriseCode = enterpriseCode;
                // 拠点コード
                delDataWork.SectionCode = baseCode;
                // 目標設定区分
                delDataWork.TargetSetCd = 10;
                // 目標区分コード
                DateTime nowYearMonthDt = nowYearMonth[i];
                nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                delDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                // 拠点目標更新の場合、
                if (kubun == kubun_Section)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 10;
                    // 部門コード
                    delDataWork.SubSectionCode = 0;
                    // 従業員区分
                    delDataWork.EmployeeDivCd = 0;
                    // 従業員コード
                    delDataWork.EmployeeCode = string.Empty;
                }
                // 部門目標更新の場合、
                else if (kubun == kubun_SubSection)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 20;
                    // 部門コード
                    delDataWork.SubSectionCode = subSectionCode;
                    // 従業員区分
                    delDataWork.EmployeeDivCd = 0;
                    // 従業員コード
                    delDataWork.EmployeeCode = string.Empty;
                }
                // 担当者目標更新の場合、
                else if (kubun == kubun_Tantosya)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 22;
                    // 部門コード
                    delDataWork.SubSectionCode = 0;
                    // 従業員区分
                    delDataWork.EmployeeDivCd = 10;
                    // 従業員コード
                    delDataWork.EmployeeCode = employeeCode;
                }
                // 受注者目標更新の場合、
                else if (kubun == kubun_ReceOrd)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 22;
                    // 部門コード
                    delDataWork.SubSectionCode = 0;
                    // 従業員区分
                    delDataWork.EmployeeDivCd = 20;
                    // 従業員コード
                    delDataWork.EmployeeCode = employeeCode;
                }
                // 発行者目標更新の場合、
                else if (kubun == kubun_Publisher)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 22;
                    // 部門コード
                    delDataWork.SubSectionCode = 0;
                    // 従業員区分
                    delDataWork.EmployeeDivCd = 30;
                    // 従業員コード
                    delDataWork.EmployeeCode = employeeCode;
                }
                delDataList.Add(delDataWork);
            }
        }

        /// <summary>
        /// 従業員別売上目標設定マスタの平均処理
        /// </summary>
        /// <param name="periodKun">対象期区分</param>
        /// <param name="pastMonth">過去*ヶ月</param>
        /// <param name="kubun">処理区分</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="empSalesTargetList">従業員別データリスト</param>
        /// <param name="unit">端数処理の単位</param>
        /// <param name="fractionProc">端数処理区分</param>
        /// <param name="salesTarget">数量</param>
        /// <param name="amountTarget">売上目標</param>
        /// <param name="groMarginTarget">粗利目標</param>
        /// <param name="nowStartMonthDate">会計年度</param>
        /// <param name="nowEndMonthDate">会計年度開始日</param>
        /// <param name="nowYearMonth">会計年度年月</param>
        /// <param name="averageDataList">平均データリスト</param>
        /// <param name="delDataList">削除データ</param>
        /// <remarks>
        /// <br>Note       : 従業員別売上目標設定マスタの平均処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public void AverageEmpDate(Int32 periodKun, Int32 pastMonth, Int32 kubun, string baseCode, string enterpriseCode, ArrayList empSalesTargetList, Int32 unit, Int32 fractionProc, Int32 salesTarget,
            Int32 amountTarget, Int32 groMarginTarget, List<DateTime> nowStartMonthDate, List<DateTime> nowEndMonthDate,
            List<DateTime> nowYearMonth, out ArrayList averageDataList, out ArrayList delDataList)
        {
            averageDataList = new ArrayList();
            Int32 empSalesTargetCount = empSalesTargetList.Count;
            Int32 subSectionCode = 0;
            string employeeCode = string.Empty;
            Int32 nowYearMonthInt = 0;
            delDataList = new ArrayList();
            double fractionUnit = 1;
            Int32 fractionProcess = 1;

            if (null != empSalesTargetList && empSalesTargetCount > 0)
            {
                double totalAmount = 0;
                double totalMoney = 0;
                double totalProfit = 0;

                for (int i = 0; i < empSalesTargetCount; i++)
                {
                    EmpSalesTargetWork empSalesTargetWork = (EmpSalesTargetWork)empSalesTargetList[i];
                    baseCode = empSalesTargetWork.SectionCode;
                    subSectionCode = empSalesTargetWork.SubSectionCode;
                    employeeCode = empSalesTargetWork.EmployeeCode;

                    totalAmount = totalAmount + empSalesTargetWork.SalesTargetCount;
                    totalMoney = totalMoney + (double)empSalesTargetWork.SalesTargetMoney;
                    totalProfit = totalProfit + (double)empSalesTargetWork.SalesTargetProfit;
                }

                // 毎月に数量、金額、粗利を集計する
                // 前期
                if (0 == periodKun)
                {
                    totalAmount = totalAmount / 12;
                    totalMoney = totalMoney / 12;
                    totalProfit = totalProfit / 12;
                }
                else
                {
                    totalAmount = totalAmount / pastMonth;
                    totalMoney = totalMoney / pastMonth;
                    totalProfit = totalProfit / pastMonth;
                }

                // 単位
                // 百円、
                if (unit == 1)
                {
                    fractionUnit = 100;
                }
                // 千円、
                else if (unit == 2)
                {
                    fractionUnit = 1000;
                }
                // 万円
                else if (unit == 3)
                {
                    fractionUnit = 10000;
                }

                // 端数処理
                // 四捨五入
                if (fractionProc == 0)
                {
                    fractionProcess = 2;
                }
                // 切上
                else if (fractionProc == 1)
                {
                    fractionProcess = 3;
                }
                // 切捨
                else
                {
                    fractionProcess = 1;
                }

                // UP率処理
                totalAmount = totalAmount * amountTarget / 100;
                totalMoney = totalMoney * salesTarget / 100;
                totalProfit = totalProfit * groMarginTarget / 100;
                // MOD 2009/07/07 譚洪 --->>>
                FractionCalculate.FracCalcMoney(totalAmount, 1, fractionProcess, out totalAmount);
                // MOD 2009/07/07 譚洪 ---<<<
                FractionCalculate.FracCalcMoney(totalMoney, fractionUnit, fractionProcess, out totalMoney);
                FractionCalculate.FracCalcMoney(totalProfit, fractionUnit, fractionProcess, out totalProfit);

                // 登録ヘッダ情報
                EmpSalesTargetWork empSalesTargetInsertWork = new EmpSalesTargetWork();
                object objInsert = (object)this;
                IFileHeader insertIf = (IFileHeader)empSalesTargetInsertWork;
                FileHeader fileInsert = new FileHeader(objInsert);
                fileInsert.SetInsertHeader(ref insertIf, objInsert);

                for (int i = 0; i < 12; i++)
                {
                    EmpSalesTargetWork averageDataWork = new EmpSalesTargetWork();
                    // 企業コード
                    averageDataWork.EnterpriseCode = enterpriseCode;
                    // 拠点コード
                    averageDataWork.SectionCode = baseCode;
                    // 目標設定区分
                    averageDataWork.TargetSetCd = 10;
                    // 目標区分名称
                    averageDataWork.TargetDivideName = string.Empty;
                    // 目標区分コード
                    DateTime nowYearMonthDt = nowYearMonth[i];
                    nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                    averageDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                    // 適用開始日
                    DateTime nowStartMonthDt = nowStartMonthDate[i];
                    averageDataWork.ApplyStaDate = nowStartMonthDt;
                    // 適用終了日
                    DateTime nowEndMonthDt = nowEndMonthDate[i];
                    averageDataWork.ApplyEndDate = nowEndMonthDt;
                    // 売上目標数量
                    averageDataWork.SalesTargetCount = totalAmount;
                    // 売上目標金額
                    averageDataWork.SalesTargetMoney = (long)totalMoney;
                    // 売上目標粗利額
                    averageDataWork.SalesTargetProfit = (long)totalProfit;
                    // 拠点目標更新の場合、
                    if (kubun == kubun_Section)
                    {
                        // 目標対比区分
                        averageDataWork.TargetContrastCd = 10;
                        // 部門コード
                        averageDataWork.SubSectionCode = 0;
                        // 従業員区分
                        averageDataWork.EmployeeDivCd = 0;
                        // 従業員コード
                        averageDataWork.EmployeeCode = string.Empty;
                    }
                    // 担当者目標更新の場合、
                    else if (kubun == kubun_Tantosya)
                    {
                        // 目標対比区分
                        averageDataWork.TargetContrastCd = 22;
                        // 部門コード
                        averageDataWork.SubSectionCode = 0;
                        // 従業員区分
                        averageDataWork.EmployeeDivCd = 10;
                        // 従業員コード
                        averageDataWork.EmployeeCode = employeeCode;
                    }
                    // 受注者目標更新の場合、
                    else if (kubun == kubun_ReceOrd)
                    {
                        // 目標対比区分
                        averageDataWork.TargetContrastCd = 22;
                        // 部門コード
                        averageDataWork.SubSectionCode = 0;
                        // 従業員区分
                        averageDataWork.EmployeeDivCd = 20;
                        // 従業員コード
                        averageDataWork.EmployeeCode = employeeCode;
                    }
                    // 発行者目標更新の場合、
                    else if (kubun == kubun_Publisher)
                    {
                        // 目標対比区分
                        averageDataWork.TargetContrastCd = 22;
                        // 部門コード
                        averageDataWork.SubSectionCode = 0;
                        // 従業員区分
                        averageDataWork.EmployeeDivCd = 30;
                        // 従業員コード
                        averageDataWork.EmployeeCode = employeeCode;
                    }
                    averageDataList.Add(averageDataWork);
                }
            }

            for (int i = 0; i < 12; i++)
            {
                EmpSalesTargetWork delDataWork = new EmpSalesTargetWork();
                // 企業コード
                delDataWork.EnterpriseCode = enterpriseCode;
                // 拠点コード
                delDataWork.SectionCode = baseCode;
                // 目標設定区分
                delDataWork.TargetSetCd = 10;
                // 目標区分コード
                DateTime nowYearMonthDt = nowYearMonth[i];
                nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                delDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                // 拠点目標更新の場合、
                if (kubun == kubun_Section)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 10;
                    // 部門コード
                    delDataWork.SubSectionCode = 0;
                    // 従業員区分
                    delDataWork.EmployeeDivCd = 0;
                    // 従業員コード
                    delDataWork.EmployeeCode = string.Empty;
                }
                // 担当者目標更新の場合、
                else if (kubun == kubun_Tantosya)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 22;
                    // 部門コード
                    delDataWork.SubSectionCode = 0;
                    // 従業員区分
                    delDataWork.EmployeeDivCd = 10;
                    // 従業員コード
                    delDataWork.EmployeeCode = employeeCode;
                }
                // 受注者目標更新の場合、
                else if (kubun == kubun_ReceOrd)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 22;
                    // 部門コード
                    delDataWork.SubSectionCode = 0;
                    // 従業員区分
                    delDataWork.EmployeeDivCd = 20;
                    // 従業員コード
                    delDataWork.EmployeeCode = employeeCode;
                }
                // 発行者目標更新の場合、
                else if (kubun == kubun_Publisher)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 22;
                    // 部門コード
                    delDataWork.SubSectionCode = 0;
                    // 従業員区分
                    delDataWork.EmployeeDivCd = 30;
                    // 従業員コード
                    delDataWork.EmployeeCode = employeeCode;
                }
                delDataList.Add(delDataWork);
            }
        }

        /// <summary>
        /// 得意先別売上目標設定マスタの同月比処理
        /// </summary>
        /// <param name="kubun">処理区分</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="custSalesTargetList">得意先別データリスト</param>
        /// <param name="unit">端数処理の単位</param>
        /// <param name="fractionProc">端数処理区分</param>
        /// <param name="salesTarget">数量</param>
        /// <param name="amountTarget">売上目標</param>
        /// <param name="groMarginTarget">粗利目標</param>
        /// <param name="fiscalYear">会計年度</param>
        /// <param name="fiscalStartMonth">会計年度開始日</param>
        /// <param name="fiscalEndMonth">会計年度終了日</param>
        /// <param name="nowYearMonth">会計年度年月</param>
        /// <param name="compareMonthDataList">同月比データリスト</param>
        /// <param name="delDataList">削除データ</param>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタの同月比処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public void CompareCusMonthDate(Int32 kubun, string baseCode, string enterpriseCode, ArrayList custSalesTargetList, Int32 unit, Int32 fractionProc, Int32 salesTarget,
    Int32 amountTarget, Int32 groMarginTarget, Hashtable fiscalYear, Hashtable fiscalStartMonth, Hashtable fiscalEndMonth,
    List<DateTime> nowYearMonth, out ArrayList compareMonthDataList, out ArrayList delDataList)
        {
            compareMonthDataList = new ArrayList();

            Int32 customerCode = -1;
            Int32 salesAreaCode = -1;
            double fractionUnit = 1;
            Int32 fractionProcess = 1;
            Int32 typeBusiness = -1;

            if (null != custSalesTargetList && custSalesTargetList.Count > 0)
            {
                double totalAmount = 0;
                double totalMoney = 0;
                double totalProfit = 0;

                Int32 custSalesTargetCount = custSalesTargetList.Count;

                for (int i = 0; i < custSalesTargetCount; i++)
                {
                    CustSalesTargetWork custSalesTargetWork = (CustSalesTargetWork)custSalesTargetList[i];
                    baseCode = custSalesTargetWork.SectionCode;
                    customerCode = custSalesTargetWork.CustomerCode;
                    salesAreaCode = custSalesTargetWork.SalesAreaCode;
                    typeBusiness = custSalesTargetWork.BusinessTypeCode;

                    totalAmount = custSalesTargetWork.SalesTargetCount;
                    totalMoney = (double)custSalesTargetWork.SalesTargetMoney;
                    totalProfit = (double)custSalesTargetWork.SalesTargetProfit;

                    // 単位
                    // 百円、
                    if (unit == 1)
                    {
                        fractionUnit = 100;
                    }
                    // 千円、
                    else if (unit == 2)
                    {
                        fractionUnit = 1000;
                    }
                    // 万円
                    else if (unit == 3)
                    {
                        fractionUnit = 10000;
                    }

                    // 端数処理
                    // 四捨五入
                    if (fractionProc == 0)
                    {
                        fractionProcess = 2;
                    }
                    // 切上
                    else if (fractionProc == 1)
                    {
                        fractionProcess = 3;
                    }
                    // 切捨
                    else
                    {
                        fractionProcess = 1;
                    }

                    // UP率処理
                    totalAmount = totalAmount * amountTarget / 100;
                    totalMoney = totalMoney * salesTarget / 100;
                    totalProfit = totalProfit * groMarginTarget / 100;
                    // MOD 2009/07/07 譚洪 --->>>
                    FractionCalculate.FracCalcMoney(totalAmount, 1, fractionProcess, out totalAmount);
                    // MOD 2009/07/07 譚洪 ---<<<
                    FractionCalculate.FracCalcMoney(totalMoney, fractionUnit, fractionProcess, out totalMoney);
                    FractionCalculate.FracCalcMoney(totalProfit, fractionUnit, fractionProcess, out totalProfit);

                    CustSalesTargetWork compareMonthDataWork = new CustSalesTargetWork();
                    // 企業コード
                    compareMonthDataWork.EnterpriseCode = enterpriseCode;
                    // 拠点コード
                    compareMonthDataWork.SectionCode = baseCode;
                    // 目標設定区分
                    compareMonthDataWork.TargetSetCd = 10;
                    // 目標区分コード
                    compareMonthDataWork.TargetDivideCode = Convert.ToString(fiscalYear[custSalesTargetWork.TargetDivideCode.Trim()]);
                    // 目標区分名称
                    compareMonthDataWork.TargetDivideName = string.Empty;
                    // 業種コード
                    compareMonthDataWork.BusinessTypeCode = 0;
                    // 適用開始日
                    compareMonthDataWork.ApplyStaDate = (DateTime)fiscalStartMonth[custSalesTargetWork.TargetDivideCode.Trim()];
                    // 適用終了日
                    compareMonthDataWork.ApplyEndDate = (DateTime)fiscalEndMonth[custSalesTargetWork.TargetDivideCode.Trim()];
                    // 売上目標数量
                    compareMonthDataWork.SalesTargetCount = totalAmount;
                    // 売上目標金額
                    compareMonthDataWork.SalesTargetMoney = (long)totalMoney;
                    // 売上目標粗利額
                    compareMonthDataWork.SalesTargetProfit = (long)totalProfit;
                    // 得意先目標更新の場合、
                    if (kubun == kubun_Customer)
                    {
                        // 目標対比区分
                        compareMonthDataWork.TargetContrastCd = 30;
                        // 得意先コード
                        compareMonthDataWork.CustomerCode = customerCode;
                        // 販売エリアコード
                        compareMonthDataWork.SalesAreaCode = 0;
                    }
                    // 地区目標更新の場合、
                    else if (kubun == kubun_District)
                    {
                        // 目標対比区分
                        compareMonthDataWork.TargetContrastCd = 32;
                        // 得意先コード
                        compareMonthDataWork.CustomerCode = 0;
                        // 販売エリアコード
                        compareMonthDataWork.SalesAreaCode = salesAreaCode;
                    }
                    // 業種目標更新の場合、
                    else if (kubun == kubun_TypeBusiness)
                    {
                        // 目標対比区分
                        compareMonthDataWork.TargetContrastCd = 31;
                        // 得意先コード
                        compareMonthDataWork.CustomerCode = 0;
                        // 販売エリアコード
                        compareMonthDataWork.SalesAreaCode = 0;
                        // 業種コード
                        compareMonthDataWork.BusinessTypeCode = typeBusiness;
                    }
                    compareMonthDataList.Add(compareMonthDataWork);
                }
            }

            // 削除用ワーク
            delDataList = new ArrayList();
            CustSalesTargetWork delDataWork = null;
            Int32 nowYearMonthInt = 0;
            for (int i = 0; i < 12; i++)
            {
                delDataWork = new CustSalesTargetWork();
                // 企業コード
                delDataWork.EnterpriseCode = enterpriseCode;
                // 拠点コード
                delDataWork.SectionCode = baseCode;
                // 目標設定区分
                delDataWork.TargetSetCd = 10;
                // 目標区分コード
                DateTime nowYearMonthDt = nowYearMonth[i];
                nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                delDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                // 業種コード
                delDataWork.BusinessTypeCode = 0;
                // 得意先目標更新の場合、
                if (kubun == kubun_Customer)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 30;
                    // 得意先コード
                    delDataWork.CustomerCode = customerCode;
                    // 販売エリアコード
                    delDataWork.SalesAreaCode = 0;
                }
                // 地区目標更新の場合、
                else if (kubun == kubun_District)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 32;
                    // 得意先コード
                    delDataWork.CustomerCode = 0;
                    // 販売エリアコード
                    delDataWork.SalesAreaCode = salesAreaCode;
                }
                // 業種目標更新の場合、
                else if (kubun == kubun_TypeBusiness)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 31;
                    // 得意先コード
                    delDataWork.CustomerCode = 0;
                    // 販売エリアコード
                    delDataWork.SalesAreaCode = 0;
                    // 業種コード
                    delDataWork.BusinessTypeCode = typeBusiness;
                }
                delDataList.Add(delDataWork);
            }
        }

        /// <summary>
        /// 得意先別売上目標設定マスタの平均処理
        /// </summary>
        /// <param name="periodKun">対象期区分</param>
        /// <param name="pastMonth">過去*ヶ月</param>
        /// <param name="kubun">処理区分</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="custSalesTargetList">得意先別データリスト</param>
        /// <param name="unit">端数処理の単位</param>
        /// <param name="fractionProc">端数処理区分</param>
        /// <param name="salesTarget">数量</param>
        /// <param name="amountTarget">売上目標</param>
        /// <param name="groMarginTarget">粗利目標</param>
        /// <param name="nowStartMonthDate">会計年度</param>
        /// <param name="nowEndMonthDate">会計年度開始日</param>
        /// <param name="nowYearMonth">会計年度年月</param>
        /// <param name="averageDataList">平均データリスト</param>
        /// <param name="delDataList">削除データ</param>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタの平均処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public void AverageCusDate(Int32 periodKun, Int32 pastMonth, Int32 kubun, string baseCode, string enterpriseCode, ArrayList custSalesTargetList, Int32 unit, Int32 fractionProc, Int32 salesTarget,
            Int32 amountTarget, Int32 groMarginTarget, List<DateTime> nowStartMonthDate, List<DateTime> nowEndMonthDate,
            List<DateTime> nowYearMonth, out ArrayList averageDataList, out ArrayList delDataList)
        {
            averageDataList = new ArrayList();
            Int32 custSalesTargetCount = custSalesTargetList.Count;
            Int32 customerCode = -1;
            Int32 salesAreaCode = -1;
            Int32 typeBusiness = -1;
            Int32 nowYearMonthInt = 0;
            delDataList = new ArrayList();
            double fractionUnit = 1;
            Int32 fractionProcess = 1;


            if (null != custSalesTargetList && custSalesTargetCount > 0)
            {
                double totalAmount = 0;
                double totalMoney = 0;
                double totalProfit = 0;

                for (int i = 0; i < custSalesTargetCount; i++)
                {
                    CustSalesTargetWork custSalesTargetWork = (CustSalesTargetWork)custSalesTargetList[i];
                    baseCode = custSalesTargetWork.SectionCode;
                    customerCode = custSalesTargetWork.CustomerCode;
                    salesAreaCode = custSalesTargetWork.SalesAreaCode;
                    typeBusiness = custSalesTargetWork.BusinessTypeCode;

                    totalAmount = totalAmount + custSalesTargetWork.SalesTargetCount;
                    totalMoney = totalMoney + (double)custSalesTargetWork.SalesTargetMoney;
                    totalProfit = totalProfit + (double)custSalesTargetWork.SalesTargetProfit;
                }

                // 毎月に数量、金額、粗利を集計する
                // 前期
                if (0 == periodKun)
                {
                    totalAmount = totalAmount / 12;
                    totalMoney = totalMoney / 12;
                    totalProfit = totalProfit / 12;
                }
                // 今期
                else
                {
                    totalAmount = totalAmount / pastMonth;
                    totalMoney = totalMoney / pastMonth;
                    totalProfit = totalProfit / pastMonth;
                }


                // 単位
                // 百円、
                if (unit == 1)
                {
                    fractionUnit = 100;
                }
                // 千円、
                else if (unit == 2)
                {
                     fractionUnit = 1000;
                }
                // 万円
                else if (unit == 3)
                {
                     fractionUnit = 10000;
                }

                // 端数処理
                // 四捨五入
                if (fractionProc == 0)
                {
                    fractionProcess = 2;
                }
                // 切上
                else if (fractionProc == 1)
                {
                    fractionProcess = 3;
                }
                // 切捨
                else
                {
                    fractionProcess = 1;
                }

                // UP率処理
                totalAmount = totalAmount * amountTarget / 100;
                totalMoney = totalMoney * salesTarget / 100;
                totalProfit = totalProfit * groMarginTarget / 100;

                // MOD 2009/07/07 譚洪 --->>>
                FractionCalculate.FracCalcMoney(totalAmount, 1, fractionProcess, out totalAmount);
                // MOD 2009/07/07 譚洪 ---<<<
                FractionCalculate.FracCalcMoney(totalMoney, fractionUnit, fractionProcess, out totalMoney);
                FractionCalculate.FracCalcMoney(totalProfit, fractionUnit, fractionProcess, out totalProfit);

                for (int i = 0; i < 12; i++)
                {
                    CustSalesTargetWork averageDataWork = new CustSalesTargetWork();
                    // 企業コード
                    averageDataWork.EnterpriseCode = enterpriseCode;
                    // 拠点コード
                    averageDataWork.SectionCode = baseCode;
                    // 目標設定区分
                    averageDataWork.TargetSetCd = 10;
                    // 目標区分名称
                    averageDataWork.TargetDivideName = string.Empty;
                    // 目標区分コード
                    DateTime nowYearMonthDt = nowYearMonth[i];
                    nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                    averageDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                    // 適用開始日
                    DateTime nowStartMonthDt = nowStartMonthDate[i];
                    averageDataWork.ApplyStaDate = nowStartMonthDt;
                    // 適用終了日
                    DateTime nowEndMonthDt = nowEndMonthDate[i];
                    averageDataWork.ApplyEndDate = nowEndMonthDt;
                    // 売上目標数量
                    averageDataWork.SalesTargetCount = (double)totalAmount;
                    // 売上目標金額
                    averageDataWork.SalesTargetMoney = (long)totalMoney;
                    // 売上目標粗利額
                    averageDataWork.SalesTargetProfit = (long)totalProfit;
                    // 得意先目標更新の場合、
                    if (kubun == kubun_Customer)
                    {
                        // 目標対比区分
                        averageDataWork.TargetContrastCd = 30;
                        // 得意先コード
                        averageDataWork.CustomerCode = customerCode;
                        // 販売エリアコード
                        averageDataWork.SalesAreaCode = 0;
                        // 業種コード
                        averageDataWork.BusinessTypeCode = 0;
                    }
                    // 地区目標更新の場合、
                    else if (kubun == kubun_District)
                    {
                        // 目標対比区分
                        averageDataWork.TargetContrastCd = 32;
                        // 得意先コード
                        averageDataWork.CustomerCode = 0;
                        // 販売エリアコード
                        averageDataWork.SalesAreaCode = salesAreaCode;
                        // 業種コード
                        averageDataWork.BusinessTypeCode = 0;
                    }
                    // 業種目標更新の場合、
                    else if (kubun == kubun_TypeBusiness)
                    {
                        // 目標対比区分
                        averageDataWork.TargetContrastCd = 31;
                        // 得意先コード
                        averageDataWork.CustomerCode = 0;
                        // 販売エリアコード
                        averageDataWork.SalesAreaCode = 0;
                        // 業種コード
                        averageDataWork.BusinessTypeCode = typeBusiness;
                    }

                    averageDataList.Add(averageDataWork);
                }
            }

            for (int i = 0; i < 12; i++)
            {
                CustSalesTargetWork delDataWork = new CustSalesTargetWork();
                // 企業コード
                delDataWork.EnterpriseCode = enterpriseCode;
                // 拠点コード
                delDataWork.SectionCode = baseCode;
                // 目標設定区分
                delDataWork.TargetSetCd = 10;
                // 目標区分コード
                DateTime nowYearMonthDt = nowYearMonth[i];
                nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                delDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                // 得意先目標更新の場合、
                if (kubun == kubun_Customer)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 30;
                    // 得意先コード
                    delDataWork.CustomerCode = customerCode;
                    // 販売エリアコード
                    delDataWork.SalesAreaCode = 0;
                    // 業種コード
                    delDataWork.BusinessTypeCode = 0;
                }
                // 地区目標更新の場合、
                else if (kubun == kubun_District)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 32;
                    // 得意先コード
                    delDataWork.CustomerCode = 0;
                    // 販売エリアコード
                    delDataWork.SalesAreaCode = salesAreaCode;
                    // 業種コード
                    delDataWork.BusinessTypeCode = 0;
                }
                // 業種目標更新の場合、
                else if (kubun == kubun_TypeBusiness)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 31;
                    // 得意先コード
                    delDataWork.CustomerCode = 0;
                    // 販売エリアコード
                    delDataWork.SalesAreaCode = 0;
                    // 業種コード
                    delDataWork.BusinessTypeCode = typeBusiness;
                }
                delDataList.Add(delDataWork);
            }
        }

        /// <summary>
        /// 商品別売上目標設定マスタの同月比処理
        /// </summary>
        /// <param name="kubun">処理区分</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="gcdSalesTargetList">商品別データリスト</param>
        /// <param name="unit">端数処理の単位</param>
        /// <param name="fractionProc">端数処理区分</param>
        /// <param name="salesTarget">数量</param>
        /// <param name="amountTarget">売上目標</param>
        /// <param name="groMarginTarget">粗利目標</param>
        /// <param name="fiscalYear">会計年度</param>
        /// <param name="fiscalStartMonth">会計年度開始日</param>
        /// <param name="fiscalEndMonth">会計年度終了日</param>
        /// <param name="nowYearMonth">会計年度年月</param>
        /// <param name="compareMonthDataList">同月比データリスト</param>
        /// <param name="delDataList">削除データ</param>
        /// <remarks>
        /// <br>Note       : 商品別売上目標設定マスタの同月比処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public void CompareGcdMonthDate(Int32 kubun, string baseCode, string enterpriseCode, ArrayList gcdSalesTargetList, Int32 unit, Int32 fractionProc, Int32 salesTarget,
Int32 amountTarget, Int32 groMarginTarget, Hashtable fiscalYear, Hashtable fiscalStartMonth, Hashtable fiscalEndMonth,
List<DateTime> nowYearMonth, out ArrayList compareMonthDataList, out ArrayList delDataList)
        {
            compareMonthDataList = new ArrayList();

            Int32 salesCode = -1;
            double fractionUnit = 1;
            Int32 fractionProcess = 1;

            if (null != gcdSalesTargetList && gcdSalesTargetList.Count > 0)
            {
                double totalAmount = 0;
                double totalMoney = 0;
                double totalProfit = 0;

                Int32 gcdSalesTargetCount = gcdSalesTargetList.Count;

                for (int i = 0; i < gcdSalesTargetCount; i++)
                {
                    GcdSalesTargetWork gcdSalesTargetWork = (GcdSalesTargetWork)gcdSalesTargetList[i];
                    baseCode = gcdSalesTargetWork.SectionCode;
                    salesCode = gcdSalesTargetWork.SalesCode;

                    totalAmount = gcdSalesTargetWork.SalesTargetCount;
                    totalMoney = (double)gcdSalesTargetWork.SalesTargetMoney;
                    totalProfit = (double)gcdSalesTargetWork.SalesTargetProfit;

                    // 単位
                    // 百円、
                    if (unit == 1)
                    {
                        fractionUnit = 100;
                    }
                    // 千円、
                    else if (unit == 2)
                    {
                        fractionUnit = 1000;
                    }
                    // 万円
                    else if (unit == 3)
                    {
                        fractionUnit = 10000;
                    }

                    // 端数処理
                    // 四捨五入
                    if (fractionProc == 0)
                    {
                        fractionProcess = 2;
                    }
                    // 切上
                    else if (fractionProc == 1)
                    {
                        fractionProcess = 3;
                    }
                    // 切捨
                    else
                    {
                        fractionProcess = 1;
                    }

                    // UP率処理
                    totalAmount = totalAmount * amountTarget / 100;
                    totalMoney = totalMoney * salesTarget / 100;
                    totalProfit = totalProfit * groMarginTarget / 100;

                    // MOD 2009/07/07 譚洪 --->>>
                    FractionCalculate.FracCalcMoney(totalAmount, 1, fractionProcess, out totalAmount);
                    // MOD 2009/07/07 譚洪 ---<<<
                    FractionCalculate.FracCalcMoney(totalMoney, fractionUnit, fractionProcess, out totalMoney);
                    FractionCalculate.FracCalcMoney(totalProfit, fractionUnit, fractionProcess, out totalProfit);

                    GcdSalesTargetWork compareMonthDataWork = new GcdSalesTargetWork();
                    // 企業コード
                    compareMonthDataWork.EnterpriseCode = enterpriseCode;
                    // 拠点コード
                    compareMonthDataWork.SectionCode = baseCode;
                    // 目標設定区分
                    compareMonthDataWork.TargetSetCd = 10;
                    // 目標対比区分
                    compareMonthDataWork.TargetContrastCd = 30;
                    // 目標区分コード
                    compareMonthDataWork.TargetDivideCode = Convert.ToString(fiscalYear[gcdSalesTargetWork.TargetDivideCode.Trim()]);
                    // 目標区分名称
                    compareMonthDataWork.TargetDivideName = string.Empty;
                    // 商品メーカーコード
                    compareMonthDataWork.GoodsMakerCd = 0;
                    // 商品番号
                    compareMonthDataWork.GoodsNo = string.Empty;
                    // BLグループコード
                    compareMonthDataWork.BLGroupCode = 0;
                    // BL商品コード
                    compareMonthDataWork.BLGoodsCode = 0;
                    // 自社分類コード
                    compareMonthDataWork.EnterpriseGanreCode = 0;
                    // 適用開始日
                    compareMonthDataWork.ApplyStaDate = (DateTime)fiscalStartMonth[gcdSalesTargetWork.TargetDivideCode.Trim()];
                    // 適用終了日
                    compareMonthDataWork.ApplyEndDate = (DateTime)fiscalEndMonth[gcdSalesTargetWork.TargetDivideCode.Trim()];
                    // 売上目標数量
                    compareMonthDataWork.SalesTargetCount = (double)totalAmount;
                    // 売上目標金額
                    compareMonthDataWork.SalesTargetMoney = (long)totalMoney;
                    // 売上目標粗利額
                    compareMonthDataWork.SalesTargetProfit = (long)totalProfit;
                    // 販売区分目標更新の場合、
                    if (kubun == kubun_SalesCode)
                    {
                        // 目標対比区分
                        compareMonthDataWork.TargetContrastCd = 44;
                        // 販売区分コード
                        compareMonthDataWork.SalesCode = salesCode;
                    }

                    compareMonthDataList.Add(compareMonthDataWork);
                }
            }

            // 削除用ワーク
            delDataList = new ArrayList();
            GcdSalesTargetWork delDataWork = null;
            Int32 nowYearMonthInt = 0;
            for (int i = 0; i < 12; i++)
            {
                delDataWork = new GcdSalesTargetWork();
                // 企業コード
                delDataWork.EnterpriseCode = enterpriseCode;
                // 拠点コード
                delDataWork.SectionCode = baseCode;
                // 目標設定区分
                delDataWork.TargetSetCd = 10;
                // 目標対比区分
                delDataWork.TargetContrastCd = 30;
                // 目標区分コード
                DateTime nowYearMonthDt = nowYearMonth[i];
                nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                delDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                // 商品メーカーコード
                delDataWork.GoodsMakerCd = 0;
                // 商品番号
                delDataWork.GoodsNo = string.Empty;
                // BLグループコード
                delDataWork.BLGroupCode = 0;
                // BL商品コード
                delDataWork.BLGoodsCode = 0;
                // 自社分類コード
                delDataWork.EnterpriseGanreCode = 0;
                // 販売区分目標更新の場合、
                if (kubun == kubun_SalesCode)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 44;
                    // 販売区分コード
                    delDataWork.SalesCode = salesCode;
                }
                delDataList.Add(delDataWork);
            }
        }

        /// <summary>
        /// 商品別売上目標設定マスタの平均処理
        /// </summary>
        /// <param name="periodKun">対象期区分</param>
        /// <param name="pastMonth">過去*ヶ月</param>
        /// <param name="kubun">処理区分</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="gcdSalesTargetList">商品別データリスト</param>
        /// <param name="unit">端数処理の単位</param>
        /// <param name="fractionProc">端数処理区分</param>
        /// <param name="salesTarget">数量</param>
        /// <param name="amountTarget">売上目標</param>
        /// <param name="groMarginTarget">粗利目標</param>
        /// <param name="nowStartMonthDate">会計年度</param>
        /// <param name="nowEndMonthDate">会計年度開始日</param>
        /// <param name="nowYearMonth">会計年度年月</param>
        /// <param name="averageDataList">平均データリスト</param>
        /// <param name="delDataList">削除データ</param>
        /// <remarks>
        /// <br>Note       : 商品別売上目標設定マスタの平均処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public void AverageGcdDate(Int32 periodKun, Int32 pastMonth, Int32 kubun, string baseCode, string enterpriseCode, ArrayList gcdSalesTargetList, Int32 unit, Int32 fractionProc, Int32 salesTarget,
            Int32 amountTarget, Int32 groMarginTarget, List<DateTime> nowStartMonthDate, List<DateTime> nowEndMonthDate,
            List<DateTime> nowYearMonth, out ArrayList averageDataList, out ArrayList delDataList)
        {
            averageDataList = new ArrayList();
            Int32 gcdSalesTargetCount = gcdSalesTargetList.Count;
            Int32 salesCode = -1;
            Int32 enterpriseGanreCode = 0;
            Int32 nowYearMonthInt = 0;
            double fractionUnit = 1;
            Int32 fractionProcess = 1;
            delDataList = new ArrayList();

            if (null != gcdSalesTargetList && gcdSalesTargetCount > 0)
            {
                double totalAmount = 0;
                double totalMoney = 0;
                double totalProfit = 0;

                for (int i = 0; i < gcdSalesTargetCount; i++)
                {
                    GcdSalesTargetWork gcdSalesTargetWork = (GcdSalesTargetWork)gcdSalesTargetList[i];
                    baseCode = gcdSalesTargetWork.SectionCode;
                    salesCode = gcdSalesTargetWork.SalesCode;
                    enterpriseGanreCode = gcdSalesTargetWork.EnterpriseGanreCode;

                    totalAmount = totalAmount + gcdSalesTargetWork.SalesTargetCount;
                    totalMoney = totalMoney + (double)gcdSalesTargetWork.SalesTargetMoney;
                    totalProfit = totalProfit + (double)gcdSalesTargetWork.SalesTargetProfit;
                }

                // 毎月に数量、金額、粗利を集計する
                // 前期
                if (0 == periodKun)
                {
                    totalAmount = totalAmount / 12;
                    totalMoney = totalMoney / 12;
                    totalProfit = totalProfit / 12;
                }
                else
                {
                    totalAmount = totalAmount / pastMonth;
                    totalMoney = totalMoney / pastMonth;
                    totalProfit = totalProfit / pastMonth;
                }


                // 単位
                // 百円、
                if (unit == 1)
                {
                    fractionUnit = 100;
                }
                // 千円、
                else if (unit == 2)
                {
                    fractionUnit = 1000;
                }
                // 万円
                else if (unit == 3)
                {
                    fractionUnit = 10000;
                }

                // 端数処理
                // 四捨五入
                if (fractionProc == 0)
                {
                    fractionProcess = 2;
                }
                // 切上
                else if (fractionProc == 1)
                {
                    fractionProcess = 3;
                }
                // 切捨
                else
                {
                    fractionProcess = 1;
                }

                // UP率処理
                totalAmount = totalAmount * amountTarget / 100;
                totalMoney = totalMoney * salesTarget / 100;
                totalProfit = totalProfit * groMarginTarget / 100;

                // MOD 2009/07/07 譚洪 --->>>
                FractionCalculate.FracCalcMoney(totalAmount, 1, fractionProcess, out totalAmount);
                // MOD 2009/07/07 譚洪 ---<<<
                FractionCalculate.FracCalcMoney(totalMoney, fractionUnit, fractionProcess, out totalMoney);
                FractionCalculate.FracCalcMoney(totalProfit, fractionUnit, fractionProcess, out totalProfit);

                for (int i = 0; i < 12; i++)
                {
                    GcdSalesTargetWork averageDataWork = new GcdSalesTargetWork();
                    // 企業コード
                    averageDataWork.EnterpriseCode = enterpriseCode;
                    // 拠点コード
                    averageDataWork.SectionCode = baseCode;
                    // 目標設定区分
                    averageDataWork.TargetSetCd = 10;
                    // 目標区分名称
                    averageDataWork.TargetDivideName = string.Empty;
                    // 目標区分コード
                    DateTime nowYearMonthDt = nowYearMonth[i];
                    nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                    averageDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                    // 商品メーカーコード
                    averageDataWork.GoodsMakerCd = 0;
                    // 商品番号
                    averageDataWork.GoodsNo = string.Empty;
                    // BLグループコード
                    averageDataWork.BLGroupCode = 0;
                    // BL商品コード
                    averageDataWork.BLGoodsCode = 0;
                    // 適用開始日
                    DateTime nowStartMonthDt = nowStartMonthDate[i];
                    averageDataWork.ApplyStaDate = nowStartMonthDt;
                    // 適用終了日
                    DateTime nowEndMonthDt = nowEndMonthDate[i];
                    averageDataWork.ApplyEndDate = nowEndMonthDt;
                    // 売上目標数量
                    averageDataWork.SalesTargetCount = totalAmount;
                    // 売上目標金額
                    averageDataWork.SalesTargetMoney = (long)totalMoney;
                    // 売上目標粗利額
                    averageDataWork.SalesTargetProfit = (long)totalProfit;
                    // 販売区分目標更新の場合、
                    if (kubun == kubun_SalesCode)
                    {
                        // 目標対比区分
                        averageDataWork.TargetContrastCd = 44;
                        // 販売区分コード
                        averageDataWork.SalesCode = salesCode;
                        // 自社分類コード
                        averageDataWork.EnterpriseGanreCode = 0;
                    }
                    // 商品区分目標更新の場合、
                    else if (kubun == kubun_ComDivision)
                    {
                        // 目標対比区分
                        averageDataWork.TargetContrastCd = 45;
                        // 販売区分コード
                        averageDataWork.SalesCode = 0;
                        // 自社分類コード
                        averageDataWork.EnterpriseGanreCode = enterpriseGanreCode;
                    }
                    averageDataList.Add(averageDataWork);
                }
            }

            for (int i = 0; i < 12; i++)
            {
                GcdSalesTargetWork delDataWork = new GcdSalesTargetWork();
                // 企業コード
                delDataWork.EnterpriseCode = enterpriseCode;
                // 拠点コード
                delDataWork.SectionCode = baseCode;
                // 目標設定区分
                delDataWork.TargetSetCd = 10;
                // 目標区分コード
                DateTime nowYearMonthDt = nowYearMonth[i];
                nowYearMonthInt = this.DateTimeToInt(nowYearMonthDt);
                delDataWork.TargetDivideCode = Convert.ToString(nowYearMonthInt);
                // 商品メーカーコード
                delDataWork.GoodsMakerCd = 0;
                // 商品番号
                delDataWork.GoodsNo = string.Empty;
                // BLグループコード
                delDataWork.BLGroupCode = 0;
                // BL商品コード
                delDataWork.BLGoodsCode = 0;
                // 販売区分目標更新の場合、
                if (kubun == kubun_SalesCode)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 44;
                    // 販売区分コード
                    delDataWork.SalesCode = salesCode;
                    // 自社分類コード
                    delDataWork.EnterpriseGanreCode = 0;
                }
                // 商品区分目標更新の場合、
                else if (kubun == kubun_ComDivision)
                {
                    // 目標対比区分
                    delDataWork.TargetContrastCd = 45;
                    // 販売区分コード
                    delDataWork.SalesCode = 0;
                    // 自社分類コード
                    delDataWork.EnterpriseGanreCode = enterpriseGanreCode;
                }
                delDataList.Add(delDataWork);
            }
        }


        /// <summary>
        /// DateTime⇒Int処理
        /// </summary>
        /// <param name="yearMonthDt">日期</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : DateTime⇒Int処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.14</br>
        /// </remarks>
        public Int32 DateTimeToInt(DateTime yearMonthDt)
        {
            string yearMonthStr = yearMonthDt.ToString("yyyyMMdd");
            //yearMonthStr = yearMonthStr.Replace("/", "");
            //yearMonthStr = yearMonthStr.Replace(":", "");
            yearMonthStr = yearMonthStr.Substring(0, 6);
            Int32 yearMonthInt = Convert.ToInt32(yearMonthStr);
            return yearMonthInt;
        }
        #endregion

        #region ■ 集計用データを検索処理 ■
        /// <summary>
        /// 売上月次集計データ検索処理（拠点）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上月次集計データ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2012/11/12 yangyi</br>
        /// <br>             redmine#31515 No.1633 目標自動設定 目標設定は不正がある</br>
        /// </remarks>
        private int GetSectionMTtList(string baseCode, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.ADDUPYEARMONTHRF, ");
                sb.Append(" A.ADDUPSECCODERF, ");
                sb.Append(" SUM(A.TOTALSALESCOUNTRF) AS SALESCOUNTRF, ");
                // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                sb.Append(" SUM(A.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF, ");
                sb.Append(" SUM(A.DISCOUNTPRICERF) AS DISCOUNTPRICERF, ");
                // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                sb.Append(" SUM(A.SALESMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.GROSSPROFITRF) AS PROFITRF ");
                sb.Append(" FROM MTTLSALESSLIPRF A, SECINFOSETRF B ");
                sb.Append(" WHERE ");
                sb.Append(" A.ADDUPYEARMONTHRF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.ADDUPYEARMONTHRF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.ADDUPSECCODERF = B.SECTIONCODERF ");
                // 実績集計区分
                sb.Append(" AND A.RSLTTTLDIVCDRF=@RSLTTTLDIVCD ");
                // ADD 2009/06/18 --->>>
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // ADD 2009/06/18 ---<<<

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.ADDUPSECCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.ADDUPYEARMONTHRF, A.ADDUPSECCODERF ");
                sb.Append(" ORDER BY A.ADDUPSECCODERF ");


                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 --->>>
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 ---<<<


                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                // ADD 2009/06/18 --->>>
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(10);
                // ADD 2009/06/18 ---<<<

                sqlCommand.CommandText = sb.ToString();

                //using (StreamWriter sw = new StreamWriter(@"C:\CopyFile.log"))
                //{
                //    sw.WriteLine(sb.ToString());
                //    sw.WriteLine(yearMonthEndInt);
                //    sw.WriteLine(yearMonthBegInt);
                //}

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                    long salesretgoodprice = 0;
                    long discount = 0;
                    // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        empSalesTargetWork.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        empSalesTargetWork.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        /// <summary>
        /// 得意先別売上目標設定マスタ検索処理（拠点）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetSectionEmpList(string baseCode, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM EMPSALESTARGETRF A, SECINFOSETRF B ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(10);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }
        /// <summary>
        /// 売上月次集計データ検索処理（得意先）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上月次集計データ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2012/11/12 yangyi</br>
        /// <br>             redmine#31515 No.1633 目標自動設定 目標設定は不正がある</br>
        /// </remarks>
        private int GetCustomerMTtList(string baseCode, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.ADDUPYEARMONTHRF, ");
                sb.Append(" A.ADDUPSECCODERF, ");
                sb.Append(" A.CUSTOMERCODERF, ");
                sb.Append(" SUM(A.TOTALSALESCOUNTRF) AS SALESCOUNTRF, ");
                // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                sb.Append(" SUM(A.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF, ");
                sb.Append(" SUM(A.DISCOUNTPRICERF) AS DISCOUNTPRICERF, ");
                // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                sb.Append(" SUM(A.SALESMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.GROSSPROFITRF) AS PROFITRF ");
                sb.Append(" FROM MTTLSALESSLIPRF A, CUSTOMERRF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.ADDUPYEARMONTHRF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.ADDUPYEARMONTHRF >= @BEGADDUPYEARMONTHRF ");
                // 企業コード
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                // 論理削除区分
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                // 実績集計区分
                sb.Append(" AND A.RSLTTTLDIVCDRF=@RSLTTTLDIVCD ");
                // 「管理拠点コード」と「得意先コード」が得意先マスタに未登録の場合は作成対象としません。
                sb.Append(" AND A.ADDUPSECCODERF + A.CUSTOMERCODERF = C.MNGSECTIONCODERF + C.CUSTOMERCODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                // ADD 2009/06/18 --->>>
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // ADD 2009/06/18 ---<<<

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.ADDUPSECCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.ADDUPYEARMONTHRF, A.ADDUPSECCODERF, A.CUSTOMERCODERF ");
                sb.Append(" ORDER BY A.ADDUPSECCODERF, A.CUSTOMERCODERF ");


                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                // ADD 2009/06/18 --->>>
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 ---<<<


                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // ADD 2009/06/18 --->>>
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(10);
                // ADD 2009/06/18 ---<<<

                sqlCommand.CommandText = sb.ToString(); ;

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string custmoerCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                    long salesretgoodprice = 0;
                    long discount = 0;
                    // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    custmoerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")).ToString();
                    compareKey = sectionCode.Trim() + custmoerCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        custSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + custmoerCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        custSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + custmoerCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 得意先別売上目標設定マスタ検索処理（得意先）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetCustomerCusList(string baseCode, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        A.CUSTOMERCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, CUSTOMERRF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                // 「管理拠点コード」と「得意先コード」が得意先マスタに未登録の場合は作成対象としません。
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF + A.CUSTOMERCODERF = C.MNGSECTIONCODERF + C.CUSTOMERCODERF ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, A.CUSTOMERCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, A.CUSTOMERCODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(30);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string customerCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    customerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF")).ToString();
                    compareKey = sectionCode.Trim() + customerCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + customerCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + customerCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 売上月次集計データ検索処理（担当者）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeDivCd">従業員区分</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上月次集計データ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2012/11/12 yangyi</br>
        /// <br>             redmine#33218 No.1633 目標自動設定 目標設定は不正がある</br>
        /// </remarks>
        private int GetTantosyaMTtList(string baseCode, string enterpriseCode, Int32 employeeDivCd, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.ADDUPYEARMONTHRF, ");
                sb.Append(" A.ADDUPSECCODERF, ");
                sb.Append(" A.EMPLOYEECODERF, ");
                sb.Append(" SUM(A.TOTALSALESCOUNTRF) AS SALESCOUNTRF, ");
                // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                sb.Append(" SUM(A.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF, ");
                sb.Append(" SUM(A.DISCOUNTPRICERF) AS DISCOUNTPRICERF, ");
                // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                sb.Append(" SUM(A.SALESMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.GROSSPROFITRF) AS PROFITRF ");
                sb.Append(" FROM MTTLSALESSLIPRF A, EMPLOYEERF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.ADDUPYEARMONTHRF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.ADDUPYEARMONTHRF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                // 売上月次集計データの「計上拠点コード・従業員コード」が従業員マスタの「所属拠点・従業員コード」と一致する場合のみ対象とする
                sb.Append(" AND A.ADDUPSECCODERF + A.EMPLOYEECODERF = C.BELONGSECTIONCODERF + C.EMPLOYEECODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                // 対象設定マスタが「担当者：行う」でかつ「実績」の場合、「１０」を対象とする
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // 実績集計区分
                sb.Append(" AND A.RSLTTTLDIVCDRF=@RSLTTTLDIVCD ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.ADDUPSECCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.ADDUPYEARMONTHRF, A.ADDUPSECCODERF, A.EMPLOYEECODERF ");
                sb.Append(" ORDER BY A.ADDUPSECCODERF, A.EMPLOYEECODERF ");


                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                SqlParameter findRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);


                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(employeeDivCd);
                findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sb.ToString(); ;

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string employeeCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                    long salesretgoodprice = 0;
                    long discount = 0;
                    // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    employeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    compareKey = sectionCode.Trim() + employeeCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        empSalesTargetWork.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        empSalesTargetList.Add(empSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + employeeCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        empSalesTargetWork.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        empSalesTargetList.Add(empSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + employeeCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 従業員別売上目標設定マスタ検索処理（担当者）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="employeeDivCd">従業員区分</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetTantosyaEmpList(string baseCode, Int32 employeeDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        A.EMPLOYEECODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM EMPSALESTARGETRF A, EMPLOYEERF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // 従業員別売上目標設定マスタの「拠点コード・従業員コード」が従業員マスタの「所属拠点・従業員コード」と一致する場合のみ対象とする
                sb.Append(" AND A.SECTIONCODERF + A.EMPLOYEECODERF = C.BELONGSECTIONCODERF + C.EMPLOYEECODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, A.EMPLOYEECODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, A.EMPLOYEECODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(22);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 10:担当者
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(employeeDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string employeeCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    employeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    compareKey = sectionCode.Trim() + employeeCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + employeeCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + employeeCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 売上月次集計データ検索処理（地区）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="userGuideDivCd">ユーザーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上月次集計データ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2012/11/12 yangyi</br>
        /// <br>             redmine#33218 No.1633 目標自動設定 目標設定は不正がある</br>
        /// </remarks>
        private int GetDistrictMTtList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.ADDUPYEARMONTHRF, ");
                sb.Append(" A.ADDUPSECCODERF, ");
                sb.Append(" C.SALESAREACODERF, ");
                sb.Append(" SUM(A.TOTALSALESCOUNTRF) AS SALESCOUNTRF, ");
                // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                sb.Append(" SUM(A.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF, ");
                sb.Append(" SUM(A.DISCOUNTPRICERF) AS DISCOUNTPRICERF, ");
                // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                sb.Append(" SUM(A.SALESMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.GROSSPROFITRF) AS PROFITRF ");
                sb.Append(" FROM MTTLSALESSLIPRF A, SECINFOSETRF B, CUSTOMERRF C, USERGDBDURF D ");
                sb.Append(" WHERE ");
                sb.Append(" A.ADDUPYEARMONTHRF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.ADDUPYEARMONTHRF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.ADDUPSECCODERF = B.SECTIONCODERF ");
                // 売上月次集計データの「計上拠点コード・得意先コード」と「管理拠点コード・得意先コード」が一致する
                sb.Append(" AND A.ADDUPSECCODERF + A.CUSTOMERCODERF = C.MNGSECTIONCODERF + C.CUSTOMERCODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND D.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND A.ENTERPRISECODERF = D.ENTERPRISECODERF ");
                sb.Append(" AND C.SALESAREACODERF = D.GUIDECODERF ");
                // 実績集計区分
                sb.Append(" AND A.RSLTTTLDIVCDRF=@RSLTTTLDIVCD ");
                // ADD 2009/06/18 --->>>
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // ADD 2009/06/18 ---<<<

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.ADDUPSECCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.ADDUPYEARMONTHRF, A.ADDUPSECCODERF, C.SALESAREACODERF ");
                sb.Append(" ORDER BY A.ADDUPSECCODERF, C.SALESAREACODERF ");


                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);
                SqlParameter findRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 --->>>
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 ---<<<


                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 販売エリアコード 21
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);
                findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                // ADD 2009/06/18 --->>>
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(10);
                // ADD 2009/06/18 ---<<<

                sqlCommand.CommandText = sb.ToString(); ;

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string salesAreaCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                    long salesretgoodprice = 0;
                    long discount = 0;
                    // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    salesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF")).ToString();
                    compareKey = sectionCode.Trim() + salesAreaCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        custSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesAreaCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        custSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesAreaCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 得意先別売上目標設定マスタ検索処理（地区）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="userGuideDivCd">ユーザーコード</param>
        /// <param name="targetContrastCd">目標コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetDistrictCusList(string baseCode, Int32 userGuideDivCd, Int32 targetContrastCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        D.SALESAREACODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C, CUSTOMERRF D ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                sb.Append(" AND D.LOGICALDELETECODERF=@DLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = D.SALESAREACODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");
                // 得意先別売上目標設定マスタの「拠点コード・得意先コード」と「管理拠点コード・得意先コード」が一致する
                sb.Append(" AND A.ENTERPRISECODERF = D.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF + A.CUSTOMERCODERF = D.MNGSECTIONCODERF + D.CUSTOMERCODERF ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, D.SALESAREACODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, D.SALESAREACODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findDLogicalDeleteCode = sqlCommand.Parameters.Add("@DLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(targetContrastCd);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findDLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 販売エリアコード 21
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string salesAreaCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    salesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF")).ToString();
                    compareKey = sectionCode.Trim() + salesAreaCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesAreaCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesAreaCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 売上月次集計データ検索処理（業種）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="userGuideDivCd">ユーザーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上月次集計データ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2012/11/12 yangyi</br>
        /// <br>             redmine#33218 No.1633 目標自動設定 目標設定は不正がある</br>
        /// </remarks>
        private int GetTypeBusinessMTtList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.ADDUPYEARMONTHRF, ");
                sb.Append(" A.ADDUPSECCODERF, ");
                sb.Append(" C.BUSINESSTYPECODERF, ");
                sb.Append(" SUM(A.TOTALSALESCOUNTRF) AS SALESCOUNTRF, ");
                // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                sb.Append(" SUM(A.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF, ");
                sb.Append(" SUM(A.DISCOUNTPRICERF) AS DISCOUNTPRICERF, ");
                // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                sb.Append(" SUM(A.SALESMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.GROSSPROFITRF) AS PROFITRF ");
                sb.Append(" FROM MTTLSALESSLIPRF A, SECINFOSETRF B, CUSTOMERRF C, USERGDBDURF D ");
                sb.Append(" WHERE ");
                sb.Append(" A.ADDUPYEARMONTHRF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.ADDUPYEARMONTHRF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                sb.Append(" AND D.LOGICALDELETECODERF=@DLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.ADDUPSECCODERF = B.SECTIONCODERF ");
                // 売上月次集計データの「計上拠点コード・得意先コード」と「管理拠点コード・得意先コード」が一致する
                sb.Append(" AND A.ADDUPSECCODERF + A.CUSTOMERCODERF = C.MNGSECTIONCODERF + C.CUSTOMERCODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND D.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND A.ENTERPRISECODERF = D.ENTERPRISECODERF ");
                sb.Append(" AND C.BUSINESSTYPECODERF = D.GUIDECODERF ");
                // 実績集計区分
                sb.Append(" AND A.RSLTTTLDIVCDRF=@RSLTTTLDIVCD ");
                // ADD 2009/06/18 --->>>
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // ADD 2009/06/18 ---<<<

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.ADDUPSECCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.ADDUPYEARMONTHRF, A.ADDUPSECCODERF, C.BUSINESSTYPECODERF ");
                sb.Append(" ORDER BY A.ADDUPSECCODERF, C.BUSINESSTYPECODERF ");


                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findDLogicalDeleteCode = sqlCommand.Parameters.Add("@DLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);
                SqlParameter findRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 --->>>
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 ---<<<


                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findDLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 業種コード 33
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);
                findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                // ADD 2009/06/18 --->>>
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(10);
                // ADD 2009/06/18 ---<<<

                sqlCommand.CommandText = sb.ToString(); ;

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string businessTypeCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                    long salesretgoodprice = 0;
                    long discount = 0;
                    // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    businessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF")).ToString();
                    compareKey = sectionCode.Trim() + businessTypeCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        custSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + businessTypeCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        custSalesTargetWork.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + businessTypeCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 得意先別売上目標設定マスタ検索処理（業種）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="userGuideDivCd">ユーザーコード</param>
        /// <param name="targetContrastCd">目標コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetTypeBusinessCusList(string baseCode, Int32 userGuideDivCd, Int32 targetContrastCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        D.BUSINESSTYPECODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C, CUSTOMERRF D ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                sb.Append(" AND D.LOGICALDELETECODERF=@DLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = D.BUSINESSTYPECODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");
                // 得意先別売上目標設定マスタの「拠点コード・得意先コード」と「管理拠点コード・得意先コード」が一致する
                sb.Append(" AND A.ENTERPRISECODERF = D.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF + A.CUSTOMERCODERF = D.MNGSECTIONCODERF + D.CUSTOMERCODERF ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, D.BUSINESSTYPECODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, D.BUSINESSTYPECODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findDLogicalDeleteCode = sqlCommand.Parameters.Add("@DLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(targetContrastCd);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findDLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 業種コード 33
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string businessTypeCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    businessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF")).ToString();
                    compareKey = sectionCode.Trim() + businessTypeCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + businessTypeCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + businessTypeCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 売上月次集計データ検索処理（販売区分）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="userGuideDivCd">ユーザーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 売上月次集計データ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// <br>Update Note: 2012/11/12 yangyi</br>
        /// <br>             redmine#33218 No.1633 目標自動設定 目標設定は不正がある</br>
        /// </remarks>
        private int GetSalesDivisionMTtList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            string sqlStr = string.Empty;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.ADDUPYEARMONTHRF, ");
                sb.Append(" A.ADDUPSECCODERF, ");
                sb.Append(" A.SALESCODERF, ");
                sb.Append(" SUM(A.TOTALSALESCOUNTRF) AS SALESCOUNTRF, ");
                // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                sb.Append(" SUM(A.SALESRETGOODSPRICERF) AS SALESRETGOODSPRICERF, ");
                sb.Append(" SUM(A.DISCOUNTPRICERF) AS DISCOUNTPRICERF, ");
                // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                sb.Append(" SUM(A.SALESMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.GROSSPROFITRF) AS PROFITRF ");
                sb.Append(" FROM MTTLSALESSLIPRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.ADDUPYEARMONTHRF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.ADDUPYEARMONTHRF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.ADDUPSECCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND A.SALESCODERF = C.GUIDECODERF ");
                // 実績集計区分
                sb.Append(" AND A.RSLTTTLDIVCDRF=@RSLTTTLDIVCD ");
                // ADD 2009/06/18 --->>>
                sb.Append(" AND A.EMPLOYEEDIVCDRF=@EMPLOYEEDIVCD ");
                // ADD 2009/06/18 ---<<<

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.ADDUPSECCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.ADDUPYEARMONTHRF, A.ADDUPSECCODERF, A.SALESCODERF ");
                sb.Append(" ORDER BY A.ADDUPSECCODERF, A.SALESCODERF ");


                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);
                SqlParameter findRsltTtlDivCd = sqlCommand.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 --->>>
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                // ADD 2009/06/18 ---<<<


                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // ユーザーガイドマスタ（販売区分） 71
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);
                findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(0);
                // ADD 2009/06/18 --->>>
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(10);
                // ADD 2009/06/18 ---<<<

                sqlCommand.CommandText = sb.ToString(); ;

                myReader = sqlCommand.ExecuteReader();

                GcdSalesTargetWork gcdSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string salesCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList gcdSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                    long salesretgoodprice = 0;
                    long discount = 0;
                    // ----- ADD 2012/11/12 yangyi #33218----------<<<<<
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
                    salesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF")).ToString();
                    compareKey = sectionCode.Trim() + salesCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(gcdSalesTargetList);
                        gcdSalesTargetList = new ArrayList();
                        gcdSalesTargetWork = new GcdSalesTargetWork();
                        gcdSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        gcdSalesTargetWork.SectionCode = sectionCode;
                        gcdSalesTargetWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                        gcdSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        gcdSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        gcdSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        gcdSalesTargetWork.SalesTargetMoney = gcdSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        gcdSalesTargetList.Add(gcdSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        gcdSalesTargetWork = new GcdSalesTargetWork();
                        gcdSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF")).ToString();
                        gcdSalesTargetWork.SectionCode = sectionCode;
                        gcdSalesTargetWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                        gcdSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        gcdSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        gcdSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));
                        // ----- ADD 2012/11/12 yangyi #33218---------->>>>>
                        salesretgoodprice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESRETGOODSPRICERF"));
                        discount = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DISCOUNTPRICERF"));
                        gcdSalesTargetWork.SalesTargetMoney = gcdSalesTargetWork.SalesTargetMoney + salesretgoodprice + discount;
                        // ----- ADD 2012/11/12 yangyi #33218----------<<<<<

                        gcdSalesTargetList.Add(gcdSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesCode;
                    }
                }

                if (null != gcdSalesTargetList && gcdSalesTargetList.Count > 0)
                {
                    allDataList.Add(gcdSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 商品別売上目標設定マスタ検索処理（販売区分）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="userGuideDivCd">ユーザーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetSalesDivisionGcdList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        A.SALESCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM GCDSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = A.SALESCODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, A.SALESCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, A.SALESCODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(44);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // ユーザーガイドマスタ（販売区分） 71
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                GcdSalesTargetWork gcdSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string salesCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList gcdSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    salesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF")).ToString();
                    compareKey = sectionCode.Trim() + salesCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(gcdSalesTargetList);
                        gcdSalesTargetList = new ArrayList();
                        gcdSalesTargetWork = new GcdSalesTargetWork();
                        gcdSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        gcdSalesTargetWork.SectionCode = sectionCode;
                        gcdSalesTargetWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                        gcdSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        gcdSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        gcdSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        gcdSalesTargetList.Add(gcdSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        gcdSalesTargetWork = new GcdSalesTargetWork();
                        gcdSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        gcdSalesTargetWork.SectionCode = sectionCode;
                        gcdSalesTargetWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                        gcdSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        gcdSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        gcdSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        gcdSalesTargetList.Add(gcdSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesCode;
                    }
                }

                if (null != gcdSalesTargetList && gcdSalesTargetList.Count > 0)
                {
                    allDataList.Add(gcdSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 得意先別売上目標設定マスタ検索処理（拠点⇒得意先再設定）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreSecCustomerEmpList(string baseCode, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(30);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 得意先別売上目標設定マスタ検索処理（得意先再設定）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreCustomerEmpList(string baseCode, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        C.EMPLOYEECODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, CUSTOMERRF B, EMPLOYEERF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");

                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.CUSTOMERCODERF = B.CUSTOMERCODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                // 得意先マスタを参照し、得意先マスタの「管理拠点コード・顧客担当従業員コード」が従業員マスタの「所属拠点・従業員コード」と一致する場合のみ対象とする　
                sb.Append(" AND B.MNGSECTIONCODERF + B.CUSTOMERAGENTCDRF = C.BELONGSECTIONCODERF + EMPLOYEECODERF ");
                // 得意先別売上目標設定マスタの「拠点コード・得意先コード」と「管理拠点コード・得意先コード」が一致する
                sb.Append(" AND A.SECTIONCODERF + A.CUSTOMERCODERF = B.MNGSECTIONCODERF + B.CUSTOMERCODERF ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, C.EMPLOYEECODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(30);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string compareKey = string.Empty;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string employeeCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    employeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                    compareKey = sectionCode.Trim() + employeeCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + employeeCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + employeeCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 従業員別売上目標設定マスタ検索処理（拠点⇒担当者再設定）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="employeeDivCd">従業員コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreSecTantosyaEmpList(string baseCode, Int32 employeeDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM EMPSALESTARGETRF A, SECINFOSETRF B ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND A.EMPLOYEEDIVCDRF = @EMPLOYEEDIVCD ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(22);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 10:担当者
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(employeeDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 従業員別売上目標設定マスタ検索処理（担当者再設定）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="employeeDivCd">従業員コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 従業員別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreTantosyaEmpList(string baseCode, Int32 employeeDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                            out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM EMPSALESTARGETRF A, SECINFOSETRF B, EMPLOYEERF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND A.ENTERPRISECODERF = C.ENTERPRISECODERF ");
                sb.Append(" AND A.EMPLOYEECODERF = C.EMPLOYEECODERF ");
                sb.Append(" AND A.EMPLOYEEDIVCDRF = @EMPLOYEEDIVCD ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findEmployeeDivCd = sqlCommand.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(22);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 10:担当者
                findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(employeeDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 得意先別売上目標設定マスタ検索処理（地区）目標⇒行う
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="userGuideDivCd">ユーザーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetDistrictDOCusList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        A.SALESAREACODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = A.SALESAREACODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, A.SALESAREACODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, A.SALESAREACODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(32);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 販売エリアコード 21
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                string compareKey = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;
                string salesAreaCode = string.Empty;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    salesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF")).ToString();
                    compareKey = sectionCode.Trim() + salesAreaCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesAreaCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + salesAreaCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 得意先別売上目標設定マスタ検索処理（地区再設定）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="userGuideDivCd">ユーザーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreDistrictCusList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = A.SALESAREACODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(32);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 販売エリアコード 21
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 得意先別売上目標設定マスタ検索処理（業種再設定）拠点用
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="userGuideDivCd">ユーザーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreTypeBusinessCusList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = A.BUSINESSTYPECODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(31);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 業種コード 33
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 得意先別売上目標設定マスタ検索処理（業種）業種用
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="userGuideDivCd">ユーザーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetTypeBusinessTBCusList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append("        A.BUSINESSTYPECODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM CUSTSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND C.LOGICALDELETECODERF=@CLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = A.BUSINESSTYPECODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF, A.BUSINESSTYPECODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF, A.BUSINESSTYPECODERF  ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findCLogicalDeleteCode = sqlCommand.Parameters.Add("@CLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(31);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findCLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // 業種コード 33
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                CustSalesTargetWork custSalesTargetWork = null;
                string compareKeyTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList custSalesTargetList = new ArrayList();
                string compareKey = string.Empty;
                string businessTypeCode = string.Empty;
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                    businessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF")).ToString();
                    compareKey = sectionCode.Trim() + businessTypeCode;

                    if (!compareKeyTemp.Equals(compareKey) && isFirstDatabool)
                    {
                        allDataList.Add(custSalesTargetList);
                        custSalesTargetList = new ArrayList();
                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + businessTypeCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        custSalesTargetWork = new CustSalesTargetWork();
                        custSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        custSalesTargetWork.SectionCode = sectionCode;
                        custSalesTargetWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                        custSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        custSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        custSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        custSalesTargetList.Add(custSalesTargetWork);

                        compareKeyTemp = sectionCode.Trim() + businessTypeCode;
                    }
                }

                if (null != custSalesTargetList && custSalesTargetList.Count > 0)
                {
                    allDataList.Add(custSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        /// <summary>
        /// 商品別売上目標設定マスタ検索処理（販売区分再設定）
        /// </summary>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="userGuideDivCd">ユーザーコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="yearMonthBegInt">開始日付</param>
        /// <param name="yearMonthEndInt">終了日付</param>
        /// <param name="sqlConnection">ＤＢ接続オブジェクト</param>
        /// <param name="sqlTransaction">sqlTransactionオブジェクト</param>
        /// <param name="allDataList">戻るメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品別売上目標設定マスタデータ検索処理を行う</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        private int GetMoreSalesDivisionGcdList(string baseCode, Int32 userGuideDivCd, string enterpriseCode, Int32 yearMonthBegInt, Int32 yearMonthEndInt, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction,
                    out ArrayList allDataList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage = string.Empty;
            allDataList = new ArrayList();
            //--------------------------
            // データベースオープン
            //--------------------------
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
            StringBuilder sb = new StringBuilder();

            try
            {
                //selectコマンドの生成
                sb.Append(" SELECT A.TARGETDIVIDECODERF, ");
                sb.Append("        A.SECTIONCODERF, ");
                sb.Append(" SUM(A.SALESTARGETCOUNTRF) AS SALESCOUNTRF, ");
                sb.Append(" SUM(A.SALESTARGETMONEYRF) AS MONEYRF, ");
                sb.Append(" SUM(A.SALESTARGETPROFITRF) AS PROFITRF ");
                sb.Append(" FROM GCDSALESTARGETRF A, SECINFOSETRF B, USERGDBDURF C ");
                sb.Append(" WHERE ");
                sb.Append(" A.TARGETDIVIDECODERF <= @ENDADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETDIVIDECODERF >= @BEGADDUPYEARMONTHRF ");
                sb.Append(" AND A.TARGETCONTRASTCDRF = @TARGETCONTRASTCD ");
                sb.Append(" AND A.ENTERPRISECODERF = @ENTERPRISECODE ");
                sb.Append(" AND A.LOGICALDELETECODERF=@ALOGICALDELETECODE ");
                sb.Append(" AND B.LOGICALDELETECODERF=@BLOGICALDELETECODE ");
                sb.Append(" AND A.ENTERPRISECODERF = B.ENTERPRISECODERF ");
                sb.Append(" AND A.SECTIONCODERF = B.SECTIONCODERF ");
                sb.Append(" AND C.USERGUIDEDIVCDRF = @USERGUIDEDIVCD ");
                sb.Append(" AND C.GUIDECODERF = A.SALESCODERF ");
                sb.Append(" AND C.ENTERPRISECODERF = A.ENTERPRISECODERF ");

                // 「00」は全て対象
                if (!"00".Equals(baseCode))
                {
                    sb.Append(" AND A.SECTIONCODERF = @SECTIONCODE ");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@SECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(baseCode);

                }

                sb.Append(" GROUP BY A.TARGETDIVIDECODERF, A.SECTIONCODERF ");
                sb.Append(" ORDER BY A.SECTIONCODERF ");

                //Prameterオブジェクトの作成
                SqlParameter findEndParaEnterpriseCode = sqlCommand.Parameters.Add("@ENDADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findBegParaEnterpriseCode = sqlCommand.Parameters.Add("@BEGADDUPYEARMONTHRF", SqlDbType.Int);
                SqlParameter findTargetContrastCd = sqlCommand.Parameters.Add("@TARGETCONTRASTCD", SqlDbType.Int);
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                SqlParameter findALogicalDeleteCode = sqlCommand.Parameters.Add("@ALOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findBLogicalDeleteCode = sqlCommand.Parameters.Add("@BLOGICALDELETECODE", SqlDbType.Int);
                SqlParameter findUserGuideDivCd = sqlCommand.Parameters.Add("@USERGUIDEDIVCD", SqlDbType.Int);

                //Parameterオブジェクトへ値設定
                findEndParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthEndInt);
                findBegParaEnterpriseCode.Value = SqlDataMediator.SqlSetInt32(yearMonthBegInt);
                findTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(44);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
                findALogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                findBLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
                // ユーザーガイドマスタ（販売区分） 71
                findUserGuideDivCd.Value = SqlDataMediator.SqlSetInt32(userGuideDivCd);

                sqlCommand.CommandText = sb.ToString();

                myReader = sqlCommand.ExecuteReader();

                EmpSalesTargetWork empSalesTargetWork = null;
                string sectionCodeTemp = string.Empty;
                string sectionCode = string.Empty;
                ArrayList empSalesTargetList = new ArrayList();
                bool isFirstDatabool = false;

                while (myReader.Read())
                {
                    sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));

                    if (!sectionCodeTemp.Equals(sectionCode) && isFirstDatabool)
                    {
                        allDataList.Add(empSalesTargetList);
                        empSalesTargetList = new ArrayList();
                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                    else
                    {
                        isFirstDatabool = true;

                        empSalesTargetWork = new EmpSalesTargetWork();
                        empSalesTargetWork.TargetDivideCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("TARGETDIVIDECODERF"));
                        empSalesTargetWork.SectionCode = sectionCode;
                        empSalesTargetWork.SalesTargetCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESCOUNTRF"));
                        empSalesTargetWork.SalesTargetMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("MONEYRF"));
                        empSalesTargetWork.SalesTargetProfit = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PROFITRF"));

                        empSalesTargetList.Add(empSalesTargetWork);

                        sectionCodeTemp = sectionCode;
                    }
                }

                if (null != empSalesTargetList && empSalesTargetList.Count > 0)
                {
                    allDataList.Add(empSalesTargetList);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DispatchInstsWorkReadDB.GetStockMoveList Exception=" + ex.Message);
                retMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
                if (myReader != null)
                    if (!myReader.IsClosed) myReader.Close();
            }

            return status;
        }

        #endregion

        # region ■ 従業員別、得意先別、商品別売上目標設定マスタ情報を削除処理 ■
        /// <summary>
        /// 従業員別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="empsalestargetList">従業員別売上目標設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 従業員別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.30</br>
        private int DeleteEmpSalesTargetProc(ArrayList empsalestargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            string sqlStr = string.Empty;
            try
            {

                for (int i = 0; i < empsalestargetList.Count; i++)
                {
                    EmpSalesTargetWork empsalestargetWork = empsalestargetList[i] as EmpSalesTargetWork;

                    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);
                    sqlStr = "DELETE FROM EMPSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                    if (!"00".Equals(empsalestargetWork.SectionCode))
                    {
                        sqlStr += " AND SECTIONCODERF=@FINDSECTIONCODE ";
                    }
                    sqlStr += " AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND EMPLOYEEDIVCDRF=@FINDEMPLOYEEDIVCD AND SUBSECTIONCODERF=@FINDSUBSECTIONCODE  ";
                    // 従業員コード
                    if (!string.IsNullOrEmpty(empsalestargetWork.EmployeeCode.Trim()))
                    {
                        sqlStr += " AND EMPLOYEECODERF=@FINDEMPLOYEECODE ";
                    }

                    sqlCommand.CommandText = sqlStr;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    if (!"00".Equals(empsalestargetWork.SectionCode))
                    {
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.SectionCode);
                    }
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaEmployeeDivCd = sqlCommand.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);
                    SqlParameter findParaSubSectionCode = sqlCommand.Parameters.Add("@FINDSUBSECTIONCODE", SqlDbType.Int);
                    // 従業員コード
                    if (!string.IsNullOrEmpty(empsalestargetWork.EmployeeCode.Trim()))
                    {
                        SqlParameter findParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                        findParaEmployeeCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EmployeeCode);
                    }


                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.EnterpriseCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(empsalestargetWork.TargetDivideCode);
                    findParaEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.EmployeeDivCd);
                    findParaSubSectionCode.Value = SqlDataMediator.SqlSetInt32(empsalestargetWork.SubSectionCode);


                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 得意先別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="custSalesTargetList">得意先別売上目標設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 得意先別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.30</br>
        private int DeleteCustSalesTargetProc(ArrayList custSalesTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            string sqlStr = string.Empty;
            try
            {

                for (int i = 0; i < custSalesTargetList.Count; i++)
                {
                    CustSalesTargetWork custSalesTargetWork = custSalesTargetList[i] as CustSalesTargetWork;

                    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                    sqlStr = "DELETE FROM CUSTSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                    // 拠点コード
                    if (!"00".Equals(custSalesTargetWork.SectionCode))
                    {
                        sqlStr += " AND SECTIONCODERF=@FINDSECTIONCODE ";
                    }
                    // 得意先コード
                    if (-1 != custSalesTargetWork.CustomerCode)
                    {
                        sqlStr += " AND CUSTOMERCODERF=@FINDCUSTOMERCODE ";
                    }
                    // 業種コード
                    if (-1 != custSalesTargetWork.BusinessTypeCode)
                    {
                        sqlStr += " AND BUSINESSTYPECODERF=@FINDBUSINESSTYPECODE ";
                    }
                    // 販売エリアコード
                    if (-1 != custSalesTargetWork.SalesAreaCode)
                    {
                        sqlStr += " AND SALESAREACODERF=@FINDSALESAREACODE ";
                    }
                    sqlStr += " AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE ";
                    
                    
                    
                    sqlCommand.CommandText = sqlStr;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    // 拠点コード
                    if (!"00".Equals(custSalesTargetWork.SectionCode))
                    {
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.SectionCode);
                    }
                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    // 販売エリアコード
                    if (-1 != custSalesTargetWork.SalesAreaCode)
                    {
                        SqlParameter findParaSalesAreaCode = sqlCommand.Parameters.Add("@FINDSALESAREACODE", SqlDbType.Int);
                        findParaSalesAreaCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.SalesAreaCode);
                    }

                    // 業種コード
                    if (-1 != custSalesTargetWork.BusinessTypeCode)
                    {
                        SqlParameter findParaBusinessTypeCode = sqlCommand.Parameters.Add("@FINDBUSINESSTYPECODE", SqlDbType.Int);
                        findParaBusinessTypeCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.BusinessTypeCode);

                    }
                    // 得意先コード
                    if (-1 != custSalesTargetWork.CustomerCode)
                    {
                        SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                        findParaCustomerCode.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.CustomerCode);
                    }

                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.EnterpriseCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(custSalesTargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(custSalesTargetWork.TargetDivideCode);

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// 商品別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)
        /// </summary>
        /// <param name="gcdSalesTargetList">従業員別売上目標設定マスタ情報オブジェクト</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <param name="sqlTransaction">sqlTransaction</param>
        /// <returns></returns>
        /// <br>Note       : 商品別売上目標設定マスタ情報を物理削除します(外部からのSqlConnection SqlTranactionを使用)</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.30</br>
        private int DeleteGcdSalesTargetProc(ArrayList gcdSalesTargetList, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand sqlCommand = null;
            string sqlStr = string.Empty;
            try
            {

                for (int i = 0; i < gcdSalesTargetList.Count; i++)
                {
                    GcdSalesTargetWork gcdSalesTargetWork = gcdSalesTargetList[i] as GcdSalesTargetWork;

                    sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

                    sqlStr = "DELETE FROM GCDSALESTARGETRF WHERE ENTERPRISECODERF=@FINDENTERPRISECODE ";
                    if (!"00".Equals(gcdSalesTargetWork.SectionCode))
                    {
                        sqlStr += " AND SECTIONCODERF=@FINDSECTIONCODE ";
                    }
                    sqlStr += " AND TARGETSETCDRF=@FINDTARGETSETCD AND TARGETCONTRASTCDRF=@FINDTARGETCONTRASTCD AND TARGETDIVIDECODERF=@FINDTARGETDIVIDECODE AND GOODSMAKERCDRF=@FINDGOODSMAKERCD AND GOODSNORF=@FINDGOODSNO AND BLGROUPCODERF=@FINDBLGROUPCODE AND BLGOODSCODERF=@FINDBLGOODSCODE ";
                    // 販売区分コード
                    if (-1 != gcdSalesTargetWork.SalesCode)
                    {
                        sqlStr += " AND SALESCODERF=@FINDSALESCODE ";
                    }
                    sqlStr += " AND ENTERPRISEGANRECODERF=@FINDENTERPRISEGANRECODE ";

                    sqlCommand.CommandText = sqlStr;

                    //Prameterオブジェクトの作成
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    if (!"00".Equals(gcdSalesTargetWork.SectionCode))
                    {
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(gcdSalesTargetWork.SectionCode);
                    }

                    SqlParameter findParaTargetSetCd = sqlCommand.Parameters.Add("@FINDTARGETSETCD", SqlDbType.Int);
                    SqlParameter findParaTargetContrastCd = sqlCommand.Parameters.Add("@FINDTARGETCONTRASTCD", SqlDbType.Int);
                    SqlParameter findParaTargetDivideCode = sqlCommand.Parameters.Add("@FINDTARGETDIVIDECODE", SqlDbType.NChar);
                    SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                    SqlParameter findParaGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);
                    SqlParameter findParaBLGroupCode = sqlCommand.Parameters.Add("@FINDBLGROUPCODE", SqlDbType.Int);
                    SqlParameter findParaBLGoodsCode = sqlCommand.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);
                    // 販売区分コード
                    if (-1 != gcdSalesTargetWork.SalesCode)
                    {
                        SqlParameter findParaSalesCode = sqlCommand.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);
                        findParaSalesCode.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.SalesCode);
                    }
                    SqlParameter findParaEnterpriseGanreCode = sqlCommand.Parameters.Add("@FINDENTERPRISEGANRECODE", SqlDbType.Int);

                    //KEYコマンドを再設定
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(gcdSalesTargetWork.EnterpriseCode);
                    findParaTargetSetCd.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.TargetSetCd);
                    findParaTargetContrastCd.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.TargetContrastCd);
                    findParaTargetDivideCode.Value = SqlDataMediator.SqlSetString(gcdSalesTargetWork.TargetDivideCode);
                    findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.GoodsMakerCd);
                    if (string.IsNullOrEmpty(gcdSalesTargetWork.GoodsNo.Trim()))
                    {
                        findParaGoodsNo.Value = gcdSalesTargetWork.GoodsNo;
                    }
                    else
                    {
                        findParaGoodsNo.Value = SqlDataMediator.SqlSetString(gcdSalesTargetWork.GoodsNo);
                    }

                    findParaBLGroupCode.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.BLGroupCode);
                    findParaBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.BLGoodsCode);
                    findParaEnterpriseGanreCode.Value = SqlDataMediator.SqlSetInt32(gcdSalesTargetWork.EnterpriseGanreCode);

                    sqlCommand.ExecuteNonQuery();
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }

            return status;
        }
        #endregion
    }
}
