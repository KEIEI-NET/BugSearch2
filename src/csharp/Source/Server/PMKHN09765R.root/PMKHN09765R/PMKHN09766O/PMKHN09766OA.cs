using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �i�ԕϊ��}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �i�ԕϊ��}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2014/12/23</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IGoodsNoChangeDB
	{

		/// <summary>
		/// �w�肳�ꂽ�i�ԕϊ��}�X�^Guid�̕i�ԕϊ��}�X�^��߂��܂�
		/// </summary>
		/// <param name="parabyte">GoodsNoChangeWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�i�ԕϊ��}�X�^Guid�̕i�ԕϊ��}�X�^��߂��܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        int Read(ref byte[] parabyte, int readMode);

		/// <summary>
		/// �i�ԕϊ��}�X�^���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">GoodsNoChangeWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �i�ԕϊ��}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
		/// �i�ԕϊ��}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="goodsNoChangeWork">��������</param>
		/// <param name="paragoodsNoChangeWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork")]
			out object goodsNoChangeWork,
			object paragoodsNoChangeWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
		/// �i�ԕϊ��}�X�^����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="goodsNoChangeWork">GoodsNoChangeWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �i�ԕϊ��}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork")]
			ref object goodsNoChangeWork
			);

		/// <summary>
		/// �i�ԕϊ��}�X�^����_���폜���܂�
		/// </summary>
		/// <param name="goodsNoChangeWork">GoodsNoChangeWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �i�ԕϊ��}�X�^����_���폜���܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork")]
			ref object goodsNoChangeWork
			);

		/// <summary>
		/// �_���폜�i�ԕϊ��}�X�^���𕜊����܂�
		/// </summary>
		/// <param name="goodsNoChangeWork">GoodsNoChangeWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�i�ԕϊ��}�X�^���𕜊����܂�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork")]
			ref object goodsNoChangeWork
			);

        #endregion
	}
}
