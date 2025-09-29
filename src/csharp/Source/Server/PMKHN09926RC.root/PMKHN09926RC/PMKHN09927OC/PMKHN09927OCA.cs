//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品テキスト変換DBインターフェースクラス
// プログラム概要   : 商品テキスト変換DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10802197-00  作成担当 : FSI菅原 庸平
// 作 成 日  K2012/05/28  修正内容 : 新規作成 山形部品個別対応
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 商品テキスト変換DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品テキスト変換DBインターフェースです。</br>
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : K2012/05/28</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsUMasDB
    {
　      /// <summary>
        /// 商品テキスト明細情報のリストを取得します。
        /// </summary>
        /// <param name="outList">検索結果</param>
        /// <param name="paraWork">検索条件</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除区分(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 商品テキストのキー値が一致する、全ての商品テキスト明細情報を取得します。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : K2012/05/28</br>
        [MustCustomSerialization]
        int Search([CustomSerializationMethodParameterAttribute("PMKHN09928DC", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
                   out object outList, object paraWork, int readMode, ConstantManagement.LogicalMode logicalMode);

    }
}