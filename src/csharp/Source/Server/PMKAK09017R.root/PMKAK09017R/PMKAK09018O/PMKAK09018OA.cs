//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先総括マスタ一覧表DB RemoteObjectインターフェース
// プログラム概要   : 仕入先総括マスタ一覧表DB RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI菅原　要
// 作 成 日  2012/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 仕入先総括マスタ一覧表 リモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 仕入先総括マスタ一覧表 リモート インターフェースです。</br>
    /// <br>Programmer : FSI菅原　要</br>
    /// <br>Date       : 2012/09/07</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumSuppStPrintResultDB
    {
        #region [カスタムシリアライズ対応メソッド]
        /// <summary>
        /// 仕入先総括マスタ一覧表データを戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="SumSuppStPrintResultWork">検索結果</param>
        /// <param name="SumSuppStPrintParaWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI菅原　要</br>
        /// <br>Date       : 2012/09/07</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKAK09019D", "Broadleaf.Application.Remoting.ParamData.SumSuppStPrintResultWork")]
			out object SumSuppStPrintResultWork,
            object     SumSuppStPrintParaWork);
        #endregion
    }
}
