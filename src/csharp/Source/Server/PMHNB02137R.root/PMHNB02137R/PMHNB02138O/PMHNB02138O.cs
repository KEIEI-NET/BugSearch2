using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���Ӑ�ߔN�x���v�\DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���Ӑ�ߔN�x���v�\DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22008 ���� ���n</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustFinancialListResultWorkDB
	{
        
        /// <summary>
        /// ���Ӑ�ߔN�x���v�\��LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="custFinancialListResultList">��������</param>
        /// <param name=" custFinancialListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 22008 ���� ���n</br>
		/// <br>Date       : 2008.10.24</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB02139D", "Broadleaf.Application.Remoting.ParamData.CustFinancialListResultWork")]
			out object custFinancialListResultList,
            object custFinancialListCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

	}
}
