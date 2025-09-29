using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PureSettingPmDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PureSettingPmDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 脇田　靖之</br>
    /// <br>Date       : 2013.02.18</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]

    public interface IPureSettingPmDB
    {
        /// <summary>
        /// 指定された純正設定マスタGuidの純正設定マスタを戻します
        /// </summary>
        /// <param name="parabyte">parabyteオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された純正設定マスタGuidの純正設定マスタを戻します</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        int Read(ref byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 純正設定マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="PureSettingPmWork">検索結果</param>
        /// <param name="paraPureSettingPmWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : 2013.02.18</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09913D", "Broadleaf.Application.Remoting.ParamData.PureSettingPmWork")]
			out object PureSettingPmWork,
         object paraPureSettingPmWork);

        #endregion

    }

}
