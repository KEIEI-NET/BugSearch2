//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル棚卸DBリモートオブジェクトインターフェース//
// プログラム概要   : ハンディターミナル棚卸DBリモートオブジェクトインターフェースです//
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 陳艶丹
// 作 成 日  2017/08/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11570136-00 作成担当 : 岸
// 作 成 日  2019/11/13  修正内容 : ハンディ６次改良
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ハンディターミナル棚卸DBリモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル棚卸DBリモートオブジェクトインターフェースです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/08/16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyInventoryDataDB
    {
        #region [棚卸処理（一斉）]
        /// <summary>
        /// 棚卸処理(一斉)_棚卸対象確認処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸対象が存在しているかの確認を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchCount(object condObj);

        /// <summary>
        /// 棚卸処理(一斉)_棚卸対象取得処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <param name="refObj">検索结果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸対象と取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search( object condObj,
            [CustomSerializationMethodParameterAttribute("PMHND05504D", "Broadleaf.Application.Remoting.ParamData.HandyInventoryDataWork")]
            out object refObj);

        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// 棚卸処理(一斉)_棚卸対象取得処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <param name="refObj">検索结果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸対象と取得します。</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchHandy(object condObj,
            [CustomSerializationMethodParameterAttribute("PMHND05504D", "Broadleaf.Application.Remoting.ParamData.HandyInventoryDataWork")]
            out object refObj);
        // --- ADD 2019/11/13 ----------<<<<<

        /// <summary>
        /// 棚卸処理(一斉)_棚卸データ登録処理
        /// </summary>
        /// <param name="condObj">棚卸処理（一斉）登録データオブジェクト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸データ登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(object condObj);
        #endregion

        #region [棚卸処理(循環)]
        /// <summary>
        /// 棚卸処理(循環)_倉庫存在確認処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 倉庫データを検索します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchStockCount(
            byte[] condByte);

        /// <summary>
        /// 棚卸処理（循環)_在庫情報取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫情報を検索します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchStock(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND04104D", "Broadleaf.Application.Remoting.ParamData.HandyStockWork")]
            out object retObj);

        // --- ADD 2019/11/13 ---------->>>>>
        /// <summary>
        /// 棚卸処理（循環)_在庫情報取得処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retObj">検索結果</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫情報を検索します。</br>
        /// <br>Programmer : 岸</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchStockHandy(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND04104D", "Broadleaf.Application.Remoting.ParamData.HandyStockWork")]
            out object retObj);
        // --- ADD 2019/11/13 ----------<<<<<


        /// <summary>
        /// 棚卸処理（循環)_棚卸情報登録
        /// </summary>
        /// <param name="inventDataObj">棚卸処理（循環）登録データオブジェクト</param>
        /// <param name="inventorySeqNo">棚卸通番</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸情報を登録します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteCirculInvent(
            object inventDataObj,
            out int inventorySeqNo);
        #endregion

        #region  [循環棚卸照会]
        /// <summary>
        /// 循環棚卸照会データ抽出処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <param name="retObj">循環棚卸照会データ情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 循環棚卸照会データ抽出処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchCirculInventData(object condObj, out object retObj);
        #endregion
    }
}
