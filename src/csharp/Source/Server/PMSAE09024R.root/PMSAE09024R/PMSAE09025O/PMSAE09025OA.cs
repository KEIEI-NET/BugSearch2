//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オートバックス商品コード変換マスタメンテナンス
// プログラム概要   : 商品コード変換の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/08/05  修正内容 : 新規作成
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
    /// オートバックス商品コード変換マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : オートバックス商品コード変換マスタDBインターフェースです。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.08.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISAndEGoodsCdChgSetDB
    {
        /// <summary>
        /// オートバックス商品コード変換マスタ情報を物理削除します
        /// </summary>
        /// <param name="objectSAndEGoodsCdChgWork">SAndEGoodsCdChgWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品コード変換マスタのキー値が一致する商品コード変換マスタ情報を物理削除します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMSAE09026D", "Broadleaf.Application.Remoting.ParamData.SAndEGoodsCdChgWork")]
            ref object objectSAndEGoodsCdChgWork);

        /// <summary>
        /// オートバックス商品コード変換マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outSAndEGoodsCdChgWorkList">検索結果</param>
        /// <param name="paraSAndEGoodsCdChgSetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品コード変換マスタのキー値が一致する、全ての商品コード変換マスタ情報を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMSAE09026D", "Broadleaf.Application.Remoting.ParamData.SAndEGoodsCdChgWork")]
            out object outSAndEGoodsCdChgWorkList, object paraSAndEGoodsCdChgSetWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// オートバックス商品コード変換マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="objectsAndEGoodsCdChgWork">追加・更新する商品コード変換マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <param name="writeMode">更新区分</param>
        /// <br>Note       : SAndEGoodsCdChgWork に格納されている商品コード変換マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMSAE09026D", "Broadleaf.Application.Remoting.ParamData.SAndEGoodsCdChgWork")]
            ref object objectsAndEGoodsCdChgWork, int writeMode);

        /// <summary>
        /// オートバックス商品コード変換マスタ情報を論理削除します。
        /// </summary>
        /// <param name="objectsAndEGoodsCdChgWork">論理削除する商品コード変換マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork に格納されている商品コード変換マスタ情報を論理削除します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMSAE09026D", "Broadleaf.Application.Remoting.ParamData.SAndEGoodsCdChgWork")]
            ref object objectsAndEGoodsCdChgWork);

        /// <summary>
        /// オートバックス商品コード変換マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="objectsAndEGoodsCdChgWork">論理削除を解除する商品コード変換マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork に格納されている商品コード変換マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMSAE09026D", "Broadleaf.Application.Remoting.ParamData.SAndEGoodsCdChgWork")]
            ref object objectsAndEGoodsCdChgWork);
    }
}
