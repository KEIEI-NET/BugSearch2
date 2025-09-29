using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �L�����y�[���֘A�}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �L�����y�[���֘A�}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350�@�N��@����</br>
	/// <br>Date       : 2009.05.13</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignLinkDB
	{

		/// <summary>
        /// �w�肳�ꂽ�L�����y�[���֘A�}�X�^Guid�̃L�����y�[���֘A�}�X�^��߂��܂�
		/// </summary>
        /// <param name="parabyte">CampaignLinkWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�L�����y�[���֘A�}�X�^Guid�̃L�����y�[���֘A�}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
        /// �L�����y�[���֘A�}�X�^���𕨗��폜���܂�
		/// </summary>
        /// <param name="parabyte">CampaignLinkWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
        /// �L�����y�[���֘A�}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
        /// <param name="campaignLinkWork">��������</param>
        /// <param name="paracampaignLinkWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09576D", "Broadleaf.Application.Remoting.ParamData.CampaignLinkWork")]
			out object campaignLinkWork,
			object paracampaignLinkWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// �L�����y�[���֘A�}�X�^����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="campaignLinkWork">CampaignLinkWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09576D", "Broadleaf.Application.Remoting.ParamData.CampaignLinkWork")]
			ref object campaignLinkWork
			);

		/// <summary>
        /// �L�����y�[���֘A�}�X�^����_���폜���܂�
		/// </summary>
        /// <param name="campaignLinkWork">CampaignLinkWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���֘A�}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09576D", "Broadleaf.Application.Remoting.ParamData.CampaignLinkWork")]
			ref object campaignLinkWork
			);

		/// <summary>
        /// �_���폜�L�����y�[���֘A�}�X�^���𕜊����܂�
		/// </summary>
        /// <param name="campaignLinkWork">CampaignLinkWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�L�����y�[���֘A�}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.13</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09576D", "Broadleaf.Application.Remoting.ParamData.CampaignLinkWork")]
			ref object campaignLinkWork
			);
		#endregion
	}
}
