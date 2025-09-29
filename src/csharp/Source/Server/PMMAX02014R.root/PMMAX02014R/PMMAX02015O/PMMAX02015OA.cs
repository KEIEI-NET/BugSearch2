//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 出品一括更新
// プログラム概要   : 出品一括更新 RemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270001-00   作成担当 : 宋剛
// 作 成 日 : 2016/01/22    修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary> 
    /// 出品一括更新DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 出品一括更新DBインターフェースです.</br>
    /// <br>Programmer : 宋剛</br>
    /// <br>Date       : 2016/01/22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPartsMaxStockUpdDB
    {
        /// <summary>
        ///部品MAX件数の取得処理
        /// </summary>
        /// <param name="searchCount">検索結果</param>
        /// <param name="partsMaxStockUpdateCndtnWork">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : 部品MAX件数を取得します。</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        [MustCustomSerialization]
        int SearchCount(
           out int searchCount,
           object partsMaxStockUpdateCndtnWork,
           out string errMessage);

        /// <summary>
        /// 出品一括更新検索を戻します
        /// </summary>
        /// <param name="partsMaxStockUpdateResultWork">検索結果</param>
        /// <param name=" partsMaxStockUpdateCndtnWork">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="loopIndex">分割index</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 出品一括更新を戻します</br>
        /// <br>Programmer : 宋剛</br>
        /// <br>Date       : 2016/01/22</br>
        [MustCustomSerialization]
        int Search(
          [CustomSerializationMethodParameterAttribute("PMMAX02016D", "Broadleaf.Application.Remoting.ParamData.PartsMaxStockUpdateResultWork")]
          out object partsMaxStockUpdateResultWork,
          object partsMaxStockUpdateCndtnWork,
          out string errMessage,
          int loopIndex);
    }
}
