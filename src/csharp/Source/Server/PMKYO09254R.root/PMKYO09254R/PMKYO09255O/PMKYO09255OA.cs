//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理接続先設定マスタメンテナンス
// プログラム概要   : 拠点管理接続先設定マスタの登録・変更を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 接続先設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 接続先設定マスタDBインターフェースです。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.04.23</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISecMngConnectStDB
    {
        /// <summary>
        /// 接続先設定マスタのリストを取得します。
        /// </summary>
        /// <remarks>
        /// <param name="outSecMngConnectStWorkList">検索結果</param>
        /// <param name="paraSecMngConnectStWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 接続先設定マスタのキー値が一致する、全ての発注点設定マスタ情報を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMKYO09256D", "Broadleaf.Application.Remoting.ParamData.SecMngConnectStWork")]
                  out object outSecMngConnectStWorkList, object paraSecMngConnectStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 接続先設定マスタ情報を追加・更新します。
        /// </summary>
        /// <remarks>
        /// <param name="objSecMngConnectStWork">SecMngConnectStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 接続先設定マスタを追加・更新します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMKYO09256D", "Broadleaf.Application.Remoting.ParamData.SecMngConnectStWork")]
            ref object objSecMngConnectStWork);

        /// <summary>
        /// サーバー用接続先更新処理
        /// </summary>
        /// <remarks>
        /// <param name="objSecMngConnectStWork">SecMngConnectStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : サーバー用接続先を更新します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.23</br>
        /// </remarks>
        [MustCustomSerialization]
        int UpdateRegistryKeyValue([CustomSerializationMethodParameterAttribute("PMKYO09256D", "Broadleaf.Application.Remoting.ParamData.SecMngConnectStWork")]
            ref object objSecMngConnectStWork);
    }
}
