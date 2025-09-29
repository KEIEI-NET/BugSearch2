using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �݌ɑg���E��������  DBRemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �݌ɑg���E�������� DBRemoteObject Interface�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.10.06</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStckAssemOvhulDB
	{
        /// <summary>
        /// �݌ɑg���E��������LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="paraStckAssemOvhulRstWork">��������</param>
        /// <param name="paraStckAssemOvhulReqWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.06</br>
        [MustCustomSerialization]
		int Search(
             [CustomSerializationMethodParameterAttribute("PMZAI04026D", "Broadleaf.Application.Remoting.ParamData.StckAssemOvhulRstWork")]
			 out object paraStckAssemOvhulRstWork
            ,object paraStckAssemOvhulReqWork
            ,ConstantManagement.LogicalMode logicalMode
            );
	}
}
