//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 一括リアル更新
// プログラム概要   : 一括リアル更新DB Access RemoteObjectインターフェース。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2009/12/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 一括リアル更新用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 一括リアル更新用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAllRealUpdToolDB
    {
        /// <summary>
        /// 一括リアル更新処理
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">売上ワーク</param>
        /// <param name="mTtlStockUpdParaWork">仕入ワーク</param>
        /// <param name="procDiv">処理区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 一括リアル更新処理を行うクラスです。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        [MustCustomSerialization]
        int AllRealUpdProc(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, MTtlStockUpdParaWork mTtlStockUpdParaWork, int procDiv);
    }
}
