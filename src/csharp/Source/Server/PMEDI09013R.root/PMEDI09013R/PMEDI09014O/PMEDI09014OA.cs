//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : EDI連携設定マスタリモートオブジェクトインターフェース
// プログラム概要   : EDI連携設定マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 管理番号  11370098-00  作成担当 : 陳艶丹
// 作 成 日  2017/11/16   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// EDI連携設定マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : EDI連携設定マスタDBインターフェースです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/11/16</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEDICooperatStDB
    {
        /// <summary>
        /// EDI連携設定マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">EDICooperatStWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDI連携設定マスタのキー値が一致するEDI連携設定マスタ情報を物理削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(object parabyte);

        /// <summary>
        /// EDI連携設定マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="paraObj">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="refObj">検索結果</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 企業コードマスタのキー値が一致する、全てのEDI連携設定マスタ情報を取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMEDI09015D", "Broadleaf.Application.Remoting.ParamData.EDICooperatStWork")]
            object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, out object refObj);

        /// <summary>
        /// EDI連携設定マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="eDICooperatStWork">追加・更新するEDI連携設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDICooperatStWork に格納されているEDI連携設定マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMEDI09015D", "Broadleaf.Application.Remoting.ParamData.EDICooperatStWork")]
            ref object eDICooperatStWork);

        /// <summary>
        /// EDI連携設定マスタ情報を論理削除します。
        /// </summary>
        /// <param name="eDICooperatStWork">論理削除するEDI連携設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDICooperatStWork に格納されているEDI連携設定マスタ情報を論理削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMEDI09015D", "Broadleaf.Application.Remoting.ParamData.EDICooperatStWork")]
            ref object eDICooperatStWork);

        /// <summary>
        /// EDI連携設定マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="eDICooperatStWork">論理削除を解除するEDI連携設定マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : EDICooperatStWork に格納されているEDI連携設定マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/11/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMEDI09015D", "Broadleaf.Application.Remoting.ParamData.EDICooperatStWork")]
            ref object eDICooperatStWork);
    }
}
