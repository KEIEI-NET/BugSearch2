using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �����񓚕i�ڐݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �����񓚕i�ڐݒ�}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30745�@�g���@�F��</br>
    /// <br>Date       : 2012/10/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAutoAnsItemStDB
	{
        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="AutoAnsItemStWork">��������</param>
        /// <param name="parabyte">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        int Read2(
            out object AutoAnsItemStWork,
            byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="AutoAnsItemStWork">��������</param>
        /// <param name="parabyte">AutoAnsItemStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        int Read3(
            out object AutoAnsItemStWork,
            byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
		/// �����񓚕i�ڐݒ�}�X�^���𕨗��폜���܂�
		/// </summary>
        /// <param name="parabyte">AutoAnsItemStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �����񓚕i�ڐݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="AutoAnsItemStWork">��������</param>
        /// <param name="paraAutoAnsItemStWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09707D", "Broadleaf.Application.Remoting.ParamData.AutoAnsItemStWork")]
			out object AutoAnsItemStWork,
           object paraAutoAnsItemStWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
		/// �����񓚕i�ڐݒ�}�X�^����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="AutoAnsItemStWork">AutoAnsItemStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����o�^�A�X�V���܂�</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09707D", "Broadleaf.Application.Remoting.ParamData.AutoAnsItemStWork")]
			ref object AutoAnsItemStWork
			);

		/// <summary>
		/// �݌ɊǗ��S�̐ݒ�}�X�^����_���폜���܂�
		/// </summary>
        /// <param name="AutoAnsItemStWork">AutoAnsItemStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����_���폜���܂�</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09707D", "Broadleaf.Application.Remoting.ParamData.AutoAnsItemStWork")]
			ref object AutoAnsItemStWork
			);

		/// <summary>
		/// �_���폜�݌ɊǗ��S�̐ݒ�}�X�^���𕜊����܂�
		/// </summary>
        /// <param name="AutoAnsItemStWork">AutoAnsItemStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�݌ɊǗ��S�̐ݒ�}�X�^���𕜊����܂�</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09707D", "Broadleaf.Application.Remoting.ParamData.AutoAnsItemStWork")]
			ref object AutoAnsItemStWork
			);
		#endregion
	}
}
