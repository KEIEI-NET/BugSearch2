//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　倉庫マスタコード変換インターフェース
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/02/18  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PM.NS統合ツール　倉庫マスタコード変換インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの倉庫マスタコード変換インターフェースです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IWarehouseConvertDB
    {
        /// <summary>
        /// 倉庫マスタのリストを取得します。
        /// </summary>
        /// <param name="warehousePrmObj">検索条件</param>
        /// <param name="warehouseRetObjList">検索結果</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に倉庫マスタのリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN05107D", "Broadleaf.Application.Remoting.ParamData.WarehouseSearchParamWork")]
            object warehousePrmObj,
            [CustomSerializationMethodParameterAttribute("PMKHN05107D", "Broadleaf.Application.Remoting.ParamData.WarehouseSearchWork")]
            ref object warehouseRetObjList
            );

        /// <summary>
        /// コード変換処理
        /// </summary>
        /// <param name="warehouseConvertPrmObj">変換条件</param>
        /// <param name="numberOfTransactions">処理件数を格納した変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に倉庫コードを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        int Convert(
            [CustomSerializationMethodParameterAttribute("PMKHN05107D", "Broadleaf.Application.Remoting.ParamData.WarehouseConvertPrmInfoList")]
            object warehouseConvertPrmObj,
            ref long numberOfTransactions
            );

        /// <summary>
        /// コード変換対象テーブルリスト取得処理
        /// </summary>
        /// <param name="targetTableList">コード変換対象テーブルリスト</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : コード変換対象のテーブルのリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        int GetConvertTableList(
            ref object targetTableList
            );
    }
}
