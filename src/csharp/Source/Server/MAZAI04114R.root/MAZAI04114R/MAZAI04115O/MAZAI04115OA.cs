using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���i�݌Ɍ���DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i�݌Ɍ���DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2007.01.18</br>
	/// <br></br>
	/// <br>Update Note: 2007.09.07 ���� DC.NS�p�ɏC��</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IGoodsStockSearchDB
	{

		/// <summary>
		/// ���i�݌Ɍ���LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="goodsStockSearchWork">��������</param>
		/// <param name="paragoodsStockSearchWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.18</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object goodsStockSearchWork,
			object paragoodsStockSearchWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// <summary>
        /// ���i�݌Ɍ���LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="goodsStockSearchWork">��������</param>
        /// <param name="paragoodsStockSearchWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 20073�@�� �B</br>
        /// <br>Date       :  2012/04/10</br>
        [MustCustomSerialization]
        int Search2(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object goodsStockSearchWork,
            object paragoodsStockSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode);
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

        /*
        /// <summary>
        /// ���i�݌Ɍ���LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="goodsStockSearchWork">��������</param>
        /// <param name="paragoodsStockSearchWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        [MustCustomSerialization]
        int SearchEachWarehouse(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object goodsStockSearchWork,
            object paragoodsStockSearchWork, int readMode, ConstantManagement.LogicalMode logicalMode);
        */
    }
}
