using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 在庫調整データ検索 RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫調整データ検索 RemoteObjectインターフェース</br>
    /// <br>Programmer : 22018　鈴木　正臣</br>
    /// <br>Date       : 2008.08.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockAdjRefSearchDB
    {
        /// <summary>
        /// 指定されたパラメータの条件を満たす全ての在庫調整データLISTを戻します
        /// </summary>
        /// <param name="searchPara">検索パラメータ</param>
        /// <param name="retWork">検索結果在庫調整データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 指定された検索キーの在庫調整データLISTを全て戻します</br>
        /// <br>Programmer : 22018　鈴木　正臣</br>
        /// <br>Date       : 2008.08.20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object searchPara,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retWork);
    }
}
