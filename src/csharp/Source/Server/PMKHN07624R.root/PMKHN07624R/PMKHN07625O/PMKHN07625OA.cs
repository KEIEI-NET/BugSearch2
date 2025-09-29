//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TBO検索マスタ（インポート）
// プログラム概要   : TBO検索マスタ（インポート）DBインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/15  修正内容 : 新規作成
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
    /// TBO検索マスタ（インポート）DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : TBO検索マスタ（インポート）DBインターフェースです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITBOSearchUImportDB
    {
        /// <summary>
        /// TBO検索マスタ（インポート）のインポート処理。
        /// </summary>
        /// <param name="processKbn">処理区分</param>
        /// <param name="importWorkList">インポートデータリスト</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="addCnt">追加件数</param>
        /// <param name="updCnt">処理件数</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : TBO検索マスタ（インポート）のインポート処理を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.15</br>
        [MustCustomSerialization]
        int Import(
            Int32 processKbn,
            [CustomSerializationMethodParameterAttribute("PMKEN09116D", "Broadleaf.Application.Remoting.ParamData.TBOSearchUWork")]
            ref object importWorkList,
            out Int32 readCnt,
            out Int32 addCnt,
            out Int32 updCnt,
            out string errMsg);

    }
}
