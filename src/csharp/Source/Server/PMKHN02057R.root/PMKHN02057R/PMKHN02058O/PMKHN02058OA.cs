//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン実績表
// プログラム概要   : キャンペーン実績表　DBRemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 田建委
// 作 成 日  2011/05/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// キャンペーン実績表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン実績表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date       : 2011/05/19</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignRsltListResultDB
    {
        #region
        /// <summary>
        /// アクセスクラスから受渡された企業コードで、登録した売上データ（伝票種別：売上）の抽出を行う。
        /// </summary>
        /// <param name="campaignstRsltListSalesWork">検索結果1</param>
        /// <param name="campaignstRsltListTargetWork">検索結果2</param>
        /// <param name="campaignstRsltListPrtWork">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 指定された条件のキャンペーン実績データを戻します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2011/05/19</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN02059D", "Broadleaf.Application.Remoting.ParamData.CampaignstRsltListResultWork")]
			out object campaignstRsltListSalesWork,
            out object campaignstRsltListTargetWork,
            object campaignstRsltListPrtWork);

        #endregion
    }
}
