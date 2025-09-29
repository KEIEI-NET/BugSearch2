//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入売上実績表
// プログラム概要   : 仕入売上実績表帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 汪千来
// 作 成 日  2009/05/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入売上実績表DBRemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入売上実績表DBRemoteObjectインターフェースのインスタンスの作成を行う。</br>
    /// <br>Programmer : 汪千来</br>
    /// <br>Date       : 2009.05.10</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockSalesResultInfoTableDB
    {

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 仕入売上実績表一覧表LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="stockSalesInfoWork">検索結果</param>
        /// <param name="paraStockSalesInfoCndtnWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 仕入売上実績表一覧表LISTを全て戻しますことを行います。</br>
        /// <br>Programmer : 汪千来</br>
        /// <br>Date       : 2009.05.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKOU02069D", "Broadleaf.Application.Remoting.ParamData.StockSalesResultInfoWork")]
			out object stockSalesInfoWork,
           object paraStockSalesInfoCndtnWork);


        #endregion
    }
}
