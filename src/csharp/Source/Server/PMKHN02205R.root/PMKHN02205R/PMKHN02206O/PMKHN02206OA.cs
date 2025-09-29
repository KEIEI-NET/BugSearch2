using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// メニュー制御設定印刷DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : メニュー制御設定印刷DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30747 三戸　伸悟</br>
    /// <br>Date       : 2013/02/07</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IMenueStDB
    {
        #region カスタムシリアライズ対応メソッド
        /// <summary>
        /// メニュー制御設定印刷LISTを全て戻します（論理削除除く）:カスタムシリアライズ
        /// </summary>
        /// <param name="menueStWork">検索結果</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sortCode">印刷順</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30747 三戸　伸悟</br>
        /// <br>Date       : 2013/02/07</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN02207D", "Broadleaf.Application.Remoting.ParamData.MenueStWork")]
            out object menueStWork, String enterpriseCode, Int32 sortCode);
        #endregion
    }
}
