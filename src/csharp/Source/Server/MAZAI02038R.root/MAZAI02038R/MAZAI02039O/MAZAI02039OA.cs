using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �݌ɁE�q�Ɉړ��m�F�\DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �݌ɁE�q�Ɉړ��m�F�\DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22035 �O�� �O��</br>
	/// <br>Date       : 2007.03.14</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockMoveListWorkDB
	{
        
        /// <summary>
        /// �݌Ɉړ��m�F�\LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="stockMoveListResultWork">��������</param>
        /// <param name=" stockMoveListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2007.03.14</br>
        [MustCustomSerialization]
		int SearchStock(
            [CustomSerializationMethodParameterAttribute("MAZAI02036D", "Broadleaf.Application.Remoting.ParamData.StockMoveListResultWork")]
			out object stockMoveListResultWork,
            object stockMoveListCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �q�Ɉړ��m�F�\LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="stockMoveListResultWork">��������</param>
        /// <param name="stockMoveListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.03.14</br>
        [MustCustomSerialization]
        int SearchEnterWareh(
            [CustomSerializationMethodParameterAttribute("MAZAI02036D", "Broadleaf.Application.Remoting.ParamData.StockMoveListResultWork")]
			out object stockMoveListResultWork,
            object stockMoveListCndtnWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
	}
}
