//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上データテキスト出力 DBRemoteObjectインターフェース
// プログラム概要   : 売上データテキスト出力を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11370098-00  作成担当 : 陳艶丹
// 作 成 日  2017/11/20   修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary> 
    /// 売上データテキストDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上データテキストDBインターフェースです.</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/11/20</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEDISalesResultDB
    {
        #region Search
        /// <summary>
        /// 売上データテキスト情報リストの取得処理。
        /// </summary>
        /// <param name="eDISalesResultObj">検索結果</param>
        /// <param name="eDISalesCndtnObj">検索条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 売上データテキストのキー値が一致する、全ての売上データテキスト情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMEDI02016D", "Broadleaf.Application.Remoting.ParamData.EDISalesResultWork")]
            out object eDISalesResultObj,
           object eDISalesCndtnObj);
        #endregion

        #region Write
        /// <summary>
        /// 売上データテキスト情報の追加・更新処理。
        /// </summary>
        /// <param name="eDISalesResultWorkObj">追加・更新する売上データテキスト情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDISalesResultWork に格納されている売上データテキスト情報を追加・更新します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMEDI02016D", "Broadleaf.Application.Remoting.ParamData.EDISalesResultWork")]
            ref object eDISalesResultWorkObj);
        #endregion

    }
}
