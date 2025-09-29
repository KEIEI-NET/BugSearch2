using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �|���}�X�^���  DBRemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �|���}�X�^��� DBRemoteObject Interface�ł��B</br>
    /// <br>Programmer : 23015 �X�{ ��P</br>
    /// <br>Date       : 2008.10.01</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRatePrtDB
	{
        /// <summary>
        /// �|���}�X�^LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="paraRatePrtRstWork">��������</param>
        /// <param name="paraRatePrtReqWork">��������</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 23015 �X�{ ��P</br>
        /// <br>Date       : 2008.10.01</br>
        [MustCustomSerialization]
		int Search(
             [CustomSerializationMethodParameterAttribute("PMKHN02018D", "Broadleaf.Application.Remoting.ParamData.RatePrtRstWork")]
			 out object paraRatePrtRstWork
            ,object paraRatePrtReqWork
            ,ConstantManagement.LogicalMode logicalMode
            );
	}
}
