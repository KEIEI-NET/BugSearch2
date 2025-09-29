//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形明細表DB RemoteObjectインターフェース
// プログラム概要   : 手形明細表DB RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/4/28  修正内容 : 新規作成
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
    /// 手形明細表 リモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形明細表 リモート インターフェースです。</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010.04.28</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITegataMeisaiListReportResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 返品理由一覧データを戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="tegataMeisaiListReportResultWork">検索結果</param>
        /// <param name="tegataMeisaiListReportParaWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.28</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTEG02109D", "Broadleaf.Application.Remoting.ParamData.TegataMeisaiListReportResultWork")]
			out object tegataMeisaiListReportResultWork,
           object tegataMeisaiListReportParaWork);
        #endregion
    }
}
