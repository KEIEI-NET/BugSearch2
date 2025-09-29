using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �`�[����ݒ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �`�[����ݒ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22027�@���{�@����</br>
	/// <br>Date       : 2005.08.30</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ISlipPrtSetDB
	{
		/// <summary>
		/// �`�[����ݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFURI09026D","Broadleaf.Application.Remoting.ParamData.SlipPrtSetWork")]
			out object retobj,
			object paraobj,
			int readMode,ConstantManagement.LogicalMode logicalMode);
					
		/// <summary>
		/// �w�肳�ꂽ�`�[����ݒ�Guid�̓`�[����ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�`�[����ݒ�Guid�̓`�[����ݒ��߂��܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// �`�[����ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �`�[����ݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// �`�[����ݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �`�[����ݒ���𕨗��폜���܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// �`�[����ݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �`�[����ݒ����_���폜���܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// �_���폜�`�[����ݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">SlipPrtSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�`�[����ݒ���𕜊����܂�</br>
		/// <br>Programmer : 22027�@���{�@����</br>
		/// <br>Date       : 2005.08.30</br>
		int RevivalLogicalDelete(ref byte[] parabyte);
	}
}
