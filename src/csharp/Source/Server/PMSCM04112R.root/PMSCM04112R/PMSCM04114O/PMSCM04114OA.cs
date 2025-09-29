//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   同期状況確認 DBRemoteObjectインターフェース
//                  :   PMSCM04114O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   田建委
// Date             :   2014/08/01
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
// 管理番号  11070136-00  作成担当 : 田建委
// 作 成 日  2014/08/01   修正内容 : 新規作成
//----------------------------------------------------------------------
// Programmer       :   吉岡
//                  :   2014/07/14 SCM高速化
//----------------------------------------------------------------------
// 管理番号  11070136-00  作成担当 : 田建委
// 作 成 日  2014/09/03   修正内容 : Redmine#43408
//                                   ステータスが2、またMaxErrorCountまで到達していないものも取得する対応
//----------------------------------------------------------------------
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 同期状況確認 DBRemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期状況確認 DBRemoteObjectインターフェースです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2014/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISynchConfirmDB
    {
        /// <summary>
        /// 同期管理マスタの検索
        /// </summary>
        /// <param name="syncMngResultData">検索結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="param">検索条件</param>
        /// <param name="logicalMode">論理削除コード</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 同期管理マスタの検索を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// <br>Update Note: 2014/09/03 田建委</br>
        /// <br>管理番号   : 11070136-00 Redmine#43408</br>
        /// <br>           : ステータスが2、またMaxErrorCountまで到達していないものも取得する対応</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchSyncMngData(
            [CustomSerializationMethodParameterAttribute("PMSCM00217D", "Broadleaf.Application.Remoting.ParamData.SyncMngWork")]
            out object syncMngResultData,
            out string errMessage,
            object param,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// 同期要求データ件数の検索
        /// </summary>
        /// <param name="syncReqResultData">検索結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="param">検索条件</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 同期要求データ件数の検索を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int GetSyncReqDataCount(
            [CustomSerializationMethodParameterAttribute("PMSCM00216D", "Broadleaf.Application.Remoting.ParamData.SyncReqDataWork")]
            out object syncReqResultData,
            out string errMessage,
            object param);

        /// <summary>
        /// 同期要求エラー情報の取得
        /// </summary>
        /// <param name="syncReqResultData">検索結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="param">検索条件</param>
        /// <param name="maxRetryCount">最大再試行回数</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 同期要求エラー情報の取得を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchSyncReqErrData(
            [CustomSerializationMethodParameterAttribute("PMSCM00216D", "Broadleaf.Application.Remoting.ParamData.SyncReqDataWork")]
            out object syncReqResultData,
            out string errMessage,
            object param,
            int maxRetryCount);

        /// <summary>
        /// 作成日時により同期要求エラー情報の取得
        /// </summary>
        /// <param name="syncReqResultData">検索結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="maxRetryCount">最大再試行回数</param> // ADD 2014/09/03 田建委 Redmine#43408
        /// <param name="param">検索条件</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 同期要求データの検索を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// <br>Update Note: 2014/09/03 田建委</br>
        /// <br>管理番号   : 11070136-00 Redmine#43408</br>
        /// <br>           : ステータスが2、またMaxErrorCountまで到達していないものも取得する対応</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchSyncReqErrDataByCreateDateTime(
            [CustomSerializationMethodParameterAttribute("PMSCM00216D", "Broadleaf.Application.Remoting.ParamData.SyncReqDataWork")]
            out object syncReqResultData,
            out string errMessage,
            int maxRetryCount, // ADD 2014/09/03 田建委 Redmine#43408
            object param);

        // ADD 2014/07/14 SCM高速化 吉岡  -------------->>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 初期同期完了判断
        /// </summary>
        /// <returns>true：同期済み false：同期未実施</returns>
        [MustCustomSerialization]
        bool SyncMngDataExists();
        // ADD 2014/07/14 SCM高速化 吉岡  --------------<<<<<<<<<<<<<<<<<<
    }
}
