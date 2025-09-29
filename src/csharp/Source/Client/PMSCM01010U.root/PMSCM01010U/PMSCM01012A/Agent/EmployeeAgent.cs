//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/07/09  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = EmployeeAcs;
    using RecordType        = KeyValuePair<Employee, EmployeeDtl>;

    /// <summary>
    /// 従業員マスタアクセスの代理人クラス
    /// </summary>
    public class EmployeeAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "従業員マスタ";
        private const string CLASS_NAME = "EmployeeAgent";  // ログ用

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public EmployeeAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>該当する従業員</returns>
        public RecordType Find(
            string enterpriseCode,
            string employeeCode
        )
        {
            const string METHOD_NAME = "Find()";    // ログ用

            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatEmployeeCode(employeeCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            Employee    foundEmployee       = null;
            EmployeeDtl foundEmployeeDetail = null;
            int status = RealAccesser.Read(out foundEmployee, out foundEmployeeDetail, enterpriseCode, employeeCode);
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                #region <Log>

                string msg = string.Format(
                    "従業員マスタの検索エラー：{0}(企業コード={1}, 従業員コード={2})",
                    status,
                    enterpriseCode,
                    employeeCode
                );
                EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                Debug.Assert(false, MY_NAME + "の検索が失敗しました。");
            }

            if (foundEmployee != null && foundEmployee.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, new RecordType(foundEmployee, foundEmployeeDetail ?? new EmployeeDtl()));
                return FoundRecordMap[key];
            }

            return new RecordType(foundEmployee ?? new Employee(), foundEmployeeDetail ?? new EmployeeDtl());
        }
    }
}
