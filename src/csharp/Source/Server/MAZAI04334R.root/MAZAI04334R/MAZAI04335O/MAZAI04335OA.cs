using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �݌Ɏ󕥗����f�[�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌Ɏ󕥗����f�[�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2007.01.30</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockAcPayHistDB
	{

		/// <summary>
		/// �w�肳�ꂽ�݌Ɏ󕥗����f�[�^Guid�̍݌Ɏ󕥗����f�[�^��߂��܂�
		/// </summary>
		/// <param name="parabyte">StockAcPayHistWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�݌Ɏ󕥗����f�[�^Guid�̍݌Ɏ󕥗����f�[�^��߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.30</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// �݌Ɏ󕥗����f�[�^���𕨗��폜���܂�
		/// </summary>
        /// <param name="paraobj">StockAcPayHistWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌Ɏ󕥗����f�[�^���𕨗��폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.30</br>
		int Delete(object paraobj);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
		/// �݌Ɏ󕥗����f�[�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="stockAcPayHistWork">��������</param>
		/// <param name="parastockAcPayHistWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.30</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object stockAcPayHistWork,
			object parastockAcPayHistWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �݌Ɏ󕥗����f�[�^����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="stockAcPayHistWork">StockAcPayHistWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌Ɏ󕥗����f�[�^����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.30</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAcPayHistWork
			);

		/// <summary>
		/// �݌Ɏ󕥗����f�[�^����_���폜���܂�
		/// </summary>
		/// <param name="stockAcPayHistWork">StockAcPayHistWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌Ɏ󕥗����f�[�^����_���폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.30</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAcPayHistWork
			);

        /*
		/// <summary>
		/// �_���폜�݌Ɏ󕥗����f�[�^���𕜊����܂�
		/// </summary>
		/// <param name="stockAcPayHistWork">StockAcPayHistWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�݌Ɏ󕥗����f�[�^���𕜊����܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.30</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAcPayHistWork
			);
        */ 
		#endregion
	}
}
