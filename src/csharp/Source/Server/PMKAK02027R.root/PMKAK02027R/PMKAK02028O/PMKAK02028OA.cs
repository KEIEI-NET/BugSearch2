//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 買掛残高一覧表（総括） DBRemoteObjectインターフェース
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI冨樫 紗由里
// 作 成 日  2012/09/14  修正内容 : 新規作成 仕入総括機能対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 買掛残高一覧表（総括）DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 買掛残高一覧表（総括）DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : FSI冨樫 紗由里</br>
    /// <br>Date       : 2012/09/14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumAccPaymentListWorkDB
    {

        /// <summary>
        /// 買掛残高一覧表（総括）を戻します
        /// </summary>
        /// <param name="sumAccPaymentListResultWork">検索結果</param>
        /// <param name=" sumAccPaymentListCndtnWork">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI冨樫 紗由里</br>
        /// <br>Date       : 2012/09/14</br>
        [MustCustomSerialization]
        int Search(
          [CustomSerializationMethodParameterAttribute("PMKAK02029D", "Broadleaf.Application.Remoting.ParamData.SumAccPaymentListResultWork")]
          out object sumAccPaymentListResultWork, object sumAccPaymentListCndtnWork, int readMode, ConstantManagement.LogicalMode logicalMode);

    }
}
