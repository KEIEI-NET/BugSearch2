//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   車種名称マスタDBインターフェース
//                  :   PMTKD09072O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.06.10
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 車種名称マスタDBインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車種名称マスタDBインターフェースです。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.06.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IModelNameDB
    {
        /// <summary>
        /// 単一の車種名称マスタ情報を取得します。
        /// </summary>
        /// <param name="modelNameObj">ModelNameWorkオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する車種名称マスタ情報を取得します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTKD09073D", "Broadleaf.Application.Remoting.ParamData.ModelNameWork")]
            ref object modelNameObj);

        /// <summary>
        /// 車種名称マスタ情報のリストを取得します。
        /// </summary>
        /// <param name="modelNameList">検索結果</param>
        /// <param name="modelNameObj">検索条件[コード設定なし：全件検索]</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 車種名称マスタのキー値が一致する、全ての車種名称マスタ情報を取得します。</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.06.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMTKD09073D", "Broadleaf.Application.Remoting.ParamData.ModelNameWork")]
            ref object modelNameList,
            object modelNameObj);

    }
}
