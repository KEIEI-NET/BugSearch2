//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　担当者マスタコード変換インターフェース
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2016/03/10  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PM.NS統合ツール　担当者マスタコード変換インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの担当者マスタコード変換インターフェースです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEmployeeConvertDB
    {
        /// <summary>
        /// 担当者マスタのリストを取得します。
        /// </summary>
        /// <param name="employeePrmObj">検索条件</param>
        /// <param name="employeeRetObjList">検索結果</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に担当者マスタのリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        int Search(
            [CustomSerializationMethodParameter("PMKHN05117D", "Broadleaf.Application.Remoting.ParamData.EmployeeSearchParamWork")]
            object employeePrmObj,
            [CustomSerializationMethodParameter("PMKHN05117D", "Broadleaf.Application.Remoting.ParamData.EmployeeSearchWork")]
            ref object employeeRetObjList
            );

        /// <summary>
        /// コード変換処理
        /// </summary>
        /// <param name="employeeConvertPrmObj">変換条件</param>
        /// <param name="numberOfTransactions">処理件数を格納した変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に担当者コードを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        int Convert(
            [CustomSerializationMethodParameter("PMKHN05117D", "Broadleaf.Application.Remoting.ParamData.EmployeeConvertParamInfoList")]
            object employeeConvertPrmObj,
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
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        int GetConvertTableList(
            ref object targetTableList
            );
    }
}
