using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���i�Ǘ����}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i�Ǘ����}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2007.01.25</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IGoodsMngDB
	{

		/// <summary>
		/// �w�肳�ꂽ���i�Ǘ����}�X�^Guid�̏��i�Ǘ����}�X�^��߂��܂�
		/// </summary>
		/// <param name="parabyte">GoodsMngWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���i�Ǘ����}�X�^Guid�̏��i�Ǘ����}�X�^��߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.25</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// ���i�Ǘ����}�X�^���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">GoodsMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���i�Ǘ����}�X�^���𕨗��폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.25</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
		/// ���i�Ǘ����}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="goodsMngWork">��������</param>
		/// <param name="paragoodsMngWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.25</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAKHN09526D","Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
			out object goodsMngWork,
			object paragoodsMngWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���i�ԍ����o�^�̏��i�Ǘ����}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="goodsMngWork">��������</param>
        /// <param name="paragoodsMngWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int SearchNoneGoodsNo(
            [CustomSerializationMethodParameterAttribute("MAKHN09526D", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
			out object goodsMngWork,
            object paragoodsMngWork, int readMode, ConstantManagement.LogicalMode logicalMode);
            
        /// <summary>
		/// ���i�Ǘ����}�X�^����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="goodsMngWork">GoodsMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���i�Ǘ����}�X�^����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int Write(
			[CustomSerializationMethodParameterAttribute("MAKHN09526D","Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
			ref object goodsMngWork
			);

		/// <summary>
		/// ���i�Ǘ����}�X�^����_���폜���܂�
		/// </summary>
		/// <param name="goodsMngWork">GoodsMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���i�Ǘ����}�X�^����_���폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int LogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAKHN09526D","Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
			ref object goodsMngWork
			);

		/// <summary>
		/// �_���폜���i�Ǘ����}�X�^���𕜊����܂�
		/// </summary>
		/// <param name="goodsMngWork">GoodsMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���i�Ǘ����}�X�^���𕜊����܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.25</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAKHN09526D","Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
			ref object goodsMngWork
			);
		#endregion
	}
}
