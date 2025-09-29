//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良部品バーコード情報抽出リモート
// プログラム概要   : 優良部品バーコード情報抽出RemoteObjectインターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370074-00  作成担当 : 30757 佐々木貴英
// 作 成 日  2017/09/20   修正内容 : ハンディターミナル二次対応（新規作成）
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// 優良部品バーコード情報抽出RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 優良部品バーコード情報抽出RemoteObjectインターフェースの定義</br>
    /// <br>Programmer : 30757　佐々木　貴英</br>
    /// <br>Date       : 2017/09/20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//←アプリケーションサーバーの接続先を属性で指示
    public interface IOfferPrmPartsBrcdInfo
    {
        /// <summary>
        /// 優良部品バーコード情報抽出件数取得
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="retCnt">抽出件数</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する優良部品バーコード情報を取得した場合の件数を取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int GetSearchCount(
            [CustomSerializationMethodParameterAttribute( "PMTKD09404D", "Broadleaf.Application.Remoting.ParamData.GetPrmPartsBrcdParaWork" )]
                ref object selectParam,
                out int retCnt
            );

        /// <summary>
        /// 優良部品バーコード情報抽出
        /// </summary>
        /// <param name="selectParam">抽出パラメータ</param>
        /// <param name="prmPartsBrcdInfoList">抽出結果</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 抽出パラメータの条件に合致する優良部品バーコード情報を取得取得する</br>
        /// <br>Programmer : 30757　佐々木　貴英</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute( "PMTKD09404D", "Broadleaf.Application.Remoting.ParamData.GetPrmPartsBrcdParaWork" )]
                ref object selectParam,
            [CustomSerializationMethodParameterAttribute( "PMTKD09404D", "Broadleaf.Application.Remoting.ParamData.RettPrmPartsBrcdInfoWork" )]
                out object prmPartsBrcdInfoList
            );
    }
}
