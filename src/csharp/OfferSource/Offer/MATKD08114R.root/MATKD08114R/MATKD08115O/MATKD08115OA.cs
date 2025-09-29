using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���i�}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i�}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2007.02.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
	public interface IGoodsDB
	{

		/// <summary>
		/// �w�肳�ꂽ���i�}�X�^Guid�̏��i�}�X�^��߂��܂�
		/// </summary>
		/// <param name="parabyte">GoodsWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���i�}�X�^Guid�̏��i�}�X�^��߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.02.06</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// ���i�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="goodsWork">��������</param>
		/// <param name="paragoodsWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.02.06</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MATKD08116D","Broadleaf.Application.Remoting.ParamData.GoodsWork")]
			out object goodsWork,
			object paragoodsWork, int readMode,ConstantManagement.LogicalMode logicalMode);

	}
}
