using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 請求一覧表(総括)DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求一覧表(総括)DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 30350　櫻井　亮太</br>
    /// <br>Date       : 2009.04.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISumBillTableDB
    {

        /// <summary>
        /// 請求一覧表(総括)を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 30350　櫻井　亮太</br>
        /// <br>Date       : 2009.04.13</br>
        /// <br>Note       : </br>
        /// <br>Update Note: 30531　大矢　睦美</br>
        /// <br>Date       : 2010.02.01</br>
        [MustCustomSerialization]
        // --- ADD  大矢睦美  2010/02/01 ---------->>>>>
        //int SearchBillTable([CustomSerializationMethodParameterAttribute("PMHNB02263D", "Broadleaf.Application.Remoting.ParamData.SumRsltInfo_DemandTotalWork")]out object retObj, object paraObj);
        int SearchBillTable(out object retObj, object paraObj);
        // --- ADD  大矢睦美  2010/02/01 ----------<<<<<

    }
}
