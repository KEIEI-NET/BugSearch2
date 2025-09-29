//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信ログ表示
// プログラム概要   : 送信ログ表示DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2019/12/02  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 送信ログ表示DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 送信ログ表示DBインターフェースです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2019/12/02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalCprtSndLogDB
    {
        /// <summary>
        /// 売上データ送信ログテーブルのログ情報取得
        /// </summary>
        /// <param name="salCprtSndLogListResultWork">売上データ送信ログ抽出結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="salCprtSndLogListCondPara">売上データ送信ログ抽出条件パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchSalCprtSndLog(
            [CustomSerializationMethodParameterAttribute("PMSDC04007D", "Broadleaf.Application.Remoting.ParamData.SalCprtSndLogListResultWork")]
            out object salCprtSndLogListResultWork, 
            out string errMessage,
            ref object salCprtSndLogListCondPara,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// SE売上データ送信ログテーブルのログ情報を削除する
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2019/12/02</br>
        /// </remarks>
        int ResetSalCprtSndLog(
            out string errMessage,
            string enterpriseCode);

    }
}