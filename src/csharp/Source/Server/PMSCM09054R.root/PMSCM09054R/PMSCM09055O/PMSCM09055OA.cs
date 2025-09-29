using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// SCM���ꉿ�i�ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350�@�N��@����</br>
	/// <br>Date       : 2009.05.08</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISCMMrktPriStDB
	{

		/// <summary>
        /// �w�肳�ꂽSCM���ꉿ�i�ݒ�}�X�^Guid��SCM���ꉿ�i�ݒ�}�X�^��߂��܂�
		/// </summary>
        /// <param name="parabyte">SCMMrktPriStWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽSCM���ꉿ�i�ݒ�}�X�^Guid��SCM���ꉿ�i�ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^���𕨗��폜���܂�
		/// </summary>
        /// <param name="parabyte">SCMMrktPriStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
        /// <param name="scmMrktPriStWork">��������</param>
		/// <param name="parastockmngttlstWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMSCM09056D", "Broadleaf.Application.Remoting.ParamData.SCMMrktPriStWork")]
			out object scmMrktPriStWork,
			object parastockmngttlstWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="scmMrktPriStWork">SCMMrktPriStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMSCM09056D", "Broadleaf.Application.Remoting.ParamData.SCMMrktPriStWork")]
			ref object scmMrktPriStWork
			);

		/// <summary>
        /// SCM���ꉿ�i�ݒ�}�X�^����_���폜���܂�
		/// </summary>
        /// <param name="scmMrktPriStWork">SCMMrktPriStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : SCM���ꉿ�i�ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09056D", "Broadleaf.Application.Remoting.ParamData.SCMMrktPriStWork")]
			ref object scmMrktPriStWork
			);

		/// <summary>
        /// �_���폜SCM���ꉿ�i�ݒ�}�X�^���𕜊����܂�
		/// </summary>
        /// <param name="scmMrktPriStWork">SCMMrktPriStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �_���폜SCM���ꉿ�i�ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.08</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09056D", "Broadleaf.Application.Remoting.ParamData.SCMMrktPriStWork")]
			ref object scmMrktPriStWork
			);
		#endregion
	}
}
