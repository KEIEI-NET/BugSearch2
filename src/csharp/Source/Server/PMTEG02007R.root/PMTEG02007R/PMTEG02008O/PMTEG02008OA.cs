//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形確認表DB RemoteObjectインターフェース
// プログラム概要   : 手形確認表DB RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/05/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 手形確認表 リモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形確認表 リモート インターフェースです。</br>
    /// <br>Programmer : 張義</br>
    /// <br>Date       : 2010.05.05</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITegataConfirmReportResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 返品理由一覧データを戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="tegataConfirmReportResultWork">検索結果</param>
        /// <param name="tegataConfirmReportParaWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 張義</br>
        /// <br>Date       : 2010.05.05</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTEG02009D", "Broadleaf.Application.Remoting.ParamData.TegataConfirmReportResultWork")]
			out object tegataConfirmReportResultWork,
           object tegataConfirmReportParaWork);
        #endregion
    }
}
