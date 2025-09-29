//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 決済手形消込処理
// プログラム概要   : 決済手形消込処理DB Access RemoteObjectインターフェース。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/04/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 決済手形消込処理用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 決済手形消込処理用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 張義</br>
    /// <br>Date       : 2010/04/22</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISettlementBillDelDB
    {
        /// <summary>
        /// 決済手形消込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="processDate">処理日</param>
        /// <param name="prevTotalMonth">前回締処理月</param>
        /// <param name="billDiv">手形区分0:受取手形;1:支払手形</param>
        /// <param name="pieceDelete">削除件数</param>
        /// <param name="totalpiece">抽出件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: 決済手形消込処理を行う。</br>
        /// <br>Programmer	: 張義</br>	
        /// <br>Date		: 2010/04/22</br>
        /// </remarks>
        int SettlementBillDelProc(string enterpriseCode, int processDate, int prevTotalMonth, int billDiv, out int pieceDelete, out int totalpiece);
    }
}
