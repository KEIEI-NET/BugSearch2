using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PartsLayerStPmDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PartsLayerStPmDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 脇田　靖之</br>
    /// <br>Date       : 2013.02.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]

    public interface IPartsLayerStPmDB
    {
        /// <summary>
        /// 指定された層別設定マスタGuidの層別設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">parabyteオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された層別設定マスタGuidの層別設定マスタを戻します</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        int Read(ref byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 層別設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="PartsLayerStPmWork">検索結果</param>
        /// <param name="paraPartsLayerStPmWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09917D", "Broadleaf.Application.Remoting.ParamData.PartsLayerStPmWork")]
			out object PartsLayerStPmWork,
       object paraPartsLayerStPmWork);

        #endregion

    }

}
