//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : S&E売上データテキスト出力
// プログラム概要   : S&E売上データテキスト出力帳票を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/08/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委  
// 修 正 日  2013/06/26  修正内容 : 送信ログの登録
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary> 売上データテキストDBインターフェース</summary>
    /// <br>Note       : 売上データテキストDBインターフェースです.</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.08.05</br>
    /// <br></br>
    /// <br>UpdateNote : 2013/06/26 田建委</br>
    /// <br>           : 送信ログの登録</br>
    /// <br>Update Note: </br>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesHistoryJoinWorkDB
    {
        /// <summary>
        /// 売上データテキスト情報リストの取得処理。
        /// </summary>
        /// <param name="salesHistoryResultWork">検索結果</param>
        /// <param name="salesHistoryCndtnWork">検索条件</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SE売上データテキストのキー値が一致する、全てのSE売上データテキスト情報を取得します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSAE02016D", "Broadleaf.Application.Remoting.ParamData.SalesHistoryJoinWork")]
            out object salesHistoryResultWork,
            object salesHistoryCndtnWork);

        /// <summary>
        /// SE売上データテキスト情報の追加・更新処理。
        /// </summary>
        /// <param name="objectsalesHistoryJoinWork">追加・更新するSE売上データテキスト情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork に格納されているSE売上データテキスト情報を追加・更新します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMSAE02016D", "Broadleaf.Application.Remoting.ParamData.SalesHistoryJoinWork")]
            ref object objectsalesHistoryJoinWork);

        // ----- ADD 田建委 2013/06/26 ----->>>>>
        /// <summary>
        /// SE売上データテキスト送信ログ情報の登録処理。
        /// </summary>
        /// <param name="objectSAndESalSndLogWork">登録するSE売上データテキスト送信ログ情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : objectSAndESalSndLogWork に格納されているSE売上データテキスト送信ログ情報を登録します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2013/06/26</br>
        [MustCustomSerialization]
        int WriteLog([CustomSerializationMethodParameterAttribute("PMSAE04007D", "Broadleaf.Application.Remoting.ParamData.SAndESalSndLogListResultWork")]
            ref object objectSAndESalSndLogWork);
        // ----- ADD 田建委 2013/06/26 -----<<<<<

    }
}
