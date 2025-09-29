using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 請求一覧表DB RemoteObjectインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 請求一覧表DB RemoteObject Interfaceです。</br>
    /// <br>Programmer : 20036　斉藤　雅明</br>
    /// <br>Date       : 2007.05.11</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IBillTableDB
    {

        /// <summary>
        /// 請求一覧表を戻します
        /// </summary>
        /// <param name="retObj">検索結果</param>
        /// <param name="paraObj">検索パラメータ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20036　斉藤　雅明</br>
        /// <br>Date       : 2007.05.11</br>
        /// <br>Note       : </br>
        /// <br>Programmer : 30531　大矢 睦美</br>
        /// <br>Date       : 2010.01.25</br>
        // --- ADD  大矢睦美  2010/01/25 ---------->>>>>
        //[MustCustomSerialization]
        //int SearchBillTable([CustomSerializationMethodParameterAttribute("MAKAU02032D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_DemandTotalWork")]out object retObj, object paraObj);
        int SearchBillTable(out object retObj, object paraObj);
        // --- ADD  大矢睦美  2010/01/25 ----------<<<<<
    }
}
