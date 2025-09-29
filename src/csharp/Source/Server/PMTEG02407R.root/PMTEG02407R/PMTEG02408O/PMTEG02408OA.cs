//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形月別予定表DB RemoteObjectインターフェース
// プログラム概要   : 手形月別予定表DB RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 姜凱
// 作 成 日  2010/05/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 手形月別予定表 リモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形月別予定表 リモート インターフェースです。</br>
    /// <br>Programmer : 姜凱</br>
    /// <br>Date       : 2010.05.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITegataTsukibetsuYoteListReportResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 返品理由一覧データを戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="tegataTorihikisakiListReportResultWork">検索結果</param>
        /// <param name="tegataTorihikisakiListReportParaWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 姜凱</br>
        /// <br>Date       : 2010.05.05</br>
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTEG02409D", "Broadleaf.Application.Remoting.ParamData.TegataTsukibetsuYoteListReportResultWork")]
			out object tegataTorihikisakiListReportResultWork,
           object tegataTorihikisakiListReportParaWork);
        #endregion
    }
}
