//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : TSP送信データ作成 DBRemoteObjectインターフェース
// プログラム概要   : TSP送信データ作成 DBRemoteObjectインターフェースです
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11670305-00 作成担当 : 陳艶丹
// 作 成 日  2020/11/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// TSP送信データ作成 DBRemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : TSP送信データ作成 DBRemoteObjectインターフェースです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/11/20</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITspSdRvDataDB
    {
        #region
        /// <summary>
        /// 共通通番を採番します。
        /// </summary>
        /// <param name="enterprisecode">企業コードを指定します。</param>
        /// <param name="sectioncode">拠点コードを指定します。</param>
        /// <param name="commonseqno">採番した共通通番を返します。</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 共通通番を採番します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        int GetTspCommonSeqNo(
            string enterprisecode, 
            string sectioncode, 
            out Int64 commonseqno);

        /// <summary>
        /// 指定された条件のTSP明細データLISTの件数を戻します。
        /// </summary>
        /// <param name="tspDtlWorkPara">検索条件</param>
        /// <param name="tspDtlWorkList">TSP明細データLIST</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のTSP明細データLISTの件数を戻します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            TspDtlWork tspDtlWorkPara,
            [CustomSerializationMethodParameterAttribute("PMTSP01206D", "Broadleaf.Application.Remoting.ParamData.TspDtlWork")]
            out object tspDtlWorkList
            );

        /// <summary>
        /// TSP明細データを登録、更新します。
        /// </summary>
        /// <param name="tspDtlWork">TSP連携マスタ設定情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP明細データを登録、更新します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMTSP01206D", "Broadleaf.Application.Remoting.ParamData.TspDtlWork")]
            ref object tspDtlWork
            );

        /// <summary>
        /// TSP明細データを完全削除します。
        /// </summary>
        /// <param name="tspDtlWork">TSP明細データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : TSP明細データを完全削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            object tspDtlWork
            );
        #endregion
    }
}
