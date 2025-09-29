//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象自動更新メンテナンス
// プログラム概要   : コンバート対象自動更新を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 佐々木亘
// 作 成 日  2020/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// コンバート対象自動更新 RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象自動更新 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IConvObjDB
    {
        /// <summary>
        /// コンバート対象自動更新します。
        /// </summary>
        /// <param name="convObjWorkbyte">自動更新情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象自動更新します。</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int ConvObjAutoUpdate([CustomSerializationMethodParameterAttribute("PMCMN00145D", "Broadleaf.Application.Remoting.ParamData.ConvObjWork")]
            ref ConvObjWork convObjWorkbyte
            );

        /// <summary>
        /// 操作ログ出力
        /// </summary>
        /// <param name="writeParam">ログ出力情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 操作ログテーブルにログを出力する</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        int WriteOprtnHisLog(OprtnHisLogWork writeParam);

    }
}
