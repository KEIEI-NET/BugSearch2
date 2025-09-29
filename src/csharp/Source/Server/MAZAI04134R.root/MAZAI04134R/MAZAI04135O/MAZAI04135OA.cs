using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �݌�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2007.01.18</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockDB
	{

		/// <summary>
		/// �w�肳�ꂽ�݌�Guid�̍݌ɂ�߂��܂�
		/// </summary>
		/// <param name="parabyte">StockWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�݌�Guid�̍݌ɂ�߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.18</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// �݌ɏ��𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">StockWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɏ��𕨗��폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.18</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
		/// �݌�LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="stockWork">��������</param>
		/// <param name="parastockWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.18</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAZAI04136D","Broadleaf.Application.Remoting.ParamData.StockWork")]
			out object stockWork,
			object parastockWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �݌ɏ���o�^�A�X�V���܂�
		/// </summary>
		/// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɏ���o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.18</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
			ref object stockWork
			);

		/// <summary>
		/// �݌ɏ���_���폜���܂�
		/// </summary>
		/// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɏ���_���폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.18</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
			ref object stockWork
			);
        
		/// <summary>
		/// �_���폜�݌ɏ��𕜊����܂�
		/// </summary>
		/// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�݌ɏ��𕜊����܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.18</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
			ref object stockWork
			);
		#endregion

        //IOWrite�e�X�g�p
        /// <summary>
        /// �݌ɏ���o�^�A�X�V���܂�
        /// </summary>
        /// <param name="stockWork">StockWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɏ���o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.18</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockWork,
            out string retMsg
            );
    }
}
