using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �L�����y�[���Ǘ��}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �L�����y�[���Ǘ��}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350�@�N��@����</br>
	/// <br>Date       : 2009.05.12</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICampaignMngDB
	{

		/// <summary>
        /// �w�肳�ꂽ�L�����y�[���Ǘ��}�X�^Guid�̃L�����y�[���Ǘ��}�X�^��߂��܂�
		/// </summary>
        /// <param name="parabyte">CampaignMngWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�L�����y�[���Ǘ��}�X�^Guid�̃L�����y�[���Ǘ��}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
        /// �L�����y�[���Ǘ��}�X�^���𕨗��폜���܂�
		/// </summary>
        /// <param name="parabyte">CampaignMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
        /// �L�����y�[���Ǘ��}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
        /// <param name="campaignMngWork">��������</param>
        /// <param name="paracampaignMngWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09607D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork")]
			out object campaignMngWork,
			object paracampaignMngWork, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// �L�����y�[���Ǘ��}�X�^����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="campaignMngWork">CampaignMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09607D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork")]
			ref object campaignMngWork
			);

		/// <summary>
        /// �L�����y�[���Ǘ��}�X�^����_���폜���܂�
		/// </summary>
        /// <param name="campaignMngWork">CampaignMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �L�����y�[���Ǘ��}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09607D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork")]
			ref object campaignMngWork
			);

		/// <summary>
        /// �_���폜�݃L�����y�[���Ǘ��}�X�^���𕜊����܂�
		/// </summary>
        /// <param name="campaignMngWork">CampaignMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�L�����y�[���Ǘ��}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.05.12</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09607D", "Broadleaf.Application.Remoting.ParamData.CampaignMngWork")]
			ref object campaignMngWork
			);
		#endregion
	}
}
