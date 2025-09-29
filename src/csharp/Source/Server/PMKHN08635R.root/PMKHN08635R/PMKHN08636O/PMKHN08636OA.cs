using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 売上目標設定マスタ印刷DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上目標設定マスタ印刷DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 23012 畠中 啓次朗</br>
    /// <br>Date       : 2008.11.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalTrgtPrintResultDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// 売上目標設定マスタ印刷データを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="SalTrgtPrintResult">検索結果</param>
        /// <param name="salTrgtPrintParamWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23012 畠中 啓次朗</br>
        /// <br>Date       : 2008.11.11</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN08637D", "Broadleaf.Application.Remoting.ParamData.SalTrgtPrintResultWork")]
			out object salTrgtPrintResultWork,
            object salTrgtPrintParamWork,
            ConstantManagement.LogicalMode logicalMode);
        #endregion
    }
}
