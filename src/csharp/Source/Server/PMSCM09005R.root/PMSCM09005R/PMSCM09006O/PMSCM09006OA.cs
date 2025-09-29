using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// SCM�i�ڐݒ�}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : SCM�i�ڐݒ�}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350�@�N��@����</br>
	/// <br>Date       : 2009.04.27</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISCMPrtSettingDB
	{

		/// <summary>
		/// �w�肳�ꂽSCM�i�ڐݒ�}�X�^Guid��SCM�i�ڐݒ�}�X�^��߂��܂�
		/// </summary>
        /// <param name="parabyte">SCMPrtSettingWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽSCM�i�ڐݒ�}�X�^Guid��SCM�i�ڐݒ�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
		/// <br>Date       : 2009.04.27</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// SCM�i�ڐݒ�}�X�^���𕨗��폜���܂�
		/// </summary>
        /// <param name="parabyte">SCMPrtSettingWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^���𕨗��폜���܂�</br>
		/// <br>Programmer : 30350�@�N��@����</br>
		/// <br>Date       : 2009.04.27</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
        /// SCM�i�ڐݒ�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
        /// <param name="scmPrtSettingWork">��������</param>
        /// <param name="parascmPrtSettingWork">�����p�����[�^</param>
        /// <param name="scmPrtSettingOrderWork">���o�����N���X</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 30350�@�N��@����</br>
		/// <br>Date       : 2009.04.27</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMSCM09007D", "Broadleaf.Application.Remoting.ParamData.SCMPrtSettingWork")]
			out object scmPrtSettingWork,
           object parascmPrtSettingWork, int readMode, ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// SCM�i�ڐݒ�}�X�^����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="scmPrtSettingWork">SCMPrtSettingWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMSCM09007D", "Broadleaf.Application.Remoting.ParamData.SCMPrtSettingWork")]
			ref object scmPrtSettingWork
			);

		/// <summary>
		/// �݌ɊǗ��S�̐ݒ�}�X�^����_���폜���܂�
		/// </summary>
        /// <param name="scmPrtSettingWork">SCMPrtSettingWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɊǗ��S�̐ݒ�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09007D", "Broadleaf.Application.Remoting.ParamData.SCMPrtSettingWork")]
			ref object scmPrtSettingWork
			);

		/// <summary>
		/// �_���폜�݌ɊǗ��S�̐ݒ�}�X�^���𕜊����܂�
		/// </summary>
        /// <param name="stockmngttlstWork">SCMPrtSettingWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�݌ɊǗ��S�̐ݒ�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.04.27</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMSCM09007D", "Broadleaf.Application.Remoting.ParamData.SCMPrtSettingWork")]
			ref object scmPrtSettingWork
			);
		#endregion
	}
}
