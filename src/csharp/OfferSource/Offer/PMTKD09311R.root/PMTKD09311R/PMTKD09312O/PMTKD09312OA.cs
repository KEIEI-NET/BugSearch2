//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 優良部品詳細マスタDBリモートオブジェクト
// プログラム概要   : 優良部品詳細マスタの取得を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370090-00 作成担当 : 櫻井　亮太
// 作 成 日  2017/10/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//

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
    /// <br>Note       : PrimePartsDtlDB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2017.10.17</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]

    public interface IPrimePartsDtlDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 優良部品詳細マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="TbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2017.10.17</br>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTKD09313D", "Broadleaf.Application.Remoting.ParamData.PrmPrtDtInfWork")]
			out object PrmPrtDtInfobj,
            object PrmPrtDtlParaObj);
 

        /// <summary>
        /// 優良部品詳細マスタの存在チェックを行います。
        /// </summary>
        /// <param name="TbsPartsCodeWork">検索結果</param>
        /// <param name="paraTbsPartsCodeWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350 櫻井　亮太</br>
        /// <br>Date       : 2017.10.17</br>
        [MustCustomSerialization]
        int CheckExist(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object PrimPartsCheckObj,
            object PrimePartsParaObj);
        #endregion
    }

}
