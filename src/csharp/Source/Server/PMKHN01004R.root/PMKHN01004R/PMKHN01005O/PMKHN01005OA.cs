//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データクリア処理
// プログラム概要   : データクリア処理DB RemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/06/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// データクリア処理DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : データクリア処理DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.06.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IDataClearDB
    {
        #region データクリア処理の実行処理
        /// <summary>
        /// データクリア処理を行う
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="delYM">削除年月</param>
        /// <param name="delYMD">削除年月開始日</param>
        /// <param name="dataClearList">データクリアリスト</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.16</br>
        [MustCustomSerialization]
        int Clear(
            string enterpriseCode,
            Int32 delYM,
            Int32 delYMD,
            [CustomSerializationMethodParameterAttribute("PMKHN01006D", "Broadleaf.Application.Remoting.ParamData.DataClearWork")]
            ref object dataClearList,
            out string errMsg);
        #endregion

        #region 処理コード＝9：価格改正履歴データクリア（提供データ削除処理用）
        /// <summary>
        /// 処理コード＝9：価格改正履歴データクリア（提供データ削除処理用）
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 処理コード＝9：価格改正履歴データクリアの処理（提供データ削除処理用）</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.06.18</br>
        int ClearDataByCode9(string enterpriseCode);
        #endregion
    }
}
