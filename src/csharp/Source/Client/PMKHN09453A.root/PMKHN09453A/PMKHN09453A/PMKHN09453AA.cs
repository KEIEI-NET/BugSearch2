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
// 管理番号              作成担当 : 
// 修 正 日  2009/07/07  修正内容 : PVCS#263 対象期の適用月算出方法不正                     
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 目標自動設定処理スクラス
    /// </summary>
    /// <remarks>
    /// Note       : 目標自動設定処理です。<br />
    /// Programmer : 譚洪<br />
    /// Date       : 2009.04.02<br />
    /// </remarks>
    public class ObjAutoSetAcs
    {
        #region ■ Const Memebers ■
        private const string ALL_SECTIONCODE = "00";
        #endregion

        # region ■ Constructor ■
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private ObjAutoSetAcs()
        {
            this._companyInfAcs = new CompanyInfAcs();
            _dateGet = DateGetAcs.GetInstance();
            _totalDayCalculator = TotalDayCalculator.GetInstance();
            this._objAutoSetControlDB = ObjAutoSetDB.GetObjAutoSetControlDB();
        }
        # endregion

        # region ■ Private Members ■
        private static ObjAutoSetAcs _objAutoSetAcs;
        private CompanyInfAcs _companyInfAcs;
        private DateGetAcs _dateGet;
        private IObjAutoSetControlDB _objAutoSetControlDB;
        private TotalDayCalculator _totalDayCalculator;
        # endregion

        #region ■ 目標自動設定アクセスクラス インスタンス取得処理 ■
        /// <summary>
        /// 目標自動設定アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>目標自動設定アクセスクラス インスタンス</returns>
        public static ObjAutoSetAcs GetInstance()
        {
            if (_objAutoSetAcs == null)
            {
                _objAutoSetAcs = new ObjAutoSetAcs();
            }

            return _objAutoSetAcs;
        }
        #endregion ■ 目標自動設定アクセスクラス インスタンス取得処理 ■

        #region ■ オフライン状態チェック処理 ■

        /// <summary>
        /// ログオン時オンライン状態チェック処理
        /// </summary>
        /// <returns>チェック処理結果</returns>
        public bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// リモート接続可能判定
        /// </summary>
        /// <returns>判定結果</returns>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion ■ オフライン状態チェック処理 ■

        #region ■ 実行処理 ■
        /// <summary>
        /// 会計年度取得処理
        /// <param name="yearMonth">会計年度</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 会計年度の取得処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        public void GetCompanyInf(out List<DateTime> yearMonth)
        {
            List<DateTime> startMonthDate;
            List<DateTime> endMonthDate;
            // 当年 → 0 当年会計年度取得
            _dateGet.GetFinancialYearTable(0, out startMonthDate, out endMonthDate, out yearMonth);
        }

        /// <summary>
        /// 現在処理年月取得処理
        /// <param name="yearMonth">現在処理年月</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       :現在処理年月の取得処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        public void GetThisYearMonth(out DateTime yearMonth)
        {
            DateTime prevTotalDay = new DateTime();
            DateTime currentTotalDay = new DateTime();
            // MOD 譚洪 2009/07/07 --->>>
            //_dateGet.GetThisYearMonth(out yearMonth);
            // 今回締処理月取得
            _totalDayCalculator.InitializeHisMonthlyAccRec();
            // MOD 譚洪 2009/07/09 --->>>
            _totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay, out currentTotalDay);
            // MOD 譚洪 2009/07/09 ---<<<
            if (currentTotalDay != DateTime.MinValue)
            {
                yearMonth = currentTotalDay;
            }
            else
            {
                // 現在処理年月取得
                DateTime nowYearMonth;
                _dateGet.GetThisYearMonth(out nowYearMonth);
                yearMonth = nowYearMonth;
            }
            // MOD 譚洪 2009/07/07 ---<<<
        }

        /// <summary>
        /// 実行処理
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="baseCode">拠点コード</param>
        /// <param name="objAutoSetWork">ドロップダウンデータ</param>
        /// <param name="yearMonth">会計年度</param>
        /// </summary>
        /// <remarks>
        /// <br>Note       : 実行処理を行う。</br>      
        /// <br>Programmer : 譚洪</br>                                  
        /// <br>Date       : 2009.04.29</br> 
        /// </remarks>
        /// <returns>実行結果ステータス</returns>
        public int ObjAutoSetProc(string enterpriseCode, string baseCode, ObjAutoSetWork objAutoSetWork, List<DateTime> yearMonth)
        {
            List<DateTime> pastStartMonthDate;
            List<DateTime> pastEndMonthDate;
            List<DateTime> pastYearMonth;

            List<DateTime> nowStartMonthDate;
            List<DateTime> nowEndMonthDate;
            List<DateTime> nowYearMonth;

            DateTime nowYearMonthDate = new DateTime();

            // 前期会計年度もう一度取得する。
            _dateGet.GetFinancialYearTable(-1, out pastStartMonthDate, out pastEndMonthDate, out pastYearMonth);
            // 当期会計年度もう一度取得する。
            _dateGet.GetFinancialYearTable(0, out nowStartMonthDate, out nowEndMonthDate, out nowYearMonth);
            // 現在処理年月取得
            // MOD 譚洪 2009/07/07 --->>>
            //_dateGet.GetThisYearMonth(out nowYearMonthDate);
            this.GetThisYearMonth(out nowYearMonthDate);
            // MOD 譚洪 2009/07/07 ---<<<

            // 自社情報読み込み
            int status = this._objAutoSetControlDB.ObjAutoSetProc(enterpriseCode, baseCode, pastStartMonthDate, pastEndMonthDate, pastYearMonth,
                nowStartMonthDate, nowEndMonthDate, nowYearMonth, nowYearMonthDate, objAutoSetWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //CompanyBiginMonth = this._companyInf.CompanyBiginMonth;
            }
            return status;
        }
        #endregion
    }
}
