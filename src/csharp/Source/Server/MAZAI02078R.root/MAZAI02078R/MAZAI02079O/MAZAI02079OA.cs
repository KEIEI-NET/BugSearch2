using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �݌Ɉꗗ�\DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �݌Ɉꗗ�\DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22035 �O�� �O��</br>
	/// <br>Date       : 2007.03.20</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockListWorkDB
	{
		/// <summary>
        /// ����c�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="stockListResultWork">��������</param>
        /// <param name="stockListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2007.03.20</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("MAZAI02076D", "Broadleaf.Application.Remoting.ParamData.StockListResultWork")]
			out object stockListResultWork,
            object stockListCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);
	}
}
