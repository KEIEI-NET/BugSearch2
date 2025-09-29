//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   得意先マスタ（与信設定）DBインターフェース
//                  :   PMKHN09266O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2008.10.14
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 得意先マスタ（与信設定）DBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（与信設定）DBインターフェースです。</br>
    /// <br>Programmer : 22008 長内 数馬</br>
    /// <br>Date       : 2008.10.14</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustCreditDB
    {
        /// <summary>
        /// 得意先マスタ（与信設定）情報を追加・更新します。
        /// </summary>
        /// <param name="resultList">追加・更新後の得意先マスタ（与信設定）情報を含む ArrayList</param>
        /// <param name="paraCustCreditCndtn">抽出条件クラス</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : sumCustStList に格納されている得意先マスタ（与信設定）情報を追加・更新します。</br>
        /// <br>Programmer : 22008 長内 数馬</br>
        /// <br>Date       : 2008.10.14</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09146D", "Broadleaf.Application.Remoting.ParamData.CustomerChangeWork")]
            out object resultList, object paraCustCreditCndtn);
    }
}
