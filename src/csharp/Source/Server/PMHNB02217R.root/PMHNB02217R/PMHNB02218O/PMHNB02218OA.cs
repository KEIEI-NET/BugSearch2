//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 返品理由一覧表DB RemoteObjectインターフェース
// プログラム概要   : 返品理由一覧表DB RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/05/11  修正内容 : 新規作成
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
    /// 返品理由一覧表 リモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 返品理由一覧表 リモート インターフェースです。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.05.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRetGoodsReasonReportResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 返品理由一覧データを戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="retGoodsReasonReportResultWork">検索結果</param>
        /// <param name="retGoodsReasonReportParaWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.05.11</br>

        int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB02219D", "Broadleaf.Application.Remoting.ParamData.RetGoodsReasonReportResultWork")]
			out object retGoodsReasonReportResultWork,
           object retGoodsReasonReportParaWork);
        #endregion
    }
}
