//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル在庫仕入（入庫更新）リモートオブジェクト インターフェース
// プログラム概要   : ハンディターミナル在庫仕入（入庫更新）RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ハンディターミナル在庫仕入（入庫更新）リモートオブジェクト インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）リモートオブジェクト インターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/08/11</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyStockSupplierDB
    {
        #region [ハンディターミナル在庫仕入（入庫更新）_一覧抽出処理]
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_一覧抽出処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）_一覧情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        [MustCustomSerialization]
        int SearchStockSupplierList(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND01114D", "Broadleaf.Application.Remoting.ParamData.HandyUOEOrderListWork")]
            out object retListObj);
        #endregion

        #region [ハンディターミナル在庫仕入（入庫更新）_明細抽出処理]
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_明細抽出処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <br>Note       : ハンディターミナル在庫仕入（入庫更新）_明細を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        [MustCustomSerialization]
        int SearchHandyStockSupplierSlipNum(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND01114D", "Broadleaf.Application.Remoting.ParamData.HandyUOEOrderResultDtlWork")]
            out object retListObj);
        #endregion

        #region [ハンディターミナル在庫仕入（入庫更新）_登録処理]
        /// <summary>
        /// ハンディターミナル在庫仕入（入庫更新）_登録処理
        /// </summary>
        /// <param name="writeListObj">検品登録データ</param>
        /// <param name="uoeStcUpdDataList">登録用発注データ</param>
        /// <returns>登録結果ステータス</returns>
        /// <br>Note       : ハンディターミナルログイン情報を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        [MustCustomSerialization]
        int WriteStockSupplier(
            [CustomSerializationMethodParameterAttribute("PMHND01114D", "Broadleaf.Application.Remoting.ParamData.InspectDataAddWork")]
            ref object writeListObj,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object uoeStcUpdDataList);
        #endregion

        #region [ハンディターミナル在庫仕入(UOE以外)明細抽出処理]
        /// <summary>
        /// ハンディターミナル在庫仕入(UOE以外)明細抽出処理
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <br>Note       : ハンディターミナル在庫仕入(UOE以外)明細情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        [MustCustomSerialization]
        int SearchNonUOEStockSupplier(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("PMHND01114D", "Broadleaf.Application.Remoting.ParamData.HandyNonUOEStockResultWork")]
            out object retListObj);
        #endregion

        #region [ハンディターミナル在庫仕入(UOE以外)明細抽出処理（既存ワーク）]
        /// <summary>
        /// ハンディターミナル在庫仕入(UOE以外)全明細抽出処理（既存ワーク）
        /// </summary>
        /// <param name="condByte">検索条件</param>
        /// <param name="retListObj">検索結果</param>
        /// <returns>検索結果ステータス</returns>
        /// <br>Note       : ハンディターミナル在庫仕入(UOE以外)明細情報を抽出します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        [MustCustomSerialization]
        int SearchHandyNonUOESlipInfo(
            byte[] condByte,
            [CustomSerializationMethodParameterAttribute("DCHAT02113D", "Broadleaf.Application.Remoting.ParamData.OrderListResultWork")]
            out object retListObj);
        #endregion

        #region [ハンディターミナル在庫仕入（UOE以外）_登録処理]
        /// <summary>
        /// ハンディターミナル在庫仕入（UOE以外）_登録処理
        /// </summary>
        /// <param name="writeListObj">検品登録データ</param>
        /// <param name="uoeStcUpdDataList">登録用発注データ</param>
        /// <returns>登録結果ステータス</returns>
        /// <br>Note       : ハンディターミナルログイン情報を登録します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/08/11</br>
        [MustCustomSerialization]
        int WriteHandyStockData(
            [CustomSerializationMethodParameterAttribute("PMHND01114D", "Broadleaf.Application.Remoting.ParamData.HandyNonUOEInspectParamWork")]
            ref object writeListObj,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object uoeStcUpdDataList);
        #endregion

    }
}
