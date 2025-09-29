using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// TbsPartsCdChgDB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : TbsPartsCdChgDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.05.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]

    public interface ITbsPartsCdChgDB
    {
        /// <summary>
        /// 指定されたBLコード変換マスタGuidのBLコード変換マスタを戻します
        /// </summary>
        /// <param name="parabyte">parabyteオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定されたBLコード変換マスタGuidのBLコード変換マスタを戻します</br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.22</br>
        int Read(ref byte[] parabyte);

        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// BLコード変換マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="TbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.05.22</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD09103D", "Broadleaf.Application.Remoting.ParamData.TbsPartsCdChgWork")]
			out object tbsPartsCdChgWork,
        object paraTbsPartsCdChgWork);
        #endregion

    }

}
