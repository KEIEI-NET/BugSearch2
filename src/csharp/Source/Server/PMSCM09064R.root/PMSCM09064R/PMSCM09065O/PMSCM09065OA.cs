using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// SCM�D��ݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : SCM�D��ݒ�}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350�@�N��@����</br>
	/// <br>Date       : 2009.05.12</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISCMPriorStDB
	{

		/// <summary>
        /// �w�肳�ꂽSCM�D��ݒ�}�X�^Guid��SCM�D��ݒ�}�X�^��߂��܂�
		/// </summary>
        /// <param name="parabyte">SCMPriorStWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽSCM�D��ݒ�}�X�^Guid��SCM�D��ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
		int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// �w�肳�ꂽSCM�D��ݒ�}�X�^Guid��SCM�D��ݒ�}�X�^��߂��܂�(PCCUOE)
        /// </summary>
        /// <param name="parabyte">SCMPriorStWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽSCM�D��ݒ�}�X�^Guid��SCM�D��ݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : LIUSY</br>
        /// <br>Date       : 2011.08.10</br>
        int ReadPCCUOE(ref byte[] parabyte, int readMode);

		/// <summary>
        /// SCM�D��ݒ�}�X�^���𕨗��폜���܂�
		/// </summary>
        /// <param name="parabyte">SCMPriorStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���𕨗��폜���܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.03.02</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
        /// SCM�D��ݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
        /// <param name="scmPriorStWork">��������</param>
        /// <param name="parascmPriorStWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMSCM09066D", "Broadleaf.Application.Remoting.ParamData.SCMPriorStWork")]
			out object scmPriorStWork,
			object parascmPriorStWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// SCM�D��ݒ�}�X�^����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMSCM09066D", "Broadleaf.Application.Remoting.ParamData.SCMPriorStWork")]
			ref object scmPriorStWork
			);

		/// <summary>
        /// SCM�D��ݒ�}�X�^����_���폜���܂�
		/// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09066D", "Broadleaf.Application.Remoting.ParamData.SCMPriorStWork")]
			ref object scmPriorStWork
			);

		/// <summary>
        /// �_���폜SCM�D��ݒ�}�X�^���𕜊����܂�
		/// </summary>
        /// <param name="scmPriorStWork">StockMngTtlStWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �_���폜SCM�D��ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09066D", "Broadleaf.Application.Remoting.ParamData.SCMPriorStWork")]
			ref object scmPriorStWork
			);
		#endregion
	}
}
