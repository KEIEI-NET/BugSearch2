//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品予定一覧表
// プログラム概要   : 仕入返品予定一覧表 DBRemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI高橋 文彰
// 作 成 日   2013/01/28 修正内容 : 新規作成 仕入返品予定機能対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入返品予定一覧表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入返品予定一覧表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : FSI高橋 文彰</br>
    /// <br>Date       :  2013/01/28</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockRetPlnTableDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 仕入返品予定一覧表LISTを全て戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="StockRetPlnList">検索結果</param>
        /// <param name="stockRetPlnParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI高橋 文彰</br>
        /// <br>Date       :  2013/01/28</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKAK02039D", "Broadleaf.Application.Remoting.ParamData.StockRetPlnList")]
			out object StockRetPlnList,
            object stockRetPlnParamWork);
        #endregion
    }
}
