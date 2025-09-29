using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// 優良設定マスタ RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優良設定マスタ検索 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//←アプリケーションサーバーの接続先を属性で指示
    public interface IPrimeSettingDB
    {

        /// <summary>
        /// 提供優良設定LISTを全て戻します
        /// </summary>
        /// <param name="PrimeSettingRetWork">優良設定検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD09023D", "Broadleaf.Application.Remoting.ParamData.PrmSettingWork")]
            out object PrimeSettingRetWork);

        /// <summary>
        /// 提供優良設定備考LISTを全て戻します
        /// </summary>
        /// <param name="PrimeSettingNoteRetWork">優良設定備考検索条件</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        [MustCustomSerialization]
        int SearchNote(
            [CustomSerializationMethodParameterAttribute("PMTKD09023D", "Broadleaf.Application.Remoting.ParamData.PrmSetNoteWork")]
            out object PrimeSettingNoteRetWork);

        /// <summary>
        /// 提供優良設定変更マスタLISTを全て戻します
        /// </summary>
        /// <param name="PrimeSettingChgWork">優良設定変更マスタ検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// [MustCustomSerialization]
        int SearchChg(
            [CustomSerializationMethodParameterAttribute("PMTKD09023D", "Broadleaf.Application.Remoting.ParamData.PrmSettingChgWork")]
            out object PrimeSettingChgWork);
    }
}
