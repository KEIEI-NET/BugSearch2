//**********************************************************************
// System           : PM.NS
// Sub System       :
// Program name     : PMTAB汎用検索結果セッション管理トランザクションデータ RemoteObject Interface
//                  : PMTAB08035O.DLL
// Name Space       : Broadleaf.Application.Remoting
// Programmer       : 30746 高川 悟
// Date             : 2014/09/26
//----------------------------------------------------------------------
//                  (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTAB汎用検索結果セッション管理トランザクションデータマスタ RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB汎用検索結果セッション管理トランザクションデータマスタ RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30746 高川 悟</br>
    /// <br>Date       : 2014/09/26</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IPmtGeneralSrRstDB
    {
        #region データ区分１
        /// <summary>
        /// 指定された条件のPMTAB汎用検索結果セッション管理トランザクションデータLISTを全て戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB汎用検索結果セッション管理トランザクションデータ情報を検索します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2014/09/26</br>
        [MustCustomSerialization]
        int SearchForLinkDataCode1(
            [CustomSerializationMethodParameterAttribute("PMTAB08036D", "Broadleaf.Application.Remoting.ParamData.PmtGeneralSrRstWork")]
			out object retObj,
            object paraObj);

        /// <summary>
        /// 指定された条件のPMTAB汎用検索結果セッション管理トランザクションデータLISTを全て戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <param name="readMode">検索区分</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6::正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="msgDiv">メッセージ区分　[True:メッセージ有]</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB汎用検索結果セッション管理トランザクションデータを検索します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2014/09/26</br>
        [MustCustomSerialization]
        int SearchForLinkDataCode1(
            [CustomSerializationMethodParameterAttribute("PMTAB08036D", "Broadleaf.Application.Remoting.ParamData.PmtGeneralSrRstWork")]
			out object retObj,
            object paraObj,
            ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection,
            out bool msgDiv,
            out string errMsg);

        /// <summary>
        /// PMTAB汎用検索結果セッション管理トランザクションデータを追加・更新します。
        /// </summary>
        /// <param name="PmtGeneralSrRstWork">追加・更新するPMTAB汎用検索結果セッション管理トランザクションデータ</param>
        /// <param name="msgDiv">メッセージ区分　[True:メッセージ有]</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB汎用検索結果セッション管理トランザクションデータを追加・更新します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2014/09/26</br>
        [MustCustomSerialization]
        int WriteForLinkDataCode1(
            [CustomSerializationMethodParameterAttribute("PMTAB08036D", "Broadleaf.Application.Remoting.ParamData.PmtGeneralSrRstWork")]
            ref object paraList,
            out bool msgDiv,
            out string errMsg);

        /// <summary>
        /// PMTAB汎用検索結果セッション管理トランザクションデータを削除します。
        /// </summary>
        /// <param name="PmtGeneralSrRstWork">削除するPMTAB汎用検索結果セッション管理トランザクションデータ</param>
        /// <param name="msgDiv">メッセージ区分　[True:メッセージ有]</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB汎用検索結果セッション管理トランザクションデータを削除します。</br>
        /// <br>Programmer : 30746 高川 悟</br>
        /// <br>Date       : 2014/09/26</br>
        [MustCustomSerialization]
        int DeleteForLinkDataCode1(
            [CustomSerializationMethodParameterAttribute("PMTAB08036D", "Broadleaf.Application.Remoting.ParamData.PmtGeneralSrRstWork")]
            ref object paraList,
            out bool msgDiv,
            out string errMsg);
    }
    #endregion データ区分１
}
