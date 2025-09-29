//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品MAX入荷予約
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11270001-00  作成担当 : 陳艶丹
// 作 成 日  2016/01/21   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>部品MAX入荷予約DBインターフェース</summary>
    /// <br>Note       : 部品MAX入荷予約DBインターフェースです.</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2016/01/21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPartsMaxStockArrivalDB
    {
        #region 部品MAX入荷予約情件数の取得処理
        /// <summary>
        ///部品MAX入荷予約情件数の取得処理。
        /// </summary>
        /// <param name="searchCount">検索結果</param>
        /// <param name="partsMaxStockArrivalCndtnWork">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : 部品MAX入荷予約の件数を取得します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        [MustCustomSerialization]
        int SearchCount(
           out int searchCount,
           object partsMaxStockArrivalCndtnWork,
           out string errMessage);
        #endregion

        #region 部品MAX入荷予約情報リストの取得処理
        /// <summary>
        ///部品MAX入荷予約情報リストの取得処理。
        /// </summary>
        /// <param name="partsMaxStockArrivalResultWork">検索結果</param>
        /// <param name="partsMaxStockArrivalCndtnWork">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="loopIndex">分割index</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : 部品MAX入荷予約のキー値が一致する、全ての売上データテキスト情報を取得します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2016/01/21</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMMAX02006D", "Broadleaf.Application.Remoting.ParamData.PartsMaxStockArrivalWork")]
            out object partsMaxStockArrivalResultWork,
            object partsMaxStockArrivalCndtnWork,
            out string errMessage,
            int loopIndex);

        #endregion
    }
}
