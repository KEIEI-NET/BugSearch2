//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   同期実行管理 DBRemoteObjectインターフェース
//                  :   PMSCM00212O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   田建委
// Date             :   2014/08/01
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 同期実行管理 DBRemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 同期実行管理 DBRemoteObjectインターフェースです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2014/08/01</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISynchExecuteMngDB
    {
        /// <summary>
        /// 最大再試行回数の取得処理
        /// </summary>
        /// <param name="maxRetryCount">最大再試行回数</param>
        /// <remarks>
        /// <br>Note       : 最大再試行回数の取得処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        void GetMaxRetryCount(out int maxRetryCount);

        /// <summary>
        /// 指定テーブル同期要求処理
        /// </summary>
        /// <param name="enterpriceCode">企業コード</param>
        /// <param name="tableIDList">テーブル名（複数）</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 指定テーブル同期要求処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        int SyncReqExecuteForTable(string enterpriceCode, object tableIDList);

        /// <summary>
        /// 同期要求再開処理
        /// </summary>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 同期要求再開処理を行う。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        int SyncReqReExecute();

        /// <summary>
        /// 変換開始要求処理
        /// </summary>
        /// <remarks>
        /// </remarks>
        void TranslateExecute();

        /// <summary>
        /// 定期起動処理
        /// </summary>
        /// <param name="syncServUrl"></param>
        void RegularStart(string syncServUrl);
    }
}
