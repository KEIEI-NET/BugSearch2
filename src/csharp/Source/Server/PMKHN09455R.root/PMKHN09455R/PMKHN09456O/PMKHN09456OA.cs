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
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 目標自動設定処理用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 目標自動設定処理用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009.04.02</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IObjAutoSetControlDB
    {
        /// <summary>
        /// 目標自動設定
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
        /// <br>Note       : 目標自動設定する</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.4.31</br>
        int ObjAutoSetProc(string enterpriseCode, string baseCode, List<DateTime> pastStartMonthDate, List<DateTime> pastEndMonthDate,
            List<DateTime> pastYearMonth, List<DateTime> nowStartMonthDate, List<DateTime> nowEndMonthDate, List<DateTime> nowYearMonth, DateTime yearMonth,
            ObjAutoSetWork objAutoSetWork);
    }
}
