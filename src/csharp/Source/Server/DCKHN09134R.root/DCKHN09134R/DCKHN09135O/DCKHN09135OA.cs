using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 20081�@�D�c�@�E�l</br>
	/// <br>Date       : 2007.09.18</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ICustSlipMngDB
	{

		/// <summary>
        /// �w�肳�ꂽ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^Guid�̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^��߂��܂�
		/// </summary>
        /// <param name="parabyte">CustSlipMngWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^Guid�̓��Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^��߂��܂�</br>
		/// <br>Programmer : 20081�@�D�c�@�E�l</br>
		/// <br>Date       : 2007.09.18</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���𕨗��폜���܂�
		/// </summary>
        /// <param name="parabyte">CustSlipMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���𕨗��폜���܂�</br>
		/// <br>Programmer : 20081�@�D�c�@�E�l</br>
		/// <br>Date       : 2007.09.18</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="custslipmngWork">��������</param>
		/// <param name="paracustslipmngWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 20081�@�D�c�@�E�l</br>
		/// <br>Date       : 2007.09.18</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("DCKHN09136D", "Broadleaf.Application.Remoting.ParamData.CustSlipMngWork")]
			out object custslipmngWork,
			object paracustslipmngWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="custslipmngWork">CustSlipMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 20081�@�D�c�@�E�l</br>
		/// <br>Date       : 2007.09.18</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("DCKHN09136D", "Broadleaf.Application.Remoting.ParamData.CustSlipMngWork")]
			ref object custslipmngWork
			);

		/// <summary>
        /// ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^����_���폜���܂�
		/// </summary>
        /// <param name="custslipmngWork">CustSlipMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^����_���폜���܂�</br>
		/// <br>Programmer : 20081�@�D�c�@�E�l</br>
		/// <br>Date       : 2007.09.18</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09136D", "Broadleaf.Application.Remoting.ParamData.CustSlipMngWork")]
			ref object custslipmngWork
			);

		/// <summary>
        /// �_���폜���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���𕜊����܂�
		/// </summary>
        /// <param name="custslipmngWork">CustSlipMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �_���폜���Ӑ�}�X�^(�`�[�Ǘ�)�}�X�^���𕜊����܂�</br>
		/// <br>Programmer : 20081�@�D�c�@�E�l</br>
		/// <br>Date       : 2007.09.18</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("DCKHN09136D", "Broadleaf.Application.Remoting.ParamData.CustSlipMngWork")]
			ref object custslipmngWork
			);
		#endregion
	}
}
