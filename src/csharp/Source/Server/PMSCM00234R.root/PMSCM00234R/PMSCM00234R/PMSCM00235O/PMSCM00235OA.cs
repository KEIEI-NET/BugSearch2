//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オプション管理DBインターフェース
// プログラム概要   : オプション管理DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745 吉岡
// 作 成 日  2014/08/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// オプション管理マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : オプション管理マスタDBインターフェースです。</br>
    /// <br>Programmer : limm</br>
    /// <br>Date       : 2014/08/05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPMOptMngDB
    {
        /// <summary>
        ///  オプション管理マスタLISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="pMOptMngWorkList">検索結果</param>
        /// <param name="parapMOptMngWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/07</br>
        //[MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSCM00236D", "Broadleaf.Application.Remoting.ParamData.PMOptMngWork")]
			out object pMOptMngWorkList,
          object parapMOptMngWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        ///  オプション管理マスタLISTを全て戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="pMOptMngWorkList">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/07</br>
        [MustCustomSerialization]
        int SearchAll(
            [CustomSerializationMethodParameterAttribute("PMSCM00236D", "Broadleaf.Application.Remoting.ParamData.PMOptMngWork")]
			out object pMOptMngWorkList);

        /// <summary>
        /// オプション管理マスタを追加・更新します。
        /// </summary>
        /// <param name="pMOptMngWorkList">追加・更新するオプション管理マスタを含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : pMOptMngWorkList に格納されているオプション管理マスタを追加・更新します。</br>
        /// <br>Programmer : limm</br>
        /// <br>Date       : 2014/08/07</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMSCM00236D", "Broadleaf.Application.Remoting.ParamData.PMOptMngWork")]
            ref object pMOptMngWorkList);
    }
}
