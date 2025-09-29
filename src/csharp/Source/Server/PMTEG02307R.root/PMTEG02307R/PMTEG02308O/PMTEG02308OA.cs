//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形期日別表DB RemoteObjectインターフェース
// プログラム概要   : 手形期日別表DB RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/5/5    修正内容 : 新規作成
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
    /// 手形期日別表 リモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形期日別表 リモート インターフェースです。</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010.05.05</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITegataKibiListReportResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 返品理由一覧データを戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="TegataKibiListReportResultWork">検索結果</param>
        /// <param name="TegataKibiListReportParaWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.05.05</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTEG02309D", "Broadleaf.Application.Remoting.ParamData.TegataKibiListReportResultWork")]
			out object tegataKibiListReportResultWork,
           object tegataKibiListReportParaWork);
        #endregion
    }
}
