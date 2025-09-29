//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカー・品番S＆E商品コード変換マスタメンテナンス
// プログラム概要   : メーカー・品番S＆E商品コード変換の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 寺田義啓
// 作 成 日  2020/02/20  修正内容 : 新規作成
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
    /// メーカー・品番S＆E商品コード変換マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : メーカー・品番S＆E商品コード変換マスタDBインターフェースです。</br>
    /// <br>Programmer : 寺田義啓</br>
    /// <br>Date       : 2020.02.20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISAndEMkrGdsCdChgSetDB
    {
        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報を物理削除します
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">SAndEMkrGdsCdChgWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタのキー値が一致するメーカー・品番S＆E商品コード変換マスタ情報を物理削除します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("PMSAE09046D", "Broadleaf.Application.Remoting.ParamData.SAndEMkrGdsCdChgWork")]
            ref object objectSAndEMkrGdsCdChgWork);

        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="outSAndEMkrGdsCdChgWorkList">検索結果</param>
        /// <param name="paraSAndEMkrGdsCdChgSetWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタのキー値が一致する、全てのメーカー・品番S＆E商品コード変換マスタ情報を取得します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMSAE09046D", "Broadleaf.Application.Remoting.ParamData.SAndEMkrGdsCdChgWork")]
            out object outSAndEMkrGdsCdChgWorkList, object paraSAndEMkrGdsCdChgSetWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報を追加・更新します。
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">追加・更新するメーカー・品番S＆E商品コード変換マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <param name="writeMode">更新区分</param>
        /// <br>Note       : SAndEMkrGdsCdChgWork に格納されているメーカー・品番S＆E商品コード変換マスタ情報を追加・更新します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMSAE09046D", "Broadleaf.Application.Remoting.ParamData.SAndEMkrGdsCdChgWork")]
            ref object objectSAndEMkrGdsCdChgWork, int writeMode);

        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報を論理削除します。
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">論理削除するメーカー・品番S＆E商品コード変換マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork に格納されているメーカー・品番S＆E商品コード変換マスタ情報を論理削除します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        [MustCustomSerialization]
        int LogicalDelete([CustomSerializationMethodParameterAttribute("PMSAE09046D", "Broadleaf.Application.Remoting.ParamData.SAndEMkrGdsCdChgWork")]
            ref object objectSAndEMkrGdsCdChgWork);

        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ情報の論理削除を解除します。
        /// </summary>
        /// <param name="objectSAndEMkrGdsCdChgWork">論理削除を解除するメーカー・品番S＆E商品コード変換マスタ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEMkrGdsCdChgWork に格納されているメーカー・品番S＆E商品コード変換マスタ情報の論理削除を解除します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete([CustomSerializationMethodParameterAttribute("PMSAE09046D", "Broadleaf.Application.Remoting.ParamData.SAndEMkrGdsCdChgWork")]
            ref object objectSAndEMkrGdsCdChgWork);
    }
}
