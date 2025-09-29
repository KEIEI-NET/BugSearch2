//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : コンバート対象バックアップメンテナンス
// プログラム概要   : コンバート対象バックアップを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 小原
// 作 成 日  2020/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// コンバート対象バックアップ RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : コンバート対象バックアップ RemoteObject Interfaceです。</br>
    /// <br>Programmer : 小原</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IConvObjSingleBkDB
    {
        /// <summary>
        /// コンバート対象バックアップします。
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : コンバート対象バックアップします。</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int ConvObjSingleBackupExec([CustomSerializationMethodParameterAttribute("PMCMN00165D", "Broadleaf.Application.Remoting.ParamData.ConvObjSingleBkWork")]
            ref ConvObjSingleBkWork ConvObjSingleBkWork
            );

        /// <summary>
        /// 操作ログ出力
        /// </summary>
        /// <param name="writeParam">ログ出力情報</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 操作ログテーブルにログを出力する</br>
        /// <br>Programmer : 小原</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        int WriteOprtnHisLog(OprtnHisLogWork writeParam);

    }
}
