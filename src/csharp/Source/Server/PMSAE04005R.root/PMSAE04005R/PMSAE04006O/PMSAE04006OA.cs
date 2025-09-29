//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 送信ログ表示
// プログラム概要   : 送信ログ表示DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhaimm
// 作 成 日  2013.06.26  修正内容 : 新規作成
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
    /// <br>Programmer : zhaimm</br>
    /// <br>Date       : 2013.06.26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISAndESalSndLogDB
    {
        /// <summary>
        /// 売上データ送信ログテーブルのログ情報取得
        /// </summary>
        /// <param name="sAndESalSndLogListResultWork">売上データ送信ログ抽出結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="sAndESalSndLogListCondPara">売上データ送信ログ抽出条件パラメータ</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchSAndESalSndLog(
            [CustomSerializationMethodParameterAttribute("PMSAE04007D", "Broadleaf.Application.Remoting.ParamData.SAndESalSndLogListResultWork")]
            out object sAndESalSndLogListResultWork, 
            out string errMessage, 
            ref object sAndESalSndLogListCondPara,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// SE売上データ送信ログテーブルのログ情報を削除する
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Programmer : zhaimm</br>
        /// <br>Date       : 2013.06.26</br>
        /// </remarks>
        int ResetSAndESalSndLog(
            out string errMessage,
            string enterpriseCode);

    }
}