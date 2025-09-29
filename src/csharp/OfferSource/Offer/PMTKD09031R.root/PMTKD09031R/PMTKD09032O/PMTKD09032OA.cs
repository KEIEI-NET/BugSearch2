using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// TbsPartsCodeDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : TbsPartsCodeDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 22008　長内　数馬</br>
    /// <br>Date       : 2008.06.04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]

    public interface ITbsPartsCodeDB
    {
        /// <summary>
        /// 指定されたBLコードマスタGuidのBLコードマスタを戻します
        /// </summary>
        /// <param name="parabyte">parabyteオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたBLコードマスタGuidのBLコードマスタを戻します</br>
        /// <br>Programmer : 22008　長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        int Read(ref byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// BLコードマスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="TbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD09033D", "Broadleaf.Application.Remoting.ParamData.TbsPartsCodeWork")]
			out object TbsPartsCodeWork,
         object paraTbsPartsCodeWork);

        /// <summary>
        /// BLコードマスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="TbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008 長内　数馬</br>
        /// <br>Date       : 2008.06.04</br>
        [MustCustomSerialization]
        int SearchDerived(
            [CustomSerializationMethodParameterAttribute("PMTKD09033D", "Broadleaf.Application.Remoting.ParamData.TbsPartsCodeWork")]
			out object TbsPartsCodeWork,
         object paraTbsPartsCodeWork);
        #endregion

    }

}
