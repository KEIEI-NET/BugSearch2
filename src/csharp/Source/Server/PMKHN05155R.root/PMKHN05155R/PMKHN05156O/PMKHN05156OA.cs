//**************************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM.NS統合ツール 伝票番号変換インターフェース
// プログラム概要   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//=====================================================================================//
// 履歴
//-------------------------------------------------------------------------------------//
// 管理番号  11470153-00 作成担当 : 倉内
// 修 正 日  2018/09/07  修正内容 : 新規作成
//-------------------------------------------------------------------------------------//
using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PM.NS統合ツール　伝票番号変換インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS統合ツール伝票番号変換インターフェースです。</br>
    /// <br>Programmer : 30175 倉内</br>
    /// <br>Date       : 2018/09/07</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISlipNoConvertDB
    {
        /// <summary>
        /// 伝票番号変換対象テーブルリスト取得処理
        /// </summary>
        /// <param name="secDiv">拠点区分（0：全社、1：拠点）</param>
        /// <param name="targetTableList">伝票番号変換対象テーブルリスト</param>
        /// <returns>処理ステータス</returns>
        /// <remarks>
        /// <br>Note       : 伝票番号変換対象のテーブルのリストを取得します。</br>
        /// <br>Programmer : 30175 倉内</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        int GetTargetTableList(int secDiv, ref object targetTableList);

        
        /// <summary>
        /// 伝票番号変換前チェック処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="slipNoCnvPrm">変更データ</param>
        /// <param name="check">チェック結果</param>
        /// <returns>処理ステータス</returns>
        int CheckConvertSlipNo(string enterpriseCode, 
            [CustomSerializationMethodParameterAttribute("PMKHN05157D", "Broadleaf.Application.Remoting.ParamData.SlipNoConvertPrmInfoList")] object slipNoCnvPrm,
            ref bool check
            );


        /// <summary>
        /// 伝票番号変換処理
        /// </summary>
        /// <param name="enterprise">企業コード</param>
        /// <param name="slipNoCnvPrm">変更データ</param>
        /// <param name="numberOfTransactions">処理件数を格納した変数</param>
        /// <returns></returns>
        int ConvertSlipNo(string enterprise,
            [CustomSerializationMethodParameterAttribute("PMKHN05157D", "Broadleaf.Application.Remoting.ParamData.SlipNoConvertPrmInfoList")] object slipNoCnvPrm,
            ref long numberOfTransactions
            );
    }
}
