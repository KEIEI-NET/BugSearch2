//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール　拠点コード変換インターフェース
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11200041-00 作成担当 : 宮津
// 修 正 日  2017/12/15  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PM.NS統合ツール　拠点コード変換インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツールの拠点コード変換インターフェースです。</br>
    /// <br>Programmer : 30365 宮津</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISectionConvertDB
    {
        /// <summary>
        /// 拠点のリストを取得します。
        /// </summary>
        /// <param name="sectionPrmObj">検索条件</param>
        /// <param name="sectionRetObjList">検索結果</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に拠点のリストを取得します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN05137D", "Broadleaf.Application.Remoting.ParamData.SectionSearchParamWork")]
            object sectionPrmObj,
            [CustomSerializationMethodParameterAttribute("PMKHN05137D", "Broadleaf.Application.Remoting.ParamData.SectionSearchWork")]
            ref object sectionRetObjList
            );

        /// <summary>
        /// コード変換処理
        /// </summary>
        /// <param name="sectionConvertPrmObj">変換条件</param>
        /// <param name="numberOfTransactions">処理件数を格納した変数</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面で指定した条件を元に拠点コードを変換します。</br>
        /// <br>Programmer : 30365 宮津</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        int Convert(
            [CustomSerializationMethodParameterAttribute("PMKHN05137D", "Broadleaf.Application.Remoting.ParamData.SectionConvertPrmInfoList")]
            object sectionConvertPrmObj,
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
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        int GetConvertTableList(
            ref object targetTableList
            );
    }
}
