using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

	/// <summary>
    /// LSM���O�`�F�b�N���W���[��DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : LSM���O�`�F�b�N���W���[��DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : �e�c ���V</br>
	/// <br>Date       : 2015/09/24</br>
	/// <br></br>
	/// <br>Update Note: </br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ILSMLogCheckDB
    {
        /// <summary>
        /// LSM���O�@Check
        /// </summary>
        /// <param name="retWorkList">����ArrayList</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int CheckLSMLog(
            out object retWorkList, out string machineName, object lsmChkWordWorkList);
    }
}
