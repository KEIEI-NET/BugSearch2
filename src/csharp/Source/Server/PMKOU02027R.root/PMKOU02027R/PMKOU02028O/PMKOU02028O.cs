using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �d�����͕\DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �d�����͕\DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 23012 ���� �[���N</br>
	/// <br>Date       : 2008.11.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISlipHistAnalyzeResultWorkDB
	{
        
        /// <summary>
        /// �d�����͕\��LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="slipHistAnalyzeResultList">��������</param>
        /// <param name=" slipHistAnalyzeParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 23012 ���� �[���N</br>
		/// <br>Date       : 2008.11.13</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKOU02029D", "Broadleaf.Application.Remoting.ParamData.SlipHistAnalyzeResultWork")]
			out object slipHistAnalyzeResultList,
            object slipHistAnalyzeParamWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

	}
}
