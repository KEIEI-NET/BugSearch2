//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品価格マスタ展開DB RemoteObjectインターフェース
// プログラム概要   : 部品価格マスタ展開DB RemoteObjectインターフェースを管理する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : huangqb
// 作 成 日  K2011/07/14 作成内容 : イスコ個別対応
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : huangqb
// 修 正 日  K2011/08/20 修正内容 : イスコ個別対応
//                       Redmine23619対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources; // ADD K2011/08/20
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 部品価格マスタ展開DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 部品価格マスタ展開DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : huangqb</br>
    /// <br>Date       : K2011/07/14</br>
    /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
    /// <br></br>
    /// <br>Note       : 「Sytem.OutOfMemoryException」障害対応</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : K2013/04/09</br>
    /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
    /// <br></br>
    /// 
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICostExpandDB
    {
        // ----- ADD K2011/08/20 --------------------------->>>>>
        /// <summary>
        /// ユーザー商品マスタと価格マスタのみ取得処理
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ユーザー商品マスタと価格マスタのみを取得します。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/08/20</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int UsrGoodsOnlySearch([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]out object retObj, 
                               object paraObj, 
                               int readMode, 
                               ConstantManagement.LogicalMode logicalMode);
        // ----- ADD K2011/08/20 ---------------------------<<<<<

        /// <summary>
        /// 部品価格マスタ展開処理
        /// </summary>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="retObj">検索結果</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 部品価格マスタ展開を行います。</br>
        /// <br>Programmer : huangqb</br>
        /// <br>Date       : K2011/07/14</br>
        /// <br>管理番号   : 10703874-00 イスコ個別対応</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int CostExpand(object paraObj,
                       [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]out object retObj);

        // --- ADD K2013/04/05 Y.Wakita ---------->>>>>
        /// <summary>
        /// 掛率設定マスタを論理削除します
        /// </summary>
        /// <param name="paraObj">RateWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 掛率設定マスタを論理削除します</br>
        /// <br>Programmer : 脇田　靖之</br>
        /// <br>Date       : K2013/04/05</br>
        [MustCustomSerialization]
        int LogicalDelete(
			ref object paraObj
            );
        // --- ADD K2013/04/05 Y.Wakita ----------<<<<<
    }
}
