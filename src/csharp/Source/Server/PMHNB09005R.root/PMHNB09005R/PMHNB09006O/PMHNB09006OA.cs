//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタメンテナンス
// プログラム概要   : 表示区分マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/10/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
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
    /// 表示区分マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 表示区分マスタDBインターフェースです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.10.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPriceSelectSetDB
    {
        /// <summary>
        /// 表示区分マスタ情報を物理削除します
        /// </summary>
        /// <param name="parabyte">PriceSelectSetWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 表示区分マスタのキー値が一致する表示区分マスタ情報を物理削除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMHNB09007D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork")]
            ref object parabyte);

        /// <summary>
        /// 表示区分マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outPriceSelectSetList">検索結果</param>
        /// <param name="paraPriceSelectSetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 企業コードマスタのキー値が一致する、全ての表示区分マスタ情報を取得します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMHNB09007D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork")]
            out object outPriceSelectSetList, object paraPriceSelectSetWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 表示区分マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="PriceSelectSetWorkbyte">追加・更新する表示区分マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <param name="writeMode">更新区分</param>
        /// <br>Note       : PriceSelectSetWork に格納されている表示区分マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMHNB09007D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork")]
            ref object PriceSelectSetWorkbyte, int writeMode);

        /// <summary>
        /// 表示区分マスタ情報を論理削除します。
        /// </summary>
        /// <param name="priceSelectSetWork">論理削除する表示区分マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PriceSelectSetWork に格納されている表示区分マスタ情報を論理削除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMHNB09007D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork")]
            ref object priceSelectSetWork);

        /// <summary>
        /// 表示区分マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="priceSelectSetWork">論理削除を解除する表示区分マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PriceSelectSetWork に格納されている表示区分マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.16</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMHNB09007D", "Broadleaf.Application.Remoting.ParamData.PriceSelectSetWork")]
            ref object priceSelectSetWork);
    }
}
