using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �[���Ǘ��}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �[���Ǘ��}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350�@�N��@����</br>
	/// <br>Date       : 2009.06.09</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPosTerminalMgDB
	{

		/// <summary>
        /// �w�肳�ꂽ�[���Ǘ��}�X�^Guid�̒[���Ǘ��}�X�^��߂��܂�
		/// </summary>
        /// <param name="parabyte">PosTerminalMgWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�[���Ǘ��}�X�^Guid�̒[���Ǘ��}�X�^��߂��܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.06.09</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
        /// �[���Ǘ��}�X�^���𕨗��폜���܂�
		/// </summary>
        /// <param name="parabyte">PosTerminalMgWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : SCM�D��ݒ�}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.06.09</br>
		int Delete(byte[] parabyte);

		#region �J�X�^���V���A���C�Y�Ή����\�b�h
		/// <summary>
        /// �[���Ǘ��}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
        /// <param name="scmPriorStWork">��������</param>
        /// <param name="parascmPriorStWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.06.09</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN09183D", "Broadleaf.Application.Remoting.ParamData.PosTerminalMgServerWork")]
			out object posTerminalMgWork,
           object paraposTerminalMgWork, int readMode, ConstantManagement.LogicalMode logicalMode);

		/// <summary>
        /// �[���Ǘ��}�X�^����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="scmPriorStWork">PosTerminalMgWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.06.09</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMKHN09183D", "Broadleaf.Application.Remoting.ParamData.PosTerminalMgServerWork")]
			ref object posTerminalMgWork
			);

		/// <summary>
        /// �[���Ǘ��}�X�^����_���폜���܂�
		/// </summary>
        /// <param name="scmPriorStWork">PosTerminalMgWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �[���Ǘ��}�X�^����_���폜���܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.06.09</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09183D", "Broadleaf.Application.Remoting.ParamData.PosTerminalMgServerWork")]
			ref object posTerminalMgWork
			);

		/// <summary>
        /// �_���폜�[���Ǘ��}�X�^���𕜊����܂�
		/// </summary>
        /// <param name="scmPriorStWork">PosTerminalMgWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �_���폜�[���Ǘ��}�X�^���𕜊����܂�</br>
        /// <br>Programmer : 30350�@�N��@����</br>
        /// <br>Date       : 2009.06.09</br>
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMKHN09183D", "Broadleaf.Application.Remoting.ParamData.PosTerminalMgServerWork")]
			ref object posTerminalMgWork
			);
		#endregion
	}
}
