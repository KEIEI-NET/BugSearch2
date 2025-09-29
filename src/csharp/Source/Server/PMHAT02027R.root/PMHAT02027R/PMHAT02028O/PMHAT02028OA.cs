//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタリスト一覧表DB RemoteObjectインターフェース
// プログラム概要   : 発注点設定マスタリスト一覧表DB RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/04/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 発注点設定マスタリスト一覧表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定マスタリスト一覧表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.03.27</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IOrderSetMasListDB
    {

        /// <summary>
        /// 発注点設定マスタリスト一覧表LISTを全て戻します論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="orderSetMasListWork">検索結果</param>
        /// <param name="orderSetMasListParaWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 全て一元化配信制御のデータの取得処理を行う。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHAT02029D", "Broadleaf.Application.Remoting.ParamData.OrderSetMasListWork")]
            out object orderSetMasListWork, ref object orderSetMasListParaWork);
    }
}

