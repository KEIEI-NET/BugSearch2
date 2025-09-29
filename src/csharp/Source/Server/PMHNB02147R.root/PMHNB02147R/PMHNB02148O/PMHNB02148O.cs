using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �o�׏��i�D�ǑΉ��\DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �o�׏��i�D�ǑΉ��\DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22008 ���� ���n</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IShipGdsPrimeListResultWorkDB
	{   
        
        /// <summary>
        /// �o�׏��i�D�ǑΉ��\��LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="shipGdsPrimeListResultList">��������</param>
        /// <param name="shipGdsPrimeListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 22008 ���� ���n</br>
		/// <br>Date       : 2008.10.24</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB02149D", "Broadleaf.Application.Remoting.ParamData.ShipGdsPrimeListResultWork")]
			out object shipGdsPrimeListResultList,
            object shipGdsPrimeListCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �o�׏��i�D�ǑΉ��\��LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="shipGdsPrimeListResultList">��������</param>
        /// <param name="shipGdsPrimeListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2008.10.24</br>
        [MustCustomSerialization]
        int SearchPartner(
            [CustomSerializationMethodParameterAttribute("PMHNB02149D", "Broadleaf.Application.Remoting.ParamData.ShipGdsPrimeListResultWork")]
			out object shipGdsPrimeListResultList,
            object shipGdsPrmListCndtnPartnerList,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
    }
}
