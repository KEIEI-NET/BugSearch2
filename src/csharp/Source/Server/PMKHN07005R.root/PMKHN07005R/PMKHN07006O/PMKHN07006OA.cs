//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 葉書・封筒・ＤＭテキスト出力
// プログラム概要   : 葉書・封筒・ＤＭテキスト出力を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>																	
    /// マスタ一覧表DB RemoteObjectインターフェース																	
    /// </summary>																	
    /// <remarks>																	
    /// <br>Note       : マスタ一覧表DB RemoteObject Interfaceです。</br>																	
    /// <br>Programmer : 朱宝軍</br>																	
    /// <br>Date       : 2009.04.01</br>																	
    /// <br></br>																	
    /// <br>Update Note: </br>																	
    /// </remarks>																	
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IUseMastListDB
    {
        /// <summary>																	
        /// 得意先一覧表LISTを全て戻します（論理削除除く）:カスタムシリアライズ																	
        /// </summary>																	
        /// <param name="ListRetWorkList">検索結果</param>																	
        /// <param name="ListParaWork">検索パラメータ</param>																	
        /// <returns>STATUS</returns>																	
        /// <br>Note       : </br>																	
        /// <br>Programmer : 朱宝軍</br>																	
        /// <br>Date       : 2009.04.01</br>																	
        [MustCustomSerialization]
        int SearchCustomer(
            [CustomSerializationMethodParameterAttribute("PMKHN07007D", "Broadleaf.Application.Remoting.ParamData.PostCustomerWork")]																	
			 out object ListRetWorkList,object ListParaWork);

        /// <summary>																	
        /// 拠点一覧表LISTを全て戻します（論理削除除く）:カスタムシリアライズ																	
        /// </summary>																	
        /// <param name="ListRetWorkList">検索結果</param>																	
        /// <param name="ListParaWork">検索パラメータ</param>																	
        /// <returns>STATUS</returns>																	
        /// <br>Note       : </br>																	
        /// <br>Programmer : 朱宝軍</br>																	
        /// <br>Date       : 2009.04.01</br>																	
        [MustCustomSerialization]
        int SearchSecInfoSet(
            [CustomSerializationMethodParameterAttribute("PMKHN07007D", "Broadleaf.Application.Remoting.ParamData.PostSecInfoSetWork")]																	
			 out object ListRetWorkList, object ListParaWork);

    }																	

}
