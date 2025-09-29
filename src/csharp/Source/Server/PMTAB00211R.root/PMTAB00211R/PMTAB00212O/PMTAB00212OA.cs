//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PMTABセッション管理データ  DB RemoteObjectインターフェース
// プログラム概要   : PMTABセッション管理データテーブルに対して追加・更新・削除処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2017/04/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTABセッション管理データ用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : デPMTABセッション管理データ用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2017/04/06</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPmTabSessionMngDB
    {
        /// <summary>
        /// PMTABセッション管理データ削除処理
        /// </summary>
        /// <param name="paraPmTabSessionMngObj">PMTABセッション管理データパラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データ削除処理する</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        [MustCustomSerialization]
        int DeleteSessionMng(
            [CustomSerializationMethodParameterAttribute("PMTAB00213D", "Broadleaf.Application.Remoting.ParamData.PmTabSessionMngWork")]
            ref object paraPmTabSessionMngObj,
            out string retMsg);

        /// <summary>
        /// PMTABセッション管理データ検索処理
        /// </summary>
        /// <param name="pmTabSeesionMngObj">PMTABセッション管理データオブジェクト</param>
        /// <param name="paraPmTabSessionMngObj">PMTABセッション管理データパラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 同一セッションIDの存在チェックを行う。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
       [MustCustomSerialization]
        int SearchSessionId(
           [CustomSerializationMethodParameterAttribute("PMTAB00213D", "Broadleaf.Application.Remoting.ParamData.PmTabSessionMngWork")]
            out object  pmTabSeesionMngObj,
            object paraPmTabSessionMngObj,
            out string retMsg);


        /// <summary>
        /// PMTABセッション管理データの新規追加処理
        /// </summary>
        /// <param name="paraPmTabSessionMngObj"> PMTABセッション管理データパラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : PMTABセッション管理データ情報を追加します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2017/04/06</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteSessionMng(
            [CustomSerializationMethodParameterAttribute("PMTAB00213D", "Broadleaf.Application.Remoting.ParamData.PmTabSessionMngWork")]
            ref object paraPmTabSessionMngObj,
            out string retMsg);
    }
}
