//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 環境調査
// プログラム概要   : 環境調査を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670219-00 作成担当 : 佐々木亘
// 作 成 日  2020/06/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 環境調査 RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 環境調査 RemoteObject Interfaceです。</br>
    /// <br>Programmer : 佐々木亘</br>
    /// <br>Date       : 2020/06/15</br>
    /// <br>管理番号   : 11670219-00</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IEnvSurvObjDB
    {
        /// <summary>
        /// 全体バックアップ情報取得
        /// </summary>
        /// <param name="envFullBackupInf">全体バックアップ情報</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 環境調査</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int EnvFullBackupInfSearch([CustomSerializationMethodParameterAttribute("PMCMN00155D", "Broadleaf.Application.Remoting.ParamData.EnvFullBackupInfWork")]
            out object envFullBackupInf
            );

        /// <summary>
        /// マスタ件数取得
        /// </summary>
        /// <param name="mstCount">マスタ件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 環境調査</br>
        /// <br>Programmer : 佐々木亘</br>
        /// <br>Date       : 2020/06/15</br>
        /// <br>管理番号   : 11670219-00</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int PriceMstInfCntSearch(out Int32 mstCount);

    }
}
