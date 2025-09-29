using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���i�}�X�^�i���[�U�[�o�^���jDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���jDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2007.01.24</br>
    /// <br></br>
    /// <br>Update Note: PM.NS�p�ɏC��</br>
    /// <br>Programmer : 20081�@�D�c �E�l</br>
    /// <br>Date       : 2008.06.06</br>
   	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IGoodsUDB
	{

		/// <summary>
		/// �w�肳�ꂽ���i�}�X�^�i���[�U�[�o�^���jGuid�̏��i�}�X�^�i���[�U�[�o�^���j��߂��܂�
		/// </summary>
		/// <param name="parabyte">GoodsUWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���i�}�X�^�i���[�U�[�o�^���jGuid�̏��i�}�X�^�i���[�U�[�o�^���j��߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.24</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// ���i�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">GoodsUWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j���𕨗��폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.24</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
		/// ���i�}�X�^�i���[�U�[�o�^���jLIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="goodsUWork">��������</param>
		/// <param name="paragoodsUWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.24</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("MAKHN09286D","Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			out object goodsUWork,
			object paragoodsUWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int Write(
			[CustomSerializationMethodParameterAttribute("MAKHN09286D","Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			ref object goodsUWork
			);

		/// <summary>
		/// ���i�}�X�^�i���[�U�[�o�^���j����_���폜���܂�
		/// </summary>
		/// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���i�}�X�^�i���[�U�[�o�^���j����_���폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int LogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAKHN09286D","Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			ref object goodsUWork
			);

		/// <summary>
		/// �_���폜���i�}�X�^�i���[�U�[�o�^���j���𕜊����܂�
		/// </summary>
		/// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���i�}�X�^�i���[�U�[�o�^���j���𕜊����܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.01.24</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
			[CustomSerializationMethodParameterAttribute("MAKHN09286D","Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			ref object goodsUWork
			);

        /// <summary>
        /// �w�肵�����i���}�X�^�ɑ��݂��Ȃ��ꍇ�ɐV�K�o�^���܂��B
        /// </summary>
        /// <param name="goodsUWork">GoodsUWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肵�����i���}�X�^�ɑ��݂��Ȃ��ꍇ�ɐV�K�o�^���܂��B</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.06</br>
        [MustCustomSerialization]
        int ReadWrite(
            [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
			ref object goodsUWork
            );
		#endregion


    }
}
