using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

	/// <summary>
    /// LSMログチェックモジュールDB RemoteObjectインターフェース
	/// </summary>
	/// <remarks>
    /// <br>Note       : LSMログチェックモジュールDB RemoteObject Interfaceです。</br>
	/// <br>Programmer : 脇田 靖之</br>
	/// <br>Date       : 2015/09/24</br>
	/// <br></br>
	/// <br>Update Note: </br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ILSMLogCheckDB
    {
        /// <summary>
        /// LSMログ　Check
        /// </summary>
        /// <param name="retWorkList">結果ArrayList</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int CheckLSMLog(
            out object retWorkList, out string machineName, object lsmChkWordWorkList);
    }
}
