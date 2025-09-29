//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 当月車検車両一覧表DB RemoteObjectインターフェース
// プログラム概要   : 当月車検車両一覧表DB RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 薛祺
// 作 成 日  2010/04/21  修正内容 : 新規作成
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
    /// 当月車検車両一覧 リモートオブジェクトインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 当月車検車両一覧 リモート インターフェースです。</br>
    /// <br>Programmer : 薛祺</br>
    /// <br>Date       : 2010.04.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IMonthCarInspectListResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 当月車検車両一覧データを戻します:カスタムシリアライズ
        /// </summary>
        /// <param name="monthCarInspectListResultWork">検索結果</param>
        /// <param name="monthCarInspectListParaWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>

        int Search(
            [CustomSerializationMethodParameterAttribute("PMSYA02109D", "Broadleaf.Application.Remoting.ParamData.MonthCarInspectListResultWork")]
			out object monthCarInspectListResultWork,
            object monthCarInspectListParaWork);
        #endregion
    }
}
