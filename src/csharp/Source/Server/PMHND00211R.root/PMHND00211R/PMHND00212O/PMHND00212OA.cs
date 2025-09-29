//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 検品データ  DB RemoteObjectインターフェース
// プログラム概要   : 検品データテーブルに対して削除処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 陳艶丹
// 作 成 日  2017/06/30  修正内容 : 検品データ登録の対応
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 陳艶丹
// 作 成 日  2017/07/20  修正内容 : 検品データ登録の対応
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
    /// 検品データ用DB Access RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品データ用DB Access RemoteObjectインターフェースです。</br>
    /// <br>Programmer : 3H 張小磊</br>
    /// <br>Date       : 2017/05/22</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IInspectDataDB
    {
        /// <summary>
        /// 検品データ削除処理
        /// </summary>
        /// <param name="inspectDataObj">検品データパラメータ</param>
        /// <param name="retMsg">エラーメッセージ</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 検品データ削除処理する</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/05/22</br>
        /// <br>UpdateNote : 2017/06/30 陳艶丹</br>
        /// <br>           : 検品データ登録の対応</br>
        /// </remarks>
        [MustCustomSerialization]
        int DeleteInspectData(
            [CustomSerializationMethodParameterAttribute("PMHND00213D", "Broadleaf.Application.Remoting.ParamData.InspectDataWork")]
            ref object inspectDataObj,
            out string retMsg);

        // ----------- ADD 2017/06/30 陳艶丹 ---------------->>>>
        #region [検品データ登録（同一キーで物理削除）]
        /// <summary>
        /// 検品データ登録（同一キーで物理削除）
        /// </summary>
        /// <param name="inspectDataObj">HandyInspectDataWorkオブジェクト</param>
        /// <param name="mode">0:検品データ登録、1:検品データ登録(先行検品)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品データ情報を登録します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteInspectData(
            [CustomSerializationMethodParameterAttribute("PMHND00213D", "Broadleaf.Application.Remoting.ParamData.HandyInspectDataWork")]
			ref object inspectDataObj,
            int mode);
        #endregion
        // ----------- ADD 2017/06/30 陳艶丹 ----------------<<<<

        // ----------- ADD 2017/07/20 陳艶丹 ---------------->>>>
        #region [検品データ検索]
        /// <summary>
        /// 検品データLISTを全て戻します。
        /// </summary>
        /// <param name="paraInspectDataWork">検索パラメータ</param>
        /// <param name="inspectDataObj">検索結果</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            object paraInspectDataWork,
            [CustomSerializationMethodParameterAttribute("PMHND00213D", "Broadleaf.Application.Remoting.ParamData.HandyInspectDataWork")]
            out object inspectDataObj);
        #endregion
        // ----------- ADD 2017/07/20 陳艶丹 ----------------<<<<
    }

}
