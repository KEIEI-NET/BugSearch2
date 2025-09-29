using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫マスタ一覧表印刷DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫マスタ一覧表印刷DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 20081</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockMasterTblDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 在庫マスタ一覧表印刷データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="rsltInfo_StockMasterTblWork">検索結果</param>
        /// <param name="extrInfo_StockMasterTblWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20081</br>
        /// <br>Date       : 2008.08.20</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMZAI02026D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_StockMasterTblWork")]
            out object rsltInfo_StockMasterTblWork,
            object extrInfo_StockMasterTblWork);
        #endregion
    }
}
