//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 車検期日更新
// プログラム概要   : 車検期日更新DB Access RemoteObjectインターフェース。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王海立
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
    /// 車検期日更新用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車検期日更新用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 王海立</br>
    /// <br>Date       : 2010/04/21</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IInspectDateUpdDB
    {
        /// <summary>
        /// 車検期日更新処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="updateDate">更新年月</param>
        /// <param name="searchNum">抽出件数</param>
        /// <param name="updNum">更新件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 車検期日更新処理を行うクラスです。</br>
        /// <br>Programmer : 王海立</br>
        /// <br>Date       : 2010/04/21</br>
        /// </remarks>
        [MustCustomSerialization]
        int InspectDateUpdProc(string enterpriseCode, int updateDate, out int searchNum, out int updNum);
    }
}
