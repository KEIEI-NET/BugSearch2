//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　得意先マスタコード変換インターフェース
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/23  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PM.NS統合ツール　得意先マスタコード変換インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの得意先マスタコード変換インターフェースです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustomerConvertDB
    {
        /// <summary>
        /// 得意先マスタのリストを取得します。
        /// </summary>
        /// <param name="customerPrmObj">検索条件</param>
        /// <param name="customerRetObjList">検索結果</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に得意先マスタのリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        int Search(
            [CustomSerializationMethodParameter("PMKHN05127D", "Broadleaf.Application.Remoting.ParamData.CustomerSearchParamWork")]
            object customerPrmObj,
            [CustomSerializationMethodParameter("PMKHN05127D", "Broadleaf.Application.Remoting.ParamData.CustomerSearchWork")]
            ref object customerRetObjList
            );

        /// <summary>
        /// コード変換処理
        /// </summary>
        /// <param name="customerConvertPrmObj">変換条件</param>
        /// <param name="numberOfTransactions">処理件数を格納した変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に得意先コードを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        int Convert(
            [CustomSerializationMethodParameter("PMKHN05127D", "Broadleaf.Application.Remoting.ParamData.CustomerConvertParamInfoList")]
            object customerConvertPrmObj,
            ref int numberOfTransactions
            );

        /// <summary>
        /// コード変換対象テーブルリスト取得処理
        /// </summary>
        /// <param name="targetTableList">コード変換対象テーブルリスト</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : コード変換対象のテーブルのリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        int GetConvertTableList(
            ref object targetTableList
            );
    }
}
