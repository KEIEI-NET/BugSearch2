//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   簡単問合せ接続情報DBインターフェース
//                  :   PMSCM00206O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21024　佐々木 健
// Date             :   2010/03/25
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 簡単問合せ接続情報DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 簡単問合せ接続情報DBインターフェースです。</br>
    /// <br>Programmer : 21024　佐々木 健</br>
    /// <br>Date       : 2010/03/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISimplInqCnectInfoDB
    {
        /// <summary>
        /// 簡単問合せ接続情報情報を削除します
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="simplInqCnectInfoList">物理削除する簡単問合せ接続情報情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 簡単問合せ接続情報のキー値が一致する簡単問合せ接続情報情報を物理削除します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        int Delete(
            string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMSCM00207D", "Broadleaf.Application.Remoting.ParamData.SimplInqCnectInfoWork")]
            object simplInqCnectInfoList);

        /// <summary>
        /// 簡単問合せ接続情報情報のリストを取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="simplInqCnectInfoList">検索結果</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 簡単問合せ接続情報のキー値が一致する、全ての簡単問合せ接続情報情報を取得します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        [MustCustomSerialization]
        int Search(
            string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMSCM00207D", "Broadleaf.Application.Remoting.ParamData.SimplInqCnectInfoWork")]
            out object simplInqCnectInfoList);

        /// <summary>
        /// 簡単問合せ接続情報情報を追加します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="simplInqCnectInfoList">追加・更新する簡単問合せ接続情報情報を含む ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : simplInqCnectInfoList に格納されている簡単問合せ接続情報情報を追加・更新します。</br>
        /// <br>Programmer : 21024　佐々木 健</br>
        /// <br>Date       : 2010/03/25</br>
        int Write(
            string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMSCM00207D", "Broadleaf.Application.Remoting.ParamData.SimplInqCnectInfoWork")]
            object simplInqCnectInfoList);
    }
}
