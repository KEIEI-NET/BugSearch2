using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �݌ɉߏ�ꗗ�\DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �݌ɉߏ�ꗗ�\DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22008 ���� ���n</br>
	/// <br>Date       : 2007.11.07</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockOverListWorkDB
	{
		/// <summary>
        /// ����c�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="stockOverListResultWork">��������</param>
        /// <param name="stockOverListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22008 ���� ���n</br>
		/// <br>Date       : 2007.11.07</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("DCZAI02193D", "Broadleaf.Application.Remoting.ParamData.StockOverListResultWork")]
			out object stockOverListResultWork,
            object stockOverListCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);
	}
}
