//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル検品照会リモートオブジェクト インターフェース
// プログラム概要   : ハンディターミナル検品照会RemoteObject Interfaceです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 陳艶丹
// 作 成 日  2017/07/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11470154-00 作成担当 : 陳艶丹                              
// 修 正 日  2018/10/16  修正内容 : ハンディターミナル五次対応
//                                  取消機能とテキスト出力機能の追加
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ハンディターミナル検品照会リモートオブジェクト インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       :ハンディターミナル 検品照会リモートオブジェクト インターフェースです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/07/20</br>
    /// <br>Update Note: 2018/10/16 陳艶丹</br>
    /// <br>　　　　　 : ハンディターミナル五次対応</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyInspectRefDataDB
    {
        #region [Search]
        /// <summary>
        /// ハンディターミナル検品照会情報の取得処理
        /// </summary>
        /// <param name="inspectRefDataObj">検索結果</param>
        /// <param name="searchCondtObj">検索条件</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル検品照会情報を検索します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHND04206D", "Broadleaf.Application.Remoting.ParamData.InspectRefDataWork")]
           out object inspectRefDataObj,
           object searchCondtObj,
           out string errMessage);
        #endregion

        #region [検品ガイドデータ検索]
        /// <summary>
        /// 検品ガイドデータ検索
        /// </summary>
        /// <param name="paraInspectDataWork">検索パラメータ</param>
        /// <param name="inspectDataObj">検索結果</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品ガイドデータを取得します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchGuid(
            object paraInspectDataWork,
            [CustomSerializationMethodParameterAttribute("PMHND00213D", "Broadleaf.Application.Remoting.ParamData.HandyInspectDataWork")]
            out object inspectDataObj);
        #endregion

        #region [引当処理]
        /// <summary>
        /// 引当データ処理
        /// </summary>
        /// <param name="deleteDataObj">先行検品データ物理削除データ</param>
        /// <param name="insertDataObj">検品データ</param>
        /// <param name="Type">0:手動検品データ登録処理,1:先行検品引当登録処理</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 引当データ処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        [MustCustomSerialization]
         int WriteInspectData(
            object deleteDataObj,
            object insertDataObj,
            int Type);
        #endregion

        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
        #region [削除処理]
        /// <summary>
        /// 検品データ削除処理
        /// </summary>
        /// <param name="delInspectDataObj">検品データ</param>
         /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品データ削除処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2019/10/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int DeleteInspectData(
            object delInspectDataObj,
            out string retMessage);
        #endregion
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
    }
}