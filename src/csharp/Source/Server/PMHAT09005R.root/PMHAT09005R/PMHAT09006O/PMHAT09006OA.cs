//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 発注点設定マスタメンテナンス
// プログラム概要   : 発注点設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/03/31  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 発注点設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 発注点設定マスタDBインターフェースです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.04.08</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IOrderPointStDB
    {
        /// <summary>
        /// 発注点設定マスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outOrderPointStList">検索結果</param>
        /// <param name="paraOrderPointStWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 発注点設定マスタのキー値が一致する、全ての発注点設定マスタ情報を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.03.27</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork")]
                  out object outOrderPointStList, object paraOrderPointStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 発注点設定マスタ情報を追加・更新します。
        /// </summary>
        /// <remarks>
        /// <param name="orderPointStList">OrderPointWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 発注点設定マスタを追加・更新します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.09</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork")]
            ref object orderPointStList);

        /// <summary>
        /// 発注点設定マスタ情報を論理削除します。
        /// </summary>
        /// <remarks>
        /// <param name="orderPointStList">OrderPointWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 発注点設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork")]
            ref object orderPointStList);

        /// <summary>
        /// 論理削除発注点設定マスタ情報情報を復活します
        /// </summary>
        /// <remarks>
        /// <param name="objOrderPointStList">EmpSalesTargetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 論理削除発注点設定マスタ情報情報を復活します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork")]
            ref object objOrderPointStList);

        /// <summary>
        /// 発注点設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="orderPointStList">OrderPointWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 発注点設定マスタ情報を物理削除します</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMHAT09007D", "Broadleaf.Application.Remoting.ParamData.OrderPointStWork")]
            ref object orderPointStList);
    }
}
